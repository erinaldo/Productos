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
    public class CoberturaPorProductoMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string nombreReport, string nombreCedis, string FechaInicial, string FechaFinal, string Cedis, string whereAlmacen, string whereFechaDia, string whereEsquema, int vavclave, string dateStatus, string unidadMedida, string pvProductos, string nombreProductos)
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


                StringBuilder sConsulta1 = new StringBuilder();
                sConsulta1.AppendLine("SET LANGUAGE Spanish ");
                sConsulta1.AppendLine("Select  Distinct YEAR(D.FechaCaptura) As Anio, MONTH(D.FechaCaptura) as Mes, E.Nombre, P.Nombre AS NombreProducto, COUNT(distinct V.ClienteClave) as ClienteVisitados ");
                sConsulta1.AppendLine("from TransProd TP (NOLOCK) ");
                sConsulta1.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = Isnull(TP.VisitaClave,TP.VisitaClave1) and TP.Tipo = 1 and TipoFase in ('2','3') ");
                sConsulta1.AppendLine("inner join VENCentroDistHist VDH (NOLOCK) on VDH.VendedorId = V.VendedorID ");
                sConsulta1.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VDH.AlmacenId ");
                sConsulta1.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = ISNULL(TP.DiaClave,TP.DiaClave1) and D.FechaCaptura BETWEEN VDH.VCHFechaInicial AND VDH.FechaFinal ");
                sConsulta1.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TP.TransProdID = TPD.TransProdID ");
                sConsulta1.AppendLine("inner join ProductoEsquema PE (NOLOCK) on TPD.ProductoClave = PE.ProductoClave ");
                sConsulta1.AppendLine("inner join Esquema E (NOLOCK) on E.EsquemaID = PE.EsquemaID ");
                sConsulta1.AppendLine("inner join ProductoUnidad PU (NOLOCK) on PU.ProductoClave = PE.ProductoClave ");
                sConsulta1.AppendLine("inner join Producto P (NOLOCK) on PE.ProductoClave = P.ProductoClave ");
                sConsulta1.AppendLine("where 1=1");
                sConsulta1.AppendLine(whereAlmacen);
                sConsulta1.AppendLine(whereFechaDia);
                sConsulta1.AppendLine(whereEsquema);
                sConsulta1.AppendLine("Group By YEAR(D.FechaCaptura), MONTH(D.FechaCaptura), E.Nombre, P.Nombre ");
                sConsulta1.AppendLine("order by Anio, Mes, E.Nombre, P.Nombre ");


                QueryString = "";
                QueryString = sConsulta1.ToString();

                List<C1CoberturaPorProductoMORModel> Todo = Connection.Query<C1CoberturaPorProductoMORModel>(QueryString, null, null, true, 600).ToList();
                if (Todo.Count() <= 0)
                {
                    return null;
                }

                StringBuilder sConsulta2 = new StringBuilder();
                sConsulta2.AppendLine("SET LANGUAGE Spanish ");
                sConsulta2.AppendLine("Select  Distinct E.Nombre, P.Nombre as Producto ");
                sConsulta2.AppendLine("from TransProd TP (NOLOCK) ");
                sConsulta2.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = Isnull(TP.VisitaClave,TP.VisitaClave1) and TP.Tipo = 1 and TipoFase in ('2','3') ");
                sConsulta2.AppendLine("inner join VENCentroDistHist VDH (NOLOCK) on VDH.VendedorId = V.VendedorID  ");
                sConsulta2.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VDH.AlmacenId ");
                sConsulta2.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = ISNULL(TP.DiaClave,TP.DiaClave1) and D.FechaCaptura BETWEEN VDH.VCHFechaInicial AND VDH.FechaFinal ");
                sConsulta2.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TP.TransProdID = TPD.TransProdID ");
                sConsulta2.AppendLine("inner join ProductoEsquema PE (NOLOCK) on TPD.ProductoClave = PE.ProductoClave ");
                sConsulta2.AppendLine("inner join Esquema E (NOLOCK) on E.EsquemaID = PE.EsquemaID ");
                sConsulta2.AppendLine("inner join ProductoUnidad PU (NOLOCK) on PU.ProductoClave = PE.ProductoClave ");
                sConsulta2.AppendLine("inner join Producto P (NOLOCK) on PE.ProductoClave = P.ProductoClave ");
                if (existeOrderProductos)
                    sConsulta2.AppendLine("left join OrdenProductos OP (NOLOCK) on P.ProductoClave = Op.ProductoClave and Op.ReporteW = 166");
                sConsulta2.AppendLine("where 1=1");
                sConsulta2.AppendLine(whereAlmacen);
                sConsulta2.AppendLine(whereFechaDia);
                sConsulta2.AppendLine(whereEsquema);
                sConsulta2.AppendLine("order by E.Nombre, ");
                if (existeOrderProductos)
                    sConsulta2.AppendLine("OP.Orden Desc");
                else
                    sConsulta2.AppendLine("P.Nombre ");


                QueryString = "";
                QueryString = sConsulta2.ToString();

                List<C2CoberturaPorProductoMORModel> Productos = Connection.Query<C2CoberturaPorProductoMORModel>(QueryString, null, null, true, 600).ToList();
                if (Productos.Count() <= 0)
                {
                    return null;
                }

                string whereLY = String.Empty;
                string whereActual = String.Empty;

                switch (dateStatus)
                {
                    case "Igual":
                        whereLY = "and d.FechaCaptura = Dateadd(year,-1,'" + dFechaIni.Date.ToString("dd/MM/yyyy") + "')";
                        whereActual = "and d.FechaCaptura = '" + dFechaIni.Date.ToString("dd/MM/yyyy") + "' ";
                        break;
                    case "Entre":
                        whereLY = " and d.FechaCaptura between Dateadd(year,-1,'" + dFechaIni.Date.ToString("dd/MM/yyyy") + "') and Dateadd(year,-1,'" + dFechaFin.Date.ToString("dd/MM/yyyy") + "')";
                        whereActual = "and d.FechaCaptura between '" + dFechaIni.Date.ToString("dd/MM/yyyy") + "' and '" + dFechaFin.Date.ToString("dd/MM/yyyy") + "'";
                        break;
                }

                StringBuilder sConsulta3 = new StringBuilder();
                sConsulta3.AppendLine("SET LANGUAGE Spanish ");
                sConsulta3.AppendLine("Select YEAR(D.FechaCaptura) As Anio, MONTH(D.FechaCaptura) as Mes, ");
                if (unidadMedida == "Cartones")
                    sConsulta3.AppendLine(" SUM(TPD.Cantidad) As Cantidad");
                else
                    sConsulta3.AppendLine(" SUM((TPD.Cantidad * PU.Volumen)) as Cantidad ");
                sConsulta3.AppendLine("From ProductoUnidad PU (NOLOCK) ");
                sConsulta3.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TPD.ProductoClave = pu.ProductoClave ");
                sConsulta3.AppendLine("inner join TransProd TP (NOLOCK) on TPD.TransProdID = TP.TransProdID  ");
                sConsulta3.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = ISNULL(TP.DiaClave,TP.DiaClave1) ");
                sConsulta3.AppendLine("where 1=1");

                string consultaLY = sConsulta3.ToString();
                consultaLY += whereLY;
                consultaLY += " Group By YEAR(D.FechaCaptura), MONTH(D.FechaCaptura) ";

                List<C3CoberturaPorProductoMORModel> LY = Connection.Query<C3CoberturaPorProductoMORModel>(consultaLY, null, null, true, 600).ToList();

                string consultaActual = sConsulta3.ToString();
                consultaActual += whereActual;
                consultaActual += " Group By YEAR(D.FechaCaptura), MONTH(D.FechaCaptura) ";

                List<C3CoberturaPorProductoMORModel> Actual = Connection.Query<C3CoberturaPorProductoMORModel>(consultaActual, null, null, true, 600).ToList();


                string empresaQuery = "select NombreEmpresa from Configuracion (NOLOCK) ";
                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();


                string filename = nombreReport+ DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")+".xlsx";
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
                createCell(4, ref Rows, "A4", CellValues.String, "Agencia: "+ nombreCedis);

                createRow(5, ref Rows);
                createCell(5, ref Rows, "A5", CellValues.String, "Periodo: " + sFecha.ToString("dd /MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"));



                createRow(6, ref Rows);
                createCell(6, ref Rows, "A6", CellValues.String, "Segmentos: " + nombreProductos);

                //convertimos la unidadMedida a hectolitraje si es hectolitros
                if (unidadMedida != "Cartones")
                    unidadMedida = "Hectolitraje";
                createRow(7, ref Rows);
                createCell(7, ref Rows, "A7", CellValues.String, "Unidad: " + unidadMedida);


                //cuerpo
                string acumularEsquemas = String.Empty;
                int mesesSoloUnavez = 0;
                int contadorCobertura = 0;

                string stLy = String.Empty;
                string stActual = String.Empty;

                DateTime desde = dFechaIni;
                string mes = String.Empty;
                int contadorFecha = 0;
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

                while (desde<=dFechaFin)
                {
                    mes += desde.ToString("MMMM") + "'" + desde.Year.ToString() + "|";
                    var drLY = (from c in LY where c.Anio == desde.Year.ToString() where c.Mes == desde.Month.ToString() select c.Cantidad).ToList();

                    if (drLY.Count > 0)
                    {
                        stLy += drLY.FirstOrDefault() + "|";
                    }
                    else
                    {
                        stLy += "0|";
                    }

                    var drActual = (from c in Actual where c.Anio == desde.Year.ToString() where c.Mes == desde.Month.ToString() select c.Cantidad).ToList();

                    if (drActual.Count > 0)
                    {
                        stActual += drActual.FirstOrDefault() + "|";
                    }
                    else
                    {
                        stActual += "0|";
                    }
                    desde = desde.AddMonths(1);
                    contadorFecha++;
                }

                int[] totalCantidades = new int[contadorFecha];
                string ventaTotal = String.Empty;
                int ultimoRegistro = Productos.Count();
                int contadorFor = 0;

                List<string> totalesSplit = new List<string>();

                int currentRow = 8;

                foreach(var drProducto in Productos)
                {
                    string cabecera = string.Empty;
                    if (!acumularEsquemas.Contains(drProducto.Nombre))
                    {
                        contadorCobertura = 0;
                        acumularEsquemas += drProducto.Nombre;
                        cabecera = drProducto.Nombre;

                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "C"+currentRow, CellValues.String, ventaTotal);
                        foreach (var oneTotal in totalesSplit)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, oneTotal.Replace(",", "."));
                        }
                        currentRow += 2;

                        if (mesesSoloUnavez == 1)
                        {
                            createRow(currentRow, ref Rows);
                            createCell(currentRow, ref Rows, "B"+currentRow, CellValues.String, "Venta");
                            createCell(currentRow, ref Rows, null, CellValues.String, "LY");
                            List<string> LYSplit = stLy.Split('|').ToList();
                            foreach (var oneLY in LYSplit)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, oneLY.Replace(",", "."));
                            }

                            currentRow++;

                            createRow(currentRow, ref Rows);
                            createCell(currentRow, ref Rows, "C" + currentRow, CellValues.String, "Actual");
                            List<string> ActualSplit = stActual.Split('|').ToList();
                            foreach (var oneActual in ActualSplit)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, oneActual.Replace(",", "."));
                            }

                            currentRow++;
                        }

                        int xx = 0;
                        for (xx=0;xx<totalCantidades.Length;xx++)
                        {
                            totalCantidades[xx] = 0;
                        }

                        currentRow++;

                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "A"+currentRow, CellValues.String, cabecera);
                        createCell(currentRow, ref Rows, null, CellValues.String, "");

                        if (mesesSoloUnavez == 0)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.String, "Presentacion");
                            List<string> meses = mes.Split('|').ToList();
                            foreach(var mesanio in meses)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.String, mesanio);
                            }
                        }
                        currentRow++;

                        mesesSoloUnavez = 1;

                    }

                    desde = dFechaIni;
                    string cantidades = string.Empty;
                    int contFecha = 0;

                    while(desde <= dFechaFin)
                    {
                        var filaProductos = (from c in Todo where c.Anio == desde.Year.ToString() where c.Mes == desde.Month.ToString() where c.Nombre == drProducto.Nombre where c.NombreProducto == drProducto.Producto  select c.ClienteVisitados).ToList();

                        if (filaProductos.Count > 0)
                        {
                            cantidades += filaProductos.FirstOrDefault().ToString() + "|";
                            totalCantidades[contFecha] = totalCantidades[contFecha] + filaProductos.FirstOrDefault();
                        }
                        else
                        {
                            cantidades += "0|";
                            totalCantidades[contFecha] = totalCantidades[contFecha] + 0;
                        }
                        desde = desde.AddMonths(1);
                        contFecha++;
                    }

                    //variable de prueba
                    string cobertura = string.Empty;
                    if(contadorCobertura == 0)
                    {
                        cobertura = "Cobertura";
                    }


                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, cobertura);
                    createCell(currentRow, ref Rows, null, CellValues.String, drProducto.Producto);

                    List<string> cantidadesSplit = cantidades.Split('|').ToList();
                    foreach (var cantidadIndividual in cantidadesSplit)
                    {
                        createCell(currentRow, ref Rows, null, CellValues.Number, cantidadIndividual.Replace(",", "."));
                    }

                    //createCell(currentRow, ref Rows, null, CellValues.String, cantidades);

                    currentRow++;

                    string totales = string.Empty;
                    int x = 0;
                    for (x=0;x<totalCantidades.Length;x++)
                    {
                        if (x == totalCantidades.Length - 1)
                        {
                            totales += totalCantidades[x].ToString();
                        }else
                        {
                            totales += totalCantidades[x].ToString() + "|";
                        }
                    }

                    ventaTotal = "Venta " + drProducto.Nombre;

                    contadorCobertura++;
                    contadorFor++;

                    totalesSplit = totales.Split('|').ToList();

                    if (contadorFor == ultimoRegistro)
                    {
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "C" + currentRow, CellValues.String, ventaTotal);
                        
                        foreach (var oneTotal in totalesSplit)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, oneTotal);
                        }

                        currentRow+=2;

                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, "Venta");
                        createCell(currentRow, ref Rows, null, CellValues.String, "LY");
                        List<string> LYSplit = stLy.Split('|').ToList();
                        foreach (var oneLY in LYSplit)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, oneLY.Replace(",", "."));
                        }
                        //createCell(currentRow, ref Rows, null, CellValues.String, stLy);
                        currentRow++;
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "C" + currentRow, CellValues.String, "Actual");
                        List<string> ActualSplit = stActual.Split('|').ToList();
                        foreach (var oneActual in ActualSplit)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, oneActual.Replace(",", "."));
                        }

                        currentRow++;
                    }

                }

                currentRow++;
                currentRow++;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, "** En la sección de cobertura de Productos se presenta la cantidad de clientes con venta del producto y en la sección de venta dependerá del filtro de unidad.");



                foreach (var row in Rows)
                {
                    sd.Append(row.Value);
                }

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = nombreReport;
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

        void createCell(int idRow,ref Dictionary<int, Row> Rows,  string cellReference, DocumentFormat.OpenXml.Spreadsheet.CellValues dt, string cellValue)
        {
            Cell cell = new Cell();
            if (cellReference != null)
                cell.CellReference = cellReference;
            cell.DataType = dt;
            cell.CellValue = new CellValue(cellValue);
            if (Rows.ContainsKey(idRow))
            {
                Rows[idRow].Append(cell);
            }
        }

        bool ordenProductos(int numReporte)
        {
            string query = "Select * from OrdenProductos (NOLOCK) where ReporteW = '" + numReporte + "'";
            List<DataTable> dt = Connection.Query<DataTable>(query, null, null, true, 9000).ToList();

            if(dt.Count > 0)
                return true;
            else
            return false;
        }
    }

    class C1CoberturaPorProductoMORModel
    {
        public string Anio { get; set; }     
        public string Mes { get; set; }
        public string Nombre { get; set; }
        public string NombreProducto { get; set; }
        public int ClienteVisitados { get; set; }
    }

    class C2CoberturaPorProductoMORModel
    {
        public string Nombre { get; set; }
        public string Producto { get; set; }
    }

    class C3CoberturaPorProductoMORModel
    {
        public string Anio { get; set; }
        public string Mes { get; set; }
        public string Cantidad { get; set; }
    }


}