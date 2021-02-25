using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.DataAccess.Sql;
using Microsoft.Ajax.Utilities;

namespace eRoute.Models.ReportesModels
{
    public class R274LiquidacionROV
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private R274_Report_Design report;
        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream LogoEmpresa, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string Sellers)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();
                var NomVendedores = "";
                string[] SellersArrays = Sellers.Split(',');
                int countSellers = SellersArrays.Length;

                sConsulta.Clear();
                sConsulta.AppendLine("EXECUTE [DBO].[stpr_R274Liquidacion_ROV]");
                sConsulta.AppendLine("@filterSellers = '" + Sellers + "',");
                sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
                sConsulta.AppendLine("@numQuery = 1");
                QueryString = sConsulta.ToString();

                Connection.Open();
                var query = Connection.Query(QueryString, null, null, true, 600).ToList();
                Connection.Close();

                if (!Sellers.Equals("") && SellersArrays.Length == 1)
                {
                    var Vendedor = (from V in db.Vendedor
                                    join U in db.Usuario on V.USUId equals U.USUId
                                    where V.VendedorID == Sellers
                                    select V.Nombre).Take(1).ToList();

                    NomVendedores = Vendedor[0].ToString();
                }

                if (query.Count() > 0)
                {
                    var lenguaje = ObtenerLenguaje();
                    report = new R274_Report_Design();
                    report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");

                    report.Parameters["parameterSeller"].Value = Sellers;
                    report.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");

                    report.logo.Image = Image.FromStream(LogoEmpresa);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    report.report_Company.Text = CompanyName.ToUpper();
                    report.report_Name.Text = ReportName.ToUpper();
                    report.Label_Direccion.Text = Mensaje.ObtenerDescripcion("XDireccion", lenguaje);
                    report.Label_Telefono.Text = Mensaje.ObtenerDescripcion("XTelefono", lenguaje);
                    report.headerVendedor.Text = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);
                    report.headerFecha.Text = Mensaje.ObtenerDescripcion("XFecha", lenguaje);
                    report.L_FechaRango.Text = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                    report.L_VendedorNombre.Text = NomVendedores;
                    report.Lb_Liquidacion.Text = Mensaje.ObtenerDescripcion("XMLiquidacion", lenguaje).ToUpper();

                    return report;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}