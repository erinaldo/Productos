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
using System.Drawing;
using Newtonsoft.Json;

namespace eRoute.Models.ReportesModels
{
    public class R270DescargasDIV
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string queryString;
        private string companyName;
        private string reportName;
        private string cedis;
        private string namecedis;
        private string routes;
        private string initialDate;
        private string finalDate;
        private string statusDate;
        private string language;
        private StringBuilder sConsulta = new StringBuilder();
        private DataTable dtDescargas;
        private DataTable dtDescargasResumen;

        RouteEntities db = new RouteEntities();

        public string getLanguage()
        {
            var language = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return language[0];
        }

        public bool GetReport(MemoryStream CompanyLogo, string CompanyName, string ReportName, string CEDIS, string NameCEDIS, string Routes, string StatusDate, string InitialDate, string FinalDate)
        {
            this.cedis = CEDIS;
            this.namecedis = NameCEDIS;
            this.routes = (!Routes.Equals("") ? Routes : "Todas las Rutas");

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R270Descargas_DIV]");
            sConsulta.AppendLine("@filterCedi = '" + this.cedis + "',");
            sConsulta.AppendLine("@filterRoutes = '" + Routes + "',");
            sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@filterDateEnd = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@numQuery = 0");

            queryString = sConsulta.ToString();
            Connection.Open();
            var queryDescargas = Connection.Query(queryString, null, null, true, 600).ToList();
            Connection.Close();

            if (queryDescargas.Count() > 0)
            {
                var jsonDescargas = JsonConvert.SerializeObject(queryDescargas);
                this.dtDescargas = (DataTable)JsonConvert.DeserializeObject(jsonDescargas, (typeof(DataTable)));
                this.companyName = CompanyName;
                this.reportName = ReportName;
                this.initialDate = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                this.finalDate = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : DateTime.Parse(InitialDate).ToString("dd/MM/yyyy"));
                this.statusDate = StatusDate;

                sConsulta.Clear();
                sConsulta.AppendLine("EXECUTE [DBO].[stpr_R270Descargas_DIV]");
                sConsulta.AppendLine("@filterCedi = '" + this.cedis + "',");
                sConsulta.AppendLine("@filterRoutes = '" + Routes + "',");
                sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
                sConsulta.AppendLine("@filterDateEnd = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "',");
                sConsulta.AppendLine("@numQuery = 1");

                queryString = sConsulta.ToString();
                Connection.Open();
                var queryDescargasResumen = Connection.Query(queryString, null, null, true, 600).ToList();
                Connection.Close();

                var jsonResumen = JsonConvert.SerializeObject(queryDescargasResumen);
                this.dtDescargasResumen = (DataTable)JsonConvert.DeserializeObject(jsonResumen, (typeof(DataTable)));

                ArchivoXlsModel file = GenerarExcel(CompanyLogo);
                DownloadFile.DownloadOpenXML(file);
                return true;
            }
            else
            {
                return false;
            }
        }
        private ArchivoXlsModel GenerarExcel(MemoryStream CompanyLogo)
        {
            IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xlsx);
            ArchivoXlsModel archivo;
            this.language = getLanguage();

            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.reportName.Split(' ')[0];

                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }

                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Arial";
                        cellFormatting.Font.Size = 9;

                        XlCellFormatting cellFormattingBold = new XlCellFormatting();
                        cellFormattingBold.CopyFrom(cellFormatting);
                        cellFormattingBold.Font.Bold = true;

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

                        XlFont Font = new XlFont();
                        Font.Bold = false;

                        using (IXlRow row = sheet.CreateRow(1))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 1, 0, 4));
                                using (IXlPicture picture = sheet.CreatePicture())
                                {
                                    picture.Image = Image.FromStream(CompanyLogo);
                                    picture.SetOneCellAnchor(new XlAnchorPoint(0, 1), 100, 100);
                                }
                            }

                            using (IXlCell cell = row.CreateCell(2))
                            {
                                cell.Value = this.companyName.ToUpper();
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(2, 1, 5, 1));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(2))
                            {
                                cell.Value = this.reportName.ToUpper();
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(2, 2, 5, 2));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(2))
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XCEDI", this.language) + ": " + this.namecedis;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(2, 3, 5, 3));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(2))
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XFechas", this.language) + ": " + (this.statusDate == "Entre" ? this.initialDate + " - " + this.finalDate : this.initialDate);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(2, 4, 5, 4));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(2))
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XRuta", this.language) + ": " + this.routes;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(2, 5, 5, 5));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        DataView view = new DataView(this.dtDescargas);
                        DataTable distinctFolio;
                        DataTable dtFinalFolio;
                        DataTable dtFinalProducts;
                        DataColumn columnAlias;

                        DataTable distinctDates = view.ToTable(true, "DiaClave");
                        DataTable distinctRoutes = view.ToTable(true, "RUTClave");
                        Array rutasArray = distinctRoutes.AsEnumerable().Select(r => r.Field<string>("RUTClave")).ToArray();
                        Array.Sort(rutasArray);

                        var dates = (from d in this.dtDescargas.AsEnumerable()
                                     select d["DiaClave"]).Distinct().ToList();

                        int countRows = 7;
                        string sRegistro = "";
                        string folioDescarga = "";
                        string fechaHoraMovimiento = "";
                        string producto = "";
                        string cantidad = "";
                        string descripcionProd = "";

                        folioDescarga = Mensaje.ObtenerDescripcion("XFolioDescarga", this.language);
                        fechaHoraMovimiento = Mensaje.ObtenerDescripcion("XFechaHoraMovimiento", this.language);
                        producto = Mensaje.ObtenerDescripcion("XProducto", this.language);
                        cantidad = Mensaje.ObtenerDescripcion("XCantidad", this.language);
                        descripcionProd = Mensaje.ObtenerDescripcion("XDescripcionProducto", this.language);

                        distinctFolio = view.ToTable(true, "RUTClave", "Folio", "DiaClave", "FechaHoraAlta");

                        foreach (var date in dates)
                        {
                            countRows++;
                            using (IXlRow row = sheet.CreateRow(countRows))
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = date.ToString();
                                    cell.ApplyFormatting(subHeaderRowFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }
                            }

                            var routes = (from r in dtDescargas.Select("DiaClave = '" + date + "'", "RUTClave")
                                          select r["RUTClave"]).Distinct().ToList();

                            foreach (var route in routes)
                            {
                                sRegistro = route.ToString();
                                countRows++;

                                var folios = (from f in dtDescargas.Select("DiaClave = '" + date + "' and RUTClave = '" + route + "'", "RUTClave")
                                              select f["Folio"]).Distinct().ToList();

                                using (IXlRow row = sheet.CreateRow(countRows))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sRegistro;
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }

                                    foreach (var folio in folios)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = folioDescarga;
                                            sheet.MergedCells.Add(XlCellRange.FromLTRB(cell.ColumnIndex, cell.RowIndex, cell.ColumnIndex + 1, cell.RowIndex));
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }

                                        using (IXlCell cell = row.CreateCell(sheet.CurrentColumnIndex + 1))
                                        {
                                            cell.Value = fechaHoraMovimiento;
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }
                                    }
                                }

                                DataRow[] dtfolio;
                                DataRow[] dtFolioAux;
                                DataRow[] dtProductoAux;

                                countRows++;
                                using (IXlRow row = sheet.CreateRow(countRows))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = "";
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }

                                    foreach (var folio in folios)
                                    {
                                        dtfolio = distinctFolio.Select("DiaClave = '" + date + "' and RUTClave = '" + route + "' and Folio = '" + folio + "'", "FechaHoraAlta");

                                        foreach (var item in dtfolio)
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = item["Folio"].ToString();
                                                sheet.MergedCells.Add(XlCellRange.FromLTRB(cell.ColumnIndex, cell.RowIndex, cell.ColumnIndex + 1, cell.RowIndex));
                                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                                                cell.ApplyFormatting(cellFormatting);
                                                cell.ApplyFormatting(XlBorder.NoBorders());
                                            }

                                            using (IXlCell cell = row.CreateCell(sheet.CurrentColumnIndex + 1))
                                            {
                                                cell.Value = item["FechaHoraAlta"].ToString();
                                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                                                cell.ApplyFormatting(cellFormatting);
                                                cell.ApplyFormatting(XlBorder.NoBorders());
                                            }
                                        }
                                    }
                                }

                                countRows++;
                                using (IXlRow row = sheet.CreateRow(countRows))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = "";
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }

                                    foreach (var folio in folios)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = producto;
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }

                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = descripcionProd;
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }

                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = cantidad;
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }
                                    }
                                }

                                int numProducts = 0;
                                dtFinalFolio = new DataTable();
                                dtFinalProducts = new DataTable();

                                foreach (var folio in folios)
                                {
                                    columnAlias = dtFinalFolio.Columns.Add(folio.ToString(), typeof(string));
                                    columnAlias = dtFinalFolio.Columns.Add(folio.ToString() + "_descripcion", typeof(string));
                                    columnAlias = dtFinalFolio.Columns.Add(folio.ToString() + "_cantidad", typeof(string));
                                }

                                dtFinalProducts = dtFinalFolio.Copy();

                                foreach (var folio in folios)
                                {
                                    dtProductoAux = dtDescargas.Select("DiaClave = '" + date + "' and RUTClave = '" + route + "' and Folio = '" + folio + "'", "ProductoClave");

                                    foreach (DataRow row in dtProductoAux)
                                    {
                                        DataRow drNewRow = dtFinalProducts.NewRow();
                                        drNewRow[folio.ToString()] = row["ProductoClave"].ToString();
                                        drNewRow[folio.ToString() + "_descripcion"] = row["Nombre"].ToString();
                                        drNewRow[folio.ToString() + "_cantidad"] = row["Cantidad"].ToString();
                                        dtFinalProducts.Rows.Add(drNewRow);
                                    }
                                }

                                DataTable dtFinalProductsAux = new DataTable();
                                dtFinalProductsAux = dtFinalFolio.Copy();

                                if (folios.Count() > 1)
                                {
                                    Array productosArray;
                                    Array productosDescArray;
                                    Array productosCantArray;
                                    List<string> proNombreString;
                                    List<string> proDescripcionString;
                                    List<string> proCantidadString;

                                    foreach (var folio in folios)
                                    {
                                        proNombreString = dtFinalProducts.AsEnumerable().Select(r => r.Field<string>(folio.ToString())).ToList();
                                        proNombreString.RemoveAll(p => string.IsNullOrEmpty(p));
                                        productosArray = proNombreString.ToArray();

                                        if (numProducts <= productosArray.Length)
                                        {
                                            numProducts = productosArray.Length;
                                        }
                                    }

                                    for (int i = 0; i < numProducts; i++)
                                    {
                                        DataRow row = dtFinalProductsAux.NewRow();
                                        dtFinalProductsAux.Rows.Add(row);
                                    }

                                    foreach (var folio in folios)
                                    {
                                        proNombreString = dtFinalProducts.AsEnumerable().Select(r => r.Field<string>(folio.ToString())).ToList();
                                        proNombreString.RemoveAll(p => string.IsNullOrEmpty(p));
                                        productosArray = proNombreString.ToArray();

                                        proDescripcionString = dtFinalProducts.AsEnumerable().Select(r => r.Field<string>(folio.ToString() + "_descripcion")).ToList();
                                        proDescripcionString.RemoveAll(p => string.IsNullOrEmpty(p));
                                        productosDescArray = proDescripcionString.ToArray();

                                        proCantidadString = dtFinalProducts.AsEnumerable().Select(r => r.Field<string>(folio.ToString() + "_cantidad")).ToList();
                                        proCantidadString.RemoveAll(p => string.IsNullOrEmpty(p));
                                        productosCantArray = proCantidadString.ToArray();

                                        for (int i = 0; i < productosArray.Length; i++)
                                        {
                                            dtFinalProductsAux.Rows[i][folio.ToString()] = productosArray.GetValue(i);
                                            dtFinalProductsAux.Rows[i][folio.ToString() + "_descripcion"] = productosDescArray.GetValue(i);
                                            dtFinalProductsAux.Rows[i][folio.ToString() + "_cantidad"] = productosCantArray.GetValue(i);
                                        }
                                    }
                                }

                                if (folios.Count() > 1)
                                {
                                    dtFolioAux = dtFinalProductsAux.Select();
                                }
                                else
                                {
                                    dtFolioAux = dtFinalProducts.Select();
                                }

                                foreach (DataRow fila in dtFolioAux)
                                {
                                    countRows++;
                                    using (IXlRow row = sheet.CreateRow(countRows))
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "";
                                            cell.ApplyFormatting(cellFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }

                                        foreach (DataColumn cols in dtFinalProducts.Columns)
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = fila[cols.ColumnName].ToString();
                                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                                                cell.ApplyFormatting(cellFormatting);
                                                cell.ApplyFormatting(XlBorder.NoBorders());
                                            }
                                        }
                                    }
                                }

                                countRows++;
                            }
                        }

                        countRows++;
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XRESUMEN", this.language).ToUpper();
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                        }

                        countRows++;
                        foreach (var route in rutasArray)
                        {
                            using (IXlRow row = sheet.CreateRow(countRows))
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = route.ToString();
                                    cell.ApplyFormatting(subHeaderRowFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = producto;
                                    cell.ApplyFormatting(subHeaderRowFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = descripcionProd;
                                    cell.ApplyFormatting(subHeaderRowFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = cantidad;
                                    cell.ApplyFormatting(subHeaderRowFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }
                            }

                            DataTable dtProductos = view.ToTable(true, "ProductoClave");
                            Array productoArray = dtProductos.AsEnumerable().Select(r => r.Field<string>("ProductoClave")).ToArray();
                            Array.Sort(productoArray);

                            DataRow[] dtfolios;
                            DataRow[] drProductos;
                            dtfolios = dtDescargasResumen.Select("RUTClave = '" + route + "'", "ProductoClave");

                            countRows++;
                            foreach (DataRow rows in dtfolios)
                            {
                                using (IXlRow row = sheet.CreateRow(countRows++))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = "";
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = rows["ProductoClave"].ToString();
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = rows["Nombre"].ToString();
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = rows["Cantidad"].ToString();
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                            }
                            countRows++;
                        }

                        XlCellFormatting totalRowFormatting = new XlCellFormatting();
                        totalRowFormatting.CopyFrom(cellFormatting);
                        totalRowFormatting.Font.Bold = true;
                        totalRowFormatting.Fill = XlFill.SolidFill(XlColor.FromTheme(XlThemeColor.Accent5, 0.6));
                    }
                }
                archivo = new ArchivoXlsModel();
                archivo.archivo = stream.ToArray();
                archivo.nombre = this.reportName.Replace(" ", "") + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            }
            return archivo;
        }
    }
}