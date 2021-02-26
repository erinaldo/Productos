declare 
@FechaInicial as datetime,
@FechaFinal as datetime,
@Filtro as varchar(1000)

set @FechaInicial = '20110401'
set @FechaFinal = '20110401'
set @Filtro = ' AND UCTES.Login in (''JBENITEZ'')'

--select * from UsuariosClientes 

SELECT CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente, CTE.RazonSocial AS Cliente, VEN.Serie, VEN.Folio, VEN.Serie + ' ' + cast(VEN.Folio as varchar(20)) as SerieFolio,
	VEN.IdSucursal, NombreSucursal, VEN.Subtotal AS [SubtotalF], VEN.Iva AS [IVAF], VEN.Total AS [TotalF],
	VACR.FechaAcredita, VACR.FechaEntrega, VACR.FolioEntrega, 
	VACR.FolioCliente, VACR.Remision, VACR.Factura, VACR.Status, VACR.Observaciones, UCTES.Login, Usuarios.Nombre + ' ' + Usuarios.ApPaterno  + ' ' + Usuarios.ApMaterno as Nombre 
FROM VentasAcredita VACR 
inner join Ventas VEN on VACR.IdCedis = VEN.IdCedis and VACR.IdTipoVenta = VEN.IdTipoVenta
	and VEN.Serie = VACR.Serie and VEN.Folio = VACR.Folio  
INNER JOIN Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente 		
inner join ClienteSucursal on ClienteSucursal.IdCedis = VEN.IdCedis and ClienteSucursal.IdSucursal = VEN.IdSucursal		
inner join UsuariosClientes UCTES on UCTES.IdCedis = CTE.IdCedis and UCTES.IdCliente = CTE.IdCliente 
inner join Usuarios on Usuarios.Login = UCTES.Login 
INNER JOIN Cedis CED ON VEN.IdCedis = CED.IdCedis
WHERE (VACR.FechaAcredita BETWEEN @FechaInicial and @FechaFinal) AND UCTES.Login = 'JBENITEZ' 
ORDER BY Usuarios.Login, Nombre, VEN.Fecha, VEN.IdCliente, ClienteSucursal.IdSucursal, VEN.Serie, VEN.Folio

--select * from ClienteSucursal  where IdCliente = 3500

--select * from Ventas where IdCliente = 3500
--select * from VentasDetalle where Serie = 'JSY' and Folio in (682, 695, 697)
--select * from VentasAcredita  where Serie = 'JSY' and Folio in (682, 695, 697)

--select * from Productos where CodBarras like '%%' -- IdProducto = 1

--exec Rep_Movimientos 14, '20110301', '20110402', 1


--exec ( 'SELECT CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente, CTE.RazonSocial AS Cliente, VEN.Serie, VEN.Folio, VEN.Serie + '' '' + cast(VEN.Folio as varchar(15)) as SerieFolio,
--			VEN.IdSucursal, NombreSucursal, VEN.Subtotal AS [SubtotalF], VEN.Iva AS [IVAF], VEN.Total AS [TotalF],
--			VACR.FechaAcredita, VACR.FechaEntrega, VACR.FolioEntrega, 
--			VACR.FolioCliente, VACR.Remision, VACR.Factura, VACR.Status, VACR.Observaciones, Usuarios.Login, Usuarios.Nombre + '' '' + Usuarios.ApPaterno  + '' '' + Usuarios.ApMaterno as Nombre 
--		FROM VentasAcredita VACR 
--		inner join Ventas VEN on VACR.IdCedis = VEN.IdCedis and VACR.IdTipoVenta = VEN.IdTipoVenta
--			and VEN.Serie = VACR.Serie and VEN.Folio = VACR.Folio  
--		INNER JOIN Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente 		
--		inner join ClienteSucursal on ClienteSucursal.IdCedis = VEN.IdCedis and ClienteSucursal.IdSucursal = VEN.IdSucursal		
--		inner join UsuariosClientes UCTES on UCTES.IdCedis = CTE.IdCedis and UCTES.IdCliente = CTE.IdCliente 
--		inner join Usuarios on Usuarios.Login = UCTES.Login 
--		INNER JOIN Cedis CED ON VEN.IdCedis = CED.IdCedis
--		WHERE (VACR.FechaAcredita BETWEEN ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''') ' + @Filtro + '
--		ORDER BY Usuarios.Login, Nombre, VEN.Fecha, VEN.IdCliente, ClienteSucursal.IdSucursal, VEN.Serie, VEN.Folio' )


