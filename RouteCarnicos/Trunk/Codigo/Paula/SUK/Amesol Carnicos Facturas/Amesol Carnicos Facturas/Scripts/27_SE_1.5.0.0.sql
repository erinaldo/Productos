IF (SELECT COUNT(*) FROM VARValor WHERE VARCodigo = 'VERFACTE' AND VAVClave = '3') = 0
BEGIN
	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('VERFACTE','3','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VERFACTE','3','EC','2.2','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VERFACTE','3','ECR','2.2','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VERFACTE','3','EM','2.2','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VERFACTE','3','EP','2.2','Admin',getdate())
END

UPDATE VARValor SET Grupo='CFD',Estado=1,MUsuarioId='Admin',MFechaHora=getdate() WHERE VARCodigo='VERFACTE' AND VAVClave='1'
UPDATE VARValor SET Grupo='CFD',Estado=1,MUsuarioId='Admin',MFechaHora=getdate() WHERE VARCodigo='VERFACTE' AND VAVClave='3'


Update VARValor set Grupo = 'CFD' where VARCodigo = 'FRMFAC'
