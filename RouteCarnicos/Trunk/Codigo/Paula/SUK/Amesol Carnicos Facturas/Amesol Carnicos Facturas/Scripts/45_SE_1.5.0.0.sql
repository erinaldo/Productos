IF (SELECT COUNT(*) FROM Mensaje where MENClave = 'XEfectosFiscales2') = 0
BEGIN
	insert Mensaje values('XEfectosFiscales2','G',3,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XEfectosFiscales2','EC','','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XEfectosFiscales2','ECR','','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XEfectosFiscales2','EM','','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XEfectosFiscales2','EP','','Admin',GETDATE())	
END

IF (SELECT COUNT(*) FROM Mensaje where MENClave = 'XExpedida') = 0
BEGIN
	insert Mensaje values('XExpedida','G',3,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XExpedida','EC','Expedida en','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XExpedida','EP','Expedida en:','Admin',GETDATE())	
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XExpedida','ECR','Expedida en','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XExpedida','EM','Expedida en:','Admin',GETDATE())
	
END

if (select COUNT(*) from Mensaje where MENClave = 'XPUnitario')=0 
begin
	insert into Mensaje values ('XPUnitario','G',1,3,'Admin',GETDATE())
	insert into MENDetalle Values ('XPUnitario','EM','P. Unitario','Admin',GETDATE())
	insert into MENDetalle Values ('XPUnitario','EC','P. Unitario','Admin',GETDATE())
	insert into MENDetalle Values ('XPUnitario','EP','P. Unitario','Admin',GETDATE())
	insert into MENDetalle Values ('XPUnitario','ECR','P. Unitario','Admin',GETDATE())
end

if (Select COUNT(*) from Mensaje where MENClave ='XDesc') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('XDesc','G',3,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XDesc','EM','Desc.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XDesc','EC','Desc.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XDesc','ECR','Desc.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XDesc','EP','Desc.','Admin',GETDATE())
END

IF (SELECT COUNT(*) FROM Mensaje where MENClave = 'XEfectosFiscales') = 0
BEGIN
	insert Mensaje values('XEfectosFiscales','G',3,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XEfectosFiscales','EC','','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XEfectosFiscales','ECR','','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XEfectosFiscales','EM','','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XEfectosFiscales','EP','','Admin',GETDATE())	
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'XRegimenFiscal') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('XRegimenFiscal','G',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XRegimenFiscal','EC','Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XRegimenFiscal','ECR','Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XRegimenFiscal','EM','Régimen Fiscal','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XRegimenFiscal','EP','Régimen Fiscal','Admin',getdate())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'XRegimen') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('XRegimen','G',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XRegimen','EC','Régimen','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XRegimen','ECR','Régimen','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XRegimen','EM','Régimen','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XRegimen','EP','Régimen','Admin',getdate())
END