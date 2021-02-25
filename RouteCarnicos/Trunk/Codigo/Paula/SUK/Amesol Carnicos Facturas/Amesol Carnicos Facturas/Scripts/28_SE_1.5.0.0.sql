if not exists(select * from Mensaje where MENClave ='E0774')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('E0774','T',3,3,'Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0774','EC','[E0774] Ya existe un centro de expedición tipo matriz asociado a la sub-empresa $0$','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0774','ECR','[E0774] Ya existe un centro de expedición tipo matriz asociado a la sub-empresa $0$','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0774','EM','[E0774] Ya existe un centro de expedición tipo matriz asociado a la sub-empresa $0$','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('E0774','EP','[E0774] Ya existe un centro de expedición tipo matriz asociado a la sub-empresa $0$','Admin',GETDATE ())
end