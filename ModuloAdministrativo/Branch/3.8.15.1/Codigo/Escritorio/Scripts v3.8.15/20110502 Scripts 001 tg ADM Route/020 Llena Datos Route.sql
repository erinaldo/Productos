use Route

delete
from ProductoImpuesto 

delete
from ImpuestoVig 

delete
from Impuesto  

use RouteADM 

update Configuracion set Route = 1

-- Ejecutar uno por uno
update PreciosLista set IdLista = IdLista 

update ClienteSucursal set IdSucursal = IdSucursal 

insert into PreciosListaCliente 
select IdCedis, IdCliente, 3
from Clientes where IdCliente not in (select IdCliente from PreciosListaCliente )

update PreciosListaCliente set IdLista = IdLista 

update PreciosListaRuta set IdLista = IdLista 

update Productos set Producto = Producto 

update ClienteSucursal set IdSucursal = IdSucursal 

