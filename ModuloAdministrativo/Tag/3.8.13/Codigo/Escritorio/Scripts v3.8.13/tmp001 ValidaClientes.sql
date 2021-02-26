

declare @FechaInicial as datetime, @FechaFinal as datetime

set @FechaInicial = '20100601'
set @FechaFinal = '20100605'

--CLIENTES CON VENTA QUE NO ESTÁN EN LA BASE DE DATOS DE ADM

select distinct IdCedis, IdCliente, IdSucursal 
from Ventas 
WHERE IdSucursal NOT IN (
	SELECT IdSucursal FROM ClienteSucursal 
)
and fecha between @FechaInicial and @FechaFinal 
order by IdSucursal 

--CLIENTES CON VENTA QUE NO ESTÁN EN LA BASE DE DATOS DE ROUTE

select distinct IdCedis, IdCliente, IdSucursal 
from Ventas 
WHERE IdSucursal NOT IN (
	select ClienteClave from Route.dbo.Cliente 
)
and fecha between @FechaInicial and @FechaFinal 
order by IdSucursal 

-- CLIENTES CON VENTA QUE ESTÁN DADOS DE ALTA MÁS DE UNA VEZ EN ADM
select IdCedis, IdCliente, IdSucursal, NombreSucursal, Status from ClienteSucursal 
where IdSucursal in (
	select ClienteSucursal.IdSucursal
	from ClienteSucursal 
	-- inner join Ventas on Ventas.IdSucursal = ClienteSucursal.IdSucursal and Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.Fecha between @FechaInicial and @FechaFinal 
	group by ClienteSucursal.IdSucursal
	having COUNT(NombreSucursal) > 1
) 
order by IdSucursal 

