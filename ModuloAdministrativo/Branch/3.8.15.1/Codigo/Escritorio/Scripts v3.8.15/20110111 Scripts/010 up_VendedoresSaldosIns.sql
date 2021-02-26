USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos]    Script Date: 01/14/2011 11:00:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldosIns]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldosIns]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosIns]    Script Date: 01/14/2011 11:00:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[up_VendedoresSaldosIns] 
@IdCedis as bigint,
@IdSurtido as varchar(20),
@IdVendedor as varchar(10),
@Fecha as datetime,
@Opc as int
AS

declare @Efectivo as money, @LiquidacionEfectivo as char(1), @IdRuta as bigint
declare @SaldoAnterior as money, @VentaContado as money, @Otros as money
declare @FechaCargoAbono as datetime

if @Opc = 1
begin

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
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido and Fecha <= @Fecha 
			order by Fecha desc, IdSurtido desc

			set @VentaContado = 0
			select @VentaContado = ISNULL(sum(Total),0)
			from VentasDetalle 
			where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and IdTipoVenta = 1

			if exists(select IdVendedor from VendedoresCargosAbonos where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and IdSurtido = 0)
			begin
				update VendedoresCargosAbonos set IdSurtido = @IdSurtido 
				where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and IdSurtido = 0
			end

			set @Otros = 0
			select @Otros = isnull(sum(Importe),0)
			from VendedoresCargosAbonos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and IdSurtido = @IdSurtido

			set @IdRuta = 0
			select top 1 @IdRuta = isnull(Surtidos.IdRuta, 0)
			from Surtidos 
			inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
			where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido
			order by Surtidos.IdSurtido desc

			insert into VendedoresSaldos values (@IdCedis, @IdSurtido, @IdRuta, 'EF', @IdVendedor, @Fecha, @SaldoAnterior, @Efectivo - @VentaContado, @Otros, @SaldoAnterior + @Efectivo - @VentaContado + @Otros )
end
