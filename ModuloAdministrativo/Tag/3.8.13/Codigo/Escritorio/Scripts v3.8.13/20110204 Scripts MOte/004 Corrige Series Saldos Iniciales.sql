
use RouteCPC 

--select *
--from Ventas 
--where Saldo < 0

update Ventas set Serie = 'REML'
where Serie = 'REM2'

update VentasDetalle set Serie = 'REML'
where Serie = 'REM2'

update MovimientosFacturas set Serie = 'REML'
where Serie = 'REM2'

update Ventas set Serie = replace(Serie,'REM', 'R')
where Serie like 'REM%' and Serie not in ('REMH', 'REML')

update VentasDetalle set Serie = replace(Serie,'REM', 'R')
where Serie like 'REM%' and Serie not in ('REMH', 'REML')

update MovimientosFacturas  set Serie = replace(Serie,'REM', 'R')
where Serie like 'REM%' and Serie not in ('REMH', 'REML')
