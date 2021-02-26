USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos]    Script Date: 12/18/2010 13:16:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos]    Script Date: 12/18/2010 13:16:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[up_VendedoresSaldos] 
@IdCedis as bigint,
@IdSurtido as varchar(20),
@IdVendedor as varchar(10),
@Fecha as datetime,
@Opc as int
AS

declare @Efectivo as money, @LiquidacionEfectivo as char(1)
declare @SaldoAnterior as money, @VentaContado as money, @Otros as money


if @Opc = 1
begin

set @LiquidacionEfectivo = (select LiquidacionSaldoVendedor from Configuracion where IdCedis = @IdCedis )

if @LiquidacionEfectivo = 'S'
	begin
		delete 
		from VendedoresSaldos
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoSaldo = 'EF' and Fecha = @Fecha
		
		set @Efectivo = 0		
		select @Efectivo = isnull(sum(IdDenominacion * SurtidosDenominacion.Cantidad * ISNULL(TipoDeCambio.TipoCambio,1)), 0)
		from SurtidosDenominacion
		inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
		left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosDenominacion.IdMoneda 
		where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido
		
		select @Efectivo = @Efectivo + isnull(sum(Importe * ISNULL(TipoDeCambio.TipoCambio,1)),0)
		from SurtidosCheque 
		inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
		left outer join TipoDeCambio on TipoDeCambio.Fecha = Surtidos.Fecha and TipoDeCambio.IdMoneda = SurtidosCheque.IdMoneda 
		where SurtidosCheque.IdCedis = @IdCedis and SurtidosCheque.IdSurtido = @IdSurtido

		set @SaldoAnterior = 0
		select top 1 @SaldoAnterior = isnull(SaldoActual,0)
		from  VendedoresSaldos 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido
		order by Fecha desc, IdSurtido desc

		set @VentaContado = 0
		select @VentaContado = ISNULL(sum(Total),0)
		from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and IdTipoVenta = 1

		if exists(select IdVendedor from VendedoresCargosAbonos where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and ( IdSurtido = 0 or IdSurtido = @IdSurtido ) )
		begin
			update VendedoresCargosAbonos set IdSurtido = @IdSurtido 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and ( IdSurtido = 0 or IdSurtido = @IdSurtido )
		end

		set @Otros = 0
		select @Otros = isnull(sum(Importe),0)
		from VendedoresCargosAbonos 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and IdSurtido = @IdSurtido

		insert into VendedoresSaldos 
		select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, Surtidos.IdRuta, 'EF', SurtidosVendedor.IdVendedor, @Fecha, @SaldoAnterior, @Efectivo - @VentaContado, @Otros, @SaldoAnterior + @Efectivo - @VentaContado + @Otros 
		from VentasDetalle
		inner join SurtidosVendedor on VentasDetalle.IdCedis = SurtidosVendedor.IdCedis and VentasDetalle.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
		inner join Surtidos on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
		group by VentasDetalle.IdCedis, VentasDetalle.IdSurtido, SurtidosVendedor.IdVendedor, Surtidos.IdRuta

		--select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, Surtidos.IdRuta, 'EF', SurtidosVendedor.IdVendedor, @Fecha, 
		--isnull((select top 1 SaldoActual
		--from  VendedoresSaldos 
		--where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido
		--order by Fecha desc, IdSurtido desc), 0),

		--@Efectivo - isnull(( select sum(Total)
		--from VentasDetalle 
		--where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and IdTipoVenta = 1), 0), 

		--isnull((select Otros from VendedoresSaldos 
		--where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' ),0), 

		--isnull((select top 1 SaldoActual
		--from  VendedoresSaldos 
		--where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido
		--order by Fecha desc, IdSurtido desc), 0) +
		--isnull((select Otros from VendedoresSaldos 
		--where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' ),0) + 
		--@Efectivo - isnull(( select sum(Total)
		--from VentasDetalle 
		--where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and IdTipoVenta = 1), 0)

		--from VentasDetalle
		--inner join SurtidosVendedor on VentasDetalle.IdCedis = SurtidosVendedor.IdCedis and VentasDetalle.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
		--inner join Surtidos on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		--where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
		--group by VentasDetalle.IdCedis, VentasDetalle.IdSurtido, SurtidosVendedor.IdVendedor, Surtidos.IdRuta
	end
end








GO


