
insert into RouteCPC.dbo.Cuentas values ('BANCO',			3, 1, '1101 0001')
insert into RouteCPC.dbo.Cuentas values ('VTALIQ',			3, 1, '4100 0003 0001')
insert into RouteCPC.dbo.Cuentas values ('VTAAGUA',			3, 2, '4100 0005 0001')
insert into RouteCPC.dbo.Cuentas values ('VTAAGUASAB',		3, 3, '4100 0006 0001')
insert into RouteCPC.dbo.Cuentas values ('IVA',				3, 1, '2103')
insert into RouteCPC.dbo.Cuentas values ('CVTALIQ',			3, 1, '5100')
insert into RouteCPC.dbo.Cuentas values ('CVTAAGUA',		3, 1, '5400')
insert into RouteCPC.dbo.Cuentas values ('DCTOS',			3, 1, '4400')
insert into RouteCPC.dbo.Cuentas values ('DCTOSA',			3, 1, '4600')

insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 3,  '1105 0006 017 008')
insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 11, '1105 0006 005 005')
insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 12, '1105 0006 006 003')
insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 31, '1105 0006 012 013')
insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 32, '1105 0006 013 004')
insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 33, '1105 0006 014 004')
insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 34, '1105 0006 015 013')
insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 35, '1105 0006 016 004')
insert into RouteCPC.dbo.Cuentas values ('RUTA',			3, 36, '1105 0006 017 005')

update Cuentas set Cuenta = REPLACE(Cuenta,' ','')

select *
from RouteCPC.dbo.Cuentas 

