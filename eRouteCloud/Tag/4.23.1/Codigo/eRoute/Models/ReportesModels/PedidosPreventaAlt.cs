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
    public class PedidosPreventaAlt
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string VendedoresSplit, string ClientesSplit, string FechaInicial, string FechaFinal, string Cedis, string NombreCedis, bool detallado)
        {
            try
            {
                bool pvConversionKg = Connection.Query<int>("Select top 1 ConversionKg From ConHist (NOLOCK) Order By MFechaHora Desc", null, null, true, 600).FirstOrDefault() == 1;
                StringBuilder sConsulta = new StringBuilder();

                ProductosPedidosAlt subPedidos = new ProductosPedidosAlt();
                List<ProductosPedidosAltModel> listSub = Connection.Query<ProductosPedidosAltModel>(GetProducts(pvCondicion, pvConversionKg, Cedis), null, null, true, 600).ToList();
                subPedidos.DataSource = listSub;

                double gtot = listSub.Sum(item => item.Total);
                double totprod = listSub.Sum(item => item.Cantidad);
                double totKilos = listSub.Sum(item => item.KgLts);

                subPedidos.xrLabelKg.Visible = pvConversionKg;
                subPedidos.subClave.DataBindings.Add("Text", null, "Clave");
                subPedidos.subProducto.DataBindings.Add("Text", null, "Producto");
                subPedidos.subUnidad.DataBindings.Add("Text", null, "Unidad");
                subPedidos.subCantidad.DataBindings.Add("Text", null, "Cantidad");
                subPedidos.subKilos.Visible = pvConversionKg;
                subPedidos.subKilos.DataBindings.Add("Text", null, "KgLts");
                //subPedidos.subTotal.DataBindings.Add("Text", null, "Total", "{0:$#.00}");
                subPedidos.subTotal.DataBindings.Add("Text", null, "Total", "{0:$#,###,##0.00}");
                subPedidos.grantotal.Text = String.Format("{0:$#,###,##0.00}", gtot);
                subPedidos.totprod.Text = totprod.ToString();
                subPedidos.totKilos.Visible = pvConversionKg;
                subPedidos.totKilos.Text = totKilos.ToString();
                subPedidos.xrLabelKgTot.Visible = pvConversionKg;
                subPedidos.lbTotalPro.Visible = !detallado;
                subPedidos.totprod.Visible = !detallado;

                if (detallado)
                {
                    #region reporte detallado
                    sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                    sConsulta.AppendLine("set nocount on ");
                    sConsulta.AppendLine("select FechaCaptura as Fecha, VENNombre as Vendedor, RUTClave + ' ' + RUTDescripcion as Ruta, ");
                    sConsulta.AppendLine("TMP.TransProdID,Folio, RazonSocial as Cliente, ProductoClave as Clave, PRONombre as Producto, Unidad, TMP.Fase, ");
                    if (pvConversionKg)
                    {
                        sConsulta.AppendLine("TMP.KgLts, ");
                    }

                    sConsulta.AppendLine("Precio as PrecioU, ALNClave + ' ' + ALNNombre as CEDI, Cantidad as Cant, TPDSubtotal as SubTotal, DescuentoImp as DescProducto, ");
                    sConsulta.AppendLine("DescuentoCliente, ((TPDSubTotal - DescuentoCliente-DescuentoImp ) * DescVendPor / 100) as DescVend, ");
                    sConsulta.AppendLine("Impuesto - (Impuesto * DescVendPor / 100)  as Impuesto, ");
                    sConsulta.AppendLine("((TPDSubTotal - DescuentoImp - DescuentoCliente) - ((TPDSubTotal - DescuentoCliente - DescuentoImp ) * DescVendPor / 100) + (Impuesto - (Impuesto * DescVendPor / 100))) as Total "); ;
                    sConsulta.AppendLine("from (");
                    sConsulta.AppendLine("select TMP.DiaClave, TMP.FechaCaptura, TMP.TransProdID,TMP.Folio, TMP.DescVendPor, ");
                    sConsulta.AppendLine("TMP.TRPSubtotal, TMP.ClienteClave, TMP.RazonSocial, TMP.ProductoClave, TMP.Precio, ");
                    sConsulta.AppendLine("TMP.Cantidad, TMP.DescuentoCliente, TMP.DescuentoImp, TMP.TPDSubtotal, TMP.Impuesto, TMP.TipoUnidad, ");
                    if (pvConversionKg)
                    {
                        sConsulta.AppendLine("TMP.KgLts, ");
                    }
                    sConsulta.AppendLine("TMP.PRONombre, TMP.Unidad, TMP.RutClave, TMP.VendedorId, TMP.VENNombre, TMP.Fase, ");
                    sConsulta.AppendLine("ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, RUT.Descripcion as RUTDescripcion ");
                    sConsulta.AppendLine("from (");
                    sConsulta.AppendLine("select TRP.DiaClave, ");
                    sConsulta.AppendLine("TRP.FechaCaptura, TRP.TransProdID,TRP.Folio, TRP.DescVendPor, TRP.Subtotal as TRPSubtotal, VIS.ClienteClave, ");
                    sConsulta.AppendLine("CLI.RazonSocial+' '+cli.nombrecontacto as razonsocial, TPD.ProductoClave, TPD.Precio, TPD.Cantidad, TPD.DescuentoImp, ");

                    if (pvConversionKg)
                    {
                        sConsulta.AppendLine("PRU.KgLts * TPD.Cantidad as KgLts, ");
                    }
                    sConsulta.AppendLine("(TPD.Precio * TPD.Cantidad) as TPDSubTotal, ");
                    sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD (NOLOCK)  WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ");
                    sConsulta.AppendLine("(TPD.Impuesto - (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as Impuesto, ");
                    sConsulta.AppendLine("TPD.TipoUnidad, PRO.Nombre as PRONombre, ");
                    sConsulta.AppendLine("VAD.Descripcion as Unidad, VIS.RutClave, VEN.VendedorId, VEN.Nombre as VENNombre, VENCEDI.AlmacenId, VAD2.Descripcion AS Fase ");
                    sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = TRP.DiaClave ");
                    sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TPD.TransProdId = TRP.TransProdId ");
                    sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave ");
                    if (pvConversionKg)
                    {
                        sConsulta.AppendLine("inner join ProductoUnidad PRU (NOLOCK) on PRU.ProductoClave=PRO.ProductoClave and PRU.PRUTipoUnidad=TPD.TipoUnidad ");
                    }
                    sConsulta.AppendLine("inner join VAVDescripcion VAD (NOLOCK) on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = 'EM' ");
                    sConsulta.AppendLine("inner join VAVDescripcion VAD2 (NOLOCK) on VAD2.VARCodigo = 'TRPFASE' and VAD2.VAVClave = TRP.TipoFase and VAD2.VADTipoLenguaje = 'EM' ");
                    sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on VIS.VisitaClave = TRP.VisitaClave ");
                    sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
                    sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                    sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST VENCEDI (NOLOCK) ON VENCEDI.VENDEDORID=VEN.VENDEDORID AND Vis.FechaHoraInicial  ");
                    sConsulta.AppendLine("BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL ");
                    sConsulta.AppendLine(pvCondicion + " and TRP.Tipo = 1 ");
                    sConsulta.AppendLine(") TMP ");

                    sConsulta.AppendLine("inner join Almacen ALN (NOLOCK) on ALN.AlmacenID = TMP.AlmacenId  ");
                    sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on TMP.RUTClave = RUT.RUTClave ");
                    sConsulta.AppendLine("where ALN.AlmacenID = '" + Cedis + "') TMP ");
                    sConsulta.AppendLine("set nocount off ");

                    QueryString = "";

                    QueryString = sConsulta.ToString();

                    //realizamos la consulta y guardamos el resultado en un modelo
                    List<PedidosAltModel> User = Connection.Query<PedidosAltModel>(QueryString, null, null, true, 600).ToList();
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
                    List<PedidosAltModel> formatlist = new List<PedidosAltModel>();
                    //recorremos cada gurpo de la lista y a continuacion cada elemento del grupo para llenar la formatlist
                    foreach (var grupo in s)
                    {
                        foreach (var objetoAgrupado in grupo)
                        {
                            formatlist.Add(new PedidosAltModel
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
                                Fecha = objetoAgrupado.Fecha,
                                Fase = objetoAgrupado.Fase
                            });
                        }
                        //hacemos la sumatoria de totales de este grupo para sacar el gran total de este bloque
                        formatlist.Last().GranTotal = grupo.Sum(c => c.Total);
                    }
                    //se hace la sumatoria de todos los totales de la lista para calcular el total del cedi
                    double gtotCedi = lista.Sum(item => item.Total);
                    //se cuentan los grupos que se obtuvieron y se obtiene el total de folios
                    int totFolio = s.Count();

                    ReportePedidosPreventaAlt report = new ReportePedidosPreventaAlt();
                    report.DataSource = formatlist;



                    DateTime fInicio = DateTime.Parse(FechaInicial);

                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    report.logo.Image = Image.FromStream(mStream);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    report.empresa.Text = NombreEmpresa;
                    report.reporte.Text = NombreReporte + " Detallado";
                    
                    //ReportHeader
                    report.headerlabelcedis.Text = NombreCedis;
                    report.labelfechaheader.Text = fInicio.Date.ToShortDateString();
                    if (String.IsNullOrEmpty(VendedoresSplit))
                        report.labelrutasheader.Text = RutasSplit;
                    if (String.IsNullOrEmpty(RutasSplit))
                        report.labelvendedorheader.Text = VendedoresSplit;
                    report.labelvendedorheader.DataBindings.Add("Text", report.DataSource, "Vendedor");
                    

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

                    GroupField groupFase = new GroupField("Fase");
                    report.GroupHeader6.GroupFields.Add(groupFase);
                    report.faselabel.DataBindings.Add("Text", report.DataSource, "Fase");

                    GroupField groupFolio = new GroupField("Folio");
                    report.GroupHeader1.GroupFields.Add(groupFolio);
                    report.xrLabel5.DataBindings.Add("Text", report.DataSource, "Folio");
                    report.clienteLabel.DataBindings.Add("Text", report.DataSource, "Cliente");

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
                    report.kgLitros.Visible = pvConversionKg;
                    report.lbKgL.Visible = pvConversionKg;
                    report.kgLitros.DataBindings.Add("Text", null, "KgLts");
                    report.total.DataBindings.Add("Text", null, "GranTotal", "{0:$#,###,##0.00}");
                    

                    //report.gTotal.DataBindings.Add("Text", null, "GranTotal", "{0:$#.00}");
                    int totprodd = lista.Sum(item => item.Cant);
                    report.totFolios.Text = totFolio.ToString();
                    report.totVendido.Text = String.Format("{0:$#,###,##0.00}", gtotCedi);
                    report.gtcedi.Text = String.Format("{0:$#,###,##0.00}", gtotCedi);
                    report.totProducto.Text = totprodd.ToString();

                    report.xrSubreport1.ReportSource = subPedidos;



                    return report;
                    #endregion
                }
                else
                {
                    #region reporte general
                    sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                    sConsulta.AppendLine("set nocount on ");
                    sConsulta.AppendLine("select distinct FechaCaptura as Fecha, VENNombre as Vendedor, RutClave + ' ' + RUTDescripcion as Ruta, ");
                    sConsulta.AppendLine("TMP.TransProdId, Folio, CLIRazonSocial as Cliente, CLIClave as Clave, ALNClave + ' ' + ALNNombre as CEDI, Total, TMP.Descripcion AS Fase ");
                    sConsulta.AppendLine("from (");
                    sConsulta.AppendLine("select TMP.FechaCaptura, TMP.Folio, TMP.TransProdId, TMP.Total, TMP.DiaClave, TMP.CLIRazonSocial, TMP.CLIClave, TMP.VENNombre, ");
                    sConsulta.AppendLine("TMP.VendedorID, TMP.RutClave, TMP.RUTDescripcion, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, TMP.Descripcion ");
                    sConsulta.AppendLine("from (");
                    sConsulta.AppendLine("select TRP.FechaCaptura, TRP.Folio, TRP.TransProdId, TRP.Total, TRP.DiaClave, ");
                    sConsulta.AppendLine("CLI.RazonSocial +' '+cli.nombrecontacto as CLIRazonSocial, CLI.Clave as CLIClave, ");
                    sConsulta.AppendLine("VEN.Nombre as VENNombre, VEN.VendedorID, RUT.RutClave, RUT.Descripcion as RUTDescripcion, VENCEDI.AlmacenId, VAD.Descripcion ");
                    sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = TRP.DiaClave ");
                    sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on VIS.VisitaClave = TRP.VisitaClave ");
                    sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
                    sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                    sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave = RUT.RUTClave ");
                    sConsulta.AppendLine("inner join VAVDescripcion VAD (NOLOCK) on VAD.VARCodigo = 'TRPFASE' and VAD.VAVClave = TRP.TipoFase and VAD.VADTipoLenguaje = 'EM' ");
                    sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST VENCEDI (NOLOCK) ON VENCEDI.VENDEDORID=VEN.VENDEDORID AND Vis.FechaHoraInicial  ");
                    sConsulta.AppendLine("BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL ");
                    sConsulta.AppendLine(pvCondicion + " and TRP.Tipo = 1 ");
                    sConsulta.AppendLine(") TMP ");
                    sConsulta.AppendLine("inner join Almacen ALN (NOLOCK) on ALN.AlmacenID = TMP.AlmacenId ");
                    sConsulta.AppendLine("where ALN.AlmacenID = '" + Cedis + "') TMP ");
                    sConsulta.AppendLine("set nocount off ");


                    QueryString = "";

                    QueryString = sConsulta.ToString();


                    List<PedidosGeneralAltModel> User = Connection.Query<PedidosGeneralAltModel>(QueryString, null, null, true, 600).ToList();

                    if (User.Count() <= 0)
                    {
                        return null;
                    }
                    //var lista = (from c in User

                    //             select c).ToList();

                    var lista = (from c in User
                                 select c).ToList();

                    var sd = lista.GroupBy(l => new { l.Fecha, l.Ruta })
                        .SelectMany(cl => cl.Select(cs => new PedidosGeneralAltModel
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
                            Fase = cs.Fase,
                            GranTotal = cl.Sum(c => c.Total)//cl.Sum(c => c.Total).ToString(),
                        })).ToList();

                    double gtotCedi = lista.Sum(item => item.Total);
                    int totFolio = lista.Count();


                    ReportePedidoGeneralAlt reportG = new ReportePedidoGeneralAlt();
                    //reportG.DataSource = lista;
                    reportG.DataSource = sd;

                    DateTime fInicio = DateTime.Parse(FechaInicial);

                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    reportG.logo.Image = Image.FromStream(mStream);
                    reportG.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    reportG.empresa.Text = NombreEmpresa;
                    reportG.reporte.Text = NombreReporte + " General";


                    //ReportHeader
                    reportG.headerlabelcedis.Text = NombreCedis;
                    reportG.labelfechaheader.Text = fInicio.Date.ToShortDateString();
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

                    GroupField groupFase = new GroupField("Fase");
                    reportG.GroupHeader5.GroupFields.Add(groupFase);
                    reportG.faselabel.DataBindings.Add("Text", reportG.DataSource, "Fase");

                    reportG.l1.DataBindings.Add("Text", null, "Folio");
                    reportG.l2.DataBindings.Add("Text", null, "Clave");
                    reportG.l3.DataBindings.Add("Text", null, "Cliente");
                    reportG.l4.DataBindings.Add("Text", null, "Total", "{0:$#,###,##0.00}");

                    reportG.gTotal.DataBindings.Add("Text", null, "GranTotal", "{0:$#,###,##0.00}");
                    reportG.totFolios.Text = totFolio.ToString();
                    reportG.totVendido.Text = String.Format("{0:$#,###,##0.00}", gtotCedi);
                    reportG.gtcedi.Text = String.Format("{0:$#,###,##0.00}", gtotCedi);
                    reportG.gTotalCentro.DataBindings.Add("Text", null, "GranTotal", "{0:$#,###,##0.00}");

                    reportG.xrSubreport1.ReportSource = subPedidos;


                    return reportG;
                    #endregion
                }
            }
            catch (Exception ex)
            {

                return new ReportePedidosPreventaAlt();
            }
        }


        public string GetProducts(string pvCondicion, bool pvConversionKg, string Cedis)
        {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            sConsulta.AppendLine("set nocount on ");
            sConsulta.AppendLine("select CEDI, Clave, Producto, Unidad, ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("sum(KgLts) as KgLts, ");
            }
            sConsulta.AppendLine("sum(Cantidad) as Cantidad, sum(Total) as Total ");
            sConsulta.AppendLine("from(	select ClienteClave, (ALNClave + ' ' + ALNNombre) as CEDI, ProductoClave as Clave, ");
            sConsulta.AppendLine("PRONombre as Producto, Unidad, ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("KgLts, ");
            }
            sConsulta.AppendLine("Cantidad, TPDTotal as Total ");
            sConsulta.AppendLine("from (");
            sConsulta.AppendLine("select TMP.ProductoClave, TMP.Cantidad, ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("TMP.KgLts, ");
            }
            sConsulta.AppendLine("(SubTotal - DescuentoCliente -((SubTotal - DescuentoCliente) * DescVendPor / 100)) + (Impuesto - DescuentoClienteImpuesto -((Impuesto - DescuentoClienteImpuesto) * DescVendPor / 100)) as TPDtotal, ");
            sConsulta.AppendLine("TMP.Impuesto, TMP.DescVendPor, TMP.DiaClave, TMP.ClienteClave, TMP.PRONombre, TMP.Unidad, ");
            sConsulta.AppendLine("TMP.VendedorId, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ");
            sConsulta.AppendLine("from (");
            sConsulta.AppendLine("select TPD.ProductoClave, TPD.Cantidad, TPD.Impuesto, TRP.DescVendPor, TPD.SubTotal, ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("PRU.KgLts * TPD.Cantidad as KgLts, ");
            }
            sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ");
            sConsulta.AppendLine("(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes AS TDD (NOLOCK) WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoClienteImpuesto, ");
            sConsulta.AppendLine("TRP.DiaClave, TRP.ClienteClave, PRO.Nombre as PRONombre, VAD.Descripcion as Unidad, VEN.VendedorId, RUT.RUTClave, VENCEDI.AlmacenId ");
            sConsulta.AppendLine("from TransProdDetalle TPD (NOLOCK) ");
            sConsulta.AppendLine("inner join TransProd TRP (NOLOCK) on TRP.TransProdId = TPD.TransProdId ");
            sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = TRP.DiaClave ");
            sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave ");
            if (pvConversionKg)
            {
                sConsulta.AppendLine("inner join ProductoUnidad PRU (NOLOCK) on PRU.ProductoClave=PRO.ProductoClave and PRU.PRUTipoUnidad=TPD.TipoUnidad ");
            }
            sConsulta.AppendLine("inner join VAVDescripcion VAD (NOLOCK) on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = 'EM' ");
            sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on VIS.VisitaClave = TRP.VisitaClave ");
            sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
            sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
            sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave = RUT.RUTClave  ");
            sConsulta.AppendLine("INNER JOIN VENCENTRODISTHIST VENCEDI (NOLOCK) ON VENCEDI.VENDEDORID=VEN.VENDEDORID AND Vis.FechaHoraInicial  ");
            sConsulta.AppendLine("BETWEEN VENCEDI.VCHFECHAINICIAL AND VENCEDI.FECHAFINAL ");
            sConsulta.AppendLine(pvCondicion + " and TRP.Tipo = 1 ");
            sConsulta.AppendLine(") TMP ");
            sConsulta.AppendLine("inner join Almacen ALN (NOLOCK) on ALN.AlmacenID = TMP.AlmacenID");
            sConsulta.AppendLine("where ALN.AlmacenID = '" + Cedis + "') TMP ");
            sConsulta.AppendLine(") as t1 group by CEDI, Clave, Producto, Unidad ");
            sConsulta.AppendLine("set nocount off ");
            string res = sConsulta.ToString();
            return res;
        }
    }

    //class GranTotal
    //{
    //    public double GranTotal { get; set; }
    //}


    class PedidosAltModel
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
        public string Fase { get; set; }
    }

    class PedidosGeneralAltModel
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
        public string Fase { get; set; }
    }

    class ProductosPedidosAltModel
    {
        public string CEDI { get; set; }
        public string Clave { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public double KgLts { get; set; }
        public string GranTotal { get; set; }
        public string TotalProductos { get; set; }
    }
}