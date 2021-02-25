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
    public class VentaDetalladoCompleto
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string ClientesSplit, string FechaInicial, string Cedis, bool detallado, int nPresupuesto)
        {
            RouteEntities db = new RouteEntities();
            StringBuilder sConsulta = new StringBuilder();
            DateTime init = DateTime.Parse(FechaInicial);



            long clientesConCompra = 0, pedidosEntregados = 0, pedidosPorEntregar = 0, tiempoRecorrido = 0, clientesVisitados = 0;

            bool TipoRutaB = true;

            var TipoRuta = (from x in db.Ruta where x.RUTClave == RutasSplit select new { x.Tipo }).ToList();

            sConsulta.AppendLine("select Tipo From Ruta (NOLOCK) ");
            sConsulta.AppendLine("where RUTClave = '" + RutasSplit + "'");
            QueryString = "";



            QueryString = sConsulta.ToString();

            List<TipoRutaList> Ruta = Connection.Query<TipoRutaList>(QueryString, null, null, true, 600).ToList();

            QueryString = "";
            sConsulta = new StringBuilder();
            //   sConsulta.AppendLine("set @RUTClave = ");
            sConsulta.AppendLine("Select count(Distinct VIS.ClienteClave) as ClientesVisitados ");
            sConsulta.AppendLine(" from Visita VIS (NOLOCK) ");
            sConsulta.AppendLine("  inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("where VIS.RUTClave = '" + RutasSplit + "' and Dia.FechaCaptura = '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'");
            QueryString = sConsulta.ToString();

            List<ResumenHeader> ClienteVistados = Connection.Query<ResumenHeader>(QueryString, null, null, true, 600).ToList();

            clientesVisitados = ClienteVistados.Last().ClientesVisitados;

            QueryString = "";
            sConsulta = new StringBuilder();
            sConsulta.AppendLine(" Select sum(DateDiff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) as TiempoRecorrido  ");
            sConsulta.AppendLine(" from Visita VIS (NOLOCK) ");
            sConsulta.AppendLine("inner  join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("where VIS.RUTClave = '" + RutasSplit + "' and Dia.FechaCaptura = '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'");
            QueryString = sConsulta.ToString();

            List<ResumenHeader> tiempoRec = Connection.Query<ResumenHeader>(QueryString, null, null, true, 600).ToList();

            tiempoRecorrido = tiempoRec.Last().TiempoRecorrido;

            foreach (var b in Ruta)
            {

                if (b.Tipo == 2)
                {
                    TipoRutaB = true;
                }
                else if (b.Tipo == 3) //reparto
                {
                    TipoRutaB = false;
                }
                else
                {
                    TipoRutaB = true;
                }
            }

            /* true  --> Auto-Venta Preventa
             * false --> Reparto
             * **/

            /*CONSULTAS VENTA POR CLIENTES COMPLETA - DETALLADO**/
            sConsulta = new StringBuilder();

            if (TipoRutaB == true) //Preventa
            {
                sConsulta.AppendLine(" SELECT Clave, RazonSocial, Folio, DiaClave, ProductoClave as SKU, NombreLargo as Producto, Descripcion as Unidad_de_Medida, ");
                sConsulta.AppendLine("isnull(Venta, 0) as Venta, isnull(Cambios, 0) as Cambios, isnull([Promociones],0) as Promociones, isnull(Importe, 0) as Importe_Venta ");
                sConsulta.AppendLine("FROM( ");
                sConsulta.AppendLine("select c.Clave, c.RazonSocial, tp.Folio, d.DiaClave, p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select c.Clave, c.RazonSocial, (select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo = 1 and t.TipoFase <> 0 and vi.DiaClave = isnull(t.VisitaClave1, t.VisitaClave) and vi.DiaClave = isnull(t.DiaClave1, t.DiaClave)  and t.ClienteClave = vi.ClienteClave) as Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 9 and tp.TipoFase <> 0 and tp.TipoMovimiento = 1 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("  from TransProd tp (NOLOCK) ");

                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 and tpd.Promocion = 2 and tpd.Total = 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("  union all ");
                sConsulta.AppendLine("select c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");

                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");

                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("   ) pvt ");
                sConsulta.AppendLine("   PIVOT ");
                sConsulta.AppendLine("( ");
                sConsulta.AppendLine("sum(Total) FOR Nombre IN([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe]) ");
                sConsulta.AppendLine(") AS PivotTable; ");

            }
            else //Reparto
            {
                sConsulta.AppendLine(" SELECT Clave, RazonSocial, Folio, DiaClave, ProductoClave as SKU, NombreLargo as Producto, Descripcion as Unidad_de_Medida, ");
                sConsulta.AppendLine("isnull(Venta, 0) as Venta, isnull(Cambios, 0) as Cambios, isnull([Promociones],0) as Promociones, isnull(Importe, 0) as Importe_Venta ");
                sConsulta.AppendLine("FROM( ");
                sConsulta.AppendLine("select c.Clave, c.RazonSocial, tp.Folio, d.DiaClave, p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select c.Clave, c.RazonSocial, (select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo = 1 and t.TipoFase <> 0 and vi.DiaClave = isnull(t.VisitaClave1, t.VisitaClave) and vi.DiaClave = isnull(t.DiaClave1, t.DiaClave)  and t.ClienteClave = vi.ClienteClave) as Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 9 and tp.TipoFase <> 0 and tp.TipoMovimiento = 1 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("  from TransProd tp (NOLOCK) ");

                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 and tpd.Promocion = 2 and tpd.Total = 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("  union all ");
                sConsulta.AppendLine("select c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");

                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");

                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("   ) pvt ");
                sConsulta.AppendLine("   PIVOT ");
                sConsulta.AppendLine("( ");
                sConsulta.AppendLine("sum(Total) FOR Nombre IN([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe]) ");
                sConsulta.AppendLine(") AS PivotTable; ");
            }


            QueryString = "";

            QueryString = sConsulta.ToString();


            List<AutoVentaPreventaCompleto> User = Connection.Query<AutoVentaPreventaCompleto>(QueryString, null, null, true, 600).ToList();


            if (User.Count == 0)
            {
                return null;
            }

            User.LastOrDefault().TotalPiezas = User.Sum(c => c.Venta);
            User.LastOrDefault().TotalPiezasCambio = User.Sum(c => c.Cambios);
            User.LastOrDefault().TotalPiezasPromocion = User.Sum(c => c.Promociones);
            User.LastOrDefault().TotalImporte = User.Sum(c => c.Importe_Venta);

            sConsulta = new StringBuilder();

            if (TipoRutaB == true)
            {

                sConsulta.AppendLine("SELECT ProductoClave as SKU, NombreLargo as Producto, Descripcion as Unidad_de_Medida, isnull(Venta, 0) as Venta, ");
                sConsulta.AppendLine("isnull(Cambios, 0) as Cambios, isnull([Promociones],0) as Promociones, isnull(Importe, 0) as Importe_Venta, ");

                sConsulta.AppendLine("(select count(cte.Clave) from Cliente cte (NOLOCK) ");
                sConsulta.AppendLine("inner join Transprod tp (NOLOCK) on tp.Tipo = 1 and tp.TipoFase <> 0 and tp.ClienteClave = cte.ClienteClave ");

                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave =  tp.VisitaClave and vi.DiaClave = tp.DiaClave ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ) as Clientes_Compra, ");
                sConsulta.AppendLine("isnull(CompraEfectiva, 0) as Compra_Efectiva ");
                sConsulta.AppendLine("FROM( ");
                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave =  tp.VisitaClave and vi.DiaClave = tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");

                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 9 and tp.TipoFase <> 0 and tp.TipoMovimiento = 1 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave =  tp.VisitaClave and vi.DiaClave = tp.DiaClave ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 and tpd.Promocion = 2 and tpd.Total = 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave =  tp.VisitaClave and vi.DiaClave = tp.DiaClave ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave =  tp.VisitaClave and vi.DiaClave = tp.DiaClave ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'CompraEfectiva' as Nombre, 1 as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave =  tp.VisitaClave and vi.DiaClave = tp.DiaClave ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("group by p.ProductoClave, p.NombreLargo, vd.Descripcion, tp.ClienteClave ");
                sConsulta.AppendLine(") pvt ");
                sConsulta.AppendLine("PIVOT ");
                sConsulta.AppendLine("( ");
                sConsulta.AppendLine("sum(Total) FOR Nombre IN([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe], [CompraEfectiva]) ");
                sConsulta.AppendLine(") AS PivotTable; ");
                sConsulta.AppendLine(" ");

            }
            else
            {
                /**RESUMEN POR CODIGO*/

                sConsulta.AppendLine("SELECT ProductoClave as SKU, NombreLargo as Producto, Descripcion as Unidad_de_Medida, isnull(Venta, 0) as Venta, ");
                sConsulta.AppendLine("isnull(Cambios, 0) as Cambios, isnull([Promociones],0) as Promociones, isnull(Importe, 0) as Importe_Venta, ");

                sConsulta.AppendLine("(select count(cte.Clave) from Cliente cte (NOLOCK) ");
                sConsulta.AppendLine("inner join Transprod tp (NOLOCK) on tp.Tipo = 1 and tp.TipoFase <> 0 and tp.ClienteClave = cte.ClienteClave ");

                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(" ) as Clientes_Compra, ");
                sConsulta.AppendLine("isnull(CompraEfectiva, 0) as Compra_Efectiva ");
                sConsulta.AppendLine("FROM( ");
                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");

                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 9 and tp.TipoFase <> 0 and tp.TipoMovimiento = 1 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 and tpd.Promocion = 2 and tpd.Total = 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select p.ProductoClave, p.NombreLargo, vd.Descripcion, 'CompraEfectiva' as Nombre, 1 as Total ");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase <> 0 ");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave, tp.VisitaClave1) and vi.DiaClave = isnull(tp.DiaClave, tp.DiaClave1) ");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                sConsulta.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave = c.ClienteClave ");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("group by p.ProductoClave, p.NombreLargo, vd.Descripcion, tp.ClienteClave ");
                sConsulta.AppendLine(") pvt ");
                sConsulta.AppendLine("PIVOT ");
                sConsulta.AppendLine("( ");
                sConsulta.AppendLine("sum(Total) FOR Nombre IN([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe], [CompraEfectiva]) ");
                sConsulta.AppendLine(") AS PivotTable; ");
                sConsulta.AppendLine(" ");

            }


            QueryString = "";

            QueryString = sConsulta.ToString();


            List<ResumenPorCodigoList> resumenPorCodigo = Connection.Query<ResumenPorCodigoList>(QueryString, null, null, true, 600).ToList();


            ResumenCorto resumenCorto = new ResumenCorto();
            ResumenLargo resumenLargo = new ResumenLargo();

            AutoVentaPreventaCompleto reporteDetallado = new AutoVentaPreventaCompleto();
            AutoVentaResumen reporteResumen = new AutoVentaResumen();


            dImporte AutoventaPreventaCompleto = new dImporte();

            //Sí es verdadero es preventa sí no es reparto
            //Primera Parte
            if (TipoRutaB)
            {
                /*
                sConsulta = new StringBuilder();

                sConsulta.AppendLine("DECLARE @FechaFiltro as datetime, @RUTClave as varchar(10) ");
                sConsulta.AppendLine("set @FechaFiltro =  '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'");
                sConsulta.AppendLine("set @RUTClave = '" + RutasSplit + "'");
                sConsulta.AppendLine("DECLARE @TipoFasePedido Integer ");
                sConsulta.AppendLine("Select @TipoFasePedido = CASE WHEN Tipo in(1,3) THEN 2 ELSE 1 END ");
                sConsulta.AppendLine("from Ruta where RUTClave = @RUTClave ");
                sConsulta.AppendLine("Select *, ");
                sConsulta.AppendLine("CASE WHEN ClientesProgramados = 0 THEN 0 ELSE(ClientesVisitados / ClientesProgramados) * 100 END as EfectividadVisita,  ");
                sConsulta.AppendLine("CASE WHEN ClientesVisitados = 0 THEN 0 ELSE(ClientesConCompra / ClientesVisitados) * 100 END as EfectividadCompra ");
                sConsulta.AppendLine("from ");
                sConsulta.AppendLine("( ");
                sConsulta.AppendLine("    Select count(Distinct AGV.ClienteClave) as Cantidad, 'ClientesProgramados' as Dato ");
                sConsulta.AppendLine("    from AgendaVendedor AGV ");
                sConsulta.AppendLine(" inner join Dia on AGV.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("    where AGV.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.AppendLine("  UNION ALL ");
                sConsulta.AppendLine("Select count(Distinct VIS.ClienteClave) as Cantidad, 'ClientesVisitados' as Dato ");
                sConsulta.AppendLine("    from Visita VIS ");
                sConsulta.AppendLine("  inner  join Dia on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine(" where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.AppendLine("  UNION ALL ");
                sConsulta.AppendLine("    Select count(Distinct VIS.ClienteClave) as Cantidad, 'ClientesConCompra' ");
                sConsulta.AppendLine(" from Visita VIS ");
                sConsulta.AppendLine(" inner join Dia on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join TransProd TRP on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("    where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro and TRP.Tipo = 1 and TRP.TipoFase = @TipoFasePedido ");
                sConsulta.AppendLine(") as ResumenOperativo PIVOT( ");
                sConsulta.AppendLine("SUM(Cantidad) ");
                sConsulta.AppendLine("FOR Dato IN([ClientesProgramados], [ClientesVisitados], [ClientesConCompra]) ");
                sConsulta.AppendLine(") AS ContadoresRuta ");

                QueryString = "";

                QueryString = sConsulta.ToString();


                List<ResumenHeader> resumenHeader = Connection.Query<ResumenHeader>(QueryString, null, null, true, 600).ToList();
                */
                sConsulta = new StringBuilder();
                /*
                sConsulta.AppendLine("DECLARE @FechaFiltro as datetime, @RUTClave as varchar(10) ");
                sConsulta.AppendLine("set @FechaFiltro =  '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'");

                sConsulta.AppendLine("set @RUTClave = '" + RutasSplit + "'");
                sConsulta.AppendLine("DECLARE @TipoFasePedido Integer ");

                sConsulta.AppendLine("Select @TipoFasePedido = CASE WHEN Tipo in(1,3) THEN 2 ELSE 1 END ");
                sConsulta.AppendLine("from Ruta where RUTClave = @RUTClave ");
                sConsulta.AppendLine("DECLARE @VendedorID as varchar(16), @InicioJornada datetime, @FinJornada datetime ");
                sConsulta.AppendLine("Select @VendedorID = VEJ.VendedorId, @InicioJornada = min(VEJFechaInicial), @FinJornada = max(FechaFinal) ");

                sConsulta.AppendLine("from VendedorJornada VEJ ");
                sConsulta.AppendLine("inner join VenRut VER on VEJ.VendedorId = VER.VendedorID ");
                sConsulta.AppendLine("inner join Ruta RUT on RUT.RUTClave = VER.RUTClave and  VER.TipoEstado = 1 ");
                sConsulta.AppendLine("inner join Dia on VEJ.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where RUT.RUTClave = @RUTClave and @FechaFiltro = Dia.FechaCaptura ");
                sConsulta.AppendLine("group by VEJ.VendedorId ");
                sConsulta.AppendLine("Select isnull(ClientesProgramados, 0) as ClientesProgramados, isnull(ClientesVisitados, 0) as ClientesVisitados, isnull(ClientesConCompra, 0) as ClientesConCompra,  ");
                sConsulta.AppendLine("CASE WHEN ClientesProgramados = 0 THEN 0 ELSE(cast(ClientesVisitados as Decimal) / cast(ClientesProgramados as Decimal)) * 100 END as EfectividadVisita,  ");
                sConsulta.AppendLine("CASE WHEN ClientesVisitados = 0 THEN 0 ELSE(cast(ClientesConCompra as DEcimal) / cast(ClientesVisitados as decimal)) * 100 END as EfectividadCompra, ");
                sConsulta.AppendLine("@InicioJornada as InicioJornada, @FinJornada as FinJornada, isnull(TiempoRecorrido, 0) as TiempoRecorrido, isnull(ClientesNuevos, 0) as ClientesNuevos ");
                sConsulta.AppendLine("from ");
                sConsulta.AppendLine("( ");
                sConsulta.AppendLine("   Select count(Distinct AGV.ClienteClave) as Cantidad, 'ClientesProgramados' as Dato ");

                sConsulta.AppendLine("from AgendaVendedor AGV ");
                sConsulta.AppendLine(" inner join Dia on AGV.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where AGV.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.AppendLine("   UNION ALL ");
                sConsulta.AppendLine("Select count(Distinct VIS.ClienteClave) as Cantidad, 'ClientesVisitados' as Dato ");
                sConsulta.AppendLine("from Visita VIS ");
                sConsulta.AppendLine(" inner join Dia on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");

                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("Select count(Distinct VIS.ClienteClave) as Cantidad, 'ClientesConCompra' ");
                sConsulta.AppendLine("from Visita VIS ");
                sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join TransProd TRP on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro and TRP.Tipo = 1 and TRP.TipoFase = @TipoFasePedido ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("Select DateDiff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal) as Cantidad, 'TiempoRecorrido' ");
                sConsulta.AppendLine("from Visita VIS ");
                sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.AppendLine("UNION ALL ");

                sConsulta.AppendLine("Select Count(Distinct CLI.ClienteClave) as Cantidad, 'ClientesNuevos' ");
                sConsulta.AppendLine("from Cliente CLI ");
                sConsulta.AppendLine("where Clave like @RUTClave + '%' and CONVERT(char(10), CLI.FechaRegistroSistema, 112) = @FechaFiltro ");
                sConsulta.AppendLine(") as ResumenOperativo PIVOT( ");
                sConsulta.AppendLine("SUM(Cantidad) ");
                sConsulta.AppendLine("FOR Dato IN([ClientesProgramados], [ClientesVisitados], [ClientesConCompra],[TiempoRecorrido],[ClientesNuevos]) ");
                sConsulta.AppendLine(") AS ContadoresRuta ");*/
                sConsulta.AppendLine("DECLARE @FechaFiltro as datetime, @RUTClave as varchar(10) ");
                sConsulta.AppendLine("set @FechaFiltro =  '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'");

                sConsulta.AppendLine("set @RUTClave = '" + RutasSplit + "'");
                sConsulta.AppendLine("   DECLARE @VendedorID as varchar(16), @InicioJornada datetime, @FinJornada datetime ");
                sConsulta.AppendLine(" Select @VendedorID = VEJ.VendedorId, @InicioJornada = min(VEJFechaInicial), @FinJornada = max(FechaFinal) ");

                sConsulta.AppendLine("   from    VendedorJornada VEJ (NOLOCK) ");
                sConsulta.AppendLine("inner   join VenRut VER (NOLOCK) on VEJ.VendedorId = VER.VendedorID ");
                sConsulta.AppendLine(" inner  join Ruta RUT (NOLOCK) on RUT.RUTClave = VER.RUTClave and  VER.TipoEstado = 1 ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VEJ.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where RUT.RUTClave = @RUTClave and @FechaFiltro = Dia.FechaCaptura ");
                sConsulta.AppendLine(" group by VEJ.VendedorId ");
                sConsulta.AppendLine("  Select isnull(ClientesProgramados, 0) as ClientesProgramados, isnull(ClientesVisitados, 0) as ClientesVisitados, isnull(ClientesConCompra, 0) as ClientesConCompra, ");
                sConsulta.AppendLine("    CASE WHEN isnull(ClientesProgramados, 0) = 0 THEN 0 ELSE(cast(isnull(ClientesVisitados, 0) as Decimal) / cast(isnull(ClientesProgramados, 0) as Decimal)) * 100 END as EfectividadVisita, ");

                sConsulta.AppendLine("   CASE WHEN isnull(ClientesVisitados, 0) = 0 THEN 0 ELSE(cast(isnull(ClientesConCompra, 0) as DEcimal) / cast(isnull(ClientesVisitados, 0) as decimal)) * 100 END as EfectividadCompra, ");
                sConsulta.AppendLine(" @InicioJornada as InicioJornada, @FinJornada as FinJornada, isnull(TiempoRecorrido, 0) as TiempoRecorrido, isnull(ClientesNuevos, 0) as ClientesNuevos ");
                sConsulta.AppendLine("   from  ( ");
                sConsulta.AppendLine("Select count(Distinct AGV.ClienteClave) as Cantidad, 'ClientesProgramados' as Dato ");
                sConsulta.AppendLine("   from AgendaVendedor AGV (NOLOCK) ");

                sConsulta.AppendLine("    inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("         where AGV.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.AppendLine("  UNION ALL ");
                sConsulta.AppendLine("       Select count(Distinct VIS.ClienteClave) as Cantidad, 'ClientesVisitados' as Dato ");
                sConsulta.AppendLine(" from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.AppendLine(" UNION ALL ");
                sConsulta.AppendLine("  Select count(Distinct VIS.ClienteClave) as Cantidad, 'ClientesConCompra' ");
                sConsulta.AppendLine(" from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("inner  join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join TransProd TRP (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine(" where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro and TRP.Tipo = 1 and TRP.TipoFase <> 0 ");
                sConsulta.AppendLine(" UNION ALL ");
                sConsulta.AppendLine(" Select DateDiff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal) as Cantidad, 'TiempoRecorrido' ");
                sConsulta.AppendLine(" from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("inner  join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine(" where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.AppendLine(" UNION ALL ");
                sConsulta.AppendLine(" Select Count(Distinct CLI.ClienteClave) as Cantidad, 'ClientesNuevos' ");
                sConsulta.AppendLine(" from Cliente CLI (NOLOCK) ");
                sConsulta.AppendLine(" where Clave like @RUTClave + '%' and CONVERT(char(10), CLI.FechaRegistroSistema, 112) = @FechaFiltro ");
                sConsulta.AppendLine("   ) as ResumenOperativo PIVOT( ");
                sConsulta.AppendLine(" SUM(Cantidad) ");
                sConsulta.AppendLine(" FOR Dato IN([ClientesProgramados], [ClientesVisitados], [ClientesConCompra],[TiempoRecorrido],[ClientesNuevos]) ");
                sConsulta.AppendLine(") AS ContadoresRuta ");


                QueryString = "";

                QueryString = sConsulta.ToString();

                // var resumenHdr = (from c in resumenHeader
                //                 select c).ToList();


                // var clientesConCompra = resumenHeader.First().ClientesConCompra;
                List<ResumenHeader> resumenHeader2 = Connection.Query<ResumenHeader>(QueryString, null, null, true, 600).ToList();

                var resumenHdr2 = (from c in resumenHeader2
                                   select c).ToList();
                clientesConCompra = resumenHeader2.First().ClientesConCompra;
                resumenHdr2.First().ClientesNoCompra = resumenHdr2.First().ClientesVisitados - resumenHdr2.First().ClientesConCompra;
                //   tiempoRecorrido = resumenHdr2.Last().TiempoRecorrido;
                //   clientesVisitados = resumenHdr2.Last().ClientesVisitados;
                // (TiempoFinal - TiempoInicio) / clientes visitados resumenHeader2.First().ClientesConCompra

                //*Ozkar
                resumenCorto.DataSource = resumenHdr2;
                resumenCorto.clientesVisitado.DataBindings.Add("Text", resumenHeader2, "ClientesVisitados");
                resumenCorto.clienteProg.DataBindings.Add("Text", resumenHeader2, "ClientesProgramados");


                resumenCorto.clientesConCompra.DataBindings.Add("Text", resumenHeader2, "ClientesConCompra");
                resumenCorto.clientesNoCompra.DataBindings.Add("Text", resumenHdr2, "ClientesNoCompra");
                resumenCorto.efectividadVisita.DataBindings.Add("Text", resumenHeader2, "EfectividadVisita", "{0:#.00}%");

                resumenCorto.inicioJornada.DataBindings.Add("Text", resumenHeader2, "InicioJornada", "{0:H':'mm':'ss}");
                resumenCorto.finJornada.DataBindings.Add("Text", resumenHeader2, "FinJornada", "{0:H':'mm':'ss}");
                resumenCorto.clientesNuevos.DataBindings.Add("Text", resumenHeader2, "ClientesNuevos");
                resumenCorto.totalPresupuesto.DataBindings.Add("Text", resumenCorto.DataSource, "TotalPresupuesto");
                resumenCorto.efectividadCompra.DataBindings.Add("Text", resumenHeader2, "EfectividadCompra", "{0:#.00}%");

                resumenCorto.cumplimientoVenta.DataBindings.Add("Text", resumenCorto.DataSource, "CumplimientoVenta", "{0:#.00}%");
                resumenCorto.dropSize.DataBindings.Add("Text", resumenCorto.DataSource, "DropSize");
                resumenCorto.totalVenta.DataBindings.Add("Text", resumenCorto.DataSource, "TotalVenta");




                //Resumen Corto

            }
            else      //reparto
            {

                sConsulta = new StringBuilder();
                sConsulta.Append("DECLARE @FechaFiltro as datetime, @RUTClave as varchar(10) ");
                sConsulta.AppendLine("set @FechaFiltro =  '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'");

                sConsulta.AppendLine("set @RUTClave = '" + RutasSplit + "'");
                sConsulta.Append("Select TRP.Folio, VIS.ClienteClave, TRP.TipoFase into #Ventas ");
                sConsulta.Append("from Visita VIS (NOLOCK) ");

                sConsulta.Append("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.Append("inner join TransProd TRP (NOLOCK) on TRP.VisitaClave1 = VIS.VisitaClave and TRP.DiaClave1 = VIS.DiaClave ");
                sConsulta.Append("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro and TRP.Tipo = 1 and TRP.TipoFase in(0,2) ");
                sConsulta.Append("DECLARE @VendedorID as varchar(16), @InicioJornada datetime, @FinJornada datetime ");
                sConsulta.Append("Select @VendedorID = VEJ.VendedorId, @InicioJornada = min(VEJFechaInicial), @FinJornada = max(FechaFinal) ");
                sConsulta.Append("from VendedorJornada VEJ (NOLOCK) ");
                sConsulta.Append("inner join VenRut VER (NOLOCK) on VEJ.VendedorId = VER.VendedorID ");
                sConsulta.Append("inner join Ruta RUT (NOLOCK) on RUT.RUTClave = VER.RUTClave and  VER.TipoEstado = 1 ");
                sConsulta.Append("inner join Dia (NOLOCK) on VEJ.DiaClave = Dia.DiaClave ");
                sConsulta.Append("     where RUT.RUTClave = @RUTClave and @FechaFiltro = Dia.FechaCaptura ");

                sConsulta.Append("group by VEJ.VendedorId ");
                sConsulta.Append("Select isnull(ClientesProgramados, 0) as ClientesProgramados, isnull(ClientesVisitados, 0) as ClientesVisitados, isnull(PedidosPorEntregar, 0) as PedidosPorEntregar, ");
                sConsulta.Append("isnull(PedidosEntregados, 0) as PedidosEntregados, isnull(CtePedidoEntregado, 0) as CtePedidoEntregado, isnull(CtePedidoNoEntregado, 0) as CtePedidoNoEntregado, ");
                sConsulta.Append("CASE WHEN isnull(PedidosPorEntregar, 0) = 0 THEN 0 ELSE(cast(isnull(ClientesVisitados, 0) as Decimal) / cast(isnull(PedidosPorEntregar, 0) as Decimal)) * 100 END as EfectividadVisita,  ");
                sConsulta.Append("CASE WHEN isnull(PedidosPorEntregar, 0) = 0 THEN 0 ELSE(cast(isnull(PedidosEntregados, 0) as DEcimal) / cast(isnull(PedidosPorEntregar, 0) as decimal)) * 100 END as EfectividadCompra, ");
                sConsulta.Append("@InicioJornada as InicioJornada, @FinJornada as FinJornada, isnull(TiempoRecorrido, 0) as TiempoRecorrido, isnull(ClientesNuevos, 0) as ClientesNuevos ");

                sConsulta.Append("from ");
                sConsulta.Append("( ");

                sConsulta.Append(" Select count(Distinct AGV.ClienteClave) as Cantidad, 'ClientesProgramados' as Dato ");
                sConsulta.Append("from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.Append(" inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave ");
                sConsulta.Append(" where AGV.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.Append("UNION ALL ");
                sConsulta.Append("Select count(Distinct VIS.ClienteClave) as Cantidad, 'ClientesVisitados' as Dato ");
                sConsulta.Append("  from Visita VIS (NOLOCK) ");
                sConsulta.Append("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.Append("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.Append("  UNION ALL ");
                sConsulta.Append("    Select count(Distinct Folio) as Cantidad, 'PedidosPorEntregar' ");
                sConsulta.Append("    from #Ventas VEN ");
                sConsulta.Append("where VEN.TipoFase in(0, 2) ");
                sConsulta.Append("     UNION ALL ");
                sConsulta.Append("Select count(Distinct Folio) as Cantidad, 'PedidosEntregados' ");
                sConsulta.Append(" from #Ventas VEN ");
                sConsulta.Append("where VEN.TipoFase = 2 ");
                sConsulta.Append(" UNION ALL ");
                sConsulta.Append("Select count(Distinct ClienteClave), 'CtePedidoEntregado' ");
                sConsulta.Append("  from #Ventas VEN ");
                sConsulta.Append("where VEN.TipoFase = 2 ");
                sConsulta.Append("  UNION ALL ");
                sConsulta.Append(" Select count(Distinct ClienteClave), 'CtePedidoNoEntregado' ");
                sConsulta.Append("from #Ventas VEN ");
                sConsulta.Append("where VEN.TipoFase = 0 ");
                sConsulta.Append(" UNION ALL ");
                sConsulta.Append("Select DateDiff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal) as Cantidad, 'TiempoRecorrido' ");
                sConsulta.Append("from Visita VIS (NOLOCK) ");
                sConsulta.Append("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.Append("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                sConsulta.Append("    UNION ALL ");
                sConsulta.Append("Select Count(Distinct CLI.ClienteClave) as Cantidad, 'ClientesNuevos' ");
                sConsulta.Append("from Cliente CLI (NOLOCK) ");
                sConsulta.Append("where Clave like @RUTClave + '%' and CONVERT(char(10), CLI.FechaRegistroSistema, 112) = @FechaFiltro ");
                sConsulta.Append(") as ResumenOperativo PIVOT( ");
                sConsulta.Append("SUM(Cantidad) ");
                sConsulta.Append("FOR Dato IN([ClientesProgramados], [ClientesVisitados], [PedidosPorEntregar],[PedidosEntregados],[CtePedidoEntregado],[CtePedidoNoEntregado],[TiempoRecorrido],[ClientesNuevos]) ");

                sConsulta.Append(") AS ContadoresRuta ");
                sConsulta.Append("DROP TABLE #Ventas ");

                //resumenLargo.DataSource
                QueryString = "";

                QueryString = sConsulta.ToString();


                // clientesConCompra = resumenHeader.First().ClientesConCompra;

                List<ResumenHeader> resumenHeader2 = Connection.Query<ResumenHeader>(QueryString, null, null, true, 600).ToList();

                var resumenHdrReparto = (from c in resumenHeader2
                                         select c).ToList();


                pedidosEntregados = resumenHdrReparto.Last().PedidosEntregados;
                pedidosPorEntregar = resumenHdrReparto.Last().PedidosPorEntregar;


                resumenLargo.DataSource = resumenHdrReparto;

                //Resumen Largo
                resumenLargo.clienteProg.DataBindings.Add("Text", resumenLargo.DataSource, "ClientesProgramados");
                resumenLargo.clientesVisitado.DataBindings.Add("Text", resumenLargo.DataSource, "ClientesVisitados");
                resumenLargo.PedidosPorEntregar.DataBindings.Add("Text", resumenLargo.DataSource, "PedidosPorEntregar");
                resumenLargo.PedidosEntreg.DataBindings.Add("Text", resumenLargo.DataSource, "PedidosEntregados");
                resumenLargo.clientesConPedidosEntr.DataBindings.Add("Text", resumenLargo.DataSource, "CtePedidoEntregado");
                resumenLargo.clientesConPedidosNoEnt.DataBindings.Add("Text", resumenLargo.DataSource, "CtePedidoNoEntregado");
                resumenLargo.efectividadVisita.DataBindings.Add("Text", resumenLargo.DataSource, "EfectividadVisita", "{0:#.00}%");
                resumenLargo.efectividadCompra.DataBindings.Add("Text", resumenLargo.DataSource, "EfectividadCompra", "{0:#.00}%");

                resumenLargo.EfectivaDeEntrega.DataBindings.Add("Text", resumenLargo.DataSource, "EfectividadDeCompra");
                resumenLargo.InicioDeJornada.DataBindings.Add("Text", resumenLargo.DataSource, "InicioJornada", "{0:hh':'mm':'ss}");
                resumenLargo.FinDeJornada.DataBindings.Add("Text", resumenLargo.DataSource, "FinJornada", "{0:hh':'mm':'ss}");

                // resumenLargo.tiempoPromedio.DataBindings.Add("Text", resumenLargo.DataSource, "TiempoRecorrido");

                resumenLargo.clientesConPedidosEntr.DataBindings.Add("Text", resumenLargo.DataSource, "ClientesVisitados");



            }

            //Segunda Parte
            //Sí es un reporte detallado o completo
            if (detallado)
            {


                //Venta por clientes largo o con agrupaciones
                //       sConsulta.AppendLine("where tp.ProductoClave = '200600'");

                QueryString = "";

                QueryString = sConsulta.ToString();


                if (User.Count() <= 0)
                {
                    return null;
                }

                var lista2 = (from c in User
                              select c).ToList();
                List<AutoVentaPreventaCompleto> formatlist2 = new List<AutoVentaPreventaCompleto>();

                var s2 = (from gr in lista2 group gr by new { gr.Folio } into grupo select grupo);

                Decimal total2 = 0;
                long totalPiezas2 = 0;
                long totalCambio2 = 0;
                long totalPromocion2 = 0;


                Decimal totalAux = 0;
                long totalPiezasAux = 0;
                long totalCambioAux = 0;
                long totalPromocionAux = 0;


                Decimal subtotal2 = 0;
                long subtotalPiezas2 = 0;
                long subtotalCambio2 = 0;
                long subtotalPromocion2 = 0;


                foreach (var grupo in s2)
                {


                    foreach (var objetoAgrupado in grupo)
                    {
                        formatlist2.Add(new AutoVentaPreventaCompleto
                        {
                            Clave = objetoAgrupado.Clave,
                            Folio = objetoAgrupado.Folio,
                            // Folio = objetoAgrupado.Folio + " - " + objetoAgrupado.RazonSocial,
                            RazonSocial = objetoAgrupado.RazonSocial,
                            DiaClave = objetoAgrupado.DiaClave,
                            SKU = objetoAgrupado.SKU,
                            Producto = objetoAgrupado.Producto,
                            Venta = objetoAgrupado.Venta,
                            Cambios = objetoAgrupado.Cambios,
                            Promociones = objetoAgrupado.Promociones,
                            Importe_Venta = objetoAgrupado.Importe_Venta,
                        });
                        formatlist2.Last().ImporteSubTotal = grupo.Sum(c => c.Importe_Venta);
                        formatlist2.Last().PiezasSubTotal = grupo.Sum(c => c.Venta);
                        formatlist2.Last().PiezasCambioSubTotal = grupo.Sum(c => c.Cambios);
                        formatlist2.Last().PiezasPromocionSubTotal = grupo.Sum(c => c.Promociones);

                        subtotal2 = grupo.Sum(c => c.Importe_Venta);
                        subtotalPiezas2 = grupo.Sum(c => c.Venta);
                        subtotalCambio2 = grupo.Sum(c => c.Cambios);
                        subtotalPromocion2 = grupo.Sum(c => c.Promociones);

                        // totalAux



                        totalAux += objetoAgrupado.Importe_Venta;
                        totalPiezasAux += objetoAgrupado.Venta;
                        totalCambioAux += objetoAgrupado.Cambios;
                        totalPromocionAux += objetoAgrupado.Promociones;


                    }

                    if (grupo.Key.Equals(s2.Last().Key))
                    {
                        subtotal2 = grupo.Sum(c => c.Importe_Venta);
                        subtotalPiezas2 = grupo.Sum(c => c.Venta);
                        subtotalCambio2 = grupo.Sum(c => c.Cambios);
                        subtotalPromocion2 = grupo.Sum(c => c.Promociones);

                        total2 += totalAux;
                        totalPiezas2 += totalPiezasAux;
                        totalCambio2 += totalCambioAux;
                        totalPromocion2 += totalPromocionAux;

                        formatlist2.Last().TotalImporte = total2;
                        formatlist2.Last().TotalPiezas = totalPiezas2;

                        formatlist2.Last().TotalPiezasCambio = totalCambio2;
                        formatlist2.Last().TotalPiezasPromocion = totalPromocion2;

                    }
                    formatlist2.Last().TotalPiezas = User.LastOrDefault().TotalPiezas;
                    formatlist2.Last().TotalImporte = User.LastOrDefault().TotalImporte;
                    formatlist2.Last().TotalPiezasCambio = User.LastOrDefault().TotalPiezasCambio;
                    formatlist2.Last().TotalPiezasPromocion = User.LastOrDefault().TotalPiezasPromocion;

                }



                dImporte report = new dImporte();
                AutoventaPreventaCompleto.DataSource = formatlist2;







                GroupField groupRuta = new GroupField("Folio");
                AutoventaPreventaCompleto.GroupHeader1.GroupFields.Add(groupRuta);
                AutoventaPreventaCompleto.folioCliente.Text = "[Clave] - [RazonSocial]";
                //  AutoventaPreventaCompleto.folioCliente.DataBindings.Add("Text", AutoventaPreventaCompleto.DataSource, "Folio");


                //Datos del detail
                AutoventaPreventaCompleto.dFolio.DataBindings.Add("Text", null, "Folio");
                AutoventaPreventaCompleto.dFechaEntrega.DataBindings.Add("Text", null, "DiaClave", "{0:dd/MM/yyyy}");
                AutoventaPreventaCompleto.dCodigo.DataBindings.Add("Text", null, "SKU");
                AutoventaPreventaCompleto.dDescripcion.DataBindings.Add("Text", null, "Producto");
                AutoventaPreventaCompleto.dPiezasVenta.DataBindings.Add("Text", null, "Venta");
                AutoventaPreventaCompleto.dPiezasCambio.DataBindings.Add("Text", null, "Cambios");
                AutoventaPreventaCompleto.dPiezasPromocion.DataBindings.Add("Text", null, "Promociones");
                AutoventaPreventaCompleto.detImporte.DataBindings.Add("Text", null, "Importe_Venta", "{0:$#,##0.00}");

                //Footer Folio
                AutoventaPreventaCompleto.subtotalPiezas.DataBindings.Add("Text", null, "PiezasSubTotal");
                AutoventaPreventaCompleto.subtotalPiezasCambio.DataBindings.Add("Text", null, "PiezasCambioSubTotal");
                AutoventaPreventaCompleto.subtotalPiezasPromocion.DataBindings.Add("Text", null, "PiezasPromocionSubTotal");
                AutoventaPreventaCompleto.subtotalImporte.DataBindings.Add("Text", null, "ImporteSubTotal", "{0:$#,##0.00}");



                AutoventaPreventaCompleto.totalPiezas.DataBindings.Add("Text", null, "TotalPiezas");
                AutoventaPreventaCompleto.totalPiezasCambio.DataBindings.Add("Text", null, "TotalPiezasCambio");
                AutoventaPreventaCompleto.totalPiezasPromocion.DataBindings.Add("Text", null, "TotalPiezasPromocion");
                AutoventaPreventaCompleto.total.DataBindings.Add("Text", null, "TotalImporte", "{0:$#,##0.00}");

                //total
                /*  report.totalPiezas.Text= totalPiezas.ToString();
                  report.totalPiezasCambio.Text= totalCambio.ToString();
                  report.totalPiezasPromocion.Text = totalPromocion.ToString();
                  report.total.Text = total.ToString();
                  */


            }
            else
            { //Reporte resumen
              //Venta por clientes corto/sin agrupaciones


                /**CONSULTA PARA REPARTO O PREVENTA**/


                sConsulta = new StringBuilder();

                if (TipoRutaB == true) //Preventa
                {
                    sConsulta.Append("DECLARE @FechaFiltro as datetime, @RUTClave as varchar(10) ");
                    sConsulta.AppendLine("set @FechaFiltro =  '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'");

                    sConsulta.AppendLine("set @RUTClave = '" + RutasSplit + "'");
                    sConsulta.Append("Select ClienteClave as Folio, RazonSocial, FechaCaptura as DiaClave, Numero, TiempoTransito, FechaHoraInicial, FechaHoraFinal, TiempoVisita, sum(PzasVenta) as Venta, ");
                    sConsulta.Append("sum(PzasCambios) as Cambios, sum(PzasPromocion) as Promociones, sum(ImporteVenta) as Importe_Venta from( ");
                    sConsulta.Append("Select VIS.ClienteClave, CLI.RazonSocial, Dia.FechaCaptura, VIS.Numero, ");

                    sConsulta.Append("DATEDIFF(second, isnull((Select TOP 1 FechaHoraFinal from Visita V (NOLOCK) where V.DiaClave = Dia.DiaClave and V.VendedorID = VIS.VendedorID and V.Numero < VIS.Numero order by Numero desc), VEJ.VEJFechaInicial), VIS.FechaHoraInicial) as TiempoTransito, ");
                    sConsulta.Append("VIS.FechaHoraInicial, Vis.FechaHoraFinal, DATEDIFF(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal) as TiempoVisita, ");
                    sConsulta.Append("CASE WHEN TRP.Tipo = 1 and isnull(TPD.Promocion, 0) <> 2 THEN sum(Cantidad) ELSE 0 END as PzasVenta, ");
                    sConsulta.Append("CASE WHEN  TRP.Tipo = 9 and TipoMovimiento = 1 THEN sum(Cantidad) ELSE 0 END as PzasCambios, ");
                    sConsulta.Append("CASE WHEN TRP.Tipo = 1 and isnull(TPD.Promocion, 0) = 2 THEN sum(Cantidad) ELSE 0 END as PzasPromocion, ");
                    sConsulta.Append("CASE WHEN TRP.Tipo = 1 THEN TRP.Total ELSE 0 END as ImporteVenta ");
                    sConsulta.Append("from Visita VIS (NOLOCK) ");
                    sConsulta.Append("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
                    sConsulta.Append("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                    sConsulta.Append("inner join VendedorJornada VEJ (NOLOCK) on VEJ.VendedorId = VIS.VendedorID and VEJ.DiaClave = Dia.DiaClave ");
                    sConsulta.Append("left join TransProd TRP (NOLOCK) on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.TipoFase <> 0 ");
                    sConsulta.Append("left join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                    sConsulta.Append("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                    sConsulta.Append("group by VIS.ClienteClave, CLI.RazonSocial, Dia.FechaCaptura, VIS.Numero, Dia.DiaClave, VIS.VendedorID, VEJ.VEJFechaInicial, VIS.FechaHoraInicial, ");
                    sConsulta.Append("VIS.FechaHoraFinal, TRP.Tipo, TPD.Promocion, TRP.TipoMovimiento, TRP.Total ");

                    sConsulta.Append(") as VentasXCte ");
                    sConsulta.Append("group by ClienteClave, RazonSocial, FechaCaptura, Numero, TiempoTransito, FechaHoraInicial, FechaHoraFinal,TiempoVisita ");
                    sConsulta.Append("order by Numero ");
                }
                else //Reparto
                {
                    sConsulta.Append("DECLARE @FechaFiltro as datetime, @RUTClave as varchar(10) ");
                    sConsulta.AppendLine("set @FechaFiltro =  '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'");
                    sConsulta.AppendLine("set @RUTClave = '" + RutasSplit + "'");
                    sConsulta.Append("Select ClienteClave as Folio, RazonSocial, FechaCaptura as DiaClave, Numero, TiempoTransito, FechaHoraInicial, FechaHoraFinal, TiempoVisita, sum(PzasVenta) as Venta, ");
                    sConsulta.Append("sum(PzasCambios) as Cambios, sum(PzasPromocion) as Promociones, sum(ImporteVenta) as Importe_Venta from( ");
                    sConsulta.Append("Select VIS.ClienteClave, CLI.RazonSocial, Dia.FechaCaptura, VIS.Numero, ");
                    sConsulta.Append("DATEDIFF(second, isnull((Select TOP 1 FechaHoraFinal from Visita V (NOLOCK) where V.DiaClave = Dia.DiaClave and V.VendedorID = VIS.VendedorID and V.Numero < VIS.Numero order by Numero desc), VEJ.VEJFechaInicial), VIS.FechaHoraInicial) as TiempoTransito, ");
                    sConsulta.Append("VIS.FechaHoraInicial, Vis.FechaHoraFinal, DATEDIFF(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal) as TiempoVisita, ");
                    sConsulta.Append("CASE WHEN TRP.Tipo = 1 and isnull(TPD.Promocion, 0) <> 2 THEN sum(Cantidad) ELSE 0 END as PzasVenta, ");
                    sConsulta.Append("CASE WHEN  TRP.Tipo = 9 and TipoMovimiento = 1 THEN sum(Cantidad) ELSE 0 END as PzasCambios, ");
                    sConsulta.Append("CASE WHEN TRP.Tipo = 1 and isnull(TPD.Promocion, 0) = 2 THEN sum(Cantidad) ELSE 0 END as PzasPromocion, ");
                    sConsulta.Append("CASE WHEN TRP.Tipo = 1 THEN TRP.Total ELSE 0 END as ImporteVenta ");
                    sConsulta.Append("from Visita VIS (NOLOCK) ");
                    sConsulta.Append("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
                    sConsulta.Append("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                    sConsulta.Append("inner join VendedorJornada VEJ (NOLOCK) on VEJ.VendedorId = VIS.VendedorID and VEJ.DiaClave = Dia.DiaClave ");
                    sConsulta.Append("left join TransProd TRP (NOLOCK) on VIS.VisitaClave = isnull(TRP.VisitaClave1, TRP.VisitaClave) and VIS.DiaClave = isnull(TRP.DiaClave1, TRP.DiaClave) and TRP.TipoFase <> 0 ");
                    sConsulta.Append("left join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                    sConsulta.Append("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura = @FechaFiltro ");
                    sConsulta.Append("group by VIS.ClienteClave, CLI.RazonSocial, Dia.FechaCaptura, VIS.Numero, Dia.DiaClave, VIS.VendedorID, VEJ.VEJFechaInicial, VIS.FechaHoraInicial, ");
                    sConsulta.Append("VIS.FechaHoraFinal, TRP.Tipo, TPD.Promocion, TRP.TipoMovimiento, TRP.Total ");
                    sConsulta.Append(") as VentasXCte ");
                    sConsulta.Append("group by ClienteClave, RazonSocial, FechaCaptura, Numero, TiempoTransito,FechaHoraInicial, FechaHoraFinal,TiempoVisita ");
                    sConsulta.Append("order by Numero ");
                }


                QueryString = "";

                QueryString = sConsulta.ToString();


                List<AutoVentaPreventaCompleto> VentaAutoResumen = Connection.Query<AutoVentaPreventaCompleto>(QueryString, null, null, true, 600).ToList();


                var lista3 = (from c in VentaAutoResumen
                              select c).ToList();

                List<AutoVentaPreventaCompleto> formatlist3 = new List<AutoVentaPreventaCompleto>();

                var s3 = (from gr in lista3 group gr by new { gr.Folio } into grupo select grupo);



                Decimal total3 = 0;
                long totalPiezas3 = 0;
                long totalCambio3 = 0;
                long totalPromocion3 = 0;





                foreach (var grupo in s3)
                {


                    foreach (var objetoAgrupado in grupo)
                    {
                        formatlist3.Add(new AutoVentaPreventaCompleto
                        {
                            Clave = objetoAgrupado.Folio,
                            Folio = objetoAgrupado.Folio + " - " + objetoAgrupado.RazonSocial,
                            DiaClave = objetoAgrupado.DiaClave,
                            SKU = objetoAgrupado.SKU,
                            Producto = objetoAgrupado.Producto,
                            Venta = objetoAgrupado.Venta,

                            TiempoTransito = objetoAgrupado.TiempoTransito,
                            FechaHoraInicial = objetoAgrupado.FechaHoraInicial,
                            FechaHoraFinal = objetoAgrupado.FechaHoraFinal,
                            TiempoVisita = objetoAgrupado.TiempoVisita,

                            Cambios = objetoAgrupado.Cambios,
                            Promociones = objetoAgrupado.Promociones,
                            Importe_Venta = objetoAgrupado.Importe_Venta,
                        });
                        total3 += formatlist3.Last().Importe_Venta;
                        totalPiezas3 += formatlist3.Last().Venta;
                        totalCambio3 += formatlist3.Last().Cambios;
                        totalPromocion3 += formatlist3.Last().Promociones;
                        //   tiempoRecorrido += formatlist3.Last().TiempoVisita;
                    }
                    if (grupo.Key.Equals(s3.Last().Key))
                    {


                        formatlist3.Last().TotalImporte = total3;
                        formatlist3.Last().TotalPiezas = totalPiezas3;
                        formatlist3.Last().TotalPiezasCambio = totalCambio3;
                        formatlist3.Last().TotalPiezasPromocion = totalPromocion3;
                    }

                }



                DateTime fInicio3 = DateTime.Parse(FechaInicial);

                if (String.IsNullOrEmpty(ClientesSplit) || ClientesSplit.Equals("null"))
                {
                    ClientesSplit = String.Empty;
                }

                reporteResumen.DataSource = formatlist3;



                //Datos del detail

                reporteResumen.dFolio.DataBindings.Add("Text", null, "Folio");
                reporteResumen.dFechaEntrega.DataBindings.Add("Text", null, "DiaClave", "{0:dd/MM/yyyy}");

                //Tiempo en transito


                reporteResumen.dPiezasVenta.DataBindings.Add("Text", null, "Venta");
                reporteResumen.dPiezasCambio.DataBindings.Add("Text", null, "Cambios");
                reporteResumen.dPiezasPromocion.DataBindings.Add("Text", null, "Promociones");
                reporteResumen.TiempoTransito.DataBindings.Add("Text", null, "TiempoTransito");
                reporteResumen.HoraInicial.DataBindings.Add("Text", null, "FechaHoraInicial", "{0:HH:mm}");

                reporteResumen.HoraFin.DataBindings.Add("Text", null, "FechaHoraFinal", "{0:HH:mm}");
                reporteResumen.TiempoVisita.DataBindings.Add("Text", null, "TiempoVisita");
                reporteResumen.detImporte.DataBindings.Add("Text", null, "Importe_Venta", "{0:$#,##0.00}");

                //Total general
                reporteResumen.totalPiezas.DataBindings.Add("Text", null, "TotalPiezas");
                reporteResumen.totalPiezasCambio.DataBindings.Add("Text", null, "TotalPiezasCambio");
                reporteResumen.totalPiezasPromocion.DataBindings.Add("Text", null, "TotalPiezasPromocion");
                reporteResumen.total.DataBindings.Add("Text", null, "TotalImporte", "{0:$#,##0.00}");






            }

            //Tercera parte
            ResumenPorCodigo resumenCodigo = new ResumenPorCodigo();


            //total
            /*  report.totalPiezas.Text= totalPiezas.ToString();
              report.totalPiezasCambio.Text= totalCambio.ToString();
              report.totalPiezasPromocion.Text = totalPromocion.ToString();
              report.total.Text = total.ToString();
              */

            //Resumen por codigo
            var lista = (from c in resumenPorCodigo
                         select c).ToList();
            List<ResumenPorCodigoList> formatlist = new List<ResumenPorCodigoList>();

            var s = (from gr in lista group gr by new { gr.Folio } into grupo select grupo);

            Decimal total = 0;
            long totalPiezas = 0;
            long totalCambio = 0;
            long totalPromocion = 0;




            Decimal subtotal = 0;
            long subtotalPiezas = 0;
            long subtotalCambio = 0;
            long subtotalPromocion = 0;


            foreach (var grupo in s)
            {


                foreach (var objetoAgrupado in grupo)
                {
                    long Cobertura = 0;
                    if (objetoAgrupado.Compra_Efectiva != 0)
                    {
                        Cobertura = objetoAgrupado.Clientes_Compra / objetoAgrupado.Compra_Efectiva;
                    }
                    else
                    {
                        Cobertura = 0;
                    }


                    formatlist.Add(new ResumenPorCodigoList
                    {
                        Folio = objetoAgrupado.Folio,
                        DiaClave = objetoAgrupado.DiaClave,
                        SKU = objetoAgrupado.SKU,
                        Producto = objetoAgrupado.Producto,
                        Venta = objetoAgrupado.Venta,
                        Cambios = objetoAgrupado.Cambios,
                        Promociones = objetoAgrupado.Promociones,
                        Importe_Venta = objetoAgrupado.Importe_Venta,
                        Clientes_Compra = objetoAgrupado.Clientes_Compra,
                        Compra_Efectiva = objetoAgrupado.Compra_Efectiva,
                        Cobertura = Cobertura

                    });
                    formatlist.Last().TotalImporte = grupo.Sum(c => c.Importe_Venta);
                    formatlist.Last().TotalPiezas = grupo.Sum(c => c.Venta);
                    formatlist.Last().TotalPiezasCambio = grupo.Sum(c => c.Cambios);
                    formatlist.Last().TotalPiezasPromocion = grupo.Sum(c => c.Promociones);

                    subtotal = grupo.Sum(c => c.Importe_Venta);
                    subtotalPiezas = grupo.Sum(c => c.Venta);
                    subtotalCambio = grupo.Sum(c => c.Cambios);
                    subtotalPromocion = grupo.Sum(c => c.Promociones);
                }
                total += subtotal;
                totalPiezas += subtotalPiezas;
                totalCambio += subtotalCambio;
                totalPromocion += subtotalPromocion;


                if (grupo.Key.Equals(s.Last().Key))
                {
                    formatlist.Last().TotalImporte = total;
                    formatlist.Last().TotalPiezas = totalPiezas;
                    formatlist.Last().TotalPiezasCambio = totalCambio;
                    formatlist.Last().TotalPiezasPromocion = totalPromocion;
                }

            }

            DateTime fInicio = DateTime.Parse(FechaInicial);

            if (String.IsNullOrEmpty(ClientesSplit) || ClientesSplit.Equals("null"))
            {
                ClientesSplit = String.Empty;
            }

            ResumenPorCodigo resumenPCodigo = new ResumenPorCodigo();

            resumenPCodigo.DataSource = formatlist;


            //Datos del detail
            resumenPCodigo.dCodigo.DataBindings.Add("Text", null, "SKU");
            resumenPCodigo.dDescripcion.DataBindings.Add("Text", null, "Producto");
            resumenPCodigo.dPiezasVenta.DataBindings.Add("Text", null, "Venta");
            resumenPCodigo.dPiezasCambio.DataBindings.Add("Text", null, "Cambios");
            resumenPCodigo.dPiezasPromocion.DataBindings.Add("Text", null, "Promociones");
            resumenPCodigo.detImporte.DataBindings.Add("Text", null, "Importe_Venta", "{0:$#,##0.00}");

            resumenPCodigo.detClienteConcompra.DataBindings.Add("Text", null, "Clientes_Compra");
            resumenPCodigo.detClienteConcompraEfectiva.DataBindings.Add("Text", null, "Compra_Efectiva");
            resumenPCodigo.Cobertura.DataBindings.Add("Text", null, "Cobertura");

            //total
            resumenPCodigo.totalPiezas.DataBindings.Add("Text", null, "TotalPiezas");
            resumenPCodigo.totalPiezasCambio.DataBindings.Add("Text", null, "TotalPiezasCambio");
            resumenPCodigo.totalPiezasPromocion.DataBindings.Add("Text", null, "TotalPiezasPromocion");
            resumenPCodigo.total.DataBindings.Add("Text", null, "TotalImporte", "{0:$#,##0.00}");





            //Datos del groupfooter1





            //Reporte Completo

            ReporteGeneral reporteGeneral = new ReporteGeneral();
            string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);
            reporteGeneral.logo.Image = Image.FromStream(mStream);
            reporteGeneral.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            reporteGeneral.empresa.Text = NombreEmpresa;
            reporteGeneral.reporte.Text = NombreReporte;


            reporteGeneral.CentroDistribucion.Text = Cedis;
            reporteGeneral.FechaPedido.Text = init.Date.ToString("dd/MM/yyyy");

            string rutaTipo = "";
            if (TipoRutaB == true) rutaTipo = "PREVENTA"; else rutaTipo = "REPARTO";
            reporteGeneral.Ruta.Text = "RUTA " + rutaTipo + " " + RutasSplit;
            reporteGeneral.TipoReporte.Text = (detallado == true) ? "Completo" : "Resumen";


            //Se calcula el tiempo de recorrido
            Int32 tsegundos = Convert.ToInt32(tiempoRecorrido / clientesVisitados);




            Int32 horas = (tsegundos / 3600);
            Int32 minutos = ((tsegundos - horas * 3600) / 60);
            Int32 segundos2 = tsegundos - (horas * 3600 + minutos * 60);

            DateTime da = new DateTime(1, 1, 1, horas, minutos, segundos2, 0);
            var sa = String.Format("{0:HH:mm:ss}", da);

            //PRIMERA SECCIÓN //CAMBIA POR EL TIPO
            if (TipoRutaB)
            {
                //Header
                // resumenPCodigo.total.DataBindings.Add("Text", null, "TotalImporte", "{0:$#.00}");


                List<ResumenHeader> resu = new List<ResumenHeader>();


                resu.Add(new ResumenHeader
                {
                    DropSize = formatlist.Last().TotalImporte / clientesConCompra,
                    TotalVenta = formatlist.Last().TotalImporte,
                    TotalPresupuesto = nPresupuesto,

                    CumplimientoVenta = Math.Round((formatlist.Last().TotalImporte / nPresupuesto) * 100)        //   [(Total Venta / Total Presupuesto) * 100

                });



                resumenCorto.tiempoPromedio.Text = sa;

                resumenCorto.dropSize.DataBindings.Add("Text", resu, "DropSize", "{0:#.00}");
                resumenCorto.totalVenta.DataBindings.Add("Text", resu, "TotalVenta", "{0:$#,##0.00}");
                resumenCorto.totalPresupuesto.DataBindings.Add("Text", resu, "TotalPresupuesto", "{0:$#,##0.00}");
                resumenCorto.cumplimientoVenta.DataBindings.Add("Text", resu, "CumplimientoVenta", "{0:#.00}%");
                reporteGeneral.sResumen.ReportSource = resumenCorto;

            }
            else
            {
                List<ResumenHeader> resu = new List<ResumenHeader>();
                //  double a = ((double) pedidosEntregados / (double) pedidosPorEntregar) * 100;

                resu.Add(new ResumenHeader
                {
                    EfectividadEntrega = Math.Round(((double)pedidosEntregados / (double)pedidosPorEntregar) * 100),
                    TotalVenta = formatlist.Last().TotalImporte,
                });
                //  [(Pedidos Entregados / Pedidos por Entregar) * 100] (**redondear al entero más próximo)

                //   formatlist.Last().TotalImporte
                resumenLargo.tiempoPromedio.Text = sa;
                resumenLargo.EfectivaDeEntrega.DataBindings.Add("Text", resu, "EfectividadEntrega");
                resumenLargo.ImporteTotalPedidos.DataBindings.Add("Text", resu, "Totalventa", "{0:$#,##0.00}");

                reporteGeneral.sResumen.ReportSource = resumenLargo;
            }

            reporteGeneral.sVentaPorClientes.ReportSource = null;
            //II SEGUNDA SECCIÓN CAMBIA SÍ ES DETALLADO O COMPLETO
            if (detallado)
            {

                reporteGeneral.sVentaPorClientes.ReportSource = AutoventaPreventaCompleto;
            }
            else
            {
                reporteGeneral.sVentaPorClientes.ReportSource = reporteResumen;

            }



            //Resumen por codigo //TERCERA SECCIÓN  NO CAMBIA
            reporteGeneral.sResumenPorCodigo.ReportSource = resumenPCodigo;


            return reporteGeneral;
        }

        public class AutoVentaPreventaCompleto
        {
            public string Clave { get; set; }
            public string Folio { get; set; }
            public string RazonSocial { get; set; }
            public DateTime DiaClave { get; set; }
            public string SKU { get; set; }
            public string Producto { get; set; }
            public long Venta { get; set; }
            public long Cambios { get; set; }
            public long Promociones { get; set; }
            public Decimal Importe_Venta { get; set; }

            /***/
            public long TiempoTransito { get; set; }
            public DateTime FechaHoraInicial { get; set; }
            public DateTime FechaHoraFinal { get; set; }
            public long TiempoVisita { get; set; }

            //Subtotal
            public long PiezasSubTotal { get; set; }
            public long PiezasCambioSubTotal { get; set; }
            public long PiezasPromocionSubTotal { get; set; }
            public Decimal ImporteSubTotal { get; set; }
            //Total
            public long TotalPiezas { get; set; }
            public long TotalPiezasCambio { get; set; }
            public long TotalPiezasPromocion { get; set; }
            public Decimal TotalImporte { get; set; }
        }
        public class ResumenPorCodigoList
        {
            public string Folio { get; set; }
            public DateTime DiaClave { get; set; }
            public string SKU { get; set; }
            public string Producto { get; set; }
            public long Venta { get; set; }
            public long Cambios { get; set; }
            public long Promociones { get; set; }
            public Decimal Importe_Venta { get; set; }
            public long Clientes_Compra { get; set; }
            public long Compra_Efectiva { get; set; }
            public long Cobertura { get; set; }

            //Totales
            public long TotalPiezas { get; set; }
            public long TotalPiezasCambio { get; set; }
            public long TotalPiezasPromocion { get; set; }
            public Decimal TotalImporte { get; set; }
        }
        public class totales
        {
            public long TotalPiezas { get; set; }
            public long TotalPiezasCambio { get; set; }
            public long TotalPiezasPromocion { get; set; }
            public Decimal TotalImporte { get; set; }

        }
        public class ResumenHeader
        {
            public long ClientesProgramados { get; set; }
            public long ClientesVisitados { get; set; }
            public long ClientesConCompra { get; set; }
            public long ClientesNoCompra { get; set; }
            public long CtePedidoEntregado { get; set; }
            public long CtePedidoNoEntregado { get; set; }


            public long EfectividadVisita { get; set; }
            public long EfectividadCompra { get; set; }
            public double EfectividadEntrega { get; set; }

            public DateTime InicioJornada { get; set; }
            public DateTime FinJornada { get; set; }
            public long TiempoRecorrido { get; set; }
            public DateTime TiempoRecFormat { get; set; }

            public long ClientesNuevos { get; set; }
            public Decimal TotalVenta { get; set; }
            public long TotalPresupuesto { get; set; }
            public Decimal DropSize { get; set; }
            public Decimal CumplimientoVenta { get; set; }


            //resumen largo
            public long PedidosPorEntregar { get; set; }
            public long PedidosEntregados { get; set; }
            public long ImporteTotal { get; set; }


        }
        public class TipoRutaList
        {
            public long Tipo { get; set; }
        }

    }
}