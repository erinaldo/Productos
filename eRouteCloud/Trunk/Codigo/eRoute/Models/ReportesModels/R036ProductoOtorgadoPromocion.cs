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
    public class R036ProductoOtorgadoPromocion
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R036_Report_Design report1;
        private string companyName;
        private string reportName;
        private string cedis;
        private string namecedis;
        private string seller;
        private string nameSeller;
        private string routes;
        private string initialDate;
        private string finalDate;
        private string statusDate;
        private string language;
        private string queryString;
        private StringBuilder sConsulta = new StringBuilder();
        private RouteEntities db = new RouteEntities();

        public string getLanguage()
        {
            var language = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return language[0];
        }

        public XtraReport GetReport(string reportName, string companyName, MemoryStream companyLogo, string CEDIS, string nameCEDIS, string statusDate, string initialDate, string finalDate, string routes, string seller)
        {
            var namSeller = "";
            string[] sellerArray = seller.Split(',');

            if (!seller.Equals("") && sellerArray.Length == 1)
            {
                var sel = (from V in db.Vendedor
                           join U in db.Usuario on V.USUId equals U.USUId
                           where V.VendedorID == seller
                           select V.Nombre).Take(1).ToList();
                namSeller = sel[0].ToString();
            }

            this.companyName = companyName;
            this.reportName = reportName;
            this.cedis = CEDIS;
            this.namecedis = nameCEDIS;
            this.seller = seller;
            this.nameSeller = namSeller;
            this.routes = routes;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R036ProductoOtorgadoPromo]");
            sConsulta.AppendLine("@filterSeller = '" + this.seller + "',");
            sConsulta.AppendLine("@filterRoutes = '" + this.routes + "',");
            sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(initialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@filterDateEnd = '" + (statusDate == "Entre" ? DateTime.Parse(finalDate).ToString("yyyyMMdd") : DateTime.Parse(initialDate).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@numQuery = 0 ");

            queryString = sConsulta.ToString();
            Connection.Open();
            var query = Connection.Query(queryString, null, null, true, 600).ToList();
            Connection.Close();

            if (initialDate != null)
            {
                this.initialDate = DateTime.Parse(initialDate).ToString("dd/MM/yyyy");
                this.finalDate = (statusDate == "Entre" ? DateTime.Parse(finalDate).ToString("dd/MM/yyyy") : initialDate);
                this.statusDate = statusDate;
            }

            if (query.Count() > 0)
            {
                this.language = getLanguage();
                report1 = new R036_Report_Design();

                string cedi = Mensaje.ObtenerDescripcion("Xcentrodistribucion", this.language);
                string vendedor = Mensaje.ObtenerDescripcion("XVendedor", this.language);
                string ruta = Mensaje.ObtenerDescripcion("XRuta", this.language);
                string fecha = Mensaje.ObtenerDescripcion("XFecha", this.language);

                string productoEntregado = Mensaje.ObtenerDescripcion("Xproductoentregado", this.language);
                string producto = Mensaje.ObtenerDescripcion("XProducto", this.language);
                string unidad = Mensaje.ObtenerDescripcion("XUnidad", this.language);
                string cantidad = Mensaje.ObtenerDescripcion("XCantidad", this.language);
                string pedido = Mensaje.ObtenerDescripcion("XPedido", this.language);
                string promocion = Mensaje.ObtenerDescripcion("XPromocion", this.language);
                string cliente = Mensaje.ObtenerDescripcion("XCliente", this.language);
                string surtido = Mensaje.ObtenerDescripcion("Xfechasurtido", this.language);

                report1.Name = this.reportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                report1.logo.Image = Image.FromStream(companyLogo);
                report1.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report1.report_Company.Text = this.companyName.ToUpper();
                report1.report_Name.Text = this.reportName.ToUpper();
                report1.headerCEDI.Text = cedi;
                report1.L_CEDI.Text = this.namecedis;
                report1.headerVendedor.Text = vendedor;
                report1.L_VendedorNombre.Text = this.nameSeller;
                report1.headerRuta.Text = ruta;
                report1.L_Ruta.Text = this.routes;
                report1.headerFecha.Text = fecha;
                report1.L_FechaRango.Text = (this.statusDate == "Entre" ? DateTime.Parse(this.initialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(this.finalDate).ToString("dd/MM/yyyy") : DateTime.Parse(this.initialDate).ToString("dd/MM/yyyy"));

                report1.Label_ProducEntr.Text = productoEntregado;
                report1.Label_Producto.Text = producto;
                report1.Label_Unidad.Text = unidad;
                report1.Label_Cantidad.Text = cantidad;
                report1.Label_Pedidos.Text = pedido;
                report1.Label_Fecha.Text = fecha;
                report1.Label_Promocion.Text = promocion;
                report1.Label_Cliente.Text = cliente;
                report1.Label_FechaSurtido.Text = surtido;

                report1.Lb_Vendedor_Grupo.Text = vendedor;
                report1.Lb_Ruta_Grupo.Text = ruta;

                report1.Parameters["parameterSeller"].Value = this.seller;
                report1.Parameters["parameterRoutes"].Value = this.routes;
                report1.Parameters["parameterDateIni"].Value = DateTime.Parse(this.initialDate).ToString("yyyyMMdd");
                report1.Parameters["parameterDateEnd"].Value = (this.statusDate == "Entre" ? DateTime.Parse(this.finalDate).ToString("yyyyMMdd") : DateTime.Parse(this.initialDate).ToString("yyyyMMdd"));

                sConsulta.Clear();
                sConsulta.AppendLine("EXECUTE [DBO].[stpr_R036ProductoOtorgadoPromo]");
                sConsulta.AppendLine("@filterSeller = '" + this.seller + "',");
                sConsulta.AppendLine("@filterRoutes = '" + this.routes + "',");
                sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(initialDate).ToString("yyyyMMdd") + "',");
                sConsulta.AppendLine("@filterDateEnd = '" + (statusDate == "Entre" ? DateTime.Parse(finalDate).ToString("yyyyMMdd") : DateTime.Parse(initialDate).ToString("yyyyMMdd")) + "',");
                sConsulta.AppendLine("@numQuery = 3");

                queryString = sConsulta.ToString();
                Connection.Open();
                var query2 = Connection.Query(queryString, null, null, true, 600).ToList();
                Connection.Close();

                if (query2.Count() == 0)
                {
                    report1.xrSubreport3.Visible = false;
                }

                return report1;
            }
            else
            {
                return null;
            }
        }
    }
}