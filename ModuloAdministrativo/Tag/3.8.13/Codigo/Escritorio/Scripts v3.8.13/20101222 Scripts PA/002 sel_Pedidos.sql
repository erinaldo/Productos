USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Pedidos]    Script Date: 12/22/2010 11:17:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Pedidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Pedidos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Pedidos]    Script Date: 12/22/2010 11:17:51 ******/
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

declare @IdPedido as varchar(20)

if @Opc = 1
begin 

	set @IdPedido = @Ruta

	if @Filtro = '0' set @Filtro = ' and ( Pedidos.Folio = 0 or Pedidos.Folio is null )' 
	if @Filtro = '1' set @Filtro = ' and Pedidos.Folio <> 0 ' 
	if @Filtro = '2' set @Filtro = '' 
	if @Ruta <> '' set @Ruta = ' and (Pedidos.IdRutaPedido = ' + @Ruta + ' or Pedidos.IdRutaEntrega = ' + @Ruta + ') '
	
	exec ( 'select Pedidos.IdCedis, Pedidos.IdPedido, Pedidos.IdTipoVenta, isnull(VentasTipo.TipoVenta, ''Tipo de Venta no Definido'') as ''Tipo de Venta'', Pedidos.IdPedido, 
	Pedidos.IdRutaPedido as ''R. Pedido'', Pedidos.FechaPedido as ''F. Pedido'', Pedidos.IdRutaEntrega as ''R. Entrega'', Pedidos.FechaEntrega as ''F. Entrega'', 
	Pedidos.IdCliente as ''No. Cliente'', isnull(Clientes.RazonSocial, ''Cliente no encontrado'')  as ''Cliente'', 
	Pedidos.Subtotal as ''Subtotal'', Pedidos.Iva as ''Iva'', Pedidos.Total as ''Total'', isnull( ClienteSucursal.CodigoBarras, '' - '') as ''Código de Barras'', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
	Pedidos.FechaPedido, isnull(ClienteSucursal.RFC, ''-'') as RFC, Clientes.Domicilio, Clientes.Telefono, isnull(PreciosLista.IdLista,0), isnull(PreciosLista.Descripcion, ''El Cliente no tiene Lista de Precios asignada''),
	IdSurtido, Serie, Folio, isnull(FolioImpresion,'''') as FolioImpresion
	from Pedidos
	left outer join PedidosFacturados on TransProdId = ''C'' + replicate(''0'', 2 - len(' + @IdCedis + ')) + cast(' + @IdCedis + 'as varchar(2)) + ''Ped'' + replicate(''0'', 9 - len(Pedidos.IdPedido)) + cast(Pedidos.IdPedido as varchar(10))
	left outer join VentasTipo on Pedidos.IdTipoVenta = VentasTipo.IdTipoVenta
	left outer join Clientes on Pedidos.IdCliente = Clientes.IdCliente and Clientes.IdCedis = Pedidos.IdCedis
	left outer join ClienteSucursal on Pedidos.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = Pedidos.IdCedis and ClienteSucursal.IdSucursal = Pedidos.IdSucursal
	left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
	left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
	where Pedidos.IdCedis = ' + @IdCedis + ' and Pedidos.FechaPedido = ''' + @FechaP + ''' ' + @Filtro + '  ' + @Ruta + '
	order by Pedidos.IdPedido desc')
	
end

if @Opc = 2
	select isnull(MAX(IdPedido) + 1, 1)
	from Pedidos 
	where IdCedis = @IdCedis  -- and FechaPedido = @FechaP 




GO


