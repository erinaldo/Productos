if (Select COUNT(*) from Mensaje where MENClave = 'XSubEmpresa') = 0
BEGIN
	Insert into Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto , MUsuarioId, MFechaHora )
	VALUES('XSubEmpresa', 'G', 3,3,'Admin', GETDATE ())

	Insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioID, MFechaHora)
	VALUES('XSubEmpresa', 'EC',	'Sub-Empresa',	'Admin', GETDATE())
	Insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioID, MFechaHora)
	VALUES('XSubEmpresa', 'ECR','Sub-Empresa',	'Admin', GETDATE())
	Insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioID, MFechaHora)
	VALUES('XSubEmpresa', 'EM',	'Sub-Empresa',	'Admin', GETDATE())
	Insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioID, MFechaHora)
	VALUES('XSubEmpresa', 'EP',	'Sub-Empresa',	'Admin', GETDATE())
	Insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioID, MFechaHora)
	VALUES('XSubEmpresa', 'IN',	'Sub-Company',	'Admin', GETDATE())
END