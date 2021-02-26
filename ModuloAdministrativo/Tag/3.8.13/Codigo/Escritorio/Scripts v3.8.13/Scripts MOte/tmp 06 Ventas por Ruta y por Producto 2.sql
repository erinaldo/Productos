
select Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, Surtidos.IdRuta, 
VentasDetalle.IdProducto, SUM(Cantidad) as Piezas, SUM(VentasDetalle.Subtotal) as Total, Obsequios as Obsequios
from Surtidos 
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
inner join SurtidosDetalle on Surtidos.IdCedis = SurtidosDetalle.IdCedis and Surtidos.IdSurtido = SurtidosDetalle.IdSurtido 
	and SurtidosDetalle.IdProducto = VentasDetalle.IdProducto 
left outer join SurtidosCambios on SurtidosCambios.IdCedis = Surtidos.IdCedis and SurtidosCambios.IdSurtido = Surtidos.IdSurtido 
	and SurtidosCambios.IdProducto = SurtidosDetalle.IdProducto 
where Surtidos.Fecha between '20100501' and '20100531' 
	-- and Surtidos.IdSurtido = 862
group by Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, Surtidos.IdRuta, VentasDetalle.IdProducto, Obsequios, Salida
order by Surtidos.IdCedis, Surtidos.IdSurtido, Surtidos.Fecha, Surtidos.IdRuta 

