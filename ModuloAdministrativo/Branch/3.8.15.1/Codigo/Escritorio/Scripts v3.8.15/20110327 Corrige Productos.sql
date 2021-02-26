
select IdProducto, Producto, Productos.IdMarca, Marca, Productos.IdGrupo, Grupo, Productos.IdFamilia, Familia,
'update Productos set IdMarca = ' + CAST(Productos.IdMarca as varchar(10)) + ', IdGrupo = ' + CAST(Productos.IdGrupo as varchar(10))
+ ', IdFamilia = ' + CAST(Productos.IdFamilia as varchar(10)) + ' where IdProducto = ' + CAST(Productos.IdProducto as varchar(10)) as SQLStr
from Productos 
left outer join Marcas on Marcas.IdMarca = Productos.IdMarca 
left outer join Grupos on Grupos.IdMarca = Marcas.IdMarca and Grupos.IdGrupo = Productos.IdGrupo 
left outer join Familias on Familias.IdGrupo = Grupos.IdGrupo and Familias.IdFamilia = Productos.IdFamilia 

--select IdProducto, Producto, Productos.IdMarca, Marca, Productos.IdGrupo, Grupo, Productos.IdFamilia, Familia 
--from Productos 
--left outer join Marcas on Marcas.IdMarca = Productos.IdMarca 
--left outer join Grupos on Grupos.IdMarca = Marcas.IdMarca and Grupos.IdGrupo = Productos.IdGrupo 
--left outer join Familias on Familias.IdGrupo = Grupos.IdGrupo and Familias.IdFamilia = Productos.IdFamilia 
--where Marca is null or Grupo is null or Familia is null

--select Marcas.IdMarca, Marca, Grupos.IdGrupo, Grupo, Familias.IdFamilia, Familia 
--from Marcas 
--left outer join Grupos on Grupos.IdMarca = Marcas.IdMarca 
--left outer join Familias on Familias.IdGrupo = Grupos.IdGrupo 
--where Marcas.IdMarca = 3

--update Productos set IdFamilia = 15 where IdMarca = 4 and IdGrupo = 6
--update Familias set IdGrupo = 4 where Familia = 'tampico'
--update Productos set IdGrupo = 4, IdFamilia = 5 where IdMarca = 2
--update Productos set IdGrupo = 5, IdFamilia = 16 where IdMarca = 3