USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_PedidosDetalle]    Script Date: 11/26/2010 21:06:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_PedidosDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_PedidosDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_PedidosDetalle]    Script Date: 11/26/2010 21:06:19 ******/
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
	PedidosDetalle.Cantidad as 'Cantidad', PedidosDetalle.Entregado as 'Entregado',
	PedidosDetalle.Precio as 'Precio', 
	PedidosDetalle.DctoPorc as 'Dcto.', PedidosDetalle.DctoImp as 'Dcto. Imp.', PedidosDetalle.Subtotal as 'Subtotal', 
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
        where Productos.IdProducto = @IdProducto and Productos.Status = 'A'
end

if @Opc = 3
begin
	select isnull(sum(subtotal),0), isnull(Sum(((cantidad * precio) - DctoImp) * iva),0), isnull(sum(total),0), ISNULL(sum(DctoImp),0)
	from PedidosDetalle 
	where PedidosDetalle.IdCedis = @IdCedis and PedidosDetalle.IdPedido = @IdPedido 
end

if @Opc = 4
begin
	select PedidosDetalle.IdCedis, PedidosDetalle.IdPedido, PedidosDetalle.IdTipoVenta, 
	Pedidos.IdCliente, Pedidos.IdSucursal, Pedidos.FechaPedido, CS.RFC, CS.RazonSocial, 	
	cs.CalleF + ' ' + cs.NumExterior + ' ' + cs.NumInteriorF + ', ' + CS.ColoniaF as Domicilio, 
	cs.PoblacionF + ', ' + cs.EntidadF  as Ciudad, 
	PedidosDetalle.IdProducto as 'Cve. Prod.', Productos.Producto as 'Producto', 
	PedidosDetalle.Cantidad as 'Cantidad', PedidosDetalle.Entregado as 'Entregado', PedidosDetalle.Precio as 'Precio', 
	PedidosDetalle.DctoPorc as 'Dcto.', PedidosDetalle.DctoImp as 'Dcto. Imp.', PedidosDetalle.Subtotal as 'Subtotal', 
	((PedidosDetalle.Cantidad * PedidosDetalle.Precio ) - PedidosDetalle.DctoImp )* PedidosDetalle.Iva as 'Iva', PedidosDetalle.Total as 'Total', 
	Productos.CodBarras as Codigo, Pedidos.FechaEntrega 
	from Pedidos
	inner join ClienteSucursal CS on CS.IdCedis = Pedidos.IdCedis and CS.IdSucursal = Pedidos.IdSucursal  
	inner join PedidosDetalle on Pedidos.IdCedis = PedidosDetalle.IdCedis and Pedidos.IdPedido = PedidosDetalle.IdPedido 
	inner join Productos on PedidosDetalle.IdProducto = Productos.IdProducto
	where Pedidos.IdCedis = @IdCedis and Pedidos.IdPedido = @IdPedido
	order by PedidosDetalle.IdProducto
end


GO


