

	select Surtidos.Fecha, Surtidos.IdRuta, Ventas.IdSucursal, NombreSucursal, 
	Calle + ' ' + NumExterior + ' ' + NumInterior as Direccion, Colonia as Colonia,
	sum(Cantidad) as Piezas, sum(Cantidad * Conversion) as Cajas, sum(VentasDetalle.total) as Importe
	from Surtidos 
	inner join Ventas on Surtidos.IdCedis = Ventas.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 	
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	inner join ClienteSucursal on ClienteSucursal.IdSucursal = Ventas.IdSucursal
	where Surtidos.IdCedis = 1 and Surtidos.Fecha between '20100401' and '20100401'
	group by Surtidos.Fecha, Surtidos.IdRuta, Ventas.IdSucursal, NombreSucursal, Calle, NumExterior, NumInterior, Colonia
	order by Surtidos.Fecha, Surtidos.IdRuta, Ventas.IdSucursal