-- select *
delete 
from vendedoressaldos where fecha > '20100331' and idvendedor in (11, 39, 43, 10)

/*
update vendedoressaldos 
set saldoanterior = 0
where saldoanterior is null

update vendedoressaldos 
set saldoactual = saldoanterior + saldo
where saldoactual  is null

delete
from vendedoressaldos 
where fecha > '20100331' -- and idvendedor in (29, 30)
-- and saldoactual > 0
*/
declare @IdCedis as bigint, @IdSurtido as bigint, @IdVendedor as bigint, @Fecha as datetime

			declare  ActPrecio cursor for
				select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, SurtidosVendedor.IdVendedor
				from Surtidos 
				inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
					and SurtidosVendedor.IdVendedor in (11, 39, 43, 10)
				where Surtidos.Fecha between '20100401' and '20100427'  -- and Surtidos.IdRuta = 108
				order by Surtidos.IdCedis, SurtidosVendedor.IdVendedor, Surtidos.Fecha
			open ActPrecio
			
			fetch next from ActPrecio into @IdCedis, @IdSurtido, @Fecha, @IdVendedor 
			while (@@fetch_status = 0)
			begin
				exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1 

				fetch next from ActPrecio into @IdCedis, @IdSurtido, @Fecha, @IdVendedor 
			end
			close ActPrecio
			deallocate ActPrecio		

