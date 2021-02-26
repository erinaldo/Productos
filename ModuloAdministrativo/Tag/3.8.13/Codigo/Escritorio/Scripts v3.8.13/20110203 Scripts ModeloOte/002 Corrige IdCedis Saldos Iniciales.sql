
use RouteCPC 

select Ventas.IdCedis, ClienteSucursal.IdCedis as IdCedisBueno, Ventas.IdCliente, Ventas.IdSucursal
from Ventas 
inner join ClienteSucursal on Ventas.IdSucursal = ClienteSucursal.IdSucursal 
where Login = 'SIniciales' and Ventas.IdCedis <> ClienteSucursal.IdCedis
-- IdSucursal = '020400'

update Ventas set IdCedis = 2
--select * from Ventas 
where IdCedis = 3 and IdSucursal = '020400' and Login = 'SIniciales' 

update Ventas set IdCedis = 3
--select * from Ventas 
where IdCedis = 2 and IdSucursal in ( '210150', '251020' ) and Login = 'SIniciales' 

select Ventas.IdCedis, ClienteSucursal.IdCedis as IdCedisBueno, Ventas.IdCliente, Ventas.IdSucursal
from Ventas 
inner join ClienteSucursal on Ventas.IdSucursal = ClienteSucursal.IdSucursal 
where Login = 'SIniciales' and Ventas.IdCedis <> ClienteSucursal.IdCedis
