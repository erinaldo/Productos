
--exec GeneraSaldos '20110402', '20110402'

select *
-- delete 
from Folio
where Folio >= 14

select *
-- delete 
from FolioDetalle 
where Folio >= 14

select *
-- delete 
from Movimientos 
where (IdCedis = 1 and IdMovimiento = 11) or (IdCedis = 2 and IdMovimiento = 3) or 
	(IdCedis = 3 and IdMovimiento = 4) or (IdCedis = 5 and IdMovimiento = 2) 

select *
-- delete 
from MovimientosFacturas 
where (IdCedis = 1 and IdMovimiento = 11) or (IdCedis = 2 and IdMovimiento = 3) or 
	(IdCedis = 3 and IdMovimiento = 4) or (IdCedis = 5 and IdMovimiento = 2) 
