
declare @FechaInicial as datetime, @FechaFinal as datetime

set @FechaInicial = '20100910'
set @FechaFinal = '20100910'

select FNDias.IdCedis, FNDias.Fecha, Surtidos.IdRuta, FNDias.IdSucursal, FNDias.NombreSucursal, FNDias.IdProducto, 
isnull(SUM(VentasDetalle.Cantidad),0) as Venta, isnull(sum(VentasDetalle.Total),0) as Total,
isnull(FNPromo.Cantidad,0) as Promo, isnull(FNCambios.Cantidad,0) as Cambios
from FN_DiasSucursalProducto (@FechaInicial, @FechaFinal) FNDias
left outer join Ventas on Ventas.IdCedis = FNDias.IdCedis and Ventas.Fecha = FNDias.Fecha and Ventas.IdSucursal <> '' and Ventas.IdSucursal = FNDias.IdSucursal 
left outer join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido
left outer join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdProducto = FNDias.IdProducto 
left outer join FN_RouteObsequiosPromo (@FechaInicial, @FechaFinal) FNPromo on FNDias.IdCedis = FNPromo.IdCedis and FNDias.Fecha = FNPromo.Fecha 
	and FNDias.IdSucursal = FNPromo.ClienteClave and FNDias.IdProducto = cast(FNPromo.ProductoClave as bigint) 
left outer join FN_RouteObsequiosCambios (@FechaInicial, @FechaFinal) FNCambios on FNDias.IdCedis = FNCambios.IdCedis and FNDias.Fecha = FNCambios.Fecha 
	and FNDias.IdSucursal = FNCambios.ClienteClave and FNDias.IdProducto = cast(FNCambios.ProductoClave as bigint) 
where FNDias.Fecha between @FechaInicial and @FechaFinal 
group by FNDias.IdCedis, FNDias.Fecha, Surtidos.IdRuta, FNDias.IdSucursal, FNDias.NombreSucursal, FNDias.IdProducto, FNPromo.Cantidad, FNCambios.Cantidad 
having SUM(VentasDetalle.Total) is not null or FNPromo.Cantidad is not null or FNCambios.Cantidad is not null
order by FNDias.IdCedis, FNDias.Fecha, Surtidos.IdRuta, FNDias.IdSucursal, FNDias.IdProducto


