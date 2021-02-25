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
    public class R196ResumenTiemposMovimientosCOS
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R196_Report_Design report;
        private string QueryString;
        private RouteEntities db = new RouteEntities();

        public string getLanguage()
        {
            var language = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return language[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream CompanyLogo, string CEDIS, string NameCEDIS, string InitialDate)
        {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R196ResumenTiempoMovimiento]");
            sConsulta.AppendLine("@filterCedi = '" + CEDIS + "',");
            sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(InitialDate).ToString("yy/MM/dd") + "'");
            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                report = new R196_Report_Design();
                var language = getLanguage();

                string cedi = Mensaje.ObtenerDescripcion("XCEDI", language);
                string difMin = Mensaje.ObtenerDescripcion("XDifMin", language);

                report.Parameters["parameterCedis"].Value = CEDIS;
                report.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yy/MM/dd");

                report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                report.logo.Image = Image.FromStream(CompanyLogo);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.report_Company.Text = CompanyName.ToUpper();
                report.report_Name.Text = ReportName.ToUpper();
                report.XCentro.Text = cedi + ":";
                report.L_CEDI.Text = NameCEDIS;
                report.XFecha.Text = Mensaje.ObtenerDescripcion("XFecha", language) + ":";
                report.L_FechaRango.Text = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");

                report.XCedi.Text = cedi;
                report.XRuta.Text = Mensaje.ObtenerDescripcion("XRuta", language);
                report.XUsuario.Text = Mensaje.ObtenerDescripcion("XUsuario", language);
                report.XFechaAgenda.Text = Mensaje.ObtenerDescripcion("XFechaAgenda", language);
                report.XPrimeraVenta.Text = Mensaje.ObtenerDescripcion("XFechaPrimeraVenta", language);
                report.XDifIniJorPrimVenta.Text = difMin;
                report.XUltimaVenta.Text = Mensaje.ObtenerDescripcion("XFUltimaVenta", language);
                report.XFechaFinJornada.Text = Mensaje.ObtenerDescripcion("XFechaFinJornada", language);
                report.XDifUltVentaFinJor.Text = difMin;

                report.XFechaHoraImpresion.Text = Mensaje.ObtenerDescripcion("XFechaHoraImpresion", language);

                return report;
            }
            else
            {
                return null;
            }
        }
    }
}