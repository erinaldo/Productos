USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_WEB_VentasRuta]    Script Date: 02/25/2011 09:54:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_WEB_VentasRuta]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_WEB_VentasRuta]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_WEB_VentasRuta]    Script Date: 02/25/2011 09:54:14 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE FUNCTION [dbo].[FN_WEB_VentasRuta]
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
	                      TOP 100 PERCENT dbo.Familias.IdFamilia, dbo.Familias.Familia, dbo.Familias.IdGrupo, dbo.Ventas.Fecha, dbo.Periodos.Per_SemNat, 
	                      dbo.Periodos.Per_Dia, dbo.Cedis.IdRegion, dbo.Ventas.IdCedis, SUM(dbo.VentasDetalle.Cantidad * dbo.Productos.Conversion) AS kilolitros, 
	                      SUM(dbo.VentasDetalle.Total) AS Venta, COUNT(dbo.VentasDetalle.Cantidad) AS Piezas, dbo.Rutas.IdRuta, dbo.Rutas.Ruta,dbo.Periodos.Per_NoMes, dbo.Periodos.Per_Mes
	FROM         dbo.VentasDetalle INNER JOIN
	                      dbo.Ventas ON dbo.VentasDetalle.IdCedis = dbo.Ventas.IdCedis AND dbo.VentasDetalle.IdSurtido = dbo.Ventas.IdSurtido AND 
	                      dbo.VentasDetalle.IdTipoVenta = dbo.Ventas.IdTipoVenta AND dbo.VentasDetalle.Folio = dbo.Ventas.Folio INNER JOIN
	                      dbo.Productos ON dbo.VentasDetalle.IdProducto = dbo.Productos.IdProducto INNER JOIN
	                      dbo.Familias ON dbo.Productos.IdFamilia = dbo.Familias.IdFamilia INNER JOIN
	                      dbo.Periodos ON dbo.Ventas.Fecha = dbo.Periodos.Per_Fecha INNER JOIN
	                      dbo.Cedis ON dbo.Ventas.IdCedis = dbo.Cedis.IdCedis INNER JOIN
	                      dbo.Surtidos ON dbo.VentasDetalle.IdCedis = dbo.Surtidos.IdCedis AND dbo.VentasDetalle.IdSurtido = dbo.Surtidos.IdSurtido INNER JOIN
	                      dbo.Rutas ON dbo.Surtidos.IdCedis = dbo.Rutas.IdCedis AND dbo.Surtidos.IdRuta = dbo.Rutas.IdRuta
	WHERE     (dbo.Ventas.Fecha BETWEEN CONVERT(DATETIME, @FechaInicial, 102) AND CONVERT(DATETIME, @FechaFinal, 102)) 
	                      AND (dbo.Cedis.IdRegion <> 0) AND (dbo.Cedis.IdCedis = @IdCedis)
	GROUP BY dbo.Ventas.IdCedis, dbo.Familias.IdGrupo, dbo.Familias.Familia, dbo.Ventas.Fecha, dbo.Familias.IdFamilia, dbo.Periodos.Per_SemNat, 
	                      dbo.Periodos.Per_Dia, dbo.Cedis.IdRegion, dbo.Rutas.IdRuta, dbo.Rutas.Ruta,dbo.Periodos.Per_NoMes, dbo.Periodos.Per_Mes
	ORDER BY dbo.Familias.IdFamilia, dbo.Familias.IdGrupo, dbo.Ventas.Fecha, dbo.Periodos.Per_SemNat,dbo.Periodos.Per_NoMes, dbo.Periodos.Per_Dia, dbo.Cedis.IdRegion, 
	                      dbo.Ventas.IdCedis

	)























GO


