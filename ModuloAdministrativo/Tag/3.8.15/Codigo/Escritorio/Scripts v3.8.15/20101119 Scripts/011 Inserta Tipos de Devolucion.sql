
insert into TipoDevolucion values (1, 'En Ruta', 1, GETDATE(), 'A')
insert into TipoDevolucion values (2, 'En Almacén', 0, GETDATE(), 'A')

select *
from TipoDevolucion
