
IF (SELECT COUNT(*) FROM SysColumns WHERE Name = 'SubEmpresaId' AND Id = (SELECT Id FROM SysObjects WHERE Name = 'CentroExpedicion')) = 0
begin

ALTER TABLE dbo.CentroExpedicion
	DROP CONSTRAINT FK_CentroExpedicion_CertificadoFolio

CREATE TABLE dbo.Tmp_CentroExpedicion_1
	(
	CentroExpID varchar(16) NOT NULL,
	CentroExpPadreID varchar(16) NULL,
	Nombre varchar(60) NOT NULL,
	Tipo smallint NOT NULL,
	SubEmpresaId varchar(16) NOT NULL,
	NumCertificado varchar(20) NULL,
	RFC varchar(13) NULL,
	Calle varchar(64) NOT NULL,
	NumExt varchar(16) NULL,
	NumInt varchar(16) NULL,
	Colonia varchar(64) NULL,
	CodigoPostal varchar(16) NOT NULL,
	ReferenciaDom varchar(100) NULL,
	Localidad varchar(40) NULL,
	Municipio varchar(40) NOT NULL,
	Entidad varchar(40) NOT NULL,
	Pais varchar(40) NOT NULL,
	TipoEstado smallint NULL,
	MFechaHora datetime NOT NULL,
	MUsuarioID varchar(40) NOT NULL
	)  ON [PRIMARY]

IF EXISTS(SELECT * FROM dbo.CentroExpedicion)
	 EXEC('INSERT INTO dbo.Tmp_CentroExpedicion_1 (CentroExpID, CentroExpPadreID, Nombre, Tipo,SubEmpresaId, NumCertificado, RFC, Calle, NumExt, NumInt, Colonia, CodigoPostal, ReferenciaDom, Localidad, Municipio, Entidad, Pais, TipoEstado, MFechaHora, MUsuarioID)
		SELECT CentroExpID, CentroExpPadreID, Nombre, Tipo,(select top 1 SubEmpresaId from SubEmpresa), NumCertificado, RFC, Calle, NumExt, NumInt, Colonia, CodigoPostal, ReferenciaDom, Localidad, Municipio, Entidad, Pais, TipoEstado, MFechaHora, MUsuarioID FROM dbo.CentroExpedicion (HOLDLOCK TABLOCKX)')

ALTER TABLE dbo.CentroExpedicion
	DROP CONSTRAINT FK_CentroExpedicion_CentroExpedicion

DROP TABLE dbo.CentroExpedicion

EXECUTE sp_rename N'dbo.Tmp_CentroExpedicion_1', N'CentroExpedicion', 'OBJECT'

ALTER TABLE dbo.CentroExpedicion ADD CONSTRAINT
	PK_CentroExpedicion PRIMARY KEY CLUSTERED 
	(
	CentroExpID
	) ON [PRIMARY]


ALTER TABLE dbo.CentroExpedicion WITH NOCHECK ADD CONSTRAINT
	FK_CentroExpedicion_CentroExpedicion FOREIGN KEY
	(
	CentroExpPadreID
	) REFERENCES dbo.CentroExpedicion
	(
	CentroExpID
	)

ALTER TABLE dbo.CentroExpedicion WITH NOCHECK ADD CONSTRAINT
	FK_CentroExpedicion_CertificadoFolio FOREIGN KEY
	(
	NumCertificado
	) REFERENCES dbo.CertificadoFolio
	(
	NumCertificado
	)

ALTER TABLE dbo.CentroExpedicion WITH NOCHECK ADD CONSTRAINT
	FK_CentroExpedicion_SubEmpresa FOREIGN KEY
	(
	SubEmpresaId
	) REFERENCES dbo.SubEmpresa
	(
	SubEmpresaId
	)

end