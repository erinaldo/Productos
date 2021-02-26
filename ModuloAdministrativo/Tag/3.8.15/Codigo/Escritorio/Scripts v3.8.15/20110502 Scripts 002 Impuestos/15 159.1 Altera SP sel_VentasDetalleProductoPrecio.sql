USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalleProductoPrecio]    Script Date: 05/03/2011 16:55:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasDetalleProductoPrecio]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasDetalleProductoPrecio]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalleProductoPrecio]    Script Date: 05/03/2011 16:55:17 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_VentasDetalleProductoPrecio] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@IdProducto as bigint,
@IdCliente as bigint,
@IdRuta as bigint,
@Opc as int

AS

if @Opc = 1
	select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, 
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	VentasDetalle.Cantidad as 'Cantidad', VentasDetalle.Precio as 'Precio', VentasDetalle.Subtotal as 'Subtotal', 
	VentasDetalle.Cantidad * VentasDetalle.Precio * VentasDetalle.Iva as 'Impuestos', VentasDetalle.Total as 'Total'
	from VentasDetalle
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = @IdProducto






GO


