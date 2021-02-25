using DevExpress.XtraReports.UI;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class MLiquidacionPDR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);


        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string DateStatus, string CEDIS, string Vendedores, string FechaInicial)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();
                DateTime dFechaIni;
                DateTime.TryParse(FechaInicial, out dFechaIni);
                DateTime dFechaFin = dFechaIni.Date.AddSeconds(86399);

                ReportGetCondition filter = new ReportGetCondition();
                string SplitVendedor = (Vendedores == "" ? "Todos los Vendedores" : Vendedores);
                Vendedores = (Vendedores == "" ? "null" : "'" + Vendedores + "'");

                //PRODUCTOS
                sConsulta.AppendLine("SELECT ALM.Clave AS ClaveCEDI, ALM.Nombre AS ALMNombre, DET.VendedorID, VEN.Nombre AS VENNombre, DET.ProductoClave, VAD.Descripcion AS TipoUnidad, PRO.Nombre AS PRONombre, ");
                sConsulta.AppendLine("SUM(InvInicial) AS InvInicial, SUM(Recarga) AS Recarga, SUM(CambioEnt) AS CambioEnt, SUM(DevolucionCli) AS DevolucionCli, SUM(Merma) AS Merma, SUM(Descarga) AS Descarga, SUM(DET.Venta) AS Venta, ");
                sConsulta.AppendLine("SUM((SubTotal- DescCliPor - ((SubTotal-DescCliPor) * DescVendPor / 100) ) + (Impuesto-DescCliPorImp-((Impuesto-DescCliPorImp) * DescVendPor / 100))) AS Importe, ");
                sConsulta.AppendLine("SUM((SubTotalCredito - DescCliPorCredito - ((SubTotalCredito-DescCliPorCredito) * DescVendPorCredito / 100)) + (ImpuestoCredito-DescCliPorImpCredito - ((ImpuestoCredito-DescCliPorImpCredito) * DescVendPorCredito / 100))) AS ImporteCredito ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("	SELECT VIS.VendedorID, Dia.FechaCaptura, TPD.ProductoClave, TPD.TipoUnidad, ");
                sConsulta.AppendLine("	InvInicial = 0, Recarga = 0, ");
                sConsulta.AppendLine("	CambioEnt = (SELECT CASE WHEN TRP.Tipo = 9 AND TRP.TipoMovimiento = 1 THEN TPD.Cantidad ELSE 0 END), ");
                sConsulta.AppendLine("	DevolucionCli = (SELECT CASE WHEN TRP.Tipo = 3 AND TRP.TipoFase <> 0 THEN TPD.Cantidad ELSE 0 END), ");
                sConsulta.AppendLine("	Merma = 0, Descarga = 0, ");
                sConsulta.AppendLine("	Venta = (SELECT CASE WHEN TRP.Tipo = 1 AND TRp.TipoFase <> 0 AND isnull(TPD.Promocion, 0) <> 2 THEN TPD.Cantidad ELSE 0 END), ");
                sConsulta.AppendLine("	SubTotal = (SELECT CASE WHEN TRP.Tipo = 1  AND TPD.Total > 0 THEN TPD.Subtotal ELSE 0 END), ");
                sConsulta.AppendLine("	DescCliPor = (SELECT CASE WHEN TRP.Tipo = 1  AND TPD.Total > 0 THEN (SELECT (CASE WHEN SUM(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) ELSE 0 END), ");
                sConsulta.AppendLine("	DescVendPor = (SELECT CASE WHEN TRP.Tipo = 1 AND TPD.Total > 0 THEN (SELECT CASE WHEN TRP.DescVendPor IS NULL THEN 0 ELSE TRP.DescVendPor END) ELSE 0 END), ");
                sConsulta.AppendLine("	Impuesto = (SELECT CASE WHEN TRP.Tipo = 1  AND TPD.Total > 0 THEN (SELECT CASE WHEN TPD.Impuesto IS NULL THEN 0 ELSE TPD.Impuesto END) ELSE 0 END), ");
                sConsulta.AppendLine("	DescCliPorImp = (SELECT CASE WHEN TRP.Tipo = 1 AND TPD.Total > 0 THEN (SELECT (CASE WHEN SUM(DesImpuesto) IS NULL THEN 0 ELSE SUM(DesImpuesto) END) ");
                sConsulta.AppendLine("	FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) ELSE 0 END), ");
                sConsulta.AppendLine("	SubTotalCredito = (SELECT CASE WHEN TRP.Tipo = 1 AND TRP.CFVTipo = 2 AND TPD.Total > 0 THEN TPD.Subtotal ELSE 0 END), ");
                sConsulta.AppendLine("	DescCliPorCredito = (SELECT CASE WHEN TRP.Tipo = 1 AND TRP.CFVTipo = 2 AND TPD.Total > 0 THEN (SELECT (CASE WHEN SUM(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) ELSE 0 END), ");
                sConsulta.AppendLine("	DescVendPorCredito = (SELECT CASE WHEN TRP.Tipo = 1 AND TRP.CFVTipo = 2 AND TPD.Total > 0 THEN (SELECT CASE WHEN TRP.DescVendPor IS NULL THEN 0 ELSE TRP.DescVendPor END) ELSE 0 END), ");
                sConsulta.AppendLine("	ImpuestoCredito = (SELECT CASE WHEN TRP.Tipo = 1  AND TRP.CFVTipo = 2 AND TPD.Total > 0 THEN (SELECT CASE WHEN TPD.Impuesto IS NULL THEN 0 ELSE TPD.Impuesto END) ELSE 0 END), ");
                sConsulta.AppendLine("	DescCliPorImpCredito = (SELECT CASE WHEN TRP.Tipo = 1  AND TRP.CFVTipo = 2 AND TPD.Total>0 THEN (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) ");
                sConsulta.AppendLine("	FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) ELSE 0 END) ");
                sConsulta.AppendLine("	FROM TransProd AS TRP (NOLOCK) ");
                sConsulta.AppendLine("	INNER JOIN Visita VIS (NOLOCK) ON ISNULL(TRP.VisitaClave1, TRP.VisitaClave) = VIS.VisitaClave AND ISNULL(TRP.DiaClave1, TRP.DiaClave) = VIS.DiaClave ");
                sConsulta.AppendLine("	INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("	INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TPD.TransProdId = TRP.TransProdId ");
                sConsulta.AppendLine("	WHERE DIA.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("  AND ((VIS.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("	AND TRP.Tipo IN (1,3,9) AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("	UNION ALL ");
                sConsulta.AppendLine("	SELECT VEN.VendedorID, Dia.FechaCaptura, TPD.ProductoClave, TPD.TipoUnidad, ");
                sConsulta.AppendLine("	InvInicial = (SELECT CASE WHEN TRP.Tipo = 2 AND TRP.FechaHoraAlta = CAR.FechaHoraAlta THEN TPD.Cantidad ELSE 0 END), ");
                sConsulta.AppendLine("	Recarga = (SELECT CASE WHEN TRP.Tipo = 2 AND TRP.FechaHoraAlta > CAR.FechaHoraAlta THEN TPD.Cantidad ELSE 0 END), ");
                sConsulta.AppendLine("	CambioEnt = 0, DevolucionCli = 0, ");
                sConsulta.AppendLine("	Merma = (SELECT CASE WHEN TRP.Tipo = 4 AND TRP.TipoFase <> 0 THEN TPD.Cantidad ELSE 0 END), ");
                sConsulta.AppendLine("	Descarga = (SELECT CASE WHEN TRP.Tipo = 7 AND TRP.TipoFase <> 0 THEN TPD.Cantidad ELSE 0 END), ");
                sConsulta.AppendLine("	Venta = 0, SubTotal = 0, DescCliPor = 0, DescVendPor = 0, Impuesto = 0, DescCliPorImp = 0, SubTotalCredito = 0, DescCliPorCredito = 0, DescVendPorCredito = 0, ImpuestoCredito = 0, DescCliPorImpCredito = 0 ");
                sConsulta.AppendLine("	FROM TransProd AS TRP (NOLOCK) ");
                sConsulta.AppendLine("	INNER JOIN Dia (NOLOCK) ON TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("	INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TPD.TransProdId = TRP.TransProdId ");
                sConsulta.AppendLine("	INNER JOIN Producto AS PRO (NOLOCK) ON PRO.ProductoClave = TPD.ProductoClave ");
                sConsulta.AppendLine("	INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.USUId = TRP.MUsuarioID ");
                sConsulta.AppendLine("	LEFT JOIN ( ");
                sConsulta.AppendLine("		SELECT VEN.VendedorID, MIN(TRP.FechaHoraAlta) AS FechaHoraAlta ");
                sConsulta.AppendLine("		FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("		INNER JOIN Vendedor VEN (NOLOCK) ON TRP.MUsuarioID = VEN.USUId ");
                sConsulta.AppendLine("		INNER JOIN Dia (NOLOCK) ON TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("		WHERE TRP.Tipo = 2 AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("	    AND DIA.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("  AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("		GROUP BY VEN.VendedorID ");
                sConsulta.AppendLine("	) AS CAR ON VEN.VendedorID = CAR.VendedorID ");
                sConsulta.AppendLine("	WHERE DIA.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("  AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("	AND ((TRP.Tipo = 2 AND TRP.TipoFase = 1) OR (TRP.Tipo IN (4,7) AND TRP.TipoFase <> 0)) ");
                sConsulta.AppendLine("	UNION ALL ");
                sConsulta.AppendLine("	SELECT VEN.VendedorID, Dia.FechaCaptura, TPD.ProductoClave, TPD.TipoUnidad, ");
                sConsulta.AppendLine("	InvInicial = TPD.Cantidad, Recarga = 0, CambioEnt = 0, DevolucionCli = 0, Merma = 0, Descarga = 0, Venta = 0, SubTotal = 0, DescCliPor = 0, ");
                sConsulta.AppendLine("	DescVendPor = 0, Impuesto = 0, DescCliPorImp= 0, SubTotalCredito = 0, DescCliPorCredito = 0, DescVendPorCredito = 0, ImpuestoCredito = 0, DescCliPorImpCredito = 0 ");
                sConsulta.AppendLine("	FROM TransProd AS TRP (NOLOCK) ");
                sConsulta.AppendLine("	INNER JOIN Dia (NOLOCK) ON TRP.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("	INNER JOIN TransProdDetalle AS TPD (NOLOCK) ON TPD.TransProdId = TRP.TransProdId ");
                sConsulta.AppendLine("	INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.USUId = TRP.MUsuarioId ");
                sConsulta.AppendLine("	INNER JOIN (  ");
                sConsulta.AppendLine("		SELECT VEN.VendedorID, MAX(TRP.FechaHoraAlta) AS FechaHoraAlta ");
                sConsulta.AppendLine("		FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("		INNER JOIN Vendedor VEN (NOLOCK) ON TRP.MUsuarioID = VEN.USUId ");
                sConsulta.AppendLine("		INNER JOIN Dia (NOLOCK) ON TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("		WHERE TRP.Tipo = 23 AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("	    AND DIA.FechaCaptura < '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("  AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("		GROUP BY VEN.VendedorID ");
                sConsulta.AppendLine("	) AS INI ON VEN.VendedorID = INI.VendedorID AND TRP.FechaHoraAlta = INI.FechaHoraAlta ");
                sConsulta.AppendLine("	WHERE TRP.Tipo = 23 AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("  AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine(") AS DET ");
                sConsulta.AppendLine("INNER JOIN Producto AS PRO (NOLOCK) ON PRO.ProductoClave = DET.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle AS PDD (NOLOCK) ON PDD.ProductoClave = DET.ProductoClave AND PDD.PRUTipoUnidad = DET.TipoUnidad AND PDD.PRUTipoUnidad = DET.TipoUnidad AND PDD.ProductoDetClave = DET.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.VendedorID = DET.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorID = VEN.VendedorId AND DET.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen as ALM (NOLOCK) ON ALM.AlmacenID = VCH.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD (NOLOCK) on VAD.VARCodigo = 'UNIDADV' AND VAD.VADTipoLenguaje = dbo.FNObtenerLenguaje() AND DET.TipoUnidad = VAD.VAVClave ");
                sConsulta.AppendLine("GROUP BY ALM.Clave, ALM.Nombre, DET.VendedorID, VEN.Nombre, DET.ProductoClave, VAD.Descripcion, PRO.Nombre ");
                sConsulta.AppendLine("ORDER BY ALM.Clave, ALM.Nombre, DET.VendedorID, VEN.Nombre, DET.ProductoClave, VAD.Descripcion ");
                string QueryProductos = sConsulta.ToString();

                //VENTAS DE CONTADO
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, ALM.Nombre AS ALMNombre, VEN.VendedorId, VEN.Nombre AS VENNombre, ");
                sConsulta.AppendLine("TRP.Folio, TRP.FechaHoraAlta, CLI.NombreCorto + ' - ' + CLI.RazonSocial AS Cliente, CASE WHEN TRP.TipoFase = 0 THEN 0 ELSE TRP.Total END AS Total, TRP.TipoFase ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.DiaClave = VIS.DiaClave AND TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON TRP.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK) GROUP BY DiaClave, VendedorId, ClaveCEDI) AS AGV ON AGV.DiaClave = TRP.DiaClave AND AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Almacen AS ALM (NOLOCK) ON ALM.Clave = AGV.ClaveCEDI ");
                sConsulta.AppendLine("WHERE Dia.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("AND TRP.Tipo = 1 AND TRP.CFVTipo = 1 AND TRP.FacturaId IS NULL ");
                sConsulta.AppendLine("ORDER BY ClaveCEDI, ALMNombre, VEN.VendedorId, VENNombre, TRP.FechaHoraAlta ");
                string QueryVentaCont = sConsulta.ToString();

                //VENTAS DE CREDITO
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT AGV.ClaveCEDI, ALM.Nombre AS ALMNombre, VEN.VendedorId, VEN.Nombre AS VENNombre, ");
                sConsulta.AppendLine("TRP.Folio, TRP.FechaHoraAlta, CLI.NombreCorto + ' - ' + CLI.RazonSocial AS Cliente, CASE WHEN TRP.TipoFase = 0 THEN 0 ELSE TRP.Total END AS Total, TRP.TipoFase ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.DiaClave = VIS.DiaClave AND TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON TRP.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK) GROUP BY DiaClave, VendedorId, ClaveCEDI) AS AGV ON AGV.DiaClave = TRP.DiaClave AND AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Almacen as ALM (NOLOCK) ON ALM.Clave = AGV.ClaveCEDI ");
                sConsulta.AppendLine("WHERE Dia.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("AND TRP.Tipo = 1 AND TRP.CFVTipo = 2 AND TRP.FacturaId IS NULL ");
                sConsulta.AppendLine("ORDER BY ClaveCEDI, ALMNombre, VEN.VendedorId, VENNombre, TRP.FechaHoraAlta ");
                string QueryVentaCred = sConsulta.ToString();

                //COBRANZA
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT CLI.NombreCorto + ' - '+ CLI.RazonSocial AS Cliente, TP.Folio, ABT.FechaHora, TP.Total, TP.Saldo, ");
                sConsulta.AppendLine("VD.Descripcion, ISNULL(ABD.Referencia,'') AS Referencia, ABT.Importe, Vis.VendedorID ");
                sConsulta.AppendLine("FROM TransProd TP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN AbnTrp ABT (NOLOCK) ON TP.TransProdID = ABT.TransProdID AND TP.TipoFase <> '0' ");
                sConsulta.AppendLine("AND TP.CFVTipo = '2' AND TP.FechaCaptura <> '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("INNER JOIN Abono Ab (NOLOCK) ON Ab.ABNId = ABT.ABNId ");
                sConsulta.AppendLine("INNER JOIN Visita Vis (NOLOCK) ON Vis.VisitaClave = Ab.VisitaClave AND Vis.DiaClave = Ab.DiaClave ");
                sConsulta.AppendLine("AND ((VIS.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = Vis.DiaClave AND Dia.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "'");
                sConsulta.AppendLine("INNER JOIN ABNDetalle ABD (NOLOCK) ON ABT.ABNId = ABD.ABNId ");
                sConsulta.AppendLine("INNER JOIN VAVDescripcion VD (NOLOCK) ON VD.VARCodigo = 'PAGO' AND VD.VAVClave = ABD.TipoPago AND VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON TP.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("ORDER BY Vis.VendedorID, TP.FechaHoraAlta ");
                string QueryCobranza = sConsulta.ToString();

                //PRELIQUIDACION
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT DISTINCT VEN.ClaveCEDI, VEN.VendedorId, ISNULL(ABN.Abonos, 0) AS Cobranza ");
                sConsulta.AppendLine("   FROM ( ");
                sConsulta.AppendLine("   SELECT DISTINCT AGV.ClaveCEDI, VEN.VendedorId ");
                sConsulta.AppendLine("   FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("   INNER JOIN Visita VIS (NOLOCK) ON TRP.DiaClave = VIS.DiaClave AND TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("   INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("   INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("   INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK) GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("   WHERE Dia.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("   AND TRP.Tipo IN (1,3,9) AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("   UNION ");
                sConsulta.AppendLine("   SELECT DISTINCT AGV.ClaveCEDI, VEN.VendedorId ");
                sConsulta.AppendLine("   FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("   INNER JOIN Dia (NOLOCK) ON TRP.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("   INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.USUId = TRP.MUsuarioID ");
                sConsulta.AppendLine("   INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK) GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("   WHERE Dia.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("   AND TRP.Tipo IN (2,4,7,23) AND TRP.TipoFase <> 0 ");
                sConsulta.AppendLine("   ) AS VEN ");
                sConsulta.AppendLine("   LEFT JOIN ( ");
                sConsulta.AppendLine("       SELECT AGV.ClaveCEDI, VEN.VendedorId, SUM(ABT.Importe) as Abonos ");
                sConsulta.AppendLine("       FROM AbnTrp ABT (NOLOCK) ");
                sConsulta.AppendLine("       INNER JOIN Abono ABN (NOLOCK) on ABT.ABNId = ABN.ABNId ");
                sConsulta.AppendLine("       INNER JOIN Visita VIS (NOLOCK) ON ISNULL(ABT.DiaClave, ABN.DiaClave) = VIS.DiaClave AND ISNULL(ABT.VisitaClave, ABN.VisitaClave) = VIS.VisitaClave ");
                sConsulta.AppendLine("       INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = DIA.DiaClave ");
                sConsulta.AppendLine("       INNER JOIN TransProd TRP (NOLOCK) ON ABT.TransProdId = TRP.TransProdId ");
                sConsulta.AppendLine("       INNER JOIN Vendedor AS VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("       INNER JOIN (SELECT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK) GROUP BY DiaClave, VendedorId, ClaveCEDI) as AGV ON AGV.DiaClave=TRP.DiaClave AND AGV.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("       WHERE Dia.FechaCaptura = '" + dFechaIni.ToString("yyyyMMdd") + "' ");
                sConsulta.AppendLine("       AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("       AND TRP.TipoFase <> 0 AND TRP.Tipo = 1 AND TRP.CFVTipo = 2 ");
                sConsulta.AppendLine("       GROUP BY AGV.ClaveCEDI, VEN.VendedorId ");
                sConsulta.AppendLine("   ) ABN ON VEN.ClaveCEDI = ABN.ClaveCEDI AND VEN.VendedorID = ABN.VendedorID ");
                string QueryPreliquidacion = sConsulta.ToString();

                //DESGLOSE
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT SUM(Cantidad) As Cantidad, Tipo, Descripcion, VendedorID, (SUM(Cantidad) * CAST(Descripcion AS float)) AS Subtotal FROM( ");
                sConsulta.AppendLine("SELECT  PLE.Cantidad, PL.VendedorID, ");
                sConsulta.AppendLine("(SELECT CASE WHEN VV.Grupo = 1 THEN 'Billete' ");
                sConsulta.AppendLine("ELSE 'Moneda' END FROM VARValor VV (NOLOCK) WHERE VV.VAVClave = PLE.TipoEfectivo AND VV.VARCodigo = 'DENOMINA') AS Tipo, ");
                sConsulta.AppendLine("(SELECT VD.Descripcion FROM VAVDescripcion VD (NOLOCK) WHERE VD.VAVClave = PLE.TipoEfectivo AND VD.VARCodigo = 'DENOMINA' AND VD.VADTipoLenguaje = 'EM') AS Descripcion ");
                sConsulta.AppendLine("FROM PreLiquidacion PL (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN PLIEfectivo PLE (NOLOCK) ON PL.PLIId = PLE.PLIId ");
                sConsulta.AppendLine("AND((PL.VendedorId IN(SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("AND PL.FechaPreliquidacion BETWEEN '" + dFechaIni.ToString("yyyyMMdd") + "' AND '" + dFechaFin.ToString("yyyyMMdd") + "') DE ");
                sConsulta.AppendLine("GROUP BY DE.Descripcion, DE.VendedorId, Tipo ");
                sConsulta.AppendLine("ORDER BY DE.Tipo, CAST(DE.Descripcion as numeric), VendedorID ");
                string QueryDesglose = sConsulta.ToString();

                //DEPOSITOS
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT VV.Descripcion, PLI.Referencia, PLI.Ficha, PLI.Total, PL.VendedorID, PL.FechaPreLiquidacion FROM PreLiquidacion PL (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN PLIBancario PLI (NOLOCK) ON PLI.PLIId = PL.PLIId AND PL.FechaPreliquidacion BETWEEN '" + dFechaIni.ToString("yyyyMMdd") + "' AND '" + dFechaFin.ToString("yyyyMMdd") + "'");
                sConsulta.AppendLine("AND ((PL.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta.AppendLine("INNER JOIN VAVDescripcion VV (NOLOCK) ON VV.VARCodigo = 'TBANCO' AND VV.VADTipoLenguaje = 'EM' AND VV.VAVClave = PLI.TipoBanco");
                string QueryDeposito = sConsulta.ToString();

                LiquidacionPDR report = new LiquidacionPDR(QueryProductos, QueryVentaCont, QueryVentaCred, QueryPreliquidacion, QueryCobranza, QueryDesglose, QueryDeposito);

                report.logo.Image = Image.FromStream(LogoEmpresa);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;
                report.filtro.Text = SplitVendedor;
                report.centro.Text = NombreCEDIS;
                report.fecha.Text = dFechaIni.ToShortDateString();

                //GrouHeader
                report.lbVendedorGrupo.Text = Mensaje.ObtenerDescripcion("XVendedor", "EM");
                report.lbMovimientosProd.Text = Mensaje.ObtenerDescripcion("XMovProductos", "EM");
                report.lbClave.Text = Mensaje.ObtenerDescripcion("XClave", "EM");
                report.lbDescripcion.Text = Mensaje.ObtenerDescripcion("XDescripcion", "EM");
                report.lbUnidad.Text = Mensaje.ObtenerDescripcion("XUnidad", "EM");
                report.lbInvInicial.Text = Mensaje.ObtenerDescripcion("XInvInicial", "EM");
                report.lbRecargas.Text = Mensaje.ObtenerDescripcion("XRecargas", "EM");
                report.lbCambios.Text = Mensaje.ObtenerDescripcion("XCambios", "EM");
                report.lbDevolucionesCte.Text = Mensaje.ObtenerDescripcion("XDevoluciones", "EM");
                report.lbMermas.Text = Mensaje.ObtenerDescripcion("XMerma", "EM");
                report.lbDescargasAlm.Text = Mensaje.ObtenerDescripcion("XDescargas", "EM");
                report.lbVentas.Text = Mensaje.ObtenerDescripcion("XVentas", "EM");
                report.lbImporte.Text = Mensaje.ObtenerDescripcion("XImporte", "EM");
                report.lbInvFinal.Text = Mensaje.ObtenerDescripcion("XInvFinal", "EM");

                //Venta Contado
                ((VentasContadoPDR)report.srptVentasContado.ReportSource).lbVentasContado.Text = Mensaje.ObtenerDescripcion("XVtaContado", "EM");
                ((VentasContadoPDR)report.srptVentasContado.ReportSource).lbVenta.Text = Mensaje.ObtenerDescripcion("XVenta", "EM");
                ((VentasContadoPDR)report.srptVentasContado.ReportSource).lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");
                ((VentasContadoPDR)report.srptVentasContado.ReportSource).lbCliente.Text = Mensaje.ObtenerDescripcion("XCliente", "EM");
                ((VentasContadoPDR)report.srptVentasContado.ReportSource).lbImporte.Text = Mensaje.ObtenerDescripcion("XImporte", "EM");
                ((VentasContadoPDR)report.srptVentasContado.ReportSource).lbTotalVentasContado.Text = Mensaje.ObtenerDescripcion("XTotalVtaContado", "EM");

                //Venta Credito
                ((VentasCreditoPDR)report.srptVentasCredito.ReportSource).lbVentasCredito.Text = Mensaje.ObtenerDescripcion("XVtaCredito", "EM");
                ((VentasCreditoPDR)report.srptVentasCredito.ReportSource).lbVenta.Text = Mensaje.ObtenerDescripcion("XVenta", "EM");
                ((VentasCreditoPDR)report.srptVentasCredito.ReportSource).lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");
                ((VentasCreditoPDR)report.srptVentasCredito.ReportSource).lbCliente.Text = Mensaje.ObtenerDescripcion("XCliente", "EM");
                ((VentasCreditoPDR)report.srptVentasCredito.ReportSource).lbImporte.Text = Mensaje.ObtenerDescripcion("XImporte", "EM");
                ((VentasCreditoPDR)report.srptVentasCredito.ReportSource).lbTotalVentasCredito.Text = Mensaje.ObtenerDescripcion("XTotalVtaCredito", "EM");

                //Cobranzaa
                ((CobranzaPDR)report.srptCobranza.ReportSource).lbCliente.Text = Mensaje.ObtenerDescripcion("XCliente", "EM");
                ((CobranzaPDR)report.srptCobranza.ReportSource).lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");
                ((CobranzaPDR)report.srptCobranza.ReportSource).lbImporte.Text = Mensaje.ObtenerDescripcion("XImporte", "EM");
                ((CobranzaPDR)report.srptCobranza.ReportSource).lbCobranza.Text = Mensaje.ObtenerDescripcion("XCobranza", "EM");
                ((CobranzaPDR)report.srptCobranza.ReportSource).lbVenta.Text = Mensaje.ObtenerDescripcion("XVenta", "EM");


                //Preliquidacion
                ((PreliquidacionPDR)report.srptPreliquidacion.ReportSource).lbPreliquidacion.Text = Mensaje.ObtenerDescripcion("XPreliquidacion", "EM");
                ((PreliquidacionPDR)report.srptPreliquidacion.ReportSource).lbVentaTotal.Text = Mensaje.ObtenerDescripcion("XVentaTotal", "EM");
                ((PreliquidacionPDR)report.srptPreliquidacion.ReportSource).lbVentaCredito.Text = Mensaje.ObtenerDescripcion("XVtaCredito", "EM");
                ((PreliquidacionPDR)report.srptPreliquidacion.ReportSource).lbVentaContado.Text = Mensaje.ObtenerDescripcion("XVtaContado", "EM");
                ((PreliquidacionPDR)report.srptPreliquidacion.ReportSource).lbCobranzaCredito.Text = Mensaje.ObtenerDescripcion("XCobranzoCredito", "EM");
                ((PreliquidacionPDR)report.srptPreliquidacion.ReportSource).lbTotalLiquidar.Text = Mensaje.ObtenerDescripcion("XTotalLiquidarSencillo", "EM");

                //Desglose
                ((DesgloseEfectivo)report.srptDesglose.ReportSource).lbCantidad.Text = Mensaje.ObtenerDescripcion("XCantidad", "EM");
                ((DesgloseEfectivo)report.srptDesglose.ReportSource).lbImporte.Text = Mensaje.ObtenerDescripcion("XImporte", "EM");
                ((DesgloseEfectivo)report.srptDesglose.ReportSource).lbTipo.Text = Mensaje.ObtenerDescripcion("XTipo", "EM");
                ((DesgloseEfectivo)report.srptDesglose.ReportSource).lbTotalEfectivo.Text = Mensaje.ObtenerDescripcion("XTotalEfectivo", "EM");

                //Desglose Depositos
                ((DesglosePDR)report.srptDepositos.ReportSource).lbDepositos.Text = Mensaje.ObtenerDescripcion("XDepCheqOtrosConcep", "EM");
                ((DesglosePDR)report.srptDepositos.ReportSource).lbBanco.Text = Mensaje.ObtenerDescripcion("XBanco", "EM");
                ((DesglosePDR)report.srptDepositos.ReportSource).lbFicha.Text = Mensaje.ObtenerDescripcion("XFicha", "EM");
                ((DesglosePDR)report.srptDepositos.ReportSource).lbImporte2.Text = Mensaje.ObtenerDescripcion("XImporte", "EM");
                ((DesglosePDR)report.srptDepositos.ReportSource).lbReferencia.Text = Mensaje.ObtenerDescripcion("XReferencia", "EM");
                ((DesglosePDR)report.srptDepositos.ReportSource).lbTotalDeposito.Text = Mensaje.ObtenerDescripcion("XTotalDeposito", "EM");

                return report;
            }
            catch (Exception ex) { return new LiquidacionPDR(); }
        }
    }
}