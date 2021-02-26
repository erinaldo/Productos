/****** Object:  StoredProcedure [dbo].[sp_importAbonosADM]    Script Date: 07/22/2010 15:40:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_importAbonosADM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_importAbonosADM]
GO

/****** Object:  StoredProcedure [dbo].[sp_importAbonosADM]    Script Date: 07/22/2010 15:40:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		IGOR AVILES
-- Create date: 13/07/2010
-- Description:	GENERAR ABONOS A VENTAS DE CONTADO Y REGISTRAR ABONOS REALIZADOS DURANTE EL DIA
-- =============================================
CREATE PROCEDURE [dbo].[sp_importAbonosADM] 
	@Fecha AS DATETIME, 
	@idCedis AS INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @MonedaID AS VARCHAR(20)
	DECLARE @TransProdID AS VARCHAR(16)
	DECLARE @Total AS MONEY
	DECLARE @VisitaClave AS VARCHAR(16)
	DECLARE @DiaClave AS VARCHAR(16)
	DECLARE @ABNID AS VARCHAR(16)
	DECLARE @Folio AS VARCHAR(16)
	DECLARE @MUsuarioID AS VARCHAR(16)
	DECLARE @ClienteClave AS VARCHAR(16)
	
	SELECT @MonedaID = MonedaID FROM CONHist ORDER BY CONHistFechaInicio DESC
	
	SET @DiaClave = RIGHT('00' + CONVERT(VARCHAR,DAY(@Fecha)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@Fecha)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@Fecha)),4)
	IF(SELECT COUNT(*) FROM Dia WHERE DiaClave = @DiaClave )=0
			INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) VALUES(@DiaClave,'','1',@Fecha,GETDATE(),'Interfaz')

	DECLARE CursorVentas  CURSOR STATIC
		FOR
		SELECT T.TransProdID, T.Saldo, T.VisitaClave, T.DiaClave, T.Folio, T.MUsuarioID, V.ClienteClave
		FROM TRANSPROD T
		INNER JOIN Visita V ON V.VisitaClave = T.VisitaClave AND V.DiaClave = T.DiaClave
		WHERE T.Folio COLLATE database_default IN (SELECT CONVERT(VARCHAR(20),V.Serie)+ RIGHT('0000000'+CONVERT(VARCHAR(8),V.Folio),7) COLLATE database_default
			FROM RouteADM.dbo.Ventas V
			LEFT JOIN RouteCPC.dbo.Ventas   VC ON VC.IdCedis = V.IdCedis AND VC.IdTipoVenta = V.IdTipoVenta AND VC.Serie COLLATE database_default = V.Serie COLLATE database_default AND VC.Folio = V.Folio
			WHERE V.Fecha = @Fecha AND V.IdCedis = @idCedis and VC.IdCedis IS NULL)
		
	OPEN CursorVentas
	
	FETCH NEXT FROM CursorVentas INTO @TransProdID, @Total, @VisitaClave, @DiaClave, @Folio, @MUsuarioID, @ClienteClave
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF NOT EXISTS(SELECT * FROM Abono WHERE Folio = @Folio)
		BEGIN
			SET @ABNID =  RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
			INSERT INTO Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioID)
				VALUES(@ABNID, @Folio, @Fecha, @VisitaClave, @DiaClave, @Fecha, @Total, 0, GETDATE(), @MUsuarioID)
			
			INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
				VALUES(@ABNID, @TransProdID, @Fecha, @Total, '','',1,GETDATE(), @MUsuarioID)
			
			INSERT INTO ABNDetalle (ABNId, ABDId, TipoPago, Importe, SaldoDeposito, MonedaId, Referencia, MFechaHora, MUsuarioID)
				VALUES(@ABNID, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), 1, @Total, 0, @MonedaID, '', GETDATE(), @MUsuarioID)
			UPDATE TransProd SET Saldo = Saldo - @Total WHERE TransProdID = @TransProdID 
			UPDATE Cliente SET SaldoEfectivo = SaldoEfectivo - @Total WHERE ClienteClave = @ClienteClave 
		END
		
		FETCH NEXT FROM CursorVentas INTO @TransProdID, @Total, @VisitaClave, @DiaClave, @Folio, @MUsuarioID, @ClienteClave
	END
	
	CLOSE CursorVentas  
	DEALLOCATE CursorVentas
	
	DECLARE @Serie AS VARCHAR(20), @IdTipoVenta AS INT, @FolioADM AS INT, @idRuta as INT, @IdMovimiento AS INT, @IdMovimientoDetalle AS INT, @idSucursal AS INT
	
	DECLARE CursorAbonos CURSOR STATIC
	FOR
	SELECT M.IdTipoVenta, M.Serie, M.Folio, M.Total, S.IdRuta, M.IdMovimiento, M.IdMovimientoDetalle, V.IdSucursal
	FROM RouteCPC.dbo.MovimientosFacturas M
	INNER JOIN RouteADM.dbo.Ventas V ON V.IdCedis = M.IdCedis AND V.IdTipoVenta = M.IdTipoVenta AND V.Serie COLLATE database_default = M.Serie COLLATE database_default  AND V.Folio = M.Folio 
	INNER JOIN RouteADM.dbo.Surtidos S ON S.IdCedis = V.IdCedis AND S.IdSurtido = V.IdSurtido 
	WHERE M.Fecha = @Fecha AND M.IdCedis = @idCedis
	
	OPEN CursorAbonos
	
	FETCH NEXT FROM CursorAbonos INTO @IdTipoVenta, @Serie, @FolioADM, @Total, @idRuta, @IdMovimiento, @IdMovimientoDetalle, @idSucursal
	
	DECLARE @FolioRoute AS VARCHAR(20), @RUTClave AS VARCHAR(16), @USUID AS VARCHAR(16), @VendedorId AS VARCHAR(16)
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @Folio = RIGHT('0000000000' + CONVERT(VARCHAR(10),@IdMovimiento),10)+ RIGHT('000000' + CONVERT(VARCHAR(10),@IdMovimientoDetalle),6)
		IF NOT EXISTS(SELECT * FROM Abono WHERE Folio = @Folio )
		BEGIN
			SET @TransProdID = NULL 
			SELECT TOP 1 @TransProdID  = TransProdID
			FROM TransProd 
			WHERE Folio = CONVERT(VARCHAR(20), @Serie) + RIGHT('0000000'+CONVERT(VARCHAR(8),@FolioADM),7) AND CFVTipo = @IdTipoVenta AND Saldo <> 0
			IF @TransProdID IS NOT NULL 
			BEGIN
				SET @RUTClave =  CONVERT(VARCHAR(20),@idCedis)+RIGHT('0000'+CONVERT(VARCHAR(4),@idRuta),4)
		
				SELECT TOP 1 @VendedorId= VR.VendedorID , @USUID = USUId
				FROM VenRut VR
				INNER JOIN Vendedor V ON VR.VendedorID = V.VendedorID 
				WHERE RUTClave = @RUTClave AND VR.TipoEstado = 1
		
				SET @ABNID =  RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
				
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

				INSERT INTO Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioID)
					VALUES(@ABNID, @Folio, @Fecha, @VisitaClave, @DiaClave, @Fecha, @Total, 0, GETDATE(), @MUsuarioID)
			
				INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
					VALUES(@ABNID, @TransProdID, @Fecha, @Total, '','',1,GETDATE(), @MUsuarioID)
				
				INSERT INTO ABNDetalle (ABNId, ABDId, TipoPago, Importe, SaldoDeposito, MonedaId, Referencia, MFechaHora, MUsuarioID)
					VALUES(@ABNID, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), 1, @Total, 0, @MonedaID, '', GETDATE(), @MUsuarioID)
					
				UPDATE TransProd SET Saldo = Saldo - @Total WHERE TransProdID = @TransProdID 
				UPDATE Cliente SET SaldoEfectivo = SaldoEfectivo - @Total WHERE ClienteClave = @ClienteClave 
			END
		END
		FETCH NEXT FROM CursorAbonos INTO @IdTipoVenta, @Serie, @FolioADM, @Total, @idRuta, @IdMovimiento, @IdMovimientoDetalle, @idSucursal
	END
	
	CLOSE CursorAbonos 
	DEALLOCATE CursorAbonos

END



GO


