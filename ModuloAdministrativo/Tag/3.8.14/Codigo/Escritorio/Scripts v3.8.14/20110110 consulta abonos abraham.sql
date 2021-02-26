select left(CS.NombreCorto,60) NombreSucursal, FAC.Folio as Folio,cs.clienteclave, sum(ABT.Importe) as Total 
from Route.dbo.AbnTrp ABT 
inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave 
inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave 
inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID 
inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId 
inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
where Dia.FechaCaptura between '20101227' and '20101227'   and fac.SubEmpresaID=1 
and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
group by Dia.FechaCaptura, CS.NombreCorto,CS.ClienteClave ,FAC.Folio 
order by Dia.FechaCaptura,  CS.NombreCorto,cs.clienteclave, FAC.Folio 