declare @IdCedis as bigint, @IdSurtido as bigint, @IdTipoVenta as bigint, @Serie as varchar(5), @Folio as bigint, @IdMarca as bigint

declare VentasDet cursor for
	select distinct IdCedis, IdSurtido, IdTipoVenta, Serie, Folio, IdMarca  
	from VentasDetalle 
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
	where Serie = 'LP' 
	order by IdCedis, IdSurtido, IdTipoVenta, Serie, Folio 
open VentasDet

fetch next from VentasDet into @IdCedis, @IdSurtido, @IdTipoVenta, @Serie, @Folio, @IdMarca  
while (@@fetch_status = 0)
begin
	if @IdMarca = 1
	begin
		update VentasDetalle set Serie = 'EBQ'
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and 
			Serie = @Serie and Folio = @Folio

		update Ventas set Serie = 'EBQ'
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and 
			Serie = @Serie and Folio = @Folio
	end
	else
	begin
		update VentasDetalle set Serie = 'EBQX'
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and 
			Serie = @Serie and Folio = @Folio

		update Ventas set Serie = 'EBQX'
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and 
			Serie = @Serie and Folio = @Folio
	end	
	
	fetch next from VentasDet into @IdCedis, @IdSurtido, @IdTipoVenta, @Serie, @Folio, @IdMarca  
end
close VentasDet
deallocate VentasDet		