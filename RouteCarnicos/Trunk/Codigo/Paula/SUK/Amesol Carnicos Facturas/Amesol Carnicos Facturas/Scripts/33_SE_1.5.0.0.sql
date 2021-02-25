
if not exists(select * from Mensaje where MENClave ='VENTipo')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('VENTipo','T',1,3,'Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VENTipo','EC','Tipo','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VENTipo','ECR','Tipo','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VENTipo','EM','Tipo','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VENTipo','EP','Tipo','Admin',GETDATE ())
end


if not exists(select * from Mensaje where MENClave ='VENTipoT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('VENTipoT','T',1,3,'Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VENTipoT','EC','Tipo de vendedor a configurar','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VENTipoT','ECR','Tipo de vendedor a configurar','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VENTipoT','EM','Tipo de vendedor a configurar','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('VENTipoT','EP','Tipo de vendedor a configurar','Admin',GETDATE ())
end

if not exists(select * from ValorReferencia where VARCodigo ='TVEND')
begin
	INSERT INTO ValorReferencia(VARCodigo,Descripcion,TipoDato,TipoAplicacion,TipoNulo,TipoModificable,MUsuarioId,MFechaHora) VALUES('TVEND','Tipo de vendedor','N',3,0,0,'Admin',GETDATE ())
end

if not exists(select * from VARValor where VARCodigo ='TVEND' and VAVClave ='1')
begin
INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('TVEND','1','',1,'Admin',GETDATE ())
INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TVEND','1','EC','Móvil','Admin',GETDATE ())
INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TVEND','1','ECR','Móvil','Admin',GETDATE ())
INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TVEND','1','EM','Móvil','Admin',GETDATE ())
INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TVEND','1','EP','Móvil','Admin',GETDATE ())
end

if not exists(select * from VARValor where VARCodigo ='TVEND' and VAVClave ='2')
begin
INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('TVEND','2','',1,'Admin',GETDATE ())
INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TVEND','2','EC','Mostrador (Escritorio)','Admin',GETDATE ())
INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TVEND','2','ECR','Mostrador (Escritorio)','Admin',GETDATE ())
INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TVEND','2','EM','Mostrador (Escritorio)','Admin',GETDATE ())
INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('TVEND','2','EP','Mostrador (Escritorio)','Admin',GETDATE ())
end
