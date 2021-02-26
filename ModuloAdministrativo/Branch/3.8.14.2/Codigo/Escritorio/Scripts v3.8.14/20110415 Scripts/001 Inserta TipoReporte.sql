
use RouteADM 


insert into GReportesNivel values (19, 2, 'Por Marca', 20, 0, 1, 'Surtidos.IdRuta', 'S','S','S', 'Ruta', 20, 1, 10)

update GReportesNivel set CampoFinalXLS = 10, Descripcion = 'Por Marca', DescripcionAgrupacion = 'Marca', CampoFiltro = 'Surtidos.IdRuta' where IdReporte = 19 and IdSubReporte = 2


