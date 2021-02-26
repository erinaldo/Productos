USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasImpresion]    Script Date: 12/09/2010 11:49:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_FacturasImpresion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_FacturasImpresion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasImpresion]    Script Date: 12/09/2010 11:49:26 ******/
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
		sum(VentasDetalle.Cantidad * VentasDetalle.Precio * VentasDetalle.Iva) as ''Iva'', sum(VentasDetalle.Total) as ''Total'', ''Piezas'' as Unidad
		from VentasDetalle
		inner join Ventas on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie and 
			VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and Ventas.IdSurtido = VentasDetalle.IdSurtido
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
		sum(VentasDetalle.Cantidad * VentasDetalle.Precio * VentasDetalle.Iva) as ''Iva'', sum(VentasDetalle.Total) as ''Total'', 
		case Conversion
			when 1 then ''Piezas''
			else ''Cajas''
		end as Unidad
		from VentasDetalle
		inner join Ventas on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie and 
			VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and Ventas.IdSurtido = VentasDetalle.IdSurtido	
		inner join VentasTipo on VentasTipo.IdTipoVenta = Ventas.IdTipoVenta
		inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
		where ' + @Filtro + ' 
		group by VentasDetalle.IdProducto, Productos.Producto, Productos.Conversion
		order by VentasDetalle.IdProducto')
	end
end

if @Opc = 2
begin
	if @Piezas = 1
	begin
		exec( 'SELECT Td.ProductoClave as ''Cve. Prod.'', PRO.Nombre as ''Producto'', sum(td.cantidad * PRD.Factor) as ''Cantidad'', sum(td.subtotal) / sum(td.cantidad * PRD.Factor) as ''Precio'', sum(td.subtotal) as ''SubTotal'', sum(td.impuesto) as ''Iva'', sum(td.total) as ''Total'', ''Piezas'' as Unidad
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
		exec( 'SELECT Td.ProductoClave as ''Cve. Prod.'', PRO.Nombre as ''Producto'', sum(td.cantidad * PRD.Factor * Conversion)  as ''Cantidad'', sum(td.subtotal) / sum(td.cantidad * PRD.Factor * Conversion) as ''Precio'', sum(td.subtotal) as ''SubTotal'', sum(td.impuesto) as ''Iva'', sum(td.total) as ''Total'', 
		case Conversion
			when 1 then ''Piezas''
			else ''Cajas''
		end as Unidad
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
		GROUP BY Td.ProductoClave, PRO.Nombre, PR.Conversion
		ORDER BY cast(Td.ProductoClave as bigint), PRO.Nombre')
	end
end

if @Opc = 5
begin
	if @Piezas = 1
	begin
		exec( 'select 
		PedidosDetalle.IdProducto as ''Cve. Prod.'', Productos.Producto as ''Producto'', 
		sum(PedidosDetalle.Cantidad) as ''Cantidad'', avg(PedidosDetalle.Precio) as ''Precio'', sum(PedidosDetalle.Subtotal) as ''Subtotal'', 
		sum(PedidosDetalle.Cantidad * PedidosDetalle.Precio * PedidosDetalle.Iva) as ''Iva'', sum(PedidosDetalle.Total) as ''Total'', ''Piezas'' as Unidad
		from PedidosDetalle
		inner join Pedidos on PedidosDetalle.IdCedis = Pedidos.IdCedis and PedidosDetalle.IdPedido = Pedidos.IdPedido
		inner join VentasTipo on VentasTipo.IdTipoVenta = Pedidos.IdTipoVenta
		inner join Productos on PedidosDetalle.IdProducto = Productos.IdProducto
		where ' + @Filtro + ' 
		group by PedidosDetalle.IdProducto, Productos.Producto
		order by PedidosDetalle.IdProducto')
	end

	if @Piezas = 2
	begin
		exec( 'select 
		PedidosDetalle.IdProducto as ''Cve. Prod.'', Productos.Producto as ''Producto'', 
		sum(PedidosDetalle.Cantidad * Conversion) as ''Cantidad'', sum(PedidosDetalle.Subtotal) / sum(PedidosDetalle.Cantidad * Conversion) as ''Precio'', sum(PedidosDetalle.Subtotal) as ''Subtotal'', 
		sum(PedidosDetalle.Cantidad * PedidosDetalle.Precio * PedidosDetalle.Iva) as ''Iva'', sum(PedidosDetalle.Total) as ''Total'', 
		case Conversion
			when 1 then ''Piezas''
			else ''Cajas''
		end as Unidad
		from PedidosDetalle
		inner join Pedidos on PedidosDetalle.IdCedis = Pedidos.IdCedis and PedidosDetalle.IdPedido = Pedidos.IdPedido
		inner join VentasTipo on VentasTipo.IdTipoVenta = Pedidos.IdTipoVenta
		inner join Productos on PedidosDetalle.IdProducto = Productos.IdProducto
		where ' + @Filtro + ' 
		group by PedidosDetalle.IdProducto, Productos.Producto, Productos.Conversion
		order by PedidosDetalle.IdProducto')
	end
end

if @Opc = 3
begin
	if SUBSTRING(@Filtro,1,4)=' ( V'
		exec('select distinct Clientes.IdCliente, Clientes.RFC, Clientes.RazonSocial, Clientes.Domicilio
		from Ventas 
		inner join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IdCliente = Ventas.IdCliente 
		where ' + @Filtro + ' ')
	if SUBSTRING(@Filtro,1,2)='t.'
		exec('select distinct Clientes.IdCliente, Clientes.RFC, Clientes.RazonSocial, Clientes.Domicilio
		from  Route.dbo.TransProd T 
		inner join ClienteSucursal on ClienteSucursal.IdSucursal = T.ClienteClave
		inner join Clientes on Clientes.IdCedis = ClienteSucursal.IdCedis and Clientes.IdCliente = ClienteSucursal.IdCliente 
		where ' + @Filtro + ' ')
	if SUBSTRING(@Filtro,1,4)=' ( P'
		exec('select distinct Clientes.IdCliente, Clientes.RFC, Clientes.RazonSocial, Clientes.Domicilio
		from Pedidos 
		inner join Clientes on Clientes.IdCedis = Pedidos.IdCedis and Clientes.IdCliente = Pedidos.IdCliente 
		where ' + @Filtro + ' ')
end

if @Opc = 4
begin
	if SUBSTRING(@Filtro,1,4)=' ( V'
		exec('select distinct ClienteSucursal.IdSucursal,  ClienteSucursal.RFC as RFCS, ClienteSucursal.RazonSocial as RazonSocialF, ClienteSucursal.CalleF + '' '' + ClienteSucursal.NumExteriorF + '' '' + ClienteSucursal.NumInteriorF + '', '' + ClienteSucursal.Colonia + ''. '' + ClienteSucursal.LocalidadF + '', '' + ClienteSucursal.EntidadF + '', CP '' + ClienteSucursal.CPF as DomicilioS, ClienteSucursal.NombreSucursal
		from Ventas 
		inner join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
		where ' + @Filtro + ' ')
	if SUBSTRING(@Filtro,1,2)='t.'
		exec('select distinct ClienteSucursal.IdSucursal,  ClienteSucursal.RFC as RFCS, ClienteSucursal.RazonSocial as RazonSocialF, ClienteSucursal.CalleF + '' '' + ClienteSucursal.NumExteriorF + '' '' + ClienteSucursal.NumInteriorF + '', '' + ClienteSucursal.Colonia + ''. '' + ClienteSucursal.LocalidadF + '', '' + ClienteSucursal.EntidadF  + '', CP '' + ClienteSucursal.CPF as DomicilioS, ClienteSucursal.NombreSucursal
		from Route.dbo.TransProd T 
		inner join ClienteSucursal on ClienteSucursal.IdSucursal = T.ClienteClave
		where ' + @Filtro + ' ')
	if SUBSTRING(@Filtro,1,4)=' ( P'
		exec('select distinct ClienteSucursal.IdSucursal,  ClienteSucursal.RFC as RFCS, ClienteSucursal.RazonSocial as RazonSocialF, ClienteSucursal.CalleF + '' '' + ClienteSucursal.NumExteriorF + '' '' + ClienteSucursal.NumInteriorF + '', '' + ClienteSucursal.Colonia + ''. '' + ClienteSucursal.LocalidadF + '', '' + ClienteSucursal.EntidadF  + '', CP '' + ClienteSucursal.CPF as DomicilioS, ClienteSucursal.NombreSucursal
		from Pedidos 
		inner join ClienteSucursal on ClienteSucursal.IdCedis = Pedidos.IdCedis and ClienteSucursal.IdSucursal = Pedidos.IdSucursal 
		where ' + @Filtro + ' ')
end

if @Opc = 7
begin
	select '990000001' as IdSucursal, 'XAXX010101000' as RFCS, 'PUBLICO GENERAL' as RazonSocialF, 'QUERÉTARO, MÉXICO' as DomicilioS, 'PUBLICO GENERAL' as NombreSucursal
end

GO


