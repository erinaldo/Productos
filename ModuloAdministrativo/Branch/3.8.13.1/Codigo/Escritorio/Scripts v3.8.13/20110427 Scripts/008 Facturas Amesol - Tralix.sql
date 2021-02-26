
-- Se agregó el campo FechaEdicion y Login en la tabla Ventas donde se especifica la fecha de creación de una venta y el usuario que la creó
-- Se agregó el campo FechaEdicion y Login en la tabla VentasCanceladas donde se especifica la fecha de cancelación de una venta y el usuario que la cancelación
-- Se agregó el campo Login en la tabla VentasFacturadas donde se especifica el usuario que creaó la una venta
-- Se agregó el campo Login en la tabla PedidosFacturados donde se especifica el usuario que creaó la una venta

/*pedidos*/

select  '01|'+ 
		case when Vtas.IDCEDIS='1' then 'AC' when Vtas.IDCEDIS='2' then 'SJ' when Vtas.IDCEDIS='3' then 'PL' end 
	 +'1'+'|'+
		case when Vtas.IDCEDIS='1' then 'AC' when Vtas.IDCEDIS='2' then 'SJ' when Vtas.IDCEDIS='3' then 'PL' end 
	+'|1|'
		+CONVERT(VARCHAR,DATEPART(YYYY,FECHAPEDIDO))+'/'+right('0'+convert(varchar,datepart (month,FECHAPEDIDO)),2)+'/'+right('0'+convert(varchar,datepart (day,FECHAPEDIDO)),2)+'T'+'23:00:00'+'|'
		+CONVERT(VARCHAR,Vtas.Subtotal)+'|'+ CONVERT(VARCHAR,Vtas.Total)+'|'+case when Vtas.Iva<>0 then  convert(varchar,Vtas.Iva)+'|' else '|' end+'|||'+
	(RouteADM.dbo.fn_NumeroLetra(Vtas.Total) )+'|MXN'+'|'+'|||||',null
from pedidos Vtas
	inner join Configuracion Con on Con.IdCedis = Vtas.IdCedis --and Vtas.Serie = Con.SerieFacturasCredito 
	inner join ClienteSucursal CteSuc on CteSuc.IdCedis = Vtas.IdCedis and CteSuc.IdSucursal = Vtas.IdSucursal and Vtas.IdCliente = CteSuc.IdCliente  
	where vtas.idpedido = 950 and Vtas.IdCedis= 1
	order by Vtas.Serie, Vtas.Folio 


/*ventas */
select  '01|'+ 
		case when Clientes.IdCedis='1' then 'AC' when Clientes.IdCedis='2' then 'SJ' when Clientes.IdCedis='3' then 'PL' end 
	 +'1'+'|'+
		case when Clientes.IdCedis='1' then 'AC' when Clientes.IdCedis='2' then 'SJ' when Clientes.IdCedis='3' then 'PL' end 
	+'|1|'
		+CONVERT(VARCHAR,DATEPART(YYYY,FECHA))+'/'+right('0'+convert(varchar,datepart (month,FECHA)),2)+'/'+right('0'+convert(varchar,datepart (DAY,FECHA)),2)+'T'+'23:00:00'+'|'
		+CONVERT(VARCHAR,sum(td.subtotal))+'|'+ CONVERT(VARCHAR,sum(td.Total))+'|'+'||||'+
	upper(REPLACE( REPLACE( REPLACE( REPLACE( REPLACE( REPLACE ( (RouteADM.dbo.fn_NumeroLetra(sum(td.Total)) ),'á','a'), 'é','e'),'í','i'),'ó','o'),'ú','u'),'ñ','n') )
	+'|MXN'+'|'+'|||||',null
	FROM Route.dbo.TransProd T
	INNER JOIN Route.dbo.Dia D ON D.DiaClave = T.DiaClave
	INNER JOIN Route.dbo.Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
	INNER JOIN Route.dbo.TransProdDetalle TD ON T.TransProdId = TD.TransProdId
	inner join Route.dbo.Producto PRO on PRO.ProductoClave = TD.ProductoClave 
	inner join Route.dbo.ProductoDetalle PRD on TD.ProductoClave = PRD.ProductoClave and TD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
	inner join ClienteSucursal on ClienteSucursal.IdSucursal = t.ClienteClave
	inner join Clientes on Clientes.IdCliente = ClienteSucursal.IdCliente and Clientes.IdCedis = ClienteSucursal.IdCedis
	inner join PedidosFacturados on T.TransProdId = PedidosFacturados.TransProdId 
	WHERE T.Tipo = 1 AND T.TipoFase <> 0 AND T.TipoFase = 1
	AND  FolioImpresion = 2058 and Clientes.IdCedis= 1
	group by RUTClave, fecha,FolioImpresion,Clientes.IdCedis
	order by FolioImpresion	



/*Ventas Normales*/	


select  '01|'+ 
		case when Vtas.IDCEDIS='1' then 'AC' when Vtas.IDCEDIS='2' then 'SJ' when Vtas.IDCEDIS='3' then 'PL' end 
	 +'1'+'|'+
		case when Vtas.IDCEDIS='1' then 'AC' when Vtas.IDCEDIS='2' then 'SJ' when Vtas.IDCEDIS='3' then 'PL' end 
	+'|1|'
		+CONVERT(VARCHAR,DATEPART(YYYY,VtasFact.FECHA))+'/'+right('0'+convert(varchar,datepart (month,VtasFact.FECHA)),2)+'/'+right('0'+convert(varchar,datepart (DAY,VtasFact.FECHA)),2)+'T'+'23:00:00'+'|'
		+CONVERT(VARCHAR,sum(Vtas.Subtotal))+'|'+ CONVERT(VARCHAR,sum(Vtas.Total))+'|'+case when Vtas.Iva<>0 then  convert(varchar,Vtas.Iva)+'|' else '|' end+'|||'+
	upper(REPLACE( REPLACE( REPLACE( REPLACE( REPLACE( REPLACE ( (RouteADM.dbo.fn_NumeroLetra(sum(Vtas.Total)) ),'á','a'), 'é','e'),'í','i'),'ó','o'),'ú','u'),'ñ','n') )
	+'|MXN'+'|'+'|||||',null
		from Ventas Vtas 	
		inner join VentasFacturadas VtasFact on Vtas.IdCedis = VtasFact.IdCedis and Vtas.IdSurtido = VtasFact.IdSurtido 
			and Vtas.IdTipoVenta = VtasFact.IdTipoVenta and Vtas.Folio = VtasFact.Folio 
		inner join ClienteSucursal CteSuc on CteSuc.IdCedis = Vtas.IdCedis and CteSuc.IdSucursal = Vtas.IdSucursal and Vtas.IdCliente = CteSuc.IdCliente  
		where Vtas.Serie not in (select SerieFacturasCredito from Configuracion where IdCedis = Vtas.IdCedis) 
		and Vtas.IdCedis= 1 and VtasFact.FOLIOIMPRESION= 2061
		group by Vtas.IdCedis,VtasFact.Fecha,Vtas.Iva

/*Factura DEL DIA*/

select  '01|'+ 
		case when Ventas.IdCedis='1' then 'AC' when Ventas.IdCedis='2' then 'SJ' when Ventas.IdCedis='3' then 'PL' end 
	 +'1'+'|'+
		case when Ventas.IdCedis='1' then 'AC' when Ventas.IdCedis='2' then 'SJ' when Ventas.IdCedis='3' then 'PL' end 
	+'|1|'
		+CONVERT(VARCHAR,DATEPART(YYYY,Ventas.Fecha))+'/'+right('0'+convert(varchar,datepart (month,Ventas.Fecha)),2)+'/'+right('0'+convert(varchar,datepart (DAY,Ventas.Fecha)),2)+'T'+'23:00:00'+'|'
		+CONVERT(VARCHAR,convert(numeric(15,2),sum(VentasDetalle.Subtotal)))+'|'+ CONVERT(VARCHAR,convert(numeric(15,2),sum(VentasDetalle.Total)))+'|'+'||||'+
	upper(REPLACE( REPLACE( REPLACE( REPLACE( REPLACE( REPLACE ( (RouteADM.dbo.fn_NumeroLetra(convert(numeric(15,2),sum(VentasDetalle.Total))) ),'á','a'), 'é','e'),'í','i'),'ó','o'),'ú','u'),'ñ','n') )
	+'|MXN'+'|'+'|||||',null
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
		and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio  
		and VentasDetalle.IdTipoVenta in ( select IdTipoVenta from VentasTipo where Tipo = 2 )
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
	left outer join FN_VentasContadoFacturadas(1, 40657.7, 40657.7) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
		and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
	left outer join FN_VentasContadoPOSTFactura(1, 40657.7, 40657.7) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
		and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
	where Ventas.IdCedis = 1 and Ventas.Fecha = 40657.7 and Ventas.IdTipoVenta = 1
		and FNFact.Folio is null and FNPostFact.Folio is null
		group by  Ventas.IdCedis,Ventas.Fecha
