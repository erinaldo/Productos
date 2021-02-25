using Dapper;
using DevExpress.Export.Xl;
using System;
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
    public class R234ResumenDevolucionClienteLEO
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string queryString;
        private string companyName;
        private string reportName;
        private string cedis;
        private string namecedis;
        private string seller;
        private string nameSeller;
        private string routes;
        private string scheme;
        private string nameScheme;
        private string initialDate;
        private string finalDate;
        private string statusDate;
        private string language;
        private StringBuilder sConsulta = new StringBuilder();
        private DataTable dtRouteSeller;
        private DataTable dtProducts;
        private DataTable dtPriceList;

        RouteEntities db = new RouteEntities();

        public string getLanguage()
        {
            var language = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return language[0];
        }

        public bool GetReport(MemoryStream CompanyLogo, string companyName, string reportName, string CEDIS, string nameCEDIS, string statusDate, string initialDate, string finalDate, string routes, string seller, string customerSchemes)
        {
            var namSeller = "";
            string[] sellerArray = seller.Split(',');

            if (!seller.Equals("") && sellerArray.Length == 1)
            {
                var sel = (from V in db.Vendedor
                           join U in db.Usuario on V.USUId equals U.USUId
                           where V.VendedorID == seller
                           select V.Nombre).Take(1).ToList();
                namSeller = sel[0].ToString();
            }

            var namScheme = "";
            string[] schemeArray = customerSchemes.Split(',');

            if (!customerSchemes.Equals("") && schemeArray.Length == 1)
            {
                var sche = (from E in db.Esquema
                            where E.EsquemaID == customerSchemes
                            select E.Nombre).Take(1).ToList();
                namScheme = sche[0].ToString();
            }

            this.cedis = CEDIS;
            this.namecedis = nameCEDIS;
            this.routes = routes;
            this.seller = seller;
            this.nameSeller = namSeller;
            this.scheme = customerSchemes;
            this.nameScheme = namScheme;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R234ResumenDevolucionCliente_LEO]");
            sConsulta.AppendLine("@filterCedi = '" + this.cedis + "',");
            sConsulta.AppendLine("@filterSeller = '" + this.seller + "',");
            sConsulta.AppendLine("@filterRoutes = '" + this.routes + "',");
            sConsulta.AppendLine("@filterCustomerScheme = '" + this.scheme + "',");
            sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(initialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@filterDateEnd = '" + (statusDate == "Entre" ? DateTime.Parse(finalDate).ToString("yyyyMMdd") : DateTime.Parse(initialDate).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@numQuery = 0 ");

            queryString = sConsulta.ToString();
            Connection.Open();
            var querySellers = Connection.Query(queryString, null, null, true, 600).ToList();
            Connection.Close();

            if (querySellers.Count() > 0)
            {
                var jsonSellers = JsonConvert.SerializeObject(querySellers);
                this.dtRouteSeller = (DataTable)JsonConvert.DeserializeObject(jsonSellers, (typeof(DataTable)));

                if (initialDate != null)
                {
                    this.initialDate = DateTime.Parse(initialDate).ToString("dd/MM/yyyy");
                    this.finalDate = (statusDate == "Entre" ? DateTime.Parse(finalDate).ToString("dd/MM/yyyy") : initialDate);
                    this.statusDate = statusDate;

                    sConsulta.Clear();
                    sConsulta.AppendLine("EXECUTE [DBO].[stpr_R234ResumenDevolucionCliente_LEO]");
                    sConsulta.AppendLine("@filterCedi = '" + this.cedis + "',");
                    sConsulta.AppendLine("@filterSeller = '" + this.seller + "',");
                    sConsulta.AppendLine("@filterRoutes = '" + this.routes + "',");
                    sConsulta.AppendLine("@filterCustomerScheme = '" + this.scheme + "',");
                    sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(initialDate).ToString("yyyyMMdd") + "',");
                    sConsulta.AppendLine("@filterDateEnd = '" + (statusDate == "Entre" ? DateTime.Parse(finalDate).ToString("yyyyMMdd") : DateTime.Parse(initialDate).ToString("yyyyMMdd")) + "',");
                    sConsulta.AppendLine("@numQuery = 1");

                    queryString = sConsulta.ToString();
                    Connection.Open();
                    var queryProducts = Connection.Query(queryString, null, null, true, 600).ToList();
                    Connection.Close();

                    var jsonProducts = JsonConvert.SerializeObject(queryProducts);
                    this.dtProducts = (DataTable)JsonConvert.DeserializeObject(jsonProducts, (typeof(DataTable)));

                    sConsulta.Clear();
                    sConsulta.AppendLine("EXECUTE [DBO].[stpr_R234ResumenDevolucionCliente_LEO]");
                    sConsulta.AppendLine("@filterCedi = '" + this.cedis + "',");
                    sConsulta.AppendLine("@filterSeller = '" + this.seller + "',");
                    sConsulta.AppendLine("@filterRoutes = '" + this.routes + "',");
                    sConsulta.AppendLine("@filterCustomerScheme = '" + this.scheme + "',");
                    sConsulta.AppendLine("@filterDateIni = '" + DateTime.Parse(initialDate).ToString("yyyyMMdd") + "',");
                    sConsulta.AppendLine("@filterDateEnd = '" + (statusDate == "Entre" ? DateTime.Parse(finalDate).ToString("yyyyMMdd") : DateTime.Parse(initialDate).ToString("yyyyMMdd")) + "',");
                    sConsulta.AppendLine("@numQuery = 2");

                    queryString = sConsulta.ToString();
                    Connection.Open();
                    var queryPriceList = Connection.Query(queryString, null, null, true, 600).ToList();
                    Connection.Close();

                    var jsonPriceList = JsonConvert.SerializeObject(queryPriceList);
                    this.dtPriceList = (DataTable)JsonConvert.DeserializeObject(jsonPriceList, (typeof(DataTable)));
                }

                this.companyName = companyName;
                this.reportName = reportName;

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

            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("CEDI", typeof(string));
            dtFinal.Columns.Add("Ruta", typeof(string));
            dtFinal.Columns.Add("Vendedor", typeof(string));
            dtFinal.Columns.Add("ClienteClave", typeof(string));
            dtFinal.Columns.Add("CLIClave", typeof(string));
            dtFinal.Columns.Add("CLINombre", typeof(string));

            string sCol;
            Object nTotalVta;
            DataRow[] filas;
            DataColumn columnAlias;

            //PRODUCTOS
            sCol = "";
            filas = dtProducts.Select("Contenido = 0", "ProductoClave");
            foreach (DataRow row in filas)
            {
                if (row["ProductoClave"].ToString() != sCol)
                {
                    columnAlias = dtFinal.Columns.Add("Nom_" + row["ProductoClave"].ToString(), typeof(double));
                    columnAlias.Caption = "'" + row["Nombre"].ToString();
                    sCol = row["ProductoClave"].ToString();
                }
            }

            //CONTENIDOS
            sCol = "";
            filas = dtProducts.Select("Contenido = 1", "ProductoClave");
            string envase = Mensaje.ObtenerDescripcion("VRVEnvase", this.language);
            foreach (DataRow row in filas)
            {
                if (row["ProductoClave"].ToString() != sCol)
                {
                    columnAlias = dtFinal.Columns.Add("NomCont_" + row["ProductoClave"].ToString(), typeof(double));
                    columnAlias.Caption = "'" + envase + " " + row["Nombre"].ToString();
                    sCol = row["ProductoClave"].ToString();
                }
            }

            //TOTALES
            dtFinal.Columns.Add("DevolucionLiquido", typeof(double));
            dtFinal.Columns.Add("DevolucionEnvase", typeof(double));
            dtFinal.Columns.Add("Importe", typeof(double));
            dtFinal.Columns.Add("ListaPrecios", typeof(string));

            //AGREGAR REGISTROS
            filas = this.dtRouteSeller.Select();
            foreach (var fil in filas)
            {
                DataRow drNueva = dtFinal.NewRow();
                drNueva["CEDI"] = fil["ClaveCEDI"].ToString();
                drNueva["Ruta"] = fil["RUTClave"].ToString();
                drNueva["Vendedor"] = fil["VendedorId"].ToString();
                drNueva["ClienteClave"] = fil["ClienteClave"].ToString();
                drNueva["CLIClave"] = fil["CLIClave"].ToString();
                drNueva["CLINombre"] = fil["CLINombre"].ToString();

                foreach (DataColumn col in dtFinal.Columns)
                {
                    if (col.ColumnName != "CEDI" && col.ColumnName != "Ruta" && col.ColumnName != "Vendedor" && col.ColumnName != "ClienteClave" && col.ColumnName != "CLIClave" && col.ColumnName != "CLINombre")
                    {
                        drNueva[col.ColumnName] = 0;
                    }
                }

                //PRODUCTOS
                filas = dtProducts.Select("Contenido = 0 and ClaveCEDI = '" + fil["ClaveCEDI"].ToString() + "' and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'", "ProductoClave");
                foreach (DataRow row in filas)
                {
                    drNueva["Nom_" + row["ProductoClave"].ToString()] = row["Cantidad"].ToString();
                }

                //CONTENIDOS
                filas = dtProducts.Select("Contenido = 1 and ClaveCEDI = '" + fil["ClaveCEDI"].ToString() + "' and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'", "ProductoClave");
                foreach (DataRow row in filas)
                {
                    drNueva["NomCont_" + row["ProductoClave"].ToString()] = row["Cantidad"].ToString();
                }

                //DEVOLUCION LIQUIDO
                nTotalVta = dtProducts.Compute("sum(Cantidad)", "Contenido = 0 and ClaveCEDI = '" + fil["ClaveCEDI"].ToString() + "' and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                if (String.IsNullOrEmpty(nTotalVta.ToString()))
                {
                    nTotalVta = 0;
                }
                drNueva["DevolucionLiquido"] = nTotalVta;

                //DEVOLUCION ENVASE
                nTotalVta = dtProducts.Compute("sum(Cantidad)", "Contenido = 1 and ClaveCEDI = '" + fil["ClaveCEDI"].ToString() + "' and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                if (String.IsNullOrEmpty(nTotalVta.ToString()))
                {
                    nTotalVta = 0;
                }
                drNueva["DevolucionEnvase"] = nTotalVta;

                //IMPORTE
                nTotalVta = dtProducts.Compute("sum(Importe)", "ClaveCEDI = '" + fil["ClaveCEDI"].ToString() + "' and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                if (String.IsNullOrEmpty(nTotalVta.ToString()))
                {
                    nTotalVta = 0;
                }
                drNueva["Importe"] = nTotalVta;

                //LISTA PRECIOS
                string sPrecios = "";
                if (this.dtPriceList.Rows.Count > 0)
                {
                    filas = this.dtPriceList.Select("ClaveCEDI = '" + fil["ClaveCEDI"].ToString() + "' and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                    foreach (DataRow row in filas)
                    {
                        sPrecios = row["PCEPrecioClave"].ToString() + ", ";
                    }
                    if (sPrecios.Length > 0)
                    {
                        sPrecios = sPrecios.Remove(sPrecios.Length - 2, 2);
                    }
                    drNueva["ListaPrecios"] = sPrecios;
                }
                dtFinal.Rows.Add(drNueva);
            }

            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.reportName.Split(' ')[0];

                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 120; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 250; }

                        for (int i = 0; i < dtFinal.Columns.Count; i++)
                        {
                            using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        }

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

                        using (IXlRow row = sheet.CreateRow(1))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 1, 0, 5));
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
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XCEDI", this.language) + ": " + this.namecedis;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(1, 3, 5, 3));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XFecha", this.language) + ": " + (this.statusDate == "Entre" ? this.initialDate + " - " + this.finalDate : this.initialDate);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(1, 4, 5, 4));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XVendedor", this.language) + ": " + this.nameSeller;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(1, 5, 5, 5));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XRuta", this.language) + ": " + this.routes;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(1, 6, 8, 6));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XCategoriaCliente", this.language) + ": " + this.nameScheme;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(1, 7, 5, 7));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        int countRows = 10;
                        string sRegistro = "";

                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            foreach (DataColumn col in dtFinal.Columns)
                            {
                                if (col.ColumnName != "CEDI" && col.ColumnName != "Ruta" && col.ColumnName != "Vendedor" && col.ColumnName != "ClienteClave")
                                {
                                    if (col.ColumnName.StartsWith("Nom_") ^ col.ColumnName.StartsWith("NomCont_"))
                                    {
                                        sRegistro = col.Caption;
                                    }
                                    else
                                    {
                                        sRegistro = Mensaje.ObtenerDescripcion("RDC" + col.ColumnName, this.language);
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sRegistro;
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                            }
                        }

                        Object nTotal;
                        string sTotales;
                        var cedis = (from c in this.dtRouteSeller.AsEnumerable()
                                     select c["ClaveCEDI"]).Distinct().ToList();

                        var routes = (from r in this.dtRouteSeller.AsEnumerable()
                                      select r["RUTClave"]).Distinct().ToList();

                        var sellers = (from s in this.dtRouteSeller.AsEnumerable()
                                       select s["VendedorID"]).Distinct().ToList();

                        countRows += 2;
                        foreach (var cedi in cedis)
                        {
                            filas = this.dtRouteSeller.Select("ClaveCEDI = '" + cedi + "'");
                            sRegistro = Mensaje.ObtenerDescripcion("Xcentrodistribucion", this.language) + ": " + filas[0]["ClaveCEDI"].ToString() + " " + filas[0]["ALMNombre"].ToString();
                            using (IXlRow row = sheet.CreateRow(countRows++))
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = sRegistro;
                                    cell.ApplyFormatting(subHeaderRowFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }
                            }
                            foreach (var route in routes)
                            {
                                filas = this.dtRouteSeller.Select("ClaveCEDI = '" + cedi + "' and RUTClave = '" + route + "'");
                                sRegistro = Mensaje.ObtenerDescripcion("XRuta", this.language) + ": " + filas[0]["RUTClave"].ToString();
                                using (IXlRow row = sheet.CreateRow(countRows++))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sRegistro;
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }

                                foreach (var seller in sellers)
                                {
                                    filas = this.dtRouteSeller.Select("ClaveCEDI = '" + cedi + "' and RUTClave = '" + route + "' and VendedorID = '" + seller + "'");
                                    if (filas.Count() > 0)
                                    {
                                        sRegistro = Mensaje.ObtenerDescripcion("XVendedor", this.language) + ": " + filas[0]["VENNombre"].ToString();
                                        using (IXlRow row = sheet.CreateRow(countRows++))
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = sRegistro;
                                                cell.ApplyFormatting(subHeaderRowFormatting);
                                                cell.ApplyFormatting(XlBorder.NoBorders());
                                            }
                                        }
                                        filas = dtFinal.Select("CEDI = '" + cedi + "' and Ruta = '" + route + "' and Vendedor = '" + seller + "'");
                                        if (filas.Count() > 0)
                                        {
                                            foreach (DataRow rows in filas)
                                            {
                                                sRegistro = "";
                                                using (IXlRow row = sheet.CreateRow(countRows++))
                                                {
                                                    foreach (DataColumn cols in dtFinal.Columns)
                                                    {
                                                        if (cols.ColumnName != "CEDI" && cols.ColumnName != "Ruta" && cols.ColumnName != "Vendedor" && cols.ColumnName != "ClienteClave")
                                                        {
                                                            sRegistro = rows[cols.ColumnName].ToString();
                                                            using (IXlCell cell = row.CreateCell())
                                                            {
                                                                cell.Value = sRegistro;
                                                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                                                if (cols.ColumnName == "CLIClave" ^ cols.ColumnName == "CLINombre")
                                                                {
                                                                    cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                                                }
                                                                cell.ApplyFormatting(cellFormatting);
                                                                cell.ApplyFormatting(XlBorder.NoBorders());
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            //totalVendedor
                                            using (IXlRow row = sheet.CreateRow(countRows++))
                                            {
                                                using (IXlCell cell = row.CreateCell())
                                                {
                                                    sRegistro = Mensaje.ObtenerDescripcion("XTotalPorVendedor", this.language);
                                                    cell.Value = sRegistro;
                                                    cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                                    cell.ApplyFormatting(cellFormatting);
                                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                                }
                                                using (IXlCell cell = row.CreateCell())
                                                {
                                                    sRegistro = "";
                                                    cell.Value = sRegistro;
                                                    cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                                    cell.ApplyFormatting(cellFormatting);
                                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                                }
                                                foreach (DataColumn cols in dtFinal.Columns)
                                                {
                                                    if (cols.DataType.ToString() != "System.String")
                                                    {
                                                        nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "CEDI = '" + cedi + "' and Ruta = '" + route + "' and Vendedor = '" + seller + "'");
                                                        sTotales = nTotal.ToString();
                                                        using (IXlCell cell = row.CreateCell())
                                                        {
                                                            cell.Value = sTotales;
                                                            cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                                            cell.ApplyFormatting(cellFormatting);
                                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                //totalRuta
                                using (IXlRow row = sheet.CreateRow(countRows++))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        sRegistro = Mensaje.ObtenerDescripcion("XTotalPorRuta", this.language);
                                        cell.Value = sRegistro;
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        sRegistro = "";
                                        cell.Value = sRegistro;
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                    foreach (DataColumn cols in dtFinal.Columns)
                                    {
                                        if (cols.DataType.ToString() != "System.String")
                                        {
                                            nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "CEDI = '" + cedi + "' and Ruta = '" + route + "'");
                                            sTotales = nTotal.ToString();
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = sTotales;
                                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                                cell.ApplyFormatting(cellFormatting);
                                                cell.ApplyFormatting(XlBorder.NoBorders());
                                            }
                                        }
                                    }
                                }
                                countRows++;
                            }
                            //totalCedi
                            --countRows;
                            using (IXlRow row = sheet.CreateRow(countRows++))
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    sRegistro = Mensaje.ObtenerDescripcion("XTotalPorCEDI", this.language);
                                    cell.Value = sRegistro;
                                    cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    sRegistro = "";
                                    cell.Value = sRegistro;
                                    cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                }
                                foreach (DataColumn cols in dtFinal.Columns)
                                {
                                    if (cols.DataType.ToString() != "System.String")
                                    {
                                        nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "CEDI = '" + cedi + "'");
                                        sTotales = nTotal.ToString();
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = sTotales;
                                            cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                            cell.ApplyFormatting(cellFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }
                                    }
                                }
                            }
                        }

                        using (IXlRow row = sheet.CreateRow(countRows++))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XGRANTOTAL", this.language);
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = "";
                                cell.Value = sRegistro;
                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                            }
                            foreach (DataColumn cols in dtFinal.Columns)
                            {
                                if (cols.DataType.ToString() != "System.String")
                                {
                                    nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "");
                                    sTotales = nTotal.ToString();
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sTotales;
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
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
                archivo.nombre = this.reportName.Replace(" ", "") + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            }
            return archivo;
        }
    }
}