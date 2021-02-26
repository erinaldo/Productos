USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_KdxFecha]    Script Date: 07/27/2011 10:42:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_KdxFecha]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_KdxFecha]
GO

USE [RouteADM]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_KdxFecha]    Script Date: 07/27/2011 10:42:56 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE FUNCTION [dbo].[FN_KdxFecha]
(
@IdCedis as bigint, 
@Fecha as datetime
)  
RETURNS Table AS  
return
(
	select surtidosdetalle.idcedis,  surtidosdetalle.fecha, surtidosdetalle.idproducto, 
	isnull( sum(surtido), 0) as Surtido, isnull( sum(DevBuena), 0) as DevBuena, isnull( sum(DevMala), 0) as DevMala, isnull( sum(Obsequios), 0) as Obsequios,
	isnull( sum(VentaContado), 0) as VentaContado, isnull( sum(VentaCredito), 0) as VentaCredito,
	isnull( sum(Consignacion), 0) as Consignacion, isnull( sum(Recuperacion), 0) as Recuperacion 
	from surtidosdetalle 
	where surtidosdetalle.idcedis = @IdCedis and surtidosdetalle.fecha = @Fecha
	group by surtidosdetalle.idcedis,  surtidosdetalle.fecha, surtidosdetalle.idproducto

)






GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 15, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 15 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO