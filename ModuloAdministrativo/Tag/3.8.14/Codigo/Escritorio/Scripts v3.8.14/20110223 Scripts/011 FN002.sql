USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPorSucursalPorFactura]    Script Date: 02/25/2011 09:45:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VentasPorSucursalPorFactura]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VentasPorSucursalPorFactura]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPorSucursalPorFactura]    Script Date: 02/25/2011 09:45:43 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[FN_VentasPorSucursalPorFactura]
(
	@IdCedis as bigint,
	@FechaInicial as datetime,
	@FechaFinal as Datetime
)  
RETURNS Table 

AS  

	Return
	(
		SELECT     VEN.IdCedis, VEN.IdSurtido, VEN.IdTipoVenta, VEN.Folio, VEN.Serie, VEN.Fecha, VEN.IdCliente, VEN.IdSucursal, VENDET.IdProducto, PRO.Producto, 
		                      PRO.IdMarca, PRO.IdGrupo, PRO.IdFamilia, PRO.Conversion, SUM(VENDET.Cantidad) AS Cantidad, AVG(VENDET.Precio) AS PrecioPromedio, 
		                      SUM(VENDET.Cantidad * VENDET.Precio * VENDET.Iva) AS IVA, SUM(VENDET.Subtotal) AS Subtotal, SUM(VENDET.Total) AS Total
		FROM         VentasDetalle VENDET INNER JOIN
		                      Ventas VEN ON VENDET.IdCedis = VEN.IdCedis AND VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
		                      VENDET.Folio = VEN.Folio INNER JOIN
		                      Productos PRO ON VENDET.IdProducto = PRO.IdProducto
		WHERE     (VEN.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND (VENDET.IdCedis = @IdCedis) 
		GROUP BY VEN.IdCedis, VEN.IdSurtido, VEN.IdTipoVenta, VEN.Folio, VEN.Serie, VEN.Fecha, VEN.IdCliente, VENDET.IdProducto, PRO.IdMarca, PRO.IdGrupo, 
		                      PRO.IdFamilia, PRO.Conversion, PRO.Producto, VEN.IdSucursal
	)



GO


