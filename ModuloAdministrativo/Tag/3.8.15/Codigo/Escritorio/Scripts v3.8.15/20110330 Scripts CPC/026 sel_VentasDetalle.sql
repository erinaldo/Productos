USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalle]    Script Date: 04/01/2011 15:13:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalle]    Script Date: 04/01/2011 15:13:51 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_VentasDetalle]
@IdCedis as bigint,
@IdTipoVenta as int,
@Serie as varchar(5),
@Folio as bigint,
@Opc as int

AS

if @Opc = 1
	select VentasDetalle.IdCedis, VentasDetalle.Serie, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, 
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	VentasDetalle.Cantidad as 'Cantidad', VentasDetalle.Precio as 'Precio', VentasDetalle.Subtotal as 'Subtotal', 
	VentasDetalle.Cantidad * VentasDetalle.Precio * VentasDetalle.Iva as 'Iva', VentasDetalle.Total as 'Total',
	Ventas.IdCliente, isnull(Clientes.RazonSocial,'-Cliente No Econtrado-') as RazonSocial,
	Ventas.IdSucursal, isnull(ClienteSucursal.NombreSucursal,'-Sucursal No Econtrada-') as NombreSucursal, TipoVenta, 
	Clientes.RFC, Clientes.Domicilio, Ventas.Status   
	from Ventas 
	left outer join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie and 
		VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio	
	left outer join VentasTipo on VentasTipo.IdTipoVenta = Ventas.IdTipoVenta
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 
	left outer join ClienteSucursal on Clientes.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal 
	left outer join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Serie = @Serie
		and Ventas.IdTipoVenta = @IdTipoVenta and Ventas.Folio = @Folio 
	order by VentasDetalle.IdProducto

if @Opc = 2
	select isnull(sum(subtotal),0), isnull(Sum(cantidad * precio * iva),0), isnull(sum(total),0) from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.Serie = @Serie
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio

if @Opc = 3
	select VentasDetalle.IdProducto, Producto 
	from VentasDetalle 
	left outer join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where IdCedis = @IdCedis and Serie = @Serie and IdTipoVenta = @IdTipoVenta and Folio = @Folio and ( Cantidad = 0 or Precio = 0)

if @Opc = 4
	select VentasDetalle.IdCedis, VentasDetalle.Serie, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, 
	Ventas.IdCliente, Ventas.IdSucursal, Ventas.Fecha, CS.RFC, CS.RazonSocial, 	
	cs.CalleF + ' ' + cs.NumExterior + ' ' + cs.NumInteriorF + ', ' + CS.ColoniaF as Domicilio, 
	cs.PoblacionF + ', ' + cs.EntidadF  as Ciudad, 
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	VentasDetalle.Cantidad as 'Cantidad', VentasDetalle.Entregado as 'Entregado', VentasDetalle.Precio as 'Precio', 
	VentasDetalle.DctoPorc as 'Dcto.', VentasDetalle.DctoImp as 'Dcto. Imp.', VentasDetalle.Subtotal as 'Subtotal', 
	((VentasDetalle.Cantidad * VentasDetalle.Precio ) - VentasDetalle.DctoImp )* VentasDetalle.Iva as 'Iva', VentasDetalle.Total as 'Total', Productos.CodBarras as Codigo
	from Ventas
	left outer join ClienteSucursal CS on CS.IdCedis = Ventas.IdCedis and CS.IdSucursal = Ventas.IdSucursal  
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta 
		and Ventas.Serie = VentasDetalle.Serie and Ventas.Folio = VentasDetalle.Folio 
	left outer join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Serie = @Serie  
	and Ventas.IdTipoVenta = @IdTipoVenta and Ventas.Folio = @Folio 
	order by VentasDetalle.IdProducto


GO


