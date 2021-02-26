
select Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, Ventas.IdSucursal, ClienteSucursal.NombreSucursal,
VentasDetalle.IdProducto, SUM(Cantidad) as Piezas, SUM(VentasDetalle.Subtotal) as Total
from Surtidos 
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
inner join Ventas on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido 
	and Ventas.Serie = VentasDetalle.Serie and Ventas.Folio = VentasDetalle.Folio 
inner join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
where Surtidos.Fecha  between '20100414' and '20100414' 
group by Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, VentasDetalle.IdProducto, Ventas.IdSucursal, ClienteSucursal.NombreSucursal
order by Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta 
