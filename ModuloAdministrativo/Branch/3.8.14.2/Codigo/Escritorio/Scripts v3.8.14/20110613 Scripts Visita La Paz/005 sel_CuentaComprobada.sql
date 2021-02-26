USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CuentaComprobada]    Script Date: 06/17/2011 15:08:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_CuentaComprobada]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_CuentaComprobada]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_CuentaComprobada]    Script Date: 06/17/2011 15:08:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sel_CuentaComprobada]
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Opc as int

AS

if @Opc = 1 
begin
	select 0 as Orden, 'Ventas de Contado' as Concepto, isnull(SUM(Total),0) as Total
	from Ventas 
	where IdCedis = @IdCedis and IdTipoVenta = 1
		and Fecha between @FechaInicial and @FechaFinal 

	union 

		select 1 as Orden, 'Cobranza' as Concepto, isnull(sum(t.Total),0) as Total
			from (
			select USU.Clave, ABN.ABNId, ABT.Importe as Total
			from Route.dbo.AbnTrp ABT
			inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
			left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
			inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
			inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
			inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
			inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
			inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
			where Dia.FechaCaptura between @FechaInicial and @FechaFinal 
			and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
			)as t

	union 

	select 2 as Orden, 'TOTAL' as Concepto, 

	isnull(( select SUM(Total) as Total
	from Ventas 
	where IdCedis = @IdCedis and IdTipoVenta = 1
		and Fecha between @FechaInicial and @FechaFinal  ),0)
	+
	isnull( (	select sum(t.Total) as Total
	from (
	select USU.Clave, ABN.ABNId, ABT.Importe as Total
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	where Dia.FechaCaptura between @FechaInicial and @FechaFinal 
	and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
	)as t ),0)

end

if @Opc = 2
begin

	select 0 as Orden, 'TOTAL VENTAS DE CONTADO' as Concepto, isnull(SUM(VEND.Cantidad * PreciosDetalle.Precio * (1+(Productos.Iva))),0) as Total
	from Ventas VEN
	inner join VentasDetalle VEND on VEN.IdCedis = VEND.IdCedis and VEN.IdTipoVenta = VEND.IdTipoVenta 
		and VEN.IdSurtido = VEND.IdSurtido and VEN.Folio = VEND.Folio 
	inner join Productos on Productos.IdProducto = VEND.IdProducto 
	inner join Marcas on Marcas.IdMarca = Productos.IdMarca 
	inner join PreciosDetalle on PreciosDetalle.IdProducto = VEND.IdProducto and IdLista in ( select IdLista 
		from PreciosLista where TipoLista = 'BA')
	where VEN.IdCedis = @IdCedis and Fecha between @FechaInicial and @FechaFinal and VEN.IdTipoVenta = 1

	union

	select 1 as Orden, 'COBRANZA A CLIENTES' as Concepto, isnull(sum(ABT.Importe),0) + isnull((select sum(MOVF.Total) 
		from RouteCPC.dbo.Movimientos MOV
		inner join RouteCPC.dbo.MovimientosFacturas MOVF on MOV.IdCedis = MOVF.IdCedis and MOV.IdMovimiento = MOVF.IdMovimiento 
			and MOVF.Status = 'A' 
		where MOV.IdCedis = @IdCedis and MOV.Fecha between @FechaInicial and @FechaFinal and MOV.Status = 'A' and MOV.CargoAbono = 'A'
			and MOV.IdDocumento in ('CT', 'PA')),0) as Total 
	from Route.dbo.AbnTrp ABT
	inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
	left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
	inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
	inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	where Dia.FechaCaptura between @FechaInicial and @FechaFinal  
	and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) -- and FAC.SubEmpresaId = @IdMarca

	union 

	select 2 as Orden, MOVF.IdDocumento + ' | ' + MOVF.IdTipoDocumento + ' - ' + DOCT.TipoDocumento as Concepto, isnull(sum(MOVF.Total),0) as Total
	from RouteCPC.dbo.Movimientos MOV
	inner join RouteCPC.dbo.MovimientosFacturas MOVF on MOV.IdCedis = MOVF.IdCedis and MOV.IdMovimiento = MOVF.IdMovimiento 
		and MOVF.Status = 'A' 
	inner join RouteCPC.dbo.DocumentosTipo DOCT on DOCT.IdDocumento = MOV.IdDocumento and DOCT.IdTipoDocumento = MOVF.IdTipoDocumento 
	where MOV.IdCedis = @IdCedis and MOV.Fecha between @FechaInicial and @FechaFinal and MOV.Status = 'A' and MOV.CargoAbono = 'A'
		and MOV.IdDocumento = 'NR'
	group by MOVF.IdDocumento, MOVF.IdTipoDocumento, DOCT.TipoDocumento 

	order by Orden 

end
GO


