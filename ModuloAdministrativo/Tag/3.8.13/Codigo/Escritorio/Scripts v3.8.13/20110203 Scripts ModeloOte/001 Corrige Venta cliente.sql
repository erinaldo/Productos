
use RouteADM 


update Ventas set IdSucursal = '030006'
where Serie = 'REMH' and Folio = 192 and IdSurtido = 2835

select *
from Route.dbo.ProductoPrestamoCli where ClienteClave in ('030001', '030006')

--select cast(ProdD.ProductoDetClave as bigint) as IdProd, sum(Cantidad*Factor) Cantidad
--from VentasDetalle 
--inner join Route.dbo.ProductoDetalle as ProdD on cast(ProdD.ProductoClave as bigint) = VentasDetalle.IdProducto 
--	and Prestamo = 1 and cast(ProdD.ProductoDetClave as bigint) <> VentasDetalle.IdProducto 
--where Serie = 'REMH' and Folio = 192 and IdSurtido = 2835
--group by ProdD.ProductoDetClave 

--declare @IdProd as bigint, @Cantidad as bigint

--declare  ActEnvase cursor for
--	select cast(ProdD.ProductoDetClave as bigint) as IdProd, sum(Cantidad*Factor) Cantidad
--	from VentasDetalle 
--	inner join Route.dbo.ProductoDetalle as ProdD on cast(ProdD.ProductoClave as bigint) = VentasDetalle.IdProducto 
--		and Prestamo = 1 and cast(ProdD.ProductoDetClave as bigint) <> VentasDetalle.IdProducto 
--	where Serie = 'REMH' and Folio = 192 and IdSurtido = 2835
--	group by ProdD.ProductoDetClave 
--open ActEnvase

--fetch next from ActEnvase into @IdProd, @Cantidad
--while (@@fetch_status = 0)
--begin
	
--	select @IdProd, @Cantidad 
	
--	update Route.dbo.ProductoPrestamoCli set Saldo = Saldo + @Cantidad 
--	where ClienteClave = '030006' and cast(ProductoClave as bigint) = @IdProd 

--	update Route.dbo.ProductoPrestamoCli set Saldo = Saldo - @Cantidad 
--	where ClienteClave = '030001' and cast(ProductoClave as bigint) = @IdProd 
	
--	fetch next from ActEnvase into @IdProd, @Cantidad
--end
--close ActEnvase
--deallocate ActEnvase		

--select *
--from Route.dbo.ProductoPrestamoCli where ClienteClave in ('030001', '030006')

update Route.dbo.TransProd set ClienteClave = '030006'
where Folio like 'REMH%192'

update Route.dbo.Visita set ClienteClave = '030006' where VisitaClave = '886F9D655E4C8F1F'

update Route.dbo.Cliente set SaldoEfectivo = SaldoEfectivo - 648 where ClienteClave = '030001'
update Route.dbo.Cliente set SaldoEfectivo = SaldoEfectivo + 648 where ClienteClave = '030006'

select * from Route.dbo.Visita where VisitaClave = '886F9D655E4C8F1F'

select *
from Route.dbo.Cliente where ClienteClave in ('030001', '030006')

select *
from Route.dbo.TransProd 
where Folio like 'REMH%192'

select *
from Ventas
where Serie = 'REMH' and Folio = 192
