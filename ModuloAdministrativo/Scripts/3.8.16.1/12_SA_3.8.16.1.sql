/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
USE RouteADM


IF (SELECT COUNT(*) FROM syscolumns WHERE (NAME ='Consignacion' OR NAME ='Recuperacion') AND ID =(SELECT ID FROM sysobjects WHERE NAME ='InventarioKardex' ))=0
BEGIN
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_InventarioKardex
		(
		IdCedis bigint NOT NULL,
		Fecha datetime NOT NULL,
		IdProducto bigint NOT NULL,
		Inicial decimal(19, 4) NULL,
		Entradas decimal(19, 4) NULL,
		Salidas decimal(19, 4) NULL,
		Surtido decimal(19, 4) NULL,
		DevBuena decimal(19, 4) NULL,
		DevMala decimal(19, 4) NULL,
		Obsequios decimal(19, 4) NULL,
		VentaContado decimal(19, 4) NULL,
		VentaCredito decimal(19, 4) NULL,
		Consignacion decimal(19, 4) NULL,
		Recuperacion decimal(19, 4) NULL,
		Teorico  AS ((((([Inicial]+[Entradas])-[Salidas])-[Obsequios])-[VentaContado])-[VentaCredito]),
		Fisico decimal(19, 4) NULL
		)  ON [PRIMARY]
		
	ALTER TABLE dbo.Tmp_InventarioKardex SET (LOCK_ESCALATION = TABLE)

	IF EXISTS(SELECT * FROM dbo.InventarioKardex)
		 EXEC('INSERT INTO dbo.Tmp_InventarioKardex (IdCedis, Fecha, IdProducto, Inicial, Entradas, Salidas, Surtido, DevBuena, DevMala, Obsequios, VentaContado, VentaCredito, Consignacion, Recuperacion, Fisico)
			SELECT IdCedis, Fecha, IdProducto, Inicial, Entradas, Salidas, Surtido, DevBuena, DevMala, Obsequios, VentaContado, VentaCredito, 0, 0, Fisico FROM dbo.InventarioKardex WITH (HOLDLOCK TABLOCKX)')

	DROP TABLE dbo.InventarioKardex

	EXECUTE sp_rename N'dbo.Tmp_InventarioKardex', N'InventarioKardex', 'OBJECT' 

	ALTER TABLE dbo.InventarioKardex ADD CONSTRAINT
		PK_InventarioKardex PRIMARY KEY CLUSTERED 
		(
		IdCedis,
		Fecha,
		IdProducto
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	COMMIT
END
GO


USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 12, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 12 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO