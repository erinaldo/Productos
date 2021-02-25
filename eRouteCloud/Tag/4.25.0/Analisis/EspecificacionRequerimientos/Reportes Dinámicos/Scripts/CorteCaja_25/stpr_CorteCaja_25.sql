/* Reporte Dinamico Corte De Caja */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_CorteCaja_25]
	@filterStartDate = '2020-01-01',
	@filterEndDate = '2020-01-15'
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_CorteCaja_25]'))
	DROP PROCEDURE [dbo].[stpr_CorteCaja_25]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_CorteCaja_25]
	@filterStartDate AS varchar(10) = NULL,
	@filterEndDate AS varchar(10) = NULL
AS
	SET ANSI_WARNINGS OFF
	SET NOCOUNT ON
	DECLARE @TipoCobranza AS int, @IVA AS int, @sql AS nvarchar(MAX) = '', @sqlTotales AS nvarchar(MAX) = '', @sqlNC AS nvarchar(MAX) = '', @parameters AS nvarchar(MAX)
	SET @TipoCobranza = (SELECT TOP 1 TipoCobranza FROM CONHist (NOLOCK) ORDER BY CONHistFechaInicio DESC)
	SET @IVA= (SELECT TOP 1 IVG.Valor FROM Impuesto AS I INNER JOIN ImpuestoVig AS IVG (NOLOCK) ON I.ImpuestoClave = IVG.ImpuestoClave WHERE I.Abreviatura = 'IVA' AND I.TipoEstado = 1 AND IVG.Valor != 0)
	SET @parameters = '@parameterIVA AS int, @parameterStartDate AS nvarchar(10), @parameterEndDate AS nvarchar(10)'
	/* Facturas o Ambas */
	IF ((@TipoCobranza = 0 OR @TipoCobranza = 2) AND @IVA <> 0)
		BEGIN
			SET @sql = @sql + '
				SELECT 
					CLI.Clave AS [Cliente],
					(SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VADTipoLenguaje = dbo.FNObtenerLenguaje() AND VARCodigo = ''PAGO'' AND VAVClave = ADT.TipoPago) AS [Concepto],
					A.FechaAbono AS [Fecha Abono|FORMAT%dd/MM/yyyy],
					A.Folio AS [Folio Abono],
					TRP.Folio AS [Folio Documento],
					ISNULL(ADT.Referencia, '''') AS [Referencia],
					ADT.Importe AS [Abono|FORMAT&$|SUMMARY],
					ADT.Importe / (1 + (@parameterIVA * 0.01)) AS [Subtotal|FORMAT&$|SUMMARY],
					ADT.Importe - (ADT.Importe / (1 + (@parameterIVA * 0.01))) AS [IVA|FORMAT&$|SUMMARY],
					TRP.FechaFacturacion AS [Fecha Documento|FORMAT%dd/MM/yyyy] 
				FROM TransProd AS TRP (NOLOCK) 
					INNER JOIN Visita AS VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave 
					INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave OR D.DiaClave = TRP.DiaClave1 
					INNER JOIN Cliente AS CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 2 
					INNER JOIN AbnTrp AS ABN (NOLOCK) ON ABN.TransProdID = TRP.TransProdID 
					INNER JOIN ABNDetalle AS ADT (NOLOCK) ON ADT.ABNId = ABN.ABNId 
					INNER JOIN Abono AS A (NOLOCK) ON ABN.ABNId = A.ABNId and A.DiaClave = D.DiaClave 
				WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 AND ((TRP.TipoFase = 2)) OR (TRP.TipoFase = 6))) OR (TRP.Tipo = 8 AND TRP.TipoFase != 0)) AND TRP.CFVTipo = 2 
					AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @parameterStartDate AND @parameterEndDate '
			IF (@TipoCobranza = 0)
				BEGIN 
					SET @sql = @sql + 'ORDER BY CLI.Clave '
				END
			ELSE
				BEGIN 
					SET @sql = @sql + 'UNION ALL '
				END

			IF (@TipoCobranza = 2)
				BEGIN 
					SET @sqlTotales = @sqlTotales + 'SELECT [Concepto|TABLE_TITLE:Abonos] AS [Concepto|TABLE_TITLE:Abonos], SUM([Total|FORMAT&$|SUMMARY]) AS [Total|FORMAT&$|SUMMARY] FROM ('
					SET @sqlNC = @sqlNC + 'SELECT Concepto AS [Concepto], SUM([Total|FORMAT&$]) AS [Total|FORMAT&$] FROM ('
				END
		
			SET @sqlTotales = @sqlTotales + '
				SELECT
					(SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VADTipoLenguaje = dbo.FNObtenerLenguaje() AND VARCodigo = ''PAGO'' AND VAVClave = ADT.TipoPago) AS [Concepto|TABLE_TITLE:Abonos],
					SUM(ADT.Importe) AS [Total|FORMAT&$|SUMMARY]
				FROM TransProd AS TRP (NOLOCK) 
					INNER JOIN Visita AS VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave 
					INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave OR D.DiaClave = TRP.DiaClave1 
					INNER JOIN Cliente AS CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 2 
					INNER JOIN AbnTrp AS ABN (NOLOCK) ON ABN.TransProdID = TRP.TransProdID 
					INNER JOIN ABNDetalle AS ADT (NOLOCK) ON ADT.ABNId = ABN.ABNId AND ADT.TipoPago != 5 
					INNER JOIN Abono AS A (NOLOCK) ON ABN.ABNId = A.ABNId AND A.DiaClave = D.DiaClave 
				WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 AND ((TRP.TipoFase = 2)) OR (TRP.TipoFase = 6))) OR (TRP.Tipo = 8 AND TRP.TipoFase != 0)) AND TRP.CFVTipo = 2 
					AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @parameterStartDate AND @parameterEndDate 
				GROUP BY ADT.TipoPago '

			SET @sqlNC = @sqlNC + '
				SELECT
					(SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VADTipoLenguaje = dbo.FNObtenerLenguaje() AND VARCodigo = ''PAGO'' AND VAVClave = ADT.TipoPago) AS [Concepto],
					SUM(ADT.Importe) AS [Total|FORMAT&$]
				FROM TransProd AS TRP (NOLOCK) 
					INNER JOIN Visita AS VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave 
					INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave OR D.DiaClave = TRP.DiaClave1 
					INNER JOIN Cliente AS CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 2 
					INNER JOIN AbnTrp AS ABN (NOLOCK) ON ABN.TransProdID = TRP.TransProdID 
					INNER JOIN ABNDetalle AS ADT (NOLOCK) ON ADT.ABNId = ABN.ABNId AND ADT.TipoPago = 5 
					INNER JOIN Abono AS A (NOLOCK) ON ABN.ABNId = A.ABNId AND A.DiaClave = D.DiaClave 
				WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 AND ((TRP.TipoFase = 2)) OR (TRP.TipoFase = 6))) OR (TRP.Tipo = 8 AND TRP.TipoFase != 0)) AND TRP.CFVTipo = 2 
					AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @parameterStartDate AND @parameterEndDate 
				GROUP BY ADT.TipoPago '

			IF (@TipoCobranza = 2)
				BEGIN 
					SET @sqlTotales = @sqlTotales + 'UNION ALL '
					SET @sqlNC = @sqlNC + 'UNION ALL '
				END
		END

	/* Ventas */
	IF ((@TipoCobranza = 0 OR @TipoCobranza = 2) AND @IVA <> 0)
		BEGIN
			SET @sql = @sql + '
				SELECT 
					CLI.Clave AS [Cliente],
					(SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VADTipoLenguaje = dbo.FNObtenerLenguaje() AND VARCodigo = ''PAGO'' AND VAVClave = ADT.TipoPago) AS [Concepto],
					A.FechaAbono AS [Fecha Abono|FORMAT%dd/MM/yyyy],
					A.Folio AS [Folio Abono],
					TRP.Folio AS [Folio Documento],
					ISNULL(ADT.Referencia, '''') AS [Referencia],
					ADT.Importe AS [Abono|FORMAT&$|SUMMARY],
					ADT.Importe / (1 + (@parameterIVA * 0.01)) AS [Subtotal|FORMAT&$|SUMMARY],
					ADT.Importe - (ADT.Importe / (1 + (@parameterIVA * 0.01))) AS [IVA|FORMAT&$|SUMMARY],
					TRP.FechaSurtido AS [Fecha Documento|FORMAT%dd/MM/yyyy] 
				FROM TransProd AS TRP (NOLOCK) 
					INNER JOIN Visita AS VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave 
					INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave OR D.DiaClave = TRP.DiaClave1 
					INNER JOIN Cliente AS CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 1 
					INNER JOIN AbnTrp AS ABN (NOLOCK) ON ABN.TransProdID = TRP.TransProdID 
					INNER JOIN ABNDetalle AS ADT (NOLOCK) ON ADT.ABNId = ABN.ABNId 
					INNER JOIN Abono AS A (NOLOCK) ON ABN.ABNId = A.ABNId AND A.DiaClave = D.DiaClave 
				WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 AND ((TRP.TipoFase = 2)) OR (TRP.TipoFase = 6))) OR (TRP.Tipo = 1 AND TRP.TipoFase IN (2,3))) AND TRP.CFVTipo = 1
					AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @parameterStartDate AND @parameterEndDate 
				ORDER BY CLI.Clave'

			SET @sqlTotales = @sqlTotales + '
				SELECT 
					(SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VADTipoLenguaje = dbo.FNObtenerLenguaje() AND VARCodigo = ''PAGO'' AND VAVClave = ADT.TipoPago) AS [Concepto|TABLE_TITLE:Abonos],
					SUM(ADT.Importe) AS [Total|FORMAT&$|SUMMARY]
				FROM TransProd AS TRP (NOLOCK) 
					INNER JOIN Visita AS VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave 
					INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave OR D.DiaClave = TRP.DiaClave1 
					INNER JOIN Cliente AS CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 1 
					INNER JOIN AbnTrp AS ABN (NOLOCK) ON ABN.TransProdID = TRP.TransProdID 
					INNER JOIN ABNDetalle AS ADT (NOLOCK) ON ADT.ABNId = ABN.ABNId AND ADT.TipoPago != 5 
					INNER JOIN Abono AS A (NOLOCK) ON ABN.ABNId = A.ABNId AND A.DiaClave = D.DiaClave 
				WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 AND ((TRP.TipoFase = 2)) OR (TRP.TipoFase = 6))) OR (TRP.Tipo = 1 AND TRP.TipoFase IN (2,3))) AND TRP.CFVTipo = 1 
					AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @parameterStartDate AND @parameterEndDate 
				GROUP BY ADT.TipoPago '

			SET @sqlNC = @sqlNC + '
				SELECT 
					(SELECT Descripcion FROM VAVDescripcion (NOLOCK) WHERE VADTipoLenguaje = dbo.FNObtenerLenguaje() AND VARCodigo = ''PAGO'' AND VAVClave = ADT.TipoPago) AS [Concepto],
					SUM(ADT.Importe) AS [Total|FORMAT&$]
				FROM TransProd TRP 
					INNER JOIN Visita AS VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave OR TRP.VisitaClave1 = VIS.VisitaClave 
					INNER JOIN Dia AS D (NOLOCK) ON TRP.DiaClave = D.DiaClave OR D.DiaClave = TRP.DiaClave1 
					INNER JOIN Cliente AS CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave AND CLI.TipoFiscal = 1 
					INNER JOIN AbnTrp AS ABN (NOLOCK) ON ABN.TransProdID = TRP.TransProdID 
					INNER JOIN ABNDetalle AS ADT (NOLOCK) ON ADT.ABNId = ABN.ABNId AND ADT.TipoPago = 5 
					INNER JOIN Abono AS A (NOLOCK) ON ABN.ABNId = A.ABNId and A.DiaClave = D.DiaClave 
				WHERE (((TRP.Tipo = 24 AND TRP.TipoFase != 0 AND ((TRP.TipoFase = 2)) OR (TRP.TipoFase = 6))) OR (TRP.Tipo = 1 AND TRP.TipoFase IN (2,3))) AND TRP.CFVTipo = 1 
					AND CONVERT(date, D.FechaCaptura, 112) BETWEEN @parameterStartDate AND @parameterEndDate 
				GROUP BY ADT.TipoPago '

			IF (@TipoCobranza = 2)
				BEGIN 
					SET @sqlTotales = @sqlTotales + ') AS t GROUP BY [Concepto|TABLE_TITLE:Abonos] ORDER BY [Concepto|TABLE_TITLE:Abonos]'
					SET @sqlNC = @sqlNC + ') AS t GROUP BY Concepto ORDER BY Concepto'
				END
		END

	EXEC sp_executesql @sql, @parameters, @parameterIVA = @IVA, @parameterStartDate = @filterStartDate, @parameterEndDate = @filterEndDate
	EXEC sp_executesql @sqlTotales, @parameters, @parameterIVA = @IVA, @parameterStartDate = @filterStartDate, @parameterEndDate = @filterEndDate
	EXEC sp_executesql @sqlNC, @parameters, @parameterIVA = @IVA, @parameterStartDate = @filterStartDate, @parameterEndDate = @filterEndDate
	SET NOCOUNT OFF
/*go*/go