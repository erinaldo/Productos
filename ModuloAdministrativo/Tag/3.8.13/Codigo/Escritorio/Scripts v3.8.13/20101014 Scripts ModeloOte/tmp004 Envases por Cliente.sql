
declare @IdCedis as bigint, @Fecha as datetime, @IdRuta as bigint

set @IdCedis = 2
set @Fecha = '20101007'
set @IdRuta = 2

-- Envase de Venta
select 'Ventas' Concepto, Ventas.IdSucursal, PRD.ProductoDetClave, SUM(cantidad) as Cantidad, 
' update Route.dbo.ProductoPrestamoCli set Saldo = Saldo + ' + CAST(SUM(cantidad) as varchar(100)) + ' where ClienteClave = ''' + 
Ventas.IdSucursal + ''' and ProductoClave = ''' + PRD.ProductoDetClave + ''' '  as Script
-- VentasDetalle.IdProducto, VentasDetalle.Cantidad, PRO.ProductoClave, PRD.ProductoDetClave  
from Surtidos 
inner join Ventas on Ventas.IdCedis = Surtidos.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha >= @Fecha and IdRuta = @IdRuta  and PRD.ProductoClave is not null
	--and Ventas.Serie = 'REM' and ventas.Folio  = 49
group by Ventas.IdSucursal, PRD.ProductoDetClave 
-- order by Ventas.IdSucursal, PRD.ProductoDetClave 

union

-- Envases de Consignas Entregadas
select 'Cons. Entregadas' Concepto, Consignas.IdSucursal, PRD.ProductoDetClave, SUM(Surtido) as Cantidad, 
' update Route.dbo.ProductoPrestamoCli set Saldo = Saldo + ' + CAST(SUM(Surtido) as varchar(100)) + ' where ClienteClave = ''' + 
Consignas.IdSucursal + ''' and ProductoClave = ''' + PRD.ProductoDetClave + ''' '  as Script
from Consignas 
inner join ConsignasDetalle on Consignas.IdCedis = ConsignasDetalle.IdCedis and Consignas.IdConsigna = ConsignasDetalle.IdConsigna 
inner join Productos on Productos.IdProducto = ConsignasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where Consignas.IdCedis = @IdCedis and Consignas.Status in ('E', 'V') and FechaEntrega >= @Fecha and PRD.ProductoClave is not null
group by Consignas.IdSucursal, PRD.ProductoDetClave
-- order by Consignas.IdSucursal, PRD.ProductoDetClave

union

-- Envases de Consignas Devueltas
select 'Cons. Devueltas' Concepto, Consignas.IdSucursal, PRD.ProductoDetClave, SUM(Surtido) * -1 as Cantidad, 
' update Route.dbo.ProductoPrestamoCli set Saldo = Saldo - ' + CAST(SUM(Surtido) as varchar(100)) + ' where ClienteClave = ''' + 
Consignas.IdSucursal + ''' and ProductoClave = ''' + PRD.ProductoDetClave + ''' '  as Script
from Consignas 
inner join ConsignasDetalle on Consignas.IdCedis = ConsignasDetalle.IdCedis and Consignas.IdConsigna = ConsignasDetalle.IdConsigna 
inner join Productos on Productos.IdProducto = ConsignasDetalle.IdProducto 
inner join Route.dbo.Producto PRO on cast(PRO.ProductoClave as int) = Productos.IdProducto 
left outer join Route.dbo.ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave <> PRD.ProductoDetClave 
	AND PRD.Factor = 1 
where ConsignasDetalle.IdCedis = @IdCedis  and Consignas.Status = 'V' and FechaDevolucion >= @Fecha and PRD.ProductoClave is not null
	--and ConsignasDetalle.IdConsigna = 2
group by Consignas.IdSucursal, PRD.ProductoDetClave
--order by Consignas.IdSucursal, PRD.ProductoDetClave

union

-- Devoluciones de envase
select 'Devolución' Concepto, Devolucion.IdSucursal, IdProducto as ProductoDetClave, SUM(cantidad) * -1 as Cantidad, 
' update Route.dbo.ProductoPrestamoCli set Saldo = Saldo - ' + CAST(SUM(cantidad) as varchar(100)) + ' where ClienteClave = ''' + 
Devolucion.IdSucursal + ''' and ProductoClave = ''' + cast(IdProducto as varchar(10)) + ''' '  as Script
from Surtidos 
inner join Devolucion on Devolucion.IdCedis = Surtidos.IdCedis and Devolucion.IdSurtido = Surtidos.IdSurtido 
inner join DevolucionDetalle on DevolucionDetalle.IdCedis = Devolucion.IdCedis and DevolucionDetalle.IdDevolucion = Devolucion.IdDevolucion 
where Surtidos.IdCedis = @IdCedis and Fecha >= @Fecha
group by Devolucion.IdSucursal, IdProducto 
--order by Devolucion.IdSucursal, IdProducto 

union

-- Envase de Venta
select 'Venta Envase' Concepto, Ventas.IdSucursal, cast(VentasDetalle.IdProducto as varchar(10)) as ProductoDetClave, SUM(cantidad) * -1 as Cantidad, 
' update Route.dbo.ProductoPrestamoCli set Saldo = Saldo - ' + CAST(SUM(cantidad) as varchar(100)) + ' where ClienteClave = ''' + 
Ventas.IdSucursal + ''' and ProductoClave = ''' + cast(VentasDetalle.IdProducto as varchar(10)) + ''' '  as Script
-- VentasDetalle.IdProducto, VentasDetalle.Cantidad, PRO.ProductoClave, PRD.ProductoDetClave  
from Surtidos 
inner join Ventas on Ventas.IdCedis = Surtidos.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
	and VentasDetalle.IdProducto between 30 and 39
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha >= @Fecha and IdRuta = @IdRuta  
group by Ventas.IdSucursal, VentasDetalle.IdProducto 

order by Concepto, IdSucursal, ProductoDetClave 
