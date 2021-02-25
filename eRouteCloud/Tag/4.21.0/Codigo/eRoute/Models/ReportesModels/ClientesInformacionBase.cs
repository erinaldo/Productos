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
    public class ClientesInformacionBase
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string nombreReport, string nombreCedis, string FechaInicial, string FechaFinal, string Cedis)
        {
            try
            {
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
                sConsulta1.AppendLine("Select ");
                sConsulta1.AppendLine("EsquemaID,Nombre");
                sConsulta1.AppendLine("From Esquema (NOLOCK) ");
                sConsulta1.AppendLine("where");
                sConsulta1.AppendLine("Tipo = 1");
                sConsulta1.AppendLine("and TipoEstado = 1");
                sConsulta1.AppendLine("and Nivel = 1");


                QueryString = "";
                QueryString = sConsulta1.ToString();

                List<EsquemaModel> Esquema1 = Connection.Query<EsquemaModel>(QueryString, null, null, true, 600).ToList();
                if (Esquema1.Count() <= 0)
                {
                    return null;
                }

                StringBuilder sConsulta2 = new StringBuilder();
                sConsulta2.AppendLine("SET LANGUAGE Spanish ");
                sConsulta2.AppendLine("Select ");
                sConsulta2.AppendLine("EsquemaID,Nombre");
                sConsulta2.AppendLine("From Esquema (NOLOCK) ");
                sConsulta2.AppendLine("where");
                sConsulta2.AppendLine("Tipo = 1");
                sConsulta2.AppendLine("and TipoEstado = 1");
                sConsulta2.AppendLine("and Nivel = 2");


                QueryString = "";
                QueryString = sConsulta2.ToString();

                List<EsquemaModel> Esquema2 = Connection.Query<EsquemaModel>(QueryString, null, null, true, 600).ToList();
                if (Esquema2.Count() <= 0)
                {
                    return null;
                }

                StringBuilder sConsulta3 = new StringBuilder();
                sConsulta3.AppendLine("SET LANGUAGE Spanish ");
                sConsulta3.AppendLine("Select ");
                sConsulta3.AppendLine("COUNT(distinct tp.ClienteClave)");
                sConsulta3.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta3.AppendLine("inner join Visita v (NOLOCK) on tp.VisitaClave = v.VisitaClave and tp.DiaClave = v.DiaClave");//sConsulta3.AppendLine("inner join Visita v on tp.VisitaClave = v.VisitaClave or tp.VisitaClave1 = v.VisitaClave");
                sConsulta3.AppendLine("inner join cliente c (NOLOCK) on v.ClienteClave = c.ClienteClave");
                sConsulta3.AppendLine("inner join ClienteEsquema ce (NOLOCK) on c.ClienteClave = ce.ClienteClave");
                sConsulta3.AppendLine("inner join Esquema e (NOLOCK) on ce.EsquemaID = e.EsquemaID or ce.EsquemaID = e.EsquemaIDPadre");
                sConsulta3.AppendLine("inner join Dia d (NOLOCK) on tp.DiaClave = d.DiaClave ");
                sConsulta3.AppendLine("where");
                sConsulta3.AppendLine("tp.Tipo = 1");
                sConsulta3.AppendLine("and tp.TipoFase in (2,3)");
                sConsulta3.AppendLine("and c.AlmacenID = '" +Cedis + "' ");


                QueryString = "";
                QueryString = sConsulta3.ToString();

                //string ConteoRegistros = Connection.Query<string>(QueryString, null, null, true, 600).FirstOrDefault();

                

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

                //createCell(1, ref Rows, "A1", CellValues.String, nombreEmpresa);
                createCell(1, ref Rows, "A1", CellValues.String, nombreEmpresa);

                createRow(2, ref Rows);
                createCell(2, ref Rows, "A2", CellValues.String, "Reporte: " + nombreReport);

                createRow(4, ref Rows);
                createCell(4, ref Rows, "A4", CellValues.String, "Agencia: "+ nombreCedis);

                createRow(5, ref Rows);
                createCell(5, ref Rows, "A5", CellValues.String, "Periodo: " + sFecha.ToString("dd/MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"));



                createRow(7, ref Rows);
                createCell(7, ref Rows, "A7", CellValues.String, "Canal");
                createCell(7, ref Rows, null, CellValues.String, "Segmentacion");

                DateTime tempFI = sFecha;

                int contadorFechas = 0;
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

                while (tempFI<=sFechaFin)
                {
                    createCell(7, ref Rows, null, CellValues.String, tempFI.ToString("MMMM") + "'" + tempFI.Year.ToString());
                    tempFI = tempFI.AddMonths(1);
                    contadorFechas++;
                }

                int currentRow = 7;
                string consultaEsquemas2;

                int[] universoTotal = new int[contadorFechas];

                foreach (var drEsquema in Esquema1)
                {

                    consultaEsquemas2 = sConsulta2.ToString() + " and EsquemaIDPadre = '" + drEsquema.EsquemaID + "'";
                    List<EsquemaModel> lista = Connection.Query<EsquemaModel>(consultaEsquemas2, null, null, true, 600).ToList();
                    int[,] total= new int[Esquema1.Count(), contadorFechas];
                    string numero;
                    int contadorFor = 0;
                    int contadorWhile = 0;
                    if (lista.Count() > 0)
                    {
                        currentRow++;
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, drEsquema.Nombre);

                    }
                    foreach (var drEsquema2 in lista)
                    {
                        currentRow++;
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, drEsquema2.Nombre);
                        DateTime desde2 = sFecha;
                        while(desde2 <= sFechaFin)
                        {
                            string consultaConteoRegistros = sConsulta3.ToString();
                            consultaConteoRegistros += "and DATEPART(MONTH,d.FechaCaptura) " + "=" + " DATEPART(MONTH,'" + desde2.ToString("dd/MM/yyyy") + "') and  DATEPART(YEAR,d.FechaCaptura) " + "=" + " DATEPART(YEAR,'" + desde2.ToString("dd/MM/yyyy") + "') and ce.EsquemaID = '" + drEsquema2.EsquemaID + "'";
                            numero = Connection.Query<string>(consultaConteoRegistros, null, null, true, 600).FirstOrDefault();
                            total[contadorFor, contadorWhile] = Convert.ToInt32(numero);
                            createCell(currentRow, ref Rows, null, CellValues.Number, numero);
                            desde2 = desde2.AddMonths(1);
                            contadorWhile++;
                        }
                        contadorWhile = 0;
                        contadorFor++;
                    }

                    if (lista.Count() > 0)
                    {
                        currentRow++;
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, "Total");
                        int y;
                        for (y = 0; y <= contadorFechas - 1; y++)
                        {
                            int totalNum = 0;
                            int z;
                            for (z = 0; z <= lista.Count() - 1; z++)
                            {
                                totalNum += total[z, y];
                            }
                            createCell(currentRow, ref Rows, null, CellValues.Number, totalNum.ToString());
                            universoTotal[y] = totalNum + universoTotal[y];
                        }
                        currentRow++;
                    }

                }

                currentRow++;
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Universo");

                currentRow++;
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, "Total");

                currentRow++;
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, "");

                for (int m = 0; m <= contadorFechas-1 ; m++)
                {
                    createCell(currentRow, ref Rows, null, CellValues.Number, universoTotal[m].ToString());
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


    }

    class ClientesInformacionBaseModel
    {
        public string ALMClave { get; set; }     
        public string ALMNombre { get; set; }
        public long OrdenEsquema { get; set; }
        public string ClaveEsquema { get; set; }
        public string NombreEsquema { get; set; }
        public string SAP { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Cupo { get; set; }
        public long TotalInventario { get; set; }
        public Decimal TotalLY { get; set; }
        public Decimal DiaDiaLY { get; set; }
        public Decimal DiaDia { get; set; }
        public long gTotalInventario { get; set; }
        public Decimal gTotalLY { get; set; }
        public Decimal gDiaDiaLY { get; set; }
        public Decimal gDiaDia { get; set; }
    }
    
    public class EsquemaModel
    {
        public string EsquemaID { get; set; }
        public string Nombre { get; set; }
    }
}