use RouteADM 

select *
from GReportesNaturaleza 

update GReportesNaturaleza set NombreReporte = 'Ventas por Marca'
where IdReporte = 28

--select *
--from GReportesNivel 
--where IdReporte = 28

update GReportesNivel set Descripcion = 'Detallado por Fecha'
where IdReporte = 28 and IdSubReporte = 1

insert into GReportesNivel values (28, 2, 'General por Fecha', 20, 0, 1, 'VEN.IdTipoVenta', 'S', 'S', 'S', 'IdMarca', 21, 1, 22 )


