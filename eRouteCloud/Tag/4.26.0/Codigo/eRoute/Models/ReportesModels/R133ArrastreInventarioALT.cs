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
    public class R133ArrastreInventarioALT
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string nombreEmpresa;
        private string nombreReporte;
        private string CEDIS;
        private string NameCEDIS;
        private string FechaInicial;
        private string FechaFinal;
        private string StatusDate;
        private bool TypeProduct;
        private string Lenguaje;
        private StringBuilder sConsulta = new StringBuilder();
        private DataTable dtArrastreInventario;

        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public bool GetReport(string ReportName, string CompanyName, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string FinalDate, bool ReportType)
        {
            this.CEDIS = CEDIS;
            this.NameCEDIS = NameCEDIS;
            this.TypeProduct = ReportType;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R133ArrastreInventario_ALT]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@Producto = " + (ReportType ? 1 : 0) + ",");
            sConsulta.AppendLine("@Envase = " + (!ReportType ? 1 : 0));

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryList = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (queryList.Count() > 0)
            {
                var jsonArrastre = JsonConvert.SerializeObject(queryList);
                this.dtArrastreInventario = (DataTable)JsonConvert.DeserializeObject(jsonArrastre, (typeof(DataTable)));

                if (InitialDate != null)
                {
                    this.FechaInicial = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                    this.FechaFinal = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : this.FechaInicial);
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

                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 120; }
                        //using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }

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
                                cell.Value = Mensaje.ObtenerDescripcion("Xcentrodistribucion", this.Lenguaje) + ": " + this.NameCEDIS;
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
                                cell.Value = Mensaje.ObtenerDescripcion("XFecha", this.Lenguaje) + "(s): " + (this.StatusDate == "Entre" ? this.FechaInicial + " Al " + this.FechaFinal : this.FechaInicial);
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
                                cell.Value = Mensaje.ObtenerDescripcion("XTipoProducto", this.Lenguaje) + ": " + (this.TypeProduct ? Mensaje.ObtenerDescripcion("XProducto", this.Lenguaje) : Mensaje.ObtenerDescripcion("XEnvase", this.Lenguaje));
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                cell.ApplyFormatting(Font);
                            }
                        }

                        string sCol = "";
                        DataColumn columnAlias;
                        int TotalColumnas = 0;

                        foreach (DataRow row in dtArrastreInventario.Rows)
                        {
                            TotalColumnas += 1;
                        }
                        TotalColumnas += 1;

                        int countRows = 8;
                        string sRegistro = "";

                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        // Nombre de los Encabezados.
                        countRows++;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["ProductoClave"].ToString();
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
                                sRegistro = Mensaje.ObtenerDescripcion("XTotalesm", this.Lenguaje);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows++;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows += 2;
                        //Inv Físico
                        double TotalInvFisico = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XInvFisico", this.Lenguaje);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["InvFisico"].ToString();
                                TotalInvFisico += Double.Parse(fil["InvFisico"].ToString());
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
                                sRegistro = TotalInvFisico.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Consignas
                        countRows++;
                        double TotalConsignas = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XConsignas", this.Lenguaje);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Consignas"].ToString();
                                TotalConsignas += Double.Parse(fil["Consignas"].ToString());
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
                                sRegistro = TotalConsignas.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Cargas
                        countRows++;
                        double TotalCargas = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XCargas", this.Lenguaje);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Cargas"].ToString();
                                TotalCargas += Double.Parse(fil["Cargas"].ToString());
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
                                sRegistro = TotalCargas.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Consumos
                        countRows++;
                        double TotalConsumos = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XConsumos", this.Lenguaje);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Consumos"].ToString();
                                TotalConsumos += Double.Parse(fil["Consumos"].ToString());
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
                                sRegistro = TotalConsumos.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows += 2;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //TotalGrupo1
                        countRows++;
                        double TotalGrupo1 = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "";
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["TotalGrupo1"].ToString();
                                TotalGrupo1 += Double.Parse(fil["TotalGrupo1"].ToString());
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
                                sRegistro = TotalGrupo1.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Compras
                        countRows += 2;
                        double TotalCompras = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XCompras", this.Lenguaje);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Compras"].ToString();
                                TotalCompras += Double.Parse(fil["Compras"].ToString());
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
                                sRegistro = TotalCompras.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows += 2;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "------------------------------";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Suma
                        countRows++;
                        double TotalSuma = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XSuma", this.Lenguaje).ToUpper();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Suma"].ToString();
                                TotalSuma += Double.Parse(fil["Suma"].ToString());
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = sRegistro;
                                    cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                    //cellFormatting.Border = new XlBorder();
                                    //cellFormatting.Border.TopLineStyle = XlBorderLineStyle.Medium;
                                    //cellFormatting.Border.BottomLineStyle = XlBorderLineStyle.Medium;
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = TotalSuma.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows++;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "------------------------------";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Tepatitlan
                        countRows += 2;
                        double TotalTepatitlan = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = "TEPATITLAN";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Tepatitlan"].ToString();
                                TotalTepatitlan += Double.Parse(fil["Tepatitlan"].ToString());
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
                                sRegistro = TotalTepatitlan.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Atotonilco
                        countRows++;
                        double TotalAtotonilco = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = "ATOTONILCO";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Atotonilco"].ToString();
                                TotalAtotonilco += Double.Parse(fil["Atotonilco"].ToString());
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
                                sRegistro = TotalAtotonilco.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Arandas
                        countRows++;
                        double TotalArandas = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = "ARANDAS";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Arandas"].ToString();
                                TotalArandas += Double.Parse(fil["Arandas"].ToString());
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
                                sRegistro = TotalArandas.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Yahualica
                        countRows++;
                        double TotalYahualica = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = "YAHUALICA";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Yahualica"].ToString();
                                TotalYahualica += Double.Parse(fil["Yahualica"].ToString());
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
                                sRegistro = TotalYahualica.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows += 2;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //TotalGrupo2
                        countRows++;
                        double TotalGrupo2 = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "";
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["TotalGrupo2"].ToString();
                                TotalGrupo2 += Double.Parse(fil["TotalGrupo2"].ToString());
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
                                sRegistro = TotalGrupo2.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows += 2;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "------------------------------";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Subtotal
                        countRows++;
                        double TotalSubTotal = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XSubtotal", this.Lenguaje).ToUpper();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["SubTotal"].ToString();
                                TotalSubTotal += Double.Parse(fil["SubTotal"].ToString());
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
                                sRegistro = TotalSubTotal.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows++;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "------------------------------";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Ventas
                        countRows += 2;
                        double TotalVentas = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XVentas", this.Lenguaje);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Ventas"].ToString();
                                TotalVentas += Double.Parse(fil["Ventas"].ToString());
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
                                sRegistro = TotalVentas.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Terminados
                        countRows++;
                        double TotalTerminados = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XTerminados", this.Lenguaje);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Terminado"].ToString();
                                TotalTerminados += Double.Parse(fil["Terminado"].ToString());
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
                                sRegistro = TotalTerminados.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows += 2;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "------------------------------";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        //Total
                        countRows++;
                        double TotalTotal = 0;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XTotal", this.Lenguaje).ToUpper();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }

                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = fil["Total"].ToString();
                                TotalTotal += Double.Parse(fil["Total"].ToString());
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
                                sRegistro = TotalTotal.ToString();
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows++;
                        sRegistro = "";
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "------------------------------";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataRow fil in dtArrastreInventario.Rows)
                            {
                                sRegistro = "------------------------------";
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
                                sRegistro = "------------------------------";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
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