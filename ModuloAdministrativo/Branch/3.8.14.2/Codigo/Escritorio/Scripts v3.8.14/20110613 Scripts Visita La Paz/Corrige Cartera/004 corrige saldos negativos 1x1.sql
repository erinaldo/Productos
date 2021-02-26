
use RouteCPC 

declare @IdCedis as bigint, @IdTipoVenta as bigint, @Serie as varchar(10), @Folio as bigint

set @Serie = 'EBQX'
set @Folio = 2915

select * from Ventas where Serie = @Serie and Folio = @Folio 

select * from MovimientosFacturas where Serie = @Serie and Folio = @Folio 
order by FechaEdicion desc

/*
update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2675 and IdMovimientoDetalle = 3
update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2669 and IdMovimientoDetalle = 31
update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2667 and IdMovimientoDetalle = 4

update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2791 and IdMovimientoDetalle = 46
update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2789 and IdMovimientoDetalle = 46

update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2791 and IdMovimientoDetalle = 23
update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2789 and IdMovimientoDetalle = 23

update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2792 and IdMovimientoDetalle = 3
update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2790 and IdMovimientoDetalle = 3

update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2792 and IdMovimientoDetalle = 4
update MovimientosFacturas set Subtotal = 0 where IdCedis = 1 and IdMovimiento = 2790 and IdMovimientoDetalle = 4
*/

/*
	select distinct Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Total, Ventas.Saldo
	from Ventas 
	inner join MovimientosFacturas MovF on Ventas.IdCedis = MovF.IdCedis and Ventas.IdTipoVenta = MovF.IdTipoVenta 
		and Ventas.Serie = MovF.Serie and Ventas.Folio = MovF.Folio --and MovF.Status = 'A' and MovF.CargoAbono = 'A' and MovF.IdDocumento = 'CT'
	where Ventas.Saldo < 0
	order by Ventas.Serie, Ventas.Folio
*/