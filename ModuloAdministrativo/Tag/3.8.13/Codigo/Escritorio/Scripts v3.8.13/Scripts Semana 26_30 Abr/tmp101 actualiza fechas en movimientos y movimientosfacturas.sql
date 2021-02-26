
execute sel_Movimientos 4, 3, 'CT', 1

select cast( cast(YEAR(fecha) as varchar(4)) + 
	replicate('0',2-LEN( cast(MONTH(fecha)as varchar(2)))) + cast(MONTH(fecha)as varchar(2)) + 
	replicate('0',2-LEN( cast(day(fecha)as varchar(2)))) + cast(day(fecha)as varchar(2)) as datetime), *
from Movimientos 

update MovimientosFacturas  set Fecha =  cast( cast(YEAR(fecha) as varchar(4)) + 
	replicate('0',2-LEN( cast(MONTH(fecha)as varchar(2)))) + cast(MONTH(fecha)as varchar(2)) + 
	replicate('0',2-LEN( cast(day(fecha)as varchar(2)))) + cast(day(fecha)as varchar(2)) as datetime)
	

select *
from MovimientosFacturas 
