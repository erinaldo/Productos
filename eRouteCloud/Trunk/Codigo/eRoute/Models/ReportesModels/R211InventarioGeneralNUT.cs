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
    public class R211InventarioGeneralNUT
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string nombreEmpresa;
        private string nombreReporte;
        private string CEDIS;
        private string NameCEDIS;
        private string FechaInicial;
        private string StatusDate;
        private string Lenguaje;
        private StringBuilder sConsulta = new StringBuilder();
        private DataTable dtKardex;

        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public bool GetReport(string ReportName, string CompanyName, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate)
        {
            this.CEDIS = CEDIS;
            this.NameCEDIS = NameCEDIS;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R211InventarioGeneral_NUT]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "'");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryKardex = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (queryKardex.Count() > 0)
            {
                var jsonKardex = JsonConvert.SerializeObject(queryKardex);
                this.dtKardex = (DataTable)JsonConvert.DeserializeObject(jsonKardex, (typeof(DataTable)));

                if (InitialDate != null)
                {
                    this.FechaInicial = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                    this.StatusDate = StatusDate;
                }

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
                        sheet.Name = this.nombreReporte.Split(' ')[0];

                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 300; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 120; }

                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Arial";
                        cellFormatting.Font.Size = 9;

                        XlCellFormatting cellFormattingBold = new XlCellFormatting();
                        cellFormattingBold.CopyFrom(cellFormatting);
                        cellFormattingBold.Font.Bold = true;

                        XlCellFormatting subHeaderRowFormatting = new XlCellFormatting();
                        subHeaderRowFormatting.CopyFrom(cellFormatting);
                        subHeaderRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                        subHeaderRowFormatting.Border = new XlBorder();
                        subHeaderRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.Medium;

                        XlCellFormatting headerRowFormatting = new XlCellFormatting();
                        headerRowFormatting.CopyFrom(subHeaderRowFormatting);
                        headerRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.None;
                        subHeaderRowFormatting.Font.Bold = true;
                        headerRowFormatting.Font.Size = 15;

                        XlFont Font = new XlFont();
                        Font.Bold = false;

                        // Datos de los Filtros Seleccionados.
                        // Nombre del Reporte.
                        using (IXlRow row = sheet.CreateRow(1))
                        {
                            using (IXlCell cell = row.CreateCell(2))
                            {
                                cell.Value = this.nombreReporte.ToUpper();
                                cell.ApplyFormatting(headerRowFormatting);
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(2, 1, 7, 1));
                            }
                        }

                        // Nombre de la Empresa.
                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = this.nombreEmpresa.ToUpper();
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
                                cell.Value = Mensaje.ObtenerDescripcion("XCEDI", this.Lenguaje) + ": " + this.NameCEDIS;
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
                                cell.Value = Mensaje.ObtenerDescripcion("XDia", this.Lenguaje) + ": " + this.FechaInicial;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                cell.ApplyFormatting(Font);
                            }
                        }

                        int countRows = 6;
                        string sRegistro = "";
                        string encabezado = "";
                        string producto = "";
                        string almacen = "";
                        string clave = "";
                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XProducto", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XClave", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtKardex.Rows)
                            {
                                if (!encabezado.Contains(fil["Almacen"].ToString()))
                                {
                                    encabezado += fil["Almacen"].ToString();
                                    almacen += fil["Almacen"].ToString() + ",";

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = fil["Almacen"].ToString();
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }

                                if (!clave.Contains(fil["Producto"].ToString()))
                                {
                                    clave += fil["Producto"].ToString();
                                    producto += fil["Nombre"].ToString() + ",";
                                }
                            }

                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XTotal", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XConsigna", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        string[] productosArreglo = producto.Split(',');
                        Array productosArray = productosArreglo;
                        Array.Sort(productosArray);

                        Array almacenArray = almacen.TrimEnd(',').Split(',');
                        int conteo = 0;

                        foreach (var productoF in productosArray)
                        {
                            if (conteo > 0)
                            {
                                long totalFila = 0;
                                long ConsignaFila = 0;
                                countRows++;

                                using (IXlRow row = sheet.CreateRow(countRows))
                                {
                                    //filaPorFila = productoF.ToString();

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = productoF.ToString();
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }

                                    DataRow[] claveProducto = dtKardex.Select("Nombre = '" + productoF + "'");

                                    if (claveProducto.Length > 0)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = claveProducto[0][1].ToString();
                                            cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                            cell.ApplyFormatting(cellFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }
                                    }

                                    foreach (var almacenF in almacenArray)
                                    {
                                        DataRow[] fila = dtKardex.Select("Almacen = '" + almacenF + "' and Nombre = '" + productoF + "'");

                                        if (fila.Length > 0)
                                        {
                                            sRegistro = fila[0][3].ToString();
                                            totalFila += long.Parse(fila[0][3].ToString());
                                            ConsignaFila += long.Parse(fila[0][4].ToString());
                                            //filaPorFila += 
                                        }
                                        else
                                        {
                                            sRegistro = "0";
                                        }

                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = sRegistro;
                                            cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                            cell.ApplyFormatting(cellFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = totalFila;
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = ConsignaFila;
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                            }
                            conteo = 1;
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