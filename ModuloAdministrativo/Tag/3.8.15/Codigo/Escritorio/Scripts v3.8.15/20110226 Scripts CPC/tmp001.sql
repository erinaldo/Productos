
select * from Configuracion 
select * from FacturacionGlobal 

update MovimientosFacturas set Status = 'A' where IdMovimiento = 3

select * 
from Folio
where Folio = 2

select * 
from FolioDetalle 
where Folio = 2

select * from Movimientos
where IdMovimiento = 3

select * from MovimientosFacturas 
where IdMovimiento = 3

select *
from Ventas
where (IdCedis = 2 and Serie = 'REM' and Folio = 13101) or (IdCedis = 3 and Serie = 'REM03' and Folio = 8051) 
