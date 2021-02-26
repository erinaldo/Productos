USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDevoluciones]    Script Date: 12/03/2010 11:55:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasDevoluciones]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasDevoluciones]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDevoluciones]    Script Date: 12/03/2010 11:55:45 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO







CREATE PROCEDURE [dbo].[sel_VentasDevoluciones] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@IdSurtidoD as bigint,
@IdTipoVentaD as bigint,
@FolioD as bigint,
@Opc as int

AS

declare @Filtro as varchar(8000)

if @Opc = 1
begin 

	select VentasDevolucion.IdCedisD, VentasDevolucion.IdSurtidoD, VentasDevolucion.IdTipoVentaD, VentasDevolucion.SerieD, VentasDevolucion.FolioD,
	isnull(VentasTipo.TipoVenta, 'Tipo de Venta no Definido') as 'Tipo de Venta', VentasDevolucion.Tipo
	from VentasDevolucion 
	inner join VentasTipo on VentasDevolucion.IdTipoVentaD = VentasTipo.IdTipoVenta
	where VentasDevolucion.IdCedisD = @IdCedis and VentasDevolucion.IdSurtido = @IdSurtido 
		and VentasDevolucion.IdTipoVenta = @IdTipoVenta and VentasDevolucion.Folio = @Folio 

end

if @Opc = 2
begin
	select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, 
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	abs(VentasDetalle.Cantidad) as 'Cantidad', isnull(abs(VenDev.Cantidad),0) as Devolucion, ISNULL(abs(VenDev2.Cantidad),0) as OtrasDev, isnull(abs(VenDev.Cantidad),0) + ISNULL(abs(VenDev2.Cantidad),0) as TotalDev,
	VentasDetalle.Precio as 'Precio', VentasDetalle.DctoPorc as 'Dcto.', VentasDetalle.DctoImp as 'Dcto. Imp.', VentasDetalle.Subtotal as 'Subtotal', 
	((abs(VentasDetalle.Cantidad) * VentasDetalle.Precio ) - VentasDetalle.DctoImp )* VentasDetalle.Iva as 'Iva', VentasDetalle.Total as 'Total'
	from VentasDetalle
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	left outer join VentasDetalle VenDev on VenDev.IdCedis = @IdCedis and VenDev.IdSurtido = @IdSurtidoD 
		and VenDev.IdTipoVenta = @IdTipoVentaD and VenDev.Folio = @FolioD and VenDev.IdProducto = VentasDetalle.IdProducto 
	left outer join VentasDevolucion on VentasDevolucion.IdCedisD = VentasDetalle.IdCedis and VentasDevolucion.IdSurtido = VentasDetalle.IdSurtido 
		and VentasDevolucion.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDevolucion.Folio = VentasDetalle.Folio 
		and VentasDevolucion.FolioD <> @FolioD 
	left outer join VentasDetalle VenDev2 on VenDev2.IdCedis = VentasDevolucion.IdCedisD and VenDev2.IdSurtido = VentasDevolucion.IdSurtidoD 
		and VenDev2.IdTipoVenta = VentasDevolucion.IdTipoVentaD and VenDev2.Folio = VentasDevolucion.FolioD and VenDev2.IdProducto = VentasDetalle.IdProducto 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio 
	order by VentasDetalle.IdProducto
end




GO


