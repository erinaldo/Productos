

select *
-- delete
from MovimientosFacturas  
where IdMovimiento in  (
	select IdMovimiento 
	from Movimientos where IdCedis = MovimientosFacturas.IdCedis and IdMovimiento = MovimientosFacturas.IdMovimiento 
	and Fecha > '20101010' )
order by IdCedis, IdMovimiento 

select * 
-- delete
from Movimientos 
where Fecha > '20101010'

select * 
-- delete 
from Ventas 
where Fecha > '20101010' and Login = 'SNoReg'
