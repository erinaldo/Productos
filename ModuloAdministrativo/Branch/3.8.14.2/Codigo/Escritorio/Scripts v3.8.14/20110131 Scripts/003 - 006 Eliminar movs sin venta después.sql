
use RouteCPC 

-- select distinct Serie 
delete 
from MovimientosFacturas 
where Status = 'A' and Folio not in (
	select Folio from Ventas where IdCedis = MovimientosFacturas.IdCedis and IdTipoVenta = MovimientosFacturas.IdTipoVenta 
	and Serie = MovimientosFacturas.Serie and Folio = MovimientosFacturas.Folio 
) -- and len(Serie) > 4
