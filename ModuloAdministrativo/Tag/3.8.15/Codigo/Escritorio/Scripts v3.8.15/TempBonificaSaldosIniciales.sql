declare @IdCedis as bigint, @Serie as varchar(5), @IdTipoVenta as int, @FolioN as bigint
declare @Abono as float, @Ventas as int, @IdUnico as varchar(30)


declare  ActVentas cursor for
	select idcedis, idtipovent, serie, FolioN, abonos  
	from Enc  
	where abonos<> 0 
open ActVentas
fetch next from ActVentas into @IdCedis, @IdTipoVenta, @Serie, @FolioN, @Abono
while (@@fetch_status = 0)
begin
	
	--select 1, @IdCedis, @IdTipoVenta, @Serie, @FolioN, 0, '20110404', 0, 'AJ', 'INI', 'A', '', '', @Abono, 0, 'A', 'Iniciales', 1		
	exec up_MovimientosFacturas  27, @IdCedis, @IdTipoVenta, @Serie, @FolioN, 0, '20110501', 0, 'AJ', 'INI', 'A', '', '', @Abono, 0, 'A', 'Iniciales', 1		

	fetch next from ActVentas into @IdCedis, @IdTipoVenta, @Serie, @FolioN, @Abono
end
close ActVentas
deallocate ActVentas		
