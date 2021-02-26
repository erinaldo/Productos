USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_DiasCerrados]    Script Date: 06/16/2011 13:24:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_DiasCerrados]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_DiasCerrados]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_DiasCerrados]    Script Date: 06/16/2011 13:24:32 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_DiasCerrados] 
@IdCedis as bigint,
@Opc as int
AS

if @Opc = 1 -- Por Cedis y Fechas
	select distinct SD.StatusDesc, SD.Fecha
	from RouteADM.dbo.StatusDia SD 
	where SD.IdCedis = 1 and SD.Fecha not in ( select Fecha from Movimientos 
	where IdDocumento = 'CT' and Status in ('A', 'P') and Fecha = SD.Fecha )
	and Status = 'C' and SD.Fecha > '20110531' and SD.Fecha in (
		select distinct Dia.FechaCaptura 
		from Route.dbo.AbnTrp ABT
		inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
		inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
		inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
		inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
		inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
		inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
		where Dia.FechaCaptura = SD.Fecha and FAC.Tipo = 8 and FAC.TipoFase <> 0 and (FAC.CFVTipo = 2 or FAC.CFVTipo is null
			and USU.Clave <> '10000' ) 
		)
	order by SD.Fecha desc
	
	--select distinct SD.StatusDesc, SD.Fecha
	--from RouteADM.dbo.StatusDia SD 
	--where SD.IdCedis = @IdCedis and SD.Fecha not in ( select Fecha from Movimientos 
	--where IdDocumento = 'CT' and Status = 'A' and Fecha = SD.Fecha )
	--	and Status = 'C'
	--order by SD.Fecha desc

GO


