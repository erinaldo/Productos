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

namespace eRoute.Models.ReportesModels
{
    public class EstatusPedidosSAPChocolatera
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        EstatusPedidosSAPChocolateraReport report = new EstatusPedidosSAPChocolateraReport();
        public XtraReport GetReport(string pvCondicion, string FechaInicial, string FechaFinal, string NombreCedis, string Vendedor)
        {
            try
            {
                #region reporte
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select (a.Clave + a.Nombre) as CEDI,");
                sConsulta.AppendLine("	d.FechaCaptura as Fecha,");
                sConsulta.AppendLine("	ve.Nombre as Vendedor,");
                sConsulta.AppendLine("	(c.Clave + ' - ' + c.RazonSocial) as Cliente, ");
                sConsulta.AppendLine("	t.Folio as FolioRoute, ");
                sConsulta.AppendLine("	pd.Fecha as FechaEnvio, ");
                sConsulta.AppendLine("  (select replace(Datos,'VBELN: ','') from dbo.FNSplit(tva.Observaciones2,',') where Datos like '%VBELN%') as FolioSAP,");
                sConsulta.AppendLine("  (case ");
                sConsulta.AppendLine("		when (select replace(Datos,'VBELN: ','') from dbo.FNSplit(tva.Observaciones2,',') where Datos like '%VBELN%')='' ");
                sConsulta.AppendLine("			then (select replace(Datos,'MENSAJE: ','') from dbo.FNSplit(tva.Observaciones2,',') where Datos like '%MENSAJE%')");
                sConsulta.AppendLine("		when (select replace(Datos,'VBELN: ','') from dbo.FNSplit(tva.Observaciones2,',') where Datos like '%VBELN%')<>''");
                sConsulta.AppendLine("			then ('Completado')");
                sConsulta.AppendLine("	end) as Estatus	");
                sConsulta.AppendLine("from TransProd t (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on t.DiaClave=d.DiaClave");
                sConsulta.AppendLine("inner join Visita v (NOLOCK) on t.VisitaClave=v.VisitaClave and v.DiaClave=v.DiaClave");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on v.ClienteClave=c.ClienteClave");
                sConsulta.AppendLine("inner join VENCentroDistHist vdh (NOLOCK) on v.VendedorID=vdh.VendedorId and (d.FechaCaptura between vdh.VCHFechaInicial and vdh.FechaFinal)");
                sConsulta.AppendLine("inner join Almacen a (NOLOCK) on vdh.AlmacenID=a.AlmacenID");
                sConsulta.AppendLine("inner join Vendedor ve (NOLOCK) on v.VendedorID=ve.VendedorID");
                sConsulta.AppendLine("left join TRPVtaAcreditada tva (NOLOCK) on t.TransProdID=tva.TransProdID");
                sConsulta.AppendLine("left join tmp_expPedidosDevolucionesCHOH pd (NOLOCK) on t.TransProdID=pd.TransProdID");                              
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("  and t.Tipo=1 and t.TipoFase in (12,13)");  

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<EstatusPedidosSAPChocolateraModel> User = Connection.Query<EstatusPedidosSAPChocolateraModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                if (User.Count() <= 0)
                {
                    return null;
                }
                
                var lista = (from c in User
                             select c).ToList();


                var s = (from gr in lista group gr by new { gr.CEDI, gr.Fecha, gr.Vendedor} into grupo select grupo);
                List<EstatusPedidosSAPChocolateraModel> formatlist = new List<EstatusPedidosSAPChocolateraModel>();
                foreach (var grupo in s)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        formatlist.Add(new EstatusPedidosSAPChocolateraModel
                        {
                            CEDI = objetoAgrupado.CEDI,
                            Fecha = objetoAgrupado.Fecha,
                            Vendedor = objetoAgrupado.Vendedor,
                            Cliente = objetoAgrupado.Cliente,
                            FolioRoute = objetoAgrupado.FolioRoute,
                            FechaEnvio = objetoAgrupado.FechaEnvio,
                            FolioSAP = objetoAgrupado.FolioSAP,
                            Estatus = objetoAgrupado.Estatus
                        });
                    }                    
                }

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

                string LogoQuery = "Select Logotipo from Configuracion (NOLOCK) ";

                Connection.Open();
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.xrPictureBox1.Image = Image.FromStream(mStream);
                report.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.DataSource = formatlist;

                //ReportHeader
                report.headerlabelcedis.Text = NombreCedis;
                report.labelfechaheader.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.labelvendedorheader.Text = Vendedor;

                //grouheader5
                GroupField groupCedi = new GroupField("CEDI");
                report.GroupHeader5.GroupFields.Add(groupCedi);
                report.cediClave.DataBindings.Add("Text", report.DataSource, "CEDI");
                //grouheader4
                GroupField groupFecha = new GroupField("Fecha");
                report.GroupHeader4.GroupFields.Add(groupFecha);
                report.Fecha.DataBindings.Add("Text", report.DataSource, "Fecha", "{0:dd/MM/yyyy}");                
                //grouheader2
                GroupField groupVendedor = new GroupField("Vendedor");
                report.GroupHeader2.GroupFields.Add(groupVendedor);
                report.Vendedor.DataBindings.Add("Text", report.DataSource, "Vendedor");                

                //Datos del detail
                report.dCliente.DataBindings.Add("Text", null, "Cliente");
                report.dFolioRoute.DataBindings.Add("Text", null, "FolioRoute");
                report.dFechaEnvio.DataBindings.Add("Text", null, "FechaEnvio");
                report.dFolioSAP.DataBindings.Add("Text", null, "FolioSAP");
                report.dEstatus.DataBindings.Add("Text", null, "Estatus");                            

                #endregion
                return report;
            }
            catch (Exception ex)
            {
                return new TiemposRutaReport();
            }
        }
    }

    class EstatusPedidosSAPChocolateraModel
    {
        public String CEDI { get; set; }
        public DateTime Fecha { get; set; }
        public String Vendedor { get; set; }
        public String Cliente { get; set; }
        public String FolioRoute { get; set; }
        public DateTime FechaEnvio { get; set; }
        public String FolioSAP { get; set; }
        public String Estatus { get; set; }
    } 
}