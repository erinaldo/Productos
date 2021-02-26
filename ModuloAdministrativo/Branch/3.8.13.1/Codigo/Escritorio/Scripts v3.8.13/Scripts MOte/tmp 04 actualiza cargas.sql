
declare @idcedis as bigint, 
@idsurtido as bigint, 
@idcarga as bigint, 
@idproducto as bigint, 
@cantidad as bigint, 
@fecha as datetime

			declare  ActPrecio cursor for
				
				select s.IdCedis, s.IdSurtido, s.Fecha, sc.IdCarga, idproducto, cantidad
				from surtidos s
				inner join surtidoscargas sc on s.idcedis = sc.idcedis and s.idsurtido = sc.idsurtido
				where fecha = '20100414' and idproducto in (1,2,4,6,7,8,10,14,15,17,24,25,26,27,28)
				order by s.IdCedis, s.IdSurtido, sc.IdCarga, s.Fecha, idproducto, cantidad
				
			open ActPrecio
			
			fetch next from ActPrecio into @idcedis, @idsurtido, @fecha, @idcarga, @idproducto, @cantidad 

			while (@@fetch_status = 0)
			begin
				exec up_surtidoscargas @IdCedis, @IdSurtido, @IdCarga, @IdProducto, @Fecha, @cantidad, 1
							
				fetch next from ActPrecio into @idcedis, @idsurtido, @fecha, @idcarga, @idproducto, @cantidad 
			end
			close ActPrecio
			deallocate ActPrecio		


