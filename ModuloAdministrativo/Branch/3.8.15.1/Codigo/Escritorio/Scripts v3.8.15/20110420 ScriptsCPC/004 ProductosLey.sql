
use RouteCPC 

--102011    LECHES, CHOCOLECHE, JUGO JERSEY, TAMPICO CREMA PARA                 CAFE
--102001    CREMA, YOGURT Y MANTEQUILLA
--104147    SUCURSAL PUERTO PEÑASCO  ((3515)) UNICAMENTE LOS PRODUCTOS DEL CODIGO 102011
--106690    SUCURSAL CENTRO DE DISTRIBUCION TODOS LOS PRODUCTOS ((3526))

insert into leyproductos
select IdProducto, 
case idfamilia 
	when 1 then '102011'
	when 2 then '102011'
	when 4 then '102011'
	when 5 then '102011'
	
	when 3 then '102001'
	when 15 then '102001'
	when 17 then '102001'
	when 6 then '102001'
	when 7 then '102001'
	when 8 then '102001'
	when 10 then '102001'
end AS IdProductoLey, IdSucursal, 'SUPER', GETDATE()
from leysucursal 
inner join Productos on Productos.IdProducto > 0 and IdFamilia in (1,2,4,5, 3,15,6,7,8,10,17)
where idsucursal not in ('3515', '3526')

insert into leyproductos
select IdProducto, 
case idfamilia 
	when 1 then '104147'
	when 2 then '104147'
	when 4 then '104147'
	when 5 then '104147'
	
	when 3 then '102001'
	when 15 then '102001'
	when 17 then '102001'
	when 6 then '102001'
	when 7 then '102001'
	when 8 then '102001'
	when 10 then '102001'
end AS IdProductoLey, IdSucursal, 'SUPER', GETDATE()
from leysucursal 
inner join Productos on Productos.IdProducto > 0  and IdFamilia in (1,2,4,5, 3,15,6,7,8,10,17)
where idsucursal in ('3515')

insert into leyproductos
select IdProducto, 
case idfamilia 
	when 1 then '106690'
	when 2 then '106690'
	when 4 then '106690'
	when 5 then '106690'
	
	when 3 then '106690'
	when 15 then '106690'
	when 17 then '106690'
	when 6 then '106690'
	when 7 then '106690'
	when 8 then '106690'
	when 10 then '106690'
end AS IdProductoLey, IdSucursal, 'SUPER', GETDATE()
from leysucursal 
inner join Productos on Productos.IdProducto > 0  and IdFamilia in (1,2,4,5, 3,15,6,7,8,10,17)
where idsucursal in ('3526')

--select * 
delete 
from leyproductos
where idproductoley is null

--select * from Productos where Productos.IdFamilia in (1,2,4,5) 
--select * from Productos where Productos.IdFamilia in (3,15,6,7,8,10 )
--select * from Productos where IdProducto = 300

