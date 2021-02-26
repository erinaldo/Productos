
use RouteADM 

insert into GReportesNaturaleza values (29, 'Ventas por Producto a Precio Base', 'S')
update GReportesNaturaleza set NombreReporte = 'Ventas por Producto a Precio Base' where IdReporte = 29
select *
from GReportesNaturaleza 

insert into GReportesNivel values (29, 1, 'Por Fecha', 10, 0,1, 'VEN.IdTipoVenta', 'S','S','S', 'IdMarca', 11, 0, 8)
update GReportesNivel set CampoFinalXLS = 13 where IdReporte = 29 and IdSubReporte = 1
select *
from GReportesNivel 

use RouteADM 

update GReportesNaturaleza set NombreReporte = 'Ventas por Marca'
where IdReporte = 28

--select *
--from GReportesNivel 
--where IdReporte = 28

update GReportesNivel set Descripcion = 'Detallado por Fecha'
where IdReporte = 28 and IdSubReporte = 1

insert into GReportesNivel values (28, 2, 'General por Fecha', 20, 0, 1, 'VEN.IdTipoVenta', 'S', 'S', 'S', 'IdMarca', 21, 1, 22 )