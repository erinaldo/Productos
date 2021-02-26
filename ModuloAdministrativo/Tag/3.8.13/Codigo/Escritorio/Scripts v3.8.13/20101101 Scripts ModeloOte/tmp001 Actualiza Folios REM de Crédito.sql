
--update Movimientos 
--set Status = 'P'
--where IdDocumento <> 'CT'

select *
from Ventas 
where Serie = 'R2' and Folio = 246

select *
from MovimientosFacturas  
where IdDocumento <> 'CT'

--select *
--from Route.dbo.TransProd
--where Folio like 'REM%03'
----where Folio like 'VTA%246' and MUsuarioID = '2O6M+QCBPI3G1C1'

--select * from Route.dbo.Usuario where USUId = '2O6M+QCBPI3G1C1'

select *
from Route.dbo.AbnTrp  
where TransProdID in ( 'e8845cf1dc904a38', '8B4866097103CCC2')
order by MFechaHora desc

--select *
--from Route.dbo.ABNDetalle 
--where ABNId in ('8D7DBA6B53E4F3C8', 
--'99FF2C5B52EE9AF6')


select *
from Route.dbo.TransProd
-- update  Route.dbo.TransProd set Folio = 'REML0000044'
where substring(Folio,1,3) = 'REM' and substring(Folio,1,4) not in ('REMH', 'REML')
and Folio like 'REM%44'

select *
from Route.dbo.TransProd 
-- update  Route.dbo.TransProd set Folio = 'REMH0000003'
where substring(Folio,1,3) = 'REM' and substring(Folio,1,4) not in ('REMH', 'REML')
and Folio like 'REM%03'


select *
-- delete 
from Ventas 
where IdCedis in (2, 3) and Serie = 'REM' and IdTipoVenta = 2 and Folio = 44

select *
-- delete 
from VentasDetalle 
where IdCedis in (2, 3) and Serie = 'REM' and IdTipoVenta = 2 and Folio = 44