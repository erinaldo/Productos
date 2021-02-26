
use RouteADM 

delete from clientesucursal where idcliente = 8 and idsucursal like '22730001'
delete from clientesucursal where idcliente = 3 and idsucursal like '22740001'
delete from clientesucursal where idcliente = 4 and idsucursal like '22760001'
delete from clientesucursal where idcliente = 2 and idsucursal like '22770001'
delete from clientesucursal where idcliente = 7 and idsucursal like '22770002'
delete from clientesucursal where idcliente = 6 and idsucursal like '22780001'

delete 
from Route.dbo.ClienteEsquema  
where ClienteClave like '02%' -- isnumeric(EsquemaID ) = 1

update ClienteSucursal set NombreSucursal = NombreSucursal 
where IdCedis = 2

--select IdCliente, IdSucursal, NombreSucursal 
--from ClienteSucursal 
--where IdCedis = 2 and IdSucursal in ('022730001',
--'022740001',
--'022760001',
--'022770001',
--'022770002',
--'022780001')
--order by IdSucursal 

