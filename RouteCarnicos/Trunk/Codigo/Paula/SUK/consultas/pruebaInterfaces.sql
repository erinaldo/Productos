Select * from transprod where transProdId in(Select TransProdId from tmp_ventaFacturada2)
Select * from transprodDetalle where transProdId in(Select TransProdId from tmp_ventaFacturada2)

Delete from TransProd where transprodid in(Select TransProdId from tmp_ventaFacturada)
Delete from TransProdDetalle where transprodid in(Select TransProdId from tmp_ventaFacturada)
delete from tmp_ventaFacturada
delete from tmp_ventaFacturadaDet

insert into tmp_VentaFacturadadet
Select * from tmp_ventaFacturadadet2

insert into tmp_VentaFacturadaDet2
Select * from SK2.dbo.tmp_VentaFacturadaDet

insert into tmp_VentaFacturadaDet
Select * from tmp_ventaFacturadaDet2

Select * from transprod where TransProdID = '0000050000316487'


Select * from tmp_Cliente

select * from cliente where ClienteClave = 'CTEPrueba'

insert into tmp_Cliente VALUES ('CTEPrueba',	NULL,	'CTEPrueba',	'','XAXX010101000','VTA.CDO.(R.CLN-9) .', 	1,	1,	'VTA.CDO.(R.CLN-9)',	'',	'2011-10-01T21:03:00',	NULL,	'VTA.CDO.(R.CLN-9) .', 	1,	9931.4100,	0,	0,	0,	'2012-05-09T17:01:32',	0,	1,	1,	'2012-05-09T17:01:32',	0,	'',	NULL,	NULL)