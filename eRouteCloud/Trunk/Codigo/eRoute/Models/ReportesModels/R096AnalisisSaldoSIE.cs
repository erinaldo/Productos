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
    public class R096AnalisisSaldoSIE
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R096_General_Design report1;
        private R096_Detailed_Design report2;
        private R096_SubReport_Design report3;
        private string QueryString;
        private RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream LogoEmpresa, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string Routes, string Sellers, string CustomerSchemes, string Customers, bool ReportType)
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
            sConsulta.AppendLine("EXECUTE [dbo].[stpr_R096AnalisisSaldo_SIE]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + Routes + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + CustomerSchemes + "',");
            sConsulta.AppendLine("@FILTROCLIENTES = '" + Customers + "',");
            sConsulta.AppendLine("@noConsulta = " + (ReportType ? 1 : 0));
            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                var lenguaje = ObtenerLenguaje();

                string cedi = Mensaje.ObtenerDescripcion("XCEDI", lenguaje);
                string vendedor = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);
                string ruta = Mensaje.ObtenerDescripcion("XRuta", lenguaje);
                string clientes = Mensaje.ObtenerDescripcion("XClientes", lenguaje);
                string fecha = Mensaje.ObtenerDescripcion("XFecha", lenguaje);

                string clave = Mensaje.ObtenerDescripcion("XClaveCliente", lenguaje);
                string razonSocial = Mensaje.ObtenerDescripcion("XRazonSocial", lenguaje);
                string nombreContacto = Mensaje.ObtenerDescripcion("XNombreContacto", lenguaje);
                string credito = Mensaje.ObtenerDescripcion("XCredito", lenguaje);
                string consignacion = Mensaje.ObtenerDescripcion("XConsignacion", lenguaje);
                string total = Mensaje.ObtenerDescripcion("XTotal", lenguaje);
                string envase = Mensaje.ObtenerDescripcion("XEnvase", lenguaje);
                string folio = Mensaje.ObtenerDescripcion("XFolio", lenguaje);
                string fechaVencimiento = Mensaje.ObtenerDescripcion("XFechaVencimiento", lenguaje);

                string totalVendedor = Mensaje.ObtenerDescripcion("XTotalPorVendedor", lenguaje);
                string rotalRuta = Mensaje.ObtenerDescripcion("XTotalPorRuta", lenguaje);
                string totalCEDI = Mensaje.ObtenerDescripcion("XTotalPorCEDI", lenguaje);
                string granTotal = Mensaje.ObtenerDescripcion("XGRANTOTAL", lenguaje);

                if (ReportType)
                {
                    report2 = new R096_Detailed_Design();
                    report2.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                    report2.logo.Image = Image.FromStream(LogoEmpresa);
                    report2.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    report2.report_Company.Text = CompanyName.ToUpper();
                    report2.report_Name.Text = ReportName.ToUpper() + " - " + Mensaje.ObtenerDescripcion("XDetallado", lenguaje).ToUpper();
                    report2.headerCEDI.Text = cedi;
                    report2.L_CEDI.Text = NameCEDIS;
                    report2.headerVendedor.Text = vendedor;
                    report2.L_VendedorNombre.Text = NomVendedores;
                    report2.headerRuta.Text = ruta;
                    report2.L_Ruta.Text = Routes;
                    report2.headerClientes.Text = clientes;
                    report2.L_Clientes.Text = Customers;
                    report2.headerFecha.Text = fecha;
                    report2.L_FechaRango.Text = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                    report2.Lb_CEDI_Grupo.Text = cedi;
                    report2.Lb_Ruta_Grupo.Text = ruta;
                    report2.Lb_Vendedor_Grupo.Text = vendedor;
                    report2.Label_Clave.Text = clave;
                    report2.Label_Nombre.Text = razonSocial;
                    report2.Label_NomContacto.Text = nombreContacto;
                    report2.Label_Fecha.Text = fecha;
                    report2.Label_Folio.Text = folio;
                    report2.Label_FVencim.Text = fechaVencimiento;
                    report2.Label_Credito.Text = credito;
                    report2.Label_Consignacion.Text = consignacion;
                    report2.Label_Total.Text = total;
                    report2.Label_Envase.Text = envase;
                    report2.Lb_Total.Text = total;
                    report2.Lb_Vendedor.Text = totalVendedor;
                    report2.Lb_Ruta.Text = rotalRuta;
                    report2.Lb_CEDI.Text = totalCEDI;
                    report2.Lb_GTotal.Text = granTotal;
                    report2.Parameters["parameterCEDI"].Value = CEDIS;
                    report2.Parameters["parameterSeller"].Value = Sellers;
                    report2.Parameters["parameterRoutes"].Value = Routes;
                    report2.Parameters["parameterScheme"].Value = CustomerSchemes;
                    report2.Parameters["parameterCustomers"].Value = Customers;
                    report2.Parameters["parameterNumQuery"].Value = 1;
                    return report2;
                }
                else
                {
                    report1 = new R096_General_Design();
                    report1.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                    report1.logo.Image = Image.FromStream(LogoEmpresa);
                    report1.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    report1.report_Company.Text = CompanyName.ToUpper();
                    report1.report_Name.Text = ReportName.ToUpper() + " - " + Mensaje.ObtenerDescripcion("XGeneral", lenguaje).ToUpper();
                    report1.headerCEDI.Text = cedi;
                    report1.L_CEDI.Text = NameCEDIS;
                    report1.headerVendedor.Text = vendedor;
                    report1.L_VendedorNombre.Text = NomVendedores;
                    report1.headerRuta.Text = ruta;
                    report1.L_Ruta.Text = Routes;
                    report1.headerClientes.Text = clientes;
                    report1.L_Clientes.Text = Customers;
                    report1.headerFecha.Text = fecha;
                    report1.L_FechaRango.Text = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                    report1.Lb_CEDI_Grupo.Text = cedi;
                    report1.Lb_Ruta_Grupo.Text = ruta;
                    report1.Lb_Vendedor_Grupo.Text = vendedor;
                    report1.Label_Clave.Text = clave;
                    report1.Label_Nombre.Text = razonSocial;
                    report1.Label_NomContacto.Text = nombreContacto;
                    report1.Label_Credito.Text = credito;
                    report1.Label_Consignacion.Text = consignacion;
                    report1.Label_Total.Text = total;
                    report1.Label_Envase.Text = envase;
                    report1.Lb_Vendedor.Text = totalVendedor;
                    report1.Lb_Ruta.Text = rotalRuta;
                    report1.Lb_Cedi.Text = totalCEDI;
                    report1.Lb_GTotal.Text = granTotal;
                    report1.Parameters["parameterCEDI"].Value = CEDIS;
                    report1.Parameters["parameterSeller"].Value = Sellers;
                    report1.Parameters["parameterRoutes"].Value = Routes;
                    report1.Parameters["parameterScheme"].Value = CustomerSchemes;
                    report1.Parameters["parameterCustomers"].Value = Customers;
                    return report1;
                }
            }
            else
            {
                return null;
            }
        }
    }
}