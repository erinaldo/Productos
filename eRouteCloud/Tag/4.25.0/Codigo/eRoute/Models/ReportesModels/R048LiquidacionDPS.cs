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
    public class R048LiquidacionDPS
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R048_Report_Design report;
        private string QueryString;

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream LogoEmpresa, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string Sellers)
        {
            StringBuilder sConsulta = new StringBuilder();
            RouteEntities db = new RouteEntities();
            var NomVendedores = "";
            string[] SellersArrays = Sellers.Split(',');
            int countSellers = SellersArrays.Length;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R048LiquidacionDPS]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "', ");
            sConsulta.AppendLine("@noConsulta = 0");
            sConsulta.AppendLine("");

            QueryString = sConsulta.ToString();
            var query = Connection.Query(QueryString).ToList();

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
                report = new R048_Report_Design();
                report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");

                report.Parameters["parameterCEDI"].Value = CEDIS;
                report.Parameters["parameterSeller"].Value = Sellers;
                report.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");
                report.Parameters["parameterDateEnd"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");

                report.logo.Image = Image.FromStream(LogoEmpresa);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.report_Company.Text = CompanyName.ToUpper();
                report.report_Name.Text = ReportName.ToUpper();
                report.L_CEDI.Text = NameCEDIS;
                report.L_FechaRango.Text = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                report.L_VendedorNombre.Text = NomVendedores;

                sConsulta.Clear();
                sConsulta.AppendLine("EXECUTE [DBO].[stpr_R048LiquidacionDPS]");
                sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
                sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
                sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
                sConsulta.AppendLine("@FILTROFECHAFIN = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "', ");
                sConsulta.AppendLine("@noConsulta = 6");

                QueryString = sConsulta.ToString();
                var queryCobranza = Connection.Query(QueryString).ToList();

                double TotalCobraza = 0;

                foreach (var item in queryCobranza)
                {
                    TotalCobraza += item.Cobranza;
                }

                report.L_TotalCobraza.Text = TotalCobraza.ToString("$#,###,##0.00");
                //report.L_TotalCobraza.Text = String.Format("{0:$#,###,##0.00}", Double.Parse(queryCobranza[0].Cobranza));





                return report;
            }
            else
            {
                return null;
            }
        }
    }
}