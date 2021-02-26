
		select Clientes.IdCedis, IdTipoVenta, Serie, Folio, Fecha, FechaVencimiento, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, '-') as CTipo, NombreSucursal as RazonSocial, Saldo, DiasVencidos, Serie + ' ' + cast(Folio as varchar(15)) as DFolio
		from Clientes
		inner join RouteADM.dbo.ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join FN_VencimientoAlaFechaS (1 , '20100615') on FN_VencimientoAlaFechaS.IdCedis = Clientes.IdCedis 
			and FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		where IdTipoVenta is not null  and Clientes.IdCedis = 1
		order by CS.IdSucursal, Fecha

			
			select Clientes.IdCedis, CS.IdSucursal as 'IdCliente', isnull( ClientesTipo.Tipo, '-') as CTipo, NombreSucursal as 'RazonSocial', 

			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (1, '20100615') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal 
			and DiasVencidos < 1 
			), 0) as '0', 

			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (1, '20100615') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal 
			and DiasVencidos >= 1 and DiasVencidos <= 30 
			), 0) as '1 a 30', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (1, '20100615') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			and DiasVencidos >= 31 and DiasVencidos <= 60
			), 0) as '31 a 60', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (1, '20100615') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			and DiasVencidos >= 61 and DiasVencidos <= 90
			), 0) as '61 a 90', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (1, '20100615') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			and DiasVencidos >= 91 and DiasVencidos <= 120
			), 0) as '91 a 120', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (1, '20100615') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			and DiasVencidos > 120 
			), 0) as '120', 
			
			isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (1, '20100615') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			), 0) as 'Total'
			
			from Clientes 
			left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente
			left outer join ClienteSucursal CS on CS.IdCliente = Clientes.IdCliente 
			where Clientes.IdCedis = 1
			group by Clientes.IdCedis, CS.IdSucursal, NombreSucursal, ClientesTipo.Tipo, Clientes.IdCliente
			having (isnull((select sum(Saldo)
			from FN_VencimientoAlaFechaS (1, '20100615') 
			where FN_VencimientoAlaFechaS.IdSucursal = CS.IdSucursal
			), 0)) <> 0			

			order by CS.IdSucursal