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
    public class R014InformeVentaEsquema
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R014_Report_Design report;
        private string QueryString;
        private RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream LogoEmpresa, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string FinalDate, string Routes, string Sellers)
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

            var ConversionKg = (from CH in db.CONHist
                                orderby CH.CONHistFechaInicio descending
                                select CH.ConversionKg).Take(1).ToList();

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R014InformeVentaEsquema]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + Routes + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "'");
            sConsulta.AppendLine("");

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
                string clave = Mensaje.ObtenerDescripcion("XClave", lenguaje);
                string producto = Mensaje.ObtenerDescripcion("XProducto", lenguaje);
                string unidad = Mensaje.ObtenerDescripcion("XUnidad", lenguaje);
                string venta = Mensaje.ObtenerDescripcion("XVenta", lenguaje);
                string devolucion = Mensaje.ObtenerDescripcion("XDevolucion", lenguaje);
                string cambio = Mensaje.ObtenerDescripcion("XCambio", lenguaje);
                string cantidad = Mensaje.ObtenerDescripcion("XCantidad", lenguaje);
                string moneda = Mensaje.ObtenerDescripcion("X$", lenguaje);
                string total = Mensaje.ObtenerDescripcion("XTotal", lenguaje);
                string resumenUnidades = Mensaje.ObtenerDescripcion("Xresumendeunidades", lenguaje);
                string resumenImportes = Mensaje.ObtenerDescripcion("XRESUMENDEIMPORTES", lenguaje);
                string ventas = Mensaje.ObtenerDescripcion("XVentas", lenguaje);
                string devoluciones = Mensaje.ObtenerDescripcion("XDevoluciones", lenguaje);
                string cambios = Mensaje.ObtenerDescripcion("XCambios", lenguaje);

                report = new R014_Report_Design();

                if (!ConversionKg[0])
                {
                    report.Lb_KgLts.Visible = false;
                    report.Lb_KgLts2.Visible = false;
                    report.Lb_KgLts3.Visible = false;
                    report.xrLabel44.Visible = false;
                    report.xrLabel38.Visible = false;
                    report.xrLabel33.Visible = false;
                    report.xrLabel161.Visible = false;
                    report.xrLabel157.Visible = false;
                    report.xrLabel153.Visible = false;
                    report.Lb_ResumenKgLts.Visible = false;
                    report.Ventas3.Visible = false;
                    report.Devoluciones3.Visible = false;
                    report.Cambios3.Visible = false;
                    report.xrLabel187.Visible = false;
                    report.xrLabel183.Visible = false;
                    report.xrLabel179.Visible = false;
                }
                else
                {
                    string kglts = Mensaje.ObtenerDescripcion("XKgLt", lenguaje);
                    string resumenKgLts = Mensaje.ObtenerDescripcion("Xresumendekilolitros", lenguaje);

                    report.Lb_KgLts.Text = kglts;
                    report.Lb_KgLts2.Text = kglts;
                    report.Lb_KgLts3.Text = kglts;
                    report.Lb_ResumenKgLts.Text = resumenKgLts;
                    report.Ventas3.Text = ventas;
                    report.Devoluciones3.Text = devoluciones;
                    report.Cambios3.Text = cambios;
                }



                report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                report.logo.Image = Image.FromStream(LogoEmpresa);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.report_Company.Text = CompanyName.ToUpper();
                report.report_Name.Text = ReportName.ToUpper();
                report.headerCEDI.Text = CEDI;
                report.L_CEDI.Text = NameCEDIS;
                report.headerFecha.Text = FECHA;
                report.L_FechaRango.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));
                report.headerVendedor.Text = VENDEDOR;
                report.L_VendedorNombre.Text = NomVendedores;
                report.Lb_Clave.Text = clave;
                report.Lb_Producto.Text = producto;
                report.Lb_Unidad.Text = unidad;
                report.Lb_Venta.Text = venta;
                report.Lb_Devolucion.Text = devolucion;
                report.Lb_Cambio.Text = cambio;
                report.Lb_Cantidad.Text = cantidad;
                report.Lb_Moneda.Text = moneda;
                report.Lb_Cantidad2.Text = cantidad;
                report.Lb_Moneda2.Text = moneda;
                report.Lb_Cantidad3.Text = cantidad;
                report.Lb_Moneda3.Text = moneda;
                report.groupCEDI.Text = CEDI;
                report.groupFecha.Text = FECHA;
                report.groupVendedor.Text = VENDEDOR;
                report.groupHeaderRuta.Text = RUTA;
                report.Lb_Total.Text = total;

                report.Lb_ResumenUnidades.Text = resumenUnidades;
                report.Ventas1.Text = ventas;
                report.Devoluciones1.Text = devoluciones;
                report.Cambios1.Text = cambios;

                report.Lb_ResumenImportes.Text = resumenImportes;
                report.Ventas2.Text = ventas;
                report.Devoluciones2.Text = devoluciones;
                report.Cambios2.Text = cambios;



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