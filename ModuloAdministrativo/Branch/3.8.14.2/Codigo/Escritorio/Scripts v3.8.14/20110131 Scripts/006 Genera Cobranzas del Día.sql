
use RouteCPC 

--select *
delete 
from MovimientosFacturas 
where IdDocumento = 'CT' and IdMovimiento in (
	select IdMovimiento 
	from Movimientos 
	where IdDocumento = 'CT' and Fecha >= '20110101' and IdCedis = MovimientosFacturas.IdCedis and Movimientos.IdMovimiento = MovimientosFacturas.IdMovimiento 
)

--select *
delete 
from Movimientos 
where IdDocumento = 'CT' and Fecha >= '20110101'

Go


use RouteCPC 

declare @IdCedis as bigint, @Fecha as datetime 

declare AplicaAbonosEnero cursor for

	select  IdCedis, Fecha
	from routeadm.dbo.statusdia 
	where fecha between '20110101' and '20110131' and status = 'C'
	order by Fecha asc

	open AplicaAbonosEnero
	fetch next from AplicaAbonosEnero into @IdCedis, @Fecha
		while @@fetch_status = 0
		begin
			
			--select @Idcedis, @Fecha, 'SISTEMAS', 1
			execute up_CobranzaTerminal @Idcedis, @Fecha, 'SISTEMAS', 1

			fetch next from AplicaAbonosEnero into @IdCedis, @Fecha
		end
	close AplicaAbonosEnero

deallocate AplicaAbonosEnero


