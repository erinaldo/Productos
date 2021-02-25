using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class R275CumplimientoVisRutGHR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string FechaIni;
        private string FechaFin;
        private string Rutas;
        private string nombreCedis;

        public bool GetReport(int Reporte, string FechaIni, string FechaFin, string Rutas, string nombreCedis)
        {
            if (Reporte == 275)
                return GetReportRuta(FechaIni, FechaFin, Rutas, nombreCedis);
            return false;
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
                sConsulta.AppendLine("  select A.Clave AS ALMClave, A.Nombre AS ALMNombre, AGV.RUTClave, AGV.VendedorId, count(AGV.ClienteClave) as VisitasPlan ");
                sConsulta.AppendLine("  from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave and Dia.FechaCaptura between @FechaIni and @FechaFin ");
                sConsulta.AppendLine("	inner join Ruta R (NOLOCK) on AGV.RUTClave = R.RUTClave and R.RUTClave in (" + Rutas + ") ");
                sConsulta.AppendLine("	inner join Almacen A (NOLOCK) on R.AlmacenID = A.AlmacenID and A.AlmacenID in (" + nombreCedis + ") ");
                sConsulta.AppendLine("	group by A.Clave, A.Nombre, AGV.RUTClave, AGV.VendedorId");
                sConsulta.AppendLine(") as t");

                sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisita')) is not null drop table #tmpVisita");
                sConsulta.AppendLine("select* into #tmpVisita from (");
                sConsulta.AppendLine("	select t1.Clave, t1.RUTClave, sum(VisitaPresencial) as VisitaPresencial, sum(VisitaNoPresencial) as VisitaNoPresencial, ");
                sConsulta.AppendLine("	sum(VisitaFPPresencial) as VisitaFPPresencial, sum(VisitaFPNoPresencial) as VisitaFPNoPresencial");
                sConsulta.AppendLine("  from(");
                sConsulta.AppendLine("      select t.Clave, t.RUTClave, t.DiaClave, count(distinct(t.ClientePresencial)) as VisitaPresencial, count(distinct(t.ClienteNoPresencial)) as VisitaNoPresencial,");
                sConsulta.AppendLine("      count(distinct(t.ClienteFPPresencial)) as VisitaFPPresencial, count(distinct(t.ClienteFPNoPresencial)) as VisitaFPNoPresencial");
                sConsulta.AppendLine("      from(");
                sConsulta.AppendLine("          select A.Clave, VIS.RUTClave, Dia.DiaClave, ");
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
                sConsulta.AppendLine("      ) as t");
                sConsulta.AppendLine("      group by t.Clave, t.RUTClave, t.DiaClave");
                sConsulta.AppendLine("  ) as t1");
                sConsulta.AppendLine("  group by t1.Clave, t1.RUTClave");
                sConsulta.AppendLine(") as t2");

                sConsulta.AppendLine("select AGV.ALMClave AS OFVTA, AGV.ALMNombre AS Sucursal, '' AS UnidDeNeg, RIGHT(AGV.RUTClave, 3) AS Ruta, '40' + AGV.VendedorId AS Agente, ");
                sConsulta.AppendLine("CASE WHEN (select count(datos) from FNSplit((select V.Nombre from Vendedor V where V.VendedorID = AGV.VendedorId), '-')) > 1 THEN (select TRIM(datos) from FNSplit((select V.Nombre from Vendedor V where V.VendedorID = AGV.VendedorId), '-') where RowNum = 2) ELSE (select V.Nombre from Vendedor V where V.VendedorID = AGV.VendedorId) END AS NombreAgente, ");
                sConsulta.AppendLine("AGV.VisitasPlan, isnull(VIS.VisitaPresencial, 0) as VisitaPresencial, isnull(VIS.VisitaNoPresencial, 0) as VisitaNoPresencial, ");
                sConsulta.AppendLine("round((isnull(VIS.VisitaPresencial, 0)/convert(float, AGV.VisitasPlan))*100, 2) as PorcentajeCumplimiento, isnull(VIS.VisitaFPPresencial, 0) as VisitaFPPresencial, ");
                sConsulta.AppendLine("isnull(VIS.VisitaFPNoPresencial, 0) as VisitaFPNoPresencial");
                sConsulta.AppendLine("from #tmpAgenda AGV");
                sConsulta.AppendLine("left join #tmpVisita VIS on AGV.RUTClave = VIS.RUTClave ");
                sConsulta.AppendLine("order by AGV.ALMClave, AGV.RUTClave ");

                sConsulta.AppendLine("if (select object_id('tempdb..#tmpAgenda')) is not null drop table #tmpAgenda");
                sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisita')) is not null drop table #tmpVisita");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<R275CumplimientoVisitaRutaGHRModel> Datos = Connection.Query<R275CumplimientoVisitaRutaGHRModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                if (Datos.Count() <= 0)
                    return false;
                else
                {
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

        private ArchivoXlsModel GenerarExcelRuta(List<R275CumplimientoVisitaRutaGHRModel> Datos)
        {
            string fileName = "CumplimientoVisita_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
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

                Row row = new Row();
                row.Append(MyOpenXML.ConstructCell(ValorReferencia.ObtenerDescripcion("REPORTEW", "203", "EM"), CellValues.String));
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

                bool primera = true;
                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XOFVTA", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XSucursal", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XUnidDeNeg", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRuta", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XNumeralAgente", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XNombreAgente", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitasPlan", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaNoPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPorcentajeCumplimiento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaFPPresencial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVisitaFPNoPresencial", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                var rutas = Datos
                  .GroupBy(x => new { x.OFVTA, x.Ruta })
                  .Select(x => new {
                      OFVTA = x.First().OFVTA,
                      Sucursal = x.First().Sucursal,
                      UnidDeNeg = x.First().UnidDeNeg,
                      Ruta = x.First().Ruta,
                      Agente = x.First().Agente,
                      NombreAgente = x.First().NombreAgente,
                      VisitasPlan = x.Sum(y => y.VisitasPlan),
                      VisitaPresencial = x.Sum(y => y.VisitaPresencial),
                      VisitaNoPresencial = x.Sum(y => y.VisitaNoPresencial),
                      VisitaFPPresencial = x.Sum(y => y.VisitaFPPresencial),
                      VisitaFPNoPresencial = x.Sum(y => y.VisitaFPNoPresencial)
                  })
                  .OrderBy(x => x.OFVTA)
                  .OrderBy(x => x.Ruta)
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
                        MyOpenXML.ConstructCell(ruta.OFVTA, CellValues.String),
                        MyOpenXML.ConstructCell(ruta.Sucursal, CellValues.String),
                        MyOpenXML.ConstructCell(ruta.UnidDeNeg, CellValues.String),
                        MyOpenXML.ConstructCell(ruta.Ruta, CellValues.String),
                        MyOpenXML.ConstructCell(ruta.Agente, CellValues.String),
                        MyOpenXML.ConstructCell(ruta.NombreAgente, CellValues.String),
                        MyOpenXML.ConstructCell(ruta.VisitasPlan.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(ruta.VisitaPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(ruta.VisitaNoPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(Math.Round(((double)ruta.VisitaPresencial / (double)ruta.VisitasPlan) * 100, 2).ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(ruta.VisitaFPPresencial.ToString(), CellValues.Number),
                        MyOpenXML.ConstructCell(ruta.VisitaFPNoPresencial.ToString(), CellValues.Number));
                    sheetData.AppendChild(row);
                }

                row = new Row();
                row.Append(
                 MyOpenXML.ConstructCell("", CellValues.String),
                 MyOpenXML.ConstructCell("", CellValues.String),
                 MyOpenXML.ConstructCell("", CellValues.String),
                 MyOpenXML.ConstructCell("", CellValues.String),
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
            }
            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
        }
    }

    class R275CumplimientoVisitaRutaGHRModel
    {
        public String OFVTA { get; set; }
        public String Sucursal { get; set; }
        public String UnidDeNeg { get; set; }
        public String Ruta { get; set; }
        public String Agente { get; set; }
        public String NombreAgente { get; set; }
        public long VisitasPlan { get; set; }
        public long VisitaPresencial { get; set; }
        public long VisitaNoPresencial { get; set; }
        public float PorcentajeCumplimiento { get; set; }
        public long VisitaFPPresencial { get; set; }
        public long VisitaFPNoPresencial { get; set; }
    }
}