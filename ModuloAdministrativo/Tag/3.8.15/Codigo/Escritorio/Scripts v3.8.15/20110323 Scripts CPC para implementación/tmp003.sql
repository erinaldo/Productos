

select AnticiposDetalle.IdCedisCargoAnt, AnticiposDetalle.IdMovimientoCargoAnt, AnticiposDetalle.IdMovimientoDetalleCargoAnt, MovimientosFacturas.Total 
from AnticiposDetalle
left outer join MovimientosFacturas on MovimientosFacturas.IdCedis = AnticiposDetalle.IdCedisMov and
	MovimientosFacturas.IdMovimiento = AnticiposDetalle.IdMovimiento and MovimientosFacturas.IdMovimientoDetalle = AnticiposDetalle.IdMovimientoDetalle 
order by IdMovimientoDetalleCargoAnt 

select * from MovimientosFacturas 
where CargoAbono = 'C'
order by IdMovimientoDetalle 

update AnticiposDetalle set IdMovimientoDetalleCargoAnt = 100
where IdCedisCargoAnt = 2 and IdMovimientoCargoAnt = 10 and IdMovimientoDetalleCargoAnt = 5

update AnticiposDetalle set IdMovimientoDetalleCargoAnt = 5
where IdCedisCargoAnt = 2 and IdMovimientoCargoAnt = 10 and IdMovimientoDetalleCargoAnt = 6

update AnticiposDetalle set IdMovimientoDetalleCargoAnt = 6
where IdCedisCargoAnt = 2 and IdMovimientoCargoAnt = 10 and IdMovimientoDetalleCargoAnt = 100



select IdCedis, IdTipoVenta, Serie, Folio, 7, IdCedis, IdMovimiento, IdMovimientoDetalle, 0,0,0, 'A', login, GETDATE() from MovimientosFacturas 
where (IdCedis = 2 and IdMovimiento = 9 and IdMovimientoDetalle between 1 and 5) or (IdCedis = 3 and IdMovimiento = 7 and IdMovimientoDetalle between 1 and 1)
