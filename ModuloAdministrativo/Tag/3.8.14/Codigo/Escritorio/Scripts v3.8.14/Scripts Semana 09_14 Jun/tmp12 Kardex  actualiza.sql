
select *
from ClienteSucursal 
where IdSucursal = ''

select *
from Movimientos 

select *
-- delete 
from InventarioInicial 
where Mes = 5 and IdCedis = 999

--update InventarioInicial set Cantidad = 0 
--where IdCedis = 1 and Mes = 5

select *
from InventarioKardex 
where IdCedis = 1 and Fecha = '20100528'

--update InventarioKardex 
--set Inicial = 0
--where IdCedis = 1 and Fecha = '20100528'

--update InventarioKardex
--	set Inicial = II.Cantidad 
--from InventarioInicial II
--where II.IdCedis = 999
--	and II.Mes = 5 and II.IdCedis = 999
--	and II.IdProducto = InventarioKardex.IdProducto 
--	and InventarioKardex.Fecha = '20100528'