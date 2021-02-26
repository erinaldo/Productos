declare 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdVendedor as bigint,
@IdRuta as bigint,
@Fecha as datetime,
@BorrarSaldos as char(1),
@FechaInicial as datetime,
@FechaFinal as datetime

-- Florido Fecha = '20101120'
-- Mexicali Fecha = '20110102'

set @IdCedis = 2
set @Fecha = '20101121'
set @FechaInicial = '20101121'
set @FechaFinal = '20110126'
set @IdVendedor = 2779
set @IdRuta = 722
set @BorrarSaldos = 'S'

	create table #tempSaldoActual(IdCedis bigint, IdSurtido bigint, IdRuta bigint, IdTipoSaldo varchar(2), 
		IdVendedor bigint, Fecha datetime, SaldoAnterior float, Saldo float, Otros float, SaldoActual float)

	declare  ActSaldos cursor for
		select distinct Surtidos.IdCedis, SurtidosVendedor.IdVendedor
		from Surtidos 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 		
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha > @Fecha --and SurtidosVendedor.IdVendedor = @IdVendedor
		order by SurtidosVendedor.IdVendedor
	open ActSaldos

	fetch next from ActSaldos into @IdCedis, @IdVendedor
	while (@@fetch_status = 0)
	begin

		select @IdSurtido = 0, @Fecha = '19000101'

		insert into #tempSaldoActual
		select top 1 *
		from VendedoresSaldos
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor 
		order by Fecha desc, IdSurtido desc

		fetch next from ActSaldos into @IdCedis, @IdVendedor
	end
	close ActSaldos
	deallocate ActSaldos		
	
	select * from #tempSaldoActual
	drop table #tempSaldoActual
	