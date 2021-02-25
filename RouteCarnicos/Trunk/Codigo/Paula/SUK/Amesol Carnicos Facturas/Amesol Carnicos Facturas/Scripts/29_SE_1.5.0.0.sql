IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'CLIExigirOrdenCompra') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompra','T',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompra','EC','Exigir Orden de Compra','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompra','ECR','Exigir Orden de Compra','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompra','EM','Exigir Orden de Compra','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompra','EP','Exigir Orden de Compra','Admin',getdate())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'CLIExigirOrdenCompraT') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompraT','T',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompraT','EC','Indica si se debe exigir como requerida la orden de compra en la facturación electrónica','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompraT','ECR','Indica si se debe exigir como requerida la orden de compra en la facturación electrónica','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompraT','EM','Indica si se debe exigir como requerida la orden de compra en la facturación electrónica','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLIExigirOrdenCompraT','EP','Indica si se debe exigir como requerida la orden de compra en la facturación electrónica','Admin',getdate())
END
