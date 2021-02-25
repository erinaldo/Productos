if (Select COUNT(*) from Mensaje where MENClave = 'CLICriterioCredito') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('CLICriterioCredito','T',1,3,'Admin','2012-05-03T15:15:17.810')
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLICriterioCredito','EM','Criterio Crédito','Admin','2012-05-03T15:15:17.917')
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLICriterioCredito','EC','Criterio Crédito','Admin','2012-05-03T15:15:17.953')
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLICriterioCredito','ECR','Criterio Crédito','Admin','2012-05-03T15:15:17.957')
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLICriterioCredito','EP','Criterio Crédito','Admin','2012-05-03T15:15:17.957')
END

if (Select COUNT(*) from Mensaje where MENClave = 'CLICriterioCreditoT') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('CLICriterioCreditoT','T',1,3,'Admin','2012-05-03T15:15:17.830')
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLICriterioCreditoT','EC','Indica si el saldo del cliente se calcula sobre el saldo efectivo o Ventas y Facturas','Admin','2012-05-03T15:15:17.957')
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLICriterioCreditoT','ECR','Indica si el saldo del cliente se calcula sobre el saldo efectivo o Ventas y Facturas','Admin','2012-05-03T15:15:17.960')
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLICriterioCreditoT','EM','Indica si el saldo del cliente se calcula sobre el saldo efectivo o Ventas y Facturas','Admin','2012-05-03T15:15:17.960')
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CLICriterioCreditoT','EP','Indica si el saldo del cliente se calcula sobre el saldo efectivo o Ventas y Facturas','Admin','2012-05-03T15:15:17.960')
END