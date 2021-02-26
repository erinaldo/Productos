declare @IdCedis as bigint,
	@FechaIni as datetime,
	@FechaFin as datetime,
	@IdSurtido as bigint

	set @IdCedis = 1
	set @IdSurtido = 731


	select 2 as Orden,'Ventas de Contado' as Concepto, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido -- between @FechaIni and @FechaFin
	group by Ventas.Fecha

	union

	select 1 as Orden,'Ventas de Crédito' as Concepto, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 2
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido 
	group by Ventas.Fecha

	union

	select 4 as Orden,'Saldo Actual' as Concepto, sum(Saldo) as Total
	from VendedoresSaldos
	where VendedoresSaldos.IdCedis = @IdCedis and VendedoresSaldos.IdSurtido = @IdSurtido 
	and IdTipoSaldo = 'EF'
	group by VendedoresSaldos.Fecha 

	union

	select 3 as Orden,'Efectivo Entregado' as Concepto, sum(Cantidad * IdDenominacion) as Total
	from SurtidosDenominacion
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido
	where SurtidosDenominacion.IdCedis = @IdCedis and SurtidosDenominacion.IdSurtido = @IdSurtido 
	group by Surtidos.Fecha

	union

	select 0 as Orden,'Ventas Totales' as Concepto, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio-- and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido 
	group by Ventas.Fecha 

	order by Orden

	