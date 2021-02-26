
declare @IdCedis as bigint, @Fecha as datetime, @IdProducto as bigint, @IdRuta as bigint, @Valor as money

set @IdCedis = 3
set @Fecha = '20101111'
set @IdProducto = 30
set @IdRuta = 3

--select *
--from Movimientos where IdCedis = @IdCedis and IdTipoMovimiento = 12 and Fecha = @Fecha 

	set @Valor = ISNULL((
	select  sum(TD.Cantidad *PD.Factor) 
		 FROM Route.dbo.TransProd TP
		 INNER JOIN Route.dbo.Dia D ON D.DiaClave = TP.DiaClave 
		 INNER JOIN Route.dbo.Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
		 INNER JOIN Route.dbo.Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
		 INNER JOIN Route.dbo.Usuario U ON U.USUId = VEN.USUId 
		 INNER JOIN Route.dbo.TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
		 INNER JOIN Route.dbo.ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave <> TD.ProductoClave 
		 WHERE TP.Tipo = 24 AND TP.TipoFase <> 0 and TP.FechaCaptura = @Fecha 
		 and U.Clave = 'USER' + REPLICATE ('0', 2-len(CAST(@IdRuta as varchar(10))))  + CAST(@IdRuta as varchar(10))
		 and Route.dbo.FNObtenerSoloNumeros(PD.ProductoDetClave) = cast(@IdProducto as int)), 0)

select 'Consignas', @Valor 

	set @Valor = ISNULL((
	select SUM(Cantidad * PD.Factor)
		 FROM Surtidos  
		 INNER JOIN VentasDetalle ON Surtidos.IdCedis = VentasDetalle.IdCedis and Surtidos.IdSurtido = VentasDetalle.IdSurtido 
		 INNER JOIN Route.dbo.ProductoDetalle PD ON cast(PD.ProductoClave as bigint) = VentasDetalle.IdProducto AND cast(PD.ProductoDetClave as bigint) <> VentasDetalle.IdProducto 
		 and Route.dbo.FNObtenerSoloNumeros(PD.ProductoDetClave) = cast(@IdProducto as int)
		 WHERE Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha and Surtidos.IdRuta = @IdRuta), 0)

select 'Ventas', @Valor 

	set @Valor = ISNULL((
		select SUM(TPD.Cantidad * PD.Factor )
		from Route.dbo.TransProd TRPC
		inner join Route.dbo.TrpTpd TPD on TPD.TransProdID1 = TRPC.TransProdID 
		inner join Route.dbo.TransProd TRP on TPD.TransProdID = TRP.TransProdID 
		INNER JOIN Route.dbo.TransProdDetalle TD ON TD.TransProdID = TRPC.TransProdID 		
		inner join Route.dbo.Dia Dia on TRP.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave
		INNER JOIN Route.dbo.Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
		INNER JOIN Route.dbo.Usuario U ON U.USUId = VEN.USUId 
		INNER JOIN Route.dbo.ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave <> TD.ProductoClave 
		where TRPC.Tipo = 24 AND TRPC.TipoFase <> 0 and TRPC.FechaCaptura = @Fecha 
		 and U.Clave = 'USER' + REPLICATE ('0', 2-len(CAST(@IdRuta as varchar(10))))  + CAST(@IdRuta as varchar(10))
		 and Route.dbo.FNObtenerSoloNumeros(PD.ProductoDetClave) = cast(@IdProducto as int)), 0)

select 'Consignas Devueltas', @Valor 

	set @Valor = ISNULL((
	select  sum(TD.Cantidad ) 
		 FROM Route.dbo.TransProd TP
		 INNER JOIN Route.dbo.Dia D ON D.DiaClave = TP.DiaClave 
		 INNER JOIN Route.dbo.Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
		 INNER JOIN Route.dbo.Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
		 INNER JOIN Route.dbo.Usuario U ON U.USUId = VEN.USUId 
		 INNER JOIN Route.dbo.TransProdDetalle TD ON TD.TransProdID = TP.TransProdID and cast(TD.ProductoClave as bigint) = @IdProducto 
		 WHERE TP.Tipo = 3 AND TP.TipoFase <> 0 and TP.FechaCaptura = @Fecha 
		 and U.Clave = 'USER' + REPLICATE ('0', 2-len(CAST(@IdRuta as varchar(10))))  + CAST(@IdRuta as varchar(10)) ), 0)
		 --and Route.dbo.FNObtenerSoloNumeros(TD.ProductoClave) = cast(@IdProducto as int)), 0)

select 'Devoluciones de Envase', @Valor 

	set @Valor = ISNULL((
	select  sum(TD.Cantidad ) 
		 FROM Route.dbo.TransProd TP
		 INNER JOIN Route.dbo.Dia D ON D.DiaClave = TP.DiaClave 
		 INNER JOIN Route.dbo.Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
		 INNER JOIN Route.dbo.Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
		 INNER JOIN Route.dbo.Usuario U ON U.USUId = VEN.USUId 
		 INNER JOIN Route.dbo.TransProdDetalle TD ON TD.TransProdID = TP.TransProdID and cast(TD.ProductoClave as bigint) = @IdProducto 
		 WHERE TP.Tipo = 1 AND TP.TipoFase <> 0 and TP.FechaCaptura = @Fecha
		 and U.Clave = 'USER' + REPLICATE ('0', 2-len(CAST(@IdRuta as varchar(10))))  + CAST(@IdRuta as varchar(10)) ), 0)

select 'Ventas de Envase', @Valor 

--select *
--from TipoMovimiento  

--select IdMovimientoConsignas 
--from Configuracion 

