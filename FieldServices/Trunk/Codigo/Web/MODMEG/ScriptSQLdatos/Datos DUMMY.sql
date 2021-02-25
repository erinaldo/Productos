
INSERT INTO Trabajo VALUES ('clave1','descripcion trabajo 1',1,10,1)
INSERT INTO Trabajo VALUES ('clave2','descripcion trabajo 2',2,11,1)
INSERT INTO Trabajo VALUES ('clave3','descripcion trabajo 3',3,12,1)
INSERT INTO Trabajo VALUES ('clave4','descripcion trabajo 4',4,13,1)
INSERT INTO Trabajo VALUES ('clave5','descripcion trabajo 5',5,14,1)

INSERT INTO Suscriptor VALUES ('SUP1','nombre SUSCRIPTOR 1','calle 1','ext 1','int 1','colonia 1','sector 1',null,null,null,null,null)
INSERT INTO Suscriptor VALUES ('SUP2','nombre SUSCRIPTOR 2','calle 2','ext 1','int 1','colonia 2','sector 1',null,null,null,null,null)
INSERT INTO Suscriptor VALUES ('SUP3','nombre SUSCRIPTOR 3','calle 3','ext 1','int 1','colonia 3','sector 1',null,null,null,null,null)
INSERT INTO Suscriptor VALUES ('SUP4','nombre SUSCRIPTOR 4','calle 4','ext 1','int 1','colonia 4','sector 1',null,null,null,null,null)

INSERT INTO Ciudad VALUES ('TOL','OCCI','Toluca',1)
INSERT INTO Ciudad VALUES ('QTO','OCCI','Queretaro',1)
INSERT INTO Ciudad VALUES ('GTO','OCCI','Guanajuato',1)

INSERT INTO Sucursal VALUES ('TOL','TOL','OCCI','Toluca','111','222',1)
INSERT INTO Sucursal VALUES ('QTO','QTO','OCCI','Queretaro','111','222',1)
INSERT INTO Sucursal VALUES ('GTO','GTO','OCCI','Guanajuato','111','222',1)

INSERT INTO Cuadrilla VALUES ('CUADRILLA1','GDL','cuadrilla 1',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA2','GDL','cuadrilla 2',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA3','GDL','cuadrilla 3',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA4','GDL','cuadrilla 4',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA5','TOL','cuadrilla 5',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA6','TOL','cuadrilla 6',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA7','TOL','cuadrilla 7',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA8','QTO','cuadrilla 8',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA9','QTO','cuadrilla 9',1,1)
INSERT INTO Cuadrilla VALUES ('CUADRILLA10','QTO','cuadrilla 10',1,1)

INSERT INTO Usuario VALUES ('usuario1','Admin','CUADRILLA1','GDL',6,'pass1','Administrador del Sistema 1',1)
INSERT INTO Usuario VALUES ('usuario2','Admin','CUADRILLA2','GDL',6,'pass1','Administrador del Sistema 2',1)
INSERT INTO Usuario VALUES ('usuario3','Admin','CUADRILLA5','TOL',6,'pass1','Administrador del Sistema 3',1)
INSERT INTO Usuario VALUES ('usuario4','Admin','CUADRILLA6','TOL',6,'pass1','Administrador del Sistema 4',1)
INSERT INTO Usuario VALUES ('usuario5','Admin','CUADRILLA8','QTO',6,'pass1','Administrador del Sistema 5',1)
INSERT INTO Usuario VALUES ('usuario6','Admin','CUADRILLA9','QTO',6,'pass1','Administrador del Sistema 6',1)

INSERT INTO Terminal VALUES ('TER1','GDL','numeroserie1','modelo1',1,1,'comentario')
INSERT INTO Terminal VALUES ('TER2','GDL','numeroserie2','modelo1',1,1,'comentario')
INSERT INTO Terminal VALUES ('TER3','TOL','numeroserie3','modelo1',1,1,'comentario')
INSERT INTO Terminal VALUES ('TER4','TOL','numeroserie4','modelo1',1,1,'comentario')

DECLARE @id;
SELECT @id = SELECT newid();
INSERT INTO Jornada VALUES (@id,'usuario1','CUADRILLA1','TER1','numeroeco1','2010-09-22 08:00:00.000','2010-09-22 23:59:59.000',10.0,11,10)
INSERT INTO Visita VALUES (@id,'1734E501-6E03-481C-AAD3-7A1D73978B73','SUP1',null,null,'2010-09-22 10:06:51.853','2010-09-22 11:11:51.853')
SELECT @id = SELECT newid();
INSERT INTO Jornada VALUES (@id,'usuario2','CUADRILLA2','TER2','numeroeco2','2010-09-21 08:00:00.000','2010-09-21 23:59:59.000',10.0,11,10)
INSERT INTO Visita VALUES (@id,'976B035F-C109-4FE9-B813-64720A5BC341','SUP2',null,null,'2010-09-22 12:06:51.853','2010-09-22 14:08:12.853')
SELECT @id = SELECT newid();
INSERT INTO Jornada VALUES (@id,'usuario3','CUADRILLA5','TER3','numeroeco3','2010-09-19 08:00:00.000','2010-09-16 23:59:59.000',10.0,11,10)
INSERT INTO Visita VALUES (@id,'B868E00D-A0F8-461D-86F0-22720B95FCAA','SUP3',null,null,'2010-09-22 13:06:51.853','2010-09-22 14:07:45.853')
SELECT @id = SELECT newid();
INSERT INTO Jornada VALUES (@id,'usuario4','CUADRILLA6','TER4','numeroeco4','2010-09-15 08:00:00.000','2010-09-19 23:59:59.000',10.0,11,10)
INSERT INTO Visita VALUES (@id,'CCF9A6D4-59CC-4DA3-B9F3-76475CE15756','SUP4',null,null,'2010-09-22 08:06:51.853','2010-09-22 10:09:23.853')

INSERT INTO OrdenTrabajo VALUES ('folio','SUP1','CUADRILLA1','5BA9008B-2134-4322-B18E-91B75C65181E','clave1',1,1,1,1,'obseer','2010-09-22 10:00:00.000')
INSERT INTO OrdenTrabajo VALUES ('folio2','SUP2','CUADRILLA2','DA4AC4BD-0952-4ABD-84D1-99B26269D372','clave2',1,1,1,1,'obseer','2010-09-22 12:00:00.000')
INSERT INTO OrdenTrabajo VALUES ('folio3','SUP3','CUADRILLA5','04ED244D-80EF-4D51-9800-4C14030F6723','clave3',1,1,1,1,'obseer','2010-09-22 13:00:00.000')
INSERT INTO OrdenTrabajo VALUES ('folio4','SUP4','CUADRILLA6','BC3366FC-B866-400F-BA2C-D4EB0F4EE840','clave4',1,1,1,1,'obseer','2010-09-22 08:00:00.000')


--delete usuario where claveUsuario != 'super' 
--delete ordentrabajo
--delete visita
--delete jornada
--delete cuadrilla 
--select * from sucursal
--select * from ciudad
--select * from usuario
--select * from valorreferencia
--select * from cuadrilla
















