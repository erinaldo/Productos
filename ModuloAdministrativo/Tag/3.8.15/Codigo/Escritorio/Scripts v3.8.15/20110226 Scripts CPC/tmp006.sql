
exec sel_FacturasImpresion ' ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 12863) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 12860) ', 1, 1

declare @Filtro as varchar(8000), @strCedis as varchar(8000), @strFecha as varchar(8000)--, @ordCedis as varchar(8000), @ordFecha as varchar(8000)

set @strCedis = '1' 
set @strFecha = '1'

if @strCedis <> '' set @strCedis = ' Ventas.IdCedis, '
if @strFecha <> '' set @strFecha = ' Ventas.Fecha, '

set @Filtro = ' ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 12860) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 12863) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 13370) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 13385) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 13896) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 14379) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 14399) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 14615) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 14643) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 14912) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 15144) '

		exec( 'select distinct Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Folio, Ventas.Fecha, Ventas.Total
		from Ventas 
		where ' + @Filtro + ' 
		order by ' + @strCedis + ' ' + @strFecha + ' Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Folio' )

		exec( 'select ' + @strCedis + ' ' + @strFecha + 
		' VentasDetalle.IdProducto as ''Cve. Prod.'', Productos.Producto as ''Producto'', 
		sum(VentasDetalle.Cantidad) as ''Cantidad'', round(VentasDetalle.Precio,3) as ''Precio'', sum(VentasDetalle.Subtotal) as ''Subtotal'', 
		sum(VentasDetalle.Cantidad * VentasDetalle.Precio * VentasDetalle.Iva) as ''Iva'', sum(VentasDetalle.Total) as ''Total'', ''Piezas'' as Unidad
		from VentasDetalle
		inner join Ventas on VentasDetalle.IdCedis = Ventas.IdCedis and VentasDetalle.Serie = Ventas.Serie collate Traditional_Spanish_CI_AS and 
			VentasDetalle.IdTipoVenta = Ventas.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and Ventas.IdSurtido = VentasDetalle.IdSurtido
		inner join VentasTipo on VentasTipo.IdTipoVenta = Ventas.IdTipoVenta
		inner join Productos on VentasDetalle.IdProducto = Productos.IdProducto
		where ' + @Filtro + ' 
		group by ' + @strCedis + ' ' + @strFecha + ' VentasDetalle.IdProducto, Productos.Producto, round(VentasDetalle.Precio,3)
		order by ' + @strCedis + ' ' + @strFecha + ' VentasDetalle.IdProducto')
