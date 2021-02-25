using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class CumplimientoVisitaGHR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string FechaIni;
        private string FechaFin;
        private string Rutas;
        private string nombreCedis;

        public bool GetReport(string NombreReporte, string NombreEmpresa, int Reporte, string FechaIni, string FechaFin, string Rutas, string nombreCedis)
        {
            if (Reporte == 202)
                return GetReportGeneral(FechaIni, FechaFin);
            else if (Reporte == 203)
                return GetReportRuta(FechaIni, FechaFin, Rutas, nombreCedis);
            else if (Reporte == 204)
                return GetReportCliente(FechaIni, FechaFin, Rutas, nombreCedis);
            return false;
        }

        public bool GetReportGeneral(string FechaIni, string FechaFin)
        {
            DateTime dFechaIni;
            DateTime.TryParse(FechaIni, out dFechaIni);
            DateTime dFechaFin;
            DateTime.TryParse(FechaFin, out dFechaFin);
            this.FechaIni = dFechaIni.ToShortDateString();
            this.FechaFin = dFechaFin.ToShortDateString();

            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            sConsulta.AppendLine("SET NOCOUNT ON ");
            sConsulta.AppendLine("declare @FechaIni as datetime");
            sConsulta.AppendLine("declare @FechaFin as datetime");

            sConsulta.AppendLine("set @FechaIni = '" + dFechaIni.Date.ToString("s") + "'");
            sConsulta.AppendLine("set @FechaFin = '" + dFechaFin.Date.ToString("s") + "'");

            sConsulta.AppendLine("if (select object_id('tempdb..#tmpAgenda')) is not null drop table #tmpAgenda ");
            sConsulta.AppendLine("select* into #tmpAgenda from ( ");
            sConsulta.AppendLine("	select ALM.AlmacenID, Dia.Semana, count(AGV.ClienteClave) as VisitasPlan ");
            sConsulta.AppendLine("	from AgendaVendedor AGV (NOLOCK) ");
            sConsulta.AppendLine("	inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("	inner join Ruta RUT (NOLOCK) on AGV.RUTClave = RUT.RUTClave ");
            sConsulta.AppendLine("	inner join Almacen ALM (NOLOCK) on RUT.AlmacenID = ALM.AlmacenID ");
            sConsulta.AppendLine("	where Dia.FechaCaptura between @FechaIni and @FechaFin ");
            sConsulta.AppendLine("	group by ALM.AlmacenID, Dia.Semana ");
            sConsulta.AppendLine(") as t ");

            sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisita')) is not null drop table #tmpVisita ");
            sConsulta.AppendLine("select* into #tmpVisita from ( ");
            sConsulta.AppendLine("	select t1.AlmacenID, t1.Semana, sum(VisitaPresencial) as VisitaPresencial, sum(VisitaNoPresencial) as VisitaNoPresencial, ");
            sConsulta.AppendLine("	sum(VisitaFPPresencial) as VisitaFPPresencial, sum(VisitaFPNoPresencial) as VisitaFPNoPresencial ");
            sConsulta.AppendLine("	from( ");
            sConsulta.AppendLine("		select t.AlmacenID, t.DiaClave, t.Semana, count(distinct(t.ClientePresencial)) as VisitaPresencial, count(distinct(t.ClienteNoPresencial)) as VisitaNoPresencial, ");
            sConsulta.AppendLine("		count(distinct(t.ClienteFPPresencial)) as VisitaFPPresencial, count(distinct(t.ClienteFPNoPresencial)) as VisitaFPNoPresencial ");
            sConsulta.AppendLine("		from( ");
            sConsulta.AppendLine("			select ALM.AlmacenID, Dia.DiaClave, Dia.Semana, ");
            sConsulta.AppendLine("			case when(VIS.FueraFrecuencia = 0 and isnull(VIS.DistanciaGPS, 0) <= ASV.LimiteGPS) then VIS.ClienteClave else null end as ClientePresencial, ");
            sConsulta.AppendLine("			case when(VIS.FueraFrecuencia = 0 and isnull(VIS.DistanciaGPS, 0) > ASV.LimiteGPS) then VIS.ClienteClave else null end as ClienteNoPresencial, ");
            sConsulta.AppendLine("			case when(VIS.FueraFrecuencia = 1 and isnull(VIS.DistanciaGPS, 0) <= ASV.LimiteGPS) then VIS.ClienteClave else null end as ClienteFPPresencial, ");
            sConsulta.AppendLine("			case when(VIS.FueraFrecuencia = 1 and isnull(VIS.DistanciaGPS, 0) > ASV.LimiteGPS) then VIS.ClienteClave else null end as ClienteFPNoPresencial ");
            sConsulta.AppendLine("			from Visita VIS (NOLOCK) ");
            sConsulta.AppendLine("			inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("			inner join Ruta RUT (NOLOCK) on VIS.RUTClave = RUT.RUTClave ");
            sConsulta.AppendLine("			inner join Almacen ALM (NOLOCK) on RUT.AlmacenID = ALM.AlmacenID ");
            sConsulta.AppendLine("			inner join Vendedor VEN (NOLOCK) on VIS.VendedorID = VEN.VendedorID ");
            sConsulta.AppendLine("			inner join AseguramientoVisita ASV (NOLOCK) on VEN.MCNClave = ASV.MCNClave ");
            sConsulta.AppendLine("			inner join ( ");
            sConsulta.AppendLine("			    select VIS2.DiaClave, VIS2.ClienteClave, max(VIS2.FechaHoraInicial) as FechaHoraInicial ");
            sConsulta.AppendLine("			    from Visita (NOLOCK) VIS2 ");
            sConsulta.AppendLine("			    inner join Dia (NOLOCK) DIA2 on VIS2.DiaClave = DIA2.DiaClave ");
            sConsulta.AppendLine("			    where DIA2.FechaCaptura between @FechaIni and @FechaFin ");
            sConsulta.AppendLine("			    group by VIS2.DiaClave, VIS2.ClienteClave ");
            sConsulta.AppendLine("			) as T ON VIS.DiaClave = T.DiaClave and VIS.ClienteClave = T.ClienteClave and VIS.FechaHoraInicial = T.FechaHoraInicial ");
            sConsulta.AppendLine("			where VEN.TipoEstado = 1 AND Dia.FechaCaptura between @FechaIni and @FechaFin ");
            sConsulta.AppendLine("		) as t ");
            sConsulta.AppendLine("		group by t.AlmacenID, t.DiaClave, t.Semana ");
            sConsulta.AppendLine("	) as t1 ");
            sConsulta.AppendLine("	group by t1.AlmacenID, t1.Semana ");
            sConsulta.AppendLine(") as t2 ");

            sConsulta.AppendLine("select ALM.Clave as ALMClave, ALM.Nombre as ALMNombre, AGV.Semana, AGV.VisitasPlan, isnull(VIS.VisitaPresencial, 0) as VisitaPresencial, isnull(VIS.VisitaNoPresencial, 0) as VisitaNoPresencial, ");
            sConsulta.AppendLine("round((isnull(VIS.VisitaPresencial, 0)/convert(float, AGV.VisitasPlan))*100, 2) as PorcentajeCumplimiento, isnull(VIS.VisitaFPPresencial, 0) as VisitaFPPresencial, ");
            sConsulta.AppendLine("isnull(VIS.VisitaFPNoPresencial, 0) as VisitaFPNoPresencial ");
            sConsulta.AppendLine("from #tmpAgenda AGV ");
            sConsulta.AppendLine("left join #tmpVisita VIS on AGV.AlmacenID = VIS.AlmacenID and AGV.Semana = VIS.Semana ");
            sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on AGV.AlmacenID = ALM.AlmacenID ");
            sConsulta.AppendLine("order by ALM.Clave, ALM.Nombre, AGV.Semana ");

            sConsulta.AppendLine("if (select object_id('tempdb..#tmpAgenda')) is not null drop table #tmpAgenda");
            sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisita')) is not null drop table #tmpVisita");

            sConsulta.AppendLine("SET NOCOUNT OFF ");

            QueryString = sConsulta.ToString();

            Connection.Open();
            List<CumplimientoVisitaGralGHRModel> Datos = Connection.Query<CumplimientoVisitaGralGHRModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            if (Datos.Count() <= 0)
                return false;
            else
            {
                //string fileName = GenerarExcelGeneral(Datos);
                //DownloadFile.DownloadOpenXML(fileName);

                ArchivoXlsModel file = GenerarExcelGeneral(Datos);
                DownloadFile.DownloadOpenXML(file);
            }


            return true;

        }

        public bool GetReportRuta(string FechaIni, string FechaFin, string Rutas, string nombreCedis)
        {
            try
            {
                DateTime dFechaIni;
                DateTime.TryParse(FechaIni, out dFechaIni);
                DateTime dFechaFin;
                DateTime.TryParse(FechaFin, out dFechaFin);
                this.FechaIni = dFechaIni.ToShortDateString();
                this.FechaFin = dFechaFin.ToShortDateString();
                this.Rutas = Rutas.Replace("'", "");

                StringBuilder aConsulta = new StringBuilder();
                aConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                aConsulta.AppendLine("SET NOCOUNT ON ");
                aConsulta.AppendLine("Select Clave, Nombre from Almacen where almacenID in (" + nombreCedis + ")");

                QueryString = aConsulta.ToString();

                Connection.Open();
                List<Almacen> DatosAlmacen = Connection.Query<Almacen>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                String Nom = "";
                foreach (var oActual in DatosAlmacen.Select(x => x).ToList())
                {
                    Nom += oActual.Clave + " " + oActual.Nombre + ", ";
                }
                Nom = Nom.Substring(0, Nom.Length - 2);
                this.nombreCedis = Nom;

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("declare @FechaIni as datetime");
                sConsulta.AppendLine("declare @FechaFin as datetime");

                sConsulta.AppendLine("set @FechaIni = '" + dFechaIni.Date.ToString("s") + "'");
                sConsulta.AppendLine("set @FechaFin = '" + dFechaFin.Date.ToString("s") + "'");

                sConsulta.AppendLine("if (select object_id('tempdb..#tmpAgenda')) is not null drop table #tmpAgenda");
                sConsulta.AppendLine("select* into #tmpAgenda from (");
                sConsulta.AppendLine("  select A.Clave, AGV.RUTClave, Dia.Semana, count(AGV.ClienteClave) as VisitasPlan");
                sConsulta.AppendLine("  from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave and Dia.FechaCaptura between @FechaIni and @FechaFin ");
                sConsulta.AppendLine("	inner join Ruta R (NOLOCK) on AGV.RUTClave = R.RUTClave and R.RUTClave in (" + Rutas + ") ");
                sConsulta.AppendLine("	inner join Almacen A (NOLOCK) on R.AlmacenID = A.AlmacenID and A.AlmacenID in (" + nombreCedis + ") ");
                sConsulta.AppendLine("	group by A.Clave, AGV.RUTClave, Dia.Semana");
                sConsulta.AppendLine(") as t");

                sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisita')) is not null drop table #tmpVisita");
                sConsulta.AppendLine("select* into #tmpVisita from (");
                sConsulta.AppendLine("	select t1.Clave, t1.RUTClave, t1.Semana, sum(VisitaPresencial) as VisitaPresencial, sum(VisitaNoPresencial) as VisitaNoPresencial, ");
                sConsulta.AppendLine("	sum(VisitaFPPresencial) as VisitaFPPresencial, sum(VisitaFPNoPresencial) as VisitaFPNoPresencial");
                sConsulta.AppendLine("  from(");
                sConsulta.AppendLine("      select t.Clave, t.RUTClave, t.DiaClave, t.Semana, count(distinct(t.ClientePresencial)) as VisitaPresencial, count(distinct(t.ClienteNoPresencial)) as VisitaNoPresencial,");
                sConsulta.AppendLine("      count(distinct(t.ClienteFPPresencial)) as VisitaFPPresencial, count(distinct(t.ClienteFPNoPresencial)) as VisitaFPNoPresencial");
                sConsulta.AppendLine("      from(");
                sConsulta.AppendLine("          select A.Clave, VIS.RUTClave, Dia.DiaClave, Dia.Semana,");
                sConsulta.AppendLine("			case when(VIS.FueraFrecuencia = 0 and isnull(VIS.DistanciaGPS, 0) <= ASV.LimiteGPS) then VIS.ClienteClave else null end as ClientePresencial,");
                sConsulta.AppendLine("			case when(VIS.FueraFrecuencia = 0 and isnull(VIS.DistanciaGPS, 0) > ASV.LimiteGPS) then VIS.ClienteClave else null end as ClienteNoPresencial,");
                sConsulta.AppendLine("			case when(VIS.FueraFrecuencia = 1 and isnull(VIS.DistanciaGPS, 0) <= ASV.LimiteGPS) then VIS.ClienteClave else null end as ClienteFPPresencial,");
                sConsulta.AppendLine("			case when(VIS.FueraFrecuencia = 1 and isnull(VIS.DistanciaGPS, 0) > ASV.LimiteGPS) then VIS.ClienteClave else null end as ClienteFPNoPresencial");
                sConsulta.AppendLine("          from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave AND Dia.FechaCaptura between @FechaIni and @FechaFin");
                sConsulta.AppendLine("	        inner join Ruta R (NOLOCK) on VIS.RUTClave = R.RUTClave and R.RUTClave in (" + Rutas + ") ");
                sConsulta.AppendLine("	        inner join Almacen A (NOLOCK) on R.AlmacenID = A.AlmacenID and A.AlmacenID in (" + nombreCedis + ") ");
                sConsulta.AppendLine("          inner join Vendedor VEN (NOLOCK) on VIS.VendedorID = VEN.VendedorID");
                sConsulta.AppendLine("          inner join AseguramientoVisita ASV (NOLOCK) on VEN.MCNClave = ASV.MCNClave");
                sConsulta.AppendLine("			inner join ( ");
                sConsulta.AppendLine("			    select VIS2.DiaClave, VIS2.ClienteClave, max(VIS2.FechaHoraInicial) as FechaHoraInicial ");
                sConsulta.AppendLine("			    from Visita (NOLOCK) VIS2 ");
                sConsulta.AppendLine("			    inner join Dia (NOLOCK) DIA2 on VIS2.DiaClave = DIA2.DiaClave and DIA2.FechaCaptura between @FechaIni and @FechaFin ");
                sConsulta.AppendLine("			    inner join Ruta R2 (NOLOCK) on VIS2.RUTClave = R2.RUTClave and R2.RUTClave in (" + Rutas + ") ");
                sConsulta.AppendLine("              inner join Almacen A2 (NOLOCK) on R2.AlmacenID = A2.AlmacenID and A2.AlmacenID in (" + nombreCedis + ") ");
                sConsulta.AppendLine("			    group by VIS2.DiaClave, VIS2.ClienteClave ");
                sConsulta.AppendLine("			) as T ON VIS.DiaClave = T.DiaClave and VIS.ClienteClave = T.ClienteClave and VIS.FechaHoraInicial = T.FechaHoraInicial ");
                sConsulta.AppendLine("          where VEN.TipoEstado = 1");
                //sConsulta.AppendLine("          and VIS.RUTClave in (" + Rutas + ")");
                sConsulta.AppendLine("      ) as t");
                sConsulta.AppendLine("      group by t.Clave, t.RUTClave, t.DiaClave, t.Semana");
                sConsulta.AppendLine("  ) as t1");
                sConsulta.AppendLine("  group by t1.Clave, t1.RUTClave, t1.Semana");
                sConsulta.AppendLine(") as t2");

                sConsulta.AppendLine("select AGV.Clave, AGV.RUTClave, AGV.Semana, AGV.VisitasPlan, isnull(VIS.VisitaPresencial, 0) as VisitaPresencial, isnull(VIS.VisitaNoPresencial, 0) as VisitaNoPresencial, ");
                sConsulta.AppendLine("round((isnull(VIS.VisitaPresencial, 0)/convert(float, AGV.VisitasPlan))*100, 2) as PorcentajeCumplimiento, isnull(VIS.VisitaFPPresencial, 0) as VisitaFPPresencial, ");
                sConsulta.AppendLine("isnull(VIS.VisitaFPNoPresencial, 0) as VisitaFPNoPresencial");
                sConsulta.AppendLine("from #tmpAgenda AGV");
                sConsulta.AppendLine("left join #tmpVisita VIS on AGV.RUTClave = VIS.RUTClave and AGV.Semana = VIS.Semana");
                sConsulta.AppendLine("order by AGV.Clave, AGV.RUTClave, AGV.Semana");

                sConsulta.AppendLine("if (select object_id('tempdb..#tmpAgenda')) is not null drop table #tmpAgenda");
                sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisita')) is not null drop table #tmpVisita");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<CumplimientoVisitaRutaGHRModel> Datos = Connection.Query<CumplimientoVisitaRutaGHRModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                if (Datos.Count() <= 0)
                    return false;
                else
                {
                    //string fileName = GenerarExcelRuta(Datos);                    
                    //DownloadFile.DownloadOpenXML(fileName);

                    ArchivoXlsModel file = GenerarExcelRuta(Datos);
                    DownloadFile.DownloadOpenXML(file);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool GetReportCliente(string FechaIni, string FechaFin, string Rutas, string nombreCedis)
        {
            DateTime dFechaIni;
            DateTime.TryParse(FechaIni, out dFechaIni);
            DateTime dFechaFin;
            DateTime.TryParse(FechaFin, out dFechaFin);
            this.FechaIni = dFechaIni.ToShortDateString();
            this.FechaFin = dFechaFin.ToShortDateString();
            this.Rutas = Rutas.Replace("'", "");
            this.nombreCedis = nombreCedis;

            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            sConsulta.AppendLine("SET NOCOUNT ON ");
            sConsulta.AppendLine("declare @FechaIni as datetime");
            sConsulta.AppendLine("declare @FechaFin as datetime");

            sConsulta.AppendLine("set @FechaIni = '" + dFechaIni.Date.ToString("s") + "'");
            sConsulta.AppendLine("set @FechaFin = '" + dFechaFin.Date.ToString("s") + "'");

            sConsulta.AppendLine("if (select object_id('tempdb..#tmpAgenda')) is not null drop table #tmpAgenda ");
            sConsulta.AppendLine("select * into #tmpAgenda from ( ");
            sConsulta.AppendLine("	select AGV.ClienteClave, AGV.RUTClave, COUNT(AGV.ClienteClave) as VisitasPlan ");
            sConsulta.AppendLine("	from AgendaVendedor AGV (NOLOCK) ");
            sConsulta.AppendLine("	inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("	where Dia.FechaCaptura between @FechaIni and @FechaFin ");
            sConsulta.AppendLine("	and AGV.RUTClave in (" + Rutas + ") ");
            sConsulta.AppendLine("	group by AGV.ClienteClave, AGV.RUTClave ");
            sConsulta.AppendLine(") as t ");

            sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisita')) is not null drop table #tmpVisita ");
            sConsulta.AppendLine("select* into #tmpVisita from ( ");
            sConsulta.AppendLine("	select t.ClienteClave, t.RUTClave, sum(t.VisitaPresencial) as VisitaPresencial, sum(t.VisitaNoPresencial) as VisitaNoPresencial, ");
            sConsulta.AppendLine("	sum(t.VisitaFPPresencial) as VisitaFPPresencial, sum(t.VisitaFPNoPresencial) as VisitaFPNoPresencial ");
            sConsulta.AppendLine("	from ( ");
            sConsulta.AppendLine("		select VIS.ClienteClave, VIS.RUTClave, ");
            sConsulta.AppendLine("		case when(VIS.FueraFrecuencia = 0 and isnull(VIS.DistanciaGPS, 0) <= ASV.LimiteGPS) then 1 else 0 end as VisitaPresencial, ");
            sConsulta.AppendLine("		case when(VIS.FueraFrecuencia = 0 and isnull(VIS.DistanciaGPS, 0) > ASV.LimiteGPS) then 1 else 0 end as VisitaNoPresencial, ");
            sConsulta.AppendLine("		case when(VIS.FueraFrecuencia = 1 and isnull(VIS.DistanciaGPS, 0) <= ASV.LimiteGPS) then 1 else 0 end as VisitaFPPresencial, ");
            sConsulta.AppendLine("		case when(VIS.FueraFrecuencia = 1 and isnull(VIS.DistanciaGPS, 0) > ASV.LimiteGPS) then 1 else 0 end as VisitaFPNoPresencial ");
            sConsulta.AppendLine("		from Visita VIS (NOLOCK) ");
            sConsulta.AppendLine("		inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("		inner join Vendedor VEN (NOLOCK) on VIS.VendedorID = VEN.VendedorID ");
            sConsulta.AppendLine("		inner join AseguramientoVisita ASV (NOLOCK) on VEN.MCNClave = ASV.MCNClave ");
            sConsulta.AppendLine("		inner join ( ");
            sConsulta.AppendLine("		    select VIS2.DiaClave, VIS2.ClienteClave, max(VIS2.FechaHoraInicial) as FechaHoraInicial ");
            sConsulta.AppendLine("		    from Visita (NOLOCK) VIS2 ");
            sConsulta.AppendLine("		    inner join Dia (NOLOCK) DIA2 on VIS2.DiaClave = DIA2.DiaClave ");
            sConsulta.AppendLine("		    where DIA2.FechaCaptura between @FechaIni and @FechaFin ");
            sConsulta.AppendLine("             and VIS2.RUTClave in (" + Rutas + ") ");
            sConsulta.AppendLine("		    group by VIS2.DiaClave, VIS2.ClienteClave ");
            sConsulta.AppendLine("		) as T ON VIS.DiaClave = T.DiaClave and VIS.ClienteClave = T.ClienteClave and VIS.FechaHoraInicial = T.FechaHoraInicial ");
            sConsulta.AppendLine("		where VEN.TipoEstado = 1 AND Dia.FechaCaptura between @FechaIni and @FechaFin ");
            sConsulta.AppendLine("		and VIS.RUTClave in (" + Rutas + ") ");
            sConsulta.AppendLine("	) as t ");
            sConsulta.AppendLine("	group by t.ClienteClave, t.RUTClave ");
            sConsulta.AppendLine(") as t1 ");

            sConsulta.AppendLine("if (select object_id('tempdb..#tmpCliente')) is not null drop table #tmpCliente ");
            sConsulta.AppendLine("select* into #tmpCliente from ( ");
            sConsulta.AppendLine("	select t.ClienteClave, t.Clave, t.RazonSocial, min(Segmento) as Segmento, isnull(min(Giro), '') as Giro, isnull(min(ProOne), 'NO') as ProOne ");
            sConsulta.AppendLine("	from ( ");
            sConsulta.AppendLine("	    select CLI.ClienteClave, CLI.Clave, CLI.RazonSocial, ESQ.Nombre as Segmento, null as Giro, null as ProOne ");
            sConsulta.AppendLine("	    from #tmpAgenda AGV ");
            sConsulta.AppendLine("	    inner join Cliente CLI (NOLOCK) on AGV.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("	    inner join ClienteEsquema CLE (NOLOCK) on CLI.ClienteClave = CLE.ClienteClave ");
            sConsulta.AppendLine("	    inner join Esquema ESQ (NOLOCK) on CLE.EsquemaID = ESQ.EsquemaID ");
            sConsulta.AppendLine("	    where CLE.TipoEstado = 1 and ESQ.Clasificacion = 6 and ESQ.Nivel = 2 ");
            sConsulta.AppendLine("	    union ");
            sConsulta.AppendLine("	    select CLI.ClienteClave, CLI.Clave, CLI.RazonSocial, null as Segmento, ESQ.Nombre as Giro, null as ProOne ");
            sConsulta.AppendLine("	    from #tmpAgenda AGV ");
            sConsulta.AppendLine("	    inner join Cliente CLI (NOLOCK) on AGV.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("	    inner join ClienteEsquema CLE (NOLOCK) on CLI.ClienteClave = CLE.ClienteClave ");
            sConsulta.AppendLine("	    inner join Esquema ESQ (NOLOCK) on CLE.EsquemaID = ESQ.EsquemaID ");
            sConsulta.AppendLine("	    where CLE.TipoEstado = 1 and ESQ.Clasificacion = 7 and ESQ.Nivel = 2 ");
            sConsulta.AppendLine("	    union ");
            sConsulta.AppendLine("	    select CLI.ClienteClave, CLI.Clave, CLI.RazonSocial, null as Segmento, null as Giro, 'SI' as ProOne ");
            sConsulta.AppendLine("	    from #tmpAgenda AGV ");
            sConsulta.AppendLine("	    inner join Cliente CLI (NOLOCK) on AGV.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("	    inner join ClienteEsquema CLE (NOLOCK) on CLI.ClienteClave = CLE.ClienteClave ");
            sConsulta.AppendLine("	    inner join Esquema ESQ (NOLOCK) on CLE.EsquemaID = ESQ.EsquemaID ");
            sConsulta.AppendLine("	    where CLE.TipoEstado = 1 and ESQ.Clasificacion = 8 and ESQ.Nivel = 2 ");
            sConsulta.AppendLine("	) as t ");
            sConsulta.AppendLine("	group by t.ClienteClave, t.Clave, t.RazonSocial ");
            sConsulta.AppendLine(") as t1 ");

            sConsulta.AppendLine("select CLI.Clave as CLIClave, CLI.RazonSocial, AGV.RUTClave, AGV.VisitasPlan, isnull(VIS.VisitaPresencial, 0) as VisitaPresencial, ");
            sConsulta.AppendLine("isnull(VIS.VisitaNoPresencial, 0) as VisitaNoPresencial, isnull(VIS.VisitaFPPresencial, 0) as VisitaFPPresencial, ");
            sConsulta.AppendLine("round((isnull(VIS.VisitaPresencial, 0)/convert(float, AGV.VisitasPlan))*100, 2) as PorcentajeCumplimiento, ");
            sConsulta.AppendLine("isnull(VIS.VisitaFPNoPresencial, 0) as VisitaFPNoPresencial, CLI.Segmento, CLI.Giro, CLI.ProOne ");
            sConsulta.AppendLine("from #tmpAgenda AGV ");
            sConsulta.AppendLine("left join #tmpVisita VIS on AGV.ClienteClave = VIS.ClienteClave and AGV.RUTClave = VIS.RUTClave ");
            sConsulta.AppendLine("inner join #tmpCliente CLI on AGV.ClienteClave = CLI.ClienteClave ");
            sConsulta.AppendLine("order by CLI.Clave, AGV.RUTClave ");

            sConsulta.AppendLine("if (select object_id('tempdb..#tmpAgenda')) is not null drop table #tmpAgenda");
            sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisita')) is not null drop table #tmpVisita");
            sConsulta.AppendLine("if (select object_id('tempdb..#tmpCliente')) is not null drop table #tmpCliente");

            sConsulta.AppendLine("SET NOCOUNT OFF ");

            QueryString = sConsulta.ToString();

            Connection.Open();
            List<CumplimientoVisitaClienteGHRModel> Datos = Connection.Query<CumplimientoVisitaClienteGHRModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            if (Datos.Count() <= 0)
                return false;
            else
            {
                //string fileName = GenerarExcelCliente(Datos);
                //DownloadFile.DownloadOpenXML(fileName);

                ArchivoXlsModel file = GenerarExcelCliente(Datos);
                DownloadFile.DownloadOpenXML(file);
            }

            return true;

        }

        private ArchivoXlsModel GenerarExcelGeneral(List<CumplimientoVisitaGralGHRModel> Datos)
        {
            //string path = ConfigurationManager.AppSettings.Get("pathReportes");
            //string fileName = path + @"\CumplimientoVisita_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            string fileName = "CumplimientoVisita_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            //using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Cumplimiento de Visita" };
                sheets.Append(sheet);
                workbookPart.Workbook.Save();

                RouteEntities db = new RouteEntities();
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();
                row.Append(MyOpenXML.ConstructCell(ValorReferencia.ObtenerDescripcion("REPORTEW", "202", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(MyOpenXML.ConstructCell(((Configuracion)db.Configuracion.First()).NombreEmpresa, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                string sFecha = FechaIni + " al " + FechaFin;
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFecha", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(sFecha, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitasPlan", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaNoPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPorcentajeCumplimiento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaFPPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaFPNoPresencial", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                var cedis = Datos
                  .GroupBy(x => x.ALMClave)
                  .Select(x => new
                  {
                      ALMClave = x.First().ALMClave,
                      ALMNombre = x.First().ALMNombre,
                      VisitasPlan = x.Sum(y => y.VisitasPlan),
                      VisitaPresencial = x.Sum(y => y.VisitaPresencial),
                      VisitaNoPresencial = x.Sum(y => y.VisitaNoPresencial),
                      VisitaFPPresencial = x.Sum(y => y.VisitaFPPresencial),
                      VisitaFPNoPresencial = x.Sum(y => y.VisitaFPNoPresencial)
                  })
                  .OrderBy(x => x.ALMNombre)
                  .ToList();

                long totalVisitasPlan = 0;
                long totalVisitaPresencial = 0;
                long totalVisitaNoPresencial = 0;
                long totalVisitaFPPresencial = 0;
                long totalVisitaFPNoPresencial = 0;

                foreach (var cedi in cedis)
                {
                    totalVisitasPlan += cedi.VisitasPlan;
                    totalVisitaPresencial += cedi.VisitaPresencial;
                    totalVisitaNoPresencial += cedi.VisitaNoPresencial;
                    totalVisitaFPPresencial += cedi.VisitaFPPresencial;
                    totalVisitaFPNoPresencial += cedi.VisitaFPNoPresencial;

                    row = new Row();
                    row.Append(
                        MyOpenXML.ConstructCell(cedi.ALMNombre, CellValues.String),
                        MyOpenXML.ConstructCell(cedi.VisitasPlan.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cedi.VisitaPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cedi.VisitaNoPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(Math.Round(((double)cedi.VisitaPresencial / (double)cedi.VisitasPlan) * 100, 2).ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cedi.VisitaFPPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cedi.VisitaFPNoPresencial.ToString(), CellValues.Number));
                    sheetData.AppendChild(row);

                    var semanas = Datos
                        .Where(x => x.ALMClave == cedi.ALMClave)
                        .OrderBy(x => x.Semana)
                        .ToList();

                    foreach (var semana in semanas)
                    {
                        row = new Row();
                        row.Append(
                         MyOpenXML.ConstructCell("S" + semana.Semana.ToString(), CellValues.String),
                         MyOpenXML.ConstructCell(semana.VisitasPlan.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.VisitaPresencial.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.VisitaNoPresencial.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.PorcentajeCumplimiento.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.VisitaFPPresencial.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.VisitaFPNoPresencial.ToString(), CellValues.Number));
                        sheetData.AppendChild(row);
                    }//foreach (var semana in semanas)

                }//foreach (var ruta in rutas)

                row = new Row();
                row.Append(
                     MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTotal", "EM"), CellValues.String),
                     MyOpenXML.ConstructCell(totalVisitasPlan.ToString(), CellValues.Number),
                     MyOpenXML.ConstructCell(totalVisitaPresencial.ToString(), CellValues.Number),
                     MyOpenXML.ConstructCell(totalVisitaNoPresencial.ToString(), CellValues.Number),
                     MyOpenXML.ConstructCell(Math.Round(((double)totalVisitaPresencial / (double)totalVisitasPlan) * 100, 2).ToString(), CellValues.Number),
                     MyOpenXML.ConstructCell(totalVisitaFPPresencial.ToString(), CellValues.Number),
                     MyOpenXML.ConstructCell(totalVisitaFPNoPresencial.ToString(), CellValues.Number));
                sheetData.AppendChild(row);

                worksheetPart.Worksheet.Save();

            }//using
            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
            //return fileName;
        }//GenerarExcel

        private ArchivoXlsModel GenerarExcelRuta(List<CumplimientoVisitaRutaGHRModel> Datos)
        {
            //string path = ConfigurationManager.AppSettings.Get("pathReportes");
            //string fileName = path + @"\CumplimientoVisita_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            string fileName = "CumplimientoVisita_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            //using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Cumplimiento de Visita" };
                sheets.Append(sheet);
                workbookPart.Workbook.Save();

                RouteEntities db = new RouteEntities();
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();
                row.Append(MyOpenXML.ConstructCell(ValorReferencia.ObtenerDescripcion("REPORTEW", "203", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                //String empresa = Connection.Query<String>("select NombreEmpresa from Configuracion", null, null, true, 600).ToList().FirstOrDefault();                
                row.Append(MyOpenXML.ConstructCell(((Configuracion)db.Configuracion.First()).NombreEmpresa, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                      MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XSucursal", "EM"), CellValues.String),
                      MyOpenXML.ConstructCell(nombreCedis, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRuta", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Rutas, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                string sFecha = FechaIni + " al " + FechaFin;
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFecha", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(sFecha, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                bool primera = true;
                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitasPlan", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaNoPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPorcentajeCumplimiento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaFPPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaFPNoPresencial", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                var rutas = Datos
                  .GroupBy(x => new { x.Clave, x.RUTClave })
                  .Select(x => new {
                      Clave = x.First().Clave,
                      RUTClave = x.First().RUTClave,
                      VisitasPlan = x.Sum(y => y.VisitasPlan),
                      VisitaPresencial = x.Sum(y => y.VisitaPresencial),
                      VisitaNoPresencial = x.Sum(y => y.VisitaNoPresencial),
                      VisitaFPPresencial = x.Sum(y => y.VisitaFPPresencial),
                      VisitaFPNoPresencial = x.Sum(y => y.VisitaFPNoPresencial)
                  })
                  .OrderBy(x => x.Clave)
                  .OrderBy(x => x.RUTClave)
                  .ToList();

                long totalVisitasPlan = 0;
                long totalVisitaPresencial = 0;
                long totalVisitaNoPresencial = 0;
                long totalVisitaFPPresencial = 0;
                long totalVisitaFPNoPresencial = 0;

                foreach (var ruta in rutas)
                {
                    totalVisitasPlan += ruta.VisitasPlan;
                    totalVisitaPresencial += ruta.VisitaPresencial;
                    totalVisitaNoPresencial += ruta.VisitaNoPresencial;
                    totalVisitaFPPresencial += ruta.VisitaFPPresencial;
                    totalVisitaFPNoPresencial += ruta.VisitaFPNoPresencial;

                    row = new Row();
                    row.Append(
                        MyOpenXML.ConstructCell(ruta.Clave, CellValues.String),
                        MyOpenXML.ConstructCell(ruta.RUTClave, CellValues.String),
                        MyOpenXML.ConstructCell(ruta.VisitasPlan.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(ruta.VisitaPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(ruta.VisitaNoPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(Math.Round(((double)ruta.VisitaPresencial / (double)ruta.VisitasPlan) * 100, 2).ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(ruta.VisitaFPPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(ruta.VisitaFPNoPresencial.ToString(), CellValues.Number));
                    sheetData.AppendChild(row);

                    var semanas = Datos
                        .Where(x => x.RUTClave == ruta.RUTClave)
                        .OrderBy(x => x.Semana)
                        .ToList();

                    foreach (var semana in semanas)
                    {
                        row = new Row();
                        row.Append(
                         MyOpenXML.ConstructCell("", CellValues.String),
                         MyOpenXML.ConstructCell("S" + semana.Semana.ToString(), CellValues.String),
                         MyOpenXML.ConstructCell(semana.VisitasPlan.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.VisitaPresencial.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.VisitaNoPresencial.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.PorcentajeCumplimiento.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.VisitaFPPresencial.ToString(), CellValues.Number),
                         MyOpenXML.ConstructCell(semana.VisitaFPNoPresencial.ToString(), CellValues.Number));
                        sheetData.AppendChild(row);
                    }//foreach (var semana in semanas)

                }//foreach (var ruta in rutas)

                row = new Row();
                row.Append(
                 MyOpenXML.ConstructCell("", CellValues.String),
                 MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTotal", "EM"), CellValues.String),
                 MyOpenXML.ConstructCell(totalVisitasPlan.ToString(), CellValues.Number),
                 MyOpenXML.ConstructCell(totalVisitaPresencial.ToString(), CellValues.Number),
                 MyOpenXML.ConstructCell(totalVisitaNoPresencial.ToString(), CellValues.Number),
                 MyOpenXML.ConstructCell(Math.Round(((double)totalVisitaPresencial / (double)totalVisitasPlan) * 100, 2).ToString(), CellValues.Number),
                 MyOpenXML.ConstructCell(totalVisitaFPPresencial.ToString(), CellValues.Number),
                 MyOpenXML.ConstructCell(totalVisitaFPNoPresencial.ToString(), CellValues.Number));
                sheetData.AppendChild(row);

                worksheetPart.Worksheet.Save();

            }//using
            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
            //return fileName;
        }//GenerarExcel

        private ArchivoXlsModel GenerarExcelCliente(List<CumplimientoVisitaClienteGHRModel> Datos)
        {
            //string path = ConfigurationManager.AppSettings.Get("pathReportes");
            //string fileName = path + @"\CumplimientoVisita_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            string fileName = "CumplimientoVisita_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            //using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Cumplimiento de Visita" };
                sheets.Append(sheet);
                workbookPart.Workbook.Save();

                RouteEntities db = new RouteEntities();
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();
                row.Append(MyOpenXML.ConstructCell(ValorReferencia.ObtenerDescripcion("REPORTEW", "204", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(MyOpenXML.ConstructCell(((Configuracion)db.Configuracion.First()).NombreEmpresa, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                  MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XSucursal", "EM"), CellValues.String),
                  MyOpenXML.ConstructCell(nombreCedis, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRuta", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Rutas, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                string sFecha = FechaIni + " al " + FechaFin;
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFecha", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(sFecha, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XCliente", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRazonSocial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRuta", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitasPlan", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaNoPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPorcentajeCumplimiento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaFPPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaFPNoPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XSegmento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XGiro", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XProOne", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                foreach (var cliente in Datos)
                {
                    row = new Row();
                    row.Append(
                        MyOpenXML.ConstructCell(cliente.CLIClave, CellValues.String),
                        MyOpenXML.ConstructCell(cliente.RazonSocial, CellValues.String),
                        MyOpenXML.ConstructCell(cliente.RUTClave, CellValues.String),
                        MyOpenXML.ConstructCell(cliente.VisitasPlan.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cliente.VisitaPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cliente.VisitaNoPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cliente.PorcentajeCumplimiento.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cliente.VisitaFPPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cliente.VisitaFPNoPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(cliente.Segmento, CellValues.String),
                        MyOpenXML.ConstructCell(cliente.Giro, CellValues.String),
                        MyOpenXML.ConstructCell(cliente.ProOne, CellValues.String));
                    sheetData.AppendChild(row);

                }//foreach (var cliente in Datos)

                worksheetPart.Worksheet.Save();

            }//using
            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
            //return fileName;
        }//GenerarExcel
    }

    class CumplimientoVisitaGralGHRModel
    {
        public String ALMClave { get; set; }
        public String ALMNombre { get; set; }
        public int Semana { get; set; }
        public long VisitasPlan { get; set; }
        public long VisitaPresencial { get; set; }
        public long VisitaNoPresencial { get; set; }
        public float PorcentajeCumplimiento { get; set; }
        public long VisitaFPPresencial { get; set; }
        public long VisitaFPNoPresencial { get; set; }
    }

    class CumplimientoVisitaRutaGHRModel
    {
        public String Clave { get; set; }
        public String RUTClave { get; set; }
        public int Semana { get; set; }
        public long VisitasPlan { get; set; }
        public long VisitaPresencial { get; set; }
        public long VisitaNoPresencial { get; set; }
        public float PorcentajeCumplimiento { get; set; }
        public long VisitaFPPresencial { get; set; }
        public long VisitaFPNoPresencial { get; set; }

    }

    class CumplimientoVisitaClienteGHRModel
    {
        public String CLIClave { get; set; }
        public String RazonSocial { get; set; }
        public String RUTClave { get; set; }
        public long VisitasPlan { get; set; }
        public long VisitaPresencial { get; set; }
        public long VisitaNoPresencial { get; set; }
        public float PorcentajeCumplimiento { get; set; }
        public long VisitaFPPresencial { get; set; }
        public long VisitaFPNoPresencial { get; set; }
        public String Segmento { get; set; }
        public String Giro { get; set; }
        public String ProOne { get; set; }
    }
}