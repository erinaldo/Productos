
use RouteCPC 

update Ventas set Serie = 'REMH'
where Serie = 'REM3' 

update VentasDetalle set Serie = 'REMH'
where Serie = 'REM3' 

update MovimientosFacturas set Serie = 'REMH'
where Serie = 'REM3' 

update Movimientos set IdMovimiento = IdMovimiento + 200
update MovimientosFacturas set IdMovimiento = IdMovimiento + 200

exec up_Movimientos 3, 201, '20110204', '', 'A', 0, '', '', '', 'A', 'SUPER', 5

exec up_Movimientos 3, 202, '20110204', '', 'A', 0, '', '', '', 'A', 'SUPER', 5

select TransProdID, Folio, Total, Saldo 
from Route.dbo.TransProd TP
where Folio like 'REMH%113' or Folio like 'REMH%130'

insert into Movimientos values (2, 200, '20110208', 'P', 'A', 0, '', '', 'Inicial', 'A', 'SUPER', GETDATE())

