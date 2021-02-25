using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class PuntosRecorrido
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("SELECT DIA.FechaCaptura AS DiaTrabajo, (RUT.RUTClave + '-' + RUT.Descripcion) AS Ruta, ");
                sConsulta.AppendLine("str(GPS.CoordenadaX, 20, 12) AS LongitudX, str(GPS.CoordenadaY, 20, 12) AS LatitudY, VEN.Nombre AS Vendedor ");
                sConsulta.AppendLine("FROM PuntoGPS GPS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON DIA.DiaClave = GPS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorId = GPS.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = GPS.RUTClave ");
                sConsulta.AppendLine("WHERE 1 = 1 ");
                sConsulta.AppendLine(pvCondicion);

                QueryString = "";

                QueryString = sConsulta.ToString();

                List<PuntosRecorridosModel> User = Connection.Query<PuntosRecorridosModel>(QueryString, null, null, true, 600).ToList();

                if (User.Count() <= 0)
                {
                    return null;
                }

                var lista = (from c in User
                             select c).ToList();

                ReportePuntosRecorrido report = new ReportePuntosRecorrido();
                report.DataSource = lista;


                DateTime fInicio = DateTime.Parse(FechaInicial);
                DateTime fFin = DateTime.Now;
                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
                {
                    FechaFinal = "";
                }
                else
                {
                    fFin = DateTime.Parse(FechaFinal);
                    FechaFinal = " - " + fFin.Date.ToShortDateString();

                }

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;


                report.labelfechaheader.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.labelrutasheader.Text = RutasSplit;

                report.l1.DataBindings.Add("Text", null, "DiaTrabajo", "{0:dd/MM/yyyy}");
                report.l2.DataBindings.Add("Text", null, "Ruta");
                report.l3.DataBindings.Add("Text", null, "LongitudX");
                report.l4.DataBindings.Add("Text", null, "LatitudY");
                report.l5.DataBindings.Add("Text", null, "Vendedor");

                return report;
            }
            catch
            {
                return new ReportePuntosRecorrido();
            }
        }
    }

    class PuntosRecorridosModel
    {
        public DateTime DiaTrabajo { get; set; }
        public string Ruta { get; set; }
        public string LongitudX { get; set; }
        public string LatitudY { get; set; }
        public string Vendedor { get; set; }
    }


}