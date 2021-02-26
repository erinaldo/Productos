/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
USE RouteADM


IF (SELECT COUNT(*) FROM syscolumns WHERE (NAME ='Consignacion' OR NAME ='Recuperacion') AND ID =(SELECT ID FROM sysobjects WHERE NAME ='SurtidosDetalle' ))=0
BEGIN
	BEGIN TRANSACTION
	CREATE TABLE dbo.Tmp_SurtidosDetalle
		(
		IdCedis bigint NOT NULL,
		IdSurtido bigint NOT NULL,
		IdProducto char(10) COLLATE Traditional_Spanish_CI_AS NOT NULL,
		Fecha datetime NOT NULL,
		Surtido decimal(19, 4) NULL,
		DevBuena decimal(19, 4) NULL,
		DevMala decimal(19, 4) NULL,
		Obsequios decimal(19, 4) NULL,
		VentaContado decimal(19, 4) NULL,
		VentaCredito decimal(19, 4) NULL,
		Consignacion decimal(19, 4) NULL,
		Recuperacion decimal(19, 4) NULL,
		Precio money NULL,
		Iva float(53) NULL,
		SubTotal  AS ([Surtido] * [Precio]),
		Total  AS ([Surtido] * ([Precio] * (1 + [Iva])))
		)  ON [PRIMARY]

	ALTER TABLE dbo.Tmp_SurtidosDetalle SET (LOCK_ESCALATION = TABLE)

	IF EXISTS(SELECT * FROM dbo.SurtidosDetalle)
		 EXEC('INSERT INTO dbo.Tmp_SurtidosDetalle (IdCedis, IdSurtido, IdProducto, Fecha, Surtido, DevBuena, DevMala, Obsequios, VentaContado, VentaCredito, Consignacion, Recuperacion, Precio, Iva)
			SELECT IdCedis, IdSurtido, IdProducto, Fecha, Surtido, DevBuena, DevMala, Obsequios, VentaContado, VentaCredito, 0, 0, Precio, Iva FROM dbo.SurtidosDetalle WITH (HOLDLOCK TABLOCKX)')

	DROP TABLE dbo.SurtidosDetalle

	EXECUTE sp_rename N'dbo.Tmp_SurtidosDetalle', N'SurtidosDetalle', 'OBJECT' 

	ALTER TABLE dbo.SurtidosDetalle ADD CONSTRAINT
		PK_DSurtidos PRIMARY KEY CLUSTERED 
		(
		IdCedis,
		IdSurtido,
		IdProducto,
		Fecha
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	COMMIT
END

GO

USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 4, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 4 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO