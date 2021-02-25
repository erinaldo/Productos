IF (SELECT COUNT(*) FROM SysColumns WHERE Name = 'TipoComprobante' AND Id = (SELECT Id FROM SysObjects WHERE Name = 'FolioSolicitado')) = 0
BEGIN
	ALTER TABLE dbo.FolioSolicitado
		DROP CONSTRAINT FK_FolioSolicitado_Folio

	CREATE TABLE dbo.Tmp_FolioSolicitado_1
		(
		FolioID varchar(16) NOT NULL,
		FOSId varchar(16) NOT NULL,
		Serie varchar(10) NOT NULL,
		FechaCreacion datetime NOT NULL,
		TipoComprobante smallint NOT NULL,
		Aprobacion int NOT NULL,
		AnioAprobacion int NOT NULL,
		CantSolicitada int NOT NULL,
		Usados int NOT NULL,
		MFechaHora datetime NOT NULL,
		MUsuarioID varchar(16) NOT NULL
		)  ON [PRIMARY]

	ALTER TABLE dbo.Tmp_FolioSolicitado_1 ADD CONSTRAINT
		DF_FolioSolicitado_TipoComprobante DEFAULT 1 FOR TipoComprobante

	IF EXISTS(SELECT * FROM dbo.FolioSolicitado)
		 EXEC('INSERT INTO dbo.Tmp_FolioSolicitado_1 (FolioID, FOSId, Serie, FechaCreacion, Aprobacion, AnioAprobacion, CantSolicitada, Usados, MFechaHora, MUsuarioID)
			SELECT FolioID, FOSId, Serie, FechaCreacion, Aprobacion, AnioAprobacion, CantSolicitada, Usados, MFechaHora, MUsuarioID FROM dbo.FolioSolicitado (HOLDLOCK TABLOCKX)')

	ALTER TABLE dbo.FOSHist
		DROP CONSTRAINT FK_FOSHist_FolioSolicitado

	DROP TABLE dbo.FolioSolicitado

	EXECUTE sp_rename N'dbo.Tmp_FolioSolicitado_1', N'FolioSolicitado', 'OBJECT'

	ALTER TABLE dbo.FolioSolicitado ADD CONSTRAINT
		PK_FolioSolicitado PRIMARY KEY CLUSTERED 
		(
		FolioID,
		FOSId
		) ON [PRIMARY]


	ALTER TABLE dbo.FolioSolicitado WITH NOCHECK ADD CONSTRAINT
		FK_FolioSolicitado_Folio FOREIGN KEY
		(
		FolioID
		) REFERENCES dbo.Folio
		(
		FolioID
		)

	ALTER TABLE dbo.FOSHist WITH NOCHECK ADD CONSTRAINT
		FK_FOSHist_FolioSolicitado FOREIGN KEY
		(
		FolioID,
		FOSId
		) REFERENCES dbo.FolioSolicitado
		(
		FolioID,
		FOSId
		)
END
/*go*/go


if not exists(Select * from Mensaje where MENClave ='FOLSubEmpresaT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('FOLSubEmpresaT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLSubEmpresaT','EC','Sub-Empresa asociada al folio fiscal.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLSubEmpresaT','ECR','Sub-Empresa asociada al folio fiscal.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLSubEmpresaT','EM','Sub-Empresa asociada al folio fiscal.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLSubEmpresaT','EP','Sub-Empresa asociada al folio fiscal.','Admin',getdate())
end

IF (SELECT COUNT(*) FROM ValorReferencia WHERE VARCodigo = 'FOLTIPO') = 0
BEGIN
	INSERT INTO ValorReferencia(VARCodigo,Descripcion,TipoDato,TipoAplicacion,TipoNulo,TipoModificable,MUsuarioId,MFechaHora) VALUES('FOLTIPO','Tipo de comprobante para el folio fiscal','N',3,0,0,'Admin',getdate())

	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('FOLTIPO','1','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLTIPO','1','EC','Factura','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLTIPO','1','ECR','Factura','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLTIPO','1','EP','Factura','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLTIPO','1','EM','Factura','Admin',getdate())

	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('FOLTIPO','2','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLTIPO','2','EC','Nota de Crédito','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLTIPO','2','ECR','Nota de Crédito','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLTIPO','2','EM','Nota de Crédito','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FOLTIPO','2','EP','Nota de Crédito','Admin',getdate())
END

If (select COUNT(*) from Mensaje where MENClave = 'XTipoComprobante' and TipoMensaje = 'G') = 0
BEGIN
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('XTipoComprobante','G',1,3,'Admin',GETDATE())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XTipoComprobante','EC','Tipo Comprobante','Admin',GETDATE())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XTipoComprobante','ECR','Tipo Comprobante','Admin',GETDATE())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XTipoComprobante','EM','Tipo Comprobante','Admin',GETDATE())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XTipoComprobante','EP','Tipo Comprobante','Admin',GETDATE())
END
