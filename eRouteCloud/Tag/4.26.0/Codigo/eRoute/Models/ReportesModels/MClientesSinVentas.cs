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
    public class MClientesSinVentas
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        ClientesSinVenta report;
        RouteEntities db = new RouteEntities();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string ReportName, string Routes, string FechaInicial, string FechaFinal, string StatusDate)
        {
            if (FechaInicial != null && Routes != "")
            {
                FechaInicial = DateTime.Parse(FechaInicial).ToString("yyyy-MM-dd");
                FechaFinal = (StatusDate == "Entre" ? DateTime.Parse(FechaFinal).ToString("yyyy-MM-dd") : FechaFinal);

                #region consulta
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteClienteSinVenta] ");
                sConsulta.AppendLine("@filtroRutas = '" + Routes + "', ");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "', ");
                sConsulta.AppendLine("@filtroFechaFin = '" + FechaFinal + "' ");
                QueryString = sConsulta.ToString();
                var query = Connection.Query(QueryString).ToList();
                #endregion

                if (query.Count() > 0)
                {
                    var lenguaje = ObtenerLenguaje();

                    report = new ClientesSinVenta();
                    report.Parameters["filtroRutas"].Value = Routes;
                    report.Parameters["filtroFechaInicio"].Value = FechaInicial;
                    report.Parameters["filtroFechaFin"].Value = FechaFinal;
                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    report.logo.Image = Image.FromStream(mStream);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    report.empresa.Text = NombreEmpresa;
                    report.reporte.Text = NombreReporte;

                    report.XFecha.Text = Mensaje.ObtenerDescripcion("XFecha", lenguaje) + ":";
                    report.L_FechaRango.Text = DateTime.Parse(FechaInicial).ToString("dd/MM/yyyy") + (StatusDate == "Entre" ? " - " + DateTime.Parse(FechaFinal).ToString("dd/MM/yyyy") : FechaFinal);
                    report.XRutas.Text = Mensaje.ObtenerDescripcion("XRuta(s)", lenguaje) + ":";
                    report.L_Ruta.Text = Routes;
                    report.XDiaTrabajo.Text = Mensaje.ObtenerDescripcion("XDiaTrabajo", lenguaje);
                    report.XRuta.Text = Mensaje.ObtenerDescripcion("XRuta", lenguaje);
                    report.XClaveCliente.Text = Mensaje.ObtenerDescripcion("XClaveCliente", lenguaje);
                    report.XCliente.Text = Mensaje.ObtenerDescripcion("XCliente", lenguaje);
                    report.XNombreCorto.Text = Mensaje.ObtenerDescripcion("XNombreCorto", lenguaje);
                    report.XCalle.Text = Mensaje.ObtenerDescripcion("XCalle", lenguaje);
                    report.XExterior.Text = Mensaje.ObtenerDescripcion("XExterior", lenguaje);
                    report.XInterior.Text = Mensaje.ObtenerDescripcion("XInterior", lenguaje);
                    report.XImcumplimiento.Text = Mensaje.ObtenerDescripcion("XImcumplimiento", lenguaje);
                    report.XFechaHoraImpresion.Text = Mensaje.ObtenerDescripcion("XFechaHoraImpresion", lenguaje);
                    report.XClienteNoVisitado.Text = Mensaje.ObtenerDescripcion("XClienteNoVisitado", lenguaje) + ":";
                    report.XClienteVisitadoSinVenta.Text = Mensaje.ObtenerDescripcion("XClienteVisitadoSinVenta", lenguaje) + ":";
                    report.Name = ReportName + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");
                    return report;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }
    }
}