
USE [RouteADM] 
GO

Update GReportesNivel set Descripcion = 'Semanal' where IdReporte = 3 and IdSubReporte = 1 
Delete from GReportesNivel where IdReporte = 3 and IdSubReporte = 2 

USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 68, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 68 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO