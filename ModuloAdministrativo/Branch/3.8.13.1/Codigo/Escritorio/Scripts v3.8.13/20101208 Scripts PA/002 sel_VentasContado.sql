USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasContado]    Script Date: 12/09/2010 11:13:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasContado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasContado]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasContado]    Script Date: 12/09/2010 11:13:51 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_VentasContado] 
@IdCedis as bigint,
@Fecha as datetime,
@Opc as int
AS

if @Opc = 1
	select VentasContado.Serie, VentasContado.Folio, isnull(sum(VentasDetalle.Subtotal), 0) as Subtotal, isnull(sum(VentasDetalle.subtotal*VentasDetalle.iva), 0) as Iva, isnull(sum(VentasDetalle.total), 0) as Total
	from VentasContado 
	inner join Surtidos on Surtidos.IdCedis = VentasContado.IdCedis and  VentasContado.Fecha = Surtidos.Fecha
	inner join Ventas on Ventas.IdCedis = Surtidos.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
	left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
		and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
	inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
		and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
	and VentasDetalle.IdSurtido = Surtidos.IdSurtido and VentasDetalle.IdTipoVenta in ( select IdTipoVenta from VentasTipo where Tipo = 2 )
	where VentasContado.IdCedis = @IdCedis and VentasContado.Fecha = @Fecha and VentasFacturadas.Serie is null
	group by VentasContado.Serie, VentasContado.Folio

if @Opc = 2
	select VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto, isnull(sum(Cantidad), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Subtotal)/sum(Cantidad), 0) as Precio, isnull(sum(VentasDetalle.Subtotal), 0) as Subtotal, 
	isnull(sum(VentasDetalle.subtotal*VentasDetalle.iva), 0) as Iva, isnull(sum(VentasDetalle.total), 0) as Total,
	'Piezas' as Unidad
	from Ventas 
	left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
		and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
		and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		and VentasDetalle.IdTipoVenta in ( select IdTipoVenta from VentasTipo where Tipo = 2 )
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and VentasFacturadas.Serie is null
	group by VentasDetalle.IdProducto, Productos.Producto, Productos.Conversion 

if @Opc = 3
	select VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto, isnull(sum(Cantidad * Conversion), 0) as Cantidad, 
	isnull(sum(VentasDetalle.Subtotal)/sum(Cantidad * Conversion), 0) as Precio, isnull(sum(VentasDetalle.Subtotal), 0) as Subtotal, 
	isnull(sum(VentasDetalle.subtotal*VentasDetalle.iva), 0) as Iva, isnull(sum(VentasDetalle.total), 0) as Total,
	case Conversion
		when 1 then 'Piezas'
		else 'Cajas'
	end as Unidad
	from Ventas 
	left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
		and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
		and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		and VentasDetalle.IdTipoVenta in ( select IdTipoVenta from VentasTipo where Tipo = 2 )
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and VentasFacturadas.Serie is null
	group by VentasDetalle.IdProducto, Productos.Producto, Productos.Conversion 


if @Opc = 3
	select IdCedis, IdSurtido
	from Ventas
	where IdCedis = @IdCedis and Fecha = @Fecha and IdTipoVenta in ( Select IdTipoVenta from VentasTipo where Tipo = 2 )


GO


