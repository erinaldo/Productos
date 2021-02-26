
use RouteADM 

insert into ClientesImpuestos 
select IdCedis, IdCliente, IdSucursal, IdProducto, 2
from Productos 
inner join ClienteSucursal on IdCliente > 0 
where IdFamilia = 5  and IdCliente = 9056

declare 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@IdProducto as bigint,
@Serie as varchar(10), @fecha as datetime, @Cantidad as float, @Precio as money, @Entregado as float

declare  ActPrecio cursor for
	select distinct PedidosDetalle.IdCedis, PedidosDetalle.IdPedido, PedidosDetalle.IdTipoVenta, PedidosDetalle.IdProducto,
		PedidosDetalle.cantidad, PedidosDetalle.Precio, PedidosDetalle.Entregado 
	from Pedidos
	inner join PedidosDetalle on Pedidos.IdCedis = PedidosDetalle.IdCedis and Pedidos.IdPedido = PedidosDetalle.IdPedido 
		--and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio 
	where IdCliente = 9056 and IdProducto in (select IdProducto from Productos where IdFamilia = 5) and PedidosDetalle.Iva = 0

open ActPrecio

fetch next from ActPrecio into @IdCedis, @IdSurtido, @IdTipoVenta, @IdProducto, @cantidad, @precio, @entregado 
while (@@fetch_status = 0)
begin

	exec up_PedidosDetalle @idcedis, @idsurtido, @idtipoventa, @idproducto, @cantidad, @precio, 0, 0, 0, @entregado, 1 

	fetch next from ActPrecio into @IdCedis, @IdSurtido, @IdTipoVenta, @IdProducto, @cantidad, @precio, @entregado 
end
close ActPrecio
deallocate ActPrecio	


declare  ActPrecio cursor for
	select distinct VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, VentasDetalle.IdProducto,
		Ventas.Serie, Ventas.fecha, VentasDetalle.cantidad, Ventasdetalle.Precio, VentasDetalle.Entregado 
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido 
		and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio 
	where IdCliente = 9056 and IdProducto in (select IdProducto from Productos where IdFamilia = 5) and VentasDetalle.Iva = 0

open ActPrecio

fetch next from ActPrecio into @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @serie, @fecha, @cantidad, @precio, @entregado 
while (@@fetch_status = 0)
begin

	exec up_VentasDetalle @idcedis, @idsurtido, @idtipoventa, @folio, @serie, @fecha, @idproducto, @cantidad, @precio, 0, 0, 0, 0, @entregado, 1 

	fetch next from ActPrecio into @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @serie, @fecha, @cantidad, @precio, @entregado 
end
close ActPrecio
deallocate ActPrecio		


--select *
--from Ventas 
--inner join VentasImpuestos on Ventas.IdCedis = VentasImpuestos.IdCedis and Ventas.IdSurtido = VentasImpuestos.IdSurtido 
--	and Ventas.IdTipoVenta = VentasImpuestos.IdTipoVenta and Ventas.Folio = VentasImpuestos.Folio 
--where IdCliente = 9056 and IdProducto in (select IdProducto from Productos where IdFamilia = 5) and VentasImpuestos.IdTipoImpuesto = 1

--select * from ClientesImpuestos 
--select * from ProductosImpuestos where IdProducto in (select IdProducto from Productos where IdFamilia = 5)

--delete from ProductosImpuestos 
--where IdProducto in (
--	select IdProducto from Productos where IdFamilia = 5
--)

