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
    public class R016VentaEsquemaProducto
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private R016VentasEsquemasProductos report;
        private string QueryString;
        private RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public XtraReport GetReport(string ReportName, string CompanyName, MemoryStream LogoEmpresa, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string FinalDate, string Routes, string Sellers)
        {
            try
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
                sConsulta.AppendLine("EXECUTE [DBO].[stpr_R016VentaEsquemaProducto]");
                sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
                sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
                sConsulta.AppendLine("@FILTRORUTAS = '" + Routes + "',");
                sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
                sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "',");
                sConsulta.AppendLine("@noConsulta = 1");
                sConsulta.AppendLine("");

                QueryString = sConsulta.ToString();
                Connection.Open();
                var query = Connection.Query(QueryString).ToList();
                Connection.Close();

                if (query.Count() > 0)
                {
                    var lenguaje = ObtenerLenguaje();

                    report = new R016VentasEsquemasProductos();
                    report.Name = ReportName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                    report.logo.Image = Image.FromStream(LogoEmpresa);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    report.empresa.Text = CompanyName.ToUpper();
                    report.reporte.Text = ReportName.ToUpper();
                    

                    report.Lb_CEDI.Text = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje) + ":";
                    report.Lb_Fecha.Text = Mensaje.ObtenerDescripcion("XFecha", lenguaje) + ":";
                    report.Lb_Vendedor.Text = Mensaje.ObtenerDescripcion("XVendedor", lenguaje) + ":";
                    report.Lb_Ruta.Text = Mensaje.ObtenerDescripcion("XRuta", lenguaje) + ":";

                    report.X_CEDI.Text = NameCEDIS;
                    report.X_Fecha.Text = (StatusDate == "Entre" ? DateTime.Parse(InitialDate).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));
                    report.X_Vendedor.Text = NomVendedores;
                    report.X_Ruta.Text = Routes;

                    if (!ConversionKg[0])
                    {
                        report.Label_KiloLitro.Visible = false;
                        report.xrLabel24.Visible = false;
                        report.xrLabel32.Visible = false;
                    }

                    report.Label_Clave.Text = Mensaje.ObtenerDescripcion("XClave", lenguaje);
                    report.Label_Nombre.Text = Mensaje.ObtenerDescripcion("XNombre", lenguaje);
                    report.Label_Unidades.Text = Mensaje.ObtenerDescripcion("XUnidades", lenguaje);
                    report.Label_KiloLitro.Text = Mensaje.ObtenerDescripcion("XKiloLitros", lenguaje);
                    report.Label_Importe.Text = Mensaje.ObtenerDescripcion("XImporte", lenguaje);
                    report.Label_Descuentos.Text = Mensaje.ObtenerDescripcion("XDescuentos", lenguaje);
                    report.Label_Total.Text = Mensaje.ObtenerDescripcion("XTotal", lenguaje);

                    report.Lb_CEDI_Grupo.Text = Mensaje.ObtenerDescripcion("Xcentrodistribucion", lenguaje);
                    report.Lb_Fecha_Grupo.Text = Mensaje.ObtenerDescripcion("XFecha", lenguaje);
                    report.Lb_Vendedor_Grupo.Text = Mensaje.ObtenerDescripcion("XVendedor", lenguaje);
                    report.Lb_Ruta_Grupo.Text = Mensaje.ObtenerDescripcion("XRuta", lenguaje);

                    report.Lb_Total.Text = Mensaje.ObtenerDescripcion("XTotal", lenguaje);

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
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}