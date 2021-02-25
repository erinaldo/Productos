
IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'E0816')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('E0816','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('E0816', 'EC', '[E0816] El formato de correo es incorrecto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('E0816', 'ECR', '[E0816] El formato de correo es incorrecto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('E0816', 'EP', '[E0816] El formato de correo es incorrecto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('E0816', 'EM', '[E0816] El formato de correo es incorrecto', 'Admin', GETDATE())
END


IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHCorreoElectronico')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHCorreoElectronico','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronico', 'EC', 'Correo electrónico', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronico', 'ECR', 'Correo electrónico', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronico', 'EP', 'Correo electrónico', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronico', 'EM', 'Correo electrónico', 'Admin', GETDATE())
END


IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHCorreoElectronicoT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHCorreoElectronicoT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronicoT', 'EC', 'Dirección del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronicoT', 'ECR', 'Dirección del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronicoT', 'EP', 'Dirección del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronicoT', 'EM', 'Dirección del correo electrónico saliente', 'Admin', GETDATE())
END



IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHPuerto')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHPuerto','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuerto', 'EC', 'Puerto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuerto', 'ECR', 'Puerto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuerto', 'EP', 'Puerto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuerto', 'EM', 'Puerto', 'Admin', GETDATE())
END


IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHPuertoT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHPuertoT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuertoT', 'EC', 'Puerto del servidor SMTP del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuertoT', 'ECR', 'Puerto del servidor SMTP del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuertoT', 'EP', 'Puerto del servidor SMTP del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuertoT', 'EM', 'Puerto del servidor SMTP del correo electrónico saliente', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHServidorSMTP')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHServidorSMTP','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTP', 'EC', 'Servidor SMTP', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTP', 'ECR', 'Servidor SMTP', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTP', 'EP', 'Servidor SMTP', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTP', 'EM', 'Servidor SMTP', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHServidorSMTPT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHServidorSMTPT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTPT', 'EC', 'Nombre del servidor SMTP de la cuenta de correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTPT', 'ECR', 'Nombre del servidor SMTP de la cuenta de correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTPT', 'EP', 'Nombre del servidor SMTP de la cuenta de correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTPT', 'EM', 'Nombre del servidor SMTP de la cuenta de correo electrónico saliente', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHConfirmarContraseña')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHConfirmarContraseña','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseña', 'EC', 'Confirmar Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseña', 'ECR', 'Confirmar Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseña', 'EP', 'Confirmar Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseña', 'EM', 'Confirmar Contraseña', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHContraseña')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHContraseña','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContraseña', 'EC', 'Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContraseña', 'ECR', 'Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContraseña', 'EP', 'Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContraseña', 'EM', 'Contraseña', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHContraseñaT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHContraseñaT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContraseñaT', 'EC', 'Contraseña del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContraseñaT', 'ECR', 'Contraseña del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContraseñaT', 'EP', 'Contraseña del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContraseñaT', 'EM', 'Contraseña del correo electrónico saliente', 'Admin', GETDATE())
END



IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHConfirmarContraseña')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHConfirmarContraseña','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseña', 'EC', 'Confirmar Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseña', 'ECR', 'Confirmar Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseña', 'EP', 'Confirmar Contraseña', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseña', 'EM', 'Confirmar Contraseña', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHConfirmarContraseñaT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHConfirmarContraseñaT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseñaT', 'EC', 'Confirmar contraseña del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseñaT', 'ECR', 'Confirmar contraseña del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseñaT', 'EP', 'Confirmar contraseña del correo electrónico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContraseñaT', 'EM', 'Confirmar contraseña del correo electrónico saliente', 'Admin', GETDATE())
END

if(Select COUNT (*) from Mensaje where MENClave ='COHSSL')= 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('COHSSL','T',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSL','EM','Secure Socket Layer','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSL','EC','Secure Socket Layer','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSL','ECR','Secure Socket Layer','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSL','EP','Secure Socket Layer','Admin',GETDATE())
END

if (Select COUNT(*) from Mensaje where MENClave ='COHSSLT') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('COHSSLT','U',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSLT','EM','Indica si se utiliza SSL (Secure Sockets Layer) para cifrar la conexión.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSLT','EC','Indica si se utiliza SSL (Secure Sockets Layer) para cifrar la conexión.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSLT','ECR','Indica si se utiliza SSL (Secure Sockets Layer) para cifrar la conexión.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSLT','EP','Indica si se utiliza SSL (Secure Sockets Layer) para cifrar la conexión.','Admin',GETDATE())
END
