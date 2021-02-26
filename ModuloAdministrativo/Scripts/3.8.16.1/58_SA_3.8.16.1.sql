USE [RouteADM] 

IF (SELECT COUNT(*) FROM syscolumns WHERE (NAME = 'FechaPrev' OR name = 'RutaPrev') AND ID =(SELECT ID FROM sysobjects WHERE NAME ='Ventas' )) =  0
BEGIN
	ALTER TABLE dbo.Ventas ADD
		FechaPrev datetime NULL,
		RutaPrev bigint NULL

	ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
END
GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 58, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 58 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO