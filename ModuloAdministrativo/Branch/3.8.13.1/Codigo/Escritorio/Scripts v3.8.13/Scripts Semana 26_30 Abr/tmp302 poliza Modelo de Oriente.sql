declare 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdVendedor as bigint,
@IdRuta as bigint, 
@Fecha as datetime,
@Concepto as varchar(25)

set @IdCedis = 3
set @Fecha = '20100426'

if @IdCedis = 3
	set @Concepto = 'VENTAS HUAMANTLA'
else
	set @Concepto = 'VENTAS PUEBLA'

	select 1 as Orden, @IdCedis, @Fecha, '' as Cuenta, 'BANCO HSBC CTA. 1544' as Descripcion, @Concepto as Concepto,
	isnull(( select SUM(IdDenominacion*Cantidad) 
	from Surtidos  
	inner join SurtidosDenominacion on SurtidosDenominacion.IdCedis = Surtidos.IdCedis and SurtidosDenominacion.IdSurtido = Surtidos.IdSurtido
	where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha), 0 ) as Cargo, 0 as Abono

union

select 2 as Orden, @IdCedis, @Fecha, '' as Cuenta, 'CLIENTES CRÉDITOS' as Descripcion, @Concepto as Concepto,
	isnull(( select SUM(Total) 
	from Surtidos  
	inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		and VentasDetalle.IdTipoVenta = 2
	where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha ),0) as Cargo, 0 as Abono

union

	select 3 as Orden, @IdCedis, @Fecha, '' as Cuenta, 'CLIENTES COBROS' as Descripcion, @Concepto as Concepto, 0 as Cargo, 
	isnull(( select SUM(IdDenominacion*Cantidad) 
	from Surtidos  
	inner join SurtidosDenominacion on SurtidosDenominacion.IdCedis = Surtidos.IdCedis and SurtidosDenominacion.IdSurtido = Surtidos.IdSurtido
	where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha), 0 ) -
	isnull(( select SUM(Total) 
	from Surtidos  
	inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		and VentasDetalle.IdTipoVenta = 1
	where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha ),0) as Abono

union

	select SubFamilias.IdSubFamilia + 3 as Orden,  @IdCedis, @Fecha, '' as Cuenta, 'VENTA ' + SubFamilia as Descripcion, @Concepto as Concepto, 0 as Cargo, isnull(SUM(Total),0) as Abono
	from Surtidos  
	inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
	inner join SubFamilias on SubFamilias.IdSubFamilia = Productos.IdSubFamilia 
	where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha  
	group by SubFamilias.IdSubFamilia, SubFamilia 

union

	select 7 as Orden, @IdCedis, @Fecha, '' as Cuenta, 'IVA' as Descripcion, @Concepto as Concepto, 0 as Cargo, 
	isnull(( select SUM(Total*.16) 
	from Surtidos  
	inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
	where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha ),0) as Abono

union

	select SubFamilias.IdSubFamilia + 7 as Orden,  @IdCedis, @Fecha, '' as Cuenta, 'COSTO DE VENTA ' + SubFamilia as Descripcion, @Concepto as Concepto, 
	isnull(( select SUM(Cantidad * PreciosDetalle.Precio ) 
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
		inner join SubFamilias as SubF on SubF.IdSubFamilia = Productos.IdSubFamilia and SubF.IdSubFamilia = SubFamilias.IdSubFamilia 
		left outer join PreciosDetalle on PreciosDetalle.IdProducto = Productos.IdProducto and PreciosDetalle.IdLista=5 
		where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha ),0) as Cargo, 0 as Abono
	from SubFamilias 
	group by SubFamilias.IdSubFamilia, SubFamilia 

union

	select 12 as Orden,  @IdCedis, @Fecha, '' as Cuenta, Producto as Descripcion, @Concepto as Concepto, 0 as Cargo, isnull(SUM(Total),0) as Abono
	from Surtidos  
	inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
	where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha  
	group by Productos.IdProducto, Productos.Producto 
		
order by Orden 