if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_importVentasADM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_importVentasADM]
/*go*/go
 

-- =============================================
create PROCEDURE [dbo].[sp_importVentasADM] 
	@idCedis int, @idSurtido int, @idTipoVenta int, @Folio int, @Serie as varchar(10)
AS
BEGIN
	SET NOCOUNT ON;

--    DECLARE @Serie AS VARCHAR(5)
--    declare @idCedis int, @idSurtido int, @idTipoVenta int, @Folio int
--set @idCedis = 1
--set @idSurtido = 1533
--set @idTipoVenta = 1
--set @Folio = 3541
--set @Serie='EBA'

DECLARE @Fecha AS DATETIME
	DECLARE @SubTotal AS MONEY
	DECLARE @Iva AS MONEY
	DECLARE @idSucursal AS VARCHAR(16)
	DECLARE @DiaClave as VARCHAR(10)
	DECLARE @idRuta AS INT
	DECLARE @RUTClave as VARCHAR(10)
	DECLARE @VendedorId as VARCHAR(16)
	DECLARE @USUID AS VARCHAR(16)
	DECLARE @ClienteClave AS VARCHAR(16)
	DECLARE @TransProdId AS VARCHAR(16)
	DECLARE @VisitaClave AS VARCHAR(16)
	DECLARE @ModuloClave AS VARCHAR(16)
	DECLARE @ModuloMovDetalleClave AS VARCHAR(16)
	DECLARE @FolioRoute AS VARCHAR(16)
	DECLARE @TipoPedido AS SMALLINT
	DECLARE @TipoMovimiento AS SMALLINT
	DECLARE @TipoFase AS SMALLINT
	--DECLARE @DctoImp AS MONEY
	--DECLARE @DiasCredito as INT
	DECLARE @PrestamoCliente AS BIT	
	DECLARE @SaldoVenta AS MONEY
		
	SET @TipoFase = 2
    SELECT @Serie = Serie, @Fecha = Fecha,  @SubTotal = Subtotal, @Iva = Iva, @idSucursal = IdSucursal
	FROM RouteADM.dbo.Ventas 
	WHERE IdCedis = @idCedis AND IdSurtido=@idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie 
	
	IF @Serie IS NULL
	BEGIN
		SET @TipoFase = 0
		SELECT @Serie = Serie, @Fecha = Fecha,  @SubTotal = Subtotal, @Iva = Iva, @idSucursal = IdSucursal
		FROM RouteADM.dbo.VentasCanceladas 
		WHERE IdCedis = @idCedis AND IdSurtido=@idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie 	
	END
	
	
		
	SELECT @idRuta = IdRuta  FROM RouteADM.dbo.Surtidos WHERE IdCedis = @idCedis AND IdSurtido = @idSurtido	
	SET @RUTClave =  RIGHT('10000' + @idRuta, 5)

	SET @DiaClave = RIGHT('00' + CONVERT(VARCHAR,DAY(@Fecha)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@Fecha)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@Fecha)),4)
	
	SELECT TOP 1 @VendedorId= VendedorID FROM VenRut WHERE RUTClave = @RUTClave AND TipoEstado = 1
	
	SELECT @USUID = USUId, @ModuloClave = ModuloClave 
	FROM Vendedor 
	WHERE VendedorID = @VendedorId 

	SET @FolioRoute = @Serie + RIGHT('0000000'+CONVERT(VARCHAR(8),@Folio),7)
	
	--print convert(varchar(20),@idCedis) + ',' + convert(varchar(20),@idSurtido) + ',' + convert(varchar(20),@idTipoVenta) + ',' + convert(varchar(20),@Folio)
	DECLARE @ImporteSinDesc AS FLOAT
	DECLARE @DescVendPor AS FLOAT
	DECLARE @Descuento AS BIT
	DECLARE @FechaCobranza AS DATETIME
	
	
		SET @DescVendPor = 0
	
		
	SET @Descuento =0
	SET @FechaCobranza = @Fecha
	
	SET @ClienteClave = CONVERT(VARCHAR(16),@idSucursal)
	SELECT @PrestamoCliente = Prestamo FROM Cliente WHERE ClienteClave = @ClienteClave
		
	SELECT @TransProdId = TransProdID  FROM TransProd WHERE Folio = @FolioRoute AND CFVTipo = @idTipoVenta
	IF @TransProdId IS NULL
	BEGIN
		IF(SELECT COUNT(*) FROM Dia WHERE DiaClave = @DiaClave )=0
			INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) VALUES(@DiaClave,'','1',@Fecha,GETDATE(),@USUID)		
	      
		SET @VisitaClave = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
			    
		INSERT INTO [Route].[dbo].[Visita]
			   ([VisitaClave],[DiaClave],[ClienteClave],[VendedorID],[RUTClave]
			   ,[Numero],[FechaHoraInicial],[FechaHoraFinal],[TipoEstado],[FueraFrecuencia],[CodigoLeido],[GPSLeido],[DistanciaGPS]
			   ,[MFechaHora],[MUsuarioID])
		 VALUES(
				@VisitaClave,@DiaClave,@ClienteClave,@VendedorId,@RUTClave
			   ,1,@Fecha,@Fecha,1,0,0,0,NULL
			   ,GETDATE(),@USUID)

		SET @TransProdId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)		 

		SELECT @ModuloMovDetalleClave = ModuloMovDetalleClave, @TipoPedido = TipoPedido, @TipoMovimiento = TipoMovimiento  
		FROM ModuloMovDetalle 
		WHERE TipoIndice = 9 AND TipoTransProd = 1 AND TipoEstado = 1 AND Baja = 0 AND ModuloClave = @ModuloClave

		DECLARE @FechaPrimera AS DATETIME		

		INSERT INTO [Route].[dbo].[TransProd]
			   ([TransProdID],[VisitaClave],[DiaClave],[PCEModuloMovDetClave],[ClienteClave],[ClientePagoID]
			   ,[CFVTipo],[Folio],[Tipo],[TipoPedido],[TipoFase],[TipoMovimiento]
				,[FechaHoraAlta],[FechaCaptura],[FechaEntrega],[FechaFacturacion],[FechaSurtido],[FechaCancelacion]
			   ,[TipoMotivo]
			   ,[SubTDetalle],[DescVendPor],[DescuentoVendedor],[DescuentoImp],[Subtotal],[Impuesto],[Total],[Saldo]
			   ,[Promocion],[Descuento]
			   ,[TipoTurno],[FechaCobranza],[DiasCredito]
			   ,[TipoFaseIntSal],[MFechaHora],[MUsuarioID])
		VALUES(
			   @TransProdId,@VisitaClave,@DiaClave,@ModuloMovDetalleClave,@ClienteClave,'1'
			   ,@idTipoVenta,@FolioRoute,1,@TipoPedido,@TipoFase,@TipoMovimiento
			   ,@Fecha,@Fecha,@Fecha,@FechaPrimera,@Fecha,@FechaPrimera
			   ,0
			   ,@ImporteSinDesc,@DescVendPor,0,0,@SubTotal,@Iva,@SubTotal + @Iva,@SubTotal + @Iva
			   ,0,@Descuento
			   ,0,@FechaCobranza,0 
			   ,1,GETDATE(),@USUID)		
		
		SET @SaldoVenta = @SubTotal + @Iva



		IF(SELECT COUNT(*) FROM RouteADM.dbo.VentasDetalle WHERE IdCedis = @idCedis AND IdSurtido = @idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio AND Serie = @Serie )>0
		BEGIN
			DELETE FROM TPDImpuesto WHERE TransProdID = @TransProdId 
			DELETE FROM TransProdDetalle WHERE TransProdID = @TransProdId 
			
			DECLARE @IdProducto as BIGINT
			DECLARE @Cantidad AS DECIMAL(19,2)
			DECLARE @Precio AS MONEY
			DECLARE @IvaPor AS FLOAT
			DECLARE @IvaImp AS FLOAT
			DECLARE @ProductoClave AS VARCHAR(10)
			DECLARE @ImpuestoClave AS VARCHAR(16)
			DECLARE @ProductoEnvase AS VARCHAR(10)
			DECLARE @PrestamoProducto AS BIT
			DECLARE @EsEnvase as BIT
			DECLARE @TipoUnidad as SMALLINT
			
			DECLARE @CursorVar1 AS CURSOR 
			SET @CursorVar1 = CURSOR SCROLL STATIC  
			FOR
			SELECT IdProducto, Cantidad, Precio, Iva
			FROM RouteADM.dbo.VentasDetalle 
			WHERE IdCedis = @idCedis AND IdSurtido = @idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio AND Serie = @Serie
			
			OPEN @CursorVar1
			
			FETCH NEXT FROM @CursorVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor

			WHILE @@FETCH_STATUS = 0      
			BEGIN
				SET @ProductoClave = RIGHT('00' + CONVERT(VARCHAR(10),@IdProducto), 2)			
				SET @IvaImp = ROUND((@Cantidad * @Precio) * @IvaPor ,2)
				SET @PrestamoProducto = 0
				SET @ProductoEnvase = NULL 
				
				SELECT @EsEnvase = Contenido FROM Producto where ProductoClave = @ProductoClave 
				SELECT @TipoUnidad = PRUTipoUnidad FROM ProductoDetalle WHERE ProductoClave = @ProductoClave AND ProductoClave = ProductoDetClave AND Factor = 1								
				
				INSERT INTO TransProdDetalle(
					TransProdID, TransProdDetalleID, ProductoClave,TipoUnidad,Partida,
					Cantidad,Precio,DescuentoPor,DescuentoImp,Subtotal,Impuesto,Total,
					Promocion,TipoFaseIntSal, MFechaHora,MUsuarioID)
				VALUES(
					@TransProdId,@ProductoClave, @ProductoClave,@TipoUnidad,1,
					@Cantidad,@Precio,0,0,(@Cantidad * @Precio), @IvaImp,(@Cantidad * @Precio)+@IvaImp,
					0,1,GETDATE(),@USUID)
				
				IF(@IvaPor > 0)
				BEGIN
					SELECT TOP 1 @ImpuestoClave = P.ImpuestoClave  FROM ProductoImpuesto P
					INNER JOIN ImpuestoVig I ON P.ImpuestoClave = I.ImpuestoClave 
					WHERE ProductoClave = @ProductoClave  AND Valor = (@IvaPor * 100)  AND TipoEstado = 1
					ORDER BY FechaFinal DESC
					
					INSERT INTO TPDImpuesto(
						TransProdID, TransProdDetalleID, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, MFechaHora,MUsuarioID)
					VALUES(
						@TransProdId, @ProductoClave, @ProductoClave, @ImpuestoClave, (@IvaPor * 100), @IvaImp, GETDATE(),@USUID)
					
				END
				

				
				FETCH NEXT FROM @CursorVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor
			END 
			CLOSE @CursorVar1  
			DEALLOCATE @CursorVar1
		
		END
		
		--Cobranza (PagoAutomatico, CobrarVentas y Venta a Contado)
		IF (SELECT TOP 1 CASE WHEN CobrarVentas = 1 AND PagoAutomatico = 1 THEN 1 ELSE 0 END FROM CONHist ORDER BY CONHistFechaInicio DESC) = 1 AND @idTipoVenta = 1
		BEGIN
			DECLARE @ABNID AS VARCHAR(16)
			DECLARE @MonedaID AS VARCHAR(20)	
	
			SELECT @MonedaID = MonedaID FROM CONHist ORDER BY CONHistFechaInicio DESC
	
			SET @ABNID =  RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)				
			INSERT INTO Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioID)
				VALUES(@ABNID, @FolioRoute, @FechaCobranza, @VisitaClave, @DiaClave, @FechaCobranza, @SaldoVenta, 0, GETDATE(), @USUID)
			
			INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
				VALUES(@ABNID, @TransProdID, @FechaCobranza, @SaldoVenta, '','',1,GETDATE(), @USUID)
			
			INSERT INTO ABNDetalle (ABNId, ABDId, TipoPago, Importe, SaldoDeposito, MonedaId, Referencia, MFechaHora, MUsuarioID)
				VALUES(@ABNID, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), 1, @SaldoVenta, 0, @MonedaID, '', GETDATE(), @USUID)
				
			UPDATE TransProd SET Saldo = 0 WHERE TransProdID = @TransProdID 								
		END
		ELSE
			UPDATE Cliente SET SaldoEfectivo = SaldoEfectivo + @SaldoVenta WHERE ClienteClave = @ClienteClave
		
	END	
	


end