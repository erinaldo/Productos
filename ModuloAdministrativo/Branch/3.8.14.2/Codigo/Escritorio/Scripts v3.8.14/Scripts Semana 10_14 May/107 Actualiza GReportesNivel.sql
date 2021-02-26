
--select * from GReportesNivel 


update GReportesNivel 
set CampoFiltro = 'Cedis.IdCedis', CampoInicial = 0, CampoFinal = 1,
	ImpresionXLS = 'S', CampoInicialXLS = 1, CampoFinalXLS = 13
where IdReporte = 26

