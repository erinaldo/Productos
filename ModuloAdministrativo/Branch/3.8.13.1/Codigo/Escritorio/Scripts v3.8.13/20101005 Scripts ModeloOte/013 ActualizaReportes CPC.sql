
use RouteCPC 

update GReportesNaturaleza set NombreReporte = UPPER(nombreReporte)
where IdReporte = 20

update GReportesNaturaleza set Mostrar = 'N'
where IdReporte = 105
