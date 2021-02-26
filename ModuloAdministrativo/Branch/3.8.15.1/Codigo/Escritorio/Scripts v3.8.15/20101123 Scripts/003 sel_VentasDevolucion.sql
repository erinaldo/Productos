USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDevolucion]    Script Date: 11/23/2010 17:36:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasDevolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasDevolucion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasDevolucion]    Script Date: 11/23/2010 17:36:40 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_VentasDevolucion] 
@IdCedis as bigint,
@FechaIni as datetime, 
@FechaFinal as datetime, 
@IdRuta as bigint,
@IdTipoVenta as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(20),
@Opc as int

AS

declare @Filtro as varchar(8000)

if @Opc = 1
begin
	set @Filtro = ''
	if @IdRuta <> 0 set @Filtro = @Filtro + ' and Surtidos.IdRuta = ' + cast(@IdRuta as varchar(10))
	if @IdTipoVenta <> 0 set @Filtro = @Filtro + ' and Ventas.IdTipoVenta = ' + cast(@IdTipoVenta as varchar(10))
	if @IdCliente <> 0 set @Filtro = @Filtro + ' and Ventas.IdCliente = ' + cast(@IdCliente as varchar(10))
	if @IdSucursal <> '' set @Filtro = @Filtro + ' and Ventas.IdSucursal = ''' + @IdSucursal + ''' '
	
	exec ( 'select Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, 
	isnull(VentasTipo.TipoVenta, ''Tipo de Venta no Definido'') as ''Tipo de Venta'', Ventas.IdCliente as ''No. Cliente'', isnull(Clientes.RazonSocial, ''Cliente no encontrado'')  as ''Cliente'', 
	Ventas.Subtotal as ''Subtotal'', Ventas.DctoImp as ''Dcto.'', Ventas.Iva as ''Iva'', Ventas.Total as ''Total'', isnull( ClienteSucursal.CodigoBarras, '' - '') as ''Código de Barras'', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
	Ventas.Fecha, isnull(ClienteSucursal.RFC, ''-'') as RFC, Clientes.Domicilio, Clientes.Telefono
	from Ventas
	inner join Surtidos on Ventas.IdCedis = Surtidos.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
	inner join VentasTipo on Ventas.IdTipoVenta = VentasTipo.IdTipoVenta
	inner join Clientes on Ventas.IdCliente = Clientes.IdCliente and Clientes.IdCedis = Ventas.IdCedis
	inner join ClienteSucursal on Ventas.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal
	where Ventas.IdCedis = ' + @IdCedis + ' and Ventas.Fecha between ''' + @FechaIni + ''' and ''' + @FechaFinal + ''' ' + @Filtro + ' 
	order by Ventas.Fecha desc, Ventas.Serie, Ventas.Folio' )
end

if @Opc = 2
begin

	declare @IdSurtido as bigint, @Folio as bigint
	set @IdSurtido = @IdRuta 
	set @Folio = @IdCliente 

	select Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, 
	isnull(VentasTipo.TipoVenta, 'Tipo de Venta no Definido') as 'Tipo de Venta', Ventas.IdCliente as 'No. Cliente', isnull(Clientes.RazonSocial, 'Cliente no encontrado')  as 'Cliente', 
	Ventas.Subtotal as 'Subtotal', Ventas.DctoImp as 'Dcto.', Ventas.Iva as 'Iva', Ventas.Total as 'Total', isnull( ClienteSucursal.CodigoBarras, ' - ') as 'Código de Barras', isnull(ClienteSucursal.NombreSucursal, 0) as NombreSucursal, isnull(ClienteSucursal.IdSucursal, 0) as IdSucursal,
	Ventas.Fecha, isnull(ClienteSucursal.RFC, '-') as RFC, Clientes.Domicilio, Clientes.Telefono
	from VentasDevolucion 
	inner join Ventas on Ventas.IdCedis = VentasDevolucion.IdCedisD and Ventas.IdSurtido = VentasDevolucion.IdSurtido 
		and Ventas.IdTipoVenta = VentasDevolucion.IdTipoVenta and Ventas.Folio = VentasDevolucion.Folio 
	inner join VentasTipo on Ventas.IdTipoVenta = VentasTipo.IdTipoVenta
	inner join Clientes on Ventas.IdCliente = Clientes.IdCliente and Clientes.IdCedis = Ventas.IdCedis
	inner join ClienteSucursal on Ventas.IdCliente = ClienteSucursal.IdCliente and ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal
	where VentasDevolucion.IdCedisD = @IdCedis and VentasDevolucion.IdSurtidoD = @IdSurtido 
		and VentasDevolucion.IdTipoVentaD = @IdTipoVenta and VentasDevolucion.FolioD = @Folio  
	order by Ventas.Fecha desc, Ventas.Serie, Ventas.Folio
end
