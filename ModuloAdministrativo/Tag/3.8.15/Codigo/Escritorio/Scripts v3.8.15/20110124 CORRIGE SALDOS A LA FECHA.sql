
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
-- Mexicali Fecha = '20110101'
-- San Quintín Fecha = '20110131'

set @IdCedis = 4
set @Fecha = '20110131'
set @FechaInicial = '20110201'
set @FechaFinal = '20110201'
set @IdVendedor = 2902
set @IdRuta = 722
set @BorrarSaldos = 'S'

--update VendedoresSaldos set SaldoAnterior = Saldo, Saldo = 0 where IdSurtido = 0 and Fecha = '20101120'

if @BorrarSaldos = 'S'
begin

	delete from VendedoresSaldos where IdCedis = IdCedis and (Fecha > @Fecha or (Fecha = @Fecha and IdSurtido <> 0)) --and IdVendedor = @IdVendedor 

	update VendedoresCargosAbonos set IdSurtido = 0 where IdCedis = @IdCedis and Fecha between @FechaInicial and @FechaFinal --and IdVendedor = @IdVendedor 
--end
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

		select top 1 @IdSurtido = Surtidos.IdSurtido, @Fecha = Surtidos.Fecha
		from Surtidos 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		where Surtidos.IdCedis = @IdCedis and SurtidosVendedor.IdVendedor = @IdVendedor 
		order by Surtidos.Fecha desc, Surtidos.IdSurtido desc

		exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1
		--select @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1
		
		fetch next from ActSaldos into @IdCedis, @IdVendedor
	end
	close ActSaldos
	deallocate ActSaldos		
end

select SUM(Importe)
from VendedoresCargosAbonos 
where IdCedis = @IdCedis and Fecha between @FechaInicial and @FechaFinal --and IdVendedor = @IdVendedor 

select SUM(otros)
from VendedoresSaldos 
where IdCedis = @IdCedis and Fecha between @FechaInicial and @FechaFinal --and IdVendedor = @IdVendedor 

select * 
from VendedoresSaldos 
--where IdVendedor = @IdVendedor 
order by IdVendedor, Fecha desc, IdSurtido desc

--select IdVendedor, SUM(Importe)
--from VendedoresCargosAbonos 
--where IdCedis = @IdCedis and Fecha between @FechaInicial and @FechaFinal
--group by IdVendedor
--order by IdVendedor

--select IdVendedor, SUM(otros)
--from VendedoresSaldos 
--where IdCedis = @IdCedis and Fecha between @FechaInicial and @FechaFinal
--group by IdVendedor 
--having SUM(Otros) > 0
--order by IdVendedor

--select *
--from VendedoresSaldos 
--where IdCedis = 2 --and IdVendedor = @IdVendedor 
--order by IdVendedor, Fecha, IdSurtido 

--exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1

--insert into Ventas values (2, 3098, 1, 8840, 'DEV02', '20101121', 9900, 0, 0, 9956, 0, NULL)
--insert into VentasDetalle values (2, 3098, 1, 8840, 201, 'DEV02', -24, 9.95, 0, 0, 0, 0)

