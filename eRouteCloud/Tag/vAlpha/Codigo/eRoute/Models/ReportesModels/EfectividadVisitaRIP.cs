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
    public class EfectividadVisitaRIP
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string sCondicion, string sCondicionDia1, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, AGV.RUTClave, RUT.Descripcion as RUTDescripcion, COUNT(Distinct AGV.ClienteClave) as VisitasPlaneadas, ");
                sConsulta.AppendLine("(Select COUNT(distinct VIS.ClienteClave) as ClientesVisitados  from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia Dia1 (NOLOCK) ON Dia1.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId =VIS.VendedorID and Dia1.FechaCaptura between VCH.VCHFechaInicial and VCH.FechaFinal ");
                sConsulta.AppendLine("where VIS.RutClave = AGV.RUTClave and ALM.AlmacenID = VCH.AlmacenId " + sCondicionDia1 + ") as VisitasExitosas, ");
                sConsulta.AppendLine("(Select COUNT(distinct VIS.ClienteClave) as ClientesVisitados from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia Dia1 (NOLOCK) ON Dia1.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId =VIS.VendedorID and Dia1.FechaCaptura between VCH.VCHFechaInicial and VCH.FechaFinal ");
                sConsulta.AppendLine("where VIS.FueraFrecuencia = 1 and VIS.RutClave = AGV.RUTClave and ALM.AlmacenID = VCH.AlmacenId " + sCondicionDia1 + ") as FueraDeRuta ");
                sConsulta.AppendLine("from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON Dia.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) ON RUT.RUTClave = AGV.RUTClave ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) ON ALM.Clave = AGV.ClaveCEDI ");
                sConsulta.AppendLine(sCondicion);
                sConsulta.AppendLine("group by  ALM.AlmacenID,ALM.Clave, ALM.Nombre, AGV.RUTClave, RUT.Descripcion ");
                sConsulta.AppendLine("order by ALM.Clave, AGV.RUTClave ");

                QueryString = sConsulta.ToString();

                List<EfectividadVisitaModel> EfectividadVisita = Connection.Query<EfectividadVisitaModel>(QueryString, null, null, true, 600).ToList();

                if (EfectividadVisita.Count() <= 0)
                {
                    return null;
                }


                ReporteEfectividadVisitaRIP report = new ReporteEfectividadVisitaRIP();
                report.DataSource = EfectividadVisita;

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


                EfectividadVisita.FirstOrDefault().TVisitasPlaneadas = EfectividadVisita.Sum(c => c.VisitasPlaneadas);
                EfectividadVisita.FirstOrDefault().TVisitasExitosas = EfectividadVisita.Sum(c => c.VisitasExitosas);
                EfectividadVisita.FirstOrDefault().TFueraDeRuta = EfectividadVisita.Sum(c => c.FueraDeRuta);
                EfectividadVisita.FirstOrDefault().TEfectividadVisitas = ((EfectividadVisita.FirstOrDefault().TVisitasExitosas - EfectividadVisita.FirstOrDefault().TFueraDeRuta) * 100) / EfectividadVisita.FirstOrDefault().TVisitasPlaneadas;
                EfectividadVisita.FirstOrDefault().TEfectividadTotal = (EfectividadVisita.FirstOrDefault().TVisitasExitosas * 100) / (EfectividadVisita.FirstOrDefault().TVisitasPlaneadas + EfectividadVisita.FirstOrDefault().TFueraDeRuta);

                foreach (EfectividadVisitaModel registro in EfectividadVisita)
                {
                    registro.EfectividadVisitas = ((registro.VisitasExitosas - registro.FueraDeRuta) * 100) / registro.VisitasPlaneadas;
                    registro.EfectividadTotal = (registro.VisitasExitosas*100)/(registro.VisitasPlaneadas + registro.FueraDeRuta);
                }

                Decimal max = EfectividadVisita.Select(c => c.EfectividadTotal).ToList().OrderByDescending(r =>r).Skip(2).FirstOrDefault();
                Decimal min = EfectividadVisita.Select(c => c.EfectividadTotal).ToList().OrderBy(r => r).Skip(2).FirstOrDefault();


                foreach (EfectividadVisitaModel ev in EfectividadVisita)
                {
                    ev.EfectividadTotalMayor = max;
                    ev.EfectividadTotalMenor = min;
                }


                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;
                
                report.headerlabelcedis.Text = EfectividadVisita.FirstOrDefault().ALMClave + " - " + EfectividadVisita.FirstOrDefault().ALMNombre;
                report.labelfechaheader.Text = fInicio.Date.ToShortDateString() + FechaFinal;

                report.headerCedi.Text = EfectividadVisita.FirstOrDefault().ALMClave + " - " + EfectividadVisita.FirstOrDefault().ALMNombre;
                report.headerVisitaProgramada.Text = EfectividadVisita.FirstOrDefault().TVisitasPlaneadas.ToString("#,###,##0");
                report.headerVisitaEfectuada.Text = EfectividadVisita.FirstOrDefault().TVisitasExitosas.ToString("#,###,##0");
                report.headerEfectividadVisitas.Text = EfectividadVisita.FirstOrDefault().TEfectividadVisitas.ToString("##0.00\\%");
                report.headerFueraRuta.Text = EfectividadVisita.FirstOrDefault().TFueraDeRuta.ToString("#,###,##0");
                report.headerEfectividadTotal.Text = EfectividadVisita.FirstOrDefault().TEfectividadTotal.ToString("##0.00\\%");

                report.detalleRuta.Text = "[RUTClave] - [RUTDescripcion]";
                report.detalleVisitaProgramada.DataBindings.Add("Text", null, "VisitasPlaneadas", "{0:#,###,##0}");
                report.detalleVisitasEfectuadas.DataBindings.Add("Text", null, "VisitasExitosas", "{0:#,###,##0}");
                report.detalleEfectividadVisitas.DataBindings.Add("Text", null, "EfectividadVisitas", "{0:##0.00\\%}");
                report.detalleFueraRuta.DataBindings.Add("Text", null, "FueraDeRuta", "{0:#,###,##0}");
                report.detalleEfectividadTotal.DataBindings.Add("Text", null, "EfectividadTotal", "{0:##0.00\\%}");

                return report;
            }
            catch
            {
                return new ReportePuntosGPS();
            }
        }
    }

    class EfectividadVisitaModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public string RUTClave { get; set; }
        public string RUTDescripcion { get; set; }
        public Decimal VisitasPlaneadas { get; set; }
        public Decimal VisitasExitosas { get; set; }
        public Decimal FueraDeRuta { get; set; }

        public Decimal EfectividadVisitas { get; set; }
        public Decimal EfectividadTotal { get; set; }

        //EfectividadTotalMayor y menor
        public Decimal EfectividadTotalMayor { get; set; }
        public Decimal EfectividadTotalMenor { get; set; }

        //Totales
        public Decimal TVisitasPlaneadas { get; set; }
        public Decimal TVisitasExitosas { get; set; }
        public Decimal TFueraDeRuta { get; set; }

        public Decimal TEfectividadVisitas { get; set; }
        public Decimal TEfectividadTotal { get; set; }
    }


}