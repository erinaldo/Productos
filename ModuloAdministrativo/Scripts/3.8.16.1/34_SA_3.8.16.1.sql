USE [Route] 
GO

/****** Object:  StoredProcedure [dbo].[sp_importVentasADM]    Script Date: 07/30/2011 15:10:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_importVentasADM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_importVentasADM]
GO

USE [Route]     
GO

/****** Object:  StoredProcedure [dbo].[sp_importVentasADM]    Script Date: 07/30/2011 15:10:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
CREATE PROCEDURE [dbo].[sp_importVentasADM] 
	@IdCedis INT, @IdSurtido INT
AS
BEGIN
	SET NOCOUNT ON;

	--DECLARE @IdCedis INT, @idSurtido INT
	--SET @IdCedis = 1
	--SET @idSurtido = 5

	DECLARE @IdTipoVenta AS INT
	DECLARE @Folio AS INT
	DECLARE @Serie AS VARCHAR(10)
	DECLARE @Fecha AS DATETIME
	DECLARE @SubTotal AS MONEY
	DECLARE @Iva AS MONEY
	DECLARE @IdSucursal AS VARCHAR(16)
	DECLARE @DiaClave AS VARCHAR(10)
	DECLARE @IdRuta AS INT
	DECLARE @RUTClave AS VARCHAR(10)
	DECLARE @VendedorId AS VARCHAR(16)
	DECLARE @USUId AS VARCHAR(16)
	DECLARE @ClienteClave AS VARCHAR(16)
	DECLARE @TransProdId AS VARCHAR(16)
	DECLARE @VisitaClave AS VARCHAR(16)
	DECLARE @ModuloClave AS VARCHAR(16)
	DECLARE @ModuloMovDetalleClave AS VARCHAR(16)
	DECLARE @FolioRoute AS VARCHAR(16)
	DECLARE @TipoPedido AS SMALLINT
	DECLARE @TipoMovimiento AS SMALLINT
	DECLARE @TipoFase AS SMALLINT
	DECLARE @SaldoVenta AS MONEY
	DECLARE @Tipo AS smallINT
	DECLARE @SubEmpresaId AS VARCHAR(16)
	DECLARE @DescVendPor AS FLOAT
	DECLARE @Descuento AS BIT
	DECLARE @FechaCobranza AS DATETIME
	DECLARE @FechaPrimera AS DATETIME
	DECLARE @FechaCancelacion AS DATETIME
		
	SET @Tipo = 1

	SELECT @IdRuta = IdRuta  
	FROM RouteADM.dbo.Surtidos 
	WHERE IdCedis = @IdCedis AND IdSurtido = @idSurtido
		
	SET @RUTClave =  RIGHT('10000' + @IdRuta, 5)
	SELECT TOP 1 @VendedorId= VendedorID FROM Route.dbo.VenRut WHERE RUTClave = @RUTClave AND TipoEstado = 1
	
	SELECT @USUId = USUId, @ModuloClave = ModuloClave 
	FROM Route.dbo.Vendedor 
	WHERE VendedorID = @VendedorId 
	
	--Recupera la longitud del folio para los TransProd de Tipo 1
	DECLARE @LongFolio AS INT
	SELECT @LongFolio = LEN(FOD.Formato), @ModuloMovDetalleClave = MMD.ModuloMovDetalleClave, 
	@TipoPedido = TipoPedido, @TipoMovimiento = TipoMovimiento
	FROM Route.dbo.Folio FOL 
	INNER JOIN Route.dbo.FolioDetalle FOD ON FOL.FolioID = FOD.FolioID 
	INNER JOIN Route.dbo.FolioUsuario FOU ON FOL.FolioID = FOU.FolioID 
	INNER JOIN Route.dbo.Vendedor VEN ON VEN.VendedorID = FOU.VendedorID 
	INNER JOIN Route.dbo.Usuario USU ON USU.USUId = VEN.USUId
	INNER JOIN Route.dbo.ModuloMovDetalle MMD ON FOL.ModuloMovDetalleClave = MMD.ModuloMovDetalleClave 
	WHERE FOD.TipoContenido = 2 AND FOD.TipoEstado = 1 AND MMD.TipoEstado = 1 AND MMD.Baja = 0
	AND MMD.TipoIndice = 9 AND MMD.TipoTransProd = 1 AND USU.USUId = @USUId AND MMD.ModuloClave = @ModuloClave 
	
	SET @SubEmpresaId = (SELECT TOP 1 SubEmpresaId FROM Route.dbo.SubEmpresa WHERE TipoEstado = 1)	
	
	--Cobranza (PagoAutomatico, CobrarVentas y Venta a Contado)
	DECLARE @CobrarVentas AS BIT
	DECLARE @PagoAutomatico AS BIT
	
	SELECT TOP 1 @CobrarVentas = CobrarVentas, @PagoAutomatico = PagoAutomatico FROM Route.dbo.CONHist ORDER BY CONHistFechaInicio DESC							
		
	DECLARE @CursorVentas AS CURSOR
	SET @CursorVentas = CURSOR SCROLL STATIC FOR
		SELECT IdTipoVenta, Serie, Folio, Fecha, Subtotal, Iva, IdSucursal, 2 AS TipoFase
		FROM RouteADM.dbo.Ventas 	
		WHERE IdCedis = @IdCedis AND IdSurtido = @IdSurtido
		UNION ALL
		SELECT IdTipoVenta, Serie, Folio, Fecha, Subtotal, Iva, IdSucursal, 0 AS TipoFase
		FROM RouteADM.dbo.VentasCanceladas
		WHERE IdCedis = @IdCedis AND IdSurtido = @IdSurtido		
		
	OPEN @CursorVentas			
	FETCH NEXT FROM @CursorVentas INTO @IdTipoVenta, @Serie, @Folio, @Fecha, @Subtotal, @Iva, @IdSucursal, @TipoFase
	WHILE @@FETCH_STATUS = 0      
	BEGIN	
	
		IF @TipoFase = 2 
			SET @FechaCancelacion = @FechaPrimera 
		ELSE
			SET @FechaCancelacion = @Fecha	
							
		SELECT @TransProdId = TransProdID FROM RouteADM.dbo.VentasTransProd WHERE IdCedis = @IdCedis AND IdSurtido = @idSurtido AND IdTipoVenta = @IdTipoVenta AND Serie = @Serie AND Folio = @Folio 
		IF @TransProdId IS NULL
		BEGIN 
					
			SET @DiaClave = RIGHT('00' + CONVERT(VARCHAR,DAY(@Fecha)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@Fecha)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@Fecha)),4)
			SET @FolioRoute = @Serie + RIGHT(REPLICATE('0', @LongFolio) + CONVERT(VARCHAR(8),@Folio),@LongFolio)
			
			SET @DescVendPor = 0		
			SET @Descuento =0
			SET @FechaCobranza = @Fecha
			
			SET @ClienteClave = CONVERT(VARCHAR(16),@IdSucursal)
				
			IF(SELECT COUNT(*) FROM Route.dbo.Dia WHERE DiaClave = @DiaClave )=0
				INSERT INTO Route.dbo.Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) VALUES(@DiaClave,'','1',@Fecha,GETDATE(),@USUId)		
		      
			SET @VisitaClave = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
				    
			INSERT INTO [Route].[dbo].[Visita]
				   ([VisitaClave],[DiaClave],[ClienteClave],[VendedorID],[RUTClave]
				   ,[Numero],[FechaHoraInicial],[FechaHoraFinal],[TipoEstado],[FueraFrecuencia],[CodigoLeido],[GPSLeido],[DistanciaGPS]
				   ,[MFechaHora],[MUsuarioID])
			VALUES(
					@VisitaClave,@DiaClave,@ClienteClave,@VendedorId,@RUTClave
				   ,1,@Fecha,@Fecha,1,0,0,0,NULL
				   ,GETDATE(),@USUId)

			SET @TransProdId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16) 

			INSERT INTO [Route].[dbo].[TransProd]
				   ([TransProdID],[VisitaClave],[DiaClave],[PCEModuloMovDetClave],[SubEmpresaID],[ClienteClave],[ClientePagoID]
				   ,[CFVTipo],[Folio],[Tipo],[TipoPedido],[TipoFASe],[TipoMovimiento]
				   ,[FechaHoraAlta],[FechaCaptura],[FechaEntrega],[FechaFacturacion],[FechASurtido],[FechaCancelacion],[TipoMotivo]
				   ,[SubTDetalle],[DescVendPor],[DescuentoVendedor],[DescuentoImp],[Subtotal],[Impuesto],[Total],[Saldo]
				   ,[Promocion],[Descuento]
				   ,[TipoTurno],[FechaCobranza],[DiASCredito]
				   ,[TipoFASeINTSal],[MFechaHora],[MUsuarioID])
			VALUES(
				   @TransProdId,@VisitaClave,@DiaClave,@ModuloMovDetalleClave,@SubEmpresaId,@ClienteClave,'1'
				   ,@IdTipoVenta,@FolioRoute,@Tipo,@TipoPedido,@TipoFase,@TipoMovimiento
				   ,@Fecha,@Fecha,@Fecha,@FechaPrimera,@Fecha,@FechaCancelacion,0
				   ,@SubTotal,@DescVendPor,0,0,@SubTotal,@Iva,@SubTotal + @Iva,@SubTotal + @Iva
				   ,0,@Descuento
				   ,0,@FechaCobranza,0 
				   ,1,GETDATE(),@USUId)		
				   
			INSERT INTO [RouteADM].dbo.VentasTransProd (IdCedis, IdSurtido, IdTipoVenta, Serie, Folio, TransProdId, Fecha)
			VALUES (@IdCedis, @IdSurtido, @IdTipoVenta, @Serie, @Folio, @TransProdID, GETDATE())		   
			
			SET @SaldoVenta = @SubTotal + @Iva
			
			IF(SELECT COUNT(*) FROM RouteADM.dbo.VentasDetalle WHERE IdCedis = @IdCedis AND IdSurtido = @idSurtido AND IdTipoVenta = @IdTipoVenta AND Folio = @Folio AND Serie = @Serie )>0
			BEGIN				
				DECLARE @IdProducto AS BIGINT
				DECLARE @Cantidad AS DECIMAL(19,2)
				DECLARE @Precio AS MONEY
				DECLARE @IvaPor AS FLOAT
				DECLARE @IvaImp AS FLOAT
				DECLARE @ProductoClave AS VARCHAR(10)
				DECLARE @ImpuestoClave AS VARCHAR(16)
				DECLARE @TipoUnidad AS SMALLINT
				
				DECLARE @CURSORVar1 AS CURSOR 
				SET @CURSORVar1 = CURSOR SCROLL STATIC FOR
					SELECT IdProducto, Cantidad, Precio, Iva
					FROM RouteADM.dbo.VentasDetalle 
					WHERE IdCedis = @IdCedis AND IdSurtido = @idSurtido AND IdTipoVenta = @IdTipoVenta AND Folio = @Folio AND Serie = @Serie
				
				OPEN @CURSORVar1				
				FETCH NEXT FROM @CURSORVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor				
				WHILE @@FETCH_STATUS = 0      
				BEGIN
					SET @ProductoClave = @IdProducto		
					SET @IvaImp = ROUND((@Cantidad * @Precio) * @IvaPor ,2)
							
					SELECT @TipoUnidad = PRUTipoUnidad FROM Route.dbo.ProductoDetalle 
					WHERE ProductoClave = @ProductoClave AND ProductoClave = ProductoDetClave AND Factor = 1								
					
					INSERT INTO Route.dbo.TransProdDetalle(
						TransProdID, TransProdDetalleID, ProductoClave,TipoUnidad,Partida,
						Cantidad,Precio,DescuenTOPor,DescuentoImp,Subtotal,Impuesto,Total,
						Promocion,TipoFASeINTSal, MFechaHora,MUsuarioID)
					VALUES(
						@TransProdId,@ProductoClave, @ProductoClave,@TipoUnidad,1,
						@Cantidad,@Precio,0,0,(@Cantidad * @Precio), @IvaImp,(@Cantidad * @Precio)+@IvaImp,
						0,1,GETDATE(),@USUId)
					
					IF(@IvaPor > 0)
					BEGIN
						SELECT TOP 1 @ImpuestoClave = P.ImpuestoClave  
						FROM Route.dbo.ProductoImpuesto P
						INNER JOIN Route.dbo.ImpuestoVig I ON P.ImpuestoClave = I.ImpuestoClave 
						WHERE ProductoClave = @ProductoClave  AND Valor = (@IvaPor * 100)  AND TipoEstado = 1
						ORDER BY FechaFinal DESC
						
						INSERT INTO Route.dbo.TPDImpuesto(
							TransProdID, TransProdDetalleID, TPDImpuestoID, ImpuestoClave, ImpuesTOPor, ImpuestoImp, MFechaHora,MUsuarioID)
						VALUES(
							@TransProdId, @ProductoClave, @ProductoClave, @ImpuestoClave, (@IvaPor * 100), @IvaImp, GETDATE(),@USUId)						
					END
					
					FETCH NEXT FROM @CURSORVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor
				END 
				CLOSE @CURSORVar1  
				DEALLOCATE @CURSORVar1
			
			END
			
			IF @TipoFase <> 0
			BEGIN	
							
				IF @CobrarVentas = 1 AND @PagoAutomatico = 1 AND @IdTipoVenta = 1
				BEGIN
					DECLARE @ABNID AS VARCHAR(16)
					DECLARE @MonedaID AS VARCHAR(20)	
			
					SELECT @MonedaID = MonedaID FROM Route.dbo.CONHist ORDER BY CONHistFechaInicio DESC
			
					SET @ABNID =  RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)				
					INSERT INTO Route.dbo.Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioID)
					VALUES(@ABNID, @FolioRoute, @FechaCobranza, @VisitaClave, @DiaClave, @FechaCobranza, @SaldoVenta, 0, GETDATE(), @USUId)				
					
					INSERT INTO Route.dbo.AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFASeINTSal, MFechaHora, MUsuarioID)
					VALUES(@ABNID, @TransProdId, @FechaCobranza, @SaldoVenta, '','',1,GETDATE(), @USUId)
					
					INSERT INTO Route.dbo.ABNDetalle (ABNId, ABDId, TipoPago, Importe, SaldoDeposito, MonedaId, Referencia, MFechaHora, MUsuarioID)
					VALUES(@ABNID, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), 1, @SaldoVenta, 0, @MonedaID, '', GETDATE(), @USUId)
											
					UPDATE Route.dbo.TransProd SET Saldo = 0 WHERE TransProdID = @TransProdId	
				END			
				ELSE
					UPDATE Route.dbo.Cliente SET SaldoEfectivo = SaldoEfectivo + @SaldoVenta WHERE ClienteClave = @ClienteClave			
			END
			
		END --END TransProdId IS NULL
		ELSE
		BEGIN
			IF @TipoFase = 0
			BEGIN
				SELECT @SaldoVenta = Saldo FROM Route.dbo.TransProd WHERE TransProdID = @TransProdId 
				
				UPDATE Route.dbo.TransProd SET TipoFase = @TipoFase, FechaCancelacion = @FechaCancelacion, MUsuarioID = @USUId, MFechaHora = GETDATE()
				
				IF @CobrarVentas = 1 AND @PagoAutomatico = 1 AND @IdTipoVenta = 1
				BEGIN
					DELETE Route.dbo.ABNDetalle 
					FROM Route.dbo.ABNDetalle ABD
					INNER JOIN Route.dbo.Abono ABN ON ABD.ABNId = ABN.ABNId 
					INNER JOIN Route.dbo.AbnTrp ABT ON ABT.ABNId = ABN.ABNId 
					WHERE ABT.TransProdID = @TransprodID
					
					DELETE Route.dbo.Abono 
					FROM Route.dbo.Abono ABN
					INNER JOIN Route.dbo.AbnTrp ABT ON ABT.ABNId = ABN.ABNId 
					WHERE ABT.TransProdID = @TransprodID
					
					DELETE Route.dbo.AbnTrp WHERE TransProdID=@TransprodID
					
					UPDATE Route.dbo.TransProd SET Saldo = Total WHERE TransProdID = @TransprodID				
				END
				ELSE
					UPDATE Route.dbo.Cliente SET SaldoEfectivo = SaldoEfectivo - @SaldoVenta WHERE ClienteClave = @ClienteClave

			END
		END		
				
		SET @TransProdId = NULL
		FETCH NEXT FROM @CursorVentas INTO @IdTipoVenta, @Serie, @Folio, @Fecha, @Subtotal, @Iva, @IdSucursal, @TipoFase
	END			
		
	CLOSE @CursorVentas  
	DEALLOCATE @CursorVentas		
 
END
GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 34, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 34 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO