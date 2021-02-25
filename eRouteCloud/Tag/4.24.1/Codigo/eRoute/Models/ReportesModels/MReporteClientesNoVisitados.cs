using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class MReporteClientesNoVisitados
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
                sConsulta.AppendLine("SELECT DISTINCT DIA.FechaCaptura, (RUT.RUTClave + '-' + RUT.Descripcion) AS Deposito,Es.Clave AS Ruta, ");
                sConsulta.AppendLine("CLI.Clave, CLI.RazonSocial, CLI.IdElectronico, CLD.Calle , CLD.Numero, ");
                sConsulta.AppendLine("CLD.NumInt, CLD.Colonia, CLD.Localidad, CLD.Poblacion, CLD.Entidad, ");
                sConsulta.AppendLine("CLD.CodigoPostal, CLD.ReferenciaDom, str(CLD.CoordenadaX, 20, 12) AS CoordenadaX, str(CLD.CoordenadaY, 20, 12) AS CoordenadaY ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN DIA (NOLOCK) ON DIA.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN ClienteDomicilio CLD (NOLOCK) ON CLD.ClienteClave = CLI.ClienteClave AND CLD.Tipo= 2 ");
                sConsulta.AppendLine("INNER JOIN ClienteEsquema CE (NOLOCK) ON CE.ClienteClave = Cli.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Esquema Es (NOLOCK) ON CE.EsquemaID = Es.EsquemaID ");
                sConsulta.AppendLine("WHERE AGV.ClienteClave NOT IN (SELECT VIS.ClienteClave ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("WHERE VIS.DiaClave = AGV.DiaClave ) ");
                //sConsulta.AppendLine(" AND AGV.RUTClave IN ('006') AND convert(datetime,Convert(varchar(20),DIA.FechaCaptura,112)) between '2017-01-01T00:00:00' AND '2017-01-05T00:00:00' ");
                sConsulta.AppendLine(pvCondicion);

                QueryString = "";

                QueryString = sConsulta.ToString();

                List<MReporteClientesPorRutaModel> User = Connection.Query<MReporteClientesPorRutaModel>(QueryString, null, null, true, 600).ToList();

                if (User.Count() <= 0)
                {
                    return null;
                }


                var lista = (from c in User
                             select c).ToList();

                ReporteClientesNoVisitados report = new ReporteClientesNoVisitados();
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

                report.fecha.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.fechaActual1.Text = DateTime.Now.ToString("d");

                report.xl1.DataBindings.Add("Text", null, "FechaCaptura");
                report.xl2.DataBindings.Add("Text", null, "Deposito");
                report.xl3.DataBindings.Add("Text", null, "Ruta");
                report.xl4.DataBindings.Add("Text", null, "Clave");
                report.xl5.DataBindings.Add("Text", null, "RazonSocial");
                report.xl6.DataBindings.Add("Text", null, "IdElectronico");
                report.xl7.DataBindings.Add("Text", null, "Calle");
                report.xl8.DataBindings.Add("Text", null, "Numero");
                report.xl9.DataBindings.Add("Text", null, "NumInt");
                report.xl10.DataBindings.Add("Text", null, "Colonia");
                report.xl11.DataBindings.Add("Text", null, "Localidad");
                report.xl12.DataBindings.Add("Text", null, "Poblacion");
                report.xl13.DataBindings.Add("Text", null, "Entidad");
                report.xl14.DataBindings.Add("Text", null, "CodigoPostal");
                report.xl15.DataBindings.Add("Text", null, "ReferenciaDom");
                report.xl16.DataBindings.Add("Text", null, "CoordenadaX");
                report.xl17.DataBindings.Add("Text", null, "CoordenadaY");

                return report;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    class MReporteClientesPorRutaModel
    {
        public DateTime FechaCaptura { get; set; }
        public string Deposito { get; set; }
        public string Ruta { get; set; }
        public string Clave { get; set; }
        public string RazonSocial { get; set; }
        public string IdElectronico { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string NumInt { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Poblacion { get; set; }
        public string Entidad { get; set; }
        public string CodigoPostal { get; set; }
        public string ReferenciaDom { get; set; }
        public string CoordenadaX { get; set; }
        public string CoordenadaY { get; set; }
    }
}