USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SeriesCFD]    Script Date: 06/27/2011 17:39:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_SeriesCFD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_SeriesCFD]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SeriesCFD]    Script Date: 06/27/2011 17:39:00 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sel_SeriesCFD]
@IdCedis as bigint,
@IdRuta as bigint,
@SubEmpresaId as varchar(20),
@CFDCedis as bit,
@Opc as int
AS

if @Opc = 1
begin
	
	select FolS.Serie as SerieId, FolS.Serie, SubE.NombreEmpresa, SubE.SubEmpresaId as SubId, (FolS.Usados) + 1 as CFD
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10))
	
end

if @Opc = 2
begin
	select FolS.Serie as SerieId, FolS.Serie, SubE.NombreEmpresa, SubE.SubEmpresaId as SubId, (FolS.Usados) + 1 as CFD
	from Route.dbo.SubEmpresa SubE 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = 'CFDCed' + CAST(@IdCedis as varchar(10))
end


GO


