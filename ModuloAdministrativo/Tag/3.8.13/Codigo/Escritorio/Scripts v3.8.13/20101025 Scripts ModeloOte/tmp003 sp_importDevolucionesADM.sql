
declare @IdCedis as bigint, @IdSurtido as bigint, @Opc as int

SET @IdCedis = 2
SET @IdSurtido = 913
	
	DECLARE @DiaClave as VARCHAR(10)	
	DECLARE @ClienteClave as VARCHAR(16)
	DECLARE @Fecha as DATETIME
	DECLARE @IdDevolucion as INT
	DECLARE @FolioRoute as VARCHAR(16)
	DECLARE @IdCliente as INT
	DECLARE @IdProducto as BIGINT
	DECLARE @IdSucursal as VARCHAR(16)
	DECLARE @ModuloClave as VARCHAR(16)
	DECLARE @ModuloMovDetalleClave as VARCHAR(16)
	DECLARE @TipoMovimiento as SMALLINT
	DECLARE @ProductoClave as VARCHAR(10)
	DECLARE @Cantidad as DECIMAL(19,2)
	DECLARE @RUTClave as VARCHAR(10)
	DECLARE @TPDID as varchar(5)
	DECLARE @TransProdId as VARCHAR(16)
	DECLARE @USUID as VARCHAR(16)
	DECLARE @VendedorId as VARCHAR(16)
	DECLARE @VisitaClave as VARCHAR(16)	
	DECLARE @PrestamoCliente AS BIT	
	
	select @RUTClave = 'R' + RIGHT('00' + CONVERT(VARCHAR(2),IdRuta), 2), @Fecha = Fecha from RouteADM.dbo.Surtidos where IdSurtido = @IdSurtido
	SELECT TOP 1 @VendedorId= VendedorID FROM VenRut WHERE RUTClave = @RUTClave AND TipoEstado = 1
	
	SELECT @USUID = USUId, @ModuloClave = ModuloClave 
	FROM Vendedor 
	WHERE VendedorID = @VendedorId
			
	SELECT @ModuloMovDetalleClave = ModuloMovDetalleClave, @TipoMovimiento = TipoMovimiento
	FROM ModuloMovDetalle 
	WHERE TipoIndice = 13 AND TipoTransProd = 3 AND TipoEstado = 1 AND Baja = 0 AND ModuloClave = @ModuloClave	

	DECLARE CursorOD  CURSOR STATIC FOR	
		SELECT IdDevolucion, IdCliente, IdSucursal			
		FROM RouteADM.dbo.Devolucion
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and Status = 'A'
						
	OPEN CursorOD

	FETCH NEXT FROM CursorOD INTO @IdDevolucion, @IdCliente, @IdSucursal
	
	WHILE @@FETCH_STATUS = 0
	BEGIN				
		SET @FolioRoute =Convert(varchar,@IdCedis) +  RIGHT('00000000' + convert(varchar,@IdDevolucion),8 ) 
		SET @TransProdId = null
		
		SET @ClienteClave = CONVERT(VARCHAR(16),@IdSucursal)
		SELECT @PrestamoCliente = Prestamo FROM Cliente WHERE ClienteClave = @ClienteClave

		SELECT @TransProdId = TransProdID  FROM TransProd WHERE Folio = @FolioRoute AND Tipo=3
		IF @TransProdId IS NULL 
		BEGIN
			SET @DiaClave = RIGHT('00' + CONVERT(VARCHAR,DAY(@Fecha)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@Fecha)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@Fecha)),4)			

			IF(SELECT COUNT(*) FROM DIA WHERE DiaClave = @DiaClave )=0
				INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) 
				VALUES(@DiaClave,'','1',@Fecha,GETDATE(),@USUID)
		
			SET @VisitaClave = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)

			INSERT INTO Visita
			   (VisitaClave,DiaClave,ClienteClave,VendedorID,RUTClave
			   ,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS
			   ,MFechaHora,MUsuarioID)
			VALUES(@VisitaClave,@DiaClave,@ClienteClave,@VendedorId,@RUTClave
			   ,1,@Fecha,@Fecha,1,0,0,0,NULL
			   ,GETDATE(),@USUID)
			
			SET @TransProdId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
				
			INSERT INTO TransProd
				(TransProdID,VisitaClave,DiaClave,PCEModuloMovDetClave,Folio,Tipo,TipoFase,TipoMovimiento,
				FechaHoraAlta,FechaCaptura,TipoMotivo,Total,Saldo,Notas,TipoFaseIntSal,MFechaHora,MUsuarioID)
			VALUES(@TransProdId,@VisitaClave,@DiaClave,@ModuloMovDetalleClave,@FolioRoute,3,1,@TipoMovimiento,
				@Fecha,@Fecha,1,0,0,'',1, GETDATE(),@USUID)				
				
			--Detalle
			DECLARE CursorODD  CURSOR STATIC FOR
				SELECT IdProducto, Cantidad
				FROM RouteADM.dbo.DevolucionDetalle
				WHERE IdDevolucion = @IdDevolucion
						
			OPEN CursorODD
		
			FETCH NEXT FROM CursorODD INTO @IdProducto, @Cantidad
		
			WHILE @@FETCH_STATUS = 0
			BEGIN
				DECLARE @ProductoEnvase AS VARCHAR(10)
				DECLARE @PrestamoProducto AS BIT
				DECLARE @EsEnvase as BIT
				DECLARE @TipoUnidad as SMALLINT
			
				SET @TPDID = NULL 				
				SET @ProductoClave = RIGHT('00' + CONVERT(VARCHAR(10),@IdProducto), 2)
				SELECT @EsEnvase = Contenido FROM Producto where ProductoClave = @ProductoClave		
				SELECT @TipoUnidad = PRUTipoUnidad FROM ProductoDetalle WHERE ProductoClave = @ProductoClave AND ProductoClave = ProductoDetClave AND Factor = 1																																	
				
				SELECT @TPDID = TransProdDetalleID FROM TransProdDetalle WHERE TransProdID = @TransProdId AND ProductoClave = @ProductoClave
				IF @TPDID IS NULL 
				BEGIN					
					SET @TPDID = @ProductoClave
					INSERT INTO TransProdDetalle(
						TransProdID, TransProdDetalleID, ProductoClave,TipoUnidad,Partida,Cantidad,Precio,
						Subtotal,Total,TipoFaseIntSal, MFechaHora,MUsuarioID)
					VALUES(
						@TransProdId,@TPDID, @ProductoClave,@TipoUnidad,1,@Cantidad,0,						
						0,0,1,GETDATE(),@USUID)
						
					--Actualizar ProductoPrestamoCli si el Producto contiene envase o es envase y el cliente permite prestamo
					SET @ProductoEnvase = NULL
					SET @PrestamoProducto = 0
					
					IF @EsEnvase = 0 						
						SELECT @ProductoEnvase = PRD.ProductoDetClave 
						FROM ProductoDetalle PRD
						INNER JOIN Producto PRO ON PRD.ProductoDetClave = PRO.ProductoClave 
						WHERE PRD.ProductoClave <> PRD.ProductoDetClave AND PRO.Contenido = 1
						AND PRD.ProductoClave = @ProductoClave AND PRD.PRUTipoUnidad = @TipoUnidad 
					ELSE
						SET @ProductoEnvase = @ProductoClave 
					
					SELECT @PrestamoProducto = PRD.Prestamo 
					FROM Producto PRO
					INNER JOIN ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave = PRD.ProductoDetClave AND PRD.PRUTipoUnidad = @TipoUnidad 
					WHERE PRO.ProductoClave = @ProductoEnvase AND PRO.Contenido = 1

					--IF (@PrestamoCliente = 1 AND @PrestamoProducto = 1)
					--BEGIN				
					--	IF (SELECT COUNT(*) FROM ProductoPrestamoCli WHERE ClienteClave = @ClienteClave AND ProductoClave = @ProductoEnvase) = 0
					--		INSERT INTO ProductoPrestamoCli (ClienteClave, ProductoClave, Saldo, MFechaHora, MUsuarioID) 
					--		VALUES	(@ClienteClave, @ProductoEnvase, @Cantidad * -1, GETDATE(), @USUID)
					--	ELSE
					--		UPDATE ProductoPrestamoCli SET Saldo = Saldo + (@Cantidad * -1), MFechaHora = GETDATE(), MUsuarioID = @USUID 
					--		WHERE ClienteClave = @ClienteClave AND ProductoClave = @ProductoEnvase 								
					--END
					
				END
				
				FETCH NEXT FROM CursorODD INTO @IdProducto, @Cantidad
			END
			
			CLOSE CursorODD 
			DEALLOCATE CursorODD
			
		END
		
		FETCH NEXT FROM CursorOD INTO @IdDevolucion, @IdCliente, @IdSucursal
	END
	
	CLOSE CursorOD 
	DEALLOCATE CursorOD
	
