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
    public class VentaDetalladaMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string ClientesSplit, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis)
        {
            try
            {
                String sCondicionALN = "where ALN.AlmacenID = '" + Cedis + "' ";

                StringBuilder sConsulta = new StringBuilder();

                bool pvConversionKg = Connection.Query<int>("Select top 1 ConversionKg From ConHist (NOLOCK) Order By MFechaHora Desc", null, null, true, 600).FirstOrDefault() == 1;


                //Ventas
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("set nocount on ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select FechaCaptura as Fecha, VENNombre as Vendedor, RUTClave + ' ' + RUTDescripcion as Ruta, ");
                sConsulta.AppendLine("	TMP.TransProdID,Folio, RazonSocial as Cliente, ProductoClave as Clave, PRONombre as Producto, Unidad, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("  TMP.KgLts, ");
                sConsulta.AppendLine("	Precio as PrecioU, ALNClave + ' ' + ALNNombre as CEDI, Cantidad as Cant, TPDSubtotal as SubTotal, DescuentoImp as DescProducto, ");
                sConsulta.AppendLine("	DescuentoCliente, ((TPDSubTotal - DescuentoCliente-DescuentoImp ) * DescVendPor / 100) as DescVend, ");
                sConsulta.AppendLine("	IVA - (IVA * DescVendPor / 100)  as IVA, ");
                sConsulta.AppendLine("	IEPS - (IEPS * DescVendPor / 100)  as IEPS, ");
                sConsulta.AppendLine("	((TPDSubTotal - DescuentoImp - DescuentoCliente) - ((TPDSubTotal - DescuentoCliente - DescuentoImp ) * DescVendPor / 100) + ((IVA+IEPS) - ((IVA+IEPS) * DescVendPor / 100))) as Total ");
                sConsulta.AppendLine("from (");
                sConsulta.AppendLine("	select TMP.DiaClave, TMP.FechaCaptura, TMP.TransProdID,TMP.Folio, TMP.DescVendPor, ");
                sConsulta.AppendLine("	    TMP.TRPSubtotal, TMP.ClienteClave, TMP.RazonSocial, TMP.ProductoClave, TMP.Precio, ");
                sConsulta.AppendLine("	    TMP.Cantidad, TMP.DescuentoCliente, TMP.DescuentoImp, TMP.TPDSubtotal, TMP.IVA, TMP.IEPS, TMP.TipoUnidad, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("          TMP.KgLts, ");
                sConsulta.AppendLine("	    TMP.PRONombre, TMP.Unidad, TMP.RutClave, TMP.VendedorId, TMP.VENNombre, ");
                sConsulta.AppendLine("	    ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, RUT.Descripcion as RUTDescripcion ");
                sConsulta.AppendLine("	from (");
                sConsulta.AppendLine("		select case when trp.DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end as DiaClave, ");
                sConsulta.AppendLine("			Dia.FechaCaptura, TRP.TransProdID, TRP.Folio, TRP.DescVendPor, TRP.Subtotal as TRPSubtotal, TRP.ClienteClave, ");
                sConsulta.AppendLine("			CLI.RazonSocial+' '+cli.nombrecontacto as razonsocial, TPD.ProductoClave, TPD.Precio, TPD.Cantidad, TPD.DescuentoImp, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("          PRU.KgLts * TPD.Cantidad as KgLts, ");
                sConsulta.AppendLine("			(TPD.Precio * TPD.Cantidad) as TPDSubTotal, ");
                sConsulta.AppendLine("			(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes (NOLOCK) AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, 		");
                sConsulta.AppendLine("			((select isnull(sum(TPI.ImpuestoImp),0) from TPDImpuesto TPI (NOLOCK) ");
                sConsulta.AppendLine("			inner join Impuesto IMP (NOLOCK) on TPI.ImpuestoClave=IMP.ImpuestoClave");
                sConsulta.AppendLine("			where TPI.TransProdID=TRP.TransprodId and TPI.TransProdDetalleID=TPD.TransprodDetalleId and IMP.Abreviatura='IVA')");
                sConsulta.AppendLine("			- ");
                sConsulta.AppendLine("			(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes (NOLOCK) AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as IVA,");
                sConsulta.AppendLine("			((select isnull(sum(TPI.ImpuestoImp),0) from TPDImpuesto TPI (NOLOCK) ");
                sConsulta.AppendLine("			inner join Impuesto IMP (NOLOCK) on TPI.ImpuestoClave=IMP.ImpuestoClave");
                sConsulta.AppendLine("			where TPI.TransProdID=TRP.TransprodId and TPI.TransProdDetalleID=TPD.TransprodDetalleId and IMP.Abreviatura='IEPS')");
                sConsulta.AppendLine("			- ");
                sConsulta.AppendLine("			(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes (NOLOCK) AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as IEPS,");
                sConsulta.AppendLine("			TPD.TipoUnidad, PRO.Nombre as PRONombre, ");
                sConsulta.AppendLine("			VAD.Descripcion as Unidad, VIS.RutClave, VEN.VendedorId, VEN.Nombre as VENNombre ");
                sConsulta.AppendLine("		from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("		inner join Dia (NOLOCK) on Dia.DiaClave=case when trp.DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end ");
                sConsulta.AppendLine("		inner join Cliente CLI (NOLOCK) on CLI.ClienteClave=TRP.ClienteClave ");
                sConsulta.AppendLine("		inner join TransProdDetalle TPD (NOLOCK) on TPD.TransProdId=TRP.TransProdId ");
                sConsulta.AppendLine("		inner join Producto PRO (NOLOCK) on TPD.ProductoClave=PRO.ProductoClave ");
                if (pvConversionKg)
                    sConsulta.AppendLine("        inner join ProductoUnidad PRU (NOLOCK) on PRU.ProductoClave=PRO.ProductoClave and PRU.PRUTipoUnidad=TPD.TipoUnidad ");
                sConsulta.AppendLine("		inner join VAVDescripcion VAD (NOLOCK) on VAD.VARCodigo='UNIDADV' and VAD.VAVClave=TPD.TipoUnidad and VAD.VADTipoLenguaje='EM' ");//lenguaje
                sConsulta.AppendLine("		inner join Visita VIS (NOLOCK) on VIS.VisitaClave=case when trp.VisitaClave1 is null then TRP.VisitaClave  else TRP.VisitaClave1 end ");
                sConsulta.AppendLine("		inner join Vendedor VEN (NOLOCK) on VIS.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine(pvCondicion + " and TRP.Tipo = 1 and TRP.TipoFase in (2,3) and VIS.RUTClave <>'RUT001' ");
                sConsulta.AppendLine("	) TMP ");
                sConsulta.AppendLine("	inner join (select distinct DiaClave, VendedorId, ClaveCEDI, RUTClave from AgendaVendedor (NOLOCK) ) AGV on TMP.DiaClave=AGV.DiaClave and TMP.VendedorId=AGV.VendedorId and AGV.RUTClave=TMP.RUTClave ");
                sConsulta.AppendLine("	inner join Almacen ALN (NOLOCK) on AGV.ClaveCEDI=ALN.Clave ");
                sConsulta.AppendLine("	inner join Ruta RUT (NOLOCK) on TMP.RUTClave=RUT.RUTClave ");
                sConsulta.AppendLine(sCondicionALN);
                sConsulta.AppendLine(") TMP ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("set nocount off ");

                QueryString = "";

                QueryString = sConsulta.ToString();


                List<VentasModel> Ventas = Connection.Query<VentasModel>(QueryString, null, null, true, 600).ToList();

                if (Ventas.Count() <= 0)
                {
                    return null;
                }

                //Venta por Producto por Precio
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("set nocount on ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select ProductoClave as Clave, PRONombre as Producto, Unidad, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("  sum(TMP.KgLts) as KgLts, ");
                sConsulta.AppendLine("	Precio as PrecioU, sum(Cantidad) as Cant, sum(TPDSubtotal) as SubTotal, sum(DescuentoImp) as DescProducto, ");
                sConsulta.AppendLine("	sum(DescuentoCliente) as DescuentoCliente, sum((TPDSubTotal - DescuentoCliente-DescuentoImp ) * DescVendPor / 100) as DescVend, ");
                sConsulta.AppendLine("	sum(IVA - (IVA * DescVendPor / 100))  as IVA, ");
                sConsulta.AppendLine("	sum(IEPS - (IEPS * DescVendPor / 100))  as IEPS, ");
                sConsulta.AppendLine("	sum((TPDSubTotal - DescuentoImp - DescuentoCliente) - ((TPDSubTotal - DescuentoCliente - DescuentoImp ) * DescVendPor / 100) + ((IVA+IEPS) - ((IVA+IEPS) * DescVendPor / 100))) as Total ");
                sConsulta.AppendLine("from (");
                sConsulta.AppendLine("	select TMP.DiaClave, TMP.DescVendPor, ");
                sConsulta.AppendLine("	    TMP.TRPSubtotal, TMP.ProductoClave, TMP.Precio, ");
                sConsulta.AppendLine("	    TMP.Cantidad, TMP.DescuentoCliente, TMP.DescuentoImp, TMP.TPDSubtotal, TMP.IVA, TMP.IEPS, TMP.TipoUnidad, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("          TMP.KgLts, ");
                sConsulta.AppendLine("	    TMP.PRONombre, TMP.Unidad, TMP.RutClave, TMP.VendedorId, TMP.VENNombre, ");
                sConsulta.AppendLine("	    ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, RUT.Descripcion as RUTDescripcion ");
                sConsulta.AppendLine("	from (");
                sConsulta.AppendLine("		select case when trp.DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end as DiaClave, ");
                sConsulta.AppendLine("			TRP.DescVendPor, TRP.Subtotal as TRPSubtotal, ");
                sConsulta.AppendLine("			TPD.ProductoClave, TPD.Precio, TPD.Cantidad, TPD.DescuentoImp, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("          PRU.KgLts * TPD.Cantidad as KgLts, ");
                sConsulta.AppendLine("			(TPD.Precio * TPD.Cantidad) as TPDSubTotal, ");
                sConsulta.AppendLine("			(SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes (NOLOCK) AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, 		");
                sConsulta.AppendLine("			((select isnull(sum(TPI.ImpuestoImp),0) from TPDImpuesto TPI (NOLOCK) ");
                sConsulta.AppendLine("			inner join Impuesto IMP (NOLOCK) on TPI.ImpuestoClave=IMP.ImpuestoClave");
                sConsulta.AppendLine("			where TPI.TransProdID=TRP.TransprodId and TPI.TransProdDetalleID=TPD.TransprodDetalleId and IMP.Abreviatura='IVA')");
                sConsulta.AppendLine("			- ");
                sConsulta.AppendLine("			(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes (NOLOCK) AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as IVA,");
                sConsulta.AppendLine("			((select isnull(sum(TPI.ImpuestoImp),0) from TPDImpuesto TPI (NOLOCK) ");
                sConsulta.AppendLine("			inner join Impuesto IMP (NOLOCK) on TPI.ImpuestoClave=IMP.ImpuestoClave");
                sConsulta.AppendLine("			where TPI.TransProdID=TRP.TransprodId and TPI.TransProdDetalleID=TPD.TransprodDetalleId and IMP.Abreviatura='IEPS')");
                sConsulta.AppendLine("			- ");
                sConsulta.AppendLine("			(SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes (NOLOCK) AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId)) as IEPS,");
                sConsulta.AppendLine("			TPD.TipoUnidad, PRO.Nombre as PRONombre, ");
                sConsulta.AppendLine("			VAD.Descripcion as Unidad, VIS.RutClave, VEN.VendedorId, VEN.Nombre as VENNombre ");
                sConsulta.AppendLine("		from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("		inner join Dia (NOLOCK) on Dia.DiaClave=case when trp.DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end ");
                sConsulta.AppendLine("		inner join Cliente CLI (NOLOCK) on CLI.ClienteClave=TRP.ClienteClave ");
                sConsulta.AppendLine("		inner join TransProdDetalle TPD (NOLOCK) on TPD.TransProdId=TRP.TransProdId ");
                sConsulta.AppendLine("		inner join Producto PRO (NOLOCK) on TPD.ProductoClave=PRO.ProductoClave ");
                if (pvConversionKg)
                    sConsulta.AppendLine("        inner join ProductoUnidad PRU (NOLOCK) on PRU.ProductoClave=PRO.ProductoClave and PRU.PRUTipoUnidad=TPD.TipoUnidad ");
                sConsulta.AppendLine("		inner join VAVDescripcion VAD (NOLOCK) on VAD.VARCodigo='UNIDADV' and VAD.VAVClave=TPD.TipoUnidad and VAD.VADTipoLenguaje='EM' ");//languaje
                sConsulta.AppendLine("		inner join Visita VIS (NOLOCK) on VIS.VisitaClave=case when trp.VisitaClave1 is null then TRP.VisitaClave  else TRP.VisitaClave1 end ");
                sConsulta.AppendLine("		inner join Vendedor VEN (NOLOCK) on VIS.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine(pvCondicion + " and TRP.Tipo = 1 and TRP.TipoFase in (2,3) and VIS.RUTClave <>'RUT001' ");
                sConsulta.AppendLine("	) TMP ");
                sConsulta.AppendLine("	inner join (select distinct DiaClave, VendedorId, ClaveCEDI, RUTClave from AgendaVendedor (NOLOCK) ) AGV on TMP.DiaClave=AGV.DiaClave and TMP.VendedorId=AGV.VendedorId and AGV.RUTClave=TMP.RUTClave ");
                sConsulta.AppendLine("	inner join Almacen ALN (NOLOCK) on AGV.ClaveCEDI=ALN.Clave ");
                sConsulta.AppendLine("	inner join Ruta RUT (NOLOCK) on TMP.RUTClave=RUT.RUTClave ");
                sConsulta.AppendLine(sCondicionALN);
                sConsulta.AppendLine(") TMP ");
                sConsulta.AppendLine("group by ProductoClave, PRONombre, Unidad, Precio");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("set nocount off ");

                QueryString = "";

                QueryString = sConsulta.ToString();


                List<VentasProductoPorPrecioModel> VentasProductoPorPrecio = Connection.Query<VentasProductoPorPrecioModel>(QueryString, null, null, true, 600).ToList();

                //Ventas por Producto
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("set nocount on ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select CEDI, Clave, Producto, Unidad, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("  sum(KgLts) as KgLts, ");
                sConsulta.AppendLine("  sum(Cantidad) as Cantidad, sum(Total) as Total ");
                sConsulta.AppendLine("from(	");
                sConsulta.AppendLine("  select ClienteClave, (ALNClave + ' ' + ALNNombre) as CEDI, ProductoClave as Clave, ");
                sConsulta.AppendLine("  PRONombre as Producto, Unidad, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("  KgLts, ");
                sConsulta.AppendLine("  Cantidad, TPDTotal as Total ");
                sConsulta.AppendLine("  from (");
                sConsulta.AppendLine("      select TMP.ProductoClave, TMP.Cantidad, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("      TMP.KgLts, ");
                sConsulta.AppendLine("      (SubTotal - DescuentoCliente -((SubTotal - DescuentoCliente) * DescVendPor / 100)) + (Impuesto - DescuentoClienteImpuesto -((Impuesto - DescuentoClienteImpuesto) * DescVendPor / 100)) as TPDtotal, ");
                sConsulta.AppendLine("      TMP.Impuesto, TMP.DescVendPor, TMP.DiaClave, TMP.ClienteClave, TMP.PRONombre, TMP.Unidad, ");
                sConsulta.AppendLine("      TMP.VendedorId, ALN.Clave as ALNClave, ALN.Nombre as ALNNombre ");
                sConsulta.AppendLine("      from (");
                sConsulta.AppendLine("          select TPD.ProductoClave, TPD.Cantidad, TPD.Impuesto, TRP.DescVendPor, TPD.SubTotal, ");
                if (pvConversionKg)
                    sConsulta.AppendLine("          PRU.KgLts * TPD.Cantidad as KgLts, ");
                sConsulta.AppendLine("          (SELECT (CASE WHEN sum(DesImporte) IS NULL THEN 0 ELSE sum(DesImporte) END) FROM TpdDes (NOLOCK) AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoCliente, ");
                sConsulta.AppendLine("          (SELECT (CASE WHEN sum(DesImpuesto) IS NULL THEN 0 ELSE sum(DesImpuesto) END) FROM TpdDes (NOLOCK) AS TDD WHERE TDD.TransProdId=TRP.TransProdId AND TDD.TransProdDetalleId=TPD.TransProdDetalleId) as DescuentoClienteImpuesto, ");
                sConsulta.AppendLine("          case when trp.DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end as DiaClave, TRP.ClienteClave, PRO.Nombre as PRONombre, VAD.Descripcion as Unidad, VEN.VendedorId, RUT.RUTClave ");
                sConsulta.AppendLine("          from TransProdDetalle TPD (NOLOCK) ");
                sConsulta.AppendLine("          inner join TransProd TRP (NOLOCK) on TRP.TransProdId = TPD.TransProdId ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on Dia.DiaClave = case when trp.DiaClave1 is null then TRP.DiaClave else TRP.DiaClave1 end ");
                sConsulta.AppendLine("          inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave ");
                if (pvConversionKg)
                    sConsulta.AppendLine("          inner join ProductoUnidad PRU (NOLOCK) on PRU.ProductoClave=PRO.ProductoClave and PRU.PRUTipoUnidad=TPD.TipoUnidad ");
                sConsulta.AppendLine("          inner join VAVDescripcion VAD (NOLOCK) on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = 'EM' ");//languaje
                sConsulta.AppendLine("          inner join Visita VIS (NOLOCK) on VIS.VisitaClave = case when trp.DiaClave1 is null then TRP.VisitaClave  else TRP.VisitaClave1 end ");
                sConsulta.AppendLine("          inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = TRP.ClienteClave ");
                sConsulta.AppendLine("          inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("          inner join Ruta RUT (NOLOCK) on VIS.RUTClave = RUT.RUTClave  ");
                sConsulta.AppendLine(pvCondicion + " and TRP.Tipo = 1 and TRP.TipoFase in (2,3) and RUT.RUTClave <>'RUT001' ");
                sConsulta.AppendLine("      ) TMP ");
                sConsulta.AppendLine("      inner join (select distinct DiaClave, VendedorId, ClaveCEDI, RUTClave from AgendaVendedor (NOLOCK) ) AGV on TMP.DiaClave = AGV.DiaClave and TMP.VendedorId = AGV.VendedorId and AGV.RUTClave = TMP.RUTClave ");
                sConsulta.AppendLine("      inner join Almacen ALN (NOLOCK) on AGV.ClaveCEDI = ALN.Clave ");
                sConsulta.AppendLine(sCondicionALN);
                sConsulta.AppendLine("  ) TMP ");
                sConsulta.AppendLine(") as t1 ");
                sConsulta.AppendLine("group by CEDI, Clave, Producto, Unidad ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("set nocount off ");

                QueryString = "";

                QueryString = sConsulta.ToString();


                List<VentasProductoModel> VentasProducto = Connection.Query<VentasProductoModel>(QueryString, null, null, true, 600).ToList();

                //if (pvConversionKg)
                //{

                //}

                var cedisList = (from gr in Ventas group gr by new { gr.CEDI } into grupo select grupo);
                List<VentasModel> formatlistVentasKg = new List<VentasModel>();

                foreach (var gCedi in cedisList)
                {
                    var vendedorList = (from gr in gCedi group gr by new { gr.Vendedor } into grupo orderby grupo.FirstOrDefault().Vendedor select grupo);

                    foreach (var gVendedor in vendedorList)
                    {
                        var clienteList = (from gr in gVendedor group gr by new { gr.Folio } into grupo select grupo);

                        foreach (var gCliente in clienteList)
                        {
                            foreach (var objetoAgrupado in gCliente)
                            {
                                formatlistVentasKg.Add(new VentasModel
                                {
                                    Fecha = objetoAgrupado.Fecha,
                                    Vendedor = objetoAgrupado.Vendedor,
                                    Ruta = objetoAgrupado.Ruta,
                                    TransProdID = objetoAgrupado.TransProdID,
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
                                    IVA = objetoAgrupado.IVA,
                                    IEPS = objetoAgrupado.IEPS,
                                    Total = objetoAgrupado.Total
                                });
                            }
                            //sumamos total del cliente
                            formatlistVentasKg.Last().CantCliente = gCliente.Sum(c => c.Cant);
                            formatlistVentasKg.Last().KgLtsCliente = gCliente.Sum(c => c.KgLts);
                            formatlistVentasKg.Last().SubTotalCliente = gCliente.Sum(c => c.SubTotal);
                            formatlistVentasKg.Last().DescProductoCliente = gCliente.Sum(c => c.DescProducto);
                            formatlistVentasKg.Last().DescuentoClienteCliente = gCliente.Sum(c => c.DescuentoCliente);
                            formatlistVentasKg.Last().DescVendCliente = gCliente.Sum(c => c.DescVend);
                            formatlistVentasKg.Last().IVACliente = gCliente.Sum(c => c.IVA);
                            formatlistVentasKg.Last().IEPSCliente = gCliente.Sum(c => c.IEPS);
                            formatlistVentasKg.Last().TotalCliente = gCliente.Sum(c => c.Total);

                            //sumamos total del vendedor
                            formatlistVentasKg.Last().CantVendedor = gVendedor.Sum(c => c.Cant);
                            formatlistVentasKg.Last().KgLtsVendedor = gVendedor.Sum(c => c.KgLts);
                            formatlistVentasKg.Last().SubTotalVendedor = gVendedor.Sum(c => c.SubTotal);
                            formatlistVentasKg.Last().DescProductoVendedor = gVendedor.Sum(c => c.DescProducto);
                            formatlistVentasKg.Last().DescuentoClienteVendedor = gVendedor.Sum(c => c.DescuentoCliente);
                            formatlistVentasKg.Last().DescVendVendedor = gVendedor.Sum(c => c.DescVend);
                            formatlistVentasKg.Last().IVAVendedor = gVendedor.Sum(c => c.IVA);
                            formatlistVentasKg.Last().IEPSVendedor = gVendedor.Sum(c => c.IEPS);
                            formatlistVentasKg.Last().TotalVendedor = gVendedor.Sum(c => c.Total);

                            //sumamos total del CEDI
                            formatlistVentasKg.Last().CantCedi = gCedi.Sum(c => c.Cant);
                            formatlistVentasKg.Last().KgLtsCedi = gCedi.Sum(c => c.KgLts);
                            formatlistVentasKg.Last().SubTotalCedi = gCedi.Sum(c => c.SubTotal);
                            formatlistVentasKg.Last().DescProductoCedi = gCedi.Sum(c => c.DescProducto);
                            formatlistVentasKg.Last().DescuentoClienteCedi = gCedi.Sum(c => c.DescuentoCliente);
                            formatlistVentasKg.Last().DescVendCedi = gCedi.Sum(c => c.DescVend);
                            formatlistVentasKg.Last().IVACedi = gCedi.Sum(c => c.IVA);
                            formatlistVentasKg.Last().IEPSCedi = gCedi.Sum(c => c.IEPS);
                            formatlistVentasKg.Last().TotalCedi = gCedi.Sum(c => c.Total);
                        }
                        
                    }
                    
                }


                //DateTime fInicio = DateTime.Parse(FechaInicial);

                //if (String.IsNullOrEmpty(ClientesSplit) || ClientesSplit.Equals("null"))
                //{
                //    ClientesSplit = String.Empty;
                //}

                VentaDetalladaKgMOR report = new VentaDetalladaKgMOR();

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
                report.headerLabelCedis.Text = nombreCedis;
                report.headerLabelFecha.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.headerLabelVendedor.Text = "";
                report.headerLabelRuta.Text = RutasSplit;

                VentasKg ventasKg = new VentasKg();
                ventasKg.DataSource = formatlistVentasKg;

                //grouheader5
                GroupField groupCedi = new GroupField("CEDI");
                ventasKg.GroupHeader5.GroupFields.Add(groupCedi);
                //dejo pendiente agregar mas bindings a este header ya que en su reporteador no aparece nada


                //grouheader4
                GroupField groupVendedor = new GroupField("Vendedor");
                ventasKg.GroupHeader4.GroupFields.Add(groupVendedor);
                //dejo pendiente agregar mas bindings a este header ya que en su reporteador no aparece nada

                ////grouheader3
                //GroupField groupFecha = new GroupField("Fecha");
                //subreport1.GroupHeader3.GroupFields.Add(groupFecha);

                ////grouheader2
                //GroupField groupRuta = new GroupField("Ruta");
                //subreport1.GroupHeader2.GroupFields.Add(groupRuta);

                //groupheader1
                GroupField groupCliente = new GroupField("Folio");
                ventasKg.GroupHeader1.GroupFields.Add(groupCliente);
                ventasKg.labelFolioCliente.DataBindings.Add("Text", ventasKg.DataSource, "Folio");
                ventasKg.labelClienteCliente.DataBindings.Add("Text", ventasKg.DataSource, "Cliente");

                //Datos del detail
                ventasKg.labelClave.DataBindings.Add("Text", ventasKg.DataSource, "Clave");
                ventasKg.labelProducto.DataBindings.Add("Text", ventasKg.DataSource, "Producto");
                ventasKg.labelUnidad.DataBindings.Add("Text", ventasKg.DataSource, "Unidad");
                ventasKg.labelPrecioU.DataBindings.Add("Text", ventasKg.DataSource, "PrecioU", "{0:$#,##0.00}");
                ventasKg.labelCantidad.DataBindings.Add("Text", ventasKg.DataSource, "Cant", "{0:#,##0}");
                ventasKg.labelKgLts.DataBindings.Add("Text", ventasKg.DataSource, "KgLts", "{0:#,##0.00}");
                ventasKg.labelSubtotal.DataBindings.Add("Text", ventasKg.DataSource, "SubTotal", "{0:$#,##0.00}");
                ventasKg.labelDescProducto.DataBindings.Add("Text", ventasKg.DataSource, "DescProducto", "{0:$#,##0.00}");
                ventasKg.labelDescCliente.DataBindings.Add("Text", ventasKg.DataSource, "DescuentoCliente", "{0:$#,##0.00}");
                ventasKg.labelDescVendedor.DataBindings.Add("Text", ventasKg.DataSource, "DescVend", "{0:$#,##0.00}");
                ventasKg.labelIVA.DataBindings.Add("Text", ventasKg.DataSource, "IVA", "{0:$#,##0.00}");
                ventasKg.labelIEPS.DataBindings.Add("Text", ventasKg.DataSource, "IEPS", "{0:$#,##0.00}");
                ventasKg.labelTotal.DataBindings.Add("Text", ventasKg.DataSource, "Total", "{0:$#,##0.00}");

                //Datos del groupfooter1
                ventasKg.labelClienteCantidad.DataBindings.Add("Text", ventasKg.DataSource, "CantCliente", "{0:#,##0}");
                ventasKg.labelClienteKgLts.DataBindings.Add("Text", ventasKg.DataSource, "KgLtsCliente", "{0:#,##0.00}");
                ventasKg.labelClienteSubtotal.DataBindings.Add("Text", ventasKg.DataSource, "SubTotalCliente", "{0:$#,##0.00}");
                ventasKg.labelClienteDescProducto.DataBindings.Add("Text", ventasKg.DataSource, "DescProductoCliente", "{0:$#,##0.00}");
                ventasKg.labelClienteDescCliente.DataBindings.Add("Text", ventasKg.DataSource, "DescuentoClienteCliente", "{0:$#,##0.00}");
                ventasKg.labelClienteDescVendedor.DataBindings.Add("Text", ventasKg.DataSource, "DescVendCliente", "{0:$#,##0.00}");
                ventasKg.labelClienteIVA.DataBindings.Add("Text", ventasKg.DataSource, "IVACliente", "{0:$#,##0.00}");
                ventasKg.labelClienteIEPS.DataBindings.Add("Text", ventasKg.DataSource, "IEPSCliente", "{0:$#,##0.00}");
                ventasKg.labelClienteTotal.DataBindings.Add("Text", ventasKg.DataSource, "TotalCliente", "{0:$#,##0.00}");

                //Datos del groupfooter4 (Vendedor)
                ventasKg.labelVendedorCantidad.DataBindings.Add("Text", ventasKg.DataSource, "CantVendedor", "{0:#,##0}");
                ventasKg.labelVendedorKgLts.DataBindings.Add("Text", ventasKg.DataSource, "KgLtsVendedor", "{0:#,##0.00}");
                ventasKg.labelVendedorSubtotal.DataBindings.Add("Text", ventasKg.DataSource, "SubTotalVendedor", "{0:$#,##0.00}");
                ventasKg.labelVendedorDescProducto.DataBindings.Add("Text", ventasKg.DataSource, "DescProductoVendedor", "{0:$#,##0.00}");
                ventasKg.labelVendedorDescCliente.DataBindings.Add("Text", ventasKg.DataSource, "DescuentoClienteVendedor", "{0:$#,##0.00}");
                ventasKg.labelVendedorDescVendedor.DataBindings.Add("Text", ventasKg.DataSource, "DescVendVendedor", "{0:$#,##0.00}");
                ventasKg.labelVendedorIVA.DataBindings.Add("Text", ventasKg.DataSource, "IVAVendedor", "{0:$#,##0.00}");
                ventasKg.labelVendedorIEPS.DataBindings.Add("Text", ventasKg.DataSource, "IEPSVendedor", "{0:$#,##0.00}");
                ventasKg.labelVendedorTotal.DataBindings.Add("Text", ventasKg.DataSource, "TotalVendedor", "{0:$#,##0.00}");

                //Datos del groupfooter5 (Cedi)
                ventasKg.labelCediCantidad.DataBindings.Add("Text", ventasKg.DataSource, "CantCedi", "{0:#,##0}");
                ventasKg.labelCediKgLts.DataBindings.Add("Text", ventasKg.DataSource, "KgLtsCedi", "{0:#,##0.00}");
                ventasKg.labelCediSubtotal.DataBindings.Add("Text", ventasKg.DataSource, "SubTotalCedi", "{0:$#,##0.00}");
                ventasKg.labelCediDescProducto.DataBindings.Add("Text", ventasKg.DataSource, "DescProductoCedi", "{0:$#,##0.00}");
                ventasKg.labelCediDescCliente.DataBindings.Add("Text", ventasKg.DataSource, "DescuentoClienteCedi", "{0:$#,##0.00}");
                ventasKg.labelCediDescVendedor.DataBindings.Add("Text", ventasKg.DataSource, "DescVendCedi", "{0:$#,##0.00}");
                ventasKg.labelCediIVA.DataBindings.Add("Text", ventasKg.DataSource, "IVACedi", "{0:$#,##0.00}");
                ventasKg.labelCediIEPS.DataBindings.Add("Text", ventasKg.DataSource, "IEPSCedi", "{0:$#,##0.00}");
                ventasKg.labelCediTotal.DataBindings.Add("Text", ventasKg.DataSource, "TotalCedi", "{0:$#,##0.00}");


                //segundo subreporte
                ProductoPorPrecioKg ventasProductoPorPrecio = new ProductoPorPrecioKg();

                ventasProductoPorPrecio.DataSource = VentasProductoPorPrecio;

                //Datos del detail
                ventasProductoPorPrecio.labelClave.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "Clave");
                ventasProductoPorPrecio.labelProducto.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "Producto");
                ventasProductoPorPrecio.labelUnidad.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "Unidad");
                ventasProductoPorPrecio.labelPrecioU.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "PrecioU", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelCantidad.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "Cant", "{0:#,##0}");
                ventasProductoPorPrecio.labelKgLts.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "KgLts", "{0:#,##0.00}");
                ventasProductoPorPrecio.labelSubtotal.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "SubTotal", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelDescProducto.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "DescProducto", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelDescCliente.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "DescuentoCliente", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelDescVendedor.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "DescVend", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelIVA.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "IVA", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelIEPS.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "IEPS", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelTotal.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "Total", "{0:$#,##0.00}");

                //
                VentasProductoPorPrecio.Last().CantTotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.Cant),2);
                VentasProductoPorPrecio.Last().KgLtsTotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.KgLts),2);
                VentasProductoPorPrecio.Last().SubTotalTotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.SubTotal),2);
                VentasProductoPorPrecio.Last().DescProductoTotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.DescProducto),2);
                VentasProductoPorPrecio.Last().DescuentoClienteTotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.DescuentoCliente),2);
                VentasProductoPorPrecio.Last().DescVendTotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.DescVend),2);
                VentasProductoPorPrecio.Last().IVATotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.IVA),2);
                VentasProductoPorPrecio.Last().IEPSTotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.IEPS),2);
                VentasProductoPorPrecio.Last().TotalTotal = Math.Round(VentasProductoPorPrecio.Sum(c => c.Total),2);
                //

                //footer
                ventasProductoPorPrecio.labelPrecioCantidad.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "CantTotal", "{0:#,##0}");
                ventasProductoPorPrecio.labelPrecioKgLts.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "KgLtsTotal", "{0:#,##0.00}");
                ventasProductoPorPrecio.labelPrecioSubtotal.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "SubTotalTotal", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelPrecioDescProducto.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "DescProductoTotal", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelPrecioDescCliente.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "DescuentoClienteTotal", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelPrecioDescVendedor.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "DescVendTotal", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelPrecioIVA.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "IVATotal", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelPrecioIEPS.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "IEPSTotal", "{0:$#,##0.00}");
                ventasProductoPorPrecio.labelPrecioTotal.DataBindings.Add("Text", ventasProductoPorPrecio.DataSource, "TotalTotal", "{0:$#,##0.00}");

                //tercer subreporte
                VentasProductoKg ventasProductoKg = new VentasProductoKg();

                ventasProductoKg.DataSource = VentasProducto;

                //Datos del detail
                ventasProductoKg.labelClave.DataBindings.Add("Text", ventasProductoKg.DataSource, "Clave");
                ventasProductoKg.labelProducto.DataBindings.Add("Text", ventasProductoKg.DataSource, "Producto");
                ventasProductoKg.labelUnidad.DataBindings.Add("Text", ventasProductoKg.DataSource, "Unidad");
                ventasProductoKg.labelCantidad.DataBindings.Add("Text", ventasProductoKg.DataSource, "Cantidad", "{0:#,##0}");
                ventasProductoKg.labelKgLts.DataBindings.Add("Text", ventasProductoKg.DataSource, "KgLts", "{0:#,##0.00}");
                ventasProductoKg.labelTotal.DataBindings.Add("Text", ventasProductoKg.DataSource, "Total", "{0:$#,##0.00}");

                //
                VentasProducto.Last().CantidadTotal = VentasProducto.Sum(c => c.Cantidad);
                VentasProducto.Last().KgLtsTotal = Math.Round(VentasProducto.Sum(c => c.KgLts),2);
                VentasProducto.Last().TotalTotal = Math.Round(VentasProducto.Sum(c => c.Total),2);
                //

                //footer
                ventasProductoKg.labelProductoCantidad.DataBindings.Add("Text", ventasProductoKg.DataSource, "CantidadTotal", "{0:#,##0}");
                ventasProductoKg.labelProductoKgLts.DataBindings.Add("Text", ventasProductoKg.DataSource, "KgLtsTotal", "{0:#,##0.00}");
                ventasProductoKg.labelProductoTotal.DataBindings.Add("Text", ventasProductoKg.DataSource, "TotalTotal", "{0:$#,##0.00}");

                report.VentasKg.ReportSource = ventasKg;
                report.VentasProductoPorPrecioKg.ReportSource = ventasProductoPorPrecio;
                report.VentasProductoKg.ReportSource = ventasProductoKg;

                return report;
            }
            catch (Exception ex)
            {
                return new ReportePedidos();
            }
        }
    }



    class VentasModel
    {
        public DateTime Fecha { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public string TransProdID { get; set; }
        public string Folio { get; set; }
        public string Cliente { get; set; }
        public string Clave { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public Decimal KgLts { get; set; }
        public Decimal PrecioU { get; set; }
        public string CEDI { get; set; }
        public int Cant { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal DescProducto { get; set; }
        public Decimal DescuentoCliente { get; set; }
        public Decimal DescVend { get; set; }
        public Decimal IVA { get; set; }
        public Decimal IEPS { get; set; }
        public Decimal Total { get; set; }

        //totales cliente
        public int CantCliente { get; set; }
        public Decimal KgLtsCliente { get; set; }
        public Decimal SubTotalCliente { get; set; }
        public Decimal DescProductoCliente { get; set; }
        public Decimal DescuentoClienteCliente { get; set; }
        public Decimal DescVendCliente { get; set; }
        public Decimal IVACliente { get; set; }
        public Decimal IEPSCliente { get; set; }
        public Decimal TotalCliente { get; set; }

        //totales vendedor
        public int CantVendedor { get; set; }
        public Decimal KgLtsVendedor { get; set; }
        public Decimal SubTotalVendedor { get; set; }
        public Decimal DescProductoVendedor { get; set; }
        public Decimal DescuentoClienteVendedor { get; set; }
        public Decimal DescVendVendedor { get; set; }
        public Decimal IVAVendedor { get; set; }
        public Decimal IEPSVendedor { get; set; }
        public Decimal TotalVendedor { get; set; }

        //totales cedi
        public int CantCedi { get; set; }
        public Decimal KgLtsCedi { get; set; }
        public Decimal SubTotalCedi { get; set; }
        public Decimal DescProductoCedi { get; set; }
        public Decimal DescuentoClienteCedi { get; set; }
        public Decimal DescVendCedi { get; set; }
        public Decimal IVACedi { get; set; }
        public Decimal IEPSCedi { get; set; }
        public Decimal TotalCedi { get; set; }
    }

    class VentasProductoPorPrecioModel
    {
        public string Clave { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public Decimal KgLts { get; set; }
        public Decimal PrecioU { get; set; }
        public Decimal Cant { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal DescProducto { get; set; }
        public Decimal DescuentoCliente { get; set; }
        public Decimal DescVend { get; set; }
        public Decimal IVA { get; set; }
        public Decimal IEPS { get; set; }
        public Decimal Total { get; set; }

        //totales
        public Decimal CantTotal { get; set; }
        public Decimal KgLtsTotal { get; set; }
        public Decimal SubTotalTotal { get; set; }
        public Decimal DescProductoTotal { get; set; }
        public Decimal DescuentoClienteTotal { get; set; }
        public Decimal DescVendTotal { get; set; }
        public Decimal IVATotal { get; set; }
        public Decimal IEPSTotal { get; set; }
        public Decimal TotalTotal { get; set; }
    }

    class VentasProductoModel
    {
        public string CEDI { get; set; }
        public string Clave { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public Decimal KgLts { get; set; }
        public int Cantidad { get; set; }
        public Decimal Total { get; set; }

        //totales
        public int CantidadTotal { get; set; }
        public Decimal KgLtsTotal { get; set; }
        public Decimal TotalTotal { get; set; }
    }

}