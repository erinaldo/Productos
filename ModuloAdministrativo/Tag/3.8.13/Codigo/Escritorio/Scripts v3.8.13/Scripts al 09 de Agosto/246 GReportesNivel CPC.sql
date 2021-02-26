USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[Gsp_NivelReporte]    Script Date: 07/29/2010 18:25:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gsp_NivelReporte]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Gsp_NivelReporte]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[Gsp_NivelReporte]    Script Date: 07/29/2010 18:25:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Gsp_NivelReporte]

@ReporteOrigen as int,
@Tipo as int,
@IdCedi as varchar(3),
@FechaInicial as datetime,
@FechaFinal as datetime,
@Filtro as varchar(4000),
@Ordenamiento as varchar(200)

AS

declare @FechaIni as datetime, @IdDocumento as varchar(10) -- , @FechaFin as datetime

if ( (@ReporteOrigen >= 1 and @ReporteOrigen <= 5) or (@ReporteOrigen >= 10 and @ReporteOrigen <= 15) ) and @Ordenamiento = '0'
begin
	if @ReporteOrigen = 1 set @IdDocumento = 'NC'
	if @ReporteOrigen = 2 set @IdDocumento = 'NR'
	if @ReporteOrigen = 3 set @IdDocumento = 'NRA'
	if @ReporteOrigen = 4 set @IdDocumento = 'P'
	if @ReporteOrigen = 5 set @IdDocumento = 'PR'

	if @ReporteOrigen = 10 set @IdDocumento = 'P8212'
	if @ReporteOrigen = 11 set @IdDocumento = 'PBAJI'
	if @ReporteOrigen = 12 set @IdDocumento = 'PBCR'
	if @ReporteOrigen = 13 set @IdDocumento = 'PBNX'
	if @ReporteOrigen = 14 set @IdDocumento = 'PHSBC'
	if @ReporteOrigen = 15 set @IdDocumento = 'AR'

	exec( ' 	Select MovimientosFacturas.IdMovimiento, Fecha, MovimientosFacturas.IdDocumento, Documento
	from MovimientosFacturas
	inner join Documentos on MovimientosFacturas.IdDocumento = Documentos.IdDocumento
	where MovimientosFacturas.IdCedis = ' + @IdCedi + ' 
	and MovimientosFacturas.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 
	and MovimientosFacturas.Status=''A''  ' + @Filtro + ' and MovimientosFacturas.IdDocumento = ''' + @IdDocumento + '''  
	group by MovimientosFacturas.IdMovimiento, Fecha, MovimientosFacturas.IdDocumento, Documento')
	
end

if ( (@ReporteOrigen >= 1 and @ReporteOrigen <= 5) or (@ReporteOrigen >= 10 and @ReporteOrigen <= 15) ) and ( @Tipo >= 10 or @Tipo >= 11 ) and @Ordenamiento = '1'
begin		
	if @ReporteOrigen = 1 set @IdDocumento = 'NC'
	if @ReporteOrigen = 2 set @IdDocumento = 'NR'
	if @ReporteOrigen = 3 set @IdDocumento = 'NRA'
	if @ReporteOrigen = 4 set @IdDocumento = 'P'
	if @ReporteOrigen = 5 set @IdDocumento = 'PR'

	if @ReporteOrigen = 10 set @IdDocumento = 'P8212'
	if @ReporteOrigen = 11 set @IdDocumento = 'PBAJI'
	if @ReporteOrigen = 12 set @IdDocumento = 'PBCR'
	if @ReporteOrigen = 13 set @IdDocumento = 'PBNX'
	if @ReporteOrigen = 14 set @IdDocumento = 'PHSBC'
	if @ReporteOrigen = 15 set @IdDocumento = 'AR'

	exec ( '
	select Movimientos.IdCedis, Cedis, Ventas.Serie, Ventas.Folio, Ventas.Fecha, MovimientosFacturas.Total as Monto,
	Movimientos.IdDocumento + '' '' + Documento as Referencia, MovimientosFacturas.IdDocumento + '' '' + MovimientosFacturas.IdTipoDocumento as TipoD, 
	replicate(0, 6 - len(Movimientos.IdMovimiento)) + cast(Movimientos.IdMovimiento as varchar(6)) as IdMovimiento,
	Movimientos.Fecha as FechaM, Ventas.IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, RazonSocial, Monto as Importe, Movimientos.Login, DocumentosTipo.TipoDocumento as TipoDocumento, 
	Movimientos.Referencia as ReferenciaB, Movimientos.ReferenciaBancos as ReferenciaBancos, Observaciones
	from Movimientos
	inner join Cedis on Cedis.IdCedis = Movimientos.IdCedis
	inner join MovimientosFacturas on Movimientos.IdCedis = MovimientosFacturas.IdCedis and Movimientos.IdMovimiento = MovimientosFacturas.IdMovimiento and MovimientosFacturas.Status <> ''B'' 
	inner join Ventas on Ventas.IdCedis = MovimientosFacturas.IdCedis and Ventas.IdTipoVenta = MovimientosFacturas.IdTipoVenta
	and Ventas.Serie = MovimientosFacturas.Serie and Ventas.Folio = MovimientosFacturas.Folio
	inner join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IDCliente = Ventas.IdCliente 
	left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IDCliente = ClientesTipo.IdCliente 
	inner join Documentos on Movimientos.IdDocumento = Documentos.IdDocumento 
	inner join DocumentosTipo on DocumentosTipo.IdTipoDocumento = MovimientosFacturas.IdTipoDocumento and DocumentosTipo.IdDocumento = MovimientosFacturas.IdDocumento
	where Movimientos.Status <> ''B'' and Movimientos.IdCedis = ' + @IdCedi + '  ' + @Filtro + ' and MovimientosFacturas.IdDocumento = ''' + @IdDocumento + '''  order by Movimientos.IdMovimiento')
--	where Movimientos.Status <> ''B'' and Movimientos.IdCedis = ' + @IdCedi + '  ' + @Filtro + ' and MovimientosFacturas.IdMovimiento = ' + @IdDocumento + '  order by Movimientos.IdMovimiento')
end


if @ReporteOrigen = 6 			-- ANTIGUEDAD DE SALDOS
begin
	If @Tipo = 1 or @Tipo = 2 			-- documento
	begin
		Select distinct Clientes.IdCliente, RazonSocial
		from Clientes
		-- inner join FN_VentasPorCliente(@IdCedi, @FechaInicial, @FechaFinal) on Clientes.IdCedis = FN_VentasPorCliente.IdCedis and Clientes.IdCliente = FN_VentasPorCliente.IdCliente
		where Clientes.IdCedis = @IdCedi
		order by Clientes.IdCliente
	end

	If @Tipo = 3	-- marcas
	begin
		Select IdMarca, Marca
		from Marcas 
		order by IdMarca 
	end

	if @Tipo = 10 or @Tipo = 11
	begin		
		exec ( 'select Clientes.IdCedis, Clientes.IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, RazonSocial, 

			isnull((select sum(Saldo)
			from FN_VencimientoAlaFecha (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente 
			and DiasVencidos < 1 
			), 0) as ''0'', 

			isnull((select sum(Saldo)
			from FN_VencimientoAlaFecha (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente 
			and DiasVencidos >= 1 and DiasVencidos <= 30 
			), 0) as ''1 a 30'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFecha (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente
			and DiasVencidos >= 31 and DiasVencidos <= 60
			), 0) as ''31 a 60'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFecha (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente
			and DiasVencidos >= 61 and DiasVencidos <= 90
			), 0) as ''61 a 90'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFecha (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente
			and DiasVencidos >= 91 and DiasVencidos <= 120
			), 0) as ''91 a 120'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFecha (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente
			and DiasVencidos > 120 
			), 0) as ''120'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFecha (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente
			), 0) as ''Total''
			
			from Clientes 
			left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente
			where Clientes.IdCedis = ' +  @IdCedi + '  ' + @Filtro + ' 
			group by Clientes.IdCedis, Clientes.IdCliente, Clientes.RazonSocial, ClientesTipo.Tipo
			having (isnull((select sum(Saldo)
			from FN_VencimientoAlaFecha (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente
			), 0)) <> 0			

			order by Clientes.IdCliente ' )

	end
	
	if @Tipo = 20 or @Tipo = 21
	begin		
		exec('select Clientes.IdCedis, CS.IdSucursal as ''IdCliente'', isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as ''RazonSocial'', 

			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal 
			and DiasVencidos < 1 
			), 0) as ''0'', 

			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal 
			and DiasVencidos >= 1 and DiasVencidos <= 30 
			), 0) as ''1 a 30'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			and DiasVencidos >= 31 and DiasVencidos <= 60
			), 0) as ''31 a 60'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			and DiasVencidos >= 61 and DiasVencidos <= 90
			), 0) as ''61 a 90'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			and DiasVencidos >= 91 and DiasVencidos <= 120
			), 0) as ''91 a 120'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			and DiasVencidos > 120 
			), 0) as ''120'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			), 0) as ''Total''
			
			from Clientes 
			left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente
			left outer join ClienteSucursal CS on CS.IdCliente = Clientes.IdCliente 
			where Clientes.IdCedis = ' +  @IdCedi + '  ' + @Filtro + ' 
			group by Clientes.IdCedis, CS.IdSucursal, NombreSucursal, ClientesTipo.Tipo, Clientes.IdCliente
			having (isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			), 0)) <> 0			

			order by CS.NombreSucursal')
	end

	if @Tipo = 30 or @Tipo = 31
	begin		
		exec('select Clientes.IdCedis, CS.IdSucursal as ''IdCliente'', isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as ''RazonSocial'', 

			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '  
			and DiasVencidos < 1 
			), 0) as ''0'', 

			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '  
			and DiasVencidos >= 1 and DiasVencidos <= 30 
			), 0) as ''1 a 30'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
			and DiasVencidos >= 31 and DiasVencidos <= 60
			), 0) as ''31 a 60'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
			and DiasVencidos >= 61 and DiasVencidos <= 90
			), 0) as ''61 a 90'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
			and DiasVencidos >= 91 and DiasVencidos <= 120
			), 0) as ''91 a 120'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
			and DiasVencidos > 120 
			), 0) as ''120'', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + '   
			), 0) as ''Total'', Marcas.IdMarca, Marca
			
			from Clientes 
			left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente
			left outer join ClienteSucursal CS on CS.IdCliente = Clientes.IdCliente 
			left outer join Marcas on ' + @Ordenamiento + ' 
			where Clientes.IdCedis = ' +  @IdCedi + '  
			group by Clientes.IdCedis, CS.IdSucursal, NombreSucursal, ClientesTipo.Tipo, Clientes.IdCliente, Marcas.IdMarca, Marca
			having (isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (' + @IdCedi + ', ''' + @FechaFinal + ''')  
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal ' + @Filtro + ' 
			), 0)) <> 0			

			order by CS.NombreSucursal')
	end
end


if @ReporteOrigen = 7      		-- ANTIGUEDAD DE SALDOS DETALLADA
begin
	If @Tipo = 1 or @Tipo = 2			-- documento
	begin
		Select distinct Clientes.IdCliente, RazonSocial
		from Clientes
		where Clientes.IdCedis = @IdCedi
		order by Clientes.IdCliente
	end

	If @Tipo = 3	-- marcas
	begin
		Select IdMarca, Marca
		from Marcas 
		order by IdMarca 
	end

	if @Tipo = 10 or @Tipo = 11
	begin
		exec ( 'select Clientes.IdCedis, IdTipoVenta, Serie, Folio, Fecha, FechaVencimiento, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, Saldo, DiasVencidos, Serie + '' '' + cast(Folio as varchar(15)) as DFolio
		from Clientes
		inner join RouteADM.dbo.ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join FN_VencimientoAlaFecha (' + @IdCedi + ' , ''' + @FechaFinal + ''' ) on FN_VencimientoAlaFecha.IdCedis = Clientes.IdCedis 
			and FN_VencimientoAlaFecha.IdCliente = Clientes.IdCliente
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		where IdTipoVenta is not null  and Clientes.IdCedis = ' + @IdCedi + ' ' + @Filtro + '  		
		order by Clientes.IdCliente, CS.IdSucursal, Fecha')
		-- FechaVencimiento, 
	end

	if @Tipo = 20 or @Tipo = 21
	begin
		exec ( 'select Clientes.IdCedis, IdTipoVenta, Serie, Folio, Fecha, FechaVencimiento, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, Saldo, DiasVencidos, Serie + '' '' + cast(Folio as varchar(15)) as DFolio
		from Clientes
		inner join RouteADM.dbo.ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join FN_VencimientoAlaFechaS (' + @IdCedi + ' , ''' + @FechaFinal + ''' ) on FN_VencimientoAlaFechaS.IdCedis = Clientes.IdCedis 
			and FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		where IdTipoVenta is not null  and Clientes.IdCedis = ' + @IdCedi + ' ' + @Filtro + '  		
		order by CS.NombreSucursal' )
		-- FechaVencimiento, 
	end

	if @Tipo = 30 or @Tipo = 31
	begin
		exec ( 'select Clientes.IdCedis, IdTipoVenta, Serie, Folio, Fecha, FechaVencimiento, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, Saldo, DiasVencidos, Serie + '' '' + cast(Folio as varchar(15)) as DFolio
		from Clientes
		inner join RouteADM.dbo.ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join FN_VencimientoAlaFechaS (' + @IdCedi + ' , ''' + @FechaFinal + ''' ) on FN_VencimientoAlaFechaS.IdCedis = Clientes.IdCedis 
			and FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal  ' + @Filtro + '  		
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		where IdTipoVenta is not null  and Clientes.IdCedis = ' + @IdCedi + '
		order by CS.NombreSucursal' )
		-- FechaVencimiento, 
	end
end


if @ReporteOrigen = 8 			-- BALANZA DE CLIENTES
begin
	If @Tipo = 1 or @Tipo = 2			-- documento
	begin
		Select distinct Clientes.IdCliente, RazonSocial
		from Clientes
		where Clientes.IdCedis = @IdCedi
		order by Clientes.IdCliente
	end

	If @Tipo = 3	-- marcas
	begin
		Select IdMarca, Marca
		from Marcas 
		order by IdMarca 
	end

	if @Tipo = 10 or @Tipo = 11
	begin	
		set @FechaIni = @FechaInicial - 1
		exec( '
		select Clientes.IdCedis, Cedis, Clientes.IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, RazonSocial, 
		
		isnull(sum(SaldoInicial), 0) as ''INICIAL'', isnull(sum(Monto + Cargos), 0) as ''CARGOS'', isnull(sum(Abonos), 0) as ''ABONOS'',
		isnull(sum(SaldoInicial + Monto + Cargos - Abonos ), 0) as ''SALDO''
		from Clientes 
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		left outer join FN_SaldosPorFecha (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') on FN_SaldosPorFecha.IdCedis = Clientes.IdCedis and FN_SaldosPorFecha.IdCliente = Clientes.IdCliente
		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
		where Clientes.IdCedis = ' + @IdCedi + '  ' + @Filtro + '  
		group by Clientes.IdCedis, Cedis.Cedis, Clientes.IdCliente, RazonSocial, ClientesTipo.Tipo  
		having isnull(sum(SaldoInicial), 0) <> 0 or isnull(sum(Monto + Cargos), 0) <> 0 or isnull(sum(Abonos), 0) <> 0 -- isnull(sum(SaldoInicial + Monto + Cargos - Abonos ), 0)  <> 0 ')
	end

	if @Tipo = 20 or @Tipo = 21
	begin	
		set @FechaIni = @FechaInicial - 1
		exec( '
		select Clientes.IdCedis, Cedis, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, 
		
		isnull(sum(SaldoInicial), 0) as ''INICIAL'', isnull(sum(Monto + Cargos), 0) as ''CARGOS'', isnull(sum(Abonos), 0) as ''ABONOS'',
		isnull(sum(SaldoInicial + Monto + Cargos - Abonos ), 0) as ''SALDO''
		from Clientes 
		inner join ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente 
		left outer join FN_SaldosPorFechaS (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') on FN_SaldosPorFechaS.IdCedis = Clientes.IdCedis and FN_SaldosPorFechaS.IdSucursal = CS.IdSucursal 
		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
		where Clientes.IdCedis = ' + @IdCedi + '  ' + @Filtro + '  
		group by Clientes.IdCedis, Cedis.Cedis, Clientes.IdCliente, CS.IdSucursal, NombreSucursal, ClientesTipo.Tipo  
		having isnull(sum(SaldoInicial), 0) <> 0 or isnull(sum(Monto + Cargos), 0) <> 0 or isnull(sum(Abonos), 0) <> 0 
		order by CS.NombreSucursal')
	end

	if @Tipo = 30 or @Tipo = 31
	begin	
		set @FechaIni = @FechaInicial - 1
		exec( '
		select Clientes.IdCedis, Cedis, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, 
		
		isnull(sum(SaldoInicial), 0) as ''INICIAL'', isnull(sum(Monto + Cargos), 0) as ''CARGOS'', isnull(sum(Abonos), 0) as ''ABONOS'',
		isnull(sum(SaldoInicial + Monto + Cargos - Abonos ), 0) as ''SALDO''
		from Clientes 
		inner join ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente 
		left outer join FN_SaldosPorFechaS (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') on FN_SaldosPorFechaS.IdCedis = Clientes.IdCedis 
			and FN_SaldosPorFechaS.IdSucursal = CS.IdSucursal   ' + @Filtro + '  
		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
		where Clientes.IdCedis = ' + @IdCedi + ' 
		group by Clientes.IdCedis, Cedis.Cedis, Clientes.IdCliente, CS.IdSucursal, NombreSucursal, ClientesTipo.Tipo  
		having isnull(sum(SaldoInicial), 0) <> 0 or isnull(sum(Monto + Cargos), 0) <> 0 or isnull(sum(Abonos), 0) <> 0 
		order by CS.NombreSucursal')
	end

end

if @ReporteOrigen = 18 			-- BALANZA DE CLIENTES DETALLADA
begin
	If @Tipo = 1 or @Tipo = 2			-- documento
	begin
		Select distinct Clientes.IdCliente, RazonSocial
		from Clientes
		where Clientes.IdCedis = @IdCedi
		order by Clientes.IdCliente
	end

	If @Tipo = 3	-- marcas
	begin
		Select IdMarca, Marca
		from Marcas 
		order by IdMarca 
	end

	if @Tipo = 10 or @Tipo = 11
	begin	
--		set @FechaIni = @FechaInicial - 1
		exec( ' 
		select Clientes.IdCedis, Cedis, Clientes.IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, RazonSocial, 
		Serie, Folio, IdMovimiento, IdDocumento, IdTipoDocumento, Fecha, Inicial as ''INICIAL'', Cargos as ''CARGOS'', Abonos as ''ABONOS''
		from Clientes 
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		left outer join FN_BalanzaDetallada (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') on FN_BalanzaDetallada.IdCedis = Clientes.IdCedis and FN_BalanzaDetallada.IdCliente = Clientes.IdCliente
		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
		where Clientes.IdCedis = ' + @IdCedi + '  ' + @Filtro + '  and Inicial is not null and Cargos is not null and Abonos is not null 
		order by Clientes.IdCliente, FN_BalanzaDetallada.Orden, FN_BalanzaDetallada.Fecha ')	
	end

	if @Tipo = 20 or @Tipo = 21
	begin	
--		set @FechaIni = @FechaInicial - 1
		exec( ' 
		select Clientes.IdCedis, Cedis, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, 
		Serie, Folio, IdMovimiento, IdDocumento, IdTipoDocumento, Fecha, Inicial as ''INICIAL'', Cargos as ''CARGOS'', Abonos as ''ABONOS''
		from Clientes 
		inner join ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		left outer join FN_BalanzaDetalladaS (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') on FN_BalanzaDetalladaS.IdCedis = Clientes.IdCedis and FN_BalanzaDetalladaS.IdSucursal = CS.IdSucursal
		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
		where Clientes.IdCedis = ' + @IdCedi + '  ' + @Filtro + '  and Inicial is not null and Cargos is not null and Abonos is not null 
		order by CS.NombreSucursal')	
	end

	if @Tipo = 30 or @Tipo = 31
	begin	
--		set @FechaIni = @FechaInicial - 1
		exec( ' 
		select Clientes.IdCedis, Cedis, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, NombreSucursal as RazonSocial, 
		Serie, Folio, IdMovimiento, IdDocumento, IdTipoDocumento, Fecha, Inicial as ''INICIAL'', Cargos as ''CARGOS'', Abonos as ''ABONOS''
		from Clientes 
		inner join ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		left outer join FN_BalanzaDetalladaM (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', ' + @Ordenamiento + ') on FN_BalanzaDetalladaM.IdCedis = Clientes.IdCedis and FN_BalanzaDetalladaM.IdSucursal = CS.IdSucursal
		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
		where Clientes.IdCedis = ' + @IdCedi + '  and Inicial is not null and Cargos is not null and Abonos is not null 
		order by CS.NombreSucursal')	
	end
end

if @ReporteOrigen = 9 			-- VENTAS POR CLIENTE
begin
	If @Tipo = 1 			-- documento
	begin
		Select distinct Clientes.IdCliente, RazonSocial
		from Clientes
		-- inner join FN_VentasPorCliente(@IdCedi, @FechaInicial, @FechaFinal) on Clientes.IdCedis = FN_VentasPorCliente.IdCedis and Clientes.IdCliente = FN_VentasPorCliente.IdCliente
		where Clientes.IdCedis = @IdCedi
		order by Clientes.IdCliente
	end

	if @Tipo = 10 or @Tipo = 11
	begin		
		exec( 'select FN_VentasPorCliente.IdCedis, FN_VentasPorCliente.IdCliente, isnull( ClientesTipo.Tipo, ''-'') as CTipo, RazonSocial, IdGpo, IdFam, 
		FN_VentasPorCliente.IdProducto, FN_VentasPorCliente.Producto, sum(Cantidad) as Piezas, sum(Kilolitros) as Kilolitros, 
		sum(Total) as Importe, Precio as PrecioProm 
		from FN_VentasPorCliente (' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''')
		left outer join ClientesTipo on FN_VentasPorCliente.IdCedis = ClientesTipo.IdCedis and FN_VentasPorCliente.IdCliente = ClientesTipo.IdCliente   
		inner join CLientes on Clientes.IdCedis = FN_VentasPorCliente.IdCedis and Clientes.IdCliente = FN_VentasPorCliente.IdCliente
		inner join Grupos on Grupos.IdGrupo = FN_VentasPorCliente.IdGrupo
		inner join Familias on Familias.IdFamilia = FN_VentasPorCliente.IdFamilia
		group by FN_VentasPorCliente.IdCedis, FN_VentasPorCliente.IdCliente, RazonSocial, FN_VentasPorCliente.IdGrupo, IdGpo, FN_VentasPorCliente.IdFamilia, IdFam, FN_VentasPorCliente.IdProducto, FN_VentasPorCliente.Producto, Precio, ClientesTipo.Tipo 		
		order by FN_VentasPorCliente.IdCliente, FN_VentasPorCliente.IdGrupo, FN_VentasPorCliente.IdFamilia, FN_VentasPorCliente.IdProducto')
	end

end

if @ReporteOrigen = 16 			-- CONCILIACIÓN BANCARIA
begin
	If @Tipo = 1 			-- documento
	begin

		Select IdDocumento, Documento
		from Documentos
		order by IdDocumento, Documento
	end

	if @Tipo = 10 or @Tipo = 11
	begin		
		exec ( '
		select replicate(0, 6 - len(Movimientos.IdMovimiento)) + cast(Movimientos.IdMovimiento as varchar(6)) as IdMovimiento,
		Movimientos.Fecha as FechaM, Movimientos.IdDocumento + '' '' + Documento as Referencia, Movimientos.Login, Monto as Importe,
		Movimientos.Referencia as ReferenciaB, Movimientos.ReferenciaBancos as ReferenciaBancos 
		from Movimientos
		inner join Documentos on Movimientos.IdDocumento = Documentos.IdDocumento 
		where Movimientos.Status <> ''B'' and Movimientos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' and Movimientos.IdCedis = ' + @IdCedi + '  ' + @Filtro + ' order by Movimientos.IdMovimiento')
	end

end

if @ReporteOrigen = 17 			-- DEPOSITOS DE CLIENTES POR BANCO
begin
	If @Tipo = 1 			-- documento
	begin
		Select IdCedis, Cedis
		from Cedis
		where IdCedis not in ( 999 )
		order by Cedis, IdCedis
	end

	if @Tipo = 10 or @Tipo = 11
	begin	
		exec(
		' select FN_ClientesBancos.IdCedis, isnull( CedisCuentas.Cuenta, ''No Definida'') as Entidad, isnull( DocumentosCuentas.Cuenta, ''No Definida'') as Cuenta, IdCliente, RazonSocial, Banco, ReferenciaB, ReferenciaBancos, Pago
		from FN_ClientesBancos (''' + @FechaInicial + ''', ''' + @FechaFinal + ''')
		left outer join CedisCuentas on CedisCuentas.IdCedis = FN_ClientesBancos.IdCedis
		left outer join DocumentosCuentas on DocumentosCuentas.IdDocumento = FN_ClientesBancos.IdDocumento
		where FN_ClientesBancos.IdCedis > 0  ' +  @Filtro + '   
		order by FN_ClientesBancos.IdCedis, IdCliente, ReferenciaB, ReferenciaBancos   ' )
	end

end

if @ReporteOrigen = 19 			-- PROMOCIONES DETALLADO
begin
	If @Tipo = 1 			-- documento
	begin
		exec( ' select distinct PromocionesAplicadas.IdPromocion, Promociones.Nombre as ''Promoción'', PromocionesAplicadas.IdAplicacion as ''Folio'', Movimientos.Fecha as ''F. Aplicación''
		from PromocionesAplicadas
		inner join Promociones on Promociones.IdPromocion = PromocionesAplicadas.IdPromocion
		inner join PromocionesAplicadasDetalle on PromocionesAplicadasDetalle.IdPromocion = PromocionesAplicadas.IdPromocion and 
			PromocionesAplicadasDetalle.IdAplicacion = PromocionesAplicadas.IdAplicacion
		inner join Movimientos on Movimientos.IdCedis = PromocionesAplicadasDetalle.IdCedis and 
			Movimientos.IdMovimiento = PromocionesAplicadasDetalle.IdMovimiento and Movimientos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''
		where PromocionesAplicadas.Status = ''A''' )
	end
		
	if @Tipo = 10 or @Tipo = 11
	begin	
		
		exec ( 'CREATE TABLE [RouteCPC].dbo.[' + @Ordenamiento + '] (
			[IdPromocion] [bigint] NOT NULL ,
			[Nombre] [varchar] (200) COLLATE Traditional_Spanish_CI_AS NULL ,
			[InicioPromo] [datetime] NULL ,
			[FinalPromo] [datetime] NULL ,
			[IdAplicacion] [bigint] NULL ,
			[FechaAplicacion] [datetime] NULL ,
			[FechaEjecucion] [datetime] NULL ,
			[InicioAplicacion] [datetime] NULL ,
			[FinAplicacion] [datetime] NULL ,
			[IdCedis] [bigint] NULL ,
			[Cedis] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
			[IdProducto] [bigint] NULL ,
			[Producto] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
			[Total] [money] NULL ,
			[Piezas] [float] NULL ,
			[ImportePromocion] [money] NULL ,
			[Porcentaje] [float] NULL 
		) ON [PRIMARY] ')
		
		exec ( '
		
		declare @IdPromocion as bigint, @IdAplicacion as bigint
		
		declare  Promociones cursor for
			select distinct PromocionesAplicadas.IdPromocion, PromocionesAplicadas.IdAplicacion
			from PromocionesAplicadas 
			inner join PromocionesAplicadasDetalle on PromocionesAplicadasDetalle.IdPromocion = PromocionesAplicadas.IdPromocion and 
				PromocionesAplicadasDetalle.IdAplicacion = PromocionesAplicadas.IdAplicacion
			inner join Movimientos on Movimientos.IdCedis = PromocionesAplicadasDetalle.IdCedis and 
				Movimientos.IdMovimiento = PromocionesAplicadasDetalle.IdMovimiento and Movimientos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''
			where PromocionesAplicadas.Status = ''A'' 
			order by PromocionesAplicadas.IdPromocion, PromocionesAplicadas.IdAplicacion
		open Promociones
		
		fetch next from Promociones into @IdPromocion, @IdAplicacion 
		while (@@fetch_status = 0)
		begin
			INSERT INTO [RouteCPC].dbo.[' + @Ordenamiento + ']
		
			select PromocionesAplicadasDetalle.IdPromocion, Promociones.Nombre, Promociones.FechaInicial as ''Inicio Promo'', Promociones.FechaFinal as ''Final Promo'', 
			PromocionesAplicadasDetalle.IdAplicacion, Movimientos.Fecha as ''Fecha Aplicacion'', PromocionesAplicadas.Fecha as ''Fecha Ejecucion'', PromocionesAplicadas.FechaInicial as ''Inicio de Aplicacion'', PromocionesAplicadas.FechaFinal as ''Fin de Aplicacion'', 
			VentasDetalle.IdCedis, Cedis, 
			VentasDetalle.IdProducto, Productos.Producto, sum(VentasDetalle.Total) as Total, 
			sum(VentasDetalle.Cantidad) as Piezas, sum(VentasDetalle.Total * Porcentaje) as ImportePromocion, avg(Porcentaje) as ''Porcentaje''
			from PromocionesAplicadasDetalle
			inner join Movimientos on Movimientos.IdCedis = PromocionesAplicadasDetalle.IdCedis and 
				Movimientos.IdMovimiento = PromocionesAplicadasDetalle.IdMovimiento
			inner join Promociones on Promociones.IdPromocion = PromocionesAplicadasDetalle.IdPromocion
			inner join PromocionesAplicadas on PromocionesAplicadas.IdPromocion = PromocionesAplicadasDetalle.IdPromocion and PromocionesAplicadas.IdAplicacion = PromocionesAplicadasDetalle.IdAplicacion 
			inner join VentasDetalle on VentasDetalle.IdCedis = PromocionesAplicadasDetalle.IdCedis 
				and VentasDetalle.IdTipoVenta = PromocionesAplicadasDetalle.IdTipoVenta and VentasDetalle.Folio = PromocionesAplicadasDetalle.Folio 
			inner join Cedis on Cedis.IdCedis = VentasDetalle.IdCedis
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto
			inner join FN_PromocionesProductos (@IdPromocion) as FNProds on FNProds.IdProducto = VentasDetalle.IdProducto
			where PromocionesAplicadasDetalle.IdAplicacion = @IdAplicacion and PromocionesAplicadasDetalle.IdPromocion = @IdPromocion 
			group by PromocionesAplicadasDetalle.IdAplicacion, PromocionesAplicadasDetalle.IdPromocion, Promociones.Nombre, Promociones.FechaInicial, Promociones.FechaFinal, VentasDetalle.IdCedis, Cedis, 
			VentasDetalle.IdProducto, Productos.Producto, Movimientos.Fecha, PromocionesAplicadas.Fecha, PromocionesAplicadas.FechaInicial, PromocionesAplicadas.FechaFinal
			order by VentasDetalle.IdCedis, PromocionesAplicadasDetalle.IdPromocion desc, PromocionesAplicadasDetalle.IdAplicacion desc, VentasDetalle.IdProducto
		
			fetch next from Promociones into @IdPromocion, @IdAplicacion 
		end
		close Promociones
		deallocate Promociones ')		
	end

end

if @ReporteOrigen = 20
begin 

	If @Tipo = 1 
	begin
		select 'Cobranza Vendedores del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
	end

	if @Tipo = 10 or @Tipo = 11
	begin
		exec ( 'select ''COBRANZA'' as Concepto, Dia.FechaCaptura as Fecha, M.IdMarca as IdMarca, left(M.Marca,30) Marca, 
		left(CS.NombreCorto,60) NombreSucursal, FAC.Folio as Folio, sum(ABN.Total) as Total 
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
		left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		inner join RouteADM.dbo.Marcas M on M.IdMarca = FAC.SubEmpresaID 
		inner join Route.dbo.Cliente CS on CS.ClienteClave = VIS.ClienteClave 
		where Dia.FechaCaptura between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''  
		and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
		group by Dia.FechaCaptura, M.IdMarca, M.Marca, CS.NombreCorto, FAC.Folio
		order by Dia.FechaCaptura, M.IdMarca, M.Marca, CS.NombreCorto, FAC.Folio' )
	end

end

if @ReporteOrigen = 100			-- DIARIO DE VENTAS
begin
	If @Tipo = 1 			-- Cedis
	begin
		Select IdCedis, Cedis
		from Cedis
		where IdCedis not in ( 999 )
		order by Cedis, IdCedis
	end

	if @Tipo = 10 or @Tipo = 11
	begin		
		exec ( 'Select Orden , Cuenta, Entidad, Clave, NombreCuenta, NomCuenta, NombreEntidad, Cargos, Abonos, FN_PolizaDiarioVentasCompleta.IdCedis
		from FN_PolizaDiarioVentasCompleta ( ''' + @FechaInicial + ''', ''' + @FechaFinal + ''' ) 
		inner join Cedis as CED on CED.IdCedis = FN_PolizaDiarioVentasCompleta.IdCedis ' + @Filtro + ' 
		where Orden >= 0 ' + @Filtro + ' 

		order by NombreEntidad, Orden' )
	end

end

if @ReporteOrigen = 101			-- LIBRO DE VENTAS
begin
	If @Tipo = 1 			-- Cedis
	begin
		Select IdCedis, Cedis
		from Cedis
		where IdCedis not in ( 999 )
		order by Cedis, IdCedis
	end

	if @Tipo = 10 or @Tipo = 11
	begin
	exec ( 'SELECT  Substring(FNCTA.Cuenta,5,2) AS No, Familias.Familia, FNCTA.Cuenta, FNCTA.Entidad, FNCTA.IdProducto AS Clave, PRO.Producto AS NombreCuenta, CED.Cedis AS NombreEntidad, FNCTA.Piezas, 
	                      PRO.Conversion AS Unidad, PRO.Conversion * FNCTA.Piezas AS Kilolitros, FNCTA.SubTotal / FNCTA.Piezas as PrecioProm, FNCTA.SubTotal, FNCTA.IVA, 
	                      FNCTA.Total, FNCTA.IdCedis as IdCedis, 0 as Orden
		FROM         FN_CuentasCEDIS_SKU ( ''' + @FechaInicial + ''', ''' + @FechaFinal + ''' ) FNCTA INNER JOIN
		                      Cedis CED ON FNCTA.IdCedis = CED.IdCedis LEFT OUTER JOIN
		                      Productos PRO ON FNCTA.IdProducto = PRO.IdProducto LEFT OUTER JOIN
					Familias on Familias.IdFamilia = PRO.IdFamilia
		WHERE FNCTA.IdProducto >= 0 ' + @Filtro + '  
	
		union 
	
		select '''' as No, '''' as Familia, ''Cuenta No Definida'' as Cuenta, ''No Entidad'' as Entidad, 0 as Clave, ''FACTURAS OXXO'' as NombreCuenta, Cedis as NombreEntidad, isnull(sum(Cantidad), 0) as Piezas, 
		0 as Unidad, isnull(sum(Cantidad * Conversion), 0) as Kilolitros, 0 as PrecioProm, isnull(sum(VentasDetalle.SubTotal), 0) as Subtotal, isnull(sum(VentasDetalle.Total) - sum(VentasDetalle.SubTotal), 0) as Iva,  
		isnull(sum(VentasDetalle.Total), 0) as Total, Ventas.IdCedis as IdCedis, 1 as Orden
		from Ventas
		inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and 
		VentasDetalle.Serie = Ventas.Serie and VentasDetalle.Folio = Ventas.Folio 
		inner join Cedis as CED on CED.IdCedis = Ventas.IdCedis ' + @Filtro + ' 
		inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto			
		where Ventas.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' and ( Ventas.Serie like ''OX%'' or Ventas.Serie like ''BA%'' )  ' + @Filtro + ' 
		group by CED.Cedis, Ventas.IdCedis
	
		union
	
		select '''' as No, '''' as Familia, ''11060500'' as Cuenta, CedisCuentas.Cuenta  as Entidad, 0 as Clave, ''CLIENTES'' as NombreCuenta, Cedis as NombreEntidad, 0 as Piezas, 
		0 as Unidad, 0 as Kilolitros, 0 as PrecioProm, isnull(sum(MC.Total), 0) - isnull(sum(MA.Total), 0) as Subtotal, 0 as Iva,  
		isnull(sum(MC.Total), 0) - isnull(sum(MA.Total), 0) as Total, Ventas.IdCedis as IdCedis, 2 as Orden
		from Ventas 
		left outer join MovimientosFacturas as MC on MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
		MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> ''B'' and MC.CargoAbono = ''C'' and MC.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''
		left outer join MovimientosFacturas as MA on MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
		MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> ''B'' and MA.CargoAbono = ''A'' and MA.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''
			and substring(MA.IdDocumento, 1, 1) <> ''P''  
		left outer join Cedis as CED on CED.IdCedis = Ventas.IdCedis
		left outer join CedisCuentas on CedisCuentas.IdCedis = CED.IdCedis
		where Ventas.Fecha <= ''' + @FechaFinal + '''  ' + @Filtro + ' 
		group by Ventas.IdCedis, CedisCuentas.Cuenta, CED.Cedis
		
		ORDER BY IdCedis, Orden, FNCTA.Cuenta  ' )		
	
/*		exec ( 'SELECT     FNCTA.Cuenta, FNCTA.Entidad, FNCTA.IdProducto AS Clave, PRO.Producto AS NombreCuenta, CED.Cedis AS NombreEntidad, FNCTA.Piezas, 
		                      PRO.Conversion AS Unidad, PRO.Conversion * FNCTA.Piezas AS Kilolitros, FNCTA.[Precio Promedio de Venta] as PrecioProm, FNCTA.SubTotal, FNCTA.IVA, 
		                      FNCTA.Total, FNCTA.IdCedis as IdCedis, 0 as Orden
			FROM         FN_CuentasCEDIS_SKU ( ''' + @FechaInicial + ''', ''' + @FechaFinal + ''' ) FNCTA INNER JOIN
			                      Cedis CED ON FNCTA.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      Productos PRO ON FNCTA.IdProducto = PRO.IdProducto
			WHERE FNCTA.IdProducto >= 0 ' + @Filtro + '  

			union 

			select ''Cuenta No Definida'' as Cuenta, ''No Entidad'' as Entidad, 0 as Clave, ''FACTURAS OXXO'' as NombreCuenta, Cedis as NombreEntidad, isnull(sum(Cantidad), 0) as Piezas, 
			0 as Unidad, isnull(sum(Cantidad * Conversion), 0) as Kilolitros, 0 as PrecioProm, isnull(sum(VentasDetalle.SubTotal), 0) as Subtotal, isnull(sum(VentasDetalle.Total) - sum(VentasDetalle.SubTotal), 0) as Iva,  
			isnull(sum(VentasDetalle.Total), 0) as Total, Ventas.IdCedis as IdCedis, 1 as Orden
			from Ventas
			inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and 
			VentasDetalle.Serie = Ventas.Serie and VentasDetalle.Folio = Ventas.Folio 
			inner join Cedis as CED on CED.IdCedis = Ventas.IdCedis ' + @Filtro + ' 
			inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto			
			where Ventas.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' and ( Ventas.Serie like ''OX%'' or Ventas.Serie like ''BA%'' )  ' + @Filtro + ' 
			group by CED.Cedis, Ventas.IdCedis

			union

			select ''11060500'' as Cuenta, CedisCuentas.Cuenta  as Entidad, 0 as Clave, ''CLIENTES'' as NombreCuenta, Cedis as NombreEntidad, 0 as Piezas, 
			0 as Unidad, 0 as Kilolitros, 0 as PrecioProm, 0 as Subtotal, 0 as Iva,  
			isnull(sum(MC.Total), 0) - isnull(sum(MA.Total), 0) as Total, Ventas.IdCedis as IdCedis, 2 as Orden
			from Ventas 
			left outer join MovimientosFacturas as MC on MC.IdCedis = Ventas.IdCedis and MC.IdTipoVenta = Ventas.IdTipoVenta and 
			MC.Serie = Ventas.Serie and MC.Folio = Ventas.Folio and MC.Status <> ''B'' and MC.CargoAbono = ''C'' and MC.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''
			left outer join MovimientosFacturas as MA on MA.IdCedis = Ventas.IdCedis and MA.IdTipoVenta = Ventas.IdTipoVenta and 
			MA.Serie = Ventas.Serie and MA.Folio = Ventas.Folio and MA.Status <> ''B'' and MA.CargoAbono = ''A'' and MA.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''
				and substring(MA.IdDocumento, 1, 1) <> ''P''  
			left outer join Cedis as CED on CED.IdCedis = Ventas.IdCedis
			left outer join CedisCuentas on CedisCuentas.IdCedis = CED.IdCedis
			where Ventas.Fecha <= ''' + @FechaFinal + '''  ' + @Filtro + ' 
			group by Ventas.IdCedis, CedisCuentas.Cuenta, CED.Cedis
			
			ORDER BY IdCedis, Orden, FNCTA.Cuenta  ' )		*/
	end

end

if @ReporteOrigen = 102			-- RESUMEN DE MOVIMIENTOS
begin
	If @Tipo = 1 			-- Cedis
	begin
		Select IdCedis, Cedis
		from Cedis
		where IdCedis not in ( 999 )
		order by Cedis, IdCedis
	end

	if @Tipo = 10 or @Tipo = 11
	begin
		exec( '		
			Select IdCedis, Cedis, Orden, Concepto, sum(Cargos) as Cargos, sum(Abonos) as Abonos
			from FN_PolizaResumenMovimientos ( ''' + @FechaInicial + ''', ''' + @FechaFinal + ''' )
			where idcedis > 0 ' + @Filtro + ' 
			group by IdCedis, Cedis, Orden, Concepto
			order by Cedis, Orden '
		)
	end

end

if @ReporteOrigen = 103			-- IVA POR PAGAR COBRADO
begin
	If @Tipo = 1 			-- Cedis
	begin
		Select IdCedis, Cedis
		from Cedis
		where IdCedis not in ( 999 )
		order by Cedis, IdCedis
	end

	if @Tipo = 10 or @Tipo = 11
	begin

		exec ( 
		'Select MovimientosFacturas.IdCedis, Cedis, Ventas.IdCliente, RazonSocial, MovimientosFacturas.IdMovimiento, MovimientosFacturas.IdDocumento + '' '' + MovimientosFacturas.IdTipoDocumento + '' - '' +  TipoDocumento as ''TipoDocumento'', MovimientosFacturas.Fecha,  MovimientosFacturas.Total as Pago, 
		Ventas.Fecha as FechaFactura, case VentasTipo.Tipo when 1 then ''Factura de Crédito'' else ''Factura de Contado'' end as ''TipoVenta'', Ventas.Serie, Ventas.Folio, Ventas.Iva, Ventas.Total,
		case Ventas.Total when 0 then 0 else MovimientosFacturas.Total * Ventas.Iva / Ventas.Total end as ''IvaReconocido'', case Ventas.Iva * Ventas.Total when 0 then 0 else ( MovimientosFacturas.Total * Ventas.Iva / Ventas.Total ) / Ventas.Iva end as ''Factor''
		from MovimientosFacturas
		inner join Ventas on Ventas.IdCedis = MovimientosFacturas.IdCedis and Ventas.IdTipoVenta = MovimientosFacturas.IdTipoVenta and 
			Ventas.Serie = MovimientosFacturas.Serie and Ventas.Folio = MovimientosFacturas.Folio
		inner join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IdCliente = Ventas.IdCliente
		inner join VentasTipo on VentasTipo.IdTipoVenta = Ventas.IdTipoVenta
		inner join Cedis on Cedis.IdCedis = MovimientosFacturas.IdCedis
		inner join DocumentosTipo on MovimientosFacturas.IdDocumento = DocumentosTipo.IdDocumento and MovimientosFacturas.IdTipoDocumento = DocumentosTipo.IdTipoDocumento 
		where MovimientosFacturas.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' and MovimientosFacturas.Status <> ''B'' and MovimientosFacturas.CargoAbono = ''A'' and substring(MovimientosFacturas.IdDocumento, 1, 1) = ''P'' ' + @Filtro + '   
		order by MovimientosFacturas.IdCedis, Cedis, Ventas.IdCliente, MovimientosFacturas.IdMovimiento' 
		 )
	end
end


if @ReporteOrigen = 104			-- IETU
begin
	If @Tipo = 1 			-- Cedis
	begin
		Select IdCedis, Cedis
		from Cedis
		where IdCedis not in ( 999 )
		order by Cedis, IdCedis
	end

	if @Tipo = 10 or @Tipo = 11
	begin

		exec ( 'Select MovimientosFacturas.IdCedis, Cedis, Ventas.IdCliente, RazonSocial, Ventas.Fecha as FechaFactura, case VentasTipo.Tipo when 1 then ''Factura de Crédito'' else ''Factura de Contado'' end as ''TipoVenta'', Ventas.Serie, Ventas.Folio, Ventas.Total, 
		MovimientosFacturas.IdMovimiento, MovimientosFacturas.IdDocumento + '' '' + MovimientosFacturas.IdTipoDocumento + '' - '' +  TipoDocumento as ''TipoDocumento'', MovimientosFacturas.Fecha,  MovimientosFacturas.Total as Pago
		from MovimientosFacturas
		inner join Ventas on Ventas.IdCedis = MovimientosFacturas.IdCedis and Ventas.IdTipoVenta = MovimientosFacturas.IdTipoVenta and 
			Ventas.Serie = MovimientosFacturas.Serie and Ventas.Folio = MovimientosFacturas.Folio and year(Ventas.Fecha) = year(''' +  @FechaInicial + ''')
		inner join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IdCliente = Ventas.IdCliente
		inner join VentasTipo on VentasTipo.IdTipoVenta = Ventas.IdTipoVenta
		inner join Cedis on Cedis.IdCedis = MovimientosFacturas.IdCedis
		inner join DocumentosTipo on MovimientosFacturas.IdDocumento = DocumentosTipo.IdDocumento and MovimientosFacturas.IdTipoDocumento = DocumentosTipo.IdTipoDocumento 
		where MovimientosFacturas.Fecha between ''' +  @FechaInicial + ''' and ''' +  @FechaFinal + ''' and MovimientosFacturas.Status <> ''B'' and MovimientosFacturas.CargoAbono = ''A'' and substring(MovimientosFacturas.IdDocumento, 1, 1) = ''P''  ' + @Filtro + '   
		order by MovimientosFacturas.IdCedis, Cedis, Ventas.IdCliente, MovimientosFacturas.IdMovimiento ')
	end
end

if @ReporteOrigen = 105			-- MERMAS Y OBSEQUIOS
begin
	If @Tipo = 1 			-- Cedis
	begin
		Select IdCedis, Cedis
		from Cedis
		where IdCedis not in ( 999 )
		order by Cedis, IdCedis
	end

	if @Tipo = 10 or @Tipo = 11
	begin
		exec ( ' select FN_MermasObsequios.IdCedis, Cedis, isnull( Cuenta, ''Cuenta no Definida'') as Entidad, IdProducto, Producto, MalaPiezas, MalaKgLts, ObsequiosPiezas, ObsequiosKgLts
		from [RouteADM].dbo.FN_MermasObsequios (''' + @FechaInicial + ''', ''' + @FechaFinal + ''') as FN_MermasObsequios
		left outer join CedisCuentas on FN_MermasObsequios.IdCedis = CedisCuentas.IdCedis
		where MalaPiezas > 0 and ObsequiosPiezas > 0  ' + @Filtro + '   
		order by FN_MermasObsequios.IdCedis, Cedis, cast( IdProducto as int ) ' )
	end
end

GO

