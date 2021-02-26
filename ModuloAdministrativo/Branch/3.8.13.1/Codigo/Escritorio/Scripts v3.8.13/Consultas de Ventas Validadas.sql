

declare @FechaInicial as datetime, @FechaFinal as datetime

set @FechaInicial = '20100601'
set @FechaFinal = '20100605'

-- A Nivel Cliente (cuenta agrupadora)
select Ventas.IdCedis, Ventas.Fecha, Surtidos.IdRuta, Ventas.IdCliente, Clientes.RazonSocial as NombreCliente,
VentasDetalle.IdProducto, 
SUM(Cantidad) as Piezas, SUM(VentasDetalle.Subtotal) as Total
from Ventas 
inner join Clientes on Ventas.IdCedis = Clientes.IdCedis and Ventas.IdCliente = Clientes.IdCliente 
inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido 
inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
      and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Ventas.Fecha between @FechaInicial and @FechaFinal 
group by Ventas.IdCedis, Ventas.Fecha, Surtidos.IdRuta, VentasDetalle.IdProducto, Ventas.IdCliente, Clientes.RazonSocial 
order by Ventas.IdCedis, Ventas.Fecha, Surtidos.IdRuta, Clientes.RazonSocial

-- A Nivel Sucursal (sucursal de cliente)
select Ventas.IdCedis, Ventas.Fecha, Surtidos.IdRuta, Ventas.IdSucursal, NombreSucursal as NombreCliente,
VentasDetalle.IdProducto, 
SUM(Cantidad) as Piezas, SUM(VentasDetalle.Subtotal) as Total
from Ventas 
inner join ClienteSucursal on Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal 
inner join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido 
inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
      and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
where Ventas.Fecha between @FechaInicial and @FechaFinal 
group by Ventas.IdCedis, Ventas.Fecha, Surtidos.IdRuta, VentasDetalle.IdProducto, Ventas.IdSucursal, NombreSucursal 
order by Ventas.IdCedis, Ventas.Fecha, Surtidos.IdRuta, NombreSucursal 

-- A NIVEL SUCURSAL CON CAMBIOS FÍSICOS Y PROMOCIONES
select FNDias.IdCedis, FNDias.Fecha, FNDias.IdSucursal, FNDias.NombreSucursal, FNDias.IdProducto, 
isnull(SUM(VentasDetalle.Cantidad),0) as Venta, isnull(sum(VentasDetalle.Total),0) as Total,
isnull(FNPromo.Cantidad,0) as Promo, isnull(FNCambios.Cantidad,0) as Cambios
from FN_DiasSucursalProducto (@FechaInicial, @FechaFinal) FNDias
left outer join Ventas on Ventas.IdCedis = FNDias.IdCedis and Ventas.Fecha = FNDias.Fecha and Ventas.IdSucursal <> '' and Ventas.IdSucursal = FNDias.IdSucursal 
left outer join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdProducto = FNDias.IdProducto 
left outer join FN_RouteObsequiosPromo (@FechaInicial, @FechaFinal) FNPromo on FNDias.IdCedis = FNPromo.IdCedis and FNDias.Fecha = FNPromo.Fecha 
	and FNDias.IdSucursal = FNPromo.ClienteClave and FNDias.IdProducto = cast(FNPromo.ProductoClave as bigint) 
left outer join FN_RouteObsequiosCambios (@FechaInicial, @FechaFinal) FNCambios on FNDias.IdCedis = FNCambios.IdCedis and FNDias.Fecha = FNCambios.Fecha 
	and FNDias.IdSucursal = FNCambios.ClienteClave and FNDias.IdProducto = cast(FNCambios.ProductoClave as bigint) 
where FNDias.Fecha between @FechaInicial and @FechaFinal 
group by FNDias.IdCedis, FNDias.Fecha, FNDias.IdSucursal, FNDias.NombreSucursal, FNDias.IdProducto, FNPromo.Cantidad, FNCambios.Cantidad 
having SUM(VentasDetalle.Total) is not null or FNPromo.Cantidad is not null or FNCambios.Cantidad is not null
order by FNDias.IdCedis, FNDias.Fecha, FNDias.IdSucursal, FNDias.IdProducto



--select sum(Cantidad) as Piezas, SUM(VentasDetalle.Subtotal) as Total
--from Ventas 
--inner join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido 
--      and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio 
--where Ventas.Fecha between @FechaInicial and @FechaFinal 

