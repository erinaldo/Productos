
select SurtidosDevolucion.IdProducto, sum(Cantidad)
from (select Rutas.IdCedis, Rutas.IdRuta, (
	select top 1 IdSurtido 
	from Surtidos 
	where Surtidos.IdCedis = 3 and Surtidos.Fecha = '20110103' and Surtidos.IdRuta = Rutas.IdRuta 
	order by IdSurtido desc ) as IdSurtido
from Rutas 
where Rutas.IdCedis = 3 ) as SurtidosR, Surtidos, SurtidosDevolucion 
where Surtidos.IdCedis = SurtidosR.IdCedis and Surtidos.IdSurtido = SurtidosR.IdSurtido and Surtidos.Fecha = '20110103'
	and Surtidos.IdCedis = SurtidosDevolucion.IdCedis and Surtidos.IdSurtido = SurtidosDevolucion.IdSurtido
	and SurtidosDevolucion.IdTipoDevolucion in (select IdTipoDevolucion from TipoDevolucion where EnRuta = 1)
--	and SurtidosDevolucion.IdProducto = @IdProducto 
group by SurtidosDevolucion.IdProducto 

select IdProducto, SUM(SurtidosCargas.Cantidad) 
from Cargas 
inner join SurtidosCargas on Cargas.IdCedis = SurtidosCargas.IdCedis and Cargas.IdSurtido = SurtidosCargas.IdSurtido 
	and Cargas.IdCarga = SurtidosCargas.IdCarga
where Cargas.IdCedis = 3 and Cargas.Fecha = '20110104' and Cargas.IdCarga = 1
group by IdProducto

select Cargas.IdSurtido, IdProducto, SurtidosCargas.Cantidad 
from Cargas 
inner join SurtidosCargas on Cargas.IdCedis = SurtidosCargas.IdCedis and Cargas.IdSurtido = SurtidosCargas.IdSurtido 
	and Cargas.IdCarga = SurtidosCargas.IdCarga and SurtidosCargas.IdProducto = 1 and SurtidosCargas.Cantidad = 288
where Cargas.IdCedis = 3 and Cargas.Fecha = '20110104' and Cargas.IdCarga = 1
--group by IdProducto
