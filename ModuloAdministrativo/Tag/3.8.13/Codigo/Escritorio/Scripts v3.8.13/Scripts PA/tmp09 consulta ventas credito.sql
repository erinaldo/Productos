
	select Ventas.Fecha, Ventas.IdCliente, Clientes.RazonSocial as Cliente, 
		isnull(sum(Cantidad), 0) as Cantidad, isnull(sum(VentasDetalle.total), 0) as Total
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 2
	inner join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IdCliente = Ventas.IdCliente 
	where Ventas.IdCedis = 1 and Ventas.Fecha between '20100401' and '20100401'
	group by Ventas.Fecha, Ventas.IdCliente, Clientes.RazonSocial
	order by Ventas.Fecha, Clientes.RazonSocial

