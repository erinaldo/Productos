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
    public class R001Facturas
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R001_General_Design report1;
        private R001_Detailed_Design report2;
        private R001_SubReport report3;
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
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R001Facturas]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + Routes + "',");
            sConsulta.AppendLine("@FILTROCLIENTES = '" + Customers + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = " + (ReportType == true ? 0 : 1));
            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                var lenguaje = ObtenerLenguaje();

                string CEDI = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje);
                string FECHA = Mensaje.ObtenerDescripcion("XFecha", lenguaje);
                string VENDEDOR = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);
                string RUTA = Mensaje.ObtenerDescripcion("XRuta", lenguaje);
                string folio = Mensaje.ObtenerDescripcion("XFolio", lenguaje);
                string cliente = Mensaje.ObtenerDescripcion("XCliente", lenguaje);
                string clave = Mensaje.ObtenerDescripcion("XClave", lenguaje);
                string producto = Mensaje.ObtenerDescripcion("XProducto", lenguaje);
                string unidad = Mensaje.ObtenerDescripcion("XUnidad", lenguaje);
                string precioUnidad = Mensaje.ObtenerDescripcion("XP.U", lenguaje);
                string cantidad = Mensaje.ObtenerDescripcion("XCantidad", lenguaje);
                string subtotal = Mensaje.ObtenerDescripcion("XSubtotal", lenguaje);
                string descProducto = Mensaje.ObtenerDescripcion("XDesc.Producto", lenguaje);
                string descCliente = Mensaje.ObtenerDescripcion("XDesc.Cliente", lenguaje);
                string descVendedor = Mensaje.ObtenerDescripcion("XDesc.Vendedor", lenguaje);
                string impuesto = Mensaje.ObtenerDescripcion("XImpuesto", lenguaje);
                string total = Mensaje.ObtenerDescripcion("XTotal", lenguaje);
                string granTotal = Mensaje.ObtenerDescripcion("XGRANTOTAL", lenguaje);
                string totalCedi = Mensaje.ObtenerDescripcion("Xtotalcentrodistribucion", lenguaje);
                string totalFolios = Mensaje.ObtenerDescripcion("XTotalFolios", lenguaje);
                string totalProductos = Mensaje.ObtenerDescripcion("XTotalProductos", lenguaje);
                string totalVendido = Mensaje.ObtenerDescripcion("XTotalVendido", lenguaje);
                string granTotalCedi = Mensaje.ObtenerDescripcion("Xgrantotalcentrodistribucion", lenguaje);
                string ventasProducto = Mensaje.ObtenerDescripcion("XVentasProducto", lenguaje);

                if (ReportType)
                {
                    report2 = new R001_Detailed_Design();
                    report2.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                    report2.logo.Image = Image.FromStream(LogoEmpresa);
                    report2.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    report2.report_Company.Text = CompanyName.ToUpper();
                    report2.report_Name.Text = ReportName.ToUpper() + " " + Mensaje.ObtenerDescripcion("XDetallado", lenguaje).ToUpper();
                    report2.headerCEDI.Text = CEDI;
                    report2.L_CEDI.Text = NameCEDIS;
                    report2.headerFecha.Text = FECHA;
                    report2.L_FechaRango.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));
                    report2.headerVendedor.Text = VENDEDOR;
                    report2.L_VendedorNombre.Text = NomVendedores;
                    report2.headerRuta.Text = RUTA;
                    report2.L_Ruta.Text = Routes;
                    report2.Lb_Clave.Text = clave;
                    report2.Lb_Producto.Text = producto;
                    report2.Lb_Unidad.Text = unidad;
                    report2.Lb_Pu.Text = precioUnidad;
                    report2.Lb_Cantidad.Text = cantidad;
                    report2.Lb_SubTotal.Text = subtotal;
                    report2.Lb_DescProducto.Text = descProducto;
                    report2.Lb_DescCiente.Text = descCliente;
                    report2.Lb_DescVendedor.Text = descVendedor;
                    report2.Lb_Impuesto.Text = impuesto;
                    report2.Lb_TotalHeader.Text = total;
                    report2.Lb_Total.Text = total;
                    report2.Lb_GTotal.Text = granTotal;
                    report2.Lb_TotalCEDI.Text = totalCedi;
                    report2.Lb_Total_Folios.Text = totalFolios;
                    report2.Lb_Total_Productos.Text = totalProductos;
                    report2.Lb_Total_Vendido.Text = totalVendido;
                    report2.Lb_GCEDI.Text = granTotalCedi;
                    report2.Parameters["parameterCEDI"].Value = CEDIS;
                    report2.Parameters["parameterSeller"].Value = Sellers;
                    report2.Parameters["parameterRoutes"].Value = Routes;
                    report2.Parameters["parameterCustomers"].Value = Customers;
                    report2.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");
                    report2.Parameters["parameterDateEnd"].Value = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd"));
                    return report2;
                }
                else
                {
                    report1 = new R001_General_Design();
                    report1.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                    report1.logo.Image = Image.FromStream(LogoEmpresa);
                    report1.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    report1.report_Company.Text = CompanyName.ToUpper();
                    report1.report_Name.Text = ReportName.ToUpper() + " " + Mensaje.ObtenerDescripcion("XGeneral", lenguaje).ToUpper();
                    report1.headerCEDI.Text = CEDI;
                    report1.L_CEDI.Text = NameCEDIS;
                    report1.headerFecha.Text = FECHA;
                    report1.L_FechaRango.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));
                    report1.headerVendedor.Text = VENDEDOR;
                    report1.L_VendedorNombre.Text = NomVendedores;
                    report1.headerRuta.Text = RUTA;
                    report1.L_Ruta.Text = Routes;
                    report1.Label_Folio.Text = folio;
                    report1.Label_Clave.Text = clave;
                    report1.Label_Cliente.Text = cliente;
                    report1.Lb_Total.Text = total;
                    report1.Lb_CEDI_Grupo.Text = CEDI;
                    report1.Lb_Vendedor_Grupo.Text = VENDEDOR;
                    report1.Lb_Fecha_Grupo.Text = FECHA;
                    report1.Lb_Ruta_Grupo.Text = RUTA;
                    report1.Lb_GTotal.Text = granTotal;
                    report1.Lb_CEDI.Text = totalCedi;
                    report1.Lb_Total_Folios.Text = totalFolios;
                    report1.Lb_Total_Productos.Text = totalProductos;
                    report1.TProducto.Text = "";
                    report1.Lb_Total_Vendido.Text = totalVendido;
                    report1.Lb_GCEDI.Text = granTotalCedi;
                    report1.Parameters["parameterCEDI"].Value = CEDIS;
                    report1.Parameters["parameterSeller"].Value = Sellers;
                    report1.Parameters["parameterRoutes"].Value = Routes;
                    report1.Parameters["parameterCustomers"].Value = Customers;
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