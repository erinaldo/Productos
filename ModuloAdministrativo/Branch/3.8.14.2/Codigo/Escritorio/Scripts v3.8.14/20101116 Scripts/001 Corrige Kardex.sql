
declare @IdCedis as bigint, @Fecha as datetime

set @IdCedis = 1
set @Fecha = '20101102'

delete 
from Ventas 
where IdCedis = @IdCedis and Fecha = @Fecha and IdSurtido not in (
	select IdSurtido from Surtidos where IdCedis = @IdCedis and Fecha = @Fecha 
)

delete
from VentasDetalle 
where IdCedis = @IdCedis and IdSurtido = 0

exec up_ActualizaKardex 1, @Fecha, 0, 1
--select * from Configuracion 

select -- IdProducto, 
SUM(ventacontado + ventacredito)
from InventarioKardex 
where IdCedis = @IdCedis and Fecha = @Fecha
--group by IdProducto 
having SUM(ventacontado + ventacredito) > 0

select SUM(ventasdetalle.cantidad)
from Ventas 
inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido 
	and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio 
where Ventas.IdCedis = @IdCedis and Fecha = @Fecha

select SUM(ventasdetalle.cantidad)
from Surtidos 
inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido 
	-- and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio 
where Surtidos.IdCedis = @IdCedis and  Surtidos.Fecha = @Fecha

