

-- Envase de Venta
select Ventas.IdSucursal, PRD.ProductoDetClave, SUM(cantidad)
-- VentasDetalle.IdProducto, VentasDetalle.Cantidad, PRO.ProductoClave, PRD.ProductoDetClave  
from Surtidos 
inner join Ventas on Ventas.IdCedis = Surtidos.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where Surtidos.IdCedis = 3 and Surtidos.Fecha >= '20101003' and IdRuta = 3 
group by Ventas.IdSucursal, PRD.ProductoDetClave 
order by Ventas.IdSucursal, PRD.ProductoDetClave 

-- Envases de Consignas Entregadas
select Consignas.IdSucursal, PRD.ProductoDetClave, SUM(Surtido)
from Consignas 
inner join ConsignasDetalle on Consignas.IdCedis = ConsignasDetalle.IdCedis and Consignas.IdConsigna = ConsignasDetalle.IdConsigna 
inner join Productos on Productos.IdProducto = ConsignasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where Consignas.IdCedis = 3 and Consignas.Status in ('E', 'V') and FechaEntrega >= '20101003'
group by Consignas.IdSucursal, PRD.ProductoDetClave
order by Consignas.IdSucursal, PRD.ProductoDetClave

-- Envases de Consignas Devueltas
select Consignas.IdSucursal, PRD.ProductoDetClave, SUM(Surtido)
from Consignas 
inner join ConsignasDetalle on Consignas.IdCedis = ConsignasDetalle.IdCedis and Consignas.IdConsigna = ConsignasDetalle.IdConsigna 
inner join Productos on Productos.IdProducto = ConsignasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where ConsignasDetalle.IdCedis = 3  and Consignas.Status = 'V' and FechaDevolucion >= '20101003'
group by Consignas.IdSucursal, PRD.ProductoDetClave
order by Consignas.IdSucursal, PRD.ProductoDetClave

-- Devoluciones de envase
select Devolucion.IdSucursal, IdProducto, SUM(cantidad)
from Surtidos 
inner join Devolucion on Devolucion.IdCedis = Surtidos.IdCedis and Devolucion.IdSurtido = Surtidos.IdSurtido 
inner join DevolucionDetalle on DevolucionDetalle.IdCedis = Devolucion.IdCedis and DevolucionDetalle.IdDevolucion = Devolucion.IdDevolucion 
where Surtidos.IdCedis = 3 and Fecha >= '20101003'
group by Devolucion.IdSucursal, IdProducto 
order by Devolucion.IdSucursal, IdProducto 

-- Envase de Venta
select Ventas.IdSucursal, cast(VentasDetalle.IdProducto as varchar(10)), SUM(cantidad)
-- VentasDetalle.IdProducto, VentasDetalle.Cantidad, PRO.ProductoClave, PRD.ProductoDetClave  
from Surtidos 
inner join Ventas on Ventas.IdCedis = Surtidos.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
	and VentasDetalle.IdProducto between 30 and 39
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Surtidos.IdCedis = 3 and Surtidos.Fecha >= '20101003' and IdRuta = 3 
group by Ventas.IdSucursal, VentasDetalle.IdProducto 
