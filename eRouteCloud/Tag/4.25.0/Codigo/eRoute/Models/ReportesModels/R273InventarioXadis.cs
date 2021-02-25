using Dapper;
using DevExpress.Export.Xl;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace eRoute.Models.ReportesModels
{
    public class R273InventarioXadis
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

        private string nombreEmpresa;
        private string nombreReporte;
        private string CEDI;
        private string FechaInicial;
        private string Lenguaje;
        private DataTable dt;
        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public bool GetReport(string ReportName, string CompanyName, MemoryStream CompanyLogo, string CEDIS, string NameCEDIS, string InitialDate)
        {
            StringBuilder sConsulta = new StringBuilder();
            string QueryString;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_RW234InventarioTEZ]");
            sConsulta.AppendLine("@filtroCEDIS = '" + CEDIS + "',");
            sConsulta.AppendLine("@filtroFecha = '" + InitialDate + "'");
            
            QueryString = sConsulta.ToString();
            Connection.Open();
            var query = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (query.Count() > 0)
            {
                this.nombreEmpresa = CompanyName;
                this.nombreReporte = ReportName;
                this.CEDI = NameCEDIS;
                this.FechaInicial = InitialDate;
                
                var jsonClientes = JsonConvert.SerializeObject(query);
                this.dt = (DataTable)JsonConvert.DeserializeObject(jsonClientes, (typeof(DataTable)));

                ArchivoXlsModel file = GenerarExcel();
                DownloadFile.DownloadOpenXML(file);
                return true;
            }
            else
            {
                return false;
            }
        }
        private ArchivoXlsModel GenerarExcel()
        {
            IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xlsx);
            ArchivoXlsModel archivo;
            this.Lenguaje = ObtenerLenguaje();

            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.nombreReporte.Replace(" ", "");

                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        
                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Arial";
                        cellFormatting.Font.Size = 9;

                        XlCellFormatting subHeaderRowFormatting = new XlCellFormatting();
                        subHeaderRowFormatting.CopyFrom(cellFormatting);
                        subHeaderRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                        //subHeaderRowFormatting.Border = new XlBorder();
                        //subHeaderRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.Medium;

                        XlCellFormatting headerRowFormatting = new XlCellFormatting();
                        headerRowFormatting.CopyFrom(subHeaderRowFormatting);
                        //headerRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.None;
                        subHeaderRowFormatting.Font.Bold = true;
                        headerRowFormatting.Font.Size = 11;

                        XlFont Font = new XlFont();
                        Font.Bold = false;

                        // Datos de los Filtros Seleccionados.
                        // Nombre del Reporte.
                        using (IXlRow row = sheet.CreateRow(1))
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = this.nombreReporte;
                                cell.ApplyFormatting(headerRowFormatting);
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(1, 1, 5, 1));
                            }
                        }

                        // Nombre de la Empresa.
                        using (IXlRow row = sheet.CreateRow(3))
                        {
                            using (IXlCell cell = row.CreateCell(3))
                            {
                                cell.Value = this.nombreEmpresa;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XCEDI", this.Lenguaje) + ": " + this.CEDI;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XFecha", this.Lenguaje) + ": " + this.FechaInicial;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                cell.ApplyFormatting(Font);
                            }
                        }

                        int countRows = 7;
                        int countRowsPicture;
                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XCodArticulo", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.OutlineBorders(XlColor.Auto, XlBorderLineStyle.Thin));
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XCodAlmacen", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.OutlineBorders(XlColor.Auto, XlBorderLineStyle.Thin));
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XStock", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.OutlineBorders(XlColor.Auto, XlBorderLineStyle.Thin));
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XUniMinima", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.OutlineBorders(XlColor.Auto, XlBorderLineStyle.Thin));
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XPeriodoXadis", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.OutlineBorders(XlColor.Auto, XlBorderLineStyle.Thin));
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XTStock", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.OutlineBorders(XlColor.Auto, XlBorderLineStyle.Thin));
                            }
                        }

                        DataRow[] filas = this.dt.Select();
                        string sRegistro = "";

                        foreach (DataRow rows in this.dt.Rows)
                        {
                            countRows++;

                            using (IXlRow row = sheet.CreateRow(countRows))
                            {
                                foreach (DataColumn cols in dt.Columns)
                                {
                                   sRegistro = rows[cols.ColumnName].ToString();
                                   cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                                   

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sRegistro;
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.OutlineBorders(XlColor.Auto, XlBorderLineStyle.Thin));
                                    }
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
                archivo.nombre = this.nombreReporte.Replace(" ", "") + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            }
            return archivo;
        }
    }


}