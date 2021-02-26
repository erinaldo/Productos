
select *
-- delete  
from UsuariosModulos 
where Login <> 'SUPER'

-- insert into UsuariosModulos 
select distinct Usuarios.Login, UsuariosModulos.Modulo 
from UsuariosModulos 
inner join Usuarios on Usuarios.Login <> 'SUPER'
where UsuariosModulos.Login = 'SUPER'

select *
-- delete  
from UsuariosDocumentos 
where Login <> 'SUPER'

-- insert into UsuariosDocumentos
select distinct Usuarios.Login, IdDocumento, CargoAbono 
from Documentos 
inner join Usuarios on Usuarios.Login = 'SUPER'

select *
-- delete  
from UsuariosCedis 
where Login <> 'SUPER'

-- insert into UsuariosCedis
select Usuarios.Login, cedis.IdCedis 
from Cedis  
inner join Usuarios on Usuarios.Login <> 'SUPER'


select *
-- delete  
from DocumentosTipo  
where IdDocumento not in ('NR', 'P', 'AN')

select distinct IdCedis, Fecha
from Ventas 
order by Fecha desc, IdCedis 

select *
from Usuarios  