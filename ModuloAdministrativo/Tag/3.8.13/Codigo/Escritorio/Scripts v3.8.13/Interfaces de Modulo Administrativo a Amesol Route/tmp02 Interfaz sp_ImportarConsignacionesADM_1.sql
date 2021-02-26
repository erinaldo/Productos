USE [Route]
GO
/****** Object:  StoredProcedure [dbo].[sp_importConsignacionesADM]    Script Date: 09/14/2010 11:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 --=============================================
 --Author:		DAVID MORENO
 --Create date: 09/08/2010
 --Description:	INTERFAZ DE ENTRADA DEL MODULO ADMINISTRATIVO A ROUTE
 --=============================================
ALTER PROCEDURE [dbo].[sp_importConsignacionesADM] 
@IdCedis as bigint,
@IdSurtido as bigint,
@Opc as int

AS

BEGIN
	SET NOCOUNT ON;
	
--SET @IdCedis = 3
--SET @IdSurtido = 1361 
--SET @Opc = 1
	
	DECLARE @DiaClave as VARCHAR(10)
	DECLARE @Surtido as DECIMAL(19,2)
	DECLARE @Devolucion as DECIMAL(19,2)
	DECLARE @ClienteClave as VARCHAR(16)
	DECLARE @Fecha as DATETIME
	DECLARE @FechaCobranza as DATETIME
	DECLARE @Folio as INT
	DECLARE @FolioLiq as INT
	DECLARE @FolioRoute as VARCHAR(16)
	DECLARE @IdConsigna as INT
	DECLARE @IdCliente as INT
	DECLARE @IdProducto as BIGINT
	DECLARE @IdRuta as INT
	DECLARE @IdRutaD as INT
	DECLARE @IdSucursal as VARCHAR(16)
	DECLARE @Impuestos as MONEY
	DECLARE @ModuloClave as VARCHAR(16)
	DECLARE @ModuloMovDetalleClave as VARCHAR(16)
	DECLARE @Notas as varchar(5000)
	DECLARE @Precio as MONEY
	DECLARE @PrecioClave as SMALLINT
	DECLARE @ProductoClave as VARCHAR(10)
	DECLARE @RUTClave as VARCHAR(10)
	DECLARE @Serie as varchar(5)
	DECLARE @SerieLiq as varchar(5)
	DECLARE @Subtotal as MONEY
	DECLARE @TipoMovimiento as SMALLINT
	DECLARE @TipoPedido as SMALLINT
	DECLARE @Total as MONEY
	DECLARE @TPDID as varchar(5)
	DECLARE @TransProdId as VARCHAR(16)
	DECLARE @USUID as VARCHAR(16)
	DECLARE @VendedorId as VARCHAR(16)
	DECLARE @VisitaClave as VARCHAR(16)
	DECLARE @Venta as MONEY
	DECLARE @VentaTotal as MONEY
	DECLARE @ABNId AS VARCHAR(16)
	DECLARE @MonedaID AS VARCHAR(20)	
	DECLARE @IVA AS DECIMAL(2,2)
	
	DECLARE @status as varchar(1)
	DECLARE @check as SMALLINT
	DECLARE @cont as INT;

	SELECT @MonedaID = MonedaID FROM CONHist ORDER BY CONHistFechaInicio DESC

	DECLARE CursorOD  CURSOR STATIC
		FOR	
			SELECT IdConsigna, IdRutaEntrega, IdSucursal, IdCliente, FechaEntrega, FechaDevolucion, IdMovimientoEntrega, Serie, Observaciones,status, IdSurtidoDevolucion, IdMovimientoDevolucion, IdRutaDevolucion
			FROM RouteADM.dbo.Consignas
			where IdCedis = @IdCedis and ((IdSurtidoEntrega = @IdSurtido and Status = 'E') or (IdSurtidoDevolucion = @IdSurtido and Status = 'V'))
						
	OPEN CursorOD

	FETCH NEXT FROM CursorOD INTO @IdConsigna, @IdRuta, @IdSucursal, @IdCliente, @Fecha, @FechaCobranza, @Folio, @Serie, @Notas, @status, @folioliq, @serieliq, @IdRutaD
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @status='E' OR @status = 'V'
		BEGIN
			SET @check = 0
			SET @cont = 0
		
			if @status = 'E'
			begin
				SET @RUTClave = 'R'+ CONVERT(VARCHAR(2),@idRuta)
			end
			else
				set @RUTClave = 'R'+ CONVERT(VARCHAR(2),@IdRutaD)
			
				
			SELECT TOP 1 @VendedorId= VendedorID FROM VenRut WHERE RUTClave = @RUTClave AND TipoEstado = 1
	 
			SELECT @USUID = USUId, @ModuloClave = ModuloClave 
			FROM Vendedor 
			WHERE VendedorID = @VendedorId

			SET @FolioRoute = CONVERT(VARCHAR(8),@Folio)
			SET @VentaTotal = 0

			SET @TransProdId = null

			SELECT @TransProdId = TransProdID  FROM TransProd WHERE Folio = @FolioRoute AND Tipo=24
			IF @TransProdId IS NULL
			BEGIN
				SET @DiaClave = RIGHT('00' + CONVERT(VARCHAR,DAY(@Fecha)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@Fecha)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@Fecha)),4)
			

				IF(SELECT COUNT(*) FROM DIA WHERE DiaClave = @DiaClave )=0
					INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) 
					VALUES(@DiaClave,'','1',@Fecha,GETDATE(),@USUID)
			
				SET @VisitaClave = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
				
				SET @ClienteClave = CONVERT(VARCHAR(16),@IdSucursal)

				INSERT INTO Visita
				   (VisitaClave,DiaClave,ClienteClave,VendedorID,RUTClave
				   ,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS
				   ,MFechaHora,MUsuarioID)
				VALUES(@VisitaClave,@DiaClave,@ClienteClave,@VendedorId,@RUTClave
				   ,1,@Fecha,@Fecha,1,0,0,0,NULL
				   ,GETDATE(),@USUID)
				   
					DECLARE @FechaPrimera AS DATETIME
					SET @FechaPrimera = '1900-01-01 00:00:00.000'
			
					SET @TransProdId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
			
					SELECT @ModuloMovDetalleClave = ModuloMovDetalleClave, @TipoMovimiento = TipoMovimiento, @TipoPedido = TipoPedido
					FROM ModuloMovDetalle 
					WHERE TipoIndice = 26 AND TipoTransProd = 24 AND TipoEstado = 1 AND Baja = 0 AND ModuloClave = @ModuloClave
			
					DECLARE @SubTotalT as MONEY
					DECLARE @TotalT as MONEY
					DECLARE @ImpuestosT as MONEY
			
					SELECT  @SubTotalT = SUM(Subtotal), @TotalT = SUM(Total)
					FROM	RouteADM.dbo.ConsignasDetalle
					WHERE	IdConsigna = @IdConsigna
			
					SET @ImpuestosT = @TotalT - @SubTotalT
					
					SELECT TOP 1 @PrecioClave =	PrecioClave 
											FROM PrecioClienteEsquema
											WHERE ModuloMovDetalleClave = @ModuloMovDetalleClave
											AND EsquemaID = (	SELECT TOP 1 EsquemaID 
																FROM ClienteEsquema 
																WHERE ClienteClave = @ClienteClave
																ORDER BY MFechaHora)
				IF @status = 'E'
					BEGIN
					INSERT INTO TransProd
						(TransProdID,VisitaClave,DiaClave,PCEModuloMovDetClave,ClienteClave,PCEPrecioClave,
						Folio,Tipo,TipoPedido,TipoFase,TipoMovimiento,FechaHoraAlta,FechaCaptura,FechaEntrega,
						FechaFacturacion,FechaSurtido,FechaCancelacion,TipoMotivo,SubTDetalle,DescVendPor,
						DescuentoVendedor,DescuentoImp,Subtotal,Impuesto,Total,Saldo,Promocion,Descuento,TipoTurno,
						FechaCobranza,DiasCredito,TipoFaseIntSal,Notas,MFechaHora,MUsuarioID)
					VALUES(@TransProdId,@VisitaClave,@DiaClave,@ModuloMovDetalleClave,@ClienteClave,@PrecioClave, @FolioRoute,24,
						@TipoPedido,2,@TipoMovimiento,@Fecha,@Fecha,@Fecha,@FechaPrimera,@Fecha,@FechaPrimera,
						0,@SubTotalT,0,0,0,@SubTotalT,@ImpuestosT,@TotalT,@TotalT,0,0,0,@FechaPrimera,0,1,@Notas, GETDATE(),@USUID)
				END
				IF @status = 'V'
				BEGIN
					DECLARE @DiaClave1 as VARCHAR(10)
					DECLARE @VisitaClave1 as VARCHAR(16)
					DECLARE @TransProdId1 as VARCHAR(16)
					DECLARE @FolioRouteLiq as VARCHAR(16)
					DECLARE @TipoMovimiento1 as SMALLINT
					DECLARE @TipoPedido1 as SMALLINT
					DECLARE @ModuloMovDetalleClave1 as VARCHAR(16)
			
					SET @DiaClave1 = RIGHT('00' + CONVERT(VARCHAR,DAY(@FechaCobranza)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@FechaCobranza)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@FechaCobranza)),4)
			
					IF(SELECT COUNT(*) FROM DIA WHERE DiaClave = @DiaClave1 )=0
					INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) 
					VALUES(@DiaClave1,'','1',@FechaCobranza,GETDATE(),@USUID)
			
					SET @VisitaClave1 = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
				
					INSERT INTO Visita
						(VisitaClave,DiaClave,ClienteClave,VendedorID,RUTClave
						,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS
						,MFechaHora,MUsuarioID)
					VALUES(@VisitaClave1,@DiaClave1,@ClienteClave,@VendedorId,@RUTClave
						,1,@FechaCobranza,@FechaCobranza,1,0,0,0,NULL
						,GETDATE(),@USUID)
				
					SET @TransProdId1 = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
				
					SET @FolioRouteLiq = @Serieliq + RIGHT('0000000'+CONVERT(VARCHAR(8),@Folioliq),7)
				
					SELECT @ModuloMovDetalleClave1 = ModuloMovDetalleClave, @TipoMovimiento1 = TipoMovimiento, @TipoPedido1 = TipoPedido
					FROM ModuloMovDetalle 
					WHERE TipoIndice = 13 AND TipoTransProd = 3 AND TipoEstado = 1 AND Baja = 0 AND ModuloClave = @ModuloClave
				
					--Devolucion
					INSERT INTO TransProd
						(TransProdID,VisitaClave,DiaClave,PCEModuloMovDetClave, ClienteClave, PCEPrecioClave,
						Folio,Tipo,TipoPedido,TipoFase,TipoMovimiento,FechaHoraAlta,FechaCaptura,FechaEntrega,
						FechaFacturacion,FechaSurtido,FechaCancelacion,TipoMotivo,SubTDetalle,DescVendPor,
						DescuentoVendedor,DescuentoImp,Subtotal,Impuesto,Total,Saldo,Promocion,Descuento,TipoTurno,
						DiasCredito,TipoFaseIntSal,Notas,MFechaHora,MUsuarioID)
					VALUES(@TransProdId1,@VisitaClave1,@DiaClave1,@ModuloMovDetalleClave1,@ClienteClave,@PrecioClave, @FolioRouteLiq,3,
						@TipoPedido1,1,@TipoMovimiento1,@FechaCobranza,@FechaCobranza,@FechaCobranza,@FechaPrimera,@FechaCobranza,@FechaPrimera,
						12,0,0,0,0,0,0,0,0,0,0,0,0,0,@Notas, GETDATE(),@USUID)	
				
					--Consigna
					INSERT INTO TransProd
						(TransProdID,VisitaClave,DiaClave,VisitaClave1, DiaClave1,PCEModuloMovDetClave, ClienteClave,PCEPrecioClave,
						Folio,Tipo,TipoPedido,TipoFase,TipoMovimiento,FechaHoraAlta,FechaCaptura,FechaEntrega,
						FechaFacturacion,FechaSurtido,FechaCancelacion,TipoMotivo,SubTDetalle,DescVendPor,
						DescuentoVendedor,DescuentoImp,Subtotal,Impuesto,Total,Saldo,Promocion,Descuento,TipoTurno,
						FechaCobranza,DiasCredito,TipoFaseIntSal,Notas,MFechaHora,MUsuarioID)
					VALUES(@TransProdId,@VisitaClave,@DiaClave,@VisitaClave1, @DiaClave1,@ModuloMovDetalleClave,@ClienteClave,@PrecioClave, @FolioRoute,24,
						@TipoPedido,6,@TipoMovimiento,@Fecha,@Fecha,@Fecha,@FechaCobranza,@Fecha,@FechaPrimera,
						0,@SubTotalT,0,0,0,@SubTotalT,@ImpuestosT,@TotalT,@TotalT,0,0,0,@FechaCobranza,0,2,@Notas, GETDATE(),@USUID)
					

					
				END
				SET @check = 1
			END
			
			IF @check = 0
			BEGIN
				SELECT  @SubTotalT = SUM(Subtotal), @TotalT = SUM(Total)
				FROM	RouteADM.dbo.ConsignasDetalle
				WHERE	IdConsigna = @IdConsigna
			
				SET @ImpuestosT = @TotalT - @SubTotalT
			
				UPDATE TransProd 
				SET MUsuarioID = @USUID , MFechaHora = GETDATE(),Subtotal = @SubTotalT, 
				SubTDetalle = @SubTotalT, Impuesto = @ImpuestosT, Total = @TotalT
				WHERE TransProdID = @TransProdId 
			END
						
			DECLARE CursorODD  CURSOR STATIC
			FOR
			SELECT Surtido, Devolucion, Venta, IdProducto, Precio, IVA, Subtotal, Total
			FROM RouteADM.dbo.ConsignasDetalle
			WHERE IdConsigna = @IdConsigna
						
			OPEN CursorODD
		
			FETCH NEXT FROM CursorODD INTO @Surtido, @Devolucion, @Venta, @IdProducto, @Precio, @IVA, @Subtotal, @Total
		
			WHILE @@FETCH_STATUS = 0
			BEGIN
				SET @cont = @cont + 1
				
				SET @check = 0
			
				SET @Impuestos = @Total-@Subtotal
				
				SET @TPDID = '00' + CONVERT(VARCHAR(2), @cont)
				
				IF @IdProducto <10
				BEGIN
					SET @ProductoClave = '0' + CONVERT(VARCHAR(2), @IdProducto)
				END
				IF @IdProducto > 9
				BEGIN
					SET @ProductoClave = CONVERT(VARCHAR(10),@IdProducto)
				END
				
				DECLARE @TotalDev AS MONEY
				DECLARE @ImpuestoDev as MONEY
				
				SET @TotalDev = (@Devolucion*@Precio)*(1+@IVA)
				SET @ImpuestoDev = @TotalDev - (@Devolucion*@Precio) 
				
				IF (SELECT TransProdID from TransProdDetalle WHERE TransProdDetalleID = @TPDID AND (TransProdID = @TransProdId OR TransProdID = @TransProdId1)) is null
				BEGIN
					INSERT INTO TransProdDetalle(
						TransProdID, TransProdDetalleID, ProductoClave,TipoUnidad,Partida,
						Cantidad,Precio,DescuentoPor,DescuentoImp,Subtotal,Impuesto,Total,
						Promocion,TipoFaseIntSal, MFechaHora,MUsuarioID)
					VALUES(
						@TransProdId,@TPDID, @ProductoClave,2,1,
						@Surtido,@Precio,0,0,@Subtotal, @Impuestos,@Total,
						0,1,GETDATE(),@USUID)
			
					IF @status = 'V'
					BEGIN		
						INSERT INTO TransProdDetalle(TransProdID, TransProdDetalleID, ProductoClave,TipoUnidad,Partida,
							Cantidad,Precio,DescuentoPor,DescuentoImp,Subtotal,Impuesto,Total,
							Promocion,TipoFaseIntSal, MFechaHora,MUsuarioID)
						VALUES(@TransProdId1,@TPDID, @ProductoClave,2,1,
							@Devolucion,@Precio,0,0,(@Devolucion*@Precio),@ImpuestoDev,@TotalDev,
							0,1,GETDATE(),@USUID)
					
						INSERT INTO TrpTpd(TransProdID, TransProdID1, TransProdDetalleID, Cantidad, Precio, Subtotal,
										Impuesto, Total, MFechaHora, MUsuarioID)
						VALUES(@TransProdId1, @TransProdId, @TPDID, @Devolucion, @Precio, (@Devolucion*@Precio), @ImpuestoDev,
							@TotalDev, GETDATE(), @USUID)
					
						SET @VentaTotal = @VentaTotal + (@Venta*@Precio)*(1+@IVA)
					END
					
					SET @check = 1
				END
				IF @check = 0
				BEGIN
					UPDATE	TransProdDetalle
					SET		Cantidad = @Surtido,Precio = @Precio, Subtotal = @Subtotal,Impuesto = @Impuestos,
							Total = @Total,MFechaHora = GETDATE()
					WHERE TransProdDetalleID = @ProductoClave AND TransProdID = @transprodid
			
					IF @status = 'V'
					BEGIN
						UPDATE	TransProdDetalle
						SET		Cantidad = @Devolucion,Precio = @Precio, Subtotal = (@Devolucion*@Precio),Impuesto = @ImpuestoDev,
							Total = @TotalDev,MFechaHora = GETDATE()
						WHERE TransProdDetalleID = @ProductoClave AND transprodid = @transprodid1
					
						UPDATE	TrpTpd
						SET		Cantidad = @Devolucion, Precio = @Precio, Subtotal = (@Devolucion*@Precio),
										Impuesto = @ImpuestoDev, Total= @TotalDev, MFechaHora = GETDATE()
						WHERE	TransProdId = @TransProdId1 AND TransProdDetalleID = @ProductoClave
						
						SET @VentaTotal = @VentaTotal + (@Venta*@Precio)*(1+@IVA)
					END
				END
			FETCH NEXT FROM CursorODD INTO @Surtido, @Devolucion, @Venta, @IdProducto, @Precio, @IVA, @Subtotal, @Total
			END
			
			CLOSE CursorODD 
			DEALLOCATE CursorODD
			
			--COBRANZA PARA LAS CONSIGNAS LIQUIDADAS	
			IF @status = 'V'
			BEGIN		
				IF NOT EXISTS(SELECT * FROM Abono WHERE Folio = @FolioRoute)
				BEGIN
					SET @ABNID =  RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)				
					INSERT INTO Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioID)
						VALUES(@ABNID, @Folio, @FechaCobranza, @VisitaClave, @DiaClave, @FechaCobranza, @VentaTotal, 0, GETDATE(), @USUID)
					
					INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
						VALUES(@ABNID, @TransProdID, @FechaCobranza, @VentaTotal, '','',1,GETDATE(), @USUID)
					
					INSERT INTO ABNDetalle (ABNId, ABDId, TipoPago, Importe, SaldoDeposito, MonedaId, Referencia, MFechaHora, MUsuarioID)
						VALUES(@ABNID, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), 1, @VentaTotal, 0, @MonedaID, '', GETDATE(), @USUID)
						
					UPDATE TransProd SET Saldo = 0 WHERE TransProdID = @TransProdID 					
				END
			END
		
		END		
		
		FETCH NEXT FROM CursorOD INTO @IdConsigna, @IdRuta, @IdSucursal, @IdCliente, @Fecha, @FechaCobranza, @Folio, @Serie, @Notas, @status, @folioliq, @serieliq, @IdRutaD
	END
	
	CLOSE CursorOD 
	DEALLOCATE CursorOD
	
END

