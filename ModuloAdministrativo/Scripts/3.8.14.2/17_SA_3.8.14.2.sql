USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_importVentasADM]    Script Date: 05/31/2011 13:56:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_importVentasADM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_importVentasADM]
GO

USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_importVentasADM]    Script Date: 05/31/2011 13:56:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
CREATE PROCEDURE [dbo].[sp_importVentasADM] 
	@idCedis int, @idSurtido int, @idTipoVenta int, @Folio int, @Serie as varchar(10)
AS
BEGIN
	SET NOCOUNT ON;

--DECLARE @Serie AS VARCHAR(5)
--declare @idCedis int, @idSurtido int, @idTipoVenta int, @Folio int
--set @idCedis = 1
--set @idSurtido = 5147
--set @idTipoVenta = 1
--set @Folio = 1517
--set @Serie='REM'

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
	DECLARE @ModuloMovDetalleClaveFAC AS VARCHAR(16)
	DECLARE @ModuloMovDetalleClaveVTA AS VARCHAR(16)
	DECLARE @ModuloMovDetalleClave AS VARCHAR(16)
	DECLARE @FolioRoute AS VARCHAR(16)
	DECLARE @TipoPedido AS SMALLINT
	DECLARE @TipoMovimiento AS SMALLINT
	DECLARE @TipoFase AS SMALLINT
	DECLARE @SaldoVenta AS MONEY
	declare @Tipo as smallint
	declare @SubempresaId as varchar(16)
	
	if(select COUNT(*) from FolioSolicitado where Serie = @Serie) > 0	
		set @Tipo = 8
	else
		set @Tipo = 1
		
	set @SubempresaId = (
	select top 1 PRO.IdMarca 
	from RouteADM.dbo.VentasDetalle VTA
	inner join RouteADM.dbo.Productos PRO on VTA.IdProducto = PRO.IdProducto 	
	WHERE IdCedis = @idCedis AND IdSurtido=@idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie )	
	
				
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
	DECLARE @DescVendPor AS FLOAT
	DECLARE @Descuento AS BIT
	DECLARE @FechaCobranza AS DATETIME
	
	SET @DescVendPor = 0		
	SET @Descuento =0
	SET @FechaCobranza = @Fecha
	
	SET @ClienteClave = CONVERT(VARCHAR(16),@idSucursal)
		
	SELECT @TransProdId = TransProdID  FROM TransProd WHERE Folio = @FolioRoute AND CFVTipo = @idTipoVenta and Tipo = @Tipo  
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

		
		SELECT @ModuloMovDetalleClaveVTA = ModuloMovDetalleClave, @TipoPedido = TipoPedido, @TipoMovimiento = TipoMovimiento  
		FROM ModuloMovDetalle 
		WHERE TipoIndice = 9 AND TipoTransProd = 1 AND TipoEstado = 1 AND Baja = 0 AND ModuloClave = @ModuloClave
	
		SELECT @ModuloMovDetalleClaveFAC = ModuloMovDetalleClave  
		FROM ModuloMovDetalle 
		WHERE TipoIndice = 25 AND TipoTransProd = 8 AND TipoEstado = 1 AND Baja = 0 AND ModuloClave = @ModuloClave
		
		IF @Tipo = 8
			SET @ModuloMovDetalleClave = @ModuloMovDetalleClaveFAC 
		ELSE
			SET @ModuloMovDetalleClave = @ModuloMovDetalleClaveVTA 
	
		DECLARE @FechaPrimera AS DATETIME		

		INSERT INTO [Route].[dbo].[TransProd]
			   ([TransProdID],[VisitaClave],[DiaClave],[PCEModuloMovDetClave],[SubEmpresaID],[ClienteClave],[ClientePagoID]
			   ,[CFVTipo],[Folio],[Tipo],[TipoPedido],[TipoFase],[TipoMovimiento]
			   ,[FechaHoraAlta],[FechaCaptura],[FechaEntrega],[FechaFacturacion],[FechaSurtido],[FechaCancelacion],[TipoMotivo]
			   ,[SubTDetalle],[DescVendPor],[DescuentoVendedor],[DescuentoImp],[Subtotal],[Impuesto],[Total],[Saldo]
			   ,[Promocion],[Descuento]
			   ,[TipoTurno],[FechaCobranza],[DiasCredito]
			   ,[TipoFaseIntSal],[MFechaHora],[MUsuarioID])
		VALUES(
			   @TransProdId,@VisitaClave,@DiaClave,@ModuloMovDetalleClave,@SubempresaId,@ClienteClave,'1'
			   ,@idTipoVenta,@FolioRoute,@Tipo,@TipoPedido,@TipoFase,@TipoMovimiento
			   ,@Fecha,@Fecha,@Fecha,@FechaPrimera,@Fecha,@FechaPrimera,0
			   ,@SubTotal,@DescVendPor,0,0,@SubTotal,@Iva,@SubTotal + @Iva,@SubTotal + @Iva
			   ,0,@Descuento
			   ,0,@FechaCobranza,0 
			   ,1,GETDATE(),@USUID)					   
		
		SET @SaldoVenta = @SubTotal + @Iva
		
		declare @SerieVenta varchar(5)
		declare @FolioVenta bigint
		declare @FolioVtaRoute varchar(16)
		declare @TransProdIdVta varchar(16)
		declare @VentaNueva bit		
		
		IF @Tipo = 8
		BEGIN
			select @SerieVenta = Serie, @FolioVenta = Folio from RouteADM.dbo.VentasRoute where SerieFactura = @Serie and FolioFactura = @Folio 
			set @FolioVtaRoute = @SerieVenta + RIGHT('0000000'+CONVERT(VARCHAR(8),@FolioVenta),7)			
			select @TransProdIdVta = TransProdID from TransProd where Tipo = 1 and Folio = @FolioVtaRoute 
			
			--Validar si existe la venta, sino crearla		
			if @TransProdIdVta is null 
			begin
				SET @TransProdIdVta = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)	
				
				INSERT INTO [Route].[dbo].[TransProd]
				   ([TransProdID],[VisitaClave],[DiaClave],[PCEModuloMovDetClave],[SubEmpresaID],[ClienteClave],[ClientePagoID]
				   ,[CFVTipo],[Folio],[Tipo],[TipoPedido],[TipoFase],[TipoMovimiento]
					,[FechaHoraAlta],[FechaCaptura],[FechaEntrega],[FechaFacturacion],[FechaSurtido],[FechaCancelacion],[TipoMotivo]
				   ,[SubTDetalle],[DescVendPor],[DescuentoVendedor],[DescuentoImp],[Subtotal],[Impuesto],[Total],[Saldo]
				   ,[Promocion],[Descuento]
				   ,[TipoTurno],[FechaCobranza],[DiasCredito]
				   ,[TipoFaseIntSal],[MFechaHora],[MUsuarioID])
					VALUES(
				   @TransProdIdVta,@VisitaClave,@DiaClave,@ModuloMovDetalleClaveVTA,@SubempresaId,@ClienteClave,'1'
				   ,@idTipoVenta,@FolioVtaRoute,1,@TipoPedido,@TipoFase,@TipoMovimiento
				   ,@Fecha,@Fecha,@Fecha,@Fecha,@Fecha,@FechaPrimera,0
				   ,@SubTotal,@DescVendPor,0,0,@SubTotal,@Iva,@SubTotal + @Iva,@SubTotal + @Iva
				   ,0,@Descuento
				   ,0,@FechaCobranza,0 
				   ,1,GETDATE(),@USUID)	
				   
				set @VentaNueva = 1
			end
			else
				set @VentaNueva = 0
		
			--Actualizar FacturaId para la venta relacionada
			update TransProd set FacturaID = @TransProdId, TipoFase = 3, FechaFacturacion = @Fecha, MFechaHora = GETDATE(), MUsuarioID = @USUID 
			where TransProdID = @TransProdIdVta 
			
		END	
		ELSE
			SET @TransProdIdVta = @TransProdId 
			

		IF @Tipo = 1 or @VentaNueva = 1
		BEGIN			
			IF(SELECT COUNT(*) FROM RouteADM.dbo.VentasDetalle WHERE IdCedis = @idCedis AND IdSurtido = @idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio AND Serie = @Serie )>0
			BEGIN
				--DELETE FROM TPDImpuesto WHERE TransProdID = @TransProdIdVta 
				--DELETE FROM TransProdDetalle WHERE TransProdID = @TransProdIdVta 
				
				DECLARE @IdProducto as BIGINT
				DECLARE @Cantidad AS DECIMAL(19,2)
				DECLARE @Precio AS MONEY
				DECLARE @IvaPor AS FLOAT
				DECLARE @IvaImp AS FLOAT
				DECLARE @ProductoClave AS VARCHAR(10)
				DECLARE @ImpuestoClave AS VARCHAR(16)
				--DECLARE @ProductoEnvase AS VARCHAR(10)
				--DECLARE @PrestamoProducto AS BIT
				--DECLARE @EsEnvase as BIT
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
					SET @ProductoClave = @IdProducto --RIGHT('00' + CONVERT(VARCHAR(10),@IdProducto), 2)			
					SET @IvaImp = ROUND((@Cantidad * @Precio) * @IvaPor ,2)
					--SET @PrestamoProducto = 0
					--SET @ProductoEnvase = NULL 
					
					--SELECT @EsEnvase = Contenido FROM Producto where ProductoClave = @ProductoClave 
					SELECT @TipoUnidad = PRUTipoUnidad FROM ProductoDetalle WHERE ProductoClave = @ProductoClave AND ProductoClave = ProductoDetClave AND Factor = 1								
					
					INSERT INTO TransProdDetalle(
						TransProdID, TransProdDetalleID, ProductoClave,TipoUnidad,Partida,
						Cantidad,Precio,DescuentoPor,DescuentoImp,Subtotal,Impuesto,Total,
						Promocion,TipoFaseIntSal, MFechaHora,MUsuarioID)
					VALUES(
						@TransProdIdVta,@ProductoClave, @ProductoClave,@TipoUnidad,1,
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
							@TransProdIdVta, @ProductoClave, @ProductoClave, @ImpuestoClave, (@IvaPor * 100), @IvaImp, GETDATE(),@USUID)						
					END
					
					FETCH NEXT FROM @CursorVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor
				END 
				CLOSE @CursorVar1  
				DEALLOCATE @CursorVar1
			
			END
		END
		
		--Cobranza (PagoAutomatico, CobrarVentas y Venta a Contado)
		declare @CobrarVentas as bit
		declare @PagoAutomatico as bit
		
		SELECT TOP 1 @CobrarVentas = CobrarVentas, @PagoAutomatico = PagoAutomatico FROM CONHist ORDER BY CONHistFechaInicio DESC
		
		if @Tipo = 1 and @CobrarVentas = 0
			update TransProd set Saldo = 0 where TransProdID = @TransProdIdVta 
		else if @Tipo = 8 
		begin
			if @CobrarVentas = 1	
				update TransProd set Saldo = 0 where TransProdID = @TransProdId
			else if @VentaNueva = 1
				update TransProd set Saldo = 0 where TransProdID = @TransProdIdVta 				
		end	
		
		
		IF @IdTipoVenta = 1 and @PagoAutomatico = 1 and ((@Tipo = 1 and @CobrarVentas = 1) or (@Tipo = 8 and (@CobrarVentas = 0 or @VentaNueva = 1)))
		BEGIN
			DECLARE @ABNID AS VARCHAR(16)
			DECLARE @MonedaID AS VARCHAR(20)	
	
			SELECT @MonedaID = MonedaID FROM CONHist ORDER BY CONHistFechaInicio DESC
	
			SET @ABNID =  RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)				
			INSERT INTO Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioID)
			VALUES(@ABNID, @FolioRoute, @FechaCobranza, @VisitaClave, @DiaClave, @FechaCobranza, @SaldoVenta, 0, GETDATE(), @USUID)
			
			if @Tipo = 1 and @CobrarVentas = 1			
				INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
				VALUES(@ABNID, @TransProdIdVta, @FechaCobranza, @SaldoVenta, '','',1,GETDATE(), @USUID)
			else if @Tipo = 8
			begin
				if @CobrarVentas = 0
					INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
					VALUES(@ABNID, @TransProdId, @FechaCobranza, @SaldoVenta, '','',1,GETDATE(), @USUID)
				else if @VentaNueva = 1
					INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
					VALUES(@ABNID, @TransProdIdVta, @FechaCobranza, @SaldoVenta, '','',1,GETDATE(), @USUID)
			end
				
			
			INSERT INTO ABNDetalle (ABNId, ABDId, TipoPago, Importe, SaldoDeposito, MonedaId, Referencia, MFechaHora, MUsuarioID)
			VALUES(@ABNID, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), 1, @SaldoVenta, 0, @MonedaID, '', GETDATE(), @USUID)
				
			
			if @Tipo = 1 and @CobrarVentas = 1			
				UPDATE TransProd SET Saldo = 0 WHERE TransProdID = @TransProdIdVta
			else if @Tipo = 8
			begin
				if @CobrarVentas = 0
					UPDATE TransProd SET Saldo = 0 WHERE TransProdID = @TransProdId
				else if @VentaNueva = 1
					UPDATE TransProd SET Saldo = 0 WHERE TransProdID = @TransProdIdVta
			end
			
		END			
		ELSE
			UPDATE Cliente SET SaldoEfectivo = SaldoEfectivo + @SaldoVenta WHERE ClienteClave = @ClienteClave			
		END	
		
end
GO


