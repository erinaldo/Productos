if not exists(select * from Mensaje where MENClave ='CEESubEmpresa')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('CEESubEmpresa','T',1,3,'Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CEESubEmpresa','EC','Sub-Empresa','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CEESubEmpresa','ECR','Sub-Empresa','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CEESubEmpresa','EM','Sub-Empresa','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CEESubEmpresa','EP','Sub-Empresa','Admin',GETDATE ())
end

if not exists(select * from Mensaje where MENClave ='CEESubEmpresaT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('CEESubEmpresaT','T',1,3,'Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CEESubEmpresaT','EC','Sub-Empresa a la pertenece el centro de expedición.','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CEESubEmpresaT','ECR','Sub-Empresa a la pertenece el centro de expedición.','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CEESubEmpresaT','EM','Sub-Empresa a la pertenece el centro de expedición.','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('CEESubEmpresaT','EP','Sub-Empresa a la pertenece el centro de expedición.','Admin',GETDATE ())
end