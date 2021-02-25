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
    public class R020MovSinInvSinVisita
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R020_Report_Design report;
        private string QueryString;

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream LogoEmpresa, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string FinalDate, bool detallado, string Sellers)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();
                RouteEntities db = new RouteEntities();
                var NomVendedores = "";
                string[] SellersArrays = Sellers.Split(',');
                int countSellers = SellersArrays.Length;

                sConsulta.Clear();
                sConsulta.AppendLine("EXECUTE [DBO].[stpr_r020MoviSinInvSinVisita_GUA]");
                sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
                sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
                sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
                sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "'");
                sConsulta.AppendLine("");

                QueryString = sConsulta.ToString();

                Connection.Open();
                var query = Connection.Query(QueryString, null, null, true, 600).ToList();
                Connection.Close();

                if (!Sellers.Equals("") && SellersArrays.Length == 1)
                {
                    var Vendedor = (from V in db.Vendedor
                                    join U in db.Usuario on V.USUId equals U.USUId
                                    where V.VendedorID == Sellers
                                    select U.Clave + " - " + V.Nombre).Take(1).ToList();

                    NomVendedores = Vendedor[0].ToString();
                }

                if (query.Count() > 0)
                {
                    report = new R020_Report_Design();
                    report.Parameters["FILTROCEDI"].Value = CEDIS;
                    report.Parameters["FILTROVENDEDOR"].Value = Sellers;
                    report.Parameters["FILTROFECHAINI"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");
                    report.Parameters["FILTROFECHAFIN"].Value = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd"));

                    report.logo.Image = Image.FromStream(LogoEmpresa);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    report.report_Name.Text = ReportName.ToUpper() + (detallado ? " DETALLADO" : " GENERAL");
                    report.L_CEDI.Text = NameCEDIS;
                    report.L_FechaRango.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));
                    report.L_VendedorClave.Text = (!Sellers.Equals("") ? NomVendedores : "Todos los Vendedores");

                    if (!detallado)
                    {
                        report.label_Unidad.Visible = false;
                        report.xrLabel76.Visible = false;
                    }
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