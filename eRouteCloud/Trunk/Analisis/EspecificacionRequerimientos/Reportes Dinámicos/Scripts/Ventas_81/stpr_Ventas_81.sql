/* Reporte Dinamico Ventas */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_Ventas_81]
	@filtroVendedores = 'R-CACH,R-DES1',
	@filtroFechaInicio = '2020-01-01',
	@filtroFechaFin = '2020-06-30'
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_Ventas_81]'))
	DROP PROCEDURE [dbo].[stpr_Ventas_81]
SET NOCOUNT OFF
/*go*/go
 
CREATE PROCEDURE [dbo].[stpr_Ventas_81]
	@filtroVendedores AS VARCHAR(MAX) = NULL,
	@filtroFechaInicio AS VARCHAR(10) = NULL,
	@filtroFechaFin AS VARCHAR(10) = NULL
AS
SET NOCOUNT ON
	SELECT
		Productos.VendedorID + ' - ' + NombreVendedor AS [Vendedor|GROUPER],
		DiaClave AS [Fecha],
		SUM((Subtotal - DesCliPor - DesVendPor) + (Impuesto - DesCliPorImp)) AS [Total De Ventas De Productos|FORMAT&n],
		ISNULL(TotalDeVentasDeContado, 0) AS [Total De Ventas De Contado|FORMAT&n],
		ISNULL(TotalDeVentasACredito, 0) AS [Total De Ventas A Crédito|FORMAT&n],
		ISNULL(TotalDeCobranza, 0) AS [Total De Cobranza|FORMAT&n],
		ISNULL(TotalDeGastosDeVendedor, 0) AS [Total De Gastos De Vendedor|FORMAT&n],
		ISNULL(TotalDeComisiones, 0) AS [Total De Comisiones|FORMAT&n],
		ISNULL(TotalDevoluciones, 0) AS [Total Devoluciones|FORMAT&n],
		ISNULL(TotalALiquidar, 0) - ISNULL(TotalDeGastosDeVendedor, 0) AS [Total A Liquidar|FORMAT&n]
	FROM (
		/*Total De Ventas De Productos*/
		SELECT
			VD.VendedorID,
			VD.Nombre AS NombreVendedor,
			D.DiaClave,
			D.FechaCaptura,
			Subtotal = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN TD.Subtotal ELSE 0 END),
			DesCliPor = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN (SELECT (CASE WHEN SUM(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD (NOLOCK) WHERE T.TransProdID = TDD.TransProdId AND TDD.TransProdDetalleId = TD.TransProdDetalleID) ELSE 0 END),
			DesVendPor = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN TD.Subtotal - (SELECT (CASE WHEN SUM(DesImpuesto) IS NULL THEN 0 ELSE SUM(DesImpuesto) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = T.TransProdID AND TDD.TransProdDetalleId = TD.TransProdDetalleID) ELSE 0 END) * (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN (SELECT CASE WHEN T.DescVendPor IS NULL THEN 0 ELSE T.DescVendPor END) ELSE 0 END) / 100,
			Impuesto = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN (SELECT CASE WHEN TD.Impuesto IS NULL THEN 0 ELSE TD.Impuesto END) ELSE 0 END),
			DesCliPorImp = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN (SELECT (CASE WHEN SUM(DesImpuesto) IS NULL THEN 0 ELSE SUM(DesImpuesto) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = T.TransProdID AND TDD.TransProdDetalleId = TD.TransProdDetalleID) ELSE 0 END)
		FROM TransProd AS T (NOLOCK)
			INNER JOIN Dia AS D (NOLOCK) ON T.DiaClave = D.DiaClave
			INNER JOIN Visita AS V (NOLOCK) ON T.VisitaClave = V.VisitaClave AND T.DiaClave = V.DiaClave
			INNER JOIN TransProdDetalle AS TD (NOLOCK) ON T.TransProdID = TD.TransProdID
			INNER JOIN Producto AS P (NOLOCK) ON TD.ProductoClave = P.ProductoClave
			INNER JOIN ProductoDetalle AS PD (NOLOCK) ON TD.ProductoClave = PD.ProductoClave AND TD.ProductoClave = PD.ProductoDetClave AND TD.TipoUnidad = PD.PRUTipoUnidad
			INNER JOIN Vendedor AS VD (NOLOCK) ON V.VendedorID = VD.VendedorID
		WHERE T.Tipo = 1 AND T.TipoFase NOT IN (0,1,7)
			/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
			/*Filtro Vendedores*/	AND VD.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
	UNION ALL
		SELECT
			VD.VendedorID,
			VD.Nombre AS NombreVendedor,
			D.DiaClave,
			D.FechaCaptura,
			Subtotal = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN TD.Subtotal ELSE 0 END),
			DesCliPor = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN (SELECT (CASE WHEN SUM(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD (NOLOCK) WHERE T.TransProdID = TDD.TransProdId AND TDD.TransProdDetalleId = TD.TransProdDetalleID) ELSE 0 END),
			DesVendPor = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN TD.Subtotal - (SELECT (CASE WHEN SUM(DesImpuesto) IS NULL THEN 0 ELSE SUM(DesImpuesto) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = T.TransProdID AND TDD.TransProdDetalleId = TD.TransProdDetalleID) ELSE 0 END) * (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN (SELECT CASE WHEN T.DescVendPor IS NULL THEN 0 ELSE T.DescVendPor END) ELSE 0 END) / 100,
			Impuesto = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN (SELECT CASE WHEN TD.Impuesto IS NULL THEN 0 ELSE TD.Impuesto END) ELSE 0 END),
			DesCliPorImp = (SELECT CASE WHEN T.Tipo = 1 AND TD.Total > 0 THEN (SELECT (CASE WHEN SUM(DesImpuesto) IS NULL THEN 0 ELSE SUM(DesImpuesto) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = T.TransProdID AND TDD.TransProdDetalleId = TD.TransProdDetalleID) ELSE 0 END)
		FROM TransProd AS T (NOLOCK)
			INNER JOIN Dia AS D (NOLOCK) ON T.DiaClave1 = D.DiaClave
			INNER JOIN Visita AS V (NOLOCK) ON T.VisitaClave1 = V.VisitaClave AND T.DiaClave1 = V.DiaClave
			INNER JOIN TransProdDetalle AS TD (NOLOCK) ON T.TransProdID = TD.TransProdID
			INNER JOIN Producto AS P (NOLOCK) ON TD.ProductoClave = P.ProductoClave
			INNER JOIN ProductoDetalle AS PD (NOLOCK) ON TD.ProductoClave = PD.ProductoClave AND TD.ProductoClave = PD.ProductoDetClave AND TD.TipoUnidad = PD.PRUTipoUnidad
			INNER JOIN Vendedor AS VD (NOLOCK) ON V.VendedorID = VD.VendedorID
		WHERE T.Tipo = 1 AND T.TipoFase NOT IN (0,1,7)
			/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
			/*Filtro Vendedores*/	AND VD.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
	) AS Productos
		LEFT JOIN (
			/*Total De Ventas De Contado*/
			SELECT
				VendedorID,
				FechaCaptura,
				SUM(Total) AS TotalDeVentasDeContado
			FROM (
				SELECT
					VD.VendedorID,
					D.FechaCaptura,
					Total = (SELECT CASE WHEN T.TipoFase = 0 THEN 0 ELSE T.Total END)
				FROM TransProd AS T (NOLOCK)
					INNER JOIN Dia AS D (NOLOCK) ON T.DiaClave = D.DiaClave
					INNER JOIN Visita AS V (NOLOCK) ON T.VisitaClave = V.VisitaClave AND T.DiaClave = V.DiaClave
					INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
					INNER JOIN Vendedor AS VD (NOLOCK) ON V.VendedorID = VD.VendedorID
					LEFT JOIN TransProd AS T2 (NOLOCK) ON T2.Tipo = 8 AND T.FacturaID = T2.TransProdID
				WHERE T.Tipo = 1 AND T.CFVTipo = 1 AND T.TipoFase NOT IN (1,7)
					/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
					/*Filtro Vendedores*/	AND VD.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
				UNION ALL
				SELECT
					VD.VendedorID,
					D.FechaCaptura,
					Total = (SELECT CASE WHEN T.TipoFase = 0 THEN 0 ELSE T.Total END)
				FROM TransProd AS T (NOLOCK)
					INNER JOIN Dia AS D (NOLOCK) ON T.DiaClave1 = D.DiaClave
					INNER JOIN Visita AS V (NOLOCK) ON T.VisitaClave1 = V.VisitaClave AND T.DiaClave1 = V.DiaClave
					INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
					INNER JOIN Vendedor AS VD (NOLOCK) ON V.VendedorID = VD.VendedorID
					LEFT JOIN TransProd AS T2 (NOLOCK) ON T2.Tipo = 8 AND T.FacturaID = T2.TransProdID
				WHERE T.Tipo = 1 AND T.CFVTipo = 1 AND T.TipoFase NOT IN (1,7)
					/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
					/*Filtro Vendedores*/	AND VD.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
			) AS Contado
			GROUP BY VendedorID, FechaCaptura
		) AS Contado ON Contado.VendedorID = Productos.VendedorID AND Contado.FechaCaptura = Productos.FechaCaptura
		LEFT JOIN (
			/*Total De Ventas A Crédito*/
			SELECT
				VendedorID,
				FechaCaptura,
				SUM(Total) AS TotalDeVentasACredito
			FROM (
				SELECT
					VD.VendedorID,
					D.FechaCaptura,
					Total = (SELECT CASE WHEN T.TipoFase = 0 THEN 0 ELSE T.Total END)
				FROM TransProd AS T (NOLOCK)
					INNER JOIN Dia AS D (NOLOCK) ON T.DiaClave = D.DiaClave
					INNER JOIN Visita AS V (NOLOCK) ON T.VisitaClave = V.VisitaClave AND T.DiaClave = V.DiaClave
					INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
					INNER JOIN Vendedor AS VD (NOLOCK) ON V.VendedorID = VD.VendedorID
					LEFT JOIN TransProd AS T2 (NOLOCK) ON T2.Tipo = 8 AND T.FacturaID = T2.TransProdID
				WHERE T.Tipo = 1 AND T.CFVTipo = 2 AND T.TipoFase NOT IN (1,7)
					/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
					/*Filtro Vendedores*/	AND VD.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
				UNION ALL
				SELECT
					VD.VendedorID,
					D.FechaCaptura,
					Total = (SELECT CASE WHEN T.TipoFase = 0 THEN 0 ELSE T.Total END)
				FROM TransProd AS T (NOLOCK)
					INNER JOIN Dia AS D (NOLOCK) ON T.DiaClave1 = D.DiaClave
					INNER JOIN Visita AS V (NOLOCK) ON T.VisitaClave1 = V.VisitaClave AND T.DiaClave1 = V.DiaClave
					INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
					INNER JOIN Vendedor AS VD (NOLOCK) ON V.VendedorID = VD.VendedorID
					LEFT JOIN TransProd AS T2 (NOLOCK) ON T2.Tipo = 8 AND T.FacturaID = T2.TransProdID
				WHERE T.Tipo = 1 AND T.CFVTipo = 2 AND T.TipoFase NOT IN (1,7)
					/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
					/*Filtro Vendedores*/	AND VD.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
			) AS Contado
			GROUP BY VendedorID, FechaCaptura
		) AS Credito ON Credito.VendedorID = Productos.VendedorID AND Credito.FechaCaptura = Productos.FechaCaptura
		LEFT JOIN (
			/*Total De Cobranza*/
			SELECT
				VendedorID,
				FechaCaptura,
				SUM(Total) AS TotalDeCobranza
			FROM (
				SELECT
					V.VendedorID,
					D.FechaCaptura,
					ABT.Importe AS Total
				FROM Abono AS A (NOLOCK)
					INNER JOIN Dia AS D (NOLOCK) ON A.DiaClave = D.DiaClave
					INNER JOIN Visita AS V (NOLOCK) ON A.VisitaClave = V.VisitaClave AND A.DiaClave = V.DiaClave
					INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
					INNER JOIN ABNDetalle AS AD (NOLOCK) ON A.ABNId = AD.ABNId
					INNER JOIN AbnTrp AS ABT (NOLOCK) ON A.ABNId = ABT.ABNId
					INNER JOIN TransProd AS T (NOLOCK) ON ABT.TransProdID = T.TransProdID
				WHERE T.CFVTipo IN (2, CASE WHEN (SELECT TOP 1 PagoAutomatico FROM ConHist (NOLOCK) WHERE CONHistFechaInicio <= T.FechaCaptura ORDER BY CONHistFechaInicio DESC) = 0 THEN 1 ELSE 2 END) 
					/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
					/*Filtro Vendedores*/	AND V.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
				UNION 
				SELECT
					V.VendedorID,
					CONVERT(date, A.DiaClave, 103) AS FechaCaptura,
					ABT.Importe AS Total
				FROM Abono AS A (NOLOCK)
					INNER JOIN Dia AS D (NOLOCK) ON A.DiaClave = D.DiaClave
					INNER JOIN Visita AS V (NOLOCK) ON A.VisitaClave = V.VisitaClave AND A.DiaClave = V.DiaClave
					INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
					INNER JOIN ABNDetalle AS AD (NOLOCK) ON A.ABNId = AD.ABNId
					INNER JOIN AbnTrp AS ABT (NOLOCK) ON A.ABNId = ABT.ABNId
					INNER JOIN TransProd AS T (NOLOCK) ON ABT.TransProdID = T.TransProdID
				WHERE T.CFVTipo IN (2, CASE WHEN (SELECT TOP 1 PagoAutomatico FROM ConHist (NOLOCK) WHERE CONHistFechaInicio <= T.FechaCaptura ORDER BY CONHistFechaInicio DESC) = 0 THEN 1 ELSE 2 END)
					/*Filtro Fechas*/		AND CONVERT(date, A.DiaClave, 103) BETWEEN @filtroFechaInicio AND @filtroFechaFin
											AND T.FechaCaptura < CONVERT(date, A.DiaClave, 103)
					/*Filtro Vendedores*/	AND V.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
			) AS Cobranza
			GROUP BY VendedorID, FechaCaptura
		) AS Cobranza ON Cobranza.VendedorID = Productos.VendedorID AND Cobranza.FechaCaptura = Productos.FechaCaptura
		LEFT JOIN (
			/*Total De Gastos De Vendedor*/
			SELECT
				G.VendedorID,
				D.FechaCaptura,
				SUM(Total) AS TotalDeGastosDeVendedor
			FROM Gasto AS G (NOLOCK)
				INNER JOIN Dia AS D (NOLOCK) ON G.DiaClave = D.DiaClave
				INNER JOIN VAVDescripcion AS VD (NOLOCK) ON G.TipoConcepto = VD.VAVClave
			WHERE VD.VARCodigo = 'GASTIPO' AND VD.VADTipoLenguaje = (SELECT dbo.FNObtenerLenguaje())
				/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
				/*Filtro Vendedores*/	AND G.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
			GROUP BY G.VendedorId, D.FechaCaptura
		) AS Gastos ON Gastos.VendedorID = Productos.VendedorID AND Gastos.FechaCaptura = Productos.FechaCaptura
		LEFT JOIN (
			/*Total De Comisiones*/
			SELECT
				VendedorID,
				FechaCaptura,
				SUM(ImporteComision) AS TotalDeComisiones
			FROM (
				SELECT
					V.VendedorID,
					D.FechaCaptura,
					SUM(TD.Cantidad) * CE.Comision AS ImporteComision
				FROM TransProd AS T (NOLOCK)
					INNER JOIN Visita AS V (NOLOCK) ON V.VisitaClave = T.VisitaClave AND T.DiaClave = V.DiaClave
					INNER JOIN Dia AS D (NOLOCK) ON V.DiaClave = D.DiaClave
					INNER JOIN TransProdDetalle AS TD (NOLOCK) ON T.TransProdID = TD.TransProdID
					INNER JOIN ProductoEsquema AS PE (NOLOCK) ON PE.ProductoClave = TD.ProductoClave
					INNER JOIN ComisionEsquema AS CE (NOLOCK) ON CE.PrecioClave = T.PCEPrecioClave AND PE.EsquemaID = CE.EsquemaId
					INNER JOIN Esquema AS E (NOLOCK) ON PE.EsquemaID = E.EsquemaID
					INNER JOIN Precio AS P (NOLOCK) ON T.PCEPrecioClave = P.PrecioClave
				WHERE T.Tipo = 1 AND T.TipoFase IN (2,3) AND iSNULL(TD.Promocion,0) <> 2
					/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
					/*Filtro Vendedores*/	AND V.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
				GROUP BY V.VendedorID, D.FechaCaptura, CE.Comision
			) AS Comisiones
			GROUP BY VendedorID, FechaCaptura
		) AS Comisiones ON Comisiones.VendedorID = Productos.VendedorID AND Comisiones.FechaCaptura = Productos.FechaCaptura
		LEFT JOIN (
			/*Total Devoluciones*/
			SELECT
				V.VendedorID,
				D.FechaCaptura,
				SUM(TD.Total) AS TotalDevoluciones
			FROM TransProd AS T (NOLOCK)
				INNER JOIN Visita AS V (NOLOCK) ON V.VisitaClave = T.VisitaClave AND T.DiaClave = V.DiaClave
				INNER JOIN Dia AS D (NOLOCK) ON V.DiaClave = D.DiaClave
				INNER JOIN TransProdDetalle AS TD (NOLOCK) ON T.TransProdID = TD.TransProdID  AND T.Tipo = 3 AND T.TipoFase <> 0
				INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
				INNER JOIN VAVDescripcion AS VD (NOLOCK) ON TD.TipoMotivo = VD.VAVClave
				INNER JOIN Producto AS P (NOLOCK) ON td.ProductoClave = p.ProductoClave
			WHERE VD.VARCodigo = 'TRPMOT' AND VD.VADTipoLenguaje = (SELECT dbo.FNObtenerLenguaje())
				/*Filtro Fechas*/		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
				/*Filtro Vendedores*/	AND V.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
			GROUP BY V.VendedorID, D.FechaCaptura
		) AS Devoluciones ON Devoluciones.VendedorID = Productos.VendedorID AND Devoluciones.FechaCaptura = Productos.FechaCaptura
		LEFT JOIN (
			/*Total A Liquidar*/
			SELECT
				V.VendedorID,
				D.FechaCaptura,
				ISNULL(SUM(ABT.Importe),0) AS TotalALiquidar
			FROM Abono AS A (NOLOCK)
				INNER JOIN ABNDetalle AS AD (NOLOCK) ON A.ABNId = AD.ABNId
				INNER JOIN Dia AS D (NOLOCK) ON A.DiaClave = D.DiaClave
				INNER JOIN AbnTrp AS ABT (NOLOCK) ON A.ABNId = ABT.ABNId
				INNER JOIN TransProd AS T (NOLOCK) ON ABT.TransProdID = T.TransProdID
				INNER JOIN Visita AS V (NOLOCK) ON A.VisitaClave = V.VisitaClave AND A.DiaClave = V.DiaClave
				INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
			WHERE
				/*Filtro Fechas*/		CONVERT(date, D.FechaCaptura, 112) BETWEEN @filtroFechaInicio AND @filtroFechaFin
				/*Filtro Vendedores*/	AND V.VendedorID IN (SELECT Datos FROM FNSplit(@filtroVendedores, ','))
			GROUP BY V.VendedorID, D.FechaCaptura
		) AS Liquidar ON Liquidar.VendedorID = Productos.VendedorID AND Liquidar.FechaCaptura = Productos.FechaCaptura
	GROUP BY Productos.VendedorID, NombreVendedor, Productos.FechaCaptura, DiaClave, TotalDeVentasDeContado, TotalDeVentasACredito, TotalDeCobranza, TotalDeGastosDeVendedor, TotalDeComisiones, TotalDevoluciones, TotalALiquidar
	ORDER BY Productos.VendedorID, NombreVendedor, Productos.FechaCaptura
SET NOCOUNT OFF
/*go*/go