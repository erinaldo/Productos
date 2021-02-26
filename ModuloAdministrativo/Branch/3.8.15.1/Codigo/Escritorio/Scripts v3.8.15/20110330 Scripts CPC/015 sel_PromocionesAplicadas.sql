USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_PromocionesAplicadas]    Script Date: 03/31/2011 14:55:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_PromocionesAplicadas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_PromocionesAplicadas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_PromocionesAplicadas]    Script Date: 03/31/2011 14:55:57 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_PromocionesAplicadas] 
@Opc as int
AS

if @Opc = 1
	select '', IdAplicacion, IdPromocion as IdAcuerdo, FechaInicial, FechaFinal, Login, Fecha, case Status when 'A' then 'Aplicado' when 'C' then 'Cancelado' when 'E' then 'Cancelación Parcial' else 'Pendiente' end as Status
	from PromocionesAplicadas
	order by FechaFinal desc, IdAplicacion desc, IdPromocion desc


GO


