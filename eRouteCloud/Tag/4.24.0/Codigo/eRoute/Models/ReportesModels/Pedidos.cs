using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Text;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class Pedidos
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string VendedoresSplit, string ClientesSplit, string FechaInicial, string FechaFinal, string Cedis, string NombreCedis, bool detallado)
        {
            try
            {
                bool pvConversionKg = false;
                StringBuilder sConsulta = new StringBuilder();

                if (detallado)
                {
                    #region reporte detallado
                    sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                    sConsulta.AppendLine("SET NOCOUNT ON ");
                    sConsulta.AppendLine("SELECT FechaCaptura AS Fecha, VENNombre AS Vendedor, RUTClave + ' ' + RUTDescripcion AS Ruta, ");
                    sConsulta.AppendLine("TMP.TransProdID,Folio, RazonSocial AS Cliente, ProductoClave AS Clave, PRONombre AS Producto, Unidad, ");
                    if (pvConversionKg)
                    {
                        sConsulta.AppendLine("TMP.KgLts, ");
                    }

                    sConsulta.AppendLine("Precio AS PrecioU, ALNClave + ' ' + ALNNombre AS CEDI, Cantidad AS Cant, TPDSubtotal AS SubTotal, DescuentoImp AS DescProducto, ");
                    sConsulta.AppendLine("DescuentoCliente, ((TPDSubTotal - DescuentoCliente-DescuentoImp ) * DescVendPor / 100) AS DescVend, ");
                    sConsulta.AppendLine("Impuesto - (Impuesto * DescVendPor / 100) AS Impuesto, ");
                    sConsulta.AppendLine("((TPDSubTotal - DescuentoImp - DescuentoCliente) - ((TPDSubTotal - DescuentoCliente - DescuentoImp ) * DescVendPor / 100) + (Impuesto - (Impuesto * DescVendPor / 100))) AS Total "); ;
                    sConsulta.AppendLine("FROM (");
                    sConsulta.AppendLine("SELECT TMP.DiaClave, TMP.FechaCaptura, TMP.TransProdID,TMP.Folio, TMP.DescVendPor, ");
                    sConsulta.AppendLine("TMP.TRPSubtotal, TMP.ClienteClave, TMP.RazonSocial, TMP.ProductoClave, TMP.Precio, ");
                    sConsulta.AppendLine("TMP.Cantidad, TMP.DescuentoCliente, TMP.DescuentoImp, TMP.TPDSubtotal, TMP.Impuesto, TMP.TipoUnidad, ");
                    if (pvConversionKg)
                    {
                        sConsulta.AppendLine("TMP.KgLts, ");
                    }
                    sConsulta.AppendLine("TMP.PRONombre, TMP.Unidad, TMP.RutClave, TMP.VendedorId, TMP.VENNombre, ");
                    sConsulta.AppendLine("ALN.Clave AS ALNClave, ALN.Nombre AS ALNNombre, RUT.Descripcion AS RUTDescripcion ");
                    sConsulta.AppendLine("FROM (");
                    sConsulta.AppendLine("SELECT TRP.DiaClave, ");
                    sConsulta.AppendLine("TRP.FechaCaptura, TRP.TransProdID,TRP.Folio, TRP.DescVendPor, TRP.Subtotal AS TRPSubtotal, VIS.ClienteClave, ");
                    sConsulta.AppendLine("CLI.RazonSocial + ' ' + cli.nombrecontacto AS razonsocial, TPD.ProductoClave, TPD.Precio, TPD.Cantidad, TPD.DescuentoImp, ");

                    if (pvConversionKg)
                    {
                        sConsulta.AppendLine("PRU.KgLts * TPD.Cantidad AS KgLts, ");
                    }
                    sConsulta.AppendLine("(TPD.Precio * TPD.Cantidad) AS TPDSubTotal, ");
                    sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) AS DescuentoCliente, ");
                    sConsulta.AppendLine("(TPD.Impuesto - (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId = TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId)) AS Impuesto, ");
                    sConsulta.AppendLine("TPD.TipoUnidad, PRO.Nombre AS PRONombre, ");
                    sConsulta.AppendLine("VAD.Descripcion AS Unidad, VIS.RutClave, VEN.VendedorId, VEN.Nombre AS VENNombre, VENCEDI.AlmacenId ");
                    sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = TRP.DiaClave ");
                    sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TPD.TransProdId = TRP.TransProdId ");
                    sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave ");
                    if (pvConversionKg)
                    {
                        sConsulta.AppendLine("INNER JOIN ProductoUnidad PRU (NOLOCK) ON PRU.ProductoClave = PRO.ProductoClave AND PRU.PRUTipoUnidad = TPD.TipoUnidad ");
                    }
                    sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD (NOLOCK) ON VAD.VARCodigo = 'UNIDADV' AND VAD.VAVClave = TPD.TipoUnidad AND VAD.VADTipoLenguaje = 'EM' ");
                    sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave ");
                    sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave ");
                    sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST VENCEDI (NOLOCK) ON VENCEDI.VENDEDORID = VEN.VENDEDORID AND Vis.FechaHoraInicial ");
                    sConsulta.AppendLine("BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL ");
                    sConsulta.AppendLine(pvCondicion + " AND TRP.Tipo = 1 AND TRP.TipoFase IN (1,7) ");
                    sConsulta.AppendLine(") TMP ");

                    sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.AlmacenID = TMP.AlmacenId ");
                    sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON TMP.RUTClave = RUT.RUTClave ");
                    sConsulta.AppendLine("WHERE ALN.AlmacenID = '" + Cedis + "') TMP ");
                    sConsulta.AppendLine("SET NOCOUNT OFF ");

                    QueryString = "";

                    QueryString = sConsulta.ToString();

                    //realizamos la consulta y guardamos el resultado en un modelo
                    List<PedidosModel> User = Connection.Query<PedidosModel>(QueryString, null, null, true, 600).ToList();
                    //si el resultado de la consulta no nos devuelve ningun registro devolvemos null
                    if (User.Count() <= 0)
                    {
                        return null;
                    }
                    //pasamos a una lista el resultado de la consulta
                    var lista = (from c in User
                                 select c).ToList();
                    //Agrupamos la lista con respecto a los filtros del reporte
                    var s = (from gr in lista group gr by new { gr.Fecha, gr.Ruta, gr.Folio } into grupo select grupo);
                    //creamos una lista con formato que nos servira de datasource para el reporteador
                    List<PedidosModel> formatlist = new List<PedidosModel>();
                    //recorremos cada gurpo de la lista y a continuacion cada elemento del grupo para llenar la formatlist
                    foreach (var grupo in s)
                    {
                        foreach (var objetoAgrupado in grupo)
                        {
                            formatlist.Add(new PedidosModel
                            {
                                Vendedor = objetoAgrupado.Vendedor,
                                Ruta = objetoAgrupado.Ruta,
                                TansProdID = objetoAgrupado.TansProdID,
                                Folio = objetoAgrupado.Folio,
                                Cliente = objetoAgrupado.Cliente,
                                Clave = objetoAgrupado.Clave,
                                Producto = objetoAgrupado.Producto,
                                Unidad = objetoAgrupado.Unidad,
                                KgLts = objetoAgrupado.KgLts,
                                PrecioU = objetoAgrupado.PrecioU,
                                CEDI = objetoAgrupado.CEDI,
                                Cant = objetoAgrupado.Cant,
                                SubTotal = objetoAgrupado.SubTotal,
                                DescProducto = objetoAgrupado.DescProducto,
                                DescuentoCliente = objetoAgrupado.DescuentoCliente,
                                DescVend = objetoAgrupado.DescVend,
                                Impuesto = objetoAgrupado.Impuesto,
                                Total = objetoAgrupado.Total,
                                Fecha = objetoAgrupado.Fecha

                            });
                        }
                        //hacemos la sumatoria de totales de este grupo para sacar el gran total de este bloque
                        formatlist.Last().GranTotal = grupo.Sum(c => c.Total);
                    }
                    //se hace la sumatoria de todos los totales de la lista para calcular el total del cedi
                    double gtotCedi = lista.Sum(item => item.Total);
                    //se cuentan los grupos que se obtuvieron y se obtiene el total de folios
                    int totFolio = s.Count();

                    ReportePedidos report = new ReportePedidos();
                    report.DataSource = formatlist;



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
                    report.reporte.Text = NombreReporte + " Detallado";



                    //ReportHeader
                    report.headerlabelcedis.Text = NombreCedis;
                    report.labelfechaheader.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                    if (String.IsNullOrEmpty(VendedoresSplit))
                        report.labelrutasheader.Text = RutasSplit;
                    if (String.IsNullOrEmpty(RutasSplit))
                        report.labelvendedorheader.Text = VendedoresSplit;
                    //report.labelvendedorheader.DataBindings.Add("Text", report.DataSource, "Vendedor");


                    //grouheader4
                    GroupField groupCedi = new GroupField("CEDI");

                    report.GroupHeader5.GroupFields.Add(groupCedi);
                    report.CediLabel.DataBindings.Add("Text", report.DataSource, "CEDI");
                    //grouheader3
                    GroupField groupVendedor = new GroupField("Vendedor");
                    report.GroupHeader4.GroupFields.Add(groupVendedor);
                    report.labelVen.DataBindings.Add("Text", report.DataSource, "Vendedor");
                    //grouheader2
                    GroupField groupRuta = new GroupField("Ruta");
                    report.GroupHeader3.GroupFields.Add(groupRuta);
                    report.rutalabel.DataBindings.Add("Text", report.DataSource, "Ruta");
                    System.Diagnostics.Debug.WriteLine(groupRuta.SortOrder);
                    //grouheader1
                    GroupField groupFecha = new GroupField("Fecha");
                    report.GroupHeader2.GroupFields.Add(groupFecha);
                    report.fechalabel.DataBindings.Add("Text", report.DataSource, "Fecha", "{0:dd/MM/yyyy}");

                    GroupField groupFolio = new GroupField("Folio");
                    report.GroupHeader1.GroupFields.Add(groupFolio);
                    report.xrLabel5.DataBindings.Add("Text", report.DataSource, "Folio");

                    report.l1.DataBindings.Add("Text", null, "Clave");
                    report.l2.DataBindings.Add("Text", null, "Producto");
                    report.l3.DataBindings.Add("Text", null, "Unidad");
                    report.l4.DataBindings.Add("Text", null, "PrecioU", "{0:$#,###,##0.00}");
                    report.l5.DataBindings.Add("Text", null, "Cant");
                    report.l6.DataBindings.Add("Text", null, "SubTotal", "{0:$#,###,##0.00}");
                    report.l7.DataBindings.Add("Text", null, "DescProducto", "{0:$#,###,##0.00}");
                    report.l8.DataBindings.Add("Text", null, "DescuentoCliente", "{0:$#,###,##0.00}");
                    report.l9.DataBindings.Add("Text", null, "DescVend", "{0:$#,###,##0.00}");
                    report.l10.DataBindings.Add("Text", null, "Impuesto", "{0:$#,###,##0.00}");
                    report.l11.DataBindings.Add("Text", null, "Total", "{0:$#,###,##0.00}");
                    report.total.DataBindings.Add("Text", null, "GranTotal", "{0:$#,###,##0.00}");

                    //report.gTotal.DataBindings.Add("Text", null, "GranTotal", "{0:$#.00}");
                    int totprodd = lista.Sum(item => item.Cant);
                    report.totFolios.Text = totFolio.ToString();
                    report.totVendido.Text = String.Format("{0:$#,###,##0.00}", gtotCedi);
                    report.gtcedi.Text = String.Format("{0:$#,###,##0.00}", gtotCedi);
                    report.totProducto.Text = totprodd.ToString();


                    ProductosPedidos subPedidos = new ProductosPedidos();
                    List<ProductosPedidosModel> listSub = Connection.Query<ProductosPedidosModel>(GetProducts(pvCondicion, pvConversionKg, Cedis), null, null, true, 600).ToList();

                    double gtot = listSub.Sum(item => item.Total);
                    double totprod = listSub.Sum(item => item.Cantidad);

                    subPedidos.DataSource = listSub;

                    subPedidos.subClave.DataBindings.Add("Text", null, "Clave");
                    subPedidos.subProducto.DataBindings.Add("Text", null, "Producto");
                    subPedidos.subUnidad.DataBindings.Add("Text", null, "Unidad");
                    subPedidos.subCantidad.DataBindings.Add("Text", null, "Cantidad");
                    subPedidos.subTotal.DataBindings.Add("Text", null, "Total", "{0:$#,###,###.##}");

                    subPedidos.grantotal.Text = String.Format("{0:$#,###,###.##}", gtot);
                    //subPedidos.grantotal.Text = String.Format("{0:$#.00}", gtot);
                    subPedidos.totprod.Text = totprod.ToString();


                    report.xrSubreport1.ReportSource = subPedidos;



                    return report;
                    #endregion
                }
                else
                {
                    #region reporte general
                    sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                    sConsulta.AppendLine("SET NOCOUNT ON ");
                    sConsulta.AppendLine("SELECT DISTINCT FechaCaptura AS Fecha, VENNombre AS Vendedor, RutClave + ' ' + RUTDescripcion AS Ruta, ");
                    sConsulta.AppendLine("TMP.TransProdId, Folio, CLIRazonSocial AS Cliente, CLIClave AS Clave, ALNClave + ' ' + ALNNombre AS CEDI, Total ");
                    sConsulta.AppendLine("FROM (");
                    sConsulta.AppendLine("SELECT TMP.FechaCaptura, TMP.Folio, TMP.TransProdId, TMP.Total, TMP.DiaClave, TMP.CLIRazonSocial, TMP.CLIClave, TMP.VENNombre, ");
                    sConsulta.AppendLine("TMP.VendedorID, TMP.RutClave, TMP.RUTDescripcion, ALN.Clave AS ALNClave, ALN.Nombre AS ALNNombre ");
                    sConsulta.AppendLine("FROM (");
                    sConsulta.AppendLine("SELECT TRP.FechaCaptura, TRP.Folio, TRP.TransProdId, TRP.Total, TRP.DiaClave, ");
                    sConsulta.AppendLine("CLI.RazonSocial +' '+cli.nombrecontacto AS CLIRazonSocial, CLI.Clave AS CLIClave, ");
                    sConsulta.AppendLine("VEN.Nombre AS VENNombre, VEN.VendedorID, RUT.RutClave, RUT.Descripcion AS RUTDescripcion, VENCEDI.AlmacenId ");
                    sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = TRP.DiaClave ");
                    sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave ");
                    sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave ");
                    sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON VIS.RUTClave = RUT.RUTClave ");
                    sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST VENCEDI (NOLOCK) ON VENCEDI.VENDEDORID = VEN.VENDEDORID AND Vis.FechaHoraInicial ");
                    sConsulta.AppendLine("BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL ");
                    sConsulta.AppendLine(pvCondicion + " AND TRP.Tipo = 1 AND TRP.TipoFase IN (1,7) ");
                    sConsulta.AppendLine(") TMP ");
                    sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.AlmacenID = TMP.AlmacenId ");
                    sConsulta.AppendLine("WHERE ALN.AlmacenID = '" + Cedis + "') TMP ");
                    sConsulta.AppendLine("SET NOCOUNT OFF ");


                    QueryString = "";

                    QueryString = sConsulta.ToString();


                    List<PedidosGeneralModel> User = Connection.Query<PedidosGeneralModel>(QueryString, null, null, true, 600).ToList();

                    if (User.Count() <= 0)
                    {
                        return null;
                    }
                    //var lista = (FROM c IN User

                    // SELECT c).ToList();

                    var lista = (from c in User
                                 select c).ToList();

                    var sd = lista.GroupBy(l => new { l.Fecha, l.Ruta })
                    .SelectMany(cl => cl.Select(cs => new PedidosGeneralModel
                    {
                        Vendedor = cs.Vendedor,
                        Ruta = cs.Ruta,
                        TransProdId = cs.TransProdId,
                        Folio = cs.Folio,
                        Cliente = cs.Cliente,
                        Clave = cs.Clave,
                        CEDI = cs.CEDI,
                        Total = cs.Total,
                        Fecha = cs.Fecha,
                        GranTotal = cl.Sum(c => c.Total)//cl.Sum(c => c.Total).ToString(),
                    })).ToList();

                    double gtotCedi = lista.Sum(item => item.Total);
                    int totFolio = lista.Count();


                    ReportePedidoGeneral reportG = new ReportePedidoGeneral();
                    //reportG.DataSource = lista;
                    reportG.DataSource = sd;

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
                    reportG.logo.Image = Image.FromStream(mStream);
                    reportG.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    reportG.empresa.Text = NombreEmpresa;
                    reportG.reporte.Text = NombreReporte + " General";



                    //ReportHeader
                    reportG.headerlabelcedis.Text = NombreCedis;
                    reportG.labelfechaheader.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                    if (String.IsNullOrEmpty(VendedoresSplit))
                        reportG.labelrutasheader.Text = RutasSplit;
                    if (String.IsNullOrEmpty(RutasSplit))
                        reportG.labelvendedorheader.Text = VendedoresSplit;

                    //grouheader4
                    GroupField groupCedi = new GroupField("CEDI");

                    reportG.GroupHeader4.GroupFields.Add(groupCedi);
                    reportG.CediLabel.DataBindings.Add("Text", reportG.DataSource, "CEDI");
                    //grouheader3
                    GroupField groupVendedor = new GroupField("Vendedor");
                    reportG.GroupHeader3.GroupFields.Add(groupVendedor);
                    reportG.labelVen.DataBindings.Add("Text", reportG.DataSource, "Vendedor");
                    //grouheader2
                    GroupField groupRuta = new GroupField("Ruta");
                    reportG.GroupHeader2.GroupFields.Add(groupRuta);
                    reportG.rutalabel.DataBindings.Add("Text", reportG.DataSource, "Ruta");
                    System.Diagnostics.Debug.WriteLine(groupRuta.SortOrder);
                    //grouheader1
                    GroupField groupFecha = new GroupField("Fecha");
                    reportG.GroupHeader1.GroupFields.Add(groupFecha);
                    reportG.fechalabel.DataBindings.Add("Text", reportG.DataSource, "Fecha", "{0:dd/MM/yyyy}");

                    reportG.l1.DataBindings.Add("Text", null, "Folio");
                    reportG.l2.DataBindings.Add("Text", null, "Clave");
                    reportG.l3.DataBindings.Add("Text", null, "Cliente");
                    reportG.l4.DataBindings.Add("Text", null, "Total", "{0:$#,###,##0.00}");

                    reportG.gTotal.DataBindings.Add("Text", null, "GranTotal", "{0:$#,###,##0.00}");
                    reportG.totFolios.Text = totFolio.ToString();
                    reportG.totVendido.Text = String.Format("{0:$#,###,##0.00}", gtotCedi);
                    reportG.gtcedi.Text = String.Format("{0:$#,###,##0.00}", gtotCedi);

                    ProductosPedidos subPedidos = new ProductosPedidos();
                    List<ProductosPedidosModel> listSub = Connection.Query<ProductosPedidosModel>(GetProducts(pvCondicion, pvConversionKg, Cedis), null, null, true, 600).ToList();
                    subPedidos.DataSource = listSub;

                    double gtot = listSub.Sum(item => item.Total);
                    double totprod = listSub.Sum(item => item.Cantidad);


                    subPedidos.subClave.DataBindings.Add("Text", null, "Clave");
                    subPedidos.subProducto.DataBindings.Add("Text", null, "Producto");
                    subPedidos.subUnidad.DataBindings.Add("Text", null, "Unidad");
                    subPedidos.subCantidad.DataBindings.Add("Text", null, "Cantidad");
                    //subPedidos.subTotal.DataBindings.Add("Text", null, "Total", "{0:$#.00}");
                    subPedidos.subTotal.DataBindings.Add("Text", null, "Total", "{0:$#,###,##0.00}");

                    subPedidos.grantotal.Text = String.Format("{0:$#,###,##0.00}", gtot);
                    subPedidos.totprod.Text = totprod.ToString();

                    reportG.xrSubreport1.ReportSource = subPedidos;


                    return reportG;
                    #endregion
                }
            }
            catch (Exception ex)
            {

                return new ReportePedidos();
            }
        }


        public string GetProducts(string pvCondicion, bool pvConversionKg, string Cedis)
        {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            sConsulta.AppendLine("SET NOCOUNT ON ");
            sConsulta.AppendLine("SELECT CEDI, Clave, Producto, Unidad, ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("SUM(KgLts) AS KgLts, ");
            }
            sConsulta.AppendLine("SUM(Cantidad) AS Cantidad, SUM(Total) AS Total ");
            sConsulta.AppendLine("FROM (SELECT ClienteClave, (ALNClave + ' ' + ALNNombre) AS CEDI, ProductoClave AS Clave, ");
            sConsulta.AppendLine("PRONombre AS Producto, Unidad, ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("KgLts, ");
            }
            sConsulta.AppendLine("Cantidad, TPDTotal AS Total ");
            sConsulta.AppendLine("FROM ( ");
            sConsulta.AppendLine("SELECT TMP.ProductoClave, TMP.Cantidad, ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("TMP.KgLts, ");
            }
            sConsulta.AppendLine("(SubTotal - DescuentoCliente -((SubTotal - DescuentoCliente) * DescVendPor / 100)) + (Impuesto - DescuentoClienteImpuesto -((Impuesto - DescuentoClienteImpuesto) * DescVendPor / 100)) AS TPDtotal, ");
            sConsulta.AppendLine("TMP.Impuesto, TMP.DescVendPor, TMP.DiaClave, TMP.ClienteClave, TMP.PRONombre, TMP.Unidad, ");
            sConsulta.AppendLine("TMP.VendedorId, ALN.Clave AS ALNClave, ALN.Nombre AS ALNNombre ");
            sConsulta.AppendLine("FROM ( ");
            sConsulta.AppendLine("SELECT TPD.ProductoClave, TPD.Cantidad, TPD.Impuesto, TRP.DescVendPor, TPD.SubTotal, ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("PRU.KgLts * TPD.Cantidad AS KgLts, ");
            }
            sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE SUM(DesImporte) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) AS DescuentoCliente, ");
            sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE SUM(DesImpuesto) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId = TPD.TransProdDetalleId) AS DescuentoClienteImpuesto, ");
            sConsulta.AppendLine("TRP.DiaClave, TRP.ClienteClave, PRO.Nombre AS PRONombre, VAD.Descripcion AS Unidad, VEN.VendedorId, RUT.RUTClave, VENCEDI.AlmacenId ");
            sConsulta.AppendLine("FROM TransProdDetalle TPD (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN TransProd TRP (NOLOCK) ON TRP.TransProdId = TPD.TransProdId ");
            sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = TRP.DiaClave ");
            sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("INNER JOIN ProductoUnidad PRU (NOLOCK) ON PRU.ProductoClave = PRO.ProductoClave AND PRU.PRUTipoUnidad = TPD.TipoUnidad ");
            }
            sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD (NOLOCK) ON VAD.VARCodigo = 'UNIDADV' AND VAD.VAVClave = TPD.TipoUnidad AND VAD.VADTipoLenguaje = 'EM' ");
            sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave ");
            sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON CLI.ClienteClave = VIS.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId ");
            sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON VIS.RUTClave = RUT.RUTClave ");
            sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST VENCEDI (NOLOCK) ON VENCEDI.VENDEDORID = VEN.VENDEDORID AND Vis.FechaHoraInicial ");
            sConsulta.AppendLine("BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL ");
            sConsulta.AppendLine(pvCondicion + " AND TRP.Tipo = 1 AND TRP.TipoFase in(1,7) ");
            sConsulta.AppendLine(") TMP ");
            sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.AlmacenID = TMP.AlmacenID");
            sConsulta.AppendLine("WHERE ALN.AlmacenID = '" + Cedis + "') TMP ");
            sConsulta.AppendLine(") AS t1 GROUP BY CEDI, Clave, Producto, Unidad ");
            sConsulta.AppendLine("SET NOCOUNT OFF ");
            string res = sConsulta.ToString();
            return res;
        }
    }

    //class GranTotal
    //{
    // public double GranTotal { get; set; }
    //}


    class PedidosModel
    {
        public DateTime Fecha { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public string TansProdID { get; set; }
        public string Folio { get; set; }
        public string Cliente { get; set; }
        public string Clave { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public string KgLts { get; set; }
        public double PrecioU { get; set; }
        public string CEDI { get; set; }
        public int Cant { get; set; }
        public double SubTotal { get; set; }
        public double DescProducto { get; set; }
        public double DescuentoCliente { get; set; }
        public double DescVend { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public double GranTotal { get; set; }
    }

    class PedidosGeneralModel
    {
        public DateTime Fecha { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public string TransProdId { get; set; }
        public string Folio { get; set; }
        public string Cliente { get; set; }
        public string Clave { get; set; }
        public string CEDI { get; set; }
        public double Total { get; set; }
        public double GranTotal { get; set; }
    }

    class ProductosPedidosModel
    {
        public string CEDI { get; set; }
        public string Clave { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public string GranTotal { get; set; }
        public string TotalProductos { get; set; }
    }
}