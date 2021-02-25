using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class TiemposEnRuta
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private DateTime fInicio;
        private DateTime fFin;
        TiemposRutaReport report = new TiemposRutaReport();
        SubKilometros kilometraje = new SubKilometros();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreCEDIS, string CEDIS, string EstatusFecha, string FechaInicial, string FechaFinal, string Rutas, string Vendedores, bool FiltroReporte)
        {
            try
            {
                #region reporte
                if (FiltroReporte)
                {
                    report.xrLabel25.Text = "Vendedor(es): ";
                    report.labelrutasheader.Text = (Vendedores == "" ? "Todas los Vendedores" : Vendedores);
                }
                else
                {
                    report.xrLabel25.Text = "Ruta(s): ";
                    report.labelrutasheader.Text = (Rutas == "" ? "Todas las Rutas" : Rutas);
                }
                report.labelrutasheader.Text = (Rutas == "" ? "Todos las Rutas" : Rutas);
                DateTime.TryParse(FechaInicial, out fInicio);
                FechaInicial = fInicio.ToString("yyyyMMdd");
                DateTime.TryParse(FechaFinal, out fFin);
                FechaFinal = fFin.ToString("yyyyMMdd");
                Rutas = (Rutas == "" ? "null" : "'" + Rutas + "'");
                CEDIS = (CEDIS == "" ? "null" : "'" + CEDIS + "'");
                Vendedores = (Vendedores == "" ? "null" : "'" + Vendedores + "'");
                
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("set nocount on ");

                sConsulta.AppendLine("if (select object_id('tempdb..#TmpVisita')) is not null drop table #TmpVisita");
                sConsulta.AppendLine("select * into #TmpVisita from( ");
                sConsulta.AppendLine("select VIS.VisitaClave, VIS.DiaClave, VIS.ClienteClave, VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.CodigoLeido, VCH.AlmacenId");
                sConsulta.AppendLine("from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta.AppendLine("where VIS.RUTClave <>'RUT001' and VCH.AlmacenID = " + CEDIS + " ");
                sConsulta.AppendLine("and Dia.FechaCaptura BETWEEN '" + FechaInicial + "' AND '" + FechaFinal + "'");
                sConsulta.AppendLine(" AND ((VIS.RUTClave IN (SELECT Datos FROM FNSplit(" + Rutas + ", ','))) OR " + Rutas + " IS NULL) ");
                sConsulta.AppendLine(") as t ");

                sConsulta.AppendLine("if (select object_id('tempdb..#TmpAgenda')) is not null drop table #TmpAgenda ");
                sConsulta.AppendLine("select * into #TmpAgenda from( ");
                sConsulta.AppendLine("select AGV.RUTClave, AGV.DiaClave, AGV.ClienteClave, AGV.VendedorId, AGV.ClaveCEDI, AGV.Orden  ");
                sConsulta.AppendLine("from AgendaVendedor AGV (NOLOCK)");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = AGV.ClaveCEDI");
                sConsulta.AppendLine("where AGV.RUTClave <>'RUT001' and ALN.AlmacenID = " + CEDIS + " ");
                sConsulta.AppendLine("and Dia.FechaCaptura BETWEEN '" + FechaInicial + "' AND '" + FechaFinal + "'");
                sConsulta.AppendLine(" AND ((AGV.RUTClave IN (SELECT Datos FROM FNSplit(" + Rutas + ", ','))) OR " + Rutas + " IS NULL) ");
                sConsulta.AppendLine(") as t");

                sConsulta.AppendLine("if (select object_id('tempdb..#TmpVenta')) is not null drop table #TmpVenta");
                sConsulta.AppendLine("select * into #TmpVenta from( ");
                sConsulta.AppendLine("select TRP.VisitaClave, TRP.DiaClave, TRP.TransProdID ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join #TmpVisita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("where TRP.Tipo = 1 AND TRP.TipoFase <>0 ");
                sConsulta.AppendLine(") as t");

                sConsulta.AppendLine("if (select object_id('tempdb..#TmpTiempos')) is not null drop table #TmpTiempos ");
                sConsulta.AppendLine("select * into #TmpTiempos from( ");
                sConsulta.AppendLine("select case when VEN.JornadaTrabajo = 1 then isnull(VEJ.VEJFechaInicial,VIS.FechaHoraInicial) else VIS.FechaHoraInicial end as HoraInicialJornada, case when VEN.JornadaTrabajo = 1 then isnull(VEJ.FechaFinal,VIS.FechaHoraFinal) else VIS.FechaHoraFinal end as HoraFinalJornada, VIS.VisitaClave, VIS.DiaClave, VIS.ClienteClave, VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.CodigoLeido, ");
                sConsulta.AppendLine("CLI.Clave as CLIClave, CLI.RazonSocial +' - '+cli.nombrecontacto as CLIRazonSocial, isnull(cd.Localidad,'')+', '+isnull(cd.Poblacion,'') as LocalidadPoblacion, RUT.Descripcion as RUTDescripcion,  AGV.Orden as SECOrden, VEN.Nombre as VENNombre, ");
                sConsulta.AppendLine("ALN.Clave as ALNClave, ALN.Nombre as ALNNombre, VEN.Kilometraje ");
                sConsulta.AppendLine("from #TmpVisita VIS ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("left join Ruta RUT (NOLOCK) on RUT.RUTClave = VIS.RUTClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("left join VendedorJornada VEJ (NOLOCK) on VEN.VendedorId = VEJ.VendedorId and VIS.DiaClave = VEJ.DiaClave AND VEJ.DiaClave is not null  ");
                sConsulta.AppendLine("left join #TmpAgenda AGV on VIS.VendedorId = AGV.VendedorId and VIS.DiaClave = AGV.DiaClave and  AGV.ClienteClave = VIS.ClienteClave");
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal");
                sConsulta.AppendLine("left join Almacen ALN (NOLOCK) on VCH.AlmacenId = ALN.AlmacenID  ");
                sConsulta.AppendLine("inner join ClienteDomicilio cd on VIS.ClienteClave=cd.ClienteClave and cd.Tipo=2  ");
                sConsulta.AppendLine(")as t1 ");
                sConsulta.AppendLine("inner join (");
                sConsulta.AppendLine("SELECT SUM(SINVENTA) as SINVENTA ,SUM (VISITADOS)+SUM(NOVISITADOS) as TotalCLientes ,SUM (VISITADOS) AS VISITADOS, SUM(NOVISITADOS) as NOVISITADOS, ");
                sConsulta.AppendLine("CASE WHEN CAST((sum(T.NOVISITADOS+ T.VISITADOS)) AS FLOAT) = 0 THEN 0 ELSE (CAST(sum(T.VISITADOS) AS FLOAT) /CAST((sum(T.NOVISITADOS + T.VISITADOS)) AS FLOAT))*100 END AS VISITAEfectiva , ");
                sConsulta.AppendLine("CASE WHEN sum(t.VISITADOS) = 0 THEN 0 ELSE CAST((sum(t.VISITADOS - t.SINVENTA)) AS FLOAT)/CAST(sum(t.VISITADOS) AS FLOAT)*100 END  AS EfectividadCompra , ");
                sConsulta.AppendLine("t.RutClave as Ruta ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("	select VIS.RutClave, VIS.VendedorId,  VIS.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi, ");
                sConsulta.AppendLine("	COUNT(DISTINCT AGV.ClienteClave) as VISITADOS, 0 as NOVISITADOS, 0 as SINVENTA ");
                sConsulta.AppendLine("	from #TmpVisita VIS  ");
                sConsulta.AppendLine("	inner join Vendedor VEN (NOLOCK) on VIS.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("	INNER JOIN #TmpAgenda AGV (NOLOCK) ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID  ");
                sConsulta.AppendLine("	INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = AGV.ClaveCEDI ");
                sConsulta.AppendLine("	GROUP BY VIS.RutClave, VIS.VendedorId,  VIS.DiaClave ,Aln.Clave,ALn.Nombre ");
                sConsulta.AppendLine("	Union ");
                sConsulta.AppendLine("	SELECT AGV.RutClave, AGV.VendedorId,  AGV.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi, ");
                sConsulta.AppendLine("	0 as VISITADOS, COUNT(DISTINCT AGV.ClienteClave) as NOVISITADOS, 0 AS SINVENTA ");
                sConsulta.AppendLine("	FROM #TmpAgenda AGV ");
                sConsulta.AppendLine("	LEFT JOIN #TmpVisita VIS ON VIS.RUTClave = AGV.RUTClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorID = AGV.VendedorId AND VIS.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("	INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = AGV.ClaveCEDI ");
                sConsulta.AppendLine("	where VIS.ClienteClave IS NULL ");
                sConsulta.AppendLine("	GROUP BY AGV.RutClave, AGV.VendedorId,  AGV.DiaClave ,Aln.Clave,ALn.Nombre ");
                sConsulta.AppendLine("	UNION ");
                sConsulta.AppendLine("	SELECT AGV.RutClave, AGV.VendedorId,  AGV.DiaClave, Aln.Clave+' '+ALn.Nombre as Cedi, ");
                sConsulta.AppendLine("	0 AS VISITADOS, 0 AS NOVISITADOS, COUNT (DISTINCT AGV.ClienteClave)as SINVENTA ");
                sConsulta.AppendLine("	FROM #TmpAgenda AGV ");
                sConsulta.AppendLine("	INNER JOIN #TmpVisita VIS ON VIS.RUTClave = AGV.RUTClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorID = AGV.VendedorId AND VIS.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("	INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = AGV.ClaveCEDI ");
                sConsulta.AppendLine("	LEFT JOIN #TmpVenta TRP (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("	WHERE TRP.TransProdID IS NULL ");
                sConsulta.AppendLine("	GROUP BY AGV.RutClave, AGV.VendedorId,  AGV.DiaClave ,Aln.Clave,ALn.Nombre ");
                sConsulta.AppendLine("	) AS T ");
                sConsulta.AppendLine("inner join vendedor v on T.VendedorId=v.VendedorId ");
                sConsulta.AppendLine("inner join ruta r on T.rutclave = r.rutclave ");
                sConsulta.AppendLine("GROUP BY t.RutClave, T.VendedorId ,V.Nombre,r.Descripcion ,t.cedi ");
                sConsulta.AppendLine(") as T2 ");
                sConsulta.AppendLine("ON T1.RUTClave = T2.Ruta ");

                sConsulta.AppendLine("select Kilometraje,HoraInicialJornada,HoraFinalJornada,VENNombre as Vendedor, convert(datetime,convert(varchar(20), FechaHoraInicial, 112)) as Fecha, RUTClave + ' ' + RUTDescripcion as Ruta, ");
                sConsulta.AppendLine("max(SECOrden) as Secuencia, CLIClave as Clave, CLIRazonSocial as NombreCliente, LocalidadPoblacion, CodigoNoLeido=(select case when CodigoLeido=0 then '*' else '' end), ");
                sConsulta.AppendLine("ImpCodigoNoLeido=(select case when CodigoLeido=0 then 1 else 0 end), ");
                sConsulta.AppendLine("0 as MinutosTransito, FechaHoraInicial as HoraInicio, FechaHoraFinal as HoraFin, datediff(s, FechaHoraInicial, FechaHoraFinal) as MinutosVisita, ");
                sConsulta.AppendLine("(select top 1 case when count(*) > 0 then 'SI' else 'NO' end from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as Venta, ");
                sConsulta.AppendLine("(select top 1 case when count(*) > 0 then 'SI' else 'NO' end from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TRP.VisitaClave1 = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as Surtido, ");
                sConsulta.AppendLine("convert(varchar(25), isnull((select VAD.Descripcion from ImproductividadVenta IMV inner join VAVDescripcion VAD on IMV.TipoMotivo = VAD.VAVClave and VAD.VARCodigo = 'MOTIMPRO' and VAD.VADTipoLenguaje = 'EM' where IMV.VisitaClave = TMP.VisitaClave AND IMV.DIACLAVE=TMP.DIACLAVE), 0)) as Concepto, ");
                sConsulta.AppendLine("(select sum(TRP.Total) from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClave) as TotalVenta, ");
                sConsulta.AppendLine("ALNClave + ' ' + ALNNombre as CEDI,TMP.SINVENTA,TMP.TotalCLientes,TMP.VISITADOS,TMP.NOVISITADOS,TMP.VISITAEfectiva,TMP.EfectividadCompra ");
                sConsulta.AppendLine("from #TmpTiempos TMP ");
                sConsulta.AppendLine("group by HoraInicialJornada,HoraFinalJornada,ALNClave, ALNNombre, VisitaClave, VENNombre, FechaHoraInicial, RUTClave, ClienteClave, CodigoLeido, ");
                sConsulta.AppendLine("CLIRazonSocial, LocalidadPoblacion, FechaHoraInicial, FechaHoraFinal, ClienteClave, CLIClave, RUTClave, RUTDescripcion,TMP.DIACLAVE, Kilometraje,SINVENTA,TotalCLientes,VISITADOS,NOVISITADOS,VISITAEfectiva,EfectividadCompra ");
                sConsulta.AppendLine("order by ALNClave, VENNombre, RUTClave, FechaHoraInicial ");

                sConsulta.AppendLine("drop table #TmpVisita ");
                sConsulta.AppendLine("drop table #TmpAgenda ");
                sConsulta.AppendLine("drop table #TmpVenta ");
                sConsulta.AppendLine("drop table #TmpTiempos ");
                sConsulta.AppendLine("set nocount off ");
                QueryString = "";

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<TiemposEnRutaModel> User = Connection.Query<TiemposEnRutaModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();
                
                if (User.Count() <= 0)
                {
                    return null;
                }

                StringBuilder sConsulta2 = new StringBuilder();
                sConsulta2.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta2.AppendLine("SET NOCOUNT ON ");
                sConsulta2.AppendLine("SELECT VEN.Nombre AS Vendedor, RES.SINVENTA AS SinVenta, RES.NOVISITADOS + RES.VISITADOS AS TotalClientes, ");
                sConsulta2.AppendLine("RES.NOVISITADOS, RES.VISITADOS, ");
                sConsulta2.AppendLine("CASE WHEN CAST((RES.NOVISITADOS + RES.VISITADOS) AS FLOAT) = 0 THEN 0  ELSE (CAST(RES.VISITADOS AS FLOAT) / CAST((RES.NOVISITADOS + RES.VISITADOS) AS FLOAT)) * 100 END AS VISITAEfectiva, ");
                sConsulta2.AppendLine("CASE WHEN RES.VISITADOS = 0 THEN 0 ELSE CAST((RES.VISITADOS - RES.SINVENTA) AS FLOAT)/ CAST(RES.VISITADOS AS FLOAT) * 100 END AS EfectividadCompra, ");
                sConsulta2.AppendLine("RUT.RUTClave + ' ' + RUT.Descripcion AS Ruta, ALN.Clave + ' ' + ALN.Nombre AS CEDI ");
                sConsulta2.AppendLine("FROM( ");
                sConsulta2.AppendLine("SELECT RutClave, VendedorId, DiaClave, SUM(VISITADOS) AS VISITADOS, SUM(NOVISITADOS) AS NOVISITADOS, SUM(SINVENTA) AS SINVENTA ");
                sConsulta2.AppendLine("FROM( ");
                sConsulta2.AppendLine("SELECT VIS.RutClave, VIS.VendedorId, VIS.DiaClave, ");
                sConsulta2.AppendLine("COUNT(DISTINCT VIS.ClienteClave) AS VISITADOS, 0 AS NOVISITADOS, 0 AS SINVENTA ");
                sConsulta2.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta2.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta2.AppendLine("INNER JOIN Dia (NOLOCK) ON DIA.DiaClave = VIS.DiaClave and Dia.FechaCaptura BETWEEN '" + FechaInicial + "' AND '" + FechaFinal + "'");
                sConsulta2.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = VIS.RUTClave AND RUT.RUTClave <> 'RUT001' AND ((RUT.RUTClave IN (SELECT Datos FROM FNSplit(" + Rutas + ", ','))) OR " + Rutas + " IS NULL) ");
                sConsulta2.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta2.AppendLine("LEFT JOIN Almacen ALN (NOLOCK) ON VCH.AlmacenId = ALN.AlmacenID AND ALN.AlmacenID = " + CEDIS + "");
                sConsulta2.AppendLine("LEFT JOIN AgendaVendedor AGV (NOLOCK) ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID ");
                sConsulta2.AppendLine("WHERE AGV.ClienteClave IS NULL ");
                sConsulta2.AppendLine("GROUP BY VIS.RutClave, VIS.VendedorId, VIS.DiaClave ");
                sConsulta2.AppendLine("UNION ");
                sConsulta2.AppendLine("SELECT VIS.RutClave, VIS.VendedorId, VIS.DiaClave, ");
                sConsulta2.AppendLine("0 AS VISITADOS, 0 AS NOVISITADOS, COUNT(DISTINCT VIS.ClienteClave) AS SINVENTA ");
                sConsulta2.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta2.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId AND ((VEN.VendedorId IN (SELECT Datos FROM FNSplit((" + Vendedores + "), ','))) OR " + Vendedores + " IS NULL) ");
                sConsulta2.AppendLine("INNER JOIN Dia (NOLOCK) ON DIA.DiaClave = VIS.DiaClave and Dia.FechaCaptura BETWEEN '" + FechaInicial + "' AND '" + FechaFinal + "'");
                sConsulta2.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = VIS.RUTClave AND RUT.RUTClave <> 'RUT001' AND ((RUT.RUTClave IN (SELECT Datos FROM FNSplit(" + Rutas + ", ','))) OR " + Rutas + " IS NULL) ");
                sConsulta2.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta2.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");
                sConsulta2.AppendLine("LEFT JOIN Almacen ALN (NOLOCK) ON VCH.AlmacenId = ALN.AlmacenID AND ALN.AlmacenID = " + CEDIS + "");
                sConsulta2.AppendLine("LEFT JOIN AgendaVendedor AGV (NOLOCK) ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID ");
                sConsulta2.AppendLine("WHERE AGV.ClienteClave IS NULL AND TRP.TransProdID IS NULL ");
                sConsulta2.AppendLine("GROUP BY VIS.RutClave, VIS.VendedorId, VIS.DiaClave ");
                sConsulta2.AppendLine(") AS T ");
                sConsulta2.AppendLine("GROUP BY RutClave, VendedorId, DiaClave ");
                sConsulta2.AppendLine(") AS RES ");
                sConsulta2.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = RES.VendedorID ");
                sConsulta2.AppendLine("INNER JOIN (SELECT DISTINCT DiaClave, VendedorId, ClaveCEDI FROM AgendaVendedor (NOLOCK)) AGV ON RES.VendedorId = AGV.VendedorId AND RES.DiaClave = AGV.DiaClave ");
                sConsulta2.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = RES.RUTClave ");
                sConsulta2.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                sConsulta2.AppendLine("SET NOCOUNT OFF ");
                QueryString = "";

                QueryString = sConsulta2.ToString();

                Connection.Open();
                List<ClientesFueraFrecuencia> ClientesFF = Connection.Query<ClientesFueraFrecuencia>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();
                
                var lista = (from c in User
                             select c).ToList();

                var listaClientes = (from c in ClientesFF
                                     select c).ToList();

                var s = (from gr in lista group gr by new { gr.CEDI, gr.Vendedor, gr.Ruta, gr.Fecha } into grupo select grupo);
                var cliff = (from gr in listaClientes group gr by new { gr.Vendedor, gr.Ruta } into grupo select grupo);
                List<TiemposEnRutaModel> formatlist = new List<TiemposEnRutaModel>();

                long tiempoRecorrido = 0;
                long tiempoVisita = 0;
                long tiempoTransitoTotal = 0;
                long tiempoPromedio = 0;
                int codigosNoLeidos = 0;
                Decimal TotalVentasGral = 0;
                int index = 0;
                int index2 = 0;

                foreach (var grupo in s)
                {
                    index++;
                    bool firstFromList = true;
                    foreach (var objetoAgrupado in grupo)
                    {
                        formatlist.Add(new TiemposEnRutaModel
                        {
                            Vendedor = objetoAgrupado.Vendedor,
                            Ruta = objetoAgrupado.Ruta,
                            Kilometraje = objetoAgrupado.Kilometraje,
                            HoraFinalJornada = objetoAgrupado.HoraFinalJornada,
                            HoraInicialJornada = objetoAgrupado.HoraInicialJornada,
                            Secuencia = objetoAgrupado.Secuencia,
                            Clave = objetoAgrupado.Clave,
                            NombreCliente = objetoAgrupado.NombreCliente,
                            LocalidadPoblacion = objetoAgrupado.LocalidadPoblacion,
                            CodigoNoLeido = objetoAgrupado.CodigoNoLeido,
                            ImpCodigoNoLeido = objetoAgrupado.ImpCodigoNoLeido,
                            MinutosTransito = objetoAgrupado.MinutosTransito,
                            HoraInicio = objetoAgrupado.HoraInicio,
                            HoraFin = objetoAgrupado.HoraFin,
                            MinutosVisita = objetoAgrupado.MinutosVisita,
                            Venta = objetoAgrupado.Venta,
                            Surtido = objetoAgrupado.Surtido,
                            Concepto = objetoAgrupado.Concepto,
                            TotalVenta = objetoAgrupado.TotalVenta,
                            CEDI = objetoAgrupado.CEDI,
                            Fecha = objetoAgrupado.Fecha,
                            MinutosVisitado = objetoAgrupado.HoraFin.Subtract(objetoAgrupado.HoraInicio),
                            //clientes en agenda
                            SINVENTA = objetoAgrupado.SINVENTA,
                            TotalCLientes = objetoAgrupado.TotalCLientes,
                            VISITADOS = objetoAgrupado.VISITADOS,
                            NOVISITADOS = objetoAgrupado.NOVISITADOS,
                            VISITAEfectiva = objetoAgrupado.VISITAEfectiva,
                            EfectividadCompra = objetoAgrupado.EfectividadCompra,
                            //clientes fuera de la frecuencia
                            SinVentaF = objetoAgrupado.SinVentaF,
                            TotalClientesF = objetoAgrupado.TotalClientesF,
                            NOVISITADOSF = objetoAgrupado.NOVISITADOSF,
                            VISITADOSF = objetoAgrupado.VISITADOSF,
                            VISITAEfectivaF = objetoAgrupado.VISITAEfectivaF,
                            EfectividadCompraF = objetoAgrupado.EfectividadCompraF
                        });
                        if (firstFromList)
                        {
                            formatlist.Last().TiempoTransito = TimeSpan.Zero;
                            firstFromList = false;
                        }
                        else
                        {
                            formatlist.Last().TiempoTransito = formatlist.Last().HoraInicio.Subtract(formatlist.ElementAt(index2 - 1).HoraFin);
                            tiempoTransitoTotal += formatlist.Last().TiempoTransito.Ticks;
                        }
                        if (formatlist.Last().CodigoNoLeido == "0")
                        {
                            formatlist.Last().CodigoNoLeido = "";
                        }
                        if (formatlist.Last().Concepto == "0")
                        {
                            formatlist.Last().Concepto = "";
                        }
                        index2++;
                    }
                    //llenamos los datos del primer footer solo en el ultimo registro del grupo
                    formatlist.Last().TotalFecha = grupo.Sum(c => c.TotalVenta);

                    //hacemos la sumatoria del grupo

                    //seccion clientes en agenda
                    tiempoRecorrido += grupo.Last().HoraFin.Subtract(grupo.First().HoraInicio).Ticks;
                    tiempoVisita += grupo.Sum(r => r.HoraFin.Subtract(r.HoraInicio).Ticks);
                    tiempoPromedio += grupo.Count();
                    codigosNoLeidos += grupo.Sum(c => int.Parse(c.ImpCodigoNoLeido));
                    TotalVentasGral += formatlist.Last().TotalFecha;
                    
                    if (!grupo.Key.Equals(s.Last().Key))
                    {
                        //realizamos la sumatoria de todos los totales de esta ruta
                        if (!grupo.LastOrDefault().Ruta.Equals(s.ElementAt(index).Key.Ruta))
                        {
                            formatlist.Last().TiempoRecorrido = TimeSpan.FromTicks(tiempoRecorrido);
                            formatlist.Last().TiempoVisita = TimeSpan.FromTicks(tiempoVisita);
                            formatlist.Last().TiempoTransitoTotal = TimeSpan.FromTicks(tiempoTransitoTotal);
                            formatlist.Last().TiempoPromedio = TimeSpan.FromTicks(tiempoVisita / tiempoPromedio);
                            formatlist.Last().TotalNoLeidos = codigosNoLeidos.ToString();
                            formatlist.Last().TotalVentasGral = TotalVentasGral;

                            formatlist.Last().TiempoRecorridoS = ((long)formatlist.Last().TiempoRecorrido.TotalHours).ToString("D2") + ":" + formatlist.Last().TiempoRecorrido.Minutes.ToString("D2") + ":" + formatlist.Last().TiempoRecorrido.Seconds.ToString("D2");
                            formatlist.Last().TiempoVisitaS = ((long)formatlist.Last().TiempoVisita.TotalHours).ToString("D2") + ":" + formatlist.Last().TiempoVisita.Minutes.ToString("D2") + ":" + formatlist.Last().TiempoVisita.Seconds.ToString("D2");
                            formatlist.Last().TiempoTransitoTotalS = ((long)formatlist.Last().TiempoTransitoTotal.TotalHours).ToString("D2") + ":" + formatlist.Last().TiempoTransitoTotal.Minutes.ToString("D2") + ":" + formatlist.Last().TiempoTransitoTotal.Seconds.ToString("D2");
                            formatlist.Last().TiempoPromedioS = ((long)formatlist.Last().TiempoPromedio.TotalHours).ToString("D2") + ":" + formatlist.Last().TiempoPromedio.Minutes.ToString("D2") + ":" + formatlist.Last().TiempoPromedio.Seconds.ToString("D2");

                            //seccion clientes fuera de frecuencia
                            foreach (var clientes in cliff)
                            {
                                if (grupo.LastOrDefault().Ruta.Equals(clientes.LastOrDefault().Ruta) && grupo.LastOrDefault().Vendedor.Equals(clientes.LastOrDefault().Vendedor))
                                {
                                    formatlist.Last().VISITADOSF = clientes.Sum(c => c.VISITADOS);
                                    formatlist.Last().SinVentaF = clientes.Sum(c => c.SinVenta);
                                    formatlist.LastOrDefault().EfectividadCompraF = clientes.Sum(c => c.EfectividadCompra) / clientes.Count();
                                }
                            }
                            tiempoRecorrido = 0;
                            tiempoVisita = 0;
                            tiempoTransitoTotal = 0;
                            tiempoPromedio = 0;
                            codigosNoLeidos = 0;
                            TotalVentasGral = 0;
                        }
                    }
                    else
                    {
                        formatlist.Last().TiempoRecorrido = TimeSpan.FromTicks(tiempoRecorrido);
                        formatlist.Last().TiempoVisita = TimeSpan.FromTicks(tiempoVisita);
                        formatlist.Last().TiempoTransitoTotal = TimeSpan.FromTicks(tiempoTransitoTotal);
                        formatlist.Last().TiempoPromedio = TimeSpan.FromTicks(tiempoVisita / tiempoPromedio);
                        formatlist.Last().TotalNoLeidos = codigosNoLeidos.ToString();
                        formatlist.Last().TotalVentasGral = TotalVentasGral;

                        formatlist.Last().TiempoRecorridoS = ((long)formatlist.Last().TiempoRecorrido.TotalHours).ToString("D2") + ":" + formatlist.Last().TiempoRecorrido.Minutes.ToString("D2") + ":" + formatlist.Last().TiempoRecorrido.Seconds.ToString("D2");
                        formatlist.Last().TiempoVisitaS = ((long)formatlist.Last().TiempoVisita.TotalHours).ToString("D2") + ":" + formatlist.Last().TiempoVisita.Minutes.ToString("D2") + ":" + formatlist.Last().TiempoVisita.Seconds.ToString("D2");
                        formatlist.Last().TiempoTransitoTotalS = ((long)formatlist.Last().TiempoTransitoTotal.TotalHours).ToString("D2") + ":" + formatlist.Last().TiempoTransitoTotal.Minutes.ToString("D2") + ":" + formatlist.Last().TiempoTransitoTotal.Seconds.ToString("D2");
                        formatlist.Last().TiempoPromedioS = ((long)formatlist.Last().TiempoPromedio.TotalHours).ToString("D2") + ":" + formatlist.Last().TiempoPromedio.Minutes.ToString("D2") + ":" + formatlist.Last().TiempoPromedio.Seconds.ToString("D2");

                        //seccion clientes fuera de frecuencia
                        foreach (var clientes in cliff)
                        {
                            if (grupo.LastOrDefault().Ruta.Equals(clientes.LastOrDefault().Ruta) && grupo.LastOrDefault().Vendedor.Equals(clientes.LastOrDefault().Vendedor))
                            {
                                formatlist.Last().VISITADOSF = clientes.Sum(c => c.VISITADOS);
                                formatlist.Last().SinVentaF = clientes.Sum(c => c.SinVenta);
                                formatlist.LastOrDefault().EfectividadCompraF = clientes.Sum(c => c.EfectividadCompra) / clientes.Count();
                            }
                        }
                    }
                }

                report.DataSource = formatlist;
                FechaInicial = this.fInicio.Date.ToShortDateString();
                FechaFinal = this.fFin.Date.ToShortDateString();
                report.labelfechaheader.Text = FechaInicial + (FechaFinal == FechaInicial ? "" : " - " + FechaFinal);
                
                Connection.Open();
                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK)";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                
                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;


                Connection.Close();
                //ReportHeader
                report.headerlabelcedis.DataBindings.Add("Text", report.DataSource, "CEDI");

                //grouheader3
                GroupField groupCedi = new GroupField("CEDI");
                report.GroupHeader3.GroupFields.Add(groupCedi);
                report.CediLabel.DataBindings.Add("Text", report.DataSource, "CEDI");
                //grouheader2
                GroupField groupVendedor = new GroupField("Vendedor");
                report.GroupHeader2.GroupFields.Add(groupVendedor);
                report.labelVen.DataBindings.Add("Text", report.DataSource, "Vendedor");
                //grouheader4
                GroupField groupRuta = new GroupField("Ruta");
                report.GroupHeader4.GroupFields.Add(groupRuta);
                report.rutalabel.DataBindings.Add("Text", report.DataSource, "Ruta");
                //grouheader1
                GroupField groupFecha = new GroupField("Fecha");
                report.GroupHeader1.GroupFields.Add(groupFecha);
                report.fechalabel.DataBindings.Add("Text", report.DataSource, "Fecha", "{0:dd/MM/yyyy}");
                report.labeliniciorecorrido.DataBindings.Add("Text", report.DataSource, "HoraInicialJornada", "{0:HH:mm:ss}");
                //groupheader5
                GroupField groupHInicio = new GroupField("HoraInicialJornada");
                report.GroupHeader5.GroupFields.Add(groupHInicio);
                
                //groupfooter1
                report.labelfooter1finrecorrido.DataBindings.Add("Text", report.DataSource, "HoraFinalJornada", "{0:HH:mm:ss}");

                report.l1.DataBindings.Add("Text", null, "Secuencia");
                report.l2.DataBindings.Add("Text", null, "Clave");
                report.l3.DataBindings.Add("Text", null, "NombreCliente");
                report.l4.DataBindings.Add("Text", null, "LocalidadPoblacion");
                report.l5.DataBindings.Add("Text", null, "CodigoNoLeido");
                report.l6.DataBindings.Add("Text", null, "TiempoTransito", "{0:hh':'mm':'ss}");
                report.l7.DataBindings.Add("Text", null, "HoraInicio", "{0:HH:mm:ss}");
                report.l8.DataBindings.Add("Text", null, "HoraFin", "{0:HH:mm:ss}");
                report.l9.DataBindings.Add("Text", null, "MinutosVisitado", "{0:hh':'mm':'ss}");
                report.l10.DataBindings.Add("Text", null, "Venta");

                report.tiemporecorrido.DataBindings.Add("Text", report.DataSource, "TiempoRecorridoS");
                report.tiempovisita.DataBindings.Add("Text", report.DataSource, "TiempoVisitaS");
                report.tiempotransito.DataBindings.Add("Text", report.DataSource, "TiempoTransitoTotalS");
                report.tiempopromedio.DataBindings.Add("Text", report.DataSource, "TiempoPromedioS");
                report.totalcodigosnoleidos.DataBindings.Add("Text", report.DataSource, "TotalNoLeidos");
                report.totalventasgeneral.DataBindings.Add("Text", report.DataSource, "TotalVentasGral", "{0:$#,###,##0.00}");
                
                if (MostrarSurtido())
                {
                    report.l11.DataBindings.Add("Text", null, "Surtido");
                }
                else
                {
                    report.l11.Visible = false;
                    report.xrLabel10.Visible = false;
                }
                report.l12.DataBindings.Add("Text", null, "Concepto");
                report.l13.DataBindings.Add("Text", null, "TotalVenta", "{0:$#,###,##0.00}");
                report.labelfooter1VentaTotal.DataBindings.Add("Text", null, "TotalFecha", "{0:$#,###,##0.00}");

                ////////Clientes Agenda
                report.labelca1.DataBindings.Add("Text", report.DataSource, "VISITADOS");
                report.labelca2.DataBindings.Add("Text", report.DataSource, "NOVISITADOS");
                report.labelca3.DataBindings.Add("Text", report.DataSource, "TotalCLientes");
                report.labelca4.DataBindings.Add("Text", report.DataSource, "VISITAEfectiva", "{0:#.00}");
                report.labelca5.DataBindings.Add("Text", report.DataSource, "SINVENTA");
                report.labelca6.DataBindings.Add("Text", report.DataSource, "EfectividadCompra", "{0:0.00}");
                ////////

                ////////ClientesFueradeFrecuencia
                report.VisitadosF.DataBindings.Add("Text", report.DataSource, "VISITADOSF");
                report.VisitadosSVF.DataBindings.Add("Text", report.DataSource, "SinVentaF");
                report.EfectividadCompraF.DataBindings.Add("Text", report.DataSource, "EfectividadCompraF", "{0:0.00}");
                ////////
                
                #endregion
                #region kilometraje
                StringBuilder KilometrajeString = new StringBuilder();
                KilometrajeString.AppendLine("SET ANSI_WARNINGS OFF ");
                KilometrajeString.AppendLine("SET NOCOUNT ON ");
                KilometrajeString.AppendLine("SELECT ALN.Clave + ' ' + ALN.Nombre AS CEDI, VEN.Nombre AS Vendedor, RUT.RUTClave + ' ' + RUT.Descripcion AS Ruta, ");
                KilometrajeString.AppendLine("CONVERT(DATETIME, CONVERT(VARCHAR(20), FechaHoraInicial, 112)) AS Fecha, CAV.KmInicial, CAV.KmFinal, CAV.Placa ");
                KilometrajeString.AppendLine("FROM CamionVendedor CAV (NOLOCK) ");
                KilometrajeString.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON CAV.VendedorId = VEN.VendedorId ");
                KilometrajeString.AppendLine("INNER JOIN (SELECT DISTINCT VendedorId, RUTClave, ClaveCEDI FROM AgendaVendedor (NOLOCK)) AGV ON CAV.VendedorId = AGV.VendedorId ");
                KilometrajeString.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON AGV.ClaveCEDI = ALN.Clave ");
                KilometrajeString.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                KilometrajeString.AppendLine("where RUT.RUTClave <>'RUT001' and ALN.AlmacenID = " + CEDIS + " ");
                KilometrajeString.AppendLine("AND CAV.FechaHoraInicial BETWEEN '" + FechaInicial + "' AND '" + FechaFinal + "' ");
                KilometrajeString.AppendLine("AND ((RUT.RUTClave IN (SELECT Datos FROM FNSplit(" + Rutas + ", ','))) OR " + Rutas + " IS NULL) ");
                KilometrajeString.AppendLine("ORDER BY Fecha ASC ");
                KilometrajeString.AppendLine("SET NOCOUNT OFF ");
                string QueryStringKm = KilometrajeString.ToString();

                Connection.Open();
                List<KilometrajeTiemposEnRutaModel> Km = Connection.Query<KilometrajeTiemposEnRutaModel>(QueryStringKm, null, null, true, 9000).ToList();
                Connection.Close();
                
                var lista2 = (from c in Km
                              select c).ToList();

                var kilolista = lista2.GroupBy(l => new { l.CEDI, l.Vendedor, l.Ruta, l.Fecha })
                        .SelectMany(cl => cl.Select(cs => new KilometrajeTiemposEnRutaModel
                        {
                            CEDI = cs.CEDI,
                            Vendedor = cs.Vendedor,
                            Ruta = cs.Ruta,
                            Fecha = cs.Fecha,
                            KmInicial = cs.KmInicial,
                            KmFinal = cs.KmFinal,
                            KmConsumido = cs.KmFinal - cs.KmInicial,
                            Placa = cs.Placa
                        })).ToList();
                
                kilometraje.DataSource = kilolista;
                kilometraje.cedilabel.DataBindings.Add("Text", kilometraje.DataSource, "CEDI");

                kilometraje.vendedorlabel.DataBindings.Add("Text", kilometraje.DataSource, "Vendedor");
                kilometraje.rutalabel.DataBindings.Add("Text", kilometraje.DataSource, "Ruta");
                kilometraje.fechalabel.DataBindings.Add("Text", kilometraje.DataSource, "Fecha", "{0:dd/MM/yy}");
                kilometraje.placalabel.DataBindings.Add("Text", kilometraje.DataSource, "Placa");

                kilometraje.labelKmInicial.DataBindings.Add("Text", kilometraje.DataSource, "KmInicial");
                kilometraje.labelKmFinal.DataBindings.Add("Text", kilometraje.DataSource, "KmFinal");
                kilometraje.labelKmConsumidos.DataBindings.Add("Text", kilometraje.DataSource, "KmConsumido");

                if (lista2.Count() > 0)
                {
                    report.xrSubreport1.ReportSource = kilometraje;
                }
                else
                {
                    report.xrLabel3.Visible = false;
                    report.xrSubreport1.Visible = false;
                }
                #endregion
                return report;
            }
            catch (Exception ex)
            {
                return new TiemposRutaReport();
            }
        }

        bool MostrarSurtido()
        {
            StringBuilder mostrar = new StringBuilder();
            mostrar.AppendLine("SELECT CONVERT(BIT, CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END) AS TieneReparto ");
            mostrar.AppendLine("FROM ModuloMovDetalle MMD (NOLOCK) ");
            mostrar.AppendLine("INNER JOIN ModuloTerm MTE (NOLOCK) ON MMD.ModuloClave = MTE.ModuloClave AND MTE.TipoIndice = 3 AND MTE.TipoEstado = 1 AND MTE.Baja = 0 ");
            mostrar.AppendLine("WHERE MMD.TipoTransProd = 1 AND MMD.TipoEstado = 1 AND MMD.Baja = 0 ");
            string query = mostrar.ToString();
            bool response = Connection.Query<bool>(query, null, null, true, 9000).FirstOrDefault();
            return response;
        }
    }

    class TiemposEnRutaModel
    {
        public bool Kilometraje { get; set; }
        public DateTime HoraInicialJornada { get; set; }
        public DateTime HoraFinalJornada { get; set; }
        public string Vendedor { get; set; }
        public DateTime Fecha { get; set; }
        public string Ruta { get; set; }
        public string Secuencia { get; set; }
        public string Clave { get; set; }
        public string NombreCliente { get; set; }
        public string LocalidadPoblacion { get; set; }
        public string CodigoNoLeido { get; set; }
        public string ImpCodigoNoLeido { get; set; }
        public string MinutosTransito { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string MinutosVisita { get; set; }
        //reemplazo a MinutosVisita
        public TimeSpan MinutosVisitado { get; set; }
        public string Venta { get; set; }
        public string Surtido { get; set; }
        public string Concepto { get; set; }
        public Decimal TotalVenta { get; set; }
        public string CEDI { get; set; }
        public Decimal TotalFecha { get; set; }
        public TimeSpan TiempoRecorrido { get; set; }
        public TimeSpan TiempoVisita { get; set; }
        public TimeSpan TiempoTransito { get; set; }
        public TimeSpan TiempoTransitoTotal { get; set; }
        public TimeSpan TiempoPromedio { get; set; }
        public string TotalNoLeidos { get; set; }
        public Decimal TotalVentasGral { get; set; }
        public string TiempoRecorridoS { get; set; }
        public string TiempoVisitaS { get; set; }
        public string TiempoTransitoTotalS { get; set; }
        public string TiempoPromedioS { get; set; }
        //Clientes en agenda
        public int SINVENTA { get; set; }
        public string TotalCLientes { get; set; }
        public int VISITADOS { get; set; }
        public string NOVISITADOS { get; set; }
        public Decimal VISITAEfectiva { get; set; }
        public Decimal EfectividadCompra { get; set; }
        //Clientes fuera de la frecuencia
        public long SinVentaF { get; set; }
        public long TotalClientesF { get; set; }
        public long NOVISITADOSF { get; set; }
        public long VISITADOSF { get; set; }
        public Decimal VISITAEfectivaF { get; set; }
        public Decimal EfectividadCompraF { get; set; }
    }

    class ClientesFueraFrecuencia
    {
        public string Vendedor { get; set; }
        public long SinVenta { get; set; }
        public long TotalClientes { get; set; }
        public long NOVISITADOS { get; set; }
        public long VISITADOS { get; set; }
        public Decimal VISITAEfectiva { get; set; }
        public Decimal EfectividadCompra { get; set; }
        public string Ruta { get; set; }
    }

    class KilometrajeTiemposEnRutaModel
    {
        public string CEDI { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal KmInicial { get; set; }
        public Decimal KmFinal { get; set; }
        public Decimal KmConsumido { get; set; }
        public string Placa { get; set; }
    }
}