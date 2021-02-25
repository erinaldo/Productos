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
    public class LiquidacionAfrima
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        ReporteLiquidacionAfrima report = new ReporteLiquidacionAfrima();

        public XtraReport GetReport(int VAVClave, string nombreReport, string pvCondicion, string VendedorSplit, string FechaInicial, string Cedis, string nombreCedis)
        {
            try
            {
                //Logo Empresa
                string LogoQuery = "Select Logotipo from Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.xrPictureBox1.Image = Image.FromStream(mStream);
                report.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                //Vendedor
                //Obtener Detalle
                StringBuilder VenDetalle = new StringBuilder();
                VenDetalle.AppendLine("Set ANSI_WARNINGS OFF ");
                VenDetalle.AppendLine("Set nocount on ");
                VenDetalle.AppendLine("select V.VendedorID + ' - ' + V.Nombre as VendedorDetalle, A.Clave as ClaveAlmacen,A.Nombre,A.Domicilio,A.Telefono,U.Clave as ClaveAlmacenABordo ");
                VenDetalle.AppendLine("from VENCentroDistHist VDH (NOLOCK) ");
                VenDetalle.AppendLine("inner join Almacen A (NOLOCK) on VDH.AlmacenId=A.AlmacenID ");
                VenDetalle.AppendLine("inner join Vendedor V (NOLOCK) on V.VendedorID=VDH.VendedorID ");
                VenDetalle.AppendLine("inner join Usuario U (NOLOCK) on V.USUId=U.USUId ");
                VenDetalle.AppendLine(pvCondicion);

                QueryString = "";
                QueryString = VenDetalle.ToString();

                List<LiquidacionAfrimaDetalleVModel> VDetalle = Connection.Query<LiquidacionAfrimaDetalleVModel>(QueryString, null, null, true, 600).ToList();

                var VDet = (from VD in VDetalle select VD).ToList().GroupBy(VDD => new { VDD.VendedorDetalle })
                        .SelectMany(VDL => VDL.Select(VDS => new LiquidacionAfrimaDetalleVModel
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
                LiqProducto.AppendLine("Set ANSI_WARNINGS OFF ");
                LiqProducto.AppendLine("Set nocount on ");
                LiqProducto.AppendLine("DECLARE @FechaFiltro as datetime, @VenID as varchar(16) ");
                LiqProducto.AppendLine("set @FechaFiltro = '" + Filtro + "' ");
                LiqProducto.AppendLine("set @VenID  ='" + VendedorSplit + "' ");
                LiqProducto.AppendLine("if (select object_id('tempdb..#TmpUltimoInventarioABordo')) is not null drop table #TmpUltimoInventarioABordo ");
                LiqProducto.AppendLine("Begin ");
                LiqProducto.AppendLine("select * into #TmpUltimoInventarioABordo ");
                LiqProducto.AppendLine("from ( ");
                LiqProducto.AppendLine("select top 1 VD.VendedorID,T.FechaCaptura,FechaHoraAlta,TransProdID ");
                LiqProducto.AppendLine("from TransProd T (NOLOCK) ");
                LiqProducto.AppendLine("inner join Vendedor VD (NOLOCK) on T.MUsuarioID=VD.USUId ");
                LiqProducto.AppendLine("where T.Tipo in (23) and T.TipoFase<>0 and T.FechaCaptura<@FechaFiltro and VD.VendedorID=@VenID ");
                LiqProducto.AppendLine("group by VD.VendedorID,T.FechaCaptura,FechaHoraAlta,TransProdID ");
                LiqProducto.AppendLine("order by T.FechaHoraAlta desc ");
                LiqProducto.AppendLine(") as UltimoInventarioABordo ");
                LiqProducto.AppendLine("End ");
                LiqProducto.AppendLine("--OBTIENE PRIMERA CARGA DEL VENDEDOR ");
                LiqProducto.AppendLine("if (select object_id('tempdb..#TmpPrimeraCarga')) is not null drop table #TmpPrimeraCarga ");
                LiqProducto.AppendLine("begin ");
                LiqProducto.AppendLine("select * into #TmpPrimeraCarga from( ");
                LiqProducto.AppendLine("select VD.VendedorID,D.FechaCaptura,(min(T.FechaHoraAlta)) as FechaHoraPrimeraCarga, '1' as TipoCarga ");
                LiqProducto.AppendLine("from TransProd T (NOLOCK) ");
                LiqProducto.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave ");
                LiqProducto.AppendLine("inner join Vendedor VD (NOLOCK) on T.MUsuarioID=VD.USUId ");
                LiqProducto.AppendLine("where T.Tipo in (2) and T.TipoFase<>0 and D.FechaCaptura=@FechaFiltro and VD.VendedorID=@VenID ");
                LiqProducto.AppendLine("group by VD.VendedorID,D.FechaCaptura ");
                LiqProducto.AppendLine(") as PrimeraCarga ");
                LiqProducto.AppendLine("end ");
                LiqProducto.AppendLine("--DETALLE PRODUCTOS ");
                LiqProducto.AppendLine("select VendedorID,NombreVendedor,DiaClave,ProductoClave as Clave,NombreProducto as Descripcion,sum(Inventarioinicial) as InventarioInicial, ");
                LiqProducto.AppendLine("sum(Recarga) as Recarga, sum(Descarga) as Descarga, sum(DevolucionCte) as Devolucion, sum(Venta) as Venta, sum(DesProd + DesCliPor + DesVendPor ) + sum(Diferencia) as Promocion, ");
                LiqProducto.AppendLine("sum((Subtotal) + (Impuesto - DesCliPorImp)) as Importe, ");
                LiqProducto.AppendLine("(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda ");
                LiqProducto.AppendLine("from ( ");
                LiqProducto.AppendLine("--VentaDirecta ");
                LiqProducto.AppendLine("select V.VendedorID,VD.Nombre as NombreVendedor,D.DiaClave,TD.ProductoClave,P.Nombre as NombreProducto, ");
                LiqProducto.AppendLine("InventarioInicial=0, ");
                LiqProducto.AppendLine("Recarga=0, ");
                LiqProducto.AppendLine("DevolucionCte=0, ");
                LiqProducto.AppendLine("Promocion=(select case when T.Tipo=1 and isnull(TD.Promocion,0)=2 then TD.Cantidad * PD.Factor else 0 end), ");
                LiqProducto.AppendLine("Descarga=0, DesProd = TD.DescuentoImp, Diferencia = (PPV.Precio - TD.Precio) * TD.Cantidad,");
                LiqProducto.AppendLine("Venta=(select case when T.Tipo=1 and isnull(TD.Promocion,0)<>2 then TD.Cantidad * PD.Factor else 0 end), ");
                LiqProducto.AppendLine("SubTotal=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal else 0 end), ");
                LiqProducto.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD (NOLOCK) where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                LiqProducto.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD (NOLOCK) where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100, ");
                LiqProducto.AppendLine("Impuesto=(select case when T.Tipo=1 and TD.Total>0 then (select case when TD.Impuesto is null then 0 else TD.Impuesto end) else 0 end), ");
                LiqProducto.AppendLine("DesCliPorImp=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD (NOLOCK) where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end) ");
                LiqProducto.AppendLine("from TransProd T (NOLOCK) ");
                LiqProducto.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave ");
                LiqProducto.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave ");
                LiqProducto.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID ");
                LiqProducto.AppendLine("inner join Producto P (NOLOCK) on TD.ProductoClave=P.ProductoClave ");
                LiqProducto.AppendLine("inner join ProductoDetalle PD (NOLOCK) on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad ");
                LiqProducto.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID ");
                LiqProducto.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad ");
                LiqProducto.AppendLine("where T.Tipo in (1) and T.TipoFase not in(0,1,7) and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID ");
                LiqProducto.AppendLine("UNION ALL ");
                LiqProducto.AppendLine("--Reparto ");
                LiqProducto.AppendLine("select V.VendedorID,VD.Nombre,D.DiaClave,TD.ProductoClave,P.Nombre, ");
                LiqProducto.AppendLine("InventarioInicial=0, ");
                LiqProducto.AppendLine("Recarga=0, ");
                LiqProducto.AppendLine("DevolucionCte=0, ");
                LiqProducto.AppendLine("Promocion=(select case when T.Tipo=1 and isnull(TD.Promocion,0)=2 then TD.Cantidad * PD.Factor else 0 end), ");
                LiqProducto.AppendLine("Descarga=0, DesProd = TD.DescuentoImp, Diferencia = (PPV.Precio - TD.Precio) * TD.Cantidad,");
                LiqProducto.AppendLine("Venta=(select case when T.Tipo=1 and isnull(TD.Promocion,0)<>2 then TD.Cantidad * PD.Factor else 0 end), ");
                LiqProducto.AppendLine("SubTotal=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal else 0 end), ");
                LiqProducto.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD (NOLOCK) where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                LiqProducto.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD (NOLOCK) where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100, ");
                LiqProducto.AppendLine("Impuesto=(select case when T.Tipo=1 and TD.Total>0 then (select case when TD.Impuesto is null then 0 else TD.Impuesto end) else 0 end), ");
                LiqProducto.AppendLine("DesCliPorImp=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD (NOLOCK) where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end) ");
                LiqProducto.AppendLine("from TransProd T (NOLOCK)");
                LiqProducto.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave1=D.DiaClave ");
                LiqProducto.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave1=V.VisitaClave ");
                LiqProducto.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID ");
                LiqProducto.AppendLine("inner join Producto P (NOLOCK) on TD.ProductoClave=P.ProductoClave ");
                LiqProducto.AppendLine("inner join ProductoDetalle PD (NOLOCK) on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad ");
                LiqProducto.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID ");
                LiqProducto.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad ");
                LiqProducto.AppendLine("where T.Tipo in (1) and T.TipoFase not in(0,1,7) and D.FechaCaptura=@FechaFiltro and V.VendedorID=@VenID ");
                LiqProducto.AppendLine("UNION ALL ");
                LiqProducto.AppendLine("--PRIMERA CARGA, RECARGAS, DEVOLUCIONES DE CLIENTE Y DESCARGAS ");
                LiqProducto.AppendLine("select ");
                LiqProducto.AppendLine("VD.VendedorID,VD.Nombre as NombreVendedor,D.DiaClave,TD.ProductoClave,P.Nombre as NombreProducto, ");
                LiqProducto.AppendLine("InventarioInicial=(select case when PC.TipoCarga=1 then TD.Cantidad * PD.Factor else 0 end), ");
                LiqProducto.AppendLine("Recarga=(select case when T.Tipo=2 and PC.TipoCarga is null then TD.Cantidad * PD.Factor else 0 end), ");
                LiqProducto.AppendLine("DevolucionCte=(select case when T.Tipo=4 then TD.Cantidad * PD.Factor else 0 end), ");
                LiqProducto.AppendLine("Promocion=0, ");
                LiqProducto.AppendLine("Descarga=(select case when T.Tipo=7 then TD.Cantidad * PD.Factor else 0 end), DesProd = 0, Diferencia = 0,");
                LiqProducto.AppendLine("Venta=0, ");
                LiqProducto.AppendLine("SubTotal=0, ");
                LiqProducto.AppendLine("DesCliPor=0, ");
                LiqProducto.AppendLine("DesVendPor=0, ");
                LiqProducto.AppendLine("Impuesto=0, ");
                LiqProducto.AppendLine("DesCliPorImp=0 ");
                LiqProducto.AppendLine("from TransProd T (NOLOCK) ");
                LiqProducto.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave ");
                LiqProducto.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID ");
                LiqProducto.AppendLine("inner join Producto P (NOLOCK) on TD.ProductoClave=P.ProductoClave ");
                LiqProducto.AppendLine("inner join ProductoDetalle PD (NOLOCK) on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad ");
                LiqProducto.AppendLine("inner join Vendedor VD (NOLOCK) on T.MUsuarioID=VD.USUId ");
                LiqProducto.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad ");
                LiqProducto.AppendLine("left join #TmpPrimeraCarga PC (NOLOCK) on VD.VendedorID=PC.VendedorID and T.FechaHoraAlta=PC.FechaHoraPrimeraCarga ");
                LiqProducto.AppendLine("where T.Tipo in (2,3,4,7) and T.TipoFase<>0 and D.FechaCaptura=@FechaFiltro and VD.VendedorId=@VenID ");
                LiqProducto.AppendLine("UNION ALL ");
                LiqProducto.AppendLine("--ULTIMO INVENTARIO A BORDO ");
                LiqProducto.AppendLine("select TUA.VendedorID,VD.Nombre as NombreVendedor, ");
                LiqProducto.AppendLine("'" + FCaptura + "' " );
                LiqProducto.AppendLine(",TD.ProductoClave,P.Nombre as NombreProducto, ");
                LiqProducto.AppendLine("InventarioInicial=(select TD.Cantidad * PD.Factor), ");
                LiqProducto.AppendLine("Recarga=0, ");
                LiqProducto.AppendLine("DevolucionCte=0, ");
                LiqProducto.AppendLine("Promocion=0, ");
                LiqProducto.AppendLine("Descarga=0, DesProd = 0, Diferencia = 0,");
                LiqProducto.AppendLine("Venta=0, ");
                LiqProducto.AppendLine("SubTotal=0, ");
                LiqProducto.AppendLine("DesCliPor=0, ");
                LiqProducto.AppendLine("DesVendPor=0, ");
                LiqProducto.AppendLine("Impuesto=0, ");
                LiqProducto.AppendLine("DesCliPorImp = 0 ");
                LiqProducto.AppendLine("from #TmpUltimoInventarioABordo TUA ");
                LiqProducto.AppendLine("inner join TransProdDetalle TD on TUA.TransProdID=TD.TransProdID ");
                LiqProducto.AppendLine("inner join Producto P on TD.ProductoClave=P.ProductoClave ");
                LiqProducto.AppendLine("inner join ProductoDetalle PD on TD.ProductoClave=PD.ProductoClave and TD.ProductoClave=PD.ProductoDetClave and TD.TipoUnidad=PD.PRUTipoUnidad ");
                LiqProducto.AppendLine("inner join Vendedor VD on TUA.VendedorID=VD.VendedorID ");
                LiqProducto.AppendLine(") as LiquidacionProductos ");
                LiqProducto.AppendLine("group by VendedorID,NombreVendedor,DiaClave,ProductoClave,NombreProducto ");
                LiqProducto.AppendLine("order by ProductoClave");
                LiqProducto.AppendLine("drop table #TmpPrimeraCarga ");
                LiqProducto.AppendLine("drop table #TmpUltimoInventarioABordo ");
                LiqProducto.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqProducto.ToString();

                List<LiquidacionAfrimaGenericoModel> Productos = Connection.Query<LiquidacionAfrimaGenericoModel>(QueryString, null, null, true, 600).ToList();
                var SubLiqProductos = (from p in Productos
                                   select p).ToList();
                List<LiquidacionAfrimaGenericoModel> Pro = new List<LiquidacionAfrimaGenericoModel>();
                var SLQ = (from gr in SubLiqProductos group gr by new { gr.VendedorID } into grupo select grupo);

                Decimal Total = 0;
                string SMoneda = "";

                foreach (var grupo in SLQ)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Pro.Add(new LiquidacionAfrimaGenericoModel
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
                            InventarioFinal = (objetoAgrupado.InventarioInicial + objetoAgrupado.Recarga) - (objetoAgrupado.Descarga + objetoAgrupado.Venta + objetoAgrupado.Devolucion),
                            SimboloMoneda = objetoAgrupado.SimboloMoneda,
                            Importe = objetoAgrupado.Importe,
                            SubImporte = objetoAgrupado.Promocion + objetoAgrupado.Importe
                        });
                        Pro.Last().ImporteTotal = grupo.Sum(c => c.Importe);
                        Total += objetoAgrupado.Importe;
                        SMoneda = objetoAgrupado.SimboloMoneda;
                    }
                }

                SubReporteProductosA SubReporteP = new SubReporteProductosA();
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
                SubReporteP.PPromocion.DataBindings.Add("Text", null, "Promocion", "{0:0.00}");
                SubReporteP.PDescarga.DataBindings.Add("Text", null, "Descarga");
                SubReporteP.PVentas.DataBindings.Add("Text", null, "Venta");
                SubReporteP.PFinal.DataBindings.Add("Text", null, "InventarioFinal");
                SubReporteP.PSubtotal.DataBindings.Add("Text", null, "SubImporte", "{0:0.00}");
                SubReporteP.PSSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteP.PPSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteP.PSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteP.PImporte.DataBindings.Add("Text", null, "Importe", "{0:0.00}");
                if (Pro.Count > 0)
                {
                    report.xrSubreportProducto.ReportSource = SubReporteP;
                }
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Contado
                StringBuilder LiqContado = new StringBuilder();
                LiqContado.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR ");
                LiqContado.AppendLine("Set ANSI_WARNINGS OFF ");
                LiqContado.AppendLine("Set nocount on ");
                LiqContado.AppendLine("DECLARE @FechaFiltro as datetime, @VenID as varchar(16) ");
                LiqContado.AppendLine("set @FechaFiltro = '" + Filtro + "' ");
                LiqContado.AppendLine("set @VenID  ='" + VendedorSplit + "' ");
                LiqContado.AppendLine("select distinct *, ");
                LiqContado.AppendLine("(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda ");
                LiqContado.AppendLine("from ( ");
                LiqContado.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta, ");
                LiqContado.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end), ");
                LiqContado.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end), ");
                LiqContado.AppendLine("Diferencia =sum((PPV.Precio - TD.Precio) * TD.Cantidad),  ");
                LiqContado.AppendLine("DesProd = sum(TD.DescuentoImp),");
                //LiqContado.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                //LiqContado.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqContado.AppendLine("DesCliPor = 0, ");
                LiqContado.AppendLine("DesVendPor=0,");
                LiqContado.AppendLine("(select case when T.TipoFase=0 then 0 else ( ");
                LiqContado.AppendLine("select sum(TD.Cantidad*PU.KgLts) ");
                LiqContado.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                LiqContado.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad and TransprodId=T.TransProdId ");
                LiqContado.AppendLine(") end ");
                LiqContado.AppendLine(") as Kilos ");
                LiqContado.AppendLine("from TransProd T (NOLOCK) ");
                LiqContado.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID");
                LiqContado.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro and T.Tipo in (1) and T.CFVTipo=1 and T.TipoFase not in(1,7)");
                LiqContado.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave ");
                LiqContado.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqContado.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID and V.VendedorID=@VenID ");
                LiqContado.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID ");
                LiqContado.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad");
                LiqContado.AppendLine("group by T.Folio, T2.Folio, T.FechaHoraAlta, T.TipoFase, C.Clave, C.RazonSocial, T.Total, T.TransprodID ");
                LiqContado.AppendLine("UNION ALL ");
                LiqContado.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta, ");
                LiqContado.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end), ");
                LiqContado.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end), ");
                LiqContado.AppendLine("Diferencia = sum((PPV.Precio - TD.Precio) * TD.Cantidad), ");
                LiqContado.AppendLine("DesProd = sum(TD.DescuentoImp),");
                //LiqContado.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                LiqContado.AppendLine("DesCliPor = 0, ");
                LiqContado.AppendLine("DesVendPor=0,");
                //LiqContado.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqContado.AppendLine("(select case when T.TipoFase=0 then 0 else ( ");
                LiqContado.AppendLine("select sum(TD.Cantidad*PU.KgLts) ");
                LiqContado.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                LiqContado.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad and TransprodId=T.TransProdId ");
                LiqContado.AppendLine(") end ");
                LiqContado.AppendLine(") as Kilos ");
                LiqContado.AppendLine("from TransProd T (NOLOCK) ");
                LiqContado.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID");
                LiqContado.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro and T.Tipo in (8) and T.CFVTipo=1 and T.TipoFase in(0)");
                LiqContado.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave ");
                LiqContado.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqContado.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID and V.VendedorID=@VenID ");
                LiqContado.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID ");
                LiqContado.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad");
                LiqContado.AppendLine("group by T.Folio, T.FechaHoraAlta, T.TipoFase, C.Clave, C.RazonSocial, T.Total, T.TransprodID, TD.TransProdDetalleID, T.Tipo, TD.Total, TD.Subtotal, T.DescVendPor ");
                LiqContado.AppendLine("UNION ALL ");
                LiqContado.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta, ");
                LiqContado.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end), ");
                LiqContado.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end), ");
                LiqContado.AppendLine("Diferencia = sum((PPV.Precio - TD.Precio) * TD.Cantidad), ");
                LiqContado.AppendLine("DesProd = sum(TD.DescuentoImp),");
                //LiqContado.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                //LiqContado.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqContado.AppendLine("DesCliPor = 0, ");
                LiqContado.AppendLine("DesVendPor=0,");
                LiqContado.AppendLine("(select case when T.TipoFase=0 then 0 else ( ");
                LiqContado.AppendLine("select sum(TD.Cantidad*PU.KgLts) ");
                LiqContado.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                LiqContado.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad and TransprodId=T.TransProdId ");
                LiqContado.AppendLine(") end ");
                LiqContado.AppendLine(") as Kilos ");
                LiqContado.AppendLine("from TransProd T (NOLOCK) ");
                LiqContado.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID");
                LiqContado.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro and T.Tipo in (1) and T.CFVTipo=1 and T.TipoFase not in(1,7) ");
                LiqContado.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave");
                LiqContado.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqContado.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID and V.VendedorID=@VenID ");
                LiqContado.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID ");
                LiqContado.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad");
                LiqContado.AppendLine("group by T.Folio, T2.Folio, T.FechaHoraAlta, T.TipoFase, C.Clave, C.RazonSocial, T.Total, T.TransprodID ");
                LiqContado.AppendLine("UNION ALL ");
                LiqContado.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta, ");
                LiqContado.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end), ");
                LiqContado.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end), ");
                LiqContado.AppendLine("Diferencia = sum((PPV.Precio - TD.Precio) * TD.Cantidad),  ");
                LiqContado.AppendLine("DesProd = sum(TD.DescuentoImp),");
                //LiqContado.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                //LiqContado.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100, ");
                LiqContado.AppendLine("DesCliPor = 0, ");
                LiqContado.AppendLine("DesVendPor=0,");
                LiqContado.AppendLine("(select case when T.TipoFase=0 then 0 else ( ");
                LiqContado.AppendLine("select sum(TD.Cantidad*PU.KgLts) ");
                LiqContado.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                LiqContado.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad and TransprodId=T.TransProdId ");
                LiqContado.AppendLine(") end ");
                LiqContado.AppendLine(") as Kilos ");
                LiqContado.AppendLine("from TransProd T (NOLOCK) ");
                LiqContado.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID");
                LiqContado.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro  and T.Tipo in (8) and T.CFVTipo=1 and T.TipoFase in(0) ");
                LiqContado.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave ");
                LiqContado.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqContado.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID and V.VendedorID=@VenID ");
                LiqContado.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqContado.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad");
                LiqContado.AppendLine("group by T.Folio, T.FechaHoraAlta, T.TipoFase, C.Clave, C.RazonSocial, T.Total, T.TransprodID");
                LiqContado.AppendLine(") as LiquidacionContado ");
                LiqContado.AppendLine("order by FolioVenta,FolioFactura ");
                LiqContado.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqContado.ToString();

                List<LiquidacionAfrimaConCre> Contado = Connection.Query<LiquidacionAfrimaConCre>(QueryString, null, null, true, 600).ToList();
                var SubContado = (from co in Contado
                                       select co).ToList();
                List<LiquidacionAfrimaConCre> Con = new List<LiquidacionAfrimaConCre>();
                var SCO = (from gr in SubContado group gr by new { gr.ConCreDetalle } into grupo select grupo);

                Decimal TotalCon = 0;
                double KilosCon = 0;

                foreach (var grupo in SCO)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Con.Add(new LiquidacionAfrimaConCre
                        {
                            ConCreDetalle = "VENTA CONTADO",
                            FolioVenta = objetoAgrupado.FolioVenta,
                            FolioFactura = objetoAgrupado.FolioFactura,
                            FechaHoraAlta = objetoAgrupado.FechaHoraAlta,
                            ClienteClave = objetoAgrupado.ClienteClave,
                            Total = objetoAgrupado.Total,
                            Promocion = objetoAgrupado.DesProd + objetoAgrupado.DesCliPor + objetoAgrupado.DesVendPor + objetoAgrupado.Diferencia,
                            Kilos = objetoAgrupado.Kilos,
                            SimboloMoneda = objetoAgrupado.SimboloMoneda,
                            SubImporte = objetoAgrupado.DesProd + objetoAgrupado.DesCliPor + objetoAgrupado.DesVendPor + objetoAgrupado.Diferencia + objetoAgrupado.Total
                        });
                        Con.Last().ConCreTotal = grupo.Sum(c => c.Total);
                        Con.Last().ConCreKilos = grupo.Sum(c => c.Kilos);
                        TotalCon += objetoAgrupado.Total;
                        KilosCon += objetoAgrupado.Kilos;
                    }
                }

                SubReporteContadoA SubReporteCo = new SubReporteContadoA();
                SubReporteCo.DataSource = Con;
                //GroupHeader2
                GroupField groupCo = new GroupField("ConCreDetalle");
                SubReporteCo.GroupHeader2.GroupFields.Add(groupCo);
                SubReporteCo.SubContado.DataBindings.Add("Text", SubReporteCo.DataSource, "ConCreDetalle");
                //Detalle
                SubReporteCo.CoVenta.DataBindings.Add("Text", null, "FolioVenta");
                SubReporteCo.CoFecha.DataBindings.Add("Text", null, "FechaHoraAlta");
                SubReporteCo.CoCliente.DataBindings.Add("Text", null, "ClienteClave");
                SubReporteCo.PSubtotal.DataBindings.Add("Text", null, "SubImporte", "{0:0.00}");
                SubReporteCo.SSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteCo.PPromocion.DataBindings.Add("Text", null, "Promocion", "{0:0.00}");
                SubReporteCo.PSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteCo.CoImporte.DataBindings.Add("Text", null, "Total", "{0:0.00}");
                SubReporteCo.CoSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                //Total
                SubReporteCo.TCoSimbolo.Text = SMoneda;
                SubReporteCo.TCoImporte.Text = TotalCon.ToString("0.00");
                report.xrSubreportContado.ReportSource = SubReporteCo;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Credito
                StringBuilder LiqCredito = new StringBuilder();
                LiqCredito.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR ");
                LiqCredito.AppendLine("Set ANSI_WARNINGS OFF ");
                LiqCredito.AppendLine("Set nocount on ");
                LiqCredito.AppendLine("DECLARE @FechaFiltro as datetime, @VenID as varchar(16) ");
                LiqCredito.AppendLine("set @FechaFiltro = '" + Filtro + "' ");
                LiqCredito.AppendLine("set @VenID  ='" + VendedorSplit + "' ");
                LiqCredito.AppendLine("select distinct *,");
                LiqCredito.AppendLine("(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda");
                LiqCredito.AppendLine("from (");
                LiqCredito.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqCredito.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqCredito.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqCredito.AppendLine("Diferencia =sum((PPV.Precio - TD.Precio) * TD.Cantidad), ");
                LiqCredito.AppendLine("DesProd = sum(TD.DescuentoImp),");
                //LiqCredito.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                //LiqCredito.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqCredito.AppendLine("DesCliPor = 0, ");
                LiqCredito.AppendLine("DesVendPor=0,");
                LiqCredito.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqCredito.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqCredito.AppendLine("from TransProdDetalle TD (NOLOCK)");
                LiqCredito.AppendLine("inner join ProductoUnidad PU on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad and TransprodId=T.TransProdId");
                LiqCredito.AppendLine(") end");
                LiqCredito.AppendLine(") as Kilos");
                LiqCredito.AppendLine("from TransProd T (NOLOCK) ");
                LiqCredito.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID");
                LiqCredito.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro and T.Tipo in (1) and T.CFVTipo=2 and T.TipoFase not in(1,7)");
                LiqCredito.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave ");
                LiqCredito.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqCredito.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID and V.VendedorID=@VenID ");
                LiqCredito.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqCredito.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad");
                LiqCredito.AppendLine("group by T.Folio, T2.Folio, T.FechaHoraAlta, T.TipoFase, C.Clave, C.RazonSocial, T.Total, T.TransprodID");
                LiqCredito.AppendLine("UNION ALL");
                LiqCredito.AppendLine("");
                LiqCredito.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqCredito.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqCredito.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqCredito.AppendLine("Diferencia =sum((PPV.Precio - TD.Precio) * TD.Cantidad),");
                LiqCredito.AppendLine("DesProd = sum(TD.DescuentoImp),");
                //LiqCredito.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                //LiqCredito.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqCredito.AppendLine("DesCliPor = 0, ");
                LiqCredito.AppendLine("DesVendPor=0,");
                LiqCredito.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqCredito.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqCredito.AppendLine("from TransProdDetalle TD (NOLOCK)");
                LiqCredito.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad and TransprodId=T.TransProdId");
                LiqCredito.AppendLine(") end");
                LiqCredito.AppendLine(") as Kilos");
                LiqCredito.AppendLine("from TransProd T (NOLOCK) ");
                LiqCredito.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID");
                LiqCredito.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro and T.Tipo in (8) and T.CFVTipo=2 and T.TipoFase in(0)");
                LiqCredito.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave ");
                LiqCredito.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqCredito.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID and V.VendedorID=@VenID ");
                LiqCredito.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqCredito.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad");
                LiqCredito.AppendLine("group by T.Folio, T.FechaHoraAlta, T.TipoFase, C.Clave, C.RazonSocial, T.Total, T.TransprodID, TD.TransProdDetalleID, T.Tipo, TD.Total, TD.Subtotal, T.DescVendPor");
                LiqCredito.AppendLine("UNION ALL");
                LiqCredito.AppendLine("");
                LiqCredito.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqCredito.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqCredito.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqCredito.AppendLine("Diferencia =sum((PPV.Precio - TD.Precio) * TD.Cantidad), ");
                LiqCredito.AppendLine("DesProd = sum(TD.DescuentoImp),");
                //LiqCredito.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                //LiqCredito.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqCredito.AppendLine("DesCliPor = 0, ");
                LiqCredito.AppendLine("DesVendPor=0,");
                LiqCredito.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqCredito.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqCredito.AppendLine("from TransProdDetalle TD (NOLOCK)");
                LiqCredito.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad and TransprodId=T.TransProdId");
                LiqCredito.AppendLine(") end");
                LiqCredito.AppendLine(") as Kilos");
                LiqCredito.AppendLine("from TransProd T (NOLOCK) ");
                LiqCredito.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID");
                LiqCredito.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro and T.Tipo in (1) and T.CFVTipo=2 and T.TipoFase not in(1,7)");
                LiqCredito.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave ");
                LiqCredito.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqCredito.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID and V.VendedorID=@VenID ");
                LiqCredito.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqCredito.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad");
                LiqCredito.AppendLine("group by T.Folio, T2.Folio, T.FechaHoraAlta, T.TipoFase, C.Clave, C.RazonSocial, T.Total, T.TransprodID");
                LiqCredito.AppendLine("UNION ALL");
                LiqCredito.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                LiqCredito.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                LiqCredito.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                LiqCredito.AppendLine("Diferencia =sum((PPV.Precio - TD.Precio) * TD.Cantidad),  ");
                LiqCredito.AppendLine("DesProd = sum(TD.DescuentoImp),");
                //LiqCredito.AppendLine("DesCliPor=(select case when T.Tipo=1 and TD.Total>0 then (select (case when sum(DesImporte) is null then 0 else sum(DesImporte) end) from TpdDes as TDD where T.TransProdId=TDD.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end), ");
                //LiqCredito.AppendLine("DesVendPor=(select case when T.Tipo=1 and TD.Total>0 then TD.Subtotal- (select (case when sum(DesImpuesto) is null then 0 else sum(DesImpuesto) end) from TpdDes AS TDD where TDD.TransProdId=T.TransProdId and TDD.TransProdDetalleId=TD.TransProdDetalleId) else 0 end)*(select case when T.Tipo=1 and TD.Total>0 then (select case when T.DescVendPor is null then 0 else T.DescVendPor end) else 0 end)/100,");
                LiqCredito.AppendLine("DesCliPor = 0, ");
                LiqCredito.AppendLine("DesVendPor=0,");
                LiqCredito.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                LiqCredito.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                LiqCredito.AppendLine("from TransProdDetalle TD (NOLOCK)");
                LiqCredito.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad and TransprodId=T.TransProdId");
                LiqCredito.AppendLine(") end");
                LiqCredito.AppendLine(") as Kilos");
                LiqCredito.AppendLine("from TransProd T (NOLOCK) ");
                LiqCredito.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID=TD.TransProdID");
                LiqCredito.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro and T.Tipo in (8) and T.CFVTipo=2 and T.TipoFase in(0)");
                LiqCredito.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave ");
                LiqCredito.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqCredito.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID and V.VendedorID=@VenID ");
                LiqCredito.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                LiqCredito.AppendLine("left join PrecioProductoVig PPV (NOLOCK) on PPV.PrecioClave = VD.ListaPrecioBase and PPV.PPVFechaInicio <= T.FechaCaptura and PPV.FechaFin >= T.FechaCaptura and PPV.ProductoClave = TD.ProductoClave and PPV.PRUTipoUnidad = TD.TipoUnidad");
                LiqCredito.AppendLine("group by T.Folio, T.FechaHoraAlta, T.TipoFase, C.Clave, C.RazonSocial, T.Total, T.TransprodID");
                LiqCredito.AppendLine(") as LiquidacionCredito");
                LiqCredito.AppendLine("order by FolioVenta,FolioFactura");
                LiqCredito.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqCredito.ToString();

                List<LiquidacionAfrimaConCre> Credito = Connection.Query<LiquidacionAfrimaConCre>(QueryString, null, null, true, 600).ToList();
                var SubCredito = (from cr in Credito
                                  select cr).ToList();
                List<LiquidacionAfrimaConCre> Cre = new List<LiquidacionAfrimaConCre>();
                var SCR = (from gr in SubCredito group gr by new { gr.ConCreDetalle } into grupo select grupo);

                Decimal TotalCre = 0;
                double KilosCre = 0;

                foreach (var grupo in SCR)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Cre.Add(new LiquidacionAfrimaConCre
                        {
                            ConCreDetalle = "VENTA CRÉDITO",
                            FolioVenta = objetoAgrupado.FolioVenta,
                            FolioFactura = objetoAgrupado.FolioFactura,
                            FechaHoraAlta = objetoAgrupado.FechaHoraAlta,
                            ClienteClave = objetoAgrupado.ClienteClave,
                            Total = objetoAgrupado.Total,
                            Promocion = objetoAgrupado.DesProd + objetoAgrupado.DesCliPor + objetoAgrupado.DesVendPor + objetoAgrupado.Diferencia,
                            Kilos = objetoAgrupado.Kilos,
                            SimboloMoneda = objetoAgrupado.SimboloMoneda,
                            SubImporte = objetoAgrupado.DesProd + objetoAgrupado.DesCliPor + objetoAgrupado.DesVendPor + objetoAgrupado.Diferencia + objetoAgrupado.Total
                        });
                        Cre.Last().ConCreTotal = grupo.Sum(c => c.Total);
                        Cre.Last().ConCreKilos = grupo.Sum(c => c.Kilos);
                        TotalCre += objetoAgrupado.Total;
                        KilosCre += objetoAgrupado.Kilos;
                    }
                }
                SubReporteCreditoA SubReporteCr = new SubReporteCreditoA();
                SubReporteCr.DataSource = Cre;
                //GroupHeader2
                GroupField groupCr = new GroupField("ConCreDetalle");
                SubReporteCr.GroupHeader2.GroupFields.Add(groupCo);
                SubReporteCr.SubCredito.DataBindings.Add("Text", SubReporteCr.DataSource, "ConCredetalle");
                //Detalle
                SubReporteCr.CrVenta.DataBindings.Add("Text", null, "FolioVenta");
                SubReporteCr.CrFecha.DataBindings.Add("Text", null, "FechaHoraAlta");
                SubReporteCr.CrCliente.DataBindings.Add("Text", null, "ClienteClave");
                SubReporteCr.PSubtotal.DataBindings.Add("Text", null, "SubImporte", "{0:0.00}");
                SubReporteCr.SSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteCr.PPromocion.DataBindings.Add("Text", null, "Promocion", "{0:0.00}");
                SubReporteCr.PSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteCr.CrImporte.DataBindings.Add("Text", null, "Total", "{0:0.00}");
                SubReporteCr.CrSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                //Total
                SubReporteCr.TCrSimbolo.Text = SMoneda;
                SubReporteCr.TCrImporte.Text = TotalCre.ToString("0.00");
                report.xrSubreportCredito.ReportSource = SubReporteCr;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Cobranza
                StringBuilder LiqCobranza = new StringBuilder();
                LiqCobranza.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR ");
                LiqCobranza.AppendLine("Set ANSI_WARNINGS OFF ");
                LiqCobranza.AppendLine("Set nocount on ");
                LiqCobranza.AppendLine("DECLARE @FechaFiltro as datetime, @VenID as varchar(16) ");
                LiqCobranza.AppendLine("set @FechaFiltro = '" + Filtro + "' ");
                LiqCobranza.AppendLine("set @VenID  ='" + VendedorSplit + "' ");
                LiqCobranza.AppendLine("--COBRANZA");
                LiqCobranza.AppendLine("declare @PagoAutomatico as bit ");
                LiqCobranza.AppendLine("set @PagoAutomatico = (select top 1 PagoAutomatico from ConHist where CONHistFechaInicio <= @FechaFiltro order by CONHistFechaInicio desc) ");
                LiqCobranza.AppendLine("select LiquidacionCobranza.FolioCobranza,LiquidacionCobranza.FolioVenta,LiquidacionCobranza.FechaVenta,LiquidacionCobranza.Cliente,LiquidacionCobranza.Total,LiquidacionCobranza.FechaCobranza,");
                LiqCobranza.AppendLine("(select Simbolo from Moneda (NOLOCK) where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda");
                LiqCobranza.AppendLine("from (");
                LiqCobranza.AppendLine("select A.Folio as FolioCobranza,T.Folio as FolioVenta,T.FechaHoraAlta as FechaVenta,C.Clave+' - '+C.RazonSocial as Cliente,");
                LiqCobranza.AppendLine("AT.Importe as Total, A.FechaCreacion as FechaCobranza, A.ABNId as ABNID ");
                LiqCobranza.AppendLine("from Abono A (NOLOCK)");
                LiqCobranza.AppendLine("inner join ABNDetalle AD (NOLOCK) on A.ABNId=AD.ABNId");
                LiqCobranza.AppendLine("inner join Dia D (NOLOCK) on A.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro");
                LiqCobranza.AppendLine("inner join AbnTrp AT (NOLOCK) on A.ABNId=AT.ABNId");
                LiqCobranza.AppendLine("inner join TransProd T (NOLOCK) on AT.TransProdID=T.TransProdID and T.CFVTipo in ( 2 , CASE WHEN @PagoAutomatico = 0 THEN  1 ELSE 2 END) and T.Tipo in (1)");
                LiqCobranza.AppendLine("inner join Visita V (NOLOCK) on A.VisitaClave=V.VisitaClave and V.VendedorID=@VenID");
                LiqCobranza.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                LiqCobranza.AppendLine("UNION ");
                LiqCobranza.AppendLine("select A.Folio as FolioCobranza,T.Folio as FolioVenta,T.FechaHoraAlta as FechaVenta,C.Clave+' - '+C.RazonSocial as Cliente,");
                LiqCobranza.AppendLine("AT.Importe as Total, A.FechaCreacion as FechaCobranza ,A.ABNId as ABNID ");
                LiqCobranza.AppendLine("from Abono A");
                LiqCobranza.AppendLine("inner join ABNDetalle AD (NOLOCK) on A.ABNId=AD.ABNId and A.DiaClave=convert(varchar,convert(date,@FechaFiltro,103),103)");
                LiqCobranza.AppendLine("inner join Dia D (NOLOCK) on A.DiaClave=D.DiaClave");
                LiqCobranza.AppendLine("inner join AbnTrp AT (NOLOCK) on A.ABNId=AT.ABNId");
                LiqCobranza.AppendLine("inner join TransProd T (NOLOCK) on AT.TransProdID=T.TransProdID and T.CFVTipo in ( 2 , CASE WHEN @PagoAutomatico = 0 THEN  1 ELSE 2 END) and T.FechaCaptura<@FechaFiltro and T.Tipo in (1)");
                LiqCobranza.AppendLine("inner join Visita V (NOLOCK) on A.VisitaClave=V.VisitaClave and V.VendedorID=@VenID");
                LiqCobranza.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave	");
                LiqCobranza.AppendLine("UNION ");
                LiqCobranza.AppendLine("select AH.Folio as FolioCobranza,T.Folio as FolioVenta,T.FechaHoraAlta as FechaVenta,'COBRO CANCELADO',0 as Total,AH.FechaHoraCreacion as FechaCobranza,AH.ABNID as ABNID ");
                LiqCobranza.AppendLine("from AbonoHist AH");
                LiqCobranza.AppendLine("inner join Dia D (NOLOCK) on AH.DiaClave=D.DiaClave and D.FechaCaptura=@FechaFiltro");
                LiqCobranza.AppendLine("inner join AbnTrpHist ATH (NOLOCK) on AH.ABNId=ATH.ABNId");
                LiqCobranza.AppendLine("inner join TransProd T (NOLOCK) on ATH.TransProdID=T.TransProdID and T.CFVTipo in ( 2 , CASE WHEN @PagoAutomatico = 0 THEN  1 ELSE 2 END) and T.Tipo in (1)");
                LiqCobranza.AppendLine("inner join Visita V (NOLOCK) on AH.VisitaClave=V.VisitaClave and V.VendedorID=@VenID");
                LiqCobranza.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave	");
                LiqCobranza.AppendLine(") as LiquidacionCobranza");
                LiqCobranza.AppendLine("order by FolioCobranza,FolioVenta");
                LiqCobranza.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqCobranza.ToString();

                List<LiquidacionAfrimaCobranza> Cobranza = Connection.Query<LiquidacionAfrimaCobranza>(QueryString, null, null, true, 600).ToList();
                var SubCobranza = (from cb in Cobranza
                                  select cb).ToList();
                List<LiquidacionAfrimaCobranza> Cob = new List<LiquidacionAfrimaCobranza>();
                var SCB = (from gr in SubCobranza group gr by new { gr.CobranzaDetalle } into grupo select grupo);

                Decimal TotalCob = 0;

                foreach (var grupo in SCB)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        Cob.Add(new LiquidacionAfrimaCobranza
                        {
                            CobranzaDetalle = "COBRANZA",
                            FolioCobranza = objetoAgrupado.FolioCobranza,
                            FolioVenta = objetoAgrupado.FolioVenta,
                            FechaVenta = objetoAgrupado.FechaVenta,
                            Cliente = objetoAgrupado.Cliente,
                            Total = objetoAgrupado.Total,
                            FechaCobranza = objetoAgrupado.FechaCobranza,
                            SimboloMoneda = objetoAgrupado.SimboloMoneda
                        });
                        Cob.Last().CobranzaTotal = grupo.Sum(c => c.Total);
                        TotalCob += objetoAgrupado.Total;
                    }
                }
                SubReporteCobranzaA SubReporteCob = new SubReporteCobranzaA();
                SubReporteCob.DataSource = Cob;
                //GroupHeader2
                GroupField groupCob = new GroupField("CobranzaDetalle");
                SubReporteCob.GroupHeader2.GroupFields.Add(groupCo);
                SubReporteCob.SubCobranza.DataBindings.Add("Text", SubReporteCob.DataSource, "CobranzaDetalle");
                //Detalle
                SubReporteCob.CobCobranza.DataBindings.Add("Text", null, "FolioCobranza");
                SubReporteCob.CobVenta.DataBindings.Add("Text", null, "FolioVenta");
                SubReporteCob.CobFecha.DataBindings.Add("Text", null, "FechaVenta");
                SubReporteCob.CobCliente.DataBindings.Add("Text", null, "Cliente");
                SubReporteCob.CobImporte.DataBindings.Add("Text", null, "Total", "{0:0.00}");
                SubReporteCob.CobSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                SubReporteCob.CobFechaPago.DataBindings.Add("Text", null, "FechaCobranza");
                //Total
                SubReporteCob.TCobSimbolo.Text = SMoneda;
                SubReporteCob.TCobImporte.Text = TotalCob.ToString("0.00");
                report.xrSubreportCobranza.ReportSource = SubReporteCob;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Monedas
                StringBuilder LiqMonedas = new StringBuilder();
                LiqMonedas.AppendLine("SET ANSI_WARNINGS OFF");
                LiqMonedas.AppendLine("SET NOCOUNT ON ");
                LiqMonedas.AppendLine("--PLANTILLA DESGLOSE Monedas");
                LiqMonedas.AppendLine("select VD.Descripcion+");
                LiqMonedas.AppendLine("' =   '+(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as Billetes");
                LiqMonedas.AppendLine("from VARValor V");
                LiqMonedas.AppendLine("inner join VAVDescripcion VD on V.VARCodigo=VD.VARCodigo and V.VAVClave=VD.VAVClave");
                LiqMonedas.AppendLine("where V.VARCodigo='DENOMINA' and V.Grupo=1 and VD.VADTipoLenguaje=(select dbo.FNObtenerLenguaje()) and VD.Descripcion in ('500.00','1000.00')");
                LiqMonedas.AppendLine("order by cast(VD.Descripcion as float) asc");
                LiqMonedas.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqMonedas.ToString();

                List<LiquidacionAfrimaMonBil> Monedas = Connection.Query<LiquidacionAfrimaMonBil>(QueryString, null, null, true, 600).ToList();

                SubReporteMonedasA SubReporteMon = new SubReporteMonedasA();
                SubReporteMon.DataSource = Monedas;

                SubReporteMon.MMoneda.DataBindings.Add("Text", null, "Billetes");
                //SubReporteMon.MSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");
                //SubReporteMon.MMSimbolo.Text = "=   " + SMoneda;
                //SubReporteMon.TSimbolo.Text = "=   " + SMoneda;

                report.xrSubreportMonedas.ReportSource = SubReporteMon;
                //SubReporte-------------------------------------------------------------------------------------------------

                //SubReporte-------------------------------------------------------------------------------------------------
                //Liquidacion Billetes
                StringBuilder LiqBilletes = new StringBuilder();
                LiqBilletes.AppendLine("SET ANSI_WARNINGS OFF");
                LiqBilletes.AppendLine("SET NOCOUNT ON ");
                LiqBilletes.AppendLine("--PLANTILLA DESGLOSE Monedas");
                LiqBilletes.AppendLine("select VD.Descripcion+");
                LiqBilletes.AppendLine("' =   '+(select Simbolo from Moneda where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as Billetes");
                LiqBilletes.AppendLine("from VARValor V");
                LiqBilletes.AppendLine("inner join VAVDescripcion VD on V.VARCodigo=VD.VARCodigo and V.VAVClave=VD.VAVClave");
                LiqBilletes.AppendLine("where V.VARCodigo='DENOMINA' and V.Grupo=1 and VD.VADTipoLenguaje=(select dbo.FNObtenerLenguaje()) and VD.Descripcion not in ('500.00','1000.00')");
                LiqBilletes.AppendLine("order by cast(VD.Descripcion as float) asc");
                LiqBilletes.AppendLine("SET NOCOUNT OFF ");

                QueryString = "";
                QueryString = LiqBilletes.ToString();

                List<LiquidacionAfrimaMonBil> Billetes = Connection.Query<LiquidacionAfrimaMonBil>(QueryString, null, null, true, 600).ToList();

                SubReporteBilletesA SubReporteBil = new SubReporteBilletesA();
                SubReporteBil.DataSource = Billetes;

                SubReporteBil.BBillete.DataBindings.Add("Text", null, "Billetes");
                //SubReporteBil.BSimbolo.DataBindings.Add("Text", null, "SimboloMoneda");

                report.xrSubreportBilletes.ReportSource = SubReporteBil;
                //SubReporte-------------------------------------------------------------------------------------------------

                //Cabecera Informe
                report.PPSimbolo.Text = SMoneda;
                report.PPTotal.Text = Total.ToString("0.00");
                report.ConnSimbolo.Text = SMoneda;
                report.ConnTotal.Text = TotalCon.ToString("0.00");
                report.CreeSimbolo.Text = SMoneda;
                report.CreeTotal.Text = TotalCre.ToString("0.00");
                report.CobbSimbolo.Text = SMoneda;
                report.CobbTotal.Text = TotalCob.ToString("0.00");
                report.LiqqSimbolo.Text = SMoneda;
                report.LiqqTotal.Text = (Total - TotalCre + TotalCob).ToString("0.00");

                //PieInforme
                report.PSimbolo.Text = SMoneda;
                report.PTotal.Text = Total.ToString("0.00");
                report.CoSimbolo.Text = SMoneda;
                report.CoTotal.Text = TotalCon.ToString("0.00");
                report.CrSimbolo.Text = SMoneda;
                report.CrTotal.Text = TotalCre.ToString("0.00");
                report.CobSimbolo.Text = SMoneda;
                report.CobTotal.Text = TotalCob.ToString("0.00");
                report.LiqSimbolo.Text = SMoneda;
                report.LiqTotal.Text = (Total-TotalCre+TotalCob).ToString("0.00");

                //report.ExportOptions.Xlsx.RawDataMode = true;
                //SubReporteP.ExportOptions.Xlsx.RawDataMode = true;
                //SubReporteCo.ExportOptions.Xlsx.RawDataMode = true;
                //SubReporteCr.ExportOptions.Xlsx.RawDataMode = true;
                //SubReporteCr.ExportOptions.Xlsx.RawDataMode = true;
                //SubReporteMon.ExportOptions.Xlsx.RawDataMode = true;
                //SubReporteBil.ExportOptions.Xlsx.RawDataMode = true;
                //SubReporteCob.ExportOptions.Xlsx.RawDataMode = true;

                //report.ExportOptions.Xlsx.ExportMode

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
                return new ReporteLiquidacionAfrima();
            }
        }

    }

    class LiquidacionAfrimaDetalleVModel
    {
        public string VendedorDetalle { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
    }

    class LiquidacionAfrimaGenericoModel
    {
        public string VendedorID { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public long InventarioInicial { get; set; }
        public long Recarga { get; set; }
        public long Devolucion { get; set; }
        public Decimal Promocion { get; set; }
        public long Descarga { get; set; }
        public long Venta { get; set; }
        public long InventarioFinal { get; set; }
        public string SimboloMoneda { get; set; }
        public Decimal Importe { get; set; }
        public Decimal ImporteTotal { get; set; }
        public Decimal SubImporte { get; set; }
    }

    class LiquidacionAfrimaConCre
    {
        public string ConCreDetalle { get; set; }
        public string FolioVenta { get; set; }
        public string FolioFactura { get; set; }
        public string FechaHoraAlta { get; set; }
        public string ClienteClave { get; set; }
        public Decimal Total { get; set; }
        public Decimal Diferencia { get; set; }
        public Decimal DesProd { get; set; }
        public Decimal DesCliPor { get; set; }
        public Decimal DesVendPor { get; set; }
        public Decimal Promocion { get; set; }
        public long Kilos { get; set; }
        public string SimboloMoneda { get; set; }
        public Decimal ConCreTotal { get; set; }
        public double ConCreKilos { get; set; }
        public Decimal SubImporte { get; set; }
    }

    class LiquidacionAfrimaCobranza
    {
        public string CobranzaDetalle { get; set; }
        public string FolioCobranza { get; set; }
        public string FolioVenta { get; set; }
        public string FechaVenta { get; set; }
        public string Cliente { get; set; }
        public Decimal Total { get; set; }
        public string FechaCobranza { get; set; }
        public string SimboloMoneda { get; set; }
        public Decimal CobranzaTotal { get; set; }
    }

    class LiquidacionAfrimaMonBil
    {
        public string MonBilDetalle { get; set; }
        public string Monedas { get; set; }
        public string Billetes { get; set; }
        public string SimboloMoneda { get; set; }

    }
}