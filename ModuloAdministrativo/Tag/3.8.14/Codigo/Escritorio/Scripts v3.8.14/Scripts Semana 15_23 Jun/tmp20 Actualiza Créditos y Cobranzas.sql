


declare @IdSurtido as bigint, @IdTipoVenta as bigint, @Folio as bigint, @Fecha as datetime

	declare  InsUpCarga cursor for
		select distinct IdSurtido, Fecha
		from Ventas 
		where IdCedis = 1 and Fecha between '20100528' and '20100620'
		order by IdSurtido
	open InsUpCarga
	
	fetch next from InsUpCarga into @IdSurtido, @Fecha 
	while (@@fetch_status = 0)
	begin

		execute sel_SurtidosDetalle 1, @Fecha , @IdSurtido, 0, 13

		fetch next from InsUpCarga into @IdSurtido, @Fecha 
	end
	close InsUpCarga
	deallocate InsUpCarga		

