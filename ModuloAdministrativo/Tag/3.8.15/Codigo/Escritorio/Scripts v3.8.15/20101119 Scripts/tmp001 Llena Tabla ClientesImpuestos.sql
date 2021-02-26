
update Productos set IdFamilia = 9 where IdProducto in (191, 192, 193)

insert into ClientesImpuestos
select IdCedis, IdCliente, IdSucursal, IdProducto, .11 
from ClienteSucursal  
inner join Productos on Productos.IdFamilia = 9
where IdCedis = 2 and IdCliente = 9056

select *
from ClientesImpuestos 


select *
from Productos 
where IdFamilia = 9

