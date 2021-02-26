
use RouteCPC 

declare @IdCedis as bigint, @IdTipoVenta as bigint, @Serie as varchar(10), @Folio as bigint
declare @TransprodId as varchar(30), @AbnId as varchar(30), @Abono as money, @TotalTerminal as money, @TotalEsc as money, @Tot as int
declare @IdMov as bigint, @IdMovDet as bigint

declare @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

	select distinct top 1 Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Total, Ventas.Saldo
	from Ventas 
	inner join MovimientosFacturas MovF on Ventas.IdCedis = MovF.IdCedis and Ventas.IdTipoVenta = MovF.IdTipoVenta 
		and Ventas.Serie = MovF.Serie and Ventas.Folio = MovF.Folio --and MovF.Status = 'A' and MovF.CargoAbono = 'A' and MovF.IdDocumento = 'CT'
	where Ventas.Saldo < 0
	order by Ventas.Serie, Ventas.Folio
	
OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdTipoVenta, @Serie, @Folio, @Tot, @TotalEsc
WHILE @@FETCH_STATUS = 0      
BEGIN

	set @TotalEsc = ABS(@TotalEsc)
				
	select @IdMov = null
	select top 1 @IdMov = IdMovimiento, @IdMovDet = IdMovimientoDetalle 
	from MovimientosFacturas 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
		and Status = 'A' and CargoAbono = 'A' and IdDocumento = 'CT' and @TotalEsc between Total - 1 and Total + 1
	order by IdMovimiento desc, IdMovimientoDetalle desc  
	
	if @IdMov is null
		select top 1 @IdMov = IdMovimiento, @IdMovDet = IdMovimientoDetalle 
		from MovimientosFacturas 
		where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
			and Status = 'A' and CargoAbono = 'A' and @TotalEsc between Total - 1 and Total + 1
		order by IdMovimiento desc, IdMovimientoDetalle desc  
	
	update MovimientosFacturas set Subtotal = Subtotal - @TotalEsc  
	where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
	
	if not exists(select * from tmp_MovimientosFacturas where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet )
		insert into tmp_MovimientosFacturas 
		select IdCedis, IdTipoVenta, Serie, Folio, IdMovimiento, Fecha, IdMovimientoDetalle, IdDocumento, IdTipoDocumento, CargoAbono,
			Referencia, ReferenciaBancos, Subtotal, Iva, Status, Login, GETDATE(), @TotalEsc 
		from MovimientosFacturas 
		where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
	else
		update tmp_MovimientosFacturas set ImporteCancelado = ImporteCancelado + @TotalEsc where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
						
	
	FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdTipoVenta, @Serie, @Folio, @Tot, @TotalEsc
	
END
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

	--select Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Total, Ventas.Saldo, SUM(MovF.Total) as TotalAbonos
	--from Ventas 
	--left outer join MovimientosFacturas MovF on Ventas.IdCedis = MovF.IdCedis and Ventas.IdTipoVenta = MovF.IdTipoVenta 
	--	and Ventas.Serie = MovF.Serie and Ventas.Folio = MovF.Folio and MovF.Status = 'A' and MovF.CargoAbono = 'A' 
	--group by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Total, Ventas.Saldo 
	--having Ventas.Total < SUM(MovF.Total) 
	--order by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio
