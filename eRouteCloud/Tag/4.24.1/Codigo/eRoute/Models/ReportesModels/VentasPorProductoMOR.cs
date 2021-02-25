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
    public class VentasPorProductoMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string NombreReporte, string NombreEmpresa, string nombreCedis, string FechaInicial, string FechaFinal, string Cedis, int vavclave, string dateStatus, string unidadMedida, string pvProductos, string nombreProductos, string pvCondicionProd, string whereAlmacen, string whereFechaDia, string whereEsquema)
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
                sConsulta.AppendLine("SET LANGUAGE Spanish ");
                sConsulta.AppendLine("Select Distinct  YEAR(D.FechaCaptura) As Anio, MONTH(D.FechaCaptura) as Mes, E.Nombre, P.Id, P.NombreLargo, " + (unidadMedida == "Cartones" ? "SUM( TPD.Cantidad ) as Cantidades " : "SUM(  TPD.Cantidad * PU.Volumen ) as Cantidades"));
                sConsulta.AppendLine("From TransProd TP (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = isnull(TP.VisitaClave, TP.VisitaClave1) and TP.Tipo = 1 and TP.TipoFase in (2,3) ");
                sConsulta.AppendLine("inner join VENCentroDistHist VDH (NOLOCK) on VDH.VendedorId = V.VendedorID ");
                sConsulta.AppendLine("inner join Almacen A (NOLOCK) on VDH.AlmacenId = A.AlmacenID ");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = isnull(TP.DiaClave, TP.DiaClave1) and D.FechaCaptura BETWEEN VDH.VCHFechaInicial AND VDH.FechaFinal ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TPD.TransProdID = TP.TransProdID and TPD.Promocion <> 2 ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on PU.ProductoClave = TPD.ProductoClave ");
                sConsulta.AppendLine("inner join Producto P (NOLOCK) on P.ProductoClave = PU.ProductoClave and P.Contenido = 0 and P.Venta = 0 ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on P.ProductoClave = PE.ProductoClave ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID = E.EsquemaID ");
                sConsulta.AppendLine("where 1=1 ");
                sConsulta.AppendLine(whereAlmacen);
                sConsulta.AppendLine(whereFechaDia);
                sConsulta.AppendLine(whereEsquema);
                sConsulta.AppendLine("Group by YEAR(D.FechaCaptura), MONTH(D.FechaCaptura),E.Nombre , P.Id, P.NombreLargo ");

                QueryString = sConsulta.ToString();


                List<VPPTodosModel> Todos = Connection.Query<VPPTodosModel>(QueryString, null, null, true, 600).ToList();
                if (Todos.Count() <= 0)
                {
                    return null;
                }


                sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select Distinct E.Nombre as Esquema,  P.Id, P.Nombre" + (existeOrderProductos ? ", OP.Orden  " : ""));
                sConsulta.AppendLine("From TransProd TP (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = isnull(TP.VisitaClave, TP.VisitaClave1) and TP.Tipo = 1 and TP.TipoFase in (2,3) ");
                sConsulta.AppendLine("inner join VENCentroDistHist VDH (NOLOCK) on VDH.VendedorId = V.VendedorID ");
                sConsulta.AppendLine("inner join Almacen A (NOLOCK) on VDH.AlmacenId = A.AlmacenID");
                sConsulta.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = isnull(TP.DiaClave, TP.DiaClave1) and D.FechaCaptura BETWEEN VDH.VCHFechaInicial AND VDH.FechaFinal ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TPD.TransProdID = TP.TransProdID and TPD.Promocion <> 2 ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on PU.ProductoClave = TPD.ProductoClave ");
                sConsulta.AppendLine("inner join Producto P (NOLOCK) on P.ProductoClave = PU.ProductoClave and P.Contenido = 0 and P.Venta = 0 ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on P.ProductoClave = PE.ProductoClave ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID = E.EsquemaID");
                sConsulta.AppendLine((existeOrderProductos ? "left join OrdenProductos OP (NOLOCK) On OP.ProductoClave = P.ProductoClave and OP.ReporteW = '169'" : ""));
                sConsulta.AppendLine("where 1=1");
                sConsulta.AppendLine(whereAlmacen);
                sConsulta.AppendLine(whereFechaDia);
                sConsulta.AppendLine(whereEsquema);
                sConsulta.AppendLine("Group by E.Nombre , P.Id, P.Nombre" + (existeOrderProductos ? ", OP.Orden" : ""));
                sConsulta.AppendLine("Order By E.Nombre , " + (existeOrderProductos ? "OP.Orden DESC" : "P.Nombre"));

                QueryString = sConsulta.ToString();


                List<VPPProductosModel> Productos = Connection.Query<VPPProductosModel>(QueryString, null, null, true, 600).ToList();




                sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET LANGUAGE Spanish ");
                sConsulta.AppendLine("Select  ");
                sConsulta.AppendLine("ES.Clave, E.Nombre, PE.ProductoClave ");
                sConsulta.AppendLine("From ProductoEsquema PE (NOLOCK) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID = E.EsquemaID ");
                sConsulta.AppendLine("inner join Esquema ES (NOLOCK) on E.EsquemaIDPadre = ES.EsquemaID ");
                sConsulta.AppendLine("where ");
                sConsulta.AppendLine("E.Tipo = 2 ");
                sConsulta.AppendLine("and E.TipoEstado = 1 ");
                sConsulta.AppendLine("and ES.Tipo = 2 ");
                sConsulta.AppendLine("and ES.TipoEstado = 1 ");
                sConsulta.AppendLine("and ES.Clave IN ('CUP','MAR') ");

                QueryString = sConsulta.ToString();

                List<VPPEsquemasCupMarModel> Esquemas = Connection.Query<VPPEsquemasCupMarModel>(QueryString, null, null, true, 600).ToList();
                
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


                int currentRow = 1;
                Dictionary<int, Row> Rows = new Dictionary<int, Row>();

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, NombreEmpresa);
                currentRow++;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Reporte: " + NombreReporte);
                currentRow += 2;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Agencia: " + (nombreCedis == "null" ? "Todos" : nombreCedis));
                currentRow++;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Periodo: " + sFecha.ToString("dd/MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"));
                currentRow++;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Segmentos: " + nombreProductos);
                currentRow++;

                //convertimos la unidadMedida a hectolitraje si es hectolitros
                if (unidadMedida != "Cartones")
                    unidadMedida = "Hectolitraje";
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Unidad: " + unidadMedida);
                currentRow += 2;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Código");
                createCell(currentRow, ref Rows, null, CellValues.String, "Marca");
                createCell(currentRow, ref Rows, null, CellValues.String, "Cupo");

                DateTime fInicio = sFecha;
                int fechasContador = 0;
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

                while (fInicio <= sFechaFin)
                {
                    createCell(currentRow, ref Rows, null, CellValues.String, fInicio.ToString("MMMM") + "'" + fInicio.Year.ToString());
                    fInicio = fInicio.AddMonths(1);
                    fechasContador++;
                }
                currentRow++;

                string acomuladoEsquemas = "";
                string esquemaActual = "";
                int contadorFor = 0;
                int totalFilas = Productos.Count();
                Int64[] totales = new Int64[fechasContador];

                foreach (VPPProductosModel drProducto in Productos)
                {

                    if (!acomuladoEsquemas.Contains(drProducto.Esquema))
                    {
                        if(contadorFor > 0)
                        {
                            createRow(currentRow, ref Rows);
                            createCell(currentRow, ref Rows, "C" + currentRow, CellValues.String, "Subtotal " + esquemaActual);
                            int x = 0;
                            for(x = 0; x<= totales.Length - 1; x++)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, totales[x].ToString());
                                totales[x] = 0;
                            }
                            currentRow += 2;
                        }
                        acomuladoEsquemas += drProducto.Esquema + ",";
                        esquemaActual = drProducto.Esquema;
                    }

                    string concatenarCantidadMes = "";
                    DateTime desde = sFecha;
                    int contador = 0;

                    List<VPPEsquemasCupMarModel> drMarca = (from gr in Esquemas where gr.ProductoClave == drProducto.Id && gr.Clave == "MAR" select gr).ToList();
                    string marca = "";
                    if (drMarca.Count() > 0)
                    {
                        marca = drMarca.FirstOrDefault().Nombre;
                    }

                    List<VPPEsquemasCupMarModel> drCupo = (from gr in Esquemas where gr.ProductoClave == drProducto.Id && gr.Clave == "CUP" select gr).ToList();
                    string cupo = "";
                    if (drCupo.Count() > 0)
                    {
                        cupo = drCupo.FirstOrDefault().Nombre;
                    }

                    createRow(currentRow, ref Rows);
                    //evaluamos si el id del producto es decimal, si lo es lo mandamos como tal, sino lo mandamos como string
                    Decimal temp;
                    if (Decimal.TryParse(drProducto.Id, out temp))
                    {
                        createCell(currentRow, ref Rows, "A" + currentRow, CellValues.Number, drProducto.Id);
                    }
                    else
                    {
                        createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, drProducto.Id);
                    }

                    createCell(currentRow, ref Rows, null, CellValues.String, marca);
                    createCell(currentRow, ref Rows, null, CellValues.String, cupo);


                    while (desde <= sFechaFin)
                    {
                        List<VPPTodosModel> drCantidad = (from gr in Todos where gr.Anio == desde.Year.ToString() && gr.Mes == desde.Month.ToString() && gr.Nombre == drProducto.Esquema && gr.Id == drProducto.Id select gr).ToList();

                        if (drCantidad.Count() > 0)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, drCantidad.FirstOrDefault().Cantidades.ToString().Replace(",", "."));
                            totales[contador] += (Int64)Math.Round(drCantidad.First().Cantidades,0);//Convert.ToInt64(Math.Round(Convert.ToDouble(value)))       drCantidad.First().Cantidades
                        }
                        else
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, "0");
                        }

                        desde = desde.AddMonths(1);
                        contador++;
                    }

                    currentRow++;

                    contadorFor++;

                    if(contadorFor == totalFilas)
                    {
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "C" + currentRow, CellValues.String, "Subtotal " + esquemaActual);
                        int x = 0;
                        for (x = 0; x <= totales.Length-1; x++)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, totales[x].ToString());
                        }
                        currentRow++;
                    }

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
            string query = "Select * from OrdenProductos (NOLOCK) where ReporteW = '" + numReporte + "'";
            List<DataTable> dt = Connection.Query<DataTable>(query, null, null, true, 9000).ToList();

            if (dt.Count > 0)
                return true;
            else
                return false;
        }
    }

    class VPPTodosModel
    {
        public string Anio { get; set; }
        public string Mes { get; set; }
        public string Nombre { get; set; }
        public string Id { get; set; }
        public string NombreLargo { get; set; }
        public Decimal Cantidades { get; set; }
    }

    class VPPProductosModel
    {
        public string Esquema { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }
    }

    class VPPEsquemasCupMarModel
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ProductoClave { get; set; }
    }


}