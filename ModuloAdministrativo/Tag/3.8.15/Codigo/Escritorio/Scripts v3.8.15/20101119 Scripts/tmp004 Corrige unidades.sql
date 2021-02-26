
use RouteADM 

delete 
from ProductosUnidad  
where IdProducto not in (select IdProducto from Productos )
--where IdProducto = 91

insert into ProductosUnidad values (76, 'CAJA', 6, 'S', '', 1)
insert into ProductosUnidad values (300, 'CAJA', 1, 'S', '', 1)

update ProductosUnidad set IdUnidad = 'PZA', Divide = 'N'
where IdProducto = 300