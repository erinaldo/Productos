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
    public class AnalisisDeSaldoMOO
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string ClientesSplit, string FechaInicial, string Cedis, bool detallado)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();

                if (detallado)
                {
                    #region reporte detallado
                    sConsulta.AppendLine("SET NOCOUNT ON ");
                    sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpMov')) IS NOT NULL DROP TABLE #TmpMov ");
                    sConsulta.AppendLine("SELECT * INTO #TmpMov FROM ( ");
                    sConsulta.AppendLine("SELECT VCH.AlmacenId, SEC.RUTClave, VEN.VendedorID, VIS.ClienteClave,Dia.FechaCaptura, TRP.Folio, ");
                    sConsulta.AppendLine("CASE WHEN TRP.Tipo = 1 THEN TRP.FechaCobranza ELSE NULL END AS FechaCobranza, ");
                    sConsulta.AppendLine("CASE WHEN TRP.Tipo = 1 THEN TRP.Saldo ELSE 0 END AS Credito, ");
                    sConsulta.AppendLine("CASE WHEN TRP.Tipo = 24 THEN TRP.Saldo ELSE 0 END AS Consignacion ");
                    sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave ");
                    sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                    sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT RutClave, ClienteClave FROM Secuencia (NOLOCK) WHERE not RUTClave IS NULL) SEC ON VIS.ClienteClave = SEC.ClienteClave ");
                    sConsulta.AppendLine("INNER JOIN VenRut VRT (NOLOCK) ON SEC.RUTClave = VRT.RUTClave AND VRT.TipoEstado = 1 ");
                    sConsulta.AppendLine("INNER JOIN (SELECT VendedorId, AlmacenId, MAX(VCHFechaInicial) AS FechaInicial FROM VENCentroDistHist (NOLOCK) GROUP BY VendedorId, AlmacenId) VCH ON VCH.VendedorId = VRT.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VCH.VendedorID = VEN.VendedorID ");
                    sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCH.AlmacenId = ALM.AlmacenID ");
                    sConsulta.AppendLine(pvCondicion);
                    sConsulta.AppendLine("AND ((TRP.Tipo = 1 AND TRP.TipoFase IN (2,3)) OR (TRP.Tipo = 24 AND TRP.TipoFase <> 0)) AND TRP.Saldo <> 0 ");
                    sConsulta.AppendLine(") AS T1 ");

                    sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpEnv')) IS NOT NULL DROP TABLE #TmpEnv ");
                    sConsulta.AppendLine("SELECT * INTO #TmpEnv FROM ( ");
                    sConsulta.AppendLine("SELECT VCH.AlmacenId, SEC.RUTClave, VEN.VendedorID, PPC.ClienteClave, SUM(PPC.Saldo) AS Saldo ");
                    sConsulta.AppendLine("FROM ProductoPrestamoCli PPC (NOLOCK) ");
                    sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT RutClave, ClienteClave FROM Secuencia (NOLOCK) WHERE NOT RUTClave IS NULL) SEC ON PPC.ClienteClave = SEC.ClienteClave ");
                    sConsulta.AppendLine("INNER JOIN VenRut VRT (NOLOCK) ON SEC.RUTClave = VRT.RUTClave AND VRT.TipoEstado = 1 ");
                    sConsulta.AppendLine("INNER JOIN (SELECT VendedorId, AlmacenId, MAX(VCHFechaInicial) AS FechaInicial FROM VENCentroDistHist (NOLOCK) GROUP BY VendedorId, AlmacenId) VCH ON VCH.VendedorId = VRT.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VCH.VendedorID = VEN.VendedorID ");
                    sConsulta.AppendLine("INNER JOIN Usuario USU (NOLOCK) ON VEN.USUId = USU.USUId ");
                    sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCH.AlmacenId = ALM.AlmacenID ");
                    sConsulta.AppendLine(pvCondicion);
                    sConsulta.AppendLine("AND PPC.Saldo <> 0 ");
                    sConsulta.AppendLine("GROUP BY VCH.AlmacenId, SEC.RUTClave, VEN.VendedorID, PPC.ClienteClave ");
                    sConsulta.AppendLine(") AS T2 ");

                    sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpSaldo')) IS NOT NULL DROP TABLE #TmpSaldo ");
                    sConsulta.AppendLine("SELECT * INTO #TmpSaldo FROM ( ");
                    sConsulta.AppendLine("SELECT ISNULL(T1.AlmacenId, T2.AlmacenId) AS AlmacenId, ISNULL(T1.RutClave, T2.RutClave) AS RutClave, ");
                    sConsulta.AppendLine("ISNULL(T1.VendedorId, T2.VendedorId) AS VendedorId, ISNULL(T1.ClienteClave, T2.ClienteClave) AS ClienteClave, ");
                    sConsulta.AppendLine("T1.FechaCaptura, ISNULL(T1.Folio, '') AS Folio, T1.FechaCobranza, ");
                    sConsulta.AppendLine("ISNULL(T1.Credito, 0) AS Credito, ISNULL(T1.Consignacion, 0) AS Consignacion, ISNULL(T2.Saldo, 0) AS Envase ");
                    sConsulta.AppendLine("FROM #TmpMov T1 ");
                    sConsulta.AppendLine("FULL JOIN #TmpEnv T2 ON T1.AlmacenId = T2.AlmacenId AND T1.RutClave = T2.RutClave ");
                    sConsulta.AppendLine("AND T1.VendedorId = T2.VendedorId AND T1.ClienteClave = T2.ClienteClave ");
                    sConsulta.AppendLine(") AS T3 ");

                    sConsulta.AppendLine("SELECT ALM.Clave AS ALMClave, ALM.Nombre AS ALMNombre, RUT.RUTClave, RUT.Descripcion AS RUTDescripcion, USU.Clave AS USUClave, VEN.Nombre AS VENNombre, ");
                    sConsulta.AppendLine("CLI.Clave AS CLIClave, CLI.RazonSocial AS CLINombreCorto, CLI.NombreContacto AS CLINombreContacto, TMP.FechaCaptura, TMP.FechaCobranza AS FechaVencimiento, ");
                    sConsulta.AppendLine("TMP.Folio, TMP.Credito, TMP.Consignacion, TMP.Envase ");
                    sConsulta.AppendLine("FROM #TmpSaldo TMP ");
                    sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON ALM.AlmacenID = TMP.AlmacenId ");
                    sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = TMP.RUTClave ");
                    sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = TMP.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN Usuario USU (NOLOCK) ON VEN.USUId = USU.USUId ");
                    sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = TMP.ClienteClave ");
                    sConsulta.AppendLine("WHERE TMP.Credito <> 0 OR TMP.Consignacion <> 0 OR TMP.Envase <> 0 ");
                    sConsulta.AppendLine("ORDER BY ALM.Clave, RUT.RUTClave, USU.Clave, CLI.Clave, TMP.FechaCaptura, TMP.Folio ");

                    sConsulta.AppendLine("DROP TABLE #TmpMov ");
                    sConsulta.AppendLine("DROP TABLE #TmpEnv ");
                    sConsulta.AppendLine("DROP TABLE #TmpSaldo ");
                    sConsulta.AppendLine("SET NOCOUNT OFF ");

                    QueryString = "";

                    QueryString = sConsulta.ToString();


                    List<AnalisisDeSaldoDetMOOModel> User = Connection.Query<AnalisisDeSaldoDetMOOModel>(QueryString, null, null, true, 600).ToList();

                    if (User.Count() <= 0)
                    {
                        return null;
                    }

                    var lista = (from c in User
                                 select c).ToList();


                    var s = (from gr in lista group gr by new { gr.ALMClave, gr.RUTClave, gr.USUClave, gr.CLIClave } into grupo select grupo);
                    List<AnalisisDeSaldoDetMOOModel> formatlist = new List<AnalisisDeSaldoDetMOOModel>();

                    Decimal creditoVen = 0;
                    Decimal consignacionVen = 0;
                    Decimal totalVen = 0;
                    long envaseVen = 0;

                    Decimal creditoRut = 0;
                    Decimal consignacionRut = 0;
                    Decimal totalRut = 0;
                    long envaseRut = 0;

                    int index = 0;
                    foreach (var grupo in s)
                    {
                        index++;
                        foreach (var objetoAgrupado in grupo)
                        {
                            formatlist.Add(new AnalisisDeSaldoDetMOOModel
                            {
                                ALMClave = objetoAgrupado.ALMClave,
                                ALMNombre = objetoAgrupado.ALMNombre,
                                RUTClave = objetoAgrupado.RUTClave,
                                RUTDescripcion = objetoAgrupado.RUTDescripcion,
                                USUClave = objetoAgrupado.USUClave,
                                VENNombre = objetoAgrupado.VENNombre,
                                CLIClave = objetoAgrupado.CLIClave,
                                CLINombreCorto = objetoAgrupado.CLINombreCorto,
                                CLINombreContacto = objetoAgrupado.CLINombreContacto,
                                FechaCaptura = objetoAgrupado.FechaCaptura,
                                FechaVencimiento = objetoAgrupado.FechaVencimiento,
                                Folio = objetoAgrupado.Folio,
                                Credito = objetoAgrupado.Credito,
                                Consignacion = objetoAgrupado.Consignacion
                            });
                        }
                        //llenamos los datos del primer footer solo en el ultimo registro del grupo
                        formatlist.Last().CreditoTotal = grupo.Sum(c => c.Credito);
                        formatlist.Last().Consignacion = grupo.Sum(c => c.Consignacion);
                        formatlist.Last().Total = formatlist.Last().CreditoTotal - formatlist.Last().Consignacion;
                        formatlist.Last().Envase = grupo.FirstOrDefault().Envase;

                        //sumamos los datos por grupo (vendedores) para que al cambiar de grupo se haga la sumatoria por vendedor
                        creditoVen += formatlist.Last().CreditoTotal;
                        consignacionVen += formatlist.Last().Consignacion;
                        totalVen += formatlist.Last().Total;
                        envaseVen += formatlist.Last().Envase;

                        //sumamos los datos por grupo (rutas) para que al cambiar de grupo se haga la sumatoria por ruta
                        creditoRut += formatlist.Last().CreditoTotal;
                        consignacionRut += formatlist.Last().Consignacion;
                        totalRut += formatlist.Last().Total;
                        envaseRut += formatlist.Last().Envase;

                        if (!grupo.Key.Equals(s.Last().Key))
                        {
                            //realizamos la sumatoria de todos los totales de este vendedor
                            if (!grupo.LastOrDefault().USUClave.Equals(s.ElementAt(index).Key.USUClave))
                            {
                                formatlist.Last().CreditoVen = creditoVen;
                                formatlist.Last().ConsignacionVen = consignacionVen;
                                formatlist.Last().TotalVen = totalVen;
                                formatlist.Last().EnvaseVen = envaseVen;

                                creditoVen = 0;
                                consignacionVen = 0;
                                totalVen = 0;
                                envaseVen = 0;
                            }

                            //realizamos la sumatoria de todos los totales de esta ruta
                            if (!grupo.LastOrDefault().RUTClave.Equals(s.ElementAt(index).Key.RUTClave))
                            {
                                formatlist.Last().CreditoRut = creditoRut;
                                formatlist.Last().ConsignacionRut = consignacionRut;
                                formatlist.Last().TotalRut = totalRut;
                                formatlist.Last().EnvaseRut = envaseRut;

                                creditoRut = 0;
                                consignacionRut = 0;
                                totalRut = 0;
                                envaseRut = 0;
                            }

                        }
                        else
                        {

                            formatlist.Last().CreditoVen = creditoVen;
                            formatlist.Last().ConsignacionVen = consignacionVen;
                            formatlist.Last().TotalVen = totalVen;
                            formatlist.Last().EnvaseVen = envaseVen;

                            formatlist.Last().CreditoRut = creditoRut;
                            formatlist.Last().ConsignacionRut = consignacionRut;
                            formatlist.Last().TotalRut = totalRut;
                            formatlist.Last().EnvaseRut = envaseRut;
                        }

                    }

                    DateTime fInicio = DateTime.Parse(FechaInicial);

                    if (String.IsNullOrEmpty(ClientesSplit) || ClientesSplit.Equals("null"))
                    {
                        ClientesSplit = String.Empty;
                    }

                    AnalisisSaldosMOODetallado report = new AnalisisSaldosMOODetallado();
                    report.DataSource = formatlist;


                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    report.logo.Image = Image.FromStream(mStream);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;


                    //ReportHeader
                    report.empresa.Text = NombreEmpresa;
                    report.reporte.Text = NombreReporte;
                    report.headerlabelcedis.Text = Cedis;
                    report.labelfechaheader.Text = fInicio.Date.ToShortDateString();
                    report.labelrutasheader.Text = RutasSplit;
                    report.labelvendedorheader.DataBindings.Add("Text", report.DataSource, "VENNombre");
                    report.labelclienteheader.Text = ClientesSplit;

                    //grouheader4
                    GroupField groupCedi = new GroupField("ALMClave");
                    report.GroupHeader4.GroupFields.Add(groupCedi);
                    report.cediClave.DataBindings.Add("Text", report.DataSource, "ALMClave");
                    report.cediNombre.DataBindings.Add("Text", report.DataSource, "ALMNombre");
                    //grouheader3
                    GroupField groupRuta = new GroupField("RUTClave");
                    report.GroupHeader3.GroupFields.Add(groupRuta);
                    report.rutaClave.DataBindings.Add("Text", report.DataSource, "RUTClave");
                    report.rutaDescripcion.DataBindings.Add("Text", report.DataSource, "RUTDescripcion");

                    //grouheader2
                    GroupField groupVendedor = new GroupField("USUClave");
                    report.GroupHeader2.GroupFields.Add(groupVendedor);
                    report.usuClave.DataBindings.Add("Text", report.DataSource, "USUClave");
                    report.vendedorNombre.DataBindings.Add("Text", report.DataSource, "VENNombre");

                    //groupheader1
                    GroupField groupCliente = new GroupField("CLIClave");
                    report.GroupHeader1.GroupFields.Add(groupCliente);

                    //Datos del detail
                    report.vClave.DataBindings.Add("Text", null, "CLIClave");
                    report.vRazonSocial.DataBindings.Add("Text", null, "CLINombreCorto");
                    report.vNombreContacto.DataBindings.Add("Text", null, "CLINombreContacto");
                    report.vFecha.DataBindings.Add("Text", null, "FechaCaptura", "{0:dd/MM/yyyy}");
                    report.vFolio.DataBindings.Add("Text", null, "Folio");
                    report.vCredito.DataBindings.Add("Text", null, "Credito", "{0:$#.00}");

                    //Datos del groupfooter1
                    report.vCreditoTotal.DataBindings.Add("Text", null, "CreditoTotal", "{0:$#.00}");
                    report.vConsignacion.DataBindings.Add("Text", null, "Consignacion", "{0:$#.00}");
                    report.vTotal.DataBindings.Add("Text", null, "Total", "{0:$#.00}");
                    report.vEnvase.DataBindings.Add("Text", null, "Envase");

                    //Datos del groupfooter2 (Vendedor)
                    report.CreditoVen.DataBindings.Add("Text", null, "CreditoVen", "{0:$#.00}");
                    report.ConsignacionVen.DataBindings.Add("Text", null, "ConsignacionVen", "{0:$#.00}");
                    report.TotalVen.DataBindings.Add("Text", null, "TotalVen", "{0:$#.00}");
                    report.EnvaseVen.DataBindings.Add("Text", null, "EnvaseVen");

                    //Datos del groupfooter3 (Rutas)
                    report.CreditoRut.DataBindings.Add("Text", null, "CreditoRut", "{0:$#.00}");
                    report.ConsignacionRut.DataBindings.Add("Text", null, "ConsignacionRut", "{0:$#.00}");
                    report.TotalRut.DataBindings.Add("Text", null, "TotalRut", "{0:$#.00}");
                    report.EnvaseRut.DataBindings.Add("Text", null, "EnvaseRut");

                    Decimal creditoTotal = formatlist.Sum(item => item.Credito);
                    report.CreditoCEDI.Text = String.Format("{0:$#.00}", creditoTotal);
                    report.CreditoGTotal.Text = String.Format("{0:$#.00}", creditoTotal);

                    Decimal consigTotal = formatlist.Sum(item => item.Consignacion);
                    report.ConsignacionCEDI.Text = String.Format("{0:$#.00}", consigTotal);
                    report.ConsignacionGtotal.Text = String.Format("{0:$#.00}", consigTotal);

                    Decimal granTotal = creditoTotal - consigTotal;
                    report.TotalCEDI.Text = String.Format("{0:$#.00}", granTotal);
                    report.GTotal.Text = String.Format("{0:$#.00}", granTotal);

                    Decimal envaseTotal = formatlist.Sum(item => item.Envase);
                    report.EnvaseCEDI.Text = envaseTotal.ToString();
                    report.EnvaseGTotal.Text = envaseTotal.ToString();

                    SubVendedor subReportVen = new SubVendedor();
                    subReportVen.DataSource = formatlist;

                    //grouheader1 subVendedor
                    GroupField ghvendedor = new GroupField("RUTClave");
                    subReportVen.GroupHeader3.GroupFields.Add(ghvendedor);

                    subReportVen.RutClave.DataBindings.Add("Text", null, "RUTClave");
                    subReportVen.VenNombre.DataBindings.Add("Text", null, "VENNombre");
                    subReportVen.Credito.DataBindings.Add("Text", null, "CreditoRut", "{0:$#.00}");
                    subReportVen.Consignacion.DataBindings.Add("Text", null, "ConsignacionRut", "{0:$#.00}");
                    subReportVen.Total.DataBindings.Add("Text", null, "TotalRut", "{0:$#.00}");
                    subReportVen.Envase.DataBindings.Add("Text", null, "EnvaseRut");

                    subReportVen.CreditoCedi.Text = String.Format("{0:$#.00}", creditoTotal);
                    subReportVen.ConsignacionCedi.Text = String.Format("{0:$#.00}", consigTotal);
                    subReportVen.TotalCedi.Text = String.Format("{0:$#.00}", granTotal);
                    subReportVen.EnvaseCedi.Text = envaseTotal.ToString();

                    subReportVen.CreditoGTotal.Text = String.Format("{0:$#.00}", creditoTotal);
                    subReportVen.ConsignacionGTotal.Text = String.Format("{0:$#.00}", consigTotal);
                    subReportVen.TotalGTotal.Text = String.Format("{0:$#.00}", granTotal);
                    subReportVen.EnvaseGTotal.Text = envaseTotal.ToString();


                    report.xrSubreport1.ReportSource = subReportVen;



                    return report;
                    #endregion
                }
                else
                {
                    #region reporte general
                    sConsulta.AppendLine("SET NOCOUNT ON ");
                    sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpMov')) IS NOT NULL DROP TABLE #TmpMov ");
                    sConsulta.AppendLine("SELECT * INTO #TmpMov FROM ( ");
                    sConsulta.AppendLine("SELECT VCH.AlmacenId, SEC.RUTClave, VEN.VendedorID, VIS.ClienteClave, ");
                    sConsulta.AppendLine("SUM(CASE WHEN TRP.Tipo = 1 THEN TRP.Saldo ELSE 0 END) AS Credito, ");
                    sConsulta.AppendLine("SUM(CASE WHEN TRP.Tipo = 24 THEN TRP.Saldo ELSE 0 END) AS Consignacion ");
                    sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave ");
                    sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT RutClave, ClienteClave FROM Secuencia (NOLOCK) WHERE NOT RUTClave IS NULL) SEC ON VIS.ClienteClave = SEC.ClienteClave ");
                    sConsulta.AppendLine("INNER JOIN VenRut VRT (NOLOCK) ON SEC.RUTClave = VRT.RUTClave AND VRT.TipoEstado = 1 ");
                    sConsulta.AppendLine("INNER JOIN (SELECT VendedorId, AlmacenId, MAX(VCHFechaInicial) AS FechaInicial FROM VENCentroDistHist (NOLOCK) GROUP BY VendedorId, AlmacenId) VCH ON VCH.VendedorId = VRT.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VCH.VendedorID = VEN.VendedorID ");
                    sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCH.AlmacenId = ALM.AlmacenID ");
                    sConsulta.AppendLine(pvCondicion);
                    sConsulta.AppendLine("AND ((TRP.Tipo = 1 AND TRP.TipoFase IN (2,3)) or (TRP.Tipo = 24 AND TRP.TipoFase <> 0)) AND TRP.Saldo <> 0 ");
                    sConsulta.AppendLine("GROUP BY VCH.AlmacenId, SEC.RUTClave, VEN.VendedorID, VIS.ClienteClave ");
                    sConsulta.AppendLine(") AS T1 ");

                    sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpEnv')) IS NOT NULL DROP TABLE #TmpEnv ");
                    sConsulta.AppendLine("SELECT * INTO #TmpEnv FROM ( ");
                    sConsulta.AppendLine("SELECT VCH.AlmacenId, SEC.RUTClave, VRT.VendedorID, PPC.ClienteClave, SUM(PPC.Saldo) AS Saldo ");
                    sConsulta.AppendLine("FROM ProductoPrestamoCli PPC (NOLOCK) ");
                    sConsulta.AppendLine("INNER JOIN (SELECT DISTINCT RutClave, ClienteClave FROM Secuencia (NOLOCK) WHERE NOT RUTClave IS NULL) SEC ON PPC.ClienteClave = SEC.ClienteClave ");
                    sConsulta.AppendLine("INNER JOIN VenRut VRT (NOLOCK) ON SEC.RUTClave = VRT.RUTClave AND VRT.TipoEstado = 1 ");
                    sConsulta.AppendLine("INNER JOIN (SELECT VendedorId, AlmacenId, MAX(VCHFechaInicial) AS FechaInicial FROM VENCentroDistHist (NOLOCK) GROUP BY VendedorId, AlmacenId) VCH ON VCH.VendedorId = VRT.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VCH.VendedorID = VEN.VendedorID ");
                    sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON VCH.AlmacenId = ALM.AlmacenID ");
                    sConsulta.AppendLine(pvCondicion);
                    sConsulta.AppendLine("AND PPC.Saldo <> 0 ");
                    sConsulta.AppendLine("GROUP BY VCH.AlmacenId, SEC.RUTClave, VRT.VendedorID, PPC.ClienteClave ");
                    sConsulta.AppendLine(") AS T2 ");

                    sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpSaldo')) IS NOT NULL DROP TABLE #TmpSaldo ");
                    sConsulta.AppendLine("SELECT * INTO #TmpSaldo FROM ( ");
                    sConsulta.AppendLine("SELECT ISNULL(T1.AlmacenId, T2.AlmacenId) AS AlmacenId, ISNULL(T1.RutClave, T2.RutClave) AS RutClave, ");
                    sConsulta.AppendLine("ISNULL(T1.VendedorId, T2.VendedorId) AS VendedorId, ISNULL(T1.ClienteClave, T2.ClienteClave) AS ClienteClave, ");
                    sConsulta.AppendLine("ISNULL(T1.Credito, 0) AS Credito, ISNULL(T1.Consignacion, 0) AS Consignacion, ISNULL(T2.Saldo, 0) AS Envase ");
                    sConsulta.AppendLine("FROM #TmpMov T1 ");
                    sConsulta.AppendLine("FULL JOIN #TmpEnv T2 ON T1.AlmacenId = T2.AlmacenId AND T1.RutClave = T2.RutClave ");
                    sConsulta.AppendLine("AND T1.VendedorId = T2.VendedorId AND T1.ClienteClave = T2.ClienteClave ");
                    sConsulta.AppendLine(") AS T3 ");

                    sConsulta.AppendLine("SELECT ALM.Clave AS ALMClave, ALM.Nombre AS ALMNombre, RUT.RUTClave, RUT.Descripcion AS RUTDescripcion, USU.Clave AS USUClave, VEN.Nombre AS VENNombre, ");
                    sConsulta.AppendLine("CLI.Clave AS CLIClave, CLI.RazonSocial AS CLINombreCorto, CLI.NombreContacto AS CLINombreContacto, TMP.Credito, TMP.Consignacion, TMP.Envase ");
                    sConsulta.AppendLine("FROM #TmpSaldo TMP ");
                    sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON ALM.AlmacenID = TMP.AlmacenId ");
                    sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = TMP.RUTClave ");
                    sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = TMP.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN Usuario USU (NOLOCK) ON VEN.USUId = USU.USUId ");
                    sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = TMP.ClienteClave ");
                    sConsulta.AppendLine("WHERE TMP.Credito <> 0 OR TMP.Consignacion <> 0 OR TMP.Envase <> 0 ");
                    sConsulta.AppendLine("ORDER BY ALM.Clave, RUT.RUTClave, USU.Clave, CLI.Clave ");

                    sConsulta.AppendLine("DROP TABLE #TmpMov ");
                    sConsulta.AppendLine("DROP TABLE #TmpEnv ");
                    sConsulta.AppendLine("DROP TABLE #TmpSaldo ");
                    sConsulta.AppendLine("SET NOCOUNT OFF ");


                    QueryString = "";

                    QueryString = sConsulta.ToString();


                    List<AnalisisDeSaldoDetMOOModel> User = Connection.Query<AnalisisDeSaldoDetMOOModel>(QueryString, null, null, true, 600).ToList();

                    if (User.Count() <= 0)
                    {
                        return null;
                    }

                    var lista = (from c in User
                                 select c).ToList();

                    var s = (from gr in lista group gr by new { gr.ALMClave, gr.RUTClave, gr.USUClave, gr.CLIClave } into grupo select grupo);
                    List<AnalisisDeSaldoGenMOOModel> formatlist = new List<AnalisisDeSaldoGenMOOModel>();

                    Decimal creditoVen = 0;
                    Decimal consignacionVen = 0;
                    Decimal totalVen = 0;
                    long envaseVen = 0;

                    Decimal creditoRut = 0;
                    Decimal consignacionRut = 0;
                    Decimal totalRut = 0;
                    long envaseRut = 0;

                    int index = 0;
                    foreach (var grupo in s)
                    {
                        index++;
                        foreach (var objetoAgrupado in grupo)
                        {
                            formatlist.Add(new AnalisisDeSaldoGenMOOModel
                            {
                                ALMClave = objetoAgrupado.ALMClave,
                                ALMNombre = objetoAgrupado.ALMNombre,
                                RUTClave = objetoAgrupado.RUTClave,
                                RUTDescripcion = objetoAgrupado.RUTDescripcion,
                                USUClave = objetoAgrupado.USUClave,
                                VENNombre = objetoAgrupado.VENNombre,
                                CLIClave = objetoAgrupado.CLIClave,
                                CLINombreCorto = objetoAgrupado.CLINombreCorto,
                                CLINombreContacto = objetoAgrupado.CLINombreContacto,
                                Credito = objetoAgrupado.Credito,
                                Consignacion = objetoAgrupado.Consignacion
                            });
                        }
                        //llenamos los datos del primer footer solo en el ultimo registro del grupo
                        formatlist.Last().CreditoTotal = grupo.Sum(c => c.Credito);
                        formatlist.Last().Consignacion = grupo.Sum(c => c.Consignacion);
                        formatlist.Last().Total = formatlist.Last().CreditoTotal - formatlist.Last().Consignacion;
                        formatlist.Last().Envase = grupo.FirstOrDefault().Envase;

                        //sumamos los datos por grupo (vendedores) para que al cambiar de grupo se haga la sumatoria por vendedor
                        creditoVen += formatlist.Last().CreditoTotal;
                        consignacionVen += formatlist.Last().Consignacion;
                        totalVen += formatlist.Last().Total;
                        envaseVen += formatlist.Last().Envase;

                        //sumamos los datos por grupo (rutas) para que al cambiar de grupo se haga la sumatoria por ruta
                        creditoRut += formatlist.Last().CreditoTotal;
                        consignacionRut += formatlist.Last().Consignacion;
                        totalRut += formatlist.Last().Total;
                        envaseRut += formatlist.Last().Envase;

                        if (!grupo.Key.Equals(s.Last().Key))
                        {
                            //realizamos la sumatoria de todos los totales de este vendedor
                            if (!grupo.LastOrDefault().USUClave.Equals(s.ElementAt(index).Key.USUClave))
                            {
                                formatlist.Last().CreditoVen = creditoVen;
                                formatlist.Last().ConsignacionVen = consignacionVen;
                                formatlist.Last().TotalVen = totalVen;
                                formatlist.Last().EnvaseVen = envaseVen;

                                creditoVen = 0;
                                consignacionVen = 0;
                                totalVen = 0;
                                envaseVen = 0;
                            }

                            //realizamos la sumatoria de todos los totales de esta ruta
                            if (!grupo.LastOrDefault().RUTClave.Equals(s.ElementAt(index).Key.RUTClave))
                            {
                                formatlist.Last().CreditoRut = creditoRut;
                                formatlist.Last().ConsignacionRut = consignacionRut;
                                formatlist.Last().TotalRut = totalRut;
                                formatlist.Last().EnvaseRut = envaseRut;

                                creditoRut = 0;
                                consignacionRut = 0;
                                totalRut = 0;
                                envaseRut = 0;
                            }

                        }
                        else
                        {

                            formatlist.Last().CreditoVen = creditoVen;
                            formatlist.Last().ConsignacionVen = consignacionVen;
                            formatlist.Last().TotalVen = totalVen;
                            formatlist.Last().EnvaseVen = envaseVen;

                            formatlist.Last().CreditoRut = creditoRut;
                            formatlist.Last().ConsignacionRut = consignacionRut;
                            formatlist.Last().TotalRut = totalRut;
                            formatlist.Last().EnvaseRut = envaseRut;
                        }

                    }

                    DateTime fInicio = DateTime.Parse(FechaInicial);

                    if (String.IsNullOrEmpty(ClientesSplit) || ClientesSplit.Equals("null"))
                    {
                        ClientesSplit = String.Empty;
                    }

                    AnalisisSaldosMOOGeneral reportG = new AnalisisSaldosMOOGeneral();
                    reportG.DataSource = formatlist;

                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    reportG.logo.Image = Image.FromStream(mStream);
                    reportG.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    //ReportHeader
                    reportG.empresa.Text = NombreEmpresa;
                    reportG.reporte.Text = NombreReporte;
                    reportG.headerlabelcedis.Text = Cedis;
                    reportG.labelfechaheader.Text = fInicio.Date.ToShortDateString();
                    reportG.labelrutasheader.Text = RutasSplit;
                    reportG.labelvendedorheader.DataBindings.Add("Text", reportG.DataSource, "VENNombre");
                    reportG.labelclienteheader.Text = ClientesSplit;

                    //grouheader4
                    GroupField groupCedi = new GroupField("ALMClave");
                    reportG.GroupHeader4.GroupFields.Add(groupCedi);
                    reportG.cediClave.DataBindings.Add("Text", reportG.DataSource, "ALMClave");
                    reportG.cediNombre.DataBindings.Add("Text", reportG.DataSource, "ALMNombre");
                    //grouheader3
                    GroupField groupRuta = new GroupField("RUTClave");
                    reportG.GroupHeader3.GroupFields.Add(groupRuta);
                    reportG.rutaClave.DataBindings.Add("Text", reportG.DataSource, "RUTClave");
                    reportG.rutaDescripcion.DataBindings.Add("Text", reportG.DataSource, "RUTDescripcion");

                    //grouheader2
                    GroupField groupVendedor = new GroupField("USUClave");
                    reportG.GroupHeader2.GroupFields.Add(groupVendedor);
                    reportG.usuClave.DataBindings.Add("Text", reportG.DataSource, "USUClave");
                    reportG.vendedorNombre.DataBindings.Add("Text", reportG.DataSource, "VENNombre");

                    //groupheader1
                    GroupField groupCliente = new GroupField("CLIClave");
                    reportG.GroupHeader1.GroupFields.Add(groupCliente);

                    //Datos del detail
                    reportG.vClave.DataBindings.Add("Text", null, "CLIClave");
                    reportG.vRazonSocial.DataBindings.Add("Text", null, "CLINombreCorto");
                    reportG.vNombreContacto.DataBindings.Add("Text", null, "CLINombreContacto");

                    //Datos del groupfooter1
                    reportG.vCreditoTotal.DataBindings.Add("Text", null, "CreditoTotal", "{0:$#.00}");
                    reportG.vConsignacion.DataBindings.Add("Text", null, "Consignacion", "{0:$#.00}");
                    reportG.vTotal.DataBindings.Add("Text", null, "Total", "{0:$#.00}");
                    reportG.vEnvase.DataBindings.Add("Text", null, "Envase");

                    //Datos del groupfooter2 (Vendedor)
                    reportG.CreditoVen.DataBindings.Add("Text", null, "CreditoVen", "{0:$#.00}");
                    reportG.ConsignacionVen.DataBindings.Add("Text", null, "ConsignacionVen", "{0:$#.00}");
                    reportG.TotalVen.DataBindings.Add("Text", null, "TotalVen", "{0:$#.00}");
                    reportG.EnvaseVen.DataBindings.Add("Text", null, "EnvaseVen");

                    //Datos del groupfooter3 (Rutas)
                    reportG.CreditoRut.DataBindings.Add("Text", null, "CreditoRut", "{0:$#.00}");
                    reportG.ConsignacionRut.DataBindings.Add("Text", null, "ConsignacionRut", "{0:$#.00}");
                    reportG.TotalRut.DataBindings.Add("Text", null, "TotalRut", "{0:$#.00}");
                    reportG.EnvaseRut.DataBindings.Add("Text", null, "EnvaseRut");

                    Decimal creditoTotal = formatlist.Sum(item => item.Credito);
                    reportG.CreditoCEDI.Text = String.Format("{0:$#.00}", creditoTotal);
                    reportG.CreditoGTotal.Text = String.Format("{0:$#.00}", creditoTotal);

                    Decimal consigTotal = formatlist.Sum(item => item.Consignacion);
                    reportG.ConsignacionCEDI.Text = String.Format("{0:$#.00}", consigTotal);
                    reportG.ConsignacionGtotal.Text = String.Format("{0:$#.00}", consigTotal);

                    Decimal granTotal = creditoTotal - consigTotal;
                    reportG.TotalCEDI.Text = String.Format("{0:$#.00}", granTotal);
                    reportG.GTotal.Text = String.Format("{0:$#.00}", granTotal);

                    Decimal envaseTotal = formatlist.Sum(item => item.Envase);
                    reportG.EnvaseCEDI.Text = envaseTotal.ToString();
                    reportG.EnvaseGTotal.Text = envaseTotal.ToString();

                    SubVendedor subReportVen = new SubVendedor();
                    subReportVen.DataSource = formatlist;

                    //grouheader1 subVendedor
                    GroupField ghvendedor = new GroupField("RUTClave");
                    subReportVen.GroupHeader3.GroupFields.Add(ghvendedor);

                    subReportVen.RutClave.DataBindings.Add("Text", null, "RUTClave");
                    subReportVen.VenNombre.DataBindings.Add("Text", null, "VENNombre");
                    subReportVen.Credito.DataBindings.Add("Text", null, "CreditoRut", "{0:$#.00}");
                    subReportVen.Consignacion.DataBindings.Add("Text", null, "ConsignacionRut", "{0:$#.00}");
                    subReportVen.Total.DataBindings.Add("Text", null, "TotalRut", "{0:$#.00}");
                    subReportVen.Envase.DataBindings.Add("Text", null, "EnvaseRut");

                    subReportVen.CreditoCedi.Text = String.Format("{0:$#.00}", creditoTotal);
                    subReportVen.ConsignacionCedi.Text = String.Format("{0:$#.00}", consigTotal);
                    subReportVen.TotalCedi.Text = String.Format("{0:$#.00}", granTotal);
                    subReportVen.EnvaseCedi.Text = envaseTotal.ToString();

                    subReportVen.CreditoGTotal.Text = String.Format("{0:$#.00}", creditoTotal);
                    subReportVen.ConsignacionGTotal.Text = String.Format("{0:$#.00}", consigTotal);
                    subReportVen.TotalGTotal.Text = String.Format("{0:$#.00}", granTotal);
                    subReportVen.EnvaseGTotal.Text = envaseTotal.ToString();


                    reportG.xrSubreport1.ReportSource = subReportVen;


                    return reportG;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                return new ReportePedidos();
            }
        }
    }

    class AnalisisDeSaldoDetMOOModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public string RUTClave { get; set; }
        public string RUTDescripcion { get; set; }
        public string USUClave { get; set; }
        public string VENNombre { get; set; }
        public string CLIClave { get; set; }
        public string CLINombreCorto { get; set; }
        public string CLINombreContacto { get; set; }
        public DateTime FechaCaptura { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Folio { get; set; }
        public Decimal Credito { get; set; }
        public Decimal CreditoTotal { get; set; }
        public Decimal Consignacion { get; set; }
        public Decimal Total { get; set; }
        public long Envase { get; set; }

        public Decimal CreditoVen { get; set; }
        public Decimal ConsignacionVen { get; set; }
        public Decimal TotalVen { get; set; }
        public long EnvaseVen { get; set; }

        public Decimal CreditoRut { get; set; }
        public Decimal ConsignacionRut { get; set; }
        public Decimal TotalRut { get; set; }
        public long EnvaseRut { get; set; }


    }

    class AnalisisDeSaldoGenMOOModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public string RUTClave { get; set; }
        public string RUTDescripcion { get; set; }
        public string USUClave { get; set; }
        public string VENNombre { get; set; }
        public string CLIClave { get; set; }
        public string CLINombreCorto { get; set; }
        public string CLINombreContacto { get; set; }
        public Decimal Credito { get; set; }
        public Decimal CreditoTotal { get; set; }
        public Decimal Consignacion { get; set; }
        public Decimal Total { get; set; }
        public long Envase { get; set; }

        public Decimal CreditoVen { get; set; }
        public Decimal ConsignacionVen { get; set; }
        public Decimal TotalVen { get; set; }
        public long EnvaseVen { get; set; }

        public Decimal CreditoRut { get; set; }
        public Decimal ConsignacionRut { get; set; }
        public Decimal TotalRut { get; set; }
        public long EnvaseRut { get; set; }
    }
}