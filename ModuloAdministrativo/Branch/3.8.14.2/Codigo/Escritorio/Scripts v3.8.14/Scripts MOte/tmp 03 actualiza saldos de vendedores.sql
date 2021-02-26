
-- select *
delete 
from vendedoressaldos where fecha > '20100331' and idvendedor in (27, 30, 7, 9, 46)


declare @IdCedis as bigint, @IdSurtido as bigint, @IdVendedor as bigint, @Fecha as datetime

			declare  ActPrecio cursor for
				select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, SurtidosVendedor.IdVendedor
				from Surtidos 
				inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
				where Surtidos.Fecha between '20100401' and '20100505'  and SurtidosVendedor.IdVendedor in (27, 30, 7, 9, 46)
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

