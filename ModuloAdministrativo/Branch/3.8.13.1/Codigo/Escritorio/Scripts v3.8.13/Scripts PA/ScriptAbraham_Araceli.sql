if not exists(select * from Mensaje where MENClave ='XIndicadoresGraficos')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('XIndicadoresGraficos','T',1,3,'Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresGraficos','EC','3. Indicadores gráficos','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresGraficos','ECR','3. Indicadores gráficos','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresGraficos','EM','3. Indicadores gráficos','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresGraficos','EP','3. Indicadores gráficos','Admin',GETDATE ())
end

select * from MENDetalle where MENClave ='XIndicadoresGraficos'

if not exists(select * from Mensaje where MENClave ='XIndicadoresTabulares2')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares2','T',1,3,'Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares2','EC','2. Indicadores tabulares','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares2','ECR','2. Indicadores tabulares','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares2','EM','2. Indicadores tabulares','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares2','EP','2. Indicadores tabulares','Admin',GETDATE ())
end

if not exists(select * from Mensaje where MENClave ='XIndicadoresTabulares')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares','T',1,3,'Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares','EC','1. Indicadores tabulares','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares','ECR','1. Indicadores tabulares','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares','EM','1. Indicadores tabulares','Admin',GETDATE ())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('XIndicadoresTabulares','EP','1. Indicadores tabulares','Admin',GETDATE ())
end

if not exists(select * from Modulo where MODId ='2CAH7RNKP2KZCC2')
begin
	Insert into Modulo values('2CAH7RNKP2KZCC2',NULL,'XMWeb','XMWebDescripcion',3, 1, 0x0, 'Admin', getdate())		
end
if not exists(select * from Modulo where MODId ='2CAH7RNKP2KZCC3')
begin
	Insert into Modulo values('2CAH7RNKP2KZCC3',NULL,'XMWeb','XMWebDescripcion',3, 2, 0x0, 'Admin', getdate())
end
if not exists(select * from Modulo where MODId ='2CAH7RNKP2KZCC4')
begin
	Insert into Modulo values('2CAH7RNKP2KZCC4',NULL,'XMWeb','XMWebDescripcion',3, 3, 0x0, 'Admin', getdate())
end

Update Interfaz set MODId = '2CAH7RNKP2KZCC2' where ACTId in('ACTKPI001','ACTKPI002','ACTKPI003')
Update IntPer set MODId = '2CAH7RNKP2KZCC2' where ACTId in('ACTKPI001','ACTKPI002','ACTKPI003')
Update Interfaz set MODId = '2CAH7RNKP2KZCC3' where ACTId in('ACTKPI004','ACTKPI005','ACTKPI006')
Update IntPer set MODId = '2CAH7RNKP2KZCC3' where ACTId in('ACTKPI004','ACTKPI005','ACTKPI006')
Update Interfaz set MODId = '2CAH7RNKP2KZCC4' where ACTId in('ACTKPI007','ACTKPI008')
Update IntPer set MODId = '2CAH7RNKP2KZCC4' where ACTId in('ACTKPI007','ACTKPI008')

Update Modulo set MENNombreClave ='XActividades' where MODId = '2CAH7RNKP2KZCC1'
Update Modulo set MENNombreClave ='XIndicadoresTabulares' where MODId = '2CAH7RNKP2KZCC2'
Update Modulo set MENNombreClave ='XIndicadoresTabulares2' where MODId = '2CAH7RNKP2KZCC3'
Update Modulo set MENNombreClave ='XIndicadoresGraficos' where MODId = '2CAH7RNKP2KZCC4'


