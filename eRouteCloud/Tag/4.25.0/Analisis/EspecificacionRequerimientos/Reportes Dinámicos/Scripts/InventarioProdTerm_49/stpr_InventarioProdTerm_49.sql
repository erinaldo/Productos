/* Reporte Dinamico Inventario De Producto Terminado */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_InventarioProdTerm_49]
	@filterCEDIS = '44H5SO2UWRTK6+1',
	@filterStartDate = '2020-01-06'
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_InventarioProdTerm_49]'))
	DROP PROCEDURE [dbo].[stpr_InventarioProdTerm_49]
SET NOCOUNT OFF
/*go*/go
 
CREATE PROCEDURE [dbo].[stpr_InventarioProdTerm_49]
	@filterCEDIS AS varchar(16) = NULL,
	@filterStartDate AS varchar(10) = NULL
AS
	SET ANSI_WARNINGS OFF
	SET NOCOUNT ON
	SELECT @filterCEDIS = Clave FROM Almacen (NOLOCK) WHERE AlmacenID = @filterCEDIS
	DECLARE @ValidaCargaSugerida AS int
	SELECT @ValidaCargaSugerida = COUNT(*)
	FROM TransProd AS TRP (NOLOCK)
		INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
		INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave
		INNER JOIN ProductoDetalle AS PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave AND TPD.TipoUnidad = PRO.PRUTipoUnidad AND PRO.ProductoDetClave = TPD.ProductoClave
	WHERE TRP.Tipo = 2 AND TRP.TipoFase <> 0 AND TRP.TipoMotivo = 9
		AND D.FechaCaptura = @filterStartDate
		AND TRP.Notas = @filterCEDIS

	DECLARE @FechaUltimaDescarga AS varchar(10)
	SELECT TOP 1 @FechaUltimaDescarga = D.DiaClave
	FROM TransProd AS TRP (NOLOCK)
		INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave
	WHERE TRP.Tipo = 7
		AND D.FechaCaptura < @filterStartDate
	ORDER BY D.FechaCaptura DESC

	IF (SELECT OBJECT_ID('tempdb..#TmpProductoTerminado')) IS NOT NULL DROP TABLE #TmpProductoTerminado
	CREATE TABLE #TmpProductoTerminado
	(
		ProductoClave		varchar(25) COLLATE DATABASE_DEFAULT NOT NULL,
		ExistenciaAnterior	int NOT NULL,
		Cargas				int NOT NULL,
		SobrantesProduccion	int NOT NULL
    )

	IF @ValidaCargaSugerida > 0
		BEGIN
			INSERT INTO #TmpProductoTerminado(ProductoClave, ExistenciaAnterior, Cargas, SobrantesProduccion)
			SELECT ProductoClave, SUM(ExistenciaAnterior) AS ExistenciaAnterior, SUM(Cargas) AS Cargas, SUM(SobrantesProduccion) AS SobrantesProduccion
			FROM (
				SELECT PRO.ProductoClave, ISNULL(SUM(TPD.Cantidad * PRO.Factor), 0) AS ExistenciaAnterior, 0 AS Cargas, 0 AS SobrantesProduccion
				FROM TransProd AS TRP (NOLOCK)
					INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
					INNER JOIN Dia AS D (NOLOCK) ON D.DiaClave = TRP.DiaClave
					INNER JOIN ProductoDetalle AS PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave AND TPD.TipoUnidad = PRO.PRUTipoUnidad AND PRO.ProductoDetClave = TPD.ProductoClave
				WHERE D.FechaCaptura = @filterStartDate AND TRP.Notas = @filterCEDIS AND TRP.Tipo = 2 AND TRP.TipoFase <> 0 AND TRP.TipoMotivo = 9
				GROUP BY PRO.ProductoClave
				UNION
				SELECT PRO.ProductoClave, 0 AS ExistenciaAnterior, ISNULL(SUM(TPD.Cantidad * PRO.Factor), 0) AS Cargas, 0 AS SobrantesProduccion
				FROM TransProd AS TRP (NOLOCK)
					INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
					INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave
					INNER JOIN ProductoDetalle AS PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave AND TPD.TipoUnidad = PRO.PRUTipoUnidad AND PRO.ProductoDetClave = TPD.ProductoClave
					LEFT JOIN (SELECT DiaClave, ClaveCEDI FROM AgendaVendedor (NOLOCK) GROUP BY DiaClave, ClaveCEDI) AS AGV ON AGV.DiaClave = TRP.DiaClave
				WHERE D.FechaCaptura = @filterStartDate AND (AGV.ClaveCEDI = @filterCEDIS OR TRP.Notas = @filterCEDIS) AND TRP.Tipo = 2 AND TRP.TipoFase <> 0 AND TRP.TipoMotivo <> 9
				GROUP BY PRO.ProductoClave
				UNION
				SELECT PRO.ProductoClave, 0 AS ExistenciaAnterior, 0 AS Cargas, ISNULL(SUM(TPD.Cantidad * PRO.Factor), 0) AS SobrantesProduccion
				FROM TransProd AS TRP (NOLOCK)
					INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
					INNER JOIN ProductoDetalle AS PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave AND TPD.TipoUnidad = PRO.PRUTipoUnidad AND PRO.ProductoDetClave = TPD.ProductoClave
				WHERE TRP.Tipo = 25 AND TRP.TipoFase = 1 AND TRP.FechaHoraAlta = @filterStartDate AND TRP.Notas = @filterCEDIS
				GROUP BY PRO.ProductoClave
			) AS t GROUP BY ProductoClave
		END
	ELSE
		BEGIN
			INSERT INTO #TmpProductoTerminado(ProductoClave, ExistenciaAnterior, Cargas, SobrantesProduccion)
			SELECT ProductoClave, SUM(ExistenciaAnterior) AS ExistenciaAnterior, SUM(Cargas) AS Cargas, SUM(SobrantesProduccion) AS SobrantesProduccion
			FROM (
				SELECT PRO.ProductoClave, ISNULL(SUM(TPD.Cantidad * PRO.Factor), 0) AS ExistenciaAnterior, 0 AS Cargas, 0 AS SobrantesProduccion
				FROM TransProd AS TRP (NOLOCK)
					INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
					INNER JOIN ProductoDetalle AS PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave AND TPD.TipoUnidad = PRO.PRUTipoUnidad AND PRO.ProductoDetClave = TPD.ProductoClave
					INNER JOIN (SELECT DiaClave, ClaveCEDI FROM AgendaVendedor (NOLOCK) GROUP BY DiaClave, ClaveCEDI) AS AGV ON AGV.DiaClave = TRP.DiaClave
					INNER JOIN Dia AS D (NOLOCK) ON D.DiaClave = TRP.DiaClave
				WHERE TRP.Tipo = 7 AND TRP.TipoFase = 1 AND TRP.DiaClave = @FechaUltimaDescarga
					AND AGV.ClaveCEDI = @filterCEDIS
				GROUP BY PRO.ProductoClave
				UNION
				SELECT PRO.ProductoClave, 0 AS ExistenciaAnterior, ISNULL(SUM(TPD.Cantidad * PRO.Factor), 0) AS Cargas, 0 AS SobrantesProduccion
				FROM TransProd AS TRP (NOLOCK)
					INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
					INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave
					INNER JOIN ProductoDetalle AS PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave AND TPD.TipoUnidad = PRO.PRUTipoUnidad AND PRO.ProductoDetClave = TPD.ProductoClave
					LEFT JOIN (SELECT DiaClave, ClaveCEDI FROM AgendaVendedor (NOLOCK) GROUP BY DiaClave, ClaveCEDI) AS AGV ON AGV.DiaClave = TRP.DiaClave
				WHERE D.FechaCaptura = @filterStartDate AND (AGV.ClaveCEDI = @filterCEDIS OR TRP.Notas = @filterCEDIS) AND TRP.Tipo = 2 AND TRP.TipoFase <> 0 AND TRP.TipoMotivo <> 9
				GROUP BY PRO.ProductoClave
				UNION
				SELECT PRO.ProductoClave, 0 AS ExistenciaAnterior, 0 AS Cargas, ISNULL(SUM(TPD.Cantidad * PRO.Factor), 0) AS SobrantesProduccion
				FROM TransProd AS TRP (NOLOCK)
					INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
					INNER JOIN ProductoDetalle AS PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave AND TPD.TipoUnidad = PRO.PRUTipoUnidad AND PRO.ProductoDetClave = TPD.ProductoClave
				WHERE TRP.Tipo = 25 AND TRP.TipoFase = 1 AND TRP.FechaHoraAlta = @filterStartDate AND TRP.Notas = @filterCEDIS
				GROUP BY PRO.ProductoClave
			) AS t1 GROUP BY ProductoClave
		END

	SELECT
		TPD.ProductoClave AS [Clave],
		PRO.Nombre AS [Producto],
		TPD.ExistenciaAnterior AS [Existencia Anterior|FORMAT&n0|SUMMARY],
		TPD.Cargas AS [Cargas|FORMAT&n0|SUMMARY],
		TPD.SobrantesProduccion AS [Sobrantes Produccion|FORMAT&n0|SUMMARY],
		(TPD.ExistenciaAnterior + TPD.Cargas + TPD.SobrantesProduccion) AS [Existencia Total|FORMAT&n0|SUMMARY],
		ISNULL((
			SELECT TOP 1 Precio
			FROM PrecioProductoVig AS PPV (NOLOCK)
			WHERE PPV.ProductoClave = TPD.ProductoClave AND PrecioClave = 'LISTA01'
				AND (@filterStartDate >= PPV.PPVFechaInicio AND @filterStartDate <= PPV.FechaFin AND PPV.TipoEstado = 1) ORDER BY PRUTipoUnidad
		), 0) AS [Precion Unitario],
		ISNULL((
			(TPD.ExistenciaAnterior + TPD.Cargas + TPD.SobrantesProduccion) * (
				SELECT TOP 1 Precio
				FROM PrecioProductoVig AS PPV (NOLOCK)
				WHERE PPV.ProductoClave = TPD.ProductoClave AND PrecioClave = 'LISTA01' AND (@filterStartDate >= PPV.PPVFechaInicio AND @filterStartDate <= PPV.FechaFin AND PPV.TipoEstado = 1)
				ORDER BY PRUTipoUnidad
			)
		), 0) AS [Importe|FORMAT&n0|SUMMARY]
	FROM #TmpProductoTerminado AS TPD (NOLOCK)
		INNER JOIN Producto AS PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave

	DROP TABLE #TmpProductoTerminado 
	SET NOCOUNT OFF
/*go*/go