USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPorClienteG]    Script Date: 04/05/2011 23:36:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VentasPorClienteG]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VentasPorClienteG]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPorClienteG]    Script Date: 04/05/2011 23:36:58 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE FUNCTION [dbo].[FN_VentasPorClienteG]
(
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
	inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie and 
	VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto -- and IdFamilia not in ( 
	where Ventas.Fecha between @fechainicial and @fechafinal and Ventas.Serie not in (select Serie from FacturacionGlobal)
	group by Ventas.IdCedis, Fecha, Ventas.IdCliente, VentasDetalle.IdProducto, Producto, Conversion, Ventas.IdTipoVenta, Productos.IdMarca, IdGrupo, IdFamilia, Precio

	)

GO


