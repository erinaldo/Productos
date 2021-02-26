USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_DiasSucursalProducto]    Script Date: 10/11/2010 13:27:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_DiasSucursalProducto]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_DiasSucursalProducto]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_DiasSucursalProducto]    Script Date: 10/11/2010 13:27:18 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[FN_DiasSucursalProducto]
(
	@FechaInicial as datetime,
	@FechaFinal as Datetime
)  
RETURNS Table 

AS  

	Return
	(
	select StatusDia.IdCedis, StatusDia.Fecha, ClienteSucursal.IdSucursal, ClienteSucursal.NombreSucursal, Productos.IdProducto, Productos.Producto
	from ClienteSucursal 
	inner join StatusDia on StatusDia.Fecha between @FechaInicial and @FechaFinal and ClienteSucursal.IdCedis = StatusDia.IdCedis
	inner join Productos on Productos.IdProducto > 0
	where ClienteSucursal.IdSucursal <> ''
	)


GO


