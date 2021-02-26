
select left(v.Serie,3) + REPLICATE('0',7-len(v.folio)) + CAST(v.folio as varchar(10)) as SerieFacturaElectronica, v.*, vd.*, SE.* 
from Ventas v
inner join VentasDetalle vd on v.IdCedis = vd.idcedis and v.IdSurtido = vd.IdSurtido and v.IdTipoVenta = vd.IdTipoVenta and v.Folio = vd.Folio and v.Serie = vd.serie
inner join ClienteSucursal cs on v.IdSucursal = cs.IdSucursal
inner join Route.dbo.FolioSolicitado fs on v.serie =  fs.Serie COLLATE SQL_Latin1_General_CP1_CI_AS
inner join Route.dbo.FOSHist fh on fh.FolioID = fs.FolioID and fh.FOSId = fs.FOSId 
inner join Route.dbo.SubEmpresa SE on SE.SubEmpresaId = fh.CentroExpID 
where v.Serie not like 'R%'
order by v.Fecha, fh.CentroExpID, left(v.Serie,3) + REPLICATE('0',7-len(v.folio)) + CAST(v.folio as varchar(10)), vd.Folio

