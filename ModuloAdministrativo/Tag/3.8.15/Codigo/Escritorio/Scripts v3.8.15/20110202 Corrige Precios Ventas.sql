
use RouteADM 

declare @IdSurt as bigint, @IdTipoV as bigint, @Folio as bigint, @IdProd as bigint, @Cantidad as money, 
@Serie as varchar(10), @Precio as float, @Fecha as datetime, @PrecioAnt as float

	declare  ActPrecios cursor for
		select VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, VentasDetalle.IdProducto, VentasDetalle.Cantidad, Ventas.Serie, Ventas.Fecha, VentasDetalle.Precio
		from Ventas
		inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido 
			and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio
		where Ventas.Fecha = '20110201' 
		order by VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, VentasDetalle.IdProducto
	open ActPrecios

	fetch next from ActPrecios into @IdSurt, @IdTipoV, @Folio, @IdProd, @Cantidad, @serie, @Fecha, @PrecioAnt
	while (@@fetch_status = 0)
	begin

		select @Precio = Precio from PreciosDetalle where IdLista = 3 and IdProducto = @IdProd 
		
--		select 4, @IdSurt, @IdTipoV, @Folio, @Serie, @Fecha, @IdProd, @Cantidad, @Precio, 0, 0, 1

		exec up_VentasDetalle 4, @IdSurt, @IdTipoV, @Folio, @Serie, @Fecha, @IdProd, @Cantidad, @Precio, 0, 0, 0, 0, @Cantidad, 1
		
		fetch next from ActPrecios into @IdSurt, @IdTipoV, @Folio, @IdProd, @Cantidad, @serie, @Fecha, @PrecioAnt
	end
	close ActPrecios
	deallocate ActPrecios		
