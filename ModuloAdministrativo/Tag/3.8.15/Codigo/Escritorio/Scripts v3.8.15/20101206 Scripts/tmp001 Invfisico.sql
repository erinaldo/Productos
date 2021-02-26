
select -- SurtidosR.IdCedis, SurtidosR.IdRuta, SurtidosR.IdSurtido, 
SurtidosDevolucion.IdProducto, sum(Cantidad)
from (select Rutas.IdCedis, Rutas.IdRuta, (
	select top 1 IdSurtido 
	from Surtidos 
	where Surtidos.IdCedis = 2 and Surtidos.Fecha = '20101207' and Surtidos.IdRuta = Rutas.IdRuta 
	order by IdSurtido desc ) as IdSurtido
from Rutas 
where Rutas.IdCedis = 2 ) as SurtidosR, Surtidos, SurtidosDevolucion 
where Surtidos.IdCedis = SurtidosR.IdCedis and Surtidos.IdSurtido = SurtidosR.IdSurtido and Surtidos.Fecha = '20101207' 
	and Surtidos.IdCedis = SurtidosDevolucion.IdCedis and Surtidos.IdSurtido = SurtidosDevolucion.IdSurtido
	and SurtidosDevolucion.IdTipoDevolucion in (select IdTipoDevolucion from TipoDevolucion where EnRuta = 1)
group by SurtidosDevolucion.IdProducto 


--select SurtidosDevolucion.IdProducto, SUM(Cantidad) as Cantidad
--from Surtidos 
--inner join SurtidosDevolucion on Surtidos.IdCedis = SurtidosDevolucion.IdCedis and Surtidos.IdSurtido = SurtidosDevolucion.IdSurtido
--	and SurtidosDevolucion.IdTipoDevolucion in ( select IdTipoDevolucion from TipoDevolucion where EnRuta = 1) 
--where Surtidos.IdCedis = 2 and Surtidos.Fecha = '20101204'
--group by SurtidosDevolucion.IdProducto

