USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Ventas]    Script Date: 05/31/2011 13:52:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Ventas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Ventas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Ventas]    Script Date: 05/31/2011 13:52:05 ******/
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
@IdMarca as bigint,
@Opc as int

AS

declare 
@TVenta as bigint,
@IdRuta as bigint,
@IdLista as bigint

if @Opc = 1 -- Inserta Factura Nueva
begin
	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, @IdSucursal)
	insert into VentasRoute values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @IdSucursal, null, null)	
	
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
	select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, Subtotal, Iva, IdSucursal from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	delete from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
	
	delete from VentasRoute where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio
end

if @Opc = 4
begin
	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, 0, 0, @IdSucursal)	
	insert into VentasRoute values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @Fecha, @IdCliente, @IdSucursal, null, null)

	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'V', StatusDesc = 'Ventas' where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta

	insert into VentasDetalle
	select @IdCedis, @IdSurtido, @IdTipoVenta, @Folio, SurtidosDetalle.IdProducto, 
	@Serie, isnull( sum(Surtido - DevBuena - DevMala - Obsequios - VentaContado - VentaCredito) , 0),  0, 
	isnull( (select Iva from Productos where Productos.IdProducto = SurtidosDetalle.IdProducto), 0)
	from SurtidosDetalle 
	inner join Productos on SurtidosDetalle.IdProducto = Productos.IdProducto 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdMarca = @IdMarca 
	group by SurtidosDetalle.IdProducto
		
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Cantidad = 0

	-- ACTUALIZA PRECIOS DE CLIENTE
	set @IdLista = isnull((select PreciosListaCliente.IdLista from PreciosListaCliente  
			inner join PreciosLista on PreciosListaCliente.IdLista = PreciosLista.IdLista and TipoLista = 'CL'
			where PreciosListaCliente.IdCedis = @IdCedis and PreciosListaCliente.IdCliente = @IdCliente),0)

	if @IdLista <> 0  
		update VentasDetalle set Precio = isnull( ( select PreciosDetalle.Precio from PreciosDetalle where PreciosDetalle.IdLista = @IdLista and VentasDetalle.IdProducto = PreciosDetalle.IdProducto ), 0) 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio

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

	update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
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

	update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
end




GO


