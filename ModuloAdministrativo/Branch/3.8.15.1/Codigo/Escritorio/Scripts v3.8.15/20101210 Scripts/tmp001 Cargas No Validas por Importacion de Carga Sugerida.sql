
select distinct CAR.IdCedis, CAR.IdRuta, Cargas.Fecha, CAR.IdSurtido, CAR.IdCarga, CARDET.IdProducto, SURDET.Surtido,  
SURDET.VentaCredito, SURDET.VentaContado, SURDET.DevBuena + SURDET.DevMala as Devoluciones,
SURDET.Surtido - SURC.Cantidad as Diferencia,
CARDET.Cantidad as Solicitado, CARDET.Cambios, SURC.Cantidad, SURDET.Precio, SURC.Cantidad * SURDET.Precio as Total
from CargasSugeridas CAR
inner join Cargas on Cargas.IdCedis = CAR.IdCedis and Cargas.IdSurtido = CAR.IdSurtido and Cargas.IdCarga = CAR.IdCarga and Cargas.Status = 'A'
inner join CargasSugeridasDetalle CARDET on CAR.IdCedis = CARDET.IdCedis and CAR.IdRuta = CARDET.IdRuta 
	and CAR.FechaCarga = CARDET.FechaCarga and CAR.Tipo = CARDET.Tipo and CAR.Folio = CARDET.Folio 
inner join SurtidosDetalle SURDET on SURDET.IdCedis = CAR.IdCedis and SURDET.IdSurtido = CAR.IdSurtido and SURDET.IdProducto = CARDET.IdProducto 
inner join Productos on Productos.IdProducto = CARDET.IdProducto and Productos.Status = 'A' 
inner join SurtidosCargas SURC on Cargas.IdCedis = SURC.IdCedis and Cargas.IdSurtido = SURC.IdSurtido and Cargas.IdCarga = SURC.IdCarga 
	and SURC.IdProducto = CARDET.IdProducto 
where CAR.IdCedis = 2 and CAR.FechaCarga > '20101120' and Cambios = 0 and SURC.Cantidad <> 0 and (VentaContado <> 0 or VentaCredito <> 0) 
	and VentaContado <= SURC.Cantidad 
order by CAR.IdCedis, CAR.IdRuta, Cargas.Fecha, CAR.IdSurtido, CAR.IdCarga


--select * from CargasSugeridas 
--select * from CargasSugeridasDetalle 
