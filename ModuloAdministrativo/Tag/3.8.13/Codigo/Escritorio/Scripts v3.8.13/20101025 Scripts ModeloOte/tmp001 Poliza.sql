
declare 
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Opc as int

set @IdCedis = 3
set @FechaInicial = '20101026'
set @FechaFinal = '20101026'
set @Opc = 1


--if @Opc = 1
--begin
declare 
@Concepto as varchar(25),
@Fecha as datetime

set @Fecha = @FechaInicial 

	if @IdCedis = 3
		set @Concepto = 'VENTAS HUAMANTLA'
	else
		set @Concepto = 'VENTAS PUEBLA'

	select 1 as Orden, @IdCedis as IdCedis, @Fecha as Fecha, (select Cuenta from RouteCPC.dbo.Cuentas Cuentas where IdCedis = @IdCedis and Concepto = 'BANCO') as Cuenta, 
		'BANCO HSBC CTA. 1544' as Descripcion, @Concepto as Concepto,
		isnull(( select SUM(Ventas.Total )
			from Ventas 
			where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and Ventas.IdTipoVenta = 1), 0 ) 
		+ ISNULL((select distinct sum(ABN.Total)
			from Route.dbo.AbnTrp ABT
			inner join Route.dbo.TransProd TRP on ABT.TransProdID = TRP.TransProdID 
			inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
			inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
			inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
			inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
			inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
			where Dia.FechaCaptura= @Fecha and cast(Route.dbo.FNObtenerSoloNumeros(USU.Clave) as bigint) in ( 
				select IdRuta from Rutas where IdCedis = @IdCedis )
			and TRP.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null)),0) as Cargo, 0 as Abono

	union

	select 2 as Orden, @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'Créditos Ruta ' + CAST(Surtidos.IdRuta as varchar(2)) as Descripcion, @Concepto as Concepto,
		isnull(SUM(VentasDetalle.Total ), 0) as Cargo, 0 as Abono
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
			and VentasDetalle.IdTipoVenta = 2
		left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.IdConcepto = Surtidos.IdRuta and Cuentas.Concepto = 'RUTA'
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha 
		group by Surtidos.IdRuta, Cuentas.Cuenta 

	union

	select 3 as Orden, @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'Cobros Ruta ' + Route.dbo.FNObtenerSoloNumeros(USU.Clave) as Descripcion, @Concepto as Concepto, 0 as Abono, 
		ISNULL(sum(ABN.Total),0) as Abono
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd TRP on ABT.TransProdID = TRP.TransProdID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = @IdCedis and Cuentas.IdConcepto = cast(Route.dbo.FNObtenerSoloNumeros(USU.Clave) as bigint) and Cuentas.Concepto = 'RUTA'
		where Dia.FechaCaptura= @Fecha and cast(Route.dbo.FNObtenerSoloNumeros(USU.Clave) as bigint) in ( 
			select IdRuta from Rutas where IdCedis = @IdCedis )
		and TRP.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null)
		group by Route.dbo.FNObtenerSoloNumeros(USU.Clave), Cuentas.Cuenta 

	union

		select 4 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'VENTA ' + SubFamilia as Descripcion, @Concepto as Concepto, 0 as Cargo, isnull( (SUM(Total + DctoImp)/1.16), 0) as Abono
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and Productos.IdSubFamilia = 1
		inner join SubFamilias on SubFamilias.IdSubFamilia = Productos.IdSubFamilia 
		left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.Concepto = 'VTALIQ'
		where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha  
		group by SubFamilias.IdSubFamilia, SubFamilia, Cuentas.Cuenta 

	union

		select 5 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'VENTA ' + SubFamilia as Descripcion, @Concepto as Concepto, 0 as Cargo, isnull((SUM(Total + DctoImp)),0) as Abono
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and Productos.IdSubFamilia = 2
		inner join SubFamilias on SubFamilias.IdSubFamilia = Productos.IdSubFamilia 
		left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.Concepto = 'VTAAGUA'
		where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha  
		group by SubFamilias.IdSubFamilia, SubFamilia, Cuentas.Cuenta  

	union

		select 6 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'VENTA ' + SubFamilia as Descripcion, @Concepto as Concepto, 0 as Cargo, isnull((SUM(Total + DctoImp)),0) as Abono
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and Productos.IdSubFamilia = 3
		inner join SubFamilias on SubFamilias.IdSubFamilia = Productos.IdSubFamilia 
		left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.Concepto = 'VTAAGUASAB'
		where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha  
		group by SubFamilias.IdSubFamilia, SubFamilia, Cuentas.Cuenta 

	union

		select 7 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'IVA POR PAGAR' as Descripcion, @Concepto as Concepto, 0 as Cargo, isnull( (  (SUM(Total + DctoImp)) - (SUM(Total + DctoImp)/1.16) ),0) as Abono
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and Productos.IdSubFamilia = 1
		left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.Concepto = 'IVA'
		where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha  
		group by Cuentas.Cuenta 
		
	union

		select 8 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'COSTO DE VENTA LIQUIDO' as Descripcion, @Concepto as Concepto, 
		isnull(SUM(Cantidad * PreciosDetalle.Precio ) ,0) as Cargo, 0 as Abono
			from Surtidos  
			inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and Productos.IdSubFamilia = 1
			inner join SubFamilias as SubF on SubF.IdSubFamilia = Productos.IdSubFamilia 
			left outer join PreciosDetalle on PreciosDetalle.IdProducto = Productos.IdProducto and PreciosDetalle.IdLista=5 
			left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.Concepto = 'CVTALIQ'
			where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha
			group by Cuentas.Cuenta

	union

		select 9 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'COSTO DE VENTA AGUA' as Descripcion, @Concepto as Concepto, 
		isnull(SUM(Cantidad * PreciosDetalle.Precio ), 0) as Cargo, 0 as Abono
			from Surtidos  
			inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and Productos.IdSubFamilia in (2, 3)
			inner join SubFamilias as SubF on SubF.IdSubFamilia = Productos.IdSubFamilia 
			left outer join PreciosDetalle on PreciosDetalle.IdProducto = Productos.IdProducto and PreciosDetalle.IdLista = 5 
			left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.Concepto = 'CVTAAGUA'
			where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha 
			group by Cuentas.Cuenta
			
	union

		select 10 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, '' as Cuenta, 'COSTO ' + CAST(VentasDetalle.IdProducto as varchar(10)) + ' - ' + Productos.Producto as Descripcion, @Concepto as Concepto, 
		0 as Cargo, isnull(SUM(Cantidad * PreciosDetalle.Precio ), 0)  as Abono
			from Surtidos  
			inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
			inner join SubFamilias as SubF on SubF.IdSubFamilia = Productos.IdSubFamilia 
			left outer join PreciosDetalle on PreciosDetalle.IdProducto = Productos.IdProducto and PreciosDetalle.IdLista = 5 
			where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha 
			group by VentasDetalle.IdProducto, Productos.Producto 

union

		select 11 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'DESCUENTOS CERVEZA' as Descripcion, @Concepto as Concepto, isnull( SUM(DctoImp), 0) as Cargo, 0 as Abono
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and Productos.IdSubFamilia = 1
		left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.Concepto = 'DCTOS'
		where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha  
		group by Cuentas.Cuenta

union

		select 12 as Orden,  @IdCedis as IdCedis, @Fecha as Fecha, isnull(Cuentas.Cuenta,'') as Cuenta, 'DESCUENTOS AGUA' as Descripcion, @Concepto as Concepto, isnull( SUM(DctoImp), 0) as Cargo, 0 as Abono
		from Surtidos  
		inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and Productos.IdSubFamilia in (2, 3)
		left outer join RouteCPC.dbo.Cuentas Cuentas on Cuentas.IdCedis = Surtidos.IdCedis and Cuentas.Concepto = 'DCTOSA'
		where Surtidos.IdCedis = @IdCedis and Fecha = @Fecha  
		group by Cuentas.Cuenta

--select (select SUM(total)	
--from Ventas 
--where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and IdTipoVenta = 1) ,

--(select SUM(total)	
--from Ventas 
--where Ventas.IdCedis = @IdCedis and Ventas.Fecha = @Fecha and IdTipoVenta = 2) ,

--(select distinct sum(ABN.Total)
--from Route.dbo.AbnTrp ABT
--inner join Route.dbo.TransProd TRP on ABT.TransProdID = TRP.TransProdID 
--inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
--inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
--inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
--inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
--inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
--where Dia.FechaCaptura= @Fecha and cast(Route.dbo.FNObtenerSoloNumeros(USU.Clave) as bigint) in ( 
--	select IdRuta from Rutas where IdCedis = @IdCedis )
--and TRP.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null))
