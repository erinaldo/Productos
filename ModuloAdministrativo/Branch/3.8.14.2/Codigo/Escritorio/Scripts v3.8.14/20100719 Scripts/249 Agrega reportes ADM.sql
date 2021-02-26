
use RouteADM 

insert into GReportesNaturaleza values (29, 'Ventas por Producto a Precio Base', 'S')
update GReportesNaturaleza set NombreReporte = 'Ventas por Producto a Precio Base' where IdReporte = 29
select *
from GReportesNaturaleza 

insert into GReportesNivel values (29, 1, 'Por Fecha', 10, 0,1, 'VEN.IdTipoVenta', 'S','S','S', 'IdMarca', 11, 0, 8)
update GReportesNivel set CampoFinalXLS = 13 where IdReporte = 29 and IdSubReporte = 1
select *
from GReportesNivel 

