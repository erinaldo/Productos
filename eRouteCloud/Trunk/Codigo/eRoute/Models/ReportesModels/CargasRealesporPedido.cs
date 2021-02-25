using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class CargasRealesporPedido
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        ReporteCargasRealesporPedido report = new ReporteCargasRealesporPedido();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, int VAVClave, string pvCondicion, string RutasSplit, string FechaInicial, string Cedis, string nombreCedis, string unidadMedida)
        {
            //Logo Empresa
            string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);
            report.logo.Image = Image.FromStream(mStream);
            report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            report.empresa.Text = NombreEmpresa;
            report.reporte.Text = NombreReporte;

            //Almacen
            report.labelCEDIHeader.Text = nombreCedis;

            //Fecha de Carga
            DateTime fInicio = DateTime.Parse(FechaInicial);
            string FCapturaR = fInicio.Date.ToShortDateString();
            string FCaptura = fInicio.Date.ToString("yyyyMMdd");
            report.labelFechaHeader.Text = FCapturaR;

            //Rutas
            //Obtener Detalle
            StringBuilder CDetalle = new StringBuilder();
            CDetalle.AppendLine("Set ANSI_WARNINGS OFF ");
            CDetalle.AppendLine("Set nocount on ");
            CDetalle.AppendLine("Select Clave + ' ' + Descripcion as RutaDetalle, Clave as ClaveR from");
            CDetalle.AppendLine("(");
            CDetalle.AppendLine("select Ruta.RUTClave as Clave, Descripcion ");
            CDetalle.AppendLine("from Ruta (NOLOCK)");
            CDetalle.AppendLine(") as Detalle");
            CDetalle.AppendLine(pvCondicion);

            QueryString = "";
            QueryString = CDetalle.ToString();

            List<Detalle> Detalle = Connection.Query<Detalle>(QueryString, null, null, true, 600).ToList();

            var Det = (from D in Detalle select D).ToList().GroupBy(DD => new { DD.RutaDetalle })
                    .SelectMany(DL => DL.Select(DS => new Detalle
                    {
                        RutaDetalle = DS.RutaDetalle,
                        ClaveR = DS.ClaveR
                    })).ToList();
            string DetalleR = "";
            string RutaFiltro = "";
            foreach (var item in Det)
            {
                if (item == Det.Last())
                {
                    DetalleR += item.RutaDetalle;
                    RutaFiltro += "'" + item.ClaveR + "'";
                }
                else
                {
                    DetalleR += item.RutaDetalle + ", ";
                    RutaFiltro += "'" + item.ClaveR + "',";
                }
            }
            //---------------
            report.labelRutaHeader.Text = DetalleR;

            //Fecha de generación del Reporte
            DateTime fReporte = DateTime.Now;
            report.labelFechaReporteHeader.Text = fReporte.ToLocalTime() + "";

            float aux1 = Convert.ToInt32(report.TopMargin.HeightF);
            int contador = DetalleR.Length / 430;
            if (DetalleR.Length % 430 != 0)
                contador += 1;
            for (int i = 1; i < contador; i++)
            {
                aux1 += 20;
            }

            report.TopMargin.HeightF = (aux1);

            //Filtro
            string Filtro = FechaInicial.Substring(0, 4) + FechaInicial.Substring(5, 2) + FechaInicial.Substring(8, 2);
            //string Filtro = FechaInicial.Replace("06:00:00.000Z", "00:00:00");
            //string FiltroFin = FechaInicial.Replace("06:00:00.000Z", "23:00:00");
            string FiltroFin = FechaInicial.Substring(0, 4) + FechaInicial.Substring(5, 2) + FechaInicial.Substring(8, 2);

            //Obtiene las Rutas
            StringBuilder CRutas = new StringBuilder();
            CRutas.AppendLine("Set ANSI_WARNINGS OFF ");
            CRutas.AppendLine("Set nocount on ");
            CRutas.AppendLine("SELECT ");
            CRutas.AppendLine("Ruta, ");
            CRutas.AppendLine("isnull(Pedido, 'Cambios') as Pedido, ");
            CRutas.AppendLine("ProductoClave as SKU, ");
            CRutas.AppendLine("NombreLargo as Producto, ");
            CRutas.AppendLine("Unidad, ");
            CRutas.AppendLine("isnull(Venta,0) as Venta, ");
            CRutas.AppendLine("isnull(Cambios,0) as Cambios, ");
            CRutas.AppendLine("isnull(Promociones,0) as Promociones, ");
            CRutas.AppendLine("isnull(Venta,0)+isnull(Cambios,0)+isnull(Promociones,0) as CantidadPedido, ");
            CRutas.AppendLine("isnull(ImpVenta,0) as ImpPedido, ");
            CRutas.AppendLine("isnull(Entregado,0) as Entregado, ");
            CRutas.AppendLine("isnull(ImpEntregado,0) as ImpEntregado, ");
            CRutas.AppendLine("isnull(Venta,0)+isnull(Cambios,0)+isnull(Promociones,0) -isnull(Entregado,0) as Faltante, ");
            CRutas.AppendLine("isnull(ImpVenta,0) - isnull(ImpEntregado,0) as ImpFaltante, ");
            CRutas.AppendLine("case when (isnull(Venta,0)+isnull(Cambios,0)+isnull(Promociones,0)) > 0 then  (isnull(Entregado,0)/(isnull(Venta,0)+isnull(Cambios,0)+isnull(Promociones,0)))*100 else 0 end as Cumplimiento ");
            CRutas.AppendLine("FROM ");
            CRutas.AppendLine("( ");
            CRutas.AppendLine("select rep.Descripcion as Ruta,tp.Folio as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Venta' as Nombre, sum(isnull(tpd.CantidadOriginal, tpd.Cantidad)) as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 and  tpd.Precio > 0 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            CRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            CRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and tp.FechaEntrega between '" + Filtro + "' and '" + FiltroFin + "' and tr.Rutareparto in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by rep.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion ");
            CRutas.AppendLine("union all ");
            CRutas.AppendLine("select rep.Descripcion as Ruta,(select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo=1 and t.TipoFase=2 and t.VisitaClave=v.VisitaClave and t.DiaClave=v.DiaClave and t.ClienteClave=v.ClienteClave)as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Cambios' as Nombre, sum(tpd.Cantidad) as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=9 and  tp.TipoMovimiento=1 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            CRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            CRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and d.FechaCaptura   between  case when DATEPART(WEEKDAY,'" + Filtro + "')=1 THEN CAST('" + Filtro + "' AS DATETIME)-2 ELSE CAST('" + Filtro + "' AS DATETIME)-1  END  and case when DATEPART(WEEKDAY,'" + FiltroFin + "')=1 THEN CAST('" + FiltroFin + "' AS DATETIME)-2 ELSE CAST('" + FiltroFin + "' AS DATETIME)-1  END and tr.Rutareparto in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by rep.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion,v.VisitaClave,v.DiaClave,v.ClienteClave ");
            CRutas.AppendLine("union all ");
            CRutas.AppendLine("select rep.Descripcion as Ruta,tp.Folio as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Promociones' as Nombre, sum(tpd.Cantidad) as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 and  tpd.Precio = 0 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            CRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            CRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and tp.FechaEntrega  between '" + Filtro + "' and '" + FiltroFin + "' and tr.Rutareparto in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by rep.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion ");
            CRutas.AppendLine("union all ");
            CRutas.AppendLine("select r.Descripcion as Ruta,tp.Folio as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Entregado' as Nombre, sum(tpd.Cantidad) as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 and tp.TipoFase=2 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(tp.VisitaClave1,tp.VisitaClave) and v.DiaClave = isnull(tp.DiaClave1,tp.DiaClave) ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and d.FechaCaptura  between '" + Filtro + "' and '" + FiltroFin + "' and r.RUTClave in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by r.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion ");
            CRutas.AppendLine("union all ");
            CRutas.AppendLine("select r.Descripcion as Ruta,tp.Folio as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Entregado' as Nombre, sum(tpd.Cantidad) as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=9 and tp.TipoFase=1 and tp.TipoMovimiento=1 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(tp.VisitaClave1,tp.VisitaClave) and v.DiaClave = isnull(tp.DiaClave1,tp.DiaClave) ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and d.FechaCaptura  between '" + Filtro + "' and '" + FiltroFin + "' and r.RUTClave in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by r.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion ");
            CRutas.AppendLine("union all ");
            CRutas.AppendLine("select rep.Descripcion as Ruta,tp.Folio as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'ImpVenta' as Nombre, sum(isnull(tpd.CantidadOriginal,tpd.Cantidad) * tpd.Precio)  as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            CRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            CRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and tp.FechaEntrega  between '" + Filtro + "' and '" + FiltroFin + "' and tr.Rutareparto in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by rep.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion ");
            CRutas.AppendLine("union all ");
            //
            CRutas.AppendLine("select rep.Descripcion as Ruta,(select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo=1 and t.TipoFase=2 and t.VisitaClave=v.VisitaClave and t.DiaClave=v.DiaClave and t.ClienteClave=v.ClienteClave)as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'ImpVenta' as Nombre, sum(tpd.Cantidad*Precio) as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=9 and  tp.TipoMovimiento=1 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            CRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            CRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and d.FechaCaptura   between  case when DATEPART(WEEKDAY,'" + Filtro + "')=1 THEN CAST('" + Filtro + "' AS DATETIME)-2 ELSE CAST('" + Filtro + "' AS DATETIME)-1  END  and case when DATEPART(WEEKDAY,'" + FiltroFin + "')=1 THEN CAST('" + FiltroFin + "' AS DATETIME)-2 ELSE CAST('" + FiltroFin + "' AS DATETIME)-1  END and tr.Rutareparto in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by rep.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion,v.VisitaClave,v.DiaClave,v.ClienteClave ");
            CRutas.AppendLine("union all ");
            //
            CRutas.AppendLine("select r.Descripcion as Ruta,tp.Folio as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'ImpEntregado' as Nombre, sum(tpd.Cantidad * Precio) as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 and tp.TipoFase=2 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(tp.VisitaClave1,tp.VisitaClave) and v.DiaClave = isnull(tp.DiaClave1,tp.DiaClave) ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and d.FechaCaptura  between '" + Filtro + "' and '" + FiltroFin + "' and r.RUTClave in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by r.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion ");
            CRutas.AppendLine("Union all ");
            CRutas.AppendLine("select r.Descripcion as Ruta,tp.Folio as Pedido,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'ImpEntregado' as Nombre, sum(tpd.Cantidad * Precio) as Total ");
            CRutas.AppendLine("from Transprod tp (NOLOCK) ");
            CRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=9 and tp.TipoFase=1 and tp.TipoMovimiento=1 ");
            CRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            CRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(tp.VisitaClave1,tp.VisitaClave) and v.DiaClave = isnull(tp.DiaClave1,tp.DiaClave) ");
            CRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            CRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=3 ");
            CRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            CRutas.AppendLine("where 1 = 1 and d.FechaCaptura  between '" + Filtro + "' and '" + FiltroFin + "' and r.RUTClave in (" + RutaFiltro + ") ");
            CRutas.AppendLine("group by r.Descripcion,tp.Folio,p.ProductoClave,p.NombreLargo,va.Descripcion ");
            CRutas.AppendLine(") pvt ");
            CRutas.AppendLine("PIVOT ");
            CRutas.AppendLine("( ");
            CRutas.AppendLine("sum(Total) FOR Nombre IN ([Venta],[Cambios],[Promociones],[Entregado],[ImpVenta],[ImpEntregado]) ");
            CRutas.AppendLine(") AS PT ");
            CRutas.AppendLine("order by Ruta, Pedido, SKU ");

            QueryString = "";
            QueryString = CRutas.ToString();

            List<CargasRealesporPedidoModel> Rutas = Connection.Query<CargasRealesporPedidoModel>(QueryString, null, null, true, 600).ToList();
            //------
            var SubRutas = (from r in Rutas
                            select r).ToList();
            List<CargasRealesporPedidoModel> Rut = new List<CargasRealesporPedidoModel>();

            var SR = (from gr in SubRutas group gr by new { gr.Pedido } into grupo select grupo);

            foreach (var grupo in SR)
            {
                foreach (var objetoAgrupado in grupo)
                {
                    Rut.Add(new CargasRealesporPedidoModel
                    {
                        Ruta = objetoAgrupado.Ruta,
                        Pedido = objetoAgrupado.Pedido,
                        SKU = objetoAgrupado.SKU,
                        Producto = objetoAgrupado.Producto,
                        Unidad = objetoAgrupado.Unidad,
                        Venta = objetoAgrupado.Venta,
                        Cambios = objetoAgrupado.Cambios,
                        Promociones = objetoAgrupado.Promociones,
                        CantidadPedido = objetoAgrupado.CantidadPedido,
                        ImpPedido = objetoAgrupado.ImpPedido,
                        Entregado = objetoAgrupado.Entregado,
                        ImpEntregado = objetoAgrupado.ImpEntregado,
                        Faltante = objetoAgrupado.Faltante,
                        ImpFaltante = objetoAgrupado.ImpFaltante,
                        Cumplimiento = Math.Round(objetoAgrupado.Cumplimiento),
                        CumplimientoString = Math.Round(objetoAgrupado.Cumplimiento) + "%"
                    });
                    Rut.Last().Cabecera = "Pedido";
                    Rut.Last().Sub = "Subtotal";
                    Rut.Last().SubVenta = grupo.Sum(c => c.Venta);
                    Rut.Last().SubCambios = grupo.Sum(c => c.Cambios);
                    Rut.Last().SubPromociones = grupo.Sum(c => c.Promociones);
                    Rut.Last().SubCantidadPedido = grupo.Sum(c => c.CantidadPedido);
                    Rut.Last().SubImpPedido = grupo.Sum(c => c.ImpPedido);
                    Rut.Last().SubEntregado = grupo.Sum(c => c.Entregado);
                    Rut.Last().SubImpEntregado = grupo.Sum(c => c.ImpEntregado);
                    Rut.Last().SubFaltante = grupo.Sum(c => c.Faltante);
                    Rut.Last().SubImpFaltante = grupo.Sum(c => c.ImpFaltante);
                    double b = (double)grupo.Sum(c => c.CantidadPedido);
                    double a = (double)grupo.Sum(c => c.Entregado);
                    if (b != 0)
                    {
                        double c = Math.Round((a / b) * 100);
                        Rut.Last().SubCumplimiento = c + "%";
                    }
                    else
                    {
                        double c = 0;
                        Rut.Last().SubCumplimiento = c + "%";
                    }
                }
            }
            //------
            SubreporteSTotal subreportS = new SubreporteSTotal();
            subreportS.DataSource = Rut;

            //grouheader2
            GroupField groupRuta = new GroupField("Ruta");
            subreportS.GroupHeader2.GroupFields.Add(groupRuta);
            subreportS.labelRutaDetalle.DataBindings.Add("Text", report.DataSource, "Ruta");

            //grouheader1
            GroupField groupPedido = new GroupField("Pedido");
            subreportS.GroupHeader1.GroupFields.Add(groupPedido);
            subreportS.xrLabel15.DataBindings.Add("Text", report.DataSource, "Cabecera");
            subreportS.labelPedidoID.DataBindings.Add("Text", report.DataSource, "Pedido");

            //Datos Generales
            subreportS.labelSKUDetallado.DataBindings.Add("Text", null, "SKU");
            subreportS.labelProductoDetallado.DataBindings.Add("Text", null, "Producto");
            subreportS.labelUMDetallado.DataBindings.Add("Text", null, "Unidad");
            subreportS.labelVentaDetallado.DataBindings.Add("Text", null, "Venta");
            subreportS.labelCambiosDetallado.DataBindings.Add("Text", null, "Cambios");
            subreportS.labelPromocionesDetallado.DataBindings.Add("Text", null, "Promociones");
            subreportS.labelCantidadPDetallado.DataBindings.Add("Text", null, "CantidadPedido");
            subreportS.labelImportePDetallado.DataBindings.Add("Text", null, "ImpPedido", "{0:$0.00}");
            subreportS.labelPiezasDetalle.DataBindings.Add("Text", null, "Entregado");
            subreportS.labelImporteRCDetallado.DataBindings.Add("Text", null, "ImpEntregado", "{0:$0.00}");
            subreportS.labelFaltantesDetallado.DataBindings.Add("Text", null, "Faltante");
            subreportS.labelImporteFDetallado.DataBindings.Add("Text", null, "ImpFaltante", "{0:$0.00}");
            subreportS.labelCumplimientoDetallado.DataBindings.Add("Text", null, "CumplimientoString");

            //GroupFooter3
            subreportS.xrLabel35.DataBindings.Add("Text", report.DataSource, "Sub");
            subreportS.labelVentaS.DataBindings.Add("Text", null, "SubVenta");
            subreportS.labelCambiosS.DataBindings.Add("Text", null, "SubCambios");
            subreportS.labelPromocionesS.DataBindings.Add("Text", null, "SubPromociones");
            subreportS.labelCantidadPS.DataBindings.Add("Text", null, "SubCantidadPedido");
            subreportS.labelImportePS.DataBindings.Add("Text", null, "SubImpPedido", "{0:$0.00}");
            subreportS.labelPiezasS.DataBindings.Add("Text", null, "SubEntregado");
            subreportS.labelImporteRCS.DataBindings.Add("Text", null, "SubImpEntregado", "{0:$0.00}");
            subreportS.labelFaltantesS.DataBindings.Add("Text", null, "SubFaltante");
            subreportS.labelImporteFS.DataBindings.Add("Text", null, "SubImpFaltante", "{0:$0.00}");
            subreportS.labelCumplimientoS.DataBindings.Add("Text", null, "SubCumplimiento");

            if (Rut.Count > 0)
            {
                report.xrSubreportSub.ReportSource = subreportS;
            }

            //SubconsultaGral
            StringBuilder GralRutas = new StringBuilder();
            GralRutas.AppendLine("Set ANSI_WARNINGS OFF ");
            GralRutas.AppendLine("Set nocount on ");
            GralRutas.AppendLine("SELECT ");
            GralRutas.AppendLine("Ruta, ");
            GralRutas.AppendLine("ProductoClave as SKU, ");
            GralRutas.AppendLine("NombreLargo as Producto, ");
            GralRutas.AppendLine("Unidad, ");
            GralRutas.AppendLine("isnull(Venta,0) as Venta, ");
            GralRutas.AppendLine("isnull(Cambios,0) as Cambios, ");
            GralRutas.AppendLine("isnull(Promociones,0) as Promociones, ");
            GralRutas.AppendLine("isnull(Venta,0)+isnull(Cambios,0)+isnull(Promociones,0) as CantidadPedido, ");
            GralRutas.AppendLine("isnull(ImpVenta,0) as ImpPedido, ");
            GralRutas.AppendLine("isnull(Entregado,0) as Entregado, ");
            GralRutas.AppendLine("isnull(ImpEntregado,0) as ImpEntregado, ");
            GralRutas.AppendLine("isnull(Venta,0)+isnull(Cambios,0)+isnull(Promociones,0) -isnull(Entregado,0)  as Faltante, ");
            GralRutas.AppendLine("isnull(ImpVenta,0) - isnull(ImpEntregado,0) as ImpFaltante, ");
            GralRutas.AppendLine("case when (isnull(Venta,0)+isnull(Cambios,0)+isnull(Promociones,0)) > 0 then  (isnull(Entregado,0)/(isnull(Venta,0)+isnull(Cambios,0)+isnull(Promociones,0)))*100 else 0 end as Cumplimiento ");
            GralRutas.AppendLine("FROM (");
            GralRutas.AppendLine("select rep.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Venta' as Nombre, isnull(tpd.CantidadOriginal, tpd.Cantidad) as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK)");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 and  tpd.Precio > 0 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            GralRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            GralRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and tp.FechaEntrega  between '" + Filtro + "' and '" + FiltroFin + "' and tr.Rutareparto in (" + RutaFiltro + ") ");
            GralRutas.AppendLine("union all ");
            GralRutas.AppendLine("select rep.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Cambios' as Nombre, tpd.Cantidad as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK) ");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=9 and  tp.TipoMovimiento=1 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            GralRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            GralRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and d.FechaCaptura   between  case when DATEPART(WEEKDAY,'" + Filtro + "')=1 THEN CAST('" + Filtro + "' AS DATETIME)-2 ELSE CAST('" + Filtro + "' AS DATETIME)-1  END  and case when DATEPART(WEEKDAY,'" + FiltroFin + "')=1 THEN CAST('" + FiltroFin + "' AS DATETIME)-2 ELSE CAST('" + FiltroFin + "' AS DATETIME)-1  END and tr.Rutareparto in (" + RutaFiltro + ") ");
            GralRutas.AppendLine("union all ");
            GralRutas.AppendLine("select rep.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Promociones' as Nombre, tpd.Cantidad as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK) ");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 and  tpd.Precio = 0 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            GralRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            GralRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and tp.FechaEntrega  between '" + Filtro + "' and '" + FiltroFin + "' and tr.Rutareparto in (" + RutaFiltro + ") ");
            GralRutas.AppendLine("union all ");
            GralRutas.AppendLine("select rep.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'ImpVenta' as Nombre, isnull(tpd.CantidadOriginal,tpd.Cantidad) * tpd.Precio  as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK) ");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            GralRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            GralRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and tp.FechaEntrega  between '" + Filtro + "' and '" + FiltroFin + "' and tr.Rutareparto in (" + RutaFiltro + ") ");
            GralRutas.AppendLine("union all ");
            //
            GralRutas.AppendLine("select rep.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'ImpVenta' as Nombre, tpd.Cantidad*Precio as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK) ");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=9 and  tp.TipoMovimiento=1 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=tp.VisitaClave and v.DiaClave = tp.DiaClave ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=2 ");
            GralRutas.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave ");
            GralRutas.AppendLine("inner join Ruta rep (NOLOCK) on rep.RUTClave = tr.RutaReparto and rep.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and d.FechaCaptura   between  case when DATEPART(WEEKDAY,'" + Filtro + "')=1 THEN CAST('" + Filtro + "' AS DATETIME)-2 ELSE CAST('" + Filtro + "' AS DATETIME)-1  END  and case when DATEPART(WEEKDAY,'" + FiltroFin + "')=1 THEN CAST('" + FiltroFin + "' AS DATETIME)-2 ELSE CAST('" + FiltroFin + "' AS DATETIME)-1  END and tr.Rutareparto in (" + RutaFiltro + ") ");
            GralRutas.AppendLine("union all ");
            //
            GralRutas.AppendLine("select r.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Entregado' as Nombre, tpd.Cantidad  as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK) ");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 and tp.TipoFase=2 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(tp.VisitaClave1,tp.VisitaClave) and v.DiaClave = isnull(tp.DiaClave1,tp.DiaClave) ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and d.FechaCaptura  between '" + Filtro + "' and '" + FiltroFin + "' and r.RUTClave in (" + RutaFiltro + ") ");
            GralRutas.AppendLine("union all ");
            GralRutas.AppendLine("select r.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'Entregado' as Nombre, tpd.Cantidad  as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK) ");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=9 and tp.TipoFase=1 and tp.TipoMovimiento=1 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(tp.VisitaClave1,tp.VisitaClave) and v.DiaClave = isnull(tp.DiaClave1,tp.DiaClave) ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and d.FechaCaptura  between '" + Filtro + "' and '" + FiltroFin + "' and r.RUTClave in (" + RutaFiltro + ") ");
            GralRutas.AppendLine("union all ");
            GralRutas.AppendLine("select r.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'ImpEntregado' as Nombre, tpd.Cantidad * Precio   as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK) ");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=1 and tp.TipoFase=2 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(tp.VisitaClave1,tp.VisitaClave) and v.DiaClave = isnull(tp.DiaClave1,tp.DiaClave) ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and d.FechaCaptura  between '" + Filtro + "' and '" + FiltroFin + "' and r.RUTClave in (" + RutaFiltro + ") ");
            GralRutas.AppendLine("Union all ");
            GralRutas.AppendLine("select r.Descripcion as Ruta,p.ProductoClave,p.NombreLargo,va.Descripcion as Unidad,'ImpEntregado' as Nombre, tpd.Cantidad * Precio  as Total ");
            GralRutas.AppendLine("from Transprod tp (NOLOCK) ");
            GralRutas.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo=9 and tp.TipoFase=1 and tp.TipoMovimiento=1 ");
            GralRutas.AppendLine("inner join Producto p (NOLOCK) on tpd.ProductoClave = P.ProductoClave ");
            GralRutas.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(tp.VisitaClave1,tp.VisitaClave) and v.DiaClave = isnull(tp.DiaClave1,tp.DiaClave) ");
            GralRutas.AppendLine("inner join Dia d (NOLOCK) on v.DiaClave=d.DiaClave ");
            GralRutas.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave and r.Tipo=3 ");
            GralRutas.AppendLine("inner join VAVDescripcion va (NOLOCK) on va.VAVClave=tpd.TipoUnidad and va.VARCodigo='UNIDADV' and VADTipoLenguaje='EM' ");
            GralRutas.AppendLine("where 1 = 1 and d.FechaCaptura  between '" + Filtro + "' and '" + FiltroFin + "' and r.RUTClave in (" + RutaFiltro + ") ");
            GralRutas.AppendLine(") pvt ");
            GralRutas.AppendLine("PIVOT ");
            GralRutas.AppendLine("( ");
            GralRutas.AppendLine("sum(Total) FOR Nombre IN ([Venta],[Cambios],[Promociones],[Entregado],[ImpVenta],[ImpEntregado]) ");
            GralRutas.AppendLine(") AS PT ");
            GralRutas.AppendLine("order by Ruta, SKU");

            QueryString = "";
            QueryString = GralRutas.ToString();

            List<CargasRealesporPedidoGralModel> General = Connection.Query<CargasRealesporPedidoGralModel>(QueryString, null, null, true, 600).ToList();
            var SubGeneral = (from c in General
                              select c).ToList();
            List<CargasRealesporPedidoGralModel> Gral = new List<CargasRealesporPedidoGralModel>();

            var SG = (from gr in SubGeneral group gr by new { gr.SKU } into grupo select grupo);

            long TotalVenta = 0;
            long TotalCambio = 0;
            long TotalPromocion = 0;
            long TotalPedido = 0;
            Decimal TotalImpPedido = 0;
            long TotalEntregado = 0;
            Decimal TotalImpEntregado = 0;
            long TotalFaltante = 0;
            Decimal TotalImpFaltante = 0;
            string TotalCumplimiento = "";

            foreach (var grupo in SG)
            {
                foreach (var objetoAgrupado in grupo)
                {
                    Gral.Add(new CargasRealesporPedidoGralModel
                    {
                        Ruta = objetoAgrupado.Ruta,
                        Pedido = objetoAgrupado.Pedido,
                        SKU = objetoAgrupado.SKU,
                        Producto = objetoAgrupado.Producto,
                        Unidad = objetoAgrupado.Unidad,
                        Venta = objetoAgrupado.Venta,
                        Cambios = objetoAgrupado.Cambios,
                        Promociones = objetoAgrupado.Promociones,
                        CantidadPedido = objetoAgrupado.CantidadPedido,
                        ImpPedido = objetoAgrupado.ImpPedido,
                        Entregado = objetoAgrupado.Entregado,
                        ImpEntregado = objetoAgrupado.ImpEntregado,
                        Faltante = objetoAgrupado.Faltante,
                        ImpFaltante = objetoAgrupado.ImpFaltante,
                        Cumplimiento = Math.Round(objetoAgrupado.Cumplimiento),
                        CumplimientoString = Math.Round(objetoAgrupado.Cumplimiento) + "%",
                    });
                    Gral.Last().Gran = "Gran Total";

                    TotalVenta += objetoAgrupado.Venta;
                    TotalCambio += objetoAgrupado.Cambios;
                    TotalPromocion += objetoAgrupado.Promociones;
                    TotalPedido += objetoAgrupado.CantidadPedido;
                    TotalImpPedido += objetoAgrupado.ImpPedido;
                    TotalEntregado += objetoAgrupado.Entregado;
                    TotalImpEntregado += objetoAgrupado.ImpEntregado;
                    TotalFaltante += objetoAgrupado.Faltante;
                    TotalImpFaltante += objetoAgrupado.ImpFaltante;
                }
            }
            if (TotalPedido != 0)
            {
                double c = Math.Round(((double)TotalEntregado / (double)TotalPedido) * 100);
                TotalCumplimiento = c + "%";
            }
            else
            {
                double c = 0;
                TotalCumplimiento = c + "%";
            }

            SubreporteGral subreport = new SubreporteGral();

            subreport.DataSource = Gral;
            subreport.labelSKUResumido.DataBindings.Add("Text", null, "SKU");
            subreport.labelProductoResumido.DataBindings.Add("Text", null, "Producto");
            subreport.labelUMResumido.DataBindings.Add("Text", null, "Unidad");
            subreport.labelVentaResumido.DataBindings.Add("Text", null, "Venta");
            subreport.labelCambiosResumido.DataBindings.Add("Text", null, "Cambios");
            subreport.labelPromocionesResumido.DataBindings.Add("Text", null, "Promociones");
            subreport.labelCantidadPResumido.DataBindings.Add("Text", null, "CantidadPedido");
            subreport.labelImportePResumido.DataBindings.Add("Text", null, "ImpPedido", "{0:$0.00}");
            subreport.labelPiezasResumido.DataBindings.Add("Text", null, "Entregado");
            subreport.labelImporteRCResumido.DataBindings.Add("Text", null, "ImpEntregado", "{0:$0.00}");
            subreport.labelFaltantesResumido.DataBindings.Add("Text", null, "Faltante");
            subreport.labelImporteFResumido.DataBindings.Add("Text", null, "ImpFaltante", "{0:$0.00}");
            subreport.labelCumplimientoResumido.DataBindings.Add("Text", null, "CumplimientoString");

            subreport.labelVentaT.Text = TotalVenta + "";
            subreport.labelCambiosT.Text = TotalCambio + "";
            subreport.labelPromocionesT.Text = TotalPromocion + "";
            subreport.labelCantidadPT.Text = TotalPedido + "";
            subreport.labelImportePT.Text = TotalImpPedido.ToString("$0.00");
            subreport.labelPiezasT.Text = TotalEntregado + "";
            subreport.labelImporteRCT.Text = TotalImpEntregado.ToString("$0.00");
            subreport.labelFaltantesT.Text = TotalFaltante + "";
            subreport.labelImporteFT.Text = TotalImpFaltante.ToString("$0.00");
            subreport.labelCumplimientoT.Text = TotalCumplimiento;

            report.xrSubreportGral.ReportSource = subreport;

            //Regresa el reporte completo
            if (Rut.Count == 0 && Gral.Count == 0)
            {
                return null;
            }
            else
            {
                return report;
            }
        }

    }

    class CargasRealesporPedidoModel
    {
        public string Cabecera { get; set; }
        public string Sub { get; set; }
        public string Ruta { get; set; }
        public string Pedido { get; set; }
        public string SKU { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public long Venta { get; set; }
        public long Cambios { get; set; }
        public long Promociones { get; set; }
        public long CantidadPedido { get; set; }
        public Decimal ImpPedido { get; set; }
        public long Entregado { get; set; }
        public Decimal ImpEntregado { get; set; }
        public long Faltante { get; set; }
        public Decimal ImpFaltante { get; set; }
        public string CumplimientoString { get; set; }
        public double Cumplimiento { get; set; }

        public long SubVenta { get; set; }
        public long SubCambios { get; set; }
        public long SubPromociones { get; set; }
        public long SubCantidadPedido { get; set; }
        public Decimal SubImpPedido { get; set; }
        public long SubEntregado { get; set; }
        public Decimal SubImpEntregado { get; set; }
        public long SubFaltante { get; set; }
        public Decimal SubImpFaltante { get; set; }
        public string SubCumplimiento { get; set; }
    }

    class CargasRealesporPedidoGralModel
    {
        public string Cabecera { get; set; }
        public string Gran { get; set; }
        public string Ruta { get; set; }
        public string Pedido { get; set; }
        public string SKU { get; set; }
        public string Producto { get; set; }
        public string Unidad { get; set; }
        public long Venta { get; set; }
        public long Cambios { get; set; }
        public long Promociones { get; set; }
        public long CantidadPedido { get; set; }
        public Decimal ImpPedido { get; set; }
        public long Entregado { get; set; }
        public Decimal ImpEntregado { get; set; }
        public long Faltante { get; set; }
        public Decimal ImpFaltante { get; set; }
        public string CumplimientoString { get; set; }
        public double Cumplimiento { get; set; }
        public string SubCumplimiento { get; set; }
    }

    class Detalle
    {
        public string RutaDetalle { get; set; }
        public string ClaveR { get; set; }
    }

}