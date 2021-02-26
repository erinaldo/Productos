use RouteADM 

insert into ProductosImpuestos 
select IdProducto, 1 
from Productos where Iva = 0

insert into ProductosImpuestos 
select IdProducto, 2 
from Productos where Iva <> 0

select *
from ProductosImpuestos 

