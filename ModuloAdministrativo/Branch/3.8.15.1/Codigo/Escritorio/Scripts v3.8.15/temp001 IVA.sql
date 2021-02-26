
use RouteADM 

insert into ClientesImpuestos 
select ClienteSucursal.IdCedis, ClienteSucursal.IdCliente, IdSucursal, IdProducto, 0.11
from Productos 
inner join ClienteSucursal on IdCliente = 910
where IdProducto between 191 and 195 

