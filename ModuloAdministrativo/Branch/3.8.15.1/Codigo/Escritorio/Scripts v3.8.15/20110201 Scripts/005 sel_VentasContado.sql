USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasContado]    Script Date: 01/26/2011 12:16:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasContado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasContado]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasContado]    Script Date: 01/26/2011 12:16:50 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sel_VentasContado] 
@IdCedis as bigint,
@Fecha as datetime,
@IdMarca as bigint,
@Opc as int
AS

if @Opc = 1
begin
	if (select COUNT(SubEmpresaId) from Route.dbo.SubEmpresa )> 1 
		select '' as Serie, 1 as Folio, isnull(sum(VentasDetalle.Subtotal), 0) as Subtotal, 
		isnull(sum(VentasDetalle.subtotal*VentasDetalle.iva), 0) as Iva, isnull(sum(VentasDetalle.total), 0) as Total,
		'Piezas' as Unidad
		from Ventas 
		inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
			and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and IdMarca = @IdMarca 
		left outer join FN_VentasContadoFacturadas(@IdCedis, @Fecha, @Fecha) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
			and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
		left outer join FN_VentasContadoPOSTFactura(@IdCedis, @Fecha, @Fecha) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
			and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
		where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and Ventas.IdTipoVenta = 1
			and FNFact.Folio is null and FNPostFact.Folio is null
	else
		select '' as Serie, 1 as Folio, isnull(sum(VentasDetalle.Subtotal), 0) as Subtotal, 
		isnull(sum(VentasDetalle.subtotal*VentasDetalle.iva), 0) as Iva, isnull(sum(VentasDetalle.total), 0) as Total,
		'Piezas' as Unidad
		from Ventas 
		inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
			and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
		left outer join FN_VentasContadoFacturadas(@IdCedis, @Fecha, @Fecha) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
			and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
		left outer join FN_VentasContadoPOSTFactura(@IdCedis, @Fecha, @Fecha) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
			and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
		where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and Ventas.IdTipoVenta = 1
			and FNFact.Folio is null and FNPostFact.Folio is null
end

if @Opc = 2
begin
	if (select COUNT(SubEmpresaId) from Route.dbo.SubEmpresa )> 1 
		select VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto, isnull(sum(VentasDetalle.Cantidad), 0) as Cantidad, 
		round(VentasDetalle.Precio,3) as Precio, isnull(sum(VentasDetalle.Subtotal), 0) as Subtotal, 
		isnull(sum(VentasDetalle.subtotal*VentasDetalle.iva), 0) as Iva, isnull(sum(VentasDetalle.total), 0) as Total,
		'Piezas' as Unidad
		from Ventas 
		inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
			and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and IdMarca = @IdMarca 
		left outer join FN_VentasContadoFacturadas(@IdCedis, @Fecha, @Fecha) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
			and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
		left outer join FN_VentasContadoPOSTFactura(@IdCedis, @Fecha, @Fecha) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
			and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
		where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and Ventas.IdTipoVenta = 1
			and FNFact.Folio is null and FNPostFact.Folio is null
		group by VentasDetalle.IdProducto, Productos.Producto, Productos.Conversion, round(VentasDetalle.Precio,3)  
		order by VentasDetalle.IdProducto, round(VentasDetalle.Precio,3)
	else
		select VentasDetalle.IdProducto as 'Cve. Prod.', Productos.Producto, isnull(sum(VentasDetalle.Cantidad), 0) as Cantidad, 
		round(VentasDetalle.Precio,3) as Precio, isnull(sum(VentasDetalle.Subtotal), 0) as Subtotal, 
		isnull(sum(VentasDetalle.subtotal*VentasDetalle.iva), 0) as Iva, isnull(sum(VentasDetalle.total), 0) as Total,
		'Piezas' as Unidad
		from Ventas 
		inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
			and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
		left outer join FN_VentasContadoFacturadas(@IdCedis, @Fecha, @Fecha) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
			and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
		left outer join FN_VentasContadoPOSTFactura(@IdCedis, @Fecha, @Fecha) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
			and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
		where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and Ventas.IdTipoVenta = 1
			and FNFact.Folio is null and FNPostFact.Folio is null
		group by VentasDetalle.IdProducto, Productos.Producto, Productos.Conversion, round(VentasDetalle.Precio,3)  
		order by VentasDetalle.IdProducto, round(VentasDetalle.Precio,3)
end

if @Opc = 3
	select IdCedis, IdSurtido
	from Ventas
	where IdCedis = @IdCedis and Fecha = @Fecha and IdTipoVenta in ( Select IdTipoVenta from VentasTipo where Tipo = 2 )




GO


