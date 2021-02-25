using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class CargaPorDiaBYD
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string NombreReporte;
        private string NombreEmpresa;
        private string QueryString = "";
        private string sCEDI = "";
        private string sFecha = "";
        private string sRuta = "";
        private string sVendedor = "";
        private bool bPorRuta = false;

        public bool GetReport(string NombreReporte, string NombreEmpresa, int Reporte, string CEDI, String NombreCEDI, string FechaIni, string FechaFin, string RUTClave, string VendedorID, bool PorRuta)
        {
            this.NombreReporte = NombreReporte;
            this.NombreEmpresa = NombreEmpresa;

            DateTime dFechaIni;
            DateTime.TryParse(FechaIni, out dFechaIni);
            DateTime dFechaFin = dFechaIni;
            if (FechaFin.Equals("null") || FechaFin.Equals(""))
            {
                FechaFin = FechaIni;
            }
            else
            {
                DateTime.TryParse(FechaFin, out dFechaFin);
            }

            bPorRuta = PorRuta;
            sCEDI = NombreCEDI;
            sFecha = dFechaIni.ToShortDateString() + (!FechaFin.Equals("null") ? " - " + dFechaFin.ToShortDateString() : "");
            if (PorRuta)
                sRuta = RUTClave;
            else
                sVendedor = Connection.QueryFirst<String>("SELECT VendedorID + ' ' + Nombre FROM Vendedor (NOLOCK) WHERE VendedorID = " + VendedorID);

            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("DECLARE @USUId VARCHAR(16) ");
            sConsulta.AppendLine("DECLARE @ListaPrecios VARCHAR(10) ");
            sConsulta.AppendLine("DECLARE @Contenedor VARCHAR(1) ");
            sConsulta.AppendLine("DECLARE @FechaIni DATETIME ");
            sConsulta.AppendLine("DECLARE @FechaFin DATETIME ");

            sConsulta.AppendLine("SET @FechaIni = '" + dFechaIni.ToString("s") + "' ");
            sConsulta.AppendLine("SET @FechaFin = '" + dFechaFin.ToString("s") + "' ");

            sConsulta.AppendLine("SELECT @USUId = VEN.USUId, @ListaPrecios = VEN.ListaPrecioBase ");
            sConsulta.AppendLine("FROM VenRut VRT (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Vendedor VEN (NOLOCK) ON VRT.VendedorID = VEN.VendedorID ");
            if (PorRuta)
                sConsulta.AppendLine("WHERE VRT.RUTClave = '" + RUTClave + "' ");
            else
                sConsulta.AppendLine("WHERE VRT.VendedorID = " + VendedorID);

            sConsulta.AppendLine("SELECT * FROM ( ");
            sConsulta.AppendLine("SELECT TRP.FechaCaptura, TRP.Folio, TPD.ProductoClave, PRO.Nombre, (ISNULL(TPD.CantidadOriginal, TPD.Cantidad) *  CASE WHEN isnull(TDE.Factor,0)<=0 THEN PRD.Factor ELSE isnull(TDE.Factor,0) END) AS CantidadOriginal, (TPD.Cantidad *  CASE WHEN isnull(TDE.Factor,0)<=0 THEN PRD.Factor ELSE isnull(TDE.Factor,0) END) AS Cantidad, ");
            sConsulta.AppendLine("((TPD.Cantidad *  CASE WHEN isnull(TDE.Factor,0)<=0 THEN PRD.Factor ELSE isnull(TDE.Factor,0) END) * PPV.Precio) AS SubTotal, dbo.FNCalcularImpuestoProducto(TPD.ProductoClave, TRP.FechaCaptura, (TPD.Cantidad *  CASE WHEN isnull(TDE.Factor,0)<=0 THEN PRD.Factor ELSE isnull(TDE.Factor,0) END) * PPV.Precio) AS Impuesto, 0 AS Contenedor ");
            sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON TRP.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID ");
            sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON TPD.ProductoClave = PRO.ProductoClave ");
            sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON TPD.ProductoClave = PRD.ProductoClave AND TPD.TipoUnidad = PRD.PRUTipoUnidad AND PRD.ProductoClave = PRD.ProductoDetClave ");
            sConsulta.AppendLine("INNER JOIN ProductoUnidad PRU (NOLOCK) ON TPD.ProductoClave = PRU.ProductoClave AND TPD.TipoUnidad = PRU.PRUTipoUnidad ");
            sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD2 (NOLOCK) ON TPD.ProductoClave = PRD2.ProductoClave AND PRD2.Factor = 1 AND PRD2.ProductoClave = PRD2.ProductoDetClave ");
            sConsulta.AppendLine("INNER JOIN PrecioProductoVig PPV (NOLOCK) ON PRD2.ProductoClave = PPV.ProductoClave AND PRD2.PRUTipoUnidad = PPV.PRUTipoUnidad AND PPV.PrecioClave = @ListaPrecios AND TRP.FechaCaptura BETWEEN PPV.PPVFechaInicio AND PPV.FechaFin ");
            sConsulta.AppendLine("LEFT JOIN TPDDatosExtra TDE (NOLOCK) ON TDE.TransProdID = TPD.TransProdID and TDE.TransProdDetalleID = TPD.TransProdDetalleID ");
            sConsulta.AppendLine("WHERE TRP.Tipo = 2 AND TRP.TipoFase = 1 AND TRP.MUsuarioID = @USUId AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
            sConsulta.AppendLine("UNION ALL ");
            sConsulta.AppendLine("SELECT TRP.FechaCaptura, TRP.Folio, PRO.ProductoClave, PRO.Nombre, SUM(ISNULL(TPD.CantidadOriginal, TPD.Cantidad)) AS CantidadOriginal, SUM(TPD.Cantidad), ");
            sConsulta.AppendLine("SUM((TPD.Cantidad * PPV.Precio)) AS SubTotal, dbo.FNCalcularImpuestoProducto(PRO.ProductoClave, TRP.FechaCaptura, SUM(TPD.Cantidad * PPV.Precio)) AS Impuesto, 1 AS Contenedor ");
            sConsulta.AppendLine("FROM TransProd TRP (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON TRP.DiaClave = Dia.DiaClave ");
            sConsulta.AppendLine("INNER JOIN TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID ");
            sConsulta.AppendLine("INNER JOIN ProductoUnidad PRU (NOLOCK) ON TPD.ProductoClave = PRU.ProductoClave AND TPD.TipoUnidad = PRU.PRUTipoUnidad ");
            sConsulta.AppendLine("INNER JOIN Producto PRO (NOLOCK) ON PRU.Contenedor = PRO.ProductoClave ");
            sConsulta.AppendLine("INNER JOIN ProductoDetalle PRD (NOLOCK) ON PRO.ProductoClave = PRD.ProductoClave AND PRD.Factor = 1 AND PRD.ProductoClave = PRD.ProductoDetClave ");
            sConsulta.AppendLine("INNER JOIN PrecioProductoVig PPV (NOLOCK) ON PRD.ProductoClave = PPV.ProductoClave AND PRD.PRUTipoUnidad = PPV.PRUTipoUnidad AND PPV.PrecioClave = @ListaPrecios AND TRP.FechaCaptura BETWEEN PPV.PPVFechaInicio AND PPV.FechaFin ");
            sConsulta.AppendLine("WHERE TRP.Tipo = 2 AND TRP.TipoFase = 1 AND NOT PRU.Contenedor IS NULL AND TRP.MUsuarioID = @USUId AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
            sConsulta.AppendLine("GROUP BY TRP.FechaCaptura, TRP.Folio, PRO.ProductoClave, PRO.Nombre ");
            sConsulta.AppendLine(") AS t ");
            sConsulta.AppendLine("ORDER BY Folio, Contenedor, ProductoClave ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            List<CargaPorDiaBYDModel> detalle = Connection.Query<CargaPorDiaBYDModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            if (detalle.Count() <= 0)
                return false;
            else
            {
                ArchivoXlsModel file = GenerarExcel(detalle);
                DownloadFile.DownloadOpenXML(file);
            }
            return true;
        }

        private ArchivoXlsModel GenerarExcel(List<CargaPorDiaBYDModel> detalle)
        {
            string fileName = "CargaPorDia_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Cargas Iniciales" };
            sheets.Append(sheet);

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            Dictionary<int, Row> Rows = new Dictionary<int, Row>();
            Dictionary<string, float> totalesAlmacen = new Dictionary<string, float>();
            Dictionary<string, float> totalesRuta = new Dictionary<string, float>();
            Dictionary<string, float> totalesConsigna = new Dictionary<string, float>();
            Dictionary<int, string> tiposMov = new Dictionary<int, string>();

            MyOpenXML.createRow(3, ref Rows);
            MyOpenXML.createCell(3, ref Rows, "D3", CellValues.String, this.NombreEmpresa);

            MyOpenXML.createRow(2, ref Rows);
            MyOpenXML.createCell(2, ref Rows, "D2", CellValues.String, this.NombreReporte);

            MyOpenXML.createRow(4, ref Rows);
            MyOpenXML.createCell(4, ref Rows, "A4", CellValues.String, Mensaje.ObtenerDescripcion("XSucursal", "EM") + ": " + sCEDI);

            MyOpenXML.createRow(5, ref Rows);
            if (bPorRuta)
                MyOpenXML.createCell(5, ref Rows, "A5", CellValues.String, Mensaje.ObtenerDescripcion("XRuta", "EM") + ": " + sRuta);
            else
                MyOpenXML.createCell(5, ref Rows, "A5", CellValues.String, Mensaje.ObtenerDescripcion("XVendedor", "EM") + ": " + sVendedor);

            MyOpenXML.createRow(6, ref Rows);
            MyOpenXML.createCell(6, ref Rows, "A6", CellValues.String, Mensaje.ObtenerDescripcion("XFecha", "EM") + ": " + sFecha);

            //ALMACENES
            MyOpenXML.createRow(8, ref Rows);
            MyOpenXML.createCell(8, ref Rows, "A8", CellValues.String, Mensaje.ObtenerDescripcion("XFecha", "EM"));
            MyOpenXML.createCell(8, ref Rows, "B8", CellValues.String, Mensaje.ObtenerDescripcion("XMaterial", "EM"));
            MyOpenXML.createCell(8, ref Rows, "C8", CellValues.String, Mensaje.ObtenerDescripcion("XCantPedida", "EM"));
            MyOpenXML.createCell(8, ref Rows, "D8", CellValues.String, Mensaje.ObtenerDescripcion("XCantSurtida", "EM"));
            MyOpenXML.createCell(8, ref Rows, "E8", CellValues.String, Mensaje.ObtenerDescripcion("XNoSurtido", "EM"));
            MyOpenXML.createCell(8, ref Rows, "F8", CellValues.String, Mensaje.ObtenerDescripcion("XValorBruto", "EM"));
            MyOpenXML.createCell(8, ref Rows, "G8", CellValues.String, Mensaje.ObtenerDescripcion("XImpuesto", "EM"));
            MyOpenXML.createCell(8, ref Rows, "H8", CellValues.String, Mensaje.ObtenerDescripcion("XValorNeto", "EM"));

            string sFolio = "";
            int nRow = 9;
            float subtCantOriginal = 0;
            float subtCantidad = 0;
            float subtSubtotal = 0;
            float subtImpuesto = 0;

            float totalCantOriginal = 0;
            float totalCantidad = 0;
            float totalSubtotal = 0;
            float totalImpuesto = 0;

            foreach (CargaPorDiaBYDModel det in detalle)
            {
                if (!sFolio.Equals(det.Folio))
                {
                    if (!sFolio.Equals(""))
                    {
                        MyOpenXML.createRow(nRow, ref Rows);
                        MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XSubtotal", "EM") + ":");
                        MyOpenXML.createCell(nRow, ref Rows, "C" + nRow.ToString(), CellValues.Number, subtCantOriginal.ToString());
                        MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.Number, subtCantidad.ToString());
                        MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.Number, (subtCantOriginal - subtCantidad).ToString());
                        MyOpenXML.createCell(nRow, ref Rows, "F" + nRow.ToString(), CellValues.Number, subtSubtotal.ToString("#,##0.00"));
                        MyOpenXML.createCell(nRow, ref Rows, "G" + nRow.ToString(), CellValues.Number, subtImpuesto.ToString("#,##0.00"));
                        MyOpenXML.createCell(nRow, ref Rows, "H" + nRow.ToString(), CellValues.Number, (subtSubtotal + subtImpuesto).ToString("#,##0.00"));

                        totalCantOriginal += subtCantOriginal;
                        totalCantidad += subtCantidad;
                        totalSubtotal += subtSubtotal;
                        totalImpuesto += subtImpuesto;

                        subtCantOriginal += 0;
                        subtCantidad += 0;
                        subtSubtotal += 0;
                        subtImpuesto += 0;

                        nRow += 2;
                    }
                    MyOpenXML.createRow(nRow, ref Rows);
                    MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XPedido", "EM") + ": " + det.Folio);
                    sFolio = det.Folio;
                    nRow += 2;
                }
                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, det.FechaCaptura.ToShortDateString());
                MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, det.ProductoClave + " " + det.Nombre);
                MyOpenXML.createCell(nRow, ref Rows, "C" + nRow.ToString(), CellValues.Number, det.CantidadOriginal.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.Number, det.Cantidad.ToString());
                MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.Number, (det.CantidadOriginal - det.Cantidad).ToString());
                MyOpenXML.createCell(nRow, ref Rows, "F" + nRow.ToString(), CellValues.Number, Math.Round(det.SubTotal, 2).ToString());
                MyOpenXML.createCell(nRow, ref Rows, "G" + nRow.ToString(), CellValues.Number, Math.Round(det.Impuesto, 2).ToString());//("#,##0.00"));
                MyOpenXML.createCell(nRow, ref Rows, "H" + nRow.ToString(), CellValues.Number, Math.Round(det.SubTotal + det.Impuesto, 2).ToString()); // "#,##0.00"));

                subtCantOriginal += det.CantidadOriginal;
                subtCantidad += det.Cantidad;
                subtSubtotal += (float)Math.Round(det.SubTotal, 2);
                subtImpuesto += (float)Math.Round(det.Impuesto, 2);
                nRow++;
            }

            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XSubtotal", "EM") + ":");
            MyOpenXML.createCell(nRow, ref Rows, "C" + nRow.ToString(), CellValues.Number, subtCantOriginal.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.Number, subtCantidad.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.Number, (subtCantOriginal - subtCantidad).ToString());
            MyOpenXML.createCell(nRow, ref Rows, "F" + nRow.ToString(), CellValues.Number, Math.Round(subtSubtotal, 2).ToString());
            MyOpenXML.createCell(nRow, ref Rows, "G" + nRow.ToString(), CellValues.Number, Math.Round(subtImpuesto, 2).ToString());
            MyOpenXML.createCell(nRow, ref Rows, "H" + nRow.ToString(), CellValues.Number, Math.Round(subtSubtotal + subtImpuesto, 2).ToString());
            nRow += 3;

            totalCantOriginal += subtCantOriginal;
            totalCantidad += subtCantidad;
            totalSubtotal += subtSubtotal;
            totalImpuesto += subtImpuesto;

            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "B" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XTotal", "EM") + ":");
            MyOpenXML.createCell(nRow, ref Rows, "C" + nRow.ToString(), CellValues.Number, totalCantOriginal.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.Number, totalCantidad.ToString());
            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.Number, (totalCantOriginal - totalCantidad).ToString());
            MyOpenXML.createCell(nRow, ref Rows, "F" + nRow.ToString(), CellValues.Number, Math.Round(totalSubtotal, 2).ToString());
            MyOpenXML.createCell(nRow, ref Rows, "G" + nRow.ToString(), CellValues.Number, Math.Round(totalImpuesto, 2).ToString());
            MyOpenXML.createCell(nRow, ref Rows, "H" + nRow.ToString(), CellValues.Number, Math.Round(totalSubtotal + totalImpuesto, 2).ToString());
            nRow += 6;

            MyOpenXML.createRow(nRow, ref Rows);
            MyOpenXML.createCell(nRow, ref Rows, "A" + nRow.ToString(), CellValues.String, Mensaje.ObtenerDescripcion("XNombreFirmaVendedor", "EM") + ":");

            foreach (var row in Rows)
            {
                sheetData.Append(row.Value);
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
        }//GenerarExcel


    }


    class CargaPorDiaBYDModel
    {
        public DateTime FechaCaptura { get; set; }
        public string Folio { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public float CantidadOriginal { get; set; }
        public float Cantidad { get; set; }
        public float SubTotal { get; set; }
        public float Impuesto { get; set; }
    }


}