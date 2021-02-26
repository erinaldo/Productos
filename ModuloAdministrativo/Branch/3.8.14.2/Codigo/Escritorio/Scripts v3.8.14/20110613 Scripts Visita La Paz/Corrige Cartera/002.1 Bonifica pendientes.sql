
use RouteCPC 

insert into Route.dbo.tmp_AbonoFactura 
select distinct MOVF.Serie + REPLICATE('0', 7-len(MOVF.Folio)) + CAST( MOVF.Folio as varchar(10)) as Folio, 
REPLICATE('0', 2-len(MOVF.IdCedis)) + CAST( MOVF.IdCedis as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimiento)) + CAST( MOVF.IdMovimiento as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimientoDetalle)) + CAST( MOVF.IdMovimientoDetalle as varchar(10)) as FolioAbono,
MOV.Fecha, MOVF.Total, 1, '10000'
from Movimientos MOV 
inner join MovimientosFacturas MOVF on MOV.IdCedis = MOVF.IdCedis and MOV.IdMovimiento = MOVF.IdMovimiento 
	and MOVF.Status = 'A' and MOVF.Serie + REPLICATE('0', 7-len(MOVF.Folio)) + CAST( MOVF.Folio as varchar(10)) in (
	select Folio from Route.dbo.TransProd where Tipo = 8 and TipoFase = 1
	)
where MOV.IdCedis = 1 and MOV.Status in ('','P') and MOV.IdDocumento <> 'CT' -- and MOV.IdMovimiento = 2473 
		and REPLICATE('0', 2-len(MOVF.IdCedis)) + CAST( MOVF.IdCedis as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimiento)) + CAST( MOVF.IdMovimiento as varchar(10)) + REPLICATE('0', 6-len(MOVF.IdMovimientoDetalle)) + CAST( MOVF.IdMovimientoDetalle as varchar(10))
			not in (select FolioAbono from Route.dbo.tmp_AbonoFactura )

update Movimientos set Status = 'A', FechaEdicion = GETDATE() where IdCedis = 1 and Status in ('','P') and IdDocumento <> 'CT' 
