

		select Clientes.IdCedis, Cedis, CS.IdSucursal as IdCliente, isnull( ClientesTipo.Tipo, '-') as CTipo, NombreSucursal as RazonSocial, 
		Serie, Folio, IdMovimiento, IdDocumento, IdTipoDocumento, Fecha, Inicial as 'INICIAL', Cargos as 'CARGOS', Abonos as 'ABONOS'
		from Clientes 
		inner join ClienteSucursal CS on CS.IdCedis = Clientes.IdCedis and CS.IdCliente = Clientes.IdCliente 
		left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and Clientes.IdCliente = ClientesTipo.IdCliente   
		left outer join FN_BalanzaDetalladaS (1, '20100601', '20100610') on FN_BalanzaDetalladaS.IdCedis = Clientes.IdCedis and FN_BalanzaDetalladaS.IdSucursal = CS.IdSucursal
		inner join Cedis on Cedis.IdCedis = Clientes.IdCedis
		where Clientes.IdCedis = 1  and Inicial is not null and Cargos is not null and Abonos is not null 
		order by Clientes.IdCliente, CS.IdSucursal, FN_BalanzaDetalladaS.Orden, FN_BalanzaDetalladaS.Fecha 
