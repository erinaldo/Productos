/* Reporte Dinamico Ventas Con Saldo */

/* Caso de ejemplo de ejecucion del SP
EXEC [dbo].[stpr_VentasConSaldo_83]
	@filterCEDIS = 'ALMCEDI',
	@filterStartDate = '2020-08-03',
	@filterSellers = 'RUT01',
	@filterCustomerScheme = NULL,
	@filterCustomers = NULL
*/

SET NOCOUNT ON
IF EXISTS (SELECT TOP 1 [object_id] FROM [sys].[objects] WHERE [object_id] = OBJECT_ID(N'[dbo].[stpr_VentasConSaldo_83]'))
	DROP PROCEDURE [dbo].[stpr_VentasConSaldo_83]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[stpr_VentasConSaldo_83]
	@filterCEDIS AS varchar(16) = NULL,
	@filterStartDate AS varchar(10) = NULL,
	@filterSellers AS varchar(16) = NULL,
	@filterCustomerScheme AS varchar(16) = NULL,
	@filterCustomers AS varchar(MAX) = NULL
AS
	SET ANSI_WARNINGS OFF
	SET NOCOUNT ON

	IF @filterCustomers IS NULL OR @filterCustomers = ' ' OR @filterCustomers = '' OR @filterCustomers = 'null'
		SET @filterCustomers = NULL

	SELECT
		VEN.Nombre AS [Vendedor|GROUPER],
		CLI.Clave + ' - ' + CLI.RazonSocial AS [Cliente|GROUPER],
		TRP.Notas AS [Facturas],
		TRP.Folio AS [Folio],
		D.FechaCaptura AS [Fecha|FORMAT%dd/MM/yyyy],
		CLI.Clave AS [Clave],
		CLI.RazonSocial AS [Cliente],
		TRP.Total AS [Importe|SUMMARY|FORMAT&$],
		ISNULL((TRP.Total - (SELECT SUM(AbnTrp.Importe) FROM Abono (NOLOCK) INNER JOIN AbnTrp (NOLOCK) ON Abono.ABNId = AbnTrp.ABNId AND AbnTrp.TransProdID = TRP.TransProdID)), TRP.Total) AS [Saldo|SUMMARY|FORMAT&$]
	FROM TransProd AS TRP (NOLOCK)
		INNER JOIN Dia AS D (NOLOCK) ON D.DiaClave = ISNULL(TRP.DiaClave1, TRP.DiaClave)
		INNER JOIN Visita AS VIS (NOLOCK) ON VIS.VisitaClave = ISNULL(TRP.VisitaClave1, TRP.VisitaClave) AND VIS.DiaClave = ISNULL(TRP.DiaClave1, TRP.DiaClave)
		INNER JOIN Cliente AS CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave
		INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID
		INNER JOIN VENCentroDistHist AS VEH (NOLOCK) ON  VEH.VendedorId = VEN.VendedorID AND D.FechaCaptura <= VEH.FechaFinal AND D.FechaCaptura >= VEH.VCHFechaInicial
		INNER JOIN Almacen AS ALM (NOLOCK) ON ALM.AlmacenID = VEH.AlmacenId
	WHERE TRP.Tipo = 1 AND TRP.TipoFase <> 0 AND Saldo > 0
		AND VEN.VendedorID = @filterSellers
		AND CONVERT(date, D.FechaCaptura, 112) <= @filterStartDate
		AND ALM.AlmacenID = @filterCEDIS
		AND (CLI.ClienteClave = (SELECT Datos FROM FNSplit(@filterCustomers, ',')) OR @filterCustomers IS NULL)
	ORDER BY VEN.Nombre, CLI.Clave + ' - ' + CLI.RazonSocial
	SET NOCOUNT OFF
/*go*/go