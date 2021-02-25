using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Text;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class MIndicadoresDeVentaPDR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string Cedi, string FechaInicial, string FechaFinal, string Vendedor, string Ruta, string NombreCedis, string VendedorSplit, string RutasSplit)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();
                DateTime dFechaIni;
                DateTime.TryParse(FechaInicial, out dFechaIni);
                DateTime dFechaFin = dFechaIni;
                if (FechaFinal != "")
                    DateTime.TryParse(FechaFinal, out dFechaFin);
                dFechaFin = dFechaFin.Date.AddSeconds(86399);

                sConsulta.AppendLine("SELECT Fecha, Vendedor, Ruta, SUM(Itinerario) AS Itinerario, SUM(Visitados) AS Visitados, ");
                sConsulta.AppendLine("SUM(Eficiencia) AS Eficiencia, SUM(VisitadosVenta) AS VisitadosVenta, SUM(Efectividad) AS Efectividad, ");
                sConsulta.AppendLine("SUM(NoVisitados) AS NoVisitados, SUM(FueraFrecuencia) AS FueraFrecuencia, SUM(FueraFrecuenciaV) AS FueraFrecuenciaV, SUM(TotalVenta ) AS TotalVenta ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT Fecha, Vendedor, Ruta, Itinerario, Visitados, ");
                sConsulta.AppendLine("CASE Itinerario WHEN 0 THEN 0 ELSE (Eficiencia / CAST(Itinerario AS decimal(10, 5)))*100 END AS Eficiencia, ");
                sConsulta.AppendLine("VisitadosVenta, CASE Itinerario WHEN 0 THEN 0 ELSE Efectividad / CAST(Itinerario AS decimal(10, 5))*100 END AS Efectividad, ");
                sConsulta.AppendLine("CASE Itinerario WHEN 0 THEN 0 ELSE CAST(Itinerario AS decimal(10, 5)) - NoVisitados END AS NoVisitados, ");
                sConsulta.AppendLine("FueraFrecuencia, FueraFrecuenciaV, ISNULL(TotalVenta, 0) AS TotalVenta, DiaClave, VendedorID, RUTClave ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT CONVERT(varchar, VIS.FechaHoraInicial, 103) AS Fecha, VEN.Nombre AS Vendedor, RUT.Descripcion AS Ruta, ");
                sConsulta.AppendLine("(SELECT COUNT(DISTINCT AG.ClienteClave) FROM AgendaVendedor AG (NOLOCK) WHERE VIS.VendedorID = AG.VendedorId AND VIS.DiaClave = AG.DiaClave AND VIS.RUTClave = AG.RUTClave) AS Itinerario, ");
                sConsulta.AppendLine("COUNT(DISTINCT VIS.ClienteClave) AS Visitados, CAST(COUNT(DISTINCT VIS.ClienteClave) AS decimal(10, 5)) AS Eficiencia, ");
                sConsulta.AppendLine("COUNT(DISTINCT CASE WHEN TRP.TransProdID IS NOT NULL THEN VIS.ClienteClave END) AS VisitadosVenta, ");
                sConsulta.AppendLine("CAST(COUNT(DISTINCT CASE WHEN TRP.TransProdID IS NOT NULL THEN VIS.ClienteClave END) AS decimal(10, 5)) AS Efectividad, ");
                sConsulta.AppendLine("(COUNT(DISTINCT VIS.ClienteClave)) AS NoVisitados, (0) AS FueraFrecuencia, (0) AS FueraFrecuenciaV, SUM(TRP.Total) AS TotalVenta, VIS.DiaClave, VIS.VendedorID, VIS.RUTClave ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND VIS.FechaHoraInicial BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON ALM.AlmacenID = VCH.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = VIS.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase<>0");
                sConsulta.AppendLine("WHERE VIS.FueraFrecuencia = 0 ");
                if (Vendedor != "")
                    sConsulta.AppendLine("AND VEN.VendedorId IN (" + Vendedor + ") ");
                //if (FechaFinal != "null")
                    sConsulta.AppendLine("AND CONVERT(datetime, CONVERT(varchar(20), VIS.FechaHoraInicial, 112)) BETWEEN '" + dFechaIni.ToString("s") + "' AND '" + dFechaFin.ToString("s") + "' ");
                //else
                //    sConsulta.AppendLine("AND CONVERT(datetime, CONVERT(varchar(20), VIS.FechaHoraInicial, 112)) > '" + dFechaIni.ToString("s") + "' ");
                if (Ruta != "null" && Ruta != "")
                    sConsulta.AppendLine("AND RUT.RUTClave IN (" + Ruta + ") ");
                sConsulta.AppendLine("AND ALM.AlmacenID = '" + Cedi + "' ");
                sConsulta.AppendLine("GROUP BY CONVERT(varchar, VIS.FechaHoraInicial, 103), VEN.Nombre, RUT.Descripcion, VIS.DiaClave, VIS.VendedorID, VIS.RUTClave ");
                sConsulta.AppendLine(") AS Tabla ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("SELECT CONVERT(varchar, VIS.FechaHoraInicial, 103) AS Fecha, VEN.Nombre AS Vendedor, RUT.Descripcion AS Ruta, (0) AS Itinerario, (0) AS Visitados, (0) AS Eficiencia, ");
                sConsulta.AppendLine("(0)as VisitadosVenta, (0) AS Efectividad, (0) AS NoVisitados, COUNT(DISTINCT VIS.ClienteClave) AS FueraFrecuencia, COUNT(DISTINCT CASE WHEN TRP.TransProdID IS NOT NULL THEN VIS.ClienteClave END)as FueraFrecuenciaV, ");
                sConsulta.AppendLine("(0) AS TotalVenta, VIS.DiaClave, VIS.VendedorID, VIS.RUTClave ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND VIS.FechaHoraInicial ");
                sConsulta.AppendLine("BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON ALM.AlmacenID = VCH.AlmacenId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = VIS.RUTClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase<>0 ");
                sConsulta.AppendLine("WHERE VIS.FueraFrecuencia = 1 ");
                if (Vendedor != "" )
                    sConsulta.AppendLine("AND VEN.VendedorId IN (" + Vendedor + ") ");
                //if (FechaFinal != "null")
                    sConsulta.AppendLine("AND CONVERT(datetime, CONVERT(varchar(20), VIS.FechaHoraInicial, 112)) BETWEEN '" + dFechaIni.ToString("s") + "' AND '" + dFechaFin.ToString("s") + "' ");
                //else
                //    sConsulta.AppendLine("AND CONVERT(datetime, CONVERT(varchar(20), VIS.FechaHoraInicial, 112)) > '" + dFechaIni.ToString("s") + "' ");
                if (Ruta != "null" && Ruta != "")
                    sConsulta.AppendLine("AND RUT.RUTClave IN (" + Ruta + ") ");
                sConsulta.AppendLine("AND ALM.AlmacenID = '" + Cedi + "' ");
                sConsulta.AppendLine("GROUP BY CONVERT(varchar, VIS.FechaHoraInicial, 103), VEN.Nombre, RUT.Descripcion, VIS.DiaClave, VIS.VendedorID, VIS.RUTClave ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("GROUP BY Fecha, Vendedor, Ruta ");
                sConsulta.AppendLine("order by Ruta, CONVERT(DATETIME, Fecha, 103)");

                QueryString = sConsulta.ToString();

                IndicadoresDeVentaPDR report = new IndicadoresDeVentaPDR(QueryString);
                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                string sNombreEmpresa = Connection.Query<string>("SELECT NombreEmpresa FROM Configuracion (NOLOCK)", null, null, true, 9000).FirstOrDefault();
                report.lbNombre.Text = sNombreEmpresa;
                report.lbNombreReporte.Text = ValorReferencia.ObtenerDescripcion("REPORTEW", "258", "EM");

                report.lbCEDI.Text = Mensaje.ObtenerDescripcion("Xcentrodistribucion", "EM");
                if (Vendedor != "")
                    report.lbVenRuta.Text = Mensaje.ObtenerDescripcion("XVendedor", "EM");
                else
                    report.lbVenRuta.Text = Mensaje.ObtenerDescripcion("XRuta", "EM");
                report.lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");

                report.lbCEDIFiltro.Text = NombreCedis;
                if (Vendedor != "")
                    report.lbVenRutaFiltro.Text = VendedorSplit;
                else if (Ruta != "")
                    report.lbVenRutaFiltro.Text = RutasSplit;
                report.lbFechaFiltro.Text = dFechaIni.ToShortDateString() + (FechaFinal == "" ? "" : "-" + dFechaFin.ToShortDateString());

                //GrouHeader
                report.lbRutaG.Text = Mensaje.ObtenerDescripcion("XRuta", "EM");
                report.lbFechaG.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");
                report.lbItinerario.Text = Mensaje.ObtenerDescripcion("XEnItinerario", "EM");
                report.lbVisitados.Text = Mensaje.ObtenerDescripcion("XVisitados", "EM");
                report.lbEficiencia.Text = Mensaje.ObtenerDescripcion("XEficiencia", "EM");
                report.lbVisVenta.Text = Mensaje.ObtenerDescripcion("XVisitadosconVenta", "EM");
                report.lbEfectividad.Text = Mensaje.ObtenerDescripcion("XEfectividad", "EM");
                report.lbVisSinVenta.Text = Mensaje.ObtenerDescripcion("XVisitadossinVenta", "EM");
                report.lbImproductividad.Text = Mensaje.ObtenerDescripcion("XImproductividad", "EM");
                report.lbNoVisitados.Text = Mensaje.ObtenerDescripcion("XNoVisitados", "EM");
                report.lbAusencia.Text = Mensaje.ObtenerDescripcion("XAusencia", "EM");
                report.lbTotalVenta.Text = Mensaje.ObtenerDescripcion("XTotalVenta", "EM");

                //GroupFooter
                report.lbTotalRuta.Text = Mensaje.ObtenerDescripcion("XTotalPorRuta", "EM");

                //ReportFooter
                report.lbAcumulado.Text = Mensaje.ObtenerDescripcion("XAcumulado", "EM");

                return report;
            }
            catch (Exception ex)
            {
                return new IndicadoresDeVentaPDR();
            }
        }
    }

}