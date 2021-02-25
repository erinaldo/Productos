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
    public class CarteraMensualXRutaPDR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string NombreReporte;
        private string NombreEmpresa;
        private string NombreVendedor;
        private string QueryString;

        public bool GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreVendedor, string NombreCEDIS, string DateStatus, string CEDIS, string Rutas, string FechaInicial, string FechaFinal)
        {
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
            Consulta = new StringBuilder();
            Consulta.AppendLine("Set ANSI_WARNINGS OFF ");
            Consulta.AppendLine("Set nocount on ");
            Consulta.AppendLine("declare @FechaIni datetime");
            Consulta.AppendLine("declare @FechaFin datetime");
            Consulta.AppendLine("declare @RUTClave as varchar(10)");
            Consulta.AppendLine("set @FechaIni = '" + FiltroI + "'");
            Consulta.AppendLine("set @FechaFin = '" + FiltroF + "'");
            Consulta.AppendLine("set @RUTClave = '" + Rutas + "'");
            Consulta.AppendLine("Select distinct * from");
            Consulta.AppendLine("(");
            Consulta.AppendLine("Select distinct");
            Consulta.AppendLine("VR.RUTClave, VR.VendedorID, V.Nombre, Vis.DiaClave, Vis.FechaHoraInicial, Vis.FechaHoraFinal, D.FechaCaptura, AV.Orden, Vis.VisitaClave, Vis.ClienteClave,");
            Consulta.AppendLine("C.NombreCorto, Vis.CodigoLeido, TP.TransProdID, isnull(TP.Total,0) as Total, IMPR.TipoMotivo AS Improductividad");
            Consulta.AppendLine("from Visita Vis (NOLOCK)");
            Consulta.AppendLine("inner join Dia D (NOLOCK) on Vis.DiaClave = D.DiaClave and D.FechaCaptura between @FechaIni and @FechaFin");
            Consulta.AppendLine("inner join AgendaVendedor AV (NOLOCK) on D.DiaClave = AV.DiaClave and AV.RUTClave = Vis.RUTClave and Vis.RUTClave = @RUTClave");
            Consulta.AppendLine("inner join Cliente C (NOLOCK) on Vis.ClienteClave = C.ClienteClave and C.ClienteClave = AV.ClienteClave");
            Consulta.AppendLine("inner join VenRut VR (NOLOCK) on AV.RUTClave = VR.RUTClave");
            Consulta.AppendLine("inner join Vendedor V (NOLOCK) on VR.VendedorID = V.VendedorID");
            Consulta.AppendLine("left join TransProd TP (NOLOCK) on TP.VisitaClave = Vis.VisitaClave and Tp.Tipo = 1 and TP.TipoFase = 2");
            Consulta.AppendLine("LEFT JOIN ImproductividadVenta IMPR ON Vis.VisitaClave = IMPR.VisitaClave AND Vis.DiaClave = IMPR.DiaClave");
            Consulta.AppendLine("Union All");
            Consulta.AppendLine("select distinct");
            Consulta.AppendLine("VR.RUTClave, VR.VendedorID, V.Nombre, D.DiaClave, NULL as FechaHoraInicial, NULL asFechaHoraFinal, D.FechaCaptura, AV.Orden, NULL as VisitaClave, C.ClienteClave,");
            Consulta.AppendLine("C.NombreCorto, NULL as CodigoLeido, NULL as TransProdID, -1 as Total, '' AS Improductividad");
            Consulta.AppendLine("from");
            Consulta.AppendLine("AgendaVendedor AV (NOLOCK)");
            Consulta.AppendLine("inner join Dia D (NOLOCK) on AV.DiaClave = D.DiaClave and D.FechaCaptura between @FechaIni and @FechaFin and AV.RUTClave = @RUTClave");
            Consulta.AppendLine("inner join Cliente C (NOLOCK) on AV.ClienteClave = C.ClienteClave and (AV.DiaClave + '-' + AV.ClienteClave) not in");
            Consulta.AppendLine("(");
            Consulta.AppendLine("Select distinct");
            Consulta.AppendLine("D.DiaClave + '-' + Vis.ClienteClave");
            Consulta.AppendLine("from Visita Vis (NOLOCK)");
            Consulta.AppendLine("inner join Dia D (NOLOCK) on Vis.DiaClave = D.DiaClave and D.FechaCaptura between @FechaIni and @FechaFin");
            Consulta.AppendLine("inner join AgendaVendedor AV (NOLOCK) on D.DiaClave = AV.DiaClave and AV.RUTClave = Vis.RUTClave and Vis.RUTClave = @RUTClave");
            Consulta.AppendLine("inner join Cliente C (NOLOCK) on VIS.ClienteClave = C.ClienteClave");
            Consulta.AppendLine("inner join VenRut VR (NOLOCK) on AV.RUTClave = VR.RUTClave");
            Consulta.AppendLine("inner join Vendedor V (NOLOCK) on VR.VendedorID = V.VendedorID");
            Consulta.AppendLine("left join TransProd TP (NOLOCK) on TP.VisitaClave = Vis.VisitaClave and Tp.Tipo = 1 and TP.TipoFase = 2");
            Consulta.AppendLine(")");
            Consulta.AppendLine("inner join VenRut VR (NOLOCK) on AV.RUTClave = VR.RUTClave");
            Consulta.AppendLine("inner join Vendedor V (NOLOCK) on VR.VendedorID = V.VendedorID");
            Consulta.AppendLine(")A1");
            Consulta.AppendLine("order by RUTClave, VendedorID, Nombre, FechaCaptura, DiaClave, Orden, ClienteClave, ");
            Consulta.AppendLine("NombreCorto, CodigoLeido");
            QueryString = "";
            QueryString = Consulta.ToString();
            List<CarteraMensual> Detalle = Connection.Query<CarteraMensual>(QueryString, null, null, true, 600).ToList();

            Consulta = new StringBuilder();
            Consulta.AppendLine("Set ANSI_WARNINGS OFF ");
            Consulta.AppendLine("Set nocount on ");
            Consulta.AppendLine("DECLARE @FechaIni DATETIME");
            Consulta.AppendLine("DECLARE @FechaFin DATETIME");
            Consulta.AppendLine("DECLARE @RUTClave AS VARCHAR(10)");
            Consulta.AppendLine("SET @FechaIni = '" + FiltroI + "'");
            Consulta.AppendLine("SET @FechaFin = '" + FiltroF + "'");
            Consulta.AppendLine("SET @RUTClave = '" + Rutas + "'");
            Consulta.AppendLine("");
            Consulta.AppendLine("SELECT SUM(CASE WHEN ConVenta = 0 THEN SinVenta ELSE 0 END) AS SinVenta, SUM(ConVenta) AS ConVenta, SUM(CodigoLeido) AS CodigoLeido");
            Consulta.AppendLine("FROM (");
            Consulta.AppendLine("	SELECT SUM(VisitadosSinVenta) AS SinVenta, SUM(VisitadosConVenta) AS ConVenta, SUM(CodigoLeido) AS CodigoLeido");
            Consulta.AppendLine("	FROM (");
            Consulta.AppendLine("		SELECT DISTINCT");
            Consulta.AppendLine("			VW.RUTClave, VW.VendedorID, VW.Nombre, VW.ClienteClave, VW.NombreCorto, CodigoLeido = 0, VisitadosSinVenta = 0,");
            Consulta.AppendLine("			CASE WHEN TRP.Total IS NULL THEN 0 ELSE 1 END AS VisitadosConVenta");
            Consulta.AppendLine("		FROM vw_rptCarteraMensualPDR_Visita VW");
            Consulta.AppendLine("			LEFT JOIN [dbo].[TransProd] TRP (NOLOCK) ON VW.VisitaClave = TRP.VisitaClave AND TRP.Tipo = 1 AND TRP.TipoFase = 2 ");
            Consulta.AppendLine("		WHERE TRP.Total IS NOT NULL AND VW.FechaCaptura BETWEEN @FechaIni AND @FechaFin AND VW.RUTClave = @RUTClave ");
            Consulta.AppendLine("	UNION ALL");
            Consulta.AppendLine("		SELECT DISTINCT");
            Consulta.AppendLine("			VW.RUTClave, VW.VendedorID, VW.Nombre, VW.ClienteClave, VW.NombreCorto, CodigoLeido = 0,");
            Consulta.AppendLine("			CASE WHEN TRP.Total IS NULL THEN 1 ELSE 0 END AS VisitadosSinVenta, VisitadosConVenta = 0");
            Consulta.AppendLine("		FROM vw_rptCarteraMensualPDR_Visita VW");
            Consulta.AppendLine("			LEFT JOIN [dbo].[TransProd] TRP (NOLOCK) ON VW.VisitaClave = TRP.VisitaClave AND TRP.Tipo = 1 AND TRP.TipoFase = 2 ");
            Consulta.AppendLine("		WHERE TRP.Total IS NULL AND VW.FechaCaptura BETWEEN @FechaIni AND @FechaFin AND VW.RUTClave = @RUTClave ");
            Consulta.AppendLine("	UNION ALL");
            Consulta.AppendLine("		SELECT DISTINCT");
            Consulta.AppendLine("			VW.RUTClave, VW.VendedorID, VW.Nombre, VW.ClienteClave, VW.NombreCorto, ");
            Consulta.AppendLine("			1 AS CodigoLeido, VisitadosSinVenta = 0, VisitadosConVenta = 0");
            Consulta.AppendLine("		FROM vw_rptCarteraMensualPDR_Visita VW");
            Consulta.AppendLine("			LEFT JOIN [dbo].[TransProd] TRP (NOLOCK) ON VW.VisitaClave = TRP.VisitaClave AND TRP.Tipo = 1 AND TRP.TipoFase = 2 ");
            Consulta.AppendLine("		WHERE VW.CodigoLeido = 0 AND VW.FechaCaptura BETWEEN @FechaIni AND @FechaFin AND VW.RUTClave = @RUTClave ");
            Consulta.AppendLine("	) Detalle");
            Consulta.AppendLine("	GROUP BY Detalle.ClienteClave");
            Consulta.AppendLine(") Detalle");

            QueryString = "";
            QueryString = Consulta.ToString();
            CarteraMensualVis Visita = Connection.Query<CarteraMensualVis>(QueryString, null, null, true, 600).ToList()[0];

            Consulta = new StringBuilder();
            Consulta.AppendLine("Set ANSI_WARNINGS OFF ");
            Consulta.AppendLine("Set nocount on ");
            Consulta.AppendLine("declare @FechaIni datetime");
            Consulta.AppendLine("declare @FechaFin datetime");
            Consulta.AppendLine("declare @RUTClave as varchar(10)");
            Consulta.AppendLine("set @FechaIni = '" + FiltroI + "'");
            Consulta.AppendLine("set @FechaFin = '" + FiltroF + "'");
            Consulta.AppendLine("set @RUTClave = '" + Rutas + "'");
            Consulta.AppendLine("select count(distinct AV.ClienteClave) as NoVisitados");
            Consulta.AppendLine("from");
            Consulta.AppendLine("AgendaVendedor AV (NOLOCK)");
            Consulta.AppendLine("inner join Dia D (NOLOCK) on AV.DiaClave = D.DiaClave and D.FechaCaptura between @FechaIni and @FechaFin and AV.RUTClave = @RUTClave");
            Consulta.AppendLine("inner join Cliente C (NOLOCK) on AV.ClienteClave = C.ClienteClave and AV.ClienteClave not in");
            Consulta.AppendLine("(");
            Consulta.AppendLine("Select distinct");
            Consulta.AppendLine("Vis.ClienteClave");
            Consulta.AppendLine("from Visita Vis (NOLOCK)");
            Consulta.AppendLine("inner join Dia D (NOLOCK) on Vis.DiaClave = D.DiaClave and D.FechaCaptura between @FechaIni and @FechaFin");
            Consulta.AppendLine("inner join AgendaVendedor AV (NOLOCK) on D.DiaClave = AV.DiaClave and AV.RUTClave = Vis.RUTClave and Vis.RUTClave = @RUTClave");
            Consulta.AppendLine("inner join Cliente C (NOLOCK) on VIS.ClienteClave = C.ClienteClave");
            Consulta.AppendLine(")");
            Consulta.AppendLine("inner join VenRut VR (NOLOCK) on AV.RUTClave = VR.RUTClave");
            Consulta.AppendLine("inner join Vendedor V (NOLOCK) on VR.VendedorID = V.VendedorID");
            QueryString = "";
            QueryString = Consulta.ToString();
            CarteraMensualSin SinVis = Connection.Query<CarteraMensualSin>(QueryString, null, null, true, 600).ToList()[0];

            this.NombreEmpresa = NombreEmpresa;
            this.NombreReporte = NombreReporte;
            this.NombreVendedor = NombreVendedor;

            if (Detalle.Count == 0)
            {
                return false;
            }
            else
            {
                ArchivoXlsModel file = GenerarExcel(FechaIni, FechaFin, Detalle, Visita, SinVis);
                DownloadFile.DownloadOpenXML(file);
            }
            return true;
        }

        private ArchivoXlsModel GenerarExcel(string FechaIni, string FechaFin, List<CarteraMensual> Detalle, CarteraMensualVis Visita, CarteraMensualSin SinVis)
        {
            string fileName = this.NombreReporte.Replace(" ", "") + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            string urlImagen = ConfigurationManager.AppSettings.Get("urlImagenes");
            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = this.NombreReporte.Replace(" ", "").Substring(0, 25) };
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

            stylesPart.Stylesheet.Fonts.Count = 2;
            stylesPart.Stylesheet.Fonts.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Font(
                new Bold(),
                new DocumentFormat.OpenXml.Spreadsheet.Color() { Rgb = HexBinaryValue.FromString("000099FF") }));

            // create fills
            stylesPart.Stylesheet.Fills = new Fills();

            // create a solid red fill
            var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
            solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFFF0000") }; // red fill
            solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

            var solidBlue = new PatternFill() { PatternType = PatternValues.Solid };
            solidBlue.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("000099FF") }; // red fill
            solidBlue.BackgroundColor = new BackgroundColor { Indexed = 64 };

            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); // required, reserved by Excel
            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); // required, reserved by Excel
            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidBlue });
            stylesPart.Stylesheet.Fills.Count = 4;

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
            stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
            stylesPart.Stylesheet.CellFormats.Count = 5;

            stylesPart.Stylesheet.Save();

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            var Clientes = Detalle
                    .Select(x => new { x.ClienteClave, x.NombreCorto })
                    .Distinct()
                    .ToList();

            var Activos = 0;
            var Pasivos = 0;

            foreach (var oCliente in Clientes)
            {
                var Detalles = Detalle
                    .Where(x => x.ClienteClave == oCliente.ClienteClave)
                    .Select(x => x)
                    .Distinct()
                    .ToList();

                if (Detalles.Where(x => x.Total > 0).Select(x => x).ToList().Count() >= 2)
                {
                    Activos += 1;
                }
                else
                {
                    if (Detalles.Where(x => x.Total > 0).Select(x => x).ToList().Count() == 1)
                    {
                        Pasivos += 1;
                    }
                }
            }

            // Constructing header
            Row row = new Row();
            row.Append(MyOpenXML.ConstructCell(this.NombreReporte, CellValues.String));
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(MyOpenXML.ConstructCell(this.NombreEmpresa, CellValues.String));
            sheetData.AppendChild(row);

            row = new Row();
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Fecha(s):", CellValues.String),
                    MyOpenXML.ConstructCell(FechaIni, CellValues.String),
                    MyOpenXML.ConstructCell(FechaFin, CellValues.String));
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Vendedor:", CellValues.String),
                    MyOpenXML.ConstructCell(this.NombreVendedor, CellValues.String));
            sheetData.AppendChild(row);

            row = new Row();
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Opciones", CellValues.String),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("Estatus", CellValues.String));
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Visitados con Venta \"(Activos)\"", CellValues.String),
                    MyOpenXML.ConstructCell(Activos.ToString(), CellValues.Number, 2),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell(">= 2 Ventas", CellValues.String),
                    MyOpenXML.ConstructCell("Activo", CellValues.String, 2));
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Visitados con Venta \"(Pasivos)\"", CellValues.String),
                    MyOpenXML.ConstructCell(Pasivos.ToString(), CellValues.Number, 2),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("= 1 Venta", CellValues.String),
                    MyOpenXML.ConstructCell("Pasivo", CellValues.String, 2));
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Visitados sin Venta \"(Pésimos)\"", CellValues.String),
                    MyOpenXML.ConstructCell(Visita.SinVenta.ToString(), CellValues.Number, 2),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("Visitas sin venta", CellValues.String),
                    MyOpenXML.ConstructCell("Pesimo", CellValues.String, 2));
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("No Visitados \"(Nulos)\"", CellValues.String),
                    MyOpenXML.ConstructCell(SinVis.NoVisitados.ToString(), CellValues.Number, 2),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("", CellValues.String),
                    MyOpenXML.ConstructCell("0 Visitas (No visitado o cliente cerrado)", CellValues.String),
                    MyOpenXML.ConstructCell("Nulo", CellValues.String, 2));
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Total de Codigos No Leidos", CellValues.String),
                    MyOpenXML.ConstructCell((Visita.CodigoLeido).ToString(), CellValues.Number, 2));
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("Total de Clientes en Cartera", CellValues.String),
                    MyOpenXML.ConstructCell((Visita.SinVenta + Visita.ConVenta + SinVis.NoVisitados).ToString(), CellValues.Number, 2));
            sheetData.AppendChild(row);

            row = new Row();
            sheetData.AppendChild(row);
            row = new Row();
            sheetData.AppendChild(row);
            row = new Row();
            sheetData.AppendChild(row);
            row = new Row();
            sheetData.AppendChild(row);

            Clientes = Detalle
                    .Select(x => new { x.ClienteClave, x.NombreCorto })
                    .Distinct()
                    .ToList();

            var Fechas = Detalle
                    .Select(x => new { x.FechaCaptura, x.DiaClave })
                    .OrderBy(x => x.FechaCaptura)
                    .Distinct()
                    .ToList();

            int max = 0;
            foreach (var oCliente in Clientes)
            {
                var FechasAux = Detalle
                    .Where(x => x.ClienteClave == oCliente.ClienteClave)
                    .Select(x => new { x.FechaCaptura, x.DiaClave })
                    .Distinct()
                    .ToList();
                if (max < FechasAux.Count())
                {
                    max = FechasAux.Count();
                    Fechas = Detalle
                    .Where(x => x.ClienteClave == oCliente.ClienteClave)
                    .Select(x => new { x.FechaCaptura, x.DiaClave })
                    .Distinct()
                    .ToList();
                }
            }

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell("No.", CellValues.String),
                    MyOpenXML.ConstructCell("Nombre Corto", CellValues.String),
                    MyOpenXML.ConstructCell("Estatus Cartera", CellValues.String),
                    MyOpenXML.ConstructCell("Total de Visitas", CellValues.String));
            foreach (var oFecha in Fechas)
            {
                row.Append(
                    MyOpenXML.ConstructCell("Fecha", CellValues.String, 2),
                    MyOpenXML.ConstructCell("$", CellValues.String, 2));
            }
            sheetData.AppendChild(row);

            int Orden = 1;
            foreach (var oCliente in Clientes)
            {
                row = new Row();
                var Detalles = Detalle
                    .Where(x => x.ClienteClave == oCliente.ClienteClave)
                    .Select(x => x)
                    .Distinct()
                    .ToList();

                Fechas = Detalle
                    .Where(x => x.ClienteClave == oCliente.ClienteClave)
                    .Select(x => new { x.FechaCaptura, x.DiaClave })
                    .Distinct()
                    .ToList();

                row.Append(MyOpenXML.ConstructCell(Orden.ToString(), CellValues.Number, 2));
                row.Append(MyOpenXML.ConstructCell(oCliente.NombreCorto, CellValues.String));

                if (Detalles.Where(x => x.Total > 0).Select(x => x).ToList().Count() >= 2)
                {
                    row.Append(MyOpenXML.ConstructCell("Activo", CellValues.String));
                }
                else
                {
                    if (Detalles.Where(x => x.Total > 0).Select(x => x).ToList().Count() == 1)
                    {
                        row.Append(MyOpenXML.ConstructCell("Pasivo", CellValues.String));
                    }
                    else
                    {
                        if (Detalles.Where(x => x.VisitaClave != null).Select(x => x).ToList().Count() > 0)
                        {
                            row.Append(MyOpenXML.ConstructCell("Pesimo", CellValues.String));
                        }
                        else
                        {
                            row.Append(MyOpenXML.ConstructCell("Nulo", CellValues.String));
                        }
                    }
                }
                row.Append(MyOpenXML.ConstructCell(Detalles.Where(x => x.VisitaClave != null).Select(x => x).ToList().Count().ToString(), CellValues.Number, 2));
                foreach (var oFecha in Fechas)
                {
                    var Actual = Detalles.Where(x => x.DiaClave == oFecha.DiaClave).Select(x => x).ToList();
                    if (Actual.Count() >= 1)
                    {
                        Decimal TotalT = 0;
                        string ImproductividadT = "";
                        foreach (var oActual in Actual)
                        {
                            if (oActual.Total != null || oActual.Total != 0)
                            {
                                TotalT += oActual.Total;
                                ImproductividadT += oActual.Improductividad;
                            }
                        }
                        if (TotalT > 0)
                        {
                            row.Append(
                            MyOpenXML.ConstructCell(oFecha.DiaClave, CellValues.String),
                            MyOpenXML.ConstructCell(TotalT.ToString(), CellValues.Number, 3));
                        }
                        else
                        {
                            if (TotalT == 0 && ImproductividadT == "11")
                            {
                                row.Append(
                                MyOpenXML.ConstructCell(oFecha.DiaClave, CellValues.String),
                                MyOpenXML.ConstructCell("P", CellValues.String, 4));
                            }
                            else if (TotalT == 0)
                            {
                                row.Append(
                                MyOpenXML.ConstructCell(oFecha.DiaClave, CellValues.String),
                                MyOpenXML.ConstructCell("0", CellValues.Number, 3));
                            }


                            else
                            {
                                row.Append(
                                MyOpenXML.ConstructCell(oFecha.DiaClave, CellValues.String),
                                MyOpenXML.ConstructCell("X", CellValues.String, 1));
                            }
                        }
                    }
                    else
                    {
                        row.Append(
                        MyOpenXML.ConstructCell(oFecha.DiaClave, CellValues.String),
                        MyOpenXML.ConstructCell("X", CellValues.String, 1));
                    }
                }
                Orden++;
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

    class CarteraMensual
    {
        public string RUTClave { get; set; }
        public string VendedorID { get; set; }
        public string Nombre { get; set; }
        public string DiaClave { get; set; }
        public string FechaHoraInicial { get; set; }
        public string FechaHoraFinal { get; set; }
        public string FechaCaptura { get; set; }
        public string VisitaClave { get; set; }
        public string ClienteClave { get; set; }
        public string NombreCorto { get; set; }
        public long Orden { get; set; }
        public long CodigoLeido { get; set; }
        public string TransProdID { get; set; }
        public Decimal Total { get; set; }
        public string Improductividad { get; set; }
    }

    class CarteraMensualVis
    {
        public long SinVenta { get; set; }
        public long ConVenta { get; set; }
        public long CodigoLeido { get; set; }
    }

    class CarteraMensualSin
    {
        public long NoVisitados { get; set; }
    }
}