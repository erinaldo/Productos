USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPorCliente]    Script Date: 10/13/2010 11:08:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VentasPorCliente]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VentasPorCliente]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPorCliente]    Script Date: 10/13/2010 11:08:31 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE FUNCTION [dbo].[FN_VentasPorCliente]
(
	@IdCedis as bigint,
	@FechaInicial as datetime,
	@FechaFinal as Datetime
)  
RETURNS Table 

AS  

	Return
	(

	select Ventas.IdCedis, Fecha, Ventas.IdCliente, VentasDetalle.IdProducto, Producto, 
	Precio as Precio, sum(Cantidad) as Cantidad, sum(VentasDetalle.Total) as Total, sum( Cantidad * Conversion ) as Kilolitros,
	Conversion, Ventas.IdTipoVenta, Productos.IdMarca, IdGrupo, IdFamilia
	from Ventas
	inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie collate Traditional_Spanish_CI_AS and 
	VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto -- and IdFamilia not in ( 
	where Ventas.Fecha between @fechainicial and @fechafinal and Ventas.IdCedis = @IdCedis and Ventas.Serie not like 'OX%' and Ventas.Serie not like 'BA%' 
	group by Ventas.IdCedis, Fecha, Ventas.IdCliente, VentasDetalle.IdProducto, Producto, Conversion, Ventas.IdTipoVenta, Productos.IdMarca, IdGrupo, IdFamilia, Precio

/*		SELECT     VEN.IdCedis, VEN.Fecha, VEN.IdCliente, VENDET.IdProducto, PROD.Producto, 
		                      VENDET.Precio, SUM(VENDET.Cantidad) AS Cantidad, SUM(VENDET.Subtotal) AS SubTotal, 
		                      SUM(VENDET.Cantidad * VENDET.Precio * VENDET.Iva) AS Iva, SUM(VENDET.Total) AS Total, SUM(VENDET.Cantidad * PROD.Conversion) AS Kilolitros, 
		                      PROD.Conversion, VEN.IdTipoVenta, PROD.IdMarca, PROD.IdGrupo, PROD.IdFamilia
		FROM         Ventas VEN INNER JOIN
		                      VentasDetalle VENDET ON VENDET.IdCedis = VEN.IdCedis AND VENDET.Serie = VEN.Serie AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
		                      VENDET.Folio = VEN.Folio INNER JOIN
		                      Productos PROD ON VENDET.IdProducto = PROD.IdProducto
		WHERE     (VEN.Fecha BETWEEN @FechaInicial AND @FechaFinal) and VEN.IdCedis = @IdCedis
		GROUP BY VEN.IdCedis, VEN.Fecha, VEN.IdCliente, VENDET.IdProducto, VEN.IdTipoVenta, PROD.Producto, 
		                      PROD.Conversion, PROD.IdMarca, PROD.IdGrupo, PROD.IdFamilia, VENDET.Precio*/
	)















GO


