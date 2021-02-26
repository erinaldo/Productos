
select *
-- delete 
from SurtidosDenominacion 
where IdCedis = 3 and IdSurtido = 1640

select distinct Surtidos.IdCedis, Surtidos.IdSurtido, IdRuta, Fecha, IdCajero 
from Surtidos 
inner join SurtidosDenominacion on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
where Surtidos.IdCedis  = 3 and IdRuta in (3) and Surtidos.Fecha between '20101001' and '20101006'
order by Fecha desc

select Surtidos.IdCedis, Surtidos.IdSurtido, IdRuta, Fecha, IdCajero, SUM(Cantidad * IdDenominacion)
from Surtidos 
inner join SurtidosDenominacion on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
where Surtidos.IdCedis  = 3 and IdRuta in (3) and Surtidos.Fecha between '20101001' and '20101006'
group by Surtidos.IdCedis, Surtidos.IdSurtido, IdRuta, Fecha, IdCajero
