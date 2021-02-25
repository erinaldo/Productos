IF  NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CEERegimenFiscal]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[CEERegimenFiscal](
		[RegimenFiscalId] [varchar](16) NOT NULL,
		[CentroExpId] [varchar](16) NOT NULL,
		[TipoRegimen] [smallint] NOT NULL,
		[MFechaHora] [datetime] NOT NULL,
		[MUsuarioId] [varchar](16) NOT NULL,
	) ON [PRIMARY]
	
	ALTER TABLE [dbo].[CEERegimenFiscal] ADD 
		CONSTRAINT [PK_CEERegimenFiscal] PRIMARY KEY  CLUSTERED 
		(
			[RegimenFiscalId]
		)  ON [PRIMARY] 
	
	ALTER TABLE [dbo].[CEERegimenFiscal] ADD 
		CONSTRAINT [FK_CEERegimenFiscal_CentroExpedicion] FOREIGN KEY 
		(
			[CentroExpId]
		) REFERENCES [dbo].[CentroExpedicion] (
			[CentroExpId]
		)

END
/*go*/go

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'CRFTipoRegimen') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('CRFTipoRegimen','T',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CRFTipoRegimen','EC','Tipo Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CRFTipoRegimen','ECR','Tipo Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CRFTipoRegimen','EM','Tipo Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CRFTipoRegimen','EP','Tipo Régimen Fiscal','Admin',getdate())
END
/*go*/go

IF (SELECT COUNT(*) FROM ValorReferencia WHERE VARCodigo = 'TIPREG') = 0
BEGIN
	INSERT INTO ValorReferencia(VARCodigo,Descripcion,TipoDato,TipoAplicacion,TipoNulo,TipoModificable,MUsuarioId,MFechaHora) VALUES('TIPREG','Tipos de regimenes fiscales','N',1,0,1,'Admin',getdate())

	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('TIPREG','0','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TIPREG','0','EM','Servicios Profesionales','Admin',getdate())

	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('TIPREG','1','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TIPREG','1','EM','Intermedio','Admin',getdate())

	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('TIPREG','2','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TIPREG','2','EM','Pequeños Contribuyentes (Repeco)','Admin',getdate())

	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('TIPREG','3','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TIPREG','3','EM','Actividades Comerciales','Admin',getdate())

	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('TIPREG','4','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TIPREG','4','EM','Asimilados a Salario','Admin',getdate())

	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('TIPREG','5','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TIPREG','5','EM','Empleados o Asalariados','Admin',getdate())
END
/*go*/go