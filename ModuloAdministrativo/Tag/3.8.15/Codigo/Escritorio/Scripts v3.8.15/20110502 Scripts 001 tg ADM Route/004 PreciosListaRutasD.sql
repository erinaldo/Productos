USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteD_PreciosListaRuta]    Script Date: 05/02/2011 12:46:03 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteD_PreciosListaRuta]'))
DROP TRIGGER [dbo].[tgRouteD_PreciosListaRuta]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteD_PreciosListaRuta]    Script Date: 05/02/2011 12:46:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgRouteD_PreciosListaRuta] ON [dbo].[PreciosListaRuta] 
FOR DELETE
AS
declare @Route as int, @IdCedis as bigint
set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Deleted ) ), 0 )

if @Route = 1
begin

	set @IdCedis = ( select top 1 IdCedis from Deleted )
	
	update ClienteSucursal set NombreSucursal = NombreSucursal 
	where IdSucursal in ( select ClienteClave from ROUTE.dbo.Secuencia where RutClave in ( select replicate('0', 2 - len( IdCedis ) ) + cast( IdCedis as varchar(10) ) + '-' + cast( IdRuta as varchar(10) ) from Deleted where IdCedis = @IdCedis ) ) 
end

GO


