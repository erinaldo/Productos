USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_RouteObsequiosCambios]    Script Date: 10/11/2010 13:27:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_RouteObsequiosCambios]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_RouteObsequiosCambios]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_RouteObsequiosCambios]    Script Date: 10/11/2010 13:27:18 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[FN_RouteObsequiosCambios]
(
	@FechaInicial as datetime,
	@FechaFinal as Datetime
)  
RETURNS Table 

AS  

	Return
	(
	select left(USU.Clave, len(USU.Clave)-4) as IdCedis, Dia.FechaCaptura as Fecha, VIS.ClienteClave, TRPDET.ProductoClave, sum(TRPDET.Cantidad) as Cantidad
	from Route.dbo.TransProd TRP 
	inner join Route.dbo.Dia Dia on TRP.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.TransProdDetalle TRPDET on TRPDET.TransProdID = TRP.TransProdID 
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	where Dia.FechaCaptura between @FechaInicial and @FechaFinal 
	and TRP.TipoFase <> 0 and TRP.Tipo = 9 and TRP.TipoMovimiento = 2
	group by USU.Clave, Dia.FechaCaptura, VIS.ClienteClave, TRPDET.ProductoClave
	)


GO


