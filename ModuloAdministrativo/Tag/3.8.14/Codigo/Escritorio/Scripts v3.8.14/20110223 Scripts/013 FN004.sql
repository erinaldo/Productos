USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_WEB_VentasCedisRutaSku]    Script Date: 02/25/2011 09:49:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_WEB_VentasCedisRutaSku]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_WEB_VentasCedisRutaSku]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_WEB_VentasCedisRutaSku]    Script Date: 02/25/2011 09:49:19 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE FUNCTION [dbo].[FN_WEB_VentasCedisRutaSku]
(
	@IdCedis as bigint, 
	@FechaInicial as datetime,
	@FechaFinal as Datetime
)  
RETURNS Table 

AS  

	Return
	(
	SELECT DISTINCT 
	              TOP 100 PERCENT dbo.Familias.IdFamilia, dbo.Familias.Familia, dbo.Familias.IdGrupo, dbo.Productos.IdProducto, dbo.Productos.Producto, 
	              dbo.Cedis.IdRegion, dbo.Ventas.IdCedis, SUM(dbo.VentasDetalle.Cantidad * dbo.Productos.Conversion) AS kilolitros, SUM(dbo.VentasDetalle.Total) 
	              AS Venta, COUNT(dbo.VentasDetalle.Cantidad) AS Piezas, dbo.Rutas.IdRuta, dbo.Rutas.Ruta
	FROM         dbo.VentasDetalle INNER JOIN
	              dbo.Ventas ON dbo.VentasDetalle.IdCedis = dbo.Ventas.IdCedis AND dbo.VentasDetalle.IdSurtido = dbo.Ventas.IdSurtido AND 
	              dbo.VentasDetalle.IdTipoVenta = dbo.Ventas.IdTipoVenta AND dbo.VentasDetalle.Folio = dbo.Ventas.Folio INNER JOIN
	              dbo.Productos ON dbo.VentasDetalle.IdProducto = dbo.Productos.IdProducto INNER JOIN
	              dbo.Familias ON dbo.Productos.IdFamilia = dbo.Familias.IdFamilia INNER JOIN
	              dbo.Periodos ON dbo.Ventas.Fecha = dbo.Periodos.Per_Fecha INNER JOIN
	              dbo.Cedis ON dbo.Ventas.IdCedis = dbo.Cedis.IdCedis INNER JOIN
	              dbo.Surtidos ON dbo.VentasDetalle.IdCedis = dbo.Surtidos.IdCedis AND dbo.VentasDetalle.IdSurtido = dbo.Surtidos.IdSurtido INNER JOIN
	              dbo.Rutas ON dbo.Surtidos.IdCedis = dbo.Rutas.IdCedis AND dbo.Surtidos.IdRuta = dbo.Rutas.IdRuta
	WHERE     (dbo.Ventas.Fecha BETWEEN CONVERT(DATETIME, @fechainicial, 102) AND CONVERT(DATETIME,@fechafinal, 102))
	              AND (dbo.Cedis.IdRegion <> 0) AND (dbo.Cedis.IdCedis = @idcedis)
	GROUP BY dbo.Ventas.IdCedis, dbo.Familias.IdGrupo, dbo.Familias.Familia, dbo.Familias.IdFamilia, dbo.Cedis.IdRegion, dbo.Rutas.IdRuta, dbo.Rutas.Ruta, 
	              dbo.Productos.IdProducto, dbo.Productos.Producto
	ORDER BY dbo.Familias.IdFamilia, dbo.Familias.IdGrupo, dbo.Productos.IdProducto, dbo.Cedis.IdRegion, dbo.Ventas.IdCedis, dbo.Rutas.IdRuta
	)









GO


