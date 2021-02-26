USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesEsquemaFecha]    Script Date: 12/20/2010 11:17:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_ComisionesEsquemaFecha]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_ComisionesEsquemaFecha]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_ComisionesEsquemaFecha]    Script Date: 12/20/2010 11:17:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[FN_ComisionesEsquemaFecha]
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
		Inicial, Final, Pago as Factor, sum(cantidad) * Pago as 'Pago',
		sum(Total) * isnull(ComVendM.Porcentaje,0) as AbonoMerma, sum(Total) * isnull(ComVendV.Porcentaje,0) as AbonoVolumen, sum(Total) as VentaTotal
		from Surtidos
		inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
		inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
		inner join Familias on Familias.IdFamilia = Productos.IdFamilia
		left outer join FN_ComisionesEsquema(@IdCedis) on FN_ComisionesEsquema.IdTipoRuta = Rutas.TipoRuta 
			and FN_ComisionesEsquema.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and FN_ComisionesEsquema.IdProducto = VentasDetalle.IdProducto
		left outer join ComEsquemaVendedor ComVendM on FN_ComisionesEsquema.IdComEsquema = ComVendM.IdComEsquema and SurtidosVendedor.IdCedis = ComVendM.IdCedis  
			and SurtidosVendedor.IdVendedor = ComVendM.IdVendedor and VentasDetalle.IdProducto = ComVendM.IdProducto and ComVendM.IdConcepto = 'MERMA'
		left outer join ComEsquemaVendedor ComVendV on FN_ComisionesEsquema.IdComEsquema = ComVendV.IdComEsquema and SurtidosVendedor.IdCedis = ComVendV.IdCedis  
			and SurtidosVendedor.IdVendedor = ComVendV.IdVendedor and VentasDetalle.IdProducto = ComVendV.IdProducto and ComVendV.IdConcepto = 'VOLUMEN'
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal
		group by FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, Inicial, Final, Pago, ConceptoPago, 
		Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, SurtidosVendedor.IdTipoVendedor, TipoVendedor, 
		Surtidos.IdRuta, Rutas.TipoRuta, Productos.IdFamilia, Familia, VentasDetalle.IdProducto, Producto, ComVendM.Porcentaje, ComVendV.Porcentaje
		having sum(Cantidad) between Inicial and Final 

		union

		select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, 
		FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, 2 as IdConceptoPago, ConceptoPago, Rutas.TipoRuta, Surtidos.IdRuta, 
		SurtidosVendedor.IdTipoVendedor, TipoVendedor, Productos.IdFamilia, Familia, 
		VentasDetalle.IdProducto, Producto, round(sum(Cantidad * Conversion),2)  as Venta, 
		Inicial, Final, Pago as Factor, sum(cantidad * Conversion) * Pago as 'Pago',
		sum(Total) * isnull(ComVendM.Porcentaje,0) as AbonoMerma, sum(Total) * isnull(ComVendV.Porcentaje,0) as AbonoVolumen, sum(Total) as VentaTotal
		from Surtidos
		inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
		inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
		inner join Familias on Familias.IdFamilia = Productos.IdFamilia
		left outer join FN_ComisionesEsquema(@IdCedis) on FN_ComisionesEsquema.IdTipoRuta = Rutas.TipoRuta 
			and FN_ComisionesEsquema.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and FN_ComisionesEsquema.IdProducto = VentasDetalle.IdProducto
		left outer join ComEsquemaVendedor ComVendM on FN_ComisionesEsquema.IdComEsquema = ComVendM.IdComEsquema and SurtidosVendedor.IdCedis = ComVendM.IdCedis  
			and SurtidosVendedor.IdVendedor = ComVendM.IdVendedor and VentasDetalle.IdProducto = ComVendM.IdProducto and ComVendM.IdConcepto = 'MERMA'
		left outer join ComEsquemaVendedor ComVendV on FN_ComisionesEsquema.IdComEsquema = ComVendV.IdComEsquema and SurtidosVendedor.IdCedis = ComVendV.IdCedis  
			and SurtidosVendedor.IdVendedor = ComVendV.IdVendedor and VentasDetalle.IdProducto = ComVendV.IdProducto and ComVendV.IdConcepto = 'VOLUMEN'
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal
		group by FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, Inicial, Final, Pago, ConceptoPago, 
		Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, SurtidosVendedor.IdTipoVendedor, TipoVendedor, 
		Surtidos.IdRuta, Rutas.TipoRuta, Productos.IdFamilia, Familia, VentasDetalle.IdProducto, Producto, ComVendM.Porcentaje, ComVendV.Porcentaje
		having round(sum(Cantidad * Conversion),2)  between Inicial and Final 

		union

		select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, 
		FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, 3 as IdConceptoPago, ConceptoPago, Rutas.TipoRuta, Surtidos.IdRuta, 
		SurtidosVendedor.IdTipoVendedor, TipoVendedor, Productos.IdFamilia, Familia, 
		VentasDetalle.IdProducto, Producto, round(sum(Total),2) as Venta, 
		Inicial, Final, Pago as Factor, sum(Total) * Pago as 'Pago',
		sum(Total) * isnull(ComVendM.Porcentaje,0) as AbonoMerma, sum(Total) * isnull(ComVendV.Porcentaje,0) as AbonoVolumen, sum(Total) as VentaTotal
		from Surtidos
		inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
		inner join VentasDetalle on Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
		inner join Familias on Familias.IdFamilia = Productos.IdFamilia
		left outer join FN_ComisionesEsquema(@IdCedis) on FN_ComisionesEsquema.IdTipoRuta = Rutas.TipoRuta 
			and FN_ComisionesEsquema.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor and FN_ComisionesEsquema.IdProducto = VentasDetalle.IdProducto
		left outer join ComEsquemaVendedor ComVendM on FN_ComisionesEsquema.IdComEsquema = ComVendM.IdComEsquema and SurtidosVendedor.IdCedis = ComVendM.IdCedis  
			and SurtidosVendedor.IdVendedor = ComVendM.IdVendedor and VentasDetalle.IdProducto = ComVendM.IdProducto and ComVendM.IdConcepto = 'MERMA'
		left outer join ComEsquemaVendedor ComVendV on FN_ComisionesEsquema.IdComEsquema = ComVendV.IdComEsquema and SurtidosVendedor.IdCedis = ComVendV.IdCedis  
			and SurtidosVendedor.IdVendedor = ComVendV.IdVendedor and VentasDetalle.IdProducto = ComVendV.IdProducto and ComVendV.IdConcepto = 'VOLUMEN'
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal
		group by FN_ComisionesEsquema.IdComEsquema, FN_ComisionesEsquema.Esquema, Inicial, Final, Pago, ConceptoPago, 
		Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, SurtidosVendedor.IdTipoVendedor, TipoVendedor, 
		Surtidos.IdRuta, Rutas.TipoRuta, Productos.IdFamilia, Familia, VentasDetalle.IdProducto, Producto, ComVendM.Porcentaje, ComVendV.Porcentaje
		having round(sum(Total),2) between Inicial and Final 
	)


GO


