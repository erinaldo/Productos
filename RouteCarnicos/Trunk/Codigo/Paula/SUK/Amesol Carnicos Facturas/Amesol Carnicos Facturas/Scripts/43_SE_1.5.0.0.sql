if(Select COUNT(*) from Mensaje where MENClave = 'E0529') = 0
BEGIN
	insert into Mensaje(MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('E0529',	'E',1,	3,	'Admin',	getdate())
	insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('E0529',	'EC', '[E0529] No se puede eliminar al vendedor ya que tiene una carga por transferir.','Admin',GETDATE())
	insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('E0529',	'ECR', '[E0529] No se puede eliminar al vendedor ya que tiene una carga por transferir.','Admin',GETDATE())
	insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('E0529',	'EM', '[E0529] No se puede eliminar al vendedor ya que tiene una carga por transferir.','Admin',GETDATE())
	insert into MENDetalle(MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES('E0529',	'EP', '[E0529] No se puede eliminar al vendedor ya que tiene una carga por transferir.','Admin',GETDATE())
END