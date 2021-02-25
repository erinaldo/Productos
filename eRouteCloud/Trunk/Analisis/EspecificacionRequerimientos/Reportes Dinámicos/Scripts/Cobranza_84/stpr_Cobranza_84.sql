SET NOCOUNT ON
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND NAME='stpr_Cobranza_84')
	DROP PROCEDURE [dbo].[stpr_Cobranza_84]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_Cobranza_84]
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
		SELECT
			ABN.Folio AS [Folio Cobranza], TRP.Folio AS [Venta], TRP.FechaCaptura AS [Fecha|FORMAT%G], C.Clave + ' - ' + C.RazonSocial AS [Cliente],
			ABT.Importe AS [Importe|FORMAT&n|SUMMARY], ABT.FechaHora AS [Fecha Pago|FORMAT%G], VAD.Descripcion AS [Forma de Pago]
		FROM [DBO].[TransProd] TRP (NOLOCK)
			INNER JOIN [DBO].[AbnTrp] ABT (NOLOCK) ON TRP.TransProdID = ABT.TransProdID
			INNER JOIN [DBO].[Abono] ABN (NOLOCK) ON ABT.ABNId = ABN.ABNId
			INNER JOIN [DBO].[ABNDetalle] ABD (NOLOCK) ON ABN.ABNId = ABD.ABNId
			INNER JOIN [DBO].[VAVDescripcion] VAD (NOLOCK) ON ABD.TipoPago = VAD.VAVClave AND VAD.VARCodigo = 'PAGO' AND VAD.VADTipoLenguaje = [dbo].[FNObtenerLenguaje]()
			INNER JOIN [DBO].[Visita] VIS (NOLOCK) ON ISNULL(ABT.VisitaClave, ABN.VisitaClave) = VIS.VisitaClave AND ISNULL(ABT.DiaClave, ABN.DiaClave) = VIS.DiaClave
			INNER JOIN [DBO].[Cliente] C (NOLOCK) ON VIS.ClienteClave = C.ClienteClave
		WHERE TRP.FechaCaptura = @DATEINI AND VIS.VendedorID = @SELLER
		ORDER BY ABN.Folio
	END

	SET NOCOUNT OFF
/*go*/go