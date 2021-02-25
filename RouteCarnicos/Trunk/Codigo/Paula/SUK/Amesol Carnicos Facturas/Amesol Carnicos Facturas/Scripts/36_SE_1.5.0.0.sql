IF (SELECT COUNT(*) FROM SysColumns WHERE Name = 'TipoNotaCredito' AND Id = (SELECT Id FROM SysObjects WHERE Name = 'TRPDatoFiscal')) = 0
BEGIN
	ALTER TABLE dbo.TRPDatoFiscal
		DROP CONSTRAINT FK_TRPDatoFiscal_TransProd
	CREATE TABLE dbo.Tmp_TRPDatoFiscal
		(
		TransProdID varchar(16) NOT NULL,
		FolioId varchar(16) NOT NULL,
		FOSId varchar(16) NOT NULL,
		NumCertificado varchar(20) NOT NULL,
		Serie varchar(10) NULL,
		Aprobacion int NOT NULL,
		AnioAprobacion int NOT NULL,
		RazonSocial varchar(128) NOT NULL,
		RFC varchar(64) NULL,
		TelefonoContacto varchar(64) NULL,
		Calle varchar(64) NOT NULL,
		NumExt varchar(16) NULL,
		NumInt varchar(16) NULL,
		Colonia varchar(64) NULL,
		CodigoPostal varchar(16) NULL,
		ReferenciaDom varchar(100) NULL,
		Localidad varchar(40) NULL,
		Municipio varchar(64) NULL,
		Entidad varchar(32) NULL,
		Pais varchar(32) NOT NULL,
		CadenaOriginal text NOT NULL,
		SelloDigital text NOT NULL,
		LogotipoEm image NULL,
		TelefonoEm varchar(32) NOT NULL,
		RFCEm varchar(64) NOT NULL,
		NombreEm varchar(64) NOT NULL,
		CalleEm varchar(64) NOT NULL,
		NumExtEm varchar(16) NULL,
		NumIntEm varchar(16) NULL,
		ColoniaEm varchar(64) NULL,
		LocalidadEm varchar(40) NULL,
		ReferenciaDomEm varchar(100) NULL,
		MunicipioEm varchar(40) NULL,
		RegionEm varchar(40) NULL,
		PaisEm varchar(40) NOT NULL,
		CodigoPostalEm varchar(16) NULL,
		CalleEx varchar(64) NOT NULL,
		NumExtEx varchar(16) NULL,
		NumIntEx varchar(16) NULL,
		ColoniaEx varchar(64) NULL,
		CodigoPostalEx varchar(16) NULL,
		ReferenciaDomEx varchar(100) NULL,
		LocalidadEx varchar(40) NULL,
		MunicipioEx varchar(40) NULL,
		EntidadEx varchar(40) NULL,
		PaisEx varchar(40) NOT NULL,
		TipoVersion varchar(8) NOT NULL,
		TipoNotaCredito smallint NULL,
		MetodoPago varchar(300) NULL,
		MFechaHora datetime NOT NULL,
		MUsuarioID varchar(50) NOT NULL
		)  ON [PRIMARY]
		 TEXTIMAGE_ON [PRIMARY]
	IF EXISTS(SELECT * FROM dbo.TRPDatoFiscal)
		 EXEC('INSERT INTO dbo.Tmp_TRPDatoFiscal (TransProdID, FolioId, FOSId, NumCertificado, Serie, Aprobacion, AnioAprobacion, RazonSocial, RFC, TelefonoContacto, Calle, NumExt, NumInt, Colonia, CodigoPostal, ReferenciaDom, Localidad, Municipio, Entidad, Pais, CadenaOriginal, SelloDigital, LogotipoEm, TelefonoEm, RFCEm, NombreEm, CalleEm, NumExtEm, NumIntEm, ColoniaEm, LocalidadEm, ReferenciaDomEm, MunicipioEm, RegionEm, PaisEm, CodigoPostalEm, CalleEx, NumExtEx, NumIntEx, ColoniaEx, CodigoPostalEx, ReferenciaDomEx, LocalidadEx, MunicipioEx, EntidadEx, PaisEx, TipoVersion, MFechaHora, MUsuarioID)
			SELECT TransProdID, FolioId, FOSId, NumCertificado, Serie, Aprobacion, AnioAprobacion, RazonSocial, RFC, TelefonoContacto, Calle, NumExt, NumInt, Colonia, CodigoPostal, ReferenciaDom, Localidad, Municipio, Entidad, Pais, CadenaOriginal, SelloDigital, LogotipoEm, TelefonoEm, RFCEm, NombreEm, CalleEm, NumExtEm, NumIntEm, ColoniaEm, LocalidadEm, ReferenciaDomEm, MunicipioEm, RegionEm, PaisEm, CodigoPostalEm, CalleEx, NumExtEx, NumIntEx, ColoniaEx, CodigoPostalEx, ReferenciaDomEx, LocalidadEx, MunicipioEx, EntidadEx, PaisEx, TipoVersion, MFechaHora, MUsuarioID FROM dbo.TRPDatoFiscal WITH (HOLDLOCK TABLOCKX)')
	DROP TABLE dbo.TRPDatoFiscal
	EXECUTE sp_rename N'dbo.Tmp_TRPDatoFiscal', N'TRPDatoFiscal', 'OBJECT' 
	ALTER TABLE dbo.TRPDatoFiscal ADD CONSTRAINT
		PK_TRPDatoFiscal PRIMARY KEY CLUSTERED 
		(
		TransProdID
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

	ALTER TABLE dbo.TRPDatoFiscal ADD CONSTRAINT
		FK_TRPDatoFiscal_TransProd FOREIGN KEY
		(
		TransProdID
		) REFERENCES dbo.TransProd
		(
		TransProdID
		) ON UPDATE  NO ACTION 
		 ON DELETE  NO ACTION 
		
END
/*go*/go

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tg_TRPDatoFiscal]'))
DROP TRIGGER [dbo].[tg_TRPDatoFiscal]
/*go*/go

	create trigger dbo.tg_TRPDatoFiscal
	on dbo.TRPDatoFiscal for insert
	as

		declare @TransProdId varchar(16)
		select @TransProdId = TransProdId from Inserted
		
		update [dbo].[TRPDatoFiscal] set LogotipoEm = CON.Logotipo 
					from Configuracion CON
					where TransProdId = @TransProdId
					
/*go*/go