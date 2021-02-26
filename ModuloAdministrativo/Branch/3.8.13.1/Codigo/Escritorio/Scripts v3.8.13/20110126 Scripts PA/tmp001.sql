
declare @IdCedis as bigint, @FIni as datetime, @FFin as datetime

set @IdCedis = 1
set @FIni = '20110121'
set @FFin = '20110121'

select sum(Ventas.Total) as TotalContado
from Ventas
where IdCedis = @IdCedis and Fecha between @FIni and @FFin and IdTipoVenta = 1 

select sum(Ventas.Total) as ContadoFacturado
from Ventas
where IdCedis = @IdCedis 
and Fecha between @FIni and @FFin and IdTipoVenta = 1 
and Serie in (select SerieFacturasCredito from Configuracion where IdCedis = Ventas.IdCedis)

select sum(Ventas.Total) as PostFactura
from Ventas 
inner join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
	and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FIni and @FFin and Ventas.IdTipoVenta = 1

select sum(Ventas.Total) as ContadoNoFacturado
from Ventas
left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
	and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FIni and @FFin and Ventas.IdTipoVenta = 1 
and Ventas.Serie not in (select SerieFacturasCredito from Configuracion where IdCedis = Ventas.IdCedis) and VentasFacturadas.Folio is null

select sum(FNFact.Total) + SUM(FNPostFact.Total)
from Ventas 
left outer join FN_VentasContadoFacturadas(@IdCedis, @FIni, @FFin) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
	and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
left outer join FN_VentasContadoPOSTFactura(@IdCedis, @FIni, @FFin) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
	and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FIni and @FFin and Ventas.IdTipoVenta = 1 


	select Clientes.IdCliente, Clientes.RazonSocial as Cliente, Ventas.IdSucursal, ClienteSucursal.NombreSucursal,
	isnull(sum(VentasDetalle.Cantidad), 0) as Cantidad, isnull(sum(VentasDetalle.total), 0) as Total, 1 as Orden
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	inner join FN_VentasContadoFacturadas(@IdCedis, @FIni, @FFin) FNFact on Ventas.IdCedis = FNFact.IdCedis and Ventas.IdSurtido = FNFact.IdSurtido 
		and Ventas.IdTipoVenta = FNFact.IdTipoVenta and Ventas.Folio = FNFact.Folio 
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IdCliente = Ventas.IdCliente 
	left outer join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FIni and @FFin and Ventas.IdTipoVenta = 1
		--and FNFact.Folio is not null and FNPostFact.Folio is not null
	group by Clientes.IdCliente, Clientes.RazonSocial, Ventas.IdSucursal, ClienteSucursal.NombreSucursal

union

	select Clientes.IdCliente, Clientes.RazonSocial as Cliente, Ventas.IdSucursal, ClienteSucursal.NombreSucursal,
	isnull(sum(VentasDetalle.Cantidad), 0) as Cantidad, isnull(sum(VentasDetalle.total), 0) as Total, 1 as Orden
	from Ventas 
	inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and VentasDetalle.IdSurtido = Ventas.IdSurtido and
		Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and VentasDetalle.Folio = Ventas.Folio and VentasDetalle.IdTipoVenta = 1
	inner join FN_VentasContadoPOSTFactura(@IdCedis, @FIni, @FFin) FNPostFact on Ventas.IdCedis = FNPostFact.IdCedis and Ventas.IdSurtido = FNPostFact.IdSurtido 
		and Ventas.IdTipoVenta = FNPostFact.IdTipoVenta and Ventas.Folio = FNPostFact.Folio 
	left outer join Clientes on Clientes.IdCedis = Ventas.IdCedis and Clientes.IdCliente = Ventas.IdCliente 
	left outer join ClienteSucursal on ClienteSucursal.IdCedis = Ventas.IdCedis and ClienteSucursal.IdSucursal = Ventas.IdSucursal 
	where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FIni and @FFin and Ventas.IdTipoVenta = 1
		--and FNFact.Folio is not null and FNPostFact.Folio is not null
	group by Clientes.IdCliente, Clientes.RazonSocial, Ventas.IdSucursal, ClienteSucursal.NombreSucursal

--select * from FN_VentasContadoFacturadas(@IdCedis, @FIni, @FFin)
--select * from FN_VentasContadoPOSTFactura(@IdCedis, @FIni, @FFin)

--select sum(Ventas.Total) as PostFacturaNoFacturadas
--from Ventas 
--left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
--	and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
--where Ventas.IdCedis = @IdCedis and Ventas.Fecha between @FIni and @FFin and Ventas.IdTipoVenta = 1 and VentasFacturadas.Folio is null

