
use RouteADM 

declare @IdPedido as bigint, @IdTipoV as bigint, @Folio as bigint, @IdProd as bigint, @Cantidad as money, 
@Serie as varchar(10), @Precio as float, @Fecha as datetime, @PrecioAnt as float

	declare  ActPrecios cursor for
		select PedidosDetalle.IdPedido, Pedidos.IdTipoVenta, PedidosDetalle.IdProducto, PedidosDetalle.Cantidad, PedidosDetalle.Precio
		from Pedidos
		inner join PedidosDetalle on Pedidos.IdCedis = PedidosDetalle.IdCedis and Pedidos.IdPedido = PedidosDetalle.IdPedido 
		order by PedidosDetalle.IdPedido, PedidosDetalle.IdProducto
	open ActPrecios

	fetch next from ActPrecios into @IdPedido, @IdTipoV, @IdProd, @Cantidad, @PrecioAnt
	while (@@fetch_status = 0)
	begin

		select @Precio = Precio from PreciosDetalle where IdLista = 3 and IdProducto = @IdProd 
		
		--select 4, @IdPedido, @IdTipoV, @IdProd, @Cantidad, @Precio, @PrecioAnt

		exec up_PedidosDetalle 4, @IdPedido, @IdTipoV, @IdProd, @Cantidad, @Precio, 0, 0, 0, @Cantidad, 1

		
		fetch next from ActPrecios into @IdPedido, @IdTipoV, @IdProd, @Cantidad, @PrecioAnt
	end
	close ActPrecios
	deallocate ActPrecios		
