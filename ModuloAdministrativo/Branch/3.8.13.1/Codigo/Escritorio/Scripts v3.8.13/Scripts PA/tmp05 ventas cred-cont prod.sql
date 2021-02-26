declare @IdCedis as bigint,
	@FechaIni as datetime,
	@FechaFin as datetime

	set @IdCedis = 1
	set @FechaIni = '20100401'
	set @FechaFin = '20100422'


--	select '1-Contado' as Concepto, Ventas.Fecha, VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto, isnull(sum(Cantidad), 0) as Cantidad, 
--	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
--	from Ventas 
--	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
--		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
--	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
--	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaIni and @FechaFin
--	group by Ventas.Fecha, VentasDetalle.IdProducto, Productos.Producto
--
--	union

	select '0-Contado por Precio' as Concepto, Ventas.Fecha, VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto, isnull(sum(Cantidad), 0) as Cantidad, 
	round(Precio,2), isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaIni and @FechaFin
	group by Ventas.Fecha, VentasDetalle.IdProducto, Productos.Producto, round(Precio,2)

	union

	select '2-Crédito' as Concepto, Ventas.Fecha, VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 2
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaIni and @FechaFin
	group by Ventas.Fecha, VentasDetalle.IdProducto, Productos.Producto

	order by Concepto, Ventas.Fecha, VentasDetalle.IdProducto

	