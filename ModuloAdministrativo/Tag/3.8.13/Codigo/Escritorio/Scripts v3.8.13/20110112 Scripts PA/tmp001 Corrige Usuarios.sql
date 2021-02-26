
insert into RouteCPC.dbo.Usuarios

select Login, IdCedis, Password, Nombre, ApPaterno, ApMaterno, TipoUsuario, Status 
from Usuarios 
where Login not in (
	select Login collate Traditional_Spanish_CI_AS from RouteCPC.dbo.Usuarios
) and Status = 'A'

select Login, IdCedis, Password, Nombre, ApPaterno, ApMaterno, TipoUsuario, Status 
from Usuarios 
where Login not in (
	select Login collate Traditional_Spanish_CI_AS from RouteCPC.dbo.Usuarios
) and Status = 'A'

select * from RouteCPC.dbo.Usuarios
