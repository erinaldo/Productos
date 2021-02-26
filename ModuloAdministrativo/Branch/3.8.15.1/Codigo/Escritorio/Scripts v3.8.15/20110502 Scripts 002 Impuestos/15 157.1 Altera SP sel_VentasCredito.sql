USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasCredito]    Script Date: 05/03/2011 12:44:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasCredito]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasCredito]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasCredito]    Script Date: 05/03/2011 12:44:02 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_VentasCredito] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Opc as int

AS

if @Opc = 1 -- Encabezado

	select Ventas.Fecha, Surtidos.IdRuta, Ventas.Folio, Ventas.IdCliente, RazonSocial as Cliente, Ventas.Subtotal, Ventas.Iva as Impuestos, Ventas.Total, 
	VentasDetalle.IdProducto, Producto, VentasDetalle.Cantidad, VentasDetalle.Precio,
	VentasDetalle.Subtotal as SubtotalD, VentasDetalle.Cantidad*VentasDetalle.Precio*VentasDetalle.Iva as ImpD, VentasDetalle.Total as TotalD
	from Ventas 
	inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido
		and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido
	inner join Clientes on Clientes.IdCedis = Ventas.IdCedis and Ventas.IdCliente = Clientes.IdCliente 
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal
	and Ventas.IdTipoVenta in ( select IdTipoVenta from VentasTipo where Tipo=1)
	order by Ventas.Fecha, Surtidos.IdRuta, Ventas.Folio, Ventas.IdCliente
/*
	select Ventas.Fecha, Surtidos.IdRuta, Ventas.Folio, Ventas.IdCliente, RazonSocial as Cliente, Ventas.Subtotal, Ventas.Iva, Ventas.Total
	from Ventas 
	inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido
	inner join Clientes on Clientes.IdCedis = Ventas.IdCedis and Ventas.IdCliente = Clientes.IdCliente 
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal
	and Ventas.IdTipoVenta in ( select IdTipoVenta from VentasTipo where Tipo=1)
	order by Ventas.Fecha, Surtidos.IdRuta, Ventas.Folio, Ventas.IdCliente
*/

if @Opc = 2 -- Detalle
	select VentasDetalle.IdProducto, Producto, VentasDetalle.Cantidad, VentasDetalle.Precio,
	VentasDetalle.Subtotal, VentasDetalle.Cantidad*VentasDetalle.Precio*VentasDetalle.Iva as Impuestos, VentasDetalle.Total
	from VentasDetalle 
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where VentasDetalle.IdCedis = @IdCedis and VentasDetalle.IdSurtido = @IdSurtido
	and VentasDetalle.IdTipoVenta = @IdTipoVenta and VentasDetalle.Folio = @Folio
	order by VentasDetalle.IdProducto

GO


