
--execute up_Consignas 3,1,0,'',3,0,'10/01/2010',0,0,0,'',0,0,'','','E',3

--execute Route.dbo.sp_importConsignacionesADM 3,1591,1

select *
-- delete 
from Movimientos where IdCedis = 3 and IdMovimiento >= 1695

--update Movimientos set status = 'P' where IdCedis = 3 and IdMovimiento >= 1695

select *
-- delete 
from MovimientosDetalle where IdCedis = 3 and IdMovimiento >= 1695

select *
-- delete 
from Consignas 
-- update Consignas set Status = 'R'

select *
-- delete 
from ConsignasDetalle 

-- update Surtidos set Status = 'P' where IdCedis = 3 and IdSurtido = 1591


select *
from ROUTE.dbo.ProductoPrestamoCli 
where ClienteClave in ('030002', '030012', '030015', '030001')

select ClienteClave, Clave, NombreContacto, NombreCorto, SaldoEfectivo, MFechaHora 
from ROUTE.dbo.Cliente 
where ClienteClave in ('030002', '030012', '030015', '030001')

select *
from Route.dbo.TransProd 
where Tipo = 24 and Folio like '169%'

select *
from ROUTE.dbo.ProductoPrestamoCli 
where ClienteClave in ('030025')

select ClienteClave, Clave, NombreContacto, NombreCorto, SaldoEfectivo, MFechaHora 
from ROUTE.dbo.Cliente 
where ClienteClave in ('030025')

-- execute Route.dbo.sp_importVentasADM 3, 1592, 1, 3, REM

--update ventas set IdTipoVenta = 1 
--where IdCedis = 3 and IdSurtido = 1592

select *
from Ventas 
where IdCedis = 3 and IdSurtido = 1592

select *
from ClienteSucursal 
where DiasCredito is null

execute up_Ventas 3, 1592, 1, 1, 'REM', '10/01/2010', 1, '030001', 4
