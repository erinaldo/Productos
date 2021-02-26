declare @IdCedis as bigint, @Serie as varchar(5), @IdTipoVenta as int, @FolioN as bigint
declare @Cont as bigint, @Ventas as int, @IdUnico as varchar(30)


declare  ActVentas cursor for
	select idcedis, idtipovent, serie, FolioN, COUNT(*)
	from Enc 
	group by idcedis, idtipovent, serie, FolioN
	having COUNT(*) > 1
open ActVentas
fetch next from ActVentas into @IdCedis, @IdTipoVenta, @Serie, @FolioN, @Ventas
while (@@fetch_status = 0)
begin
		set @Cont = 1
		
		declare  ActOtro cursor for
			select distinct origen  
			from Enc 
			where IdCedis = @IdCedis and IdTipovent = @IdTipoVenta and Serie = @Serie and FolioN = @FolioN
		open ActOtro
		fetch next from ActOtro into @IdUnico
		while (@@fetch_status = 0)
		begin
				--select @IdUnico, @FolioN, cast(@FolioN as varchar(20)) + cast(@Cont as varchar(20)) 
				
				-- 2da opcion
				update Enc set FolioN = cast(@FolioN as varchar(20)) + cast(@Cont as varchar(20)) 
				where Origen = @IdUnico 

				update Det set FolioN = cast(@FolioN as varchar(20)) + cast(@Cont as varchar(20)) 
				where Origen = @IdUnico 

				update Acr set FolioN = cast(@FolioN as varchar(20)) + cast(@Cont as varchar(20)) 
				where Origen = @IdUnico 
				
				set @Cont = @Cont + 1
			fetch next from ActOtro into @IdUnico
		end
		close ActOtro
		deallocate ActOtro		

	fetch next from ActVentas into @IdCedis, @IdTipoVenta, @Serie, @FolioN, @Ventas
end
close ActVentas
deallocate ActVentas		



--select *, FolioN, Route.dbo.FNObtenerSoloNumeros(Origen)
--from Enc where FolioN = 0


