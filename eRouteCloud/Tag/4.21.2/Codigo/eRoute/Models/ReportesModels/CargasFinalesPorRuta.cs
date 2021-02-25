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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Threading;

namespace eRoute.Models.ReportesModels
{
    public class CargasFinalesPorRuta
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string pvCondicion, string pvCondicion1, string pvCondicion2, string pvCondicion3, string nombreReport, string RutasSplit, string nombreCedis, string FechaInicial, string FechaFinal, string Cedis, int vavclave, string dateStatus, string unidadMedida, string pvProductos, string nombreProductos, string pvCondicionProd, string whereAlmacen, string whereFechaDia, string whereEsquema)
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
                sConsulta.AppendLine("if (select object_id('tempdb..#Usuario')) is not null Drop Table #Usuario");
                sConsulta.AppendLine("Select V.USUId into #Usuario ");
                sConsulta.AppendLine("from Ruta R (NOLOCK) inner join VenRut VR (NOLOCK) on R.RUTClave = VR.RUTClave inner join Vendedor V (NOLOCK) on V.VendedorID = VR.VendedorID");
                sConsulta.AppendLine(pvCondicion1);
                sConsulta.AppendLine("select case when CI.Clasificacion = 9 then 'Cerveza' when CI.Clasificacion = 10 then 'Beerhouse' when CI.Clasificacion = 11 then 'Nestle' end  as Clasificacion,CI.Ruta,CI.Nombre,CI.Codigo,SUM(CI.CANTIDAD) as Cantidad from");
                sConsulta.AppendLine("(Select distinct BI.Clasificacion as Clasificacion, VR.RutClave as Ruta, P.Nombre as Nombre, TD.Productoclave as Codigo ,Td.Cantidad as Cantidad from TransProd T inner join Dia D on T.DiaClave = D.DiaClave ");
                sConsulta.AppendLine("inner join TransProdDetalle TD (NOLOCK) on T.TransProdID = TD.TransProdID");
                sConsulta.AppendLine("inner join Producto P (NOLOCK) on TD.Productoclave = P.ProductoClave");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PE.ProductoClave = P.ProductoClave");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID = E.EsquemaID");
                sConsulta.AppendLine("inner join Vendedor V (NOLOCK) on V.Usuid = T.Musuarioid ");
                sConsulta.AppendLine("inner join VenRut VR (NOLOCK) on V.VendedorId = VR.VendedorId");
                sConsulta.AppendLine("inner join ");
                sConsulta.AppendLine("(Select PRO.ProductoClave,LIN.CLasificacion");
                sConsulta.AppendLine("from ProductoEsquema PRE (NOLOCK) ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on PRO.ProductoClave = PRE.ProductoClave");
                sConsulta.AppendLine("inner join Esquema LIN (NOLOCK) on LIN.EsquemaID in (Select Ids from dbo.BuscaIdsEsquema(PRE.EsquemaID)) and LIN.Clasificacion in (9,10,11)) BI");
                sConsulta.AppendLine("on BI.ProductoClave = P.ProductoClave ");
                //sConsulta.AppendLine("where 1 = 1  and D.FechaCaptura between '2017-12-01T00:00:00' and '2017-12-01T23:00:00'
                sConsulta.AppendLine(pvCondicion2);

                sConsulta.AppendLine("and T.TIPO = 23 and T.Tipofase = 1 and T.MUsuarioID in(select USUid from #Usuario) and P.Contenido = 0 and P.Venta = 0");
               
                sConsulta.AppendLine(") as CI");
                sConsulta.AppendLine("group by CI.Clasificacion,CI.Ruta,CI.Nombre,CI.CODIGO order by CI.Codigo");




                QueryString = "";
                QueryString = sConsulta.ToString();


                List<FRutaModel> CargasF = Connection.Query<FRutaModel>(QueryString, null, null, true, 600).ToList();

                if (CargasF.Count == 0)
                {
                    return null;
                }

                string empresaQuery = "select NombreEmpresa from Configuracion (NOLOCK) ";
                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();


                string filename = nombreReport + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + ".xlsx";
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
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, nombreEmpresa);
                currentRow += 2;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Reporte: " + nombreReport);
                currentRow += 2;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Almacén: " + (nombreCedis == "null" ? "Todos" : nombreCedis));
                currentRow++;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Ruta: " + (RutasSplit == "null" ? "Todos" : RutasSplit));
                currentRow++;

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Fecha:  " + sFecha.ToString("dd/MM/yyyy"));
                currentRow += 2;



                List<String> rutas = RutasSplit.Split(',').ToList();

                var ListaClasificacion = CargasF.GroupBy(c => c.Clasificacion).ToList();
                foreach (var clasificacion in ListaClasificacion)
                {
                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, clasificacion.Key);
                    createCell(currentRow, ref Rows, null, CellValues.String, "CODIGO");
                    for (int i = 0; i < rutas.Count; i++)
                    {
                        createCell(currentRow, ref Rows, null, CellValues.String, "RUTA " + (i + 1));
                    }
                    createCell(currentRow, ref Rows, null, CellValues.String, "TOTAL");
                    currentRow++;

                    var clasificacionAgrupada = clasificacion.GroupBy(c => c.Codigo);
                    foreach (var clave in clasificacionAgrupada)
                    {
                        int totalClaves = 0;
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, clave.FirstOrDefault().Nombre);
                        createCell(currentRow, ref Rows, null, CellValues.Number, clave.FirstOrDefault().Codigo.ToString());
                        foreach (String ruta in rutas)
                        {
                            FRutaModel RutaM = clave.Where(c => c.Ruta == ruta).FirstOrDefault();
                            if (RutaM == null)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.String, "  -");
                            }
                            else
                            {
                                totalClaves += RutaM.Cantidad;
                                createCell(currentRow, ref Rows, null, CellValues.Number, RutaM.Cantidad.ToString());
                            }
                        }
                        createCell(currentRow, ref Rows, null, CellValues.Number, totalClaves.ToString());
                        currentRow++;
                    }
                    //

                    int totalCan = 0;
                    //var cantidads = clasificacion.Sum(c => c.Cantidad, c=> c.Ruta);

                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "TOTAL " + clasificacion.Key);
                    createCell(currentRow, ref Rows, null, CellValues.String, " ");
                    foreach (String ruta in rutas)
                    {


                        int Rutasc = clasificacion.Where(c => c.Ruta == ruta).ToList().Sum(c => c.Cantidad);

                        //if (Rutasc != null)
                        //{
                        //    totalCan += Rutasc.Cantidad;

                        //}

                        //var totalc = clasificacion.Sum(c => c.Cantidad);

                        createCell(currentRow, ref Rows, null, CellValues.Number, Rutasc.ToString());



                        /////////////
                    }
                    var total = clasificacion.Sum(c => c.Cantidad);


                    createCell(currentRow, ref Rows, null, CellValues.Number, total.ToString());

                    createCell(currentRow, ref Rows, null, CellValues.String, "");
                    currentRow += 3;
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

    class FRutaModel
    {
        public string Clasificacion { get; set; }
        public string Ruta { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public int Cantidad { get; set; }
    }



}