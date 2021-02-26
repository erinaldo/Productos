
		select FechaCaptura, right(Clave,2) as Ruta, SubEmpresaId, Folio, sum(t.Total) as Total
		from (
		select distinct USU.Clave, ABN.ABNId, ABN.Total, FAC.SubEmpresaID, Dia.FechaCaptura, FAC.Folio as Folio  
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
		left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		where Dia.FechaCaptura between '20100528' and '20100530' 
		and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) -- and FAC.SubEmpresaId = @IdMarca
		)as t
		group by FechaCaptura, Clave, SubEmpresaId, Folio
		order by FechaCaptura, Clave, SubEmpresaId, Folio
