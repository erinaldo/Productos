
delete from cadenas 
insert into cadenas values (1, 1, 'General', getdate(), 'A')
insert into cadenas values (2, 2, 'General', getdate(), 'A')
insert into cadenas values (3, 3, 'General', getdate(), 'A')

delete from GrupoClientes  
insert into GrupoClientes  values (1, 'General', getdate(), 'A', 1)
insert into GrupoClientes  values (2, 'General', getdate(), 'A', 2)
insert into GrupoClientes  values (3, 'General', getdate(), 'A', 3)

insert into Modulo values ('TCAMB', 'Captura de Tipo de Cambio')
insert into ModuloGrupo values ('GCAT', 'TCAMB')

insert into Modulo values ('PEDID', 'Captura de Pedidos')
insert into ModuloGrupo values ('GLIQ', 'PEDID')

select *
-- delete 
from ModuloGrupo   

-- update InventarioKardex set Inicial = 1000