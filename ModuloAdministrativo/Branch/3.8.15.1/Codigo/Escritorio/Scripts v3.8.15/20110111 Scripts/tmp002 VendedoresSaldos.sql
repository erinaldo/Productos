declare  
@IdCedis as bigint,
@IdSurtido as varchar(20),
@IdVendedor as varchar(10),
@Fecha as datetime,
@Opc as int



declare @Efectivo as money, @LiquidacionEfectivo as char(1), @IdRuta as bigint
declare @SaldoAnterior as money, @VentaContado as money, @Otros as money
declare 
@Dias as bigint,
@FechaTrabajo as datetime,
@UltimaFecha as datetime,
@FechaCargoAbono as datetime,
@IdSurtidoN as bigint

set @IdCedis = 2 
set @IdSurtido = 0
set @IdVendedor = 82
set @Opc = 1
set @Fecha = '20110113'

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
			
			--update VendedoresCargosAbonos set IdSurtido = 0
			--where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and IdSurtido in (0, @IdSurtido)

			--delete from VendedoresSaldos 
			--where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = 'EF' and IdSurtido in (0, @IdSurtido)

			select top 1 @UltimaFecha = Fecha 
			from VendedoresSaldos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha < @Fecha and IdTipoSaldo = 'EF' 
			order by IdVendedor, Fecha desc

			select @Dias = DATEDIFF(day, @UltimaFecha, @Fecha) 
			select @FechaTrabajo = @UltimaFecha 

			while @Dias > 1	
			begin 

				select @FechaTrabajo = @FechaTrabajo + 1
				
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
				
				set @Dias = @Dias - 1
			end
			
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

			-- Ejecuta InsertaSaldo
			exec up_VendedoresSaldosIns @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1
		
			
			set @UltimaFecha = @Fecha
			select top 1 @UltimaFecha = isnull(Fecha, @Fecha) 
			from VendedoresSaldos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha > @Fecha and IdTipoSaldo = 'EF' 
			order by IdVendedor, Fecha desc
			
			set @FechaCargoAbono = '19000101'
			select top 1 @FechaCargoAbono = Fecha 
			from VendedoresCargosAbonos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor 
			order by Fecha desc 
			
			if @FechaCargoAbono > @UltimaFecha set @UltimaFecha = @FechaCargoAbono 
			
			set @FechaCargoAbono = '19000101'
			select top 1 @FechaCargoAbono = Surtidos.Fecha 
			from Surtidos 
			inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = @IdVendedor
			where Surtidos.IdCedis = @IdCedis 
			order by Surtidos.Fecha desc

			if @FechaCargoAbono > @UltimaFecha set @UltimaFecha = @FechaCargoAbono 

			if @UltimaFecha is null
				select @Dias = 0
			else
				select @Dias = DATEDIFF(day, @Fecha, @UltimaFecha) 

			select @FechaTrabajo = @Fecha 

			while @Dias > 0	
			begin 

				select @FechaTrabajo = @FechaTrabajo + 1
				
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
				
				set @Dias = @Dias - 1
			end

		end
	end
end

GO


