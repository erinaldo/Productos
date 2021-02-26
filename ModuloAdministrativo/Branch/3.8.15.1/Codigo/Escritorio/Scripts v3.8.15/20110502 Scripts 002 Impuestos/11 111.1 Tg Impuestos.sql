USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteU_TipoImpuesto]    Script Date: 05/02/2011 12:44:09 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteU_TipoImpuesto]'))
DROP TRIGGER [dbo].[tgRouteU_TipoImpuesto]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteU_TipoImpuesto]    Script Date: 05/02/2011 12:44:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE TRIGGER [dbo].[tgRouteU_TipoImpuesto] ON [dbo].[TipoImpuesto] 
FOR INSERT, UPDATE
AS
declare @Route as int
set @Route = isnull( (select top 1 Route from Configuracion ), 0 )

if @Route = 1
begin

	update ROUTE.dbo.Impuesto set Nombre = Inserted.Descripcion, TipoAplicacion = Inserted.TipoAplicacion,
		Jerarquia = Inserted.Jerarquia, Abreviatura = Inserted.TipoImpuesto
	from Inserted, ROUTE.dbo.Impuesto Impuesto 
	where cast(Inserted.IdTipoImpuesto as varchar(10)) = Impuesto.ImpuestoClave
	
	insert into ROUTE.dbo.Impuesto
	select IdTipoImpuesto, Descripcion, TipoImpuesto, TipoAplicacion, Jerarquia, 1, 1, 0, getdate(), 'Interfaz'
	from Inserted
	where IdTipoImpuesto not in (select ImpuestoClave from ROUTE.dbo.Impuesto )
	
	declare @UsuId as varchar(20)
	select @UsuId = Clave from Route.dbo.Usuario where Clave = 'Super'
	
	insert into ROUTE.dbo.tmp_ImpuestoVig
	select IdTipoImpuesto, getdate(), TipoAplicacion, Tasa * 100, getdate(), @UsuId
	from Inserted
	
end




GO


