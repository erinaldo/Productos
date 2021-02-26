USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaValidaDev]    Script Date: 12/02/2010 11:27:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ExistenciaValidaDev]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ExistenciaValidaDev]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExistenciaValidaDev]    Script Date: 12/02/2010 11:27:58 ******/
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
	select VentasDetalle.IdProducto, abs(sum(VentasDetalle.Cantidad)), abs(sum(VentasDetalle.Cantidad)) -  isnull(abs(sum(VenDev.Cantidad)),0) - isnull(abs(sum(VenDev2.Cantidad)),0) 
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
	having abs(sum(VentasDetalle.Cantidad)) -  isnull(abs(sum(VenDev.Cantidad)),0) - isnull(abs(sum(VenDev2.Cantidad)),0) > 0
end

if @Opc = 2
begin
		select VentasDetalle.IdProducto, Productos.Producto, 
		isnull(abs(VentasDetalle.Cantidad), 0) as 'Cantidad', isnull(VentasDetalle.Precio, 0) as 'Precio', 
		isnull(VentasDetalle.Subtotal, 0) as 'Subtotal', isnull(abs(VentasDetalle.Cantidad)*VentasDetalle.Precio*VentasDetalle.Iva, 0) as 'Iva', 
		isnull(VentasDetalle.Total, 0) as 'Total', VentasDetalle.DctoPorc, VentasDetalle.DctoImp, 
		isnull(abs(VenDev.Cantidad),0) as Devolucion, ISNULL(abs(VenDev2.Cantidad),0) as OtrasDev, isnull(abs(VenDev.Cantidad),0) + ISNULL(abs(VenDev2.Cantidad),0) as TotalDev,
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


