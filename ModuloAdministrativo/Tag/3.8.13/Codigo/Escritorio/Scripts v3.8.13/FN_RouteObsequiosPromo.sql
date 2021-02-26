USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_RouteObsequiosPromo]    Script Date: 10/11/2010 13:27:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_RouteObsequiosPromo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_RouteObsequiosPromo]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_RouteObsequiosPromo]    Script Date: 10/11/2010 13:27:18 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[FN_RouteObsequiosPromo]
(
	@FechaInicial as datetime,
	@FechaFinal as Datetime
)  
RETURNS Table 

AS  

	Return
	(
	select left(USU.Clave, len(USU.Clave)-4) as IdCedis, Dia.FechaCaptura as Fecha, TRP.ClienteClave, TRPDET.ProductoClave, sum(TRPDET.Cantidad) as Cantidad
	from Route.dbo.TransProd TRP 
	inner join Route.dbo.Dia Dia on TRP.DiaClave = Dia.DiaClave
	inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave
	inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
	inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
	inner join Route.dbo.TransProdDetalle TRPDET on TRPDET.TransProdID = TRP.TransProdID 
		and TRPDET.Total = 0 
	where Dia.FechaCaptura between @FechaInicial and @FechaFinal
	and TRP.TipoFase <> 0 and TRP.Tipo = 1	
	group by USU.Clave, Dia.FechaCaptura, TRP.ClienteClave, TRPDET.ProductoClave
	)


GO


