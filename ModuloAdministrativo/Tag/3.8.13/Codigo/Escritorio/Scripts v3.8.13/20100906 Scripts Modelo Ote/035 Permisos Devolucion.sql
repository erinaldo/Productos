

use RouteADM 

insert into Modulo values ('DEVOL', 'Registro de Devoluciones')
insert into GrupoModulos values ('GDEVOL', 'Devoluciones', 3, 'A')
insert into ModuloGrupo values ('GDEVOL', 'DEVOL')

insert into UsuariosModulos values (2, 'SUPERL', 'DEVOL')
insert into UsuariosModulos values (3, 'SUPER',  'DEVOL')

