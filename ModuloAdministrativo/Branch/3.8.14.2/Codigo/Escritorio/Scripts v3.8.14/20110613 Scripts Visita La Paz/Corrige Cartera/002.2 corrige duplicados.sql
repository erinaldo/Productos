
use RouteCPC 

declare @IdCedis as bigint, @IdTipoVenta as bigint, @Serie as varchar(10), @Folio as bigint
declare @TransprodId as varchar(30), @AbnId as varchar(30), @Abono as money, @TotalTerminal as money, @TotalEsc as money, @Tot as int
declare @IdMov as bigint, @IdMovDet as bigint

declare @CursorMOV CURSOR
SET @CursorMOV = CURSOR SCROLL DYNAMIC FOR 

	select Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Trp.TransProdID, Ventas.Saldo, Trp.Saldo
	from Ventas 
	inner join MovimientosFacturas MovF on Ventas.IdCedis = MovF.IdCedis and Ventas.IdTipoVenta = MovF.IdTipoVenta 
		and Ventas.Serie = MovF.Serie and Ventas.Folio = MovF.Folio and MovF.Status = 'A' and MovF.CargoAbono = 'A' and MovF.IdDocumento = 'CT'
	inner join Route.dbo.TransProd Trp on Trp.Tipo = 8 and Ventas.Serie = replace(Trp.Folio, Route.dbo.FNObtenerSoloNumeros(Trp.Folio),'') 
		and Ventas.Folio = Route.dbo.FNObtenerSoloNumeros(Trp.Folio)
	where Ventas.Saldo not between Trp.Saldo - 1 and Trp.Saldo + 1 and Ventas.Saldo < Trp.Saldo
		--and Ventas.Serie = 'EBBX' and Ventas.Folio = 1048
	group by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Trp.TransProdID, Ventas.Saldo, Trp.Saldo
	order by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio
	
OPEN @CursorMOV
FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdTipoVenta, @Serie, @Folio, @TransprodId 
WHILE @@FETCH_STATUS = 0      
BEGIN

	--select @TransprodId = Trp.TransProdID 
	--from Route.dbo.TransProd Trp
	--where Trp.Tipo = 8 and @Serie = replace(Trp.Folio, Route.dbo.FNObtenerSoloNumeros(Trp.Folio),'') and @Folio = Route.dbo.FNObtenerSoloNumeros(Trp.Folio)

	set @TotalTerminal = 0
	select @TotalTerminal = isnull(SUM(AbnDet.Importe),0)
	from Route.dbo.AbnTrp AbnTrp
	inner join Route.dbo.ABNDetalle AbnDet on AbnDet.ABNId = AbnTrp.ABNId 
	where TransProdID = @TransprodId and AbnTrp.MUsuarioID <> '10000'

	set @TotalEsc = 0
	select @TotalEsc = isnull(SUM(Total),0)
	from MovimientosFacturas 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
		and Status = 'A' and CargoAbono = 'A' and IdDocumento = 'CT'

	if @TotalEsc <> @TotalTerminal 
	begin

		if exists(select AbnTrp.AbnId from Route.dbo.AbnTrp AbnTrp where TransProdID = @TransprodId and AbnTrp.MUsuarioID = '10000')	
		begin
				declare @CursorMOV1 CURSOR
				SET @CursorMOV1 = CURSOR SCROLL DYNAMIC FOR 

					select AbnTrp.AbnId
					from Route.dbo.AbnTrp AbnTrp
					where TransProdID = @TransprodId and AbnTrp.MUsuarioID = '10000'

				OPEN @CursorMOV1
				FETCH NEXT FROM @CursorMOV1 INTO @AbnId
				WHILE @@FETCH_STATUS = 0      
				BEGIN

					select @Abono = SUM(AbnDet.Importe)
					from Route.dbo.ABNDetalle AbnDet 
					where AbnId = @AbnId 
				
					select @IdMov = null
					select top 1 @IdMov = IdMovimiento, @IdMovDet = IdMovimientoDetalle 
					from MovimientosFacturas 
					where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
						and Status = 'A' and CargoAbono = 'A' and IdDocumento = 'CT' and @Abono between Total - 1 and Total + 1
					order by IdMovimiento desc, IdMovimientoDetalle desc  
					
					if @IdMov is null
						select top 1 @IdMov = IdMovimiento, @IdMovDet = IdMovimientoDetalle 
						from MovimientosFacturas 
						where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
							and Status = 'A' and CargoAbono = 'A' and IdDocumento = 'CT' and Total >= @Abono -1 
						order by IdMovimiento desc, IdMovimientoDetalle desc  
						
					update MovimientosFacturas set Subtotal = Subtotal - @Abono 
					where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
					
					if not exists(select * from tmp_MovimientosFacturas where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet )
						insert into tmp_MovimientosFacturas 
						select IdCedis, IdTipoVenta, Serie, Folio, IdMovimiento, Fecha, IdMovimientoDetalle, IdDocumento, IdTipoDocumento, CargoAbono,
							Referencia, ReferenciaBancos, Subtotal, Iva, Status, Login, GETDATE(), @Abono 
						from MovimientosFacturas 
						where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
					else
						update tmp_MovimientosFacturas set ImporteCancelado = ImporteCancelado + @Abono where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
					
					FETCH NEXT FROM @CursorMOV1 INTO @AbnId
					
				END
				CLOSE @CursorMOV1  
				DEALLOCATE @CursorMOV1
		end
		else
		begin

					select @Abono = ISNULL(sum(AbnTrp.Importe),0)
					from Route.dbo.AbnTrp AbnTrp
					where TransProdID = @TransprodId

					select @IdMov = null
					select top 1 @IdMov = IdMovimiento, @IdMovDet = IdMovimientoDetalle 
					from MovimientosFacturas 
					where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
						and Status = 'A' and CargoAbono = 'A' and IdDocumento = 'CT' and @Abono between Total - 1 and Total + 1
					order by IdMovimiento desc, IdMovimientoDetalle desc  
					
					if @IdMov is null
						select top 1 @IdMov = IdMovimiento, @IdMovDet = IdMovimientoDetalle 
						from MovimientosFacturas 
						where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Serie = @Serie and Folio = @Folio 
							and Status = 'A' and CargoAbono = 'A' and IdDocumento = 'CT' and Total >= @Abono -1 
						order by IdMovimiento desc, IdMovimientoDetalle desc  
						
					update MovimientosFacturas set Subtotal = Subtotal - @Abono 
					where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
					
					if not exists(select * from tmp_MovimientosFacturas where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet )
						insert into tmp_MovimientosFacturas 
						select IdCedis, IdTipoVenta, Serie, Folio, IdMovimiento, Fecha, IdMovimientoDetalle, IdDocumento, IdTipoDocumento, CargoAbono,
							Referencia, ReferenciaBancos, Subtotal, Iva, Status, Login, GETDATE(), @Abono 
						from MovimientosFacturas 
						where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
					else
						update tmp_MovimientosFacturas set ImporteCancelado = ImporteCancelado + @Abono where IdCedis = @IdCedis and IdMovimiento = @IdMov and IdMovimientoDetalle = @IdMovDet 
		end
	end
	
	FETCH NEXT FROM @CursorMOV INTO @IdCedis, @IdTipoVenta, @Serie, @Folio, @TransprodId 
	
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
