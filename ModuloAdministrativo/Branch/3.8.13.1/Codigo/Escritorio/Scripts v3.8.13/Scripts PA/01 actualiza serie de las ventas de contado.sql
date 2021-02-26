
select -- *, 
sum(total)
from ventas
where serie <> 'QR'

-- update ventas set serie ='REM' where serie <> 'QR'
-- update ventas set serie = 'QR' where idtipoventa = 2 and serie = 'QRA'


select -- *, 
sum(total)
from ventasdetalle
where serie <> 'QR'

-- update ventasdetalle set serie = 'REM' where serie <> 'QR'
-- update ventas set serie = 'QR' where idtipoventa = 2 and serie = 'QRA'
