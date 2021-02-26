
select distinct FACTG.SerieOX, FACTG.FolioOX, Ventas.Status, MOVF.Serie, MOVF.Folio 
from FacturasOxxo FACTG
left outer join Ventas on FACTG.IdCedisOX = Ventas.IdCedis and FACTG.IdTipoVentaOX = Ventas.IdTipoVenta 
	and FACTG.SerieOX = Ventas.Serie and FACTG.FolioOX = Ventas.Folio 
left outer join MovimientosFacturas MOVF on FACTG.IdCedis = MOVF.IdCedis and FACTG.IdTipoVenta = MOVF.IdTipoVenta 
	and FACTG.Serie = MOVF.Serie and FACTG.Folio = MOVF.Folio and MOVF.IdDocumento = 'AJ' and MOVF.IdTipoDocumento = 'FG'
where FACTG.SerieOX = 'FG' and FACTG.FolioOX = 155
order by FACTG.SerieOX, FACTG.FolioOX 