
update Configuracion set SerieRemisiones = 'REMH' where IdCedis = 3
update Configuracion set SerieRemisiones = 'REML' where IdCedis = 2

update Ventas set Serie = 'REMH' where IdCedis = 3 and Serie = 'REM'
update Ventas set Serie = 'REML' where IdCedis = 2 and Serie = 'REM'

update VentasDetalle set Serie = 'REMH' where IdCedis = 3 and Serie = 'REM'
update VentasDetalle set Serie = 'REML' where IdCedis = 2 and Serie = 'REM'

update VentasRoute set Serie = 'REMH' where IdCedis = 3 and Serie = 'REM'
update VentasRoute set Serie = 'REML' where IdCedis = 2 and Serie = 'REM'

select IdCedis, Serie, MAX(Folio)
from Ventas
where Serie like 'REM%' 
group by IdCedis, Serie