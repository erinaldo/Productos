USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Pedidos]    Script Date: 09/20/2010 10:30:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Pedidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Pedidos]
GO

/****** Object:  StoredProcedure [dbo].[sel_PedidosDetalle]    Script Date: 09/20/2010 10:30:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_PedidosDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_PedidosDetalle]
GO

/****** Object:  StoredProcedure [dbo].[up_Pedidos]    Script Date: 09/20/2010 10:30:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Pedidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Pedidos]
GO

/****** Object:  StoredProcedure [dbo].[up_PedidosDetalle]    Script Date: 09/20/2010 10:30:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PedidosDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PedidosDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Pedidos]    Script Date: 09/20/2010 10:30:36 ******/
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

	if @Filtro = '0' set @Filtro = ' and ( Pedidos.Folio = 0 or Pedidos.Folio is null )' 
	if @Filtro = '1' set @Filtro = ' and Pedidos.Folio <> 0 ' 
	if @Filtro = '2' set @Filtro = '' 
	if @Ruta <> '' set @Ruta = ' and (Pedidos.IdRutaPedido = ' + @Ruta + ' or Pedidos.IdRutaEntrega = ' + @Ruta + ') '
	
	exec ( 'select Pedidos.IdCedis, Pedidos.IdPedido, Pedidos.IdTipoVenta, isnull(VentasTipo.TipoVenta, ''Tipo de Venta no Definido'') as ''Tipo de Venta'', Pedidos.IdPedido, 
	Pedidos.IdRutaPedido as ''R. Pedido'', Pedidos.FechaPedido as ''F. Pedido'', Pedidos.IdRutaEntrega as ''R. Entrega'', Pedidos.FechaEntrega as ''F. Entrega'', 
	Pedidos.IdCliente as ''No. Cliente'', isnull(Clientes.RazonSocial, ''Cliente no encontrado'')  as ''Cliente'', 
	Pedidos.Subtotal as ''Subtotal'', Pedidos.Iva as ''Iva'', Pedidos.Total as ''Total'', isnull( ClienteSucursal.CodigoBarras, '' - '') as ''Código de Barras'', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
	Pedidos.FechaPedido, isnull(ClienteSucursal.RFC, ''-'') as RFC, Clientes.Domicilio, Clientes.Telefono, isnull(PreciosLista.IdLista,0), isnull(PreciosLista.Descripcion, ''El Cliente no tiene Lista de Precios asignada''),
	IdSurtido, Serie, Folio 
	from Pedidos
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

/****** Object:  StoredProcedure [dbo].[sel_PedidosDetalle]    Script Date: 09/20/2010 10:30:37 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_PedidosDetalle]
@IdCedis as bigint,
@IdPedido as bigint,
@IdProducto as bigint,
@Opc as int

AS

if @Opc = 1
	select PedidosDetalle.IdCedis, PedidosDetalle.IdPedido, PedidosDetalle.IdTipoVenta,
	PedidosDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	PedidosDetalle.Cantidad as 'Cantidad', -- PedidosDetalle.Entregado as 'Entregado',
	PedidosDetalle.Precio as 'Precio', 
	-- PedidosDetalle.DctoPorc as 'Dcto.', PedidosDetalle.DctoImp as 'Dcto. Imp.', 
	PedidosDetalle.Subtotal as 'Subtotal', 
	((PedidosDetalle.Cantidad * PedidosDetalle.Precio ) - PedidosDetalle.DctoImp )* PedidosDetalle.Iva as 'Iva', PedidosDetalle.Total as 'Total'
	from PedidosDetalle
	inner join Productos on PedidosDetalle.IdProducto = Productos.IdProducto
	where PedidosDetalle.IdCedis = @IdCedis and PedidosDetalle.IdPedido = @IdPedido
	order by PedidosDetalle.IdProducto

if @Opc = 2
begin
        select Productos.IdProducto, Producto, isnull(Cantidad,0), isnull(Entregado,0), isnull(DctoPorc,0), isnull(DctoImp,0), Productos.Iva, Decimales
        from Productos 
        left outer join PedidosDetalle on PedidosDetalle.IdProducto = Productos.IdProducto 
			and PedidosDetalle.IdCedis = @IdCedis and PedidosDetalle.IdPedido = @IdPedido 
        where Productos.IdProducto = @IdProducto
end

if @Opc = 3
begin
	select isnull(sum(subtotal),0), isnull(Sum(((cantidad * precio) - DctoImp) * iva),0), isnull(sum(total),0), ISNULL(sum(DctoImp),0)
	from PedidosDetalle 
	where PedidosDetalle.IdCedis = @IdCedis and PedidosDetalle.IdPedido = @IdPedido 
end


GO

/****** Object:  StoredProcedure [dbo].[up_Pedidos]    Script Date: 09/20/2010 10:30:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_Pedidos] 
@IdCedis as bigint,
@IdPedido as bigint,
@IdTipoVenta as int,
@FechaPedido as datetime,
@IdRutaPedido as bigint,
@FechaEntrega as datetime,
@IdRutaEntrega as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@IdSurtido as bigint,
@Serie as varchar(5),
@Folio as bigint,
@Opc as int

AS

declare @DiasCredito as bigint

if @Opc = 1 -- Inserta Pedido Nueva
begin
	select @IdPedido = isnull(MAX(IdPedido) + 1, 1)
	from Pedidos 
	where IdCedis = @IdCedis  

	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2

	insert into Pedidos values (@IdCedis, @IdPedido, @IdTipoVenta, @FechaPedido, @IdRutaPedido, @FechaEntrega, @IdRutaEntrega, 
		@IdCliente, @IdSucursal, 0, 0, 0, 0, '', 0, @DiasCredito)	
end

if @Opc = 2
begin
	delete from Pedidos where IdCedis = @IdCedis and IdPedido = @IdPedido 
	delete from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido 
end

if @Opc = 3
begin

	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2

	select @IdRutaEntrega = IdRuta, @FechaEntrega = Fecha 
	from Surtidos
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	
	select @Serie = SerieRemisiones 
	from Configuracion 
	where IdCedis = @IdCedis 
	
	set @Folio = (select isnull(MAX(Folio) + 1, 1) from Ventas where IdCedis = @IdCedis and Serie = @Serie)
	
	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @FechaEntrega, @IdCliente, 0, 0, @IdSucursal, 0, @DiasCredito)	

	update Pedidos set IdRutaEntrega = @IdRutaEntrega, FechaEntrega = @FechaEntrega, Serie = @Serie, Folio = @Folio, IdSurtido = @IdSurtido  
	where IdCedis = @IdCedis and IdPedido = @IdPedido 

	insert into VentasDetalle -- values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc, @Entregado)
	select IdCedis, @IdSurtido, IdTipoVenta, @Folio, IdProducto, @Serie, Cantidad, Precio, Iva, 0, 0
	from PedidosDetalle 
	where IdCedis = @IdCedis and IdPedido = @IdPedido 

	update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) ) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	set @IdRutaEntrega = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'V', StatusDesc = 'Ventas' where IdCedis = @IdCedis and Fecha = @FechaEntrega and IdRuta = @IdRutaEntrega

end

GO

/****** Object:  StoredProcedure [dbo].[up_PedidosDetalle]    Script Date: 09/20/2010 10:30:37 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_PedidosDetalle]
@IdCedis as bigint,
@IdPedido as bigint,
@IdTipoVenta as int,
@IdProducto as bigint,
@Cantidad as float,
@Precio as money,
@Iva as float,
@DctoPorc as money,
@DctoImp as money,
@Entregado as float,
@Opc as int

AS

if @Opc = 1 -- Actualiza Partida de Factura
begin

--	if @Cantidad = 0 and @CantidadAnterior <> 0
	delete from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido and IdProducto = @IdProducto
--	else
	if @Cantidad <> 0 
--			update PedidosDetalle set Cantidad = @Cantidad, Precio = @Precio, Iva = @Iva where IdCedis = @IdCedis and IdSurtido = @IdPedido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto
--		else
		insert into PedidosDetalle values (@IdCedis, @IdPedido, @IdTipoVenta, @IdProducto, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc, @Entregado)

	update Pedidos set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta ), 0),
	Pedidos.DctoImp = isnull( (select sum(PedidosDetalle.DctoImp) from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta ), 0)
	where IdCedis = @IdCedis and IdPedido = @IdPedido and IdTipoVenta = @IdTipoVenta 

end
GO

