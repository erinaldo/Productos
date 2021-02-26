
use RouteADM 

-- checo los impuestos actuales
--select * from tipoimpuesto

select distinct iva from PedidosDetalle 

-- Paso los valores de los impuestos que se generaron de PedidosDetalle a PedidosImpuestos 
--		Dependiendo de consulta anterior , tomo el valor de 1 para IdTipoImpuesto, para predeterminar el IVA y lo escribo en la siguiente instrucción de inserción
--		Para agregar los impuestos quite los comentarios del Insert Query

Insert Into PedidosImpuestos
select IdCedis, IdPedido, IdTipoVenta, IdProducto, 1 as IdTipoImpuesto, 2,1,0 
from PedidosDetalle
where Iva = 0

Insert Into PedidosImpuestos
select IdCedis, IdPedido, IdTipoVenta, IdProducto, 2 as IdTipoImpuesto, 2,1,.11 
from PedidosDetalle
where Iva <> 0

select * from PedidosImpuestos
