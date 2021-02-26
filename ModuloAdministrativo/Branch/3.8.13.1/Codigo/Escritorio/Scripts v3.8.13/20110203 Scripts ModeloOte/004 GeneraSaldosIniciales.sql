
--select SUM(TP.Saldo)
--from Route.dbo.TransProd TP
--where TP.Tipo = 1 and TP.Saldo > 0 and TP.TipoFase > 0

select isnull(Ruta.IdCedis,3) as Idcedis, TP.CFVTipo, cast(replace(Route.dbo.FNObtenerSoloNumeros(TP.Folio),'-','') as bigint) as Folio, 
	replace(TP.Folio, Route.dbo.FNObtenerSoloNumeros(TP.Folio), '') as Serie,
	DIA.FechaCaptura, CS.IdCliente, TP.Saldo, 0, TP.Saldo, 0, 0, 
	TP.DiasCredito, TP.ClienteClave, 1, TP.Folio, '', 'SIniciales', GETDATE()
from Route.dbo.TransProd TP
inner join Route.dbo.Visita VIS on VIS.VisitaClave = TP.VisitaClave and VIS.DiaClave = TP.DiaClave 
inner join Route.dbo.Dia DIA on DIA.DiaClave = VIS.DiaClave 
left outer join RouteADM.dbo.Rutas Ruta on Ruta.IdRuta = cast(Route.dbo.FNObtenerSoloNumeros(VIS.RUTClave) as bigint)
left outer join ClienteSucursal CS on CS.IdSucursal = TP.ClienteClave 
where TP.Tipo = 1 and TP.Saldo > 0 and TP.TipoFase > 0 
	--and ISNUMERIC(Route.dbo.FNObtenerSoloNumeros(TP.Folio)) = 0

--select top 1 * from Ventas 

