using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace eRoute.Models.ReportesModels
{
    public class LiquidacionMelbrin
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        ReporteLiquidacionMelbrin report = new ReporteLiquidacionMelbrin();

        public XtraReport GetReport(int VAVClave, string nombreReport, string pvCondicion, string VendedorSplit, string FechaInicial, string Cedis, string nombreCedis)
        {
            try
            {
                //Logo Empresa
                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK)";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.xrPictureBox1.Image = Image.FromStream(mStream);
                report.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                //Vendedor
                //Obtener Detalle
                StringBuilder VenDetalle = new StringBuilder();
                VenDetalle.AppendLine("SET ANSI_WARNINGS OFF ");
                VenDetalle.AppendLine("SET NOCOUNT ON ");
                VenDetalle.AppendLine("SELECT V.VendedorID + ' - ' + V.Nombre AS VendedorDetalle, A.Clave AS ClaveAlmacen,A.Nombre,A.Domicilio,A.Telefono,U.Clave AS ClaveAlmacenABordo ");
                VenDetalle.AppendLine("FROM VENCentroDistHist VDH (NOLOCK) ");
                VenDetalle.AppendLine("INNER JOIN Almacen A (NOLOCK) ON VDH.AlmacenId=A.AlmacenID ");
                VenDetalle.AppendLine("INNER JOIN Vendedor V (NOLOCK) ON V.VendedorID=VDH.VendedorID ");
                VenDetalle.AppendLine("INNER JOIN Usuario U (NOLOCK) ON V.USUId=U.USUId ");
                VenDetalle.AppendLine(pvCondicion);

                QueryString = "";
                QueryString = VenDetalle.ToString();

                List<LiquidacionMelbrinDetalleVModel> VDetalle = Connection.Query<LiquidacionMelbrinDetalleVModel>(QueryString, null, null, true, 600).ToList();

                var VDet = (from VD in VDetalle select VD).ToList().GroupBy(VDD => new { VDD.VendedorDetalle })
                        .SelectMany(VDL => VDL.Select(VDS => new LiquidacionMelbrinDetalleVModel
                        {
                            VendedorDetalle = VDS.VendedorDetalle,
                            Domicilio = VDS.Domicilio,
                            Telefono = VDS.Telefono
                        })).ToList();
                string DetalleV = "";
                string DomicilioV = "";
                string TelefonoV = "";
                foreach (var item in VDet)
                {
                    DetalleV = item.VendedorDetalle;
                    DomicilioV = item.Domicilio;
                    TelefonoV = item.Telefono;
                }
                report.HeaderVendedor.Text = DetalleV;
                report.HeaderDireccion.Text = DomicilioV;
                report.HeaderTelefono.Text = TelefonoV;
                //---------------

                //Fecha
                DateTime fInicio = DateTime.Parse(FechaInicial);
                string FCaptura = fInicio.Date.ToShortDateString();
                string Filtro = FechaInicial.Substring(0, 4) + FechaInicial.Substring(5, 2) + FechaInicial.Substring(8, 2);
                report.HeaderFecha.Text = FCaptura;

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Producto
                StringBuilder LiqProducto = new StringBuilder();
                LiqProducto.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR ");
                LiqProducto.AppendLine("SET ANSI_WARNINGS OFF");
                LiqProducto.AppendLine("SET NOCOUNT ON ");
                LiqProducto.AppendLine("DECLARE @FechaFiltro AS datetime, @VenID AS varchar(16) ");
                LiqProducto.AppendLine("SET @FechaFiltro = '" + Filtro + "' ");
                LiqProducto.AppendLine("SET @VenID  ='" + VendedorSplit + "' ");
                LiqProducto.AppendLine("IF (SELECT object_id('tempdb..#TmpUltimoInventarioABordo')) IS NOT NULL DROP TABLE #TmpUltimoInventarioABordo ");
                LiqProducto.AppendLine("Begin ");
                LiqProducto.AppendLine("SELECT * into #TmpUltimoInventarioABordo ");
                LiqProducto.AppendLine("FROM ( ");
                LiqProducto.AppendLine("SELECT TOP 1 VD.VendedorID,T.FechaCaptura,FechaHoraAlta,TransProdID ");
                LiqProducto.AppendLine("FROM TransProd T (NOLOCK) ");
                LiqProducto.AppendLine("INNER JOIN Vendedor VD (NOLOCK) ON T.MUsuarioID = VD.USUId ");
                LiqProducto.AppendLine("WHERE T.Tipo IN (23) AND T.TipoFase <> 0 AND T.FechaCaptura<@FechaFiltro AND VD.VendedorID = @VenID ");
                LiqProducto.AppendLine("GROUP BY VD.VendedorID,T.FechaCaptura,FechaHoraAlta,TransProdID ");
                LiqProducto.AppendLine("ORDER BY T.FechaHoraAlta DESC ");
                LiqProducto.AppendLine(") AS UltimoInventarioABordo ");
                LiqProducto.AppendLine("End ");

                LiqProducto.AppendLine("--OBTIENE PRIMERA CARGA DEL VENDEDOR ");
                LiqProducto.AppendLine("IF (SELECT object_id('tempdb..#TmpPrimeraCarga')) IS NOT NULL DROP TABLE #TmpPrimeraCarga ");
                LiqProducto.AppendLine("begin ");
                LiqProducto.AppendLine("SELECT * into #TmpPrimeraCarga from( ");
                LiqProducto.AppendLine("SELECT VD.VendedorID,D.FechaCaptura,(min(T.FechaHoraAlta)) AS FechaHoraPrimeraCarga, '1' AS TipoCarga ");
                LiqProducto.AppendLine("FROM TransProd T (NOLOCK) ");
                LiqProducto.AppendLine("INNER JOIN Dia D (NOLOCK) ON T.DiaClave=D.DiaClave ");
                LiqProducto.AppendLine("INNER JOIN Vendedor VD (NOLOCK) ON T.MUsuarioID=VD.USUId ");
                LiqProducto.AppendLine("WHERE T.Tipo IN (2) AND T.TipoFase<>0 AND D.FechaCaptura=@FechaFiltro AND VD.VendedorID=@VenID ");
                LiqProducto.AppendLine("GROUP BY VD.VendedorID,D.FechaCaptura ");
                LiqProducto.AppendLine(") AS PrimeraCarga ");
                LiqProducto.AppendLine("end ");

                LiqProducto.AppendLine("--DETALLE PRODUCTOS");
                LiqProducto.AppendLine("select VendedorID,NombreVendedor,DiaClave,ProductoClave as Clave,Descripcion,sum(Inventarioinicial) as InventarioInicial,");
                LiqProducto.AppendLine("sum(Recarga) as Recarga,sum(DevolucionCte) as DevolucionCte,sum(Promocion) as Promocion,sum(Descarga) as Descarga,");
                LiqProducto.AppendLine("sum(Venta) as Venta, sum(Consigna) as Consigna, sum((Subtotal - DesCliPor - DesVendPor) + (Impuesto - DesCliPorImp)) as Importe,");
                LiqProducto.AppendLine("(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda");
                LiqProducto.AppendLine("from (");
                LiqProducto.AppendLine("--VentaDirecta");
                LiqProducto.AppendLine("select V.VendedorID,VD.Nombre as NombreVendedor,D.DiaClave,TD.ProductoClave,P.Nombre as Descripcion,");
                LiqProducto.AppendLine("InventarioInicial=0,");
                LiqProducto.AppendLine("Recarga=0,");
                LiqProducto.AppendLine("DevolucionCte=0,");
                LiqProducto.AppendLine("Promocion=(select case when T.Tipo=1 and isnull(TD.Promocion,0)=2 then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("Descarga=0,");
                LiqProducto.AppendLine("Venta=(select case when T.Tipo=1 and isnull(TD.Promocion,0)<>2 then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("Consigna=0,");
                LiqProducto.AppendLine("SubTotal=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal else 0 end),");
                LiqProducto.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end),");
                LiqProducto.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqProducto.AppendLine("Impuesto=(select case when T.Tipo=1 and TD.Total>0 then (select case when TD.Impuesto is null then 0 else TD.Impuesto end) else 0 end),");
                LiqProducto.AppendLine("DesCliPorImp=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)");
                LiqProducto.AppendLine("from TransProd T");
                LiqProducto.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave");
                LiqProducto.AppendLine("inner join Visita V on T.VisitaClave=V.VisitaClave");
                LiqProducto.AppendLine("inner join TransProdDetalle TD on T.TransProdID=TD.TransProdID");
                LiqProducto.AppendLine("inner join Producto P on TD.ProductoClave=P.ProductoClave");
                LiqProducto.AppendLine("inner join ProductoDetalle PD on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad");
                LiqProducto.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqProducto.AppendLine("where T.Tipo in (1) and T.TipoFase not in(0,1,7) AND D.FechaCaptura=@FechaFiltro AND V.VendedorID=@VenID ");
                LiqProducto.AppendLine("UNION ALL");
                LiqProducto.AppendLine("--Reparto");
                LiqProducto.AppendLine("select V.VendedorID,VD.Nombre,D.DiaClave,TD.ProductoClave,P.Nombre,");
                LiqProducto.AppendLine("InventarioInicial=0,");
                LiqProducto.AppendLine("Recarga=0,");
                LiqProducto.AppendLine("DevolucionCte=0,");
                LiqProducto.AppendLine("Promocion=(select case when T.Tipo=1 and isnull(TD.Promocion,0)=2 then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("Descarga=0,");
                LiqProducto.AppendLine("Venta=(select case when T.Tipo=1 and isnull(TD.Promocion,0)<>2 then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("Consigna=0,");
                LiqProducto.AppendLine("SubTotal=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal else 0 end),");
                LiqProducto.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end),");
                LiqProducto.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqProducto.AppendLine("Impuesto=(select case when T.Tipo=1 and TD.Total>0 then (select case when TD.Impuesto is null then 0 else TD.Impuesto end) else 0 end),");
                LiqProducto.AppendLine("DesCliPorImp=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)");
                LiqProducto.AppendLine("from TransProd T");
                LiqProducto.AppendLine("inner join Dia D on T.DiaClave1=D.DiaClave");
                LiqProducto.AppendLine("inner join Visita V on T.VisitaClave1=V.VisitaClave");
                LiqProducto.AppendLine("inner join TransProdDetalle TD on T.TransProdID=TD.TransProdID");
                LiqProducto.AppendLine("inner join Producto P on TD.ProductoClave=P.ProductoClave");
                LiqProducto.AppendLine("inner join ProductoDetalle PD on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad");
                LiqProducto.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqProducto.AppendLine("where T.Tipo in (1) and T.TipoFase not in(0,1,7) AND D.FechaCaptura=@FechaFiltro AND V.VendedorID=@VenID ");
                LiqProducto.AppendLine("UNION ALL");
                LiqProducto.AppendLine("");
                LiqProducto.AppendLine("--Consigna");
                LiqProducto.AppendLine("select V.VendedorID,VD.Nombre as NombreVendedor,D.DiaClave,TD.ProductoClave,P.Nombre as Descripcion,");
                LiqProducto.AppendLine("InventarioInicial=0,");
                LiqProducto.AppendLine("Recarga=0,");
                LiqProducto.AppendLine("DevolucionCte=0,");
                LiqProducto.AppendLine("Promocion=0,");
                LiqProducto.AppendLine("Descarga=0,");
                LiqProducto.AppendLine("Venta=0,");
                LiqProducto.AppendLine("Consigna=(select case when T.Tipo=24 then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("SubTotal=(select case when T.Tipo=24 and TD.Total>0 then TD.Subtotal else 0 end),");
                LiqProducto.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end),");
                LiqProducto.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqProducto.AppendLine("Impuesto=(select case when T.Tipo=1 and TD.Total>0 then (select case when TD.Impuesto is null then 0 else TD.Impuesto end) else 0 end),");
                LiqProducto.AppendLine("DesCliPorImp=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)");
                LiqProducto.AppendLine("from TransProd T");
                LiqProducto.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave");
                LiqProducto.AppendLine("inner join Visita V on T.VisitaClave=V.VisitaClave");
                LiqProducto.AppendLine("inner join TransProdDetalle TD on T.TransProdID=TD.TransProdID");
                LiqProducto.AppendLine("inner join Producto P on TD.ProductoClave=P.ProductoClave");
                LiqProducto.AppendLine("inner join ProductoDetalle PD on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad");
                LiqProducto.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqProducto.AppendLine("where T.Tipo in (24) and T.TipoFase in(2,6)");
                LiqProducto.AppendLine("AND D.FechaCaptura = @FechaFiltro AND VD.VendedorID = @VenID ");
                LiqProducto.AppendLine("UNION ALL");
                LiqProducto.AppendLine("");
                LiqProducto.AppendLine("--PRIMERA CARGA, RECARGAS, DEVOLUCIONES DE CLIENTE Y DESCARGAS");
                LiqProducto.AppendLine("select");
                LiqProducto.AppendLine("VD.VendedorID,VD.Nombre as NombreVendedor,D.DiaClave,TD.ProductoClave,P.Nombre as Descripcion,");
                LiqProducto.AppendLine("InventarioInicial=(select case when PC.TipoCarga=1 then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("Recarga=(select case when T.Tipo=2 and PC.TipoCarga is null then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("DevolucionCte=(select case when T.Tipo=3 then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("Promocion=0,");
                LiqProducto.AppendLine("Descarga=(select case when T.Tipo=7 or T.Tipo=4 then TD.Cantidad * PD.Factor else 0 end),");
                LiqProducto.AppendLine("Venta=0,");
                LiqProducto.AppendLine("Consigna=0,");
                LiqProducto.AppendLine("SubTotal=0,");
                LiqProducto.AppendLine("DesCliPor=0,");
                LiqProducto.AppendLine("DesVendPor=0,");
                LiqProducto.AppendLine("Impuesto=0,");
                LiqProducto.AppendLine("DesCliPorImp=0");
                LiqProducto.AppendLine("from TransProd T");
                LiqProducto.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave");
                LiqProducto.AppendLine("inner join TransProdDetalle TD on T.TransProdID=TD.TransProdID");
                LiqProducto.AppendLine("inner join Producto P on TD.ProductoClave=P.ProductoClave");
                LiqProducto.AppendLine("inner join ProductoDetalle PD on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad");
                LiqProducto.AppendLine("inner join Vendedor VD on T.MUsuarioID=VD.USUId");
                LiqProducto.AppendLine("left join #TmpPrimeraCarga PC on VD.VendedorID=PC.VendedorID and T.FechaHoraAlta=PC.FechaHoraPrimeraCarga");
                LiqProducto.AppendLine("where T.Tipo in (2,3,4,7) and T.TipoFase<>0 AND D.FechaCaptura=@FechaFiltro AND VD.VendedorID=@VenID ");
                LiqProducto.AppendLine("UNION ALL");
                LiqProducto.AppendLine("--ULTIMO INVENTARIO A BORDO");
                LiqProducto.AppendLine("select TUA.VendedorID,VD.Nombre as NombreVendedor,");
                LiqProducto.AppendLine("'" + FCaptura + "' ");
                LiqProducto.AppendLine(",TD.ProductoClave,P.Nombre as Descripcion,");
                LiqProducto.AppendLine("InventarioInicial=(select TD.Cantidad * PD.Factor),");
                LiqProducto.AppendLine("Recarga=0,");
                LiqProducto.AppendLine("DevolucionCte=0,");
                LiqProducto.AppendLine("Promocion=0,");
                LiqProducto.AppendLine("Descarga=0,");
                LiqProducto.AppendLine("Venta=0,");
                LiqProducto.AppendLine("Consigna=0,");
                LiqProducto.AppendLine("SubTotal=0,");
                LiqProducto.AppendLine("DesCliPor=0,");
                LiqProducto.AppendLine("DesVendPor=0,");
                LiqProducto.AppendLine("Impuesto=0,");
                LiqProducto.AppendLine("DesCliPorImp = 0");
                LiqProducto.AppendLine("from #TmpUltimoInventarioABordo TUA");
                LiqProducto.AppendLine("inner join TransProdDetalle TD on TUA.TransProdID=TD.TransProdID");
                LiqProducto.AppendLine("inner join Producto P on TD.ProductoClave=P.ProductoClave");
                LiqProducto.AppendLine("inner join ProductoDetalle PD on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad");
                LiqProducto.AppendLine("inner join Vendedor VD on TUA.VendedorID=VD.VendedorID");
                LiqProducto.AppendLine(") as LiquidacionProductos");
                LiqProducto.AppendLine("group by VendedorID,NombreVendedor,DiaClave,ProductoClave,Descripcion");
                LiqProducto.AppendLine("order by ProductoClave ");
                LiqProducto.AppendLine("drop table #TmpPrimeraCarga ");
                LiqProducto.AppendLine("drop table #TmpUltimoInventarioABordo ");
                LiqProducto.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqProducto.ToString();

                List<LiquidacionMelbrinGenericoModel> Productos = Connection.Query<LiquidacionMelbrinGenericoModel>(QueryString, null, null, true, 600).ToList();
                var SubLiqProductos = (from p in Productos
                                       select p).ToList();
                List<LiquidacionMelbrinGenericoModel> Pro = new List<LiquidacionMelbrinGenericoModel>();
                var SLQ = (from gr in SubLiqProductos group gr by new { gr.VendedorID } into grupo select grupo);

                Decimal Total = 0;
                string SMoneda = "";

                foreach (var grupo in SLQ)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Pro.Add(new LiquidacionMelbrinGenericoModel
                        {
                            VendedorID = "VENTAS POR PRODUCTO",
                            Clave = objetoAgrupado.Clave,
                            Descripcion = objetoAgrupado.Descripcion,
                            InventarioInicial = objetoAgrupado.InventarioInicial,
                            Recarga = objetoAgrupado.Recarga,
                            Devolucion = objetoAgrupado.Devolucion,
                            Promocion = objetoAgrupado.Promocion,
                            Descarga = objetoAgrupado.Descarga,
                            Venta = objetoAgrupado.Venta,
                            Consignacion = objetoAgrupado.Consignacion,
                            InventarioFinal = (objetoAgrupado.InventarioInicial + objetoAgrupado.Recarga + objetoAgrupado.Devolucion) - (objetoAgrupado.Promocion + objetoAgrupado.Descarga + objetoAgrupado.Venta + objetoAgrupado.Consignacion),
                            SimboloMoneda = objetoAgrupado.SimboloMoneda,
                            Importe = objetoAgrupado.Importe
                        });
                        Pro.Last().ImporteTotal = grupo.Sum(c => c.Importe);
                        Total += objetoAgrupado.Importe;
                        SMoneda = objetoAgrupado.SimboloMoneda;
                    }
                }

                SubReporteProductosMelbrin SubReporteP = new SubReporteProductosMelbrin();
                SubReporteP.DataSource = Pro;
                //GroupHeader2
                GroupField groupP = new GroupField("VendedorID");
                SubReporteP.GroupHeader2.GroupFields.Add(groupP);
                SubReporteP.SubProducto.DataBindings.Add("Text", SubReporteP.DataSource, "VendedorID");
                //Detalle
                SubReporteP.PClave.DataBindings.Add("Text", null, "Clave");
                SubReporteP.PDescripcion.DataBindings.Add("Text", null, "Descripcion");
                SubReporteP.PInicial.DataBindings.Add("Text", null, "InventarioInicial");
                SubReporteP.PRecarga.DataBindings.Add("Text", null, "Recarga");
                SubReporteP.PDevolucion.DataBindings.Add("Text", null, "Devolucion");
                SubReporteP.PPromocion.DataBindings.Add("Text", null, "Promocion");
                SubReporteP.PDescarga.DataBindings.Add("Text", null, "Descarga");
                SubReporteP.PVentas.DataBindings.Add("Text", null, "Venta");
                SubReporteP.PConsignacion.DataBindings.Add("Text", null, "Consignacion");
                SubReporteP.PFinal.DataBindings.Add("Text", null, "InventarioFinal");
                SubReporteP.PSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteP.PImporte.DataBindings.Add("Text", null, "Importe", "{0:$0.00}");
                //Total
                SubReporteP.TPSimbolo.Text = SMoneda;
                SubReporteP.TPImporte.Text = Total.ToString("$0.00");
                if (Pro.Count > 0)
                {
                    report.xrSubreportProducto.ReportSource = SubReporteP;
                }
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Contado
                StringBuilder LiqContado = new StringBuilder();
                LiqContado.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR ");
                LiqContado.AppendLine("SET ANSI_WARNINGS OFF ");
                LiqContado.AppendLine("SET NOCOUNT ON ");
                LiqContado.AppendLine("DECLARE @FechaFiltro AS datetime, @VenID AS varchar(16) ");
                LiqContado.AppendLine("SET @FechaFiltro = '" + Filtro + "' ");
                LiqContado.AppendLine("SET @VenID  ='" + VendedorSplit + "' ");
                LiqContado.AppendLine("--VENTAS CONTADO");
                LiqContado.AppendLine("select *,");
                LiqContado.AppendLine("(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda");
                LiqContado.AppendLine("from (");
                LiqContado.AppendLine("--VentaDirecta");
                LiqContado.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqContado.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqContado.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqContado.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqContado.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqContado.AppendLine("from TransProdDetalle TD");
                LiqContado.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                LiqContado.AppendLine("where TransprodId=T.TransProdId");
                LiqContado.AppendLine(") end");
                LiqContado.AppendLine(") as Kilos, T.DescVendPor as Descuento");
                LiqContado.AppendLine("from TransProd T");
                LiqContado.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqContado.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave");
                LiqContado.AppendLine("inner join Visita V on T.VisitaClave=V.VisitaClave");
                LiqContado.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave");
                LiqContado.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqContado.AppendLine("where T.Tipo in (1) and T.CFVTipo=1 and T.TipoFase not in(1,7) ");
                LiqContado.AppendLine("and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID "); ;
                LiqContado.AppendLine("UNION ALL");
                LiqContado.AppendLine("--FacturaDirecta");
                LiqContado.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqContado.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqContado.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqContado.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqContado.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqContado.AppendLine("from TransProdDetalle TD");
                LiqContado.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                LiqContado.AppendLine("where TransprodId=T.TransProdId");
                LiqContado.AppendLine(") end");
                LiqContado.AppendLine(") as Kilos, T.DescVendPor as Descuento");
                LiqContado.AppendLine("from TransProd T");
                LiqContado.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqContado.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave");
                LiqContado.AppendLine("inner join Visita V on T.VisitaClave=V.VisitaClave");
                LiqContado.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave");
                LiqContado.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqContado.AppendLine("where T.Tipo in (8) and T.CFVTipo=1 and T.TipoFase in(0) ");
                LiqContado.AppendLine("and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID "); ;
                LiqContado.AppendLine("UNION ALL");
                LiqContado.AppendLine("--Reparto");
                LiqContado.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqContado.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqContado.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqContado.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqContado.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqContado.AppendLine("from TransProdDetalle TD");
                LiqContado.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                LiqContado.AppendLine("where TransprodId=T.TransProdId");
                LiqContado.AppendLine(") end");
                LiqContado.AppendLine(") as Kilos, T.DescVendPor as Descuento");
                LiqContado.AppendLine("from TransProd T");
                LiqContado.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqContado.AppendLine("inner join Dia D on T.DiaClave1=D.DiaClave");
                LiqContado.AppendLine("inner join Visita V on T.VisitaClave1=V.VisitaClave");
                LiqContado.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave");
                LiqContado.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqContado.AppendLine("where T.Tipo in (1) and T.CFVTipo=1 and T.TipoFase not in(1,7) ");
                LiqContado.AppendLine("and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID "); ;
                LiqContado.AppendLine("UNION ALL");
                LiqContado.AppendLine("--RepartoFactura");
                LiqContado.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqContado.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqContado.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqContado.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqContado.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqContado.AppendLine("from TransProdDetalle TD");
                LiqContado.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                LiqContado.AppendLine("where TransprodId=T.TransProdId");
                LiqContado.AppendLine(") end");
                LiqContado.AppendLine(") as Kilos, T.DescVendPor as Descuento");
                LiqContado.AppendLine("from TransProd T");
                LiqContado.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqContado.AppendLine("inner join Dia D on T.DiaClave1=D.DiaClave");
                LiqContado.AppendLine("inner join Visita V on T.VisitaClave1=V.VisitaClave");
                LiqContado.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave");
                LiqContado.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqContado.AppendLine("where T.Tipo in (8) and T.CFVTipo=1 and T.TipoFase in(0) ");
                LiqContado.AppendLine("and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID "); ;
                LiqContado.AppendLine(") as LiquidacionContado");
                LiqContado.AppendLine("order by FolioVenta,FolioFactura");
                LiqContado.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqContado.ToString();

                List<LiquidacionMelbrinConCre> Contado = Connection.Query<LiquidacionMelbrinConCre>(QueryString, null, null, true, 600).ToList();
                var SubContado = (from co in Contado
                                  select co).ToList();
                List<LiquidacionMelbrinConCre> Con = new List<LiquidacionMelbrinConCre>();
                var SCO = (from gr in SubContado group gr by new { gr.ConCreDetalle } into grupo select grupo);

                Decimal TotalCon = 0;
                double KilosCon = 0;

                foreach (var grupo in SCO)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Con.Add(new LiquidacionMelbrinConCre
                        {
                            ConCreDetalle = "VENTA CONTADO",
                            FolioVenta = objetoAgrupado.FolioVenta,
                            FolioFactura = objetoAgrupado.FolioFactura,
                            FechaHoraAlta = objetoAgrupado.FechaHoraAlta,
                            ClienteClave = objetoAgrupado.ClienteClave,
                            Total = objetoAgrupado.Total,
                            Kilos = objetoAgrupado.Kilos,
                            SimboloMoneda = objetoAgrupado.SimboloMoneda
                        });
                        Con.Last().ConCreTotal = grupo.Sum(c => c.Total);
                        Con.Last().ConCreKilos = grupo.Sum(c => c.Kilos);
                        TotalCon += objetoAgrupado.Total;
                        KilosCon += objetoAgrupado.Kilos;
                    }
                }

                SubReporteContado SubReporteCo = new SubReporteContado();
                SubReporteCo.DataSource = Con;
                //GroupHeader2
                GroupField groupCo = new GroupField("ConCreDetalle");
                SubReporteCo.GroupHeader2.GroupFields.Add(groupCo);
                SubReporteCo.SubContado.DataBindings.Add("Text", SubReporteCo.DataSource, "ConCreDetalle");
                //Detalle
                SubReporteCo.CoVenta.DataBindings.Add("Text", null, "FolioVenta");
                SubReporteCo.CoFactura.DataBindings.Add("Text", null, "FolioFactura");
                SubReporteCo.CoFecha.DataBindings.Add("Text", null, "FechaHoraAlta");
                SubReporteCo.CoCliente.DataBindings.Add("Text", null, "ClienteClave");
                SubReporteCo.CoImporte.DataBindings.Add("Text", null, "Total");
                SubReporteCo.CoKilos.DataBindings.Add("Text", null, "Kilos");
                SubReporteCo.CoSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                //Total
                SubReporteCo.TCoKilos.Text = KilosCon.ToString();
                SubReporteCo.TCoSimbolo.Text = SMoneda;
                SubReporteCo.TCoImporte.Text = TotalCon.ToString("$0.00");
                report.xrSubreportContado.ReportSource = SubReporteCo;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Credito
                StringBuilder LiqCredito = new StringBuilder();
                LiqCredito.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR ");
                LiqCredito.AppendLine("SET ANSI_WARNINGS OFF ");
                LiqCredito.AppendLine("SET NOCOUNT ON ");
                LiqCredito.AppendLine("DECLARE @FechaFiltro AS datetime, @VenID AS varchar(16) ");
                LiqCredito.AppendLine("SET @FechaFiltro = '" + Filtro + "' ");
                LiqCredito.AppendLine("SET @VenID  ='" + VendedorSplit + "' ");
                LiqCredito.AppendLine("select *, ");
                LiqCredito.AppendLine("(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda ");
                LiqCredito.AppendLine("from ( ");
                LiqCredito.AppendLine("--VentaDirecta");
                LiqCredito.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta, ");
                LiqCredito.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end), ");
                LiqCredito.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end), ");
                LiqCredito.AppendLine("(select case when T.TipoFase=0 then 0 else ( ");
                LiqCredito.AppendLine("select sum(TD.Cantidad*PU.KgLts) ");
                LiqCredito.AppendLine("from TransProdDetalle TD ");
                LiqCredito.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad ");
                LiqCredito.AppendLine("where TransprodId=T.TransProdId ");
                LiqCredito.AppendLine(") end ");
                LiqCredito.AppendLine(") as Kilos, T.DescVendPor as Descuento ");
                LiqCredito.AppendLine("from TransProd T ");
                LiqCredito.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID ");
                LiqCredito.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave ");
                LiqCredito.AppendLine("inner join Visita V on T.VisitaClave=V.VisitaClave ");
                LiqCredito.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave ");
                LiqCredito.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID ");
                LiqCredito.AppendLine("where T.Tipo in (1) and T.CFVTipo=2 and T.TipoFase not in(1,7)  ");
                LiqCredito.AppendLine(" and D.FechaCaptura=@FechaFiltro and V.VendedorID=@Venid ");
                LiqCredito.AppendLine("UNION ALL ");
                LiqCredito.AppendLine("--FacturaDirecta ");
                LiqCredito.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta, ");
                LiqCredito.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end), ");
                LiqCredito.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end), ");
                LiqCredito.AppendLine("(select case when T.TipoFase=0 then 0 else ( ");
                LiqCredito.AppendLine("select sum(TD.Cantidad*PU.KgLts) ");
                LiqCredito.AppendLine("from TransProdDetalle TD ");
                LiqCredito.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad ");
                LiqCredito.AppendLine("where TransprodId=T.TransProdId ");
                LiqCredito.AppendLine(") end ");
                LiqCredito.AppendLine(") as Kilos, T.DescVendPor as Descuento ");
                LiqCredito.AppendLine("from TransProd T ");
                LiqCredito.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID ");
                LiqCredito.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave ");
                LiqCredito.AppendLine("inner join Visita V on T.VisitaClave=V.VisitaClave ");
                LiqCredito.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave ");
                LiqCredito.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID ");
                LiqCredito.AppendLine("where T.Tipo in (8) and T.CFVTipo=2 and T.TipoFase in(0) ");
                LiqCredito.AppendLine("and D.FechaCaptura=@FechaFiltro and V.VendedorID=@Venid ");
                LiqCredito.AppendLine("UNION ALL ");
                LiqCredito.AppendLine("--Reparto");
                LiqCredito.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta, ");
                LiqCredito.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end), ");
                LiqCredito.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end), ");
                LiqCredito.AppendLine("(select case when T.TipoFase=0 then 0 else ( ");
                LiqCredito.AppendLine("select sum(TD.Cantidad*PU.KgLts) ");
                LiqCredito.AppendLine("from TransProdDetalle TD ");
                LiqCredito.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad ");
                LiqCredito.AppendLine("where TransprodId=T.TransProdId ");
                LiqCredito.AppendLine(") end ");
                LiqCredito.AppendLine(") as Kilos, T.DescVendPor as Descuento ");
                LiqCredito.AppendLine("from TransProd T ");
                LiqCredito.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID ");
                LiqCredito.AppendLine("inner join Dia D on T.DiaClave1=D.DiaClave ");
                LiqCredito.AppendLine("inner join Visita V on T.VisitaClave1=V.VisitaClave ");
                LiqCredito.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave ");
                LiqCredito.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID ");
                LiqCredito.AppendLine("where T.Tipo in (1) and T.CFVTipo=2 and T.TipoFase not in(1,7)  ");
                LiqCredito.AppendLine("and D.FechaCaptura=@FechaFiltro and V.VendedorID=@Venid ");
                LiqCredito.AppendLine("UNION ALL ");
                LiqCredito.AppendLine("--RepartoFactura ");
                LiqCredito.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta, ");
                LiqCredito.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end), ");
                LiqCredito.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end), ");
                LiqCredito.AppendLine("(select case when T.TipoFase=0 then 0 else ( ");
                LiqCredito.AppendLine("select sum(TD.Cantidad*PU.KgLts) ");
                LiqCredito.AppendLine("from TransProdDetalle TD ");
                LiqCredito.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad ");
                LiqCredito.AppendLine("where TransprodId=T.TransProdId ");
                LiqCredito.AppendLine(") end ");
                LiqCredito.AppendLine(") as Kilos, T.DescVendPor as Descuento ");
                LiqCredito.AppendLine("from TransProd T ");
                LiqCredito.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID ");
                LiqCredito.AppendLine("inner join Dia D on T.DiaClave1=D.DiaClave ");
                LiqCredito.AppendLine("inner join Visita V on T.VisitaClave1=V.VisitaClave ");
                LiqCredito.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave ");
                LiqCredito.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID ");
                LiqCredito.AppendLine("where T.Tipo in (8) and T.CFVTipo=2 and T.TipoFase in(0) ");
                LiqCredito.AppendLine("and D.FechaCaptura=@FechaFiltro and V.VendedorID=@Venid ");
                LiqCredito.AppendLine(") as LiquidacionCredito ");
                LiqCredito.AppendLine("order by FolioVenta,FolioFactura ");
                LiqCredito.AppendLine("SET NOCOUNT OFF  ");

                QueryString = "";
                QueryString = LiqCredito.ToString();

                List<LiquidacionMelbrinConCre> Credito = Connection.Query<LiquidacionMelbrinConCre>(QueryString, null, null, true, 600).ToList();
                var SubCredito = (from cr in Credito
                                  select cr).ToList();
                List<LiquidacionMelbrinConCre> Cre = new List<LiquidacionMelbrinConCre>();
                var SCR = (from gr in SubCredito group gr by new { gr.ConCreDetalle } into grupo select grupo);

                Decimal TotalCre = 0;
                double KilosCre = 0;

                foreach (var grupo in SCR)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Cre.Add(new LiquidacionMelbrinConCre
                        {
                            ConCreDetalle = "VENTA CRÉDITO",
                            FolioVenta = objetoAgrupado.FolioVenta,
                            FolioFactura = objetoAgrupado.FolioFactura,
                            FechaHoraAlta = objetoAgrupado.FechaHoraAlta,
                            ClienteClave = objetoAgrupado.ClienteClave,
                            Total = objetoAgrupado.Total,
                            Kilos = objetoAgrupado.Kilos,
                            SimboloMoneda = objetoAgrupado.SimboloMoneda
                        });
                        Cre.Last().ConCreTotal = grupo.Sum(c => c.Total);
                        Cre.Last().ConCreKilos = grupo.Sum(c => c.Kilos);
                        TotalCre += objetoAgrupado.Total;
                        KilosCre += objetoAgrupado.Kilos;
                    }
                }
                SubReporteCredito SubReporteCr = new SubReporteCredito();
                SubReporteCr.DataSource = Cre;
                //GroupHeader2
                GroupField groupCr = new GroupField("ConCreDetalle");
                SubReporteCr.GroupHeader2.GroupFields.Add(groupCo);
                SubReporteCr.SubCredito.DataBindings.Add("Text", SubReporteCr.DataSource, "ConCredetalle");
                //Detalle
                SubReporteCr.CrVenta.DataBindings.Add("Text", null, "FolioVenta");
                SubReporteCr.CrFactura.DataBindings.Add("Text", null, "FolioFactura");
                SubReporteCr.CrFecha.DataBindings.Add("Text", null, "FechaHoraAlta");
                SubReporteCr.CrCliente.DataBindings.Add("Text", null, "ClienteClave");
                SubReporteCr.CrImporte.DataBindings.Add("Text", null, "Total");
                SubReporteCr.CrKilos.DataBindings.Add("Text", null, "Kilos");
                SubReporteCr.CrSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                //Total
                SubReporteCr.TCrKilos.Text = KilosCre.ToString();
                SubReporteCr.TCrSimbolo.Text = SMoneda;
                SubReporteCr.TCrImporte.Text = TotalCre.ToString("$0.00");
                report.xrSubreportCredito.ReportSource = SubReporteCr;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Consignacion
                StringBuilder LiqConsginacion = new StringBuilder();
                LiqConsginacion.AppendLine("SET ANSI_WARNINGS OFF");
                LiqConsginacion.AppendLine("SET NOCOUNT ON ");
                LiqConsginacion.AppendLine("DECLARE @FechaFiltro AS datetime, @VenID AS varchar(16) ");
                LiqConsginacion.AppendLine("SET @FechaFiltro = '" + Filtro + "' ");
                LiqConsginacion.AppendLine("SET @VenID  ='" + VendedorSplit + "' ");
                LiqConsginacion.AppendLine("--VENTAS CREDITO");
                LiqConsginacion.AppendLine("select *,");
                LiqConsginacion.AppendLine("(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda");
                LiqConsginacion.AppendLine("from (");
                LiqConsginacion.AppendLine("--VentaDirecta");
                LiqConsginacion.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqConsginacion.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqConsginacion.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqConsginacion.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqConsginacion.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqConsginacion.AppendLine("from TransProdDetalle TD");
                LiqConsginacion.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                LiqConsginacion.AppendLine("where TransprodId=T.TransProdId");
                LiqConsginacion.AppendLine(") end");
                LiqConsginacion.AppendLine(") as Kilos, T.DescVendPor as Descuento,");
                LiqConsginacion.AppendLine("(select Descripcion from VAVDescripcion where VADTipoLenguaje = 'EM' and VARCodigo = 'TRPFase' and VAVClave = T.TipoFase) as Fase");
                LiqConsginacion.AppendLine("from TransProd T");
                LiqConsginacion.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqConsginacion.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave");
                LiqConsginacion.AppendLine("inner join Visita V on T.VisitaClave=V.VisitaClave");
                LiqConsginacion.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave");
                LiqConsginacion.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqConsginacion.AppendLine("where T.Tipo in (24) and T.TipoFase in(2,6)");
                LiqConsginacion.AppendLine(" and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID ");
                LiqConsginacion.AppendLine("UNION ALL");
                LiqConsginacion.AppendLine("--FacturaDirecta");
                LiqConsginacion.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqConsginacion.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqConsginacion.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqConsginacion.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqConsginacion.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqConsginacion.AppendLine("from TransProdDetalle TD");
                LiqConsginacion.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                LiqConsginacion.AppendLine("where TransprodId=T.TransProdId");
                LiqConsginacion.AppendLine(") end");
                LiqConsginacion.AppendLine(") as Kilos, T.DescVendPor as Descuento,");
                LiqConsginacion.AppendLine("(select Descripcion from VAVDescripcion where VADTipoLenguaje = 'EM' and VARCodigo = 'TRPFase' and VAVClave = T.TipoFase) as Fase");
                LiqConsginacion.AppendLine("from TransProd T");
                LiqConsginacion.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqConsginacion.AppendLine("inner join Dia D on T.DiaClave=D.DiaClave");
                LiqConsginacion.AppendLine("inner join Visita V on T.VisitaClave=V.VisitaClave");
                LiqConsginacion.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave");
                LiqConsginacion.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqConsginacion.AppendLine("where T.Tipo in (8) and T.TipoFase in(0) ");
                LiqConsginacion.AppendLine(" and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID ");
                LiqConsginacion.AppendLine("UNION ALL");
                LiqConsginacion.AppendLine("--RepartoFactura");
                LiqConsginacion.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqConsginacion.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqConsginacion.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqConsginacion.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqConsginacion.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqConsginacion.AppendLine("from TransProdDetalle TD");
                LiqConsginacion.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                LiqConsginacion.AppendLine("where TransprodId=T.TransProdId");
                LiqConsginacion.AppendLine(") end");
                LiqConsginacion.AppendLine(") as Kilos, T.DescVendPor as Descuento,");
                LiqConsginacion.AppendLine("(select Descripcion from VAVDescripcion where VADTipoLenguaje = 'EM' and VARCodigo = 'TRPFase' and VAVClave = T.TipoFase) as Fase");
                LiqConsginacion.AppendLine("from TransProd T");
                LiqConsginacion.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqConsginacion.AppendLine("inner join Dia D on T.DiaClave1=D.DiaClave");
                LiqConsginacion.AppendLine("inner join Visita V on T.VisitaClave1=V.VisitaClave");
                LiqConsginacion.AppendLine("inner join Cliente C on V.ClienteClave=C.ClienteClave");
                LiqConsginacion.AppendLine("inner join Vendedor VD on V.VendedorID=VD.VendedorID");
                LiqConsginacion.AppendLine("where T.Tipo in (8) and T.TipoFase in(0)  ");
                LiqConsginacion.AppendLine(" and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID ");
                LiqConsginacion.AppendLine(") as LiquidacionConsigna");
                LiqConsginacion.AppendLine("order by FolioVenta,FolioFactura");
                LiqConsginacion.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqConsginacion.ToString();

                List<LiquidacionMelbrinConCre> Consignacion = Connection.Query<LiquidacionMelbrinConCre>(QueryString, null, null, true, 600).ToList();
                var SubConsignacion = (from cr in Consignacion
                                       select cr).ToList();
                List<LiquidacionMelbrinConCre> Consig = new List<LiquidacionMelbrinConCre>();
                var SCOR = (from gr in SubConsignacion group gr by new { gr.ConCreDetalle } into grupo select grupo);

                Decimal TotalConsig = 0;
                double KilosConsig = 0;

                foreach (var grupo in SCOR)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Consig.Add(new LiquidacionMelbrinConCre
                        {
                            ConCreDetalle = "VENTA A CONSIGNACIÓN",
                            FolioVenta = objetoAgrupado.FolioVenta,
                            FolioFactura = objetoAgrupado.FolioFactura,
                            FechaHoraAlta = objetoAgrupado.FechaHoraAlta,
                            ClienteClave = objetoAgrupado.ClienteClave,
                            Total = objetoAgrupado.Total,
                            Kilos = objetoAgrupado.Kilos,
                            SimboloMoneda = objetoAgrupado.SimboloMoneda
                        });
                        Consig.Last().ConCreTotal = grupo.Sum(c => c.Total);
                        Consig.Last().ConCreKilos = grupo.Sum(c => c.Kilos);
                        TotalConsig += objetoAgrupado.Total;
                        KilosConsig += objetoAgrupado.Kilos;
                    }
                }
                SubReporteConsignacion SubReporteConsig = new SubReporteConsignacion();
                SubReporteConsig.DataSource = Consig;
                //GroupHeader2
                GroupField groupConsig = new GroupField("ConCreDetalle");
                SubReporteConsig.GroupHeader2.GroupFields.Add(groupCo);
                SubReporteConsig.SubCredito.DataBindings.Add("Text", SubReporteConsig.DataSource, "ConCredetalle");
                //Detalle
                SubReporteConsig.CrVenta.DataBindings.Add("Text", null, "FolioVenta");
                SubReporteConsig.CrFactura.DataBindings.Add("Text", null, "FolioFactura");
                SubReporteConsig.CrFecha.DataBindings.Add("Text", null, "FechaHoraAlta");
                SubReporteConsig.CrCliente.DataBindings.Add("Text", null, "ClienteClave");
                SubReporteConsig.CrImporte.DataBindings.Add("Text", null, "Total");
                SubReporteConsig.CrKilos.DataBindings.Add("Text", null, "Kilos");
                SubReporteConsig.CrSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                //Total
                SubReporteConsig.TCrKilos.Text = KilosConsig.ToString();
                SubReporteConsig.TCrSimbolo.Text = SMoneda;
                SubReporteConsig.TCrImporte.Text = TotalConsig.ToString("$0.00");
                report.xrSubreportConsigna.ReportSource = SubReporteConsig;
                //SubReporte-------------------------------------------------------------------------------------------------


                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Cobranza
                StringBuilder LiqCobranza = new StringBuilder();
                LiqCobranza.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR ");
                LiqCobranza.AppendLine("SET ANSI_WARNINGS OFF ");
                LiqCobranza.AppendLine("SET NOCOUNT ON ");
                LiqCobranza.AppendLine("DECLARE @FechaFiltro AS datetime, @VenID AS varchar(16) ");
                LiqCobranza.AppendLine("SET @FechaFiltro = '" + Filtro + "' ");
                LiqCobranza.AppendLine("SET @VenID  ='" + VendedorSplit + "' ");
                LiqCobranza.AppendLine("--COBRANZA");
                LiqCobranza.AppendLine("declare @PagoAutomatico AS bit ");
                LiqCobranza.AppendLine("SET @PagoAutomatico = (SELECT TOP 1 PagoAutomatico FROM ConHist (NOLOCK) WHERE CONHistFechaInicio <= @FechaFiltro ORDER BY CONHistFechaInicio desc) ");
                LiqCobranza.AppendLine("SELECT LiquidacionCobranza.FolioCobranza,LiquidacionCobranza.FolioFactura,LiquidacionCobranza.FechaFactura,LiquidacionCobranza.Cliente,LiquidacionCobranza.Total,LiquidacionCobranza.FechaCobranza, ");
                LiqCobranza.AppendLine("(SELECT Simbolo FROM Moneda (NOLOCK) WHERE MonedaID=(SELECT TOP 1 MonedaId FROM CONHist (NOLOCK) ORDER BY MFechaHora desc)) AS SimboloMoneda ");
                LiqCobranza.AppendLine("FROM ( ");
                LiqCobranza.AppendLine("SELECT A.Folio AS FolioCobranza,T.Folio AS FolioFactura,T.FechaHoraAlta AS FechaFactura,C.Clave+' - '+C.RazonSocial AS Cliente, ");
                LiqCobranza.AppendLine("AT.Importe AS Total, A.FechaCreacion AS FechaCobranza, A.ABNId AS ABNID ");
                LiqCobranza.AppendLine("FROM Abono A (NOLOCK) ");
                LiqCobranza.AppendLine("INNER JOIN ABNDetalle AD (NOLOCK) ON A.ABNId=AD.ABNId ");
                LiqCobranza.AppendLine("INNER JOIN Dia D (NOLOCK) ON A.DiaClave = D.DiaClave AND D.FechaCaptura = @FechaFiltro ");
                LiqCobranza.AppendLine("INNER JOIN AbnTrp AT (NOLOCK) ON A.ABNId = AT.ABNId ");
                LiqCobranza.AppendLine("INNER JOIN TransProd T (NOLOCK) ON AT.TransProdID = T.TransProdID AND T.CFVTipo IN (2 , CASE WHEN @PagoAutomatico = 0 THEN 1 ELSE 2 END) ");
                LiqCobranza.AppendLine("INNER JOIN Visita V (NOLOCK) ON A.VisitaClave = V.VisitaClave AND V.VendedorID = @VenID ");
                LiqCobranza.AppendLine("INNER JOIN Cliente C (NOLOCK) ON V.ClienteClave=C.ClienteClave ");
                LiqCobranza.AppendLine("UNION ");
                LiqCobranza.AppendLine("SELECT A.Folio AS FolioCobranza,T.Folio AS FolioFactura,T.FechaHoraAlta AS FechaFactura,C.Clave+' - '+C.RazonSocial AS Cliente, ");
                LiqCobranza.AppendLine("AT.Importe AS Total, A.FechaCreacion AS FechaCobranza ,A.ABNId AS ABNID ");
                LiqCobranza.AppendLine("FROM Abono A (NOLOCK) ");
                LiqCobranza.AppendLine("INNER JOIN ABNDetalle AD (NOLOCK) ON A.ABNId=AD.ABNId AND A.DiaClave=convert(varchar,convert(date,@FechaFiltro,103),103) ");
                LiqCobranza.AppendLine("INNER JOIN Dia D (NOLOCK) ON A.DiaClave=D.DiaClave ");
                LiqCobranza.AppendLine("INNER JOIN AbnTrp AT (NOLOCK) ON A.ABNId=AT.ABNId ");
                LiqCobranza.AppendLine("INNER JOIN TransProd T (NOLOCK) ON AT.TransProdID=T.TransProdID AND T.CFVTipo IN ( 2 , CASE WHEN @PagoAutomatico = 0 THEN 1 ELSE 2 END) AND T.FechaCaptura<@FechaFiltro ");
                LiqCobranza.AppendLine("INNER JOIN Visita V (NOLOCK) ON A.VisitaClave=V.VisitaClave AND V.VendedorID=@VenID ");
                LiqCobranza.AppendLine("INNER JOIN Cliente C (NOLOCK) ON V.ClienteClave=C.ClienteClave	");
                LiqCobranza.AppendLine("UNION ");
                LiqCobranza.AppendLine("SELECT AH.Folio AS FolioCobranza,T.Folio AS FolioFactura,T.FechaHoraAlta AS FechaFactura,'COBRO CANCELADO',0 AS Total,AH.FechaHoraCreacion AS FechaCobranza,AH.ABNID AS ABNID ");
                LiqCobranza.AppendLine("FROM AbonoHist AH (NOLOCK) ");
                LiqCobranza.AppendLine("INNER JOIN Dia D (NOLOCK) ON AH.DiaClave=D.DiaClave AND D.FechaCaptura=@FechaFiltro ");
                LiqCobranza.AppendLine("INNER JOIN AbnTrpHist ATH (NOLOCK) ON AH.ABNId=ATH.ABNId ");
                LiqCobranza.AppendLine("INNER JOIN TransProd T (NOLOCK) ON ATH.TransProdID=T.TransProdID AND T.CFVTipo IN ( 2 , CASE WHEN @PagoAutomatico = 0 THEN 1 ELSE 2 END) ");
                LiqCobranza.AppendLine("INNER JOIN Visita V (NOLOCK) ON AH.VisitaClave=V.VisitaClave AND V.VendedorID=@VenID ");
                LiqCobranza.AppendLine("INNER JOIN Cliente C (NOLOCK) ON V.ClienteClave=C.ClienteClave ");
                LiqCobranza.AppendLine(") AS LiquidacionCobranza ");
                LiqCobranza.AppendLine("ORDER BY FolioCobranza,FolioFactura ");
                LiqCobranza.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqCobranza.ToString();

                List<LiquidacionMelbrinCobranza> Cobranza = Connection.Query<LiquidacionMelbrinCobranza>(QueryString, null, null, true, 600).ToList();
                var SubCobranza = (from cb in Cobranza
                                   select cb).ToList();
                List<LiquidacionMelbrinCobranza> Cob = new List<LiquidacionMelbrinCobranza>();
                var SCB = (from gr in SubCobranza group gr by new { gr.CobranzaDetalle } into grupo select grupo);

                Decimal TotalCob = 0;

                foreach (var grupo in SCB)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Cob.Add(new LiquidacionMelbrinCobranza
                        {
                            CobranzaDetalle = "COBRANZA",
                            FolioCobranza = objetoAgrupado.FolioCobranza,
                            FolioFactura = objetoAgrupado.FolioFactura,
                            FechaFactura = objetoAgrupado.FechaFactura,
                            Cliente = objetoAgrupado.Cliente,
                            Total = objetoAgrupado.Total,
                            FechaCobranza = objetoAgrupado.FechaCobranza,
                            SimboloMoneda = objetoAgrupado.SimboloMoneda
                        });
                        Cob.Last().CobranzaTotal = grupo.Sum(c => c.Total);
                        TotalCob += objetoAgrupado.Total;
                    }
                }
                SubReporteCobranza SubReporteCob = new SubReporteCobranza();
                SubReporteCob.DataSource = Cob;
                //GroupHeader2
                GroupField groupCob = new GroupField("CobranzaDetalle");
                SubReporteCob.GroupHeader2.GroupFields.Add(groupCo);
                SubReporteCob.SubCobranza.DataBindings.Add("Text", SubReporteCob.DataSource, "CobranzaDetalle");
                //Detalle
                SubReporteCob.CobCobranza.DataBindings.Add("Text", null, "FolioCobranza");
                SubReporteCob.CobFactura.DataBindings.Add("Text", null, "FolioFactura");
                SubReporteCob.CobFecha.DataBindings.Add("Text", null, "Fecha");
                SubReporteCob.CobCliente.DataBindings.Add("Text", null, "Cliente");
                SubReporteCob.CobImporte.DataBindings.Add("Text", null, "Total");
                SubReporteCob.CobSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteCob.CobFechaPago.DataBindings.Add("Text", null, "FechaCobranza");
                //Total
                SubReporteCob.TCobSimbolo.Text = SMoneda;
                SubReporteCob.TCobImporte.Text = TotalCob.ToString("$0.00");
                report.xrSubreportCobranza.ReportSource = SubReporteCob;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Monedas
                StringBuilder LiqMonedas = new StringBuilder();
                LiqMonedas.AppendLine("SET ANSI_WARNINGS OFF");
                LiqMonedas.AppendLine("SET NOCOUNT ON ");
                LiqMonedas.AppendLine("--PLANTILLA DESGLOSE Monedas ");
                LiqMonedas.AppendLine("SELECT Monedas=VD.Descripcion, ");
                LiqMonedas.AppendLine("'=   '+(SELECT Simbolo FROM Moneda (NOLOCK) WHERE MonedaID=(SELECT TOP 1 MonedaId FROM CONHist (NOLOCK) ORDER BY MFechaHora desc)) AS SimboloMoneda ");
                LiqMonedas.AppendLine("FROM VARValor V (NOLOCK) ");
                LiqMonedas.AppendLine("INNER JOIN VAVDescripcion VD (NOLOCK) ON V.VARCodigo=VD.VARCodigo AND V.VAVClave=VD.VAVClave ");
                LiqMonedas.AppendLine("WHERE V.VARCodigo='DENOMINA' AND V.Grupo=2 AND VD.VADTipoLenguaje=(SELECT dbo.FNObtenerLenguaje()) ");
                LiqMonedas.AppendLine("ORDER BY cast(VD.Descripcion AS float) asc ");
                LiqMonedas.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqMonedas.ToString();

                List<LiquidacionMelbrinMonBil> Monedas = Connection.Query<LiquidacionMelbrinMonBil>(QueryString, null, null, true, 600).ToList();

                SubReporteMonedas SubReporteMon = new SubReporteMonedas();
                SubReporteMon.DataSource = Monedas;

                SubReporteMon.MMoneda.DataBindings.Add("Text", null, "Monedas");
                SubReporteMon.MSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");

                report.xrSubreportMonedas.ReportSource = SubReporteMon;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Billetes
                StringBuilder LiqBilletes = new StringBuilder();
                LiqBilletes.AppendLine("SET ANSI_WARNINGS OFF ");
                LiqBilletes.AppendLine("SET NOCOUNT ON ");
                LiqBilletes.AppendLine("--PLANTILLA DESGLOSE Monedas ");
                LiqBilletes.AppendLine("SELECT Billetes=VD.Descripcion, ");
                LiqBilletes.AppendLine("'=   '+(SELECT Simbolo FROM Moneda (NOLOCK) WHERE MonedaID=(SELECT TOP 1 MonedaId FROM CONHist (NOLOCK) ORDER BY MFechaHora desc)) AS SimboloMoneda");
                LiqBilletes.AppendLine("FROM VARValor V (NOLOCK) ");
                LiqBilletes.AppendLine("INNER JOIN VAVDescripcion VD ON V.VARCodigo=VD.VARCodigo AND V.VAVClave=VD.VAVClave ");
                LiqBilletes.AppendLine("WHERE V.VARCodigo='DENOMINA' AND V.Grupo=1 AND VD.VADTipoLenguaje=(SELECT dbo.FNObtenerLenguaje()) ");
                LiqBilletes.AppendLine("ORDER BY cast(VD.Descripcion AS float) asc ");
                LiqBilletes.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqBilletes.ToString();

                List<LiquidacionMelbrinMonBil> Billetes = Connection.Query<LiquidacionMelbrinMonBil>(QueryString, null, null, true, 600).ToList();

                SubReporteBilletes SubReporteBil = new SubReporteBilletes();
                SubReporteBil.DataSource = Billetes;

                SubReporteBil.BBillete.DataBindings.Add("Text", null, "Billetes");
                SubReporteBil.BSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");

                report.xrSubreportBilletes.ReportSource = SubReporteBil;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Desglose
                StringBuilder DetalleCobranza = new StringBuilder();
                DetalleCobranza.AppendLine("SET ANSI_WARNINGS OFF ");
                DetalleCobranza.AppendLine("SET NOCOUNT ON ");
                DetalleCobranza.AppendLine("DECLARE @FechaFiltro AS datetime, @VenID AS varchar(16) ");
                DetalleCobranza.AppendLine("SET @FechaFiltro = '" + Filtro + "' ");
                DetalleCobranza.AppendLine("SET @VenID  ='" + VendedorSplit + "' ");
                DetalleCobranza.AppendLine("--DETALLE DE COBRANZA ");
                DetalleCobranza.AppendLine("SELECT VD.Descripcion DescripcionTipo,VD2.Descripcion AS DescripcionBanco,AD.Referencia,AD.FechaCheque,AD.Importe AS Importe, ");
                DetalleCobranza.AppendLine("(SELECT Simbolo FROM Moneda (NOLOCK) WHERE MonedaID=(SELECT TOP 1 MonedaId FROM CONHist (NOLOCK) ORDER BY MFechaHora desc)) AS SimboloMoneda ");
                DetalleCobranza.AppendLine("FROM Abono A (NOLOCK) ");
                DetalleCobranza.AppendLine("INNER JOIN Dia D (NOLOCK) ON A.DiaClave=D.DiaClave ");
                DetalleCobranza.AppendLine("INNER JOIN ABNDetalle AD (NOLOCK) ON A.ABNId=AD.ABNId ");
                DetalleCobranza.AppendLine("INNER JOIN Visita V (NOLOCK) ON A.VisitaClave=V.VisitaClave ");
                DetalleCobranza.AppendLine("INNER JOIN Cliente C (NOLOCK) ON V.ClienteClave=C.ClienteClave ");
                DetalleCobranza.AppendLine("INNER JOIN VAVDescripcion VD (NOLOCK) ON VD.VARCodigo='PAGO' AND VD.VADTipoLenguaje=(SELECT dbo.FNObtenerLenguaje()) AND AD.TipoPago=Vd.VAVClave ");
                DetalleCobranza.AppendLine("left join VAVDescripcion VD2 (NOLOCK) ON VD2.VARCodigo='TBANCO' AND VD2.VADTipoLenguaje=(SELECT dbo.FNObtenerLenguaje()) AND AD.TipoBanco=VD2.VAVClave ");
                DetalleCobranza.AppendLine("where(AD.TipoPago <> 1) AND ");
                DetalleCobranza.AppendLine("A.ABNId IN ( ");
                DetalleCobranza.AppendLine("SELECT * ");
                DetalleCobranza.AppendLine("FROM ( ");
                DetalleCobranza.AppendLine("SELECT A.AbnId ");
                DetalleCobranza.AppendLine("FROM Abono A (NOLOCK) ");
                DetalleCobranza.AppendLine("INNER JOIN ABNDetalle AD (NOLOCK) ON A.ABNId=AD.ABNId ");
                DetalleCobranza.AppendLine("INNER JOIN Dia D (NOLOCK) ON A.DiaClave=D.DiaClave ");
                DetalleCobranza.AppendLine("INNER JOIN AbnTrp AT (NOLOCK) ON A.ABNId=AT.ABNId ");
                DetalleCobranza.AppendLine("INNER JOIN TransProd T (NOLOCK) ON AT.TransProdID=T.TransProdID ");
                DetalleCobranza.AppendLine("INNER JOIN Visita V (NOLOCK) ON A.VisitaClave=V.VisitaClave ");
                DetalleCobranza.AppendLine("INNER JOIN Cliente C (NOLOCK) ON V.ClienteClave=C.ClienteClave ");
                DetalleCobranza.AppendLine("WHERE T.CFVTipo in(1,2) AND D.FechaCaptura=@FechaFiltro ");
                DetalleCobranza.AppendLine("AND V.VendedorID=@VenID ");
                DetalleCobranza.AppendLine("UNION ");
                DetalleCobranza.AppendLine("SELECT A.AbnId ");
                DetalleCobranza.AppendLine("FROM Abono A (NOLOCK) ");
                DetalleCobranza.AppendLine("INNER JOIN ABNDetalle AD (NOLOCK) ON A.ABNId=AD.ABNId ");
                DetalleCobranza.AppendLine("INNER JOIN Dia D (NOLOCK) ON A.DiaClave=D.DiaClave ");
                DetalleCobranza.AppendLine("INNER JOIN AbnTrp AT (NOLOCK) ON A.ABNId=AT.ABNId ");
                DetalleCobranza.AppendLine("INNER JOIN TransProd T (NOLOCK) ON AT.TransProdID=T.TransProdID ");
                DetalleCobranza.AppendLine("INNER JOIN Visita V (NOLOCK) ON A.VisitaClave=V.VisitaClave ");
                DetalleCobranza.AppendLine("INNER JOIN Cliente C (NOLOCK) ON V.ClienteClave=C.ClienteClave ");
                DetalleCobranza.AppendLine("WHERE T.CFVTipo in(1,2) AND A.DiaClave=convert(varchar,convert(date,@FechaFiltro,103),103) AND T.FechaCaptura<@FechaFiltro ");
                DetalleCobranza.AppendLine("AND V.VendedorID=@VenID ");
                DetalleCobranza.AppendLine(") AS LiquidacionCobranza) ");
                DetalleCobranza.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = DetalleCobranza.ToString();

                List<LiquidacionMelbrinDesglose> Desglose = Connection.Query<LiquidacionMelbrinDesglose>(QueryString, null, null, true, 600).ToList();
                int Repeat = Monedas.Count + Billetes.Count + 2;

                if (Desglose.Count == 0)
                {
                    for (int i = 0; i < Repeat; i++)
                    {
                        Desglose.Add(new LiquidacionMelbrinDesglose
                        {
                            DescripcionTipo = "",
                            DescripcionBanco = "",
                            Referencia = "",
                            FechaCheque = "",
                            SimboloMoneda = ""
                        });
                    }
                }
                SubReporteDesglose SubReporteDes = new SubReporteDesglose();
                SubReporteDes.DataSource = Desglose;

                SubReporteDes.DTipo.DataBindings.Add("Text", null, "DescripcionTipo");
                SubReporteDes.DBanco.DataBindings.Add("Text", null, "DescripcionBanco");
                SubReporteDes.DReferencia.DataBindings.Add("Text", null, "Referencia");
                SubReporteDes.DFecha.DataBindings.Add("Text", null, "FechaCheque");
                SubReporteDes.DImporte.DataBindings.Add("Text", null, "SimboloMoneda");

                report.xrSubreportDesglose.ReportSource = SubReporteDes;

                //SubReporte-------------------------------------------------------------------------------------------------

                //PieInforme
                report.DSimbolo.Text = "=" + SMoneda;
                report.TDSimbolo.Text = "=" + SMoneda;
                report.GDSimbolo.Text = "=" + SMoneda;

                report.PSimbolo.Text = SMoneda;
                report.PTotal.Text = Total.ToString("$0.00");
                report.CoSimbolo.Text = SMoneda;
                report.CoTotal.Text = TotalCon.ToString("$0.00");
                report.CrSimbolo.Text = SMoneda;
                report.CrTotal.Text = TotalCre.ToString("$0.00");
                report.conSimbolo.Text = SMoneda;
                report.ConTotal.Text = TotalConsig.ToString("$0.00");
                report.CobSimbolo.Text = SMoneda;
                report.CobTotal.Text = TotalCob.ToString("$0.00");
                report.LiqSimbolo.Text = SMoneda;
                report.LiqTotal.Text = (Total - TotalCon - TotalCre + TotalCob).ToString("$0.00");
                report.TKilos.Text = (KilosCon + KilosCre).ToString("0.00");
                report.TKilosCon.Text = KilosConsig.ToString("0.00");


                //Regresa el reporte completo
                if (Pro.Count == 0 && Con.Count == 0 && Cre.Count == 0 && Cob.Count == 0)
                {
                    return null;
                }
                else
                {
                    return report;
                }
            }
            catch (Exception ex)
            {
                return new ReporteLiquidacionMelbrin();
            }
        }

    }

    class LiquidacionMelbrinDetalleVModel
    {
        public string VendedorDetalle { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
    }

    class LiquidacionMelbrinGenericoModel
    {
        public string VendedorID { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public long InventarioInicial { get; set; }
        public long Recarga { get; set; }
        public long Devolucion { get; set; }
        public long Promocion { get; set; }
        public long Descarga { get; set; }
        public long Venta { get; set; }
        public long Consignacion { get; set; }
        public long InventarioFinal { get; set; }
        public string SimboloMoneda { get; set; }
        public Decimal Importe { get; set; }
        public Decimal ImporteTotal { get; set; }
    }

    class LiquidacionMelbrinConCre
    {
        public string ConCreDetalle { get; set; }
        public string FolioVenta { get; set; }
        public string FolioFactura { get; set; }
        public string FechaHoraAlta { get; set; }
        public string ClienteClave { get; set; }
        public Decimal Total { get; set; }
        public long Kilos { get; set; }
        public string SimboloMoneda { get; set; }
        public Decimal ConCreTotal { get; set; }
        public double ConCreKilos { get; set; }
    }

    class LiquidacionMelbrinCobranza
    {
        public string CobranzaDetalle { get; set; }
        public string FolioCobranza { get; set; }
        public string FolioFactura { get; set; }
        public string FechaFactura { get; set; }
        public string Cliente { get; set; }
        public Decimal Total { get; set; }
        public string FechaCobranza { get; set; }
        public string SimboloMoneda { get; set; }
        public Decimal CobranzaTotal { get; set; }
    }

    class LiquidacionMelbrinMonBil
    {
        public string MonBilDetalle { get; set; }
        public string Monedas { get; set; }
        public string Billetes { get; set; }
        public string SimboloMoneda { get; set; }

    }

    class LiquidacionMelbrinDesglose
    {
        public string DescripcionTipo { get; set; }
        public string DescripcionBanco { get; set; }
        public string Referencia { get; set; }
        public string FechaCheque { get; set; }
        public Decimal Importe { get; set; }
        public string SimboloMoneda { get; set; }

    }
}