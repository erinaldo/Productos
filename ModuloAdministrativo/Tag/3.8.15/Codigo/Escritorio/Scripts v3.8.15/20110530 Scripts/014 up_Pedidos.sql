USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Pedidos]    Script Date: 06/07/2011 10:15:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Pedidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Pedidos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Pedidos]    Script Date: 06/07/2011 10:15:27 ******/
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

declare @DiasCredito as bigint, @SerieDev as varchar(10)

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

	declare @ClaveUsuario varchar(16), @Fecha as datetime, @IdRuta as bigint

	select @Fecha = FechaPedido, @IdRuta = IdRutaPedido, @ClaveUsuario = 'CFDCed' + CAST(IdCedis as varchar(10)), 
		@Serie = Serie, @Folio = Folio 
	from Pedidos 
	where IdCedis = @IdCedis and IdPedido = @IdPedido
	
	exec Route.dbo.SP_CancelarVenta @Folio, @Serie, @Fecha, @ClaveUsuario, @IdRuta

	delete from VentasFacturaCFD where IdCedis = @IdCedis and IdPedido = @IdPedido 
	delete from Pedidos where IdCedis = @IdCedis and IdPedido = @IdPedido 
	delete from PedidosDetalle where IdCedis = @IdCedis and IdPedido = @IdPedido 
	delete from PedidosImpuestos where IdCedis = @IdCedis and IdPedido = @IdPedido 
	delete from PedidosPromociones where IdCedis = @IdCedis and IdPedido = @IdPedido 
end

if @Opc = 3
begin

	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2

	select @IdRutaEntrega = IdRuta, @FechaEntrega = Fecha 
	from Surtidos
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	select @Serie = Serie, @Folio = Folio from Pedidos where IdCedis = @IdCedis and IdPedido = @IdPedido 
	set @SerieDev = isnull( (select SerieDevoluciones from Configuracion where IdCedis = @IdCedis ), '')

	if @Serie is null or @Serie = ''
	begin			
		set @Serie = isnull( (select SerieRemisiones from Configuracion where IdCedis = @IdCedis ), '')
		set @Folio = ( select isnull( max(Ventas.Folio)+1, 1) from Ventas where Ventas.IdCedis = @IdCedis and Serie in (@Serie, @SerieDev) )
	end	
	else
	begin
		update VentasFacturaCFD set IdSurtido = @IdSurtido, IdTipoVenta = @IdTipoVenta, Folio = @Folio 
		where IdCedis = @IdCedis and IdPedido = @IdPedido 
	end
		
	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @FechaEntrega, @IdCliente, 0, 0, @IdSucursal, 0, @DiasCredito)	

	update Pedidos set IdRutaEntrega = @IdRutaEntrega, FechaEntrega = @FechaEntrega, Serie = @Serie, Folio = @Folio, IdSurtido = @IdSurtido  
	where IdCedis = @IdCedis and IdPedido = @IdPedido 
	
	insert into VentasDetalle -- values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc, @Entregado)
	select IdCedis, @IdSurtido, IdTipoVenta, @Folio, IdProducto, @Serie, Cantidad, Precio, Iva, DctoPorc, DctoImp, Entregado 
	from PedidosDetalle 
	where IdCedis = @IdCedis and IdPedido = @IdPedido 
	
	insert into VentasImpuestos 
	select IdCedis, @IdSurtido, IdTipoVenta, @Folio, IdProducto, IdTipoImpuesto, TipoAplicacion, Jerarquia, Tasa 
	from PedidosImpuestos 
	where IdCedis = @IdCedis and IdPedido = @IdPedido 

	insert into VentasPromociones  
	select IdCedis, @IdSurtido, IdTipoVenta, @Folio, IdProducto, IdPromocion, Otras, Cascada, DctoPorc, DctoImp, Resultado 
	from PedidosPromociones 
	where IdCedis = @IdCedis and IdPedido = @IdPedido 
	
	update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	Ventas.DctoImp = isnull( (select sum(VentasDetalle.DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	set @IdRutaEntrega = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'V', StatusDesc = 'Ventas' where IdCedis = @IdCedis and Fecha = @FechaEntrega and IdRuta = @IdRutaEntrega

end





GO


