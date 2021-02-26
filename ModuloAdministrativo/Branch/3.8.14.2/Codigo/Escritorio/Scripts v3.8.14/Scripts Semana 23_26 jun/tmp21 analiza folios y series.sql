
----- MODIFICAR SERIES COBASUR
use RouteADM  

select distinct Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Folio, Ventas.Fecha  
from Ventas 
inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and IdMarca = 2
where Ventas.Serie not like 'R%' and Ventas.Serie not like '%X%'
order by Ventas.Fecha  

use RouteCPC 

select distinct Ventas.IdCedis, Ventas.Serie, Ventas.IdTipoVenta, Ventas.Folio, Ventas.Fecha  
from Ventas 
inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie 
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto and IdMarca = 2
where Ventas.Serie not like 'R%' and Ventas.Serie not like '%X%'
order by Ventas.Fecha  

-- COPIAR A EXCEL Y EJECUTAR UPDATE


----- FACTURAS O REMISIONES CON FOLIOS MENOR AL INICIAL

use RouteADM  

select Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, TMP.Folio as FolioMinimo, Ventas.Fecha, 
Ventas.IdCliente, Ventas.IdSucursal, Surtidos.IdRuta, 'REM' + cast(Surtidos.IdRuta as varchar(10)) as SerieNew
from Ventas 
inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido 
inner join tmpSeriesFolios TMP on rtrim(ltrim(TMP.Serie)) = Ventas.Serie collate Traditional_Spanish_CI_AS
where Ventas.Serie not like 'R%' and TMP.Folio > Ventas.Folio -- and Ventas.IdTipoVenta = 1
and Ventas.Serie not like 'EBQ%'
order by Ventas.Serie, Ventas.Folio 

----- VENTAS CON MISMO SERIE Y FOLIO 
use RouteADM  

select serie, folio, COUNT(IdSurtido)
from Ventas 
where serie not like 'R%'
group by Serie, Folio
having COUNT(IdSurtido) > 1

select *
from Ventas 
inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido 
where (Ventas.Serie = 'EBQX' and Folio = 472) or (Ventas.Serie = 'EBQX' and Folio = 473) 

/*

update ventasdetalle set serie = 'R6' where idcedis = 1 and idtipoventa = 1 and folio = 472 and serie = 'EBQX'
update ventasdetalle set serie = 'R6' where idcedis = 1 and idtipoventa = 1 and folio = 473 and serie = 'EBQX'

update ventas set serie = 'R6' where idcedis = 1 and idtipoventa = 1 and folio = 472 and serie = 'EBQX'
update ventas set serie = 'R6' where idcedis = 1 and idtipoventa = 1 and folio = 473 and serie = 'EBQX'

*/

