USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas]    Script Date: 09/24/2010 15:51:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Ventas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Ventas]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalle]    Script Date: 09/24/2010 15:51:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasDetalle]
GO

/****** Object:  StoredProcedure [dbo].[up_Consignas]    Script Date: 09/24/2010 15:51:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Consignas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Consignas]
GO

/****** Object:  StoredProcedure [dbo].[up_Ventas]    Script Date: 09/24/2010 15:51:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Ventas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Ventas]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 09/24/2010 15:51:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas]    Script Date: 09/24/2010 15:51:55 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_Ventas] 
@IdCedis as bigint,
@IdSurtido as bigint,
@Opc as int

AS

if @Opc = 1
	select Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, 
	isnull(VentasTipo.TipoVenta, 'Tipo de Venta no Definido') as 'Tipo de Venta', Ventas.IdCliente as 'No. Cliente', isnull(Clientes.RazonSocial, 'Cliente no encontrado')  as 'Cliente', 
	Ventas.Subtotal as 'Subtotal', Ventas.Iva as 'Iva', Ventas.Total as 'Total', isnull( ClienteSucursal.CodigoBarras, ' - ') as 'Código de Barras', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
	Ventas.Fecha, isnull(ClienteSucursal.RFC, '-') as RFC, Clientes.Domicilio, Clientes.Telefono, isnull(PreciosLista.IdLista,0), isnull(PreciosLista.Descripcion, 'El Cliente no tiene Lista de Precios asignada')
	from Ventas
	left outer join VentasTipo on Ventas.IdTipoVenta = VentasTipo.IdTipoVenta
	left outer join Clientes on Ventas.IdCliente = Clientes.IdCliente and Clientes.IdCedis = Ventas.IdCedis
	left outer join ClienteSucursal on Ventas.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal
	left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
	left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido

if @Opc = 2
	select isnull( sum(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito) , 0)
	from SurtidosDetalle 
	where SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido

if @Opc = 3
	select Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, 
	isnull(VentasTipo.TipoVenta, 'Tipo de Venta no Definido') as 'Tipo de Venta', Ventas.IdCliente as 'No. Cliente', isnull(Clientes.RazonSocial, 'Cliente no encontrado')  as 'Cliente', Ventas.DctoImp as 'Descuento',
	Ventas.Subtotal as 'Subtotal', Ventas.Iva as 'Iva', Ventas.Total as 'Total', isnull( ClienteSucursal.CodigoBarras, ' - ') as 'Código de Barras', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
	Ventas.Fecha, isnull(ClienteSucursal.RFC, '-') as RFC, Clientes.Domicilio, Clientes.Telefono, isnull(PreciosLista.IdLista,0), isnull(PreciosLista.Descripcion, 'El Cliente no tiene Lista de Precios asignada')
	from Ventas
	left outer join VentasTipo on Ventas.IdTipoVenta = VentasTipo.IdTipoVenta
	left outer join Clientes on Ventas.IdCliente = Clientes.IdCliente and Clientes.IdCedis = Ventas.IdCedis
	left outer join ClienteSucursal on Ventas.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal
	left outer join PreciosListaCliente on PreciosListaCliente.IdCliente = Clientes.IdCliente and Clientes.IdCedis = PreciosListaCliente.IdCedis
	left outer join PreciosLista on PreciosLista.IdLista = PreciosListaCliente.IdLista
	where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido

GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDetalle]    Script Date: 09/24/2010 15:51:57 ******/
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
	VentasDetalle.Cantidad as 'Cantidad', VentasDetalle.Precio as 'Precio', VentasDetalle.Subtotal as 'Subtotal', 
	VentasDetalle.Cantidad * VentasDetalle.Precio * VentasDetalle.Iva as 'Iva', VentasDetalle.Total as 'Total'
	from VentasDetalle
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio 
	order by VentasDetalle.IdProducto

if @Opc = 2
	select isnull(sum(subtotal),0), isnull(Sum(cantidad * precio * iva),0), isnull(sum(total),0), ISNULL(SUM(DctoImp),0) from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio

if @Opc = 3
	select VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Folio, 
	VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	VentasDetalle.Cantidad as 'Cantidad', VentasDetalle.Precio as 'Precio', 
	VentasDetalle.DctoPorc as 'DctoPorc', VentasDetalle.DctoImp as 'DctoImp', 
	VentasDetalle.Subtotal as 'Subtotal', 
	((VentasDetalle.Cantidad * VentasDetalle.Precio) - VentasDetalle.DctoImp) * VentasDetalle.Iva as 'Iva', VentasDetalle.Total as 'Total'
	from VentasDetalle
	inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio 
	order by VentasDetalle.IdProducto


GO

/****** Object:  StoredProcedure [dbo].[up_Ventas]    Script Date: 09/24/2010 15:51:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_Ventas] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@Fecha as datetime,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@Opc as int

AS

declare 
@TVenta as bigint,
@IdRuta as bigint,
@DiasCredito as int,
@IdLista as bigint

if @Opc = 1 -- Inserta Factura Nueva
begin
	
	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2
	
	select @Folio = isnull(MAX(Folio) + 1, 1)  
	from Ventas 
	where Serie = @Serie 

	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, @IdSucursal, 0, @DiasCredito)	

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'V', StatusDesc = 'Ventas' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta
end

if @Opc = 3 -- Elimina Factura
begin

	set @TVenta = (select Tipo from VentasTipo where IdTipoVenta = @IdTipoVenta)
	
	if @TVenta = 2 
	begin
		update SurtidosDetalle set VentaContado = VentaContado -
		( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = SurtidosDetalle.IdProducto)  
		from SurtidosDetalle where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
		and SurtidosDetalle.IdProducto in 
		(select VentasDetalle.IdProducto from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

		update InventarioKardex set VentaContado = VentaContado - 
		( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = InventarioKardex.IdProducto)  
		from InventarioKardex where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis
		and InventarioKardex.IdProducto in 
		(select VentasDetalle.IdProducto from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)
	end
	else
	begin
		update SurtidosDetalle set VentaCredito = VentaCredito -
		( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = SurtidosDetalle.IdProducto)  
		from SurtidosDetalle where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
		and SurtidosDetalle.IdProducto in 
		(select VentasDetalle.IdProducto from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

		update InventarioKardex set VentaCredito = VentaCredito - 
		( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = InventarioKardex.IdProducto) 
		from InventarioKardex where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis
		and InventarioKardex.IdProducto in 
		(select VentasDetalle.IdProducto from VentasDetalle 
		where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)
	end

	insert into VentasCanceladas 
	select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, Subtotal, Iva, IdSucursal, DiasCredito from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	delete from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	exec up_SurtidosCargas @IdCedis, @IdSurtido, 99, 0, '19000101', 0, 3
	
	update Pedidos set IdSurtido = 0, Serie = '', Folio = 0
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Serie = @Serie and Folio = @Folio 
end

if @Opc = 4
begin
	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2

	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, @IdSucursal, 0, @DiasCredito)	

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'V', StatusDesc = 'Ventas' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta

	insert into VentasDetalle
	select @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, IdProducto, @Serie, isnull( sum(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito) , 0),  0, 
	isnull( (select Iva from Productos where Productos.IdProducto = SurtidosDetalle.IdProducto), 0), 0, 0--, isnull( sum(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito) , 0)
	from SurtidosDetalle 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 
	group by IdProducto

	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Cantidad = 0

	-- ACTUALIZA PRECIOS DE RUTA ESPECIAL
	set @IdLista = isnull((select PreciosListaRuta.IdLista from PreciosListaRuta 
			inner join PreciosLista on PreciosListaRuta.IdLista = PreciosLista.IdLista and TipoLista = 'RU'
			where PreciosListaRuta.IdCedis = @IdCedis and PreciosListaRuta.IdRuta = @IdRuta),0)

	if @IdLista <> 0  
		update VentasDetalle set Precio = isnull( ( select PreciosDetalle.Precio from PreciosDetalle where PreciosDetalle.IdLista = @IdLista and VentasDetalle.IdProducto = PreciosDetalle.IdProducto ), 0) 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio

	--  INSERTA VENTA DE CONTADO CON PRECIO DE DETALLE
	set @IdLista = isnull((select PreciosListaCedis.IdLista from PreciosListaCedis 
			inner join PreciosLista on PreciosListaCedis.IdLista = PreciosLista.IdLista and TipoLista = 'BA'
			where PreciosListaCedis.idcedis = @IdCedis),0)

	if @IdLista <> 0  
		update VentasDetalle set Precio = isnull( ( select PreciosDetalle.Precio from PreciosDetalle where PreciosDetalle.IdLista = @IdLista and VentasDetalle.IdProducto = PreciosDetalle.IdProducto ), 0) 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and VentasDetalle.Precio = 0

	-- delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and ( Cantidad = 0 or Precio = 0)

	update SurtidosDetalle set VentaContado = VentaContado +
	( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = SurtidosDetalle.IdProducto)  
	from SurtidosDetalle where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
	and SurtidosDetalle.IdProducto in 
	(select VentasDetalle.IdProducto from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

	update InventarioKardex set VentaContado = VentaContado +
	( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = InventarioKardex.IdProducto)  
	from InventarioKardex where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis
	and InventarioKardex.IdProducto in 
	(select VentasDetalle.IdProducto from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

	update Ventas set DctoImp = isnull((select sum(DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	Subtotal = isnull((select sum((Cantidad * Precio)-DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio)-DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

end

if @Opc = 5
begin
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and ( Cantidad = 0 or Precio = 0)

	update SurtidosDetalle set VentaContado = VentaContado +
	( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = SurtidosDetalle.IdProducto)  
	from SurtidosDetalle where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido
	and SurtidosDetalle.IdProducto in 
	(select VentasDetalle.IdProducto from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

	update InventarioKardex set VentaContado = VentaContado +
	( select isnull(sum(Cantidad),0) from VentasDetalle where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio and VentasDetalle.IdProducto = InventarioKardex.IdProducto)  
	from InventarioKardex where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis
	and InventarioKardex.IdProducto in 
	(select VentasDetalle.IdProducto from VentasDetalle 
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio)

	update Ventas set DctoImp = isnull((select sum(DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	Subtotal = isnull((select sum((Cantidad * Precio)-DctoImp)  from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio)-DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
end




GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 09/24/2010 15:51:57 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_VentasDetalle]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@Fecha as datetime,
@IdProducto as bigint,
@Cantidad as float,
@Precio as money,
@Iva as float,
@TVenta as int,
@DctoPorc as money,
@DctoImp as money,
@Opc as int

AS

declare @CantidadAnterior as float, @IdRuta as bigint
if @Opc = 1 -- Actualiza Partida de Factura
begin
	set @CantidadAnterior = isnull( (select Cantidad from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto), 0)
	set @TVenta = (select Tipo from VentasTipo where IdTipoVenta = @IdTipoVenta )

--	if @Cantidad = 0 and @CantidadAnterior <> 0
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto
--	else
	if @Cantidad <> 0 
--			update VentasDetalle set Cantidad = @Cantidad, Precio = @Precio, Iva = @Iva where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto
--		else
		insert into VentasDetalle values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc )


	if @TVenta = 2 
	begin
		update SurtidosDetalle set VentaContado = VentaContado + @Cantidad - @CantidadAnterior 
		where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
		update InventarioKardex set VentaContado = VentaContado + @Cantidad - @CantidadAnterior 
		where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
	end
	else
	begin
		update SurtidosDetalle set VentaCredito = VentaCredito + @Cantidad - @CantidadAnterior 
		where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
		update InventarioKardex set VentaCredito = VentaCredito + @Cantidad - @CantidadAnterior 
		where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
	end

/*	update SurtidosDetalle set Surtido = Surtido - @Cantidad - @CantidadAnterior 
	where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdProducto = @IdProducto and SurtidosDetalle.IdSurtido = @IdSurtido
	update InventarioKardex set Surtido = Surtido - @Cantidad - @CantidadAnterior 
	where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
*/

	update Ventas set DctoImp = isnull((select sum(DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio)- DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	-- select SubTotal, Iva, Total from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 	

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)

	if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'HH' )
	begin
		delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'VEN'
		insert into StatusLiquidacion values ( @IdCedis, @IdSurtido, @IdRuta, @Fecha, 'VEN', 'Actualización de Ventas', getdate() )
	end

end
GO



/****** Object:  StoredProcedure [dbo].[up_Consignas]    Script Date: 09/24/2010 15:51:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[up_Consignas]
@IdCedis as bigint,
@IdConsigna as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@IdRutaEntrega as bigint,
@IdSurtidoEntrega as bigint,
@FechaEntrega as datetime,
@IdMovimientoEntrega as bigint,
@IdRutaDevolucion as bigint,
@IdSurtidoDevolucion as bigint,
@FechaDevolucion as datetime,
@IdMovimientoDevolucion as bigint,
@Folio as bigint,
@Serie as varchar(5),
@Observaciones as varchar(5000),
@Status as char(1),
@Opc as int

AS

declare @IdProducto as bigint,
@Surtido as float,
@Devolucion as float,
@Venta as float,
@Precio as money,
@Iva as money,
@SurtidoExiste as float,
@FolioInicial as bigint,
@IdTipoVenta as int,
@TVenta as int,
@IdMovimiento as bigint,
@IdCarga as bigint

if @Opc = 1
begin

	--declare @FilaInsertada table (IdCedis bigint, IdConsigna bigint);

	-- Generar el registro de la consigna
	--set @IdConsigna = isnull((Select max(IdConsigna) from Consignas where  IdCedis = @IdCedis) + 1, 1)	
	
	insert into Consignas (IdCedis, IdConsigna, IdCliente, IdSucursal, IdRutaEntrega, IdSurtidoEntrega, 
				FechaEntrega, FechaDevolucion, Observaciones, Status)
	--Output INSERTED.IdCedis, INSERTED.IdConsigna into @FilaInsertada
	values (@IdCedis, @IdConsigna, @IdCliente, @IdSucursal, @IdRutaEntrega, @IdSurtidoEntrega, 
			@FechaEntrega, @FechaDevolucion ,@Observaciones, @Status)

	--select IdCedis, IdConsigna from @FilaInsertada

end

if @Opc = 2		--cambios en la asignacion del cliente para la consigna
Begin

	update Consignas set IdCliente = @IdCliente, IdSucursal = @IdSucursal, 
						FechaDevolucion = @FechaDevolucion, Observaciones = @Observaciones
	where IdCedis = @IdCedis and IdConsigna = @IdConsigna

	--actualizar los nuevos precios de la consigna al cambio de cliente
	DECLARE Consignas_Cursor CURSOR FOR
	select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

	OPEN Consignas_Cursor;

	FETCH NEXT FROM Consignas_Cursor
	into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Actualizacion de precio
		execute up_ConsignasDetalle @IdCedis,@IdCliente,@IdRutaEntrega,@IdSurtidoEntrega,@IdConsigna,@IdProducto,0,0,3

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
	END

	CLOSE Consignas_Cursor
	DEALLOCATE Consignas_Cursor

End

if @Opc = 3		-- Cambia el Status de la consigna
begin
	-- 'P' a 'R' una vez que se guarda una consigna, para generar los movimientos de surtidos, kardex y almacen
	-- 'R' a 'E' una vez que se cierra la ruta
	-- 'E' a 'D' una vez que se comienza a registrar la devolución de la consinga
	-- 'D' a 'V' una vez que se aplica la liquidacion de un surtido donde se devolvio la consigna
	-- 'P','R' a 'C' al cancelar un registro de Consigna
	-- 'D' a 'S' al cancelar una devolucion de Consigna

	If @Status = 'R'
	Begin
		-- Generar registro de movimientos en surtidos, kardex y almacen
        -- incrementar la devolucion buena del producto en la ruta que liquida la consigna
        -- incrementar la columna de devolucion buena del producto en el kardex de inventario
		DECLARE Consignas_Cursor CURSOR FOR
		select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

		OPEN Consignas_Cursor;

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		WHILE @@FETCH_STATUS = 0
		BEGIN
			-- incrementar la devolucion buena del producto en la ruta que liquida la consigna
			set @SurtidoExiste = isnull((select Surtido from SurtidosDetalle 
								where IdCedis = @IdCedis and IdSurtido = @IdSurtidoEntrega and IdProducto = @IdProducto ),0)
			if @SurtidoExiste = 0
				Begin
					delete from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoEntrega and IdProducto = @IdProducto 
					insert into SurtidosDetalle values (@IdCedis, @IdSurtidoEntrega, @IdProducto, @FechaEntrega, @Surtido, 0, 0, 0, 0, 0, @Precio, @Iva)
				End
			Else
				Begin
					update surtidosdetalle set DevBuena = DevBuena + @Surtido
					where IdCedis = @IdCedis and IdSurtido = @IdSurtidoEntrega and IdProducto = @IdProducto
				End

			FETCH NEXT FROM Consignas_Cursor
			into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		END

		CLOSE Consignas_Cursor
		DEALLOCATE Consignas_Cursor

		-- incrementar la columna de devolucion buena del producto en el kardex de inventario
		exec up_ActualizaKardex @IdCedis , @FechaDevolucion, @IdSurtidoEntrega, 4
		
		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End
	
	If @Status = 'E'
	Begin
		-- Generar registro del movimiento de Salida de productos del Almacen
        -- generar el movimiento de salida en el Inventario
		set @IdMovimiento = isnull((Select max(IdMovimiento) from Movimientos where  IdCedis = @IdCedis)+1,1)	
		-- insert into Movimientos values (
		select @IdCedis, @IdMovimiento, @FechaEntrega, 12, 'Salida de Producto por Entrega de Consigna', 'RUTA R' + CAST(@IdRutaEntrega AS varchar(10)), 'A'-- )

		update Consignas set IdMovimientoEntrega = @IdMovimiento
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

        -- registrar los detalles del movimiento de salida generado
		insert into MovimientosDetalle (IdCedis, IdMovimiento, IdProducto, Cantidad, Observaciones) 
		Select @IdCedis, @IdMovimiento, IdProducto, Surtido, '' from ConsignasDetalle where IdCedis = @IdCedis and IdConsigna = @IdConsigna

		exec up_ActualizaKardex @IdCedis , @FechaEntrega, 0, 3

		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End

	If @Status = 'D'
	Begin
		-- Guarda los datos de Fecha, ruta y Surtido para comenzar el registro de las devoluciones
		update Consignas set IdRutaDevolucion = @IdRutaDevolucion, 
							IdSurtidoDevolucion = @IdSurtidoDevolucion,
							FechaDevolucion = @FechaDevolucion
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	
        
		-- Genera la factura de contado de cliente (IdTipoVenta 3)
		set @IdTipoVenta = 1
		set @FolioInicial = isnull((select FolioInicialContadoRutas from Configuracion where IdCedis = @IdCedis ), 0)
		set @Serie = isnull((select SerieFacturasCredito from Configuracion where IdCedis = @IdCedis ), '')
		set @Folio = (	select isnull( max(Ventas.Folio)+1, 1) 
						from	Ventas 
						where	Ventas.IdCedis = @IdCedis and Ventas.Serie = @Serie )
		if @Folio < @FolioInicial
		Begin
			set @Folio = @FolioInicial
		End
		
		--guarda la factura de contado de cliente
		execute up_Ventas @IdCedis, @IdSurtidoDevolucion, @IdTipoVenta, @Folio, @Serie, @FechaDevolucion, @IdCliente, @IdSucursal, 1

		--Guarda la relacion de la factura de contado con la consigna
		update Consignas set Folio = @Folio, Serie = @Serie
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna
		
		-- Genera Recarga para Venta
		set @IdCarga = isnull( (select max( IdCarga ) from Cargas where IdCedis = @IdCedis and Fecha = @FechaDevolucion and IdRuta = @IdRutaDevolucion) + 1 , 1)	
		insert into Cargas values (@IdCedis, @IdSurtidoDevolucion, @IdCarga, @IdRutaDevolucion, @FechaDevolucion, 'A')
		
		DECLARE Consignas_Cursor CURSOR FOR
		select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

		OPEN Consignas_Cursor;

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		WHILE @@FETCH_STATUS = 0
		BEGIN

			-- guardar el detalle de la venta de contado del producto en la ruta que liquida la consigna
			delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto	
			If @Venta <> 0
			Begin
				insert into VentasDetalle values (@IdCedis, @IdSurtidoDevolucion, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Venta, @Precio, @Iva, 0, 0)
			End
			
			-- incrementar el surtido del producto y venta de contado en la ruta que liquida la consigna
			set @SurtidoExiste = isnull((select Surtido from SurtidosDetalle 
								where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdProducto = @IdProducto ),0)
			if @SurtidoExiste = 0
				Begin
					delete from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdProducto = @IdProducto 
					insert into SurtidosDetalle values (@IdCedis, @IdSurtidoDevolucion, @IdProducto, @FechaDevolucion, @Surtido, 0, 0, 0, @Venta, 0, @Precio, @Iva)
				End
			Else
				Begin
					insert into SurtidosCargas 
					select IdCedis, @IdSurtidoDevolucion, @IdCarga, IdProducto, Venta 
					from ConsignasDetalle 
					where IdCedis = @IdCedis and IdConsigna = @IdConsigna and Venta > 0
				End

			FETCH NEXT FROM Consignas_Cursor
			into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		END

		CLOSE Consignas_Cursor
		DEALLOCATE Consignas_Cursor

		-- incrementar la columna de surtido y VentasContado del producto en el kardex de inventario
		exec up_ActualizaKardex @IdCedis , @FechaDevolucion, @IdSurtidoDevolucion, 4

		--Actualiza la informacion de Ventas
		update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
		Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

		--Estatus de la ruta
		if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdRuta = @IdRutaDevolucion and Fecha = @FechaDevolucion and Status = 'HH' )
		begin
			delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdRuta = @IdRutaDevolucion and Fecha = @FechaDevolucion and Status = 'VEN'
			insert into StatusLiquidacion values ( @IdCedis, @IdSurtidoDevolucion, @IdRutaDevolucion, @FechaDevolucion, 'VEN', 'Actualización de Ventas', getdate() )
		end

		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End

	If @Status = 'V'
	Begin
		-- generar el movimiento de entrada en el Inventario
		-- registrar los detalles del movimiento de entrada generado

		set @IdMovimiento = isnull((Select max(IdMovimiento) from Movimientos where  IdCedis = @IdCedis)+1,1)	
		insert into Movimientos values (@IdCedis, @IdMovimiento, @FechaDevolucion, 18, 'Entrada de Producto por Devolución de Consigna', 'RUTA R' + CAST(@IdRutaDevolucion AS varchar(10)), 'A')

		update Consignas set IdMovimientoDevolucion = @IdMovimiento
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

        -- registrar los detalles del movimiento de salida generado
		insert into MovimientosDetalle (IdCedis, IdMovimiento, IdProducto, Cantidad, Observaciones) 
		Select @IdCedis, @IdMovimiento, IdProducto, Venta, '' from ConsignasDetalle where IdCedis = @IdCedis and IdConsigna = @IdConsigna

		exec up_ActualizaKardex @IdCedis , @FechaDevolucion, 0, 3

		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End

	If @Status = 'C'	-- cuando se cancele una consigna que se esta registrando como entrega
	Begin
        -- decrementar la devolucion buena del producto en la ruta que liquida la consigna
        -- decrementar la columna de devolucion buena del producto en el kardex de inventario
		DECLARE Consignas_Cursor CURSOR FOR
		select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

		OPEN Consignas_Cursor;

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		WHILE @@FETCH_STATUS = 0
		BEGIN
			-- decrementar la devolucion buena del producto en la ruta que liquida la consigna

			update surtidosdetalle set DevBuena = DevBuena - @Surtido
			where IdCedis = @IdCedis and IdSurtido = @IdSurtidoEntrega and IdProducto = @IdProducto

			-- decrementar la columna de devolucion buena del producto en el kardex de inventario
			update InventarioKardex set DevBuena = DevBuena - @Surtido
			where IdCedis = @IdCedis and Fecha = @FechaEntrega and IdProducto = @IdProducto	

			FETCH NEXT FROM Consignas_Cursor
			into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		END

		CLOSE Consignas_Cursor
		DEALLOCATE Consignas_Cursor

		update Consignas set Status = @Status
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	

	End

	If @Status = 'S'	-- cuando se cancele la devolucion de una consigna
	Begin
		-- Elimina la factura de contado de cliente (IdTipoVenta 3)
		set @IdTipoVenta = 3

		-- Elimina los detalles de la factura
		delete 
		from	VentasDetalle 
		where	IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta 
				and Folio = @Folio and Serie = @Serie

		-- Elimina la factura
		delete 
		from	Ventas 
		where	IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta 
				and Folio = @Folio and Serie = @Serie

		-- Decrementa los movimientos del producto marcado como vendido
		DECLARE Consignas_Cursor CURSOR FOR
		select IdProducto, surtido, Devolucion, Venta, Precio, Iva from ConsignasDetalle where idCedis = @IdCedis and Idconsigna = @IdConsigna

		OPEN Consignas_Cursor;

		FETCH NEXT FROM Consignas_Cursor
		into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		WHILE @@FETCH_STATUS = 0
		BEGIN
			-- decrementar el surtido del producto y venta de contado en la ruta que liquida la consigna
			update surtidosdetalle set Surtido = Surtido - @Surtido, VentaContado = VentaContado - @Venta
			where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdProducto = @IdProducto

			-- decrementar la columna de surtido y VentasContado del producto en el kardex de inventario
			update InventarioKardex set Surtido = Surtido - @Surtido, VentaContado = VentaContado - @Venta
			where IdCedis = @IdCedis and Fecha = @FechaDevolucion and IdProducto = @IdProducto	

			FETCH NEXT FROM Consignas_Cursor
			into @IdProducto, @Surtido, @Devolucion, @Venta, @Precio, @Iva
		END

		CLOSE Consignas_Cursor
		DEALLOCATE Consignas_Cursor

		--Actualiza la informacion de Ventas
		update Ventas set DctoImp = isnull((select sum(DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
		Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
		Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

		--Estatus de la ruta
		if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdRuta = @IdRutaDevolucion and Fecha = @FechaDevolucion and Status = 'HH' )
		begin
			delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtidoDevolucion and IdRuta = @IdRutaDevolucion and Fecha = @FechaDevolucion and Status = 'VEN'
			insert into StatusLiquidacion values ( @IdCedis, @IdSurtidoDevolucion, @IdRutaDevolucion, @FechaDevolucion, 'VEN', 'Actualización de Ventas', getdate() )
		end

		-- Actualiza los valores de Venta y Devoluciones de los detalles de la consigna
		update ConsignasDetalle set Devolucion = 0, 
							Venta = 0
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	  

		-- Elimina los datos de Fecha, ruta y Surtido para comenzar el registro de las devoluciones y Actualiza el estatus de la consigna a "E Pendiente por Devolver"
		update Consignas set IdRutaDevolucion = null, 
							IdSurtidoDevolucion = null,
							Folio = null,
							serie = null,
							Status = 'E'
		where IdCedis = @IdCedis and IdConsigna = @IdConsigna	        
	End

end

GO