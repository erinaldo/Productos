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
using DevExpress.DataAccess.Sql;
using Microsoft.Ajax.Utilities;

namespace eRoute.Models.ReportesModels
{
    public class DiarioActividadesVit
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        report_PrincipalVit report = new report_PrincipalVit();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string pvCondicion1, string RutasSplit, string FechaInicial, string FechaFinal, string NomCEDI)
        {
            String searchString = "between";
            int startIndex = pvCondicion1.IndexOf(searchString);
            String CondicionFechas = pvCondicion1.Substring(startIndex, pvCondicion1.Length - startIndex);

            try
            {
                //DIARIODEACTIVIDADES
                #region consultaPrincipal
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpDiario_1')) IS NOT NULL DROP TABLE #TmpDiario_1 ");
                sConsulta.AppendLine("SELECT * INTO #TmpDiario_1 FROM (SELECT ALM.Clave AS ALMClave, ALM.Nombre AS ALMNombre, VEN.Nombre AS VENNombre, RUT.RUTClave, RUT.Descripcion AS RUTDescripcion, SEC.Orden AS SECOrden, cli.Clave AS clienteclave, cli.clienteClave AS clienteclaver, CLI.RazonSocial AS CLIRazonSocial, VIS.FueraFrecuencia, VIS.CodigoLeido, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.VisitaClave, CASE WHEN VEN.JornadaTrabajo = 1 THEN ISNULL(VEJ.VEJFechaInicial, VIS.FechaHoraInicial) ELSE VIS.FechaHoraInicial END AS HoraInicialJornada, CASE WHEN VEN.JornadaTrabajo = 1 THEN ISNULL(VEJ.FechaFinal, VIS.FechaHoraFinal) ELSE VIS.FechaHoraFinal END AS HoraFinalJornada FROM Visita VIS (NOLOCK) INNER JOIN Vendedor VEN (NOLOCK) ON VIS.VendedorId = VEN.VendedorId LEFT JOIN VendedorJornada VEJ (NOLOCK) ON VEN.VendedorId = VEJ.VendedorId AND VIS.DiaClave = VEJ.DiaClave AND VEJ.DiaClave IS NOT NULL LEFT JOIN (SELECT DISTINCT DiaClave, VendedorId, RUTClave, ClienteClave, ClaveCEDI, frecuenciaclave FROM AgendaVendedor (NOLOCK)) AGV ON VIS.DiaClave = AGV.DiaClave AND VIS.VendedorId = AGV.VendedorId AND VIS.RutClave = AGV.RutClave AND VIS.ClienteClave = AGV.ClienteClave INNER JOIN vencentrodisthist VENCEN (NOLOCK) ON vis.fechahorainicial BETWEEN vencen.vchfechainicial AND vencen.fechafinal AND VENCEN.vendedorid=Ven.vendedorid INNER JOIN Almacen ALM (NOLOCK) ON VENCen.almacenid = ALM.almacenid INNER JOIN Ruta RUT (NOLOCK) ON VIS.RUTClave = RUT.RUTClave INNER JOIN Cliente CLI (NOLOCK) ON VIS.ClienteClave = CLI.ClienteClave LEFT JOIN Secuencia SEc (NOLOCK) ON SEc.RUTClave = RUT.RUTClave AND SEc.ClienteClave = CLI.ClienteClave AND agv.frecuenciaclave=sec.frecuenciaclave ");
                //sConsulta.AppendLine("WHERE VEN.VendedorId = '078' AND CONVERT(DATETIME, CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 112)) BETWEEN '2018-02-01T00:00:00' AND '2018-02-28T00:00:00' ");
                sConsulta.AppendLine(pvCondicion + " AND CONVERT(DATETIME, CONVERT(VARCHAR(20), VIS.FechaHoraInicial, 112)) " + CondicionFechas);
                sConsulta.AppendLine(") AS t1 ");
                sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpDiario_2')) IS NOT NULL DROP TABLE #TmpDiario_2 ");
                sConsulta.AppendLine("SELECT * INTO #TmpDiario_2 FROM (SELECT Dia.FechaCaptura AS Fecha, AGV.DiaClave, AGV.ClaveCEDI, ALM.Nombre AS ALMNombre, AGV.VendedorId, VEN.Nombre AS VENNombre, AGV.RutClave, RUT.Descripcion AS RUTDescripcion, vis.ClienteClave AS AGVClienteClave FROM visita vis (NOLOCK) LEFT JOIN (SELECT DISTINCT DiaClave, ClaveCEDI, VendedorId, RUTClave, ClienteClave FROM AgendaVendedor (NOLOCK)) AGV ON agv.vendedorid=vis.vendedorid AND agv.diaclave=vis.diaclave INNER JOIN Vendedor VEN (NOLOCK) ON vis.VendedorId = VEN.VendedorId INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = vis.DiaClave LEFT JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave LEFT JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                //sConsulta.AppendLine("WHERE VEN.VendedorId = '078' AND CONVERT(DATETIME, CONVERT(VARCHAR(20), CONVERT(DATETIME, AGV.DiaClave, 103), 112)) BETWEEN '2018-02-01T00:00:00' AND '2018-02-28T00:00:00' AND vis.diaclave=CONVERT(VARCHAR(10), vis.FechaHoraInicial, 103) ");
                sConsulta.AppendLine(pvCondicion + " AND CONVERT(DATETIME, CONVERT(VARCHAR(20), CONVERT(DATETIME, AGV.DiaClave, 103), 112)) " + CondicionFechas + " AND vis.diaclave=CONVERT(VARCHAR(10), vis.FechaHoraInicial, 103) ");
                sConsulta.AppendLine(") AS t2 ");
                sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpDiario_3')) IS NOT NULL DROP TABLE #TmpDiario_3 ");
                sConsulta.AppendLine("SELECT * INTO #TmpDiario_3 FROM ( ");
                sConsulta.AppendLine("SELECT Dia.FechaCaptura AS Fecha, AGV.DiaClave, AGV.ClaveCEDI, ALM.Nombre AS ALMNombre, AGV.VendedorId, VEN.Nombre AS VENNombre, ");
                sConsulta.AppendLine("AGV.RutClave, RUT.Descripcion AS RUTDescripcion ");
                sConsulta.AppendLine("FROM (SELECT DISTINCT DiaClave, ClaveCEDI, VendedorId, RUTClave FROM AgendaVendedor (NOLOCK)) AGV ");
                sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave ");
                //sConsulta.AppendLine("WHERE VEN.VendedorId = '078' AND CONVERT(DATETIME, CONVERT(VARCHAR(20), CONVERT(DATETIME, AGV.DiaClave, 103), 112)) BETWEEN '2018-02-01T00:00:00' AND '2018-02-28T00:00:00' ");
                sConsulta.AppendLine(pvCondicion + " AND CONVERT(DATETIME, CONVERT(VARCHAR(20), CONVERT(DATETIME, AGV.DiaClave, 103), 112)) " + CondicionFechas);
                sConsulta.AppendLine(") AS t3 ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("/*CONSULTA_PRINCIPAL*/ ");
                sConsulta.AppendLine("SELECT DISTINCT * FROM ( ");
                sConsulta.AppendLine("SELECT DISTINCT ");
                sConsulta.AppendLine("CAST(FLOOR(CAST(FechaHoraInicial AS float)) AS DATETIME) AS Fecha, ALMClave + ' ' + ALMNombre AS CEDI, VENNombre AS Vendedor, ");
                sConsulta.AppendLine("RUTClave + ' ' + RUTDescripcion AS Ruta, SECOrden AS Secuencia, ClienteClave AS Clave, CLIRazonSocial AS NombreCliente, ");
                sConsulta.AppendLine("FueraDeFrecuencia = (SELECT CASE WHEN FueraFrecuencia = 1 THEN '*' ELSE '' END), ");
                sConsulta.AppendLine("ImpFueraDeFrecuencia = (SELECT CASE WHEN FueraFrecuencia = 1 THEN 1 ELSE 0 END), ");
                sConsulta.AppendLine("CodigoNoLeido = (SELECT CASE WHEN CodigoLeido = 0 THEN '*' ELSE '' END), ");
                sConsulta.AppendLine("ImpCodigoNoLeido = (SELECT CASE WHEN CodigoLeido = 0 THEN 1 ELSE 0 END), ");
                sConsulta.AppendLine("FechaHoraInicial AS HoraInicio, FechaHoraFinal AS HoraFin, DATEDIFF(s, FechaHoraInicial, FechaHoraFinal) AS SegundosVisita, ");
                sConsulta.AppendLine("(SELECT top 1 CASE WHEN COUNT(*) > 0 THEN 'SI' ELSE 'NO' END FROM TransProd TRP (NOLOCK) WHERE TRP.Tipo = 1 AND TRP.TipoFase <> 0 AND TRP.VisitaClave = TMP.VisitaClave AND TRP.ClienteClave = TMP.ClienteClaver) AS Venta, ");
                sConsulta.AppendLine("CONVERT(VARCHAR(25), ISNULL((SELECT VAD.Descripcion FROM ImproductividadVenta IMV (NOLOCK) INNER JOIN VAVDescripcion VAD (NOLOCK) ON IMV.TipoMotivo = VAD.VAVClave WHERE IMV.VisitaClave = TMP.VisitaClave AND VAD.VARCodigo = 'MOTIMPRO' AND VAD.VADTipoLenguaje = 'EM'), '')) AS Concepto, ");
                sConsulta.AppendLine("(SELECT SUM(TRP.Total) FROM TransProd TRP (NOLOCK) WHERE TRP.Tipo = 1 AND TRP.TipoFase <> 0 AND TRP.VisitaClave = TMP.VisitaClave AND TRP.ClienteClave = TMP.ClienteClaver) AS TotalVenta, HoraInicialJornada, HoraFinalJornada ");
                sConsulta.AppendLine("FROM #TmpDiario_1 TMP ");
                sConsulta.AppendLine("GROUP BY CONVERT(VARCHAR(10), FechaHoraInicial, 103), ALMClave, ALMNombre, VENNombre, RUTClave, RUTDescripcion, SECOrden, ClienteClave, ClienteClaver, CLIRazonSocial, ");
                sConsulta.AppendLine("FueraFrecuencia, CodigoLeido, FechaHoraInicial, FechaHoraFinal, VisitaClave, HoraInicialJornada, HoraFinalJornada ");
                sConsulta.AppendLine(") principal ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("/*CONSULTA_tOTALES*/ ");
                sConsulta.AppendLine("LEFT JOIN ( ");
                sConsulta.AppendLine("SELECT DISTINCT CAST(FLOOR(CAST(TMP.Fecha AS float)) AS DATETIME) AS Fecha2, TMP.ClaveCEDI + ' ' + TMP.ALMNombre AS CEDI2, TMP.VENNombre AS Vendedor2, TMP.RutClave + ' ' + TMP.RUTDescripcion AS Ruta2, TMP.AGVClienteClave, CASE WHEN VIS.CodigoLeido = 0 THEN VIS.ClienteClave ELSE NULL END AS CodigoNoLeido2, CASE WHEN VIS.FueraFrecuencia = 0 THEN VIS.ClienteClave ELSE NULL END AS VISClienteClave, CASE WHEN VIS.FueraFrecuencia = 1 THEN VIS.ClienteClave ELSE NULL END AS VISClienteClaveFF, CASE WHEN VIS.FueraFrecuencia = 0 THEN (CASE WHEN TRP.TransProdId IS NULL THEN TRP.TransProdId ELSE VIS.ClienteClave END) ELSE NULL END AS VTAClienteClave, CASE WHEN VIS.FueraFrecuencia = 1 THEN (CASE WHEN TRP.TransProdId IS NULL THEN TRP.TransProdId ELSE VIS.ClienteClave END) ELSE NULL END AS VTAClienteClaveFF ");
                sConsulta.AppendLine("FROM #TmpDiario_2 TMP LEFT JOIN Visita VIS (NOLOCK) ON TMP.DiaClave = VIS.DiaClave AND TMP.AGVClienteClave = VIS.ClienteClave AND TMP.VendedorId = VIS.VendedorId AND TMP.RutClave = VIS.RutClave LEFT JOIN TransProd TRP (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave AND trp.tipo=1 AND trp.tipofase<>0 ");
                sConsulta.AppendLine(") totales ON principal.Clave = totales.AGVClienteClave AND principal.Fecha = totales.Fecha2 ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("/*CONSULTA_CUOTAS*/ ");
                sConsulta.AppendLine("LEFT JOIN ( ");
                sConsulta.AppendLine("SELECT DISTINCT CAST(FLOOR(CAST(TMP.Fecha AS float)) AS DATETIME) AS Fecha3, ClaveCEDI + ' ' + ALMNombre AS CEDI3, VENNombre AS Vendedor3, ");
                sConsulta.AppendLine("RUTClave + ' ' + RUTDescripcion AS Ruta3, SUM(CVE.Minimo) AS Meta, SUM(CUC.Cantidad) AS Acumulado, ");
                sConsulta.AppendLine("SUM( CVE.Minimo - CUC.Cantidad ) AS Diferencia, ");
                sConsulta.AppendLine("MAX(CASE WHEN DATEDIFF(d, GETDATE(), CUO.FechaFin) < 0 THEN 0 ELSE DATEDIFF(d, GETDATE(), CUO.FechaFin) END) AS RestoDias ");
                sConsulta.AppendLine("FROM #TmpDiario_3 TMP ");
                sConsulta.AppendLine("INNER JOIN CuoVen CUV (NOLOCK) ON TMP.VendedorId = CUV.VendedorId AND CUV.Estado = 1 ");
                sConsulta.AppendLine("INNER JOIN CUOVendedor CVE (NOLOCK) ON CUV.CUOClave = CVE.CUOClave AND CVE.Tipo= 2 AND CVE.Estado = 1 ");
                sConsulta.AppendLine("INNER JOIN Cuota CUO (NOLOCK) ON CUV.CUOClave = CUO.CUOClave AND CUO.Estado = 1 AND CUO.Baja = 0 AND TMP.Fecha BETWEEN CUO.FechaInicio AND CUO.FechaFin ");
                sConsulta.AppendLine("INNER JOIN CuotaCumplida CUC (NOLOCK) ON CUO.CUOClave = CUC.CUOClave AND CUV.VendedorId = CUC.VendedorId ");
                sConsulta.AppendLine("GROUP BY CAST(FLOOR(CAST(TMP.Fecha AS float)) AS DATETIME), ClaveCEDI + ' ' + ALMNombre, VENNombre, RUTClave + ' ' + RUTDescripcion ");
                sConsulta.AppendLine(") cuotas ON totales.Fecha2 = cuotas.Fecha3 ");
                sConsulta.AppendLine("ORDER BY principal.HoraInicio, principal.Clave ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("DROP TABLE #TmpDiario_1 ");
                sConsulta.AppendLine("DROP TABLE #TmpDiario_2 ");
                sConsulta.AppendLine("DROP TABLE #TmpDiario_3 ");

                QueryString = "";
                QueryString = sConsulta.ToString();
                #endregion
                List<DiarioActVit> Prncipal = Connection.Query<DiarioActVit>(QueryString, null, null, true, 600).ToList();
                List<DiarioActVit> UnoGru = new List<DiarioActVit>();

                var SubUno = (from A in Prncipal
                              select A).DistinctBy(s => s.HoraInicio).ToList();

                var NomVendedores = (from A in Prncipal
                                     select A.Vendedor).Distinct().ToList();

                string cadVendedores = "";
                foreach (var item in NomVendedores)
                {
                    cadVendedores += item;
                }

                //var AgruparTotales = (from grup in SubUno group grup by grup.Fecha INTO g WHERE g.COUNT() > 1 orderby g.Key ascending
                // select new
                // {
                // Dia = g.Key, 
                // cantidad = g.COUNT(), 
                // AGV = (from l in g select l.AGVClienteClave).DISTINCT().COUNT(), 
                // VisVTA = (from l in g WHERE l.VTAClienteClave != null select l.VTAClienteClave).DISTINCT().COUNT(), 
                // });

                var agrup_1 = (from gr in SubUno group gr by new { gr.Vendedor } into grupo select grupo);//.DISTINCT();

                foreach (var gCedi in agrup_1)
                {
                    var agrup_2 = (from gr in gCedi group gr by new { gr.Fecha } into grupo select grupo);

                    foreach (var gVendedor in agrup_2)
                    {
                        var agrup_3 = (from gr in gVendedor group gr by new { gr.Vendedor } into grupo select grupo);

                        foreach (var gRuta in agrup_3)
                        {
                            var agrup_4 = (from gr in gRuta group gr by new { gr.Ruta } into grupo select grupo);

                            foreach (var item in agrup_4)
                            {
                                //var agrup_5 = (from gr in gHora group gr by new { gr.HoraInicialJornada } into grupo select grupo);

                                //foreach (var item in agrup_5)
                                //{
                                    foreach (var objAgrupado in item)
                                    {
                                        UnoGru.Add(new DiarioActVit
                                        {
                                            //PRINCIPAL
                                            Fecha = objAgrupado.Fecha,
                                            CEDI = objAgrupado.CEDI,
                                            Vendedor = objAgrupado.Vendedor,
                                            Ruta = objAgrupado.Ruta,
                                            Secuencia = objAgrupado.Secuencia,
                                            Clave = objAgrupado.Clave,
                                            NombreCliente = objAgrupado.NombreCliente,
                                            FueraDeFrecuencia = objAgrupado.FueraDeFrecuencia,
                                            ImpFueraDeFrecuencia = objAgrupado.ImpFueraDeFrecuencia,
                                            CodigoNoLeido = objAgrupado.CodigoNoLeido,
                                            ImpCodigoNoLeido = objAgrupado.ImpCodigoNoLeido,
                                            HoraInicio = objAgrupado.HoraInicio,
                                            HoraFin = objAgrupado.HoraFin,
                                            SegundosVisita = objAgrupado.SegundosVisita,
                                            Venta = objAgrupado.Venta,
                                            Concepto = objAgrupado.Concepto,
                                            TotalVenta = objAgrupado.TotalVenta,
                                            HoraInicialJornada = objAgrupado.HoraInicialJornada,
                                            HoraFinalJornada = objAgrupado.HoraFinalJornada,

                                            //SubConsulta_TOTALES
                                            Fecha2 = objAgrupado.Fecha2,
                                            CEDI2 = objAgrupado.CEDI2,
                                            Vendedor2 = objAgrupado.Vendedor2,
                                            Ruta2 = objAgrupado.Ruta2,
                                            AGVClienteClave = objAgrupado.AGVClienteClave,
                                            CodigoNoLeido2 = objAgrupado.CodigoNoLeido2,
                                            VISClienteClave = objAgrupado.VISClienteClave,
                                            VISClienteClaveFF = objAgrupado.VISClienteClaveFF,
                                            VTAClienteClave = objAgrupado.VTAClienteClave,
                                            VTAClienteClaveFF = objAgrupado.VTAClienteClaveFF,

                                            //SubConsulta_CUOTAS
                                            Fecha3 = objAgrupado.Fecha3,
                                            CEDI3 = objAgrupado.CEDI3,
                                            Vendedor3 = objAgrupado.Vendedor3,
                                            Ruta3 = objAgrupado.Ruta3,
                                            Meta = objAgrupado.Meta,
                                            Acumulado = objAgrupado.Acumulado,
                                            Diferencia = objAgrupado.Diferencia,
                                            RestoDias = objAgrupado.RestoDias,
                                            NoVisitados = 0,
                                            TotalVisitados = 0,
                                            tEficiencia_Porc = 0,
                                            tEfectividad_Porc = 0
                                        });

                                        //TotalTiempos
                                        var dif = item.LastOrDefault().HoraFinalJornada.CompareTo(item.LastOrDefault().HoraInicialJornada);
                                        var tS = UnoGru.LastOrDefault().tSegundosVisita = item.Sum(c => c.SegundosVisita);

                                        var tC = UnoGru.LastOrDefault().tClientesVis = item.Count();
                                        var tPromedioVis = UnoGru.LastOrDefault().tPromVis = tS / tC;
                                        var tiempoVis = ObtenerTiempoS(tS);
                                        var di = item.LastOrDefault().HoraFinalJornada.Subtract(item.FirstOrDefault().HoraInicialJornada);
                                        var sdf = UnoGru.LastOrDefault().CalculateJornada.Seconds;
                                        if (TimeSpan.TryParse(tiempoVis, out di))
                                        {
                                            var TiempoVisita = UnoGru.LastOrDefault().tTiempoRecorrido = di;
                                            var tiTrans = TiempoVisita.Subtract(UnoGru.LastOrDefault().CalculateJornada);
                                        
                                            UnoGru.LastOrDefault().tTiempoTransito = tiTrans;

                                            var SegundosTransito = (int)(tiTrans.TotalSeconds / item.Count());
                                            //if (SegundosTransito < 0)
                                            //    SegundosTransito *= -1;
                                            UnoGru.Last().tPromJornada = ObtenerTiempoS(SegundosTransito);
                                        }
                                        else
                                        {
                                            UnoGru.Last().tPromJornada = tiempoVis;
                                        }
                                        var s = ObtenerTiempoS(tPromedioVis);
                                        UnoGru.LastOrDefault().tPromVisTiempo = s;

                                        //subtotales
                                        var Visitados = item.GroupBy(l => l.Clave).Distinct().Count();
                                        var VisitadosVTA = item.Where(c => c.Venta == "SI").GroupBy(l => l.Clave).Distinct().Count();

                                        UnoGru.LastOrDefault().tAGVClienteClave = Visitados;
                                        UnoGru.LastOrDefault().tVTAClienteClave = VisitadosVTA;
                                        var VisitadosVTANO = Visitados - VisitadosVTA;
                                        UnoGru.LastOrDefault().tVTAClienteClaveNo = VisitadosVTANO;

                                        UnoGru.LastOrDefault().tCodigoNoLeido = item.Where(l => l.ImpCodigoNoLeido == 1).GroupBy(l => l.Clave).Distinct().Count();
                                        UnoGru.LastOrDefault().tVISClienteClave = item.GroupBy(l => l.VISClienteClave).Distinct().Count();
                                        var FueraFrec = item.Where(c => c.VISClienteClaveFF != null).GroupBy(l => l.VISClienteClaveFF).Distinct().Count();
                                        var FueraFrecVTA = item.Where(c => c.VTAClienteClaveFF != null).GroupBy(l => l.VTAClienteClaveFF).Distinct().Count();
                                        UnoGru.LastOrDefault().tVISClienteClaveFF = FueraFrec;
                                        UnoGru.LastOrDefault().tVTAClienteClaveFF = FueraFrecVTA;
                                        if (FueraFrec == 0)
                                        {
                                            UnoGru.LastOrDefault().tFueraFrec_Porc = 0;
                                        }
                                        else
                                        {
                                            UnoGru.LastOrDefault().tFueraFrec_Porc = (FueraFrecVTA / FueraFrec) * 100;
                                        }

                                        //CUOTAS
                                        UnoGru.LastOrDefault().TMeta = item.Where(c => c.Meta != 0).GroupBy(l => l.Meta).Count();
                                        UnoGru.LastOrDefault().TAcumulado = item.Where(c => c.Acumulado != 0).GroupBy(l => l.Acumulado).Count();
                                        UnoGru.LastOrDefault().TDiferencia = item.Where(c => c.Diferencia != 0).GroupBy(l => l.Diferencia).Count();
                                        UnoGru.LastOrDefault().TRestoDias = item.Where(c => c.RestoDias != 0).GroupBy(l => l.RestoDias).Count();

                                    }
                                //}
                            }
                        }
                    }
                }

                //NOVISTADOS
                #region Consulta1
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SELECT CAST(FLOOR(CAST(Dia.FechaCaptura AS float)) AS DATETIME) AS Fecha, (ALM.Clave + ' ' + ALM.Nombre) AS CEDI, VEN.Nombre AS Vendedor, (AGV.RUTClave + ' ' + RUT.Descripcion) AS Ruta, (SELECT TOP 1 ORDEN FROM SECUENCIA SEC (NOLOCK) WHERE SEC.RUTClave = AGV.RUTClave AND SEC.ClienteClave = AGV.ClienteClave AND agv.frecuenciaclave=sec.frecuenciaclave) AS Secuencia, CLI.Clave AS Clave, CLI.RazonSocial AS NombreCliente, CD.Poblacion AS Municipio, ISNULL(CD.Calle, '') + ' ' + ISNULL(CD.Numero, '') + ' ' + ISNULL(CD.NumInt, '') AS Calle FROM (SELECT DISTINCT frecuenciaclave, RUTClave, DiaClave, ClaveCEDI, VendedorId, ClienteClave FROM AgendaVendedor (NOLOCK)) AGV INNER JOIN Dia (NOLOCK) ON Dia.DiaClave = AGV.DiaClave INNER JOIN Almacen ALM (NOLOCK) ON AGV.ClaveCEDI = ALM.Clave INNER JOIN Vendedor VEN (NOLOCK) ON AGV.VendedorId = VEN.VendedorId ");
                //sConsulta.AppendLine("WHERE VEN.VendedorId = '078' AND CONVERT(DATETIME, CONVERT(VARCHAR(20), CONVERT(DATETIME, AGV.DiaClave, 103), 112)) BETWEEN '2018-02-01T00:00:00' AND '2018-02-28T00:00:00' ");
                sConsulta.AppendLine("INNER JOIN Ruta RUT (NOLOCK) ON AGV.RUTClave = RUT.RUTClave INNER JOIN Cliente CLI (NOLOCK) ON AGV.ClienteClave = CLI.ClienteClave INNER JOIN ClienteDomicilio CD (NOLOCK) ON CLI.ClienteClave=CD.ClienteClave AND CD.Tipo=2 ");
                sConsulta.AppendLine(pvCondicion + " AND CONVERT(DATETIME, CONVERT(VARCHAR(20), CONVERT(DATETIME, AGV.DiaClave, 103), 112)) " + CondicionFechas);
                sConsulta.AppendLine("AND AGV.ClienteClave NOT IN (SELECT DISTINCT ClienteClave FROM Visita VIS (NOLOCK) WHERE AGV.DiaClave = CONVERT(VARCHAR(10), vis.FechaHoraInicial, 103) AND AGV.VendedorId = VIS.VendedorId AND AGV.RUTClave = VIS.RUTClave AND AGV.ClienteClave = VIS.ClienteClave) ");
                sConsulta.AppendLine("ORDER BY SECUENCIA ");

                QueryString = "";
                QueryString = sConsulta.ToString();
                #endregion
                List<NoVisitadosVit> Dos = Connection.Query<NoVisitadosVit>(QueryString, null, null, true, 600).ToList();
                List<NoVisitadosVit> DosGru = new List<NoVisitadosVit>();
                List<NoVisitadosVit> DosAux = new List<NoVisitadosVit>();

                var SubDos = (from A in Dos
                              select A).ToList();

                var agrup_NoVis = (from gr in SubDos group gr by new { gr.Vendedor } into grupo select grupo);
                foreach (var gFecha in agrup_NoVis)
                {
                    var agrup_Fec = (from gr in gFecha group gr by new { gr.Fecha } into grupo select grupo);

                    foreach (var item in agrup_Fec)
                    {
                        var agrup_Ven = (from gr in item group gr by new { gr.Vendedor } into grupo select grupo);
                        foreach (var gRuta in agrup_Ven)
                        {
                            var agrup_Rut = (from gr in gRuta group gr by new { gr.Ruta } into grupo select grupo);
                            foreach (var item1 in agrup_Rut)
                            {
                                foreach (var objAgrupado in item1)
                                {
                                    DosAux.Add(new NoVisitadosVit
                                    {
                                        Ruta = objAgrupado.Ruta,
                                        Fecha = objAgrupado.Fecha

                                    });
                                    DosAux.LastOrDefault().cantidad = item1.Count();
                                }
                            }
                        }
                    }
                }

                var count = UnoGru.Count;
                for (var i = 0; i < count; i++)
                {
                    var item = UnoGru[i];

                    for (var j = 0; j < DosAux.Count; j++)
                    {

                        if (item.Ruta == DosAux[j].Ruta && item.Fecha == DosAux[j].Fecha)
                        {
                            item.NoVisitados = DosAux[j].cantidad;
                        }
                        item.TotalVisitados = item.NoVisitados + item.tAGVClienteClave;

                    }
                    if (DosAux.Count <= 0)
                    {
                        item.TotalVisitados = item.NoVisitados + item.tAGVClienteClave;
                    }
                    var TTVisi = item.tAGVClienteClave;
                    var TTVisiVTA = item.tVTAClienteClave;
                    var TTVisitados = item.TotalVisitados;
                    var porEfici = (((double)TTVisi / (double)TTVisitados) * 100);

                    item.tEficiencia_Porc = Math.Round(porEfici, 2);
                    item.tEfectividad_Porc = Math.Round(((double)TTVisiVTA / (double)TTVisitados * 100), 2);
                }

                agrup_NoVis = (from gr in SubDos group gr by new { gr.Vendedor } into grupo select grupo);
                foreach (var gFecha in agrup_NoVis)
                {
                    var agrup_Fec = (from gr in gFecha group gr by new { gr.Fecha } into grupo select grupo);

                    foreach (var item in agrup_Fec)
                    {
                        var agrup_Ven = (from gr in item group gr by new { gr.Vendedor } into grupo select grupo);
                        foreach (var gRuta in agrup_Ven)
                        {
                            var agrup_Rut = (from gr in gRuta group gr by new { gr.Ruta } into grupo select grupo);
                            foreach (var item1 in agrup_Rut)
                            {
                                foreach (var objAgrupado in item1)
                                {
                                    DosGru.Add(new NoVisitadosVit
                                    {
                                        Fecha = objAgrupado.Fecha,
                                        CEDI = objAgrupado.CEDI,
                                        Vendedor = objAgrupado.Vendedor,
                                        Ruta = objAgrupado.Ruta,
                                        Secuencia = objAgrupado.Secuencia,
                                        Clave = objAgrupado.Clave,
                                        NombreCliente = objAgrupado.NombreCliente,
                                        Municipio = objAgrupado.Municipio,
                                        Calle = objAgrupado.Calle,
                                    });
                                }
                            }
                        }
                    }
                }


                if (Prncipal.Count != 0)
                {
                    report_PrincipalVit report = new report_PrincipalVit();

                    report.DataSource = UnoGru;

                    //grouheader5 FECHA
                    GroupField groupFecha = new GroupField("Fecha");
                    report.GroupHeader5.GroupFields.Add(groupFecha);
                    report.Gpo_Fecha.DataBindings.Add("Text", report.DataSource, "Fecha", "{0:dd/MM/yyyy}");

                    //grouheader4 CEDI
                    GroupField groupCEDI = new GroupField("CEDI");
                    report.GroupHeader4.GroupFields.Add(groupCEDI);
                    report.Gpo_CEDI.DataBindings.Add("Text", report.DataSource, "CEDI");

                    //grouheader3 Vendedor
                    GroupField groupVendedor = new GroupField("Vendedor");
                    report.GroupHeader3.GroupFields.Add(groupVendedor);
                    report.Gpo_Vendedor.DataBindings.Add("Text", report.DataSource, "Vendedor");

                    //grouheader2 Ruta
                    GroupField groupRuta = new GroupField("Ruta");
                    report.GroupHeader2.GroupFields.Add(groupRuta);
                    report.Gpo_Ruta.DataBindings.Add("Text", report.DataSource, "Ruta");
                    report.Gpo_JornadaInicio.DataBindings.Add("Text", report.DataSource, "HoraInicialJornada", "{0:HH:mm:ss}");
                    ////grouheader1 HoraInicioJoranda
                    //GroupField groupInicioJornada = new GroupField("HoraInicialJornada");
                    //report.GroupHeader1.GroupFields.Add(groupInicioJornada);
                    //report.Gpo_JornadaInicio.DataBindings.Add("Text", report.DataSource, "HoraInicialJornada", "{0:HH:mm:ss}");

                    report.L_Secuencia.DataBindings.Add("Text", null, "Secuencia");
                    report.L_NumCliente.DataBindings.Add("Text", null, "Clave");
                    report.L_Cliente.DataBindings.Add("Text", null, "NombreCliente");
                    report.L_FueraFrecuencia.DataBindings.Add("Text", null, "FueraDeFrecuencia");
                    report.L_NoLeido.DataBindings.Add("Text", null, "CodigoNoLeido");
                    report.L_VisitaInicio.DataBindings.Add("Text", null, "HoraInicio", "{0:HH:mm:ss}");
                    report.L_VisitaFin.DataBindings.Add("Text", null, "HoraFin", "{0:HH:mm:ss}");
                    report.L_Venta.DataBindings.Add("Text", null, "Venta");
                    report.L_Improductividad.DataBindings.Add("Text", null, "Concepto");
                    report.L_TotalVta.DataBindings.Add("Text", null, "TotalVenta", "{0:$#, ###, ##0.00}");

                    report.Sub1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("Fecha", null, "Fecha"));
                    report.Sub1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("Ruta", null, "Ruta"));
                    if (Dos.Count != 0)
                    {
                        report_SubNoVisitadosVit subReport1 = new report_SubNoVisitadosVit();
                        subReport1.DataSource = DosGru;

                        GroupField groupRutaSub = new GroupField("Ruta");
                        subReport1.GroupHeader1.GroupFields.Add(groupRutaSub);
                        subReport1.Rutas.DataBindings.Add("Text", subReport1.DataSource, "Ruta");

                        //subReport1.FilterString = "[Ruta] = [Parameters.Ruta]";
                        //ParameterBinding ParameterBinding1 = new ParameterBinding("Ruta", report.DataSource, "Ruta");
                        //report.Sub1.ParameterBindings.Add(ParameterBinding1);

                        //subReport1.FilterString = "[Fecha] = [Parameters.Fecha]";
                        //ParameterBinding1 = new ParameterBinding("Fecha", report.DataSource, "Fecha");
                        //report.Sub1.ParameterBindings.Add(ParameterBinding1);

                        subReport1.L_Secuencia.DataBindings.Add("Text", null, "Secuencia");
                        subReport1.L_Clave.DataBindings.Add("Text", null, "Clave");
                        subReport1.L_NombreCliente.DataBindings.Add("Text", null, "NombreCliente");
                        subReport1.L_Municipio.DataBindings.Add("Text", null, "Municipio");
                        subReport1.L_Calle.DataBindings.Add("Text", null, "Calle");
                        report.Sub1.ReportSource = subReport1;
                    }

                    //groupfooter
                    ////////////////////////////////TOTALES////////////////////////////////
                    report.L_TotalClientes.DataBindings.Add("Text", null, "TotalVisitados");
                    report.L_Visitados.DataBindings.Add("Text", null, "tAGVClienteClave");
                    report.L_NoVisitados.DataBindings.Add("Text", null, "NoVisitados");
                    report.L_Porc_Eficiencia.DataBindings.Add("Text", null, "tEficiencia_Porc");

                    report.L_VisitaConVenta.DataBindings.Add("Text", null, "tVTAClienteClave");
                    report.L_VisitaSinVenta.DataBindings.Add("Text", null, "tVTAClienteClaveNo");
                    report.L_TotalNoLeidos.DataBindings.Add("Text", null, "tCodigoNoLeido");
                    report.L_Porc_Efectividad.DataBindings.Add("Text", null, "tEfectividad_Porc", "{0:#0.00}");

                    report.L_FueraFrec.DataBindings.Add("Text", null, "tVISClienteClaveFF");
                    report.L_FueraFrecVenta.DataBindings.Add("Text", null, "tVTAClienteClaveFF");
                    report.L_Porc_EfecFF.DataBindings.Add("Text", null, "tFueraFrec_Porc", "{0:#0.00}");

                    ////////////////////////////////TIEMPOS////////////////////////////////
                    report.L_JornadaFin.DataBindings.Add("Text", null, "HoraFinalJornada", "{0:HH:mm:ss}");
                    
                    //report.L_TiempoRecorrido.DataBindings.Add("Text", null, "tTiempoRecorrido");
                    report.L_TiempoRecorrido.Text = UnoGru.LastOrDefault().tTiempoRecorrido.ToString();
                    //report.L_TiempoTransito.DataBindings.Add("Text", null, "tTiempoTransito");
                    report.L_TiempoTransito.Text = UnoGru.LastOrDefault().tTiempoTransito.ToString();
                    //report.L_PromedioVisita.DataBindings.Add("Text", null, "tPromVisTiempo");
                    report.L_PromedioVisita.Text = UnoGru.LastOrDefault().tPromVisTiempo.ToString();
                    //report.L_PromedioTransito.DataBindings.Add("Text", null, "tPromJornada");
                    report.L_PromedioTransito.Text = UnoGru.LastOrDefault().tPromJornada.ToString();

                    report.L_Meta.DataBindings.Add("Text", null, "tMeta");
                    report.L_Acumulado.DataBindings.Add("Text", null, "TAcumulado");
                    report.L_DifMeta.DataBindings.Add("Text", null, "TDiferencia");
                    report.L_Cuota.DataBindings.Add("Text", null, "TRestoDias");

                    ////////////////////////////////TOTALES////////////////////////////////

                    //ReportHeader
                    #region reporteDiario
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
                    string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                    byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                    MemoryStream mStream = new MemoryStream(byteArrayIn);
                    report.logo.Image = Image.FromStream(mStream);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    report.empresa.Text = NombreEmpresa;
                    report.reporte.Text = NombreReporte;

                    report.L_FechaRango.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                    report.L_CEDI.Text = NomCEDI.ToString();
                    report.L_Vendedor.Text = cadVendedores;
                    report.L_Ruta.Text = RutasSplit;
                    #endregion

                    return report;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ObtenerTiempoS(int seg)
        {
            Int32 horas = Math.Abs((seg / 3600));
            Int32 minutos = Math.Abs(((seg - horas * 3600) / 60));
            Int32 segundos = Math.Abs(seg - (horas * 3600 + minutos * 60));
            string sHoras;
            string sMinutos;
            string sSegundos;
            if (horas < 10)
            {
                sHoras = "0" + horas;
            }
            else
            {
                sHoras = horas.ToString();
            }
            if (minutos < 10)
            {
                sMinutos = "0" + minutos;
            }
            else
            {
                sMinutos = minutos.ToString();
            }
            if (segundos < 10)
            {
                sSegundos = "0" + segundos;
            }
            else
            {
                sSegundos = segundos.ToString();
            }

            return sHoras + ":" + sMinutos + ":" + sSegundos;

            //if (seg < 0)
            //{
            //    seg *= (-1);
            //}

            //Int32 tsegundos = Convert.ToInt32(seg);
            //Int32 horas = (tsegundos / 3600);
            //Int32 minutos = ((tsegundos - horas * 3600) / 60);
            //Int32 segundos2 = tsegundos - (horas * 3600 + minutos * 60);
            //Int32 dias = 1;
            //Int32 mes = 1;
            //Int32 anio = 1;

            //if (horas > 24)
            //{
            //    dias = (horas / 24);
            //    horas -= (dias * 24);
            //}
            //if (dias > 30)
            //{
            //    mes = (dias / 30);
            //    dias -= (mes - 30);
            //}
            //if (mes > 12)
            //{
            //    anio = (mes / 12);
            //    mes -= (anio * 12);
            //}

            //DateTime da = new DateTime(anio, mes, dias, horas, minutos, segundos2, 0);

            //var s = String.Format("{0:HH:mm:ss}", da);
            //return s;
        }
    }

    class DiarioActVit
    {
        //PRINCIPAL
        public DateTime Fecha { get; set; }
        public string CEDI { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public string Secuencia { get; set; }
        public string Clave { get; set; }
        public string NombreCliente { get; set; }
        public string FueraDeFrecuencia { get; set; }
        public int ImpFueraDeFrecuencia { get; set; }
        public string CodigoNoLeido { get; set; }
        public int ImpCodigoNoLeido { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int SegundosVisita { get; set; }
        public string Venta { get; set; }
        public string Concepto { get; set; }
        public Decimal TotalVenta { get; set; }
        public DateTime HoraInicialJornada { get; set; }
        public DateTime HoraFinalJornada { get; set; }

        //PRINCIPAL_subtotales
        public TimeSpan CalculateJornada { get { return HoraFinalJornada.Subtract(HoraInicialJornada); } }
        public TimeSpan tTiempoRecorrido { get; set; }
        public TimeSpan tTiempoTransito { get; set; }
        public int tSegundosVisita { get; set; }
        public int tClientesVis { get; set; }
        public int tPromVis { get; set; }
        public string tPromVisTiempo { get; set; }
        public string tPromJornada { get; set; }

        //public int tAGV { get; set; }

        //TOTALES
        public DateTime Fecha2 { get; set; }
        public string CEDI2 { get; set; }
        public string Vendedor2 { get; set; }
        public string Ruta2 { get; set; }
        public string AGVClienteClave { get; set; }
        public string CodigoNoLeido2 { get; set; }
        public string VISClienteClave { get; set; }
        public string VISClienteClaveFF { get; set; }
        public string VTAClienteClave { get; set; }
        public string VTAClienteClaveFF { get; set; }
        //TOTALES_subtotales
        public int tAGVClienteClave { get; set; }
        //public int tAGVClienteClave1 { get; set; }
        public int tCodigoNoLeido { get; set; }
        public int tVISClienteClave { get; set; }
        public int tVISClienteClaveFF { get; set; }
        public int tVTAClienteClave { get; set; }
        public int tVTAClienteClaveNo { get; set; }
        public int tVTAClienteClaveFF { get; set; }


        //CUOTAS
        public DateTime Fecha3 { get; set; }
        public string CEDI3 { get; set; }
        public string Vendedor3 { get; set; }
        public string Ruta3 { get; set; }
        public Decimal Meta { get; set; }
        public Decimal Acumulado { get; set; }
        public Decimal Diferencia { get; set; }
        public Decimal RestoDias { get; set; }

        //CUOTAS_subtotales
        public int TMeta { get; set; }
        public int TAcumulado { get; set; }
        public int TDiferencia { get; set; }
        public int TRestoDias { get; set; }

        //TOTALES
        public long NoVisitados { get; set; }
        public long TotalVisitados { get; set; }
        public Double tEficiencia_Porc { get; set; }
        public Double tEfectividad_Porc { get; set; }
        public Double tFueraFrec_Porc { get; set; }
    }

    class NoVisitadosVit
    {
        public DateTime Fecha { get; set; }
        public string CEDI { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public string Secuencia { get; set; }
        public string Clave { get; set; }
        public string NombreCliente { get; set; }
        public string Municipio { get; set; }
        public string Calle { get; set; }
        //TOTALES
        public long cantidad { get; set; }
    }
}