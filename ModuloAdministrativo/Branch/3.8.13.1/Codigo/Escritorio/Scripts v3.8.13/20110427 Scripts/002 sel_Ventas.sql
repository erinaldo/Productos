USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas]    Script Date: 04/28/2011 18:08:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Ventas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Ventas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Ventas]    Script Date: 04/28/2011 18:08:15 ******/
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
	Ventas.Subtotal as 'Subtotal', Ventas.Iva as 'Iva', Ventas.Total as 'Total', isnull( ClienteSucursal.CodigoBarras, ' - ') as 'Código de Barras', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, 
	Ventas.FechaEdicion, Ventas.Login, 
	isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
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

GO


