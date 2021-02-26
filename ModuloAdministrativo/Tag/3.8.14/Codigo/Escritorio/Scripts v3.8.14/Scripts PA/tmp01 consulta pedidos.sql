
	exec( 'SELECT left(v.RutClave, len(v.RutClave)-4) as IdCedis, ''3'' as TipoVenta, left(t.Folio,3) as ''Serie'', right(t.Folio,5) as ''Folio'', D.FechaCaptura as ''Fecha'',
	Clientes.IdCliente, Clientes.RazonSocial as ''Razon Social'',  
 	t.ClienteClave as ''IdSucursal'', NombreSucursal as ''Sucursal'', sum(td.total) as ''Total'', t.transprodid
	FROM Route.dbo.TransProd T
	INNER JOIN Route.dbo.Dia D ON D.DiaClave = T.DiaClave
	INNER JOIN Route.dbo.Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
	INNER JOIN Route.dbo.TransProdDetalle TD ON T.TransProdId = TD.TransProdId
	inner join Route.dbo.Producto PRO on PRO.ProductoClave = TD.ProductoClave 
	inner join Route.dbo.ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
 	inner join ClienteSucursal on ClienteSucursal.IdSucursal = t.ClienteClave
	inner join Clientes on Clientes.IdCliente = ClienteSucursal.IdCliente and Clientes.IdCedis = ClienteSucursal.IdCedis
	WHERE D.FechaCaptura BETWEEN ''20100327'' AND ''20100329'' 
	-- AND V.RUTClave in (''10099'', ''10110'') 
	-- AND cast(right(t.folio,5) as bigint) = ''256''
	-- AND t.ClienteClave in (''011060141'')
	AND T.Tipo = 1 AND T.TipoFase <> 0 AND T.TipoFase = 1
	GROUP BY t.folio, D.FechaCaptura, Clientes.IdCliente, Clientes.RazonSocial, t.ClienteClave, NombreSucursal, V.RutClave, t.transprodid
	ORDER BY D.FechaCaptura, t.folio, t.ClienteClave')

/*
	SELECT '1' as IdCedis, '3' as TipoVenta, left(t.Folio,3) as 'Serie', right(t.Folio,5) as 'Folio', D.FechaCaptura as 'Fecha',
	Clientes.IdCliente, Clientes.RazonSocial as 'Razon Social',  
 	t.ClienteClave as 'IdSucursal', NombreSucursal as 'Sucursal', sum(td.total) as 'Total'
--	TD.ProductoClave, TD.SubTotal,TD.TipoUnidad,TD.Cantidad,
--	(PRD.Factor * TD.Cantidad) as Piezas, 
--	T.DescVendPor, TD.Impuesto,
--	(select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from Route.dbo.TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescuentoCliente, 
--	(select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from Route.dbo.TpdDes as TDD where TDD.TransProdId=TD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) as DescClienteImpuesto
	FROM Route.dbo.TransProd T
	INNER JOIN Route.dbo.Dia D ON D.DiaClave = T.DiaClave
	INNER JOIN Route.dbo.Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
	INNER JOIN Route.dbo.TransProdDetalle TD ON T.TransProdId = TD.TransProdId
	inner join Route.dbo.Producto PRO on PRO.ProductoClave = TD.ProductoClave 
	inner join Route.dbo.ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
 	inner join ClienteSucursal on ClienteSucursal.IdSucursal = t.ClienteClave
	inner join Clientes on Clientes.IdCliente = ClienteSucursal.IdCliente and Clientes.IdCedis = ClienteSucursal.IdCedis
	WHERE D.FechaCaptura BETWEEN '20100327' AND '20100329' 
	-- AND V.RUTClave in ('10099', '10110') 
	AND T.Tipo = 1 AND T.TipoFase <> 0 AND T.TipoFase = 1
GROUP BY t.folio, D.FechaCaptura, Clientes.IdCliente, Clientes.RazonSocial, t.ClienteClave, NombreSucursal, V.RutClave
ORDER BY D.FechaCaptura, t.folio, t.ClienteClave
*/