USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteU_PreciosListaRuta]    Script Date: 05/02/2011 12:46:35 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteU_PreciosListaRuta]'))
DROP TRIGGER [dbo].[tgRouteU_PreciosListaRuta]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteU_PreciosListaRuta]    Script Date: 05/02/2011 12:46:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgRouteU_PreciosListaRuta] ON [dbo].[PreciosListaRuta] 
FOR INSERT, UPDATE
AS
declare @Route as int, @IdCedis as bigint
set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )

if @Route = 1
begin

	set @IdCedis = ( select top 1 IdCedis from Inserted )
	
	update ClienteSucursal set NombreSucursal = NombreSucursal 
	where IdSucursal in ( select ClienteClave from ROUTE.dbo.Secuencia where RutClave in ( select replicate('0', 2 - len( IdCedis ) ) + cast( IdCedis as varchar(10) ) + '-' + cast( IdRuta as varchar(10) ) from Inserted where IdCedis = @IdCedis ) ) 
end

GO


