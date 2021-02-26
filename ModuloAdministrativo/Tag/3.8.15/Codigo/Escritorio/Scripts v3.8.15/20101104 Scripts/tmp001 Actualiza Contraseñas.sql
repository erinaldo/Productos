
declare @Usuario as varchar(8), @Password as varchar(10)


set @Usuario = upper('bdelapaz')
set @Password = '800000'

update routeadm.dbo.Usuarios  
	set Password = .dbo.FNCrypt (@Password)
where Login = @Usuario

--insert into RouteCPC.dbo.Usuarios values (@Usuario, 999, @Password, 'KARINA', 'VARGAS', 'NORIEGA', 1, 'A')

update RouteCPC.dbo.Usuarios 
	set Password = .dbo.FNCrypt (@Password)
where Login = @Usuario

select IdCedis, Login, .dbo.FNCrypt( Password), Nombre, ApPaterno, ApMaterno,  TipoUsuario,
case TipoUsuario
	when 0 then 'Usuario Administrador'
	when 1 then 'Usuario Liquidador'
	when 2 then 'Usuario General'
end as 'DescTipoUsuario'
from RouteADM.dbo.Usuarios 
where Login = @Usuario 

select IdCedis, Login, .dbo.FNCrypt( Password), Nombre, ApPaterno, ApMaterno,  TipoUsuario,
case TipoUsuario
	when 0 then 'Usuario Administrador'
	when 1 then 'Usuario Liquidador'
	when 2 then 'Usuario General'
end as 'DescTipoUsuario'
from RouteCPC.dbo.Usuarios 
where Login = @Usuario 

