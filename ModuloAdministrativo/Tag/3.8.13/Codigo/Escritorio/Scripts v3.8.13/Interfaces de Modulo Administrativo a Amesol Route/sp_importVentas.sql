use [Route] 

/****** Object:  StoredProcedure [dbo].[sp_importVentasADM]    Script Date: 07/22/2010 15:40:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_importVentasADM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_importVentasADM]
GO

/****** Object:  StoredProcedure [dbo].[sp_importVentasADM]    Script Date: 07/22/2010 15:40:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		IGOR AVILES
-- Create date: 09/07/2010
-- Description:	INTERFAZ DE ENTRADA DEL MODULO ADMINISTRATIVO A ROUTE
-- =============================================
CREATE PROCEDURE [dbo].[sp_importVentasADM] 
	@idCedis int, @idSurtido int, @idTipoVenta int, @Folio int
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Serie AS VARCHAR(5)
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
	
	SET @TipoFase = 2
    SELECT @Serie = Serie, @Fecha = Fecha,  @SubTotal = Subtotal, @Iva = Iva, @idSucursal = IdSucursal 
	FROM RouteADM.dbo.Ventas 
	WHERE IdCedis = @idCedis AND IdSurtido=@idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio 
	
	IF @Serie IS NULL
	BEGIN
		SET @TipoFase = 0
		SELECT @Serie = Serie, @Fecha = Fecha,  @SubTotal = Subtotal, @Iva = Iva, @idSucursal = IdSucursal 
		FROM RouteADM.dbo.VentasCanceladas 
		WHERE IdCedis = @idCedis AND IdSurtido=@idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio 		
	END
	
	SELECT @idRuta = IdRuta  FROM RouteADM.dbo.Surtidos WHERE IdCedis = @idCedis AND IdSurtido = @idSurtido 
	
	SET @RUTClave =  CONVERT(VARCHAR(20),@idCedis)+RIGHT('0000'+CONVERT(VARCHAR(4),@idRuta),4)
	
	SET @DiaClave = RIGHT('00' + CONVERT(VARCHAR,DAY(@Fecha)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@Fecha)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@Fecha)),4)
	
	SELECT TOP 1 @VendedorId= VendedorID FROM VenRut WHERE RUTClave = @RUTClave AND TipoEstado = 1
	
	SELECT @USUID = USUId, @ModuloClave = ModuloClave 
	FROM Vendedor 
	WHERE VendedorID = @VendedorId 

	SET @FolioRoute = @Serie + RIGHT('0000000'+CONVERT(VARCHAR(8),@Folio),7)
	
	--print convert(varchar(20),@idCedis) + ',' + convert(varchar(20),@idSurtido) + ',' + convert(varchar(20),@idTipoVenta) + ',' + convert(varchar(20),@Folio)
	
	SELECT @TransProdId = TransProdID  FROM TransProd WHERE Folio = @FolioRoute AND CFVTipo = @idTipoVenta
	IF @TransProdId IS NULL
	BEGIN
		IF(SELECT COUNT(*) FROM Dia WHERE DiaClave = @DiaClave )=0
			INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) VALUES(@DiaClave,'','1',@Fecha,GETDATE(),@USUID)

		SET @ClienteClave = CONVERT(VARCHAR(16),@idSucursal)
	      
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
			   ,@SubTotal,0,0,0,@SubTotal,@Iva,@SubTotal + @Iva,@SubTotal + @Iva
			   ,0,0
			   ,0,@Fecha,0
			   ,1,GETDATE(),@USUID)
	END
	ELSE
	BEGIN
		IF @TipoFase = 0
			SET @FechaPrimera = @Fecha 
		
		UPDATE TransProd 
		SET MUsuarioID = @USUID , MFechaHora = GETDATE(), TipoFase = @TipoFase, CFVTipo = @idTipoVenta , 
			FechaHoraAlta = @Fecha, FechaCaptura = @Fecha, FechaEntrega = @Fecha, FechaSurtido = @Fecha, FechaCancelacion = @FechaPrimera,
			Subtotal = @SubTotal, SubTDetalle = @SubTotal, Impuesto = @Iva, Total = @SubTotal + @Iva,
			FechaCobranza = @Fecha
		WHERE TransProdID = @TransProdId 
		
		IF @TipoFase = 0
		BEGIN
			
			DECLARE @SaldoVenta AS FLOAT
			SELECT @SaldoVenta = Saldo 
			FROM TransProd
			WHERE TransProdID = @TransProdId 
			
			UPDATE Cliente SET SaldoEfectivo = SaldoEfectivo - @SaldoVenta WHERE ClienteClave = @ClienteClave 
			
			SELECT ABNId 
			INTO #ABNIDS
			FROM AbnTrp 
			WHERE TransProdID = @TransProdId 
			
			DELETE FROM ABNDetalle 
			WHERE ABNId IN(SELECT ABNId FROM #ABNIDS)

			DELETE FROM AbnTrp 
			WHERE ABNId IN(SELECT ABNId FROM #ABNIDS)

			DELETE FROM Abono 
			WHERE ABNId IN(SELECT ABNId FROM #ABNIDS)
		
			DROP TABLE #ABNIDS
		END
		
	END

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
			SET @ProductoClave = CONVERT(VARCHAR(10),@IdProducto)
			SET @IvaImp = ROUND((@Cantidad * @Precio) * @IvaPor ,2)
			
			INSERT INTO TransProdDetalle(
				TransProdID, TransProdDetalleID, ProductoClave,TipoUnidad,Partida,
				Cantidad,Precio,DescuentoPor,DescuentoImp,Subtotal,Impuesto,Total,
				Promocion,TipoFaseIntSal, MFechaHora,MUsuarioID)
			VALUES(
				@TransProdId,@ProductoClave, @ProductoClave,1,1,
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
END



GO


