using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class ScoreCard
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string Fecha;
        private string sAlmacenNombre;
        private string sEsquemasNombre;

        List<ScoreCardCAVSMAC> oAgendaVSAnteriorCEDI;
        List<ScoreCardCAVSMAR> oAgendaVSAnteriorRUTAS;
        List<ScoreCardSemana> oSemana;
        List<ScoreCardRutas> oRutas;
        List<ScoreCardEVC> oEfectividadVentaCEDI;
        List<ScoreCardEVR> oEfectividadVentaRUTAS;
        List<ScoreCardEVSC> oEfectividadVisitaCEDI;
        List<ScoreCardEVSR> oEfectividadVisitaRUTAS;
        List<ScoreCardTVSVSPC> oVentaSemanalVSPromedioCEDI;
        List<ScoreCardTVSVSPR> oVentaSemanalVSPromedioRUTAS;
        List<ScoreCardEC> oEsquemasCEDI;
        List<ScoreCardER> oEsquemasRUTAS;
        List<ScoreCardMBC> oMixBoddaCEDI;
        List<ScoreCardMBR> oMixBoddaRUTAS;
        List<ScoreCardCCVVSMAC> oClientesVentaVSMesAnteriorCEDI;
        List<ScoreCardCCVVSMAR> oClientesVentaVSMesAnteriorRUTAS;
        List<ScoreCardECCVVSMAC> oClientesVentaVSMesAnteriorEsqCEDI;
        List<ScoreCardECCVVSMAR> oClientesVentaVSMesAnteriorEsqRUTAS;
        List<ScoreCardDSVSMAC> oDropSizeVsMesAnteriorCEDI;
        List<ScoreCardDSVSMAR> oDropSizeVsMesAnteriorRUTAS;
        List<ScoreCardEDSVSMAC> oDropSizeVsMesAnteriorEsqCEDI;
        List<ScoreCardEDSVSMAR> oDropSizeVsMesAnteriorEsqRUTAS;
        List<ScoreCardPorcDVSMAC> oDevVSMesAnteriorCEDI;
        List<ScoreCardPorcDVSMAR> oDevVSMesAnteriorRUTAS;
        List<ScoreCardPorcDVSMACE> oDevVSMesAnteriorEsqCEDI;
        List<ScoreCardPorcDVSMARE> oDevVSMesAnteriorEsqRUTAS;
        List<ScoreCardPorcCVSMAC> oCoberturaVSMesAnteriorCEDI;
        List<ScoreCardPorcCVSMAR> oCoberturaVSMesAnteriorRUTAS;
        List<ScoreCardPorcCVSMACE> oCoberturaVSMesAnteriorEsqCEDI;
        List<ScoreCardPorcCVSMARE> oCoberturaVSMesAnteriorEsqRUTAS;
        List<ScoreCardSOVSMAC> oSelloutVSMesAntCEDI;
        List<ScoreCardSOVSMAR> oSelloutVSMesAntRUTAS;
        List<ScoreCardESOVSMAC> oSelloutVSMesAntEsqCEDI;
        List<ScoreCardESOVSMAR> oSelloutVSMesAntEsqRUTAS;

        public bool GetReport(string Fecha, string AlmacenClave, string Esquemas, string AlmacenNombre, string EsquemasNombre)
        {
            try
            {
                DateTime dFecha;
                DateTime.TryParse(Fecha, out dFecha);
                DateTime dFechaIni = dFecha.Date;
                String filtroEsquemaProd = "";
                if (!Esquemas.Equals(""))
                    filtroEsquemaProd = "WHERE ESQ2.EsquemaIdPadre IN (" + Esquemas + ")";
                this.sAlmacenNombre = AlmacenNombre;
                this.sEsquemasNombre = EsquemasNombre;

                #region 'Clientes agenda vs mes anterior CEDI'
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, SUM(T.W) AS W, CASE WHEN (SUM(T.W4)/4) > 0 THEN ((CAST(SUM(T.W) AS float)/(SUM(T.W4)/4))*100)-100 else 0 end AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT DISTINCT AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 1 AS W, 0 AS W4 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON AGV.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON AGV.ClienteClave = CLIESQ.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT DISTINCT AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 0 AS W, 1 AS W4 ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON AGV.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON AGV.ClienteClave = CLIESQ.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("ORDER BY T.Nombre ");
                QueryString = sConsulta.ToString();
                oAgendaVSAnteriorCEDI = Connection.Query<ScoreCardCAVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Clientes agenda vs mes anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, SUM(T.W) AS W, CASE WHEN (SUM(T.W4)/4) > 0 THEN ((CAST(SUM(T.W) AS float)/(SUM(T.W4)/4))*100)-100 else 0 end AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT DISTINCT AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 1 AS W, 0 AS W4, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON AGV.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON AGV.ClienteClave = CLIESQ.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE AGV.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY AGV.RUTClave, AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT DISTINCT AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 0 AS W, 1 AS W4, AGV.RUTClave ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON AGV.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON AGV.ClienteClave = CLIESQ.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE AGV.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY AGV.RUTClave, AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre, T.RUTClave ");
                sConsulta.AppendLine("ORDER BY T.Nombre, T.RUTClave ");
                QueryString = sConsulta.ToString();
                oAgendaVSAnteriorRUTAS = Connection.Query<ScoreCardCAVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Consulta para calcular el numero de la semana y las fechas de inicio / fin'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') AS Semana, DATEADD(dd, -(DATEPART(DW, '" + dFechaIni.Date.ToString("s") + "') - 1), '" + dFechaIni.Date.ToString("s") + "') InicioSemana, ");
                sConsulta.AppendLine("DATEADD(dd, 7 - (DATEPART(DW, '" + dFechaIni.Date.ToString("s") + "')), '" + dFechaIni.Date.ToString("s") + "') FinSemana ");
                QueryString = sConsulta.ToString();
                oSemana = Connection.Query<ScoreCardSemana>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Obtener las rutas del cedi seleccionado'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT VRUT.RUTClave, RUT.Descripcion ");
                sConsulta.AppendLine("FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON VRUT.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("ORDER BY RUT.Descripcion ");
                QueryString = sConsulta.ToString();
                oRutas = Connection.Query<ScoreCardRutas>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Efectividad venta CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, CASE WHEN SUM(T.ConVenta) > 0 THEN (CAST(SUM(T.Visitados) AS float)/SUM(T.ConVenta))*100 else 0 end AS W, ");
                sConsulta.AppendLine("CASE WHEN SUM(T.ConVenta) > 0 THEN CASE WHEN (CAST(SUM(T.Visitados) AS float)/SUM(T.ConVenta))*100 >= 80 THEN (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XBien' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) ");
                sConsulta.AppendLine("ELSE (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XMal' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) END else (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XMal' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) end AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT DISTINCT ALM.AlmacenID, VIS.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 1 AS Visitados, 0 AS ConVenta ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY VIS.ClienteClave, ALM.AlmacenID, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ALM.AlmacenID, TRP.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 0 AS Visitados, 1 AS ConVenta ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("--WHERE PROESQ.EsquemaID = '' ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave, ALM.AlmacenID, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                QueryString = sConsulta.ToString();
                oEfectividadVentaCEDI = Connection.Query<ScoreCardEVC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Efectividad venta RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, CASE WHEN SUM(T.ConVenta) > 0 THEN (CAST(SUM(T.Visitados) AS float)/SUM(T.ConVenta))*100 else 0 end AS W, ");
                sConsulta.AppendLine("CASE WHEN SUM(T.ConVenta) > 0 THEN CASE WHEN (CAST(SUM(T.Visitados) AS float)/SUM(T.ConVenta))*100 >= 80 THEN (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XBien' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) ");
                sConsulta.AppendLine("ELSE (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XMal' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) END else (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XMal' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) end AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, VIS.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 1 AS Visitados, 0 AS ConVenta ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, VIS.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, TRP.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 0 AS Visitados, 1 AS ConVenta ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave, VIS.RUTClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID, T.Nombre ");
                QueryString = sConsulta.ToString();
                oEfectividadVentaRUTAS = Connection.Query<ScoreCardEVR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Efectividad visita CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, CASE WHEN SUM(T.Agendados) > 0 THEN (CAST(SUM(T.Visitados) AS float)/SUM(T.Agendados))*100 else 0 end AS W, ");
                sConsulta.AppendLine("CASE WHEN SUM(T.Agendados) > 0 THEN CASE WHEN (CAST(SUM(T.Visitados) AS float)/SUM(T.Agendados))*100 >= 80 THEN (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XBien' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) ");
                sConsulta.AppendLine("ELSE (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XMal' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) END else (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XMal' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) end AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT DISTINCT AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 0 AS Visitados, 1 AS Agendados ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON AGV.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON AGV.ClienteClave = CLIESQ.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT DISTINCT VIS.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 1 AS Visitados, 0 AS Agendados FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY VIS.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("ORDER BY T.Nombre ");
                QueryString = sConsulta.ToString();
                oEfectividadVisitaCEDI = Connection.Query<ScoreCardEVSC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Efectividad visita RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, CASE WHEN SUM(T.Agendados) > 0 THEN (CAST(SUM(T.Visitados) AS float)/SUM(T.Agendados))*100 else 0 end AS W, ");
                sConsulta.AppendLine("CASE WHEN SUM(T.Agendados) > 0 THEN CASE WHEN (CAST(SUM(T.Visitados) AS float)/SUM(T.Agendados))*100 >= 80 THEN (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XBien' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) ");
                sConsulta.AppendLine("ELSE (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XMal' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) END else (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XMal' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) end AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT DISTINCT AGV.RUTClave, AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 0 AS Visitados, 1 AS Agendados ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON AGV.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON AGV.ClienteClave = CLIESQ.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE AGV.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY AGV.RUTClave, AGV.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT DISTINCT VIS.RUTClave, VIS.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre, 1 AS Visitados, 0 AS Agendados FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, VIS.ClienteClave, CLIESQ.EsquemaID, ESQ.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("ORDER BY T.Nombre ");
                QueryString = sConsulta.ToString();
                oEfectividadVisitaRUTAS = Connection.Query<ScoreCardEVSR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Total venta semanal vs promedio CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT SUM(T.TotalVtaVSPromedioW) AS TotalVtaVSPromedioW, CASE WHEN (SUM(T.TotalVtaVSPromedio4W)/4) > 0 THEN ((CAST(SUM(T.TotalVtaVSPromedioW) AS float)/(SUM(T.TotalVtaVSPromedio4W)/4))*100)-100 else 0 end AS TotalVtaVSPromedio4W FROM ( ");
                sConsulta.AppendLine("SELECT SUM(TPD.Cantidad*PRODE.Factor) AS TotalVtaVSPromedioW, 0 AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS TotalVtaVSPromedioW, SUM(TPD.Cantidad*PRODE.Factor) AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine(") AS T ");
                QueryString = sConsulta.ToString();
                oVentaSemanalVSPromedioCEDI = Connection.Query<ScoreCardTVSVSPC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Total venta semanal vs promedio RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, SUM(T.TotalVtaVSPromedioW) AS TotalVtaVSPromedioW, CASE WHEN SUM(T.TotalVtaVSPromedio4W) > 0 THEN ((CAST(SUM(T.TotalVtaVSPromedioW) AS float)/(SUM(T.TotalVtaVSPromedio4W)/4))*100)-100 else 0 end AS TotalVtaVSPromedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, SUM(TPD.Cantidad*PRODE.Factor) AS TotalVtaVSPromedioW, 0 AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, 0 AS TotalVtaVSPromedioW, SUM(TPD.Cantidad*PRODE.Factor) AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                QueryString = sConsulta.ToString();
                oVentaSemanalVSPromedioRUTAS = Connection.Query<ScoreCardTVSVSPR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.Nombre, T.EsquemaID, SUM(T.TotalVtaVSPromedioW) AS TotalVtaVSPromedioW, CASE WHEN SUM(T.TotalVtaVSPromedio4W) > 0 THEN ((CAST(SUM(T.TotalVtaVSPromedioW) AS float)/(SUM(T.TotalVtaVSPromedio4W)/4))*100)-100 else 0 end AS TotalVtaVSPromedio4W FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.Nombre, ESQ2.EsquemaID, SUM(TPD.Cantidad*PRODE.Factor) AS TotalVtaVSPromedioW, 0 AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 WHERE ESQ2.Nombre != 'MIX BODDA' " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre, ESQ2.EsquemaID ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ESQ2.Nombre, ESQ2.EsquemaID, 0 AS TotalVtaVSPromedioW, SUM(TPD.Cantidad*PRODE.Factor) AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 WHERE ESQ2.Nombre != 'MIX BODDA' " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre, ESQ2.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.Nombre, T.EsquemaID ORDER BY T.Nombre ");
                QueryString = sConsulta.ToString();
                oEsquemasCEDI = Connection.Query<ScoreCardEC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, SUM(T.TotalVtaVSPromedioW) AS TotalVtaVSPromedioW, CASE WHEN SUM(T.TotalVtaVSPromedio4W) > 0 THEN ((CAST(SUM(T.TotalVtaVSPromedioW) AS float)/(SUM(T.TotalVtaVSPromedio4W)/4))*100)-100 else 0 end AS TotalVtaVSPromedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, SUM(TPD.Cantidad*PRODE.Factor) AS TotalVtaVSPromedioW, 0 AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 WHERE ESQ2.Nombre != 'MIX BODDA' " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, 0 AS TotalVtaVSPromedioW, SUM(TPD.Cantidad*PRODE.Factor) AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 WHERE ESQ2.Nombre != 'MIX BODDA' " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID ");
                QueryString = sConsulta.ToString();
                oEsquemasRUTAS = Connection.Query<ScoreCardER>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Mix bodda CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT CASE WHEN SUM(T.TotalVtaVSPromedio4W) > 0 THEN ");
                sConsulta.AppendLine("((CAST(SUM(T.TotalVtaVSPromedioW) AS float)/(SUM(T.TotalVtaVSPromedio4W)/4))*100)-100 ");
                sConsulta.AppendLine("ELSE 0 END AS TotalVtaVSPromedioW, ");
                sConsulta.AppendLine("CASE WHEN SUM(T.TotalVtaVSPromedio4W) > 0 THEN ");
                sConsulta.AppendLine("CASE WHEN ((CAST(SUM(T.TotalVtaVSPromedioW) AS float)/(SUM(T.TotalVtaVSPromedio4W)/4))*100)-100 > 0 ");
                sConsulta.AppendLine("THEN (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XArriba' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) ELSE (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XAbajo' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) END ");
                sConsulta.AppendLine("ELSE (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XAbajo' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) END AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS TotalVtaVSPromedioW, 0 AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 WHERE ESQ2.Nombre = 'MIX BODDA' ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS TotalVtaVSPromedioW, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 WHERE ESQ2.Nombre = 'MIX BODDA' ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine(") AS T ");
                QueryString = sConsulta.ToString();
                oMixBoddaCEDI = Connection.Query<ScoreCardMBC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Mix bodda RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, CASE WHEN SUM(T.TotalVtaVSPromedio4W) > 0 THEN ");
                sConsulta.AppendLine("((CAST(SUM(T.TotalVtaVSPromedioW) AS float)/(SUM(T.TotalVtaVSPromedio4W)/4))*100)-100 ");
                sConsulta.AppendLine("ELSE 0 END AS TotalVtaVSPromedioW, ");
                sConsulta.AppendLine("CASE WHEN SUM(T.TotalVtaVSPromedio4W) > 0 THEN ");
                sConsulta.AppendLine("CASE WHEN ((CAST(SUM(T.TotalVtaVSPromedioW) AS float)/(SUM(T.TotalVtaVSPromedio4W)/4))*100)-100 > 0 ");
                sConsulta.AppendLine("THEN (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XArriba' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) ELSE (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XAbajo' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) END ");
                sConsulta.AppendLine("ELSE (SELECT Descripcion FROM MENDetalle (NOLOCK) WHERE MENClave = 'XAbajo' WHERE MEDTipoLenguaje = dbo.FNObtenerLenguaje()) END AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS TotalVtaVSPromedioW, 0 AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 WHERE ESQ2.Nombre = 'MIX BODDA' ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, 0 AS TotalVtaVSPromedioW, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS TotalVtaVSPromedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 WHERE ESQ2.Nombre = 'MIX BODDA' ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                QueryString = sConsulta.ToString();
                oMixBoddaRUTAS = Connection.Query<ScoreCardMBR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Clientes con venta vs mes anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W)/4 > 0 THEN ((CAST(SUM(W) AS float)/(SUM(T.Promedio4W)/4))*100)-100 else 0 end AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT 1 AS W, 0 AS Promedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS W, 1 AS Promedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave ");
                sConsulta.AppendLine(") AS T ");
                QueryString = sConsulta.ToString();
                oClientesVentaVSMesAnteriorCEDI = Connection.Query<ScoreCardCCVVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Clientes con venta vs mes anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W)/4 > 0 THEN ((CAST(SUM(W) AS float)/(SUM(T.Promedio4W)/4))*100)-100 else 0 end AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, 1 AS W, 0 AS Promedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave, VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, 0 AS W, 1 AS Promedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave, VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                QueryString = sConsulta.ToString();
                oClientesVentaVSMesAnteriorRUTAS = Connection.Query<ScoreCardCCVVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas - Clientes con venta vs mes anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W)> 0 THEN ((CAST(SUM(W) AS float)/(CAST(SUM(T.Promedio4W) AS float)/4))*100)-100 else 0 end AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 1 AS W, 0 AS Promedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS W, 1 AS Promedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                QueryString = sConsulta.ToString();
                oClientesVentaVSMesAnteriorEsqCEDI = Connection.Query<ScoreCardECCVVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas - Clientes con venta vs mes anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) > 0 THEN ((CAST(SUM(W) AS float)/(CAST(SUM(T.Promedio4W) AS float)/4))*100)-100 else 0 end AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, 1 AS W, 0 AS Promedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave, VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, 0 AS W, 1 AS Promedio4W ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY TRP.ClienteClave, VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID ");
                QueryString = sConsulta.ToString();
                oClientesVentaVSMesAnteriorEsqRUTAS = Connection.Query<ScoreCardECCVVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Drop size vs mes anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT SUM(T.W) AS W, SUM(T.Promedio4W) AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT CASE WHEN SUM(T.Visitas) > 0 THEN SUM(T.PzasVendidas)/SUM(T.Visitas) else 0 end AS W, 0 AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT 0 AS PzasVendidas, 1 AS Visitas ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT SUM(TPD.Cantidad*PRODE.Factor) AS PzasVendidas, 0 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS W, CASE WHEN SUM(T.Visitas) > 0 THEN SUM(T.PzasVendidas)/SUM(T.Visitas) else 0 end AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT 0 AS PzasVendidas, 1 AS Visitas ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY VIS.VisitaClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT SUM(TPD.Cantidad*PRODE.Factor) AS PzasVendidas, 0 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine(") AS T ");
                QueryString = sConsulta.ToString();
                oDropSizeVsMesAnteriorCEDI = Connection.Query<ScoreCardDSVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Drop size vs mes anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, SUM(T.W) AS W, SUM(T.Promedio4W) AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.RUTClave, CASE WHEN SUM(T.Visitas) > 0 THEN SUM(T.PzasVendidas)/SUM(T.Visitas) else 0 end AS W, 0 AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, SUM(TPD.Cantidad*PRODE.Factor) AS PzasVendidas, --0 AS Visitas ");
                sConsulta.AppendLine("(SELECT SUM(T.Visitas) AS Visitas FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasVendidas, 1 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS2 (NOLOCK) ON TRP.VisitaClave = VIS2.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON VIS2.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS2.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS2.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS2.RUTClave = VIS.RUTClave ");
                sConsulta.AppendLine("GROUP BY VIS2.VisitaClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T) AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.RUTClave, 0 AS W, CASE WHEN SUM(T.Visitas) > 0 THEN SUM(T.PzasVendidas)/SUM(T.Visitas) else 0 end AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, SUM(TPD.Cantidad*PRODE.Factor) AS PzasVendidas, --0 AS Visitas ");
                sConsulta.AppendLine("(SELECT SUM(T.Visitas) AS Visitas FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasVendidas, 1 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS2 (NOLOCK) ON TRP.VisitaClave = VIS2.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON VIS2.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS2.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS2.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS2.RUTClave = VIS.RUTClave ");
                sConsulta.AppendLine("GROUP BY VIS2.VisitaClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T) AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                QueryString = sConsulta.ToString();
                oDropSizeVsMesAnteriorRUTAS = Connection.Query<ScoreCardDSVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas - Drop size vs mes anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, SUM(T.W) AS W, SUM(T.Promedio4W) AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, CASE WHEN SUM(T.Visitas) > 0 THEN SUM(T.PzasVendidas)/SUM(T.Visitas) else 0 end AS W, 0 AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasVendidas, 1 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY VIS.VisitaClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, SUM(TPD.Cantidad*PRODE.Factor) AS PzasVendidas, 0 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, 0 AS W, CASE WHEN SUM(T.Visitas) > 0 THEN SUM(T.PzasVendidas)/SUM(T.Visitas) else 0 end AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasVendidas, 1 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON VIS.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY VIS.VisitaClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, SUM(TPD.Cantidad*PRODE.Factor) AS PzasVendidas, 0 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                QueryString = sConsulta.ToString();
                oDropSizeVsMesAnteriorEsqCEDI = Connection.Query<ScoreCardEDSVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas - Drop size vs mes anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, SUM(T.W) AS W, SUM(T.Promedio4W) AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, CASE WHEN SUM(T.Visitas) > 0 THEN CAST(SUM(T.PzasVendidas) AS float)/SUM(T.Visitas) else 0 end AS W, 0 AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre, SUM(TPD.Cantidad*PRODE.Factor) AS PzasVendidas, --0 AS Visitas ");
                sConsulta.AppendLine("(SELECT SUM(T.Visitas) AS Visitas FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasVendidas, 1 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS2 (NOLOCK) ON TRP.VisitaClave = VIS2.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON VIS2.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS2.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS2.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS2.RUTClave = VIS.RUTClave ");
                sConsulta.AppendLine("GROUP BY VIS2.VisitaClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T) AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, 0 AS W, CASE WHEN SUM(T.Visitas) > 0 THEN CAST(SUM(T.PzasVendidas) AS float)/SUM(T.Visitas) else 0 end AS Promedio4W ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre, SUM(TPD.Cantidad*PRODE.Factor) AS PzasVendidas, --0 AS Visitas ");
                sConsulta.AppendLine("(SELECT SUM(T.Visitas) AS Visitas FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasVendidas, 1 AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS2 (NOLOCK) ON TRP.VisitaClave = VIS2.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON VIS2.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON VIS2.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS2.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS2.RUTClave = VIS.RUTClave ");
                sConsulta.AppendLine("GROUP BY VIS2.VisitaClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T) AS Visitas ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID, T.Nombre ");
                QueryString = sConsulta.ToString();
                oDropSizeVsMesAnteriorEsqRUTAS = Connection.Query<ScoreCardEDSVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region '% Devoluciones vs Mes Anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("((CAST(SUM(T.W) AS float)/SUM(T.Promedio4W))*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT CASE WHEN SUM(T.PzasPedidos) > 0 THEN (CAST(SUM(T.PzasDev) AS float)/SUM(T.PzasPedidos))-SUM(T.PzasDev)*100 else 0 end AS W, 0 AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidos, 0 AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') --FILTRAR POR LA SEMANA SELECCIONADA EN EL FILTRO ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') --FILTRAR POR EL AÑO TAMBIEN, SINO SE TRAE SEMANAS DE TODOS LOS AÑOS ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS PzasPedido, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 3 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS W, SUM(T.PromedioSemana)/4 AS Promedio4W FROM ( --sumar el promedio de todas las semanas y dividir entre 4 ");
                sConsulta.AppendLine("SELECT T.wk, CASE WHEN SUM(T.PzasPedido) > 0 THEN ((CAST(SUM(T.PzasDev) AS float)/SUM(T.PzasPedido))-SUM(T.PzasDev))*100 else 0 end AS PromedioSemana FROM ( --calcular el promedio por semana ");
                sConsulta.AppendLine("SELECT DATEPART(WK, D.FechaCaptura) AS wk, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedido, 0 AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura) ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT DATEPART(WK, D.FechaCaptura) AS wk, 0 AS PzasPedido, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 3 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura) ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.wk ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine(") AS T ");
                QueryString = sConsulta.ToString();
                oDevVSMesAnteriorCEDI = Connection.Query<ScoreCardPorcDVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region '% Devoluciones vs Mes Anterior RUTA'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("((CAST(SUM(T.W) AS float)/SUM(T.Promedio4W))*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.RUTClave, CASE WHEN SUM(T.PzasPedidos) > 0 THEN (CAST(SUM(T.PzasDev) AS float)/SUM(T.PzasPedidos))-SUM(T.PzasDev)*100 else 0 end AS W, 0 AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidos, 0 AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, 0 AS PzasPedido, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 3 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "')GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.RUTClave, 0 AS W, SUM(T.PromedioSemana)/4 AS Promedio4W FROM ( --sumar el promedio de todas las semanas y dividir entre 4 ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.wk, CASE WHEN SUM(T.PzasPedido) > 0 THEN ((CAST(SUM(T.PzasDev) AS float)/SUM(T.PzasPedido))-SUM(T.PzasDev))*100 else 0 end AS PromedioSemana FROM ( --calcular el promedio por semana ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, DATEPART(WK, D.FechaCaptura) AS wk, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedido, 0 AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, DATEPART(WK, D.FechaCaptura) AS wk, 0 AS PzasPedido, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 3 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.wk, T.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                QueryString = sConsulta.ToString();
                oDevVSMesAnteriorRUTAS = Connection.Query<ScoreCardPorcDVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region '% Devoluciones vs Mes Anterior CEDI ESQUEMAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("((CAST(SUM(T.W) AS float)/SUM(T.Promedio4W))*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, CASE WHEN SUM(T.PzasPedidos) > 0 THEN (CAST(SUM(T.PzasDev) AS float)/SUM(T.PzasPedidos))-SUM(T.PzasDev)*100 else 0 end AS W, 0 AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidos, 0 AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasPedido, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 3 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, 0 AS W, SUM(T.PromedioSemana)/4 AS Promedio4W FROM ( --sumar el promedio de todas las semanas y dividir entre 4 ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, T.wk, CASE WHEN SUM(T.PzasPedido) > 0 THEN ((CAST(SUM(T.PzasDev) AS float)/SUM(T.PzasPedido))-SUM(T.PzasDev))*100 else 0 end AS PromedioSemana FROM ( --calcular el promedio por semana ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, DATEPART(WK, D.FechaCaptura) AS wk, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedido, 0 AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, DATEPART(WK, D.FechaCaptura) AS wk, 0 AS PzasPedido, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 3 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.wk, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("ORDER BY T.Nombre ");
                QueryString = sConsulta.ToString();
                oDevVSMesAnteriorEsqCEDI = Connection.Query<ScoreCardPorcDVSMACE>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region '% Devoluciones vs Mes Anterior RUTAS ESQUEMAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("((CAST(SUM(T.W) AS float)/SUM(T.Promedio4W))*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, CASE WHEN SUM(T.PzasPedidos) > 0 THEN (CAST(SUM(T.PzasDev) AS float)/SUM(T.PzasPedidos))-SUM(T.PzasDev)*100 else 0 end AS W, 0 AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidos, 0 AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, 0 AS PzasPedido, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 3 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, 0 AS W, SUM(T.PromedioSemana)/4 AS Promedio4W FROM ( --sumar el promedio de todas las semanas y dividir entre 4 ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.wk, CASE WHEN SUM(T.PzasPedido) > 0 THEN ((CAST(SUM(T.PzasDev) AS float)/SUM(T.PzasPedido))-SUM(T.PzasDev))*100 else 0 end AS PromedioSemana FROM ( --calcular el promedio por semana ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, DATEPART(WK, D.FechaCaptura) AS wk, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedido, 0 AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, DATEPART(WK, D.FechaCaptura) AS wk, 0 AS PzasPedido, ISNULL(SUM(TPD.Cantidad*PRODE.Factor), 0) AS PzasDev ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 3 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.wk, T.RUTClave, T.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID ");
                QueryString = sConsulta.ToString();
                oDevVSMesAnteriorEsqRUTAS = Connection.Query<ScoreCardPorcDVSMARE>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region '% Cobertura vs Mes Anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) > 0 THEN (CAST(SUM(T.W) AS float)/SUM(T.Promedio4W)*100)-100 else 0 end AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT CASE WHEN SUM(T.PzasPedidosGral) > 0 THEN CAST(SUM(T.PzasPedidosEsq) AS float)/SUM(T.PzasPedidosGral)*100 else 0 end AS W, 0 AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosEsq, 0 AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS PzasPedidosEsq, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS W, CAST(SUM(T.Promedio4W) AS float)/4 AS Promedio4W FROM ( --sumar cada semanada y dividir entre 4 ");
                sConsulta.AppendLine("SELECT T.wk, CASE WHEN SUM(T.PzasPedidosGral) > 0 THEN CAST(SUM(T.PzasPedidosEsq) AS float)/SUM(T.PzasPedidosGral)*100 else 0 end AS Promedio4W FROM ( --calcular el promedio por semana ");
                sConsulta.AppendLine("SELECT DATEPART(WK, D.FechaCaptura) AS wk, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosEsq, 0 AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura) ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT DATEPART(WK, D.FechaCaptura) AS wk, 0 AS PzasPedidosEsq, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura) ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.wk ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine(") AS T ");
                QueryString = sConsulta.ToString();
                oCoberturaVSMesAnteriorCEDI = Connection.Query<ScoreCardPorcCVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region '% Cobertura vs Mes Anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) > 0 THEN (CAST(SUM(T.W) AS float)/SUM(T.Promedio4W)*100)-100 else 0 end AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.RUTClave, CASE WHEN SUM(T.PzasPedidosGral) > 0 THEN CAST(SUM(T.PzasPedidosEsq) AS float)/SUM(T.PzasPedidosGral)*100 else 0 end AS W, 0 AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosEsq, 0 AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, 0 AS PzasPedidosEsq, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.RUTClave, 0 AS W, CAST(SUM(T.Promedio4W) AS float)/4 AS Promedio4W FROM ( --sumar cada semanada y dividir entre 4 ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.wk, CASE WHEN SUM(T.PzasPedidosGral) > 0 THEN CAST(SUM(T.PzasPedidosEsq) AS float)/SUM(T.PzasPedidosGral)*100 else 0 end AS Promedio4W FROM ( --calcular el promedio por semana ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, DATEPART(WK, D.FechaCaptura) AS wk, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosEsq, 0 AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, DATEPART(WK, D.FechaCaptura) AS wk, 0 AS PzasPedidosEsq, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.wk, T.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                QueryString = sConsulta.ToString();
                oCoberturaVSMesAnteriorRUTAS = Connection.Query<ScoreCardPorcCVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas - % Cobertura vs Mes Anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("(CAST(SUM(T.W) AS float)/SUM(T.Promedio4W)*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, CASE WHEN SUM(T.PzasPedidosGral) > 0 THEN CAST(SUM(T.PzasPedidosEsq) AS float)/SUM(T.PzasPedidosGral)*100 else 0 end AS W, 0 AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosEsq, 0 AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasPedidosEsq, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, 0 AS W, CAST(SUM(T.Promedio4W) AS float)/4 AS Promedio4W FROM ( --sumar cada semanada y dividir entre 4 ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, T.wk, CASE WHEN SUM(T.PzasPedidosGral) > 0 THEN CAST(SUM(T.PzasPedidosEsq) AS float)/SUM(T.PzasPedidosGral)*100 else 0 end AS Promedio4W FROM ( --calcular el promedio por semana ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, DATEPART(WK, D.FechaCaptura) AS wk, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosEsq, 0 AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, DATEPART(WK, D.FechaCaptura) AS wk, 0 AS PzasPedidosEsq, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.wk, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("ORDER BY T.Nombre ");
                QueryString = sConsulta.ToString();
                oCoberturaVSMesAnteriorEsqCEDI = Connection.Query<ScoreCardPorcCVSMACE>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas - % Cobertura vs Mes Anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("(CAST(SUM(T.W) AS float)/SUM(T.Promedio4W)*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, CASE WHEN SUM(T.PzasPedidosGral) > 0 THEN CAST(SUM(T.PzasPedidosEsq) AS float)/SUM(T.PzasPedidosGral)*100 else 0 end AS W, 0 AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosEsq, 0 AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre, VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre, 0 AS PzasPedidosEsq, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre, VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, 0 AS W, CAST(SUM(T.Promedio4W) AS float)/4 AS Promedio4W FROM ( --sumar cada semanada y dividir entre 4 ");
                sConsulta.AppendLine("SELECT T.RUTClave, T.EsquemaID, T.Nombre, T.wk, CASE WHEN SUM(T.PzasPedidosGral) > 0 THEN CAST(SUM(T.PzasPedidosEsq) AS float)/SUM(T.PzasPedidosGral)*100 else 0 end AS Promedio4W FROM ( --calcular el promedio por semana ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre, DATEPART(WK, D.FechaCaptura) AS wk, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosEsq, 0 AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre, DATEPART(WK, D.FechaCaptura) AS wk, 0 AS PzasPedidosEsq, SUM(TPD.Cantidad*PRODE.Factor) AS PzasPedidosGral ");
                sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID WHERE TRP.Tipo = 1 WHERE TRP.TipoFase = 1 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CLIESQ (NOLOCK) ON TRP.ClienteClave = CLIESQ.ClienteClave WHERE CLIESQ.TipoEstado = 1 ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ (NOLOCK) ON CLIESQ.EsquemaID = ESQ.EsquemaID WHERE ESQ.EsquemaID IN (SELECT * FROM dbo.BuscaIdsEsquema(ESQ.EsquemaID)) WHERE ESQ.Nivel = 1 ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON TPD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON TPD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave, ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.wk, T.RUTClave, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine("ORDER BY T.Nombre ");
                QueryString = sConsulta.ToString();
                oCoberturaVSMesAnteriorEsqRUTAS = Connection.Query<ScoreCardPorcCVSMARE>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Sell Out vs Mes Anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("(CAST(SUM(T.W) AS float)/SUM(T.Promedio4W)*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT ISNULL(SUM(IMD.Desplazamiento * PRODE.Factor), 0) AS W, 0 AS Promedio4W FROM InventarioMercadeo IM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN InventarioMercadeoDetalle IMD (NOLOCK) ON IM.InventarioID = IMD.InventarioID ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON IMD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = IMD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON IMD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON IM.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT 0 AS W, ISNULL(CAST(SUM(T.Desplazamiento) AS float)/4, 0) AS Promedio4W FROM ( --sumar todas las semanas y dividir entre 4 ");
                sConsulta.AppendLine("SELECT DATEPART(WK, D.FechaCaptura) AS wk, ISNULL(SUM(IMD.Desplazamiento * PRODE.Factor), 0) AS Desplazamiento --calcular el desplazamiento por semana ");
                sConsulta.AppendLine("FROM InventarioMercadeo IM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN InventarioMercadeoDetalle IMD (NOLOCK) ON IM.InventarioID = IMD.InventarioID ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON IMD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = IMD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON IMD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON IM.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura) ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine(") AS T ");
                QueryString = sConsulta.ToString();
                oSelloutVSMesAntCEDI = Connection.Query<ScoreCardSOVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Sell Out vs Mes Anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.RUTClave, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("(CAST(SUM(T.W) AS float)/SUM(T.Promedio4W)*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, ISNULL(SUM(IMD.Desplazamiento * PRODE.Factor), 0) AS W, 0 AS Promedio4W FROM InventarioMercadeo IM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN InventarioMercadeoDetalle IMD (NOLOCK) ON IM.InventarioID = IMD.InventarioID ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON IMD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = IMD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON IMD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON IM.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.RUTClave, 0 AS W, ISNULL(CAST(SUM(T.Desplazamiento) AS float)/4, 0) AS Promedio4W FROM ( --sumar todas las semanas y dividir entre 4 ");
                sConsulta.AppendLine("SELECT VIS.RUTClave, DATEPART(WK, D.FechaCaptura) AS wk, ISNULL(SUM(IMD.Desplazamiento * PRODE.Factor), 0) AS Desplazamiento --calcular el desplazamiento por semana ");
                sConsulta.AppendLine("FROM InventarioMercadeo IM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN InventarioMercadeoDetalle IMD (NOLOCK) ON IM.InventarioID = IMD.InventarioID ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON IMD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = IMD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON IMD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON IM.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave ");
                QueryString = sConsulta.ToString();
                oSelloutVSMesAntRUTAS = Connection.Query<ScoreCardSOVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Esquemas - Sell Out vs Mes Anterior CEDI'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("(CAST(SUM(T.W) AS float)/SUM(T.Promedio4W)*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, ISNULL(SUM(IMD.Desplazamiento * PRODE.Factor), 0) AS W, 0 AS Promedio4W FROM InventarioMercadeo IM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN InventarioMercadeoDetalle IMD (NOLOCK) ON IM.InventarioID = IMD.InventarioID ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON IMD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = IMD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON IMD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON IM.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.Nombre, 0 AS W, ISNULL(CAST(SUM(T.Desplazamiento) AS float)/4, 0) AS Promedio4W FROM ( --sumar todas las semanas y dividir entre 4 ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, ESQ2.Nombre, DATEPART(WK, D.FechaCaptura) AS wk, ISNULL(SUM(IMD.Desplazamiento * PRODE.Factor), 0) AS Desplazamiento --calcular el desplazamiento por semana ");
                sConsulta.AppendLine("FROM InventarioMercadeo IM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN InventarioMercadeoDetalle IMD (NOLOCK) ON IM.InventarioID = IMD.InventarioID ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON IMD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = IMD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON IMD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON IM.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "' ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), ESQ2.EsquemaID, ESQ2.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.EsquemaID, T.Nombre ");
                QueryString = sConsulta.ToString();
                oSelloutVSMesAntEsqCEDI = Connection.Query<ScoreCardESOVSMAC>(QueryString, null, null, true, 600).ToList();
                #endregion

                #region 'Sell Out vs Mes Anterior RUTAS'
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT T.EsquemaID, T.RUTClave, SUM(T.W) AS W, CASE WHEN SUM(T.Promedio4W) = 0 THEN 0 ELSE ");
                sConsulta.AppendLine("(CAST(SUM(T.W) AS float)/SUM(T.Promedio4W)*100)-100 END AS Promedio4W FROM ( ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, VIS.RUTClave, ISNULL(SUM(IMD.Desplazamiento * PRODE.Factor), 0) AS W, 0 AS Promedio4W FROM InventarioMercadeo IM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN InventarioMercadeoDetalle IMD (NOLOCK) ON IM.InventarioID = IMD.InventarioID ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON IMD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = IMD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON IMD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON IM.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) = DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT T.EsquemaID, T.RUTClave, 0 AS W, ISNULL(CAST(SUM(T.Desplazamiento) AS float)/4, 0) AS Promedio4W FROM ( --sumar todas las semanas y dividir entre 4 ");
                sConsulta.AppendLine("SELECT ESQ2.EsquemaID, VIS.RUTClave, DATEPART(WK, D.FechaCaptura) AS wk, ISNULL(SUM(IMD.Desplazamiento * PRODE.Factor), 0) AS Desplazamiento --calcular el desplazamiento por semana ");
                sConsulta.AppendLine("FROM InventarioMercadeo IM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN InventarioMercadeoDetalle IMD (NOLOCK) ON IM.InventarioID = IMD.InventarioID ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle PRODE (NOLOCK) ON IMD.ProductoClave = PRODE.ProductoClave WHERE PRODE.ProductoDetClave = IMD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoEsquema PROESQ (NOLOCK) ON IMD.ProductoClave = PROESQ.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Esquema ESQ2 (NOLOCK) ON PROESQ.EsquemaID = ESQ2.EsquemaID WHERE ESQ2.Nivel = 2 " + filtroEsquemaProd);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON IM.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON D.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCDH (NOLOCK) ON VCDH.VendedorId = VEN.VendedorID WHERE D.FechaCaptura BETWEEN VCDH.VCHFechaInicial WHERE VCDH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCDH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("WHERE DATEPART(WK, D.FechaCaptura) BETWEEN DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-4 WHERE DATEPART(WK, '" + dFechaIni.Date.ToString("s") + "')-1 ");
                sConsulta.AppendLine("WHERE DATEPART(YYYY, D.FechaCaptura) = DATEPART(YYYY, '" + dFechaIni.Date.ToString("s") + "') ");
                sConsulta.AppendLine("WHERE VIS.RUTClave IN (SELECT VRUT.RUTClave FROM Almacen ALM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCD (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN VenRut VRUT (NOLOCK) ON VRUT.VendedorID = VCD.VendedorId ");
                sConsulta.AppendLine("WHERE ALM.AlmacenID = '" + AlmacenClave + "') ");
                sConsulta.AppendLine("GROUP BY DATEPART(WK, D.FechaCaptura), VIS.RUTClave, ESQ2.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY T.RUTClave, T.EsquemaID ");
                QueryString = sConsulta.ToString();
                oSelloutVSMesAntEsqRUTAS = Connection.Query<ScoreCardESOVSMAR>(QueryString, null, null, true, 600).ToList();
                #endregion


                ArchivoXlsModel file = GenerarExcel();
                DownloadFile.DownloadOpenXML(file);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private ArchivoXlsModel GenerarExcel()
        {
            string fileName = "ScoreCard_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "ScoreCard" };
            sheets.Append(sheet);

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            Dictionary<int, Row> Rows = new Dictionary<int, Row>();
            //Dictionary<string, float> totalesAlmacen = new Dictionary<string, float>();
            //Dictionary<string, float> totalesRuta = new Dictionary<string, float>();
            //Dictionary<string, float> totalesConsigna = new Dictionary<string, float>();
            //Dictionary<int, string> tiposMov = new Dictionary<int, string>();

            MyOpenXML.createRow(2, ref Rows);
            MyOpenXML.createCell(2, ref Rows, "B2", CellValues.String, ValorReferencia.ObtenerDescripcion("REPORTEW", "138", "EM"));

            //FILTROS
            MyOpenXML.createRow(5, ref Rows);
            MyOpenXML.createCell(5, ref Rows, "B5", CellValues.String, Mensaje.ObtenerDescripcion("XCEDI", "EM") + ":");
            MyOpenXML.createCell(5, ref Rows, "D5", CellValues.String, sAlmacenNombre);

            MyOpenXML.createRow(6, ref Rows);
            MyOpenXML.createCell(6, ref Rows, "B6", CellValues.String, Mensaje.ObtenerDescripcion("XEsquemasProducto", "EM") + ":");
            MyOpenXML.createCell(6, ref Rows, "D6", CellValues.String, sEsquemasNombre);

            MyOpenXML.createRow(7, ref Rows);
            MyOpenXML.createCell(7, ref Rows, "B7", CellValues.String, Mensaje.ObtenerDescripcion("XSemana", "EM") + ":");
            MyOpenXML.createCell(7, ref Rows, "D7", CellValues.String, "W" + oSemana[0].Semana.ToString());
            MyOpenXML.createCell(7, ref Rows, "E7", CellValues.String, oSemana[0].InicioSemana.ToShortDateString());
            MyOpenXML.createCell(7, ref Rows, "F7", CellValues.String, "AL");
            MyOpenXML.createCell(7, ref Rows, "G7", CellValues.String, oSemana[0].FinSemana.ToShortDateString());

            //ENCABEZADO CEDI + RUTAS
            MyOpenXML.createRow(9, ref Rows);
            MyOpenXML.createCell(9, ref Rows, "B9", CellValues.String, Mensaje.ObtenerDescripcion("XConcepto", "EM"));
            MyOpenXML.createCell(9, ref Rows, "D9", CellValues.String, Mensaje.ObtenerDescripcion("XCEDI", "EM"));

            int column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                MyOpenXML.createCell(9, ref Rows, GetExcelColumnName(column) + "9", CellValues.String, oRuta.Descripcion);
                column += 2;
            }

            column = 6;
            string sSemana = "W" + oSemana[0].Semana.ToString();
            string sPromedioW4 = Mensaje.ObtenerDescripcion("XPromedio4W", "EM");

            MyOpenXML.createRow(10, ref Rows);
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                MyOpenXML.createCell(10, ref Rows, GetExcelColumnName(column) + "10", CellValues.String, sSemana);
                column += 1;
                MyOpenXML.createCell(10, ref Rows, GetExcelColumnName(column) + "10", CellValues.String, sPromedioW4);
                column += 1;
            }

            //Clientes agenda vs mes anterior
            MyOpenXML.createRow(12, ref Rows);
            MyOpenXML.createCell(12, ref Rows, "A12", CellValues.String, Mensaje.ObtenerDescripcion("XCliAgeVSAnt", "EM"));

            string sXEfectividadVenta = Mensaje.ObtenerDescripcion("XEfectividadVenta", "EM");
            string sXMal = Mensaje.ObtenerDescripcion("XMal", "EM");
            string sXEfectividadVisita = Mensaje.ObtenerDescripcion("XEfectividadVisita", "EM");
            string sXTotalMin = Mensaje.ObtenerDescripcion("XTotalMin", "EM");
            string sXBien = Mensaje.ObtenerDescripcion("XBien", "EM");

            int nRow = 13;
            foreach (ScoreCardCAVSMAC oAVSAC in oAgendaVSAnteriorCEDI)
            {
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, oAVSAC.Nombre);
                MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oAVSAC.W.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oAVSAC.Promedio4W, 2).ToString() + "%");
                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oAgendaVSAnteriorRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave && x.EsquemaID == oAVSAC.EsquemaID))
                    {
                        ScoreCardCAVSMAR oAVSAR = oAgendaVSAnteriorRUTAS.First(x => x.RUTClave == oRuta.RUTClave && x.EsquemaID == oAVSAC.EsquemaID);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oAVSAR.W.ToString());
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oAVSAR.Promedio4W, 2).ToString() + "%");
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    }
                    column += 1;
                }
                nRow += 1;

                //Efectividad de venta rutas
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, sXEfectividadVenta);
                if (oEfectividadVentaCEDI.Exists(x => x.EsquemaID == oAVSAC.EsquemaID))
                {
                    ScoreCardEVC oEVC = oEfectividadVentaCEDI.First(x => x.EsquemaID == oAVSAC.EsquemaID);
                    MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, Math.Round(oEVC.W, 2).ToString() + "%");
                    MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, oEVC.Promedio4W.ToString());
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, "0%");
                    MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, sXMal);
                }

                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oEfectividadVentaRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave && x.EsquemaID == oAVSAC.EsquemaID))
                    {
                        ScoreCardEVR oEVR = oEfectividadVentaRUTAS.First(x => x.RUTClave == oRuta.RUTClave && x.EsquemaID == oAVSAC.EsquemaID);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oEVR.W, 2).ToString() + "%");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oEVR.Promedio4W.ToString());
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, sXMal);
                    }
                    column += 1;
                }
                nRow += 1;

                //Efectividad de visita rutas
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, sXEfectividadVisita);
                if (oEfectividadVisitaCEDI.Exists(x => x.EsquemaID == oAVSAC.EsquemaID))
                {
                    ScoreCardEVSC oEVC = oEfectividadVisitaCEDI.First(x => x.EsquemaID == oAVSAC.EsquemaID);
                    MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, Math.Round(oEVC.W, 2).ToString() + "%");
                    MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, oEVC.Promedio4W.ToString());
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, "0%");
                    MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, sXMal);
                }

                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oEfectividadVisitaRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave && x.EsquemaID == oAVSAC.EsquemaID))
                    {
                        ScoreCardEVSR oEVR = oEfectividadVisitaRUTAS.First(x => x.RUTClave == oRuta.RUTClave && x.EsquemaID == oAVSAC.EsquemaID);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oEVR.W, 2).ToString() + "%");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oEVR.Promedio4W.ToString());
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, sXMal);
                    }
                    column += 1;
                }
                nRow += 2;
            }

            //Totales 
            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, sXTotalMin);
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oAgendaVSAnteriorCEDI.Sum(x => x.W).ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oAgendaVSAnteriorCEDI.Average(x => x.Promedio4W), 2).ToString() + "%");

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oAgendaVSAnteriorRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oAgendaVSAnteriorRUTAS.Where(x => x.RUTClave == oRuta.RUTClave).Sum(x => x.W).ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oAgendaVSAnteriorRUTAS.Where(x => x.RUTClave == oRuta.RUTClave).Average(x => x.Promedio4W), 2).ToString() + "%");
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                }
                column += 1;
            }
            nRow += 1;

            //Efectividad de venta totales
            MyOpenXML.createRow(nRow, ref Rows);
            float total = oEfectividadVentaCEDI.Average(x => x.W);
            MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, sXEfectividadVenta);
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, total.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, (total > 80 ? sXBien : sXMal));

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oEfectividadVentaRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    total = oEfectividadVentaRUTAS.Where(x => x.RUTClave == oRuta.RUTClave).Average(x => x.W);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, total.ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, (total > 80 ? sXBien : sXMal));
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, sXMal);
                }
                column += 1;
            }
            nRow += 1;

            //Efectividad de visita totales
            MyOpenXML.createRow(nRow, ref Rows);
            total = oEfectividadVisitaCEDI.Average(x => x.W);
            MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, sXEfectividadVisita);
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, total.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, (total > 80 ? sXBien : sXMal));

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oEfectividadVisitaRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    total = oEfectividadVisitaRUTAS.Where(x => x.RUTClave == oRuta.RUTClave).Average(x => x.W);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, total.ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, (total > 80 ? sXBien : sXMal));
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, sXMal);
                }
                column += 1;
            }
            nRow += 2;

            //Venta vs mes anterior
            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XVentaVSMesAnt", "EM"));
            nRow += 1;

            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XTotalVtaSemVSProm", "EM"));
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oVentaSemanalVSPromedioCEDI[0].TotalVtaVSPromedioW.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oVentaSemanalVSPromedioCEDI[0].TotalVtaVSPromedio4W, 2).ToString() + "%");

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oVentaSemanalVSPromedioRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    ScoreCardTVSVSPR oVSVSPR = oVentaSemanalVSPromedioRUTAS.First(x => x.RUTClave == oRuta.RUTClave);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oVSVSPR.TotalVtaVSPromedioW.ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oVSVSPR.TotalVtaVSPromedio4W, 2).ToString() + "%");
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                }
                column += 1;
            }
            nRow += 1;

            //Esquemas
            foreach (ScoreCardEC oEC in oEsquemasCEDI)
            {
                //Dim valoresEsquemaRutas AS String = vbTab & vbTab & dr("TotalVtaVSPromedioW") & vbTab & Math.Round(dr("TotalVtaVSPromedio4W"), 2) & "%"
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, oEC.Nombre);
                MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oEC.TotalVtaVSPromedioW.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oEC.TotalVtaVSPromedio4W, 2).ToString() + "%");

                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oClientesVentaVSMesAnteriorEsqRUTAS.Exists(x => x.EsquemaID == oEC.EsquemaID && x.RUTClave == oRuta.RUTClave))
                    {
                        ScoreCardECCVVSMAR oCVVSMAR = oClientesVentaVSMesAnteriorEsqRUTAS.First(x => x.EsquemaID == oEC.EsquemaID && x.RUTClave == oRuta.RUTClave);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oCVVSMAR.W.ToString());
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oCVVSMAR.Promedio4W, 2).ToString() + "%");
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    }
                    column += 1;
                }
                nRow += 1;
            }
            nRow += 1;

            //MIX BODDA
            string sXArriba = Mensaje.ObtenerDescripcion("XArriba", "EM");
            string sXAbajo = Mensaje.ObtenerDescripcion("XAbajo", "EM");

            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, "MIX BODDA");
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, Math.Round(oMixBoddaCEDI[0].TotalVtaVSPromedioW, 2).ToString() + "%");
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, oMixBoddaCEDI[0].TotalVtaVSPromedio4W.ToString());
            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oMixBoddaRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    ScoreCardMBR oMBR = oMixBoddaRUTAS.First(x => x.RUTClave == oRuta.RUTClave);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oMBR.TotalVtaVSPromedioW, 2).ToString() + "%");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oMBR.TotalVtaVSPromedio4W.ToString());
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, sXArriba);
                }
                column += 1;
            }
            nRow += 1;

            //VS RECORD
            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, "VS RECORD");
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, Math.Round(oMixBoddaCEDI[0].TotalVtaVSPromedioW, 2).ToString() + "%");
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, (oMixBoddaCEDI[0].TotalVtaVSPromedioW >= 0 ? sXAbajo : sXArriba));
            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oMixBoddaRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    ScoreCardMBR oMBR = oMixBoddaRUTAS.First(x => x.RUTClave == oRuta.RUTClave);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oMBR.TotalVtaVSPromedioW, 2).ToString() + "%");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, (oMBR.TotalVtaVSPromedioW >= 0 ? sXAbajo : sXArriba));
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, sXAbajo);
                }
                column += 1;
            }
            nRow += 2;

            //Clientes con venta vs mes anterior
            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XClientesVtaVSMesAnt", "EM"));
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oClientesVentaVSMesAnteriorCEDI[0].W.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oClientesVentaVSMesAnteriorCEDI[0].Promedio4W, 2).ToString() + "%");

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oClientesVentaVSMesAnteriorRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    ScoreCardCCVVSMAR oCVVSMAR = oClientesVentaVSMesAnteriorRUTAS.First(x => x.RUTClave == oRuta.RUTClave);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oCVVSMAR.W.ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oCVVSMAR.Promedio4W, 2).ToString() + "%");
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                }
                column += 1;
            }
            nRow += 1;

            //Esquemas
            foreach (ScoreCardECCVVSMAC oCVVSMAEC in oClientesVentaVSMesAnteriorEsqCEDI)
            {
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, oCVVSMAEC.Nombre);
                MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oCVVSMAEC.W.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oCVVSMAEC.Promedio4W, 2).ToString() + "%");

                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oClientesVentaVSMesAnteriorEsqRUTAS.Exists(x => x.EsquemaID == oCVVSMAEC.EsquemaID && x.RUTClave == oRuta.RUTClave))
                    {
                        ScoreCardECCVVSMAR oCVVSMAER = oClientesVentaVSMesAnteriorEsqRUTAS.First(x => x.EsquemaID == oCVVSMAEC.EsquemaID && x.RUTClave == oRuta.RUTClave);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, oCVVSMAER.W.ToString());
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(oCVVSMAER.Promedio4W, 2).ToString() + "%");
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    }
                    column += 1;
                }
                nRow += 1;
            }
            nRow += 1;

            //Drop size vs mes anterior
            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XDropSizeVSMesAnt", "EM"));
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oDropSizeVsMesAnteriorCEDI[0].W.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oDropSizeVsMesAnteriorCEDI[0].Promedio4W, 2).ToString() + "%");

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oDropSizeVsMesAnteriorRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    ScoreCardDSVSMAR obj = oDropSizeVsMesAnteriorRUTAS.First(x => x.RUTClave == oRuta.RUTClave);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, obj.W.ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(obj.Promedio4W, 2).ToString() + "%");
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                }
                column += 1;
            }
            nRow += 1;

            //Esquemas
            foreach (ScoreCardEDSVSMAC obj in oDropSizeVsMesAnteriorEsqCEDI)
            {
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, obj.Nombre);
                MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, obj.W.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(obj.Promedio4W, 2).ToString() + "%");

                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oDropSizeVsMesAnteriorEsqRUTAS.Exists(x => x.EsquemaID == obj.EsquemaID && x.RUTClave == oRuta.RUTClave))
                    {
                        ScoreCardEDSVSMAR obje = oDropSizeVsMesAnteriorEsqRUTAS.First(x => x.EsquemaID == obj.EsquemaID && x.RUTClave == oRuta.RUTClave);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, obje.W.ToString());
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(obje.Promedio4W, 2).ToString() + "%");
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    }
                    column += 1;
                }
                nRow += 1;
            }
            nRow += 1;

            //% Devoluciones vs Mes Anterior
            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("X%DevVSMesAnt", "EM"));
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oDevVSMesAnteriorCEDI[0].W.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oDevVSMesAnteriorCEDI[0].Promedio4W, 2).ToString() + "%");

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oDevVSMesAnteriorRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    ScoreCardPorcDVSMAR obj = oDevVSMesAnteriorRUTAS.First(x => x.RUTClave == oRuta.RUTClave);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, obj.W.ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(obj.Promedio4W, 2).ToString() + "%");
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                }
                column += 1;
            }
            nRow += 1;

            //Esquemas
            foreach (ScoreCardPorcDVSMACE obj in oDevVSMesAnteriorEsqCEDI)
            {
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, obj.Nombre);
                MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, obj.W.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(obj.PromedioW4, 2).ToString() + "%");

                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oDevVSMesAnteriorEsqRUTAS.Exists(x => x.EsquemaID == obj.EsquemaID && x.RUTClave == oRuta.RUTClave))
                    {
                        ScoreCardPorcDVSMARE obje = oDevVSMesAnteriorEsqRUTAS.First(x => x.EsquemaID == obj.EsquemaID && x.RUTClave == oRuta.RUTClave);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, obje.W.ToString());
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(obje.PromedioW4, 2).ToString() + "%");
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    }
                    column += 1;
                }
                nRow += 1;
            }
            nRow += 1;

            //% Cobertura vs Mes Anterior
            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("X%CoberturaVSMesAnt", "EM"));
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oCoberturaVSMesAnteriorCEDI[0].W.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oCoberturaVSMesAnteriorCEDI[0].PromedioW4, 2).ToString() + "%");

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oCoberturaVSMesAnteriorRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    ScoreCardPorcCVSMAR obj = oCoberturaVSMesAnteriorRUTAS.First(x => x.RUTClave == oRuta.RUTClave);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, obj.W.ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(obj.PromedioW4, 2).ToString() + "%");
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                }
                column += 1;
            }
            nRow += 1;

            //Esquemas
            foreach (ScoreCardPorcCVSMACE obj in oCoberturaVSMesAnteriorEsqCEDI)
            {
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, obj.Nombre);
                MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, obj.W.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(obj.PromedioW4, 2).ToString() + "%");

                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oCoberturaVSMesAnteriorEsqRUTAS.Exists(x => x.EsquemaID == obj.EsquemaID && x.RUTClave == oRuta.RUTClave))
                    {
                        ScoreCardPorcCVSMARE obje = oCoberturaVSMesAnteriorEsqRUTAS.First(x => x.EsquemaID == obj.EsquemaID && x.RUTClave == oRuta.RUTClave);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, obje.W.ToString());
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(obje.PromedioW4, 2).ToString() + "%");
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    }
                    column += 1;
                }
                nRow += 1;
            }
            nRow += 1;

            //Sell Out vs Mes Anterior
            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("SelloutVSMesAnt", "EM"));
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, oSelloutVSMesAntCEDI[0].W.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(oSelloutVSMesAntCEDI[0].PromedioW4, 2).ToString() + "%");

            column = 6;
            foreach (ScoreCardRutas oRuta in oRutas)
            {
                if (oSelloutVSMesAntRUTAS.Exists(x => x.RUTClave == oRuta.RUTClave))
                {
                    ScoreCardSOVSMAR obj = oSelloutVSMesAntRUTAS.First(x => x.RUTClave == oRuta.RUTClave);
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, obj.W.ToString());
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(obj.PromedioW4, 2).ToString() + "%");
                }
                else
                {
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                    column += 1;
                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                }
                column += 1;
            }
            nRow += 1;

            //Esquemas
            foreach (ScoreCardESOVSMAC obj in oSelloutVSMesAntEsqCEDI)
            {
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, obj.Nombre);
                MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.String, obj.W.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.String, Math.Round(obj.PromedioW4, 2).ToString() + "%");

                column = 6;
                foreach (ScoreCardRutas oRuta in oRutas)
                {
                    if (oSelloutVSMesAntEsqRUTAS.Exists(x => x.EsquemaID == obj.EsquemaID && x.RUTClave == oRuta.RUTClave))
                    {
                        ScoreCardESOVSMAR obje = oSelloutVSMesAntEsqRUTAS.First(x => x.EsquemaID == obj.EsquemaID && x.RUTClave == oRuta.RUTClave);
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, obje.W.ToString());
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, Math.Round(obje.PromedioW4, 2).ToString() + "%");
                    }
                    else
                    {
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0");
                        column += 1;
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(column) + nRow.ToString(), CellValues.String, "0%");
                    }
                    column += 1;
                }
                nRow += 1;
            }

            foreach (var row in Rows)
                sheetData.Append(row.Value);

            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;

            workbookPart.Workbook.Save();

            // Close the document.
            document.Close();

            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
        }//GenerarExcel


    }

    //Clientes agenda vs mes anterior CEDI
    class ScoreCardCAVSMAC
    {
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //efectividad venta CEDI
    class ScoreCardEVC
    {
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public String Promedio4W { get; set; }
    }

    //efectividad visita CEDI
    class ScoreCardEVSC
    {
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public String Promedio4W { get; set; }
    }

    //Clientes agenda vs mes anterior RUTAS
    class ScoreCardCAVSMAR
    {
        public String RUTClave { get; set; }
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //efectividad venta RUTAS
    class ScoreCardEVR
    {
        public String RUTClave { get; set; }
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public String Promedio4W { get; set; }
    }

    //efectividad visita RUTAS
    class ScoreCardEVSR
    {
        public String RUTClave { get; set; }
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public String Promedio4W { get; set; }
    }

    //consulta para calcular el numero de la semana y las fechas de inicio/fin
    class ScoreCardSemana
    {
        public int Semana { get; set; }
        public DateTime InicioSemana { get; set; }
        public DateTime FinSemana { get; set; }
    }

    //obtener las rutas del cedi seleccionado
    class ScoreCardRutas
    {
        public String RUTClave { get; set; }
        public String Descripcion { get; set; }
    }

    //total venta semanal vs promedio CEDI
    class ScoreCardTVSVSPC
    {
        public float TotalVtaVSPromedioW { get; set; }
        public float TotalVtaVSPromedio4W { get; set; }
    }

    //total venta semanal vs promedio Rutas
    class ScoreCardTVSVSPR
    {
        public String RUTClave { get; set; }
        public float TotalVtaVSPromedioW { get; set; }
        public float TotalVtaVSPromedio4W { get; set; }
    }

    //Esquemas CEDI
    class ScoreCardEC
    {
        public String Nombre { get; set; }
        public String EsquemaID { get; set; }
        public float TotalVtaVSPromedioW { get; set; }
        public float TotalVtaVSPromedio4W { get; set; }
    }

    //Esquemas Rutas
    class ScoreCardER
    {
        public String RUTClave { get; set; }
        public String EsquemaID { get; set; }
        public float TotalVtaVSPromedioW { get; set; }
        public float TotalVtaVSPromedio4W { get; set; }
    }

    //mix bodda CEDI
    class ScoreCardMBC
    {
        public float TotalVtaVSPromedioW { get; set; }
        public String TotalVtaVSPromedio4W { get; set; }
    }

    //mix bodda RUTAS
    class ScoreCardMBR
    {
        public String RUTClave { get; set; }
        public float TotalVtaVSPromedioW { get; set; }
        public String TotalVtaVSPromedio4W { get; set; }
    }

    //clientes con venta vs mes anterior CEDI
    class ScoreCardCCVVSMAC
    {
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //clientes con venta vs mes anterior Ruta
    class ScoreCardCCVVSMAR
    {
        public String RUTClave { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //Esquemas - clientes con venta vs mes anterior CEDI
    class ScoreCardECCVVSMAC
    {
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //Esquemas - clientes con venta vs mes anterior Ruta
    class ScoreCardECCVVSMAR
    {
        public String RUTClave { get; set; }
        public String EsquemaID { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //drop size vs mes anterior CEDI
    class ScoreCardDSVSMAC
    {
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //drop size vs mes anterior RUTAS
    class ScoreCardDSVSMAR
    {
        public String RUTClave { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //Esquemas - drop size vs mes anterior CEDI
    class ScoreCardEDSVSMAC
    {
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //Esquemas - drop size vs mes anterior RUTA
    class ScoreCardEDSVSMAR
    {
        public String RUTClave { get; set; }
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //% Devoluciones vs Mes Anterior CEDI
    class ScoreCardPorcDVSMAC
    {
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //% Devoluciones vs Mes Anterior RUTA
    class ScoreCardPorcDVSMAR
    {
        public String RUTClave { get; set; }
        public float W { get; set; }
        public float Promedio4W { get; set; }
    }

    //% Devoluciones vs Mes Anterior CEDI ESQUEMAS
    class ScoreCardPorcDVSMACE
    {
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //% Devoluciones vs Mes Anterior RUTA ESQUEMAS
    class ScoreCardPorcDVSMARE
    {
        public String RUTClave { get; set; }
        public String EsquemaID { get; set; }
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //% Cobertura vs Mes Anterior CEDI
    class ScoreCardPorcCVSMAC
    {
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //% Cobertura vs Mes Anterior RUTAS
    class ScoreCardPorcCVSMAR
    {
        public String RUTClave { get; set; }
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //Esquemas - % Cobertura vs Mes Anterior CEDI
    class ScoreCardPorcCVSMACE
    {
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //% Cobertura vs Mes Anterior RUTAS
    class ScoreCardPorcCVSMARE
    {
        public String RUTClave { get; set; }
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //Sell Out vs Mes Anterior CEDI
    class ScoreCardSOVSMAC
    {
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //Sell Out vs Mes Anterior RUTAS
    class ScoreCardSOVSMAR
    {
        public String RUTClave { get; set; }
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //Esquemas - Sell Out vs Mes Anterior CEDI
    class ScoreCardESOVSMAC
    {
        public String EsquemaID { get; set; }
        public String Nombre { get; set; }
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }

    //Esquemas´- Sell Out vs Mes Anterior RUTAS
    class ScoreCardESOVSMAR
    {
        public String EsquemaID { get; set; }
        public String RUTClave { get; set; }
        public float W { get; set; }
        public float PromedioW4 { get; set; }
    }
}
