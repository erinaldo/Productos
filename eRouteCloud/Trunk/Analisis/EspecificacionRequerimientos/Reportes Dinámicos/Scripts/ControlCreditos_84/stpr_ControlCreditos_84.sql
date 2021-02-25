/* Reporte Dinamico de Control Creditos */

/*Caso de ejemplo de ejecucion del SP

EXEC [dbo].[stpr_ControlCreditos_84]
	@filterRoute = NULL,
	@filterClient = NULL,
	@filterStartDate = NULL,
	@filterEndDate = NULL

*/

SET ANSI_WARNINGS OFF
SET NOCOUNT ON
IF OBJECT_ID(N'[dbo].[stpr_ControlCreditos_84]', 'procedure') IS NOT NULL
	DROP PROCEDURE [dbo].[stpr_ControlCreditos_84]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_ControlCreditos_84]
	@filterRoute AS varchar(MAX) = NULL,
	@filterClient AS varchar(MAX) = NULL,
	@filterStartDate AS varchar(10) = NULL,
	@filterEndDate AS varchar(10) = NULL
AS
	SET ANSI_WARNINGS OFF
	SET NOCOUNT ON
	IF @filterRoute IS NULL OR @filterRoute = ' ' OR @filterRoute = '' OR @filterRoute = 'null'
		SET @filterRoute = NULL

	IF @filterClient IS NULL OR @filterClient = ' ' OR @filterClient = '' OR @filterClient = 'null'
		SET @filterClient = NULL

	SELECT
		C.Clave AS [Cliente],
		C.NombreContacto AS [Nombre],
		C.RazonSocial AS [Razon Social],
		CFV.DiasCredito AS [Dias de Crédito],
		CFV.LimiteCredito AS [Limite de Crédito|FORMAT&$],
		TP.Folio AS [Folio de Venta],
		TP.FechaCaptura AS [Fecha Creación|FORMAT%dd/MM/yyyy],
		TP.FechaCobranza AS [Fecha Vencimiento|FORMAT%dd/MM/yyyy],
		DATEDIFF(DAY, TP.FechaCobranza, GETDATE()) AS [Dias Retraso|FORMAT&n0],
		TP.Total AS [Total|FORMAT&$],
		MAX(AT.FechaHora) AS [Fecha Ult Abono|FORMAT%dd/MM/yyyy],
		SUM(ISNULL(AT.Importe, 0)) AS [Abonos|FORMAT&$],
		TP.Saldo AS [Saldo|FORMAT&$],
		CASE
			WHEN TP.FechaCobranza > GETDATE() THEN 'Vigente'
			WHEN TP.FechaCobranza = GETDATE() THEN 'Por Vencer' 
			WHEN TP.FechaCobranza < GETDATE() THEN 'Vencido' 
		END AS [Estatus] 
	FROM TransProd AS TP (NOLOCK)
		INNER JOIN Visita AS V (NOLOCK) ON TP.VisitaClave = V.VisitaClave AND TP.DiaClave = V.DiaClave
		INNER JOIN Dia AS D (NOLOCK) ON V.DiaClave = D.DiaClave
		INNER JOIN Cliente AS C (NOLOCK) ON V.ClienteClave = C.ClienteClave
		INNER JOIN Ruta AS R (NOLOCK) ON V.RUTClave = R.RUTClave
		INNER JOIN CLIFormaVenta AS CFV (NOLOCK) ON c.ClienteClave = CFV.ClienteClave AND CFV.CFVTipo = 2
		LEFT JOIN AbnTrp AS AT (NOLOCK) ON TP.TransProdID = AT.TransProdID
	WHERE TP.Tipo = 1 AND TP.TipoFase IN (2, 3) AND TP.Saldo > 0
		AND ((CAST(D.FechaCaptura AS date) BETWEEN @filterStartDate AND @filterEndDate) OR @filterStartDate IS NULL)
		AND ((R.RUTClave IN (SELECT Datos FROM FNSplit(@filterRoute, ','))) OR @filterRoute IS NULL)
		AND ((C.ClienteClave IN (SELECT Datos FROM FNSplit(@filterClient, ','))) OR @filterClient IS NULL)
	GROUP BY TP.TransProdID, C.Clave, C.NombreContacto, C.RazonSocial, CFV.DiasCredito, CFV.LimiteCredito, TP.Folio, TP.FechaCaptura, TP.FechaCobranza, TP.Total, TP.Saldo
	ORDER BY C.Clave, C.NombreContacto, C.RazonSocial, CFV.DiasCredito, CFV.LimiteCredito, TP.Folio, TP.FechaCaptura, TP.FechaCobranza, TP.Total, TP.Saldo
	SET NOCOUNT OFF
/*go*/go