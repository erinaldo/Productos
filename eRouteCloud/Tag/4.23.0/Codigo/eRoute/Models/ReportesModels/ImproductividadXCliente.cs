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
    public class ImproductividadXCliente
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string pvCondicion1, string RutasSplit, string FechaInicial, string FechaFinal, string NomCEDI, string NomReporte, string Cedis)
        {

            try
            {
                //IMPRODUCTIVIDADPORCLIENTE
                #region consultaClientes
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.AppendLine("select (ALM.Clave + '   '+ ALM.Nombre) as CentroDistribucion, ");
                sConsulta.AppendLine("(USU.Clave + '   ' + VEN.Nombre + '   '  + (select (R.RUTClave + '   ' + R.Descripcion)  ");
                sConsulta.AppendLine("from ruta R (NOLOCK) inner join VenRut VR (NOLOCK) ON R.RUTClave = VR.RUTClave where VR.VendedorID = VEN.VendedorID and R.RUTClave = VIS.RUTClave)) as Vendedor, ");
                sConsulta.AppendLine("IMV.Comentario, CLI.Clave, CLI.RazonSocial, Cli.NombreContacto, IMV.MFechaHora as Fecha, dbo.FNObtenerValorReferencia('MOTIMPRO' ,TipoMotivo ) as Motivo,  ");
                sConsulta.AppendLine("VEN.VendedorId ");
                sConsulta.AppendLine("from ImproductividadVenta IMV (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON IMV.DiaClave = Dia.DiaClave  ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) ON IMV.DiaClave = VIS.DiaClave and IMV.VisitaClave = VIS.VisitaClave  ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorID  ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) ON ALM.AlmacenID = (select top 1 AlmacenId from VENCentroDistHist (NOLOCK) where VendedorId = VEN.VendedorID order by VCHFechaInicial desc) ");
                sConsulta.AppendLine("inner join Usuario USU (NOLOCK) ON USU.usuid= VEN.USUId ");
                sConsulta.AppendLine("inner join cliente CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave ");
                sConsulta.AppendLine("where 1 = 1 and ALM.AlmacenID = '" + Cedis + "'" + pvCondicion1);
                sConsulta.AppendLine(pvCondicion);
                //sConsulta.AppendLine("where 1 = 1 and CONVERT(nvarchar(10),Dia.FechaCaptura,126)+'T00:00:00' between '2010-01-01T00:00:00' and '2018-10-26T00:00:00' and ALM.Clave = 'DETA'");
                //sConsulta.AppendLine("and VIS.RUTClave in ('00M001','00M002','00M003','00M004','00M005','00M006','00M007','00M008','00M009','00M010','00M011','00M012','00M013','00M014','00M015','00M016','00M017','00M018','00M019','00M020','00M021','00M022','00M023','00M024','00M025','00M026','00M027','00M028','00M029','00M030','00M031','00M032','00M033','00M034','00M035','00M036','00M037','00M038','00M039','00M040','00M041','00M042','00M043','00M044','00M045','00M046','00M051','00M052','00M053','00M054','00M055','00M056','00M057','00M058','00M059','00M060','00M061','00M062','00M063','00M064','00M065','00M066','00M068','00M069','00M071','00M072','00M073','00M074','00M075','00M076','00M077','00M078','00M079','00M080','00M081','00M082','00M083','00M084','00M085','00M086','00M101','00M102','00M103','00M104','00M105','00M106','00M107','00M108','00M109','00M110','00M111','00M112','00M113','00M114','00M115','00M116','00M117','00M118','00M119','00M120','00M121','00M122','00M123','00M124','00M125','00M126','00M127','00M128') ");

                QueryString = "";
                QueryString = sConsulta.ToString();
                #endregion
                List<ClientesImproductivos> Principal = Connection.Query<ClientesImproductivos>(QueryString, null, null, true, 600).ToList();
                List<ClientesImproductivos> UnoGru = new List<ClientesImproductivos>();

                var SubUno = (from A in Principal
                              orderby A.Vendedor ascending, A.Motivo ascending, A.Fecha ascending
                              select A).ToList();

                #region consultaAgenda
                sConsulta = new StringBuilder();

                sConsulta.AppendLine("select AGV.VendedorId, (ALM.Clave + '   '+ ALM.Nombre) as CentroDistribucion,  COUNT(AGV.ClienteClave) as TotalAgenda1 ");
                sConsulta.AppendLine("from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON AGV.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) ON ALM.AlmacenID = (select top 1 AlmacenId from VENCentroDistHist (NOLOCK) where VendedorId = AGV.VendedorID order by VCHFechaInicial desc)");
                sConsulta.AppendLine("where 1 = 1 and ALM.AlmacenId = '" + Cedis + "'");
                sConsulta.AppendLine(pvCondicion1);
                if (RutasSplit == "")
                {
                    sConsulta.AppendLine(pvCondicion.Replace("VEN.", "AGV."));
                }
                else
                {
                    sConsulta.AppendLine(pvCondicion.Replace("VIS.", "AGV."));
                }
                sConsulta.AppendLine("group by AGV.VendedorId ,ALM.Clave,ALM.Nombre ");

                QueryString = "";
                QueryString = sConsulta.ToString();
                #endregion

                List<ClientesAgendaProductivos> AgendaClientes = Connection.Query<ClientesAgendaProductivos>(QueryString, null, null, true, 600).ToList();

                var Agenda = (from A in AgendaClientes
                              orderby A.VendedorId
                              select A).ToList();

                var numClientesAgenda = (from A in Principal
                                         from B in AgendaClientes
                                         where A.VendedorId == B.VendedorId
                                         select new
                                         {
                                             Vendedor = B.VendedorId,
                                             Cantidad = B.TotalAgenda1
                                         }).Distinct().ToList();

                var clientesEnAgenda = 0;
                foreach (var item in numClientesAgenda)
                {
                    clientesEnAgenda += (int)item.Cantidad;
                }

                var cantidadClientesAgenda = 0;

                var agrup_1 = (from gr in SubUno group gr by new { gr.CentroDistribucion } into grupo select grupo);

                foreach (var gCedi in agrup_1)
                {
                    var agrup_2 = (from gr in gCedi group gr by new { gr.Vendedor } into grupo select grupo);

                    foreach (var item in agrup_2)
                    {
                        foreach (var objAgrupado in item)
                        {
                            UnoGru.Add(new ClientesImproductivos
                            {
                                //PRINCIPAL
                                CentroDistribucion = objAgrupado.CentroDistribucion,
                                Vendedor = objAgrupado.Vendedor,
                                Comentario = objAgrupado.Comentario,
                                Clave = objAgrupado.Clave,
                                RazonSocial = objAgrupado.RazonSocial,
                                NombreContacto = objAgrupado.NombreContacto,
                                Fecha = objAgrupado.Fecha,
                                Motivo = objAgrupado.Motivo,
                                VendedorId = objAgrupado.VendedorId
                            });
                            var gru = item.Count();
                            UnoGru.Last().tTotalCliente = gru;

                            foreach (var ag in Agenda)
                            {
                                if (ag.VendedorId == objAgrupado.VendedorId)
                                {
                                    UnoGru.Last().tTotalAgenda = ag.TotalAgenda1;
                                    cantidadClientesAgenda += (int)ag.TotalAgenda1;
                                }
                            }
                            UnoGru.Last().tPromedio = Math.Round((gru / UnoGru.Last().tTotalAgenda * 100), 2);
                        }
                    }
                }

                if (Principal.Count > 0)
                {
                    rep_ImprodXCliente reporteNuevo = new rep_ImprodXCliente();
                    reporteNuevo.DataSource = UnoGru;

                    //groupHeaderBand1 CEDI
                    GroupField groupCEDI = new GroupField("CEDI");
                    reporteNuevo.groupHeaderBand1.GroupFields.Add(groupCEDI);
                    reporteNuevo.Gpo_CEDI.DataBindings.Add("Text", reporteNuevo.DataSource, "CentroDistribucion");

                    //groupHeaderBand2 Vendedor
                    GroupField groupVendedor = new GroupField("Vendedor");
                    reporteNuevo.groupHeaderBand2.GroupFields.Add(groupVendedor);
                    reporteNuevo.Gpo_Vendedor.DataBindings.Add("Text", reporteNuevo.DataSource, "Vendedor");

                    //Details
                    reporteNuevo.L_Clave.DataBindings.Add("Text", reporteNuevo.DataSource, "Clave");
                    reporteNuevo.L_RazonSocial.DataBindings.Add("Text", reporteNuevo.DataSource, "RazonSocial");
                    reporteNuevo.L_Comentario.DataBindings.Add("Text", reporteNuevo.DataSource, "Comentario");
                    reporteNuevo.L_NombreContacto.DataBindings.Add("Text", reporteNuevo.DataSource, "NombreContacto");
                    reporteNuevo.L_Fecha.DataBindings.Add("Text", reporteNuevo.DataSource, "Fecha");
                    reporteNuevo.L_Motivo.DataBindings.Add("Text", reporteNuevo.DataSource, "Motivo");

                    //groupfooterBand2
                    reporteNuevo.L_ClienteAgenda.DataBindings.Add("Text", reporteNuevo.DataSource, "tTotalAgenda", "{0:#,###,##0}");
                    reporteNuevo.L_Improductivos.DataBindings.Add("Text", reporteNuevo.DataSource, "tTotalCliente", "{0:#,###,##0}");
                    reporteNuevo.L_Porcentaje.DataBindings.Add("Text", reporteNuevo.DataSource, "tPromedio", "{0:##0.00}%");

                    //reportfooterBand1
                    reporteNuevo.L_GlobalAgenda.Text = clientesEnAgenda.ToString("#,###");
                    reporteNuevo.L_GlobalImproductivos.Text = Principal.Count().ToString("#,###,##0");
                    try { 
                    reporteNuevo.L_GlobalPorcentaje.Text = ((decimal)Principal.Count / clientesEnAgenda).ToString("P");
                    }
                    catch (Exception ex) {
                        reporteNuevo.L_GlobalPorcentaje.Text = "0";
                    }
                    //ReportHeader
                    #region reporteClientesImproductivos
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
                    reporteNuevo.logo.Image = Image.FromStream(mStream);
                    reporteNuevo.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    reporteNuevo.empresa.Text = NombreEmpresa;
                    reporteNuevo.reporte.Text = NombreReporte;

                    reporteNuevo.L_CEDI.Text = NomCEDI.ToString();
                    reporteNuevo.L_FechaRango.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                    reporteNuevo.L_Vendedor.Text = NomReporte;
                    reporteNuevo.L_Ruta.Text = RutasSplit;

                    reporteNuevo.Name = "Improductividad por Cliente_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss");

                    #endregion

                    return reporteNuevo;
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

    class ClientesImproductivos
    {
        //PRINCIPAL
        public string CentroDistribucion { get; set; }
        public string Vendedor { get; set; }
        public string Comentario { get; set; }
        public string Clave { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string VendedorId { get; set; }

        //PRINCIPAL_subtotales
        public double tTotalCliente { get; set; }
        public double tTotalAgenda { get; set; }
        public double tPromedio { get; set; }
    }

    class ClientesAgendaProductivos
    {
        public string VendedorId { get; set; }
        public string CentroDistribucion { get; set; }
        public double TotalAgenda1 { get; set; }
    }
}