using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace eRoute.Models.ReportesModels
{
    public class VentasPorDiaMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string NombreReporte, string NombreEmpresa, string nombreCedis, string FechaInicial, string FechaFinal, string Cedis, int vavclave, string dateStatus, string unidadMedida, string pvCondicion, string RutasSplit)
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
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            sConsulta.AppendLine("SET LANGUAGE Spanish ");
            sConsulta.AppendLine(" ");
            sConsulta.AppendLine("select a.Clave +' - '+ a.Nombre as Cedi, ");
            sConsulta.AppendLine("r.RUTClave +' - '+ r.Descripcion as Ruta, ");
            sConsulta.AppendLine("d.FechaCaptura, ");
            sConsulta.AppendLine("datename(dw,d.DiaClave) as DiaSemana ");
            if (unidadMedida == "Cartones")
                sConsulta.AppendLine(", SUM(td.Cantidad) as 'CartonesHectolitraje', 1 as Cartones ");
            else
                sConsulta.AppendLine(", SUM(td.Cantidad * pu.Volumen) as 'CartonesHectolitraje', 0 as Cartones ");
            sConsulta.AppendLine("from TransProd t (NOLOCK) ");
            sConsulta.AppendLine("inner join TransprodDetalle td (NOLOCK) on t.TransprodId=td.TransprodId						 ");
            sConsulta.AppendLine("inner join Dia d (NOLOCK) on t.DiaClave=d.DiaClave ");
            sConsulta.AppendLine("inner join Visita v (NOLOCK) on v.VisitaClave=isnull(t.VisitaClave,t.VisitaClave1) and v.DiaClave=isnull(t.DiaClave,t.Diaclave1)  ");
            sConsulta.AppendLine("inner join Vendedor ve (NOLOCK) on v.VendedorId=ve.VendedorId	 ");
            sConsulta.AppendLine("inner join Usuario u (NOLOCK) on ve.UsuId=u.UsuId	 ");
            sConsulta.AppendLine("inner join VENCentroDistHist vch (NOLOCK) on v.VendedorID=vch.VendedorID and d.FechaCaptura between VCH.VCHFechaInicial and VCH.FechaFinal ");
            sConsulta.AppendLine("inner join Almacen a (NOLOCK) on vch.AlmacenId=a.AlmacenID ");
            sConsulta.AppendLine("inner join Ruta r (NOLOCK) on v.RUTClave=r.RUTClave ");
            if (unidadMedida != "Cartones")
            {
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on td.ProductoClave=pu.ProductoClave and td.TipoUnidad=PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle pd (NOLOCK) on td.ProductoClave=pd.ProductoClave and td.TipoUnidad=pd.PRUTipoUnidad and td.ProductoClave=pd.ProductoDetClave  ");
            }
            sConsulta.AppendLine(pvCondicion + " and (t.Tipo=1 and t.TipoFase in (2,3)) ");
            sConsulta.AppendLine("group by a.Clave +' - '+ a.Nombre,  ");
            sConsulta.AppendLine("r.RUTClave +' - '+ r.Descripcion,  ");
            sConsulta.AppendLine("d.FechaCaptura,  ");
            sConsulta.AppendLine("d.DiaClave ");
            sConsulta.AppendLine("order by a.Clave +' - '+ a.Nombre, r.RUTClave +' - '+ r.Descripcion, d.FechaCaptura  ");

            QueryString = sConsulta.ToString();

            List<ClientesDiaModel> Registros = Connection.Query<ClientesDiaModel>(QueryString, null, null, true, 600).ToList();
            if (Registros.Count() <= 0)
            {
                return null;
            }

            if (String.IsNullOrEmpty(RutasSplit))
            {
                RutasSplit = "Todas";
            }
            else
            {
                RutasSplit = RutasSplit.Replace(",", ", ");
            }

            DateTime fechaHora = DateTime.Now;
            string filename = NombreReporte + fechaHora.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + ".xlsx";
            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument x1 = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
            WorkbookPart wbp = x1.AddWorkbookPart();
            WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
            Workbook wb = new Workbook();
            FileVersion fv = new FileVersion();
            fv.ApplicationName = "Microsoft Office Excel";
            Worksheet ws = new Worksheet();
            SheetData sd = new SheetData();

            //creamos hoja de estilo
            WorkbookStylesPart sp = wbp.AddNewPart<WorkbookStylesPart>();
            sp.Stylesheet = CreateStylesheet();

            //guarda los cambios a la hoja de estilo
            sp.Stylesheet.Save();

            Dictionary<int, Row> Rows = new Dictionary<int, Row>();

            int currentRow = 1;

            createRow(currentRow, ref Rows);
            createCell(currentRow, ref Rows, "E" + currentRow, CellValues.String, NombreReporte, 4);
            currentRow++;

            createRow(currentRow, ref Rows);
            createCell(currentRow, ref Rows, "E" + currentRow, CellValues.String, NombreEmpresa, 5);
            currentRow += 2;

            createRow(currentRow, ref Rows);
            createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Agencia: " + (nombreCedis == "null" ? "Todos" : nombreCedis), 3);
            currentRow++;

            createRow(currentRow, ref Rows);
            createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Ruta: " + RutasSplit, 3);
            currentRow++;

            createRow(currentRow, ref Rows);
            createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Fecha: " + sFecha.ToString("dd/MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"), 3);
            currentRow++;

            //convertimos la unidadMedida a hectolitraje si es hectolitros
            if (unidadMedida != "Cartones")
                unidadMedida = "Hectolitraje";

            createRow(currentRow, ref Rows);
            createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Unidad: " + unidadMedida, 3);
            currentRow += 2;

            //Encabezados
            createRow(currentRow, ref Rows);
            createCell(currentRow, ref Rows, "D" + currentRow, CellValues.String, "Día de la Semana", 3);

            createCell(currentRow, ref Rows, "F" + currentRow, CellValues.String, "Día de la Semana", 3);

            createCell(currentRow, ref Rows, "H" + currentRow, CellValues.String, unidadMedida, 3);

            currentRow += 2;

            //agrupamos la lista en cedis para imprimir el encabezado y totales
            var cediList = (from gr in Registros group gr by new { gr.Cedi } into grupo select grupo).ToList();

            foreach (var grupoCedi in cediList)
            {

                //Cedi
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Agencia: " + grupoCedi.First().Cedi, 3);
                currentRow++;


                //agrupamos la lista en rutas para imprimir los encabezados y totales
                var formatList = (from gr in grupoCedi group gr by new { gr.Ruta } into grupo select grupo).ToList();

                foreach (var grupoRuta in formatList)
                {


                    //Ruta
                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "   Ruta: " + grupoRuta.First().Ruta, 3);
                    currentRow++;

                    foreach (var registro in grupoRuta)
                    {
                        //detalle
                        createRow(currentRow, ref Rows);

                        createCell(currentRow, ref Rows, "D" + currentRow, CellValues.String, registro.FechaCaptura.ToString("d"), 0);

                        createCell(currentRow, ref Rows, "F" + currentRow, CellValues.String, registro.DiaSemana, 0);

                        createCell(currentRow, ref Rows, "H" + currentRow, CellValues.Number, registro.CartonesHectolitraje.ToString(), 2);


                        currentRow++;
                    }

                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "F" + currentRow, CellValues.String, "Total Ruta", 3);
                    createCell(currentRow, ref Rows, "H" + currentRow, CellValues.Number, grupoRuta.Sum(c => c.CartonesHectolitraje).ToString(), 1);
                    currentRow++;

                }

                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "F" + currentRow, CellValues.String, "Total Agencia", 3);
                createCell(currentRow, ref Rows, "H" + currentRow, CellValues.Number, grupoCedi.Sum(c => c.CartonesHectolitraje).ToString(), 1);
                currentRow += 2;
            }

            currentRow += 2;

            createRow(currentRow, ref Rows);
            createCell(currentRow, ref Rows, "F" + currentRow, CellValues.String, "Fecha Hora Impresión: " + fechaHora.ToString("G"), 0);



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

        void createRow(int id, ref Dictionary<int, Row> Rows)
        {
            Rows.Add(id, new Row() { RowIndex = (UInt32)id });
        }

        void createCell(int idRow, ref Dictionary<int, Row> Rows, string cellReference, DocumentFormat.OpenXml.Spreadsheet.CellValues dt, string cellValue, UInt32Value styleIndex)
        {
            Cell cell = new Cell();
            if (cellReference != null)
                cell.CellReference = cellReference;
            cell.DataType = dt;
            cell.CellValue = new CellValue(cellValue);

            cell.StyleIndex = styleIndex;

            cell.CellValue.Space = SpaceProcessingModeValues.Preserve;
            if (Rows.ContainsKey(idRow))
            {
                Rows[idRow].Append(cell);
            }
        }

        private static Stylesheet CreateStylesheet()
        {
            Stylesheet stylesheet1 = new Stylesheet();

            Fonts fonts1 = new Fonts() { Count = (UInt32Value)3U, KnownFonts = true };

            DocumentFormat.OpenXml.Spreadsheet.Font font1 = new DocumentFormat.OpenXml.Spreadsheet.Font();
            FontSize fontSize1 = new FontSize() { Val = 10D };
            DocumentFormat.OpenXml.Office2010.Excel.Color color1 = new DocumentFormat.OpenXml.Office2010.Excel.Color() { Theme = (UInt32Value)1U };
            FontName fontName1 = new FontName() { Val = "Arial" };
            //FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
            //FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            //font1.Append(fontFamilyNumbering1);
            //font1.Append(fontScheme1);

            DocumentFormat.OpenXml.Spreadsheet.Font font2 = new DocumentFormat.OpenXml.Spreadsheet.Font();
            FontSize fontSize2 = new FontSize() { Val = 10D };
            DocumentFormat.OpenXml.Office2010.Excel.Color color2 = new DocumentFormat.OpenXml.Office2010.Excel.Color() { Theme = (UInt32Value)1U };
            FontName fontName2 = new FontName() { Val = "Arial" };
            //FontFamilyNumbering fontFamilyNumbering2 = new FontFamilyNumbering() { Val = 2 };
            //FontScheme fontScheme2 = new FontScheme() { Val = FontSchemeValues.Minor };
            Bold bold2 = new Bold();

            font2.Append(fontSize2);
            font2.Append(color2);
            font2.Append(fontName2);
            //font2.Append(fontFamilyNumbering2);
            //font2.Append(fontScheme2);
            font2.Append(bold2);

            DocumentFormat.OpenXml.Spreadsheet.Font font3 = new DocumentFormat.OpenXml.Spreadsheet.Font();
            FontSize fontSize3 = new FontSize() { Val = 16D };
            DocumentFormat.OpenXml.Office2010.Excel.Color color3 = new DocumentFormat.OpenXml.Office2010.Excel.Color() { Theme = (UInt32Value)1U };
            FontName fontName3 = new FontName() { Val = "Arial" };
            //FontFamilyNumbering fontFamilyNumbering3 = new FontFamilyNumbering() { Val = 2 };
            // FontScheme fontScheme3 = new FontScheme() { Val = FontSchemeValues.Minor };
            Bold bold3 = new Bold();

            font3.Append(fontSize3);
            font3.Append(color3);
            font3.Append(fontName3);
            //font3.Append(fontFamilyNumbering3);
            // font3.Append(fontScheme3);
            font3.Append(bold3);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);

            Fills fills1 = new Fills() { Count = (UInt32Value)5U };

            // FillId = 0
            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };
            fill1.Append(patternFill1);

            // FillId = 1
            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };
            fill2.Append(patternFill2);

            // FillId = 2,RED
            Fill fill3 = new Fill();
            PatternFill patternFill3 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor1 = new ForegroundColor() { Rgb = "FFFF0000" };
            BackgroundColor backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill3.Append(foregroundColor1);
            patternFill3.Append(backgroundColor1);
            fill3.Append(patternFill3);

            // FillId = 3,BLUE
            Fill fill4 = new Fill();
            PatternFill patternFill4 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor2 = new ForegroundColor() { Rgb = "FF0070C0" };
            BackgroundColor backgroundColor2 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill4.Append(foregroundColor2);
            patternFill4.Append(backgroundColor2);
            fill4.Append(patternFill4);

            // FillId = 4,White
            Fill fill5 = new Fill();
            PatternFill patternFill5 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor3 = new ForegroundColor() { Rgb = "FFFFFFFF" };
            BackgroundColor backgroundColor3 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill5.Append(foregroundColor3);
            patternFill5.Append(backgroundColor3);
            fill5.Append(patternFill5);

            fills1.Append(fill1);
            fills1.Append(fill2);
            fills1.Append(fill3);
            fills1.Append(fill4);
            fills1.Append(fill5);

            Borders borders1 = new Borders() { Count = (UInt32Value)1U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();
            DiagonalBorder diagonalBorder1 = new DiagonalBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);

            borders1.Append(border1);

            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };

            cellStyleFormats1.Append(cellFormat1);

            NumberingFormat nf2decimal = new NumberingFormat();
            nf2decimal.NumberFormatId = UInt32Value.FromUInt32(3453);
            nf2decimal.FormatCode = StringValue.FromString("0\\%");
            stylesheet1.NumberingFormats = new NumberingFormats();
            stylesheet1.NumberingFormats.Append(nf2decimal);

            //NumberingFormats numberingFormats = new NumberingFormats();
            //numberingFormats.Append(nf2decimal);

            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)6U };
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true, ApplyFont = true };
            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)4U, FontId = (UInt32Value)1U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true, ApplyFont = true };
            CellFormat cellFormat4 = new CellFormat() { NumberFormatId = (UInt32Value)4U, FontId = (UInt32Value)0U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true, ApplyFont = true };
            CellFormat cellFormat5 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true, ApplyFont = true };
            CellFormat cellFormat6 = new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center }) { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)2U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true, ApplyFont = true, ApplyAlignment = true };
            CellFormat cellFormat7 = new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center }) { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true, ApplyFont = true, ApplyAlignment = true };

            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);
            cellFormats1.Append(cellFormat4);
            cellFormats1.Append(cellFormat5);
            cellFormats1.Append(cellFormat6);
            cellFormats1.Append(cellFormat7);

            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

            cellStyles1.Append(cellStyle1);
            DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };
            TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleMedium9" };


            stylesheet1.Append(fonts1);
            stylesheet1.Append(fills1);
            stylesheet1.Append(borders1);
            stylesheet1.Append(cellStyleFormats1);
            //stylesheet1.Append(numberingFormats);
            stylesheet1.Append(cellFormats1);
            stylesheet1.Append(cellStyles1);
            stylesheet1.Append(differentialFormats1);
            stylesheet1.Append(tableStyles1);
            return stylesheet1;
        }
    }

    class ClientesDiaModel
    {
        public string Cedi { get; set; }
        public string Ruta { get; set; }
        public DateTime FechaCaptura { get; set; }
        public string DiaSemana { get; set; }
        public Decimal CartonesHectolitraje { get; set; }
        public string Cartones { get; set; }
    }


}