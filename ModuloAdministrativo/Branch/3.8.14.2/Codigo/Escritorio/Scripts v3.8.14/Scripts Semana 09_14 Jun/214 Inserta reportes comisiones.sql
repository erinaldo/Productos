exec Gsp_NivelReporte 3,10,'1','06/02/2010','06/08/2010', '', ''

update GReportesNivel set Descripcion = 'General', CampoFiltro = 'FN_ComisionesDetalleFecha.IdVendedor'
where IdReporte = 3 and IdSubReporte = 1

insert into GReportesNivel values (3,2,'Detallado por Día', 20, 0,2, 'FN_ComisionesDetalleFecha.IdVendedor', 'S', 'S', 'S', 'Vendedor', 21, 0,3)

update GReportesNivel set CampoFinalXLS = 4
where IdReporte = 3 and IdSubReporte = 2

update GReportesNaturaleza set NombreReporte = 'Ventas de Crédito'
where IdReporte = 11

update GReportesNaturaleza set NombreReporte = 'Ventas de Contado'
where IdReporte = 14

select *
from GReportesNaturaleza 
where IdReporte in (3)

select *
from GReportesNivel 
where IdReporte in (3) and IdSubReporte in (2)
