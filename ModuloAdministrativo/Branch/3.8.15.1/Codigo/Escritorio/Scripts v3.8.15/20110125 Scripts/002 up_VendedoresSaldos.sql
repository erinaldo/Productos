USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos]    Script Date: 01/25/2011 11:09:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldos]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldosIns]    Script Date: 01/25/2011 11:09:52 ******/
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
@UltimaFecha as datetime,
@FechaValidar as datetime,
@IdSurtidoN as bigint

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
		
			--update VendedoresCargosAbonos set IdSurtido = 0
			--where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha > @Fecha and IdTipoSaldo = 'EF'
			
			delete from VendedoresSaldos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha >= @Fecha and IdTipoSaldo = 'EF'

			if @IdSurtido = 0
			select top 1 @IdSurtido = isnull(Surtidos.IdSurtido, 0)
			from Surtidos 
			inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
			where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha
			order by Surtidos.IdSurtido desc
			
-- ************ Obtiene Último movmiento del vendedor 

			select @UltimaFecha  = @Fecha 
			select @FechaValidar = @Fecha 
			
			if exists( select Fecha from VendedoresSaldos where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha < @Fecha and IdTipoSaldo = 'EF' )
			begin 
				select top 1 @FechaValidar = Fecha 
				from VendedoresSaldos 
				where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha < @Fecha and IdTipoSaldo = 'EF' 
				order by IdVendedor, Fecha desc

				if @FechaValidar < @UltimaFecha set @UltimaFecha = @FechaValidar 
			end
			else
			begin
				select top 1 @FechaValidar = Fecha 
				from VendedoresCargosAbonos 
				where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha < @Fecha  
				order by Fecha asc 
				
				if @FechaValidar < @UltimaFecha set @UltimaFecha = @FechaValidar 

				select top 1 @FechaValidar = Surtidos.Fecha  
				from Surtidos 
				inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
				where Surtidos.IdCedis = @IdCedis and IdVendedor = @IdVendedor and Surtidos.Fecha < @Fecha 
				order by Surtidos.Fecha asc 
				
				if @FechaValidar < @UltimaFecha set @UltimaFecha = @FechaValidar 
			end

			select @Dias = DATEDIFF(day, @UltimaFecha, @Fecha) 
			select @FechaTrabajo = @UltimaFecha - 1

			while @Dias > 0
			begin 

				select @FechaTrabajo = @FechaTrabajo + 1

				if exists( select Surtidos.IdSurtido
					from Surtidos 
					inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
					where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @FechaTrabajo)
				begin 
					declare  SurtidosSaldos cursor for
						select Surtidos.IdSurtido
						from Surtidos 
						inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
						where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @FechaTrabajo 
						order by Surtidos.Fecha, Surtidos.IdSurtido 
					open SurtidosSaldos
					
					fetch next from SurtidosSaldos into @IdSurtidoN
					while (@@fetch_status = 0)
					begin

						-- Ejecuta InsertaSaldo
						exec up_VendedoresSaldosIns @IdCedis, @IdSurtidoN, @IdVendedor, @FechaTrabajo, 1
			
						fetch next from SurtidosSaldos into @IdSurtidoN
					end
					close SurtidosSaldos
					deallocate SurtidosSaldos		
				end
				else
				begin 
					-- Ejecuta InsertaSaldo
					exec up_VendedoresSaldosIns @IdCedis, 0, @IdVendedor, @FechaTrabajo, 1
				end				
				
				set @Dias = @Dias - 1
			end

-- ************ Obtiene Movmientos Actuales del vendedor 
			
			declare  SurtidosSaldos cursor for
				select Surtidos.IdSurtido
				from Surtidos 
				inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
				where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha and Surtidos.IdSurtido <> @IdSurtido
				order by Surtidos.Fecha, Surtidos.IdSurtido 
			open SurtidosSaldos
			
			fetch next from SurtidosSaldos into @IdSurtidoN
			while (@@fetch_status = 0)
			begin

				-- Ejecuta InsertaSaldo
				exec up_VendedoresSaldosIns @IdCedis, @IdSurtidoN, @IdVendedor, @Fecha, 1
	
				fetch next from SurtidosSaldos into @IdSurtidoN
			end
			close SurtidosSaldos
			deallocate SurtidosSaldos		

-- ************ Surtido Actual del vendedor 

			-- Ejecuta InsertaSaldo
			exec up_VendedoresSaldosIns @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1

-- ************ Obtiene Movmientos Posteriores del vendedor 
					
			set @UltimaFecha = @Fecha
			select top 1 @UltimaFecha = isnull(Fecha, @Fecha) 
			from VendedoresSaldos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha > @Fecha and IdTipoSaldo = 'EF' 
			order by IdVendedor, Fecha desc
			
			set @FechaValidar = '19000101'
			select top 1 @FechaValidar = Surtidos.Fecha  
			from Surtidos 
			inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
			where Surtidos.IdCedis = @IdCedis and IdVendedor = @IdVendedor 
			order by Surtidos.Fecha desc 
			
			if @FechaValidar > @UltimaFecha set @UltimaFecha = @FechaValidar 

			select top 1 @FechaValidar = Fecha 
			from VendedoresCargosAbonos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor 
			order by Fecha desc 
			
			if @FechaValidar > @UltimaFecha set @UltimaFecha = @FechaValidar 

			if @UltimaFecha is null
				select @Dias = 0
			else
				select @Dias = DATEDIFF(day, @Fecha, @UltimaFecha) 

			select @FechaTrabajo = @Fecha 

			while @Dias > 0	
			begin 

				select @FechaTrabajo = @FechaTrabajo + 1
				
				if exists(select Surtidos.IdSurtido
						from Surtidos 
						inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
						where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @FechaTrabajo and Surtidos.IdSurtido <> @IdSurtido)
				begin
					declare  SurtidosSaldos cursor for
						select Surtidos.IdSurtido
						from Surtidos 
						inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
						where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @FechaTrabajo and Surtidos.IdSurtido <> @IdSurtido
						order by Surtidos.Fecha, Surtidos.IdSurtido 
					open SurtidosSaldos
					
					fetch next from SurtidosSaldos into @IdSurtidoN
					while (@@fetch_status = 0)
					begin

						-- Ejecuta InsertaSaldo
						exec up_VendedoresSaldosIns @IdCedis, @IdSurtidoN, @IdVendedor, @FechaTrabajo, 1
			
						fetch next from SurtidosSaldos into @IdSurtidoN
					end
					close SurtidosSaldos
					deallocate SurtidosSaldos
				end		
				else
				begin 
					-- Ejecuta InsertaSaldo
					exec up_VendedoresSaldosIns @IdCedis, 0, @IdVendedor, @FechaTrabajo, 1
				end
				set @Dias = @Dias - 1
			end

		end
	end
end


GO

