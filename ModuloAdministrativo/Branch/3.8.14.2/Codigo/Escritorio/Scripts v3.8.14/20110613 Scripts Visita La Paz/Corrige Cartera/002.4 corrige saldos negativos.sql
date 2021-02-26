
use RouteCPC 

declare @IdCedis as bigint, @IdTipoVenta as bigint, @Serie as varchar(10), @Folio as bigint
declare @TransprodId as varchar(30), @AbnId as varchar(30), @Abono as money, @TotalTerminal as money, @TotalEsc as money, @Tot as int
declare @IdMov as bigint, @IdMovDet as bigint

declare @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

	select Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Trp.TransProdID
	from Ventas 
	inner join MovimientosFacturas MovF on Ventas.IdCedis = MovF.IdCedis and Ventas.IdTipoVenta = MovF.IdTipoVenta 
		and Ventas.Serie = MovF.Serie and Ventas.Folio = MovF.Folio and MovF.Status = 'A' and MovF.CargoAbono = 'A' and MovF.IdDocumento = 'CT'
	inner join Route.dbo.TransProd Trp on Trp.Tipo = 8 and Ventas.Serie = replace(Trp.Folio, Route.dbo.FNObtenerSoloNumeros(Trp.Folio),'') 
		and Ventas.Folio = Route.dbo.FNObtenerSoloNumeros(Trp.Folio)
	where Ventas.Saldo not between Trp.Saldo - 1 and Trp.Saldo + 1 and Ventas.Saldo < Trp.Saldo
		--and Ventas.Serie = 'EBBX' and Ventas.Folio = 1048
	group by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Trp.TransProdID
	order by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio
	
OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdTipoVenta, @Serie, @Folio, @TransprodId 
WHILE @@FETCH_STATUS = 0      
BEGIN

	set @TotalTerminal = 0
	select @TotalTerminal = isnull(SUM(AbnDet.Importe),0)
	from Route.dbo.AbnTrp AbnTrp
	inner join Route.dbo.ABNDetalle AbnDet on AbnDet.ABNId = AbnTrp.ABNId 
	where TransProdID = @TransprodId 

	set @TotalEsc = 0
	select @TotalEsc = isnull(SUM(Total),0)
	from MovimientosFacturas 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
		and Status = 'A' and CargoAbono = 'A' and IdDocumento = 'CT'

	if @TotalEsc > 0 and @TotalTerminal = 0
	begin

		select @IdMov = null
		select top 1 @IdMov = IdMovimiento, @IdMovDet = IdMovimientoDetalle 
		from MovimientosFacturas 
		where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
			and Status = 'A' and CargoAbono = 'A' and IdDocumento = 'CT' 
		order by IdMovimiento desc, IdMovimientoDetalle desc  
					
		update MovimientosFacturas set Subtotal = 0
		where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
		
		if not exists(select * from tmp_MovimientosFacturas where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet )
			insert into tmp_MovimientosFacturas 
			select IdCedis, IdTipoVenta, Serie, Folio, IdMovimiento, Fecha, IdMovimientoDetalle, IdDocumento, IdTipoDocumento, CargoAbono,
				Referencia, ReferenciaBancos, Subtotal, Iva, Status, Login, GETDATE(), Total  
			from MovimientosFacturas 
			where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
		else
			update tmp_MovimientosFacturas set ImporteCancelado = 999999 where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
	end			
	
	FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdTipoVenta, @Serie, @Folio, @TransprodId 
	
END
CLOSE @CursorMOV  
DEALLOCATE @CursorMOV

