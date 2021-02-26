
use RouteADM 

insert into Modulo values ('CONSIG', 'Registro de Consignas')
insert into GrupoModulos values ('GCONS', 'Consignas', 3, 'A')
insert into ModuloGrupo values ('GCONS', 'CONSIG')

insert into Modulo values ('PEDID', 'Registro de Pedidos')
insert into GrupoModulos values ('GPEDID', 'Pedidos', 3, 'A')
insert into ModuloGrupo values ('GPEDID', 'PEDID')

insert into UsuariosModulos values (2, 'SUPERL', 'CONSIG')
insert into UsuariosModulos values (3, 'SUPER',  'CONSIG')

--select * from UsuariosModulos 
--select * from ModuloGrupo 