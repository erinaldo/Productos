USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_importPreventaADM]    Script Date: 07/28/2011 21:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_importPreventaADM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_importPreventaADM]
GO

USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_importPreventaADM]    Script Date: 07/28/2011 21:10:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		NOÉ GONZÁLEZ
-- Create date: 10/04/2011
-- Description:	INTERFAZ DE ENTRADA DEL MODULO ADMINISTRATIVO A ROUTE
-- =============================================
CREATE PROCEDURE [dbo].[sp_importPreventaADM] 
	@Fecha as datetime, @USUID AS VARCHAR(16), @TransprodID as varchar(8000), @Opc as int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @VisitaClave AS VARCHAR(16)
	DECLARE @DiaClave as VARCHAR(10)
	DECLARE @RUTClave as VARCHAR(10)
	DECLARE @VendedorId as VARCHAR(16)
	DECLARE @ClienteClave AS VARCHAR(16)
	DECLARE @SaldoVenta AS float

	SELECT @SaldoVenta = TRP.Total, @ClienteClave = TRP.ClienteClave  	
	FROM Route.dbo.TransProd TRP
	INNER JOIN Route.dbo.Dia DIA ON DIA.DiaClave = TRP.DiaClave
	INNER JOIN Route.dbo.Visita VIS ON VIS.DiaClave = TRP.DiaClave AND VIS.VisitaClave = TRP.VisitaClave 
	WHERE TRP.TransProdID = @TransprodID 
	
	select @VendedorId = @USUID, @RUTClave = @USUID  
	
	SET @DiaClave = RIGHT('00' + CONVERT(VARCHAR,DAY(@Fecha)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@Fecha)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@Fecha)),4)

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

	-- ACTUALIZA FASES EN TRANSPROD
	
	if @Opc = 1
	begin	
		update [Route].[dbo].[TransProd] set VisitaClave1 = @VisitaClave, DiaClave1 = @DiaClave,
			TipoFase = 2, TipoMovimiento = 2, FechaSurtido = @Fecha, 
			Saldo = @SaldoVenta, MFechaHora = GETDATE(), MUsuarioID = @USUID 
		where TransProdID = @TransprodID   
	
		--Cobranza (PagoAutomatico, CobrarVentas y Venta a Contado)		
		IF (SELECT TOP 1 CASE WHEN CobrarVentas = 1 AND PagoAutomatico = 1 THEN 1 ELSE 0 END FROM CONHist ORDER BY MFechaHora DESC) = 1 
			AND (SELECT CASE WHEN CFVTipo = 1 AND ClientePagoId = '1' THEN 1 ELSE 0 END FROM TransProd WHERE TransProdID = @TransprodID) = 1
		BEGIN
			DECLARE @ABNID AS VARCHAR(16)
			DECLARE @MonedaID AS VARCHAR(20)	

			SELECT @MonedaID = MonedaID FROM CONHist ORDER BY CONHistFechaInicio DESC

			SET @ABNID =  RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)				
			INSERT INTO Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioID)
				VALUES(@ABNID, @TransprodID, @Fecha, @VisitaClave, @DiaClave, @Fecha, @SaldoVenta, 0, GETDATE(), @USUID)
			
			INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
				VALUES(@ABNID, @TransProdID, @Fecha, @SaldoVenta, '','',1,GETDATE(), @USUID)
			
			INSERT INTO ABNDetalle (ABNId, ABDId, TipoPago, Importe, SaldoDeposito, MonedaId, Referencia, MFechaHora, MUsuarioID)
				VALUES(@ABNID, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), 1, @SaldoVenta, 0, @MonedaID, '', GETDATE(), @USUID)
				
			UPDATE TransProd SET Saldo = 0 WHERE TransProdID = @TransProdID 								
		END
		ELSE
			UPDATE Cliente SET SaldoEfectivo = SaldoEfectivo + @SaldoVenta WHERE ClienteClave = @ClienteClave
	end

	else
	
	begin
		update [Route].[dbo].[TransProd] set VisitaClave1 = @VisitaClave, DiaClave1 = @DiaClave,
			TipoFase = 0, FechaCancelacion = @Fecha, 
			Saldo = 0, MFechaHora = GETDATE(), MUsuarioID = @USUID 
		where TransProdID = @TransprodID   
	end

END



GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 27, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 27 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO