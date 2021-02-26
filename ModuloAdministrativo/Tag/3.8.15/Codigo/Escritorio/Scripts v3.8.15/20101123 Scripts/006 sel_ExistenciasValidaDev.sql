USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaValidaDev]    Script Date: 11/24/2010 17:48:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ExistenciaValidaDev]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ExistenciaValidaDev]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaValidaDev]    Script Date: 11/24/2010 17:48:41 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_ExistenciaValidaDev] 
@IdCedisD as bigint,
@IdSurtidoD as bigint,
@IdTipoVentaD as bigint,
@FolioD as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@IdProducto as bigint,
@Cantidad as float,
@CantidadAnterior as float,
@Opc as bigint

AS

if @Opc = 1
begin
	select VentasDetalle.IdProducto, sum(VentasDetalle.Cantidad), sum(VentasDetalle.Cantidad) -  isnull(sum(VenDev.Cantidad),0) - isnull(sum(VenDev2.Cantidad),0) 
	from VentasDetalle
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	left outer join VentasDetalle VenDev on VenDev.IdCedis = @IdCedisd and VenDev.IdSurtido = @IdSurtidoD 
		and VenDev.IdTipoVenta = @IdTipoVentaD and VenDev.Folio = @FolioD and VenDev.IdProducto = VentasDetalle.IdProducto 
	left outer join VentasDevolucion on VentasDevolucion.IdCedisD = VentasDetalle.IdCedis and VentasDevolucion.IdSurtido = VentasDetalle.IdSurtido 
		and VentasDevolucion.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDevolucion.Folio = VentasDetalle.Folio 
		and VentasDevolucion.FolioD <> @FolioD 
	left outer join VentasDetalle VenDev2 on VenDev2.IdCedis = VentasDevolucion.IdCedisD and VenDev2.IdSurtido = VentasDevolucion.IdSurtidoD 
		and VenDev2.IdTipoVenta = VentasDevolucion.IdTipoVentaD and VenDev2.Folio = VentasDevolucion.FolioD and VenDev2.IdProducto = VentasDetalle.IdProducto 
	where VentasDetalle.IdCedis = @IdCedisD and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio 
	group by VentasDetalle.IdProducto 
	having sum(VentasDetalle.Cantidad) -  isnull(sum(VenDev.Cantidad),0) - isnull(sum(VenDev2.Cantidad),0) > 0
end

if @Opc = 2
begin
		select VentasDetalle.IdProducto, Productos.Producto, 
		isnull(VentasDetalle.Cantidad, 0) as 'Cantidad', isnull(VentasDetalle.Precio, 0) as 'Precio', 
		isnull(VentasDetalle.Subtotal, 0) as 'Subtotal', isnull(VentasDetalle.Cantidad*VentasDetalle.Precio*VentasDetalle.Iva, 0) as 'Iva', 
		isnull(VentasDetalle.Total, 0) as 'Total', VentasDetalle.DctoPorc, VentasDetalle.DctoImp, 
		isnull(VenDev.Cantidad,0) as Devolucion, ISNULL(VenDev2.Cantidad,0) as OtrasDev, isnull(VenDev.Cantidad,0) + ISNULL(VenDev2.Cantidad,0) as TotalDev,
		Productos.Decimales 
		from VentasDetalle 
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
		left outer join VentasDetalle VenDev on VenDev.IdCedis = @IdCedisD and VenDev.IdSurtido = @IdSurtidoD 
			and VenDev.IdTipoVenta = @IdTipoVentaD and VenDev.Folio = @FolioD and VenDev.IdProducto = VentasDetalle.IdProducto 
		left outer join VentasDevolucion on VentasDevolucion.IdCedisD = VentasDetalle.IdCedis and VentasDevolucion.IdSurtido = VentasDetalle.IdSurtido 
			and VentasDevolucion.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDevolucion.Folio = VentasDetalle.Folio 
			and VentasDevolucion.FolioD <> @FolioD 
		left outer join VentasDetalle VenDev2 on VenDev2.IdCedis = VentasDevolucion.IdCedisD and VenDev2.IdSurtido = VentasDevolucion.IdSurtidoD 
			and VenDev2.IdTipoVenta = VentasDevolucion.IdTipoVentaD and VenDev2.Folio = VentasDevolucion.FolioD and VenDev2.IdProducto = VentasDetalle.IdProducto 
		where VentasDetalle.IdCedis = @IdCedisD and VentasDetalle.IdSurtido = @IdSurtido 
		and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = @IdProducto 
end

GO


