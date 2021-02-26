USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Rutas]    Script Date: 08/02/2011 11:19:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasTransprod]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasTransprod]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasTransprod]    Script Date: 08/02/2011 11:19:15 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sel_VentasTransprod]
@IdCedis as bigint, @IdSurtido as bigint, @IdTipoVenta as int, @Serie as varchar(5), @Folio as bigint
AS

	SELECT TransProdId 
	FROM VentasTransProd 
	WHERE IdCedis = @IdCedis AND IdSurtido = @IdSurtido AND IdTipoVenta = @IdTipoVenta AND Serie = @Serie AND Folio = @Folio 

GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 46, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 46 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO