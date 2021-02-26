
declare 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdVendedor as bigint,
@IdRuta as bigint,
@Fecha as datetime,
@BorrarSaldos as char(1),
@IdCargoAbono as bigint

set @IdCedis = 2
set @Fecha = '20101120'
set @IdVendedor = 3251
set @IdRuta = 737
set @BorrarSaldos = 'S'

if @BorrarSaldos = 'S'
begin

	declare  ActSaldos cursor for
		select IdVendedor, Fecha, IdCargoAbono
		from VendedoresCargosAbonos 
		order by IdVendedor, Fecha  
	open ActSaldos

	fetch next from ActSaldos into @IdVendedor, @Fecha, @IdCargoAbono
	while (@@fetch_status = 0)
	begin
		
		select top 1 @IdSurtido = Surtidos.IdSurtido 
		from Surtidos 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido
		where Surtidos.IdCedis = @IdCedis and IdVendedor = @IdVendedor and Surtidos.Fecha = @Fecha 
		order by Surtidos.IdSurtido asc
		
		select @IdCedis, @IdVendedor, @Fecha, @IdCargoAbono, @IdSurtido 
		-- update VendedoresCargosAbonos 
			
		
		fetch next from ActSaldos into @IdVendedor, @Fecha, @IdCargoAbono
	end
	close ActSaldos
	deallocate ActSaldos		
end


