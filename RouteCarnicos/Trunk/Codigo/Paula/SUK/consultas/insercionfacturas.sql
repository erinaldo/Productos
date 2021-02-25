
Select * from tmp_DatosFacturacion

Select * from tmp_VentaFacturada 
Select * from tmp_VentaFacturadaDet 

Select * from TransProd 

Select * from Cliente where RazonSocial  like '%RAMIREZ%'
Select * from TransProdDetalle where TransProdID = 'PAU00000AAA83517'
insert into tmp_VentaFacturada 
values('PAU00000AAA83517','04/05/2012', null,'0000118788000001',1,1,'AAA-83517', '2012-05-04T00:00:00',8742.13,8742.13,0,8742.13,8742.13,1,1,'2012-05-04T00:00:00',0,'0244')

insert into tmp_VentaFacturadaDet 
values('PAU00000AAA83517',1,'0000000074',REPLACE(newId(),'-',''),1,null,100,1,62.95,6295,0, 6295)

insert into tmp_VentaFacturadaDet 
values('PAU00000AAA83517',2,'0000000074',REPLACE(newId(),'-',''),1,null,30.69,1,62.95,1931.94,0, 1931.94)

insert into tmp_VentaFacturadaDet 
values('PAU00000AAA83517',3,'0000004390',REPLACE(newId(),'-',''),1,null,6.24,1,24.95,155.69,0, 155.69)

insert into tmp_VentaFacturadaDet 
values('PAU00000AAA83517',4,'0000004394',REPLACE(newId(),'-',''),1,null,18.02,1,19.95,359.50,0, 359.50)


Select * from Producto where  Nombre= 'HIGADO EMBOLSADO SUKARNE'
Select REPLACE(newId(),'-','')

Select len(REPLACE('-','',newId()))

Select * from TransProd where tipo = 8

Select * from CLIFormaVenta  where ClienteClave = '0000118788000001'


