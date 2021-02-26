
		SELECT distinct  Usuarios.Login, Usuarios.Nombre + ' ' + Usuarios.ApPaterno  + ' ' + Usuarios.ApMaterno as Nombre 
		FROM VentasAcredita VACR 
		inner join Ventas VEN on VACR.IdCedis = VEN.IdCedis and VACR.IdTipoVenta = VEN.IdTipoVenta
			and VEN.Serie = VACR.Serie and VEN.Folio = VACR.Folio  
		INNER JOIN Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente 		
		inner join ClienteSucursal on ClienteSucursal.IdCedis = VEN.IdCedis and ClienteSucursal.IdSucursal = VEN.IdSucursal		
		inner join UsuariosClientes UCTES on UCTES.IdCedis = CTE.IdCedis and UCTES.IdCliente = CTE.IdCliente 
		inner join Usuarios on Usuarios.Login = UCTES.Login 
		INNER JOIN Cedis CED ON VEN.IdCedis = CED.IdCedis
		WHERE (VACR.FechaAcredita BETWEEN '20110301' AND '20110327') 
		ORDER BY Nombre 


		SELECT     CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente, CTE.RazonSocial AS Cliente, VEN.Serie, VEN.Folio, VEN.Serie + ' ' + cast(VEN.Folio as varchar(15)) as SerieFolio,
			VEN.IdSucursal, NombreSucursal, VEN.Subtotal AS [SubtotalF], VEN.Iva AS [IVAF], VEN.Total AS [TotalF],
			VACR.FechaAcredita, VACR.FechaEntrega, VACR.FolioEntrega, 
			VACR.FolioCliente, VACR.Remision, VACR.Factura, VACR.Status, VACR.Observaciones, Usuarios.Login, Usuarios.Nombre + ' ' + Usuarios.ApPaterno  + ' ' + Usuarios.ApMaterno as Nombre 
		FROM VentasAcredita VACR 
		inner join Ventas VEN on VACR.IdCedis = VEN.IdCedis and VACR.IdTipoVenta = VEN.IdTipoVenta
			and VEN.Serie = VACR.Serie and VEN.Folio = VACR.Folio  
		INNER JOIN Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente 		
		inner join ClienteSucursal on ClienteSucursal.IdCedis = VEN.IdCedis and ClienteSucursal.IdSucursal = VEN.IdSucursal		
		inner join UsuariosClientes UCTES on UCTES.IdCedis = CTE.IdCedis and UCTES.IdCliente = CTE.IdCliente 
		inner join Usuarios on Usuarios.Login = UCTES.Login 
		INNER JOIN Cedis CED ON VEN.IdCedis = CED.IdCedis
		WHERE (VACR.FechaAcredita BETWEEN '20110301' AND '20110327') 
			and UCTES.Login = 'SUPER'
		ORDER BY Usuarios.Login, Nombre, CED.IdCedis, VEN.Fecha, VEN.IdCliente, ClienteSucursal.IdSucursal, VEN.Serie, VEN.Folio


if @ReporteOrigen = 30 			-- VENTAS ACREDITADAS
begin
	If @Tipo = 1 or @Tipo = 2			-- por fecha
	begin
		select 'Ventas de Crédito del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
	end

	If @Tipo = 10 or @Tipo = 11 -- POR FECHA
	begin
		SELECT     CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente, CTE.RazonSocial AS Cliente, SUR.IdRuta, VEN.Serie, VEN.Folio, VEN.Serie + ' ' + cast(VEN.Folio as varchar(15)) as SerieFolio,
			VEN.IdSucursal, NombreSucursal, VEN.Subtotal AS [SubtotalF], VEN.Iva AS [IVAF], VEN.Total AS [TotalF],
			VACR.FechaAcredita, VACR.FechaEntrega, VACR.FolioEntrega, 
			VACR.FolioCliente, VACR.Remision, VACR.Factura, VACR.Status, VACR.Observaciones 
		FROM VentasAcredita VACR 
		inner join Ventas VEN on VACR.IdCedis = VEN.IdCedis and VACR.IdSurtido = VEN.IdSurtido 
			and VEN.Serie = VACR.Serie and VEN.Folio = VACR.Folio  
		INNER JOIN Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente 
		inner join ClienteSucursal on ClienteSucursal.IdCedis = VEN.IdCedis and ClienteSucursal.IdSucursal = VEN.IdSucursal
		INNER JOIN Cedis CED ON VEN.IdCedis = CED.IdCedis
		WHERE (VACR.IdCedis = @IdCedi) AND (VACR.FechaAcredita BETWEEN @FechaInicial AND @FechaFinal) 
		ORDER BY CED.IdCedis, VEN.Fecha, VEN.IdCliente, ClienteSucursal.IdSucursal, VEN.Serie, VEN.Folio
	end

end

