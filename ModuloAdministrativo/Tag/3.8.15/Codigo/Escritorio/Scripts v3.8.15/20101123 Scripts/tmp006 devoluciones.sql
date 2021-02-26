
execute sel_ExistenciaValidaDev 2, 3098, 3, 1, 3072, 1, 8767, 2, 0, 0, 2

select *
-- delete 
from Ventas 
where -- IdCedis = 2 and IdSurtido = 3072 and IdTipoVenta = 1 and Folio = 8767
Serie = 'DEV02'

select *
-- delete 
from VentasDetalle 
where Serie = 'DEV02'

select *
-- delete 
from VentasDevolucion 

