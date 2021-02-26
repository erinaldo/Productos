
declare @DiaClave as varchar(10), @DiaReparto as varchar(10)

set @DiaClave = '06'
set @DiaReparto = '01'

select clienteclave, orden -- count(ClienteClave)
from secuencia 
where rutclave in ('10099', '10110')
and frecuenciaclave = @DiaClave
order by clienteclave, orden 

select clienteclave, orden -- count(ClienteClave)
from secuencia 
where rutclave in ('10114')
and frecuenciaclave = @DiaReparto
order by clienteclave, orden 

