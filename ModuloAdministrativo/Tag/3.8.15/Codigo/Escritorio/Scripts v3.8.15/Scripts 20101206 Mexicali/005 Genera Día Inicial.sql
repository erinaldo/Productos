

insert into StatusDia values (3, '20101207', 'A', 'Inicio de Operaciones')

insert into InventarioKardex 
select 3, '20101210', idproducto, 0,0,0, 0,0,0, 0,0,0, 0
from Productos 
where Status = 'A'

--select * from InventarioKardex where fecha = '20101210'

exec up_ActualizaKardex 3, '20101210', 0, 1

update InventarioKardex set Inicial = INVF.Cantidad   
from InventarioFisico INVF, InventarioKardex INVK
where INVF.IdCedis = INVK.IdCedis and INVF.IdProducto = INVK.IdProducto 
	and INVF.Fecha = '20101209' and INVK.Fecha = '20101210'


/*
*/
