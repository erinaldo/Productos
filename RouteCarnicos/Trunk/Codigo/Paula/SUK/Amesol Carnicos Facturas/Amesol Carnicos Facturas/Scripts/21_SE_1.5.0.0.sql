IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'E0839') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('E0839','E',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0839','EC','[E0839] No existe un archivo .cer dentro del directorio $0$','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0839','ECR','[E0839] No existe un archivo .cer dentro del directorio $0$','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0839','EM','[E0839] No existe un archivo .cer dentro del directorio $0$','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0839','EP','[E0839] No existe un archivo .cer dentro del directorio $0$','Admin',getdate())
END