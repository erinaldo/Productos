--select *
--from MovimientosFamilias  
--where IdFamilia = 30 and IdTipoMovimiento in (18, 30)

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

select *
from RouteCPC.dbo.Ventas 
where  ( Serie = 'EBI' and Folio = 3034 ) or 
 ( Serie = 'EBI' and Folio = 2846 ) or 
 ( Serie = 'EBI' and Folio = 2933 ) or 
 ( Serie = 'EBI' and Folio = 2895 ) or 
 ( Serie = 'EBC' and Folio = 4364 ) or 
 ( Serie = 'EBF' and Folio = 2593 ) or 
 ( Serie = 'EBF' and Folio = 2584 ) or 
 ( Serie = 'EBF' and Folio = 2620 ) or 
 ( Serie = 'EBI' and Folio = 3123 ) or 
 ( Serie = 'EBD' and Folio = 2244 ) or 
 ( Serie = 'EBB' and Folio = 1838 ) or 
 ( Serie = 'EBP' and Folio = 2898 ) or 
 ( Serie = 'EB0' and Folio = 1822 ) or 
 ( Serie = 'EBA' and Folio = 2932 ) or 
 ( Serie = 'EBA' and Folio = 2958 ) or 
 ( Serie = 'EBD' and Folio = 2208 ) or 
 ( Serie = 'EBC' and Folio = 3988 ) or 
 ( Serie = 'EBA' and Folio = 2886 ) or 
 ( Serie = 'EBP' and Folio = 2892 ) or 
 ( Serie = 'EBJ' and Folio = 802 ) or 
 ( Serie = 'EBJ' and Folio = 813 ) or 
 ( Serie = 'EBJ' and Folio = 839 ) or 
 ( Serie = 'EBB' and Folio = 1963 ) or 
 ( Serie = 'EBP' and Folio = 2896 ) or 
 ( Serie = 'EBP' and Folio = 2899 ) order by Folio desc

select *
from RouteCPC.dbo.MovimientosFacturas  
where  ( Serie = 'EBI' and Folio = 3034 ) or 
 ( Serie = 'EBI' and Folio = 2846 ) or 
 ( Serie = 'EBI' and Folio = 2933 ) or 
 ( Serie = 'EBI' and Folio = 2895 ) or 
 ( Serie = 'EBC' and Folio = 4364 ) or 
 ( Serie = 'EBF' and Folio = 2593 ) or 
 ( Serie = 'EBF' and Folio = 2584 ) or 
 ( Serie = 'EBF' and Folio = 2620 ) or 
 ( Serie = 'EBI' and Folio = 3123 ) or 
 ( Serie = 'EBD' and Folio = 2244 ) or 
 ( Serie = 'EBB' and Folio = 1838 ) or 
 ( Serie = 'EBP' and Folio = 2898 ) or 
 ( Serie = 'EB0' and Folio = 1822 ) or 
 ( Serie = 'EBA' and Folio = 2932 ) or 
 ( Serie = 'EBA' and Folio = 2958 ) or 
 ( Serie = 'EBD' and Folio = 2208 ) or 
 ( Serie = 'EBC' and Folio = 3988 ) or 
 ( Serie = 'EBA' and Folio = 2886 ) or 
 ( Serie = 'EBP' and Folio = 2892 ) or 
 ( Serie = 'EBJ' and Folio = 802 ) or 
 ( Serie = 'EBJ' and Folio = 813 ) or 
 ( Serie = 'EBJ' and Folio = 839 ) or 
 ( Serie = 'EBB' and Folio = 1963 ) or 
 ( Serie = 'EBP' and Folio = 2896 ) or 
 ( Serie = 'EBP' and Folio = 2899 ) order by Folio desc

select ABN.*
from Route.dbo.TransProd TPROD
inner join Route.dbo.AbnTrp ABN on ABN.TransProdID = TPROD.TransProdID 
where ( ( Folio like 'EBI%3034' ) or 
 ( Folio like 'EBI%2846' ) or 
 ( Folio like 'EBI%2933' ) or 
 ( Folio like 'EBI%2895' ) or 
 ( Folio like 'EBC%4364' ) or 
 ( Folio like 'EBF%2593' ) or 
 ( Folio like 'EBF%2584' ) or 
 ( Folio like 'EBF%2620' ) or 
 ( Folio like 'EBI%3123' ) or 
 ( Folio like 'EBD%2244' ) or 
 ( Folio like 'EBB%1838' ) or 
 ( Folio like 'EBP%2898' ) or 
 ( Folio like 'EB0%1822' ) or 
 ( Folio like 'EBA%2932' ) or 
 ( Folio like 'EBA%2958' ) or 
 ( Folio like 'EBD%2208' ) or 
 ( Folio like 'EBC%3988' ) or 
 ( Folio like 'EBA%2886' ) or 
 ( Folio like 'EBP%2892' ) or 
 ( Folio like 'EBJ%802' ) or 
 ( Folio like 'EBJ%813' ) or 
 ( Folio like 'EBJ%839' ) or 
 ( Folio like 'EBB%1963' ) or 
 ( Folio like 'EBP%2896' ) or 
 ( Folio like 'EBP%2899' ) )
 order by TPROD.FechaCaptura desc, TPROD.Folio