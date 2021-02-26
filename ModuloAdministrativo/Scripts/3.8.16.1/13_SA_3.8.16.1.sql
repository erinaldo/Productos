USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_KardexDetalle]    Script Date: 07/27/2011 08:35:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_KardexDetalle]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_KardexDetalle]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_KardexDetalle]    Script Date: 07/27/2011 08:35:48 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE FUNCTION [dbo].[FN_KardexDetalle]
(
@IdCedis as bigint, 
@FechaInicial as datetime,
@FechaFinal as datetime
)  
RETURNS Table AS  
return
(
	SELECT     INVKAR.IdCedis, INVKAR.Fecha, PRO.IdMarca, PRO.IdGrupo, PRO.IdFamilia, PRO.IdProducto, 
			PRO.Producto, PRO.Conversion, INVKAR.Inicial, INVKAR.Entradas, INVKAR.Salidas, 
	                      	INVKAR.Surtido, INVKAR.DevBuena, INVKAR.DevMala, INVKAR.Obsequios, INVKAR.VentaContado AS Contado, 
	                      	INVKAR.VentaCredito AS Credito, INVKAR.Consignacion, INVKAR.Recuperacion, 
	                      	ISNULL(INVKAR.Teorico, 0) AS Teorico, ISNULL(INVKAR.Fisico, 0) AS Fisico, 
			ISNULL(INVKAR.Fisico, 0) - ISNULL(INVKAR.Teorico, 0) AS Diferencia, ISNULL(PREDET.Precio, 0) AS PrecioActual
	FROM         PreciosListaCedis PRELISCED INNER JOIN
	                      InventarioKardex INVKAR ON PRELISCED.IdCedis = INVKAR.IdCedis RIGHT OUTER JOIN
	                      Productos PRO ON INVKAR.IdProducto = PRO.IdProducto RIGHT OUTER JOIN
	                      PreciosLista PRELIS INNER JOIN
	                      PreciosDetalle PREDET ON PRELIS.IdLista = PREDET.IdLista ON PRELISCED.IdLista = PREDET.IdLista AND 
	                      INVKAR.IdProducto = PREDET.IdProducto AND PRELIS.TipoLista = 'BA'
	WHERE     (INVKAR.IdCedis = @IdCedis) AND (INVKAR.Fecha between @FechaInicial and @FechaFinal)
)







GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 13, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 13 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO