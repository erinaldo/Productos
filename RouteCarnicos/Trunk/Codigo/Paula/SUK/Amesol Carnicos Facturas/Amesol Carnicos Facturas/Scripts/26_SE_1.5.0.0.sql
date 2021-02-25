if (Select COUNT(*) from Mensaje where MENClave = 'E0677') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('E0677',	'E',	3,	3,	'Admin', GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora)  VALUES ('E0677','EC','[E0677] El campo $0$ debe conformarse de números y letras','Admin', GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora)  VALUES ('E0677','ECR','[E0677] El campo $0$ debe conformarse de números y letras','Admin', GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora)  VALUES ('E0677','EM','[E0677] El campo $0$ debe conformarse de números y letras','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora)  VALUES ('E0677','EP','[E0677] El campo $0$ debe conformarse de números y letras','Admin', GETDATE ())
END