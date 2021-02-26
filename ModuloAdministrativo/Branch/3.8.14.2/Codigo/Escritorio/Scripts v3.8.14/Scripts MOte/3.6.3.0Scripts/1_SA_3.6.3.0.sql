IF (SELECT COUNT(*) FROM VARValor WHERE VARCodigo = 'INTSAL' AND VAVClave = '43')=0
BEGIN
	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('INTSAL','43','',1,'Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','43','EM','Management','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','43','EC','Management','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','43','ECR','Management','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','43','EP','Management','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','43','IN','Management','Admin',GETDATE())
END

IF (select COUNT(*) from InterfazSalida WHERE INSTipoInterfaz = '43') = 0
BEGIN
	INSERT INTO InterfazSalida (INSTipoInterfaz,Procedimiento,TipoEstado,TipoFecha, MUsuarioID, MFechaHora )
	VALUES('43','sp_tg_exportManagement',0,3,'Admin', GETDATE())
END 

/*go*/go


if (Select count(*) from VARValor where VARCodigo = 'INTSAL' and VAVClave = '46') = 0
BEGIN
	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('INTSAL','46','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','46','EM','Carga Sugerida (Management)','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','46','EC','Carga Sugerida (Management)','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','46','ECR','Carga Sugerida (Management)','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','46','EP','Carga Sugerida (Management)','Admin',getdate())
END


if (Select count(*) from InterfazSalida where INSTipoInterfaz = 46 ) = 0
BEGIN
	Insert into interfazSalida values(46,'sp_tg_exportCargaSugerida',0,1,'Admin',getdate())
END

/*go*/go

if (Select count(*) from VARValor where VARCodigo = 'INTSAL' and VAVClave = '47') = 0
BEGIN
	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('INTSAL','47','',1,'Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','47','EM','Preliquidacion(Management)','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','47','EC','Preliquidacion(Management)','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','47','ECR','Preliquidacion(Management)','Admin',getdate())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('INTSAL','47','EP','Preliquidacion(Management)','Admin',getdate())
END


if (Select count(*) from InterfazSalida where INSTipoInterfaz = 47 ) = 0
BEGIN
	Insert into interfazSalida values(47,'sp_tg_PreliquidacionManagement',0,1,'Admin',getdate())
END

/*go*/go

update interfazsalida set tipofecha=3 where instipointerfaz=46
select * from  interfazsalida where instipointerfaz=46

update interfazsalida set tipofecha=2 where instipointerfaz=47
select * from  interfazsalida where instipointerfaz=47

/*go*/go

IF (SELECT COUNT(*) FROM VARValor WHERE VARCodigo = 'INTSAL' AND VAVClave = '51') = 0
BEGIN
	INSERT INTO VARValor VALUES ('INTSAL','51','',0,'Admin',GETDATE())
	INSERT INTO VAVDescripcion VALUES ('INTSAL','51','EM','Cuentas Por Cobrar (Management)','Admin',getdate())
	INSERT INTO VAVDescripcion VALUES ('INTSAL','51','EC','Cuentas Por Cobrar (Management)','Admin',getdate())
	INSERT INTO VAVDescripcion VALUES ('INTSAL','51','ECR','Cuentas Por Cobrar (Management)','Admin',getdate())
	INSERT INTO VAVDescripcion VALUES ('INTSAL','51','EP','Cuentas Por Cobrar (Management)','Admin',getdate())
END


IF (SELECT COUNT(*) FROM InterfazSalida WHERE INSTipoInterfaz = 51) = 0
BEGIN
	INSERT INTO InterfazSalida (INSTipoInterfaz, Procedimiento, TipoEstado, MUsuarioID, MFechaHora) VALUES (51,'sp_tg_exportCPCManagement',0,'Admin',getdate())
END
/*go*/go