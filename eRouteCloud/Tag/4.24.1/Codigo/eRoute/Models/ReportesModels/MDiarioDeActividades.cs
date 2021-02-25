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
using System.Web.WebPages;

namespace eRoute.Models.ReportesModels
{
    public class MDiarioDeActividades
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        report_Principal report = new report_Principal();
        DateTime fInicio;
        DateTime fFin;

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreObjeto, string NombreCEDIS, string DateStatus, string CEDIS, string Rutas, string Vendedores, string FechaInicial, string FechaFinal, bool FiltroReporte)
        {
            try
            {
                ReportGetCondition filter = new ReportGetCondition();
                Vendedores = (Vendedores == "" ? "null" : "'" + Vendedores + "'");
                Rutas = (Rutas == "" ? "null" : "'" + Rutas + "'");
                fInicio = DateTime.Parse(FechaInicial);
                FechaInicial = fInicio.Date.ToString("yyyy-MM-dd");
                FechaInicial = (FechaInicial == "" ? "null" : "'" + FechaInicial + "'");
                fFin = DateTime.Parse(FechaFinal);
                FechaFinal = fFin.Date.ToString("yyyy-MM-dd");

                //DIARIODEACTIVIDADES
                #region consultaPrincipal
                StringBuilder sConsulta = new StringBuilder();

                sConsulta.AppendLine("if (select object_id('tempdb..#TmpDiario_1')) is not null drop table #TmpDiario_1 ");
                sConsulta.AppendLine("select * into #TmpDiario_1 from( select ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, VEN.Nombre as VENNombre, RUT.RUTClave, RUT.Descripcion as RUTDescripcion, AGV.Orden as SECOrden, cli.Clave as clienteclave, cli.clienteClave as clienteclaver, CLI.RazonSocial as CLIRazonSocial, VIS.FueraFrecuencia, VIS.CodigoLeido, VIS.FechaHoraInicial, VIS.FechaHoraFinal, VIS.VisitaClave, case when VEN.JornadaTrabajo = 1 then isnull(VEJ.VEJFechaInicial,VIS.FechaHoraInicial) else VIS.FechaHoraInicial end as HoraInicialJornada, case when VEN.JornadaTrabajo = 1 then isnull(VEJ.FechaFinal,VIS.FechaHoraFinal) else VIS.FechaHoraFinal end as HoraFinalJornada from Visita VIS inner join Vendedor VEN on VIS.VendedorId = VEN.VendedorId left join VendedorJornada VEJ on VEN.VendedorId = VEJ.VendedorId and VIS.DiaClave = VEJ.DiaClave AND VEJ.DiaClave is not null LEFT join (select distinct DiaClave, VendedorId, RUTClave, ClienteClave, ClaveCEDI, frecuenciaclave, Orden from AgendaVendedor) AGV on VIS.DiaClave = AGV.DiaClave and VIS.VendedorId = AGV.VendedorId and VIS.RutClave = AGV.RutClave and VIS.ClienteClave = AGV.ClienteClave INNER JOIN vencentrodisthist  VENCEN    on vis.fechahorainicial between vencen.vchfechainicial and vencen.fechafinal and VENCEN.vendedorid=Ven.vendedorid inner join Almacen ALM on VENCen.almacenid = ALM.almacenid inner join Ruta RUT on VIS.RUTClave = RUT.RUTClave inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave LEFT join   Secuencia SEc on SEc.RUTClave = RUT.RUTClave and SEc.ClienteClave = CLI.ClienteClave and agv.frecuenciaclave=sec.frecuenciaclave ");
                sConsulta.AppendLine("WHERE ((VEN.VendedorId = " + (Rutas == "null" ? Vendedores : Rutas) + ") OR " + (Rutas == "null" ? Vendedores : Rutas) + " IS NULL) AND ((convert(datetime,Convert(varchar(20),VIS.FechaHoraInicial,112)) BETWEEN " + FechaInicial + " AND '" + FechaFinal + "') OR " + FechaInicial + " IS NULL) ");
                sConsulta.AppendLine(")as t1");
                sConsulta.AppendLine("if (select object_id('tempdb..#TmpDiario_2')) is not null drop table #TmpDiario_2");
                sConsulta.AppendLine("select * into #TmpDiario_2 from( select Dia.FechaCaptura as Fecha, AGV.DiaClave, AGV.ClaveCEDI, ALM.Nombre as ALMNombre, AGV.VendedorId, VEN.Nombre as VENNombre, AGV.RutClave, RUT.Descripcion as RUTDescripcion, vis.ClienteClave as AGVClienteClave from visita vis left join (select distinct DiaClave, ClaveCEDI, VendedorId, RUTClave, ClienteClave from AgendaVendedor) AGV  on agv.vendedorid=vis.vendedorid and agv.diaclave=vis.diaclave and agv.ClienteClave = vis.ClienteClave inner join Vendedor VEN on vis.VendedorId = VEN.VendedorId inner join Dia on Dia.DiaClave = vis.DiaClave left join Almacen ALM on AGV.ClaveCEDI = ALM.Clave left join Ruta RUT on AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("WHERE ((VEN.VendedorId = " + (Rutas == "null" ? Vendedores : Rutas) + ") OR " + (Rutas == "null" ? Vendedores : Rutas) + " IS NULL) AND ((convert(datetime,Convert(varchar(20),convert(datetime, AGV.DiaClave, 103),112)) BETWEEN " + FechaInicial + " AND '" + FechaFinal + "') OR " + FechaInicial + " IS NULL) " + " and vis.diaclave=convert(varchar(10), vis.FechaHoraInicial, 103)");
                sConsulta.AppendLine(")as t2 ");
                sConsulta.AppendLine("if (select object_id('tempdb..#TmpDiario_3')) is not null drop table #TmpDiario_3");
                sConsulta.AppendLine("select * into #TmpDiario_3 from( ");
                sConsulta.AppendLine("select Dia.FechaCaptura as Fecha, AGV.DiaClave, AGV.ClaveCEDI, ALM.Nombre as ALMNombre, AGV.VendedorId, VEN.Nombre as VENNombre, ");
                sConsulta.AppendLine("AGV.RutClave, RUT.Descripcion as RUTDescripcion ");
                sConsulta.AppendLine("from (select distinct DiaClave, ClaveCEDI, VendedorId, RUTClave from AgendaVendedor) AGV ");
                sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId ");
                sConsulta.AppendLine("inner join Dia on Dia.DiaClave = AGV.DiaClave ");
                sConsulta.AppendLine("inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave ");
                sConsulta.AppendLine("inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave ");
                sConsulta.AppendLine("WHERE ((VEN.VendedorId = " + (Rutas == "null" ? Vendedores : Rutas) + ") OR " + (Rutas == "null" ? Vendedores : Rutas) + " IS NULL) AND ((convert(datetime,Convert(varchar(20),convert(datetime, AGV.DiaClave, 103),112)) BETWEEN " + FechaInicial + " AND '" + FechaFinal + "') OR " + FechaInicial + " IS NULL) ");
                sConsulta.AppendLine(")as t3");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("/*CONSULTA_PRINCIPAL*/");
                sConsulta.AppendLine("select distinct * from (");
                sConsulta.AppendLine("select distinct");
                sConsulta.AppendLine("cast(floor(cast(FechaHoraInicial as float)) as datetime) as Fecha, ALMClave + ' ' + ALMNombre as CEDI, VENNombre as Vendedor, ");
                sConsulta.AppendLine("RUTClave + ' ' + RUTDescripcion as Ruta, SECOrden as Secuencia, ClienteClaveR as ClienteClave, ClienteClave as Clave, CLIRazonSocial as NombreCliente, ");
                sConsulta.AppendLine("FueraDeFrecuencia = (select case when FueraFrecuencia = 1 then '*' else '' end), ");
                sConsulta.AppendLine("ImpFueraDeFrecuencia = (select case when FueraFrecuencia = 1 then 1 else 0 end), ");
                sConsulta.AppendLine("CodigoNoLeido = (select case when CodigoLeido = 0 then '*' else '' end), ");
                sConsulta.AppendLine("ImpCodigoNoLeido = (select case when CodigoLeido = 0 then 1 else 0 end), ");
                sConsulta.AppendLine("FechaHoraInicial as HoraInicio, FechaHoraFinal as HoraFin, datediff(s, FechaHoraInicial, FechaHoraFinal) as SegundosVisita, ");
                sConsulta.AppendLine("(select top 1 case when count(*) > 0 then 'SI' else 'NO' end from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClaver) as Venta, ");
                sConsulta.AppendLine("convert(varchar(25), isnull((select VAD.Descripcion from ImproductividadVenta IMV inner join VAVDescripcion VAD on IMV.TipoMotivo = VAD.VAVClave where IMV.VisitaClave = TMP.VisitaClave and VAD.VARCodigo = 'MOTIMPRO' and VAD.VADTipoLenguaje = 'EM'), '')) as Concepto, ");
                sConsulta.AppendLine("(select sum(TRP.Total) from TransProd TRP where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.VisitaClave = TMP.VisitaClave and TRP.ClienteClave = TMP.ClienteClaver) as TotalVenta, HoraInicialJornada, HoraFinalJornada  ");
                sConsulta.AppendLine("from #TmpDiario_1 TMP ");
                sConsulta.AppendLine("group by convert(varchar(10), FechaHoraInicial, 103), ALMClave, ALMNombre, VENNombre, RUTClave, RUTDescripcion, SECOrden, ClienteClave, ClienteClaver, CLIRazonSocial, ");
                sConsulta.AppendLine("FueraFrecuencia, CodigoLeido, FechaHoraInicial, FechaHoraFinal, VisitaClave, HoraInicialJornada, HoraFinalJornada ");
                sConsulta.AppendLine(") principal");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("/*CONSULTA_tOTALES*/");
                sConsulta.AppendLine("left join (");
                sConsulta.AppendLine("select distinct cast(floor(cast(TMP.Fecha as float)) as datetime) as Fecha2, TMP.ClaveCEDI + ' ' + TMP.ALMNombre as CEDI2, TMP.VENNombre as Vendedor2, TMP.RutClave + ' ' + TMP.RUTDescripcion as Ruta2, TMP.AGVClienteClave, case when VIS.CodigoLeido = 0 then VIS.ClienteClave else NULL end as CodigoNoLeido2, case when VIS.FueraFrecuencia = 0 then VIS.ClienteClave else NULL end as VISClienteClave, case when VIS.FueraFrecuencia = 1 then VIS.ClienteClave else NULL end as VISClienteClaveFF, case when VIS.FueraFrecuencia = 0 then (case when TRP.TransProdId is null then TRP.TransProdId else VIS.ClienteClave end) else NULL end as VTAClienteClave, case when VIS.FueraFrecuencia = 1 then (case when TRP.TransProdId is null then TRP.TransProdId else VIS.ClienteClave end) else NULL end as VTAClienteClaveFF ");
                sConsulta.AppendLine("from #TmpDiario_2 TMP left join Visita VIS on TMP.DiaClave = VIS.DiaClave and TMP.AGVClienteClave = VIS.ClienteClave and TMP.VendedorId = VIS.VendedorId and TMP.RutClave = VIS.RutClave left join TransProd TRP on VIS.VisitaClave = TRP.VisitaClave and trp.tipo=1 and trp.tipofase<>0");
                sConsulta.AppendLine(") totales on principal.ClienteClave = totales.AGVClienteClave and principal.Fecha = totales.Fecha2");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("/*CONSULTA_CUOTAS*/");
                sConsulta.AppendLine("left join (");
                sConsulta.AppendLine("select distinct cast(floor(cast(TMP.Fecha as float)) as datetime) as Fecha3, ClaveCEDI + ' ' + ALMNombre as CEDI3, VENNombre as Vendedor3, ");
                sConsulta.AppendLine("RUTClave + ' ' + RUTDescripcion as Ruta3, sum(CVE.Minimo) as Meta, sum(CUC.Cantidad) as Acumulado, ");
                sConsulta.AppendLine("sum( CVE.Minimo - CUC.Cantidad ) as Diferencia, ");
                sConsulta.AppendLine("max(case when datediff(d, getdate(), CUO.FechaFin) < 0 then 0 else datediff(d, getdate(), CUO.FechaFin) end) as RestoDias ");
                sConsulta.AppendLine("from #TmpDiario_3 TMP ");
                sConsulta.AppendLine("inner join CuoVen CUV on TMP.VendedorId = CUV.VendedorId and CUV.Estado = 1 ");
                sConsulta.AppendLine("inner join CUOVendedor CVE on CUV.CUOClave = CVE.CUOClave and CVE.Tipo= 2 and CVE.Estado = 1 ");
                sConsulta.AppendLine("inner join Cuota CUO on CUV.CUOClave = CUO.CUOClave and CUO.Estado = 1 and CUO.Baja = 0 and TMP.Fecha between CUO.FechaInicio and CUO.FechaFin ");
                sConsulta.AppendLine("inner join CuotaCumplida CUC on CUO.CUOClave = CUC.CUOClave AND CUV.VendedorId = CUC.VendedorId ");
                sConsulta.AppendLine("group by cast(floor(cast(TMP.Fecha as float)) as datetime), ClaveCEDI + ' ' + ALMNombre, VENNombre, RUTClave + ' ' + RUTDescripcion ");
                sConsulta.AppendLine(") cuotas on totales.Fecha2 = cuotas.Fecha3");
                sConsulta.AppendLine("order by principal.HoraInicio, principal.Clave");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("drop table #TmpDiario_1");
                sConsulta.AppendLine("drop table #TmpDiario_2");
                sConsulta.AppendLine("drop table #TmpDiario_3");

                QueryString = "";
                QueryString = sConsulta.ToString();
                #endregion
                List<DiarioActividades> Prncipal = Connection.Query<DiarioActividades>(QueryString, null, null, true, 600).ToList();
                List<DiarioActividades> UnoGru = new List<DiarioActividades>();

                var SubUno = (from A in Prncipal
                              select A).DistinctBy(s => s.HoraInicio).ToList();

                var NomVendedores = (from A in Prncipal
                                     select A.Vendedor).Distinct().ToList();

                string cadVendedores = "";
                foreach (var item in NomVendedores)
                {
                    cadVendedores += item;
                }

                var NomRuta = (from A in Prncipal
                               select A.Ruta).Distinct().ToList();

                string cadRuta = "";
                foreach (var item in NomRuta)
                {
                    cadRuta += item;
                }

                var agrup_1 = (from gr in SubUno group gr by new { gr.Vendedor } into grupo select grupo);//.Distinct();

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
                                var jornada = item.GroupBy(r => r.Ruta)
                                .Select(grp => new
                                {
                                    MinHoraInicial = grp.Min(t => t.HoraInicialJornada),
                                    MaxHoraInicial = grp.Max(t => t.HoraInicialJornada),
                                    MinHoraFinal = grp.Min(t => t.HoraFinalJornada),
                                    MaxHoraFinal = grp.Max(t => t.HoraFinalJornada)
                                }).ToList()[0];
                                
                                foreach (var objAgrupado in item)
                                {
                                    UnoGru.Add(new DiarioActividades
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
                                        HoraInicialJornada = jornada.MinHoraInicial,
                                        HoraFinalJornada = jornada.MaxHoraFinal,

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
                                    var dif = jornada.MaxHoraFinal.CompareTo(jornada.MinHoraInicial);
                                    var tS = UnoGru.Last().tSegundosVisita = item.Sum(c => c.SegundosVisita);
                                    var tC = UnoGru.Last().tClientesVis = item.Count();
                                    var tPromedioVis = UnoGru.Last().tPromVis = tS / tC;
                                    var tiempoVis = ObtenerTiempoS(tS);
                                    var di = jornada.MaxHoraFinal.Subtract(jornada.MaxHoraInicial);
                                    var sdf = UnoGru.Last().CalculateJornada.Seconds;
                                    if (TimeSpan.TryParse(tiempoVis, out di))
                                    {
                                        var TiempoVisita = UnoGru.Last().tTiempoRecorrido = di;
                                        var tiTrans = UnoGru.Last().CalculateJornada.Subtract(TiempoVisita);
                                        UnoGru.Last().tTiempoTransito = tiTrans;

                                        var SegundosTransito = (int)(tiTrans.TotalSeconds / item.Count());
                                        if (SegundosTransito > 0)
                                        {
                                            UnoGru.Last().tPromJornada = ObtenerTiempoS(SegundosTransito);
                                        }
                                    }
                                    else
                                    {
                                        UnoGru.Last().tPromJornada = tiempoVis;
                                    }
                                    var s = ObtenerTiempoS(tPromedioVis);
                                    UnoGru.Last().tPromVisTiempo = s;

                                    //subtotales
                                    var Visitados = item.Where(c => c.AGVClienteClave != null).GroupBy(l => l.AGVClienteClave).Distinct().Count();
                                    var VisitadosVTA = item.Where(c => c.VTAClienteClave != null && c.Venta == "SI" && c.TotalVenta != 0 && c.FueraDeFrecuencia.IsEmpty()).GroupBy(l => l.AGVClienteClave).Distinct().Count();

                                    UnoGru.Last().tAGVClienteClave = Visitados;
                                    UnoGru.Last().tVTAClienteClave = VisitadosVTA;
                                    var VisitadosVTANO = Visitados - VisitadosVTA;
                                    UnoGru.Last().tVTAClienteClaveNo = VisitadosVTANO;

                                    var codigosNoLeidos = item.Where(c => c.CodigoNoLeido == "*").Count();
                                    UnoGru.Last().tCodigoNoLeido = codigosNoLeidos;
                                    UnoGru.Last().tVISClienteClave = item.GroupBy(l => l.VISClienteClave).Distinct().Count();

                                    var FueraFrec = item.Where(c => c.FueraDeFrecuencia == "*").Count();
                                    var FueraFrecVTA = item.Where(c => c.FueraDeFrecuencia == "*" && c.Venta == "SI").Count();
                                    UnoGru.Last().tVISClienteClaveFF = FueraFrec;
                                    UnoGru.Last().tVTAClienteClaveFF = FueraFrecVTA;
                                    if (FueraFrec == 0)
                                    {
                                        UnoGru.Last().tFueraFrec_Porc = 0;
                                    }
                                    else
                                    {
                                        double fueraFrec_Por = (double)FueraFrecVTA / FueraFrec * 100;
                                        UnoGru.Last().tFueraFrec_Porc = fueraFrec_Por;
                                    }

                                    //CUOTAS
                                    UnoGru.Last().TMeta = item.Where(c => c.Meta != 0).GroupBy(l => l.Meta).Count();
                                    UnoGru.Last().TAcumulado = item.Where(c => c.Acumulado != 0).GroupBy(l => l.Acumulado).Count();
                                    UnoGru.Last().TDiferencia = item.Where(c => c.Diferencia != 0).GroupBy(l => l.Diferencia).Count();
                                    UnoGru.Last().TRestoDias = item.Where(c => c.RestoDias != 0).GroupBy(l => l.RestoDias).Count();
                                }
                                //}
                            }
                        }
                    }
                }

                //NOVISTADOS
                #region Consulta1
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("select cast(floor(cast(Dia.FechaCaptura as float)) as datetime) as Fecha, (ALM.Clave + ' ' + ALM.Nombre) as CEDI, VEN.Nombre as Vendedor, (AGV.RUTClave + ' ' + RUT.Descripcion) as Ruta,  AGV.Orden as Secuencia,  CLI.Clave as Clave, CLI.RazonSocial as NombreCliente  from (SELECT Distinct frecuenciaclave, RUTClave, DiaClave, ClaveCEDI, VendedorId, ClienteClave, Orden FROM  AgendaVendedor ) AGV inner join Dia on Dia.DiaClave = AGV.DiaClave inner join Almacen ALM on AGV.ClaveCEDI = ALM.Clave inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId inner join Ruta RUT on AGV.RUTClave = RUT.RUTClave inner join Cliente CLI on AGV.ClienteClave = CLI.ClienteClave  ");
                sConsulta.AppendLine("WHERE ((VEN.VendedorId = " + (Rutas == "null" ? Vendedores : Rutas) + ") OR " + (Rutas == "null" ? Vendedores : Rutas) + " IS NULL) AND ((convert(datetime,Convert(varchar(20),convert(datetime, AGV.DiaClave, 103),112)) BETWEEN " + FechaInicial + " AND '" + FechaFinal + "') OR " + FechaInicial + " IS NULL) ");
                sConsulta.AppendLine("and AGV.ClienteClave not in (select distinct ClienteClave from Visita VIS where AGV.DiaClave = convert(varchar(10), vis.FechaHoraInicial, 103) and AGV.VendedorId = VIS.VendedorId and AGV.RUTClave = VIS.RUTClave and AGV.ClienteClave = VIS.ClienteClave) ");
                sConsulta.AppendLine("order by AGV.Orden");

                QueryString = "";
                QueryString = sConsulta.ToString();
                #endregion
                List<NoVisitados> Dos = Connection.Query<NoVisitados>(QueryString, null, null, true, 600).ToList();
                List<NoVisitados> DosGru = new List<NoVisitados>();
                List<NoVisitados> DosAux = new List<NoVisitados>();

                var SubDos = (from A in Dos
                              select A).ToList();

                var SC = (from gr in SubDos group gr by new { gr.Fecha } into grupo select grupo);

                foreach (var grupo in SC)
                {
                    foreach (var objetoAgrupado in grupo)
                    {
                        DosAux.Add(new NoVisitados
                        {
                            Ruta = objetoAgrupado.Ruta,
                            Fecha = objetoAgrupado.Fecha

                        });
                        DosAux.Last().cantidad = grupo.Count();
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
                    var TTVisi = item.tAGVClienteClave;
                    var TTVisiVTA = item.tVTAClienteClave;
                    var TTVisitados = item.TotalVisitados;
                    var porEfici = (((double)TTVisi / (double)TTVisitados) * 100);

                    item.tEficiencia_Porc = Math.Round(porEfici, 2);
                    item.tEfectividad_Porc = Math.Round(((double)TTVisiVTA / (double)TTVisitados * 100), 2);
                }

                var agrup_NoVis = (from gr in SubDos group gr by new { gr.Vendedor } into grupo select grupo);
                foreach (var gFecha in agrup_NoVis)
                {
                    var agrup_Fec = (from gr in gFecha group gr by new { gr.Fecha } into grupo select grupo);

                    foreach (var item in agrup_Fec)
                    {
                        var agrup_Ven = (from gr in item group gr by new { gr.Vendedor } into grupo select grupo);
                        foreach (var item1 in agrup_Ven)
                        {
                            foreach (var objAgrupado in item1)
                            {
                                DosGru.Add(new NoVisitados
                                {
                                    Fecha = objAgrupado.Fecha,
                                    CEDI = objAgrupado.CEDI,
                                    Vendedor = objAgrupado.Vendedor,
                                    Ruta = objAgrupado.Ruta,
                                    Secuencia = objAgrupado.Secuencia,
                                    Clave = objAgrupado.Clave,
                                    NombreCliente = objAgrupado.NombreCliente,
                                });
                            }
                        }


                    }
                }


                if (Prncipal.Count != 0)
                {
                    report_Principal report = new report_Principal();

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

                    //grouheader1 HoraInicioJoranda
                    GroupField groupInicioJornada = new GroupField("HoraInicialJornada");
                    report.GroupHeader1.GroupFields.Add(groupInicioJornada);
                    report.Gpo_JornadaInicio.DataBindings.Add("Text", report.DataSource, "HoraInicialJornada", "{0:HH:mm:ss}");

                    report.L_Secuencia.DataBindings.Add("Text", null, "Secuencia");
                    report.L_NumCliente.DataBindings.Add("Text", null, "Clave");
                    report.L_Cliente.DataBindings.Add("Text", null, "NombreCliente");
                    report.L_FueraFrecuencia.DataBindings.Add("Text", null, "FueraDeFrecuencia");
                    report.L_NoLeido.DataBindings.Add("Text", null, "CodigoNoLeido");
                    report.L_VisitaInicio.DataBindings.Add("Text", null, "HoraInicio", "{0:HH:mm:ss}");
                    report.L_VisitaFin.DataBindings.Add("Text", null, "HoraFin", "{0:HH:mm:ss}");
                    report.L_Venta.DataBindings.Add("Text", null, "Venta");
                    report.L_Improductividad.DataBindings.Add("Text", null, "Concepto");
                    report.L_TotalVta.DataBindings.Add("Text", null, "TotalVenta", "{0:$#,###,##0.00}");

                    report.Sub1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("parameter_date", null, "Fecha"));

                    if (Dos.Count != 0)
                    {
                        report_SubNoVisitados subReport1 = new report_SubNoVisitados();
                        subReport1.DataSource = DosGru;

                        subReport1.L_Secuencia.DataBindings.Add("Text", null, "Secuencia");
                        subReport1.L_Clave.DataBindings.Add("Text", null, "Clave");
                        subReport1.L_NombreCliente.DataBindings.Add("Text", null, "NombreCliente");

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

                    report.L_TiempoRecorrido.DataBindings.Add("Text", null, "CalculateJornada");
                    report.L_TiempoTransito.DataBindings.Add("Text", null, "tTiempoTransito");
                    report.L_PromedioVisita.DataBindings.Add("Text", null, "tPromVisTiempo");
                    report.L_PromedioTransito.DataBindings.Add("Text", null, "tPromJornada");

                    report.L_Meta.DataBindings.Add("Text", null, "tMeta");
                    report.L_Acumulado.DataBindings.Add("Text", null, "TAcumulado");
                    report.L_DifMeta.DataBindings.Add("Text", null, "TDiferencia");
                    report.L_Cuota.DataBindings.Add("Text", null, "TRestoDias");

                    ////////////////////////////////TOTALES////////////////////////////////

                    //ReportHeader
                    #region reporteDiario
                    FechaInicial = this.fInicio.Date.ToShortDateString();
                    FechaFinal = this.fFin.Date.ToShortDateString();
                    report.fecha.Text = FechaInicial + (FechaFinal == FechaInicial ? "" : " - " + FechaFinal);

                    report.logo.Image = Image.FromStream(LogoEmpresa);
                    report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                    report.empresa.Text = NombreEmpresa;
                    report.reporte.Text = NombreReporte;

                    report.centro.Text = NombreCEDIS;
                    report.nameFiltro.Text = (Rutas == "null" ? "Vendedor:" : "Ruta:");
                    report.filtro.Text = (Rutas == "null" ? cadVendedores : cadRuta);
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
            Int32 tsegundos = Convert.ToInt32(seg);
            Int32 horas = (tsegundos / 3600);
            Int32 minutos = ((tsegundos - horas * 3600) / 60);
            Int32 segundos2 = tsegundos - (horas * 3600 + minutos * 60);

            DateTime da = new DateTime(1, 1, 1, horas, minutos, segundos2, 0);
            var s = String.Format("{0:HH:mm:ss}", da);
            return s;
        }
    }

    class DiarioActividades
    {
        //PRINCIPAL
        public DateTime Fecha { get; set; }
        public string CEDI { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public string Secuencia { get; set; }
        public string ClienteClave { get; set; }
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

    class NoVisitados
    {
        public DateTime Fecha { get; set; }
        public string CEDI { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public string Secuencia { get; set; }
        public string Clave { get; set; }
        public string NombreCliente { get; set; }
        //TOTALES
        public long cantidad { get; set; }
    }
}