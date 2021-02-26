USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasImpresion]    Script Date: 05/03/2011 16:36:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_FacturasImpresion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_FacturasImpresion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasImpresion]    Script Date: 05/03/2011 16:36:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_FacturasImpresion] 
@Filtro as varchar(5000),
@Piezas as int,
@Opc as int

AS

if @Opc = 1
begin
	if @Piezas = 1
	begin
		exec( 'select 
		VentasDetalle.IdProducto as ''Cve. Prod.'', Productos.Producto as ''Producto'', 
		sum(VentasDetalle.Cantidad) as ''Cantidad'', avg(VentasDetalle.Precio) as ''Precio'', sum(VentasDetalle.Subtotal) as ''Subtotal'', 
		sum(VentasDetalle.Cantidad * VentasDetalle.Precio * VentasDetalle.Iva) as ''Impuestos'', sum(VentasDetalle.Total) as ''Total''
		from VentasDetalle
		inner join Ventas on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie and 
			VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio	
		inner join VentasTipo on VentasTipo.IdTipoVenta = Ventas.IdTipoVenta
		inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
		where ' + @Filtro + ' 
		group by VentasDetalle.IdProducto, Productos.Producto
		order by VentasDetalle.IdProducto')
	end

	if @Piezas = 2
	begin
		exec( 'select 
		VentasDetalle.IdProducto as ''Cve. Prod.'', Productos.Producto as ''Producto'', 
		sum(VentasDetalle.Cantidad * Conversion) as ''Cantidad'', sum(VentasDetalle.Subtotal) / sum(VentasDetalle.Cantidad * Conversion) as ''Precio'', sum(VentasDetalle.Subtotal) as ''Subtotal'', 
		sum(VentasDetalle.Cantidad * VentasDetalle.Precio * VentasDetalle.Iva) as ''Impuestos'', sum(VentasDetalle.Total) as ''Total''
		from VentasDetalle
		inner join Ventas on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie and 
			VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio	
		inner join VentasTipo on VentasTipo.IdTipoVenta = Ventas.IdTipoVenta
		inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
		where ' + @Filtro + ' 
		group by VentasDetalle.IdProducto, Productos.Producto
		order by VentasDetalle.IdProducto')
	end
end

if @Opc = 2
begin
	if @Piezas = 1
	begin
		exec( 'SELECT Td.ProductoClave as ''Cve. Prod.'', PRO.Nombre as ''Producto'', sum(td.cantidad * PRD.Factor) as ''Cantidad'', sum(td.subtotal) / sum(td.cantidad * PRD.Factor) as ''Precio'', sum(td.subtotal) as ''SubTotal'', sum(td.impuesto) as ''Impuestos'', sum(td.total) as ''Total''
		FROM Route.dbo.TransProd T
		INNER JOIN Route.dbo.Dia D ON D.DiaClave = T.DiaClave
		INNER JOIN Route.dbo.Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
		INNER JOIN Route.dbo.TransProdDetalle TD ON T.TransProdId = TD.TransProdId
		inner join Route.dbo.Producto PRO on PRO.ProductoClave = TD.ProductoClave 
		inner join Route.dbo.ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
		inner join Productos as PR on PR.IdProducto = PRO.ProductoClave
 		inner join ClienteSucursal on ClienteSucursal.IdSucursal = t.ClienteClave
		inner join Clientes on Clientes.IdCliente = ClienteSucursal.IdCliente and Clientes.IdCedis = ClienteSucursal.IdCedis
		where ' + @Filtro + ' 
		AND T.Tipo = 1 AND T.TipoFase <> 0 AND T.TipoFase = 1
		GROUP BY Td.ProductoClave, PRO.Nombre
		ORDER BY cast(Td.ProductoClave as bigint), PRO.Nombre')
	end

	if @Piezas = 2
	begin
		exec( 'SELECT Td.ProductoClave as ''Cve. Prod.'', PRO.Nombre as ''Producto'', sum(td.cantidad * PRD.Factor * Conversion)  as ''Cantidad'', sum(td.subtotal) / sum(td.cantidad * PRD.Factor * Conversion) as ''Precio'', sum(td.subtotal) as ''SubTotal'', sum(td.impuesto) as ''Impuestos'', sum(td.total) as ''Total''
		FROM Route.dbo.TransProd T
		INNER JOIN Route.dbo.Dia D ON D.DiaClave = T.DiaClave
		INNER JOIN Route.dbo.Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
		INNER JOIN Route.dbo.TransProdDetalle TD ON T.TransProdId = TD.TransProdId
		inner join Route.dbo.Producto PRO on PRO.ProductoClave = TD.ProductoClave 
		inner join Route.dbo.ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
		inner join Productos as PR on PR.IdProducto = PRO.ProductoClave
 		inner join ClienteSucursal on ClienteSucursal.IdSucursal = t.ClienteClave
		inner join Clientes on Clientes.IdCliente = ClienteSucursal.IdCliente and Clientes.IdCedis = ClienteSucursal.IdCedis
		where ' + @Filtro + ' 
		AND T.Tipo = 1 AND T.TipoFase <> 0 AND T.TipoFase = 1
		GROUP BY Td.ProductoClave, PRO.Nombre
		ORDER BY cast(Td.ProductoClave as bigint), PRO.Nombre')
	end
end




GO


