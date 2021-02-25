IF(SELECT COUNT(*) FROM ValorReferencia WHERE VARCodigo = 'FRMFAC')=0
BEGIN
	INSERT INTO ValorReferencia(VARCodigo,Descripcion,TipoDato,TipoAplicacion,TipoNulo,TipoModificable,MUsuarioId,MFechaHora) VALUES('FRMFAC','Formato de la Factura Electrónica','N',1,0,0,'Admin',GETDATE())
	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','',1,'Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','EC','Genérico','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','ECR','Genérico','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','EM','Genérico','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','EP','Genérico','Admin',GETDATE())
END