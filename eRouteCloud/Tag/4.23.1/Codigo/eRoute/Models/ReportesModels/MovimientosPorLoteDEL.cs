using Dapper;
using DevExpress.Export.Xl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace eRoute.Models.ReportesModels
{
    public class MovimientosPorLoteDEL
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string Lotes;
        private string FechaInicial;
        private string FechaFinal;
        private string NombreReporte;
        private string NombreEmpresa;
        private MemoryStream LogoEmpresa;

        private List<MovimientosPorLoteDELModel> lstMovimientosPorLote;

        public bool GetReport(string NombreReporte, string NombreEmpresa, string dateStatus, string Lotes, string FechaInicial, string FechaFinal)
        {
            try
            {
                if (FechaInicial != null)
                {
                    DateTime init = DateTime.Parse(FechaInicial);
                    switch (dateStatus)
                    {
                        case "Igual":
                            FechaInicial = init.Date.ToString("yyyy-MM-dd");
                            FechaFinal = init.Date.ToString("yyyy-MM-dd");
                            break;
                        case "Entre":
                            FechaInicial = init.Date.ToString("yyyy-MM-dd");
                            FechaFinal = DateTime.Parse(FechaFinal).Date.ToString("yyyy-MM-dd");
                            break;
                    }
                }

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteMovimientosPorLoteDEL] ");
                sConsulta.AppendLine("@filtroLotes = '" + Lotes + "', ");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "', ");
                sConsulta.AppendLine("@filtroFechaFin = '" + FechaFinal + "'");
                QueryString = sConsulta.ToString();
                lstMovimientosPorLote = Connection.Query<MovimientosPorLoteDELModel>(QueryString, null, null, true, 9000).ToList();
                
                if (lstMovimientosPorLote.Count > 0)
                {
                    this.Lotes = (Lotes == "" ? "Todos los Lotes seleccionados" : Lotes);
                    if (FechaInicial != null)
                    {
                        DateTime fInicio = DateTime.Parse(FechaInicial);
                        if (FechaFinal == null || FechaFinal == FechaInicial)
                        {
                            this.FechaFinal = "";
                        }
                        else
                        {
                            DateTime fFin = DateTime.Now;
                            fFin = DateTime.Parse(FechaFinal);
                            this.FechaFinal = " al " + fFin.Date.ToShortDateString();
                        }
                        this.FechaInicial = fInicio.Date.ToShortDateString();
                    }

                    this.NombreEmpresa = NombreEmpresa;
                    this.NombreReporte = NombreReporte;

                    ArchivoXlsModel file = GenerarExcel();
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
        private ArchivoXlsModel GenerarExcel()
        {
            IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xlsx);
            ArchivoXlsModel archivo;
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.NombreReporte.Substring(0, 25);
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 60; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 80; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 70; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 300; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 80; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 70; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 80; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 300; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 200; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 200; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 120; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 70; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 110; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 50; }

                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Arial";
                        cellFormatting.Font.Size = 10;
                        cellFormatting.Font.SchemeStyle = XlFontSchemeStyles.None;

                        XlCellFormatting subHeaderRowFormatting = new XlCellFormatting();
                        subHeaderRowFormatting.CopyFrom(cellFormatting);
                        subHeaderRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                        subHeaderRowFormatting.Border = new XlBorder();
                        subHeaderRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.Medium;
                        subHeaderRowFormatting.Font.Bold = true;

                        XlCellFormatting headerRowFormatting = new XlCellFormatting();
                        headerRowFormatting.CopyFrom(subHeaderRowFormatting);
                        headerRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.None;
                        headerRowFormatting.Font.Size = 15;

                        // Nombre del Reporte.
                        using (IXlRow row = sheet.CreateRow(1))
                        {
                            using (IXlCell cell = row.CreateCell(4))
                            {
                                cell.Value = this.NombreReporte;
                                cell.ApplyFormatting(headerRowFormatting);
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(4, 1, 8, 1));
                            }
                        }

                        // Nombre de la Empresa.
                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(4))
                            {
                                cell.Value = this.NombreEmpresa;
                                cell.ApplyFormatting(headerRowFormatting);
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(4, 2, 8, 2));
                            }
                        }

                        // Datos de los Filtros Seleccionados.
                        XlFont Font = new XlFont();
                        Font.Bold = false;
                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XLote", "EM") + "(s): " + this.Lotes;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 3, 17, 3));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XFecha", "EM") + "(s): " + this.FechaInicial + this.FechaFinal;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 4, 17, 4));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(6))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Lote";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Caducidad";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Código";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Producto";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Movimiento";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Referencia";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Fecha";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Cantidad";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Clave Clie.";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Cliente";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Dirección";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Colonia";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Población";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "C. Postal";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Teléfono";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Num. Vend.";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Vendedor";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Ruta";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                        }

                        foreach (var Lote in lstMovimientosPorLote)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Lote;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Caducidad;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Codigo;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Producto;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Movimiento;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Referencia;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Fecha;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Cantidad;
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlNumberFormat.Number2);
                                    cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center));
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.ClaveClie;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Cliente;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Direccion;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Colonia;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Poblacion;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.CPostal;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Telefono;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.NumVend;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Vendedor;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Lote.Ruta;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                            }
                        }
                    }
                }
                archivo = new ArchivoXlsModel();
                archivo.archivo = stream.ToArray();
                archivo.nombre = this.NombreReporte + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            }
            return archivo;
        }
    }

    class MovimientosPorLoteDELModel
    {
        public String Lote { get; set; }
        public String Caducidad { get; set; }
        public String Codigo { get; set; }
        public String Producto { get; set; }
        public String Movimiento { get; set; }
        public String Referencia { get; set; }
        public String Fecha { get; set; }
        public String Cantidad { get; set; }
        public String ClaveClie { get; set; }
        public String Cliente { get; set; }
        public String Direccion { get; set; }
        public String Colonia { get; set; }
        public String Poblacion { get; set; }
        public String CPostal { get; set; }
        public String Telefono { get; set; }
        public String NumVend { get; set; }
        public String Vendedor { get; set; }
        public String Ruta { get; set; }
    }
}