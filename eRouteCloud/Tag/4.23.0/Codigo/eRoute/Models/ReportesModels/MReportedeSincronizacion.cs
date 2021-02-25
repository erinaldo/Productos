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
    public class MReportedeSincronizacion
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis, string Presupuesto, string promocion)
        {
            try
            {
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

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select ALM.Clave as ClaveCEDI, ALM.Nombre as ALMNombre, RUT.RUTClave, ");
                sConsulta.AppendLine("VEN.VendedorID as VendedorId, VEN.Nombre as VENNombre, CASE WHEN not VEJ.FechaFinal is null THEN 1 ELSE 0 END as CierreJornada, ");
                sConsulta.AppendLine("VEJ.FechaFinal as FechaHoraCierre, SIV.FechaHoraSincronizacion as FechaEnvioInformacion  ");
                sConsulta.AppendLine("from Vendedor VEN (NOLOCK)");
                sConsulta.AppendLine("inner join VENCentroDistHist VCH (NOLOCK) ON VEN.VendedorID = VCH.VendedorId  ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) ON VCH.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join VenRut VER (NOLOCK) ON VEN.VendedorID = VER.VendedorID and VER.TipoEstado = 1 ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) ON VER.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("left join VendedorJornada VEJ (NOLOCK) ON VEJ.VendedorId = VEN.VendedorID  ");
                sConsulta.AppendLine(" and convert(datetime,Convert(varchar(20),Convert(datetime, CONVERT (varchar(20), VEJ.VEJFechaInicial, 112),112),112)) <= '" + FechaInicial + "'  and convert(datetime,Convert(varchar(20),VEJ.FechaFinal,112)) >= '" + FechaInicial + "' ");
                sConsulta.AppendLine("left join SincronizacionVendedor SIV (NOLOCK) ON SIV.VendedorID = VEN.VendedorID and VEJ.DiaClave = SIV.Tabla ");
                sConsulta.AppendLine("where VEN.TipoEstado = 1 and RUT.TipoEstado = 1 ");
                sConsulta.AppendLine(" and ALM.Clave = '" + Cedis + "'  and convert(datetime,Convert(varchar(20),VCH.VCHFechaInicial,112)) <= '" + FechaInicial + "'  and convert(datetime,Convert(varchar(20),VCH.FechaFinal,112)) >= '" + FechaInicial + "' ");

                QueryString = "";

                QueryString = sConsulta.ToString();


                List<ReSin> repsin = Connection.Query<ReSin>(QueryString, null, null, true, 600).ToList();
                if (repsin.Count != 0)
                {



                    ReportedeSincronizacion report = new ReportedeSincronizacion();

                    if (repsin.Exists(x => x.CierreJornada == "0"))
                    {
                        report.x3.Text = "NO";
                    }
                    else
                    {
                        report.x3.Text = "SI";

                    }
                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    report.logo.Image = Image.FromStream(mStream);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    report.empresa.Text = NombreEmpresa;
                    report.reporte.Text = NombreReporte;


                    report.fechaf.Text = fInicio.Date.ToShortDateString() + FechaFinal;


                    //CEDI
                    report.centro.Text = Cedis + '-' + nombreCedis;


                    report.DataSource = repsin;

                    report.x1.DataBindings.Add("Text", null, "RUTClave");
                    report.x2.DataBindings.Add("Text", null, "VENNombre");
                    // report.x3.DataBindings.Add("Text", null, "CierreJornada");//, String.Compare("CierreJornada", "CierreJornada") == 0 ? "true" : "false");
                    report.x4.DataBindings.Add("Text", null, "FechaHoraCierre");
                    report.x5.DataBindings.Add("Text", null, "FechaEnvioInformacion");

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

    class ReSin
    {



        public String ClaveCEDI { get; set; }
        public String ALMNombre { get; set; }
        public String RUTClave { get; set; }
        public String VendedorId { get; set; }
        public String VENNombre { get; set; }
        public String CierreJornada { get; set; }
        public String FechaHoraCierre { get; set; }
        public String FechaEnvioInformacion { get; set; }
    }
}