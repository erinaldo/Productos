
update StatusDia set Status = 'C'
where Fecha = '20101123'

update Surtidos set Status = 'C'
where Fecha = '20101123' and IdSurtido = 3139 -- and IdRuta in (305) 

update Surtidos set Status = 'P'
where Fecha = '20101120' and IdSurtido = 3056 

abre el dia 21, folio 3083 de la ruta 169, 3088 de la ruta 703, y el 3090 de la ruta 723 por fas
abre por favor el dia 22 y los folios : 3114 de la ruta 703, 3116 de la ruta 723, 3109 de la ruta 169 y el 3123 de la ruta 305 por fas
 
select *
from Surtidos 
where Fecha = '20101120'

select *
from StatusDia 
where Fecha = '20101120'