use RouteCPC 

exec GeneraSaldos '20100413', '20100728'

--declare @IdCedis as bigint, @Fecha as datetime

--declare VentasACPC cursor for

--select distinct Fecha 
--from RouteADM.dbo.Ventas  Ventas
--where Fecha between '20100413' and '20100728'
--order by Fecha 


--	open VentasACPC
--	fetch next from VentasACPC into @IdCedis, @Fecha
--		while @@fetch_status = 0
--		begin
		
--			exec GeneraSaldos @Fecha, @Fecha 
			
--			fetch next from VentasACPC into @IdCedis, @Fecha
--		end
--	close VentasACPC

--deallocate VentasACPC
