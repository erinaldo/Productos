declare @IdCedis as bigint,
	@FechaIni as datetime,
	@FechaFin as datetime

	set @IdCedis = 1
	set @FechaIni = '20100401'
	set @FechaFin = '20100422'


	select '2-Contado' as Concepto, Ventas.Fecha, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaIni and @FechaFin
	group by Ventas.Fecha

	union

	select '1-Crédito' as Concepto, Ventas.Fecha, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 2
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaIni and @FechaFin
	group by Ventas.Fecha

	union

	select '5-DeudasAgentes' as Concepto, VendedoresSaldos.Fecha as Fecha, null as Cantidad, null as Precio, sum(Saldo) as Total
	from VendedoresSaldos
	where VendedoresSaldos.IdCedis = @IdCedis and VendedoresSaldos.Fecha between @FechaIni and @FechaFin
	and IdTipoSaldo = 'EF'
	group by VendedoresSaldos.Fecha 

	union

	select '3-Efectivo' as Concepto, Surtidos.Fecha, null as Cantidad, null as Precio, sum(Cantidad * IdDenominacion) as Total
	from SurtidosDenominacion
	inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido
	where SurtidosDenominacion.IdCedis = @IdCedis and Surtidos.Fecha between @FechaIni and @FechaFin
	group by Surtidos.Fecha

	union

	select '4-Documentos (Cheques)' as Concepto, Surtidos.Fecha, null as Cantidad, null as Precio, sum(Importe) as Total
	from SurtidosCheque
	inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido
	where SurtidosCheque.IdCedis = @IdCedis and Surtidos.Fecha between @FechaIni and @FechaFin
	group by Surtidos.Fecha

	union

	select '0-Ventas Totales' as Concepto, Ventas.Fecha, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Total) /sum( Cantidad), 0) as Precio, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio-- and VentasDetalle.IdTipoVenta = 1
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaIni and @FechaFin
	group by Ventas.Fecha 

	order by Fecha, Concepto

	