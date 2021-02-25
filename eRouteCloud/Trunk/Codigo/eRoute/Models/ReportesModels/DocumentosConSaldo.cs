using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class DocumentosConSaldo
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string VendedoresSplit, string ClientesSplit, string Cedis, string nombreCedis)
        {
            int nTipoCobranza = Connection.Query<int>("SELECT TOP 1 TipoCobranza FROM CONHist (NOLOCK) ORDER BY MFechaHora DESC", null, null, true, 600).FirstOrDefault();

            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("DECLARE @TipoCobranza AS bit ");
            sConsulta.AppendLine("SET @TipoCobranza = (SELECT TOP 1 TipoCobranza FROM CONHist (NOLOCK) ORDER BY CONHistFechaInicio DESC) ");

            sConsulta.AppendLine("SELECT ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, USU.Clave as USUClave, VEN.Nombre as VENNombre, RUT.RUTClave, RUT.Descripcion as RUTNombre, ");
            sConsulta.AppendLine("CLI.Clave as CLIClave, CLI.RazonSocial as  CLINombre, TRP.Folio, Dia.FechaCaptura, TRP.FechaCobranza, TRP.Total - isnull(TT.TotalDevConsignacion, 0) AS Total, TRP.Saldo ");
            sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.VisitaClave = CASE WHEN TRP.VisitaClave1 IS NULL THEN TRP.VisitaClave ELSE CASE WHEN TRP.Tipo = 24 THEN TRP.VisitaClave ELSE TRP.VisitaClave1 END END");
            sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT ClienteClave, RUTClave FROM Secuencia (NOLOCK) WHERE NOT RUTClave IS NULL) AS SEC ON VIS.ClienteClave = SEC.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN VenRut VRT (NOLOCK) ON SEC.RUTClave = VRT.RUTClave AND VRT.TipoEstado = 1 ");
            sConsulta.AppendLine("INNER JOIN (SELECT VendedorId, AlmacenId FROM VENCentroDistHist (NOLOCK) WHERE FechaFinal >= GETDATE() AND VCHFechaInicial <= GETDATE()) AS CEDI ON VRT.VendedorID = CEDI.VendedorId ");
            sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON ALM.AlmacenID = CEDI.AlmacenId ");
            sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON CEDI.VendedorId = VEN.VendedorID ");
            sConsulta.AppendLine("INNER JOIN Usuario USU (NOLOCK) ON VEN.USUId = USU.USUId ");
            sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON VIS.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON VRT.RUTClave = RUT.RUTClave ");
            sConsulta.AppendLine("LEFT JOIN (SELECT Transprodid1, SUM(ISNULL(TTP.Total, 0)) AS TotalDevConsignacion FROM TrpTpd TTP (NOLOCK) GROUP BY transprodid1) TT ON TRP.TransProdId = TT.TransProdID1 ");
            sConsulta.AppendLine(pvCondicion);
            if (nTipoCobranza == 0 || nTipoCobranza == 1)
                sConsulta.AppendLine("AND ((@TipoCobranza = 1 AND TRP.Tipo in (1, 24)) OR (@TipoCobranza = 0 AND TRP.Tipo IN (8, 24))) AND TRP.TipoFase <> 0 AND TRP.Saldo > 0 ");
            else if (nTipoCobranza == 2)
                sConsulta.AppendLine("AND (TRP.Tipo=(CASE WHEN CLI.TipoFiscal = 1 THEN 1 ELSE 8 END)) ");
            sConsulta.AppendLine("AND TRP.TipoFase <> 0 AND TRP.Saldo > 0 ");
            sConsulta.AppendLine("ORDER BY ALM.Clave, USU.Clave, RUT.RUTClave, CLI.Clave, TRP.Folio ");


            QueryString = "";

            QueryString = sConsulta.ToString();

            List<DocumentosConSaldoModel> Documentos = Connection.Query<DocumentosConSaldoModel>(QueryString, null, null, true, 600).ToList();
            if (Documentos.Count() <= 0)
            {
                return null;
            }

            var cedisList = (from gr in Documentos group gr by new { gr.ALMClave } into grupo select grupo);
            List<DocumentosConSaldoModel> formatlist = new List<DocumentosConSaldoModel>();

            foreach (var gCedi in cedisList)
            {
                var vendedorList = (from gr in gCedi group gr by new { gr.USUClave } into grupo select grupo);

                foreach (var gVendedor in vendedorList)
                {
                    var rutaList = (from gr in gVendedor group gr by new { gr.RUTClave } into grupo select grupo);

                    foreach (var gRuta in rutaList)
                    {
                        var clienteList = (from gr in gRuta group gr by new { gr.CLIClave } into grupo select grupo);

                        foreach (var gCliente in clienteList)
                        {
                            foreach (var objetoAgrupado in gCliente)
                            {
                                formatlist.Add(new DocumentosConSaldoModel
                                {
                                    ALMClave = objetoAgrupado.ALMClave,
                                    ALMNombre = objetoAgrupado.ALMNombre,
                                    USUClave = objetoAgrupado.USUClave,
                                    VENNombre = objetoAgrupado.VENNombre,
                                    RUTClave = objetoAgrupado.RUTClave,
                                    RUTNombre = objetoAgrupado.RUTNombre,
                                    CLIClave = objetoAgrupado.CLIClave,
                                    CLINombre = objetoAgrupado.CLINombre,
                                    Folio = objetoAgrupado.Folio,
                                    FechaCaptura = objetoAgrupado.FechaCaptura,
                                    FechaCobranza = objetoAgrupado.FechaCobranza,
                                    Total = objetoAgrupado.Total,
                                    Saldo = objetoAgrupado.Saldo
                                });
                            }
                            //sumamos total del cliente
                            formatlist.Last().SaldoCliente = gCliente.Sum(c => c.Saldo);
                        }
                        //sumamos total de la ruta
                        formatlist.Last().SaldoRuta = gRuta.Sum(c => c.Saldo);
                    }
                    //sumamos total del vendedor
                    formatlist.Last().SaldoVendedor = gVendedor.Sum(c => c.Saldo);
                }
                //sumamos total del CEDI y el gran total
                formatlist.Last().SaldoCedi = gCedi.Sum(c => c.Saldo);
                formatlist.Last().SaldoGTotal = gCedi.Sum(c => c.Saldo);
            }

            ReporteDocumentosConSaldo report = new ReporteDocumentosConSaldo();
            report.DataSource = formatlist;


            string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);
            report.logo.Image = Image.FromStream(mStream);
            report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            report.empresa.Text = NombreEmpresa;
            report.reporte.Text = NombreReporte;



            //ReportHeader
            report.headerlabelCedis.Text = nombreCedis;
            if (String.IsNullOrEmpty(VendedoresSplit))
                report.headerlabelRuta.Text = RutasSplit;
            if (String.IsNullOrEmpty(RutasSplit))
                report.headerlabelVendedor.Text = VendedoresSplit;

            report.headerlabelCliente.Text = ClientesSplit;


            //groupheader1
            GroupField groupCedi = new GroupField("ALMClave");
            report.GroupHeader1.GroupFields.Add(groupCedi);
            report.cediLabel.Text = "[ALMClave] - [ALMNombre]";

            //groupheader2
            GroupField groupVendedor = new GroupField("USUClave");
            report.GroupHeader2.GroupFields.Add(groupVendedor);
            report.vendedorLabel.Text = "[USUClave] - [VENNombre]";

            //groupheader3
            GroupField groupRuta = new GroupField("RUTClave");
            report.GroupHeader3.GroupFields.Add(groupRuta);
            report.rutaLabel.Text = "[RUTClave] - [RUTNombre]";

            //System.Diagnostics.Debug.WriteLine(groupRuta.SortOrder);
            //groupheader4
            GroupField groupCliente = new GroupField("CLIClave");
            report.GroupHeader4.GroupFields.Add(groupCliente);

            report.GroupHeader4.GroupUnion = GroupUnion.WithFirstDetail;


            //Detalle
            report.detalleCLIClave.DataBindings.Add("Text", report.DataSource, "CLIClave");
            report.detalleCLINombre.DataBindings.Add("Text", report.DataSource, "CLINombre");
            report.detalleFolio.DataBindings.Add("Text", report.DataSource, "Folio");
            report.detalleFechaCaptura.DataBindings.Add("Text", report.DataSource, "FechaCaptura", "{0:dd/MM/yyyy}");
            report.detalleFechaCobranza.DataBindings.Add("Text", report.DataSource, "FechaCobranza", "{0:dd/MM/yyyy}");
            report.detalleTotal.DataBindings.Add("Text", report.DataSource, "Total", "{0:#,##0.00}");
            report.detalleSaldo.DataBindings.Add("Text", report.DataSource, "Saldo", "{0:#,##0.00}");

            //groupFooter4
            report.totalPorCliente.DataBindings.Add("Text", report.DataSource, "SaldoCliente", "{0:#,##0.00}");

            //groupFooter3
            report.totalPorRuta.DataBindings.Add("Text", report.DataSource, "SaldoRuta", "{0:#,##0.00}");


            //groupFooter2
            report.totalPorVendedor.DataBindings.Add("Text", report.DataSource, "SaldoVendedor", "{0:#,##0.00}");


            //groupFooter1
            report.totalPorCEDI.DataBindings.Add("Text", report.DataSource, "SaldoCedi", "{0:#,##0.00}");

            //reportFooter
            report.granTotal.DataBindings.Add("Text", report.DataSource, "SaldoGTotal", "{0:#,##0.00}");





            return report;
        }



    }


    class DocumentosConSaldoModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public string USUClave { get; set; }
        public string VENNombre { get; set; }
        public string RUTClave { get; set; }
        public string RUTNombre { get; set; }
        public string CLIClave { get; set; }
        public string CLINombre { get; set; }
        public string Folio { get; set; }
        public DateTime FechaCaptura { get; set; }
        public DateTime FechaCobranza { get; set; }
        public Decimal Total { get; set; }
        public Decimal Saldo { get; set; }


        public Decimal SaldoCliente { get; set; }

        public Decimal SaldoRuta { get; set; }

        public Decimal SaldoVendedor { get; set; }

        public Decimal SaldoCedi { get; set; }

        public Decimal SaldoGTotal { get; set; }
    }
}