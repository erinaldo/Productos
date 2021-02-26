
declare @IdCedis as bigint, @Fecha as datetime, @IdRuta as bigint

set @IdCedis = 2
set @Fecha = '20101007'
set @IdRuta = 2

-- Envase de Venta
select 'Ventas (+)', 0
union
select PRD.ProductoDetClave, SUM(cantidad)
-- VentasDetalle.IdProducto, VentasDetalle.Cantidad, PRO.ProductoClave, PRD.ProductoDetClave  
from Surtidos 
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha >= @Fecha and IdRuta = @IdRuta  
group by PRD.ProductoDetClave 

-- Envases de Consignas Entregadas
select 'C. Entregadas (+)', 0
union
select PRD.ProductoDetClave, SUM(Surtido)
from Consignas 
inner join ConsignasDetalle on Consignas.IdCedis = ConsignasDetalle.IdCedis and Consignas.IdConsigna = ConsignasDetalle.IdConsigna 
inner join Productos on Productos.IdProducto = ConsignasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where Consignas.IdCedis = @IdCedis and Consignas.Status in ('E', 'V') and FechaEntrega >= @Fecha
group by PRD.ProductoDetClave

-- Envases de Consignas Devueltas
select 'C. Devueltas (-)', 0
union
select PRD.ProductoDetClave, SUM(Surtido)
from Consignas 
inner join ConsignasDetalle on Consignas.IdCedis = ConsignasDetalle.IdCedis and Consignas.IdConsigna = ConsignasDetalle.IdConsigna 
inner join Productos on Productos.IdProducto = ConsignasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where ConsignasDetalle.IdCedis = @IdCedis and Consignas.Status = 'V' and FechaDevolucion >= @Fecha
group by PRD.ProductoDetClave

-- Devoluciones de envase
select 'Devolucion (-)', 0
union
select IdProducto, SUM(cantidad)
from Surtidos 
inner join DevolucionDetalle on DevolucionDetalle.IdCedis = Surtidos.IdCedis and DevolucionDetalle.IdSurtido = Surtidos.IdSurtido 
where Surtidos.IdCedis = @IdCedis and Fecha >= @Fecha
group by IdProducto 

-- Envase de Venta
select 'Ventas Envase (-)', 0
union
select cast(VentasDetalle.IdProducto as varchar(10)), SUM(cantidad)
-- VentasDetalle.IdProducto, VentasDetalle.Cantidad, PRO.ProductoClave, PRD.ProductoDetClave  
from Surtidos 
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
	and VentasDetalle.IdProducto between 30 and 39
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha >= @Fecha and IdRuta = @IdRuta  
group by VentasDetalle.IdProducto 

--select *
--from Surtidos
--where IdSurtido = 1649

--select *
--from Consignas 
--where IdRutaEntrega = 3 and FechaEntrega >= '20101006'

--select *
--from Consignas 
--where IdRutaDevolucion = 3 and FechaDevolucion >= '20101006'

