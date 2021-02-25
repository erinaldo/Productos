SET NOCOUNT ON
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE='P' AND NAME='sptr_Promociones_41')
	DROP PROCEDURE [dbo].[sptr_Promociones_41]
SET NOCOUNT OFF
/*go*/go

CREATE PROCEDURE [dbo].[sptr_Promociones_41]
@filterCedi AS VARCHAR(20),
@filterDateIni AS VARCHAR(10),
@filterDateEnd AS VARCHAR(10)
AS
	SET NOCOUNT ON
	DECLARE
		@CEDI AS VARCHAR(20),
		@DATEINI AS DATETIME,
		@DATEEND AS DATETIME

	IF NOT COALESCE(@filterCedi,'') = ''
		SET @CEDI = @filterCedi

	IF NOT COALESCE(@filterDateIni,'') = ''
		SET @DATEINI = @filterDateIni

	IF NOT COALESCE(@filterDateEnd,'') = ''
		SET @DATEEND = @filterDateEnd

	SELECT
		PRODUCTOS.Grupo AS [Categoria|GROUPER], PRODUCTOS.ClienteClave AS Id, CLI.RazonSocial AS Cliente, E.Nombre AS [Tipo Producto], PRM.Nombre AS Concepto, SUM(PRODUCTOS.Total) AS [Total|FORMAT&$|SUMMARY]
	FROM (
		SELECT 'Bonificaciones' AS Grupo, VIS.ClienteClave, SUM(TPP.PromocionImp) AS Total, TPP.PromocionClave, PE.EsquemaID
		FROM TransProd TRP (NOLOCK)
			INNER JOIN Visita VIS (NOLOCK) ON ISNULL(TRP.VisitaClave1, TRP.VisitaClave) = VIS.VisitaClave AND ISNULL(TRP.DiaClave1, TRP.DiaClave) = VIS.DiaClave
			INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave
			INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID
			INNER JOIN TrpPrp TPP (NOLOCK) ON TPD.TransProdID = TPP.TransProdID AND TPD.TransProdDetalleID = TPP.TransProdDetalleID
			INNER JOIN ProductoEsquema PE (NOLOCK) ON TPD.ProductoClave = PE.ProductoClave
			INNER JOIN Ruta R (NOLOCK) ON VIS.RUTClave = R.RUTClave
			INNER JOIN Almacen ALM (NOLOCK) ON R.AlmacenID = ALM.AlmacenID
		WHERE ALM.AlmacenID = @CEDI AND TPD.Promocion = 1 AND TPP.PromocionClave LIKE 'B%' AND D.FechaCaptura BETWEEN @DATEINI AND @DATEEND
		GROUP BY VIS.ClienteClave, TPP.PromocionClave, PE.EsquemaID
			UNION
		SELECT 'Promociones' AS Grupo, VIS.ClienteClave, SUM(TPP.PromocionImp) AS Total, TPP.PromocionClave, PE.EsquemaID
		FROM TransProd TRP (NOLOCK)
			INNER JOIN Visita VIS (NOLOCK) ON ISNULL(TRP.VisitaClave1, TRP.VisitaClave) = VIS.VisitaClave AND ISNULL(TRP.DiaClave1, TRP.DiaClave) = VIS.DiaClave
			INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave
			INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRp.TransProdID = TPD.TransProdID
			INNER JOIN TrpPrp TPP (NOLOCK) ON TPD.TransProdID = TPP.TransProdID AND TPD.TransProdDetalleID = TPP.TransProdDetalleID
			INNER JOIN Promocion P (NOLOCK) ON TPP.PromocionClave = P.PromocionClave
			INNER JOIN ProductoEsquema PE (NOLOCK) ON TPD.ProductoClave = PE.ProductoClave
			INNER JOIN Ruta R (NOLOCK) ON VIS.RUTClave = R.RUTClave
			INNER JOIN Almacen ALM (NOLOCK) ON R.AlmacenID = ALM.AlmacenID
		WHERE ALM.AlmacenID = @CEDI AND TPD.Promocion = 1 AND TPP.PromocionClave NOT LIKE 'B%' AND P.TipoAplicacion <> 4
			AND D.FechaCaptura BETWEEN @DATEINI AND @DATEEND
		GROUP BY VIS.ClienteClave, TPP.PromocionClave, PE.EsquemaID
			UNION
		SELECT 'Obsequios' AS Grupo, VIS.ClienteClave, SUM(PPV.Precio * TPD.Cantidad) AS Total, TPD.PromocionClave, PE.EsquemaID
		FROM TransProd TRP (NOLOCK)
			INNER JOIN Visita VIS (NOLOCK) ON ISNULL(TRP.VisitaClave1, TRP.VisitaClave) = VIS.VisitaClave AND ISNULL(TRP.DiaClave1, TRP.DiaClave) = VIS.DiaClave
			INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave
			INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRp.TransProdID = TPD.TransProdID
			INNER JOIN Vendedor V (NOLOCK) ON VIS.VendedorID = V.VendedorID
			INNER JOIN PrecioProductoVig PPV (NOLOCK) ON TPD.ProductoClave = PPV.ProductoClave AND V.ListaPrecioBase = PPV.PrecioClave
			INNER JOIN ProductoEsquema PE (NOLOCK) ON TPD.ProductoClave = PE.ProductoClave
			INNER JOIN Ruta R (NOLOCK) ON VIS.RUTClave = R.RUTClave
			INNER JOIN Almacen ALM (NOLOCK) ON R.AlmacenID = ALM.AlmacenID
		WHERE ALM.AlmacenID = @CEDI AND TPD.Promocion = 2 AND PPV.FechaFin >= GETDATE() AND D.FechaCaptura BETWEEN @DATEINI AND @DATEEND
		GROUP BY VIS.ClienteClave, TPD.PromocionClave, PE.EsquemaID
	) PRODUCTOS
		INNER JOIN Cliente CLI (NOLOCK) ON PRODUCTOS.ClienteClave = CLi.ClienteClave
		INNER JOIN Esquema E (NOLOCK) ON PRODUCTOS.EsquemaID = E.EsquemaID
		INNER JOIN Promocion PRM (NOLOCK) ON PRODUCTOS.PromocionClave = PRM.PromocionClave
	GROUP BY PRODUCTOS.Grupo, PRODUCTOS.ClienteClave, CLI.RazonSocial, E.Nombre, PRM.Nombre

	SET NOCOUNT OFF
/*go*/go