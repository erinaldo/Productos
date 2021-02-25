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
    public class R077DevolucionesComision
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private R077_Report_Design report;
        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream LogoEmpresa, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string Sellers)
        {
            StringBuilder sConsulta = new StringBuilder();
            var NomVendedores = "";
            string[] SellersArrays = Sellers.Split(',');

            if (!Sellers.Equals(""))
            {
                var Vendedor = (from V in db.Vendedor
                                    //join U in db.Usuario on V.USUId equals U.USUId
                                where SellersArrays.Contains(V.VendedorID)
                                //V.VendedorID == Sellers
                                select V.Nombre).ToList();

                //NomVendedores = Vendedor[0].ToString();

                foreach (var item in Vendedor)
                {
                    NomVendedores += item;
                }
            }

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R077DevolucionesComision]");
            sConsulta.AppendLine("@filterCedi = '" + CEDIS + "',");
            sConsulta.AppendLine("@filterSeller = '" + Sellers + "',");
            sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "'");

            QueryString = sConsulta.ToString();

            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                var lenguaje = ObtenerLenguaje();
                report = new R077_Report_Design();
                string cedi = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje);
                string fecha = Mensaje.ObtenerDescripcion("XFecha", lenguaje);
                string vendedor = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);

                string producto = Mensaje.ObtenerDescripcion("XProducto", lenguaje);
                string sabado = Mensaje.ObtenerDescripcion("XSabado", lenguaje);
                string lunes = Mensaje.ObtenerDescripcion("XLunes", lenguaje);
                string martes = Mensaje.ObtenerDescripcion("XMartes", lenguaje);
                string miercoles = Mensaje.ObtenerDescripcion("XMiercoles", lenguaje);
                string jueves = Mensaje.ObtenerDescripcion("XJueves", lenguaje);
                string viernes = Mensaje.ObtenerDescripcion("XViernes", lenguaje);
                string totales = Mensaje.ObtenerDescripcion("XTOTALES", lenguaje);
                string diferencia = Mensaje.ObtenerDescripcion("XDiferencia", lenguaje);
                string diferenciaCosto = Mensaje.ObtenerDescripcion("XDiferenciaEnCosto", lenguaje);
                string dev = Mensaje.ObtenerDescripcion("XDev", lenguaje);
                string vta = Mensaje.ObtenerDescripcion("XVta", lenguaje);
                string top = Mensaje.ObtenerDescripcion("XTop", lenguaje);
                string exe = Mensaje.ObtenerDescripcion("XExe", lenguaje);
                string pu = Mensaje.ObtenerDescripcion("XP.U", lenguaje);
                string totalPagar = Mensaje.ObtenerDescripcion("XTotalAPagar", lenguaje);
                string totalVenta = Mensaje.ObtenerDescripcion("XTotalVenta", lenguaje);
                string comisionParcial = Mensaje.ObtenerDescripcion("XComisionParcial", lenguaje);
                string totalDevolucion = Mensaje.ObtenerDescripcion("XTotalDevolucion", lenguaje);
                string comisionFinal = Mensaje.ObtenerDescripcion("XComisionFinal", lenguaje);

                report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                report.logo.Image = Image.FromStream(LogoEmpresa);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.report_Company.Text = CompanyName.ToUpper();
                report.report_Name.Text = ReportName.ToUpper();
                report.L_CEDI.Text = NameCEDIS;
                report.L_FechaRango.Text = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                report.L_VendedorNombre.Text = NomVendedores;

                report.Lb_Producto.Text = producto;
                report.Lb_Sabado.Text = sabado;
                report.Lb_Lunes.Text = lunes;
                report.Lb_Martes.Text = martes;
                report.Lb_Miercoles.Text = miercoles;
                report.Lb_Jueves.Text = jueves;
                report.Lb_Viernes.Text = viernes;
                report.Lb_Totales.Text = totales;
                report.Lb_Diferencia.Text = diferencia;
                report.Lb_DiferenciaCosto.Text = diferenciaCosto;
                report.Lb_Dev1.Text = dev;
                report.Lb_Vta1.Text = vta;
                report.Lb_Dev2.Text = dev;
                report.Lb_Vta2.Text = vta;
                report.Lb_Dev3.Text = dev;
                report.Lb_Vta3.Text = vta;
                report.Lb_Dev4.Text = dev;
                report.Lb_Vta4.Text = vta;
                report.Lb_Dev5.Text = dev;
                report.Lb_Vta5.Text = vta;
                report.Lb_Dev6.Text = dev;
                report.Lb_Vta6.Text = vta;
                report.Lb_Dev7.Text = dev;
                report.Lb_Vta7.Text = vta;
                report.Lb_Top.Text = top;
                report.Lb_Exe.Text = exe;
                report.Lb_Pu.Text = pu;
                report.Lb_TotalPagar.Text = totalPagar;
                report.Lb_TotalVenta.Text = totalVenta;
                report.Lb_ComisionParcial.Text = comisionParcial;
                report.Lb_TotalDevolucion.Text = totalDevolucion;
                report.Lb_ComisionFinal.Text = comisionFinal;
                report.Lb_FechaImpresion.Text = Mensaje.ObtenerDescripcion("XFechaHoraImpresion", lenguaje);

                report.Parameters["parameterCedi"].Value = CEDIS;
                report.Parameters["parameterSeller"].Value = Sellers;
                report.Parameters["parameterDateIni"].Value = DateTime.Parse(InitialDate).ToString("yyyyMMdd");

                return report;
            }
            else
            {
                return null;
            }
        }
    }
}