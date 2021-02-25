//using DevExpress.XtraReports.UI;
//using DevExpress.XtraPrinting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web;
//using Dapper;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Data;
//using System.IO;
//using System.Drawing;
//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using System.Threading;

//namespace eRoute.Models.ReportesModels
//{
//    public class PromocionesMOR
//    {
//        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
//        private string QueryString = "";

//        public ArchivoXlsModel GetReport(string nombreReport, string nombreCedis, string FechaInicial, string FechaFinal, string Cedis, string pvCondition, string sFecha, int VAVClave)
//        {
//            try
//            {

//                bool ExisteOrdenProductos = ordenProductos(VAVClave);
//                DateTime Fecha = Convert.ToDateTime(FechaInicial);
//                DateTime sFechaFin;
//                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
//                {
//                    sFechaFin = Fecha;
//                }
//                else
//                {
//                    sFechaFin = Convert.ToDateTime(FechaFinal);
//                }


//                StringBuilder sConsulta1 = new StringBuilder();
//                sConsulta1.AppendLine("declare @TotalClientesCedi as table(AlmacenId varchar(16), TotalClientes int)");
//                sConsulta1.AppendLine("");
//                sConsulta1.AppendLine("insert into @TotalClientesCedi");
//                sConsulta1.AppendLine("select ALM.AlmacenID, (count(distinct CLI.ClienteClave)) as TotalClientes");
//                sConsulta1.AppendLine("from Cliente CLI ");
//                sConsulta1.AppendLine("inner join Almacen ALM on CLI.AlmacenId = ALM.AlmacenID ");
//                sConsulta1.AppendLine(pvCondition);
//                sConsulta1.AppendLine("and CLI.TipoEstado=1");
//                sConsulta1.AppendLine("group by ALM.AlmacenID");
//                sConsulta1.AppendLine("");
//                sConsulta1.AppendLine("select ALM.AlmacenID, ALM.Clave, ALM.Nombre as AMLNombre, TPD.ProductoClave, PRO.Nombre, ");
//                sConsulta1.AppendLine("(select t.TotalClientes from @TotalClientesCedi t where t.AlmacenId=ALM.AlmacenID) as TotalClientes, ");
//                sConsulta1.AppendLine("COUNT(distinct VIS.ClienteClave) as Clientes,");
//                sConsulta1.AppendLine("round((COUNT(distinct VIS.ClienteClave)*100)/(select t.TotalClientes from @TotalClientesCedi t where t.AlmacenId=ALM.AlmacenID),0) as Cobertura");
//                sConsulta1.AppendLine("from TransProd TRP ");
//                sConsulta1.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId=TPD.TransProdId ");
//                sConsulta1.AppendLine("inner join Visita VIS on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
//                sConsulta1.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ");
//                sConsulta1.AppendLine("inner join Cliente CLI on VIS.ClienteClave=CLI.ClienteClave");
//                sConsulta1.AppendLine("inner join Almacen ALM on CLI.AlmacenId = ALM.AlmacenID ");
//                sConsulta1.AppendLine("inner join Producto PRO on TPD.ProductoClave=PRO.ProductoClave");
//                if (ExisteOrdenProductos)
//                    sConsulta1.AppendLine("inner join OrdenProductos OP on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
//                sConsulta1.AppendLine(pvCondition);
//                sConsulta1.AppendLine("and ( " + sFecha + " )");
//                sConsulta1.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion=1) ");
//                if (ExisteOrdenProductos)
//                {
//                    sConsulta1.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, TPD.ProductoClave, PRO.Nombre, OP.Orden");
//                    sConsulta1.AppendLine("order by OP.Orden");
//                }
//                else
//                {
//                    sConsulta1.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, TPD.ProductoClave, PRO.Nombre");
//                    sConsulta1.AppendLine("order by TPD.ProductoClave");
//                }

//                QueryString = "";
//                QueryString = sConsulta1.ToString();

//                List<ProductosDetalleModel> productosDetalle = Connection.Query<ProductosDetalleModel>(QueryString, null, null, true, 600).ToList();
//                //if (ProductosDetalle.Count() <= 0)
//                //{
//                //    return null;
//                //}


//                string empresaQuery = "select NombreEmpresa from Configuracion";
//                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();


//                StringBuilder sConsulta2 = new StringBuilder();
//                sConsulta2.AppendLine("select ALM.AlmacenID, ALM.Clave, ALM.Nombre, (count(distinct CLI.ClienteClave)) as TotalClientes");
//                sConsulta2.AppendLine("from Cliente CLI ");
//                sConsulta2.AppendLine("inner join Almacen ALM on CLI.AlmacenId = ALM.AlmacenID ");
//                sConsulta2.AppendLine(pvCondition);
//                sConsulta2.AppendLine("and CLI.TipoEstado=1");
//                sConsulta2.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre");


//                QueryString = "";
//                QueryString = sConsulta2.ToString();

//                List<CedisProModel> CCedis = Connection.Query<CedisProModel>(QueryString, null, null, true, 600).ToList();
//                //if (Esquema2.Count() <= 0)
//                //{
//                //    return null;
//                //}

//                StringBuilder sConsulta3 = new StringBuilder();
//                sConsulta3.AppendLine("declare @TotalClientes as Int");
//                sConsulta3.AppendLine("");
//                sConsulta3.AppendLine("select @TotalClientes=(count(distinct CLI.ClienteClave)) ");
//                sConsulta3.AppendLine("from Cliente CLI ");
//                sConsulta3.AppendLine("inner join Almacen ALM on CLI.AlmacenId = ALM.AlmacenID ");
//                sConsulta3.AppendLine(pvCondition);
//                sConsulta3.AppendLine("and CLI.TipoEstado=1");
//                sConsulta3.AppendLine("");
//                sConsulta3.AppendLine("select TPD.ProductoClave, PRO.Nombre, ");
//                sConsulta3.AppendLine("@TotalClientes as TotalClientes, ");
//                sConsulta3.AppendLine("COUNT(distinct VIS.ClienteClave) as Clientes,");
//                sConsulta3.AppendLine("round((COUNT(distinct VIS.ClienteClave)*100)/@TotalClientes,0) as Cobertura");
//                sConsulta3.AppendLine("from TransProd TRP ");
//                sConsulta3.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId=TPD.TransProdId ");
//                sConsulta3.AppendLine("inner join Visita VIS on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
//                sConsulta3.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ");
//                sConsulta3.AppendLine("inner join Cliente CLI on VIS.ClienteClave=CLI.ClienteClave");
//                sConsulta3.AppendLine("inner join Almacen ALM on CLI.AlmacenId = ALM.AlmacenID ");
//                sConsulta3.AppendLine("inner join Producto PRO on TPD.ProductoClave=PRO.ProductoClave");
//                if (ExisteOrdenProductos)
//                    sConsulta3.AppendLine("inner join OrdenProductos OP on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
//                sConsulta3.AppendLine(pvCondition);
//                sConsulta3.AppendLine("and ( " + sFecha + " )");
//                sConsulta3.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion=1) ");
//                if (ExisteOrdenProductos)
//                {
//                    sConsulta3.AppendLine("group by TPD.ProductoClave, PRO.Nombre, OP.Orden");
//                    sConsulta3.AppendLine("order by OP.Orden");
//                }
//                else
//                {
//                    sConsulta3.AppendLine("group by TPD.ProductoClave, PRO.Nombre");
//                    sConsulta3.AppendLine("order by TPD.ProductoClave");
//                }
//                QueryString = "";
//                QueryString = sConsulta3.ToString();

//                List<TotalProductosModel> totalProductos = Connection.Query<TotalProductosModel>(QueryString, null, null, true, 600).ToList();


//                StringBuilder sConsulta4 = new StringBuilder();
//                sConsulta4.AppendLine("select TPD.ProductoClave, PRO.Nombre");
//                sConsulta4.AppendLine("from TransProd TRP ");
//                sConsulta4.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId=TPD.TransProdId ");
//                sConsulta4.AppendLine("inner join Visita VIS on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
//                sConsulta4.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ");
//                sConsulta4.AppendLine("inner join Cliente CLI on VIS.ClienteClave=CLI.ClienteClave");
//                sConsulta4.AppendLine("inner join Almacen ALM on CLI.AlmacenId = ALM.AlmacenID ");
//                sConsulta4.AppendLine("inner join Producto PRO on TPD.ProductoClave=PRO.ProductoClave");
//                if (ExisteOrdenProductos)
//                    sConsulta4.AppendLine("inner join OrdenProductos OP on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
//                sConsulta4.AppendLine(pvCondition);
//                sConsulta4.AppendLine("and ( " + sFecha + " )");
//                sConsulta4.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion=1) ");
//                if (ExisteOrdenProductos)
//                {
//                    sConsulta4.AppendLine("group by TPD.ProductoClave, PRO.Nombre, OP.Orden");
//                    sConsulta4.AppendLine("order by OP.Orden");
//                }
//                else
//                {
//                    sConsulta4.AppendLine("group by TPD.ProductoClave, PRO.Nombre");
//                    sConsulta4.AppendLine("order by TPD.ProductoClave");
//                }

//                QueryString = "";
//                QueryString = sConsulta4.ToString();
//                List<ProductosProModel> productos = Connection.Query<ProductosProModel>(QueryString, null, null, true, 600).ToList();


//                List<ProductosDetalleModel> drColsProductosDetalle = new List<ProductosDetalleModel>();
//                int iContador = 0;

//                string filename = nombreReport + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + ".xlsx";
//                MemoryStream ms = new MemoryStream();
//                SpreadsheetDocument x1 = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
//                WorkbookPart wbp = x1.AddWorkbookPart();
//                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
//                Workbook wb = new Workbook();
//                FileVersion fv = new FileVersion();
//                fv.ApplicationName = "Microsoft Office Excel";
//                Worksheet ws = new Worksheet();
//                SheetData sd = new SheetData();

//                //creamos hoja de estilo
//                WorkbookStylesPart sp = wbp.AddNewPart<WorkbookStylesPart>();
//                sp.Stylesheet = new Stylesheet();
//                sp.Stylesheet.NumberingFormats = new NumberingFormats();

//                NumberingFormat nf2decimal = new NumberingFormat();
//                nf2decimal.NumberFormatId = UInt32Value.FromUInt32(3453);
//                nf2decimal.FormatCode = StringValue.FromString("0.0%");
//                sp.Stylesheet.NumberingFormats.Append(nf2decimal);

//                CellFormat cellFormat = new CellFormat();
//                cellFormat.FontId = 0;
//                cellFormat.FillId = 0;
//                cellFormat.BorderId = 0;
//                cellFormat.FormatId = 0;
//                cellFormat.NumberFormatId = nf2decimal.NumberFormatId;
//                cellFormat.ApplyNumberFormat = BooleanValue.FromBoolean(true);
//                cellFormat.ApplyFont = true;

//                //////agregamos el formato de la celda
//                sp.Stylesheet.CellFormats = new CellFormats();
//                sp.Stylesheet.CellFormats.AppendChild<CellFormat>(cellFormat);

//                //////actualizamos el contador de fuentes
//                sp.Stylesheet.CellFormats.Count = UInt32Value.FromUInt32((uint)sp.Stylesheet.CellFormats.ChildElements.Count);

//                ////guarda los cambios a la hoja de estilo
//                sp.Stylesheet.Save();
//                //fin

//                Dictionary<int, Row> Rows = new Dictionary<int, Row>();

//                createRow(1, ref Rows);

//                createCell(1, ref Rows, "A1", CellValues.String, nombreEmpresa, false);

//                createRow(2, ref Rows);
//                createCell(2, ref Rows, "A2", CellValues.String, "Reporte: " + nombreReport, false);

//                createRow(4, ref Rows);
//                createCell(4, ref Rows, "A4", CellValues.String, "Agencia: " + nombreCedis, false);

//                createRow(5, ref Rows);
//                createCell(5, ref Rows, "A5", CellValues.String, "Periodo: " + Fecha.ToString("dd/MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"), false);

//                int currentRow = 7;

//                //Encabezados
//                createRow(currentRow, ref Rows);
//                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Agencia", false);
//                createCell(currentRow, ref Rows, null, CellValues.String, "Cartera de Ctes.", false);

//                foreach (var drProducto in productos)
//                {
//                    createCell(currentRow, ref Rows, null, CellValues.String, drProducto.Nombre, false);
//                    createCell(currentRow, ref Rows, null, CellValues.String, "", false);
//                }

//                currentRow++;
//                createRow(currentRow, ref Rows);
//                createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, "", false);

//                foreach (var drProducto in productos)
//                {
//                    createCell(currentRow, ref Rows, null, CellValues.String, "Ctes", false);//
//                    createCell(currentRow, ref Rows, null, CellValues.String, "Cob", false);
//                }

//                //Detalle
//                currentRow++;
//                createRow(currentRow, ref Rows);

//                foreach (var drCedi in CCedis)
//                {
//                    createCell(currentRow, ref Rows, null, CellValues.String, drCedi.Nombre, false);
//                    createCell(currentRow, ref Rows, null, CellValues.Number, drCedi.TotalClientes, false);
//                    foreach (var drProducto in productos)
//                    {
//                        drColsProductosDetalle = (from productoD in productosDetalle where productoD.AlmacenID == drCedi.AlmacenID && productoD.ProductoClave == drProducto.ProductoClave select productoD).ToList();
//                        if (drColsProductosDetalle.Count > 0)
//                        {
//                            foreach (var drProductoDetalle in drColsProductosDetalle)
//                            {
//                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Clientes, false);
//                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Cobertura, true);
//                            }
//                        }
//                        else
//                        {
//                            createCell(currentRow, ref Rows, null, CellValues.String, "", false);
//                            createCell(currentRow, ref Rows, null, CellValues.String, "", false);
//                        }
//                    }
//                }

//                //Total
//                currentRow++;
//                currentRow++;
//                createRow(currentRow, ref Rows);
//                createCell(currentRow, ref Rows, null, CellValues.String, "Total Zona", false);

//                foreach (var drProducto in totalProductos)
//                {
//                    List<TotalProductosModel> drColsProductosDetalleT = (from productoT in totalProductos where productoT.ProductoClave == drProducto.ProductoClave select productoT).ToList();
//                    if (drColsProductosDetalleT.Count > 0)
//                    {
//                        foreach (var drProductoDetalle in drColsProductosDetalleT)
//                        {
//                            if (iContador > 0)
//                            {
//                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Clientes, false);
//                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Cobertura, true);
//                            }
//                            else
//                            {
//                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.TotalClientes, false);
//                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Clientes, false);
//                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Cobertura, true);
//                            }
//                            iContador++;
//                        }
//                    }
//                    else
//                    {
//                        createCell(currentRow, ref Rows, null, CellValues.String, "", false);
//                        createCell(currentRow, ref Rows, null, CellValues.String, "", false);
//                    }

//                }


//                foreach (var row in Rows)
//                {
//                    sd.Append(row.Value);
//                }

//                ws.Append(sd);
//                wsp.Worksheet = ws;
//                wsp.Worksheet.Save();
//                Sheets sheets = new Sheets();
//                Sheet sheet = new Sheet();
//                sheet.Name = nombreReport;
//                sheet.SheetId = 1;
//                sheet.Id = wbp.GetIdOfPart(wsp);
//                sheets.Append(sheet);
//                wb.Append(fv);
//                wb.Append(sheets);

//                x1.WorkbookPart.Workbook = wb;
//                x1.WorkbookPart.Workbook.Save();
//                x1.Close();

//                ArchivoXlsModel archivo = new ArchivoXlsModel();
//                archivo.archivo = ms.ToArray();
//                archivo.nombre = filename;
//                return archivo;
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }

//        bool ordenProductos(int VAVClave)
//        {
//            string query = "Select * from OrdenProductos where ReporteW = '" + VAVClave + "'";
//            List<DataTable> resultado = Connection.Query<DataTable>(query, null, null, true, 9000).ToList();
//            if (resultado.Count > 0)
//            {
//                return true;
//            }
//            return false;
//        }

//        void createRow(int id, ref Dictionary<int, Row> Rows)
//        {
//            Rows.Add(id, new Row() { RowIndex = (UInt32)id });
//        }

//        void createCell(int idRow, ref Dictionary<int, Row> Rows, string cellReference, DocumentFormat.OpenXml.Spreadsheet.CellValues dt, string cellValue, bool percent)
//        {
//            Cell cell = new Cell();
//            if (cellReference != null)
//                cell.CellReference = cellReference;
//            cell.DataType = dt;
//            cell.CellValue = new CellValue(cellValue);
//            //if (percent)
//            //    cell.StyleIndex = 4;
//            if (Rows.ContainsKey(idRow))
//            {
//                Rows[idRow].Append(cell);
//            }
//        }



//    }

//    class ProductosDetalleModel
//    {
//        public string AlmacenID { get; set; }
//        public string Clave { get; set; }
//        public string AMLNombre { get; set; }
//        public string ProductoClave { get; set; }
//        public string Nombre { get; set; }
//        public string TotalClientes { get; set; }
//        public string Clientes { get; set; }
//        public string Cobertura { get; set; }
//    }

//    class CedisProModel
//    {
//        public string AlmacenID { get; set; }
//        public string Clave { get; set; }
//        public string Nombre { get; set; }
//        public string TotalClientes { get; set; }
//    }

//    class TotalProductosModel
//    {
//        public string ProductoClave { get; set; }
//        public string Nombre { get; set; }
//        public string TotalClientes { get; set; }
//        public string Clientes { get; set; }
//        public string Cobertura { get; set; }
//    }

//    class ProductosProModel
//    {
//        public string ProductoClave { get; set; }
//        public string Nombre { get; set; }
//    }
//}

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
    public class PromocionesMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string nombreReport, string nombreCedis, string FechaInicial, string FechaFinal, string Cedis, string pvCondition, string sFecha, int VAVClave)
        {
            try
            {

                bool ExisteOrdenProductos = ordenProductos(VAVClave);
                DateTime Fecha = Convert.ToDateTime(FechaInicial);
                DateTime sFechaFin;
                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
                {
                    sFechaFin = Fecha;
                }
                else
                {
                    sFechaFin = Convert.ToDateTime(FechaFinal);
                }


                StringBuilder sConsulta1 = new StringBuilder();
                sConsulta1.AppendLine("declare @TotalClientesCedi as table(AlmacenId varchar(16), TotalClientes int)");
                sConsulta1.AppendLine("");
                sConsulta1.AppendLine("insert into @TotalClientesCedi");
                sConsulta1.AppendLine("select ALM.AlmacenID, (count(distinct CLI.ClienteClave)) as TotalClientes");
                sConsulta1.AppendLine("from Cliente CLI (NOLOCK) ");
                sConsulta1.AppendLine("inner join Almacen ALM (NOLOCK) on CLI.AlmacenId = ALM.AlmacenID ");
                sConsulta1.AppendLine(pvCondition);
                sConsulta1.AppendLine("and CLI.TipoEstado=1");
                sConsulta1.AppendLine("group by ALM.AlmacenID");
                sConsulta1.AppendLine("");
                sConsulta1.AppendLine("select ALM.AlmacenID, ALM.Clave, ALM.Nombre as AMLNombre, TPD.ProductoClave, PRO.Nombre, ");
                sConsulta1.AppendLine("(select t.TotalClientes from @TotalClientesCedi t where t.AlmacenId=ALM.AlmacenID) as TotalClientes, ");
                sConsulta1.AppendLine("COUNT(distinct VIS.ClienteClave) as Clientes,");
                sConsulta1.AppendLine("round((COUNT(distinct VIS.ClienteClave)*100)/(select t.TotalClientes from @TotalClientesCedi t where t.AlmacenId=ALM.AlmacenID),0) as Cobertura");
                sConsulta1.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta1.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta1.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta1.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta1.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave=CLI.ClienteClave");
                sConsulta1.AppendLine("inner join Almacen ALM (NOLOCK) on CLI.AlmacenId = ALM.AlmacenID ");
                sConsulta1.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave=PRO.ProductoClave");
                if (ExisteOrdenProductos)
                    sConsulta1.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta1.AppendLine(pvCondition);
                sConsulta1.AppendLine("and ( " + sFecha + " )");
                sConsulta1.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion=1) ");
                if (ExisteOrdenProductos)
                {
                    sConsulta1.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, TPD.ProductoClave, PRO.Nombre, OP.Orden");
                    sConsulta1.AppendLine("order by OP.Orden");
                }
                else
                {
                    sConsulta1.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, TPD.ProductoClave, PRO.Nombre");
                    sConsulta1.AppendLine("order by TPD.ProductoClave");
                }

                QueryString = "";
                QueryString = sConsulta1.ToString();

                List<ProductosDetalleModel> productosDetalle = Connection.Query<ProductosDetalleModel>(QueryString, null, null, true, 600).ToList();
                //if (ProductosDetalle.Count() <= 0)
                //{
                //    return null;
                //}


                string empresaQuery = "select NombreEmpresa from Configuracion (NOLOCK) ";
                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();


                StringBuilder sConsulta2 = new StringBuilder();
                sConsulta2.AppendLine("select ALM.AlmacenID, ALM.Clave, ALM.Nombre, (count(distinct CLI.ClienteClave)) as TotalClientes");
                sConsulta2.AppendLine("from Cliente CLI (NOLOCK) ");
                sConsulta2.AppendLine("inner join Almacen ALM (NOLOCK) on CLI.AlmacenId = ALM.AlmacenID ");
                sConsulta2.AppendLine(pvCondition);
                sConsulta2.AppendLine("and CLI.TipoEstado=1");
                sConsulta2.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre");


                QueryString = "";
                QueryString = sConsulta2.ToString();

                List<CedisProModel> CCedis = Connection.Query<CedisProModel>(QueryString, null, null, true, 600).ToList();
                //if (Esquema2.Count() <= 0)
                //{
                //    return null;
                //}

                StringBuilder sConsulta3 = new StringBuilder();
                sConsulta3.AppendLine("declare @TotalClientes as Int");
                sConsulta3.AppendLine("");
                sConsulta3.AppendLine("select @TotalClientes=(count(distinct CLI.ClienteClave)) ");
                sConsulta3.AppendLine("from Cliente CLI (NOLOCK) ");
                sConsulta3.AppendLine("inner join Almacen ALM (NOLOCK) on CLI.AlmacenId = ALM.AlmacenID ");
                sConsulta3.AppendLine(pvCondition);
                sConsulta3.AppendLine("and CLI.TipoEstado=1");
                sConsulta3.AppendLine("");
                sConsulta3.AppendLine("select TPD.ProductoClave, PRO.Nombre, ");
                sConsulta3.AppendLine("@TotalClientes as TotalClientes, ");
                sConsulta3.AppendLine("COUNT(distinct VIS.ClienteClave) as Clientes,");
                sConsulta3.AppendLine("round((COUNT(distinct VIS.ClienteClave)*100)/@TotalClientes,0) as Cobertura");
                sConsulta3.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta3.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta3.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta3.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta3.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave=CLI.ClienteClave");
                sConsulta3.AppendLine("inner join Almacen ALM (NOLOCK) on CLI.AlmacenId = ALM.AlmacenID ");
                sConsulta3.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave=PRO.ProductoClave");
                if (ExisteOrdenProductos)
                    sConsulta3.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta3.AppendLine(pvCondition);
                sConsulta3.AppendLine("and ( " + sFecha + " )");
                sConsulta3.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion=1) ");
                if (ExisteOrdenProductos)
                {
                    sConsulta3.AppendLine("group by TPD.ProductoClave, PRO.Nombre, OP.Orden");
                    sConsulta3.AppendLine("order by OP.Orden");
                }
                else
                {
                    sConsulta3.AppendLine("group by TPD.ProductoClave, PRO.Nombre");
                    sConsulta3.AppendLine("order by TPD.ProductoClave");
                }
                QueryString = "";
                QueryString = sConsulta3.ToString();

                List<TotalProductosModel> totalProductos = Connection.Query<TotalProductosModel>(QueryString, null, null, true, 600).ToList();


                StringBuilder sConsulta4 = new StringBuilder();
                sConsulta4.AppendLine("select TPD.ProductoClave, PRO.Nombre");
                sConsulta4.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta4.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta4.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta4.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta4.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave=CLI.ClienteClave");
                sConsulta4.AppendLine("inner join Almacen ALM (NOLOCK) on CLI.AlmacenId = ALM.AlmacenID ");
                sConsulta4.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave=PRO.ProductoClave");
                if (ExisteOrdenProductos)
                    sConsulta4.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta4.AppendLine(pvCondition);
                sConsulta4.AppendLine("and ( " + sFecha + " )");
                sConsulta4.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion=1) ");
                if (ExisteOrdenProductos)
                {
                    sConsulta4.AppendLine("group by TPD.ProductoClave, PRO.Nombre, OP.Orden");
                    sConsulta4.AppendLine("order by OP.Orden");
                }
                else
                {
                    sConsulta4.AppendLine("group by TPD.ProductoClave, PRO.Nombre");
                    sConsulta4.AppendLine("order by TPD.ProductoClave");
                }

                QueryString = "";
                QueryString = sConsulta4.ToString();
                List<ProductosProModel> productos = Connection.Query<ProductosProModel>(QueryString, null, null, true, 600).ToList();


                List<ProductosDetalleModel> drColsProductosDetalle = new List<ProductosDetalleModel>();
                int iContador = 0;

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

                //creamos hoja de estilo
                WorkbookStylesPart sp = wbp.AddNewPart<WorkbookStylesPart>();
                sp.Stylesheet = CreateStylesheet();

                //guarda los cambios a la hoja de estilo
                sp.Stylesheet.Save();

                Dictionary<int, Row> Rows = new Dictionary<int, Row>();

                createRow(1, ref Rows);

                createCell(1, ref Rows, "A1", CellValues.String, nombreEmpresa, false);

                createRow(2, ref Rows);
                createCell(2, ref Rows, "A2", CellValues.String, nombreReport, false);

                createRow(4, ref Rows);
                createCell(4, ref Rows, "A4", CellValues.String, "Agencia: " + nombreCedis, false);

                createRow(5, ref Rows);
                createCell(5, ref Rows, "A5", CellValues.String, "Periodo: " + Fecha.ToString("dd/MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"), false);

                int currentRow = 7;

                //Encabezados
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Agencia", false);
                createCell(currentRow, ref Rows, null, CellValues.String, "Cartera de Ctes.", false);

                foreach (var drProducto in productos)
                {
                    createCell(currentRow, ref Rows, null, CellValues.String, drProducto.Nombre, false);
                    createCell(currentRow, ref Rows, null, CellValues.String, "", false);
                }

                currentRow++;
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, "", false);

                foreach (var drProducto in productos)
                {
                    createCell(currentRow, ref Rows, null, CellValues.String, "Ctes", false);//
                    createCell(currentRow, ref Rows, null, CellValues.String, "Cob", false);
                }

                //Detalle
                currentRow++;
                createRow(currentRow, ref Rows);

                foreach (var drCedi in CCedis)
                {
                    createCell(currentRow, ref Rows, null, CellValues.String, drCedi.Nombre, false);
                    createCell(currentRow, ref Rows, null, CellValues.Number, drCedi.TotalClientes, false);
                    foreach (var drProducto in productos)
                    {
                        drColsProductosDetalle = (from productoD in productosDetalle where productoD.AlmacenID == drCedi.AlmacenID && productoD.ProductoClave == drProducto.ProductoClave select productoD).ToList();
                        if (drColsProductosDetalle.Count > 0)
                        {
                            foreach (var drProductoDetalle in drColsProductosDetalle)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Clientes, false);
                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Cobertura, true);
                            }
                        }
                        else
                        {
                            createCell(currentRow, ref Rows, null, CellValues.String, "", false);
                            createCell(currentRow, ref Rows, null, CellValues.String, "", false);
                        }
                    }
                }

                //Total
                currentRow++;
                currentRow++;
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, null, CellValues.String, "Total Zona", false);

                foreach (var drProducto in totalProductos)
                {
                    List<TotalProductosModel> drColsProductosDetalleT = (from productoT in totalProductos where productoT.ProductoClave == drProducto.ProductoClave select productoT).ToList();
                    if (drColsProductosDetalleT.Count > 0)
                    {
                        foreach (var drProductoDetalle in drColsProductosDetalleT)
                        {
                            if (iContador > 0)
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Clientes, false);
                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Cobertura, true);
                            }
                            else
                            {
                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.TotalClientes, false);
                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Clientes, false);
                                createCell(currentRow, ref Rows, null, CellValues.Number, drProductoDetalle.Cobertura, true);
                            }
                            iContador++;
                        }
                    }
                    else
                    {
                        createCell(currentRow, ref Rows, null, CellValues.String, "", false);
                        createCell(currentRow, ref Rows, null, CellValues.String, "", false);
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

        bool ordenProductos(int VAVClave)
        {
            string query = "Select * from OrdenProductos (NOLOCK) where ReporteW = '" + VAVClave + "'";
            List<DataTable> resultado = Connection.Query<DataTable>(query, null, null, true, 9000).ToList();
            if (resultado.Count > 0)
            {
                return true;
            }
            return false;
        }

        void createRow(int id, ref Dictionary<int, Row> Rows)
        {
            Rows.Add(id, new Row() { RowIndex = (UInt32)id });
        }

        void createCell(int idRow, ref Dictionary<int, Row> Rows, string cellReference, DocumentFormat.OpenXml.Spreadsheet.CellValues dt, string cellValue, bool percent)
        {
            Cell cell = new Cell();
            if (cellReference != null)
                cell.CellReference = cellReference;
            cell.DataType = dt;
            cell.CellValue = new CellValue(cellValue);
            if (percent)
                cell.StyleIndex = 1;
            if (Rows.ContainsKey(idRow))
            {
                Rows[idRow].Append(cell);
            }
        }

        private static SheetData CreateSheetData()
        {
            SheetData sheetData1 = new SheetData();
            Row row1 = new Row() { RowIndex = (UInt32Value)1U, Spans = new ListValue<StringValue>() { InnerText = "1:3" }, DyDescent = 0.25D };
            Cell cell1 = new Cell() { CellReference = "A1", StyleIndex = (UInt32Value)1U, CellValue = new CellValue("16"), DataType = CellValues.Number };

            row1.Append(cell1);

            Row row2 = new Row() { RowIndex = (UInt32Value)2U, Spans = new ListValue<StringValue>() { InnerText = "1:3" }, DyDescent = 0.25D };
            Cell cell2 = new Cell() { CellReference = "B2", StyleIndex = (UInt32Value)2U };

            row2.Append(cell2);

            Row row3 = new Row() { RowIndex = (UInt32Value)3U, Spans = new ListValue<StringValue>() { InnerText = "1:3" }, DyDescent = 0.25D };
            Cell cell3 = new Cell() { CellReference = "C3", StyleIndex = (UInt32Value)3U };

            row3.Append(cell3);

            sheetData1.Append(row1);
            sheetData1.Append(row2);
            sheetData1.Append(row3);

            return sheetData1;
        }

        private static Stylesheet CreateStylesheet()
        {
            Stylesheet stylesheet1 = new Stylesheet();

            Fonts fonts1 = new Fonts() { Count = (UInt32Value)1U, KnownFonts = true };

            DocumentFormat.OpenXml.Spreadsheet.Font font1 = new DocumentFormat.OpenXml.Spreadsheet.Font();
            FontSize fontSize1 = new FontSize() { Val = 11D };
            DocumentFormat.OpenXml.Office2010.Excel.Color color1 = new DocumentFormat.OpenXml.Office2010.Excel.Color() { Theme = (UInt32Value)1U };
            FontName fontName1 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontScheme1);

            fonts1.Append(font1);

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

            // FillId = 4,YELLO
            Fill fill5 = new Fill();
            PatternFill patternFill5 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor3 = new ForegroundColor() { Rgb = "FFFFFF00" };
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

            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)4U };
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };
            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)3453U };
            CellFormat cellFormat4 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)3U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true };
            CellFormat cellFormat5 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true };

            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);
            cellFormats1.Append(cellFormat4);
            cellFormats1.Append(cellFormat5);

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

    class ProductosDetalleModel
    {
        public string AlmacenID { get; set; }
        public string Clave { get; set; }
        public string AMLNombre { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public string TotalClientes { get; set; }
        public string Clientes { get; set; }
        public string Cobertura { get; set; }
    }

    class CedisProModel
    {
        public string AlmacenID { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string TotalClientes { get; set; }
    }

    class TotalProductosModel
    {
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public string TotalClientes { get; set; }
        public string Clientes { get; set; }
        public string Cobertura { get; set; }
    }

    class ProductosProModel
    {
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
    }
}