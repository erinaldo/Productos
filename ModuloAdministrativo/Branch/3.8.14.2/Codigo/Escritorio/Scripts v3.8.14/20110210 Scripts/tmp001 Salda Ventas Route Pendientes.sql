
insert into Route.dbo.tmp_AbonoFactura 
select distinct MOVF.Serie + REPLICATE('0', 7-len(MOVF.Folio)) + CAST( MOVF.Folio as varchar(10)) as Folio, 
REPLICATE('0', 2-len(MOVF.IdCedis)) + CAST( MOVF.IdCedis as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimiento)) + CAST( MOVF.IdMovimiento as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimientoDetalle)) + CAST( MOVF.IdMovimientoDetalle as varchar(10)) as FolioAbono,
MOV.Fecha, MOVF.Total, 1, '10000'
from Movimientos MOV 
inner join MovimientosFacturas MOVF on MOV.IdCedis = MOVF.IdCedis and MOV.IdMovimiento = MOVF.IdMovimiento and MOVF.Status = 'A' 
inner join Route.dbo.TransProd TP on TP.Tipo = 8 and TP.TipoFase = 1 and TP.Folio = MOVF.Serie + REPLICATE('0', 7-len(MOVF.Folio)) + CAST( MOVF.Folio as varchar(10))
	and TP.Saldo >= MOVF.Total
where MOV.IdCedis = 1 and MOV.Status = 'A' and MOV.IdDocumento <> 'CT' 
