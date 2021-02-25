SET NOCOUNT ON
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND NAME='stpr_CobranzaGral_25')
	DROP PROCEDURE [dbo].[stpr_CobranzaGral_25]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_CobranzaGral_25]
@FILTROCEDI AS VARCHAR(20),
@FILTROVENDEDOR AS VARCHAR(16) = NULL,
@FILTROFECHAINI AS VARCHAR(10),
@FILTROFECHAFIN AS VARCHAR(10),
@FILTROCLIENTES AS VARCHAR(MAX) = NULL
AS
	SET NOCOUNT ON
	DECLARE
		@CEDI AS VARCHAR(20),
		@VENDEDOR AS VARCHAR(16) = NULL,
		@CLIENTES AS VARCHAR(MAX) = NULL,
		@FECHAINI AS DATETIME,
		@FECHAFIN AS DATETIME,
		@TipoCobranza AS SMALLINT

	IF NOT COALESCE(@FILTROCEDI,'') = ''
		SET @CEDI = @FILTROCEDI

	IF NOT COALESCE(@FILTROVENDEDOR,'') = ''
		SET @VENDEDOR = @FILTROVENDEDOR

	IF NOT COALESCE(@FILTROCLIENTES,'') = ''
		SET @CLIENTES = @FILTROCLIENTES

	IF NOT COALESCE(@FILTROFECHAINI,'') = ''
		SET @FECHAINI = @FILTROFECHAINI

	IF NOT COALESCE(@FILTROFECHAFIN,'') = ''
		SET @FECHAFIN = @FILTROFECHAFIN

	SET @TipoCobranza = (SELECT TOP 1 TipoCobranza FROM CONHist ORDER BY CONHistFechaInicio DESC)



	If @TipoCobranza = 0
	BEGIN
		SELECT 
			CLI.Clave + ' - ' + CLI.NombreCorto AS [CONCEPTO|GROUPER], CLI.Clave,CLI.NombreCorto,
			(SELECT Descripcion FROM MENDetalle WHERE MENClave = 'XFactura' AND MEDTipoLenguaje = dbo.FNObtenerLenguaje()) as Concepto,
			TRP.Folio, CASE WHEN TRP.Tipo = 1 THEN TRP.FechaSurtido ELSE TRP.FechaFacturacion END AS [FechaAplicacion|FORMAT%d],
			TRP.FechaCobranza AS [FechaVencimiento|FORMAT%d],TRP.Total AS [Cargos|FORMAT&$|SUMMARY], SUM(ISNULL(ABN.Importe, 0)) - SUM(ISNULL(CHQ.AbnChequePosfechado, 0)) AS [Abonos|FORMAT&$|SUMMARY],
			TRP.Total - (SUM(ISNULL(ABN.Importe, 0)) - SUM(ISNULL(CHQ.AbnChequePosfechado, 0))) AS [Saldos|FORMAT&$|SUMMARY]
		FROM TransProd TRP 
			INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave
			INNER JOIN Cliente CLI ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 2
			LEFT JOIN AbnTrp ABN ON ABN.TransProdID = TRP.TransProdID
			LEFT JOIN TRPCheque CHQ ON CHQ.ABNId = ABN.ABNId AND TRP.TransProdID = CHQ.TransProdID
		WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 
			AND ((TRP.TipoFase = 2 AND CONVERT(DATETIME,CONVERT(VARCHAR(20),TRP.FechaSurtido,112)) between @FECHAINI AND @FECHAFIN))
			OR (TRP.TipoFase = 6 AND CONVERT(DATETIME,CONVERT(VARCHAR(20), (SELECT FechaCaptura FROM Dia D WHERE TRP.DiaClave1 = D.DiaClave),112)) BETWEEN @FECHAINI AND @FECHAFIN)))
			OR (TRP.Tipo = 8 AND TRP.TipoFase != 0 AND CONVERT(DATETIME,CONVERT(VARCHAR(20),TRP.FechaFacturacion,112)) BETWEEN @FECHAINI AND @FECHAFIN))
			AND VIS.VendedorID = @VENDEDOR
			AND ((CLI.ClienteClave IN (SELECT Datos FROM [dbo].[FNSplit](@CLIENTES, ','))) OR @CLIENTES IS NULL)
		GROUP BY CLI.Clave,CLI.NombreCorto,TRP.Tipo,TRP.Folio,TRP.FechaSurtido,TRP.FechaFacturacion,TRP.FechaCobranza,TRP.Total
		ORDER BY CLI.Clave, TRP.Folio
	END

	If @TipoCobranza = 1
	BEGIN
		SELECT
			CLI.Clave + ' - ' + CLI.NombreCorto AS [CONCEPTO|GROUPER], CLI.Clave,CLI.NombreCorto,
			(SELECT Descripcion FROM MENDetalle WHERE MENClave = 'XVenta' AND MEDTipoLenguaje = dbo.FNObtenerLenguaje()) AS Concepto,
			TRP.Folio, CASE WHEN TRP.Tipo = 1 THEN TRP.FechaSurtido ELSE TRP.FechaFacturacion END AS [FechaAplicacion|FORMAT%d],
			TRP.FechaCobranza AS [FechaVencimiento|FORMAT%d],TRP.Total AS [Cargos|FORMAT&$|SUMMARY], SUM(ISNULL(ABN.Importe, 0)) - SUM(ISNULL(CHQ.AbnChequePosfechado, 0)) AS [Abonos|FORMAT&$|SUMMARY],
			TRP.Total - (SUM(ISNULL(ABN.Importe, 0)) - SUM(ISNULL(CHQ.AbnChequePosfechado, 0))) AS [Saldos|FORMAT&$|SUMMARY]
		FROM TransProd TRP
			INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave
			INNER JOIN Cliente CLI ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 1
			LEFT JOIN AbnTrp ABN ON ABN.TransProdID = TRP.TransProdID
			LEFT JOIN TRPCheque CHQ ON CHQ.ABNId = ABN.ABNId AND TRP.TransProdID = CHQ.TransProdID
		WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 
			AND ((TRP.TipoFase = 2 AND CONVERT(DATETIME, CONVERT(VARCHAR(20), TRP.FechaSurtido, 112)) BETWEEN @FECHAINI AND @FECHAFIN))
			OR (TRP.TipoFase = 6  and CONVERT(DATETIME,CONVERT(VARCHAR(20), (SELECT FechaCaptura FROM Dia D WHERE TRP.DiaClave1 = D.DiaClave), 112)) BETWEEN @FECHAINI AND @FECHAFIN)))
			OR (TRP.Tipo = 1 AND TRP.TipoFase != 0  and CONVERT(DATETIME,CONVERT(VARCHAR(20),TRP.FechaSurtido,112)) BETWEEN @FECHAINI AND @FECHAFIN))
			AND VIS.VendedorID = @VENDEDOR
			AND ((CLI.ClienteClave IN (SELECT Datos FROM [dbo].[FNSplit](@CLIENTES, ','))) OR @CLIENTES IS NULL)
		GROUP BY CLI.Clave,CLI.NombreCorto,TRP.Tipo,TRP.Folio,TRP.FechaSurtido,TRP.FechaFacturacion,TRP.FechaCobranza,TRP.Total
		ORDER BY CLI.Clave, TRP.Folio
	END

	If @TipoCobranza = 2
	BEGIN
		SELECT 
			CLI.Clave + ' - ' + CLI.NombreCorto AS [CONCEPTO|GROUPER], CLI.Clave,CLI.NombreCorto,
			(SELECT Descripcion FROM MENDetalle WHERE MENClave = 'XFactura' AND MEDTipoLenguaje = dbo.FNObtenerLenguaje()) as Concepto,
			TRP.Folio, CASE WHEN TRP.Tipo = 1 THEN TRP.FechaSurtido ELSE TRP.FechaFacturacion END AS [FechaAplicacion|FORMAT%d],
			TRP.FechaCobranza AS [FechaVencimiento|FORMAT%d],TRP.Total AS [Cargos|FORMAT&$|SUMMARY], SUM(ISNULL(ABN.Importe, 0)) - SUM(ISNULL(CHQ.AbnChequePosfechado, 0)) AS [Abonos|FORMAT&$|SUMMARY],
			TRP.Total - (SUM(ISNULL(ABN.Importe, 0)) - SUM(ISNULL(CHQ.AbnChequePosfechado, 0))) AS [Saldos|FORMAT&$|SUMMARY]
		FROM TransProd TRP 
			INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave
			INNER JOIN Cliente CLI ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 2
			LEFT JOIN AbnTrp ABN ON ABN.TransProdID = TRP.TransProdID
			LEFT JOIN TRPCheque CHQ ON CHQ.ABNId = ABN.ABNId AND TRP.TransProdID = CHQ.TransProdID
		WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 
			AND ((TRP.TipoFase = 2 AND CONVERT(DATETIME,CONVERT(VARCHAR(20),TRP.FechaSurtido,112)) between @FECHAINI AND @FECHAFIN))
			OR (TRP.TipoFase = 6 AND CONVERT(DATETIME,CONVERT(VARCHAR(20), (SELECT FechaCaptura FROM Dia D WHERE TRP.DiaClave1 = D.DiaClave),112)) BETWEEN @FECHAINI AND @FECHAFIN)))
			OR (TRP.Tipo = 8 AND TRP.TipoFase != 0 AND CONVERT(DATETIME,CONVERT(VARCHAR(20),TRP.FechaFacturacion,112)) BETWEEN @FECHAINI AND @FECHAFIN))
			AND VIS.VendedorID = @VENDEDOR
			AND ((CLI.ClienteClave IN (SELECT Datos FROM [dbo].[FNSplit](@CLIENTES, ','))) OR @CLIENTES IS NULL)
		GROUP BY CLI.Clave,CLI.NombreCorto,TRP.Tipo,TRP.Folio,TRP.FechaSurtido,TRP.FechaFacturacion,TRP.FechaCobranza,TRP.Total
		UNION ALL
		SELECT
			CLI.Clave + ' - ' + CLI.NombreCorto AS [CONCEPTO|GROUPER], CLI.Clave,CLI.NombreCorto,
			(SELECT Descripcion FROM MENDetalle WHERE MENClave = 'XVenta' AND MEDTipoLenguaje = dbo.FNObtenerLenguaje()) AS Concepto,
			TRP.Folio, CASE WHEN TRP.Tipo = 1 THEN TRP.FechaSurtido ELSE TRP.FechaFacturacion END AS [FechaAplicacion|FORMAT%d],
			TRP.FechaCobranza AS FechaVencimiento,TRP.Total AS [Cargos|FORMAT&$|SUMMARY], SUM(ISNULL(ABN.Importe, 0)) - SUM(ISNULL(CHQ.AbnChequePosfechado, 0)) AS [Abonos|FORMAT&$|SUMMARY],
			TRP.Total - (SUM(ISNULL(ABN.Importe, 0)) - SUM(ISNULL(CHQ.AbnChequePosfechado, 0))) AS [Saldos|FORMAT&$|SUMMARY]
		FROM TransProd TRP
			INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave
			INNER JOIN Cliente CLI ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 1
			LEFT JOIN AbnTrp ABN ON ABN.TransProdID = TRP.TransProdID
			LEFT JOIN TRPCheque CHQ ON CHQ.ABNId = ABN.ABNId AND TRP.TransProdID = CHQ.TransProdID
		WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 
			AND ((TRP.TipoFase = 2 AND CONVERT(DATETIME, CONVERT(VARCHAR(20), TRP.FechaSurtido, 112)) BETWEEN @FECHAINI AND @FECHAFIN))
			OR (TRP.TipoFase = 6  and CONVERT(DATETIME,CONVERT(VARCHAR(20), (SELECT FechaCaptura FROM Dia D WHERE TRP.DiaClave1 = D.DiaClave), 112)) BETWEEN @FECHAINI AND @FECHAFIN)))
			OR (TRP.Tipo = 1 AND TRP.TipoFase != 0  and CONVERT(DATETIME,CONVERT(VARCHAR(20),TRP.FechaSurtido,112)) BETWEEN @FECHAINI AND @FECHAFIN))
			AND VIS.VendedorID = @VENDEDOR
			AND ((CLI.ClienteClave IN (SELECT Datos FROM [dbo].[FNSplit](@CLIENTES, ','))) OR @CLIENTES IS NULL)
		GROUP BY CLI.Clave,CLI.NombreCorto,TRP.Tipo,TRP.Folio,TRP.FechaSurtido,TRP.FechaFacturacion,TRP.FechaCobranza,TRP.Total
		ORDER BY CLI.Clave, TRP.Folio
	END

	SET NOCOUNT OFF
/*go*/go