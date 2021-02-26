
--exec up_ModeloOrienteES '3','02/01/2011'

select *
from RepModeloOrienteES 
where IdCedis = 3 and Fecha = '20110201'

select *
from Productos where IdProducto > 50 and IdFamilia = 1

--exec up_ModeloOrienteEnvase '3','02/01/2011'

--exec Gsp_NivelReporte 26,10,'3','02/01/2011','02/01/2011', '', ''

select *
from InventarioKardex 
where IdProducto > 29 and Fecha = '20110201' and IdCedis = 3
