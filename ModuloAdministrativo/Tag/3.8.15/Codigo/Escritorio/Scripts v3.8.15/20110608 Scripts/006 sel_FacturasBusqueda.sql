USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasBusqueda]    Script Date: 06/15/2011 09:51:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_FacturasBusqueda]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_FacturasBusqueda]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasBusqueda]    Script Date: 06/15/2011 09:51:29 ******/
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


if @Opc = 1 
begin
	if @IdCliente <> '' set @IdCliente = ' and ( Ventas.IdCliente in ( ' + @IdCliente + ' ) or Ventas.IdSucursal in ( ' + @IdCliente + ' ) )'

	declare @FormatoFolio as varchar(16)
	select top 1 @FormatoFolio = fd.Formato 
	from Route.dbo.FolioSolicitado fs
	inner join Route.dbo.Foliodetalle fd on fd.FolioID = fs.FolioID
	where Usados < CantSolicitada --and Serie = @Serie
	order by Usados desc

	exec ('select Ventas.IdCedis, Ventas.IdTipoVenta, 
	isnull(VentasFacturaCFD.SerieFactura + right(''' + @FormatoFolio + ''' + cast(VentasFacturaCFD.FolioFactura as varchar(10)),6) ,''N'') as Facturada, isnull(Trp.FechaFacturacion, '''') as ''F. Impresión'', 
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
	left outer join VentasFacturaCFD on Ventas.IdCedis = VentasFacturaCFD.IdCedis and  Ventas.IdTipoVenta = VentasFacturaCFD.IdTipoVenta and 
		Ventas.Serie = VentasFacturaCFD.Serie and Ventas.Folio = VentasFacturaCFD.Folio 
	left outer join Route.dbo.TransProd Trp on Trp.TransProdId = VentasFacturaCFD.TransProdIdFactura
	left outer join FacturasOxxo FOxxo1 on Ventas.IdCedis = FOxxo1.IdCedis and Ventas.IdTipoVenta = FOxxo1.IdTipoVenta 
		and Ventas.Serie = FOxxo1.Serie and Ventas.Folio = FOxxo1.Folio 
	left outer join FacturasOxxo FOxxo2 on Ventas.IdCedis = FOxxo2.IdCedisOX and Ventas.IdTipoVenta = FOxxo2.IdTipoVentaOX 
		and Ventas.Serie = FOxxo2.SerieOX and Ventas.Folio = FOxxo2.FolioOX 
	inner join Clientes on Ventas.IdCedis = Clientes.IdCedis and Ventas.IdCliente = Clientes.IdCliente 
	inner join ClienteSucursal on ClienteSucursal.IdCedis = Clientes.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal
 	' + @IdRuta + ' 
	where Ventas.Fecha between  ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' ' + @Folio + ' ' + @IdCliente + '  
		and Ventas.Serie not like ''DEV%'' and FOxxo1.FolioOX is null and FOxxo2.FolioOX is null
	order by Ventas.Fecha, Ventas.Serie, Ventas.Folio, Ventas.IdSucursal')
	--Ventas.IdCedis = ' + @IdCedis + ' and 
end

if @Opc = 2
begin
	if @IdRuta <> '' set @IdRuta = ' AND V.RUTClave in ( ' + @IdRuta + ') ' 
	if @Folio <> '' set @Folio = ' AND cast(right(t.folio,5) as bigint) =  ' + @Folio
	if @IdCliente <> '' set @IdCliente = ' AND t.ClienteClave in ( ' + @IdCliente + ' )'

	exec( 'SELECT left(v.RutClave, len(v.RutClave)-4) as IdCedis, ''3'' as TipoVenta, isnull(Facturada + '' ('' + FolioImpresion + '')'', ''N'') as Facturada, isnull(PedidosFacturados.Fecha, '''') as ''F. Impresión'', 
	case T.CFVTipo 
		when 1 then ''Contado''
		when 2 then ''Crédito''
	end as ''Forma Venta''
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
	GROUP BY t.folio, D.FechaCaptura, Clientes.IdCliente, Clientes.RazonSocial, t.ClienteClave, NombreSucursal, V.RutClave, t.transprodid, Facturada
	ORDER BY D.FechaCaptura, t.folio, t.ClienteClave')

end




GO


