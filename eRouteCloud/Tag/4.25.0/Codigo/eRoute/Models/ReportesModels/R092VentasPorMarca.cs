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
    public class R092VentasPorMarca
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R092_Report_Design report;
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
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R092VentasPorMarca]");
            sConsulta.AppendLine("@filterCedi = '" + CEDIS + "',");
            sConsulta.AppendLine("@filterSeller = '" + Sellers + "',");
            sConsulta.AppendLine("@filterRoutes = '" + Routes + "',");
            sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@filterDateEnd = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@numQuery = " + 0);
            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                var lenguaje = ObtenerLenguaje();
                report = new R092_Report_Design();
                string cedi = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje);
                string vendedor = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);
                string ruta = Mensaje.ObtenerDescripcion("XRuta", lenguaje);
                string fecha = Mensaje.ObtenerDescripcion("XFecha", lenguaje);
                string clave = Mensaje.ObtenerDescripcion("XClave", lenguaje);
                string nombre = Mensaje.ObtenerDescripcion("XNombre", lenguaje);
                string unidades = Mensaje.ObtenerDescripcion("XUnidades", lenguaje);
                string importe = Mensaje.ObtenerDescripcion("XImporte", lenguaje);
                string descuentos = Mensaje.ObtenerDescripcion("XDescuentos", lenguaje);
                string total = Mensaje.ObtenerDescripcion("XTotal", lenguaje);
                report.logo.Image = Image.FromStream(CompanyLogo);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                report.report_Company.Text = CompanyName.ToUpper();
                report.report_Name.Text = ReportName.ToUpper();
                report.headerCEDI.Text = cedi;
                report.L_CEDI.Text = NameCEDIS;
                report.headerVendedor.Text = vendedor;
                report.L_VendedorNombre.Text = NomVendedores;
                report.headerRuta.Text = ruta;
                report.L_Ruta.Text = Routes;
                report.headerFecha.Text = fecha;
                report.L_FechaRango.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));
                report.Label_Clave.Text = clave;
                report.Label_Nombre.Text = nombre;
                report.Label_Unidades.Text = unidades;
                report.Label_Importe.Text = importe;
                report.Label_Descuentos.Text = descuentos;
                report.Label_Total.Text = total;
                report.Lb_Total.Text = total;
                report.Lb_CEDI_Grupo.Text = cedi;
                report.Lb_Fecha_Grupo.Text = fecha;
                report.Lb_Vendedor_Grupo.Text = vendedor;
                report.Lb_Ruta_Grupo.Text = ruta;
                report.Lb_FechaImpresion.Text = Mensaje.ObtenerDescripcion("XFechaHoraImpresion", lenguaje);

                report.Parameters["parameterCedi"].Value = CEDIS;
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