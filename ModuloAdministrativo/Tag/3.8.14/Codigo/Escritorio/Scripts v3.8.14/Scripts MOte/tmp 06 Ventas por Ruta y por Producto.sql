
select Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, 
VentasDetalle.IdProducto, Productos.Producto, SUM(Cantidad) as Piezas, SUM(Subtotal)/SUM(Cantidad) as Precio, SUM(Subtotal) as Total
from Surtidos 
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Fecha between '20100414' and '20100414' and Surtidos.IdCedis = 3
group by Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, VentasDetalle.IdProducto, Productos.Producto
order by Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta 
