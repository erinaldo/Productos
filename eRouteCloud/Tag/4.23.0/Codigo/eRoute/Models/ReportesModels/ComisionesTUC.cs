using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class ComisionesTUC
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string sAlmacenNombre;
        private string sFiltroFecha;
        //private string sVendedores;


        //private List<IndicadoresRuta> lstIndicadoresRuta;
        //private List<IndicadoresRutaDetalle> lstIndicadoresRutaDet;
        //private List<IndicadoresRutaGeneral> lstIndicadoresRutaGral;

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string AlmacenID, string AlmacenNombre, string FechaIni, string FechaFin, string Vendedores, string VendedoresSplit)
        {
            try
            {
                DateTime dFechaIni;
                DateTime.TryParse(FechaIni, out dFechaIni);
                DateTime dFechaFin;
                DateTime.TryParse(FechaFin, out dFechaFin);

                sAlmacenNombre = AlmacenNombre;
                if (dFechaIni == dFechaFin) 
                    sFiltroFecha = dFechaIni.ToShortDateString();
                else
                    sFiltroFecha = dFechaIni.ToShortDateString() + " - " + dFechaFin.ToShortDateString();
                dFechaFin = dFechaFin.Date.AddSeconds(86399);

                //sVendedores = VendedoresSplit;

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("select t.VendedorID, t.VendedorNombre, t.ProductoClave, t.ProductoNombre, t.Id, t.TipoUnidad, t.TipoComision, t.CantidadComision, sum(T.CantidadVenta) as CantidadVenta, ");
                sConsulta.AppendLine("sum(t.CantidadDevolucion) as CantidadDevolucion, sum(t.CantidadPromocion) as CantidadPromocion, sum(T.TotalVenta) as TotalVenta, ");
                sConsulta.AppendLine("sum(t.TotalDevolucion) as TotalDevolucion ");
                sConsulta.AppendLine("from ( ");
                sConsulta.AppendLine("select vis.VendedorID, ven.Nombre as VendedorNombre, pro.ProductoClave, pro.Nombre as ProductoNombre, pro.Id, vad.Descripcion as TipoUnidad, ");
                sConsulta.AppendLine("case when trp.Tipo = 1 and isnull(tpd.Promocion, 0) != 2 then tpd.Cantidad else 0 end as CantidadVenta, ");
                sConsulta.AppendLine("case when trp.Tipo = 3 then tpd.Cantidad else 0 end as CantidadDevolucion, ");
                sConsulta.AppendLine("case when trp.Tipo = 1 and isnull(tpd.Promocion, 0) = 2 then tpd.Cantidad else 0 end as CantidadPromocion, ");
                sConsulta.AppendLine("case when trp.Tipo = 1 and isnull(tpd.Promocion, 0) != 2 then tpd.Total else 0 end as TotalVenta, ");
                sConsulta.AppendLine("case when trp.Tipo = 3 then tpd.Total else 0 end as TotalDevolucion, ");
                sConsulta.AppendLine("isnull(com.TipoComision, 0) as TipoComision, isnull(pcv.Cantidad, 0) as CantidadComision ");
                sConsulta.AppendLine("from TransProd trp (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita vis (NOLOCK) on trp.VisitaClave = vis.VisitaClave and trp.DiaClave = vis.DiaClave ");
                sConsulta.AppendLine("inner join Vendedor ven (NOLOCK) on vis.VendedorID = ven.VendedorID "); 
                sConsulta.AppendLine("inner join Dia (NOLOCK) on vis.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Cliente cli  (NOLOCK) on vis.ClienteClave = cli.ClienteClave ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on trp.TransProdID = tpd.TransProdID ");
                sConsulta.AppendLine("inner join TPDDatosExtra tde (NOLOCK) on tpd.TransProdID = tde.TransProdID and tpd.TransProdDetalleID = tde.TransProdDetalleID ");
                sConsulta.AppendLine("inner join Producto pro (NOLOCK) on tpd.ProductoClave = pro.ProductoClave ");
                sConsulta.AppendLine("left join ProductoComisionVig pcv (NOLOCK) on tpd.ProductoClave = pcv.ProductoClave and tpd.TipoUnidad = pcv.TipoUnidad and trp.FechaHoraAlta between pcv.FechaInicio and pcv.FechaFin and pcv.ClaveComision = tde.PrecioClave ");
                sConsulta.AppendLine("left join Comision com (NOLOCK) on pcv.ClaveComision = com.ClaveComision ");
                sConsulta.AppendLine("inner join VAVDescripcion vad (NOLOCK) on vad.VARCodigo = 'UNIDADV' and vad.VAVClave = tpd.TipoUnidad and vad.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("where ((trp.Tipo = 1 and trp.TipoFase = 2) or (trp.Tipo = 3 and trp.TipoFase <> 0)) ");
                sConsulta.AppendLine("and Dia.FechaCaptura between  '" + dFechaIni.ToString("s") + "' AND '" + dFechaFin.ToString("s") + "' "); 
                sConsulta.AppendLine("and vis.VendedorID in (" + Vendedores + ") ");
                sConsulta.AppendLine(") as t ");
                sConsulta.AppendLine("group by t.VendedorID, t.VendedorNombre, t.ProductoClave, t.ProductoNombre, t.Id, t.TipoUnidad, t.TipoComision, t.CantidadComision ");
                sConsulta.AppendLine("order by t.VendedorNombre, t.Id ");
                string sComisiones = sConsulta.ToString();

                sConsulta.Clear();
                sConsulta.AppendLine("select t.VendedorID, t.EsquemaID, t.EsquemaNombre, t.ProductoClave, t.ProductoNombre, t.TipoUnidad, sum(T.CantidadVenta) as CantidadVenta, sum(t.CantidadDevolucion) as CantidadDevolucion ");
                sConsulta.AppendLine("from ( ");
                sConsulta.AppendLine("select vis.VendedorID, esq.EsquemaID, esq.Nombre as EsquemaNombre, pro.ProductoClave, pro.Nombre as ProductoNombre, vad.Descripcion as TipoUnidad, ");
                sConsulta.AppendLine("case when trp.Tipo = 1 then tpd.Cantidad else 0 end as CantidadVenta, ");
                sConsulta.AppendLine("case when trp.Tipo = 3 then tpd.Cantidad else 0 end as CantidadDevolucion ");
                sConsulta.AppendLine("from TransProd trp (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita vis (NOLOCK) on trp.VisitaClave = vis.VisitaClave and trp.DiaClave = vis.DiaClave ");
                sConsulta.AppendLine("inner join Vendedor ven (NOLOCK) on vis.VendedorID = ven.VendedorID ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on vis.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Cliente cli  (NOLOCK) on vis.ClienteClave = cli.ClienteClave ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on trp.TransProdID = tpd.TransProdID ");
                sConsulta.AppendLine("inner join Producto pro (NOLOCK) on tpd.ProductoClave = pro.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoEsquema pre (NOLOCK) on pro.ProductoClave = pre.ProductoClave ");
                sConsulta.AppendLine("inner join Esquema esq (NOLOCK) on pre.EsquemaID = esq.EsquemaID ");
                sConsulta.AppendLine("inner join VAVDescripcion vad (NOLOCK) on vad.VARCodigo = 'UNIDADV' and vad.VAVClave = tpd.TipoUnidad and vad.VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("where ((trp.Tipo = 1 and trp.TipoFase = 2) or (trp.Tipo = 3 and trp.TipoFase <> 0)) and isnull(tpd.Promocion, 0) != 2 ");
                sConsulta.AppendLine("and Dia.FechaCaptura between  '" + dFechaIni.ToString("s") + "' AND '" + dFechaFin.ToString("s") + "' ");
                sConsulta.AppendLine("and vis.VendedorID in (" + Vendedores + ") ");
                sConsulta.AppendLine("and esq.Nivel = 4 ");
                sConsulta.AppendLine(") as t ");
                sConsulta.AppendLine("group by t.VendedorID, t.EsquemaID, t.EsquemaNombre, t.ProductoClave, t.ProductoNombre, t.TipoUnidad ");
                string sEsquemas = sConsulta.ToString();

                ReporteComisionesTUC rptComisiones = new ReporteComisionesTUC(sComisiones, sEsquemas);

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                rptComisiones.logo.Image = Image.FromStream(mStream);
                rptComisiones.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                rptComisiones.empresa.Text = NombreEmpresa;
                rptComisiones.reporte.Text = NombreReporte;
                rptComisiones.lbCEDI.Text = Mensaje.ObtenerDescripcion("XCEDI", "EM");
                rptComisiones.lbVendedor.Text = Mensaje.ObtenerDescripcion("XVendedor", "EM");
                rptComisiones.lbFecha.Text = Mensaje.ObtenerDescripcion("XFecha", "EM");

                rptComisiones.lbCEDIFiltro.Text = sAlmacenNombre;
                rptComisiones.lbVendedorFiltro.Text = "'"+ VendedoresSplit;
                rptComisiones.lbFechaFiltro.Text = sFiltroFecha;
                rptComisiones.lbFechaFiltroGr.Text = sFiltroFecha;

                rptComisiones.lbClave.Text = Mensaje.ObtenerDescripcion("XClave", "EM").ToUpper();
                rptComisiones.lbProducto.Text = Mensaje.ObtenerDescripcion("XProducto", "EM").ToUpper();
                rptComisiones.lbUnidad.Text = Mensaje.ObtenerDescripcion("XUnidad", "EM").ToUpper();
                rptComisiones.lbCantidad.Text = Mensaje.ObtenerDescripcion("XCantidad", "EM").ToUpper();
                rptComisiones.lbDevolucion.Text = Mensaje.ObtenerDescripcion("XDev", "EM").ToUpper();
                rptComisiones.lbTotal.Text = Mensaje.ObtenerDescripcion("XTotal", "EM").ToUpper();
                rptComisiones.lbComision.Text = Mensaje.ObtenerDescripcion("XComisionProd", "EM").ToUpper();
                rptComisiones.lbTotalComision.Text = Mensaje.ObtenerDescripcion("XTotalComisionProd", "EM").ToUpper();
                rptComisiones.lbProdPromocion.Text = Mensaje.ObtenerDescripcion("XProductoPromocion", "EM").ToUpper();
                rptComisiones.lbTotales.Text = Mensaje.ObtenerDescripcion("XTotalesm", "EM");

                ((ReporteEsquemasComisionesTUC)rptComisiones.rptEsquemas.ReportSource).lbClave.Text = Mensaje.ObtenerDescripcion("XClave", "EM").ToUpper();
                ((ReporteEsquemasComisionesTUC)rptComisiones.rptEsquemas.ReportSource).lbProducto.Text = Mensaje.ObtenerDescripcion("XProducto", "EM").ToUpper();
                ((ReporteEsquemasComisionesTUC)rptComisiones.rptEsquemas.ReportSource).lbUnidad.Text = Mensaje.ObtenerDescripcion("XUnidad", "EM").ToUpper();
                ((ReporteEsquemasComisionesTUC)rptComisiones.rptEsquemas.ReportSource).lbCantidad.Text = Mensaje.ObtenerDescripcion("XCantidad", "EM").ToUpper();
                ((ReporteEsquemasComisionesTUC)rptComisiones.rptEsquemas.ReportSource).lbTotal.Text = Mensaje.ObtenerDescripcion("XTotal", "EM").ToUpper();

                rptComisiones.Name = "ComisionesTUC" + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss") + ".xlsx";

                return rptComisiones;

          
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //private string GetExcelColumnName(int columnNumber)
        //{
        //    int dividend = columnNumber;
        //    string columnName = String.Empty;
        //    int modulo;

        //    while (dividend > 0)
        //    {
        //        modulo = (dividend - 1) % 26;
        //        columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
        //        dividend = (int)((dividend - modulo) / 26);
        //    }

        //    return columnName;
        //}

        //private ArchivoXlsModel GenerarExcel(DataTable dtComisiones)
        //{
        //    string fileName = "Comisiones_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

        //    MemoryStream ms = new MemoryStream();
        //    SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

        //    WorkbookPart workbookPart = document.AddWorkbookPart();
        //    workbookPart.Workbook = new Workbook();

        //    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        //    worksheetPart.Worksheet = new Worksheet(new SheetData());

        //    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
        //    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Comisiones" };
        //    sheets.Append(sheet);

        //    WorkbookStylesPart stylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
        //    stylesPart.Stylesheet = MyOpenXML.GenerateStyleSheet();
        //    stylesPart.Stylesheet.Save();

        //    Worksheet worksheet = new Worksheet();
        //    SheetData sheetData = new SheetData();

        //    Dictionary<int, Row> Rows = new Dictionary<int, Row>();
        //    MyOpenXML.createRow(2, ref Rows);
        //    MyOpenXML.createCell(2, ref Rows, "A2", CellValues.String, ValorReferencia.ObtenerDescripcion("REPORTEW", "245", "EM"));

        //    MyOpenXML.createRow(3, ref Rows);
        //    MyOpenXML.createCell(3, ref Rows, "A3", CellValues.String, Mensaje.ObtenerDescripcion("XCEDI", "EM") + ": ");
        //    MyOpenXML.createCell(3, ref Rows, "B3", CellValues.String, sAlmacenNombre);         

          
        //    MyOpenXML.createRow(4, ref Rows);
        //    MyOpenXML.createCell(4, ref Rows, "A4", CellValues.String, Mensaje.ObtenerDescripcion("XVendedor", "EM") + ": ");
        //    MyOpenXML.createCell(4, ref Rows, "B4", CellValues.String, sVendedores);

        //    MyOpenXML.createRow(5, ref Rows);
        //    MyOpenXML.createCell(5, ref Rows, "A5", CellValues.String, Mensaje.ObtenerDescripcion("XFecha", "EM") + ": ");
        //    MyOpenXML.createCell(5, ref Rows, "B5", CellValues.String, sFiltroFecha);

        //    MyOpenXML.createRow(6, ref Rows);
        //    MyOpenXML.createRow(7, ref Rows);
        //    int nRow = 8;

            

            
        //    MyOpenXML.createRow(8, ref Rows);
        //    MyOpenXML.createCell(8, ref Rows, "B8", CellValues.String, Mensaje.ObtenerDescripcion("XPromocion", "EM"));
        //    MyOpenXML.createCell(8, ref Rows, "C8", CellValues.String, Mensaje.ObtenerDescripcion("XClave", "EM"));
        //    MyOpenXML.createCell(8, ref Rows, "D8", CellValues.String, Mensaje.ObtenerDescripcion("XNombreContacto", "EM"));
        //    int nColumn = 5;
        //    string sRegalo = Mensaje.ObtenerDescripcion("XRegalo", "EM");
        //    foreach (DataColumn col in dtPromos.Columns) {
        //        if (!(col.ColumnName.Equals("PromocionClave") || col.ColumnName.Equals("ClaveCliente") || col.ColumnName.Equals("NombreContacto")))
        //        {
        //            string[] producto = col.ColumnName.Split('|');
        //            if (producto[1].Equals("1"))
        //                MyOpenXML.createCell(6, ref Rows, GetExcelColumnName(nColumn) + "6", CellValues.String, sRegalo);
        //            MyOpenXML.createCell(7, ref Rows, GetExcelColumnName(nColumn) + "7", CellValues.String, producto[0]);
        //            string sProductoNombre = Connection.Query<string>("select Nombre from Producto where ProductoClave = '" + producto[0] + "'", null, null, true, 9000).FirstOrDefault();
        //            MyOpenXML.createCell(8, ref Rows, GetExcelColumnName(nColumn) + "8", CellValues.String, sProductoNombre);
        //            nColumn += 1;
        //        }                
        //    }

        //    int nRow = 9;
        //    foreach (DataRow row in dtPromos.Rows)
        //    {
        //        nColumn = 2;
        //        MyOpenXML.createRow(nRow, ref Rows);
        //        foreach (DataColumn col in dtPromos.Columns)
        //        {
        //            if (col.ColumnName.Equals("PromocionClave"))
        //            {
        //                string sPromocionNombre = Connection.Query<string>("select Nombre from Promocion where PromocionClave = '" + row[col.ColumnName] + "'", null, null, true, 9000).FirstOrDefault();
        //                MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(nColumn) + nRow.ToString(), CellValues.String, sPromocionNombre);
        //            }
        //            else
        //            {
        //                if (row[col.ColumnName] != DBNull.Value)
        //                    MyOpenXML.createCell(nRow, ref Rows, GetExcelColumnName(nColumn) + nRow.ToString(), CellValues.String, row[col.ColumnName].ToString());
        //            }
        //            nColumn += 1;
        //        }
        //        nRow += 1;
        //    }

        //    foreach (var row in Rows)
        //    sheetData.Append(row.Value);

        //    worksheet.Append(sheetData);
        //    worksheetPart.Worksheet = worksheet;

        //    //string LogoQuery = "Select Logotipo from Configuracion";
        //    //byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
        //    //MemoryStream mStream = new MemoryStream(byteArrayIn);

        //    //MyOpenXML.InsertImage(worksheetPart, 1, 5, 4, 6, mStream);           

        //    workbookPart.Workbook.Save();

        //    // Close the document.
        //    document.Close();

        //    ArchivoXlsModel archivo = new ArchivoXlsModel();
        //    archivo.archivo = ms.ToArray();
        //    archivo.nombre = fileName;
        //    return archivo;
        //}//GenerarExcel


    }
      

}
