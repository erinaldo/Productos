
use RouteADM 

delete 
from SurtidosDevolucion 
where IdSurtido in (
	select SURDev.IdSurtido 
	from SurtidosDevolucion SURDev
	left outer join SurtidosDetalle SURDet on SURDev.IdCedis = SURDet.IdCedis and SURDev.IdSurtido = SURDet.IdSurtido 
		and SURDev.IdProducto = SURDet.IdProducto 
	where (SURDet.IdCedis is null or (SURDet.DevBuena = 0 and SURDev.Cantidad <> 0)) and 
		SURDev.IdCedis = SurtidosDevolucion.IdCedis and SURDev.IdSurtido = SurtidosDevolucion.IdSurtido and SURDev.IdProducto = SurtidosDevolucion.IdProducto )

