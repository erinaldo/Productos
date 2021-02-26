
select distinct fl.factura, fl.CLIENTE, fl.NOMBRE, fl.serie, fl.folio, Ventas.IdSurtido 
from  FacturasCOBASURENC   FL 
inner join VentasDetalle VenDet on VenDet.Cantidad = FL.CANTIDAD and VenDet.Precio - FL.PRECIO between -1 and 1
inner join Ventas on FL.CLIENTE = Ventas.IdSucursal AND Ventas.Fecha = FL.FECHA 
	AND Ventas.Serie = VenDet.Serie and Ventas.Folio = VenDet.Folio and Ventas.IdSurtido = VenDet.IdSurtido -- - Ventas.Subtotal BETWEEN -1 AND 1
--left outer join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
where fl.FECHA between '20100528' and '20100531'
-- having sum(FL.SUBTOTAL) - ventas.subtotal between -1 and 1
order by fl.Serie, fl.Folio 

select fecha, FACTURA, SUM(subtotal), CLIENTE, serie, folio 
from  FacturasCOBASUR  FL 
where fl.FECHA between '20100528' and '20100531'
group by fecha, FACTURA, CLIENTE, serie, folio 
order by fecha, FACTURA 

/*
select fl.CLIENTE, fl.NOMBRE,  sum(FL.SUBTOTAL), Ventas.IdSurtido, ventas.IdSucursal, NombreSucursal, Ventas.Subtotal, Iva, Total
from  FacturasLACTEOS FL 
left outer join Ventas on FL.Serie = Ventas.Serie collate Traditional_Spanish_CI_AS
	and FL.Folio = Ventas.Folio and Ventas.Fecha = FL.FECHA 
left outer join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
where fl.FECHA between '20100528' and '20100531'
group by Ventas.IdSurtido, fl.FECHA, ventas.IdSucursal, NombreSucursal, Ventas.Subtotal, Iva, Total, fl.CLIENTE, fl.NOMBRE
-- having sum(FL.SUBTOTAL) - ventas.subtotal between -1 and 1
-- order by Ventas.Serie, Ventas.Folio 

select fl.CLIENTE, fl.NOMBRE,  sum(FL.SUBTOTAL), Ventas.IdSurtido, ventas.IdSucursal, NombreSucursal, Ventas.Subtotal, Iva, Total
from  FacturasCOBASUR  FL 
left outer join Ventas on FL.Serie = Ventas.Serie collate Traditional_Spanish_CI_AS
	and FL.Folio = Ventas.Folio and Ventas.Fecha = FL.FECHA 
left outer join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
where fl.FECHA between '20100528' and '20100531'
group by Ventas.IdSurtido, fl.FECHA, ventas.IdSucursal, NombreSucursal, Ventas.Subtotal, Iva, Total, fl.CLIENTE, fl.NOMBRE
-- having sum(FL.SUBTOTAL) - ventas.subtotal between -1 and 1
-- order by Ventas.Serie, Ventas.Folio 

*/