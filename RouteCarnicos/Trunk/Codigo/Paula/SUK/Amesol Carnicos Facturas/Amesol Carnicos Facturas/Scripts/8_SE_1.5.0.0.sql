IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMFormatoFacturas' AND TipoMensaje = 'T' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturas','T',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturas','EC','Formato Comprobante Digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturas','ECR','Formato Comprobante Digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturas','EM','Formato Comprobante Digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturas','EP','Formato Comprobante Digital','Admin',GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMFormatoFacturasT' AND TipoMensaje = 'G' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturasT','G',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturasT','EC','Formato Comprobante Digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturasT','ECR','Formato Comprobante Digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturasT','EM','Formato Comprobante Digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMFormatoFacturasT','EP','Formato Comprobante Digital','Admin',GETDATE())
END