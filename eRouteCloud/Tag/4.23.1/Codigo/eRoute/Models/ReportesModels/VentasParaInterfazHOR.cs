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

namespace eRoute.Models.ReportesModels
{
    public class VentasParaInterfazHOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string NombreReporte;
        private string NombreEmpresa;


        public bool GetReport(string NombreReporte, string NombreEmpresa, string FechaInicial, string FechaFinal, string Vendedor)
        {
            try
            {
                this.NombreReporte = NombreReporte;
                this.NombreEmpresa = NombreEmpresa;

                //Fecha
                string FechaIni = "";
                string FechaFin = "";
                //Filtros
                string FiltroI = "";
                string FiltroF = "";
                if (FechaInicial != "null")
                {
                    FiltroI = DateTime.Parse(FechaInicial).Date.ToString("yyyyMMdd");
                    FechaIni = DateTime.Parse(FechaInicial).Date.ToShortDateString();
                }
                if (FechaFinal != "null")
                {
                    FiltroF = DateTime.Parse(FechaFinal).Date.ToString("yyyyMMdd");
                    FechaFin = DateTime.Parse(FechaFinal).Date.ToShortDateString();
                }
                else
                {
                    FiltroF = DateTime.Parse(FechaInicial).Date.ToString("yyyyMMdd");
                }
             
                StringBuilder Consulta = new StringBuilder();

                Consulta.AppendLine("Set ANSI_WARNINGS OFF ");
                Consulta.AppendLine("Set nocount on ");
                Consulta.AppendLine("declare @FechaIni datetime");
                Consulta.AppendLine("declare @FechaFin datetime");
                Consulta.AppendLine("set @FechaIni = '" + FiltroI + "'");
                Consulta.AppendLine("set @FechaFin = '" + FiltroF + "'");
                Consulta.AppendLine("SELECT V.VendedorID, TP.Folio, Cl.Clave, TPD.ProductoClave, TPD.Cantidad, Convert(Decimal(6,2),TPD.Precio,2) AS Precio FROM TransProd TP ");
                Consulta.AppendLine("INNER JOIN Visita V ON TP.VisitaClave = V.VisitaClave AND TP.Tipo = 1 AND TP.TipoFase = 2 ");
                if (Vendedor != "null" && Vendedor != "")
                    Consulta.AppendLine("    AND V.VendedorID IN ("+Vendedor+") ");
                Consulta.AppendLine("INNER JOIN Dia D ON D.DiaClave = V.DiaClave AND D.FechaCaptura BETWEEN @FechaIni AND @FechaFin");
                Consulta.AppendLine("INNER JOIN Cliente Cl ON V.ClienteClave = Cl.ClienteClave ");
                Consulta.AppendLine("INNER JOIN TransProdDetalle TPD ON TP.TransProdID = TPD.TransProdID ");
                //Consulta.AppendLine("INNER JOIN TPDImpuesto TI ON TPD.TransProdID = TI.TransProdID AND TPD.TransProdDetalleID = TI.TransProdDetalleID ");
                Consulta.AppendLine("ORDER BY V.VendedorID, TP.Folio ");
                
                QueryString = "";
                QueryString = Consulta.ToString();
                List<VentasParaInterfaz> Detalle = Connection.Query<VentasParaInterfaz>(QueryString, null, null, true, 600).ToList();
                               
                if (Detalle.Count == 0)
                {
                    return false;
                }
                else
                {
                    ArchivoXlsModel file = GenerarExcel(FechaIni, FechaFin, Detalle);
                    DownloadFile.DownloadOpenXML(file);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private ArchivoXlsModel GenerarExcel(string FechaIni, string FechaFin, List<VentasParaInterfaz> Detalle)
        {
            //string path = ConfigurationManager.AppSettings.Get("pathReportes");
            //string fileName = path + @"\EncAplicada_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            string fileName = this.NombreReporte + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            string urlImagen = ConfigurationManager.AppSettings.Get("urlImagenes");
            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
            //SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook, true);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            //workbookPart.Workbook.Save();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = this.NombreReporte };
            sheets.Append(sheet);

            SharedStringTablePart sharedStringTablePart = workbookPart.AddNewPart<SharedStringTablePart>();
            SharedStringTable sharedStringTable = new SharedStringTable();
            sharedStringTablePart.SharedStringTable = sharedStringTable;
            sharedStringTablePart.SharedStringTable.Save();

            WorkbookStylesPart stylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            stylesPart.Stylesheet = MyOpenXML.GenerateStyleSheet();

            // blank font list
            stylesPart.Stylesheet.Fonts = new Fonts();
            stylesPart.Stylesheet.Fonts.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Font());
            stylesPart.Stylesheet.Fonts.Count = 1;
            stylesPart.Stylesheet.Fonts.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Font(
                new Bold(),
                new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = HexBinaryValue.FromString("FFFF0000") }));

            // create fills
            stylesPart.Stylesheet.Fills = new Fills();

            // create a solid red fill
            var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
            solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFFF0000") }; // red fill
            solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); // required, reserved by Excel
            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); // required, reserved by Excel
            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
            stylesPart.Stylesheet.Fills.Count = 3;

            // blank border list
            stylesPart.Stylesheet.Borders = new Borders();
            stylesPart.Stylesheet.Borders.Count = 1;
            stylesPart.Stylesheet.Borders.AppendChild(new Border());

            // blank cell format list
            stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
            stylesPart.Stylesheet.CellStyleFormats.Count = 1;
            stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

            // cell format list
            stylesPart.Stylesheet.CellFormats = new CellFormats();
            // empty one for index 0, seems to be required
            stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
            // cell format references style format 0, font 0, border 0, fill 2 and applies the fill
            stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
            stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
            stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Right });
            stylesPart.Stylesheet.CellFormats.Count = 4;

            stylesPart.Stylesheet.Save();

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            // Constructing header
            Row row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Agente", CellValues.String),
                    MyOpenXML.ConstructCell("Folio", CellValues.String),
                    MyOpenXML.ConstructCell("Clave del cliente", CellValues.String),
                    MyOpenXML.ConstructCell("Clave producto", CellValues.String),
                    MyOpenXML.ConstructCell("Cantidad", CellValues.String),
                    MyOpenXML.ConstructCell("PrecioUnitario", CellValues.String));
            sheetData.AppendChild(row);
            
            foreach (var oDetalle in Detalle)
            {
                row = new Row();
                
                row.Append( 
                    MyOpenXML.ConstructCell(oDetalle.VendedorID, CellValues.String),
                    MyOpenXML.ConstructCell(oDetalle.Folio, CellValues.String),
                    MyOpenXML.ConstructCell(oDetalle.Clave, CellValues.String),
                    MyOpenXML.ConstructCell(oDetalle.ProductoClave, CellValues.String),
                    MyOpenXML.ConstructCell(oDetalle.Cantidad.ToString(), CellValues.Number, 2),
                    MyOpenXML.ConstructCell(oDetalle.Precio.ToString(), CellValues.Number, 2));
                
                sheetData.AppendChild(row);
            }

            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;

            workbookPart.Workbook.Save();

            // Close the document.
            document.Close();

            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
    }

}

    class VentasParaInterfaz
    {
        public string VendedorID { get; set; }
        public string Folio { get; set; }
        public string Clave { get; set; }
        public string ProductoClave { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Cantidad { get; set; }
    }
}