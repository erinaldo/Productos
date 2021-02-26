	
insert into PreciosDetalle 
select 1, IdProducto, .000000001 
from Productos  
where IdMarca = 2
 
insert into PreciosDetalle 
select 2, IdProducto, .000000001 
from Productos  
where IdMarca = 2


 