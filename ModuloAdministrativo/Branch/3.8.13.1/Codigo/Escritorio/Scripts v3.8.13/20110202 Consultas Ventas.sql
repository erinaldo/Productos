

declare @FechaInicial as datetime, @FechaFinal as datetime

set @FechaInicial = '20110103'
set @FechaFinal = '20110103'

-- A NIVEL RUTA, SUCURSAL, PRODUCTO CON CAMBIOS FÍSICOS Y PROMOCIONES

select FNDias.IdCedis, FNDias.Fecha, case isnull(Surtidos.IdRuta,0) when 0 then cast(right(Visita.RUTClave,4) as bigint) else Surtidos.IdRuta end as IdRuta, 
FNDias.IdSucursal, FNDias.NombreSucursal, FNDias.IdProducto, FNDias.Producto,
isnull(SUM(VentasDetalle.Cantidad*isnull(KgLts,0)),0) as VentaLitros, isnull(SUM(VentasDetalle.Cantidad),0) as VentaPiezas, isnull(sum(VentasDetalle.Total),0) as Importe,
isnull(FNPromo.Cantidad*isnull(KgLts,0),0) as LitrosObsequiados, isnull(FNPromo.Cantidad,0) as PiezasObsequiadas, isnull(FNPromo.Cantidad*ISNULL(PVig.Precio,0),0) as ValorObsequios, 
isnull(FNCambios.Cantidad*isnull(KgLts,0),0) as LitrosCambios, isnull(FNCambios.Cantidad,0) as PiezasCambios, isnull(FNCambios.Cantidad*ISNULL(PVig.Precio,0),0) as ValorCambios
from FN_DiasSucursalProducto (@FechaInicial, @FechaFinal) FNDias
left outer join Ventas on Ventas.IdCedis = FNDias.IdCedis and Ventas.Fecha = FNDias.Fecha and Ventas.IdSucursal <> '' and Ventas.IdSucursal = FNDias.IdSucursal 
left outer join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido 
left outer join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdProducto = FNDias.IdProducto 
left outer join FN_RouteObsequiosPromo (@FechaInicial, @FechaFinal) FNPromo on FNDias.IdCedis = FNPromo.IdCedis and FNDias.Fecha = FNPromo.Fecha 
	and FNDias.IdSucursal = FNPromo.ClienteClave and FNDias.IdProducto = cast(FNPromo.ProductoClave as bigint) 
left outer join FN_RouteObsequiosCambios (@FechaInicial, @FechaFinal) FNCambios on FNDias.IdCedis = FNCambios.IdCedis and FNDias.Fecha = FNCambios.Fecha 
	and FNDias.IdSucursal = FNCambios.ClienteClave and FNDias.IdProducto = cast(FNCambios.ProductoClave as bigint) 
left outer join Route.dbo.ProductoUnidad PUnidad on cast(PUnidad.ProductoClave as bigint) = FNDias.IdProducto and PUnidad.PRUTipoUnidad = '3'
left outer join Route.dbo.PrecioProductoVig PVig on PVig.PrecioClave = '1' and cast(PVig.ProductoClave as bigint) = FNDias.IdProducto and FNDias.Fecha between PVig.PPVFechaInicio and PVig.FechaFin 
left outer join Route.dbo.Dia Dia on Dia.FechaCaptura = FNDias.Fecha 
left outer join Route.dbo.Visita Visita on Dia.DiaClave = Visita.DiaClave and Visita.ClienteClave = FNDias.IdSucursal 
where FNDias.Fecha between @FechaInicial and @FechaFinal
group by FNDias.IdCedis, FNDias.Fecha, Visita.RUTClave, Surtidos.IdRuta, FNDias.IdSucursal, FNDias.NombreSucursal, FNDias.IdProducto, FNDias.Producto, FNPromo.Cantidad, FNCambios.Cantidad, PUnidad.KgLts, PVig.Precio  
having SUM(VentasDetalle.Total) is not null or FNPromo.Cantidad is not null or FNCambios.Cantidad is not null
order by FNDias.IdCedis, FNDias.Fecha, IdRuta, FNDias.IdSucursal, FNDias.IdProducto

-- A NIVEL RUTA, PRODUCTO CON CAMBIOS FÍSICOS Y PROMOCIONES

select FNDias.IdCedis, FNDias.Fecha, case isnull(Surtidos.IdRuta,0) when 0 then cast(right(Visita.RUTClave,4) as bigint) else Surtidos.IdRuta end as IdRuta, 
FNDias.IdProducto, FNDias.Producto,
isnull(SUM(VentasDetalle.Cantidad*isnull(KgLts,0)),0) as VentaLitros, isnull(SUM(VentasDetalle.Cantidad*isnull(KgLts,0)),0) + isnull(FNPromo.Cantidad*isnull(KgLts,0),0) as 'LitrosVta+Obs', 
isnull(SUM(VentasDetalle.Cantidad),0) + isnull(FNPromo.Cantidad,0) as 'PiezasVta+Obs', isnull(sum(VentasDetalle.Total),0) as Importe,
isnull(SUM(VentasDetalle.Cantidad*isnull(KgLts,0)),0) as VentaLitros, isnull(SUM(VentasDetalle.Cantidad),0) as VentaPiezas, 
isnull(sum(VentasDetalle.Total),0) as Importe,
isnull(FNPromo.Cantidad*isnull(KgLts,0),0) as LitrosObsequiados, isnull(FNPromo.Cantidad,0) as PiezasObsequiadas, isnull(FNPromo.Cantidad*ISNULL(PVig.Precio,0),0) as ValorObsequios, 
isnull(FNCambios.Cantidad*isnull(KgLts,0),0) as LitrosCambios, isnull(FNCambios.Cantidad,0) as PiezasCambios, isnull(FNCambios.Cantidad*ISNULL(PVig.Precio,0),0) as ValorCambios
from FN_DiasSucursalProducto (@FechaInicial, @FechaFinal) FNDias
left outer join Ventas on Ventas.IdCedis = FNDias.IdCedis and Ventas.Fecha = FNDias.Fecha and Ventas.IdSucursal <> '' and Ventas.IdSucursal = FNDias.IdSucursal 
left outer join Surtidos on Surtidos.IdCedis = Ventas.IdCedis and Surtidos.IdSurtido = Ventas.IdSurtido 
left outer join VentasDetalle on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido
	and VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdProducto = FNDias.IdProducto 
left outer join FN_RouteObsequiosPromo (@FechaInicial, @FechaFinal) FNPromo on FNDias.IdCedis = FNPromo.IdCedis and FNDias.Fecha = FNPromo.Fecha 
	and FNDias.IdSucursal = FNPromo.ClienteClave and FNDias.IdProducto = cast(FNPromo.ProductoClave as bigint) 
left outer join FN_RouteObsequiosCambios (@FechaInicial, @FechaFinal) FNCambios on FNDias.IdCedis = FNCambios.IdCedis and FNDias.Fecha = FNCambios.Fecha 
	and FNDias.IdSucursal = FNCambios.ClienteClave and FNDias.IdProducto = cast(FNCambios.ProductoClave as bigint) 
left outer join Route.dbo.ProductoUnidad PUnidad on cast(PUnidad.ProductoClave as bigint) = FNDias.IdProducto and PUnidad.PRUTipoUnidad = '3'
left outer join Route.dbo.PrecioProductoVig PVig on PVig.PrecioClave = '1' and cast(PVig.ProductoClave as bigint) = FNDias.IdProducto and FNDias.Fecha between PVig.PPVFechaInicio and PVig.FechaFin 
left outer join Route.dbo.Dia Dia on Dia.FechaCaptura = FNDias.Fecha 
left outer join Route.dbo.Visita Visita on Dia.DiaClave = Visita.DiaClave and Visita.ClienteClave = FNDias.IdSucursal 
where FNDias.Fecha between @FechaInicial and @FechaFinal
group by FNDias.IdCedis, FNDias.Fecha, Visita.RUTClave, Surtidos.IdRuta, FNDias.IdProducto, FNDias.Producto,FNPromo.Cantidad, FNCambios.Cantidad, PUnidad.KgLts, PVig.Precio  
having SUM(VentasDetalle.Total) is not null or FNPromo.Cantidad is not null or FNCambios.Cantidad is not null
order by FNDias.IdCedis, FNDias.Fecha, IdRuta, FNDias.IdProducto

