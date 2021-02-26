USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_InterfazFacturas]    Script Date: 10/05/2010 16:07:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_InterfazFacturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_InterfazFacturas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_InterfazFacturas]    Script Date: 10/05/2010 16:07:24 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_InterfazFacturas]
@FechaInicial as datetime,
@FechaFinal as datetime,
@Opc as int
AS

if @Opc = 1 -- ENCABEZADOS
	select Vtas.Serie + cast((replicate('0', 10-len(Vtas.Folio)) + cast(Vtas.Folio as varchar(20))) as varchar(30)) as NumeroFactura, 
	Vtas.Folio, Vtas.Serie, Fecha, '23:00:00' as Hora, Vtas.Subtotal, Vtas.Total, Route.dbo.fn_NumeroLetra(Vtas.Total) CantidadLetra,
	CteSuc.RFC, CteSuc.RazonSocial, CteSuc.PaisF, CteSuc.CalleF, CteSuc.NumExteriorF, CteSuc.NumInteriorF, 
	CteSuc.ColoniaF, CteSuc.LocalidadF, CteSuc.PoblacionF as MunicipioF, CteSuc.EntidadF as EstadoF, CteSuc.CPF CodigoPostalF, '' as Comentarios
	from Ventas Vtas 
	inner join Configuracion Con on Con.IdCedis = Vtas.IdCedis and Vtas.Serie = Con.SerieFacturasCredito 
	inner join ClienteSucursal CteSuc on CteSuc.IdCedis = Vtas.IdCedis and CteSuc.IdSucursal = Vtas.IdSucursal and Vtas.IdCliente = CteSuc.IdCliente  
	where Vtas.Fecha between @FechaInicial and @FechaFinal 
	order by Vtas.Serie, Vtas.Folio 

if @Opc = 2 -- DETALLE UNIDADES
	select Vtas.Serie + cast((replicate('0', 10-len(Vtas.Folio)) + cast(Vtas.Folio as varchar(20))) as varchar(30)) as NumeroFactura, 
	VtasDet.IdProducto, VtasDet.Cantidad, Prod.Producto, VtasDet.Precio, 
	VtasDet.Total, Con.Etiqueta01 as Unidad
	from Ventas Vtas 
	inner join Configuracion Con on Con.IdCedis = Vtas.IdCedis and Vtas.Serie = Con.SerieFacturasCredito 
	inner join ClienteSucursal CteSuc on CteSuc.IdCedis = Vtas.IdCedis and CteSuc.IdSucursal = Vtas.IdSucursal and Vtas.IdCliente = CteSuc.IdCliente  
	inner join VentasDetalle VtasDet on Vtas.IdCedis = VtasDet.IdCedis and Vtas.IdSurtido = VtasDet.IdSurtido 
		and Vtas.IdTipoVenta = VtasDet.IdTipoVenta and Vtas.Folio = VtasDet.Folio 
	inner join Productos Prod on Prod.IdProducto = VtasDet.IdProducto 
	where Vtas.Fecha between @FechaInicial and @FechaFinal 
	
if @Opc = 3 -- DETALLE CAJAS
	select Vtas.Serie + cast((replicate('0', 10-len(Vtas.Folio)) + cast(Vtas.Folio as varchar(20))) as varchar(30)) as NumeroFactura, 
	VtasDet.IdProducto, round(VtasDet.Cantidad * Prod.Conversion,2) as Cantidad, Prod.Producto, round((VtasDet.Precio / Prod.Conversion),2) as Precio, 
	VtasDet.Total, Con.Etiqueta02 as Unidad
	from Ventas Vtas 
	inner join Configuracion Con on Con.IdCedis = Vtas.IdCedis and Vtas.Serie = Con.SerieFacturasCredito 
	inner join ClienteSucursal CteSuc on CteSuc.IdCedis = Vtas.IdCedis and CteSuc.IdSucursal = Vtas.IdSucursal and Vtas.IdCliente = CteSuc.IdCliente  
	inner join VentasDetalle VtasDet on Vtas.IdCedis = VtasDet.IdCedis and Vtas.IdSurtido = VtasDet.IdSurtido 
		and Vtas.IdTipoVenta = VtasDet.IdTipoVenta and Vtas.Folio = VtasDet.Folio 
	inner join Productos Prod on Prod.IdProducto = VtasDet.IdProducto 
	where Vtas.Fecha between @FechaInicial and @FechaFinal 