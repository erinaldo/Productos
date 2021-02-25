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
    public class GAPMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string NombreReporte, string NombreEmpresa, string nombreCedis, string FechaInicial, string FechaFinal, int vavclave, string pvProductos, string sEsquemasProd, string pvCondicion, string RutasSplit, string sFechaAnioActual, string sFechaAnioAnterior)
        {
            try
            {
                Boolean existeOrderProductos = ordenProductos(vavclave);

                DateTime sFecha = Convert.ToDateTime(FechaInicial);
                DateTime sFechaFin;
                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
                {
                    sFechaFin = sFecha;
                }
                else
                {
                    sFechaFin = Convert.ToDateTime(FechaFinal);
                }


                DateTime dFechaIni = new DateTime(sFecha.Year, sFecha.Month, sFecha.Day);
                DateTime dFechaFin = new DateTime(sFechaFin.Year, sFechaFin.Month, sFechaFin.Day);


                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select t.*" + (existeOrderProductos ? ", Op.Orden" : "") + " from (");
                sConsulta.AppendLine("select distinct ");
                sConsulta.AppendLine("datepart(MM,Dia.DiaClave) as NoMes,");
                sConsulta.AppendLine("datename(mm,Dia.DiaClave) as Mes,	");
                sConsulta.AppendLine("datename(yy,Dia.DiaClave) as Anio,");
                sConsulta.AppendLine("PRO.Id as IDProducto, ");
                sConsulta.AppendLine("PRO.NombreLargo,");
                sConsulta.AppendLine("E.Nombre as IDEsquema,");
                sConsulta.AppendLine("COUNT(distinct VIS.ClienteClave) as NoClientes");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("inner join Usuario USU (NOLOCK) on VEN.USUId = USU.USUId ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select E1.EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='CUP'))");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave=RUT.RUTClave ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID	");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(sEsquemasProd);
                sConsulta.AppendLine("and ( " + sFechaAnioActual + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                sConsulta.AppendLine("group by ");
                sConsulta.AppendLine("datepart(MM,Dia.DiaClave), datename(mm,Dia.DiaClave), datename(yy,Dia.DiaClave), PRO.Id, PRO.NombreLargo, E.Nombre");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select distinct ");
                sConsulta.AppendLine("datepart(MM,Dia.DiaClave) as NoMes,");
                sConsulta.AppendLine("datename(mm,Dia.DiaClave) as Mes,	");
                sConsulta.AppendLine("datename(yy,Dia.DiaClave) as Anio,");
                sConsulta.AppendLine("PRO.Id as IDProducto, ");
                sConsulta.AppendLine("PRO.NombreLargo,");
                sConsulta.AppendLine("E.Nombre as IDEsquema,");
                sConsulta.AppendLine("COUNT(distinct VIS.ClienteClave) as NoClientes");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("inner join Usuario USU (NOLOCK) on VEN.USUId = USU.USUId ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select E1.EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='CUP'))");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave=RUT.RUTClave ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID	");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(sEsquemasProd);
                sConsulta.AppendLine("and ( " + sFechaAnioAnterior + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                sConsulta.AppendLine("group by ");
                sConsulta.AppendLine("datepart(MM,Dia.DiaClave), datename(mm,Dia.DiaClave), datename(yy,Dia.DiaClave), PRO.Id, PRO.NombreLargo, E.Nombre");
                sConsulta.AppendLine(") as t");
                sConsulta.AppendLine((existeOrderProductos ? "left join OrdenProductos op (NOLOCK) on t.IDProducto  = op.ProductoClave" : ""));
                sConsulta.AppendLine((existeOrderProductos ? "order by OP.Orden desc" : "order by t.IDProducto,t.Mes,t.Anio"));
                sConsulta.AppendLine("");
                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                List<GAPClientesModel> Clientes = Connection.Query<GAPClientesModel>(QueryString, null, null, true, 600).ToList();
                if (Clientes.Count() <= 0)
                {
                    return null;
                }

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("declare @TablaMeses table(Mes varchar(100))");
                sConsulta.AppendLine("declare @FechaInicial datetime,@FechaFinal datetime, @MesInicial int, @MesFinal int, @MesActual as int");
                sConsulta.AppendLine("set @FechaInicial='" + dFechaIni.ToString("s") + "'");
                sConsulta.AppendLine("set @FechaFinal='" + dFechaFin.ToString("s") + "'");
                sConsulta.AppendLine("set @MesInicial=datepart(MM,@FechaInicial)");
                sConsulta.AppendLine("set @MesFinal=datepart(MM,@FechaFinal)");
                sConsulta.AppendLine("set @MesActual=@MesInicial");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("while @MesActual <= @MesFinal");
                sConsulta.AppendLine("begin");
                sConsulta.AppendLine("insert @TablaMeses values (DATENAME(MM,'1900-'+right('0'+cast(@MesActual as varchar),2)+'-01T00:00:00'))");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("set @MesActual=@MesActual+1");
                sConsulta.AppendLine("End");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select * from @TablaMeses");

                QueryString = sConsulta.ToString();

                List<GAPMesesModel> Meses = Connection.Query<GAPMesesModel>(QueryString, null, null, true, 600).ToList();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("declare @TablaAnios table(Anio varchar(100))");
                sConsulta.AppendLine("declare @FechaInicial datetime,@FechaFinal datetime");
                sConsulta.AppendLine("set @FechaInicial='" + dFechaIni.ToString("s") + "'");
                sConsulta.AppendLine("set @FechaFinal='" + dFechaFin.ToString("s") + "'");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("insert @TablaAnios values (datepart(YYYY,@FechaInicial))");
                sConsulta.AppendLine("insert @TablaAnios values (datepart(YYYY,@FechaInicial)-1)");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select * from @TablaAnios order by Anio");

                QueryString = sConsulta.ToString();

                List<GAPAniosModel> Anios = Connection.Query<GAPAniosModel>(QueryString, null, null, true, 600).ToList();


                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("SET LANGUAGE Spanish");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select t.* " + (existeOrderProductos ? ", OP.Orden" : "") + " from (");
                sConsulta.AppendLine("select distinct ");
                sConsulta.AppendLine("datepart(MM,Dia.DiaClave) as NoMes,");
                sConsulta.AppendLine("datename(mm,Dia.DiaClave) as Mes,	");
                sConsulta.AppendLine("PRO.Id as IDProducto, ");
                sConsulta.AppendLine("PRO.NombreLargo,");
                sConsulta.AppendLine("E.Nombre as IDEsquema ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("inner join Usuario USU (NOLOCK) on VEN.USUId = USU.USUId ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select E1.EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='CUP'))");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave=RUT.RUTClave ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID	");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(sEsquemasProd);
                sConsulta.AppendLine("and ( " + sFechaAnioActual + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                sConsulta.AppendLine("group by ");
                sConsulta.AppendLine("datepart(MM,Dia.DiaClave), datename(mm,Dia.DiaClave), PRO.Id, PRO.NombreLargo, E.Nombre ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("union ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select distinct ");
                sConsulta.AppendLine("datepart(MM,Dia.DiaClave) as NoMes,");
                sConsulta.AppendLine("datename(mm,Dia.DiaClave) as Mes,	");
                sConsulta.AppendLine("PRO.Id as IDProducto, ");
                sConsulta.AppendLine("PRO.NombreLargo,");
                sConsulta.AppendLine("E.Nombre as IDEsquema ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("inner join Usuario USU (NOLOCK) on VEN.USUId = USU.USUId ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select E1.EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='CUP'))");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave=RUT.RUTClave ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID	");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(sEsquemasProd);
                sConsulta.AppendLine("and ( " + sFechaAnioAnterior + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                sConsulta.AppendLine("group by ");
                sConsulta.AppendLine("datepart(MM,Dia.DiaClave), datename(mm,Dia.DiaClave), PRO.Id, PRO.NombreLargo, E.Nombre ");
                sConsulta.AppendLine(") as t");
                sConsulta.AppendLine((existeOrderProductos ? "left Join OrdenProductos OP (NOLOCK) on OP.ProductoClave = t.IDProducto " : ""));
                sConsulta.AppendLine((existeOrderProductos ? "order by OP.orden desc" : "order by t.NoMes, t.IDProducto"));
                sConsulta.AppendLine("");
                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                List<GAPProductosModel> Productos = Connection.Query<GAPProductosModel>(QueryString, null, null, true, 600).ToList();

                if (String.IsNullOrEmpty(RutasSplit))
                {
                    RutasSplit = "Todos";
                }
                else
                {
                    RutasSplit = RutasSplit.Replace(",", ", ");
                }

                if (String.IsNullOrEmpty(pvProductos))
                {
                    pvProductos = "Todos";
                }
                else
                {
                    pvProductos = pvProductos.Replace("'", "");
                    pvProductos = pvProductos.Replace(",", ", ");
                }
                
                string filename = NombreReporte + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + ".xlsx";
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

                createCell(1, ref Rows, "A1", CellValues.String, NombreEmpresa);

                createRow(2, ref Rows);
                createCell(2, ref Rows, "A2", CellValues.String, NombreReporte);

                createRow(4, ref Rows);
                createCell(4, ref Rows, "A4", CellValues.String, "Agencia: " + nombreCedis);

                createRow(5, ref Rows);
                createCell(5, ref Rows, "A5", CellValues.String, "Ruta: " + RutasSplit);

                createRow(6, ref Rows);
                createCell(6, ref Rows, "A6", CellValues.String, "Periodo: " + sFecha.ToString("dd/MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"));

                createRow(7, ref Rows);
                createCell(7, ref Rows, "A7", CellValues.String, "Esquemas de Producto: " + pvProductos);

                int currentRow = 9;

                //Encabezados
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Código");
                createCell(currentRow, ref Rows, null, CellValues.String, "Marca");
                createCell(currentRow, ref Rows, null, CellValues.String, "Cupo");

                foreach (GAPMesesModel drMes in Meses)
                {
                    createCell(currentRow, ref Rows, null, CellValues.String, drMes.Mes);
                    createCell(currentRow, ref Rows, null, CellValues.String, "");
                }
                currentRow++;


                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "C"+currentRow, CellValues.String, "");
                foreach (GAPMesesModel drMes in Meses)
                {
                    foreach(GAPAniosModel drAnio in Anios)
                    {
                        createCell(currentRow, ref Rows, null, CellValues.Number, drAnio.Anio);
                    }
                }

                currentRow++;

                //Detalle
                foreach (GAPProductosModel drProductos in Productos)
                {
                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, null, CellValues.Number, drProductos.IDProducto);
                    createCell(currentRow, ref Rows, null, CellValues.String, drProductos.NombreLargo);
                    createCell(currentRow, ref Rows, null, CellValues.String, drProductos.IDEsquema);

                    //Mes
                    foreach (GAPMesesModel drMes in Meses)
                    {
                        foreach (GAPAniosModel drAnio in Anios)
                        {
                            List<GAPClientesModel> drColsClientes = Clientes.Where(c => c.IDProducto == drProductos.IDProducto  && c.Mes == drMes.Mes && c.Anio == drAnio.Anio).ToList();
                            if(drColsClientes.Count() > 0)
                            {
                                foreach (GAPClientesModel drNoCliente in drColsClientes)
                                {
                                    createCell(currentRow, ref Rows, null, CellValues.Number, drNoCliente.NoClientes);
                                }
                            }
                            else
                            {
                                createCell(currentRow, ref Rows, null, CellValues.String, "");
                            }
                        }
                    }

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
                sheet.Name = NombreReporte;
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

        void createRow(int id, ref Dictionary<int, Row> Rows)
        {
            Rows.Add(id, new Row() { RowIndex = (UInt32)id });
        }

        void createCell(int idRow, ref Dictionary<int, Row> Rows, string cellReference, DocumentFormat.OpenXml.Spreadsheet.CellValues dt, string cellValue)
        {
            Cell cell = new Cell();
            if (cellReference != null)
                cell.CellReference = cellReference;
            cell.DataType = dt;
            cell.CellValue = new CellValue(cellValue);
            cell.CellValue.Space = SpaceProcessingModeValues.Preserve;
            if (Rows.ContainsKey(idRow))
            {
                Rows[idRow].Append(cell);
            }
        }

        bool ordenProductos(int numReporte)
        {
            string query = "Select * from OrdenProductos where ReporteW = '" + numReporte + "'";
            List<DataTable> dt = Connection.Query<DataTable>(query, null, null, true, 9000).ToList();

            if (dt.Count > 0)
                return true;
            else
                return false;
        }
    }

    class GAPClientesModel
    {
        public int NoMes { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }
        public string IDProducto { get; set; }
        public string NombreLargo { get; set; }
        public string IDEsquema { get; set; }
        public string NoClientes { get; set; }
    }

    class GAPMesesModel
    {
        public string Mes { get; set; }
    }

    class GAPAniosModel
    {
        public string Anio { get; set; }
    }

    class GAPProductosModel
    {
        public string NoMes { get; set; }
        public string Mes { get; set; }
        public string IDProducto { get; set; }
        public string NombreLargo { get; set; }
        public string IDEsquema { get; set; }
    }


}