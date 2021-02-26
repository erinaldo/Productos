alter table TipoMerma
add Aplica bit

delete from TipoMerma 

insert into tipomerma values (1, 'Rotos', 1, getdate(), 'A', 1)
insert into tipomerma values (2, 'Vacios', 2, getdate(), 'A', 1)
insert into tipomerma values (3, 'Mal Sellados', 3, getdate(), 'A', 0)
insert into tipomerma values (4, 'Rosca Dañada', 4, getdate(), 'A', 0)
insert into tipomerma values (5, 'Caducado', 5, getdate(), 'A', 0)
insert into tipomerma values (6, 'Malos', 6, getdate(), 'A', 0)
insert into tipomerma values (7, 'Caídos', 7, getdate(), 'A', 0)
insert into tipomerma values (8, 'Sin Tapón', 8, getdate(), 'A', 0)
insert into tipomerma values (9, 'Otro', 9, getdate(), 'A', 0)
insert into tipomerma values (10, 'Inflado', 10, getdate(), 'A', 0)
insert into tipomerma values (11, 'Aplastado', 11, getdate(), 'A', 0)
