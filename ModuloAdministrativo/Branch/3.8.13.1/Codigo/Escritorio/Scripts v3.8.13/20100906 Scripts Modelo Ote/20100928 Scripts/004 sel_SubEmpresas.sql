USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SubEmpresas]    Script Date: 09/06/2010 09:46:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_SubEmpresas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_SubEmpresas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_SubEmpresas]    Script Date: 09/06/2010 09:46:54 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_SubEmpresas]
@IdCedis as bigint
AS

declare @Route as int
set @Route = isnull( ( select Route from Configuracion where IdCedis = @IdCedis ), 0 )

if @Route = 1 
begin
	select 1 as Num
	--select COUNT(SubEmpresaId) as Num
	--from Route.dbo.SubEmpresa 
end
else
begin
	select 0 as Num
end


GO

