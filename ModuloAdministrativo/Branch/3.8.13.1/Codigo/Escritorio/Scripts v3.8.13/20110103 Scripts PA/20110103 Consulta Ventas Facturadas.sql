
declare @FechaInicial as datetime, @FechaFinal as datetime

set @FechaInicial = '20110110'
set @FechaFinal = '20110110'

SELECT 'Ventas Facturas' as Origen, Vtas.IdCedis, Vtas.IdSurtido, Vtas.IdTipoVenta, Vtas.Folio as Folio, Vtas.Serie collate SQL_Latin1_General_CP1_CI_AS as Serie, Subtotal, Iva, Total, Vtas.IdCliente, Vtas.IdSucursal  	
from Ventas Vtas 	
inner join Configuracion Con on Con.IdCedis = Vtas.IdCedis and Vtas.Serie = Con.SerieFacturasCredito 
inner join ClienteSucursal CteSuc on CteSuc.IdCedis = Vtas.IdCedis and CteSuc.IdSucursal = Vtas.IdSucursal and Vtas.IdCliente = CteSuc.IdCliente  
where Vtas.Fecha between @FechaInicial and @FechaFinal 

union 

SELECT 'Ventas POST-Factura' as Origen, Vtas.IdCedis, Vtas.IdSurtido, Vtas.IdTipoVenta, VtasFact.FolioImpresion as Folio, VtasFact.Serie collate SQL_Latin1_General_CP1_CI_AS as Serie, Subtotal, Iva, Total, Vtas.IdCliente, Vtas.IdSucursal  		
from Ventas Vtas 	
inner join VentasFacturadas VtasFact on Vtas.IdCedis = VtasFact.IdCedis and Vtas.IdSurtido = VtasFact.IdSurtido 
	and Vtas.IdTipoVenta = VtasFact.IdTipoVenta and Vtas.Folio = VtasFact.Folio 
inner join ClienteSucursal CteSuc on CteSuc.IdCedis = Vtas.IdCedis and CteSuc.IdSucursal = Vtas.IdSucursal and Vtas.IdCliente = CteSuc.IdCliente  
where Vtas.Fecha between @FechaInicial and @FechaFinal and Vtas.Serie not in (select SerieFacturasCredito from Configuracion where IdCedis = Vtas.IdCedis) 

union 

SELECT 'Pedidos Facturados NO Registrados' as Origen, left(v.RutClave, len(v.RutClave)-4) as IdCedis, 0 as IdSurtido, T.CFVTipo as IdTipoVenta, FolioImpresion as Folio, left(t.Folio,3) collate SQL_Latin1_General_CP1_CI_AS as 'Serie', 
td.subtotal as 'SubTotal', td.impuesto as 'Iva', td.total as 'Total', Clientes.IdCliente, t.ClienteClave as IdSucursal
FROM Route.dbo.TransProd T
INNER JOIN Route.dbo.Dia D ON D.DiaClave = T.DiaClave
INNER JOIN Route.dbo.Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
INNER JOIN Route.dbo.TransProdDetalle TD ON T.TransProdId = TD.TransProdId
inner join Route.dbo.Producto PRO on PRO.ProductoClave = TD.ProductoClave 
inner join Route.dbo.ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
inner join ClienteSucursal on ClienteSucursal.IdSucursal = t.ClienteClave
inner join Clientes on Clientes.IdCliente = ClienteSucursal.IdCliente and Clientes.IdCedis = ClienteSucursal.IdCedis
inner join PedidosFacturados on T.TransProdId = PedidosFacturados.TransProdId 
WHERE D.FechaCaptura BETWEEN @FechaInicial and @FechaFinal and PedidosFacturados.FolioImpresion not in (select Folio from Ventas where IdCedis = left(v.RutClave, len(v.RutClave)-4) 
	and Ventas.Fecha between @FechaInicial and @FechaFinal 
	and Serie in (select SerieFacturasCredito from Configuracion where IdCedis = Ventas.IdCedis))
AND T.Tipo = 1 AND T.TipoFase <> 0 AND T.TipoFase = 1

order by Folio 

