
declare @ruta as int, @clave as varchar(20), @descripcion as varchar(1000), @idproducto as bigint

		declare  InsUpCarga cursor for
			select ruta, clave, descripcion from tmp_Cargas
		open InsUpCarga
		
		fetch next from InsUpCarga into @ruta, @clave, @descripcion
		while (@@fetch_status = 0)
		begin

			set @idproducto = isnull((select idproducto from productos where ltrim(rtrim(producto)) = ltrim(rtrim(@descripcion))), 0)
			update tmp_Cargas set idproducto = @idproducto where Ruta = @ruta and clave = @clave 
			fetch next from InsUpCarga into @ruta, @clave, @descripcion
		end
		close InsUpCarga
		deallocate InsUpCarga		

select * from tmp_Cargas