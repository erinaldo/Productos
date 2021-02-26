
/*
select *
-- delete
from Ventas
where Fecha >= '20100528'

select *
-- delete
from VentasDetalle 

select sum(Monto)
-- delete 
from Movimientos  
-- inner join MovimientosFacturas on Movimientos.IdMovimiento = MovimientosFacturas.IdMovimiento -- and Movimientos.IdTipoVenta = MovimientosFacturas.IdTipoVenta 
	-- and Ventas.Serie = VentasDetalle.Serie and Ventas.Folio = VentasDetalle.Folio
-- where Movimientos.Fecha < '20100528'
where Status = 'A'

select sum(Total)
-- delete
from MovimientosFacturas 
where Status = 'A'
*/

use RouteCPC 

declare @FIni as datetime, @FFin as datetime

set @FIni = '20100528'
set @FFin = '20100530'

-- select distinct Serie, Folio 
delete
from VentasDetalle
where Folio in ( select Folio from Ventas where Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta 
	and Ventas.Serie = VentasDetalle.Serie and Ventas.Folio = VentasDetalle.Folio
and Fecha between @FIni and @FFin )

-- select *
delete
from Ventas
where Fecha between @FIni and @FFin 

declare @Fecha as datetime, @Status as char(1)

declare @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 
	select Fecha, Status 
	from RouteADM.dbo.StatusDia 
	where Fecha between @FIni and @FFin 
	order by Fecha asc
OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @Fecha, @Status
WHILE @@FETCH_STATUS = 0      
BEGIN

	exec GeneraSaldos @Fecha, @Fecha		                                                            
	FETCH NEXT FROM @CursorMOV INTO @Fecha, @Status
END
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

--select *
--from Ventas 
--where Serie = 'EBQ' and Folio = 56

--select *
--from Route.dbo.FolioSolicitado 
--where Serie = 'EBQ'

/*
select *
-- delete
from RouteCPC2.dbo.Ventas
where Fecha >= '20100528'

select *
from RouteCPC2.dbo.MovimientosFacturas 
*/