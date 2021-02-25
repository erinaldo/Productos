using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class MReporteLiquidacionLPB
    {
        DateTime fInicio;
        private string QueryString;
        private string Fecha;
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreVendedor, string NombreCEDIS, string DateStatus, string CEDIS, string Vendedores, string FechaInicial)
        {               
            try
            {
                this.fInicio = DateTime.Parse(FechaInicial);
                this.Fecha = this.fInicio.Date.ToString("dd/MM/yyyy");
                FechaInicial = this.fInicio.Date.ToString("yyyy-MM-dd");

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("select A.Clave as ClaveAlmacen,A.Nombre,A.Domicilio,A.Telefono,U.Clave as ClaveAlmacenABordo");
                sConsulta.AppendLine("from VENCentroDistHist VDH (NOLOCK) ");
                sConsulta.AppendLine("inner join Almacen A (NOLOCK) on VDH.AlmacenId=A.AlmacenID");
                sConsulta.AppendLine("inner join Vendedor V (NOLOCK) on V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine("inner join Usuario U (NOLOCK) on V.USUId=U.USUId");
                sConsulta.AppendLine("and VDH.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine(" and '" + FechaInicial + "' between VDH.VCHFechaInicial and VDH.FechaFinal");
                sConsulta.AppendLine("SET NOCOUNT OFF ");
                QueryString = "";

                QueryString = sConsulta.ToString();
                List<direc> Una = Connection.Query<direc>(QueryString, null, null, true, 600).ToList();



                ////Liquidacion Producto
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select x.ProductoClave, ");
                sConsulta.AppendLine("p.Nombre, ");
                sConsulta.AppendLine("sum(CargasPZA) as CargasPZA, ");
                sConsulta.AppendLine("sum(CargasKG) as CargasKG,");
                sConsulta.AppendLine("sum(DevolucionesCliPZA) as DevolucionesCliPZA, ");
                sConsulta.AppendLine("sum(DevolucionesCliKG) as DevolucionesCliKG,");
                sConsulta.AppendLine("sum(CambiosEntradaPZA) as CambiosEntradaPZA, ");
                sConsulta.AppendLine("sum(CambiosEntradaKG) as CambiosEntradaKG, ");
                sConsulta.AppendLine("sum(CambiosSalidaPZA) as CambiosSalidaPZA, ");
                sConsulta.AppendLine("sum(CambiosSalidaKG) as CambiosSalidaKG, ");
                sConsulta.AppendLine("sum(DegustacionPZA) as DegustacionPZA, ");
                sConsulta.AppendLine("sum(DegustacionKG) as DegustacionKg,");
                sConsulta.AppendLine("sum(DevolucionAlmacenPZA) as DevolucionAlmacenPZA, ");
                sConsulta.AppendLine("sum(DevolucionAlmacenKG) as DevolucionAlmacenKG, ");
                sConsulta.AppendLine("sum(VentasContadoPZA) as VentasContadoPZA, ");
                sConsulta.AppendLine("sum(VentasContadoKg) as VentasContadoKG, ");
                sConsulta.AppendLine("sum(VentasCreditoPZA) as VentasCreditoPZA,");
                sConsulta.AppendLine("sum(VentasCreditoKG) as VentasCreditoKG,");
                sConsulta.AppendLine("(sum(CargasPZA)+sum(DevolucionesCliPZA)+sum(CambiosEntradaPZA)-sum(CambiosSalidaPZA)-sum(DegustacionPZA)-sum(DevolucionAlmacenPZA)-sum(VentasContadoPZA)-sum(VentasCreditoPZA)) as InventarioFinalPZA,");
                sConsulta.AppendLine("(sum(CargasKG)+sum(DevolucionesCliKG)+sum(CambiosEntradaKG)-sum(CambiosSalidaKG)-sum(DegustacionKG)-sum(DevolucionAlmacenKG)-sum(VentasContadoKG)-sum(VentasCreditoKG)) as InventarioFinalKG ");
                sConsulta.AppendLine("from( ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("Select td.ProductoClave, ");
                sConsulta.AppendLine("CargasPZA=(case when t.Tipo=2 then (case when td.TipoUnidad=1 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("CargasKG=(case when t.Tipo=2 then (case when td.TipoUnidad=2 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("DevolucionesCliPZA=0, ");
                sConsulta.AppendLine("DevolucionesCliKG=0, ");
                sConsulta.AppendLine("CambiosEntradaPZA=0, ");
                sConsulta.AppendLine("CambiosEntradaKG=0, ");
                sConsulta.AppendLine("CambiosSalidaPZA=0, ");
                sConsulta.AppendLine("CambiosSalidaKG=0, ");
                sConsulta.AppendLine("DegustacionPZA=0, ");
                sConsulta.AppendLine("DegustacionKG=0, ");
                sConsulta.AppendLine("DevolucionAlmacenPZA=(case when t.Tipo=4 then (case when td.TipoUnidad=1 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("DevolucionAlmacenKG=(case when t.Tipo=4 then (case when td.TipoUnidad=2 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("VentasContadoPZA=0, ");
                sConsulta.AppendLine("VentasContadoKG=0, ");
                sConsulta.AppendLine("VentasCreditoPZA=0,");
                sConsulta.AppendLine("VentasCreditoKG=0 ");
                sConsulta.AppendLine("from TransProd t (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = isnull(t.DiaClave,t.DiaClave1) ");
                sConsulta.AppendLine("inner join Vendedor v (NOLOCK) on t.MUsuarioID=v.USUId ");
                sConsulta.AppendLine("inner join TransProdDetalle td (NOLOCK) on t.TransProdID=td.TransProdID ");
                sConsulta.AppendLine("inner join TPDDatosExtra tde (NOLOCK) on td.TransProdID=tde.TransProdID and td.TransProdDetalleID=tde.TransProdDetalleID");
                sConsulta.AppendLine("where t.Tipo in (2,4) and t.TipoFase <> 0  and convert(datetime,Convert(varchar(20),D.FechaCaptura,112)) = '" + FechaInicial + "' ");
                sConsulta.AppendLine("and V.VendedorID = '" + Vendedores + "'");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("Select td.ProductoClave, ");
                sConsulta.AppendLine("CargasPZA=0, ");
                sConsulta.AppendLine("CargasKG=0, ");
                sConsulta.AppendLine("DevolucionesCliPZA=(case when t.Tipo=3 then (case when td.TipoUnidad=1 then td.Cantidad else tde.CantidadAlterna end) else 0 end),  ");
                sConsulta.AppendLine("DevolucionesCliKG=(case when t.Tipo=3 then (case when td.TipoUnidad=2 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("CambiosEntradaPZA=(case when t.Tipo=9 and t.TipoMovimiento=1 then (case when td.TipoUnidad=1 then td.Cantidad else tde.CantidadAlterna end) else 0 end),  ");
                sConsulta.AppendLine("CambiosEntradaKG=(case when t.Tipo=9 and t.TipoMovimiento=1 then (case when td.TipoUnidad=2 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("CambiosSalidaPZA=(case when t.Tipo=9 and t.TipoMovimiento=2 then (case when td.TipoUnidad=1 then td.Cantidad else tde.CantidadAlterna end) else 0 end),  ");
                sConsulta.AppendLine("CambiosSalidaKG=(case when t.Tipo=9 and t.TipoMovimiento=2 then (case when td.TipoUnidad=2 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("DegustacionPZA=(case when t.Tipo=21 then (case when td.TipoUnidad=1 then td.Cantidad else tde.CantidadAlterna end) else 0 end),  ");
                sConsulta.AppendLine("DegustacionKG=(case when t.Tipo=21 then (case when td.TipoUnidad=2 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("DevolucionAlmacenPZA=0, ");
                sConsulta.AppendLine("DevolucionAlmacenKG=0, ");
                sConsulta.AppendLine("VentasContadoPZA=(case when t.Tipo=1 and t.CFVTipo=1 and isnull(td.Promocion,'')<>2 then (case when td.TipoUnidad=1 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("VentasContadoKG=(case when t.Tipo=1 and t.CFVTipo=1 and isnull(td.Promocion,'')<>2 then (case when td.TipoUnidad=2 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("VentasCreditoPZA=(case when t.Tipo=1 and t.CFVTipo=2 and isnull(td.Promocion,'')<>2 then (case when td.TipoUnidad=1 then td.Cantidad else tde.CantidadAlterna end) else 0 end), ");
                sConsulta.AppendLine("VentasCreditoKG=(case when t.Tipo=1 and t.CFVTipo=2 and isnull(td.Promocion,'')<>2 then (case when td.TipoUnidad=2 then td.Cantidad else tde.CantidadAlterna end) else 0 end) ");
                sConsulta.AppendLine("from TransProd t (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = isnull(t.DiaClave1,t.DiaClave) ");
                sConsulta.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave = isnull(t.VisitaClave1, t.VisitaClave) and v.DiaClave = isnull(t.DiaClave1,t.DiaClave)");
                sConsulta.AppendLine("inner join TransProdDetalle td (NOLOCK) on t.TransProdID = td.TransProdID ");
                sConsulta.AppendLine("inner join TPDDatosExtra tde (NOLOCK) on td.TransProdID=tde.TransProdID and td.TransProdDetalleID=tde.TransProdDetalleID");
                sConsulta.AppendLine("where t.Tipo in (1,3,4,9,21) ");
                sConsulta.AppendLine("and t.TipoFase <> 0 ");
                sConsulta.AppendLine("and convert(datetime,Convert(varchar(20),D.FechaCaptura,112)) = '" + FechaInicial + "' ");
                sConsulta.AppendLine("and V.VendedorID = '" + Vendedores + "'");
                sConsulta.AppendLine(") as x");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on x.ProductoClave=p.ProductoClave ");
                sConsulta.AppendLine("group by x.ProductoClave, p.Nombre");
                sConsulta.AppendLine("order by p.Nombre");
                QueryString = "";

                QueryString = sConsulta.ToString();
                List<LiquidacionProducto> Dos = Connection.Query<LiquidacionProducto>(QueryString, null, null, true, 600).ToList();

                ///Liquidacion Ventas Contado
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select *,");
                sConsulta.AppendLine("(select Simbolo from Moneda (NOLOCK) where MonedaID=(select top 1 MonedaId from CONHist order by MFechaHora desc)) as SimboloMoneda");
                sConsulta.AppendLine("from (");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta,");
                sConsulta.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                sConsulta.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                sConsulta.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                sConsulta.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                sConsulta.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                sConsulta.AppendLine("where TransprodId=T.TransProdId");
                sConsulta.AppendLine(") end");
                sConsulta.AppendLine(") as Kilos");
                sConsulta.AppendLine("from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd T2 on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID");
                sConsulta.AppendLine("where T.Tipo in (1) and T.CFVTipo=1 and T.TipoFase not in(1,7) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine("UNION ALL");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                sConsulta.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                sConsulta.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                sConsulta.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                sConsulta.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                sConsulta.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                sConsulta.AppendLine("where TransprodId=T.TransProdId");
                sConsulta.AppendLine(") end");
                sConsulta.AppendLine(") as Kilos");
                sConsulta.AppendLine("from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID");
                sConsulta.AppendLine("where T.Tipo in (8) and T.CFVTipo=1 and T.TipoFase in(0) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine("UNION ALL");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta,");
                sConsulta.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                sConsulta.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                sConsulta.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                sConsulta.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                sConsulta.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                sConsulta.AppendLine("where TransprodId=T.TransProdId");
                sConsulta.AppendLine(") end");
                sConsulta.AppendLine(") as Kilos");
                sConsulta.AppendLine("from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave1=D.DiaClave");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave1=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID");
                sConsulta.AppendLine("where T.Tipo in (1) and T.CFVTipo=1 and T.TipoFase not in(1,7) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine("UNION ALL");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                sConsulta.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                sConsulta.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                sConsulta.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                sConsulta.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                sConsulta.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                sConsulta.AppendLine("where TransprodId=T.TransProdId");
                sConsulta.AppendLine(") end");
                sConsulta.AppendLine(") as Kilos");
                sConsulta.AppendLine("from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave1=D.DiaClave");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave1=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID");
                sConsulta.AppendLine("where T.Tipo in (8) and T.CFVTipo=1 and T.TipoFase in(0) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine(") as LiquidacionContado");
                sConsulta.AppendLine("order by FolioVenta,FolioFactura");
                sConsulta.AppendLine("SET NOCOUNT OFF ");
                QueryString = "";

                QueryString = sConsulta.ToString();
                List<ventacontado> Tres = Connection.Query<ventacontado>(QueryString, null, null, true, 600).ToList();

                //Liquidacion Ventas Credito
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select *,");
                sConsulta.AppendLine("(select Simbolo from Moneda (NOLOCK) where MonedaID=(select top 1 MonedaId from CONHist (NOLOCK) order by MFechaHora desc)) as SimboloMoneda");
                sConsulta.AppendLine("from (");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select T.Folio as FolioVenta,isnull(T2.Folio,'') as FolioFactura,T.FechaHoraAlta,");
                sConsulta.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                sConsulta.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                sConsulta.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                sConsulta.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                sConsulta.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                sConsulta.AppendLine("where TransprodId=T.TransProdId");
                sConsulta.AppendLine(") end");
                sConsulta.AppendLine(") as Kilos");
                sConsulta.AppendLine("from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID");
                sConsulta.AppendLine("where T.Tipo in (1) and T.CFVTipo=2 and T.TipoFase not in(1,7) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine("UNION ALL");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                sConsulta.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                sConsulta.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                sConsulta.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                sConsulta.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                sConsulta.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                sConsulta.AppendLine("where TransprodId=T.TransProdId");
                sConsulta.AppendLine(") end");
                sConsulta.AppendLine(") as Kilos");
                sConsulta.AppendLine("from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave=D.DiaClave");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID");
                sConsulta.AppendLine("where T.Tipo in (8) and T.CFVTipo=2 and T.TipoFase in(0) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine("UNION ALL");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select T.Folio as FolioVenta,T2.Folio as FolioFactura,T.FechaHoraAlta,");
                sConsulta.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'VENTA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                sConsulta.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                sConsulta.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                sConsulta.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                sConsulta.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                sConsulta.AppendLine("where TransprodId=T.TransProdId");
                sConsulta.AppendLine(") end");
                sConsulta.AppendLine(") as Kilos");
                sConsulta.AppendLine("from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave1=D.DiaClave");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave1=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID");
                sConsulta.AppendLine("where T.Tipo in (1) and T.CFVTipo=2 and T.TipoFase not in(1,7) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine("UNION ALL");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select 'XXX' as FolioVenta,T.Folio as FolioFactura,T.FechaHoraAlta,");
                sConsulta.AppendLine("ClienteClave=(select case when T.TipoFase=0 then 'FACTURA CANCELADA' else C.Clave+' - '+C.RazonSocial end),");
                sConsulta.AppendLine("Total=(select case when T.TipoFase=0 then 0 else T.Total end),");
                sConsulta.AppendLine("(select case when T.TipoFase=0 then 0 else (");
                sConsulta.AppendLine("select sum(TD.Cantidad*PU.KgLts)");
                sConsulta.AppendLine("from TransProdDetalle TD (NOLOCK) ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TD.ProductoClave=PU.ProductoClave and TD.TipoUnidad=PU.PRUTipoUnidad");
                sConsulta.AppendLine("where TransprodId=T.TransProdId");
                sConsulta.AppendLine(") end");
                sConsulta.AppendLine(") as Kilos");
                sConsulta.AppendLine("from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd T2 (NOLOCK) on T2.Tipo=8 and T.FacturaID=T2.TransProdID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on T.DiaClave1=D.DiaClave");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on T.VisitaClave1=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("inner join Vendedor VD (NOLOCK) on V.VendedorID=VD.VendedorID");
                sConsulta.AppendLine("where T.Tipo in (8) and T.CFVTipo=2 and T.TipoFase in(0) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine(") as LiquidacionCredito");
                sConsulta.AppendLine("order by FolioVenta,FolioFactura");
                sConsulta.AppendLine("SET NOCOUNT OFF ");
                QueryString = "";

                QueryString = sConsulta.ToString();
                List<ventacredito> Cuatro = Connection.Query<ventacredito>(QueryString, null, null, true, 600).ToList();

                //Liquidacion Cuentas Por Cobrar
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("declare @PagoAutomatico as bit ");
                sConsulta.AppendLine("set @PagoAutomatico = (select top 1 PagoAutomatico from ConHist (NOLOCK) where CONHistFechaInicio <= '" + FechaInicial + "' order by CONHistFechaInicio desc) ");
                sConsulta.AppendLine("select *,");
                sConsulta.AppendLine("(select Simbolo from Moneda (NOLOCK) where MonedaID=(select top 1 MonedaId from CONHist (NOLOCK) order by MFechaHora desc)) as SimboloMoneda");
                sConsulta.AppendLine("from (");
                sConsulta.AppendLine("select A.Folio as FolioCobranza,T.Folio as FolioFactura,T.FechaHoraAlta as FechaFactura,C.Clave+' - '+C.RazonSocial as Cliente,");
                sConsulta.AppendLine("AT.Importe as Total, A.FechaCreacion as FechaCobranza");
                sConsulta.AppendLine("from Abono A (NOLOCK) ");
                sConsulta.AppendLine("inner join ABNDetalle AD (NOLOCK) on A.ABNId=AD.ABNId");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on A.DiaClave=D.DiaClave");
                sConsulta.AppendLine("inner join AbnTrp AT (NOLOCK) on A.ABNId=AT.ABNId");
                sConsulta.AppendLine("inner join TransProd T (NOLOCK) on AT.TransProdID=T.TransProdID");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on A.VisitaClave=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("where T.CFVTipo in ( 2 , CASE WHEN @PagoAutomatico = 0 THEN  1 ELSE 2 END) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "'");
                sConsulta.AppendLine("UNION ");
                sConsulta.AppendLine("select A.Folio as FolioCobranza,T.Folio as FolioFactura,T.FechaHoraAlta as FechaFactura,C.Clave+' - '+C.RazonSocial as Cliente,");
                sConsulta.AppendLine("AT.Importe as Total, A.FechaCreacion as FechaCobranza");
                sConsulta.AppendLine("from Abono A (NOLOCK) ");
                sConsulta.AppendLine("inner join ABNDetalle AD (NOLOCK) on A.ABNId=AD.ABNId");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on A.DiaClave=D.DiaClave");
                sConsulta.AppendLine("inner join AbnTrp AT (NOLOCK) on A.ABNId=AT.ABNId");
                sConsulta.AppendLine("inner join TransProd T (NOLOCK) on AT.TransProdID=T.TransProdID");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on A.VisitaClave=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("where T.CFVTipo in ( 2 , CASE WHEN @PagoAutomatico = 0 THEN  1 ELSE 2 END) and ");
                sConsulta.AppendLine(" A.DiaClave=CONVERT(nvarchar(30), '" + this.Fecha + "', 103) and T.FechaCaptura<'" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                sConsulta.AppendLine("UNION ");
                sConsulta.AppendLine("select AH.Folio as FolioCobranza,T.Folio as FolioFactura,T.FechaHoraAlta as FechaFactura,'COBRO CANCELADO',0 as Total,AH.FechaHoraCreacion as FechaCobranza");
                sConsulta.AppendLine("from AbonoHist AH (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on AH.DiaClave=D.DiaClave");
                sConsulta.AppendLine("inner join AbnTrpHist ATH (NOLOCK) on AH.ABNId=ATH.ABNId");
                sConsulta.AppendLine("inner join TransProd T (NOLOCK) on ATH.TransProdID=T.TransProdID");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on AH.VisitaClave=V.VisitaClave");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave");
                sConsulta.AppendLine("where T.CFVTipo in ( 2 , CASE WHEN @PagoAutomatico = 0 THEN  1 ELSE 2 END) ");
                sConsulta.AppendLine(" and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "'");
                sConsulta.AppendLine(") as LiquidacionCobranza");
                sConsulta.AppendLine("order by FolioCobranza,FolioFactura");
                sConsulta.AppendLine("SET NOCOUNT OFF ");
                QueryString = "";

                QueryString = sConsulta.ToString();
                List<cCobranza> Cinco = Connection.Query<cCobranza>(QueryString, null, null, true, 600).ToList();
                //
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("select isnull(SUM(AT.Importe),0) as TotalLiquidar ");
                sConsulta.AppendLine("from Abono A (NOLOCK) ");
                sConsulta.AppendLine("inner join ABNDetalle AD (NOLOCK) on A.ABNId=AD.ABNId ");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on A.DiaClave=D.DiaClave ");
                sConsulta.AppendLine("inner join AbnTrp AT (NOLOCK) on A.ABNId=AT.ABNId ");
                sConsulta.AppendLine("inner join TransProd T (NOLOCK) on AT.TransProdID=T.TransProdID ");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on A.VisitaClave=V.VisitaClave ");
                sConsulta.AppendLine("inner join Cliente C (NOLOCK) on V.ClienteClave=C.ClienteClave ");
                sConsulta.AppendLine("where D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("and V.VendedorID='" + Vendedores + "' ");
                QueryString = "";

                QueryString = sConsulta.ToString();
                List<tliquidar> Seis = Connection.Query<tliquidar>(QueryString, null, null, true, 600).ToList();

                //
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("Select p.Nombre  as ListaPrecio,e.Nombre  as Esquema,sum(td.Cantidad) as CantidadVendida,ce.Comision as Comision ,sum(td.Cantidad)*ce.comision as ImporteComision ");
                sConsulta.AppendLine("from TransProd t (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave = t.VisitaClave and v.VendedorId= 'A03' ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave =d.DiaClave and D.FechaCaptura='2018-07-04T00:00:00'");
                sConsulta.AppendLine("inner join TransProdDetalle td (NOLOCK) on t.TransProdID =td.TransProdID  and t.Tipo=1 and t.tipoFase in(2,3) and iSNULL(td.Promocion,0) <> 2");
                sConsulta.AppendLine("inner join ProductoEsquema pe (NOLOCK) on pe.ProductoClave=td.ProductoClave ");
                sConsulta.AppendLine("inner join ComisionEsquema ce (NOLOCK) on ce.PrecioClave=t.PCEPrecioClave and pe.EsquemaID=ce.EsquemaId ");
                sConsulta.AppendLine("inner join Esquema e (NOLOCK) on pe.EsquemaID=e.EsquemaID ");
                sConsulta.AppendLine("inner join Precio p (NOLOCK) on t.PCEPrecioClave =p.PrecioClave ");
                sConsulta.AppendLine("group by ce.Comision,p.Nombre ,E.Nombre ");
                QueryString = "";
                QueryString = sConsulta.ToString();
               
                //
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("Select VD.Descripcion as Concepto, Folio, Total ");
                sConsulta.AppendLine("from Gasto G (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on g.DiaClave = d.DiaClave and d.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("inner join VAVDescripcion VD (NOLOCK) on G.TipoConcepto = VD.VAVClave and VARCodigo = 'GASTIPO' and VADTipoLenguaje =(select dbo.FNObtenerLenguaje()) ");
                sConsulta.AppendLine("where G.VendedorID = '" + Vendedores + "' ");
                QueryString = "";

                QueryString = sConsulta.ToString();
                List<GVendedor> Ocho = Connection.Query<GVendedor>(QueryString, null, null, true, 600).ToList();

                //
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("Select c.Clave +' - '+c.RazonSocial as Cliente, vd.Descripcion as Motivo, td.Cantidad as Pieza, td.Total, P.NombreLargo as Producto ");
                sConsulta.AppendLine("from TransProd t (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave = t.VisitaClave and v.VendedorId= '" + Vendedores + "' ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave =d.DiaClave and D.FechaCaptura='" + FechaInicial + "'");
                sConsulta.AppendLine("inner join TransProdDetalle td (NOLOCK) on t.TransProdID =td.TransProdID  and t.Tipo = 3 and t.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on v.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on td.TipoMotivo = vd.VAVClave and vd.VARCodigo = 'TRPMOT' and vd.VADTipoLenguaje = (select dbo.FNObtenerLenguaje()) ");
                sConsulta.AppendLine("inner join Producto P (NOLOCK) on td.ProductoClave = p.ProductoClave ");
                QueryString = "";

                QueryString = sConsulta.ToString();
                List<DClientes> Nueve = Connection.Query<DClientes>(QueryString, null, null, true, 600).ToList();

                PrincipalLiquidacionLPB report = new PrincipalLiquidacionLPB();

                string Telefono = "SELECT DISTINCT A.Telefono FROM UsuarioAlmacen UA (NOLOCK) INNER JOIN Almacen A (NOLOCK) ON A.AlmacenID = UA.AlmacenId AND A.AlmacenID = '" + CEDIS + "'";
                Telefono = Connection.Query<string>(Telefono, null, null, true, 9000).FirstOrDefault();
                string Domicilio = "SELECT DISTINCT A.Domicilio FROM UsuarioAlmacen UA (NOLOCK) INNER JOIN Almacen A (NOLOCK) ON A.AlmacenID = UA.AlmacenId AND A.AlmacenID = '" + CEDIS + "'";
                Domicilio = Connection.Query<string>(Domicilio, null, null, true, 9000).FirstOrDefault();

                FechaInicial = fInicio.Date.ToShortDateString();
                report.empresa.Text = NombreEmpresa;
                report.logo.Image = Image.FromStream(LogoEmpresa);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.fecha.Text = FechaInicial;
                report.centro.Text = NombreCEDIS;
                report.vendedor.Text = NombreVendedor;
                report.reporte.Text = NombreReporte;
                report.telefono.Text = Telefono;
                report.domicilio.Text = Domicilio;
                report.ruta.Text = Vendedores;

                Double a1 =0.0;
                Double a2 =0.0;
                Double a3 =0.0;
                Double a4 =0.0;
                Double a5 =0.0;
                Double a6 =0.0;
                Double a7 =0.0;
                //suma totales 
                if (Dos.Count != 0)
                {
                    Dos.LastOrDefault().tCargasPZA = Dos.Sum(c => c.CargasPZA);
                    Dos.LastOrDefault().tCargasKG = Dos.Sum(c => c.CargasKG);
                    Dos.LastOrDefault().tDevolucionesCliPZA = Dos.Sum(c => c.DevolucionesCliPZA);
                    Dos.LastOrDefault().tDevolucionesCliKG = Dos.Sum(c => c.DevolucionesCliKG);
                    Dos.LastOrDefault().tCambiosEntradaPZA = Dos.Sum(c => c.CambiosEntradaPZA);
                    Dos.LastOrDefault().tCambiosEntradaKG = Dos.Sum(c => c.CambiosEntradaKG);
                    Dos.LastOrDefault().tCambiosSalidaPZA = Dos.Sum(c => c.CambiosSalidaPZA);
                    Dos.LastOrDefault().tCambiosSalidaKG = Dos.Sum(c => c.CambiosSalidaKG);
                    Dos.LastOrDefault().tDegustacionPZA = Dos.Sum(c => c.DegustacionPZA);
                    Dos.LastOrDefault().tDegustacionKg = Dos.Sum(c => c.DegustacionKg);
                    Dos.LastOrDefault().tDevolucionAlmacenPZA = Dos.Sum(c => c.DevolucionAlmacenPZA);
                    Dos.LastOrDefault().tDevolucionAlmacenKG = Dos.Sum(c => c.DevolucionAlmacenKG);
                    Dos.LastOrDefault().tVentasContadoPZA = Dos.Sum(c => c.VentasContadoPZA);
                    Dos.LastOrDefault().tVentasContadoKG = Dos.Sum(c => c.VentasContadoKG);
                    Dos.LastOrDefault().tVentasCreditoPZA = Dos.Sum(c => c.VentasCreditoPZA);
                    Dos.LastOrDefault().tVentasCreditoPZA = Dos.Sum(c => c.VentasCreditoPZA);
                }
                if (Tres.Count!=0) {
                    Tres.LastOrDefault().tKiloscon = Tres.Sum(c => c.Kilos);
                    Tres.LastOrDefault().tTotalcon = Tres.Sum(c => c.Total);
                    a2= Tres.Sum(c => c.Total);
                }

                if (Cuatro.Count!=0) {
                    Cuatro.LastOrDefault().tKiloscre = Cuatro.Sum(c => c.Kilos);
                    Cuatro.LastOrDefault().tTotalcre = Cuatro.Sum(c => c.Total);
                    a3 = Cuatro.Sum(c => c.Total);
                }
                if (Cinco.Count!=0) {
                    Cinco.LastOrDefault().tTotalcobra = Cinco.Sum(c => c.Total);
                    a4= Cinco.Sum(c => c.Total);
                }
                if (Ocho.Count!=0) {
                    Ocho.LastOrDefault().tTotalvende = Ocho.Sum(c => c.Total);
                    a5= Ocho.Sum(c => c.Total);
                }
                if (Nueve.Count!=0)
                {
                    Nueve.LastOrDefault().tTotaldclientes = Nueve.Sum(c => c.Total);
                    a6= Nueve.Sum(c => c.Total);
                }

                if (Seis.Count != 0)
                {
                    Seis.LastOrDefault().TotalLiquidar = Seis.Sum(c => c.TotalLiquidar);
                    a7 = Seis.Sum(c => c.TotalLiquidar);
                }




                Sub1LPB subReport1 = new Sub1LPB();
                subReport1.DataSource = Dos;
                

               
                subReport1.nombrepro.DataBindings.Add("Text", null, "Nombre");
                subReport1.d1.DataBindings.Add("Text", null, "CargasPZA");
                subReport1.d2.DataBindings.Add("Text", null, "CargasKG");
                subReport1.d3.DataBindings.Add("Text", null, "DevolucionesCliPZA");
                subReport1.d4.DataBindings.Add("Text", null, "DevolucionesCliKG");
                subReport1.d5.DataBindings.Add("Text", null, "CambiosEntradaPZA");
                subReport1.d6.DataBindings.Add("Text", null, "CambiosEntradaKG");
                subReport1.d7.DataBindings.Add("Text", null, "CambiosSalidaPZA");
                subReport1.d8.DataBindings.Add("Text", null, "CambiosSalidaKG");
                subReport1.d9.DataBindings.Add("Text", null, "DegustacionPZA");
                subReport1.d10.DataBindings.Add("Text", null, "DegustacionKg");
                subReport1.d11.DataBindings.Add("Text", null, "DevolucionAlmacenPZA");
                subReport1.d12.DataBindings.Add("Text", null, "DevolucionAlmacenKG");
                subReport1.d13.DataBindings.Add("Text", null, "VentasContadoPZA");
                subReport1.d14.DataBindings.Add("Text", null, "VentasContadoKG");
                subReport1.d15.DataBindings.Add("Text", null, "VentasCreditoPZA");
                subReport1.d16.DataBindings.Add("Text", null, "VentasCreditoKG");
                subReport1.d17.DataBindings.Add("Text", null, "InventarioFinalPZA");
                subReport1.d18.DataBindings.Add("Text", null, "InventarioFinalKG");


                subReport1.t1.DataBindings.Add("Text", null, "tCargasPZA");
                subReport1.t2.DataBindings.Add("Text", null, "tCargasKG");
                subReport1.t3.DataBindings.Add("Text", null, "tDevolucionesCliPZA");
                subReport1.t4.DataBindings.Add("Text", null, "tDevolucionesCliKG");
                subReport1.t5.DataBindings.Add("Text", null, "tCambiosEntradaPZA");
                subReport1.t6.DataBindings.Add("Text", null, "tCambiosEntradaKG");
                subReport1.t7.DataBindings.Add("Text", null, "tCambiosSalidaPZA");
                subReport1.t8.DataBindings.Add("Text", null, "tCambiosSalidaKG");
                subReport1.t9.DataBindings.Add("Text", null, "tDegustacionPZA");
                subReport1.t10.DataBindings.Add("Text", null, "tDegustacionKg");
                subReport1.t11.DataBindings.Add("Text", null, "tDevolucionAlmacenPZA");
                subReport1.t12.DataBindings.Add("Text", null, "tDevolucionAlmacenKG");
                subReport1.t13.DataBindings.Add("Text", null, "tVentasContadoPZA");
                subReport1.t14.DataBindings.Add("Text", null, "tVentasContadoKG");
                subReport1.t15.DataBindings.Add("Text", null, "tVentasCreditoPZA");
                subReport1.t16.DataBindings.Add("Text", null, "tVentasCreditoKG");


                report.subre1.ReportSource = subReport1;

                ///ventasconado2

                Sub2LPB subReport2 = new Sub2LPB();
                subReport2.DataSource = Tres;
                
                report.subre2.ReportSource = subReport2;
                subReport2.vc1.DataBindings.Add("Text", null, "FolioVenta");
                subReport2.vc2.DataBindings.Add("Text", null, "FolioFactura");
                subReport2.vc3.DataBindings.Add("Text", null, "FechaHoraAlta", "{0:dd/MM/yyyy}");
                subReport2.vc4.DataBindings.Add("Text", null, "ClienteClave");
                subReport2.vc5.DataBindings.Add("Text", null, "Kilos");
                subReport2.vc6.DataBindings.Add("Text", null, "Total", "{0:$#,##0.00}");

                subReport2.vctkilos.DataBindings.Add("Text", null, "tKiloscon");
                subReport2.vctimporte.DataBindings.Add("Text", null, "tTotalcon", "{0:$#,##0.00}");
                report.subre2.ReportSource = subReport2;

                //VentasCrédito3
                Sub7LPB subReport7 = new Sub7LPB();
                subReport7.DataSource = Cuatro;

                              
                subReport7.vcre1.DataBindings.Add("Text", null, "FolioVenta");
                subReport7.vcre2.DataBindings.Add("Text", null, "FolioFactura");
                subReport7.vcre3.DataBindings.Add("Text", null, "FechaHoraAlta", "{0:dd/MM/yyyy}");
                subReport7.vcre4.DataBindings.Add("Text", null, "ClienteClave");
                subReport7.vcre5.DataBindings.Add("Text", null, "Kilos"); 
                subReport7.vcre6.DataBindings.Add("Text", null, "Total", "{0:$#,##0.00}");


                subReport7.vcretkilos.DataBindings.Add("Text", null, "tKiloscre");
                subReport7.vcretimporte.DataBindings.Add("Text", null, "tTotalcre", "{0:$#,##0.00}");
                report.subre7.ReportSource = subReport7;


                //Cobranza4
                Sub3LPB subReport3 = new Sub3LPB();
                subReport3.DataSource = Cinco;
                           

                subReport3.c1.DataBindings.Add("Text", null, "FolioCobranza");
                subReport3.c2.DataBindings.Add("Text", null, "FolioFactura");
                subReport3.c3.DataBindings.Add("Text", null, "FechaFactura", "{0:dd/MM/yyyy}");
                subReport3.c4.DataBindings.Add("Text", null, "Cliente");
                subReport3.c5.DataBindings.Add("Text", null, "Total", "{0:$#,##0.00}");
                subReport3.c6.DataBindings.Add("Text", null, "FechaCobranza", "{0:dd/MM/yyyy}");


                subReport3.ctotal.DataBindings.Add("Text", null, "tTotalcobra", "{0:$#,##0.00}");
                report.subre3.ReportSource = subReport3;



                //Ocho Gastos vendedor
                Sub4LPB subReport4 = new Sub4LPB();
                subReport4.DataSource = Ocho;
                
                subReport4.gv1.DataBindings.Add("Text", null, "Concepto");
                subReport4.gv2.DataBindings.Add("Text", null, "Folio");
                subReport4.gv3.DataBindings.Add("Text", null, "Total", "{0:$#,##0.00}");


                subReport4.gvtotal.DataBindings.Add("Text", null, "tTotalvende", "{0:$#,##0.00}");
                report.subre4.ReportSource = subReport4;

                //NueveDevoluciones Cliente
                Sub5LPB subReport5 = new Sub5LPB();
                subReport5.DataSource = Nueve;
               
                subReport5.dc1.DataBindings.Add("Text", null, "Cliente");
                subReport5.dc2.DataBindings.Add("Text", null, "Motivo");
                subReport5.dc3.DataBindings.Add("Text", null, "Pieza");
                subReport5.dc4.DataBindings.Add("Text", null, "Total", "{0:$#,##0.00}");
                subReport5.dc5.DataBindings.Add("Text", null, "Producto");


                subReport5.dctotal.DataBindings.Add("Text", null, "tTotaldclientes", "{0:$#,##0.00}");
                report.subre5.ReportSource = subReport5;


                //TOTALES

                //NueveDevoluciones Cliente
                Sub6LPB subReport6 = new Sub6LPB();
                subReport6.DataSource = Seis;
                a1 = a2 + a3;

                double d = a7 - a5;
                subReport6.lt1.Text=a1.ToString("$#,##0.00");
                subReport6.lt2.Text = a2.ToString("$#,##0.00");
                subReport6.lt3.Text = a3.ToString("$#,##0.00");
                subReport6.lt4.Text = a4.ToString("$#,##0.00");
                subReport6.lt5.Text = a5.ToString("$#,##0.00");
                subReport6.lt6.Text = a6.ToString("$#,##0.00");
                subReport6.lt7.Text = d.ToString("$#,##0.00");

                report.subre6.ReportSource = subReport6;

                if (Dos.Count == 0 && Tres.Count == 0 && Cuatro.Count == 0 && Cinco.Count == 0  && Ocho.Count == 0 && Nueve.Count == 0)
                {
                    return null;
                }
                else {
                    return report;
                }
                


                

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    
     class LiquidacionProducto
    {                           

        public String ProductoClave { get; set; }
        public String Nombre { get; set; }

        public double CargasPZA { get; set; }
        public double CargasKG { get; set; }

        public double DevolucionesCliPZA { get; set; }
        public double DevolucionesCliKG { get; set; }

        public double CambiosEntradaPZA { get; set; }
        public double CambiosEntradaKG { get; set; }


        public double CambiosSalidaPZA { get; set; }
        public double CambiosSalidaKG { get; set; }

                   
        public double DegustacionPZA { get; set; }
        public double DegustacionKg { get; set; }

        public double DevolucionAlmacenPZA { get; set; }
        public double DevolucionAlmacenKG { get; set; }


        public double VentasContadoPZA { get; set; }
        public double VentasContadoKG { get; set; }

        public double VentasCreditoPZA { get; set; }
        public double VentasCreditoKG { get; set; }

        public double InventarioFinalPZA { get; set; }
        public double InventarioFinalKG { get; set; }

        //TOTALES
        public double tCargasPZA { get; set; }
        public double tCargasKG { get; set; }

        public double tDevolucionesCliPZA { get; set; }
        public double tDevolucionesCliKG { get; set; }

        public double tCambiosEntradaPZA { get; set; }
        public double tCambiosEntradaKG { get; set; }


        public double tCambiosSalidaPZA { get; set; }
        public double tCambiosSalidaKG { get; set; }


        public double tDegustacionPZA { get; set; }
        public double tDegustacionKg { get; set; }

        public double tDevolucionAlmacenPZA { get; set; }
        public double tDevolucionAlmacenKG { get; set; }


        public double tVentasContadoPZA { get; set; }
        public double tVentasContadoKG { get; set; }

        public double tVentasCreditoPZA { get; set; }
        public double tVentasCreditoKG { get; set; }


    }   

    class ventacontado {
            
        public String FolioVenta { get; set; }
        public String FolioFactura { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public String ClienteClave { get; set; }
        public Double Total { get; set; }
        public Double Kilos { get; set; }
        

        public Double tTotalcon { get; set; }
        public Double tKiloscon { get; set; }

    }
    
        class direc
    {
    
        public String Domicilio { get; set; }
        public String Telefono { get; set; }

    }

    class ventacredito
    {

        public String FolioVenta { get; set; }
        public String FolioFactura { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public String ClienteClave { get; set; }
        public Double Total { get; set; }
        public Double Kilos { get; set; }
        

        public Double tTotalcre { get; set; }
        public Double tKiloscre { get; set; }

    }

    class cCobranza
    {
                   

        public String FolioCobranza { get; set; }
        public String FolioFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public String Cliente { get; set; }
        public double Total { get; set; }
        public DateTime FechaCobranza { get; set; }


        public double tTotalcobra { get; set; }

    }

    class GVendedor {
            
        public String Concepto { get; set; }
        public String Folio { get; set; }
        public double Total { get; set; }
        public double tTotalvende { get; set; }

    }

    class DClientes {
               
              public double Cliente { get; set; }
              public String Motivo { get; set; }
              public double Pieza { get; set; }
              public double Total { get; set; }
              public String Producto { get; set; }

              public double tTotaldclientes { get; set; }

    }

    class tliquidar {
        public double TotalLiquidar { get; set; }

    }

}