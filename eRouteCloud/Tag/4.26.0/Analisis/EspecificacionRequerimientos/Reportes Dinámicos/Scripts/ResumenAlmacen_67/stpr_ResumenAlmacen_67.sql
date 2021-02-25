/* Reporte Dinamico Resumen De Almacen */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_ResumenAlmacen_67]
	@filterCEDIS = '44H5SO2UWRTK6+1',
	@filterSeller = 'R-CACH',
	@filterStartDate = '2020-01-01',
	@filterEndDate = '2020-03-01'
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_ResumenAlmacen_67]'))
	DROP PROCEDURE [dbo].[stpr_ResumenAlmacen_67]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_ResumenAlmacen_67]
	@filterCEDIS AS varchar(16) = NULL,
	@filterSeller AS varchar(16) = NULL,
	@filterStartDate AS varchar(10) = NULL,
	@filterEndDate AS varchar(10) = NULL
AS
	SET ANSI_WARNINGS OFF
	SET NOCOUNT ON
	DECLARE @TablaReporte AS TABLE (
		VendedorId varchar(20) NULL,
		NombreVendedor varchar(100) NULL,
		ClaveUsuario varchar(20) NULL,
		DiaClave varchar(20) NULL,
		ProductoClave varchar(20) NULL,
		NombreProducto varchar(100) NULL,
		InventarioInicial float NULL,
		Recarga float NULL,
		CambioDevolucionCte float,
		CambioSalidaCte float,
		Promocion float,
		Descarga float,
		Devolucion float,
		Venta float	
	)
	
	DECLARE @Dia AS datetime
			
	DECLARE @CursorDiasT CURSOR
	SET @CursorDiasT= CURSOR SCROLL DYNAMIC FOR
	SELECT Fecha FROM FNObtenerFechas(@filterStartDate,@filterEndDate)

	OPEN @CursorDiasT
	FETCH NEXT FROM @CursorDiasT INTO @Dia
	WHILE @@FETCH_STATUS = 0
	BEGIN
		/* OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR */
		IF (SELECT OBJECT_ID('tempdb..#TmpUltimoInventarioABordo')) IS NOT NULL DROP TABLE #TmpUltimoInventarioABordo
		BEGIN
			SELECT * INTO #TmpUltimoInventarioABordo FROM (
				SELECT TOP 1 VD.VendedorID,T.FechaCaptura,FechaHoraAlta,TransProdID
				FROM TransProd AS T (NOLOCK)
					INNER JOIN Vendedor AS VD (NOLOCK) ON T.MUsuarioID = VD.USUId
				WHERE T.Tipo = 23 AND T.TipoFase <> 0
					AND T.FechaCaptura < @Dia
					AND VD.VendedorID = @filterSeller
				GROUP BY VD.VendedorID, T.FechaCaptura, FechaHoraAlta, TransProdID
				ORDER BY T.FechaHoraAlta DESC
			) AS UltimoInventarioABordo
		END
	
		/* DETALLE PRODUCTOS */
		INSERT INTO @TablaReporte
		SELECT VendedorID, NombreVendedor, ClaveUsuario, DiaClave, ProductoClave, NombreProducto, SUM(InventarioInicial) AS InventarioInicial,
			SUM(Recarga) AS Recarga, SUM(CambioDevolucionCte) AS CambioDevolucionCte, SUM(CambioSalidaCte) AS CambioSalidaCte, SUM(Promocion) AS Promocion,
			SUM(Descarga) AS Descarga, SUM(Devolucion) AS Devolucion, SUM(Venta) AS Venta
		FROM (
			/* Ventas, Devoluciones */
			SELECT V.VendedorID, VE.Nombre AS NombreVendedor, U.Clave AS ClaveUsuario, D.DiaClave, TD.ProductoClave, P.Nombre AS NombreProducto,
				InventarioInicial = 0,
				Recarga = 0,
				CambioDevolucionCte = (SELECT CASE WHEN T.Tipo = 3 OR (T.Tipo = 9 AND T.TipoMovimiento = 1) THEN TD.Cantidad * PD.Factor ELSE 0 END),
				CambioSalidaCte = (SELECT CASE WHEN T.Tipo = 9 AND T.TipoMovimiento = 2 THEN TD.Cantidad * PD.Factor ELSE 0 END),
				Promocion = (SELECT CASE WHEN T.Tipo = 1 AND ISNULL(TD.Promocion, 0) = 2 THEN TD.Cantidad * PD.Factor ELSE 0 END),
				Descarga = 0,
				Devolucion = 0,
				Venta = (SELECT CASE WHEN T.Tipo = 1 AND ISNULL(TD.Promocion, 0) <> 2 THEN TD.Cantidad * PD.Factor ELSE 0 END)
			FROM TransProd AS T (NOLOCK)
				INNER JOIN Dia AS D (NOLOCK) ON ISNULL(T.DiaClave1, T.DiaClave) = D.DiaClave
				INNER JOIN Visita AS V (NOLOCK) ON ISNULL(T.VisitaClave1, T.VisitaClave) = V.VisitaClave AND ISNULL(T.DiaClave1, T.DiaClave) = V.DiaClave
				INNER JOIN TransProdDetalle AS TD (NOLOCK) ON T.TransProdID = TD.TransProdID
				INNER JOIN Producto AS P (NOLOCK) ON TD.ProductoClave = P.ProductoClave
				INNER JOIN ProductoDetalle AS PD (NOLOCK) ON TD.ProductoClave = PD.ProductoClave AND TD.ProductoClave = PD.ProductoDetClave AND TD.TipoUnidad = PD.PRUTipoUnidad
				INNER JOIN Vendedor AS VE (NOLOCK) ON V.VendedorID = VE.VendedorID
				INNER JOIN Usuario AS U (NOLOCK) ON VE.USUId = U.USUId
			WHERE ((T.Tipo = 1 and T.TipoFase IN (2, 3)) OR (T.Tipo IN (3,9) AND T.TipoFase <> 0))
				AND D.FechaCaptura = @Dia
				AND V.VendedorID = @filterSeller
			UNION ALL
			/* PRIMERA CARGA, RECARGAS Y DESCARGAS */
			SELECT VE.VendedorID, VE.Nombre AS NombreVendedor, U.Clave AS ClaveUsuario, D.DiaClave, TD.ProductoClave, P.Nombre AS NombreProducto,
				InventarioInicial = 0,
				Recarga = (SELECT CASE WHEN T.Tipo = 2 AND T.TipoFase = 1 THEN TD.Cantidad * PD.Factor ELSE 0 END),	
				CambioDevolucionCte = 0,
				CambioSalidaCte = 0,
				Promocion = 0,
				Descarga = (SELECT CASE WHEN T.Tipo = 7 THEN TD.Cantidad * PD.Factor ELSE 0 END),
				Devolucion = (SELECT CASE WHEN T.Tipo = 4 THEN TD.Cantidad * PD.Factor ELSE 0 END),
				Venta = 0
			FROM TransProd AS T (NOLOCK)
				INNER JOIN Dia AS D (NOLOCK) ON T.DiaClave = D.DiaClave
				INNER JOIN TransProdDetalle AS TD (NOLOCK) ON T.TransProdID = TD.TransProdID
				INNER JOIN Producto AS P (NOLOCK) ON TD.ProductoClave = P.ProductoClave
				INNER JOIN ProductoDetalle AS PD (NOLOCK) ON TD.ProductoClave = PD.ProductoClave AND TD.ProductoClave = PD.ProductoDetClave AND TD.TipoUnidad = PD.PRUTipoUnidad
				INNER JOIN Vendedor AS VE (NOLOCK) ON T.MUsuarioID = VE.USUId
				INNER JOIN Usuario AS U (NOLOCK) ON VE.USUId = U.USUId
			WHERE T.Tipo IN (2, 4, 7) AND T.TipoFase <> 0
				AND D.FechaCaptura = @Dia
				AND VE.VendedorID = @filterSeller
			UNION ALL
			/* ULTIMO INVENTARIO A BORDO */
			SELECT TUA.VendedorID, VE.Nombre AS NombreVendedor, U.Clave AS ClaveUsuario,
				CONVERT(varchar, @Dia, 103),
				TD.ProductoClave,
				P.Nombre AS NombreProducto,
				InventarioInicial = (SELECT TD.Cantidad * PD.Factor),
				Recarga = 0,
				CambioDevolucionCte = 0,
				CambioSalidaCte = 0,
				Promocion = 0,
				Descarga = 0,
				Devolucion = 0,
				Venta = 0
			FROM #TmpUltimoInventarioABordo AS TUA (NOLOCK)
				INNER JOIN TransProdDetalle AS TD (NOLOCK) ON TUA.TransProdID = TD.TransProdID
				INNER JOIN Producto AS P (NOLOCK) ON TD.ProductoClave = P.ProductoClave
				INNER JOIN ProductoDetalle AS PD (NOLOCK) ON TD.ProductoClave = PD.ProductoClave AND TD.ProductoClave = PD.ProductoDetClave AND TD.TipoUnidad = PD.PRUTipoUnidad
				INNER JOIN Vendedor AS VE (NOLOCK) ON TUA.VendedorID = VE.VendedorID
				INNER JOIN Usuario AS U (NOLOCK) ON VE.USUId = U.USUId
		) AS ResumenAlmacen
		GROUP BY VendedorID, NombreVendedor, ClaveUsuario, DiaClave, ProductoClave, NombreProducto
		ORDER BY ProductoClave
	
		DROP TABLE #TmpUltimoInventarioABordo 
	
		FETCH NEXT FROM @CursorDiasT INTO @Dia 
	END
	
	CLOSE @CursorDiasT
	DEALLOCATE @CursorDiasT	

	SELECT
		DiaClave AS [Dia|GROUPER],
		ProductoClave AS [Clave],
		NombreProducto AS [Descripcion],
		InventarioInicial AS [Inventario Inicial|FORMAT&n0|SUMMARY],
		Recarga AS [Recarga|FORMAT&n0|SUMMARY],
		CambioDevolucionCte AS [Cambios y Dev. (Entrada)|FORMAT&n0|SUMMARY],
		CambioSalidaCte AS [Cambios (Salida)|FORMAT&n0|SUMMARY],
		Promocion AS [Promocion|FORMAT&n0|SUMMARY],
		Descarga AS [Descarga Almacen BE|FORMAT&n0|SUMMARY],
		Devolucion AS [Devolucion Almacen ME|FORMAT&n0|SUMMARY],
		Venta AS [Ventas|FORMAT&n0|SUMMARY],
		(InventarioInicial + Recarga + CambioDevolucionCte - CambioSalidaCte - Promocion - Descarga - Devolucion - Venta) AS [Inventario Final|FORMAT&n0|SUMMARY]
	FROM @TablaReporte

	SET NOCOUNT OFF
/*go*/go