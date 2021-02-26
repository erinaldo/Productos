use RouteCPC 
----- cobranza rutas

select Dia.FechaCaptura as Fecha, M.IdMarca as IdMarca, left(M.Marca,30) Marca, 
		left(CS.NombreCorto,60) NombreSucursal, FAC.Folio as Folio, sum(ABN.Total) as Total 
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
		where Dia.FechaCaptura between '20100528' and '20100528'  
		and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
		group by Dia.FechaCaptura, M.IdMarca, M.Marca, CS.NombreCorto, FAC.Folio
		order by Dia.FechaCaptura, M.IdMarca, M.Marca, CS.NombreCorto, FAC.Folio
		
-------- cobranza de escritorio

select case substring(MOVF.Serie,LEN(MOVF.Serie)-1,1) when 'X' then 'COBASUR' else 'LACTEOS' end as Empresa ,
MOVF.Serie, MOVF.Folio, MOVF.Total  
from RouteCPC.dbo.Movimientos MOV
inner join RouteCPC.dbo.MovimientosFacturas MOVF on MOV.IdCedis = MOVF.IdCedis and MOV.IdMovimiento = MOVF.IdMovimiento 
	and MOVF.Status = 'A'
--left outer join RouteCPC.dbo.VentasDetalle VD on VD.IdCedis = MOVF.IdCedis and VD.IdTipoVenta = MOVF.IdTipoVenta and VD.Serie = MOVF.Serie collate SQL_Latin1_General_CP1_CI_AS
--	and VD.Folio = MOVF.Folio 
where MOV.Fecha between '20100528' and '20100528' 

