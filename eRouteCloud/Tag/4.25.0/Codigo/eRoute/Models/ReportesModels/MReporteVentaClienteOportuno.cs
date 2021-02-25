using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class MReporteVentaClienteOportuno
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        decimal p1 = 0;
        decimal p2 = 0;
        decimal p3 = 0;
        decimal p4 = 0;
        decimal p5 = 0;
        decimal p6 = 0;
        int cont;
        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis, string Presupuesto, string promocion)
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

            string organizacionQuery = "Select Valor from ConfigParametro (NOLOCK) where Parametro = 'OrganizacionVentas'";
            string nombreorganizacion = Connection.Query<string>(organizacionQuery, null, null, true, 9000).FirstOrDefault();

            //General
            if (Presupuesto == "True")
            {
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select  ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, COUNT(DISTINCT TRP.TransProdID) as NumVtas, ");
                sConsulta.AppendLine("COUNT(DISTINCT CASE WHEN CLI.Clave like '" + nombreorganizacion + "%' THEN TRP.TransProdID ELSE null END) as NumVtasOportuno, ");
                sConsulta.AppendLine("sum(TRP.Total) as TotalVtas, sum (CASE WHEN CLI.Clave like '" + nombreorganizacion + "%' THEN TRP.Total ELSE 0 END) as TotalVtasOportuno ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave  ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on ALM.AlmacenID = RUT.AlmacenID ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase <>0    and ALM.Clave = '" + Cedis + "' ");
                //sConsulta.AppendLine(" and CONVERT(nvarchar(10),Dia.FechaCaptura,126)+'T00:00:00' between '2018-01-01T00:00:00' and '2018-03-01T00:00:00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("group by ALM.Clave,ALM.Nombre ");
                sConsulta.AppendLine("order by ALM.Clave ");


                QueryString = "";

                QueryString = sConsulta.ToString();


                List<ReCE> general = Connection.Query<ReCE>(QueryString, null, null, true, 600).ToList();
                if (general.Count != 0)
                {
                    ReporteVentaClienteOportunoGeneral report = new ReporteVentaClienteOportunoGeneral();

                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    report.logo.Image = Image.FromStream(mStream);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    report.empresa.Text = NombreEmpresa;
                    report.reporte.Text = NombreReporte + " General";

                    report.fecha.Text = fInicio.Date.ToShortDateString() + FechaFinal;

                    foreach (var i in general)
                    {
                        p1 = (i.NumVtas / i.NumVtasOportuno);
                        p2 = (i.TotalVtas / i.TotalVtasOportuno);
                    }

                    report.DataSource = general;

                    report.x1.Text = nombreCedis;
                    report.x2.DataBindings.Add("Text", null, "NumVtas", "{0:#,##0}");
                    report.x3.DataBindings.Add("Text", null, "NumVtasOportuno", "{0:#,##0}");
                    report.x4.DataBindings.Add("Text", null, "TotalVtas", "{0:$#,##0.00}");
                    report.x5.DataBindings.Add("Text", null, "TotalVtasOportuno", "{0:$#,##0.00}");
                    report.x6.Text = p1.ToString("#0.00%");
                    report.x7.Text = p2.ToString("#0.00%");

                    return report;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select  ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VIS.RUTClave as RUTClave, RUT.Descripcion as RUTDescripcion, COUNT(DISTINCT TRP.TransProdID) as NumVtas, ");
                sConsulta.AppendLine("COUNT(DISTINCT CASE WHEN CLI.Clave like '" + nombreorganizacion + "%' THEN TRP.TransProdID ELSE null END) as NumVtasOportuno, ");
                sConsulta.AppendLine("sum(TRP.Total) as TotalVtas, sum (CASE WHEN CLI.Clave like '" + nombreorganizacion + "%' THEN TRP.Total ELSE 0 END) as TotalVtasOportuno ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave  ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on ALM.AlmacenID = RUT.AlmacenID ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase <>0  and ALM.Clave = '" + Cedis + "' ");
                //sConsulta.AppendLine(" and CONVERT(nvarchar(10),Dia.FechaCaptura,126)+'T00:00:00' between '2018-01-01T00:00:00' and '2018-05-01T00:00:00' ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("group by ALM.Clave,ALM.Nombre, VIS.RUTClave, RUT.Descripcion ");
                sConsulta.AppendLine("order by ALM.Clave, VIS.RUTClave ");


                QueryString = sConsulta.ToString();

                List<ReCE> detallado = Connection.Query<ReCE>(QueryString, null, null, true, 600).ToList();
                if (detallado.Count != 0)
                {

                    detallado.LastOrDefault().tNumVtas = detallado.Sum(c => c.NumVtas);
                    detallado.LastOrDefault().tNumVtasOportuno = detallado.Sum(c => c.NumVtasOportuno);
                    detallado.LastOrDefault().tTotalVtas = detallado.Sum(c => c.TotalVtas);
                    detallado.LastOrDefault().tTotalVtasOportuno = detallado.Sum(c => c.TotalVtasOportuno);

                    ReporteVenteClienteOportunoDetallado report = new ReporteVenteClienteOportunoDetallado();

                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    report.logo.Image = Image.FromStream(mStream);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    report.empresa.Text = NombreEmpresa;
                    report.reporte.Text = NombreReporte + " Detallado";

                    report.clavenombre.Text = nombreCedis;
                    report.fecha.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                    foreach (var i in detallado)
                    {
                        p1 = (i.NumVtas / i.NumVtasOportuno);
                        p2 = (i.TotalVtas / i.TotalVtasOportuno);
                        p3 += p1;
                        p4 += p2;
                        cont++;

                    }
                    p5 = p3 / cont;
                    p6 = p4 / cont;

                    report.DataSource = detallado;
                    report.x1.DataBindings.Add("Text", null, "RUTClave");
                    report.x2.DataBindings.Add("Text", null, "NumVtas", "{0:#,##0}");
                    report.x3.DataBindings.Add("Text", null, "NumVtasOportuno", "{0:#,##0}");
                    report.x4.DataBindings.Add("Text", null, "TotalVtas", "{0:$#,##0.00}");
                    report.x5.DataBindings.Add("Text", null, "TotalVtasOportuno", "{0:$#,##0.00}");
                    report.x6.Text = p1.ToString("#0.00%");
                    report.x7.Text = p2.ToString("#0.00%");

                    report.z2.DataBindings.Add("Text", null, "tNumVtas", "{0:#,##0}");
                    report.z3.DataBindings.Add("Text", null, "tNumVtasOportuno", "{0:#,##0}");
                    report.z4.DataBindings.Add("Text", null, "tTotalVtas", "{0:$#,##0.00}");
                    report.z5.DataBindings.Add("Text", null, "tTotalVtasOportuno", "{0:$#,##0.00}");
                    report.z6.Text = p5.ToString("#0.00%");
                    report.z7.Text = p6.ToString("#0.00%");



                    return report;
                }
                else
                {
                    return null;
                }

            }
        }
    }

    class ReCE
    {



        public String ALMClave { get; set; }
        public String ALMNombre { get; set; }
        public String RUTClave { get; set; }
        public String RUTDescripcion { get; set; }
        public int NumVtas { get; set; }
        public int NumVtasOportuno { get; set; }
        public Decimal TotalVtas { get; set; }
        public Decimal TotalVtasOportuno { get; set; }

        public int tNumVtas { get; set; }
        public int tNumVtasOportuno { get; set; }
        public Decimal tTotalVtas { get; set; }
        public Decimal tTotalVtasOportuno { get; set; }
    }
}