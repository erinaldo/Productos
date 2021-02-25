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
    public class R271DocumentoConSaldoDIV
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R271_Report_Design report1;
        private string QueryString;
        private RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream CompanyLogo, string CEDIS, string NameCEDIS, string Routes, string Sellers, string CustomerSchemes, string Customers)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.Clear();
                sConsulta.AppendLine("EXECUTE [DBO].[stpr_R271DocumentoSaldo_DIV]");
                sConsulta.AppendLine("@filterCedi = '" + CEDIS + "',");
                sConsulta.AppendLine("@filterRoutes = '" + Routes + "',");
                sConsulta.AppendLine("@filterSellers = '" + Sellers + "',");
                sConsulta.AppendLine("@filterCustomerScheme = '" + CustomerSchemes + "',");
                sConsulta.AppendLine("@filterCustomer = '" + Customers + "'");
                QueryString = sConsulta.ToString();

                Connection.Open();
                var query = Connection.Query(QueryString, null, null, true, 600).ToList();
                Connection.Close();

                if (query.Count() > 0)
                {
                    report1 = new R271_Report_Design();
                    var lenguaje = ObtenerLenguaje();
                    string cedi = Mensaje.ObtenerDescripcion("XCEDI", lenguaje);
                    string vendedor = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);
                    string ruta = Mensaje.ObtenerDescripcion("XRuta", lenguaje);
                    string cliente = Mensaje.ObtenerDescripcion("XCliente", lenguaje);

                    string folio = Mensaje.ObtenerDescripcion("XFolio", lenguaje);
                    string fechaCaptura = Mensaje.ObtenerDescripcion("TRPFechaCaptura", lenguaje);
                    string fechaUltimoPago = Mensaje.ObtenerDescripcion("XFechaUltimoPago", lenguaje);
                    string total = Mensaje.ObtenerDescripcion("XTotal", lenguaje);
                    string importePago = Mensaje.ObtenerDescripcion("XTotalUltimoPago", lenguaje);
                    string saldo = Mensaje.ObtenerDescripcion("XSaldo", lenguaje);

                    string totalCliente = Mensaje.ObtenerDescripcion("XTotalPorCliente", lenguaje);
                    string rotalRuta = Mensaje.ObtenerDescripcion("XTotalPorRuta", lenguaje);
                    string totalVendedor = Mensaje.ObtenerDescripcion("XTotalPorVendedor", lenguaje);
                    string totalCEDI = Mensaje.ObtenerDescripcion("XTotalCedi", lenguaje);
                    string granTotal = Mensaje.ObtenerDescripcion("XGRANTOTAL", lenguaje);

                    report1.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                    report1.logo.Image = Image.FromStream(CompanyLogo);
                    report1.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    report1.report_Company.Text = CompanyName.ToUpper();
                    report1.report_Name.Text = ReportName.ToUpper();
                    report1.headerCEDI.Text = cedi;
                    report1.L_CEDI.Text = NameCEDIS;
                    report1.headerVendedor.Text = vendedor;
                    report1.L_VendedorNombre.Text = Sellers;
                    report1.headerRuta.Text = ruta;
                    report1.L_Ruta.Text = Routes;
                    report1.headerClientes.Text = cliente;
                    report1.L_Clientes.Text = Customers;
                    report1.Lb_CEDI_Grupo.Text = cedi;
                    report1.Lb_Vendedor_Grupo.Text = vendedor;
                    report1.Lb_Ruta_Grupo.Text = ruta;
                    report1.Label_Cliente.Text = cliente;
                    report1.Label_Folio.Text = folio;
                    report1.Label_FechaCap.Text = fechaCaptura;
                    report1.Label_FechaPago.Text = fechaUltimoPago;
                    report1.Label_Total.Text = total;
                    report1.Label_ImportePago.Text = importePago;
                    report1.Label_Saldo.Text = saldo;
                    report1.Lb_Cliente.Text = totalCliente;
                    report1.Lb_Ruta.Text = rotalRuta;
                    report1.Lb_Vendedor.Text = totalVendedor;
                    report1.Lb_Cedi.Text = totalCEDI;
                    report1.Lb_GTotal.Text = granTotal;
                    report1.Parameters["parameterCEDI"].Value = CEDIS;
                    report1.Parameters["parameterSeller"].Value = Sellers;
                    report1.Parameters["parameterRoutes"].Value = Routes;
                    report1.Parameters["parameterScheme"].Value = CustomerSchemes;
                    report1.Parameters["parameterCustomers"].Value = Customers;
                    return report1;
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