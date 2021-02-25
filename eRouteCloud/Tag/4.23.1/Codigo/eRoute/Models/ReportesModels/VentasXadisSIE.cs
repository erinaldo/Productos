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
    public class VentasXadisSIE
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string Lenguaje;

        private List<VentasXadisSIEModel> ListModel;
        private string QueryString;
        private string nombreEmpresa;
        private string nombreReporte;
        private string FechaInicial;
        private string FechaFinal;

        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public bool GetReport(string CompanyName, string ReportName, string StatusDate, string InitialDate, string FinalDate)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();

                if (InitialDate == "")
                {
                    InitialDate = null;
                }

                if (InitialDate != null)
                {
                    InitialDate = DateTime.Parse(InitialDate).ToString("yyyy-MM-dd");
                    FinalDate = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyy-MM-dd") : InitialDate);

                    sConsulta.Clear();
                    sConsulta.AppendLine("set language english");
                    sConsulta.AppendLine("");
                    sConsulta.AppendLine("EXECUTE [dbo].[Stpr_ReporteVentasXadis_SIE]");
                    sConsulta.AppendLine("@FECHAINICIAL = '" + InitialDate + "',");
                    sConsulta.AppendLine("@FECHAFINAL = '" + FinalDate + "'");
                    sConsulta.AppendLine("");
                    sConsulta.AppendLine("set language spanish");
                    QueryString = sConsulta.ToString();

                    ListModel = Connection.Query<VentasXadisSIEModel>(QueryString, null, null, true, 9000).ToList();

                    if (ListModel.Count > 0)
                    {
                        this.FechaInicial = DateTime.Parse(InitialDate).Date.ToString("yyyyMMdd");
                        this.FechaFinal = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : null);
                        this.nombreEmpresa = CompanyName;
                        this.nombreReporte = ReportName;

                        ArchivoXlsModel file = GenerarExcel();
                        DownloadFile.DownloadOpenXML(file);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        private ArchivoXlsModel GenerarExcel()
        {
            IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xlsx);
            ArchivoXlsModel archivo;
            this.Lenguaje = ObtenerLenguaje();
            var nom = ValorReferencia.ObtenerDescripcion("REPORTEW", "260", this.Lenguaje);
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = nom.ToString().Replace(" ", "");
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 110; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 110; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 75; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 75; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 140; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 160; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 110; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 110; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 60; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 105; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 50; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 130; }

                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Arial";
                        cellFormatting.Font.Size = 9;

                        XlCellFormatting subHeaderRowFormatting = new XlCellFormatting();
                        subHeaderRowFormatting.CopyFrom(cellFormatting);
                        subHeaderRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                        subHeaderRowFormatting.Border = new XlBorder();
                        subHeaderRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.Medium;

                        XlCellFormatting headerRowFormatting = new XlCellFormatting();
                        headerRowFormatting.CopyFrom(subHeaderRowFormatting);
                        headerRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.None;
                        subHeaderRowFormatting.Font.Bold = true;
                        headerRowFormatting.Font.Size = 15;

                        // Nombre del Reporte.
                        using (IXlRow row = sheet.CreateRow(1))
                        {
                            using (IXlCell cell = row.CreateCell(4))
                            {
                                cell.Value = ValorReferencia.ObtenerDescripcion("REPORTEW", "260", this.Lenguaje);
                                cell.ApplyFormatting(headerRowFormatting);
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(4, 1, 8, 1));
                            }
                        }

                        // Nombre de la Empresa.
                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(4))
                            {
                                cell.Value = this.nombreEmpresa;
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
                                cell.Value = Mensaje.ObtenerDescripcion("XFechas", this.Lenguaje) + ": " + (this.FechaFinal == null ? this.FechaInicial : this.FechaInicial + " - " + this.FechaFinal);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                cell.ApplyFormatting(Font);
                            }
                        }

                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(6))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "A = COD ARTICULO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "B = COD ALMACEN";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "C = VENTA";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "D = DEVOLUCION";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "E = UNIDAD";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "F = PERIODO AAAAMMDD";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "G = COD CLIENTE";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "H = CANAL CLIENTE";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "I = PRECIO CLIENTE";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "J = % DESCUENTO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "K = DESCUENTO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "L = PRECIO NETO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "M = IEPS";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "N = PRECIO BRUTO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "O = IVA";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "P = PRECIO FINAL";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Q = FACTURA";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "R = TIPO MOVIMIENTO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                        }

                        foreach (var item in ListModel)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.COD_ARTICULO;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.COD_ALMACEN;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.VENTA;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.DEVOLUCION;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.UNIDAD;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.PERIODO;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.COD_CLIENTE;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.CANAL_CLIENTE;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.PRECIO_CLIENTE;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.DESCUENTOPORCENTAJE;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.DESCUENTO;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.PRECIONETO;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.IEPS;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.PRECIOBRUTO;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.IVA;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.PRECIOFINAL;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.FACTURA;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.TIPOMOV;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                            }
                        }

                        XlCellFormatting totalRowFormatting = new XlCellFormatting();
                        totalRowFormatting.CopyFrom(cellFormatting);
                        totalRowFormatting.Font.Bold = true;
                        totalRowFormatting.Fill = XlFill.SolidFill(XlColor.FromTheme(XlThemeColor.Accent5, 0.6));
                    }
                }
                archivo = new ArchivoXlsModel();
                archivo.archivo = stream.ToArray();
                archivo.nombre = nom.ToString().Replace(" ", "") + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            }
            return archivo;
        }
    }

    class VentasXadisSIEModel
    {
        public string COD_ARTICULO { get; set; }
        public string COD_ALMACEN { get; set; }
        public string VENTA { get; set; }
        public string DEVOLUCION { get; set; }
        public string UNIDAD { get; set; }
        public string PERIODO { get; set; }
        public string COD_CLIENTE { get; set; }
        public string CANAL_CLIENTE { get; set; }
        public string PRECIO_CLIENTE { get; set; }
        public string DESCUENTOPORCENTAJE { get; set; }
        public string DESCUENTO { get; set; }
        public string PRECIONETO { get; set; }
        public string IEPS { get; set; }
        public string PRECIOBRUTO { get; set; }
        public string IVA { get; set; }
        public string PRECIOFINAL { get; set; }
        public string FACTURA { get; set; }
        public string TIPOMOV { get; set; }
    }
}