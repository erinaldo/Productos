
exec routeadm.dbo.sel_FacturasImpresion ' ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 12860) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 12863) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 13370) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 13385) or  ( Ventas.IdCedis = 2 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''REM'' and Ventas.Folio = 13896) ', 1, 3

execute Rep_Movimientos 7, '01/01/1900', '01/01/1900', 1
execute Rep_Movimientos2 3, ' and Movimientos.IdMovimiento in ( 7 )', ' and Ventas.Folio = 15878 and Ventas.IdTipoVenta = 2 and Ventas.Serie = ''MXL'' ', 1

select distinct Fecha 
from Ventas
order by Fecha desc
