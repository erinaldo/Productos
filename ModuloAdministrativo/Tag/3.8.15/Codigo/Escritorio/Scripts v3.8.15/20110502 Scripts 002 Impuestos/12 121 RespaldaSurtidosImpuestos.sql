use RouteADM 

-- checo los impuestos actuales
--select * from tipoimpuesto

select distinct iva from SurtidosDetalle 

-- Paso los valores de los impuestos que se generaron de SurtidosDetalle a surtidosImpuestos 
--		Dependiendo de consulta  anterior , tomo el valor de 1 para IdTipoImpuesto, para predeterminar el IVA y lo escribo en la siguiente instrucción de inserción
--		Para agregar los impuestos quite los comentarios del Insert Query

Insert Into SurtidosImpuestos
select IdCedis, IdSurtido,IdProducto, Fecha, 1 as IdTipoImpuesto, 2,1,0 
from SurtidosDetalle
where Iva = 0

Insert Into SurtidosImpuestos
select IdCedis, IdSurtido,IdProducto, Fecha, 2 as IdTipoImpuesto, 2,1,.11
from SurtidosDetalle
where Iva <> 0

select * from SurtidosImpuestos
