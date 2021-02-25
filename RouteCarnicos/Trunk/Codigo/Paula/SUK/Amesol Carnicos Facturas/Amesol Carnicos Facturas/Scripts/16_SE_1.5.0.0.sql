IF (SELECT COUNT(*) FROM SysColumns WHERE Name = 'SubEmpresaId' AND Id = (SELECT Id FROM SysObjects WHERE Name = 'Folio')) = 0
begin

ALTER TABLE dbo.Folio
	DROP CONSTRAINT FK_Folio_ModuloMovDetalle
 
CREATE TABLE dbo.Tmp_Folio_1
	(
	FolioID varchar(16) NOT NULL,
	ModuloMovDetalleClave varchar(16) NULL,
	Descripcion varchar(64) NOT NULL,
	ValorInicial varchar(16) NOT NULL,
	TipoEstado smallint NOT NULL,
	Fiscal bit NOT NULL,
	SubEmpresaId varchar(16) NULL,
	MFechaHora datetime NOT NULL,
	MUsuarioID varchar(16) NOT NULL
	)  ON [PRIMARY]
 
IF EXISTS(SELECT * FROM dbo.Folio)
	 EXEC('INSERT INTO dbo.Tmp_Folio_1 (FolioID, ModuloMovDetalleClave, Descripcion, ValorInicial, TipoEstado, Fiscal, MFechaHora, MUsuarioID)
		SELECT FolioID, ModuloMovDetalleClave, Descripcion, ValorInicial, TipoEstado, Fiscal, MFechaHora, MUsuarioID FROM dbo.Folio TABLOCKX')
 
ALTER TABLE dbo.FolioSolicitado
	DROP CONSTRAINT FK_FolioSolicitado_Folio
 
ALTER TABLE dbo.FolioDetalle
	DROP CONSTRAINT FK_FolioDetalle_Folio
 
ALTER TABLE dbo.FolioUsuario
	DROP CONSTRAINT FK_FolioUsuario_Folio
 
DROP TABLE dbo.Folio
 
EXECUTE sp_rename N'dbo.Tmp_Folio_1', N'Folio', 'OBJECT'
 
ALTER TABLE dbo.Folio ADD CONSTRAINT
	PK_Folio PRIMARY KEY CLUSTERED 
	(
	FolioID
	) ON [PRIMARY]

 
ALTER TABLE dbo.Folio WITH NOCHECK ADD CONSTRAINT
	FK_Folio_ModuloMovDetalle FOREIGN KEY
	(
	ModuloMovDetalleClave
	) REFERENCES dbo.ModuloMovDetalle
	(
	ModuloMovDetalleClave
	)
 
 
ALTER TABLE dbo.FolioUsuario WITH NOCHECK ADD CONSTRAINT
	FK_FolioUsuario_Folio FOREIGN KEY
	(
	FolioID
	) REFERENCES dbo.Folio
	(
	FolioID
	)
 
 
ALTER TABLE dbo.FolioDetalle WITH NOCHECK ADD CONSTRAINT
	FK_FolioDetalle_Folio FOREIGN KEY
	(
	FolioID
	) REFERENCES dbo.Folio
	(
	FolioID
	)
 
 
ALTER TABLE dbo.FolioSolicitado WITH NOCHECK ADD CONSTRAINT
	FK_FolioSolicitado_Folio FOREIGN KEY
	(
	FolioID
	) REFERENCES dbo.Folio
	(
	FolioID
	)
  
 EXEC(' update Folio set SubEmpresaId=(select top 1 SubEmpresaid from SubEmpresa) where fiscal =1')



end