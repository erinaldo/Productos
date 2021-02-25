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
    public class VendedorCliModelListPreBYD
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string sAlmacenNombre;
        private string NombreReporte;
        private string NombreEmpresa;


        private List<VenCliModelListPreBYD> lstVenCliModelListPreBYD;

        public bool GetReport(string NombreReporte, string NombreEmpresa, string Cedis, string nombreCedis, string pvCondicion, string FechaInicial, string FechaFinal)
        {
            try
            {
                this.NombreReporte = NombreReporte;
                this.NombreEmpresa = NombreEmpresa;

                var wheredateInit = "";
                var wheredateEnd = "";
                wheredateInit = pvCondicion.Substring(33, 21);
                wheredateEnd = pvCondicion.Substring(59);
                var whereCedi = "";
                if (Cedis != "")
                {
                    whereCedi = " and A.Clave = " + Cedis;
                }

                if (nombreCedis == "")
                {
                    nombreCedis = "Todas";
                }
                sAlmacenNombre = nombreCedis;

                DateTime fInicio = DateTime.Parse(FechaInicial);
                DateTime fFin = DateTime.Now;
                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
                {
                    FechaFinal = "";
                }
                else
                {
                    fFin = DateTime.Parse(FechaFinal);
                    FechaFinal = " AL " + fFin.Date.ToShortDateString();
                }

                var date_header = fInicio.Date.ToShortDateString() + FechaFinal;

                StringBuilder sConsulta = new StringBuilder();

                sConsulta.AppendLine("select V.VendedorID, V.Nombre, A.Clave + ' ' + A.Nombre as Sucursal, V.ClienteModelo, V.ListaPrecioBase");
                sConsulta.AppendLine("from Vendedor V (NOLOCK)");
                sConsulta.AppendLine("inner join VENCentroDistHist VCH (NOLOCK) on VCH.VendedorId = V.VendedorID and V.TipoEstado = 1");
                sConsulta.AppendLine("and VCH.VCHFechaInicial  >= " + wheredateInit + " and VCH.FechaFinal >= " + wheredateEnd);
                //sConsulta.AppendLine("and VCH.VCHFechaInicial  >= '2019-01-06T00:00:00'  and VCH.FechaFinal >= '2019-01-10T00:00:00'  ");
                sConsulta.AppendLine(pvCondicion);
                //sConsulta.AppendLine("and VCH.VCHFechaInicial  between '2019-01-06T00:00:00' and '2019-01-10T00:00:00'   ");
                sConsulta.AppendLine("inner join Almacen A (NOLOCK) on VCH.AlmacenId = A.AlmacenID and A.TipoEstado = 1 " + whereCedi);
                //sConsulta.AppendLine("inner join Almacen A (NOLOCK) on VCH.AlmacenId = A.AlmacenID and A.TipoEstado = 1 -- and A.Clave = ''");
                sConsulta.AppendLine("where V.TipoEstado = 1");
                sConsulta.AppendLine("order by V.VendedorID");

                QueryString = sConsulta.ToString();
                lstVenCliModelListPreBYD = Connection.Query<VenCliModelListPreBYD>(QueryString, null, null, true, 600).ToList();

                

                if (lstVenCliModelListPreBYD.Count > 0)
                {
                    ArchivoXlsModel file = GenerarExcel(date_header);
                    DownloadFile.DownloadOpenXML(file);
                    return true;
                }
                else
                {
                    return false;
                }
                
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

        private ArchivoXlsModel GenerarExcel(string fecha)
        {
            string fileName = this.NombreReporte + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = this.NombreReporte };
            sheets.Append(sheet);

            WorkbookStylesPart stylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            stylesPart.Stylesheet = MyOpenXML.GenerateStyleSheet();
            stylesPart.Stylesheet.Save();

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            Dictionary<int, Row> Rows = new Dictionary<int, Row>();

            MyOpenXML.createRow(2, ref Rows);
            //MyOpenXML.createCell(2, ref Rows, "B2", CellValues.String, ValorReferencia.ObtenerDescripcion("REPORTEW", "251", "EM"), 4);
            MyOpenXML.createCell(2, ref Rows, "B2", CellValues.String, this.NombreEmpresa, 5);

            MyOpenXML.createRow(3, ref Rows);
            //MyOpenXML.createCell(2, ref Rows, "B2", CellValues.String, ValorReferencia.ObtenerDescripcion("REPORTEW", "251", "EM"), 4);
            MyOpenXML.createCell(3, ref Rows, "B3", CellValues.String, this.NombreReporte, 5);

            MyOpenXML.createRow(4, ref Rows);
            MyOpenXML.createCell(4, ref Rows, "A4", CellValues.String, "Sucursal: " + sAlmacenNombre, 4);

            MyOpenXML.createRow(5, ref Rows);
            MyOpenXML.createCell(5, ref Rows, "A5", CellValues.String, Mensaje.ObtenerDescripcion("XFecha", "EM") + "(s): " + fecha, 4);

            MyOpenXML.createRow(8, ref Rows);
            MyOpenXML.createCell(8, ref Rows, "A8", CellValues.String, "Número de Vendedor", 3);
            MyOpenXML.createCell(8, ref Rows, "B8", CellValues.String, Mensaje.ObtenerDescripcion("VENNombre", "EM"), 3);
            MyOpenXML.createCell(8, ref Rows, "C8", CellValues.String, Mensaje.ObtenerDescripcion("XSucursal", "EM"), 3);
            MyOpenXML.createCell(8, ref Rows, "D8", CellValues.String, Mensaje.ObtenerDescripcion("VENClienteModelo", "EM"), 3);
            MyOpenXML.createCell(8, ref Rows, "E8", CellValues.String, "Lista Precios Base", 3);


            if (lstVenCliModelListPreBYD.Count != 0)
            {
                var initRowValues = 9;
                var initCell = 9;
                for (int a = 0; a < lstVenCliModelListPreBYD.Count(); a++)
                {
                    MyOpenXML.createRow((initRowValues + a), ref Rows);
                    MyOpenXML.createCell((initRowValues + a), ref Rows, GetExcelColumnName(1) + (initRowValues + a).ToString(), CellValues.String, lstVenCliModelListPreBYD[a].VendedorID, 2);
                    MyOpenXML.createCell((initRowValues + a), ref Rows, GetExcelColumnName(2) + (initRowValues + a).ToString(), CellValues.String, lstVenCliModelListPreBYD[a].Nombre, 2);
                    MyOpenXML.createCell((initRowValues + a), ref Rows, GetExcelColumnName(3) + (initRowValues + a).ToString(), CellValues.String, lstVenCliModelListPreBYD[a].Sucursal, 2);
                    MyOpenXML.createCell((initRowValues + a), ref Rows, GetExcelColumnName(4) + (initRowValues + a).ToString(), CellValues.String, lstVenCliModelListPreBYD[a].ClienteModelo, 2);
                    MyOpenXML.createCell((initRowValues + a), ref Rows, GetExcelColumnName(5) + (initRowValues + a).ToString(), CellValues.String, lstVenCliModelListPreBYD[a].ListaPrecioBase, 2);
                }
            }

            foreach (var row in Rows)
                sheetData.Append(row.Value);

            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;

            // Close the document.
            document.Close();

            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
        }//GenerarExcel
    }

    class VenCliModelListPreBYD
    {
        public String VendedorID { get; set; }
        public String Nombre { get; set; }
        public String Sucursal { get; set; }
        public String ClienteModelo { get; set; }
        public String ListaPrecioBase { get; set; }
    }

}
