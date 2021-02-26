USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasBusqueda]    Script Date: 04/28/2011 18:15:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_FacturasBusqueda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_FacturasBusqueda]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasBusqueda]    Script Date: 04/28/2011 18:15:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[sel_FacturasBusqueda] 
@IdCedis as bigint,
@IdCliente as varchar(8000),
@IdRuta as varchar(8000),
@Folio as varchar(8000),
@FechaInicial as datetime,
@FechaFinal as datetime,
@Orden as varchar(5000),
@Opc as int
AS

declare @Serie as varchar(6)

if @Opc = 1 
begin
	if @IdRuta <> '' set @IdRuta = ' inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido and Surtidos.IdRuta in (' + @IdRuta + ') ' 
	if @Folio <> '' set @Folio = ' and Ventas.Folio = ' + @Folio
	if @IdCliente <> '' set @IdCliente = ' and Ventas.IdSucursal in ( ' + @IdCliente + ' )'
	
	select @Orden = case @Orden 
		when '1' then ' order by Clientes.RazonSocial, ClienteSucursal.NombreSucursal '
		when '2' then ' order by Clientes.RazonSocial, Ventas.IdSucursal '
		when '3' then ' order by ClienteSucursal.NombreSucursal '

		when '4' then ' order by Clientes.RazonSocial desc, ClienteSucursal.NombreSucursal '
		when '5' then ' order by Clientes.RazonSocial, Ventas.IdSucursal desc '
		when '6' then ' order by ClienteSucursal.NombreSucursal desc'
	end 
-- select @IdRuta, @Folio, @IdCliente

	select @Serie = ISNULL(SerieFacturasCredito, '') 
	from Configuracion  
	where IdCedis = @IdCedis
	
	exec ('
	select Ventas.IdCedis, Ventas.IdTipoVenta, 
	case Ventas.Serie  
		when (select top 1 SerieFacturasCredito from Configuracion where IdCedis = 1) then ''S ('' + cast(Ventas.Folio as varchar(10)) + '')''
		else isnull(Facturada + '' ('' + FolioImpresion + '')'', ''N'') end 
	as Facturada, 
	case Ventas.Serie  
		when (select top 1 SerieFacturasCredito from Configuracion where IdCedis = 1) then Ventas.Login  
		else isnull(VentasFacturadas.Login,'''')  end as Login, 		
	isnull(VentasFacturadas.Fecha, '''') as ''F. Impresión'', 
	case Ventas.IdTipoVenta 
		when 1 then ''Contado''
		when 2 then ''Crédito''
	end as ''Forma Venta'',
	Ventas.Serie, Ventas.Folio, Ventas.Fecha, 
	Ventas.IdCliente, Clientes.RazonSocial, Ventas.IdSucursal, NombreSucursal as ''Sucursal'', Ventas.SubTotal, Ventas.Iva, Ventas.Total, Ventas.IdSurtido
	from Ventas 
	inner join Clientes on Ventas.IdCedis = Clientes.IdCedis and Ventas.IdCliente = Clientes.IdCliente 
	inner join ClienteSucursal on ClienteSucursal.IdCedis = Clientes.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal
 	left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido and 
 		Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio
 	' + @IdRuta + ' 
	where Ventas.IdCedis = ' + @IdCedis + ' and Ventas.IdTipoVenta = 2 and Ventas.Fecha between  ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' ' + @Folio + ' ' + @IdCliente + '  

union

	select Ventas.IdCedis, Ventas.IdTipoVenta, 
	case isnull(VentasFacturadas.Serie, '''')
		when '''' then 
			case ISNULL(VentasContado.Serie,'''')
			when '''' then ''N''
			else  ''S ('' + cast(isnull(VentasContado.Folio,'''') as varchar(10)) + '')'' end 
		else isnull(Facturada + '' ('' + FolioImpresion + '')'', ''N'') end 
	as Facturada, 
	case isnull(VentasFacturadas.Serie, '''')
		when '''' then 
			case ISNULL(VentasContado.Serie,'''')
			when '''' then ''''
			else  ''SUPER'' end 
		else isnull(VentasFacturadas.Login, '''') end 
	as Login, 
	isnull(VentasFacturadas.Fecha, '''') as ''F. Impresión'', 
	case Ventas.IdTipoVenta 
		when 1 then ''Contado''
		when 2 then ''Crédito''
	end as ''Forma Venta'',
	Ventas.Serie, Ventas.Folio, Ventas.Fecha, 
	Ventas.IdCliente, Clientes.RazonSocial, Ventas.IdSucursal, NombreSucursal as ''Sucursal'', Ventas.SubTotal, Ventas.Iva, Ventas.Total, Ventas.IdSurtido
	from Ventas 
	inner join Clientes on Ventas.IdCedis = Clientes.IdCedis and Ventas.IdCliente = Clientes.IdCliente 
	inner join ClienteSucursal on ClienteSucursal.IdCedis = Clientes.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal
 	left outer join VentasContado on Ventas.IdCedis = VentasContado.IdCedis and Ventas.Fecha = VentasContado.Fecha and VentasContado.Serie = ''' + @Serie + ''' 
 	left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido and 
 		Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
 	' + @IdRuta + '  	
	where Ventas.IdCedis = ' + @IdCedis + ' and Ventas.IdTipoVenta = 1 and Ventas.Fecha between  ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' ' + @Folio + ' ' + @IdCliente + '  

	' + @Orden + ' ' )
end

if @Opc = 2
begin
	if @IdRuta <> '' set @IdRuta = ' AND V.RUTClave in ( ' + @IdRuta + ') ' 
	if @Folio <> '' set @Folio = ' AND cast(right(t.folio,5) as bigint) =  ' + @Folio
	if @IdCliente <> '' set @IdCliente = ' AND t.ClienteClave in ( ' + @IdCliente + ' )'

	select @Orden = case @Orden 
		when '1' then ' order by Clientes.RazonSocial, ClienteSucursal.NombreSucursal '
		when '2' then ' order by Clientes.RazonSocial, t.ClienteClave '
		when '3' then ' order by ClienteSucursal.NombreSucursal '

		when '4' then ' order by Clientes.RazonSocial desc, ClienteSucursal.NombreSucursal '
		when '5' then ' order by Clientes.RazonSocial, t.ClienteClave desc '
		when '6' then ' order by ClienteSucursal.NombreSucursal desc'
	end 
-- select @IdRuta, @Folio, @IdCliente

	exec( 'SELECT left(v.RutClave, len(v.RutClave)-4) as IdCedis, ''3'' as TipoVenta, isnull(Facturada + '' ('' + FolioImpresion + '')'', ''N'') as Facturada, isnull(PedidosFacturados.Login, '''') as Login, isnull(PedidosFacturados.Fecha, '''') as ''F. Impresión'', 
	case T.CFVTipo 
		when 1 then ''Contado''
		when 2 then ''Crédito''
	end as ''Forma Venta'',
	left(t.Folio,3) as ''Serie'', right(t.Folio,5) as ''Folio'', D.FechaCaptura as ''Fecha'',
	Clientes.IdCliente, Clientes.RazonSocial as ''Razon Social'',  
 	t.ClienteClave as ''IdSucursal'', NombreSucursal as ''Sucursal'', sum(td.subtotal) as ''SubTotal'', sum(td.impuesto) as ''Iva'', sum(td.total) as ''Total'', t.transprodid
	FROM Route.dbo.TransProd T
	INNER JOIN Route.dbo.Dia D ON D.DiaClave = T.DiaClave
	INNER JOIN Route.dbo.Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
	INNER JOIN Route.dbo.TransProdDetalle TD ON T.TransProdId = TD.TransProdId
	inner join Route.dbo.Producto PRO on PRO.ProductoClave = TD.ProductoClave 
	inner join Route.dbo.ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
 	inner join ClienteSucursal on ClienteSucursal.IdSucursal = t.ClienteClave
	inner join Clientes on Clientes.IdCliente = ClienteSucursal.IdCliente and Clientes.IdCedis = ClienteSucursal.IdCedis
	left outer join PedidosFacturados on T.TransProdId = PedidosFacturados.TransProdId 
	WHERE D.FechaCaptura BETWEEN ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' ' + @Folio + ' ' + @IdCliente + ' ' + @IdRuta + '  
	AND T.Tipo = 1 AND T.TipoFase <> 0 AND T.TipoFase = 1
	GROUP BY t.folio, D.FechaCaptura, Clientes.IdCliente, Clientes.RazonSocial, t.ClienteClave, NombreSucursal, V.RutClave, t.transprodid, Facturada, FolioImpresion, PedidosFacturados.Fecha, T.CFVTipo, PedidosFacturados.Login 
	' + @Orden + ' ')

end





GO


