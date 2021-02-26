USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_tg_ExportManagement]    Script Date: 08/25/2011 14:59:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tg_ExportManagement]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tg_ExportManagement]
GO

USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_tg_ExportManagement]    Script Date: 08/25/2011 14:59:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO








CREATE PROCEDURE [dbo].[sp_tg_ExportManagement] 
@FechaIN AS DATETIME, @FechaFIN AS DATETIME, @Vende AS VARCHAR(20)
AS
BEGIN
	SET DATEFORMAT DMY;
	SET XACT_ABORT OFF    
	SET NOCOUNT OFF  

	SET ROWCOUNT 0 

	--DECLARE @FechaIN AS DATETIME, @FechaFIN AS DATETIME, @Vende AS VARCHAR(20)
	--SET @FechaIN = '2010-09-27 00:00:00.000'
	--SET @FechaFIN = '2010-09-27 23:59:59.999'
	--SET @Vende = 'user11'

	DECLARE @ClaveCEDI AS VARCHAR(20)
	DECLARE @DiaClave AS VARCHAR(20)
	DECLARE @RUTClave AS VARCHAR(20)
	DECLARE @Surtido AS VARCHAR(20)
	DECLARE @Dia AS DATETIME	
	
	DECLARE @FechaIniCompara DATETIME
	SET @FechaIniCompara = CONVERT(DATETIME,'9999-12-31',102)
	
	DECLARE @TipoModulo AS SMALLINT	
	
	SELECT @TipoModulo = MDT.TipoIndice FROM Vendedor VEN
	INNER JOIN ModuloTerm MDT ON VEN.ModuloClave = MDT.ModuloClave 
	where VendedorID = @Vende
	
	IF @TipoModulo <> 2 --Solo si no es Preventa 
	BEGIN

		DECLARE  @esta AS INT, @leng AS VARCHAR(10)  

		SET @leng = (SELECT TOP 1 TipoLenguaje FROM CONHist WHERE CONHistFechaInicio <= getdate() ORDER BY CONHistFechaInicio DESC)  
		SET @esta = (SELECT TOP 1 INTUnidadVta FROM CONHist WHERE CONHistFechaInicio <= getdate() ORDER BY CONHistFechaInicio DESC) 

		--Obtiene los diAS a ExpORtar
		DECLARE @CursorVar1 CURSOR  
		SET @CursorVar1 = CURSOR SCROLL DYNAMIC FOR 
			SELECT DISTINCT D.DiaClave, D.FechaCaptura
			FROM TransProd TP
			INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
			INNER JOIN USUARIO U ON U.USUId = TP.MUsuarioID
			WHERE TP.Tipo IN(1,2,23) AND TP.TipoFase <> 0 
			AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
			AND  (U.clave = @Vende) 
			UNION 		
			SELECT DISTINCT Dia.DiaClave, Dia.FechaCaptura 
			FROM TransProd TRP 
			INNER JOIN Visita VIS ON TRP.VisitaClave1 = VIS.VisitaClave AND TRP.DiaClave1 = VIS.DiaClave
			INNER JOIN Dia ON Dia.DiaClave = VIS.DiaClave
			INNER JOIN Vendedor VEN ON VIS.VendedorID = VEN.VendedorId
			INNER JOIN Usuario USU ON USU.USUId = VEN.USUId
			WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2
			AND ((TRP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TRP.TipoFaseIntSal IN (0,2)))
			AND (USU.Clave = @Vende) 

		OPEN @CursorVar1
		FETCH NEXT FROM @CursorVar1 INTO @DiaClave, @Dia
		WHILE @@FETCH_STATUS = 0      
		BEGIN 
		
			IF((SELECT COUNT(*) AS RegIStros FROM (
				SELECT VisitaClave FROM Visita VIS 
				INNER JOIN Vendedor VEN ON VIS.VendedorID = VEN.VendedorID 
				INNER JOIN Usuario USU ON VEN.USUId = USU.USUId 
				WHERE USU.Clave = @Vende AND VIS.DiaClave = @Diaclave
				UNION
				SELECT TransProdID FROM TransProd TRP
				INNER JOIN Usuario USU ON TRP.MUsuarioID = USU.USUId 
				WHERE TRP.Tipo IN (4,7) AND TRP.TipoFase <> 0 
				AND USU.Clave = @Vende AND TRP.DiaClave = @Diaclave
				) AS t1 )>0 OR @TipoModulo = 3)
			BEGIN

				--Recupera el CEDI y la Ruta
				SELECT TOP 1 @ClaveCEDI = ALMClave, @RUTClave = RUTClave FROM(
					SELECT DISTINCT   ALM.Clave AS ALMClave, VIS.RUTClave 
					FROM Visita VIS 
					INNER JOIN Vendedor VEN ON VIS.VendedorID = VEN.VendedorID 
					INNER JOIN Usuario USU ON VEN.USUId = USU.USUId AND VEN.TipoEstado = 1
					INNER JOIN VENCentroDIStHISt VCH ON VEN.VendedorID = VCH.VendedorId AND VCHFechaINicial <= @Dia AND FechaFINal >= @Dia
					INNER JOIN Almacen ALM ON VCH.AlmacenId = ALM.AlmacenID 
					WHERE USU.Clave = @Vende AND VIS.DiaClave = @Diaclave
					UNION
					SELECT DISTINCT   ALM.Clave, VRT.RUTClave 
					FROM TransProd TRP
					INNER JOIN Usuario USU ON TRP.MUsuarioID = USU.USUId 
					INNER JOIN Vendedor VEN ON USU.USUId = VEN.USUId AND VEN.TipoEstado = 1
					INNER JOIN VENCentroDIStHISt VCH ON VEN.VendedorID = VCH.VendedorId AND VCHFechaINicial <= @Dia AND FechaFINal >= @Dia
					INNER JOIN Almacen ALM ON VCH.AlmacenId = ALM.AlmacenID 
					INNER JOIN VenRut VRT ON VEN.VendedorID = VRT.VendedorID AND VRT.TipoEstado = 1
					WHERE TRP.Tipo IN (2,4,7) AND TRP.TipoFase <> 0 
					AND USU.Clave = @Vende AND TRP.DiaClave = @Diaclave
				) AS t1

				DECLARE @idRuta AS INT             
				SET @idRuta = RIGHT(dbo.FNObtenerRutaADMINTer(@RUTClave),4)
				SET @ClaveCEDI = dbo.FNObtenerCediADMINTer(@ClaveCEDI)

				DECLARE @IdCarga AS INT
				--Recupera Surtido y carga
				SELECT TOP 1 @Surtido=IdSurtido, @IdCarga = IdCarga
				FROM [RouteADM].dbo.CargAS 
				WHERE idCedIS=CAST(@ClaveCEDI AS INT) AND idRuta= @idRuta AND Fecha=@Dia 

				IF @Surtido IS NOT NULL
				BEGIN

					IF NOT EXISTS (SELECT IdCedIS FROM [RouteADM].dbo.StatusSurtido WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido ) 
					INSERT INTO [RouteADM].dbo.StatusSurtido VALUES ( @ClaveCEDI, @Surtido, 'B' )
					
					
					---------------------------ACTUALIZA LOS OBSEQUIOS POR Promocion---------------------------------------------------
					---------------SE ENVIARAN AL ADM SOLO LOS PEDIDOS DE CONTADO Y CREDITO SALDADOS EL DIA DE TRABAJO-----------------

					UPDATE [RouteADM].dbo.SurtidosDetALLe SET Obsequios=Obsequios+a.Cantidad
					FROM [RouteADM].dbo.SurtidosDetALLe AS b
					INNER JOIN (
						SELECT ProductoClave,SUM(cantidad)AS Cantidad
						FROM (
						--Reparto
							SELECT td.ProductoClave,td.cantidad
							FROM TransProd AS TP
							INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave1 AND V.DiaClave = TP.DiaClave1 
							INNER JOIN TransProdDetalle AS TD ON TD.TransProdID = TP.TransProdID
							INNER JOIN Producto P ON P.ProductoClave = TD.ProductoClave  
							INNER JOIN Vendedor VE ON VE.VendedorId = V.VendedorId
							INNER JOIN Usuario AS Us ON Us.USUId = VE.USUId
							WHERE TP.Tipo=1 AND TP.TipoFase IN (2,3) AND td.Promocion=2 AND (TP.CFVTipo = 1 OR (TP.CFVTipo = 2 AND TP.Saldo = 0))
							AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (Us.Clave = @Vende AND TP.DiaClave1 = @DiaClave) 
							UNION ALL
							--Venta directa
							SELECT td.ProductoClave,td.cantidad 
							FROM TransProd AS TP
							INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave
							INNER JOIN TransProdDetalle AS TD ON TD.TransProdID = TP.TransProdID
							INNER JOIN Producto P ON P.ProductoClave = TD.ProductoClave  
							INNER JOIN Vendedor VE ON VE.VendedorId = V.VendedorId
							INNER JOIN Usuario AS Us ON Us.USUId = VE.USUId
							WHERE TP.Tipo=1 AND TP.TipoFase IN (2,3) AND td.Promocion=2 AND (TP.CFVTipo = 1 OR (TP.CFVTipo = 2 AND TP.Saldo = 0))
							AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
							AND  (Us.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						) AS T
						GROUP BY ProductoClave
					) AS a ON b.IdProducto = CAST(a.ProductoClave AS INT)
					WHERE b.IdSurtido=@Surtido AND b.IdCedIS=@ClaveCEDI
					
					---------------------------------------------------------------------------------------------------------
					------------------------CAMBIOS DE PRODUCTO -------------------------------------------------------------
					DECLARE @Cantidad AS FLOAT
					DECLARE @ProductoClave AS INT

					UPDATE [RouteADM].dbo.SurtidosDetALLe SET Obsequios=Obsequios+a.Cantidad
					FROM
					[RouteADM].dbo.SurtidosDetALLe AS b
					INNER JOIN (
						SELECT TD.ProductoClave, SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario U ON U.USUId = VEN.USUId 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						WHERE TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 2
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 
					) AS a ON b.IdProducto = CAST(a.ProductoClave AS INT)
					WHERE b.IdSurtido=@Surtido AND b.IdCedIS=@ClaveCEDI

					UPDATE [RouteADM].dbo.SurtidosCambios SET Entrada=Entrada+a.Cantidad
					FROM
					[RouteADM].dbo.SurtidosDetALLe AS b
					INNER JOIN (
						SELECT TD.ProductoClave, SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario U ON U.USUId = VEN.USUId 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						WHERE TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 1
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 
					) AS a ON b.IdProducto = CAST(a.ProductoClave AS INT)
					WHERE b.IdSurtido=@Surtido AND b.IdCedIS=@ClaveCEDI

					UPDATE [RouteADM].dbo.SurtidosCambios SET Salida=Salida+a.Cantidad
					FROM
					[RouteADM].dbo.SurtidosDetALLe AS b
					INNER JOIN (
						SELECT TD.ProductoClave, SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario U ON U.USUId = VEN.USUId 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						WHERE TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 2
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 
					) AS a ON b.IdProducto = CAST(a.ProductoClave AS INT)
					WHERE b.IdSurtido=@Surtido AND b.IdCedIS=@ClaveCEDI

					---------------------------------------------------------------------------------------------------------
					----------------AGREGA LOS PRODUCTOS DEVUELTOS POR EL CLIENTE--------------------------------------------

					DECLARE @CursORDev CURSOR  

					SET @CursORDev = CURSOR SCROLL DYNAMIC FOR 
						SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario U ON U.USUId = VEN.USUId 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						WHERE ((TP.Tipo = 3 AND TP.TipoFase <> 0) OR (TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 1)) 
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 

					OPEN  @CursORDev
					FETCH NEXT FROM @CursORDev INTO @ProductoClave, @Cantidad
					WHILE @@FETCH_STATUS = 0      
					BEGIN 
						IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosCargAS WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND  IdCarga = @IdCarga AND IdProducto = @ProductoClave )>0
						BEGIN
							UPDATE RouteADM.dbo.SurtidosCargAS SET Cantidad = Cantidad + @Cantidad WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND  IdCarga = @IdCarga AND IdProducto = @ProductoClave
						END
						ELSE
						BEGIN
							INSERT INTO RouteADM.dbo.SurtidosCargAS(IdCedIS, IdSurtido , IdCarga , IdProducto ,Cantidad )
							VALUES(@ClaveCEDI,@Surtido,@IdCarga,@ProductoClave,@Cantidad)
						END
						FETCH NEXT FROM @CursORDev INTO @ProductoClave, @Cantidad
					END
					CLOSE @CursORDev  
					DEALLOCATE @CursORDev

					-----------------------------> ## DEVOLUCIONES Y CAMBIOS FISICOS ## <-----------------------------------------------------
					DECLARE @IdMovimiento AS INT
					DECLARE @CursORMOV CURSOR
					DECLARE @IdTipoMovimiento AS INT
					SET @IdTipoMovimiento = (SELECT TOP 1 IdMovimientoDevoluciONes FROM RouteADM.dbo.Configuracion WHERE RouteADM.dbo.Configuracion.IdCedIS =@ClaveCEDI )

					SET @CursORMOV = CURSOR SCROLL DYNAMIC FOR 
						SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario U ON U.USUId = VEN.USUId 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						WHERE ((TP.Tipo = 3 AND TP.TipoFase <> 0) OR (TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 1)) 
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 

					IF NOT EXISTS(SELECT * FROM RouteADM.dbo.Movimientos WHERE IdCedIS = @ClaveCEDI AND Fecha = @Dia AND IdTipoMovimiento = @IdTipoMovimiento)
					BEGIN
						SET @IdMovimiento = (SELECT MAX(idMovimiento) FROM RouteADM.dbo.Movimientos WHERE IdCedIS = @ClaveCEDI ) + 1
						IF @IdMovimiento IS NULL
							SET @IdMovimiento = 1
						INSERT INTO RouteADM.dbo.Movimientos VALUES(@ClaveCEDI, @IdMovimiento, @Dia, @IdTipoMovimiento  ,'','','A')
					END
					ELSE
					BEGIN
						SET @IdMovimiento = (SELECT IdMovimiento FROM RouteADM.dbo.Movimientos WHERE IdCedIS = @ClaveCEDI AND Fecha = @Dia AND IdTipoMovimiento = @IdTipoMovimiento)
						IF @IdMovimiento IS NULL
							SET @IdMovimiento = 1
					END

					OPEN @CursORMOV
					FETCH NEXT FROM @CursORMOV INTO @ProductoClave, @Cantidad
					WHILE @@FETCH_STATUS = 0      
					BEGIN                               
						IF (SELECT COUNT(*) FROM RouteADM.dbo.MovimientosDetALLe WHERE IdCedIS = @ClaveCEDI AND IdMovimiento = @IdMovimiento AND IdProducto = @ProductoClave ) > 0
						BEGIN
							UPDATE RouteADM.dbo.MovimientosDetALLe SET Cantidad = CAST(Cantidad AS DECIMAL(19,4)) + CAST(@Cantidad AS DECIMAL(19,4)) WHERE IdCedIS = @ClaveCEDI AND IdMovimiento = @IdMovimiento AND IdProducto = @ProductoClave 
						END
						ELSE
						BEGIN
							INSERT INTO RouteADM.dbo.MovimientosDetALLe VALUES(@ClaveCEDI, @IdMovimiento, @ProductoClave, CAST(@Cantidad AS DECIMAL(19,4)), '')
						END
						       
						FETCH NEXT FROM @CursORMOV INTO @ProductoClave, @Cantidad
					END
					CLOSE @CursORMOV  
					DEALLOCATE @CursORMOV

					UPDATE TransProd SET TipoFaseIntSal = 1
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
					INNER JOIN Usuario U ON U.USUId = VEN.USUId 
					WHERE TP.Tipo = 3 AND TP.TipoFase <> 0 
					AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
					AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 

					---------------------------------------------------------------------------------------------------------
					---------------------------------AGREGA LOS PRODUCTOS CAMBIOS--------------------------------------------

					DECLARE @CursORCambioEntrada CURSOR  

					SET @CursORCambioEntrada = CURSOR SCROLL DYNAMIC FOR 
						SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario U ON U.USUId = VEN.USUId 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						WHERE ((TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 1)) 
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 

					OPEN  @CursORCambioEntrada
					FETCH NEXT FROM @CursORCambioEntrada INTO @ProductoClave, @Cantidad
					WHILE @@FETCH_STATUS = 0      
					BEGIN 

						IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosCambios WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND   IdProducto = @ProductoClave AND idFecha=@Dia)>0
						BEGIN
							UPDATE RouteADM.dbo.SurtidosCambios SET Entrada = Entrada + @Cantidad WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND  IdProducto = @ProductoClave AND idFecha=@Dia
						END
						ELSE
						BEGIN
							INSERT INTO RouteADM.dbo.SurtidosCambios(IdCedIS, IdSurtido ,IdFecha , IdProducto ,Entrada,Salida )
							VALUES(@ClaveCEDI,@Surtido,@Dia,@ProductoClave,@Cantidad,0)
						END
						FETCH NEXT FROM @CursORCambioEntrada INTO @ProductoClave, @Cantidad
					END
					CLOSE @CursORCambioEntrada  
					DEALLOCATE @CursORCambioEntrada


					DECLARE @CursORCambioSalida CURSOR  

					SET @CursORCambioSalida = CURSOR SCROLL DYNAMIC FOR 
						SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario U ON U.USUId = VEN.USUId 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						WHERE ( (TP.Tipo = 9 AND TP.TipoFase <> 0 AND TP.TipoMovimiento = 2)) 
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 

					OPEN  @CursORCambioSalida
					FETCH NEXT FROM @CursORCambioSalida INTO @ProductoClave, @Cantidad
					WHILE @@FETCH_STATUS = 0      
					BEGIN 
						IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosCambios WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND IdProducto = @ProductoClave AND idFecha=@Dia)>0
						BEGIN
							UPDATE RouteADM.dbo.SurtidosCambios SET Salida = Salida + @Cantidad WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido  AND IdProducto = @ProductoClave AND idFecha=@Dia
						END
						ELSE
						BEGIN
							INSERT INTO RouteADM.dbo.SurtidosCambios(IdCedIS, IdSurtido ,idFecha,IdProducto ,Entrada,Salida )
							VALUES(@ClaveCEDI,@Surtido,@Dia,@ProductoClave,0,@Cantidad)
						END
						FETCH NEXT FROM @CursORCambioSalida INTO @ProductoClave, @Cantidad
					END
					CLOSE @CursORCambioSalida
					DEALLOCATE @CursORCambioSalida

					UPDATE TransProd SET TipoFaseIntSal = 1 
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN Visita VIS ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
					INNER JOIN Usuario U ON U.USUId = VEN.USUId    
					WHERE TP.Tipo = 9 AND TP.TipoFase <> 0 
					AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
					AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 

					---------------------------------------------------------------------------------------------------------
					----------------------------------- DESCARGA ------------------------------------------------------------

					SET @CursORMOV = CURSOR SCROLL DYNAMIC FOR 
						SELECT TD.ProductoClave, SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID
						WHERE TP.Tipo = 7 AND TP.TipoFase <> 0
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 

					OPEN @CursORMOV
					FETCH NEXT FROM @CursORMOV INTO @ProductoClave, @Cantidad
					WHILE @@FETCH_STATUS = 0      
					BEGIN
						IF(SELECT COUNT(*) FROM [RouteADM].dbo.SurtidosDetALLe WHERE IdSurtido= @Surtido AND IdCedIS=@ClaveCEDI AND IdProducto = CAST(@ProductoClave AS INT))=0
						BEGIN
							INSERT INTO [RouteADM].[dbo].[SurtidosDetALLe]([IdCedIS],[IdSurtido],[IdProducto],[Fecha],[Surtido],[DevBuena],[DevMala],[Obsequios],[VentaCONtado],[VentaCredito],[Precio],[Iva])
							VALUES(@ClaveCEDI,@Surtido,CAST(@ProductoClave AS INT),@Dia,@Cantidad,@Cantidad,0,0,0,0,0,0)
						END
						ELSE
						BEGIN
							UPDATE [RouteADM].dbo.SurtidosDetALLe SET DevBuena = DevBuena + @Cantidad
							WHERE IdSurtido= @Surtido AND IdCedIS=@ClaveCEDI AND IdProducto = CAST(@ProductoClave AS INT)
						END                          

						FETCH NEXT FROM @CursORMOV INTO @ProductoClave, @Cantidad
					END
					CLOSE @CursORMOV  
					DEALLOCATE @CursORMOV

					UPDATE TransProd SET TipoFaseIntSal = 1 
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
					WHERE TP.Tipo = 7 AND TP.TipoFase <> 0
					AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
					AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 

					---------------------------------------------------------------------------------------------------------
					------------------------ DEVOLUCIONES DE ALMACEN---------------------------------------------------------

					DECLARE @CursORDevA CURSOR  

					SET @CursORDevA = CURSOR SCROLL DYNAMIC FOR 
						SELECT CAST(TD.ProductoClave AS INT), SUM(TD.Cantidad *PD.FactOR) AS Cantidad
						FROM TransProd TP
						INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
						INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
						INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
						INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
						WHERE TP.Tipo = 4 AND TP.TipoFase <> 0
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 
						GROUP BY TD.ProductoClave 

					OPEN  @CursORDevA
					FETCH NEXT FROM @CursORDevA INTO @ProductoClave, @Cantidad
					WHILE @@FETCH_STATUS = 0      
					BEGIN 
						IF(SELECT COUNT(*) FROM RouteADM.dbo.SurtidosMerma  WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND IdTipoMerma = 1 AND IdProducto = @ProductoClave )>0
						BEGIN
							UPDATE RouteADM.dbo.SurtidosMerma SET Cantidad = Cantidad + @Cantidad WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND  IdTipoMerma = 1  AND IdProducto = @ProductoClave
						END
						ELSE
						BEGIN
							INSERT INTO RouteADM.dbo.SurtidosMerma(IdCedIS, IdSurtido , IdTipoMerma , IdProducto ,Cantidad )
							VALUES(@ClaveCEDI,@Surtido,1,@ProductoClave,@Cantidad)
						END
						
						IF(SELECT COUNT(*) FROM [RouteADM].dbo.SurtidosDetALLe WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND IdProducto = @ProductoClave)=0
						BEGIN
							INSERT INTO [RouteADM].[dbo].[SurtidosDetALLe]([IdCedIS],[IdSurtido],[IdProducto],[Fecha],[Surtido],[DevBuena],[DevMala],[Obsequios],[VentaCONtado],[VentaCredito],[Precio],[Iva])
							VALUES(@ClaveCEDI,@Surtido,CAST(@ProductoClave AS INT),@Dia,@Cantidad,0,@Cantidad,0,0,0,0,0)
						END
						ELSE
						BEGIN
							UPDATE [RouteADM].dbo.SurtidosDetALLe SET DevMala = DevMala+ @Cantidad 
							WHERE IdCedIS = @ClaveCEDI AND IdSurtido = @Surtido AND IdProducto = @ProductoClave
						END

						FETCH NEXT FROM @CursORDevA INTO @ProductoClave, @Cantidad
					END
					CLOSE @CursORDevA  
					DEALLOCATE @CursORDevA

					UPDATE TransProd SET TipoFaseIntSal = 1
					FROM TransProd TP
					INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
					INNER JOIN TransProdDetalle TD ON TD.TransProdID = TP.TransProdID 
					INNER JOIN ProductoDetalle PD ON PD.ProductoClave = TD.ProductoClave AND PD.ProductoDetClave = TD.ProductoClave 
					INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
					WHERE TP.Tipo = 4 AND TP.TipoFase <> 0
					AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
					AND  (U.Clave = @Vende AND TP.DiaClave = @DiaClave) 

					---------------------------------------------------------------------------------------------------------
					--------------------------------------------- VENTAS ----------------------------------------------------
					
					-------PEDIDOS A CREDITO QUE NO HAN SIDO SALDADOS SE ENVIARAN COMO CONSIGNACION A SURTIDOSDETALLE--------
					---------------------------------ENVIAR SOLO CUANDO SE CREAN O SURTEN------------------------------------	
					IF NOT OBJECT_ID('tempdb..#TmpConsignacion') IS NULL
					DROP TABLE #TmpConsignacion
					
					select * into #TmpConsignacion from (
					--Reparto
						SELECT TRP.TransProdID
						FROM TransProd TRP				
						INNER JOIN Visita VIS ON VIS.VisitaClave = TRP.VisitaClave1 AND VIS.DiaClave = TRP.DiaClave1 
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario USU ON USU.USUId = VEN.USUId
						WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2 AND TRP.CFVTipo = 2 and TRP.Saldo <> 0 
						AND ((TRP.FechaHoraAlta BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TRP.TipoFaseIntSal = 0)) AND USU.Clave = @Vende 
						UNION 
						--Venta Directa
						SELECT TRP.TransProdID 
						FROM TransProd TRP
						INNER JOIN Visita VIS ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave and TRP.DiaClave1 is null
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario USU ON USU.USUId = VEN.USUId
						WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2 AND TRP.CFVTipo = 2 and TRP.Saldo <> 0 
						AND ((TRP.FechaHoraAlta BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TRP.TipoFaseIntSal = 0)) AND USU.Clave = @Vende
					) as t
					
					UPDATE [RouteADM].dbo.SurtidosDetalle SET Consignacion = Consignacion + A.Cantidad
					FROM [RouteADM].dbo.SurtidosDetalle AS B
					INNER JOIN (					
						SELECT TPD.ProductoClave, SUM(TPD.Cantidad) AS Cantidad
						FROM TransProdDetalle TPD 
						INNER JOIN #TmpConsignacion TRP ON TRP.TransProdID = TPD.TransProdID
						GROUP BY TPD.ProductoClave
					) AS A ON b.IdProducto = CAST(a.ProductoClave AS INT)
					WHERE B.IdSurtido=@Surtido AND B.IdCedIS=@ClaveCEDI	
												
					UPDATE TransProd SET TipoFaseIntSal = 1 WHERE TransProdID IN (SELECT TransProdID FROM #TmpConsignacion)
					UPDATE TransProdDetalle SET TipoFaseIntSal = 1 WHERE TransProdID IN (SELECT TransProdID FROM #TmpConsignacion)
					
					
					------------------PEDIDOS A CREDITO QUE SE SALDARON EN UNA FECHA DISTINTA A LA CREACION -----------------
					-----------------------------SE ENVIARAN COMO RECUPERACION A SURTIDOSDETALLE-----------------------------	

					UPDATE [RouteADM].dbo.SurtidosDetalle SET Recuperacion = Recuperacion + A.Cantidad
					FROM [RouteADM].dbo.SurtidosDetalle AS B
					INNER JOIN (
						SELECT ProductoClave,SUM(cantidad)AS Cantidad
						FROM (
							SELECT TPD.ProductoClave, TPD.Cantidad 
							FROM TransProdDetalle TPD 
							WHERE TPD.TransProdID IN(
							SELECT DISTINCT TRP.TransProdID 
							FROM Abono ABN 
							INNER JOIN AbnTrp ABT ON ABN.ABNId = ABT.ABNId
							INNER JOIN TransProd TRP ON TRP.TransProdID = ABT.TransProdID 
							INNER JOIN Visita VIS ON VIS.VisitaClave = ABN.VisitaClave AND VIS.DiaClave = ABN.DiaClave
							INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
							INNER JOIN Usuario USU ON USU.USUId = VEN.USUId
							WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2 AND TRP.CFVTipo = 2 AND TRP.Saldo = 0 
							AND ((TRP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TRP.TipoFaseIntSal IN (0,2)))
							AND USU.Clave = @Vende and convert(varchar(20),ABN.FechaAbono,103) = convert(varchar(20),TRP.MFechaHora,103)
							AND ABN.DiaClave <> TRP.DiaClave AND (TRP.DiaClave1 IS NULL OR ABN.DiaClave <> TRP.DiaClave1))
							AND (TPD.Promocion IS NULL OR TPD.Promocion <> 2)
						) AS T
						GROUP BY ProductoClave
					) AS A ON b.IdProducto = CAST(a.ProductoClave AS INT)
					WHERE B.IdSurtido=@Surtido AND B.IdCedIS=@ClaveCEDI
					
					
					------------SE ENVIARAN AL ADM SOLO LOS PEDIDOS DE CONTADO Y CREDITO SALDADOS EL DIA DE TRABAJO----------
					--------------------------TODAS SE DEBEN ENVIAR CON FORMA DE VENTA CONTADO-------------------------------
					DECLARE @IdClienteContado AS BIGINT
					DECLARE @IdClienteContadoTmp AS BIGINT
					DECLARE @SerieFactContado AS VARCHAR(10)

					SELECT @IdClienteContado=IdClienteContado,@SerieFactContado='R'+ltrim(str(@idRuta))
					FROM [RouteADM].dbo.Configuracion

					DECLARE @Subtotal AS FLOAT
					DECLARE @Impuesto AS FLOAT
					DECLARE @ClienteClave AS VARCHAR(20)
					DECLARE @TransProdID AS VARCHAR(20)
					DECLARE @TipoVenta AS SMALLINT
					DECLARE @Folio AS VARCHAR(20)
					DECLARE @Serie AS VARCHAR(20)
					DECLARE @Descuento AS FLOAT
					DECLARE @DiasCredito AS SMALLINT
					DECLARE @FechaPrev AS DATETIME
					DECLARE @RutaPrev AS BIGINT
					
					SET @TipoVenta = 1
					
					--Recupera la longitud del folio para los TransProd de Tipo 1
					DECLARE @LongFolio AS INT
					SELECT @LongFolio = LEN(FOD.Formato)
					FROM Folio FOL 
					INNER JOIN FolioDetalle FOD ON FOL.FolioID = FOD.FolioID 
					INNER JOIN FolioUsuario FOU ON FOL.FolioID = FOU.FolioID 
					INNER JOIN Vendedor VEN ON VEN.VendedorID = FOU.VendedorID 
					INNER JOIN Usuario USU ON USU.USUId = VEN.USUId
					INNER JOIN ModuloMovDetalle MMD ON FOL.ModuloMovDetalleClave = MMD.ModuloMovDetalleClave 
					WHERE FOD.TipoContenido = 2 AND FOD.TipoEstado = 1 AND MMD.TipoEstado = 1 AND MMD.Baja = 0
					AND MMD.TipoIndice = 9 AND MMD.TipoTransProd = 1 AND USU.Clave = @Vende

					--OBTIENE LAS VENTAS REALIZADAS
					DECLARE @CursorVar2 CURSOR
					SET @CursorVar2 = CURSOR SCROLL DYNAMIC FOR 
						--Contado Reparto
						SELECT TP.Subtotal, TP.Impuesto, TP.DESCuentoVendedor + TP.DescuentoImp AS DESCuento, V.ClienteClave, 
						TP.TransProdID, dbo.FNObtenerSolONumeros(RIGHT(TP.Folio,@LongFolio)) AS folio, TP.DiasCredito,
						DPrev.FechaCaptura as FechaPrev, RIGHT(dbo.FNObtenerRutaADMINTer(VPrev.RUTClave),4) as RutaPrev											
						FROM TransProd AS TP 
						INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave1 AND V.DiaClave = TP.DiaClave1 
						INNER JOIN Visita VPrev ON TP.VisitaClave = VPrev.VisitaClave and TP.DiaClave = VPrev.DiaClave
						INNER JOIN Dia DPrev ON VPrev.DiaClave = DPrev.DiaClave
						INNER JOIN Vendedor VE ON VE.VendedorId = V.VendedorId
						INNER JOIN Usuario AS Us ON Us.USUId = VE.USUId
						WHERE TP.Tipo=1 AND TP.TipoFase=2 AND  TP.DiaClave1= @DiaClave AND TP.CFVTipo = 1
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (Us.Clave = @Vende) AND TP.Facturaid IS NULL
						UNION
						--Contado Venta directa
						SELECT TP.Subtotal ,TP.Impuesto, TP.DESCuentoVendedor + TP.DescuentoImp AS DESCuento, V.ClienteClave, 
						TP.TransProdID, dbo.FNObtenerSolONumeros(RIGHT(TP.Folio,@LongFolio)) AS folio, TP.DiasCredito,
						null as FechaPrev, null as RutaPrev
						FROM TransProd AS TP 
						INNER JOIN Visita V ON V.VisitaClave = TP.VisitaClave AND V.DiaClave = TP.DiaClave and TP.DiaClave1 is null
						INNER JOIN Vendedor VE ON VE.VendedorId = V.VendedorId
						INNER JOIN Usuario AS Us ON Us.USUId = VE.USUId
						WHERE TP.Tipo=1 AND TP.TipoFase=2 AND  TP.DiaClave= @DiaClave AND TP.CFVTipo = 1
						AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
						AND  (Us.Clave = @Vende) AND TP.Facturaid IS NULL
						UNION
						--Creditos saldados (Recuperacion y creditos saldados en la fecha que se surtieron)					
						SELECT DISTINCT TRP.Subtotal, TRP.Impuesto, TRP.DescuentoVendedor + TRP.DescuentoImp as Descuento, VIS.ClienteClave, 
						TRP.TransProdID, dbo.FNObtenerSolONumeros(RIGHT(TRP.Folio, @LongFolio)) AS Folio, TRP.DiasCredito,
					    CASE WHEN NOT TRP.DiaClave1 IS NULL THEN DPrev.FechaCaptura ELSE NULL END AS FechaPrev, 
					    CASE WHEN NOT TRP.DiaClave1 IS NULL THEN RIGHT(dbo.FNObtenerRutaADMINTer(VPrev.RUTClave),4) ELSE NULL END AS RutaPrev	
						FROM Abono ABN 
						INNER JOIN AbnTrp ABT ON ABN.ABNId = ABT.ABNId
						INNER JOIN TransProd TRP ON TRP.TransProdID = ABT.TransProdID 
						INNER JOIN Visita VIS ON VIS.VisitaClave = ABN.VisitaClave AND VIS.DiaClave = ABN.DiaClave
						INNER JOIN Visita VPrev ON TRP.VisitaClave = VPrev.VisitaClave AND TRP.DiaClave = VPrev.DiaClave
						INNER JOIN Dia DPrev ON VPrev.DiaClave = DPrev.DiaClave
						INNER JOIN Vendedor VEN ON VEN.VendedorID = VIS.VendedorID 
						INNER JOIN Usuario USU ON USU.USUId = VEN.USUId
						WHERE TRP.Tipo = 1 AND TRP.TipoFase = 2 AND TRP.CFVTipo = 2 AND TRP.Saldo = 0 
						AND ((TRP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TRP.TipoFaseIntSal IN (0,2)))
						AND USU.Clave = @Vende and convert(varchar(20),ABN.FechaAbono,103) = convert(varchar(20),TRP.MFechaHora,103)
						

					OPEN  @CursorVar2
					FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto, @Descuento, @ClienteClave, @TransProdID, @Folio, @DiasCredito, @FechaPrev, @RutaPrev
					WHILE @@FETCH_STATUS = 0      
					BEGIN 
						DECLARE @ImpORteSINDESC AS FLOAT
						DECLARE @DescuentoPrm AS FLOAT

						SET @ImpORteSINDESC = @Subtotal + @Descuento 	
						SELECT @DescuentoPrm = ISNULL(SUM(PromocionImp),0) FROM TrpPrp WHERE TransProdID = @TransProdID

						SET @Descuento = @Descuento + @DescuentoPrm 
						SET @IdClienteContadoTmp = (SELECT IdCliente FROM [RouteADM].dbo.ClienteSucursal WHERE IdSucursal = @ClienteClave AND IdCedIS = @ClaveCEDI)
						
						IF(@IdClienteContadoTmp IS NOT NULL)
							SET @IdClienteContado = @IdClienteContadoTmp             

						INSERT INTO [RouteADM].dbo.Ventas (IdCedis,IdSurtido,IdTipoVenta,Folio,Serie,Fecha,IdCliente,Subtotal,Iva,IdSucursal,DctoImp,DiasCredito,FechaPrev,RutaPrev)
						VALUES(@ClaveCEDI,@Surtido,@TipoVenta,@Folio,@SerieFactContado,@Dia,@IdClienteContado,@Subtotal,@Impuesto,@ClienteClave,@Descuento,@DiasCredito,@FechaPrev,@RutaPrev)
						                                                                                          
						INSERT INTO [RouteADM].dbo.VentasDetalle (IdCedis,IdSurtido,IdTipoVenta,Folio,IdProducto,Serie,Cantidad,Precio,Iva,DcTOPORc,DctoImp)                             
						SELECT @ClaveCEDI,@Surtido,@TipoVenta,@Folio, T1.ProductoClave, @SerieFactContado, T1.Cantidad, T1.Precio, T1.ImpuestoIVA, 
						((DESCuento * 100)/(Cantidad * Precio))/100 AS PORcentajeDESC, T1.DESCuento 
						FROM (
							SELECT ProductoClave, SUM(PiezAS) AS Cantidad, SUM(Precio * PiezAS)/SUM(PiezAS) AS Precio,
							--SUM(Impuesto - DESCClienteImpuesto - ((Impuesto - DESCClienteImpuesto) * (DescVendPor / 100))) AS Impuesto,
							ImpuestoPor/100 as ImpuestoIVA,
							SUM((((PiezAS * Precio) - (DescuentoImp + DescuentoCliente)) * (DescVendPor / 100)) + DescuentoImp + DescuentoCliente) AS DESCuento
							FROM ( 
								SELECT TPDI.ImpuestoPor,TD.ProductoClave, TD.SubTotal, (PRD.FactOR * TD.Cantidad) AS PiezAS, TD.Precio, TD.Impuesto, T.DescVendPor, TD.DescuentoImp,
								(SELECT (CASE WHEN SUM(DesImporte) IS NULL then 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD WHERE TDD.TransProdID=TD.TransProdID AND TDD.TransProdDetalleId=TD.TransProdDetalleId) AS DescuentoCliente, 
								(SELECT (CASE WHEN SUM(DesImpuesto) IS NULL then 0 ELSE SUM(DesImpuesto) END) FROM TpdDes AS TDD WHERE TDD.TransProdID=TD.TransProdID AND TDD.TransProdDetalleId=TD.TransProdDetalleId) AS DESCClienteImpuesto
								FROM TransProd T
								INNER JOIN Dia D ON D.DiaClave = T.DiaClave
								INNER JOIN Visita V ON V.DiaClave = T.DiaClave AND V.VisitaClave = T.VisitaClave 
								INNER JOIN TransProdDetalle TD ON T.TransProdID = TD.TransProdID
								INNER JOIN Producto PRO ON PRO.ProductoClave = TD.ProductoClave 
								INNER JOIN ProductoDetalle PRD ON TD.ProductoClave = PRD.ProductoClave AND TD.TipoUnidad = PRD.PRUTipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave 
								INNER JOIN TPDImpuesto TPDI ON TPDI.TransProdID=TD.TransProdID AND TPDI.TransProdDetalleID=TD.TransProdDetalleID
								WHERE td.TransProdID = @TransProdID AND td.Promocion <> 2 
							) AS T
							GROUP BY ProductoClave,ImpuestoPor
						) AS T1
																						
						INSERT INTO [RouteADM].dbo.VentasTransProd (IdCedis, IdSurtido, IdTipoVenta, Serie, Folio, TransProdId, Fecha)
						VALUES (@ClaveCEDI, @Surtido, @TipoVenta, @SerieFactContado, @Folio, @TransProdID, GETDATE())

						UPDATE TransProd SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdID
						UPDATE TransProdDetalle SET TipoFaseIntSal = 1 WHERE TransProdID = @TransProdID

						FETCH NEXT FROM @CursorVar2 INTO @Subtotal, @Impuesto, @Descuento, @ClienteClave, @TransProdID, @Folio, @DiasCredito, @FechaPrev, @RutaPrev
					END
					CLOSE @CursorVar2  
			
				END			
			END

			FETCH NEXT FROM @CursorVar1 INTO @DiaClave, @Dia
		
		END 
		CLOSE @CursorVar1  
		DEALLOCATE @CursorVar1

		--------------------------************
		
		UPDATE TransProd SET TipoFaseIntSal = 1
		FROM TransProd TP
		INNER JOIN Dia D ON D.DiaClave = TP.DiaClave 
		INNER JOIN Usuario U ON U.USUId = TP.MUsuarioID 
		WHERE TP.Tipo IN(2,23) AND TP.TipoFase <> 0 
		AND((TP.MFechaHora BETWEEN @FechaIN AND @FechaFIN) OR (@FechaIN = @FechaIniCompara AND TP.TipoFaseIntSal IN (0,2)))
		AND  (U.Clave = @Vende) 

		DECLARE @IdVendedor AS BIGINT

		SELECT TOP 1 @IdVendedor = SurtidosVendedor.IdVendedor, @DiaClave = Surtidos.Fecha
		FROM [RouteADM].dbo.Surtidos Surtidos
		INNER JOIN [RouteADM].dbo.SurtidosVendedor SurtidosVendedor ON Surtidos.IdCedIS = SurtidosVendedor.IdCedIS AND Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		WHERE Surtidos.IdCedIS = @ClaveCEDI AND Surtidos.IdSurtido = @Surtido 
		ORDER BY SurtidosVendedor.IdTipoVendedor

		EXEC [RouteADM].dbo.up_VendedoresSaldos @ClaveCEDI, @Surtido, @IdVendedor, @DiaClave, 1
		EXEC [RouteADM].dbo.up_ActualizaKardex @ClaveCEDI, @DiaClave, @Surtido, 4

		SET @IdTipoMovimiento = (SELECT TOP 1 IdMovimientoDevoluciONes FROM RouteADM.dbo.Configuracion WHERE RouteADM.dbo.Configuracion.IdCedIS =@ClaveCEDI )

		IF NOT EXISTS(SELECT * FROM RouteADM.dbo.Movimientos WHERE IdCedIS = @ClaveCEDI AND Fecha = @Dia AND IdTipoMovimiento = @IdTipoMovimiento)
		BEGIN
			SET @IdMovimiento = (SELECT MAX(idMovimiento) FROM RouteADM.dbo.Movimientos WHERE IdCedIS = @ClaveCEDI ) + 1
			IF @IdMovimiento IS NULL
				SET @IdMovimiento = 1
			INSERT INTO RouteADM.dbo.Movimientos VALUES(@ClaveCEDI, @IdMovimiento, @Dia, @IdTipoMovimiento  ,'','','A')
		END
		ELSE
		BEGIN
			SET @IdMovimiento = (SELECT IdMovimiento FROM RouteADM.dbo.Movimientos WHERE IdCedIS = @ClaveCEDI AND Fecha = @Dia AND IdTipoMovimiento = @IdTipoMovimiento)
			IF @IdMovimiento IS NULL
				SET @IdMovimiento = 1
		END

		EXEC [RouteADM].dbo.up_ActualizaKardex @ClaveCEDI, @DiaClave, @Surtido, 4
		EXEC [RouteADM].dbo.up_ActualizaKardex @ClaveCEDI, @DiaClave, @Surtido, 3
		
		
	END
	
	SET XACT_ABORT ON  
	SET NOCOUNT OFF

END





GO



USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 67, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 67 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO