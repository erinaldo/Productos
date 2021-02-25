if(Select COUNT(*) from Mensaje where MENClave = 'XVentaPorEsquemaT') = 0
BEGIN
	Insert into Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquemaT','G', 1, 3, 'Admin', GETDATE())

	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquemaT',	'EC','Indica si se mostrarán las Ventas del Esquema seleccionado','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquemaT',	'ECR','Indica si se mostrarán las Ventas del Esquema seleccionado','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquemaT',	'EM','Indica si se mostrarán las Ventas del Esquema seleccionado','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquemaT',	'EP','Indica si se mostrarán las Ventas del Esquema seleccionado','Admin', GETDATE())
END

if(Select COUNT(*) from Mensaje where MENClave = 'XVentaPorEsquema') = 0
BEGIN
	Insert into Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquema','G', 1, 3, 'Admin', GETDATE())

	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquema',	'EC','Ventas por Esquema','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquema',	'ECR','Ventas por Esquema','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquema',	'EM','Ventas por Esquema','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('XVentaPorEsquema',	'EP','Ventas por Esquema','Admin', GETDATE())
END
if(Select COUNT(*) from Mensaje where MENClave = 'BTVistaPreviaPedido') = 0
BEGIN
	Insert into Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('BTVistaPreviaPedido','B', 1, 3, 'Admin', GETDATE())

	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('BTVistaPreviaPedido',	'EC','Preview','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('BTVistaPreviaPedido',	'ECR','Preview','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('BTVistaPreviaPedido',	'EM','Preview','Admin', GETDATE())
	Insert into MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('BTVistaPreviaPedido',	'EP','Preview','Admin', GETDATE())
END

if (Select COUNT (*) from Mensaje where MENClave = 'BTVistaPreviaPedidoT') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('BTVistaPreviaPedidoT','T',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('BTVistaPreviaPedidoT','EC','Muestra el detalle de los pedidos de la Factura','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('BTVistaPreviaPedidoT','ECR','Muestra el detalle de los pedidos de la Factura','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('BTVistaPreviaPedidoT','EM','Muestra el detalle de los pedidos de la Factura','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('BTVistaPreviaPedidoT','EP','Muestra el detalle de los pedidos de la Factura','Admin',GETDATE())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'ERMTRPESC_IMetodosPago') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IMetodosPago','U',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IMetodosPago','EC','Seleccionar Método de Pago','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IMetodosPago','ECR','Seleccionar Método de Pago','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IMetodosPago','EM','Seleccionar Método de Pago','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IMetodosPago','EP','Seleccionar Método de Pago','Admin',getdate())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'TDFMetodoPago') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('TDFMetodoPago','T',3,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TDFMetodoPago','EC','Método de Pago','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TDFMetodoPago','ECR','Método de Pago','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TDFMetodoPago','EM','Método de Pago','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TDFMetodoPago','EP','Método de Pago','Admin',getdate())
END


IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'TDFMetodoPagoT') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('TDFMetodoPagoT','E',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TDFMetodoPagoT','EC','Método de Pago que aplica para el Comprobante Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TDFMetodoPagoT','ECR','Método de Pago que aplica para el Comprobante Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TDFMetodoPagoT','EM','Método de Pago que aplica para el Comprobante Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TDFMetodoPagoT','EP','Método de Pago que aplica para el Comprobante Fiscal','Admin',getdate())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'E0795') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('E0795','E',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0795','EC','[E0795] El cliente no pertenece al esquema seleccionado.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0795','ECR','[E0795] El cliente no pertenece al esquema seleccionado.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0795','EM','[E0795] El cliente no pertenece al esquema seleccionado.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0795','EP','[E0795] El cliente no pertenece al esquema seleccionado. ','Admin',GETDATE())
END

if (Select COUNT (*) from Mensaje where MENClave = 'ERMTRPESC_IDetallePedidos') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IDetallePedidos','U',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IDetallePedidos','EC','Consultar Detalle Factura','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IDetallePedidos','ECR','Consultar Detalle Factura','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IDetallePedidos','EM','Consultar Detalle Factura','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMTRPESC_IDetallePedidos','EP','Consultar Detalle Factura','Admin',GETDATE())
END

if not exists(select * from Mensaje where MENClave ='I0199')
begin
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('I0199','I',1,3,'Admin',GETDATE ())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0199','EC','[I0199] La(s) Sub-Empresa(s) $0$ no podrá(n) facturar electrónicamente, ya que no se cuenta con el archivo necesario para generar el Sello Digital','Admin',GETDATE ())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0199','ECR','[I0199] La(s) Sub-Empresa(s) $0$ no podrá(n) facturar electrónicamente, ya que no se cuenta con el archivo necesario para generar el Sello Digital','Admin',GETDATE ())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0199','EM','[I0199] La(s) Sub-Empresa(s) $0$ no podrá(n) facturar electrónicamente, ya que no se cuenta con el archivo necesario para generar el Sello Digital','Admin',GETDATE ())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('I0199','EP','[I0199] La(s) Sub-Empresa(s) $0$ no podrá(n) facturar electrónicamente, ya que no se cuenta con el archivo necesario para generar el Sello Digital','Admin',GETDATE ())
end

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'E0840') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('E0840','E',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0840','EC','[E0839] La(s) Sub-Empresa(s) $0$ no podrá(n) facturar electrónicamente, ya que no cuenta(n) con un certificado generado en el formato requerido','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0840','ECR','[E0839] La(s) Sub-Empresa(s) $0$ no podrá(n) facturar electrónicamente, ya que no cuenta(n) con un certificado generado en el formato requerido','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0840','EM','[E0839] La(s) Sub-Empresa(s) $0$ no podrá(n) facturar electrónicamente, ya que no cuenta(n) con un certificado generado en el formato requerido','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0840','EP','[E0839] La(s) Sub-Empresa(s) $0$ no podrá(n) facturar electrónicamente, ya que no cuenta(n) con un certificado generado en el formato requerido','Admin',getdate())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'E0841') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('E0841','E',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0841','EC','No se podrá facturar electrónicamente, ya que no se cuenta con un certificado generado en el formato requerido','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0841','ECR','No se podrá facturar electrónicamente, ya que no se cuenta con un certificado generado en el formato requerido','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0841','EM','No se podrá facturar electrónicamente, ya que no se cuenta con un certificado generado en el formato requerido','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0841','EP','No se podrá facturar electrónicamente, ya que no se cuenta con un certificado generado en el formato requerido','Admin',getdate())
END
