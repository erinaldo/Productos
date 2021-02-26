
	select distinct ABN.DiaClave 
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	inner join RouteADM.dbo.Marcas M on M.IdMarca = FAC.SubEmpresaID 
	inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
	where ( ( FAC.Folio like 'EBI%3034' ) or 
 ( FAC.Folio like 'EBI%2846' ) or 
 ( FAC.Folio like 'EBI%2933' ) or 
 ( FAC.Folio like 'EBI%2895' ) or 
 ( FAC.Folio like 'EBC%4364' ) or 
 ( FAC.Folio like 'EBF%2593' ) or 
 ( FAC.Folio like 'EBF%2584' ) or 
 ( FAC.Folio like 'EBF%2620' ) or 
 ( FAC.Folio like 'EBI%3123' ) or 
 ( FAC.Folio like 'EBD%2244' ) or 
 ( FAC.Folio like 'EBB%1838' ) or 
 ( FAC.Folio like 'EBP%2898' ) or 
 ( FAC.Folio like 'EB0%1822' ) or 
 ( FAC.Folio like 'EBA%2932' ) or 
 ( FAC.Folio like 'EBA%2958' ) or 
 ( FAC.Folio like 'EBD%2208' ) or 
 ( FAC.Folio like 'EBC%3988' ) or 
 ( FAC.Folio like 'EBA%2886' ) or 
 ( FAC.Folio like 'EBP%2892' ) or 
 ( FAC.Folio like 'EBJ%802' ) or 
 ( FAC.Folio like 'EBJ%813' ) or 
 ( FAC.Folio like 'EBJ%839' ) or 
 ( FAC.Folio like 'EBB%1963' ) or 
 ( FAC.Folio like 'EBP%2896' ) or 
 ( FAC.Folio like 'EBP%2899' ) ) and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
	group by M.IdMarca, M.Marca, CS.NombreCorto, FAC.Folio, TRP.FechaCaptura, TRP.Total, ABN.DiaClave 

