

select distinct Rutas.IdRuta, Rutas.Ruta
from Rutas
inner join Cedis on Cedis.IdCedis = Rutas.IdCedis
inner join Route.dbo.Secuencia as Secuencia on Secuencia.RutClave = cast( Rutas.IdCedis as varchar(10) ) + replicate(''0'', 4 - len( Rutas.IdRuta ) ) + cast( Rutas.IdRuta as varchar(10) )
where Rutas.IdCedis = 1
order by Rutas.IdRuta

exec( 'select Rutas.IdCedis, Cedis, Rutas.IdRuta, Rutas.Ruta,
Secuencia.FrecuenciaClave, Descripcion, Secuencia.Orden, Secuencia.ClienteClave,
NombreSucursal, Calle + '' '' + NumExterior + '' '' + NumInterior + '' '' + Colonia + '' '' + Localidad + '' '' + Poblacion + '' '' + Entidad as Domicilio
from Rutas
inner join Cedis on Cedis.IdCedis = Rutas.IdCedis
inner join Route.dbo.Secuencia as Secuencia on Secuencia.RutClave = cast( Rutas.IdCedis as varchar(10) ) + replicate(''0'', 4 - len( Rutas.IdRuta ) ) + cast( Rutas.IdRuta as varchar(10) )
inner join Route.dbo.Frecuencia as Frecuencia on Frecuencia.FrecuenciaClave = Secuencia.FrecuenciaClave
inner join ClienteSucursal on ClienteSucursal.IdCedis = Rutas.IdCedis and ClienteSucursal.IdSucursal = Secuencia.ClienteClave
where Rutas.IdCedis = ' + @IdCedi + '  ' + @Filtro + ' 
order by Rutas.IdRuta, Secuencia.FrecuenciaClave, Secuencia.Orden')
