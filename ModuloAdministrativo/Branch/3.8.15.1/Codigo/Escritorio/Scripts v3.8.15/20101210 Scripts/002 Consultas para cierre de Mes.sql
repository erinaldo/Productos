
declare 
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime

set @IdCedis = 2
set @FechaInicial = '20101120'
set @FechaFinal = '20101130'


-- VENTAS SIN IVA
select 'VENTAS DE CONTADO SIN IVA'
select Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto, Productos.CodBarras as Clave, Productos.Producto,
Productos.Conversion as Contenido, SUM(VentasDetalle.Cantidad) as Unidades, SUM(VentasDetalle.Subtotal) as Importe, sum(VentasDetalle.Cantidad * Precio * VentasDetalle.Iva) as Iva
from Surtidos 
inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
	and VentasDetalle.IdTipoVenta = 1 and VentasDetalle.Iva = 0
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal 
group by Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto, Productos.CodBarras, Productos.Producto, Productos.Conversion 
order by Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto

-- VENTAS CON IVA
select 'VENTAS DE CONTADO CON IVA'
select Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto, Productos.CodBarras as Clave, Productos.Producto,
Productos.Conversion as Contenido, SUM(VentasDetalle.Cantidad) as Unidades, SUM(VentasDetalle.Subtotal) as Importe, sum(VentasDetalle.Cantidad * Precio * VentasDetalle.Iva) as Iva
from Surtidos 
inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
	and VentasDetalle.IdTipoVenta = 1 and VentasDetalle.Iva <> 0
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal 
group by Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto, Productos.CodBarras, Productos.Producto, Productos.Conversion 
order by Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto

-- ************************** CREDITOS +++++++++++++++++++++++++++++++++++
-- VENTAS SIN IVA
select 'VENTAS DE CONTADO SIN IVA'
select Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto, Productos.CodBarras as Clave, Productos.Producto,
Productos.Conversion as Contenido, SUM(VentasDetalle.Cantidad) as Unidades, SUM(VentasDetalle.Subtotal) as Importe, sum(VentasDetalle.Cantidad * Precio * VentasDetalle.Iva) as Iva
from Surtidos 
inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
	and VentasDetalle.IdTipoVenta = 2 and VentasDetalle.Iva = 0
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal 
group by Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto, Productos.CodBarras, Productos.Producto, Productos.Conversion 
order by Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto

-- VENTAS CON IVA
select 'VENTAS DE CONTADO CON IVA'
select Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto, Productos.CodBarras as Clave, Productos.Producto,
Productos.Conversion as Contenido, SUM(VentasDetalle.Cantidad) as Unidades, SUM(VentasDetalle.Subtotal) as Importe, sum(VentasDetalle.Cantidad * Precio * VentasDetalle.Iva) as Iva
from Surtidos 
inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta
inner join VentasDetalle on VentasDetalle.IdCedis = Surtidos.IdCedis and VentasDetalle.IdSurtido = Surtidos.IdSurtido 
	and VentasDetalle.IdTipoVenta = 2 and VentasDetalle.Iva <> 0
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha between @FechaInicial and @FechaFinal 
group by Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto, Productos.CodBarras, Productos.Producto, Productos.Conversion 
order by Surtidos.IdCedis, Surtidos.IdRuta, Rutas.Ruta, VentasDetalle.IdProducto

