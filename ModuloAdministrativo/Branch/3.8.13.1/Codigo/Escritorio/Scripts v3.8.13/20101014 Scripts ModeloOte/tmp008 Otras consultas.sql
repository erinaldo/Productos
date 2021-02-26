
select *
from Route.dbo.TransProd 
where TransProdID = 'A2700856FD3BB13C'

select *
from Configuracion 

select *
from TipoMovimiento 

select *
from Movimientos 
where IdCedis = 3 and Fecha = '20101019'

select *
from Consignas 
where IdSurtidoDevolucion  = 1775

select IdConsigna, IdProducto, Devolucion, Venta 
from ConsignasDetalle 
where IdConsigna in ( 8, 2)
order by IdConsigna, cast(IdProducto as int)