-- configuracion.route=0
-- cambiar status = 'B' en clientesucursal
-- importar clientes de route a pdc
-- actualizar campo idcliente ?????
-- configuracion.route=1  
-- habilitar base en blanco y cambiar nombre de base en trigger y up_precios
-- insertar registro de impuesto y impuestovig en bd route
-- tablas de termianles y almacen, borrar numero de serie y tipofase = 1
-- actualizar marca, grupo y familia del producto 9999

declare @IdCedis as bigint 

set @IdCedis = 1

-- update productos set producto = producto 
-- update rutas set ruta = ruta where idcedis = @IdCedis
-- update precioslista set descripcion = descripcion where idlista in ( select Idlista from PreciosListaCedis where idcedis = @IdCedis )

declare @Lista as bigint, @Producto as bigint, @Precio as money

declare Precios cursor for 
select pd.idlista, pd.idproducto, pd.precio 
from preciosdetalle pd
inner join precioslistacedis plc on pd.idlista = plc.idlista and plc.idcedis = @IdCedis 
and pd.idproducto not in ( 840, 1000 )
order by cast( pd.idlista as int), pd.idproducto

open Precios
fetch next from Precios into @Lista, @Producto, @Precio
while (@@fetch_status = 0 )
begin

	insert into ROUTE.dbo.tmp_PrecioProductoVig 
	select cast( @Lista as varchar(10)), cast( @Producto as varchar(10)), 1, getdate(), cast( @Precio as decimal (10,5) ), 1, getdate(), null 
	
	if exists( select IdLista from PreciosLista where IdLista = @Lista and TipoLista = 'BA'  )
	begin
		declare  ActPrecio cursor for
			select PreciosLista.IdLista, @Producto, @Precio
			from PreciosLista
			inner join PreciosListaCedis on PreciosLista.IdLista = PreciosListaCedis.IdLista and PreciosListaCedis.IdCedis = @IdCedis
			where PreciosLista.IdLista not in ( select IdLista from PreciosDetalle where PreciosDetalle.IdLista = PreciosLista.IdLista and PreciosDetalle.IdProducto in ( @Producto  ) ) 
			and PreciosLista.IdLista in ( select IdLista from PreciosListaCedis where PreciosListaCedis.IdLista = PreciosLista.IdLista and IdCedis in ( @IdCedis ) )
		open ActPrecio
		
		fetch next from ActPrecio into @Lista, @Producto, @Precio
		while (@@fetch_status = 0)
		begin
			insert into ROUTE.dbo.tmp_PrecioProductoVig 
			select cast( @Lista as varchar(10)), cast( @Producto as varchar(10)), 1, getdate(), cast( @Precio  as decimal (10,5) ), 1, getdate(), null
		
			fetch next from ActPrecio into @Lista, @Producto, @Precio
		end
		close ActPrecio
		deallocate ActPrecio		
	end

	fetch next from Precios into @Lista, @Producto, @Precio	
end
close Precios
deallocate Precios

-- update clientesucursal set nombresucursal = nombresucursal where idcedis = @IdCedis and Status = 'A'
-- update PreciosListaCliente set idcliente = idcliente where IdLista in ( select IdLista from PreciosListaCedis where IdCedis = @IdCedis )