
select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, Devolucion.IdDevolucion 
from Surtidos 
inner join Devolucion on Surtidos.IdCedis = Devolucion.IdCedis and Surtidos.IdSurtido = Devolucion.IdSurtido 
where Surtidos.IdCedis = 2

select *
from Route.dbo.TransProd 
where Tipo = 3 and isnumeric(Folio ) = 1 and Folio like '2%'
