/*
select *
from VentasDetalle 
where IdCedis = 1 and idsurtido in ( 29 ) and Iva <> 0
*/
update VentasDetalle 
	set Iva = 0.11
where IdCedis = 1 and idsurtido in ( 29 ) and Iva <> 0

declare @IdSurtido as bigint, @IdTipoVenta as bigint, @Folio as bigint

	declare  InsUpCarga cursor for
		select IdSurtido, IdTipoVenta, Folio 
		from Ventas 
		where IdCedis = 1 and Fecha = '20100529' and idsurtido in ( 29 )
		order by IdSurtido, IdTipoVenta, Folio 
	open InsUpCarga
	
	fetch next from InsUpCarga into @IdSurtido, @IdTipoVenta, @Folio 
	while (@@fetch_status = 0)
	begin

		update Ventas set Subtotal = isnull((select sum(Cantidad * Precio) from VentasDetalle where IdCedis = 1 and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
		Iva = isnull( (select sum(Cantidad * Precio * Iva) from VentasDetalle where IdCedis = 1 and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
		where IdCedis = 1 and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

		fetch next from InsUpCarga into @IdSurtido, @IdTipoVenta, @Folio 
	end
	close InsUpCarga
	deallocate InsUpCarga		


