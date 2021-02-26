USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalle]    Script Date: 05/03/2011 16:54:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalle]    Script Date: 05/03/2011 16:54:05 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_VentasDetalle]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Opc as int

AS

if @Opc = 1
	select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, 
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	VentasDetalle.Cantidad as 'Cantidad', VentasDetalle.Entregado as 'Entregado',
	VentasDetalle.Precio as 'Precio', 
	VentasDetalle.DctoPorc as 'Dcto.', VentasDetalle.DctoImp as 'Dcto. Imp.', VentasDetalle.Subtotal as 'Subtotal', 
	((VentasDetalle.Cantidad * VentasDetalle.Precio ) - VentasDetalle.DctoImp )* VentasDetalle.Iva as 'Impuestos', VentasDetalle.Total as 'Total'
	from VentasDetalle
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio 
	order by VentasDetalle.IdProducto

if @Opc = 2
	select isnull(sum(subtotal),0), isnull(Sum(((cantidad * precio) - DctoImp) * iva),0), isnull(sum(total),0), ISNULL(sum(DctoImp),0)
	from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio

if @Opc = 3
	select VentasDetalle.IdProducto, Producto, Cantidad 
	from VentasDetalle 
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.Precio = 0

if @Opc = 4
	select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, 
	Ventas.IdCliente, Ventas.IdSucursal, Ventas.Fecha, CS.RFC, CS.RazonSocial, 	
	cs.CalleF + ' ' + cs.NumExterior + ' ' + cs.NumInteriorF + ', ' + CS.ColoniaF as Domicilio, 
	cs.PoblacionF + ', ' + cs.EntidadF  as Ciudad, 
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	VentasDetalle.Cantidad as 'Cantidad', VentasDetalle.Entregado as 'Entregado', VentasDetalle.Precio as 'Precio', 
	VentasDetalle.DctoPorc as 'Dcto.', VentasDetalle.DctoImp as 'Dcto. Imp.', VentasDetalle.Subtotal as 'Subtotal', 
	((VentasDetalle.Cantidad * VentasDetalle.Precio ) - VentasDetalle.DctoImp )* VentasDetalle.Iva as 'Impuestos', VentasDetalle.Total as 'Total', Productos.CodBarras as Codigo
	from Ventas
	inner join ClienteSucursal CS on CS.IdCedis = Ventas.IdCedis and CS.IdSucursal = Ventas.IdSucursal  
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta 
		and Ventas.IdSurtido = VentasDetalle.IdSurtido and Ventas.Folio = VentasDetalle.Folio 
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido
	and Ventas.IdTipoVenta = @IdTipoVenta and Ventas.Folio = @Folio 
	order by VentasDetalle.IdProducto


GO


