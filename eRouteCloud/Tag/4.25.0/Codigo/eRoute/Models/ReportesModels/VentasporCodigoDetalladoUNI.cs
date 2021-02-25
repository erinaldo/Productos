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
    public class VentasporCodigoDetalladoUNI
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        ReporteVentasporCodigoDetalladoUNI report = new ReporteVentasporCodigoDetalladoUNI();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, int VAVClave, bool detallado, string pvCondicion, string sEsquemasProd, string nombreProductos, string RutasSplit, string pvProductos, string FechaInicial, string Cedis, string nombreCedis, string unidadMedida)
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
            string FCaptura = fInicio.Date.ToShortDateString();
            report.labelFechaHeader.Text = FCaptura;

            //Rutas
            //Obtener Detalle
            StringBuilder RutDetalle = new StringBuilder();
            RutDetalle.AppendLine("Set ANSI_WARNINGS OFF ");
            RutDetalle.AppendLine("Set nocount on ");
            RutDetalle.AppendLine("Select Clave + ' ' + Descripcion as RutaDetalle, Tipo as TipoRuta from");
            RutDetalle.AppendLine("(");
            RutDetalle.AppendLine("select Ruta.RUTClave as Clave, Descripcion,  Tipo");
            RutDetalle.AppendLine("from Ruta (NOLOCK)");
            RutDetalle.AppendLine(") as Detalle");
            RutDetalle.AppendLine(pvCondicion);

            QueryString = "";
            QueryString = RutDetalle.ToString();

            List<VentasporCodigoDetalladoUNIDetalleModel> RDetalle = Connection.Query<VentasporCodigoDetalladoUNIDetalleModel>(QueryString, null, null, true, 600).ToList();

            var RDet = (from RD in RDetalle select RD).ToList().GroupBy(RDD => new { RDD.RutaDetalle })
                    .SelectMany(RDL => RDL.Select(RDS => new VentasporCodigoDetalladoUNIDetalleModel
                    {
                        RutaDetalle = RDS.RutaDetalle,
                        TipoRuta = RDS.TipoRuta
                    })).ToList();
            string DetalleR = "";
            string TipoR = "";
            foreach (var item in RDet)
            {
                if (item == RDet.Last())
                {
                    DetalleR += item.RutaDetalle;
                    TipoR = item.TipoRuta;
                }
                else
                {
                    DetalleR += item.RutaDetalle + ", ";
                }
            }
            //---------------
            report.labelRutaHeader.Text = DetalleR;

            //Familia de productos
            //Obtener Detalle
            StringBuilder ProdDetalle = new StringBuilder();
            ProdDetalle.AppendLine("Set ANSI_WARNINGS OFF ");
            ProdDetalle.AppendLine("Set nocount on ");
            ProdDetalle.AppendLine("Select EsquemaID, Nombre as EsquemaDetalle from");
            ProdDetalle.AppendLine("(");
            ProdDetalle.AppendLine("select Esquema.EsquemaId as EsquemaID, Esquema.Nombre ");
            ProdDetalle.AppendLine("from Esquema (NOLOCK)");
            ProdDetalle.AppendLine(") as Detalle");
            ProdDetalle.AppendLine(sEsquemasProd);

            QueryString = "";
            QueryString = ProdDetalle.ToString();

            List<VentasporCodigoDetalladoUNIDetalleModel> EDetalle = Connection.Query<VentasporCodigoDetalladoUNIDetalleModel>(QueryString, null, null, true, 600).ToList();

            var EDet = (from ED in EDetalle select ED).ToList().GroupBy(EDD => new { EDD.EsquemaDetalle })
                    .SelectMany(EDL => EDL.Select(EDS => new VentasporCodigoDetalladoUNIDetalleModel
                    {
                        EsquemaDetalle = EDS.EsquemaDetalle
                    })).ToList();
            string DetalleE = "";
            foreach (var item in EDet)
            {
                if (item == EDet.Last())
                {
                    DetalleE += item.EsquemaDetalle;
                }
                else
                {
                    DetalleE += item.EsquemaDetalle + ", ";
                }
            }
            //---------------
            report.labelFamiliaHeader.Text = DetalleE;

            //Productos y Detalles
            //Obtener Detalle
            StringBuilder ProdClaveDetalle = new StringBuilder();
            ProdClaveDetalle.AppendLine("Set ANSI_WARNINGS OFF ");
            ProdClaveDetalle.AppendLine("Set nocount on ");
            ProdClaveDetalle.AppendLine("Select ProductoClave, Nombre as ProductoNombre ");
            ProdClaveDetalle.AppendLine("from Producto (NOLOCK)");
            ProdClaveDetalle.AppendLine("where ProductoClave in (" + nombreProductos + ")");

            QueryString = "";
            QueryString = ProdClaveDetalle.ToString();

            List<VentasporCodigoDetalladoUNIDetalleModel> PDetalle = Connection.Query<VentasporCodigoDetalladoUNIDetalleModel>(QueryString, null, null, true, 600).ToList();

            var PDet = (from PD in PDetalle select PD).ToList().GroupBy(PDD => new { PDD.ProductoClave })
                    .SelectMany(PDL => PDL.Select(PDS => new VentasporCodigoDetalladoUNIDetalleModel
                    {
                        ProductoClave = PDS.ProductoClave,
                        ProductoNombre = PDS.ProductoNombre
                    })).ToList();
            string DetallePCla = "";
            string DetallePNom = "";
            foreach (var item in PDet)
            {
                if (item == PDet.Last())
                {
                    DetallePCla += item.ProductoClave;
                    DetallePNom += item.ProductoNombre;
                }
                else
                {
                    DetallePCla += item.ProductoClave + ", ";
                    DetallePNom += item.ProductoNombre + ", ";
                }
            }
            //---------------
            report.labelCodigoHeader.Text = DetallePCla;
            report.labelDescripcionHeader.Text = DetallePNom;

            ////Filtro
            //string Filtro = FechaInicial.Replace("06:00:00.000Z", "00:00:00");
            //string FiltroFin = FechaInicial.Replace("06:00:00.000Z", "23:00:00");
            //Filtro
            string Filtro = FechaInicial.Substring(0, 4) + FechaInicial.Substring(5, 2) + FechaInicial.Substring(8, 2);
            //string Filtro = FechaInicial.Replace("06:00:00.000Z", "00:00:00");
            //string FiltroFin = FechaInicial.Replace("06:00:00.000Z", "23:00:00");
            string FiltroFin = FechaInicial.Substring(0, 4) + FechaInicial.Substring(5, 2) + FechaInicial.Substring(8, 2);

            //TipoReporte
            if (detallado)
                report.labelTipoHeader.Text = "Completo";
            else
                report.labelTipoHeader.Text = "Resumen";

            //Cambia el tamaño del label Productos y Códigos
            float aux1 = Convert.ToInt32(report.TopMargin.HeightF);
            int contador = DetallePCla.Length / 150;
            if (DetallePCla.Length % 85 != 0)
                contador += 1;
            contador = contador + (DetallePNom.Length / 150);
            if (DetallePNom.Length % 85 != 0)
                contador += 1;
            for (int i = 2; i < contador; i++)
            {
                aux1 += 15;
            }
            TimeSpan t = TimeSpan.FromSeconds(33);

            report.TopMargin.HeightF = (aux1);

            //Seccion I
            StringBuilder Resumen = new StringBuilder();
            Resumen.AppendLine("Set ANSI_WARNINGS OFF ");
            Resumen.AppendLine("Set nocount on ");
            Resumen.AppendLine("DECLARE @FechaFiltro as datetime, @RUTClave as varchar(10) ");
            Resumen.AppendLine("set @FechaFiltro = '" + Filtro + "' ");
            Resumen.AppendLine("set @RUTClave  ='" + RutasSplit + "'");
            Resumen.AppendLine("Select TRP.Folio, VIS.ClienteClave, TRP.TipoFase, TRP.Total into #Ventas ");
            Resumen.AppendLine("from Visita VIS (NOLOCK) ");
            Resumen.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave  ");
            Resumen.AppendLine("inner join TransProd TRP (NOLOCK) on TRP.VisitaClave1 = VIS.VisitaClave and TRP.DiaClave1 = VIS.DiaClave ");
            Resumen.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TPD.TransProdID = TRP.TransProdID and TPD.ProductoClave in (" + nombreProductos + ")");
            Resumen.AppendLine("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura  = @FechaFiltro and TRP.Tipo = 1 and TRP.TipoFase in(0,2) ");
            Resumen.AppendLine("DECLARE @VendedorID as varchar(16), @InicioJornada datetime, @FinJornada datetime ");
            Resumen.AppendLine("Select @VendedorID = VEJ.VendedorId, @InicioJornada=min(VEJFechaInicial), @FinJornada=max(FechaFinal)  ");
            Resumen.AppendLine("from  ");
            Resumen.AppendLine("VendedorJornada VEJ (NOLOCK) ");
            Resumen.AppendLine("inner join VenRut VER (NOLOCK) on VEJ.VendedorId = VER.VendedorID ");
            Resumen.AppendLine("inner join Ruta RUT (NOLOCK) on RUT.RUTClave = VER.RUTClave and  VER.TipoEstado = 1 ");
            Resumen.AppendLine("inner join Dia (NOLOCK) on VEJ.DiaClave = Dia.DiaClave ");
            Resumen.AppendLine("where RUT.RUTClave = @RUTClave and @FechaFiltro = Dia.FechaCaptura ");
            Resumen.AppendLine("group by VEJ.VendedorId ");
            Resumen.AppendLine("Select isnull(ClientesProgramados,0) as ClientesProgramados, isnull(ClientesVisitados,0) as ClientesVisitados, isnull(PedidosPorEntregar,0) as PedidosPorEntregar, ");
            Resumen.AppendLine("isnull(PedidosEntregados,0) as PedidosEntregados, isnull(CtePedidoEntregado,0) as CtePedidoEntregado, isnull(CtePedidoNoEntregado,0) as CtePedidoNoEntregado, ");
            Resumen.AppendLine("CASE WHEN isnull(PedidosPorEntregar,0)  = 0 THEN 0 ELSE (cast(isnull(ClientesVisitados,0) as Decimal) / cast(isnull(PedidosPorEntregar,0) as Decimal)) * 100 END  as  EfectividadVisita, ");
            Resumen.AppendLine("CASE WHEN isnull(PedidosPorEntregar,0) = 0 THEN 0 ELSE (cast(isnull(PedidosEntregados,0) as DEcimal)  / cast(isnull(PedidosPorEntregar,0) as decimal)) * 100 END as EfectividadCompra, ");
            Resumen.AppendLine("CONVERT(varchar,@InicioJornada,108) as InicioJornada, CONVERT(varchar,@FinJornada,108) as FinJornada, isnull(TiempoRecorrido,0) as TiempoRecorrido, isnull(ClientesNuevos, 0) as ClientesNuevos, ");
            Resumen.AppendLine("case when isnull(ClientesVisitados,0) <> 0 then (isnull(TiempoRecorrido,0)/isnull(ClientesVisitados,0)) else 0 end as TiempoPromedio ");
            Resumen.AppendLine("from ");
            Resumen.AppendLine("( ");
            Resumen.AppendLine("Select count(Distinct AGV.ClienteClave) as Cantidad, 'ClientesProgramados' as Dato ");
            Resumen.AppendLine("from AgendaVendedor AGV (NOLOCK) ");
            Resumen.AppendLine("inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave ");
            Resumen.AppendLine("where AGV.RUTClave = @RUTClave and Dia.FechaCaptura  = @FechaFiltro ");
            Resumen.AppendLine("UNION ALL ");
            Resumen.AppendLine("Select count(Distinct VIS.ClienteClave) as Cantidad, 'ClientesVisitados' as Dato ");
            Resumen.AppendLine("from Visita VIS (NOLOCK) ");
            Resumen.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
            Resumen.AppendLine("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura  = @FechaFiltro ");
            Resumen.AppendLine("UNION ALL ");
            Resumen.AppendLine("Select count(Distinct Folio) as Cantidad, 'PedidosPorEntregar' ");
            Resumen.AppendLine("from #Ventas VEN (NOLOCK) ");
            Resumen.AppendLine("where VEN.TipoFase in(0, 2) ");
            Resumen.AppendLine("UNION ALL ");
            Resumen.AppendLine("Select count(Distinct Folio) as Cantidad, 'PedidosEntregados' ");
            Resumen.AppendLine("from #Ventas VEN (NOLOCK) ");
            Resumen.AppendLine("where VEN.TipoFase =2 ");
            Resumen.AppendLine("UNION ALL ");
            Resumen.AppendLine("Select count(Distinct ClienteClave), 'CtePedidoEntregado' ");
            Resumen.AppendLine("from #Ventas VEN ");
            Resumen.AppendLine("where VEN.TipoFase = 2 ");
            Resumen.AppendLine("UNION ALL ");
            Resumen.AppendLine("Select count(Distinct ClienteClave), 'CtePedidoNoEntregado' ");
            Resumen.AppendLine("from #Ventas VEN (NOLOCK) ");
            Resumen.AppendLine("where VEN.TipoFase = 0 ");
            Resumen.AppendLine("UNION ALL ");
            Resumen.AppendLine("Select DateDiff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal ) as Cantidad, 'TiempoRecorrido' ");
            Resumen.AppendLine("from Visita VIS (NOLOCK) ");
            Resumen.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
            Resumen.AppendLine("where VIS.RUTClave = @RUTClave and Dia.FechaCaptura  = @FechaFiltro ");
            Resumen.AppendLine("UNION ALL ");
            Resumen.AppendLine("Select Count(Distinct CLI.ClienteClave)  as Cantidad, 'ClientesNuevos' ");
            Resumen.AppendLine("from Cliente CLI (NOLOCK) ");
            Resumen.AppendLine("where Clave like @RUTClave + '%' and CONVERT (char(10), CLI.FechaRegistroSistema, 112)  =@FechaFiltro ");
            Resumen.AppendLine(") as ResumenOperativo PIVOT ( ");
            Resumen.AppendLine("SUM(Cantidad) ");
            Resumen.AppendLine("FOR Dato IN ([ClientesProgramados], [ClientesVisitados], [PedidosPorEntregar],[PedidosEntregados],[CtePedidoEntregado],[CtePedidoNoEntregado],[TiempoRecorrido],[ClientesNuevos]) ");
            Resumen.AppendLine(") AS ContadoresRuta ");
            Resumen.AppendLine("DROP TABLE #Ventas ");
            QueryString = "";
            QueryString = Resumen.ToString();

            List<SubReportResumen> Res = Connection.Query<SubReportResumen>(QueryString, null, null, true, 600).ToList();

            var ResumenList = (from R in Res select R).ToList().GroupBy(RD => new { RD.ClientesProgramados })
                    .SelectMany(RL => RL.Select(RS => new SubReportResumen
                    {
                        ClientesProgramados = RS.ClientesProgramados,
                        ClientesVisitados = RS.ClientesVisitados,
                        PedidosPorEntregar = RS.PedidosPorEntregar,
                        PedidosEntregados = RS.PedidosEntregados,
                        CtePedidoEntregado = RS.CtePedidoEntregado,
                        CtePedidoNoEntregado = RS.CtePedidoNoEntregado,
                        EfectividadVisita = RS.EfectividadVisita,
                        EfectividadCompra = RS.EfectividadCompra,
                        InicioJornada = RS.InicioJornada,
                        FinJornada = RS.FinJornada,
                        TiempoRecorrido = RS.TiempoRecorrido,
                        ClientesNuevos = RS.ClientesNuevos,
                        TiempoPromedio = string.Format("{0:D2}:{1:D2}:{2:D2}", TimeSpan.FromSeconds(Int32.Parse(RS.TiempoPromedio)).Hours, TimeSpan.FromSeconds(Int32.Parse(RS.TiempoPromedio)).Minutes, TimeSpan.FromSeconds(Int32.Parse(RS.TiempoPromedio)).Seconds)
                    })).ToList();

            //Sección II
            StringBuilder VentaCliente = new StringBuilder();
            VentaCliente.AppendLine("Set ANSI_WARNINGS OFF ");
            VentaCliente.AppendLine("Set nocount on ");
            VentaCliente.AppendLine("DECLARE @FechaFiltro1 as datetime, @FechaFiltro2 as datetime, @RUTClave as varchar(10) ");
            VentaCliente.AppendLine("set @FechaFiltro1 = '" + Filtro + "' ");
            VentaCliente.AppendLine("set @FechaFiltro2 = '" + FiltroFin + "' ");
            VentaCliente.AppendLine("set @RUTClave  ='" + RutasSplit + "' ");
            VentaCliente.AppendLine("SELECT ");
            VentaCliente.AppendLine("CONVERT(varchar,FechaHoraInicial,108) as FechaHoraInicial, ");
            VentaCliente.AppendLine("CONVERT(varchar,FechaHoraFinal,108) as FechaHoraFinal, ");
            VentaCliente.AppendLine("Clave, ");
            VentaCliente.AppendLine("RazonSocial as Cliente, ");
            VentaCliente.AppendLine("isnull(Folio,'Cambio') as Folio, ");
            VentaCliente.AppendLine("DiaClave, ");
            VentaCliente.AppendLine("ProductoClave as SKU, ");
            VentaCliente.AppendLine("NombreLargo as Producto, ");
            VentaCliente.AppendLine("Descripcion as Unidad_de_Medida, ");
            VentaCliente.AppendLine("isnull(Venta,0) as Venta, ");
            VentaCliente.AppendLine("isnull(Cambios,0) as CambiosC, ");
            VentaCliente.AppendLine("isnull([Promociones],0) as Promociones, ");
            VentaCliente.AppendLine("isnull(Importe,0) as Importe_Venta ");
            VentaCliente.AppendLine("from ");
            VentaCliente.AppendLine("( ");

            if (TipoR == "1" || TipoR == "2")
            {
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine("union all ");
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial,  (select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo=1 and t.TipoFase <> 0 and vi.VisitaClave = t.VisitaClave and vi.DiaClave=t.DiaClave and t.ClienteClave=vi.ClienteClave) as Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 3 and tp.TipoFase<>0 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine("union all ");
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, (select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo=1 and t.TipoFase <> 0 and vi.VisitaClave = t.VisitaClave and vi.DiaClave=t.DiaClave and t.ClienteClave=vi.ClienteClave) as Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 9 and tp.TipoFase<>0 and tp.TipoMovimiento=1 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine("union all ");
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Total_Unidades' as Nombre, tpd.Cantidad as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 and tpd.Promocion= 2 and tpd.Total=0 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine("union all ");
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine(") pvt ");
                VentaCliente.AppendLine("PIVOT ");
                VentaCliente.AppendLine("( ");
                VentaCliente.AppendLine("sum(Total) FOR Nombre IN ([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe]) ");
                VentaCliente.AppendLine(") AS PivotTable ");
            }
            else if (TipoR == "3")
            {
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave1,tp.VisitaClave) and vi.DiaClave= isnull(tp.DiaClave1,tp.DiaClave) ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine("union all ");
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, (select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo=1 and t.TipoFase <> 0 and vi.DiaClave=isnull(t.VisitaClave1,t.VisitaClave) and vi.DiaClave= isnull(t.DiaClave1,t.DiaClave)  and t.ClienteClave=vi.ClienteClave) as Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 9 and tp.TipoFase<>0 and tp.TipoMovimiento=1 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave1,tp.VisitaClave) and vi.DiaClave= isnull(tp.DiaClave1,tp.DiaClave) ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine("union all ");
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 and tpd.Promocion= 2 and tpd.Total=0 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave1,tp.VisitaClave) and vi.DiaClave= isnull(tp.DiaClave1,tp.DiaClave) ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine("union all ");
                VentaCliente.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total ");
                VentaCliente.AppendLine("from TransProd tp (NOLOCK)  ");
                VentaCliente.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 ");
                VentaCliente.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave1,tp.VisitaClave) and vi.DiaClave= isnull(tp.DiaClave1,tp.DiaClave) ");
                VentaCliente.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCliente.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCliente.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCliente.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCliente.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCliente.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                VentaCliente.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCliente.AppendLine(") pvt ");
                VentaCliente.AppendLine("PIVOT ");
                VentaCliente.AppendLine("( ");
                VentaCliente.AppendLine("sum(Total) FOR Nombre IN ([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe]) ");
                VentaCliente.AppendLine(") AS PivotTable ");
            }
            VentaCliente.AppendLine("where Venta <> 0 OR Cambios <> 0 ");
            VentaCliente.AppendLine("order by FechaHoraInicial, Folio, ProductoClave ");
            QueryString = "";
            QueryString = VentaCliente.ToString();

            List<SubReportVentaCliente> Clientes = Connection.Query<SubReportVentaCliente>(QueryString, null, null, true, 600).ToList();

            var SubClientes = (from c in Clientes
                               select c).ToList();
            List<SubReportVentaCliente> Cli = new List<SubReportVentaCliente>();

            var SC = (from gr in SubClientes group gr by new { gr.FechaHoraInicial } into grupo select grupo);

            Decimal Total = 0;
            long TotalPiezas = 0;
            long TotalCambio = 0;
            long TotalPromocion = 0;
            double auxTime = 0;

            string FInicio = ResumenList[0].InicioJornada;

            foreach (var grupo in SC)
            {
                foreach (var objetoAgrupado in grupo)
                {
                    Cli.Add(new SubReportVentaCliente
                    {
                        Clave = objetoAgrupado.Clave + " - " + objetoAgrupado.Cliente,
                        Folio = objetoAgrupado.Folio,
                        DiaClave = objetoAgrupado.DiaClave,
                        SKU = objetoAgrupado.SKU,
                        Producto = objetoAgrupado.Producto,
                        Unidad_de_Medida = objetoAgrupado.Unidad_de_Medida,
                        Venta = objetoAgrupado.Venta,
                        CambiosC = objetoAgrupado.CambiosC,
                        Promociones = objetoAgrupado.Promociones,
                        Importe_Venta = objetoAgrupado.Importe_Venta,
                        SubT = "SubTotal",
                        GraT = "GRAN TOTAL",
                        FechaHoraInicial = objetoAgrupado.FechaHoraInicial,
                        FechaHoraFinal = objetoAgrupado.FechaHoraFinal,
                        TiempoVisita = TimeSpan.Parse(objetoAgrupado.FechaHoraFinal) - TimeSpan.Parse(objetoAgrupado.FechaHoraInicial) + ""
                        //TiempoRecorrido = TimeSpan.Parse(FInicio) - TimeSpan.Parse(objetoAgrupado.FechaHoraInicial) + ""
                    });
                    Cli.Last().ImporteSubTotal = grupo.Sum(c => c.Importe_Venta);
                    Cli.Last().PiezasSubTotal = grupo.Sum(c => c.Venta);
                    Cli.Last().PiezasCambioSubTotalC = grupo.Sum(c => c.CambiosC);
                    Cli.Last().PiezasPromocionSubTotal = grupo.Sum(c => c.Promociones);

                    Total += objetoAgrupado.Importe_Venta;
                    TotalPiezas += objetoAgrupado.Venta;
                    TotalCambio += objetoAgrupado.CambiosC;
                    TotalPromocion += objetoAgrupado.Promociones;
                }
            }


            var count = Cli.Count;
            for (var i = 0; i < count; i++)
            {
                var item = Cli[i];
                if (item == Cli.First())
                {
                    item.TiempoRecorrido = TimeSpan.Parse(item.FechaHoraInicial) - TimeSpan.Parse(FInicio) + "";
                    FInicio = item.FechaHoraFinal;
                }
                else
                {
                    if (item.FechaHoraFinal != Cli[i - 1].FechaHoraFinal)
                    {
                        FInicio = Cli[i - 1].FechaHoraFinal;
                    }
                    item.TiempoRecorrido = TimeSpan.Parse(item.FechaHoraInicial) - TimeSpan.Parse(FInicio) + "";
                }

            }

            //Promedio visita
            string auxCliente = "";
            for (var i = 0; i < count; i++)
            {
                if (auxCliente != Cli[i].Clave)
                {
                    auxCliente = Cli[i].Clave;
                    auxTime += TimeSpan.Parse(Cli[i].FechaHoraFinal).TotalSeconds - TimeSpan.Parse(Cli[i].FechaHoraInicial).TotalSeconds;
                }
            }
            auxTime = auxTime / Int32.Parse(ResumenList[0].ClientesVisitados);
            string TiempoPromedio = string.Format("{0:D2}:{1:D2}:{2:D2}", TimeSpan.FromSeconds(auxTime).Hours, TimeSpan.FromSeconds(auxTime).Minutes, TimeSpan.FromSeconds(auxTime).Seconds);

            if (detallado == true)
            {
                //SubReporte Venta por Cliente
                SubReporteVentasCliente SubReportCliente = new SubReporteVentasCliente();
                SubReportCliente.DataSource = Cli;

                //Group Header
                GroupField groupCliente = new GroupField("Clave");
                SubReportCliente.GroupHeader1.GroupFields.Add(groupCliente);
                SubReportCliente.labelCliente.DataBindings.Add("Text", SubReportCliente.DataSource, "Clave");

                //Detalle
                SubReportCliente.labelFolioC.DataBindings.Add("Text", null, "Folio");
                SubReportCliente.labelFechaC.DataBindings.Add("Text", null, "DiaClave", "{0:dd/MM/yyyy}");
                SubReportCliente.labelCodigoC.DataBindings.Add("Text", null, "SKU");
                SubReportCliente.labelDescripcionC.DataBindings.Add("Text", null, "Producto");
                SubReportCliente.labelPiezasVC.DataBindings.Add("Text", null, "Venta");
                SubReportCliente.labelPiezasCC.DataBindings.Add("Text", null, "CambiosC");
                SubReportCliente.labelPiezasPC.DataBindings.Add("Text", null, "Promociones");
                SubReportCliente.labelImporteC.DataBindings.Add("Text", null, "Importe_Venta", "{0:$0.00}");

                //Subtotal
                SubReportCliente.labelSubTotalC.DataBindings.Add("Text", null, "SubT");
                SubReportCliente.labelSubVentaC.DataBindings.Add("Text", null, "PiezasSubTotal");
                SubReportCliente.labelSubCambioC.DataBindings.Add("Text", null, "PiezasCambioSubTotalC");
                SubReportCliente.labelSubPromocionC.DataBindings.Add("Text", null, "PiezasPromocionSubTotal");
                SubReportCliente.labelSubImporteC.DataBindings.Add("Text", null, "ImporteSubTotal", "{0:$0.00}");

                //GranTotal
                SubReportCliente.labelGranTotalC.DataBindings.Add("Text", null, "GraT");
                SubReportCliente.labelGranVentaC.Text = TotalPiezas + "";
                SubReportCliente.labelGranCambioC.Text = TotalCambio + "";
                SubReportCliente.labelGranPromocionC.Text = TotalPromocion + "";
                SubReportCliente.labelGranImporteC.Text = ("$" + Total).Replace(",0", ",00");

                if (Cli.Count > 0)
                {
                    report.xrSubreportCliente.ReportSource = SubReportCliente;
                }
            }
            else
            {
                //SubReporte Venta por Cliente
                SubReporteVentasClienteDetallado SubReportCliente = new SubReporteVentasClienteDetallado();
                SubReportCliente.DataSource = Cli;

                //Group Header
                GroupField groupFecha = new GroupField("FechaHoraInicial");
                SubReportCliente.GroupHeader2.GroupFields.Add(groupFecha);

                //Group Header
                GroupField groupCliente = new GroupField("Clave");
                SubReportCliente.GroupHeader1.GroupFields.Add(groupCliente);
                SubReportCliente.labelCliente.DataBindings.Add("Text", SubReportCliente.DataSource, "Clave");
                SubReportCliente.labelFechaC.DataBindings.Add("Text", null, "DiaClave", "{0:dd/MM/yyyy}");
                SubReportCliente.labelTiempoT.DataBindings.Add("Text", null, "TiempoRecorrido");
                SubReportCliente.labelHInicio.DataBindings.Add("Text", null, "FechaHoraInicial");
                SubReportCliente.labelHFinal.DataBindings.Add("Text", null, "FechaHoraFinal");
                SubReportCliente.labelTiempoVisita.DataBindings.Add("Text", null, "TiempoVisita");

                //Footer
                SubReportCliente.labelPiezasVC.DataBindings.Add("Text", null, "PiezasSubTotal");
                SubReportCliente.labelPiezasCC.DataBindings.Add("Text", null, "PiezasCambioSubTotalC");
                SubReportCliente.labelPiezasPC.DataBindings.Add("Text", null, "PiezasPromocionSubTotal");
                SubReportCliente.labelImporteC.DataBindings.Add("Text", null, "ImporteSubTotal", "{0:$0.00}");

                //GranTotal
                SubReportCliente.labelGranTotalC.DataBindings.Add("Text", null, "GraT");
                SubReportCliente.labelGranVentaC.Text = TotalPiezas + "";
                SubReportCliente.labelGranCambioC.Text = TotalCambio + "";
                SubReportCliente.labelGranPromocionC.Text = TotalPromocion + "";
                SubReportCliente.labelGranImporteC.Text = ("$" + Total).Replace(",0", ",00");

                if (Cli.Count > 0)
                {
                    report.xrSubreportCliente.ReportSource = SubReportCliente;
                }
            }
            //-----------

            //Sección III
            StringBuilder VentaCodigo = new StringBuilder();
            VentaCodigo.AppendLine("Set ANSI_WARNINGS OFF ");
            VentaCodigo.AppendLine("Set nocount on ");
            VentaCodigo.AppendLine("DECLARE @FechaFiltro1 as datetime, @FechaFiltro2 as datetime, @RUTClave as varchar(10) ");
            VentaCodigo.AppendLine("set @FechaFiltro1 = '" + Filtro + "' ");
            VentaCodigo.AppendLine("set @FechaFiltro2 = '" + FiltroFin + "' ");
            VentaCodigo.AppendLine("set @RUTClave  ='" + RutasSplit + "' ");
            VentaCodigo.AppendLine("SELECT Clave, DiaClave, ProductoClave as SKU, NombreLargo as Producto, Descripcion as Unidad_de_Medida, ");
            VentaCodigo.AppendLine("isnull(Venta, 0) as Venta, isnull(Cambios, 0) as Cambios, isnull([Promociones],0) as Promociones, isnull(Importe, 0) as Importe_Venta, 1 as Auxiliar ");
            VentaCodigo.AppendLine("FROM( ");
            if (TipoR == "1" || TipoR == "2")
            {
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine("union all ");
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial,  (select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo=1 and t.TipoFase <> 0 and vi.VisitaClave = t.VisitaClave and vi.DiaClave=t.DiaClave and t.ClienteClave=vi.ClienteClave) as Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 3 and tp.TipoFase<>0 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine("union all ");
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, (select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo=1 and t.TipoFase <> 0 and vi.VisitaClave = t.VisitaClave and vi.DiaClave=t.DiaClave and t.ClienteClave=vi.ClienteClave) as Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 9 and tp.TipoFase<>0 and tp.TipoMovimiento=1 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine("union all ");
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Total_Unidades' as Nombre, tpd.Cantidad as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 and tpd.Promocion= 2 and tpd.Total=0 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine("union all ");
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine(") pvt ");
                VentaCodigo.AppendLine("PIVOT ");
                VentaCodigo.AppendLine("( ");
                VentaCodigo.AppendLine("sum(Total) FOR Nombre IN ([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe]) ");
                VentaCodigo.AppendLine(") AS PivotTable ");
            }
            else if (TipoR == "3")
            {
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave1,tp.VisitaClave) and vi.DiaClave= isnull(tp.DiaClave1,tp.DiaClave) ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine("union all ");
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, (select top 1 t.Folio from TransProd t (NOLOCK) where t.Tipo=1 and t.TipoFase <> 0 and vi.DiaClave=isnull(t.VisitaClave1,t.VisitaClave) and vi.DiaClave= isnull(t.DiaClave1,t.DiaClave)  and t.ClienteClave=vi.ClienteClave) as Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 9 and tp.TipoFase<>0 and tp.TipoMovimiento=1 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave1,tp.VisitaClave) and vi.DiaClave= isnull(tp.DiaClave1,tp.DiaClave) ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine("union all ");
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK) ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 and tpd.Promocion= 2 and tpd.Total=0 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave1,tp.VisitaClave) and vi.DiaClave= isnull(tp.DiaClave1,tp.DiaClave) ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine("union all ");
                VentaCodigo.AppendLine("select vi.FechaHoraInicial, vi.FechaHoraFinal, c.Clave,c.RazonSocial, tp.Folio,d.DiaClave,p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total ");
                VentaCodigo.AppendLine("from TransProd tp (NOLOCK)  ");
                VentaCodigo.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0 ");
                VentaCodigo.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = isnull(tp.VisitaClave1,tp.VisitaClave) and vi.DiaClave= isnull(tp.DiaClave1,tp.DiaClave) ");
                VentaCodigo.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave ");
                VentaCodigo.AppendLine("inner join Cliente c (NOLOCK) on vi.ClienteClave=c.ClienteClave ");
                VentaCodigo.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave and p.ProductoClave in (" + nombreProductos + ") ");
                VentaCodigo.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave ");
                VentaCodigo.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM' ");
                VentaCodigo.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 3 and r.RUTClave = vi.RUTClave ");
                VentaCodigo.AppendLine("where 1 = 1 and d.FechaCaptura between @FechaFiltro1 and @FechaFiltro2 and vi.RUTClave in (@RUTClave) ");
                VentaCodigo.AppendLine(") pvt ");
                VentaCodigo.AppendLine("PIVOT ");
                VentaCodigo.AppendLine("( ");
                VentaCodigo.AppendLine("sum(Total) FOR Nombre IN ([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe]) ");
                VentaCodigo.AppendLine(") AS PivotTable ");
            }
            VentaCodigo.AppendLine("where Venta <> 0 OR Cambios <> 0 ");
            VentaCodigo.AppendLine("order by SKU ");

            QueryString = "";
            QueryString = VentaCodigo.ToString();

            List<SubReportVentaCodigo> Codigo = Connection.Query<SubReportVentaCodigo>(QueryString, null, null, true, 600).ToList();

            var SubCodigo = (from c in Codigo
                             select c).ToList();
            List<SubReportVentaCodigo> Cod = new List<SubReportVentaCodigo>();

            var SR = (from gr in SubCodigo group gr by new { gr.SKU } into grupo select grupo);

            Total = 0;
            TotalPiezas = 0;
            TotalCambio = 0;
            TotalPromocion = 0;
            string TotalClientes = "";

            foreach (var item in ResumenList)
            {
                TotalClientes = item.ClientesVisitados;
            }

            foreach (var grupo in SR)
            {
                foreach (var objetoAgrupado in grupo)
                {
                    Cod.Add(new SubReportVentaCodigo
                    {
                        DiaClave = objetoAgrupado.DiaClave,
                        SKU = objetoAgrupado.SKU,
                        Producto = objetoAgrupado.Producto,
                        Unidad_de_Medida = objetoAgrupado.Unidad_de_Medida,
                        Venta = objetoAgrupado.Venta,
                        Cambios = objetoAgrupado.Cambios,
                        Promociones = objetoAgrupado.Promociones,
                        Importe_Venta = objetoAgrupado.Importe_Venta,
                        Auxiliar = objetoAgrupado.Auxiliar,
                        GraT = "GRAN TOTAL"
                    });
                    Cod.Last().ImporteSubTotal = grupo.Sum(c => c.Importe_Venta);
                    Cod.Last().PiezasSubTotal = grupo.Sum(c => c.Venta);
                    Cod.Last().PiezasCambioSubTotal = grupo.Sum(c => c.Cambios);
                    Cod.Last().PiezasPromocionSubTotal = grupo.Sum(c => c.Promociones);
                    Cod.Last().CVisitados = Int32.Parse(TotalClientes);
                    Cod.Last().CEfectivos = grupo.Sum(c => c.Auxiliar);
                    Cod.Last().Cobertura = Math.Round((grupo.Sum(c => c.Auxiliar) / Double.Parse("0" + TotalClientes + "")) * 100, 0) + "%";

                    Total += objetoAgrupado.Importe_Venta;
                    TotalPiezas += objetoAgrupado.Venta;
                    TotalCambio += objetoAgrupado.Cambios;
                    TotalPromocion += objetoAgrupado.Promociones;
                }
            }

            //SubReporte Venta por Codigo
            SubReporteVentasCodigo SubReportCodigo = new SubReporteVentasCodigo();
            SubReportCodigo.DataSource = Cod;

            //Group Header
            GroupField groupCodigo = new GroupField("SKU");
            SubReportCodigo.GroupHeader1.GroupFields.Add(groupCodigo);
            SubReportCodigo.labelCodigoC.DataBindings.Add("Text", null, "SKU");
            SubReportCodigo.labelDescripcionC.DataBindings.Add("Text", null, "Producto");
            SubReportCodigo.labelPiezasVC.DataBindings.Add("Text", null, "PiezasSubTotal");
            SubReportCodigo.labelPiezasCC.DataBindings.Add("Text", null, "PiezasCambioSubTotal");
            SubReportCodigo.labelPiezasPC.DataBindings.Add("Text", null, "PiezasPromocionSubTotal");
            SubReportCodigo.labelImporteC.DataBindings.Add("Text", null, "ImporteSubTotal", "{0:$0.00}");
            SubReportCodigo.labelClienteC.DataBindings.Add("Text", null, "CVisitados");
            SubReportCodigo.labelClienteCE.DataBindings.Add("Text", null, "CEfectivos");
            SubReportCodigo.labelCobertura.DataBindings.Add("Text", null, "Cobertura");

            //GranTotal
            SubReportCodigo.labelGranTotalC.DataBindings.Add("Text", null, "GraT");
            SubReportCodigo.labelGranVentaC.Text = TotalPiezas + "";
            SubReportCodigo.labelGranCambioC.Text = TotalCambio + "";
            SubReportCodigo.labelGranPromocionC.Text = TotalPromocion + "";
            SubReportCodigo.labelGranImporteC.Text = ("$" + Total).Replace(",0", ",00");

            if (TipoR == "1" || TipoR == "2")
            {
                SubReporteResumenT1 SubReporteR = new SubReporteResumenT1();
                SubReporteR.DataSource = ResumenList;

                SubReporteR.labelClientesPro.DataBindings.Add("Text", null, "ClientesProgramados");
                SubReporteR.labelClientesVis.DataBindings.Add("Text", null, "ClientesVisitados");
                SubReporteR.labelTiempoPro.Text = TiempoPromedio;
                SubReporteR.labelTotalVenta.Text = ("$" + Total).Replace(",0", ",00");

                if (ResumenList.Count > 0)
                {
                    report.xrSubreportResumen.ReportSource = SubReporteR;
                }
            }
            else if (TipoR == "3")
            {
                SubReporteResumenT3 SubReporteR = new SubReporteResumenT3();
                SubReporteR.DataSource = ResumenList;

                SubReporteR.labelClientesPro.DataBindings.Add("Text", null, "ClientesProgramados");
                SubReporteR.labelClientesVis.DataBindings.Add("Text", null, "ClientesVisitados");
                SubReporteR.labelPedidosPE.DataBindings.Add("Text", null, "PedidosPorEntregar");
                SubReporteR.labelPedidosE.DataBindings.Add("Text", null, "PedidosEntregados");
                SubReporteR.labelTotalPedido.Text = ("$" + Total).Replace(",0", ",00");
                SubReporteR.labelTiempoPro.Text = TiempoPromedio;

                if (ResumenList.Count > 0)
                {
                    report.xrSubreportResumen.ReportSource = SubReporteR;
                }
            }
            //----------

            if (Cod.Count > 0)
            {
                report.xrSubreportCodigo.ReportSource = SubReportCodigo;
            }
            //-----------

            //Regresa el reporte completo
            if (Cli.Count == 0 && Cod.Count == 0)
            {
                return null;
            }
            else
            {
                return report;
            }
        }

    }

    class VentasporCodigoDetalladoUNIDetalleModel
    {
        public string RutaDetalle { get; set; }
        public string TipoRuta { get; set; }
        public string EsquemaDetalle { get; set; }
        public string ProductoClave { get; set; }
        public string ProductoNombre { get; set; }
    }

    class SubReportResumen
    {
        public string ClientesProgramados { get; set; }
        public string ClientesVisitados { get; set; }
        public string PedidosPorEntregar { get; set; }
        public string PedidosEntregados { get; set; }
        public string CtePedidoEntregado { get; set; }
        public string CtePedidoNoEntregado { get; set; }
        public string EfectividadVisita { get; set; }
        public string EfectividadCompra { get; set; }
        public string InicioJornada { get; set; }
        public string FinJornada { get; set; }
        public string TiempoRecorrido { get; set; }
        public string ClientesNuevos { get; set; }
        public string TiempoPromedio { get; set; }
    }

    class SubReportVentaCliente
    {
        public string Clave { get; set; }
        public string Cliente { get; set; }
        public string Folio { get; set; }
        public string DiaClave { get; set; }
        public string SKU { get; set; }
        public string Producto { get; set; }
        public string Unidad_de_Medida { get; set; }
        public long Venta { get; set; }
        public long CambiosC { get; set; }
        public long Promociones { get; set; }
        public Decimal Importe_Venta { get; set; }

        public string FechaHoraInicial { get; set; }
        public string FechaHoraFinal { get; set; }
        public string TiempoVisita { get; set; }
        public string TiempoRecorrido { get; set; }

        public Decimal ImporteSubTotal { get; set; }
        public long PiezasSubTotal { get; set; }
        public long PiezasCambioSubTotalC { get; set; }
        public long PiezasPromocionSubTotal { get; set; }

        public string SubT { get; set; }
        public string GraT { get; set; }
    }

    class SubReportVentaCodigo
    {
        public string Clave { get; set; }
        public string Cliente { get; set; }
        public string Folio { get; set; }
        public string DiaClave { get; set; }
        public string SKU { get; set; }
        public string Producto { get; set; }
        public string Unidad_de_Medida { get; set; }
        public long Venta { get; set; }
        public long Cambios { get; set; }
        public long Promociones { get; set; }
        public Decimal Importe_Venta { get; set; }

        public Decimal ImporteSubTotal { get; set; }
        public long PiezasSubTotal { get; set; }
        public long PiezasCambioSubTotal { get; set; }
        public long PiezasPromocionSubTotal { get; set; }

        public long CEfectivos { get; set; }
        public long CVisitados { get; set; }
        public string Cobertura { get; set; }
        public long Auxiliar { get; set; }
        public string GraT { get; set; }
    }
}