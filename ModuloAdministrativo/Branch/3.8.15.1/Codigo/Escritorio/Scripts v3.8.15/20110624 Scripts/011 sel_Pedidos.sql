USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Pedidos]    Script Date: 06/27/2011 16:24:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Pedidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Pedidos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Pedidos]    Script Date: 06/27/2011 16:24:09 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sel_Pedidos] 
@IdCedis as bigint,
@FechaP as datetime,
@Filtro as varchar(1000),
@Ruta as varchar(1000),
@Opc as int

AS

if @Opc = 1
begin 

	if @Filtro = '0' set @Filtro = ' and ( Pedidos.IdSurtido = 0 or Pedidos.IdSurtido is null )' 
	if @Filtro = '1' set @Filtro = ' and Pedidos.IdSurtido <> 0 ' 
	if @Filtro = '2' set @Filtro = '' 
	if @Ruta <> '' set @Ruta = ' and (Pedidos.IdRutaPedido = ' + @Ruta + ' or Pedidos.IdRutaEntrega = ' + @Ruta + ') '
	
	exec ( 'select Pedidos.IdCedis, Pedidos.IdPedido, Pedidos.IdTipoVenta, isnull(VentasTipo.TipoVenta, ''Tipo de Venta no Definido'') as ''Tipo de Venta'', Pedidos.IdPedido, 
	Pedidos.IdRutaPedido as ''R. Pedido'', Pedidos.FechaPedido as ''F. Pedido'', Pedidos.IdRutaEntrega as ''R. Entrega'', Pedidos.FechaEntrega as ''F. Entrega'', 
	Pedidos.IdCliente as ''No. Cliente'', isnull(Clientes.RazonSocial, ''Cliente no encontrado'')  as ''Cliente'', 
	Pedidos.Subtotal as ''Subtotal'', Pedidos.DctoImp as ''Dcto.'', Pedidos.Iva as ''Iva'', Pedidos.Total as ''Total'', isnull( ClienteSucursal.CodigoBarras, '' - '') as ''Código de Barras'', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
	Pedidos.FechaPedido, isnull(ClienteSucursal.RFC, ''-'') as RFC, Clientes.Domicilio, Clientes.Telefono, isnull(PreciosLista.IdLista,0), isnull(PreciosLista.Descripcion, ''El Cliente no tiene Lista de Precios asignada''),
	Pedidos.IdSurtido, isnull(VentasFacturaCFD.SerieFactura,'''') as SerieFactura, isnull(VentasFacturaCFD.FolioFactura,0) as FolioFactura, ISNULL(case Trp.TipoFase when ''0'' then ''B'' when null then '''' else ''E'' end,'''') as Emitida
	from Pedidos
	left outer join VentasTipo on Pedidos.IdTipoVenta = VentasTipo.IdTipoVenta
	left outer join Clientes on Pedidos.IdCliente = Clientes.IdCliente and Clientes.IdCedis = Pedidos.IdCedis
	left outer join ClienteSucursal on Pedidos.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = Pedidos.IdCedis and ClienteSucursal.IdSucursal = Pedidos.IdSucursal
	left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
	left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
	left outer join VentasFacturaCFD on VentasFacturaCFD.IdCedis = Pedidos.IdCedis and VentasFacturaCFD.IdPedido = Pedidos.IdPedido
	left outer join Route.dbo.TransProd Trp on Trp.TransProdID = VentasFacturaCFD.TransprodIdFactura and Trp.Tipo = 8 and Trp.TipoFase <> ''0''
	where Pedidos.IdCedis = ' + @IdCedis + ' and Pedidos.FechaPedido = ''' + @FechaP + ''' ' + @Filtro + '  ' + @Ruta + '
	order by Pedidos.IdPedido desc')
	
end

if @Opc = 2
	select isnull(MAX(IdPedido) + 1, 1)
	from Pedidos 
	where IdCedis = @IdCedis  -- and FechaPedido = @FechaP 





GO


