
use RouteADM 

declare @IdCedis as bigint, @IdSurtido as bigint, @Fecha as datetime 

declare AplicaAbonosEnero cursor for

	select IdCedis, IdSurtido, Fecha
	from Surtidos
	where Fecha between '20110201' and '20110307' -- and status = 'C'
	order by IdCedis, Fecha, IdSurtido

	open AplicaAbonosEnero
	fetch next from AplicaAbonosEnero into @IdCedis, @IdSurtido, @Fecha
		while @@fetch_status = 0
		begin
			
			execute sel_SurtidosDetalle @IdCedis, @Fecha, @IdSurtido, 0, 13
			
			fetch next from AplicaAbonosEnero into @IdCedis, @IdSurtido, @Fecha
		end
	close AplicaAbonosEnero

deallocate AplicaAbonosEnero




