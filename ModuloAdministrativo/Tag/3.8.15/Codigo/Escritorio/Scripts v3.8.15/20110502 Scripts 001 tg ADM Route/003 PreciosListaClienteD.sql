USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteD_PreciosListaCliente]    Script Date: 05/02/2011 12:44:43 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteD_PreciosListaCliente]'))
DROP TRIGGER [dbo].[tgRouteD_PreciosListaCliente]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteD_PreciosListaCliente]    Script Date: 05/02/2011 12:44:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgRouteD_PreciosListaCliente] ON [dbo].[PreciosListaCliente] 
FOR DELETE
AS
declare @Route as int, @IdCedis as bigint
set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Deleted ) ), 0 )

if @Route = 1
begin

	set @IdCedis = ( select top 1 IdCedis from Deleted )
	
	delete from ROUTE.dbo.ClienteEsquema where ClienteClave in ( select IdSucursal from ClienteSucursal where IdCedis = @IdCedis and IdCliente in ( select IdCliente from Deleted ) )
		and EsquemaId in ( select IdLista from Deleted ) and EsquemaId in ( select EsquemaId from ROUTE.dbo.PrecioClienteEsquema ) and isnumeric(EsquemaId)=1

end

GO


