/* Reporte Dinamico Facturacion */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_Facturacion_74]
	@filterSeller = '3SRIOQP2YV6F7BM',
	@filterCustomer = NULL,
	@filterStartDate = '2020-01-01',
	@filterEndDate = '2020-01-15'
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_Facturacion_74]'))
	DROP PROCEDURE [dbo].[stpr_Facturacion_74]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_Facturacion_74]
	@filterSeller AS varchar(16) = NULL,
	@filterCustomer AS varchar(16) = NULL,
	@filterStartDate AS varchar(10) = NULL,
	@filterEndDate AS varchar(10) = NULL
AS
	IF @filterCustomer IS NULL OR @filterCustomer = ' ' OR @filterCustomer = '' OR @filterCustomer = 'null'
		SET @filterCustomer = NULL

	SET ANSI_WARNINGS OFF
	SET NOCOUNT ON
	SELECT
		TRPDF.FechaTimbrado AS [Fecha Facturación|FORMAT%dd/MM/yyyy],
		ISNULL(V.MCNClave + ' - ', '') + V.Nombre AS [Vendedor],
		C.Clave AS [Clave Cliente],
		TRPDF.RazonSocial [Razon Social],
		C.IdFiscal AS [RFC],
		TP.Folio AS [Folio Factura],
		TRPDF.NumCertificado AS [Serie Factura],
		[dbo].[FNObtenerValorReferencia]('TRPFASE', TP.TipoFase) AS [Fase],
		TRPDF.UUID,
		TP.Total AS [Total|FORMAT&$],
		TP.Saldo AS [Saldo|FORMAT&$],
		(
			SELECT TOP 1 AB.FechaCreacion FROM AbnTrp AS ABT (NOLOCK)
				INNER JOIN Abono AS AB (NOLOCK) ON ABT.ABNId = AB.ABNId
			WHERE ABT.TransProdID = TP.TransProdID ORDER BY AB.FechaCreacion DESC
		) AS [Fecha Ultimo Abono|FORMAT%dd/MM/yyyy],
		CASE WHEN TP.ClientePagoID IS NULL OR TP.ClientePagoID = '' THEN '' ELSE [dbo].[FNObtenerValorReferencia]('PAGO', TP.ClientePagoID) END AS [Forma de Pago]
	FROM TRPDatoFiscal AS TRPDF (NOLOCK)
		INNER JOIN TransProd AS TP (NOLOCK) ON TP.TransProdID = TRPDF.TransProdID
		INNER JOIN Dia AS D (NOLOCK) ON TP.DiaClave = D.DiaClave
		INNER JOIN Visita AS VIS (NOLOCK) ON VIS.VisitaClave = TP.VisitaClave AND VIS.DiaClave = TP.DiaClave
		INNER JOIN VENCentroDistHist AS VCDH (NOLOCK) ON VCDH.VendedorId = VIS.VendedorID AND D.FechaCaptura BETWEEN VCDH.VCHFechaInicial AND VCDH.FechaFinal
		INNER JOIN Almacen AS A (NOLOCK) ON VCDH.AlmacenId = A.AlmacenID
		INNER JOIN Vendedor AS V(NOLOCK) ON V.VendedorID = VIS.VendedorID
		INNER JOIN Cliente AS C (NOLOCK) ON C.ClienteClave = VIS.ClienteClave
	WHERE TP.Tipo = 8 AND TP.TipoFase IN (0,1)
		AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @filterStartDate AND @filterEndDate
		AND V.VendedorID = @filterSeller
		AND (C.ClienteClave = (SELECT Datos FROM FNSplit(@filterCustomer, ',')) OR @filterCustomer IS NULL)
	SET NOCOUNT OFF
/*go*/go