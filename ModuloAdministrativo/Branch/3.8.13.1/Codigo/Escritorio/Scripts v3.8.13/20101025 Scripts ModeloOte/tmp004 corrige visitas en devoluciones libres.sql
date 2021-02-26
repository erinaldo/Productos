

--select *
--from Surtidos 
--inner join Devolucion on Devolucion.IdCedis = Surtidos.IdCedis and Devolucion.IdSurtido = Surtidos.IdSurtido 
--where Surtidos.IdCedis = 2 

INSERT INTO Visita
   (VisitaClave,DiaClave,ClienteClave,VendedorID,RUTClave
   ,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS
   ,MFechaHora,MUsuarioID)
VALUES('836BACCF1CF3F4B2','27/10/2010','020400','2O6M+W8LUNMWJC2','R02'
   ,1,'2010-10-27T00:00:00','2010-10-27T00:00:00',1,0,0,0,NULL
   ,GETDATE(),'2O6M+QCBPI3G1C1')

update TransProd set VisitaClave = '836BACCF1CF3F4B2', DiaClave = '27/10/2010', MUsuarioID = '2O6M+QCBPI3G1C1', 
	FechaHoraAlta = '2010-10-27T00:00:00', FechaCaptura = '2010-10-27T00:00:00'
where Tipo = 3 and Folio like '2%00%5'
---
INSERT INTO Visita
   (VisitaClave,DiaClave,ClienteClave,VendedorID,RUTClave
   ,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS
   ,MFechaHora,MUsuarioID)
VALUES('8B805934A654D547','27/10/2010','020009','2O6M+W8LUNMWJC2','R02'
   ,1,'2010-10-27T00:00:00','2010-10-27T00:00:00',1,0,0,0,NULL
   ,GETDATE(),'2O6M+QCBPI3G1C1')

update TransProd set VisitaClave = '8B805934A654D547', DiaClave = '27/10/2010', MUsuarioID = '2O6M+QCBPI3G1C1', 
	FechaHoraAlta = '2010-10-27T00:00:00', FechaCaptura = '2010-10-27T00:00:00'
where Tipo = 3 and Folio like '2%00%4'
---
INSERT INTO Visita
   (VisitaClave,DiaClave,ClienteClave,VendedorID,RUTClave
   ,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS
   ,MFechaHora,MUsuarioID)
VALUES('80A5663048556D09','19/10/2010','020400','2O6M+W8LUNMWJC2','R02'
   ,1,'2010-10-19T00:00:00','2010-10-19T00:00:00',1,0,0,0,NULL
   ,GETDATE(),'2O6M+QCBPI3G1C1')

update TransProd set VisitaClave = '80A5663048556D09', DiaClave = '19/10/2010', MUsuarioID = '2O6M+QCBPI3G1C1', 
	FechaHoraAlta = '2010-10-19T00:00:00', FechaCaptura = '2010-10-19T00:00:00'
where Tipo = 3 and Folio like '2%00%3'
---
INSERT INTO Visita
   (VisitaClave,DiaClave,ClienteClave,VendedorID,RUTClave
   ,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS
   ,MFechaHora,MUsuarioID)
VALUES('8E653A3EC935B51A','19/10/2010','020009','2O6M+W8LUNMWJC2','R02'
   ,1,'2010-10-19T00:00:00','2010-10-19T00:00:00',1,0,0,0,NULL
   ,GETDATE(),'2O6M+QCBPI3G1C1')

update TransProd set VisitaClave = '8E653A3EC935B51A', DiaClave = '19/10/2010', MUsuarioID = '2O6M+QCBPI3G1C1', 
	FechaHoraAlta = '2010-10-19T00:00:00', FechaCaptura = '2010-10-19T00:00:00'
where Tipo = 3 and Folio like '2%00%2'
---
INSERT INTO Visita
   (VisitaClave,DiaClave,ClienteClave,VendedorID,RUTClave
   ,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS
   ,MFechaHora,MUsuarioID)
VALUES('A74643A1D5969443','07/10/2010','020009','2O6M+W8LUNMWJC2','R02'
   ,1,'2010-10-07T00:00:00','2010-10-07T00:00:00',1,0,0,0,NULL
   ,GETDATE(),'2O6M+QCBPI3G1C1')

update TransProd set VisitaClave = 'A74643A1D5969443', DiaClave = '07/10/2010', MUsuarioID = '2O6M+QCBPI3G1C1', 
	FechaHoraAlta = '2010-10-07T00:00:00', FechaCaptura = '2010-10-07T00:00:00'
where Tipo = 3 and Folio like '2%00%1'


select *
from TransProd 
where Tipo = 3 and Folio like '2%00%'
