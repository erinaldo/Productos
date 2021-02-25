/* Reporte Dinamico Gastos Del Vendedor */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_GastosVendedor_0]
	@filterCEDIS = 'ALMCEDI',
	@filterStartDate = '2020-01-01',
	@filterEndDate = '2021-01-01',
	@filterSellers = 'RUT02'
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_GastosVendedor_0]'))
	DROP PROCEDURE [dbo].[stpr_GastosVendedor_0]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_GastosVendedor_0]
	@filterCEDIS AS varchar(16) = NULL,
	@filterStartDate AS varchar(10) = NULL,
	@filterEndDate AS varchar(10) = NULL,
	@filterSellers AS varchar(16) = NULL
AS
	SET ANSI_WARNINGS OFF
	SET NOCOUNT ON
	SELECT DISTINCT
		ALN.Clave + ' ' + ALN.Nombre AS [Centro De Distribucion|GROUPPER],
		VEN.Nombre AS [Vendedor|GROUPPER],
		GAS.Fecha AS [Fecha|GROUPPER|FORMAT%dd/MM/yyyy],
		GAS.Folio AS [Folio],
		VAD.Descripcion AS [Concepto],
		GAS.Importe AS [Subtotal],
		GAS.Porcentaje AS [% Impuesto],
		GAS.Impuesto AS [Impuesto],
		GAS.Total AS [Total|SUMMARY],
		GAS.Comentario AS [Comentario]
	FROM Gasto AS GAS (NOLOCK)
		INNER JOIN VAVDescripcion AS VAD (NOLOCK) ON VAD.VARcodigo = 'GASTIPO' AND VAD.VAVclave = GAS.TipoConcepto AND VAD.VADTipoLenguaje = 'EM'
		INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.VendedorID = GAS.VendedorID
		INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK)) AGV ON GAS.DiaClave = AGV.DiaClave AND GAS.VendedorID = AGV.VendedorId
		INNER JOIN Almacen AS ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave
	WHERE VEN.VendedorId = @filterSellers
		AND CONVERT(date, GAS.Fecha, 112) BETWEEN @filterStartDate AND @filterEndDate
		AND ALN.AlmacenID = @filterCEDIS
	SET NOCOUNT OFF
/*go*/go