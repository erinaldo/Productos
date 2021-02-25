using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class MInformeCuadreVentas
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal, string nombreCedis)
        {
            DateTime fInicio = DateTime.Parse(FechaInicial);
            DateTime fFin = DateTime.Now;
            if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
            {
                FechaFinal = "";
            }
            else
            {
                fFin = DateTime.Parse(FechaFinal);
                FechaFinal = " - " + fFin.Date.ToShortDateString();
            }

            StringBuilder sConsulta = new StringBuilder();

            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            sConsulta.AppendLine(" ");
            sConsulta.AppendLine("SELECT t.RUTClave, SUM(t.VentasSinImpuestos) AS VentasSinImpuestos, SUM(t.IVA) AS IVA, SUM(t.IEPS) AS IEPS ");
            sConsulta.AppendLine("FROM ( ");
            sConsulta.AppendLine("SELECT v.RUTClave, ");
            sConsulta.AppendLine("ROUND(SUM(td.Subtotal), 2) AS VentasSinImpuestos, ");
            sConsulta.AppendLine("ROUND(CASE WHEN i.Abreviatura = 'IVA' THEN SUM(ti.ImpuestoImp) ELSE 0 END, 2) AS IVA, ");
            sConsulta.AppendLine("ROUND(CASE WHEN i.Abreviatura = 'IEPS' THEN SUM(ti.ImpuestoImp) ELSE 0 END, 2) AS IEPS ");
            sConsulta.AppendLine("FROM TransProd t (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN TransProdDetalle td (NOLOCK) ON t.TransProdID = td.TransProdID AND (t.Tipo = 1 AND t.TipoFase <> 0) ");
            sConsulta.AppendLine("INNER JOIN Visita v (NOLOCK) ON v.DiaClave = isnull(t.DiaClave1, t.DiaClave) AND v.VisitaClave = isnull(t.VisitaClave1, t.VisitaClave) ");
            sConsulta.AppendLine("INNER JOIN Dia d (NOLOCK) ON d.DiaClave = isnull(t.DiaClave1, t.DiaClave) ");
            sConsulta.AppendLine("INNER JOIN Vendedor ve (NOLOCK) ON v.VendedorID = ve.VendedorID ");
            sConsulta.AppendLine("INNER JOIN Usuario u (NOLOCK) ON ve.USUId = u.USUId ");
            sConsulta.AppendLine("INNER JOIN VENCentroDistHist vch (NOLOCK) ON ve.VendedorID = vch.VendedorId AND CONVERT(datetime, left(VCHFechaInicial, 11), 112)< = d.FechaCaptura AND FechaFinal> = d.FechaCaptura ");
            sConsulta.AppendLine("INNER JOIN Almacen a (NOLOCK) ON vch.AlmacenId = a.AlmacenID ");
            sConsulta.AppendLine("LEFT JOIN TPDImpuesto ti (NOLOCK) ON td.TransProdID = ti.TransProdID AND td.TransProdDetalleID = ti.TransProdDetalleID ");
            sConsulta.AppendLine("LEFT JOIN Impuesto i (NOLOCK) ON ti.ImpuestoClave = i.ImpuestoClave ");
            sConsulta.AppendLine(pvCondicion);
            sConsulta.AppendLine("GROUP BY v.RUTClave, i.Abreviatura ");
            sConsulta.AppendLine(") AS T ");
            sConsulta.AppendLine("GROUP BY T.RUTClave ");

            QueryString = "";
            QueryString = sConsulta.ToString();

            List<CV> icv = Connection.Query<CV>(QueryString, null, null, true, 600).ToList();
            if (icv.Count != 0)
            {
                InformeCuadreVentas report = new InformeCuadreVentas();
                icv.LastOrDefault().tVentasSinImpuestos = icv.Sum(c => c.VentasSinImpuestos);
                icv.LastOrDefault().tIEPS = icv.Sum(c => c.IEPS);
                icv.LastOrDefault().tIVA = icv.Sum(c => c.IVA);
                icv.LastOrDefault().tTotal = icv.LastOrDefault().tVentasSinImpuestos + icv.LastOrDefault().tIEPS + icv.LastOrDefault().tIVA;

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;

                report.fecha.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.xLalmacen.Text = nombreCedis;
                report.DataSource = icv;

                foreach (CV a in icv)
                {
                    a.Total = a.VentasSinImpuestos + a.IEPS + a.IVA;
                }
                report.x1.DataBindings.Add("Text", null, "RUTClave");
                report.x2.DataBindings.Add("Text", null, "VentasSinImpuestos", "{0:$#,##0.00}");
                report.x3.DataBindings.Add("Text", null, "IVA", "{0:$#,##0.00}");
                report.x4.DataBindings.Add("Text", null, "IEPS", "{0:$#,##0.00}");
                report.x5.DataBindings.Add("Text", null, "Total", "{0:$#,##0.00}");

                report.fechaActual1.Text = DateTime.Now.ToString("G");
                report.fechaActual2.Text = DateTime.Now.ToString("G");
                report.y2.Text = icv.LastOrDefault().tVentasSinImpuestos.ToString("C");
                report.y3.Text = icv.LastOrDefault().tIVA.ToString("C");
                report.y4.Text = icv.LastOrDefault().tIEPS.ToString("C");
                report.y5.Text = icv.LastOrDefault().tTotal.ToString("C");

                return report;
            }
            else
            {
                return null;
            }
        }
    }

    class CV
    {
        public String RUTClave { get; set; }
        public Decimal VentasSinImpuestos { get; set; }
        public Decimal IVA { get; set; }
        public Decimal IEPS { get; set; }
        public Decimal Total { get; set; }
        public Decimal tVentasSinImpuestos { get; set; }
        public Decimal tIVA { get; set; }
        public Decimal tIEPS { get; set; }
        public Decimal tTotal { get; set; }
    }
}