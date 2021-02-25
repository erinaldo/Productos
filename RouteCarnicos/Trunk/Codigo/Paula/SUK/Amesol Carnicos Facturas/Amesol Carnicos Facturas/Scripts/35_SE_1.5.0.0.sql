IF (SELECT COUNT(*) FROM SysColumns WHERE Name = 'ImpuestoPU' AND Id = (SELECT Id FROM SysObjects WHERE Name = 'TPDImpuesto')) = 0
BEGIN
	ALTER TABLE dbo.TPDImpuesto
		DROP CONSTRAINT FK_TPDImpuesto_TransProdDetalle
	ALTER TABLE dbo.TPDImpuesto
		DROP CONSTRAINT FK_TPDImpuesto_Impuesto
	CREATE TABLE dbo.Tmp_TPDImpuesto
		(
		TransProdID varchar(16) NOT NULL,
		TransProdDetalleID varchar(16) NOT NULL,
		TPDImpuestoID varchar(16) NOT NULL,
		ImpuestoClave varchar(10) NOT NULL,
		ImpuestoPor float(53) NOT NULL,
		ImpuestoImp float(53) NOT NULL,
		ImpuestoPU float(53) NULL,
		ImpDesGlb float(53) NULL,
		MFechaHora datetime NOT NULL,
		MUsuarioID varchar(16) NOT NULL
		)  ON [PRIMARY]
	IF EXISTS(SELECT * FROM dbo.TPDImpuesto)
		 EXEC('INSERT INTO dbo.Tmp_TPDImpuesto (TransProdID, TransProdDetalleID, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, MFechaHora, MUsuarioID)
			SELECT TransProdID, TransProdDetalleID, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, MFechaHora, MUsuarioID FROM dbo.TPDImpuesto WITH (HOLDLOCK TABLOCKX)')
	DROP TABLE dbo.TPDImpuesto
	EXECUTE sp_rename N'dbo.Tmp_TPDImpuesto', N'TPDImpuesto', 'OBJECT' 
	ALTER TABLE dbo.TPDImpuesto ADD CONSTRAINT
		PK_TPDImpuesto PRIMARY KEY CLUSTERED 
		(
		TransProdID,
		TransProdDetalleID,
		TPDImpuestoID
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.TPDImpuesto WITH NOCHECK ADD CONSTRAINT
		FK_TPDImpuesto_Impuesto FOREIGN KEY
		(
		ImpuestoClave
		) REFERENCES dbo.Impuesto
		(
		ImpuestoClave
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 

	ALTER TABLE dbo.TPDImpuesto WITH NOCHECK ADD CONSTRAINT
		FK_TPDImpuesto_TransProdDetalle FOREIGN KEY
		(
		TransProdID,
		TransProdDetalleID
		) REFERENCES dbo.TransProdDetalle
		(
		TransProdID,
		TransProdDetalleID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 		
END