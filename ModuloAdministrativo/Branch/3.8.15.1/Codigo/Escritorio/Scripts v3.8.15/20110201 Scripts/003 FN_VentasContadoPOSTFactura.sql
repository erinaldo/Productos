USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_VentasPorClientePorFactura]    Script Date: 01/26/2011 12:29:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_VentasContadoPOSTFactura]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_VentasContadoPOSTFactura]
GO

USE [RouteADM]
GO		

/****** Object:  UserDefinedFunction [dbo].[FN_VentasContadoPOSTFactura]    Script Date: 01/26/2011 12:29:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE FUNCTION [dbo].[FN_VentasContadoPOSTFactura]
(
	@IdCedis as bigint,
	@FechaInicial as datetime,
	@FechaFinal as Datetime
)  
RETURNS Table 

AS  

	Return
	(
		select Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Folio, VentasDetalle.IdProducto, sum(VentasDetalle.Cantidad) as Cantidad,
		sum(VentasDetalle.Total)/sum(VentasDetalle.Cantidad) as Precio, sum(VentasDetalle.SubTotal) as SubTotal, sum(VentasDetalle.Iva) as Iva,sum(VentasDetalle.Total) as Total
		from Ventas
		inner join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
			and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
		inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
			Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
		where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal and Ventas.IdTipoVenta = 1 
			and VentasFacturadas.Serie  collate Traditional_Spanish_CI_AS not in (select SerieFacturasCredito from Configuracion where IdCedis = Ventas.IdCedis)
		group by Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Folio, VentasDetalle.IdProducto
	)


GO


