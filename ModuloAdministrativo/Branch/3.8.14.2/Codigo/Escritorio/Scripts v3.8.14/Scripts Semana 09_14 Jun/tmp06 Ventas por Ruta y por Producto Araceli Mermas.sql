
select Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, 
VentasDetalle.IdProducto, SUM(Cantidad) as Piezas, SUM(VentasDetalle.Subtotal) as Total, 
Obsequios as Obsequios, isnull(sum(Salida),0) as ObsequiosMerma, Obsequios - isnull(sum(Salida),0) as ObsequiosSinMerma
from Surtidos 
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
inner join SurtidosDetalle on Surtidos.IdCedis = SurtidosDetalle.IdCedis and Surtidos.IdSurtido = SurtidosDetalle.IdSurtido 
	and SurtidosDetalle.IdProducto = VentasDetalle.IdProducto 
left outer join SurtidosCambios on SurtidosCambios.IdCedis = SurtidosDetalle.IdCedis and SurtidosCambios.IdSurtido = SurtidosDetalle.IdSurtido 
where Surtidos.Fecha between '20100518' and '20100518' 
	-- and Surtidos.IdRuta = 100
group by Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta, VentasDetalle.IdProducto, Obsequios
order by Surtidos.IdCedis, Surtidos.Fecha, Surtidos.IdRuta 

