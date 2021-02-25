using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class PromocionesNvoMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string sAlmacenNombre;
        private string NombreReporte;
        private string NombreEmpresa;
        private string sFiltroFecha;
        private string sVendedorID;


        private List<IndicadoresRuta> lstIndicadoresRuta;
        private List<IndicadoresRutaDetalle> lstIndicadoresRutaDet;
        private List<IndicadoresRutaGeneral> lstIndicadoresRutaGral;

        public bool GetReport(string NombreReporte, string NombreEmpresa, string AlmacenID, string AlmacenNombre, string FechaIni, string FechaFin, string VendedorID)
        {
            try
            {
                this.NombreReporte = NombreReporte;
                this.NombreEmpresa = NombreEmpresa;
                DateTime dFechaIni;
                DateTime.TryParse(FechaIni, out dFechaIni);
                DateTime dFechaFin;
                DateTime.TryParse(FechaFin, out dFechaFin);

                sAlmacenNombre = AlmacenNombre;
                if (dFechaIni == dFechaFin)
                    sFiltroFecha = dFechaIni.ToShortDateString();
                else
                    sFiltroFecha = dFechaIni.ToShortDateString() + " - " + dFechaFin.ToShortDateString();
                sVendedorID = VendedorID;

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("declare @AlmacenID as varchar(16) ");
                sConsulta.AppendLine("declare @FechaIni as datetime ");
                sConsulta.AppendLine("declare @FechaFin as datetime ");
                sConsulta.AppendLine("declare @VendedorID as varchar(16) ");

                sConsulta.AppendLine("set @AlmacenID = '" + AlmacenID + "'");
                sConsulta.AppendLine("set @FechaIni = '" + dFechaIni.ToString("s") + "'");
                sConsulta.AppendLine("set @FechaFin = '" + dFechaFin.ToString("s") + "'");
                sConsulta.AppendLine("set @VendedorID = " + (VendedorID != "" ? VendedorID : "''"));
                sConsulta.AppendLine("exec spReportePromocionesMOR @AlmacenID, @FechaIni, @FechaFin, @VendedorID");

                QueryString = sConsulta.ToString();
                DataTable dtPromos = new DataTable();
                using (SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString))
                {
                    Connection.Open();
                    using (SqlDataAdapter Adapter = new SqlDataAdapter(QueryString, (SqlConnection)Connection))
                    {
                        Adapter.Fill(dtPromos);
                    }
                    Connection.Close();
                }

                if (dtPromos.Rows.Count > 0)
                {
                    ArchivoXlsModel file = GenerarExcel(dtPromos);
                    DownloadFile.DownloadOpenXML(file);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private ArchivoXlsModel GenerarExcel(DataTable dtPromos)
        {
            string fileName = "Promociones_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Promociones" };
            sheets.Append(sheet);

            WorkbookStylesPart stylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            stylesPart.Stylesheet = MyOpenXML.GenerateStyleSheet();
            stylesPart.Stylesheet.Save();

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            Dictionary<int, Row> Rows = new Dictionary<int, Row>();
            MyOpenXML.createRow(2, ref Rows);
            MyOpenXML.createCell(2, ref Rows, "B2", CellValues.String, this.NombreEmpresa);

            MyOpenXML.createRow(3, ref Rows);
            MyOpenXML.createCell(3, ref Rows, "B3", CellValues.String, this.NombreReporte);

            MyOpenXML.createRow(4, ref Rows);
            MyOpenXML.createCell(4, ref Rows, "B4", CellValues.String, Mensaje.ObtenerDescripcion("XCEDI", "EM") + ": ");
            MyOpenXML.createCell(4, ref Rows, "C4", CellValues.String, sAlmacenNombre);

            MyOpenXML.createRow(5, ref Rows);
            MyOpenXML.createCell(5, ref Rows, "B5", CellValues.String, Mensaje.ObtenerDescripcion("XFecha", "EM") + ": ");
            MyOpenXML.createCell(5, ref Rows, "C5", CellValues.String, sFiltroFecha);

            if (sVendedorID != "")
            {
                MyOpenXML.createRow(6, ref Rows);
                string sVendedorNombre = Connection.Query<string>("select Nombre from Vendedor where VendedorID = " + sVendedorID, null, null, true, 9000).FirstOrDefault();
                MyOpenXML.createCell(6, ref Rows, "B6", CellValues.String, Mensaje.ObtenerDescripcion("XVendedor", "EM") + ": ");
                MyOpenXML.createCell(6, ref Rows, "C6", CellValues.String, sVendedorNombre);
            }

            MyOpenXML.createRow(6, ref Rows);
            MyOpenXML.createRow(7, ref Rows);
            MyOpenXML.createRow(8, ref Rows);
            MyOpenXML.createCell(8, ref Rows, "B8", CellValues.String, Mensaje.ObtenerDescripcion("XPromocion", "EM"));
            MyOpenXML.createCell(8, ref Rows, "C8", CellValues.String, Mensaje.ObtenerDescripcion("XClave", "EM"));
            MyOpenXML.createCell(8, ref Rows, "D8", CellValues.String, Mensaje.ObtenerDescripcion("XNombreContacto", "EM"));
            int nColumn = 5;
            string sRegalo = Mensaje.ObtenerDescripcion("XRegalo", "EM");
            foreach (DataColumn col in dtPromos.Columns)
            {
                if (!(col.ColumnName.Equals("PromocionClave") || col.ColumnName.Equals("ClaveCliente") || col.ColumnName.Equals("NombreContacto")))
                {
                    string[] producto = col.ColumnName.Split('|');
                    if (producto[1].Equals("1"))
                        MyOpenXML.createCell(6, ref Rows, GetExcelColumnName(nColumn) + "6", CellValues.String, sRegalo);
                    MyOpenXML.createCell(7, ref Rows, GetExcelColumnName(nColumn) + "7", CellValues.String, producto[0]);
                    string sProductoNombre = Connection.Query<string>("select Nombre from Producto where ProductoClave = '" + producto[0] + "'", null, null, true, 9000).FirstOrDefault();
                    MyOpenXML.createCell(8, ref Rows, GetExcelColumnName(nColumn) + "8", CellValues.String, sProductoNombre);
                    nColumn += 1;
                }
            }

            int nRow = 9;
            foreach (DataRow row in dtPromos.Rows)
            {
                nColumn = 2;
                MyOpenXML.createRow(nRow, ref Rows);
                foreach (DataColumn col in dtPromos.Columns)
                {
                    if (col.ColumnName.Equals("PromocionClave"))
                    {
                        string sPromocionNombre = Connection.Query<string>("select Nombre from Promocion where PromocionClave = '" + row[col.ColumnName] + "'", null, null, true, 9000).FirstOrDefault();
                        MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(nColumn) + nRow.ToString(), CellValues.String, sPromocionNombre);
                    }
                    else
                    {
                        if (row[col.ColumnName] != DBNull.Value)
                            MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(nColumn) + nRow.ToString(), CellValues.String, row[col.ColumnName].ToString());
                    }
                    nColumn += 1;
                }
                nRow += 1;
            }

            foreach (var row in Rows)
                sheetData.Append(row.Value);

            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;

            //string LogoQuery = "Select Logotipo from Configuracion";
            //byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            //MemoryStream mStream = new MemoryStream(byteArrayIn);

            //MyOpenXML.InsertImage(worksheetPart, 1, 5, 4, 6, mStream);           

            workbookPart.Workbook.Save();

            // Close the document.
            document.Close();

            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
        }//GenerarExcel


    }


}
