using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using Dapper;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class PuntosGPS
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondition, string RutasSplit, string VendedorSplit, string FechaInicial, string FechaFinal, string nombreCedis)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF");
                sConsulta.AppendLine("set nocount on");
                sConsulta.AppendLine("select v.VisitaClave, c.Clave, c.RazonSocial + ' - ' + c.NombreContacto as ClienteContacto, r.Descripcion as Ruta, str(p.CoordenadaX, 20, 12) as LongitudX, ");
                sConsulta.AppendLine("str(p.CoordenadaY, 20, 12) as LatitudY, ven.Nombre as Vendedor, left(convert(time, v.FechaHoraInicial), 8) as HoraInicial, sum(t.Total) as VentaTotal, av.Orden as SecuenciaConfigurada, ");
                sConsulta.AppendLine("case v.GPSLeido when 1 then 'SI' else 'NO' end as GPSLeido, case v.CodigoLeido when 1 then 'SI' else 'NO' end as CodigoLeido, d.DiaClave as DiaTrabajo, d.FechaCaptura, ");
                sConsulta.AppendLine("(select Simbolo from Moneda (NOLOCK) where MonedaID = (select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda ");
                sConsulta.AppendLine("from Dia d (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita v (NOLOCK) ON d.DiaClave = v.DiaClave ");
                sConsulta.AppendLine("inner join (select VendedorId, AlmacenId from VENCentroDistHist (NOLOCK) where FechaFinal >= '" + FechaInicial.Remove(19) + "' AND VCHFechaInicial <= '" + FechaInicial.Remove(19) + "') as Cedi ON v.VendedorID = CEDI.VendedorId ");
                sConsulta.AppendLine("inner join Almacen a (NOLOCK) ON Cedi.AlmacenId = a.AlmacenId ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) ON v.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Vendedor ven (NOLOCK) ON v.VendedorId = ven.VendedorId ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) ON v.RutClave = r.RutClave ");
                sConsulta.AppendLine("left join PuntoGPS p (NOLOCK) ON v.VisitaClave = p.VisitaClave ");
                sConsulta.AppendLine("inner join AgendaVendedor av (NOLOCK) ON d.DiaClave = av.DiaClave and v.VendedorId = av.VendedorId and v.RutClave = av.RutClave and v.ClienteClave = av.ClienteClave ");
                sConsulta.AppendLine("left join ( ");
                sConsulta.AppendLine("select t.VisitaClave, Total ");
                sConsulta.AppendLine("from Transprod t (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON t.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Visita v (NOLOCK) ON isnull(t.VisitaClave1, t.VisitaClave) = v.VisitaClave and isnull(t.diaclave1, t.diaClave) = v.DiaClave ");
                sConsulta.AppendLine("where Dia.FechaCaptura = '" + FechaInicial.Remove(19) + "' and Tipo = 1 and TipoFase in (2, 3) and ");
                if (String.IsNullOrEmpty(VendedorSplit))
                    sConsulta.AppendLine("v.RUTClave = '" + RutasSplit + "' ");
                else
                    sConsulta.AppendLine("v.VendedorId = '" + VendedorSplit + "' ");
                sConsulta.AppendLine(") t on v.VisitaClave = t.VisitaClave ");
                sConsulta.AppendLine(pvCondition);
                sConsulta.AppendLine("group by v.VisitaClave, c.Clave, c.RazonSocial + ' - ' + c.NombreContacto, r.Descripcion, p.CoordenadaX, p.CoordenadaY, ven.Nombre, v.FechaHoraInicial, ");
                sConsulta.AppendLine("av.Orden, v.GPSLeido, v.CodigoLeido, d.DiaClave, d.FechaCaptura ");
                sConsulta.AppendLine("order by d.FechaCaptura, HoraInicial ");
                QueryString = "";

                QueryString = sConsulta.ToString();

                List<PuntosGPSModel> User = Connection.Query<PuntosGPSModel>(QueryString, null, null, true, 600).ToList();

                if (User.Count() <= 0)
                {
                    return null;
                }

                var lista = (from c in User
                             select c).ToList();

                ReportePuntosGPS report = new ReportePuntosGPS();
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


                //ReportHeader
                report.headerlabelcedis.Text = nombreCedis;
                //report.labelfechaheader.DataBindings.Add("Text", report.DataSource, "Fecha", "{0:dd/MM/yyyy}");
                report.labelfechaheader.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                //report.labelrutasheader.DataBindings.Add("Text", report.DataSource, "Ruta");
                report.labelrutasheader.Text = RutasSplit;
                report.labelvendedorheader.DataBindings.Add("Text", report.DataSource, "Vendedor");

                report.l1.DataBindings.Add("Text", null, "Clave");
                report.l2.DataBindings.Add("Text", null, "ClienteContacto");
                report.l3.DataBindings.Add("Text", null, "Ruta");
                report.l4.DataBindings.Add("Text", null, "LongitudX");
                report.l5.DataBindings.Add("Text", null, "LatitudY");
                report.l6.DataBindings.Add("Text", null, "Vendedor");
                report.l7.DataBindings.Add("Text", null, "HoraInicial");
                report.l8.DataBindings.Add("Text", null, "VentaTotal", "{0:$#.00}");
                report.l9.DataBindings.Add("Text", null, "SecuenciaConfigurada");
                report.l10.DataBindings.Add("Text", null, "GPSLeido");
                report.l11.DataBindings.Add("Text", null, "CodigoLeido");
                report.l12.DataBindings.Add("Text", null, "DiaTrabajo");


                return report;
            }
            catch
            {
                return new ReportePuntosGPS();
            }
        }
    }

    class PuntosGPSModel
    {
        public string VisitaClave { get; set; }
        public string Clave { get; set; }
        public string ClienteContacto { get; set; }
        public string Ruta { get; set; }
        public string LongitudX { get; set; }
        public string LatitudY { get; set; }
        public string Vendedor { get; set; }
        public string HoraInicial { get; set; }
        public double VentaTotal { get; set; }
        public string SecuenciaConfigurada { get; set; }
        public string GPSLeido { get; set; }
        public string CodigoLeido { get; set; }
        public string DiaTrabajo { get; set; }
        public DateTime FechaCaptura { get; set; }
        public string SimboloMoneda { get; set; }
    }
}