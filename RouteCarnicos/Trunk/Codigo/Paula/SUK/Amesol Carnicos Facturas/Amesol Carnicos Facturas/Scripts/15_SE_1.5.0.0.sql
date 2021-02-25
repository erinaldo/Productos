IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'E0867') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('E0867','E',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0867','EC','[E0867] Se debe asignar por lo menos un(a) $0$','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0867','ECR','[E0867] Se debe asignar por lo menos un(a) $0$','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0867','EM','[E0867] Se debe asignar por lo menos un(a) $0$','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0867','EP','[E0867] Se debe asignar por lo menos un(a) $0$','Admin',getdate())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'ERMCEEESC_MGeneral_gbRegimen') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('ERMCEEESC_MGeneral_gbRegimen','U',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMCEEESC_MGeneral_gbRegimen','EC','Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMCEEESC_MGeneral_gbRegimen','ECR','Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMCEEESC_MGeneral_gbRegimen','EM','Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMCEEESC_MGeneral_gbRegimen','EP','Régimen Fiscal','Admin',getdate())
END

delete CGRValor where  CGRComponente='ermceeesc'