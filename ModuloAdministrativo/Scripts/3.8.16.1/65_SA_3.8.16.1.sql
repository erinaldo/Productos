USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ValidaDesc]    Script Date: 08/18/2011 09:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ValidaDesc]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ValidaDesc]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ValidaDesc]    Script Date: 08/18/2011 09:49:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sel_ValidaDesc]
@IdCedis as int,
@IdSurtido as int
AS
BEGIN

	SET NOCOUNT ON;
	
	--select IdCedis,IdSurtido,IdListaPrecioDesc
	--from Ventas where IdCedis = 1 and IdSurtido = 1 group by IdCedis,IdSurtido,IdListaPrecioDesc
	
	select IdCedis,IdSurtido,IdListaPrecioDesc,(select COUNT(*) as Reg from
	(select IdCedis,IdSurtido,IdListaPrecioDesc
	from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and idlistapreciodesc is null
	group by IdCedis,IdSurtido,IdListaPrecioDesc) as t)
	as Registros
	from Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido and idlistapreciodesc is null
	group by IdCedis,IdSurtido,IdListaPrecioDesc
	
END


GO

USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 65, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 65 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO
