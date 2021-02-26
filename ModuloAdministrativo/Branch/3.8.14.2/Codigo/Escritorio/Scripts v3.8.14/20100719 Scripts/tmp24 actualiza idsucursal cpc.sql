declare @FechaInicial as datetime, @FechaFinal as datetime

set @FechaInicial = '20100611'
set @FechaFinal = '20100611'

declare @IdCedis as bigint, @IdTipoVenta as bigint, @Folio as bigint, 
	@Serie as varchar(5), @Fecha as datetime, @IdCliente as bigint, @Subtotal as money, @Iva as money,
	@IdSucursal as varchar(50), @IdMarca as bigint


declare VentasACPC cursor for

	select VentasADM.IdCedis, VentasADM.IdTipoVenta, VentasADM.Folio, VentasADM.Serie, VentasADM.Fecha, VentasADM.IdCliente, 
	VentasADM.Subtotal, VentasADM.Iva, VentasADM.IdSucursal 
	from RouteADM.dbo.Ventas VentasADM
	left outer join Ventas on Ventas.IdCedis = VentasADM.IdCedis and Ventas.IdTipoVenta = VentasADM.IdTipoVenta
	and Ventas.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = VentasADM.Folio
	where VentasADM.Fecha between @FechaInicial and @FechaFinal--  and Ventas.Folio is null 
	and VentasADM.IdTipoVenta = 2
	order by VentasADM.IdCedis, VentasADM.Serie, VentasADM.Folio

	open VentasACPC
	fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @IdSucursal
		while @@fetch_status = 0
		begin

			select top 1 @IdMarca = IdMarca 
			from RouteADM.dbo.VentasDetalle VentasDetalle 
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
			where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdTipoVenta = @IdTipoVenta
				and VentasDetalle.Folio = @Folio and VentasDetalle.Serie = @Serie
				
			update Ventas set IdMarca = @IdMarca, IdSucursal = @IdSucursal 
			where Ventas.IdCedis = @IdCedis and Ventas.IdTipoVenta = @IdTipoVenta
				and Ventas.Folio = @Folio and Ventas.Serie = @Serie
			
			fetch next from VentasACPC into @IdCedis, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @Subtotal, @Iva, @IdSucursal
		end
	close VentasACPC

deallocate VentasACPC
