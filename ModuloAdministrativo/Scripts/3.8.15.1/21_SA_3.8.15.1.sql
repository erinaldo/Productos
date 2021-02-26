USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasBusqueda]    Script Date: 07/15/2011 12:32:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_FacturasBusqueda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_FacturasBusqueda]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasBusqueda]    Script Date: 07/15/2011 12:32:05 ******/
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
@Opc as int

AS

--set @IdCedis = 0
--set @IdCliente = '''2000'''
--set @IdRuta = ''
--set @Folio = ''
--set @FechaInicial = '07/15/2011'
--set @FechaFinal = '07/15/2011'
--set @Opc = 2

if @Opc = 1 
begin
	--if @IdRuta <> '' set @IdRuta = ' inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido and Surtidos.IdRuta in (' + @IdRuta + ') ' 
	--if @Folio <> '' set @Folio = ' and Folio = ' + @Folio
	if @IdCliente <> '' set @IdCliente = ' and ( Ventas.IdCliente in ( ' + @IdCliente + ' ) or Ventas.IdSucursal in ( ' + @IdCliente + ' ) )'
-- select @IdRuta, @Folio, @IdCliente

	exec ('select Ventas.IdCedis, Ventas.IdTipoVenta, 
	case Ventas.Serie
		when (select top 1 SerieFacturasCredito from Configuracion where IdCedis = ' + @IdCedis + ') then ''S ('' + cast(Ventas.Folio as varchar(5)) + '')''
		else isnull(Facturada + '' ('' + FolioImpresion + '')'', ''N'') end 
	as Facturada, isnull(VentasFacturadas.Fecha, '''') as ''F. Impresión'', 
	case Ventas.IdTipoVenta 
		when 1 then ''Contado''
		when 2 then ''Crédito''
	end as ''Forma Venta'',
	Ventas.Serie, Ventas.Folio, Ventas.Fecha, VentasAcredita.FechaAcredita, VentasAcredita.FechaEntrega, 
		VentasAcredita.FolioEntrega, VentasAcredita.FolioCliente,VentasAcredita.Remision, VentasAcredita.Factura,
	Ventas.IdCliente, Clientes.RazonSocial, Ventas.IdSucursal, NombreSucursal as ''Sucursal'', Ventas.SubTotal, Ventas.Iva, Ventas.Total
	from Ventas 
	left outer join VentasAcredita on Ventas.IdCedis = VentasAcredita.IdCedis and  Ventas.IdTipoVenta = VentasAcredita.IdTipoVenta and 
		Ventas.Serie = VentasAcredita.Serie and Ventas.Folio = VentasAcredita.Folio 
	inner join Clientes on Ventas.IdCedis = Clientes.IdCedis and Ventas.IdCliente = Clientes.IdCliente 
	inner join ClienteSucursal on ClienteSucursal.IdCedis = Clientes.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal
 	left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido and 
 		Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
 	' + @IdRuta + ' 
	where Ventas.Fecha between  ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' ' + @Folio + ' ' + @IdCliente + '  
		and Ventas.Serie not like ''DEV%''
	order by Ventas.Fecha, Ventas.Serie, Ventas.Folio, Ventas.IdSucursal')
	--Ventas.IdCedis = ' + @IdCedis + ' and 
end

if @Opc = 2
begin
	if @IdRuta <> '' set @IdRuta = ' AND V.RUTClave in ( ' + @IdRuta + ') ' 
	if @Folio <> '' set @Folio = ' AND cast(right(t.folio,5) as bigint) =  ' + @Folio
	if @IdCliente <> '' set @IdCliente = ' AND t.ClienteClave in ( ' + @IdCliente + ' )'
-- select @IdRuta, @Folio, @IdCliente

	exec( 'SELECT left(v.RutClave, len(v.RutClave)-4) as IdCedis, ''3'' as TipoVenta, 
	isnull(Facturada + '' ('' + T.Folio + '')'', ''N'') as Facturada, isnull(PedidosFacturados.Fecha, '''') as ''F. Impresión'', 
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
	AND T.Tipo = 1 AND T.TipoFase = 1
	GROUP BY t.folio, D.FechaCaptura, Clientes.IdCliente, Clientes.RazonSocial, t.ClienteClave, NombreSucursal, V.RutClave, 
	t.transprodid, Facturada, PedidosFacturados.Fecha, T.CFVTipo
	ORDER BY D.FechaCaptura, t.folio, t.ClienteClave')

end



GO


