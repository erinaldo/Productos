
insert into RouteSurtidos
select IdCedis, IdSurtido, IdCarga, ISNULL((select MAX(FolioRoute)+1 from RouteSurtidos), 1)
from Cargas 

insert into Route.dbo.tmp_Carga
select Cargas.IdCedis, RouteSurtidos.FolioRoute, replicate('0', 2 - len( DAY(Fecha) ) ) + cast( DAY(Fecha) as varchar(2)) + '/' + 
	replicate('0', 2 - len( month(Fecha) ) ) + cast( month(Fecha) as varchar(2)) + '/' + cast( year(Fecha) as varchar(4)), 
	10, Cargas.IdCarga, 2, 5, 1, GETDATE(), cast( Cargas.IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10))
from Cargas 
inner join RouteSurtidos on RouteSurtidos.IdCedis = Cargas.IdCedis and RouteSurtidos.IdSurtido = Cargas.IdSurtido and RouteSurtidos.IdCarga = Cargas.IdCarga 

update Cargas set IdCarga = IdCarga where IdCedis = 1 and IdSurtido = 1 and IdCarga = 1 

update SurtidosCargas set IdCarga = IdCarga where IdCedis = 1 and IdSurtido = 1 and IdCarga = 1 and IdProducto = 1234567890

select *
from Cargas 

-- delete from RouteSurtidos

select *
-- delete 
from Route.dbo.tmp_Carga  

select *
from Route.dbo.tmp_CargaDetalle 

select *
from Route.dbo.ProductoUnidad 

select idproducto, RANK () over(order by idproducto )
from productos