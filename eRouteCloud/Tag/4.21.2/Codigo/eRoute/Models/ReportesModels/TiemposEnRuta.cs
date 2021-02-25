using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace eRoute.Models.ReportesModels
{
    public class TiemposEnRuta
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        TiemposRutaReport report = new TiemposRutaReport();
        SubKilometros kilometraje = new SubKilometros();

        public XtraReport GetReport(string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal, string pvCondicionKm, string vendedor, string ruta, string almacen, string fecha, string cav)
        {
            try
            {
                #region reporte
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpTiempos')) IS NOT NULL DROP TABLE #TmpTiempos ");
                sConsulta.AppendLine("SELECT * INTO #TmpTiempos FROM( ");
                sConsulta.AppendLine("SELECT CASE WHEN VEN.JornadaTrabajo = 1 THEN ISNULL(VEJ.VEJFechaInicial, VIS.FechaHoraInicial) ELSE VIS.FechaHoraInicial END AS HoraInicialJornada, CASE WHEN VEN.JornadaTrabajo = 1 THEN ISNULL(VEJ.FechaFinal, VIS.FechaHoraFinal) ELSE VIS.FechaHoraFinal END AS HoraFinalJornada, VIS.VisitaClave, VIS.DiaClave, VIS.ClienteClave, VIS.VendedorId, VIS.RutClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.CodigoLeido, ");
                sConsulta.AppendLine("CLI.Clave AS CLIClave, CLI.RazonSocial + ' - ' + cli.nombrecontacto AS CLIRazonSocial, ISNULL(cd.Localidad, '') + ', ' + ISNULL(cd.Poblacion, '') AS LocalidadPoblacion, RUT.Descripcion AS RUTDescripcion, AGV.Orden AS SECOrden, VEN.Nombre AS VENNombre, ");
                sConsulta.AppendLine("ALN.Clave AS ALNClave, ALN.Nombre AS ALNNombre, VEN.Kilometraje ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = VIS.DiaClave " + fecha);
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId " + vendedor);
                sConsulta.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta.AppendLine("INNER JOIN ClienteDomicilio cd (NOLOCK) ON VIS.ClienteClave = cd.ClienteClave AND cd.Tipo = 2 ");
                sConsulta.AppendLine("LEFT JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = VIS.RUTClave " + ruta + " AND RUT.RUTClave <> 'RUT001' ");
                sConsulta.AppendLine("LEFT JOIN VendedorJornada VEJ (NOLOCK) ON VEN.VendedorId = VEJ.VendedorId AND VIS.DiaClave = VEJ.DiaClave AND VEJ.DiaClave IS NOT NULL ");
                sConsulta.AppendLine("LEFT JOIN AgendaVendedor AGV (NOLOCK) ON VIS.VendedorId = AGV.VendedorId AND VIS.DiaClave = AGV.DiaClave AND AGV.ClienteClave = VIS.ClienteClave ");
                sConsulta.AppendLine("LEFT JOIN Almacen ALN (NOLOCK) ON VCH.AlmacenId = ALN.AlmacenID " + almacen);
                //sConsulta.AppendLine(pvCondicion + " AND RUT.RUTClave <> 'RUT001' ");
                sConsulta.AppendLine(") AS t1 ");

                sConsulta.AppendLine("INNER JOIN ");
                sConsulta.AppendLine("(SELECT SUM(SINVENTA) AS SINVENTA, SUM (VISITADOS) + SUM(NOVISITADOS) AS TotalCLientes, SUM (VISITADOS) AS VISITADOS, SUM(NOVISITADOS) AS NOVISITADOS, ");
                sConsulta.AppendLine("CASE WHEN CAST((SUM(T.NOVISITADOS + T.VISITADOS)) AS FLOAT) = 0 THEN 0 ELSE (CAST(SUM(T.VISITADOS) AS FLOAT) /CAST((SUM(T.NOVISITADOS + T.VISITADOS)) AS FLOAT))*100 END AS VISITAEfectiva, ");
                sConsulta.AppendLine("CASE WHEN SUM(t.VISITADOS) = 0 THEN 0 ELSE CAST((SUM(t.VISITADOS - t.SINVENTA)) AS FLOAT)/CAST(SUM(t.VISITADOS) AS FLOAT)*100 END AS EfectividadCompra, ");
                sConsulta.AppendLine("t.RutClave AS Ruta ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("SELECT VIS.RutClave, VIS.VendedorId, VIS.DiaClave, Aln.Clave + ' ' + ALn.Nombre AS Cedi, ");
                sConsulta.AppendLine("COUNT(DISTINCT AGV.ClienteClave) AS VISITADOS, 0 AS NOVISITADOS, 0 AS SINVENTA ");
                sConsulta.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId " + vendedor);
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON DIA.DiaClave = VIS.DiaClave " + fecha);
                sConsulta.AppendLine("INNER JOIN AgendaVendedor AGV (NOLOCK) ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = AGV.RUTClave AND RUT.RUTClave <> 'RUT001' " + ruta);
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = AGV.ClaveCEDI " + almacen);
                //sConsulta.AppendLine(pvCondicion + " AND RUT.RUTClave <> 'RUT001' ");
                sConsulta.AppendLine("GROUP BY VIS.RutClave, VIS.VendedorId, VIS.DiaClave, Aln.Clave, ALn.Nombre ");
                sConsulta.AppendLine("UNION ");
                sConsulta.AppendLine("SELECT AGV.RutClave, AGV.VendedorId, AGV.DiaClave, Aln.Clave + ' ' + ALn.Nombre AS Cedi, ");
                sConsulta.AppendLine("0 AS VISITADOS, COUNT(DISTINCT AGV.ClienteClave) AS NOVISITADOS, 0 AS SINVENTA ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = AGV.DiaClave " + fecha);
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = AGV.RUTClave AND RUT.RUTClave <> 'RUT001' " + ruta);
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = AGV.ClaveCEDI " + almacen);
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = AGV.VendedorId " + vendedor);
                sConsulta.AppendLine("LEFT JOIN Visita VIS (NOLOCK) ON VIS.RUTClave = AGV.RUTClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorID = AGV.VendedorId AND VIS.ClienteClave = AGV.ClienteClave ");
                //sConsulta.AppendLine(pvCondicion + " AND RUT.RUTClave <> 'RUT001' ");
                sConsulta.AppendLine("AND VIS.ClienteClave IS NULL ");
                sConsulta.AppendLine("GROUP BY AGV.RutClave, AGV.VendedorId, AGV.DiaClave, Aln.Clave, ALn.Nombre ");
                sConsulta.AppendLine("UNION ");
                sConsulta.AppendLine("SELECT AGV.RutClave, AGV.VendedorId, AGV.DiaClave, Aln.Clave + ' ' + ALn.Nombre AS Cedi, ");
                sConsulta.AppendLine("0 AS VISITADOS, 0 AS NOVISITADOS, COUNT (DISTINCT AGV.ClienteClave) AS SINVENTA ");
                sConsulta.AppendLine("FROM AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = AGV.DiaClave " + fecha);
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON VIS.RUTClave = AGV.RUTClave AND VIS.DiaClave = AGV.DiaClave AND VIS.VendedorID = AGV.VendedorId AND VIS.ClienteClave = AGV.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = VIS.RUTClave AND RUT.RUTClave <> 'RUT001' " + ruta);
                sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = AGV.ClaveCEDI " + almacen);
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VEN.VendedorID = VIS.VendedorId " + vendedor);
                sConsulta.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");
                //sConsulta.AppendLine(pvCondicion + " AND RUT.RUTClave <> 'RUT001' ");
                sConsulta.AppendLine("AND TRP.TransProdID IS NULL ");
                sConsulta.AppendLine("GROUP BY AGV.RutClave, AGV.VendedorId, AGV.DiaClave, Aln.Clave, ALn.Nombre ");
                sConsulta.AppendLine(") AS T ");
                sConsulta.AppendLine("INNER JOIN vendedor v (NOLOCK) ON T.VendedorId = v.VendedorId ");
                sConsulta.AppendLine("INNER JOIN ruta r (NOLOCK) ON T.rutclave = r.rutclave ");
                sConsulta.AppendLine("GROUP BY t.RutClave, T.VendedorId, V.Nombre, r.Descripcion, t.cedi) AS T2 ");
                sConsulta.AppendLine("ON T1.RUTClave = T2.Ruta ");
                sConsulta.AppendLine("SELECT Kilometraje, HoraInicialJornada, HoraFinalJornada, VENNombre AS Vendedor, CONVERT(DATETIME, CONVERT(VARCHAR(20), FechaHoraInicial, 112)) AS Fecha, RUTClave + ' ' + RUTDescripcion AS Ruta, ");
                sConsulta.AppendLine("MAX(SECOrden) AS Secuencia, CLIClave AS Clave, CLIRazonSocial AS NombreCliente, LocalidadPoblacion, CodigoNoLeido = (SELECT CASE WHEN CodigoLeido = 0 THEN '*' ELSE '' END), ");
                sConsulta.AppendLine("ImpCodigoNoLeido = (SELECT CASE WHEN CodigoLeido = 0 THEN 1 ELSE 0 END), ");
                sConsulta.AppendLine("0 AS MinutosTransito, FechaHoraInicial AS HoraInicio, FechaHoraFinal AS HoraFin, datediff(s, FechaHoraInicial, FechaHoraFinal) AS MinutosVisita, ");
                sConsulta.AppendLine("(SELECT TOP 1 CASE WHEN count(*) > 0 THEN 'SI' ELSE 'NO' END FROM TransProd TRP (NOLOCK) WHERE TRP.Tipo = 1 AND TRP.TipoFase <> 0 AND TRP.VisitaClave = TMP.VisitaClave AND TRP.ClienteClave = TMP.ClienteClave) AS Venta, ");
                sConsulta.AppendLine("(SELECT TOP 1 CASE WHEN count(*) > 0 THEN 'SI' ELSE 'NO' END FROM TransProd TRP (NOLOCK) WHERE TRP.Tipo = 1 AND TRP.TipoFase IN (2, 3) AND TRP.VisitaClave1 = TMP.VisitaClave AND TRP.ClienteClave = TMP.ClienteClave) AS Surtido, ");
                sConsulta.AppendLine("CONVERT(VARCHAR(25), ISNULL((SELECT VAD.Descripcion FROM ImproductividadVenta IMV (NOLOCK) INNER JOIN VAVDescripcion VAD (NOLOCK) ON IMV.TipoMotivo = VAD.VAVClave AND VAD.VARCodigo = 'MOTIMPRO' AND VAD.VADTipoLenguaje = 'EM' WHERE IMV.VisitaClave = TMP.VisitaClave AND IMV.DIACLAVE = TMP.DIACLAVE), 0)) AS Concepto, ");
                sConsulta.AppendLine("(SELECT SUM(TRP.Total) FROM TransProd TRP (NOLOCK) WHERE TRP.Tipo = 1 AND TRP.TipoFase <> 0 AND TRP.VisitaClave = TMP.VisitaClave AND TRP.ClienteClave = TMP.ClienteClave) AS TotalVenta, ");
                sConsulta.AppendLine("ALNClave + ' ' + ALNNombre AS CEDI, TMP.SINVENTA, TMP.TotalCLientes, TMP.VISITADOS, TMP.NOVISITADOS, TMP.VISITAEfectiva, TMP.EfectividadCompra ");
                sConsulta.AppendLine("FROM #TmpTiempos TMP ");
                sConsulta.AppendLine("GROUP BY HoraInicialJornada, HoraFinalJornada, ALNClave, ALNNombre, VisitaClave, VENNombre, FechaHoraInicial, RUTClave, ClienteClave, CodigoLeido, ");
                sConsulta.AppendLine("CLIRazonSocial, LocalidadPoblacion, FechaHoraInicial, FechaHoraFinal, ClienteClave, CLIClave, RUTClave, RUTDescripcion, TMP.DIACLAVE, Kilometraje, SINVENTA, TotalCLientes, VISITADOS, NOVISITADOS, VISITAEfectiva, EfectividadCompra ");
                sConsulta.AppendLine("ORDER BY ALNClave, VENNombre, RUTClave, FechaHoraInicial ");
                sConsulta.AppendLine("DROP TABLE #TmpTiempos ");
                sConsulta.AppendLine("SET NOCOUNT OFF ");
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
                sConsulta2.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId " + vendedor);
                sConsulta2.AppendLine("INNER JOIN Dia (NOLOCK) ON DIA.DiaClave = VIS.DiaClave " + fecha);
                sConsulta2.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = VIS.RUTClave AND RUT.RUTClave <> 'RUT001' " + ruta);
                sConsulta2.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta2.AppendLine("LEFT JOIN Almacen ALN (NOLOCK) ON VCH.AlmacenId = ALN.AlmacenID " + almacen);
                sConsulta2.AppendLine("LEFT JOIN AgendaVendedor AGV (NOLOCK) ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID ");
                //sConsulta2.AppendLine(pvCondicion + " AND RUT.RUTClave <> 'RUT001' ");
                sConsulta2.AppendLine("AND AGV.ClienteClave IS NULL ");
                sConsulta2.AppendLine("GROUP BY VIS.RutClave, VIS.VendedorId, VIS.DiaClave ");
                sConsulta2.AppendLine("UNION ");
                sConsulta2.AppendLine("SELECT VIS.RutClave, VIS.VendedorId, VIS.DiaClave, ");
                sConsulta2.AppendLine("0 AS VISITADOS, 0 AS NOVISITADOS, COUNT(DISTINCT VIS.ClienteClave) AS SINVENTA ");
                sConsulta2.AppendLine("FROM Visita VIS (NOLOCK) ");
                sConsulta2.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId " + vendedor);
                sConsulta2.AppendLine("INNER JOIN Dia (NOLOCK) ON DIA.DiaClave = VIS.DiaClave " + fecha);
                sConsulta2.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON RUT.RUTClave = VIS.RUTClave AND RUT.RUTClave <> 'RUT001' " + ruta);
                sConsulta2.AppendLine("INNER JOIN VENCentroDistHist VCH (NOLOCK) ON VCH.VendedorId = VEN.VendedorID AND Dia.FechaCaptura BETWEEN VCH.VCHFechaInicial AND VCH.FechaFinal ");
                sConsulta2.AppendLine("LEFT JOIN TransProd TRP (NOLOCK) ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave AND TRP.Tipo = 1 AND TRP.TipoFase <> 0 ");
                sConsulta2.AppendLine("LEFT JOIN Almacen ALN (NOLOCK) ON VCH.AlmacenId = ALN.AlmacenID " + almacen);
                sConsulta2.AppendLine("LEFT JOIN AgendaVendedor AGV (NOLOCK) ON AGV.DiaClave = VIS.DiaClave AND AGV.ClienteClave = VIS.ClienteClave AND AGV.RUTClave = VIS.RUTClave AND AGV.VendedorId = VIS.VendedorID ");
                //sConsulta2.AppendLine(pvCondicion + " AND RUT.RUTClave <> 'RUT001' ");
                sConsulta2.AppendLine("AND AGV.ClienteClave IS NULL AND TRP.TransProdID IS NULL ");
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

                report.labelfechaheader.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.labelrutasheader.Text = RutasSplit;

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK)";

                Connection.Open();
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.xrPictureBox1.Image = Image.FromStream(mStream);
                report.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                Connection.Close();
                //ReportHeader
                report.headerlabelcedis.DataBindings.Add("Text", report.DataSource, "CEDI");
                report.labelvendedorheader.DataBindings.Add("Text", report.DataSource, "Vendedor");

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
                KilometrajeString.AppendLine(pvCondicionKm + " AND RUT.RUTClave <> 'RUT001' ORDER BY Fecha ASC ");
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