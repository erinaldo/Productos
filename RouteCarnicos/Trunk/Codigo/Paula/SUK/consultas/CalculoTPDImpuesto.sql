--Select * from TransProdDetalle where TransProdId = '0000050000316161'
--Select * from tpdImpuesto

DECLARE @TransProdID varchar(255),@TransProdDetalleID varchar(255),@ProductoClave varchar(255),
@Subtotal varchar(255), @Precio varchar(255)
--Select Top 1  * from TransProdDetalle
DECLARE @CursorVar1 CURSOR 
SET @CursorVar1 = CURSOR SCROLL DYNAMIC  FOR 
	select TransProdID, TransProdDetalleID,	ProductoClave, Subtotal, Precio FROM TransProdDetalle where TransProdId = '0000050000316161'

OPEN @CursorVar1
FETCH NEXT FROM @CursorVar1 INTO @TransProdID, @TransProdDetalleID, @ProductoClave, @Subtotal, @Precio

WHILE @@FETCH_STATUS = 0 
BEGIN 
	
-------------------------------	
DECLARE @ImpuestoClave varchar(10), @ImpuestoPor float, @ImpuestoImp decimal, @TipoAplicacion smallint,@TotalImp decimal,
@ImpuestoPU decimal, @TotalImpPU decimal

DECLARE @CursorImpuestos CURSOR 
SET @CursorImpuestos  = CURSOR SCROLL DYNAMIC  FOR 
	select IMV.ImpuestoClave, IMV.Valor, IMP.TipoAplicacion  from ImpuestoVig IMV
	inner join ProductoImpuesto PRI on IMV.ImpuestoClave = PRI.ImpuestoClave
	inner join Impuesto IMP on IMV.ImpuestoClave = IMP.ImpuestoClave
	where getdate() between FechaInicial and FechaFinal and IMP.TipoEstado = 1
	and PRI.ProductoClave = @ProductoClave and PRI.TipoEstado = 1
	order by IMP.Jerarquia
	
OPEN @CursorImpuestos  
FETCH NEXT FROM @CursorImpuestos INTO @ImpuestoClave, @ImpuestoPor, @TipoAplicacion


set @TotalImp = 0
set @TotalImpPU = 0
WHILE @@FETCH_STATUS = 0 
BEGIN 
	
	If (@TipoAplicacion = 1)
	Begin
		set @ImpuestoImp = (@Subtotal * (@ImpuestoPor/100))	
		set @ImpuestoPU = (@Precio * (@ImpuestoPor/100)) 
	End
	Else
	Begin
		set @ImpuestoImp = ((@Subtotal + @TotalImp) * (@ImpuestoPor/100))	
		set @ImpuestoPU = ((@Precio + @TotalImpPU) * (@ImpuestoPor/100)) 
	End
	
	set @TotalImp = @TotalImp + @ImpuestoImp
	set @TotalImpPU = @TotalImpPU + @ImpuestoPU 
	
	If(Select count(*) from TPDImpuesto where TransProdID = @TransProdId and TransProdDetalleID = @TransProdDetalleID and ImpuestoClave = @ImpuestoClave) = 0
	BEGIN
		INSERT INTO TPDImpuesto(TransProdId, TransProdDetalleID, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, ImpuestoPU,ImpDesGlb, MFechaHora, MUsuarioID)
		VALUES(@TransProdId, @TransProdDetalleID,  (cast(replace(cast(NEWID() as varchar(36)),'-','') as varchar(16))),@ImpuestoClave, @ImpuestoPor, @ImpuestoImp,@ImpuestoPU ,0 , getdate(), 'Interfaz')
	END
	Else
	BEGIN
		UPDATE TPDImpuesto set ImpuestoPor = @ImpuestoPor, ImpuestoImp = @ImpuestoImp, ImpuestoPU = @ImpuestoPU, ImpDesGlb = 0, MFechaHora = getdate(), MUsuarioID = 'Interfaz'
		WHERE TransProdID = @TransProdId and TransProdDetalleID = @TransProdDetalleID and ImpuestoClave = @ImpuestoClave
	END 
FETCH NEXT FROM @CursorImpuestos INTO @ImpuestoClave, @ImpuestoPor, @TipoAplicacion
END

CLOSE @CursorImpuestos
DEALLOCATE @CursorImpuestos
-----------------------------------------



FETCH NEXT FROM @CursorVar1 INTO @TransProdID, @TransProdDetalleID, @ProductoClave, @Subtotal, @Precio
END

CLOSE @CursorVar1
DEALLOCATE @CursorVar1

--Select * from TPDImpuesto
