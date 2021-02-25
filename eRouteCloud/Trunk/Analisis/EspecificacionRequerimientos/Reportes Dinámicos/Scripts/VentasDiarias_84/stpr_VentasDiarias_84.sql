SET NOCOUNT ON
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND NAME='stpr_VentasDiarias_84')
	DROP PROCEDURE [dbo].[stpr_VentasDiarias_84]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_VentasDiarias_84]
@filterSeller AS VARCHAR(16),
@filterDateIni AS VARCHAR(10)
AS
	SET NOCOUNT ON
	DECLARE
		@SELLER AS VARCHAR(16) = NULL,
		@DATEINI AS DATETIME = NULL

	IF NOT COALESCE(@filterSeller,'') = ''
		SET @SELLER = @filterSeller

	IF NOT COALESCE(@filterDateIni,'') = ''
		SET @DATEINI = @filterDateIni

	IF (@SELLER IS NOT NULL) AND (@DATEINI IS NOT NULL)
	BEGIN
		SELECT DISTINCT
			(SElECT V.NOMBRE FROM Vendedor V (NOLOCK) WHERE V.VendedorID = @SELLER) AS [Vendedor|GROUPER], TRP.Folio AS [Venta], TRP.FechaHoraAlta AS [Fecha|FORMAT%G],
			C.Clave + ' - ' + C.RazonSocial AS [Cliente], TRP.Subtotal AS [Subtotal|FORMAT&n|SUMMARY], ISNULL(SUM(TPP.PromocionImp), 0) AS [Descuento|FORMAT&n|SUMMARY],
			TRP.Total AS [Importe|FORMAT&n|SUMMARY], VAV1.Descripcion AS [Forma de Pago], VAV2.Descripcion AS [Forma de Venta]
		FROM [DBO].[TransProd] TRP (NOLOCK)
			INNER JOIN [DBO].[Visita] VIS (NOLOCK) ON ISNULL(TRP.VisitaClave1, TRP.VisitaClave) = VIS.VisitaClave AND ISNULL(TRP.DiaClave1, TRP.DiaClave) = VIS.DiaClave
			INNER JOIN [DBO].[TransProdDetalle] TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
			INNER JOIN [DBO].[Cliente] C (NOLOCK) ON VIS.ClienteClave = C.ClienteClave
			INNER JOIN [DBO].[VAVDescripcion] VAV1 (NOLOCK) ON TRP.ClientePagoID = VAV1.VAVCLAVE AND VAV1.VARCodigo = 'PAGO' AND VAV1.VADTipoLenguaje = [DBO].[FNObtenerLenguaje]()
			INNER JOIN [DBO].[VAVDescripcion] VAV2 (NOLOCK) ON TRP.CFVTipo = VAV2.VAVClave AND VAV2.VARCodigo = 'FVENTA' AND VAV2.VADTipoLenguaje = [DBO].[FNObtenerLenguaje]()
			LEFT JOIN [DBO].[TrpPrp] TPP (NOLOCK) ON TPD.TransProdID = TPP.TransProdID AND TPD.TransProdDetalleID = TPP.TransProdDetalleID
		WHERE TRP.Tipo = 1 AND TRP.TipoFase <> 0
			AND TRP.FechaCaptura = @DATEINI AND VIS.VendedorID = @SELLER
		GROUP BY TRP.Folio, TRP.FechaHoraAlta, C.Clave + ' - ' + C.RazonSocial, TRP.Subtotal, TRP.Total, VAV1.Descripcion, VAV2.Descripcion
	END

	SET NOCOUNT OFF
/*go*/go