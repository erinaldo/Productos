USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos]    Script Date: 02/08/2011 10:09:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos]    Script Date: 02/08/2011 10:09:14 ******/
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

if @Opc = 1
begin

set @LiquidacionEfectivo = (select LiquidacionSaldoVendedor from Configuracion where IdCedis = @IdCedis )

if @LiquidacionEfectivo = 'S'
	begin
		delete 
		from VendedoresSaldos
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and (IdSurtido = @IdSurtido or IdSurtido = 0) and IdTipoSaldo = 'EF'
		and Fecha = @Fecha
		
		select @Efectivo = isnull(sum(IdDenominacion * SurtidosDenominacion.Cantidad), 0)
		from SurtidosDenominacion
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido	

		select @Efectivo = @Efectivo + isnull(sum(Importe),0)
		from SurtidosCheque 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido	

		insert into VendedoresSaldos 
		
		select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, Surtidos.IdRuta, 'EF', SurtidosVendedor.IdVendedor, @Fecha, 
		isnull((select top 1 SaldoActual
		from  VendedoresSaldos 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido
		order by Fecha desc), 0),

		@Efectivo - isnull(( select sum(Total)
		from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and IdTipoVenta = 1), 0), 

		isnull((select SUM(Importe) from VendedoresCargosAbonos  
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' ),0), 

		isnull((select top 1 SaldoActual
		from  VendedoresSaldos 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido
		order by Fecha desc, IdSurtido desc), 0) +
		isnull((select SUM(Importe) from VendedoresCargosAbonos  
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' ),0) + 
		@Efectivo - isnull(( select sum(Total)
		from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and IdTipoVenta = 1), 0)

		from VentasDetalle
		inner join SurtidosVendedor on VentasDetalle.IdCedis = SurtidosVendedor.IdCedis and VentasDetalle.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
		inner join Surtidos on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
		group by VentasDetalle.IdCedis, VentasDetalle.IdSurtido, SurtidosVendedor.IdVendedor, Surtidos.IdRuta
	end
end








GO


