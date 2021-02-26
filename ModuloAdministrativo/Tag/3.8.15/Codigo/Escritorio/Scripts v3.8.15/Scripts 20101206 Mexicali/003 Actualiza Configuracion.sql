
use RouteADM 

update Configuracion set IdCedis = 3, Cedis = 'MEXICALI', SerieFacturasCredito = 'MXL', SerieFacturasContado = 'MXL',
	SerieRemisiones = 'REM03', SerieDevoluciones = 'DEV03'

select *
from Configuracion 

update Cedis set IdCedis = 3,  Cedis = 'MEXICALI', RCedis = 'MEXICALI'

select *
from Cedis 

update Usuarios set IdCedis = 3 where Login = 'SUPER'

update UsuariosModulos set IdCedis = 3 where Login = 'SUPER'

select *
from UsuariosModulos 


