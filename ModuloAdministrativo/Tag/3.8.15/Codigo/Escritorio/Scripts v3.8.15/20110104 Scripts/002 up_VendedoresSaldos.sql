USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos]    Script Date: 01/04/2011 09:31:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos]    Script Date: 01/04/2011 09:31:28 ******/
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

declare @Efectivo as money, @LiquidacionEfectivo as char(1), @IdRuta as bigint
declare @SaldoAnterior as money, @VentaContado as money, @Otros as money
declare 
@Dias as bigint,
@FechaTrabajo as datetime,
@UltimaFecha as datetime

if @Opc = 1
begin

set @LiquidacionEfectivo = (select LiquidacionSaldoVendedor from Configuracion where IdCedis = @IdCedis )

if @LiquidacionEfectivo = 'S'
	begin

		if @IdVendedor = 0 and @IdSurtido <> 0
			select top 1 @IdVendedor = isnull(SurtidosVendedor.IdVendedor, 0)
			from Surtidos 
			inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
			where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido
			order by IdTipoVendedor 
			
		if @IdVendedor <> 0
		begin
			select top 1 @UltimaFecha = Fecha 
			from VendedoresSaldos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha < @Fecha and IdTipoSaldo = 'EF' 
			order by IdVendedor, Fecha desc

			select @Dias = DATEDIFF(day, @UltimaFecha, @Fecha) 
			select @FechaTrabajo = @UltimaFecha 

			while @Dias > 1	
			begin 

				select @FechaTrabajo = @FechaTrabajo + 1
				
				set @SaldoAnterior = 0
				select top 1 @SaldoAnterior = isnull(SaldoActual,0)
				from  VendedoresSaldos 
				where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido and Fecha < @FechaTrabajo 
				order by Fecha desc, IdSurtido desc

				set @Otros = 0
				select @Otros = isnull(sum(Importe),0)
				from VendedoresCargosAbonos 
				where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @FechaTrabajo and IdTipoSaldo = 'EF' 

				insert into VendedoresSaldos 
				select @IdCedis, 0, 0, 'EF', @IdVendedor, @FechaTrabajo, @SaldoAnterior, 0, @Otros, @SaldoAnterior + @Otros 
				
				set @Dias = @Dias - 1
			end

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

			select top 1 @IdRuta = isnull(Surtidos.IdRuta, 0)
			from Surtidos 
			inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
			where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido

			insert into VendedoresSaldos values (@IdCedis, @IdSurtido, @IdRuta, 'EF', @IdVendedor, @Fecha, @SaldoAnterior, @Efectivo - @VentaContado, @Otros, @SaldoAnterior + @Efectivo - @VentaContado + @Otros )

			set @UltimaFecha = @Fecha
			
			select top 1 @UltimaFecha = isnull(Fecha, @Fecha) 
			from VendedoresSaldos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha > @Fecha and IdTipoSaldo = 'EF' 
			order by IdVendedor, Fecha desc

			if @UltimaFecha is null
				select @Dias = 0
			else
				select @Dias = DATEDIFF(day, @Fecha, @UltimaFecha) 

			select @FechaTrabajo = @Fecha 

			while @Dias > 0	
			begin 

				select @FechaTrabajo = @FechaTrabajo + 1
				
				select @Fecha = @FechaTrabajo 
				
				select @IdSurtido = 0
				select @IdSurtido = isnull(Surtidos.IdSurtido, 0)
				from Surtidos 
				inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
				where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha
				
				delete 
				from VendedoresSaldos
				where IdCedis = @IdCedis and (IdSurtido = @IdSurtido or IdSurtido = 0) and IdTipoSaldo = 'EF' and Fecha = @Fecha
				
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
				where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' and IdSurtido <> @IdSurtido and Fecha < @Fecha 
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

				select @IdRuta = isnull(Surtidos.IdRuta, 0)
				from Surtidos 
				inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
				where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido

				insert into VendedoresSaldos values (@IdCedis, @IdSurtido, @IdRuta, 'EF', @IdVendedor, @Fecha, @SaldoAnterior, @Efectivo - @VentaContado, @Otros, @SaldoAnterior + @Efectivo - @VentaContado + @Otros )
				
				set @Dias = @Dias - 1
			end

		end
	end
end










GO


