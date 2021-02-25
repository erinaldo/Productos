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
    public class R021MovSinInvEnVisita
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R021_General_Design report1;
        private R021_Detailed_Design report2;
        private string QueryString;
        private RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream LogoEmpresa, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string FinalDate, string Routes, string Sellers, string CustomerSchemes, string Customers, bool ReportType)
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
            sConsulta.AppendLine("EXECUTE [dbo].[stpr_R021MovSinInventarioVisita_GUA]");
            sConsulta.AppendLine("@filterCedi = '" + CEDIS + "',");
            sConsulta.AppendLine("@filterRoutes = '" + Sellers + "',");
            sConsulta.AppendLine("@filterSellers = '" + Routes + "',");
            sConsulta.AppendLine("@filterCustomerScheme = '" + CustomerSchemes + "',");
            sConsulta.AppendLine("@filterCustomer = '" + Customers + "',");
            sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@filterDateEnd = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@numQuery = " + (ReportType ? 1 : 0));
            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                var lenguaje = ObtenerLenguaje();

                string cedi = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje);
                string vendedor = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);
                string ruta = Mensaje.ObtenerDescripcion("XRuta", lenguaje);
                string fecha = Mensaje.ObtenerDescripcion("XFecha", lenguaje);

                string clave = Mensaje.ObtenerDescripcion("XClaveCliente", lenguaje);
                string producto = Mensaje.ObtenerDescripcion("XProducto", lenguaje);
                string unidad = Mensaje.ObtenerDescripcion("XUnidad", lenguaje);
                string cantidad = Mensaje.ObtenerDescripcion("XCantidad", lenguaje);
                string promocion = Mensaje.ObtenerDescripcion("XPromocion", lenguaje);
                string total = Mensaje.ObtenerDescripcion("XTotal", lenguaje);

                string granTotal = Mensaje.ObtenerDescripcion("XGRANTOTAL", lenguaje);
                string totalCedi = Mensaje.ObtenerDescripcion("Xtotalcentrodistribucion", lenguaje);
                string totalFolios = Mensaje.ObtenerDescripcion("XTotalFolios", lenguaje);
                string totalVendido = Mensaje.ObtenerDescripcion("XTotalVendido", lenguaje);
                string granTotalCedi = Mensaje.ObtenerDescripcion("Xgrantotalcentrodistribucion", lenguaje);

                if (ReportType)
                {
                    string precioUnitario = Mensaje.ObtenerDescripcion("XPU", lenguaje);
                    string subTotal = Mensaje.ObtenerDescripcion("XSubtotal", lenguaje);
                    string descProducto = Mensaje.ObtenerDescripcion("XDesc.Producto", lenguaje);
                    string descCliente = Mensaje.ObtenerDescripcion("XDesc.Cliente", lenguaje);
                    string descVendedor = Mensaje.ObtenerDescripcion("XDesc.Vendedor", lenguaje);
                    string impuesto = Mensaje.ObtenerDescripcion("XImpuesto", lenguaje);

                    report2 = new R021_Detailed_Design();
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
                    report2.headerFecha.Text = fecha;
                    report2.L_FechaRango.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));

                    report2.Label_Clave.Text = clave;
                    report2.Label_Producto.Text = producto;
                    report2.Label_Unidad.Text = unidad;
                    report2.Label_Cantidad.Text = cantidad;
                    report2.Label_Promocion.Text = promocion;
                    report2.Label_PU.Text = precioUnitario;
                    report2.Label_Subtotal.Text = subTotal;
                    report2.Label_DescProducto.Text = descProducto;
                    report2.Label_DescCliente.Text = descCliente;
                    report2.Label_DescVendedor.Text = descVendedor;
                    report2.Label_Impuesto.Text = impuesto;
                    report2.Label_Total.Text = total;

                    report2.Lb_CEDI_Grupo.Text = cedi;
                    report2.Lb_Vendedor_Grupo.Text = vendedor;
                    report2.Lb_Fecha_Grupo.Text = ruta;
                    report2.Lb_Ruta_Grupo.Text = ruta;

                    report2.Lb_Total.Text = total;
                    report2.Lb_GTotal.Text = granTotal;
                    report2.Lb_Cedi.Text = totalCedi;
                    report2.Lb_TFolios.Text = totalFolios;
                    report2.Lb_TVendido.Text = totalVendido;
                    report2.Lb_GCedi.Text = granTotalCedi;

                    report2.Parameters["parameterCedi"].Value = CEDIS;
                    report2.Parameters["parameterRoutes"].Value = Sellers;
                    report2.Parameters["parameterSeller"].Value = Routes;
                    report2.Parameters["parameterScheme"].Value = CustomerSchemes;
                    report2.Parameters["parameterCustomer"].Value = Customers;
                    report2.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");
                    report2.Parameters["parameterDateEnd"].Value = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd"));
                    return report2;
                }
                else
                {
                    report1 = new R021_General_Design();
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
                    report1.headerFecha.Text = fecha;
                    report1.L_FechaRango.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));

                    report1.Label_Folio.Text = clave;
                    report1.Label_Clave.Text = clave;
                    report1.Label_Cliente.Text = clave;
                    report1.Label_Total.Text = total;

                    report1.Lb_CEDI_Grupo.Text = cedi;
                    report1.Lb_Vendedor_Grupo.Text = vendedor;
                    report1.Lb_Fecha_Grupo.Text = ruta;
                    report1.Lb_Ruta_Grupo.Text = ruta;

                    report1.Lb_GTotal.Text = granTotal;
                    report1.Lb_Cedi.Text = totalCedi;
                    report1.Lb_TFolios.Text = totalFolios;
                    report1.Lb_TVendido.Text = totalVendido;
                    report1.Lb_GCedi.Text = granTotalCedi;

                    report1.Parameters["parameterCedi"].Value = CEDIS;
                    report1.Parameters["parameterRoutes"].Value = Sellers;
                    report1.Parameters["parameterSeller"].Value = Routes;
                    report1.Parameters["parameterScheme"].Value = CustomerSchemes;
                    report1.Parameters["parameterCustomer"].Value = Customers;
                    report1.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");
                    report1.Parameters["parameterDateEnd"].Value = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd"));
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