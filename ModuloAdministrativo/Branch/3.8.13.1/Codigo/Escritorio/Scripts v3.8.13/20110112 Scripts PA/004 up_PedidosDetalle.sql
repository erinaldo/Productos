USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_PedidosDetalle]    Script Date: 01/12/2011 16:04:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PedidosDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PedidosDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_PedidosDetalle]    Script Date: 01/12/2011 16:04:53 ******/
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
@Precio as decimal (19,9),
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


