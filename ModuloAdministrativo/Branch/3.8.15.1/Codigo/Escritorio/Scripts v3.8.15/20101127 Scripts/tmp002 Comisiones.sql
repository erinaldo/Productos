
USE [RouteADM]

declare 

@ReporteOrigen as int,
@Tipo as int,
@IdCedis as varchar(3),
@FechaInicial as datetime,
@FechaFinal as datetime,
@Filtro as varchar(4000),
@Ordenamiento as varchar(200)

set @IdCedis = 2
set @FechaInicial = '20101114'
set @FechaFinal = '20101128'
set @Filtro = ''

	select IdVendedor, Nomina, Vendedor, SUM(Pago) as Comision, SUM(AbonoMerma) as AbonoMerma, SUM(AbonoVolumen) as AbonoVolumen, SUM(CargoMerma) as CargoMerma,
	ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = @IdCedis and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between @FechaInicial and @FechaFinal 		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
		having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
		order by VS.Fecha desc),0) as SaldoVendedor,
	SUM(Pago) + SUM(AbonoMerma) + SUM(AbonoVolumen) - SUM(CargoMerma) + 
	ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
		from VendedoresSaldos VS
		left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
		left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
		where VS.IdCedis = @IdCedis and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between @FechaInicial and @FechaFinal 		
		group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
		having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
		order by VS.Fecha desc),0) as TotalPago	
	from FN_ComisionesDetalleFecha(@IdCedis, @FechaInicial, @FechaFinal) 
	where IdVendedor <> 0 
	group by IdVendedor, Nomina, Vendedor
	order by Vendedor		

	--select top 1 vs.IdVendedor, VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
	--from VendedoresSaldos VS
	--left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
	--left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > @FechaFinal 
	--where VS.IdCedis = @IdCedis and VS.IdVendedor = 82 and VS.Fecha between @FechaInicial and @FechaFinal 		
	--group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
	--having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
	--order by VS.Fecha desc
	
	--select Cantidad * Precio 
	--from SurtidosMerma 
	--inner join SurtidosDetalle on SurtidosMerma.IdCedis = SurtidosDetalle.IdCedis and SurtidosMerma.IdSurtido = SurtidosDetalle.IdSurtido 
	--	and SurtidosMerma.IdProducto = SurtidosDetalle.IdProducto 
	--inner join TipoMerma on SurtidosMerma.IdTipoMerma = TipoMerma.IdTipoMerma and Imputable = 'V'
	--where SurtidosMerma.IdCedis = 2 and SurtidosMerma.IdSurtido = 3098

	--select Vendedores.IdVendedor, Vendedores.Nomina, ApPaterno + ' ' + ApMaterno + ' ' + Nombre as Vendedor,
	--FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor, 
	--FN_ComisionesEsquemaFecha.TipoVendedor, SUM(FN_ComisionesEsquemaFecha.Pago) as Pago, FN_ComisionesEsquemaFecha.Fecha,
	--SUM(FN_ComisionesEsquemaFecha.AbonoMerma) as AbonoMerma, SUM(FN_ComisionesEsquemaFecha.AbonoVolumen) as AbonoVolumen,
	--ISNULL((select sum(Cantidad * Precio) 
	--	from SurtidosMerma 
	--	inner join SurtidosDetalle on SurtidosMerma.IdCedis = SurtidosDetalle.IdCedis and SurtidosMerma.IdSurtido = SurtidosDetalle.IdSurtido 
	--		and SurtidosMerma.IdProducto = SurtidosDetalle.IdProducto 
	--	inner join TipoMerma on SurtidosMerma.IdTipoMerma = TipoMerma.IdTipoMerma and Imputable = 'V'
	--	where SurtidosMerma.IdCedis = FN_ComisionesEsquemaFecha.IdCedis and SurtidosMerma.IdSurtido = FN_ComisionesEsquemaFecha.IdSurtido),0) as CargoMerma
	--from FN_ComisionesEsquemaFecha(@IdCedis, @FechaInicial, @FechaFinal) 
	--inner join FN_ComisionesEsquema(@IdCedis) on FN_ComisionesEsquema.IdComEsquema = FN_ComisionesEsquemaFecha.IdComEsquema and FN_ComisionesEsquema.IdConceptoPago = FN_ComisionesEsquemaFecha.IdConceptoPago
	--	and FN_ComisionesEsquema.IdTipoRuta = FN_ComisionesEsquemaFecha.TipoRuta and FN_ComisionesEsquema.IdTipoVendedor = FN_ComisionesEsquemaFecha.IdTipoVendedor
	--	and FN_ComisionesEsquema.IdProducto = FN_ComisionesEsquemaFecha.IdProducto 
	--inner join SurtidosVendedor on FN_ComisionesEsquemaFecha.IdCedis = SurtidosVendedor.IdCedis and FN_ComisionesEsquemaFecha.IdSurtido = SurtidosVendedor.IdSurtido 
	--	and FN_ComisionesEsquemaFecha.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor
	--inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
	--group by FN_ComisionesEsquemaFecha.IdCedis, Vendedores.IdVendedor, Vendedores.Nomina, ApPaterno, ApMaterno, Nombre,
	--FN_ComisionesEsquemaFecha.TipoVendedor, FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor, FN_ComisionesEsquemaFecha.Fecha

	

