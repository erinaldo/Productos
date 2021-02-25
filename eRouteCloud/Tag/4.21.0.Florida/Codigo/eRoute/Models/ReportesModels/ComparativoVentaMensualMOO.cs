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
using System.Threading;

namespace eRoute.Models.ReportesModels
{
    public class ComparativoVentaMensualMOO
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(int VAVClave, string nombreReport, string nombreCedis, string pvCondicion, string FechaInicial, string FechaFinal, string Cedis, string unidadMedida, string sFechaAnioActual, string sFechaAnioAnterior)
        {
            try
            {
                DateTime sFecha = Convert.ToDateTime(FechaInicial);
                DateTime sFechaFin = Convert.ToDateTime(FechaFinal);

                DateTime dFechaIni = new DateTime(sFecha.Year, sFecha.Month, sFecha.Day);
                DateTime dFechaFin = new DateTime(sFechaFin.Year, sFechaFin.Month, sFechaFin.Day);

                //Fecha Acumulados

                DateTime dFechaIniAnioActual = new DateTime(sFecha.Year, 1, 1);
                DateTime dFechaFinAnioActual = dFechaFin;

                DateTime dFechaIniAnioAnterior = new DateTime(sFecha.Year - 1, 1, 1);
                DateTime dFechaFinAnioAnterior = new DateTime(dFechaFin.Year - 1, dFechaFin.Month, DateTime.DaysInMonth(dFechaFin.Year - 1, dFechaFin.Month));

                String sFechaAcumuladoAnioActual = "convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) between '" + dFechaIniAnioActual.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "' and '" + dFechaFinAnioActual.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'";
                String sFechaAcumuladoAnioAnterior = "convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) between '" + dFechaIniAnioAnterior.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "' and '" + dFechaFinAnioAnterior.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'";

                bool ExisteOrdenProductos = ordenProductos(VAVClave);
                
                //Consulta DetalleProductos
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("select * from (");
                sConsulta.AppendLine("select ALM.Clave as ALMClave, ");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre, ");
                sConsulta.AppendLine("datename(yy,Dia.DiaClave) as Anio, ");
                sConsulta.AppendLine("isnull(E.Orden,'') as Orden, ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema, ");
                sConsulta.AppendLine("TPD.ProductoClave,  ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("PRO.Contenido,  ");
                sConsulta.AppendLine("PRO.Venta ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'CartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'CartonesHectolitraje'");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioActual + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta, OP.Orden ");
                else
                    sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta ");
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select ALM.Clave as ALMClave, ");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre, ");
                sConsulta.AppendLine("datename(yy,Dia.DiaClave) as Anio, ");
                sConsulta.AppendLine("isnull(E.Orden,'') as Orden, ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema, ");
                sConsulta.AppendLine("TPD.ProductoClave,  ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("PRO.Contenido,  ");
                sConsulta.AppendLine("PRO.Venta ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'CartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'CartonesHectolitraje'");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioAnterior + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta, OP.Orden ");
                else
                    sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta ");
                sConsulta.AppendLine(") as t ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("order by t.ALMClave, t.OrdenProductos, t.ProductoClave, t.Anio");
                else
                    sConsulta.AppendLine("order by t.ALMClave, t.Orden, t.ProductoClave, t.Anio");

                String consultaDetalleProductos = sConsulta.ToString();

                List<DetalleProductosModel> DetalleProductos = Connection.Query<DetalleProductosModel>(consultaDetalleProductos, null, null, true, 600).ToList();

                if (DetalleProductos.Count() <= 0)
                {
                    return null;
                }

                //Consulta Productos
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("select isnull(E.Orden,'') as Orden,  ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema, ");
                sConsulta.AppendLine("E.Nombre as NombreEsquema, ");
                sConsulta.AppendLine("TPD.ProductoClave,  ");
                sConsulta.AppendLine("PRO.Nombre  ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0 ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioActual + " )");
                sConsulta.AppendLine("and (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                {
                    sConsulta.AppendLine("group by E.Orden, E.Clave, E.Nombre, TPD.ProductoClave, PRO.Nombre, OP.Orden ");
                    sConsulta.AppendLine("order by OP.Orden");
                }
                else
                {
                    sConsulta.AppendLine("group by E.Orden, E.Clave, E.Nombre, TPD.ProductoClave, PRO.Nombre ");
                    sConsulta.AppendLine("order by TPD.ProductoClave");
                }
                sConsulta.AppendLine("");
                String consultaProductos = sConsulta.ToString();

                List<ProductosModel> Productos = Connection.Query<ProductosModel>(consultaProductos, null, null, true, 600).ToList();


                //Consulta Anios
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("declare @TablaAnios table(Anio varchar(100))");
                sConsulta.AppendLine("declare @FechaInicial datetime,@FechaFinal datetime");
                sConsulta.AppendLine("set @FechaInicial='" + dFechaIni.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'");
                sConsulta.AppendLine("set @FechaFinal='" + dFechaFin.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("insert @TablaAnios values (datepart(YYYY,@FechaInicial))");
                sConsulta.AppendLine("insert @TablaAnios values (datepart(YYYY,@FechaInicial)-1)");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select * from @TablaAnios order by Anio desc");
                String consultaAnios = sConsulta.ToString();

                List<AniosModel> Anios = Connection.Query<AniosModel>(consultaAnios, null, null, true, 600).ToList();

                //Consulta Cedis
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("select ALM.Clave as ALMClave,");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0 ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioActual + " )");
                sConsulta.AppendLine("and (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("union");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select ALM.Clave as ALMClave,");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0 ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioAnterior + " )");
                sConsulta.AppendLine("and (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre ");

                String consultaCedis = sConsulta.ToString();

                List<CedisModel> cCedis = Connection.Query<CedisModel>(consultaCedis, null, null, true, 600).ToList();


                //Consulta ProductosGlobal
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("select * from (");
                sConsulta.AppendLine("select datename(yy,Dia.DiaClave) as Anio, ");
                sConsulta.AppendLine("isnull(E.Orden,'') as Orden, ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema, ");
                sConsulta.AppendLine("TPD.ProductoClave,  ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("PRO.Contenido,  ");
                sConsulta.AppendLine("PRO.Venta ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'CartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'CartonesHectolitraje'");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioActual + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta, OP.Orden ");
                else
                    sConsulta.AppendLine("group by datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select datename(yy,Dia.DiaClave) as Anio, ");
                sConsulta.AppendLine("isnull(E.Orden,'') as Orden, ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema, ");
                sConsulta.AppendLine("TPD.ProductoClave,  ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("PRO.Contenido,  ");
                sConsulta.AppendLine("PRO.Venta ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'CartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'CartonesHectolitraje'");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioAnterior + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta, OP.Orden ");
                else
                    sConsulta.AppendLine("group by datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta ");
                sConsulta.AppendLine(") as t ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("order by t.OrdenProductos, t.Anio");
                else
                    sConsulta.AppendLine("order by t.Orden, t.ProductoClave, t.Anio");

                String consultaProductosGlobal = sConsulta.ToString();

                List<ProductosGlobalModel> ProductosGlobal = Connection.Query<ProductosGlobalModel>(consultaProductosGlobal, null, null, true, 600).ToList();


                //Consulta ProductosAcumulado
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("select * from (");
                sConsulta.AppendLine("select datename(yy,Dia.DiaClave) as Anio, ");
                sConsulta.AppendLine("isnull(E.Orden,'') as Orden, ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema, ");
                sConsulta.AppendLine("TPD.ProductoClave,  ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("PRO.Contenido,  ");
                sConsulta.AppendLine("PRO.Venta ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'CartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'CartonesHectolitraje'");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAcumuladoAnioActual + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta, OP.Orden ");
                else
                    sConsulta.AppendLine("group by datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select datename(yy,Dia.DiaClave) as Anio, ");
                sConsulta.AppendLine("isnull(E.Orden,'') as Orden, ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema, ");
                sConsulta.AppendLine("TPD.ProductoClave,  ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("PRO.Contenido,  ");
                sConsulta.AppendLine("PRO.Venta ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'CartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'CartonesHectolitraje'");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAcumuladoAnioAnterior + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta, OP.Orden ");
                else
                    sConsulta.AppendLine("group by datename(yy,Dia.DiaClave), E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta ");
                sConsulta.AppendLine(") as t ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("order by t.OrdenProductos, t.Anio");
                else
                    sConsulta.AppendLine("order by t.Orden, t.ProductoClave, t.Anio");

                String consultaProductosAcumulado = sConsulta.ToString();

                List<ProductosAcumuladoModel> ProductosAcumulado = Connection.Query<ProductosAcumuladoModel>(consultaProductosAcumulado, null, null, true, 600).ToList();


                //Consulta NombreMesFinal
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("declare @Mes as varchar(20)");
                sConsulta.AppendLine("set @Mes=(select datename(mm,'" + dFechaFinAnioActual.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'))");
                sConsulta.AppendLine("select @Mes as Mes");

                String consultaNombreMesFinal = sConsulta.ToString();

                String NombreMesFinal = Connection.Query<String>(consultaNombreMesFinal, null, null, true, 600).FirstOrDefault();


                //Consulta ProductosPorDia
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("select Dia.DiaClave as DiaClave, ");
                sConsulta.AppendLine("Dia.FechaCaptura as Fecha,  ");
                sConsulta.AppendLine("isnull(E.Orden,'') as Orden, ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema, ");
                sConsulta.AppendLine("TPD.ProductoClave,  ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("PRO.Contenido,  ");
                sConsulta.AppendLine("PRO.Venta ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'CartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'CartonesHectolitraje'");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioActual + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                {
                    sConsulta.AppendLine("group by Dia.DiaClave, Dia.FechaCaptura, E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta, OP.Orden ");
                    sConsulta.AppendLine("order by Dia.FechaCaptura, OP.Orden");
                }
                else
                {
                    sConsulta.AppendLine("group by Dia.DiaClave, Dia.FechaCaptura, E.Orden, E.Clave, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta ");
                    sConsulta.AppendLine("order by Dia.FechaCaptura, E.Orden, TPD.ProductoClave");
                }

                String consultaProductosPorDia = sConsulta.ToString();

                List<ProductosPorDiaModel> ProductosPorDia = Connection.Query<ProductosPorDiaModel>(consultaProductosPorDia, null, null, true, 600).ToList();

                //Consulta Fechas
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("select Dia.DiaClave as DiaClave, ");
                sConsulta.AppendLine("Dia.FechaCaptura as Fecha  ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaAnioActual + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                sConsulta.AppendLine("group by Dia.DiaClave, Dia.FechaCaptura ");
                sConsulta.AppendLine("order by Dia.FechaCaptura ");

                String consultaFechas = sConsulta.ToString();

                List<FechasModel> Fechas = Connection.Query<FechasModel>(consultaFechas, null, null, true, 600).ToList();


                string empresaQuery = "select NombreEmpresa from Configuracion (NOLOCK) ";
                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();


                // Dim drColsCedis() As Data.DataRow, drColsAnios() As Data.DataRow, drColsProductosDetalle() As Data.DataRow, drColsProducto() As Data.DataRow, drColsProductosGlobal() As Data.DataRow, drColsProductosAcumulado() As Data.DataRow, drColsProductosPorDia() As Data.DataRow, drColsFechas() As Data.DataRow
                String sEsquemaClaveAnterior = "";
                String sNombreEsquemaAnterior = "";
                String sNombreCediAnterior = "";
                Decimal iTotal = 0;


                string filename = nombreReport + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + ".xlsx";
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument x1 = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = x1.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();
                SheetData sd = new SheetData();

                Dictionary<int, Row> Rows = new Dictionary<int, Row>();

                createRow(1, ref Rows);

                createCell(1, ref Rows, "A1", CellValues.String, nombreEmpresa);

                createRow(2, ref Rows);
                createCell(2, ref Rows, "A2", CellValues.String, "Reporte: " + nombreReport);

                createRow(4, ref Rows);
                createCell(4, ref Rows, "A4", CellValues.String, "Agencia: " + nombreCedis);

                createRow(5, ref Rows);
                createCell(5, ref Rows, "A5", CellValues.String, "Periodo: " + sFecha.ToString("dd/MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"));

                if (unidadMedida != "Cartones")
                {
                    unidadMedida = "Hectolitraje";
                }
                createRow(6, ref Rows);
                createCell(6, ref Rows, "A6", CellValues.String, "Unidad: " + unidadMedida);

                int currentRow = 8;

                //Encabezados
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A"+ currentRow, CellValues.String, "Agencia");

                foreach (ProductosModel producto in Productos)
                {
                    if (sEsquemaClaveAnterior != "" && sEsquemaClaveAnterior != producto.ClaveEsquema)
                    {
                        createCell(currentRow, ref Rows, null, CellValues.String, "Total " + sNombreEsquemaAnterior);
                        createCell(currentRow, ref Rows, null, CellValues.String, "Agencia");
                    }
                    createCell(currentRow, ref Rows, null, CellValues.String, producto.Nombre);
                    sEsquemaClaveAnterior = producto.ClaveEsquema;
                    sNombreEsquemaAnterior = producto.NombreEsquema;
                }
                createCell(currentRow, ref Rows, null, CellValues.String, "TOTAL " + sNombreEsquemaAnterior);
                currentRow++;

                //Detalle
                sEsquemaClaveAnterior = "";
                foreach (CedisModel cCedi in cCedis)
                {
                    if(sNombreCediAnterior != cCedi.ALMNombre)
                    {
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "A"+ currentRow, CellValues.String, cCedi.ALMNombre);

                        foreach (ProductosModel producto in Productos)
                        {
                            if(sEsquemaClaveAnterior != "" && sEsquemaClaveAnterior!= producto.ClaveEsquema)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.String, "");
                                createCell(currentRow, ref Rows, null, CellValues.String, cCedi.ALMNombre);
                                createCell(currentRow, ref Rows, null, CellValues.String, "");
                            }
                            else
                            {
                                createCell(currentRow, ref Rows, null, CellValues.String, "");
                            }
                            sEsquemaClaveAnterior = producto.ClaveEsquema;
                            sNombreEsquemaAnterior = producto.NombreEsquema;
                        }
                        currentRow++;
                        sEsquemaClaveAnterior = "";
                        sNombreEsquemaAnterior = "";
                    }

                    foreach (AniosModel anio in Anios)
                    {
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "A"+currentRow, CellValues.String, "   Venta "+anio.Anio);
                        foreach (ProductosModel producto in Productos)
                        {
                            if (sEsquemaClaveAnterior != "" && sEsquemaClaveAnterior != producto.ClaveEsquema)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, iTotal.ToString());
                                createCell(currentRow, ref Rows, null, CellValues.String, "   Venta " + anio.Anio);
                                iTotal = 0;
                            }

                            List<DetalleProductosModel> drColsProductosDetalle = (from productoDet in DetalleProductos where productoDet.ProductoClave == producto.ProductoClave && productoDet.Anio == anio.Anio && productoDet.ALMClave == cCedi.ALMClave select productoDet).ToList();
                            if(drColsProductosDetalle.Count > 0)
                            {
                                foreach (DetalleProductosModel productoDetalle in drColsProductosDetalle)
                                {
                                    createCell(currentRow, ref Rows, null, CellValues.Number, productoDetalle.CartonesHectolitraje.ToString());
                                    iTotal += productoDetalle.CartonesHectolitraje;
                                }
                            }
                            else
                            {
                                createCell(currentRow, ref Rows, null, CellValues.String, "");
                            }
                            sEsquemaClaveAnterior = producto.ClaveEsquema;
                        }
                        createCell(currentRow, ref Rows, null, CellValues.Number, iTotal.ToString());
                        currentRow++;

                        sEsquemaClaveAnterior = "";
                        iTotal = 0;
                    }
                }

                //Total Franquicia
                //esta parte del reporte no se realizara porque solo se ejecutaria este bloque solo si no se seleccionara ningun cedi, lo cual en nuestro reporteador no es posible
                //Fin total Franquicia

                //Acumulado
                currentRow++;

                foreach (AniosModel anio in Anios)
                {
                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Acumulado " + NombreMesFinal + " " + anio.Anio);
                    foreach (ProductosModel producto in Productos)
                    {
                        if (sEsquemaClaveAnterior != "" && sEsquemaClaveAnterior != producto.ClaveEsquema)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, iTotal.ToString());
                            createCell(currentRow, ref Rows, null, CellValues.String, "Acumulado " + NombreMesFinal + " " + anio.Anio);
                            iTotal = 0;
                        }

                        List<ProductosAcumuladoModel> drColsProductosAcumulado = (from productoAc in ProductosAcumulado where productoAc.ProductoClave == producto.ProductoClave && productoAc.Anio == anio.Anio select productoAc).ToList();
                        if (drColsProductosAcumulado.Count() > 0)
                        {
                            foreach (ProductosAcumuladoModel productoAcumulado in drColsProductosAcumulado)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, productoAcumulado.CartonesHectolitraje.ToString());
                                iTotal += productoAcumulado.CartonesHectolitraje;
                            }
                        }
                        else
                        {
                            createCell(currentRow, ref Rows, null, CellValues.String, "");
                        }
                        sEsquemaClaveAnterior = producto.ClaveEsquema;
                    }

                    createCell(currentRow, ref Rows, null, CellValues.Number, iTotal.ToString());
                    currentRow++;

                    sEsquemaClaveAnterior = "";
                    iTotal = 0;
                }


                //Ventas por Dia
                currentRow += 2;
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Venta por Día");
                currentRow++;


                //Encabezados
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Día");

                foreach (ProductosModel producto in Productos)
                {
                    if (sEsquemaClaveAnterior != "" && sEsquemaClaveAnterior != producto.ClaveEsquema)
                    {
                        createCell(currentRow, ref Rows, null, CellValues.String, "Total " + sNombreEsquemaAnterior);
                        createCell(currentRow, ref Rows, null, CellValues.String, "Día");
                    }
                    createCell(currentRow, ref Rows, null, CellValues.String, producto.Nombre);
                    sEsquemaClaveAnterior = producto.ClaveEsquema;
                    sNombreEsquemaAnterior = producto.NombreEsquema;
                }
                createCell(currentRow, ref Rows, null, CellValues.String, "TOTAL " + sNombreEsquemaAnterior);
                currentRow++;


                //Detalle
                sEsquemaClaveAnterior = "";
                foreach (FechasModel fecha in Fechas)
                {
                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "   " + fecha.DiaClave);
                    foreach (ProductosModel producto in Productos)
                    {
                        if(sEsquemaClaveAnterior != "" && sEsquemaClaveAnterior != producto.ClaveEsquema)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, iTotal.ToString());
                            createCell(currentRow, ref Rows, null, CellValues.String, "   " + fecha.DiaClave);
                            iTotal = 0;
                        }
                        List<ProductosPorDiaModel> drColsProductosPorDia = (from productoPD in ProductosPorDia where productoPD.ProductoClave == producto.ProductoClave && productoPD.DiaClave == fecha.DiaClave select productoPD).ToList();
                        if(drColsProductosPorDia.Count() > 0)
                        {
                            foreach (ProductosPorDiaModel productoPorDia in drColsProductosPorDia)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, productoPorDia.CartonesHectolitraje.ToString());
                                iTotal += productoPorDia.CartonesHectolitraje;
                            }
                        }
                        else
                        {
                            createCell(currentRow, ref Rows, null, CellValues.String, "");
                        }
                        sEsquemaClaveAnterior = producto.ClaveEsquema;
                    }
                    createCell(currentRow, ref Rows, null, CellValues.Number, iTotal.ToString());
                    currentRow++;

                }


                foreach (var row in Rows)
                {
                    sd.Append(row.Value);
                }

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = nombreReport.Substring(0,31);//el nombre de la hoja no puede de mas de 31 caracteres
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);

                x1.WorkbookPart.Workbook = wb;
                x1.WorkbookPart.Workbook.Save();
                x1.Close();

                ArchivoXlsModel archivo = new ArchivoXlsModel();
                archivo.archivo = ms.ToArray();
                archivo.nombre = filename;
                return archivo;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        bool ordenProductos(int VAVClave)
        {
            string query = "Select * from OrdenProductos (NOLOCK) where ReporteW = '" + VAVClave + "'";
            List<DataTable> resultado = Connection.Query<DataTable>(query, null, null, true, 9000).ToList();
            if (resultado.Count > 0)
            {
                return true;
            }
            return false;
        }

        void createRow(int id, ref Dictionary<int, Row> Rows)
        {
            Rows.Add(id, new Row() { RowIndex = (UInt32)id });
        }

        void createCell(int idRow, ref Dictionary<int, Row> Rows, string cellReference, DocumentFormat.OpenXml.Spreadsheet.CellValues dt, string cellValue)
        {
            Cell cell = new Cell();
            cell.CellReference = cellReference;
            cell.DataType = dt;
            cell.CellValue = new CellValue(cellValue);
            if (Rows.ContainsKey(idRow))
            {
                Rows[idRow].Append(cell);
            }
        }
    }

    class DetalleProductosModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public int Anio { get; set; }
        public int Orden { get; set; }
        public string ClaveEsquema { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public Decimal Contenido { get; set; }
        public Decimal Venta { get; set; }
        public Decimal CartonesHectolitraje { get; set; }
    }

    class ProductosModel
    {
        public int Orden { get; set; }
        public string ClaveEsquema { get; set; }
        public string NombreEsquema { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
    }

    class AniosModel
    {
        public int Anio { get; set; }
    }

    class CedisModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
    }

    class ProductosGlobalModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public int Anio { get; set; }
        public int Orden { get; set; }
        public string ClaveEsquema { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public Decimal Contenido { get; set; }
        public Decimal Venta { get; set; }
        public Decimal CartonesHectolitraje { get; set; }
    }

    class ProductosAcumuladoModel
    {
        public int Anio { get; set; }
        public int Orden { get; set; }
        public string ClaveEsquema { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public Decimal Contenido { get; set; }
        public Decimal Venta { get; set; }
        public Decimal CartonesHectolitraje { get; set; }
    }

    class ProductosPorDiaModel
    {
        public string DiaClave { get; set; }
        public DateTime Fecha { get; set; }
        public int Orden { get; set; }
        public string ClaveEsquema { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public Decimal Contenido { get; set; }
        public Decimal Venta { get; set; }
        public Decimal CartonesHectolitraje { get; set; }
    }

    class FechasModel
    {
        public string DiaClave { get; set; }
        public DateTime Fecha { get; set; }
    }
}