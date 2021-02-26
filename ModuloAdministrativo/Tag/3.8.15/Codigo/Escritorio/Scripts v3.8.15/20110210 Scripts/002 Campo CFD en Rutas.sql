
use RouteADM 

alter table Rutas
add CFD bit

Go

update Rutas set CFD = 0

select * from Rutas 