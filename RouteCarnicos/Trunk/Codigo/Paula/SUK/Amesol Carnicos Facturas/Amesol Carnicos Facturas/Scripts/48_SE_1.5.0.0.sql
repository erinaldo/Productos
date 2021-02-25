IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'I0210') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('I0210','I',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0210','EC','Estimado Cliente, le hacemos llegar por este medio el Comprobante Fiscal Digital (*.XML), agradecemos su preferencia y esperamos verlo pronto. Saludos','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0210','ECR','Estimado Cliente, le hacemos llegar por este medio el Comprobante Fiscal Digital (*.XML), agradecemos su preferencia y esperamos verlo pronto. Saludos','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0210','EM','Estimado Cliente, le hacemos llegar por este medio el Comprobante Fiscal Digital (*.XML), agradecemos su preferencia y esperamos verlo pronto. Saludos','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0210','EP','Estimado Cliente, le hacemos llegar por este medio el Comprobante Fiscal Digital (*.XML), agradecemos su preferencia y esperamos verlo pronto. Saludos','Admin',getdate())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'I0211') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('I0211','I',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0211','EC','[I0211] Es necesario revisar la bitácora: $0$, debido a que se generaron errores en el envío del XML','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0211','ECR','[I0211] Es necesario revisar la bitácora: $0$, debido a que se generaron errores en el envío del XML','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0211','EM','[I0211] Es necesario revisar la bitácora: $0$, debido a que se generaron errores en el envío del XML','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0211','EP','[I0211] Es necesario revisar la bitácora: $0$, debido a que se generaron errores en el envío del XML','Admin',getdate())
END