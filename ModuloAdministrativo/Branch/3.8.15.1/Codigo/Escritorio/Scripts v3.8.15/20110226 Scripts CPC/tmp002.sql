
--execute up_Anticipos 2, 1, '03/06/2011', '1000', '1004', 98765.43, '', '', 'SUPER', 5

select * 
-- delete 
from Ventas where Serie = 'ANT'

select * 
-- delete
from Folio where Folio >= 6

select * 
-- delete 
from FolioDetalle where Folio >= 6

select * 
-- delete 
from Movimientos where IdMovimiento >= 8 and IdCedis = 2

select * 
-- delete 
from MovimientosFacturas where Serie = 'ANT'

--update Anticipos set Status = 'P'