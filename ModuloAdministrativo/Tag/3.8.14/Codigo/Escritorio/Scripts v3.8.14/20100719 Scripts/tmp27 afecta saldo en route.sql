
-- insert into Route.dbo.tmp_Abono
select Serie + REPLICATE('0',7-len(MOVF.Folio)) + CAST(MOVF.Folio as varchar(10)) as FolioVenta, right(newid(),16) as FolioAbono, 
MOVF.Fecha, SUM(MOVF.Total) as Total, 1, '10000' as MUsuarioId
from MovimientosFacturas MOVF
inner join Route.dbo.TransProd as TP on TP.Folio = Serie + REPLICATE('0',7-len(MOVF.Folio)) + CAST(MOVF.Folio as varchar(10))   
where IdMovimiento = 83 and MOVF.Status = 'A'
group by Serie, MOVF.Folio, CargoAbono, MOVF.Fecha 

select * 
-- delete
from Route.dbo.tmp_Abono 

select * from Route.dbo.Usuario  

select *
from MovimientosFacturas MOVF
inner join Route.dbo.TransProd as TP on TP.Folio = Serie + REPLICATE('0',7-len(MOVF.Folio)) + CAST(MOVF.Folio as varchar(10))   
where IdMovimiento = 83 and 
MOVF.Status = 'A'
-- group by IdMovimiento, Serie, MOVF.Folio, CargoAbono, MOVF.Fecha 

--select *
--from Ventas where Serie = 'EBQ' and Folio = 1131

