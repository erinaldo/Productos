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
using DevExpress.XtraReports.Parameters;

namespace eRoute.Models.ReportesModels
{
    public class LiquidacionMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string sVendedorID, string sVendedorSplit, string FechaInicial, string Cedis)
        {
            try
            {

                DateTime dFechaIni = DateTime.Parse(FechaInicial);
                StringBuilder sConsulta = new StringBuilder();

                //Ventas por Producto
                sConsulta.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR");
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("declare @VendedorId varchar(16)");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("if (select object_id('tempdb..#TmpUltimoInventarioABordo')) is not null ");
                sConsulta.AppendLine("	drop table #TmpUltimoInventarioABordo");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("create table #TmpUltimoInventarioABordo (VendedorID varchar(16), DiaClave varchar(10), FechaCaptura datetime, FechaHoraAlta datetime, TransprodID varchar(16))");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("declare UltimoInventarioABordo cursor local for ");
                sConsulta.AppendLine("	select Datos from dbo.FNSplit" + sVendedorSplit);
                sConsulta.AppendLine("open UltimoInventarioABordo");
                sConsulta.AppendLine("fetch next from UltimoInventarioABordo into @VendedorId");
                sConsulta.AppendLine("while @@FETCH_STATUS = 0 ");
                sConsulta.AppendLine("begin");
                sConsulta.AppendLine("	insert into #TmpUltimoInventarioABordo");
                sConsulta.AppendLine("	select top 1 VD.VendedorID,T.DiaClave,T.FechaCaptura,FechaHoraAlta,TransProdID");
                sConsulta.AppendLine("	from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("	inner join Vendedor VD (NOLOCK) on T.MUsuarioID=VD.USUId");
                sConsulta.AppendLine("	where T.Tipo in (23) and T.TipoFase<>0 ");
                sConsulta.AppendLine("	and T.FechaCaptura<'" + dFechaIni.Date.ToString("s") + "'");
                sConsulta.AppendLine("	and VD.VendedorID=@VendedorId");
                sConsulta.AppendLine("	group by VD.VendedorID,T.DiaClave,T.FechaCaptura,FechaHoraAlta,TransProdID");
                sConsulta.AppendLine("	order by T.FechaHoraAlta desc");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("	fetch next from UltimoInventarioABordo into @VendedorId");
                sConsulta.AppendLine("End");
                sConsulta.AppendLine("close UltimoInventarioABordo ");
                sConsulta.AppendLine("deallocate UltimoInventarioABordo");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("Select VendedorId, VENNombre, ProductoClave, PRONombre, SUM(InventarioInicial) as InventarioInicial,");
                sConsulta.AppendLine("SUM(Recargas) as Recargas, SUM(Devoluciones) as Devoluciones, SUM(Promocion) as Promocion, SUM(Descargas) as Descargas,");
                sConsulta.AppendLine("SUM(Ventas) as Ventas, SUM(Importe) as Importe");
                sConsulta.AppendLine("from( ");
                sConsulta.AppendLine("--Movimientos Fuera de Visita");
                sConsulta.AppendLine("SELECT VEN.VendedorId, VEN.Nombre as VENNombre,");
                sConsulta.AppendLine("TRP.Tipo, TPD.ProductoClave, PRO.Nombre as PRONombre,");
                sConsulta.AppendLine("InventarioInicial=0,");
                sConsulta.AppendLine("Recargas=(SELECT CASE WHEN TRP.Tipo=2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END),");
                sConsulta.AppendLine("Devoluciones=0,");
                sConsulta.AppendLine("Promocion=0,");
                sConsulta.AppendLine("Descargas=(SELECT CASE WHEN TRP.Tipo=7 THEN TPD.Cantidad * PDD.Factor ELSE 0 END),");
                sConsulta.AppendLine("Ventas=0,");
                sConsulta.AppendLine("Importe=0");
                sConsulta.AppendLine("FROM TransProd as TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle as TPD (NOLOCK) ON TPD.TransProdId=TRP.TransProdId ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) on (TRP.DiaClave=Dia.DiaClave and TRP.DiaClave1 is null) or TRP.DiaClave1=Dia.DiaClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd as TRP1 (NOLOCK) on TRP.FacturaId=TRP1.TransProdId ");
                sConsulta.AppendLine("INNER JOIN Producto as PRO (NOLOCK) ON PRO.ProductoClave=TPD.ProductoClave	");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD (NOLOCK) ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Usuario as USU (NOLOCK) ON USU.USUId=TRP.MUsuarioId ");
                sConsulta.AppendLine("INNER JOIN Vendedor as VEN (NOLOCK) ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ");
                sConsulta.AppendLine("WHERE TRP.Tipo IN (2,7) AND TRP.TipoFase<>0 And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--Movimientos dentro de Visita");
                sConsulta.AppendLine("SELECT VEN.VendedorId, VEN.Nombre as VENNombre,");
                sConsulta.AppendLine("TRP.Tipo, TPD.ProductoClave, PRO.Nombre as PRONombre, ");
                sConsulta.AppendLine("InventarioInicial=0,");
                sConsulta.AppendLine("Recargas=0,");
                sConsulta.AppendLine("Devoluciones=(SELECT CASE WHEN TRP.Tipo=3 THEN TPD.Cantidad * PDD.Factor ELSE 0 END),");
                sConsulta.AppendLine("Promocion=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Promocion=2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END), ");
                sConsulta.AppendLine("Descargas=0,");
                sConsulta.AppendLine("Ventas=(SELECT CASE WHEN TRP.Tipo=1 AND TPD.Promocion<>2 THEN TPD.Cantidad * PDD.Factor ELSE 0 END),");
                sConsulta.AppendLine("Importe=(SELECT CASE WHEN TRP.Tipo=1 THEN TPD.Total ELSE 0 END)");
                sConsulta.AppendLine("FROM TransProd as TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle as TPD (NOLOCK) ON TPD.TransProdId=TRP.TransProdId ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) on isnull(TRP.DiaClave1,TRP.DiaClave)=Dia.DiaClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd as TRP1 (NOLOCK) on TRP.FacturaId=TRP1.TransProdId ");
                sConsulta.AppendLine("INNER JOIN Producto as PRO (NOLOCK) ON PRO.ProductoClave=TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD (NOLOCK) ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave  and isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor as VEN (NOLOCK) ON VIS.VendedorID=VEN.VendedorID  AND VEN.TipoEstado=1 AND VEN.Baja=0 ");
                sConsulta.AppendLine("WHERE ((TRP.Tipo IN (1) AND TRP.TipoFase<>0) or (TRP.Tipo IN (3) AND TRP.TipoFase<>0)) And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("--Movimiento de Conservar Inventario");
                sConsulta.AppendLine("SELECT VEN.VendedorId, VEN.Nombre as VENNombre,");
                sConsulta.AppendLine("Tipo='23',");
                sConsulta.AppendLine("TPD.ProductoClave, PRO.Nombre as PRONombre,");
                sConsulta.AppendLine("InventarioInicial=isnull((TPD.Cantidad * PDD.Factor),0),");
                sConsulta.AppendLine("Recargas=0,");
                sConsulta.AppendLine("Devoluciones=0,");
                sConsulta.AppendLine("Promocion=0,");
                sConsulta.AppendLine("Descargas=0,");
                sConsulta.AppendLine("Ventas=0,");
                sConsulta.AppendLine("Importe=0");
                sConsulta.AppendLine("FROM #TmpUltimoInventarioABordo TRP");
                sConsulta.AppendLine("INNER JOIN TransProdDetalle as TPD (NOLOCK) ON TPD.TransProdId=TRP.TransProdId collate SQL_Latin1_General_CP1_CI_AS");
                sConsulta.AppendLine("INNER JOIN Producto as PRO (NOLOCK) ON PRO.ProductoClave=TPD.ProductoClave");
                sConsulta.AppendLine("INNER JOIN ProductoDetalle as PDD (NOLOCK) ON PDD.ProductoClave=TPD.ProductoClave AND PDD.PRUTipoUnidad=TPD.TipoUnidad AND PDD.ProductoDetClave=TPD.ProductoClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor as VEN (NOLOCK) ON TRP.VendedorID collate SQL_Latin1_General_CP1_CI_AS=VEN.VendedorID  AND VEN.TipoEstado=1 AND VEN.Baja=0");
                sConsulta.AppendLine(") as Productos ");
                sConsulta.AppendLine("group by VendedorID, VENNombre, ProductoClave, PRONombre ");
                sConsulta.AppendLine("order by VendedorID ");     //sConsulta.AppendLine("order by ProductoClave ");

                QueryString = sConsulta.ToString();

                List<LMVentasPorProductoModel> VentasPorProducto = Connection.Query<LMVentasPorProductoModel>(QueryString, null, null, true, 600).ToList();

                if (VentasPorProducto.Count() <= 0)
                {
                    return null;
                }


                //Resumen Vendedores
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("--OBTIENE ULTIMO INVENTARIO A BORDO DEL VENDEDOR");
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("declare @VendedorId varchar(16)");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("if (select object_id('tempdb..#TmpUltimoInventarioABordo')) is not null ");
                sConsulta.AppendLine("	drop table #TmpUltimoInventarioABordo");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("create table #TmpUltimoInventarioABordo (VendedorID varchar(16), DiaClave varchar(10), FechaCaptura datetime, FechaHoraAlta datetime, TransprodID varchar(16))");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("declare UltimoInventarioABordo cursor local for ");
                sConsulta.AppendLine("	select Datos from dbo.FNSplit" + sVendedorSplit);
                sConsulta.AppendLine("open UltimoInventarioABordo");
                sConsulta.AppendLine("fetch next from UltimoInventarioABordo into @VendedorId");
                sConsulta.AppendLine("while @@FETCH_STATUS = 0 ");
                sConsulta.AppendLine("begin");
                sConsulta.AppendLine("	insert into #TmpUltimoInventarioABordo");
                sConsulta.AppendLine("	select top 1 VD.VendedorID,T.DiaClave,T.FechaCaptura,FechaHoraAlta,TransProdID");
                sConsulta.AppendLine("	from TransProd T (NOLOCK) ");
                sConsulta.AppendLine("	inner join Vendedor VD (NOLOCK) on T.MUsuarioID=VD.USUId");
                sConsulta.AppendLine("	where T.Tipo in (23) and T.TipoFase<>0 ");
                sConsulta.AppendLine("	and T.FechaCaptura<'" + dFechaIni.Date.ToString("s") + "'");
                sConsulta.AppendLine("	and VD.VendedorID=@VendedorId");
                sConsulta.AppendLine("	group by VD.VendedorID,T.DiaClave,T.FechaCaptura,FechaHoraAlta,TransProdID");
                sConsulta.AppendLine("	order by T.FechaHoraAlta desc");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("	fetch next from UltimoInventarioABordo into @VendedorId");
                sConsulta.AppendLine("End");
                sConsulta.AppendLine("close UltimoInventarioABordo ");
                sConsulta.AppendLine("deallocate UltimoInventarioABordo");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("Select VendedorId, VENNombre");
                sConsulta.AppendLine("from( ");
                sConsulta.AppendLine("--Movimientos Fuera de Visita");
                sConsulta.AppendLine("SELECT VEN.VendedorId, VEN.Nombre as VENNombre");
                sConsulta.AppendLine("FROM TransProd as TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) on (TRP.DiaClave=Dia.DiaClave and TRP.DiaClave1 is null) or TRP.DiaClave1=Dia.DiaClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd as TRP1 (NOLOCK) on TRP.FacturaId=TRP1.TransProdId ");
                sConsulta.AppendLine("INNER JOIN Usuario as USU (NOLOCK) ON USU.USUId=TRP.MUsuarioId ");
                sConsulta.AppendLine("INNER JOIN Vendedor as VEN (NOLOCK) ON VEN.USUId=TRP.MUsuarioId AND VEN.TipoEstado=1 AND VEN.Baja=0 ");
                sConsulta.AppendLine("WHERE TRP.Tipo IN (2,7) AND TRP.TipoFase<>0 And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--Movimientos dentro de Visita");
                sConsulta.AppendLine("SELECT VEN.VendedorId, VEN.Nombre as VENNombre");
                sConsulta.AppendLine("FROM TransProd as TRP (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) on isnull(TRP.DiaClave1,TRP.DiaClave)=Dia.DiaClave ");
                sConsulta.AppendLine("LEFT JOIN TransProd as TRP1 (NOLOCK) on TRP.FacturaId=TRP1.TransProdId ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave  and isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor as VEN (NOLOCK) ON VIS.VendedorID=VEN.VendedorID  AND VEN.TipoEstado=1 AND VEN.Baja=0 ");
                sConsulta.AppendLine("WHERE ((TRP.Tipo IN (1) AND TRP.TipoFase<>0) or (TRP.Tipo IN (3) AND TRP.TipoFase<>0)) And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("--Movimiento de Conservar Inventario");
                sConsulta.AppendLine("SELECT VEN.VendedorId, VEN.Nombre as VENNombre");
                sConsulta.AppendLine("FROM #TmpUltimoInventarioABordo TRP");
                sConsulta.AppendLine("INNER JOIN Vendedor as VEN (NOLOCK) ON TRP.VendedorID collate SQL_Latin1_General_CP1_CI_AS=VEN.VendedorID  AND VEN.TipoEstado=1 AND VEN.Baja=0");
                sConsulta.AppendLine(") as Productos ");
                sConsulta.AppendLine("group by VendedorID, VENNombre ");
                sConsulta.AppendLine("order by VendedorID, VENNombre ");

                QueryString = sConsulta.ToString();

                List<LMResumenVendedoresModel> ResumenVendedores = Connection.Query<LMResumenVendedoresModel>(QueryString, null, null, true, 600).ToList();


                //Datos CEDI
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("select top 1 a.Clave, a.Nombre, a.Domicilio, a.Telefono");
                sConsulta.AppendLine("from VENCentroDistHist vcdh (NOLOCK) ");
                sConsulta.AppendLine("inner join Almacen a (NOLOCK) on vcdh.AlmacenId=a.AlmacenID");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on vcdh.VendedorId=VEN.VendedorID");
                sConsulta.AppendLine("where vcdh.FechaFinal='9999-12-31T00:00:00.000' and vcdh.AlmacenId='" + Cedis + "'");
                sConsulta.AppendLine(sVendedorID);

                QueryString = sConsulta.ToString();

                List<LMDatosCEDIModel> DatosCEDI = Connection.Query<LMDatosCEDIModel>(QueryString, null, null, true, 600).ToList();


                //Sección Ventas Contado
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("Select TRP.Folio as Remision, ");
                sConsulta.AppendLine("	isnull(TRPF.Folio,'') as Factura,");
                sConsulta.AppendLine("	TRP.FechaHoraAlta, ");
                sConsulta.AppendLine("	case when TRP.TipoFase=0 then 'CANCELADO' else CLI.Clave + ' - ' + CLI.RazonSocial end as Cliente, ");
                sConsulta.AppendLine("	(select sum(td.Cantidad * pu.KgLts) ");
                sConsulta.AppendLine("	from TransProdDetalle td (NOLOCK) ");
                sConsulta.AppendLine("	inner join ProductoUnidad pu (NOLOCK) on td.ProductoClave=pu.ProductoClave and td.TipoUnidad=pu.PRUTipoUnidad");
                sConsulta.AppendLine("	where td.TransProdID=TRP.TransProdID) as Litros,");
                sConsulta.AppendLine("	case when TRP.TipoFase=0 then '0.00' else TRP.Total end as Total,");
                sConsulta.AppendLine("  VEN.VendedorId");
                sConsulta.AppendLine("from Transprod TRP (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd TRPF (NOLOCK) on TRP.FacturaID=TRPF.TransProdID");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("where TRP.Tipo = 1  and TRP.TipoFase in(0,2,3) and TRP.CFVTipo = 1 ");
                sConsulta.AppendLine("	and Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("order by TRP.Folio");

                QueryString = sConsulta.ToString();

                List<LMVentasModel> VentasContado = Connection.Query<LMVentasModel>(QueryString, null, null, true, 600).ToList();



                //Sección Ventas Credito
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("Select TRP.Folio as Remision, ");
                sConsulta.AppendLine("	isnull(TRPF.Folio,'') as Factura,");
                sConsulta.AppendLine("	TRP.FechaHoraAlta, ");
                sConsulta.AppendLine("	case when TRP.TipoFase=0 then 'CANCELADO' else CLI.Clave + ' - ' + CLI.RazonSocial end as Cliente, ");
                sConsulta.AppendLine("	(select sum(td.Cantidad * pu.KgLts) ");
                sConsulta.AppendLine("	from TransProdDetalle td (NOLOCK) ");
                sConsulta.AppendLine("	inner join ProductoUnidad pu (NOLOCK) on td.ProductoClave=pu.ProductoClave and td.TipoUnidad=pu.PRUTipoUnidad");
                sConsulta.AppendLine("	where td.TransProdID=TRP.TransProdID) as Litros,");
                sConsulta.AppendLine("	case when TRP.TipoFase=0 then '0.00' else TRP.Total end as Total,");
                sConsulta.AppendLine("  VEN.VendedorId");
                sConsulta.AppendLine("from Transprod TRP (NOLOCK) ");
                sConsulta.AppendLine("left join TransProd TRPF (NOLOCK) on TRP.FacturaID=TRPF.TransProdID");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("where TRP.Tipo = 1  and TRP.TipoFase in(0,2,3) and TRP.CFVTipo = 2 ");
                sConsulta.AppendLine("	And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("order by TRP.Folio");

                QueryString = sConsulta.ToString();

                List<LMVentasModel> VentasCredito = Connection.Query<LMVentasModel>(QueryString, null, null, true, 600).ToList();

                //Sección Cobranza Contado
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("select * from ( ");
                sConsulta.AppendLine("Select ABN.Folio as FolioPago, TRP.Folio as FolioDocumento, TRP.FechaHoraAlta as FechaDocumento,  CLI.Clave + ' - ' + CLI.RazonSocial as Cliente, ABT.Importe, ABN.FechaCreacion as FechaPago, VEN.VendedorId");
                sConsulta.AppendLine("from AbnTrp ABT (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProd TRP (NOLOCK) on ABT.TransProdID = TRP.TransProdID  ");
                sConsulta.AppendLine("inner join Abono ABN (NOLOCK) on ABT.ABNId = ABN.ABNId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on VIS.VisitaClave = ABN.VisitaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("where ((TRP.Tipo=1 and TRP.TipoFase in (2,3)) or (TRP.Tipo=8 and TRP.TipoFase<>0)) and TRP.CFVTipo = 1 ");
                sConsulta.AppendLine("	And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("Select ABNH.Folio as FolioPago, TRP.Folio as FolioDocumento, TRP.FechaHoraAlta as FechaDocumento, 'CANCELADO' as Cliente, '0.00' as Total, ABNH.FechaHoraCreacion as FechaPago, VEN.VendedorId");
                sConsulta.AppendLine("from AbnTrpHist ABTH (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProd TRP (NOLOCK) on ABTH.TransProdID = TRP.TransProdID  ");
                sConsulta.AppendLine("inner join AbonoHist ABNH (NOLOCK) on ABTH.ABNId = ABNH.ABNId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on VIS.VisitaClave = ABNH.VisitaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("where ((TRP.Tipo=1 and TRP.TipoFase in (2,3)) or (TRP.Tipo=8 and TRP.TipoFase<>0)) and TRP.CFVTipo = 1 ");
                sConsulta.AppendLine("	And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine(") as t ");
                sConsulta.AppendLine("order by t.FolioPago ");

                QueryString = sConsulta.ToString();

                List<LMCobranzaModel> CobranzaContado = Connection.Query<LMCobranzaModel>(QueryString, null, null, true, 600).ToList();


                //Sección Cobranza Credito
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("select * from ( ");
                sConsulta.AppendLine("Select ABN.Folio as FolioPago, TRP.Folio as FolioDocumento, TRP.FechaHoraAlta as FechaDocumento,  CLI.Clave + ' - ' + CLI.RazonSocial as Cliente, ABT.Importe, ABN.FechaCreacion as FechaPago, VEN.VendedorId");
                sConsulta.AppendLine("from AbnTrp ABT (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProd TRP (NOLOCK) on ABT.TransProdID = TRP.TransProdID  ");
                sConsulta.AppendLine("inner join Abono ABN (NOLOCK) on ABT.ABNId = ABN.ABNId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on VIS.VisitaClave = ABN.VisitaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("where ((TRP.Tipo=1 and TRP.TipoFase in (2,3)) or (TRP.Tipo=8 and TRP.TipoFase<>0)) and TRP.CFVTipo = 2 ");
                sConsulta.AppendLine("	And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("Select ABNH.Folio as FolioPago, TRP.Folio as FolioDocumento, TRP.FechaHoraAlta as FechaDocumento, 'CANCELADO' as Cliente, '0.00' as Total, ABNH.FechaHoraCreacion as FechaPago, VEN.VendedorId");
                sConsulta.AppendLine("from AbnTrpHist ABTH (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProd TRP (NOLOCK) on ABTH.TransProdID = TRP.TransProdID  ");
                sConsulta.AppendLine("inner join AbonoHist ABNH (NOLOCK) on ABTH.ABNId = ABNH.ABNId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on VIS.VisitaClave = ABNH.VisitaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("where ((TRP.Tipo=1 and TRP.TipoFase in (2,3)) or (TRP.Tipo=8 and TRP.TipoFase<>0)) and TRP.CFVTipo = 2 ");
                sConsulta.AppendLine("	And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine(") as t ");
                sConsulta.AppendLine("order by t.FolioPago ");

                QueryString = sConsulta.ToString();

                List<LMCobranzaModel> CobranzaCredito = Connection.Query<LMCobranzaModel>(QueryString, null, null, true, 600).ToList();

                //DesgloseEfectivo
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SELECT Denominacion as TipoEfectivo, sum(Cantidad) as Cantidad, (cast(Denominacion as float) * sum(Cantidad)) as Total, VendedorId  ");
                sConsulta.AppendLine("FROM ");
                sConsulta.AppendLine("( SELECT (SELECT Descripcion FROM VAVDescripcion VAD (NOLOCK) WHERE VAD.VAVClave = PLE.TipoEfectivo AND VAD.VARCodigo = 'DENOMINA' AND VAD.VADTipoLenguaje = 'EM') as Denominacion, PLE.Cantidad, VEN.VendedorId ");
                sConsulta.AppendLine("FROM Preliquidacion PLI (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN PLIEfectivo PLE (NOLOCK) ON PLE.PLIId=PLI.PLIId ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on PLI.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("WHERE convert(datetime,Convert(varchar(20),PLI.FechaPreliquidacion,112)) = '" + dFechaIni.Date.ToString("s") + "'  ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine(") as Resultado ");
                sConsulta.AppendLine("GROUP BY Denominacion, VendedorId ");
                sConsulta.AppendLine("ORDER BY VendedorId, TipoEfectivo ");

                QueryString = sConsulta.ToString();

                List<LMDesgloseEfectivoModel> DesgloseEfectivo = Connection.Query<LMDesgloseEfectivoModel>(QueryString, null, null, true, 600).ToList();

                //Sección Desglose de Documento
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("select * from ( ");
                sConsulta.AppendLine("Select (SELECT Descripcion FROM VAVDescripcion VAD (NOLOCK) WHERE VAD.VAVClave=ABD.TipoBanco AND VAD.VARCodigo='TBANCO' AND VAD.VADTipoLenguaje=(Select dbo.FNObtenerLenguaje())) as Banco,");
                sConsulta.AppendLine("	ABD.Referencia, ABD.FechaCheque as FechaCobro, ABT.Importe, VEN.VendedorId");
                sConsulta.AppendLine("from AbnTrp ABT (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProd TRP (NOLOCK) on ABT.TransProdID = TRP.TransProdID  ");
                sConsulta.AppendLine("inner join Abono ABN (NOLOCK) on ABT.ABNId = ABN.ABNId ");
                sConsulta.AppendLine("inner join AbnDetalle ABD (NOLOCK) on ABN.ABNId = ABD.ABNId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on VIS.VisitaClave = ABN.VisitaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("where ((TRP.Tipo = 1 and TRP.TipoFase in(2,3)) or (TRP.Tipo = 8 and TRP.TipoFase<>0)) and TRP.CFVTipo=2 and ABD.TipoPago<>1");
                sConsulta.AppendLine("And Dia.FechaCaptura='" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine(") as t ");

                QueryString = sConsulta.ToString();

                List<LMDesgloseDocumentosModel> DesgloseDocumentos = Connection.Query<LMDesgloseDocumentosModel>(QueryString, null, null, true, 600).ToList();


                //Kilometraje
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("select cv.KmInicial, cv.KmFinal, VEN.VendedorId ");
                sConsulta.AppendLine("from CamionVendedor cv (NOLOCK) ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on cv.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("where convert(datetime,Convert(varchar(20),cv.FechaHoraInicial,112)) = '" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);

                QueryString = sConsulta.ToString();

                List<LMKilometrajeModel> Kilometraje = Connection.Query<LMKilometrajeModel>(QueryString, null, null, true, 600).ToList();


                //Agendados
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("select T.VendedorID, ");
                sConsulta.AppendLine("sum(TotalClientes) as ClientesAgendados,");
                sConsulta.AppendLine("sum(ClientesVisitadosEnAgenda) as ClientesVisitados,");
                sConsulta.AppendLine("(sum(TotalClientes)-sum(ClientesVisitadosEnAgenda)) as ClientesNoVisitados,");
                sConsulta.AppendLine("sum(ClientesConVentaEnAgenda) as VisitadosConVenta,");
                sConsulta.AppendLine("(sum(ClientesVisitadosEnAgenda)-sum(ClientesConVentaEnAgenda)) as VisitadosSinVenta");
                sConsulta.AppendLine("from (");
                sConsulta.AppendLine("select VEN.VendedorID,");
                sConsulta.AppendLine("isnull(count(distinct AGV.ClienteClave),0) as TotalClientes,");
                sConsulta.AppendLine("0 as ClientesVisitadosEnAgenda,");
                sConsulta.AppendLine("0 as ClientesConVentaEnAgenda");
                sConsulta.AppendLine("from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("left join Visita VIS (NOLOCK) on AGV.ClienteClave = VIS.ClienteClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave and VIS.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on AGV.DiaClave = DIA.DIAClave  AND Dia.FechaCaptura = '" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on AGV.VendedorId = VEN.VendedorId " + sVendedorID);
                sConsulta.AppendLine("group by VEN.VendedorID");
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select ");
                sConsulta.AppendLine("VEN.VendedorID,");
                sConsulta.AppendLine("0 as TotalClientes,");
                sConsulta.AppendLine("isnull(count(distinct(case when VIS.VisitaClave is null then null else VIS.ClienteClave end)),0) as ClientesVisitadosEnAgenda,");
                sConsulta.AppendLine("isnull(count(distinct(case when TRP.VisitaClave is null then null else VIS.ClienteClave end)),0) as ClientesConVentaEnAgenda");
                sConsulta.AppendLine("from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on AGV.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("left join Visita VIS (NOLOCK) on AGV.ClienteClave = VIS.ClienteClave and AGV.VendedorId = VIS.VendedorId and AGV.RutClave = VIS.RutClave and VIS.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("left join TransProd TRP (NOLOCK) on VIS.VisitaClave=isnull(TRP.VisitaClave1,TRP.VisitaClave) and VIS.DiaClave=isnull(TRP.DiaClave1,TRP.DiaClave) and TRP.Tipo=1 and TRP.TipoFase in (2,3)");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on AGV.DiaClave = DIA.DIAClave  AND Dia.FechaCaptura = '" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on AGV.VendedorId = VEN.VendedorId " + sVendedorID);
                sConsulta.AppendLine("group by VEN.VendedorID");
                sConsulta.AppendLine(") as T");
                sConsulta.AppendLine("group by T.VendedorID");

                QueryString = sConsulta.ToString();

                List<LMAgendadosModel> Agendados = Connection.Query<LMAgendadosModel>(QueryString, null, null, true, 600).ToList();


                //NoAgendados
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("Select VendedorID, ");
                sConsulta.AppendLine("COUNT(distinct ClienteClave) as FueraFrecuencia , ");
                sConsulta.AppendLine("isnull(SUM(CASE WHEN Ventas>0 then 1 ELSE 0 END),0) as ConVenta ");
                sConsulta.AppendLine("from ( ");
                sConsulta.AppendLine("  select CLI.ClienteClave, sum(case when TRP.TransProdID is null THEN 0 ELSE 1 END) Ventas, VEN.VendedorID from Cliente CLI (NOLOCK) ");
                sConsulta.AppendLine("  inner join Visita VIS (NOLOCK) on CLI.ClienteClave = VIS.ClienteClave and VIS.FueraFrecuencia = 1 ");
                sConsulta.AppendLine("  left join TransProd TRP (NOLOCK) on ((TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave and TRP.VisitaClave1 is null) or ");
                sConsulta.AppendLine("  TRP.VisitaClave1 = VIS.VisitaClave and TRP.DiaClave1 = VIS.DiaClave ) and TRP.Tipo=2 ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("  where Dia.FechaCaptura = '" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("  group by CLI.ClienteClave, VEN.VendedorID ");
                sConsulta.AppendLine(") as tmp ");
                sConsulta.AppendLine("group by VendedorId ");

                QueryString = sConsulta.ToString();

                List<LMNoAgendadosModel> NoAgendados = Connection.Query<LMNoAgendadosModel>(QueryString, null, null, true, 600).ToList();


                //Tiempos
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("Select VEN.VendedorId, case when VEN.JornadaTrabajo = 1 then isnull(min(VEJ.VEJFechaInicial),min(VIS.FechaHoraInicial)) else min(VIS.FechaHoraInicial) end as HoraInicialJornada,  ");
                sConsulta.AppendLine("case when VEN.JornadaTrabajo = 1 then isnull(max(VEJ.FechaFinal),max(VIS.FechaHoraFinal)) else max(VIS.FechaHoraFinal) end as HoraFinalJornada, ");
                sConsulta.AppendLine("sum(datediff(second, VIS.FechaHoraInicial, VIS.FechaHoraFinal)) as TiempoVisita ");
                sConsulta.AppendLine("from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorID = VEN.VendedorID ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("left join VendedorJornada VEJ (NOLOCK) on VEJ.VendedorId = VIS.VendedorID and VEJ.DiaClave = VIS.DiaClave and VEJ.DiaClave is not null ");
                sConsulta.AppendLine("where Dia.FechaCaptura = '" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine(sVendedorID);
                sConsulta.AppendLine("group by VEN.VendedorId, VEN.JornadaTrabajo ");

                QueryString = sConsulta.ToString();

                List<LMTiemposModel> Tiempos = Connection.Query<LMTiemposModel>(QueryString, null, null, true, 600).ToList();

                string empresaQuery = "select NombreEmpresa from Configuracion (NOLOCK) ";
                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();


                //agregamos la lista de ventasporproducto al resumenVendedores
                //optimizar codigo con linq
                foreach (LMResumenVendedoresModel vendedor in ResumenVendedores)
                {
                    foreach (LMVentasPorProductoModel venta in VentasPorProducto)
                    {
                        if (venta.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.VentasPorProducto.Add(venta);
                        }
                    }

                    foreach (LMVentasModel ventaContado in VentasContado)
                    {
                        if (ventaContado.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.VentasContado.Add(ventaContado);
                        }
                    }

                    foreach (LMVentasModel ventaCredito in VentasCredito)
                    {
                        if (ventaCredito.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.VentasCredito.Add(ventaCredito);
                        }
                    }

                    foreach (LMCobranzaModel cobranzaContado in CobranzaContado)
                    {
                        if (cobranzaContado.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.CobranzaContado.Add(cobranzaContado);
                        }
                    }

                    foreach (LMCobranzaModel cobranzaCredito in CobranzaCredito)
                    {
                        if (cobranzaCredito.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.CobranzaCredito.Add(cobranzaCredito);
                        }
                    }

                    foreach (LMDesgloseEfectivoModel desgloseEfectivo in DesgloseEfectivo)
                    {
                        if (desgloseEfectivo.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.DesgloseEfectivoDocumentos.Add(new LMDesgloseEfectivoDocumentosModel() { TipoEfectivo = desgloseEfectivo.TipoEfectivo, Cantidad = desgloseEfectivo.Cantidad, Total = desgloseEfectivo.Total });
                        }
                    }

                    //Kilometraje
                    foreach (LMKilometrajeModel kilometraje in Kilometraje)
                    {
                        if (kilometraje.VendedorId == vendedor.VendedorId)
                        {
                            vendedor.Kilometraje.Add(kilometraje);
                        }
                    }

                    foreach (LMAgendadosModel agendados in Agendados)
                    {
                        if (agendados.VendedorID == vendedor.VendedorId)
                        {
                            vendedor.Agendados.Add(agendados);
                        }
                    }

                    foreach (LMNoAgendadosModel noAgendados in NoAgendados)
                    {
                        if (noAgendados.VendedorID == vendedor.VendedorId)
                        {
                            vendedor.NoAgendadosTiempos.Add(new LMNoAgendadosTiemposModel()
                            {
                                VendedorID = noAgendados.VendedorID,
                                FueraFrecuencia = noAgendados.FueraFrecuencia,
                                ConVenta = noAgendados.ConVenta
                            });
                        }
                    }

                    foreach (LMTiemposModel tiempos in Tiempos)
                    {
                        if (tiempos.VendedorId == vendedor.VendedorId)
                        {
                            if (vendedor.NoAgendadosTiempos.Count() == 0)
                            {
                                vendedor.NoAgendadosTiempos.Add(new LMNoAgendadosTiemposModel()
                                {
                                    HoraInicialJornada = tiempos.HoraInicialJornada,
                                    HoraFinalJornada = tiempos.HoraFinalJornada,
                                    TiempoVisita = tiempos.TiempoVisita
                                });
                            }
                            else
                            {
                                vendedor.NoAgendadosTiempos.Last().HoraInicialJornada = tiempos.HoraInicialJornada;
                                vendedor.NoAgendadosTiempos.Last().HoraFinalJornada = tiempos.HoraFinalJornada;
                                vendedor.NoAgendadosTiempos.Last().TiempoVisita = tiempos.TiempoVisita;
                            }
                        }
                    }
                }

                foreach (LMResumenVendedoresModel vendedor in ResumenVendedores)
                {
                    foreach (LMDesgloseDocumentosModel desgloseDocumentos in DesgloseDocumentos)
                    {
                        if (desgloseDocumentos.VendedorId == vendedor.VendedorId)
                        {
                            if (vendedor.DesgloseEfectivoDocumentos.Count > 0)
                            {
                                LMDesgloseEfectivoDocumentosModel registroVacio = vendedor.DesgloseEfectivoDocumentos.FirstOrDefault(de => de.Banco == null);
                                if (registroVacio == null)
                                {
                                    vendedor.DesgloseEfectivoDocumentos.Add(new LMDesgloseEfectivoDocumentosModel()
                                    {
                                        VendedorId = desgloseDocumentos.VendedorId,
                                        Banco = desgloseDocumentos.Banco,
                                        Referencia = desgloseDocumentos.Referencia,
                                        FechaCobro = desgloseDocumentos.FechaCobro,
                                        Importe = desgloseDocumentos.Importe
                                    });
                                }
                                else
                                {
                                    registroVacio.Banco = desgloseDocumentos.Banco;
                                    registroVacio.Referencia = desgloseDocumentos.Referencia;
                                    registroVacio.FechaCobro = desgloseDocumentos.FechaCobro;
                                    registroVacio.Importe = desgloseDocumentos.Importe;
                                }
                            }
                            else
                            {
                                vendedor.DesgloseEfectivoDocumentos.Add(new LMDesgloseEfectivoDocumentosModel()
                                {
                                    VendedorId = desgloseDocumentos.VendedorId,
                                    Banco = desgloseDocumentos.Banco,
                                    Referencia = desgloseDocumentos.Referencia,
                                    FechaCobro = desgloseDocumentos.FechaCobro,
                                    Importe = desgloseDocumentos.Importe
                                });
                            }
                        }
                    }
                }

                //totales
                foreach (LMResumenVendedoresModel vendedor in ResumenVendedores)
                {
                    //ventas por producto
                    if (vendedor.VentasPorProducto.Count() > 0)
                    {
                        foreach (LMVentasPorProductoModel reg in vendedor.VentasPorProducto)
                        {
                            reg.InventarioFinal = reg.InventarioInicial + reg.Recargas + reg.Devoluciones - (reg.Promocion + reg.Descargas + reg.Ventas);
                        }
                        vendedor.VentasPorProducto.LastOrDefault().TInventarioInicial = vendedor.VentasPorProducto.Sum(c => c.InventarioInicial);
                        vendedor.VentasPorProducto.LastOrDefault().TRecargas = vendedor.VentasPorProducto.Sum(c => c.Recargas);
                        vendedor.VentasPorProducto.LastOrDefault().TDevoluciones = vendedor.VentasPorProducto.Sum(c => c.Devoluciones);
                        vendedor.VentasPorProducto.LastOrDefault().TPromocion = vendedor.VentasPorProducto.Sum(c => c.Promocion);
                        vendedor.VentasPorProducto.LastOrDefault().TDescargas = vendedor.VentasPorProducto.Sum(c => c.Descargas);
                        vendedor.VentasPorProducto.LastOrDefault().TInventarioFinal = vendedor.VentasPorProducto.Sum(c => c.InventarioFinal);
                        vendedor.VentasPorProducto.LastOrDefault().TVentas = vendedor.VentasPorProducto.Sum(c => c.Ventas);
                        vendedor.VentasPorProducto.LastOrDefault().TImporte = vendedor.VentasPorProducto.Sum(c => c.Importe);
                    }

                    //ventas contado
                    if (vendedor.VentasContado.Count() > 0)
                        vendedor.VentasContado.LastOrDefault().GTotal = vendedor.VentasContado.Sum(c => c.Total);

                    //ventas credito
                    if (vendedor.VentasCredito.Count() > 0)
                        vendedor.VentasCredito.LastOrDefault().GTotal = vendedor.VentasCredito.Sum(c => c.Total);

                    //cobranza contado
                    if (vendedor.CobranzaContado.Count() > 0)
                        vendedor.CobranzaContado.LastOrDefault().TotalImporte = vendedor.CobranzaContado.Sum(c => c.Importe);

                    //cobranza credito
                    if (vendedor.CobranzaCredito.Count() > 0)
                        vendedor.CobranzaCredito.LastOrDefault().TotalImporte = vendedor.CobranzaCredito.Sum(c => c.Importe);

                    //TotalCobranza
                    vendedor.TotalCobranza.Add(new LMTotalCobranzaModel() { Total = (vendedor.CobranzaContado.LastOrDefault() == null ? 0 : vendedor.CobranzaContado.Last().TotalImporte) + (vendedor.CobranzaCredito.LastOrDefault() == null ? 0 : vendedor.CobranzaCredito.Last().TotalImporte) });

                    //Desglose Efectivo
                    vendedor.TotalDesglose.Add(new LMTotalesEfectivoDocumentosModel());
                    vendedor.TotalDesglose.LastOrDefault().TotalEfectivo = vendedor.DesgloseEfectivoDocumentos.Sum(c => c.Total);
                    vendedor.TotalDesglose.LastOrDefault().TotalDocumentos = vendedor.DesgloseEfectivoDocumentos.Sum(c => c.Importe);
                    vendedor.TotalDesglose.LastOrDefault().TotalCobranzaContado = vendedor.CobranzaContado.Sum(c => c.Importe);
                    vendedor.TotalDesglose.LastOrDefault().TotalCobranzaCredito = vendedor.CobranzaCredito.Sum(c => c.Importe);

                    vendedor.TotalDesglose.LastOrDefault().TotalCobranza = vendedor.TotalDesglose.LastOrDefault().TotalCobranzaContado + vendedor.TotalDesglose.LastOrDefault().TotalCobranzaCredito;

                    vendedor.TotalDesglose.LastOrDefault().TotalGeneralLiquidado = vendedor.TotalDesglose.LastOrDefault().TotalEfectivo + vendedor.TotalDesglose.LastOrDefault().TotalDocumentos;


                    //Kilometraje
                    if (vendedor.Kilometraje.Count() > 0)
                        vendedor.Kilometraje.LastOrDefault().KmRecorrido = vendedor.Kilometraje.Sum(c => c.KmFinal) - vendedor.Kilometraje.Sum(c => c.KmInicial);

                    //Agendados
                    if (vendedor.Agendados.Count() > 0)
                    {
                        //General
                        if (vendedor.Agendados.LastOrDefault().ClientesAgendados <= 0)
                        {
                            vendedor.Agendados.LastOrDefault().EficienciaGeneral = 0;
                        }
                        else
                        {
                            vendedor.Agendados.LastOrDefault().EficienciaGeneral = (vendedor.Agendados.LastOrDefault().ClientesVisitados / vendedor.Agendados.LastOrDefault().ClientesAgendados) * 100;
                        }
                        //Ruta
                        if (vendedor.Agendados.LastOrDefault().VisitadosConVenta + vendedor.Agendados.LastOrDefault().VisitadosSinVenta <= 0)
                        {
                            vendedor.Agendados.LastOrDefault().EficienciaRuta = 0;
                        }
                        else
                        {
                            vendedor.Agendados.LastOrDefault().EficienciaRuta = (vendedor.Agendados.LastOrDefault().VisitadosConVenta / (vendedor.Agendados.LastOrDefault().VisitadosConVenta + vendedor.Agendados.LastOrDefault().VisitadosSinVenta)) * 100;
                        }
                    }

                    //NoAgendadosTiempos
                    if (vendedor.NoAgendadosTiempos.Count()>0)
                    {
                        //Fuera de Ruta
                        if (vendedor.NoAgendadosTiempos.LastOrDefault().FueraFrecuencia <= 0)
                        {
                            vendedor.NoAgendadosTiempos.LastOrDefault().EficienciaRuta = 0;
                        }
                        else
                        {
                            vendedor.NoAgendadosTiempos.LastOrDefault().EficienciaRuta = (vendedor.NoAgendadosTiempos.LastOrDefault().ConVenta / vendedor.NoAgendadosTiempos.LastOrDefault().FueraFrecuencia) * 100;
                        }
                        //Tiempos de Visita
                        try
                        {
                            vendedor.NoAgendadosTiempos.LastOrDefault().TiempoTotal = vendedor.NoAgendadosTiempos.LastOrDefault().HoraFinalJornada - vendedor.NoAgendadosTiempos.LastOrDefault().HoraInicialJornada;
                            vendedor.NoAgendadosTiempos.LastOrDefault().TiemposVisita = TimeSpan.FromSeconds(vendedor.NoAgendadosTiempos.LastOrDefault().TiempoVisita);
                            vendedor.NoAgendadosTiempos.LastOrDefault().TiempoTransito = vendedor.NoAgendadosTiempos.LastOrDefault().TiempoTotal - vendedor.NoAgendadosTiempos.LastOrDefault().TiemposVisita;
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                }



                ReporteLiquidacionMOR2 report = new ReporteLiquidacionMOR2();
                report.DataSource = ResumenVendedores;

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;


                report.direccionCedis.Text = DatosCEDI.FirstOrDefault().Domicilio;
                report.telefonoCedis.Text = "Télefono: " + DatosCEDI.FirstOrDefault().Telefono;


                //grouHeaderVendedor
                GroupField groupVendedor = new GroupField("VendedorId");
                report.groupHeaderVendedor.GroupFields.Add(groupVendedor);




                //detalle ventas por producto
                report.VentasProducto.DataMember = "VentasPorProducto";

                report.detalleClave.DataBindings.Add("Text", null, "VentasPorProducto.ProductoClave");
                report.detalleDescripcion.DataBindings.Add("Text", null, "VentasPorProducto.PRONombre");
                report.detalleInventarioInicial.DataBindings.Add("Text", null, "VentasPorProducto.InventarioInicial");
                report.detalleRecargas.DataBindings.Add("Text", null, "VentasPorProducto.Recargas");
                report.detalleDevoluciones.DataBindings.Add("Text", null, "VentasPorProducto.Devoluciones");
                report.detallePromocion.DataBindings.Add("Text", null, "VentasPorProducto.Promocion");
                report.detalleDescargas.DataBindings.Add("Text", null, "VentasPorProducto.Descargas");
                report.detalleInventarioFinal.DataBindings.Add("Text", null, "VentasPorProducto.InventarioFinal");
                report.detalleVentas.DataBindings.Add("Text", null, "VentasPorProducto.Ventas");
                report.detalleImporte.DataBindings.Add("Text", null, "VentasPorProducto.Importe", "{0:$#,##0.00}");
                report.detalleInventarioFinal.DataBindings.Add("Text", null, "VentasPorProducto.InventarioFinal");

                report.totalInventarioInicial.DataBindings.Add("Text", null, "VentasPorProducto.TInventarioInicial");
                report.totalRecargas.DataBindings.Add("Text", null, "VentasPorProducto.TRecargas");
                report.totalDevoluciones.DataBindings.Add("Text", null, "VentasPorProducto.TDevoluciones");
                report.totalPromocion.DataBindings.Add("Text", null, "VentasPorProducto.TPromocion");
                report.totalDescargas.DataBindings.Add("Text", null, "VentasPorProducto.TDescargas");
                report.totalInventarioFinal.DataBindings.Add("Text", null, "VentasPorProducto.TInventarioFinal");
                report.totalVentas.DataBindings.Add("Text", null, "VentasPorProducto.TVentas");
                report.totalImporte.DataBindings.Add("Text", null, "VentasPorProducto.TImporte", "{0:$#,##0.00}");

                //detalle ventascontado
                report.VentasContado.DataMember = "VentasContado";

                report.VContadoDetalleVenta.DataBindings.Add("Text", null, "VentasContado.Remision");
                report.VContadoDetalleFactura.DataBindings.Add("Text", null, "VentasContado.Factura");
                report.VContadoDetalleFecha.DataBindings.Add("Text", null, "VentasContado.FechaHoraAlta");
                report.VContadoDetalleCliente.DataBindings.Add("Text", null, "VentasContado.Cliente");
                report.VContadoDetalleLitros.DataBindings.Add("Text", null, "VentasContado.Litros", "{0:#,##0.00}");
                report.VContadoDetalleImporte.DataBindings.Add("Text", null, "VentasContado.Total", "{0:$#,##0.00}");
                report.VContadoTotalImporte.DataBindings.Add("Text", null, "VentasContado.GTotal", "{0:$#,##0.00}");

                //detalle ventascredito
                report.VentasCredito.DataMember = "VentasCredito";

                report.VCreditoDetalleVenta.DataBindings.Add("Text", null, "VentasCredito.Remision");
                report.VCreditoDetalleFactura.DataBindings.Add("Text", null, "VentasCredito.Factura");
                report.VCreditoDetalleFecha.DataBindings.Add("Text", null, "VentasCredito.FechaHoraAlta");
                report.VCreditoDetalleCliente.DataBindings.Add("Text", null, "VentasCredito.Cliente");
                report.VCreditoDetalleLitros.DataBindings.Add("Text", null, "VentasCredito.Litros", "{0:#,##0.00}");
                report.VCreditoDetalleImporte.DataBindings.Add("Text", null, "VentasCredito.Total", "{0:$#,##0.00}");
                report.VCreditoTotalImporte.DataBindings.Add("Text", null, "VentasCredito.GTotal", "{0:$#,##0.00}");

                //detalle cobranzaContado
                report.CobranzaContado.DataMember = "CobranzaContado";

                report.CContadoDetalleFolio.DataBindings.Add("Text", null, "CobranzaContado.FolioPago");
                report.CContadoDetalleFactura.DataBindings.Add("Text", null, "CobranzaContado.FolioDocumento");
                report.CContadoDetalleFechaFactura.DataBindings.Add("Text", null, "CobranzaContado.FechaPago");
                report.CContadoDetalleCliente.DataBindings.Add("Text", null, "CobranzaContado.Cliente");
                report.CContadoDetalleImporte.DataBindings.Add("Text", null, "CobranzaContado.Importe", "{0:$#,##0.00}");
                report.CContadoDetalleFechaPago.DataBindings.Add("Text", null, "CobranzaContado.FechaPago");

                report.CContadoTotalImporte.DataBindings.Add("Text", null, "CobranzaContado.TotalImporte", "{0:$#,##0.00}");

                //detalle cobranzaCredito
                report.CobranzaCredito.DataMember = "CobranzaCredito";

                report.CCreditoDetalleFolio.DataBindings.Add("Text", null, "CobranzaCredito.FolioPago");
                report.CCreditoDetalleFactura.DataBindings.Add("Text", null, "CobranzaCredito.FolioDocumento");
                report.CCreditoDetalleFechaFactura.DataBindings.Add("Text", null, "CobranzaCredito.FechaPago");
                report.CCreditoDetalleCliente.DataBindings.Add("Text", null, "CobranzaCredito.Cliente");
                report.CCreditoDetalleImporte.DataBindings.Add("Text", null, "CobranzaCredito.Importe", "{0:$#,##0.00}");
                report.CCreditoDetalleFechaPago.DataBindings.Add("Text", null, "CobranzaCredito.FechaPago");

                report.CCreditoTotalImporte.DataBindings.Add("Text", null, "CobranzaCredito.TotalImporte", "{0:$#,##0.00}");

                //total Cobranza
                report.TotalCobranza.DataMember = "TotalCobranza";

                report.CCreditoTotalCobranza.DataBindings.Add("Text", null, "TotalCobranza.Total", "{0:$#,##0.00}");


                //detalle desgloseEfectivo DesgloseDocumentos
                report.DesgloseEfectivoDocumentos.DataMember = "DesgloseEfectivoDocumentos";

                report.DesgloseDetalleDenominacion.DataBindings.Add("Text", null, "DesgloseEfectivoDocumentos.TipoEfectivo");
                report.DesgloseDetalleCantidad.DataBindings.Add("Text", null, "DesgloseEfectivoDocumentos.Cantidad");
                report.DesgloseDetalleTotal.DataBindings.Add("Text", null, "DesgloseEfectivoDocumentos.Total", "{0:$#,##0.00}");

                report.DesgloseDetalleBanco.DataBindings.Add("Text", null, "DesgloseEfectivoDocumentos.Banco");
                report.DesgloseDetalleReferencia.DataBindings.Add("Text", null, "DesgloseEfectivoDocumentos.Referencia");
                report.DesgloseDetalleFechaCobro.DataBindings.Add("Text", null, "DesgloseEfectivoDocumentos.FechaCobro");
                report.DesgloseDetalleImporte.DataBindings.Add("Text", null, "DesgloseEfectivoDocumentos.Importe", "{0:$#,##0.00}");

                //total desglose
                report.TotalDesglose.DataMember = "TotalDesglose";

                report.DesgloseEfectivoTotal.DataBindings.Add("Text", null, "TotalDesglose.TotalEfectivo", "{0:$#,##0.00}");
                report.TotalImporteDocumentos.DataBindings.Add("Text", null, "TotalDesglose.TotalDocumentos", "{0:$#,##0.00}");

                report.TotalesTotalContado.DataBindings.Add("Text", null, "TotalDesglose.TotalCobranzaContado", "{0:$#,##0.00}");
                report.TotalesTotalCredito.DataBindings.Add("Text", null, "TotalDesglose.TotalCobranzaCredito", "{0:$#,##0.00}");
                report.TotalesTotalCobranza.DataBindings.Add("Text", null, "TotalDesglose.TotalCobranza", "{0:$#,##0.00}");

                report.TotalesTotalEfectivo.DataBindings.Add("Text", null, "TotalDesglose.TotalEfectivo", "{0:$#,##0.00}");
                report.TotalesTotalDocumentos.DataBindings.Add("Text", null, "TotalDesglose.TotalDocumentos", "{0:$#,##0.00}");
                report.TotalesTotalDesglose.DataBindings.Add("Text", null, "TotalDesglose.TotalCobranza", "{0:$#,##0.00}");






                //detalle kilometraje
                report.Kilometraje.DataMember = "Kilometraje";

                report.KDetalleInicial.DataBindings.Add("Text", null, "Kilometraje.KmInicial", "{0:#,##0.00}");
                report.KDetalleFinal.DataBindings.Add("Text", null, "Kilometraje.KmFinal", "{0:#,##0.00}");
                report.KDetalleRecorrido.DataBindings.Add("Text", null, "Kilometraje.KmRecorrido", "{0:#,##0.00}");

                //detalle agendados
                report.Agendados.DataMember = "Agendados";

                report.AgendaDetalleClientes.DataBindings.Add("Text", null, "Agendados.ClientesAgendados");
                report.AgendaDetalleVisitados.DataBindings.Add("Text", null, "Agendados.ClientesVisitados");
                report.AgendaDetalleNoVisitados.DataBindings.Add("Text", null, "Agendados.ClientesNoVisitados");
                report.AgendaDetalleEficiencia.DataBindings.Add("Text", null, "Agendados.EficienciaGeneral", "{0:#,##0.00}");

                report.AgendaDetalleConVenta.DataBindings.Add("Text", null, "Agendados.VisitadosConVenta");
                report.AgendaDetalleSinVenta.DataBindings.Add("Text", null, "Agendados.VisitadosSinVenta");
                report.AgendaRutaDetalleEficiencia.DataBindings.Add("Text", null, "Agendados.EficienciaRuta", "{0:#,##0.00}");

                //detalle noAgendados Tiempos
                report.NoAgendadosTiempos.DataMember = "NoAgendadosTiempos";

                report.NoAgendadosDetalleFueraRuta.DataBindings.Add("Text", null, "NoAgendadosTiempos.FueraFrecuencia");
                report.NoAgendadosDetalleFueraRutaVenta.DataBindings.Add("Text", null, "NoAgendadosTiempos.ConVenta");
                report.NoAgendadosDetalleEficiencia.DataBindings.Add("Text", null, "NoAgendadosTiempos.EficienciaRuta", "{0:#,##0.00}");

                report.TiemposDetalleTiempoTotal.DataBindings.Add("Text", null, "NoAgendadosTiempos.TiempoTotal");
                report.TiemposDetalleTiempoVisita.DataBindings.Add("Text", null, "NoAgendadosTiempos.TiemposVisita");
                report.TiemposDetalleTiempoTransito.DataBindings.Add("Text", null, "NoAgendadosTiempos.TiempoTransito");


                //footer
                report.footerVendedor.DataBindings.Add("Text", report.DataSource, "VENNombre");
                report.footerCedi.Text = nombreEmpresa;







                report.headerFecha.Text = dFechaIni.ToString("dd'/'MM'/'yyyy");
                report.headerVendedor.DataBindings.Add("Text", report.DataSource, "VENNombre");




                return report;
            }
            catch (Exception ex)
            {
                return new ReporteLiquidacionMOR();
            }
        }

    }

    class LMVentasPorProductoModel
    {
        public string VendedorId { get; set; }
        public string VENNombre { get; set; }
        public string ProductoClave { get; set; }
        public string PRONombre { get; set; }
        public Decimal InventarioInicial { get; set; }
        public Decimal InventarioFinal { get; set; }
        public Decimal Recargas { get; set; }
        public Decimal Devoluciones { get; set; }
        public Decimal Promocion { get; set; }
        public Decimal Descargas { get; set; }
        public Decimal Ventas { get; set; }
        public Decimal Importe { get; set; }

        //Totales
        public Decimal TInventarioInicial { get; set; }
        public Decimal TInventarioFinal { get; set; }
        public Decimal TRecargas { get; set; }
        public Decimal TDevoluciones { get; set; }
        public Decimal TPromocion { get; set; }
        public Decimal TDescargas { get; set; }
        public Decimal TVentas { get; set; }
        public Decimal TImporte { get; set; }


    }

    class LMResumenVendedoresModel
    {
        public string VendedorId { get; set; }
        public string VENNombre { get; set; }

        //Agregado para datamembers
        public List<LMVentasPorProductoModel> VentasPorProducto { get; set; }
        public List<LMVentasModel> VentasContado { get; set; }
        public List<LMVentasModel> VentasCredito { get; set; }
        public List<LMCobranzaModel> CobranzaContado { get; set; }
        public List<LMCobranzaModel> CobranzaCredito { get; set; }
        public List<LMDesgloseEfectivoDocumentosModel> DesgloseEfectivoDocumentos { get; set; }
        public List<LMKilometrajeModel> Kilometraje { get; set; }
        public List<LMAgendadosModel> Agendados { get; set; }
        public List<LMNoAgendadosTiemposModel> NoAgendadosTiempos { get; set; }
        public List<LMTotalCobranzaModel> TotalCobranza { get; set; }
        public List<LMTotalesEfectivoDocumentosModel> TotalDesglose { get; set; }

        public LMResumenVendedoresModel()
        {
            VentasPorProducto = new List<LMVentasPorProductoModel>();
            VentasContado = new List<LMVentasModel>();
            VentasCredito = new List<LMVentasModel>();
            CobranzaContado = new List<LMCobranzaModel>();
            CobranzaCredito = new List<LMCobranzaModel>();
            DesgloseEfectivoDocumentos = new List<LMDesgloseEfectivoDocumentosModel>();
            Kilometraje = new List<LMKilometrajeModel>();
            Agendados = new List<LMAgendadosModel>();
            NoAgendadosTiempos = new List<LMNoAgendadosTiemposModel>();
            TotalCobranza = new List<LMTotalCobranzaModel>();
            TotalDesglose = new List<LMTotalesEfectivoDocumentosModel>();
        }

    }

    class LMDatosCEDIModel
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
    }

    //modelo para ventasCredito y ventasContado
    class LMVentasModel
    {
        public string Remision { get; set; }
        public string Factura { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public string Cliente { get; set; }

        private Decimal _Litros;
        public Decimal Litros { get { return _Litros; } set { _Litros = Math.Round(value, 2); } }

        public Decimal Total { get; set; }

        public Decimal GTotal { get; set; }
        public string VendedorId { get; set; }
    }

    //modelo para cobranzaCredito y cobranzaContado
    class LMCobranzaModel
    {
        public string FolioPago { get; set; }
        public string FolioDocumento { get; set; }
        public string Cliente { get; set; }
        public Decimal Importe { get; set; }
        public DateTime FechaPago { get; set; }
        public string VendedorId { get; set; }

        public Decimal TotalImporte { get; set; }

        public Decimal TotalCobranza { get; set; }
    }

    class LMTotalCobranzaModel
    {
        public Decimal Total { get; set; }
    }

    class LMDesgloseEfectivoModel
    {
        public string TipoEfectivo { get; set; }
        public string Cantidad { get; set; }
        public Decimal Total { get; set; }
        public string VendedorId { get; set; }
    }

    class LMDesgloseDocumentosModel
    {
        public string Banco { get; set; }
        public string Referencia { get; set; }
        public string FechaCobro { get; set; }
        public Decimal Importe { get; set; }
        public string VendedorId { get; set; }
    }

    class LMDesgloseEfectivoDocumentosModel
    {
        //Efectivo
        public string TipoEfectivo { get; set; }
        public string Cantidad { get; set; }
        public Decimal Total { get; set; }

        //Documentos
        public string Banco { get; set; }
        public string Referencia { get; set; }
        public string FechaCobro { get; set; }
        public Decimal Importe { get; set; }
        public string VendedorId { get; set; }
    }

    class LMTotalesEfectivoDocumentosModel
    {
        public Decimal TotalEfectivo { get; set; }
        public Decimal TotalDocumentos { get; set; }

        public Decimal TotalCobranzaContado { get; set; }
        public Decimal TotalCobranzaCredito { get; set; }
        public Decimal TotalCobranza { get; set; }

        public Decimal TotalGeneralLiquidado { get; set; }

    }



    class LMKilometrajeModel
    {
        public Decimal KmInicial { get; set; }
        public Decimal KmFinal { get; set; }

        public Decimal KmRecorrido { get; set; }
        public string VendedorId { get; set; }
    }

    class LMAgendadosModel
    {
        //general
        public string VendedorID { get; set; }

        public Decimal ClientesAgendados { get; set; }
        public Decimal ClientesVisitados { get; set; }
        public Decimal ClientesNoVisitados { get; set; }
        public Decimal EficienciaGeneral { get; set; }



        public Decimal VisitadosConVenta { get; set; }
        public Decimal VisitadosSinVenta { get; set; }
        public Decimal EficienciaRuta { get; set; }
    }

    class LMNoAgendadosModel
    {
        public string VendedorID { get; set; }
        public Decimal FueraFrecuencia { get; set; }
        public Decimal ConVenta { get; set; }
    }

    class LMTiemposModel
    {
        public string VendedorId { get; set; }
        public DateTime HoraInicialJornada { get; set; }
        public DateTime HoraFinalJornada { get; set; }
        public int TiempoVisita { get; set; }
    }

    class LMNoAgendadosTiemposModel
    {
        //NoAgendados
        public string VendedorID { get; set; }

        public Decimal FueraFrecuencia { get; set; }
        public Decimal ConVenta { get; set; }
        public Decimal EficienciaRuta { get; set; }


        //Tiempos
        public DateTime HoraInicialJornada { get; set; }
        public DateTime HoraFinalJornada { get; set; }
        public int TiempoVisita { get; set; }

        public TimeSpan TiempoTotal { get; set; }
        public TimeSpan TiemposVisita { get; set; }
        public TimeSpan TiempoTransito { get; set; }
    }

}