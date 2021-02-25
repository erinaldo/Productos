IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'P0216') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('P0216','P',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('P0216','EC','[P0216] ¿Desea inactivar al cliente aunque tenga saldos por liquidar o activos por entregar?','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('P0216','ECR','[P0216] ¿Desea inactivar al cliente aunque tenga saldos por liquidar o activos por entregar?','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('P0216','EM','[P0216] ¿Desea inactivar al cliente aunque tenga saldos por liquidar o activos por entregar?','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('P0216','EP','[P0216] ¿Desea inactivar al cliente aunque tenga saldos por liquidar o activos por entregar?','Admin',GETDATE())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'P0217') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('P0217','P',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('P0217','EC','[P0217] ¿Desea eliminar las secuencias de visita del cliente?','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('P0217','ECR','[P0217] ¿Desea eliminar las secuencias de visita del cliente?','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('P0217','EM','[P0217] ¿Desea eliminar las secuencias de visita del cliente?','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('P0217','EP','[P0217] ¿Desea eliminar las secuencias de visita del cliente?','Admin',GETDATE())
END