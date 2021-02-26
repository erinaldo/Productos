declare 
@ReporteOrigen as int,
@Tipo as int,
@IdCedi as varchar(3),
@FechaInicial as datetime,
@FechaFinal as datetime,
@Filtro as varchar(4000),
@Ordenamiento as varchar(200),
@FechaIni as datetime

set @IdCedi = 1 
set @FechaFinal = '20100615'
set @Ordenamiento = '2'
set @Filtro = ' and FN_SaldosPorFechaS.IdMarca in (1) '

		exec( ' 
		select Clientes.IdCedis, Cedis, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, 
		Serie, Folio, IdMovimiento, IdDocumento, IdTipoDocumento, Fecha, Inicial as ''INICIAL'', Cargos as ''CARGOS'', Abonos as ''ABONOS''
		from Clientes 
		inner join ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		left outer join FN_BalanzaDetalladaS (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') on FN_BalanzaDetalladaS.IdCedis = Clientes.IdCedis and FN_BalanzaDetalladaS.IdSucursal = CS.IdSucursal
		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
		where Clientes.IdCedis = ' + @IdCedi + '  ' + @Filtro + '  and Inicial is not null and Cargos is not null and Abonos is not null 
		order by Clientes.IdCliente, CS.IdSucursal, FN_BalanzaDetalladaS.Orden, FN_BalanzaDetalladaS.Fecha ')	

--set @Filtro = ' and FN_SaldosPorFechaS.IdMarca in (1) '

--		set @FechaIni = @FechaInicial - 1
--		exec( '
--		select Clientes.IdCedis, Cedis, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, 
		
--		isnull(sum(SaldoInicial), 0) as ''INICIAL'', isnull(sum(Monto + Cargos), 0) as ''CARGOS'', isnull(sum(Abonos), 0) as ''ABONOS'',
--		isnull(sum(SaldoInicial + Monto + Cargos - Abonos ), 0) as ''SALDO''
--		from Clientes 
--		inner join ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
--		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente 
--		left outer join FN_SaldosPorFechaS (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') on FN_SaldosPorFechaS.IdCedis = Clientes.IdCedis 
--			and FN_SaldosPorFechaS.IdSucursal = CS.IdSucursal   ' + @Filtro + '  
--		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
--		where Clientes.IdCedis = ' + @IdCedi + ' 
--		group by Clientes.IdCedis, Cedis.Cedis, Clientes.IdCliente, CS.IdSucursal, NombreSucursal, ClientesTipo.Tipo  
--		having isnull(sum(SaldoInicial), 0) <> 0 or isnull(sum(Monto + Cargos), 0) <> 0 or isnull(sum(Abonos), 0) <> 0 
--		order by Clientes.IdCedis, Cedis.Cedis, Clientes.IdCliente, CS.IdSucursal ')

--set @IdCedi = 1 
--set @FechaFinal = '20100615'
--set @Ordenamiento = '2'
--set @Filtro = ' and FN_VencimientoAlaFechaS.IdMarca in (2) '

		--exec ( 'select Clientes.IdCedis, IdTipoVenta, Serie, Folio, Fecha, FechaVencimiento, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, Saldo, DiasVencidos, Serie + '' '' + cast(Folio as varchar(15)) as DFolio
		--from Clientes
		--inner join RouteADM.dbo.ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		--left outer join FN_VencimientoAlaFechaS (' + @IdCedi + ' , ''' + @FechaFinal + ''' ) on FN_VencimientoAlaFechaS.IdCedis = Clientes.IdCedis 
		--	and FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '  		
		--left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		--where IdTipoVenta is not null  and Clientes.IdCedis = ' + @IdCedi + ' 
		--order by CS.IdSucursal, Fecha' )

--		exec('select Clientes.IdCedis, CS.IdSucursal as ''IdCliente'', isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as ''RazonSocial'', 

--			isnull((select sum(Saldo)
--			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
--			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '  
--			and DiasVencidos < 1 
--			), 0) as ''0'', 

--			isnull((select sum(Saldo)
--			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
--			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '  
--			and DiasVencidos >= 1 and DiasVencidos <= 30 
--			), 0) as ''1 a 30'', 
			
--			isnull((select sum(Saldo)
--			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
--			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
--			and DiasVencidos >= 31 and DiasVencidos <= 60
--			), 0) as ''31 a 60'', 
			
--			isnull((select sum(Saldo)
--			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
--			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
--			and DiasVencidos >= 61 and DiasVencidos <= 90
--			), 0) as ''61 a 90'', 
			
--			isnull((select sum(Saldo)
--			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
--			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
--			and DiasVencidos >= 91 and DiasVencidos <= 120
--			), 0) as ''91 a 120'', 
			
--			isnull((select sum(Saldo)
--			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
--			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
--			and DiasVencidos > 120 
--			), 0) as ''120'', 
			
--			isnull((select sum(Saldo)
--			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
--			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
--			), 0) as ''Total'', Marcas.IdMarca, Marca
			
--			from Clientes 
--			left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente
--			left outer join ClienteSucursal CS on CS.IdCliente = Clientes.IdCliente 
--			left outer join Marcas on Marcas.IdMarca = ' + @Ordenamiento + ' 
--			where Clientes.IdCedis = ' +  @IdCedi + '  
--			group by Clientes.IdCedis, CS.IdSucursal, NombreSucursal, ClientesTipo.Tipo, Clientes.IdCliente, Marcas.IdMarca, Marca
--			having (isnull((select sum(Saldo)
--			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''')  
--			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + ' 
--			), 0)) <> 0			

--			order by Clientes.IdCliente, CS.IdSucursal')
