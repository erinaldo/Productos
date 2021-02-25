using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class R156KardexInventarioProducto
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R156_Report_Design report;
        private string QueryString;
        private RouteEntities db = new RouteEntities();
        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream CompanyLogo, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string Routes)
        {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R156KardexInventarioProducto_Dacza]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + Routes + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "'");
            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                report = new R156_Report_Design();
                var lenguaje = ObtenerLenguaje();

                string RUTA = Mensaje.ObtenerDescripcion("XRuta", lenguaje);

                report.Parameters["parameterCEDI"].Value = CEDIS;
                report.Parameters["parameterRoutes"].Value = Routes;
                report.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");

                report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                report.logo.Image = Image.FromStream(CompanyLogo);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.report_Company.Text = CompanyName.ToUpper();
                report.report_Name.Text = ReportName.ToUpper();
                report.headerCEDI.Text = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje);
                report.L_CEDI.Text = NameCEDIS;
                report.headerFecha.Text = Mensaje.ObtenerDescripcion("XFecha", lenguaje);
                report.L_FechaRango.Text = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                report.headerRuta.Text = RUTA;
                report.L_Ruta.Text = Routes;

                report.Lb_NoParte.Text = Mensaje.ObtenerDescripcion("XNoParte", lenguaje);
                report.Lb_Descripcion.Text = Mensaje.ObtenerDescripcion("XDescripcion", lenguaje);
                report.Lb_InvInicial.Text = Mensaje.ObtenerDescripcion("XInvInicial2", lenguaje);
                report.Lb_Entradas.Text = Mensaje.ObtenerDescripcion("XEntradas", lenguaje);
                report.Lb_Salidas.Text = Mensaje.ObtenerDescripcion("XSalidas", lenguaje);
                report.Lb_InvFinal.Text = Mensaje.ObtenerDescripcion("XInvFinal", lenguaje);
                report.groupHeaderRuta.Text = RUTA;
                report.Lb_SubTotal.Text = Mensaje.ObtenerDescripcion("XSubtotal", lenguaje);
                report.Lb_GTotal.Text = Mensaje.ObtenerDescripcion("XGRANTOTAL", lenguaje);
                report.Lb_FechaImpresion.Text = Mensaje.ObtenerDescripcion("XFechaHoraImpresion", lenguaje);

                return report;
            }
            else
            {
                return null;
            }
        }
    }
}