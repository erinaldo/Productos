USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteU_PreciosListaCliente]    Script Date: 05/02/2011 12:44:48 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteU_PreciosListaCliente]'))
DROP TRIGGER [dbo].[tgRouteU_PreciosListaCliente]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteU_PreciosListaCliente]    Script Date: 05/02/2011 12:44:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE TRIGGER [dbo].[tgRouteU_PreciosListaCliente] ON [dbo].[PreciosListaCliente] 
FOR INSERT, UPDATE
AS
declare @Route as int, @IdCedis as bigint
set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )

if @Route = 1
begin

	set @IdCedis = ( select top 1 IdCedis from Inserted )

	delete 
	from ROUTE.dbo.ClienteEsquema where ClienteClave in ( select IdSucursal from ClienteSucursal where IdCedis = @IdCedis and IdCliente in ( select IdCliente from Inserted ) )
			and EsquemaId in ( select IdLista from Inserted ) and EsquemaId in ( select EsquemaId from ROUTE.dbo.ClienteEsquema ) and isnumeric(EsquemaId)=1

	insert into ROUTE.dbo.ClienteEsquema 
	Select IdSucursal, isnull( Inserted.IdLista, ( select IdLista from PreciosLista where TipoLista = 'BA' and IdLista in ( select IdLista from PreciosListaCedis where IdCedis = @IdCedis ) ) ), 1, getdate(), 'Interfaz' 
	from Inserted
	inner join ClienteSucursal on Inserted.IdCedis = ClienteSucursal.IdCedis and Inserted.IdCliente = ClienteSucursal.IdCliente 
	left outer join PreciosListaCliente on ClienteSucursal.IdCedis = PreciosListaCliente.IdCedis and ClienteSucursal.IdCliente = PreciosListaCliente.IdCliente 
	where Inserted.IdCedis = @IdCedis 

end

GO


