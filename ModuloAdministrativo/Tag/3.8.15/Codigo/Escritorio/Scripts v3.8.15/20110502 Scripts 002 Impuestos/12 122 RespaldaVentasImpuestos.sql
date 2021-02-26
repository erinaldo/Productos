
use RouteADM 

-- checo los impuestos actuales
--select * from tipoimpuesto

select distinct iva from VentasDetalle 

-- Paso los valores de los impuestos que se generaron de VentasDetalle a VentasImpuestos 
--		Dependiendo de consulta  anterior , tomo el valor de 1 para IdTipoImpuesto, para predeterminar el IVA y lo escribo en la siguiente instrucción de inserción
--		Para agregar los impuestos quite los comentarios del Insert Query

Insert Into VentasImpuestos
select IdCedis, IdSurtido, IdTipoVenta, Folio, IdProducto, 1 as IdTipoImpuesto, 2,1,0 
from VentasDetalle 
where Iva = 0

Insert Into VentasImpuestos
select IdCedis, IdSurtido, IdTipoVenta, Folio, IdProducto, 2 as IdTipoImpuesto, 2,1,.11 
from VentasDetalle 
where Iva <> 0

select * from VentasImpuestos
