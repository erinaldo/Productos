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
    public class R108TotalVentasELE
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R108_Report_Design report;
        private string QueryString;
        private RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream CompanyLogo, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string FinalDate, string Routes, string Sellers)
        {
            StringBuilder sConsulta = new StringBuilder();
            var NomVendedores = "";
            string[] SellersArrays = Sellers.Split(',');

            if (!Sellers.Equals("") && SellersArrays.Length == 1)
            {
                var Vendedor = (from V in db.Vendedor
                                join U in db.Usuario on V.USUId equals U.USUId
                                where V.VendedorID == Sellers
                                select V.Nombre).Take(1).ToList();

                NomVendedores = Vendedor[0].ToString();
            }

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R108TotalVentas_ELE]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + Routes + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "'");
            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                var lenguaje = ObtenerLenguaje();
                report = new R108_Report_Design();
                string CEDI = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje);
                string VENDEDOR = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);
                string RUTA = Mensaje.ObtenerDescripcion("XRuta", lenguaje);
                //string FECHA = Mensaje.ObtenerDescripcion("XFecha", lenguaje);

                report.logo.Image = Image.FromStream(CompanyLogo);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                report.report_Company.Text = CompanyName.ToUpper();
                report.report_Name.Text = ReportName.ToUpper();
                report.headerCEDI.Text = CEDI;
                report.L_CEDI.Text = NameCEDIS;
                report.headerFecha.Text = Mensaje.ObtenerDescripcion("XFecha", lenguaje);
                report.L_FechaRango.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));
                report.headerVendedor.Text = VENDEDOR;
                report.L_VendedorNombre.Text = NomVendedores;
                report.headerRuta.Text = RUTA;
                report.L_Ruta.Text = Routes;
                report.Label_Clave.Text = Mensaje.ObtenerDescripcion("XClave", lenguaje);
                report.Label_Cliente.Text = Mensaje.ObtenerDescripcion("XCliente", lenguaje);
                report.Lb_GTotal.Text = Mensaje.ObtenerDescripcion("XTotalVentas", lenguaje);
                report.Lb_Descuentos.Text = Mensaje.ObtenerDescripcion("XDescuentos", lenguaje);
                report.Lb_Devoluciones.Text = Mensaje.ObtenerDescripcion("XDevoluciones", lenguaje);
                report.Lb_Total.Text = Mensaje.ObtenerDescripcion("XTotal", lenguaje);
                report.Lb_CEDI_Grupo.Text = CEDI;
                report.Lb_Vendedor_Grupo.Text = VENDEDOR;
                report.Lb_Ruta_Grupo.Text = RUTA;
                report.Lb_FechaImpresion.Text = Mensaje.ObtenerDescripcion("XFechaHoraImpresion", lenguaje);

                report.Parameters["parameterCEDI"].Value = CEDIS;
                report.Parameters["parameterSeller"].Value = Sellers;
                report.Parameters["parameterRoutes"].Value = Routes;
                report.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");
                report.Parameters["parameterDateEnd"].Value = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd"));

                return report;
            }
            else
            {
                return null;
            }
        }
    }
}