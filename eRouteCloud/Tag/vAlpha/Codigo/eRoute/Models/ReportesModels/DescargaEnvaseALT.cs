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
using System.Globalization;

namespace eRoute.Models.ReportesModels
{
    public class DescargaEnvaseALT
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string NombreReporte, string NombreEmpresa, string FechaInicial, string FechaFinal, string sCondicion, string sCondicion2, string RutasSplit)
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


                StringBuilder sConsulta = new StringBuilder();
                sConsulta.Append("Select Dia.DiaClave, sum(TPD.Cantidad * PRD.Factor ) as Cantidad ");
                sConsulta.Append("from TransProd TRP (NOLOCK) ");
                sConsulta.Append("inner join TransProdDetalle TPD (NOLOCK) ON TPD.TransProdID = TRP.TransProdID ");
                sConsulta.Append("inner join ProductoDetalle PRD (NOLOCK) ON TPD.ProductoClave = PRD.ProductoClave and TPD.TipoUnidad  = PRD.PRUTipoUnidad ");
                sConsulta.Append("inner join Producto PRO (NOLOCK) ON PRD.ProductoDetClave = PRO.ProductoClave and PRO.Contenido = 1 ");
                sConsulta.Append("inner join Visita VIS (NOLOCK) ON VIS.VisitaClave = (CASE WHEN TRP.VisitaClave1 is null THEN TRP.VisitaClave ELSE TRP.VisitaClave1 END) ");
                sConsulta.Append("inner join Dia (NOLOCK) ON Dia.DiaClave = Vis.DiaClave ");
                sConsulta.Append("and VIS.DiaClave =  (CASE WHEN TRP.DiaClave1 is null THEN TRP.DiaClave ELSE TRP.DiaClave1 END) ");
                sConsulta.Append("where TRP.Tipo = 1 and TRP.TipoFase in(2,3) ");
                sConsulta.Append(sCondicion);
                sConsulta.Append("Group by Dia.DiaClave ");


                QueryString = sConsulta.ToString();

                List<DEAVentasModel> Ventas = Connection.Query<DEAVentasModel>(QueryString, null, null, true, 600).ToList();
                if (Ventas.Count() <= 0)
                {
                    return null;
                }

                sConsulta = new StringBuilder();
                sConsulta.Append("Select Dia.DiaClave, PRO.ProductoClave , PRO.Nombre , sum(TPD.Cantidad*PRD.Factor ) as Cantidad ");
                sConsulta.Append("from TransProd TRP (NOLOCK) ");
                sConsulta.Append("inner join TransProdDetalle TPD (NOLOCK) ON TPD.TransProdID = TRP.TransProdID  ");
                sConsulta.Append("inner join ProductoDetalle PRD (NOLOCK) ON PRD.ProductoClave = TPD.ProductoClave and PRD.PRUTipoUnidad  = TPD.TipoUnidad ");
                sConsulta.Append("and PRD.ProductoDetClave = TPD.ProductoClave ");
                sConsulta.Append("inner join Producto PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido = 1 ");
                sConsulta.Append("inner join Vendedor VEN (NOLOCK) ON VEN.USUId = TRP.MUsuarioID ");
                sConsulta.Append("inner join Dia (NOLOCK) ON Dia.DiaClave = TRP.DiaClave ");
                sConsulta.Append("where TRP.Tipo = 7 and TRP.TipoFase <>0 ");
                sConsulta.Append(sCondicion2);
                sConsulta.Append("Group by Dia.DiaClave, PRO.ProductoClave, PRO.Nombre ");

                QueryString = sConsulta.ToString();
                List<DEADescargasModel> Devoluciones = Connection.Query<DEADescargasModel>(QueryString, null, null, true, 600).ToList();
                
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

                createRow(3, ref Rows);
                createCell(3, ref Rows, "A3", CellValues.String, "Fecha");
                createCell(3, ref Rows, "B3", CellValues.String, sFecha.ToString("dd/MM/yyyy") + ((sFechaFin == sFecha)? "": " - "+  sFechaFin.ToString("dd/MM/yyyy")));

                createRow(4, ref Rows);
                createCell(4, ref Rows, "A4", CellValues.String, "Ruta");
                createCell(4, ref Rows, "B4", CellValues.String, RutasSplit);

                createRow(5, ref Rows);
                createCell(5, ref Rows, "A5", CellValues.String, "Fecha");

                Decimal dTemp = 0;
                List<String> sNombres = new List<String>();
                List<String> productos = new List<String>();
                foreach (DEADescargasModel drDia in Devoluciones.GroupBy(c => c.ProductoClave).Select(c => c.FirstOrDefault()).ToList())
                {
                    createCell(5, ref Rows, null, CellValues.Number, drDia.ProductoClave.ToString());
                    sNombres.Add(drDia.Nombre);
                    productos.Add(drDia.ProductoClave.ToString());
                }

                createCell(5, ref Rows, null, CellValues.String, "Total");
                createCell(5, ref Rows, null, CellValues.String, "Devolución Envases");

                createRow(6, ref Rows);
                createCell(6, ref Rows, "A6", CellValues.String, "");


                foreach (String nombre in sNombres)
                {
                    createCell(6, ref Rows, null, CellValues.String, nombre);
                }

                int currentRow = 7;
                createRow(currentRow, ref Rows);

                Decimal dTotalProducto;
                Decimal dTotal;
                foreach (DEADescargasModel drDia in Devoluciones.GroupBy(c => c.DiaClave).Select(c => c.FirstOrDefault()).ToList())
                {
                    createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, drDia.DiaClave.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    dTotal = 0;
                    foreach(string productoClave in productos)
                    {
                        dTotalProducto = 0;
                        if (Devoluciones.Where(c => c.ProductoClave.ToString() == productoClave && c.DiaClave == drDia.DiaClave).ToList().Count() >0)
                        {
                            dTotalProducto = Devoluciones.Where(c => c.ProductoClave.ToString() == productoClave && c.DiaClave == drDia.DiaClave).FirstOrDefault().Cantidad;
                            createCell(currentRow, ref Rows, null, CellValues.Number, dTotalProducto.ToString());
                        }
                        else
                        {
                            createCell(currentRow, ref Rows, null, CellValues.String, "");
                        }
                        dTotal += dTotalProducto;
                    }
                    createCell(currentRow, ref Rows, null, CellValues.Number, dTotal.ToString());
                    if (Ventas.Where(c => c.DiaClave == drDia.DiaClave).ToList().Count()>0)
                    {
                        createCell(currentRow, ref Rows, null, CellValues.Number, Ventas.Where(c => c.DiaClave == drDia.DiaClave).FirstOrDefault().Cantidad.ToString());
                    }


                    currentRow++;
                    createRow(currentRow, ref Rows);
                }

                createCell(currentRow, ref Rows, null, CellValues.String, "TOTALES");
                dTotal = 0;
                foreach (string productoClave in productos)
                {
                    dTotalProducto = Devoluciones.Where(c => c.ProductoClave.ToString() == productoClave).Sum(c => c.Cantidad);
                    createCell(currentRow, ref Rows, null, CellValues.Number, dTotalProducto.ToString());
                    dTotal += dTotalProducto;
                }

                createCell(currentRow, ref Rows, null, CellValues.Number, dTotal.ToString());

                createCell(currentRow, ref Rows, null, CellValues.Number, Ventas.Sum(c => c.Cantidad).ToString());






                foreach (var row in Rows)
                {
                    sd.Append(row.Value);
                }

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = NombreReporte.Substring(0, 31);
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

    }

    class DEAVentasModel
    {
        public DateTime DiaClave { get; set; }
        public Decimal Cantidad { get; set; }
    }

    class DEADescargasModel
    {
        public DateTime DiaClave { get; set; }
        public int ProductoClave { get; set; }
        public string Nombre { get; set; }
        public Decimal Cantidad { get; set; }
    }

}