
select * 
-- delete 
from InventarioInicial where IdProducto in ( select IdProducto 
	from Productos 
	where IdGrupo = 2)

select * 
-- delete 
from InventarioFisico where IdProducto in ( select IdProducto 
	from Productos 
	where IdGrupo = 2)

select * 
-- delete 
from InventarioKardex where IdProducto in ( select IdProducto 
	from Productos 
	where IdGrupo = 2)

select * 
-- delete 
from MovimientosFamilias where IdFamilia in  ( select IdFamilia 
	from Familias where IdGrupo = 2 )

select *
-- delete
from Productos 
where IdGrupo = 2
