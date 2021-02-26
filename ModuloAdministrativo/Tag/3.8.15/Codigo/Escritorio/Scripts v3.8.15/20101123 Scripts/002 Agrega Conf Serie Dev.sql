
use RouteADM 

alter table Configuracion
add SerieDevoluciones varchar(6)

GO

update Configuracion set SerieDevoluciones = 'DEV02' 

GO

select *
from Configuracion 
