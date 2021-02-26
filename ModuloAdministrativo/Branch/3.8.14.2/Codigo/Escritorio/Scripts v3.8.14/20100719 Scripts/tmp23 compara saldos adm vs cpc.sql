
declare @FechaInicial as datetime, @FechaFinal as datetime

set @FechaInicial = '20100611'
set @FechaFinal = '20100611'

 -- exec GeneraSaldos @FechaInicial, @FechaFinal 

	select SUM(total), COUNT(folio)
	from RouteADM.dbo.Ventas VentasADM
	where VentasADM.Fecha between @FechaInicial and @FechaFinal 
	and VentasADM.IdTipoVenta = 2
	
	select SUM(total), COUNT(folio)
	from RouteCPC.dbo.Ventas VentasCPC
	where VentasCPC.Fecha between @FechaInicial and @FechaFinal 
	and VentasCPC.IdTipoVenta = 2
	
	select VentasADM.IdCedis, VentasADM.IdTipoVenta, VentasADM.Folio, VentasADM.Serie, VentasADM.Fecha, VentasADM.IdCliente, VentasADM.Subtotal, VentasADM.Iva
	from RouteADM.dbo.Ventas VentasADM
	left outer join Ventas on Ventas.IdCedis = VentasADM.IdCedis and Ventas.IdTipoVenta = VentasADM.IdTipoVenta
	and Ventas.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = VentasADM.Folio
	where VentasADM.Fecha between @FechaInicial and @FechaFinal and Ventas.Folio is null 
	and VentasADM.IdTipoVenta = 2
	order by VentasADM.IdCedis, VentasADM.Serie, VentasADM.Folio

	select Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Folio, Ventas.Serie, Ventas.Fecha, Ventas.IdCliente, Ventas.Subtotal, Ventas.Iva
	-- delete
	from Ventas 
	left outer join RouteADM.dbo.Ventas VentasADM on Ventas.IdCedis = VentasADM.IdCedis and Ventas.IdTipoVenta = VentasADM.IdTipoVenta
	and Ventas.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = VentasADM.Folio
	where Ventas.Fecha between @FechaInicial and @FechaFinal and VentasADM.Folio is null 
	and Ventas.IdTipoVenta = 2
	order by Ventas.IdCedis, Ventas.Serie, Ventas.Folio
	
	--select VentasADM.IdCedis, VentasADM.IdTipoVenta, VentasADM.Folio, VentasADM.Serie, VentasADM.Fecha, VentasADM.IdCliente, VentasADM.Subtotal, VentasADM.Iva,
	--	Ventas.Subtotal, Ventas.Iva 
	--from RouteADM.dbo.Ventas VentasADM
	--left outer join Ventas on Ventas.IdCedis = VentasADM.IdCedis and Ventas.IdTipoVenta = VentasADM.IdTipoVenta
	--and Ventas.Serie = VentasADM.Serie collate SQL_Latin1_General_CP1_CI_AS and Ventas.Folio = VentasADM.Folio
	--where VentasADM.Fecha between @FechaInicial and @FechaFinal -- and Ventas.Folio is null 
	--and VentasADM.IdTipoVenta = 2 and VentasADM.Total - Ventas.Total <> 0
	--order by VentasADM.IdCedis, VentasADM.Serie, VentasADM.Folio
	
	
