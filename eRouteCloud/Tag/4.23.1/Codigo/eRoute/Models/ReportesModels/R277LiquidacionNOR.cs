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
    public class R277LiquidacionNOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R277_Report_Design report;
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
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R277Liquidacion_NOR]");
            sConsulta.AppendLine("@filterCedi = '" + CEDIS + "',");
            sConsulta.AppendLine("@filterRoutes = '" + Routes + "',");
            sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "'");
            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                report = new R277_Report_Design();
                var lenguaje = ObtenerLenguaje();

                string cedi = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje);
                string fecha = Mensaje.ObtenerDescripcion("XFecha", lenguaje);
                string ruta = Mensaje.ObtenerDescripcion("XRuta(s)", lenguaje);

                report.Parameters["parameterCedis"].Value = CEDIS;
                report.Parameters["parameterRoutes"].Value = Routes;
                report.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");

                report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                report.logo.Image = Image.FromStream(CompanyLogo);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.report_Company.Text = CompanyName.ToUpper();
                report.report_Name.Text = ReportName.ToUpper();
                report.headerCEDI.Text = cedi + ":";
                report.L_CEDI.Text = NameCEDIS;
                report.headerFecha.Text = fecha + ":";
                report.L_FechaRango.Text = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                report.headerRuta.Text = Mensaje.ObtenerDescripcion("XRuta(s)", lenguaje) + ":";
                report.L_Ruta.Text = Routes;

                report.lb_Folio.Text = Mensaje.ObtenerDescripcion("XFolio", lenguaje);
                report.lb_Clave.Text = Mensaje.ObtenerDescripcion("XClave", lenguaje);
                report.lb_Cliente.Text = Mensaje.ObtenerDescripcion("XCliente", lenguaje);
                report.lb_Producto.Text = Mensaje.ObtenerDescripcion("XProducto", lenguaje);
                report.lb_Pzs.Text = Mensaje.ObtenerDescripcion("XPiezas", lenguaje);
                report.lb_Precio.Text = Mensaje.ObtenerDescripcion("XPrecio", lenguaje);
                report.lb_Total.Text = Mensaje.ObtenerDescripcion("XTotal", lenguaje);

                report.groupCEDI.Text = cedi + ":"; ;
                report.groupVendedor.Text = Mensaje.ObtenerDescripcion("XVendedor", lenguaje) + ":";
                report.groupFecha.Text = fecha + ":";
                report.groupRuta.Text = Mensaje.ObtenerDescripcion("XRuta", lenguaje) + ":";

                report.lb_TotalRuta.Text = Mensaje.ObtenerDescripcion("XTotalPorRuta", lenguaje) + ":";
                report.lb_Gtotal.Text = Mensaje.ObtenerDescripcion("XGRANTOTAL", lenguaje) + ":";

                report.lb_DateTimeImpresion.Text = Mensaje.ObtenerDescripcion("XFechaHoraImpresion", lenguaje) + ":";

                return report;
            }
            else
            {
                return null;
            }
        }
    }
}