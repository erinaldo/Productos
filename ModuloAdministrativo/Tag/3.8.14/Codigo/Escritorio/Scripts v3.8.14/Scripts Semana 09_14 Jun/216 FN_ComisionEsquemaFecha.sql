USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesEsquemaFecha]    Script Date: 06/09/2010 16:27:48 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER FUNCTION [dbo].[FN_ComisionesEsquemaFecha]
(
	@IdCedis as bigint,
	@FechaInicial as datetime,
	@FechaFinal as datetime
)  
RETURNS Table 

AS  
		
	Return
	(
		select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, 
		FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, 1 as IdConceptoPago, ConceptoPago, Rutas.TipoRuta, Surtidos.IdRuta, 
		SurtidosVendedor.IdTipoVendedor, TipoVendedor, Productos.IdFamilia, Familia, 
		VentasDetalle.IdProducto, Producto, sum(Cantidad) as Venta, 
		Inicial, Final, Pago as Factor, sum(cantidad) * Pago as 'Pago'
		from Surtidos
		inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
		inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
		inner join Familias on Familias.IdFamilia = Productos.IdFamilia
		left outer join FN_ComisionesEsquema(@IdCedis) on FN_ComisionesEsquema.IdTipoRuta = Rutas.TipoRuta 
			and FN_ComisionesEsquema.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and FN_ComisionesEsquema.IdProducto = VentasDetalle.IdProducto
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal
		group by FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, Inicial, Final, Pago, ConceptoPago, 
		Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, SurtidosVendedor.IdTipoVendedor, TipoVendedor, 
		Surtidos.IdRuta, Rutas.TipoRuta, Productos.IdFamilia, Familia, VentasDetalle.IdProducto, Producto
		having sum(Cantidad) between Inicial and Final 

		union

		select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, 
		FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, 2 as IdConceptoPago, ConceptoPago, Rutas.TipoRuta, Surtidos.IdRuta, 
		SurtidosVendedor.IdTipoVendedor, TipoVendedor, Productos.IdFamilia, Familia, 
		VentasDetalle.IdProducto, Producto, round(sum(Cantidad * Conversion),2)  as Venta, 
		Inicial, Final, Pago as Factor, sum(cantidad * Conversion) * Pago as 'Pago'
		from Surtidos
		inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
		inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
		inner join Familias on Familias.IdFamilia = Productos.IdFamilia
		left outer join FN_ComisionesEsquema(@IdCedis) on FN_ComisionesEsquema.IdTipoRuta = Rutas.TipoRuta 
			and FN_ComisionesEsquema.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and FN_ComisionesEsquema.IdProducto = VentasDetalle.IdProducto
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal
		group by FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, Inicial, Final, Pago, ConceptoPago, 
		Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, SurtidosVendedor.IdTipoVendedor, TipoVendedor, 
		Surtidos.IdRuta, Rutas.TipoRuta, Productos.IdFamilia, Familia, VentasDetalle.IdProducto, Producto
		having round(sum(Cantidad * Conversion),2)  between Inicial and Final 

		union

		select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, 
		FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, 3 as IdConceptoPago, ConceptoPago, Rutas.TipoRuta, Surtidos.IdRuta, 
		SurtidosVendedor.IdTipoVendedor, TipoVendedor, Productos.IdFamilia, Familia, 
		VentasDetalle.IdProducto, Producto, round(sum(Total),2) as Venta, 
		Inicial, Final, Pago as Factor, sum(Total) * Pago as 'Pago'
		from Surtidos
		inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
		inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
		inner join Familias on Familias.IdFamilia = Productos.IdFamilia
		left outer join FN_ComisionesEsquema(@IdCedis) on FN_ComisionesEsquema.IdTipoRuta = Rutas.TipoRuta 
			and FN_ComisionesEsquema.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and FN_ComisionesEsquema.IdProducto = VentasDetalle.IdProducto
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal
		group by FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, Inicial, Final, Pago, ConceptoPago, 
		Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, SurtidosVendedor.IdTipoVendedor, TipoVendedor, 
		Surtidos.IdRuta, Rutas.TipoRuta, Productos.IdFamilia, Familia, VentasDetalle.IdProducto, Producto
		having round(sum(Total),2) between Inicial and Final 
	)

GO


