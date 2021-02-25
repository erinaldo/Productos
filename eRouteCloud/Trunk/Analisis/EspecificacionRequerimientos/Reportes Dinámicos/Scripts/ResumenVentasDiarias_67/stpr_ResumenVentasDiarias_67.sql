
/* Reporte Dinamico Resumen De Ventas Diarias */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_ResumenVentasDiarias_67]
	@filterCEDIS = '44H5SO2UWRTK6+1',
	@filterStartDate = '2020-01-01',
	@filterEndDate = '2020-01-15'
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_ResumenVentasDiarias_67]'))
	DROP PROCEDURE [dbo].[stpr_ResumenVentasDiarias_67]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_ResumenVentasDiarias_67]
	@filterCEDIS AS varchar(16) = NULL,
	@filterStartDate AS varchar(10) = NULL,
	@filterEndDate AS varchar(10) = NULL
AS
	SET ANSI_WARNINGS OFF
	SET NOCOUNT ON
	SELECT
		ISNULL(R1.RUTClave, V.Ruta) AS [Ruta],
		VEN.Nombre AS [Vendedor],
		ISNULL ((
			SELECT COUNT(DISTINCT AV.ClienteClave)
			FROM AgendaVendedor AS AV (NOLOCK)
				INNER JOIN Dia AS D (NOLOCK) ON AV.DiaClave = D.DiaClave
				INNER JOIN Almacen AS A (NOLOCK) ON AV.ClaveCEDI = A.Clave
			WHERE CONVERT(date, D.FechaCaptura, 112) BETWEEN @filterStartDate AND @filterEndDate
				AND A.AlmacenID = @filterCEDIS AND AV.VendedorId = VEN.VendedorID
		), 0) AS [Clientes A Visitar|FORMAT&n|SUMMARY],
		ISNULL((
			SELECT COUNT(DISTINCT AV.ClienteClave)
			FROM AgendaVendedor AS AV (NOLOCK)
				INNER JOIN Dia AS D (NOLOCK) ON AV.DiaClave = D.DiaClave
				INNER JOIN Visita AS V (NOLOCK) ON AV.VendedorId = V.VendedorID AND AV.ClienteClave = V.ClienteClave AND D.DiaClave = V.DiaClave
				INNER JOIN Almacen AS A (NOLOCK) ON AV.ClaveCEDI = A.Clave
			WHERE CONVERT(date, D.FechaCaptura, 112) BETWEEN @filterStartDate AND @filterEndDate
				AND A.AlmacenID = @filterCEDIS
				AND AV.VendedorId = VEN.VendedorID
		), 0) AS [Clientes Visitados|FORMAT&n|SUMMARY],
		ISNULL(Subtotal, 0) AS [Subtotal|FORMAT&n|SUMMARY],
		CASE WHEN ImporteVenta <> 0 THEN ISNULL(ImporteDescuento, 0) ELSE 0 END AS [Importe Descuento|FORMAT&n|SUMMARY],
		CASE WHEN ImporteVenta <> 0 THEN ((ISNULL(ImporteDescuento, 0) * 100) / ImporteVenta) ELSE 0 END AS [% Descuento|FORMAT&n|SUMMARY],
		ISNULL(ImporteVenta, 0) AS [Importe Venta|FORMAT&n|SUMMARY],
		ISNULL(ImporteVentaContado, 0) AS [Contado|FORMAT&n|SUMMARY],
		CASE WHEN ImporteVenta <> 0 THEN ISNULL(ImporteVentaCredito, 0) ELSE 0 END AS [Credito|FORMAT&n|SUMMARY],
		ISNULL((
			SELECT ISNULL(SUM(ABT.Importe), 0)
			FROM Abono AS AB
				INNER JOIN Visita AS V (NOLOCK) ON AB.VisitaClave = V.VisitaClave
				INNER JOIN AbnTrp AS ABT (NOLOCK) ON AB.ABNId = ABT.ABNId
				INNER JOIN TransProd AS T (NOLOCK) ON ABT.TransProdID = T.TransProdID
				INNER JOIN Dia AS D (NOLOCK) ON AB.DiaClave = D.DiaClave
				INNER JOIN VENCentroDistHist AS VCH (NOLOCK) ON V.VendedorID = VCH.VendedorId AND CONVERT(datetime, LEFT(VCHFechaInicial, 11), 112) <= D.FechaCaptura AND FechaFinal >= D.FechaCaptura
				INNER JOIN Almacen AS A (NOLOCK) ON VCH.AlmacenId = A.AlmacenID
			WHERE T.CFVTipo = 2
				AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filterStartDate AND @filterEndDate
				AND A.AlmacenID = @filterCEDIS
				AND V.VendedorID = VEN.VendedorID
		), 0) AS [Abono A Creditos|FORMAT&n|SUMMARY],
		'=I{0}+K{0}' AS [Total Cobrado|FORMAT&n|SUMMARY]
	FROM
	(
		SELECT VEN.VendedorID, VEN.Nombre, ALM.AlmacenID
		FROM Vendedor AS VEN (NOLOCK)
			INNER JOIN (
				SELECT V1.VendedorId, V1.AlmacenId
				FROM VENCentroDistHist AS V1 (NOLOCK)
				INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist (NOLOCK) GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal
			) VENDIS ON VEN.VendedorID = VENDIS.VendedorId
			INNER JOIN Almacen ALM (NOLOCK) ON VENDIS.AlmacenId = ALM.AlmacenID AND ALM.AlmacenID = @filterCEDIS WHERE VEN.TipoEstado = 1   
	) AS VEN
		INNER JOIN Almacen AS A (NOLOCK) ON VEN.AlmacenID = A.AlmacenID
		LEFT JOIN (
			SELECT R.RUTClave, VR.VendedorID
			FROM VenRut VR
				INNER JOIN Ruta AS R (NOLOCK) ON R.RUTClave = VR.RUTClave AND VR.TipoEstado = 1
		) R1 ON VEN.VendedorID = R1.VendedorID
		LEFT JOIN (
			SELECT X.ClaveCedi, X.NombreCedi, X.Ruta, X.Vendedor, X.VendedorID,
				(
					SELECT COUNT(DISTINCT AV.ClienteClave)
					FROM AgendaVendedor AS AV (NOLOCK)
						INNER JOIN Dia AS D (NOLOCK) ON AV.DiaClave = D.DiaClave
						INNER JOIN Almacen AS A (NOLOCK) ON AV.ClaveCEDI = A.Clave
					WHERE CONVERT(date, D.FechaCaptura, 112) BETWEEN @filterStartDate AND @filterEndDate
						AND A.AlmacenID = @filterCEDIS
						AND AV.VendedorId = X.VendedorID
				) AS ClientesAVisitar,
				(
					SELECT COUNT(DISTINCT AV.ClienteClave)
					FROM AgendaVendedor AS AV (NOLOCK)
						INNER JOIN Dia AS D (NOLOCK) ON AV.DiaClave = D.DiaClave
						INNER JOIN Visita AS V (NOLOCK) ON AV.VendedorId = V.VendedorID AND AV.ClienteClave = V.ClienteClave AND D.DiaClave = V.DiaClave
						INNER JOIN Almacen AS A (NOLOCK) ON AV.ClaveCEDI = A.Clave
					WHERE CONVERT(date, D.FechaCaptura, 112) BETWEEN @filterStartDate AND @filterEndDate
						AND A.AlmacenID = @filterCEDIS
						AND AV.VendedorId = X.VendedorID
				) AS ClientesVisitados,
				(SUM(X.ImporteVentaContado) + SUM(X.ImporteVentaCredito)) AS ImporteVenta,
				(SUM(X.DescuentoVendedor) + SUM(X.DescuentoImp) + SUM(X.DescTransprodDetalle)) AS ImporteDescuento,
				SUM(X.ImporteVentaContado) AS ImporteVentaContado,
				SUM(X.ImporteVentaCredito) AS ImporteVentaCredito,
				SUM(X.Subtotal) AS Subtotal,
				(
					SELECT ISNULL(SUM(ABT.Importe), 0)
					FROM Abono AB (NOLOCK)
						INNER JOIN Visita AS V (NOLOCK) ON AB.VisitaClave = V.VisitaClave
						INNER JOIN AbnTrp AS ABT (NOLOCK) ON AB.ABNId = ABT.ABNId
						INNER JOIN TransProd AS T (NOLOCK) ON ABT.TransProdID = T.TransProdID
						INNER JOIN Dia AS D (NOLOCK) ON AB.DiaClave = D.DiaClave
						INNER JOIN VENCentroDistHist AS VCH (NOLOCK) ON V.VendedorID = VCH.VendedorId AND CONVERT(datetime, LEFT(VCHFechaInicial, 11), 112) <= D.FechaCaptura AND FechaFinal >= D.FechaCaptura
						INNER JOIN Almacen AS A (NOLOCK) ON VCH.AlmacenId = A.AlmacenID
					WHERE CONVERT(date, D.FechaCaptura, 112) BETWEEN @filterStartDate AND @filterEndDate
						AND A.AlmacenID = @filterCEDIS
						AND T.CFVTipo = 2 AND V.VendedorID = X.VendedorID
				) AS AbonoCreditos,
				TipoEstado
			FROM (
				SELECT A.Clave AS ClaveCedi, A.Nombre AS NombreCedi, R.RUTClave AS Ruta, VE.VendedorID, VE.Nombre AS Vendedor, T.TransProdID, T.CFVTipo,
					CASE T.CFVTipo WHEN 1 THEN SUM(T.Total) ELSE 0 END AS ImporteVentaContado,	  
					CASE T.CFVTipo WHEN 2 THEN SUM(T.Total) ELSE 0 END AS ImporteVentaCredito,
					SUM(T.DescuentoVendedor) AS DescuentoVendedor,
					SUM(T.DescuentoImp) AS DescuentoImp,
					(SELECT SUM(TD.DescuentoImp) FROM TransProdDetalle AS TD (NOLOCK) WHERE TD.TransProdID = T.TransProdID GROUP BY TD.TransProdID) AS DescTransprodDetalle, VR.TipoEstado,
					(SELECT SUM((TD.Cantidad * TD.Precio)) FROM TransProdDetalle AS TD (NOLOCK) WHERE TD.TransProdID = T.TransProdID GROUP BY TD.TransProdID) AS Subtotal
				FROM TransProd AS T (NOLOCK)
					INNER JOIN Visita AS V (NOLOCK) ON ISNULL(T.VisitaClave1, T.VisitaClave) = V.VisitaClave AND ISNULL(T.DiaClave1, T.DiaClave) = V.DiaClave
					INNER JOIN Dia AS D (NOLOCK) ON V.DiaClave = D.DiaClave
					INNER JOIN Vendedor AS VE (NOLOCK) ON V.VendedorID = VE.VendedorID
					INNER JOIN VENCentroDistHist AS VCH (NOLOCK) ON V.VendedorID = VCH.VendedorId AND CONVERT(datetime, LEFT(VCHFechaInicial, 11), 112) <= D.FechaCaptura AND FechaFinal >= D.FechaCaptura
					INNER JOIN Ruta AS R (NOLOCK) ON V.RUTClave = R.RUTClave
					INNER JOIN Almacen AS A (NOLOCK) ON VCH.AlmacenId = A.AlmacenID
					INNER JOIN VenRut AS VR (NOLOCK) ON VE.VendedorID = VR.VendedorID AND R.RUTClave = VR.RUTClave
				WHERE T.Tipo = 1 AND T.TipoFase IN (2,3)
					AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filterStartDate AND @filterEndDate
					AND A.AlmacenID = @filterCEDIS
				GROUP BY A.Clave, A.Nombre, R.RUTClave, VE.VendedorID, VE.Nombre, T.TransProdID, T.CFVTipo, VR.TipoEstado
			) X
			GROUP BY X.ClaveCedi, X.NombreCedi, X.Ruta, X.VendedorID, X.Vendedor, X.TipoEstado
		) V ON (V.Ruta = R1.RUTClave AND V.VendedorID = VEN.VendedorID AND V.TipoEstado = 1) OR (VEN.VendedorID = V.VendedorID AND V.TipoEstado = 0)
	WHERE R1.RUTClave IS NOT NULL OR V.Ruta IS NOT NULL
	ORDER BY R1.RUTClave
	SET NOCOUNT OFF
/*go*/go