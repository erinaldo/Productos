USE RouteCPC

insert into Documentos 
values ('NR', 'NOTA DE CRÉDITO', 'A', 'A')

insert into DocumentosTipo 
values ('NR', 'NRCF', 'SALDAR VENTAS POR CONSOLIDACIÓN', 'A', 'A')

insert into FacturacionGlobal 
values (1, 'LPCF', 'Cadena Global', 'NR', 'NRCF')

select * from DocumentosTipo 

select * from FacturacionGlobal 
