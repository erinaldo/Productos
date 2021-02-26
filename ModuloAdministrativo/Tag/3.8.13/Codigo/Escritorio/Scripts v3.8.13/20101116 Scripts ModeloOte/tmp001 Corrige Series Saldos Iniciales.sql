
use [RouteCPC] 

update Ventas set Serie = REPLACE(Serie, '0', '')
where Serie in ('R03', 'R02')

update VentasDetalle set Serie = REPLACE(Serie, '0', '')
where Serie in ('R03', 'R02')

update MovimientosFacturas set Serie = REPLACE(Serie, '0', '')
where Serie in ('R03', 'R02')

update Movimientos set Status = 'P'
where IdCedis = 3 and IdMovimiento in (41, 42)

select *
from Ventas  
where IdCedis = 3 and Folio in (485, 488) and Serie = 'R3'

select TOP 1 TransProdID, Total, Saldo 
from Route.dbo.TransProd
where FechaCaptura = '20100825' and cast( replace(Route.dbo.FNObtenerSoloNumeros( Folio ),'-','') as int) = 488 and Tipo = 1 and MUsuarioID in (
	select USUId 
	from Route.dbo.Usuario where Clave = 'USER' + replicate( '0', 2 - len(Route.dbo.FNObtenerSoloNumeros('R3'))) +  Route.dbo.FNObtenerSoloNumeros('R3')) 			


