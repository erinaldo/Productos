USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[Rep_FacturasOxxo]    Script Date: 03/24/2011 02:52:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rep_FacturasOxxo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rep_FacturasOxxo]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[Rep_FacturasOxxo]    Script Date: 03/24/2011 02:52:20 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[Rep_FacturasOxxo]
@IdCedisOX as varchar(5000),
@IdTipoVentaOX as varchar(5000),
@SerieOX as varchar(5000),
@FolioOX as varchar(5000),
@Opc as int
as

if @Opc = 1 -- encabezado de la factura
	exec (
	'select Ventas.IDCedis, IdTipoVenta, Serie, Folio, Fecha, Ventas.IdCliente, RFC, RazonSocial, Domicilio, Telefono
	from Ventas
	inner join Clientes on Clientes.IdCedis = Ventas.IDCedis and Clientes.IdCliente = Ventas.IdCliente
	where ' + @IdCedisOX )

if @Opc = 2 -- detalle de la factura poroductos sin iva
	exec (
	'select VentasDetalle.IdProducto, Producto, sum(Cantidad) as Cantidad, avg(Precio) as Precio, sum(VentasDetalle.SubTotal * VentasDetalle.Iva) as Iva,
	sum(Subtotal) as SubTotal, sum(Total) as Total
	from VentasDetalle
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where ( ' + @IdCedisOX  + ' )  and VentasDetalle.Iva = 0
	group by VentasDetalle.IdProducto, Producto
	order by VentasDetalle.IdProducto' )

if @Opc = 4 -- detalle de la factura productos con iva
	exec (
	'select VentasDetalle.IdProducto, Producto, sum(Cantidad) as Cantidad, avg(Precio) as Precio, sum(VentasDetalle.SubTotal * VentasDetalle.Iva) as Iva,
	sum(Subtotal) as SubTotal, sum(Total) as Total
	from VentasDetalle
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where ( ' + @IdCedisOX  + ' ) and VentasDetalle.Iva <> 0
	group by VentasDetalle.IdProducto, Producto
	order by VentasDetalle.IdProducto' )

if @Opc = 3 -- Folios
	exec (
	'select distinct Serie + ''-'' + replicate(0, 7 - len(Folio) ) + cast(Folio as varchar(10)) as Folio
	from FacturasOxxo
	where ' + @IdCedisOX )
	
if @Opc = 5 
	exec ('	select '''', '''', '''', '''', '''', 
	Ventas.IdCliente, Ventas.Fecha, CS.RFC, CS.RazonSocial, 	
	CS.Domicilio, '''' as Ciudad, 
	VentasDetalle.IdProducto as ''Cve. Prod.'', Productos.Producto as ''Producto'', 
	sum(VentasDetalle.Cantidad) as ''Cantidad'', sum(VentasDetalle.Entregado) as ''Entregado'', (sum(VentasDetalle.Subtotal) / sum(VentasDetalle.Cantidad)) as ''Precio'', 
	avg(VentasDetalle.DctoPorc) as ''Dcto.'', sum(VentasDetalle.DctoImp) as ''Dcto. Imp.'', sum(VentasDetalle.Subtotal) as ''Subtotal'', 
	sum(VentasDetalle.Subtotal * VentasDetalle.Iva ) as ''Iva'', 
	sum(VentasDetalle.Total) as ''Total'', Productos.CodBarras as Codigo
	from Ventas
	left outer join Clientes CS on CS.IdCedis = Ventas.IdCedis and CS.IdCliente = Ventas.IdCliente
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta 
		and Ventas.Serie = VentasDetalle.Serie and Ventas.Folio = VentasDetalle.Folio 
	left outer join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where ( ' + @IdCedisOX  + ' )
	group by Ventas.IdCliente, Ventas.Fecha, CS.RFC, CS.RazonSocial, CS.Domicilio, VentasDetalle.IdProducto, Productos.Producto, Productos.CodBarras
	order by VentasDetalle.IdProducto')

/*
if @Opc = 1 -- encabezado de la factura
	exec (
	'select Ventas.IDCedis, IdTipoVenta, Serie, Folio, Fecha, Ventas.IdCliente, RFC, RazonSocial, Domicilio, Telefono
	from Ventas
	inner join Clientes on Clientes.IdCedis = Ventas.IDCedis and Clientes.IdCliente = Ventas.IdCliente
	where Ventas.IdCedis in (' + @IdCedisOX +') and Ventas.IdTipoVenta in (' + @IdTipoVentaOX +') and Ventas.Serie in (' + @SerieOX +') and Ventas.Folio in (' + @FolioOX +')' )

if @Opc = 2 -- detalle de la factura poroductos sin iva
	exec (
	'select VentasDetalle.IdProducto, Producto, sum(Cantidad) as Cantidad, avg(Precio) as Precio, sum(VentasDetalle.SubTotal * VentasDetalle.Iva) as Iva,
	sum(Subtotal) as SubTotal, sum(Total) as Total
	from VentasDetalle
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where VentasDetalle.IdCedis in (' + @IdCedisOX +') and VentasDetalle.IdTipoVenta in (' + @IdTipoVentaOX +') 
	and VentasDetalle.Serie in (' + @SerieOX +') and VentasDetalle.Folio in (' + @FolioOX +') and VentasDetalle.Iva = 0
	group by VentasDetalle.IdProducto, Producto
	order by VentasDetalle.IdProducto' )

if @Opc = 4 -- detalle de la factura productos con iva
	exec (
	'select VentasDetalle.IdProducto, Producto, sum(Cantidad) as Cantidad, avg(Precio) as Precio, sum(VentasDetalle.SubTotal * VentasDetalle.Iva) as Iva,
	sum(Subtotal) as SubTotal, sum(Total) as Total
	from VentasDetalle
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where VentasDetalle.IdCedis in (' + @IdCedisOX +') and VentasDetalle.IdTipoVenta in (' + @IdTipoVentaOX +') 
	and VentasDetalle.Serie in (' + @SerieOX +') and VentasDetalle.Folio in (' + @FolioOX +') and VentasDetalle.Iva <> 0
	group by VentasDetalle.IdProducto, Producto
	order by VentasDetalle.IdProducto' )

if @Opc = 3 -- Folios
	exec (
	'select distinct Serie + ''-'' + replicate(0, 7 - len(Folio) ) + cast(Folio as varchar(10)) as Folio
	from FacturasOxxo
	where FacturasOxxo.IdCedisOX in (' + @IdCedisOX +') and FacturasOxxo.IdTipoVentaOX in (' + @IdTipoVentaOX +') and FacturasOxxo.SerieOX in (' + @SerieOX +') and FacturasOxxo.FolioOX in (' + @FolioOX +')' )

if @Opc = 5 -- Totales de la factura
	exec (
	'select sum(SubTotal), sum(Iva), sum(Total)
	from VentasDetalle
	where VentasDetalle.IdCedis in (' + @IdCedisOX +') and VentasDetalle.IdTipoVenta in (' + @IdTipoVentaOX +') and Ventas.Serie in (' + @SerieOX +') and Ventas.Folio in (' + @FolioOX +')' )
*/

GO


