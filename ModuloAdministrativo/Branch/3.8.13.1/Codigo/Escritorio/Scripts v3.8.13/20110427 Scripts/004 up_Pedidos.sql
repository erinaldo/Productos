USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Pedidos]    Script Date: 04/28/2011 18:12:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Pedidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Pedidos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Pedidos]    Script Date: 04/28/2011 18:12:40 ******/
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
@Login as varchar(20),
@Opc as int

AS

declare @DiasCredito as bigint
declare @IdPedidoF as varchar(20), @FolioF as bigint

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

	set @IdPedidoF = 'C' + replicate('0', 2 - len(@IdCedis)) + cast(@IdCedis as varchar(2)) + 'Ped' + replicate('0', 9 - len(@IdPedido)) + cast(@IdPedido as varchar(10))
	delete from PedidosFacturados where TransProdId = @IdPedidoF 
end

if @Opc = 3
begin

	select @DiasCredito = ISNULL(DiasCredito,0) 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and @IdTipoVenta = 2

	select @IdRutaEntrega = IdRuta, @FechaEntrega = Fecha 
	from Surtidos
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido 

	set @IdPedidoF = 'C' + replicate('0', 2 - len(@IdCedis)) + cast(@IdCedis as varchar(2)) + 'Ped' + replicate('0', 9 - len(@IdPedido)) + cast(@IdPedido as varchar(10))
	set @FolioF = ''

	if exists(select TransProdId from PedidosFacturados where TransProdId = @IdPedidoF )
		select @FolioF = FolioImpresion from PedidosFacturados where TransProdId = @IdPedidoF and isnumeric(FolioImpresion) = 1

	if @FolioF = ''
	begin 
		select @Serie = SerieRemisiones 
		from Configuracion 
		where IdCedis = @IdCedis 
		
		set @Folio = (select isnull(MAX(Folio) + 1, 1) from Ventas where IdCedis = @IdCedis and Serie = @Serie)
	end
	else
	begin
		select @Serie = SerieFacturasCredito  
		from Configuracion 
		where IdCedis = @IdCedis 
		
		select @Folio = @FolioF 
	end
	
	insert into Ventas values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @FechaEntrega, @IdCliente, 0, 0, @IdSucursal, @DiasCredito, GETDATE(), @Login)	

	update Pedidos set IdRutaEntrega = @IdRutaEntrega, FechaEntrega = @FechaEntrega, Serie = @Serie, Folio = @Folio, IdSurtido = @IdSurtido  
	where IdCedis = @IdCedis and IdPedido = @IdPedido 

	insert into VentasDetalle -- values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc, @Entregado)
	select IdCedis, @IdSurtido, IdTipoVenta, @Folio, IdProducto, @Serie, Cantidad, Precio, Iva
	from PedidosDetalle 
	where IdCedis = @IdCedis and IdPedido = @IdPedido 

	update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) ) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	set @IdRutaEntrega = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	update StatusRutas set Status = 'V', StatusDesc = 'Ventas' where IdCedis = @IdCedis and Fecha = @FechaEntrega and IdRuta = @IdRutaEntrega

end



GO


