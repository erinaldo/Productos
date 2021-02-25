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
    public class R087VentaPorClienteALT
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string nombreEmpresa;
        private string nombreReporte;
        private string CEDIS;
        private string NameCEDIS;
        private string Vendedor;
        private string VendedorNombre;
        private string Rutas;
        private string EsquemaClientes;
        private string esquemaNombre;
        private string Clientes;
        private string FechaInicial;
        private string FechaFinal;
        private string StatusDate;
        private string Lenguaje;
        private StringBuilder sConsulta = new StringBuilder();
        private DataTable dtMovimientos;

        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public bool GetReport(string ReportName, string CompanyName, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string FinalDate, string Routes, string Sellers, string CustomerSchemes, string Customers)
        {
            var NomVendedores = "";
            var NomEsquema = "";
            string[] SellersArrays = Sellers.Split(',');

            if (!Sellers.Equals("") && SellersArrays.Length == 1)
            {
                var Vendedor = (from V in db.Vendedor
                                join U in db.Usuario on V.USUId equals U.USUId
                                where V.VendedorID == Sellers
                                select V.Nombre).Take(1).ToList();

                NomVendedores = Vendedor[0].ToString();
            }

            string[] CustomerSchemesArrays = CustomerSchemes.Split(',');

            if (!CustomerSchemes.Equals("") && CustomerSchemesArrays.Length == 1)
            {
                var esquema = (from E in db.Esquema
                               where E.EsquemaID == CustomerSchemes
                               select E.Nombre).Take(1).ToList();

                NomEsquema = esquema[0].ToString();
            }

            this.CEDIS = CEDIS;
            this.NameCEDIS = NameCEDIS;
            this.StatusDate = StatusDate;
            this.FechaInicial = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
            this.FechaFinal = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : this.FechaInicial);
            this.Vendedor = (Sellers == "" ? null : Sellers);
            this.VendedorNombre = NomVendedores;
            this.Rutas = (Routes == "" ? null : Routes);
            this.EsquemaClientes = (CustomerSchemes == "" ? null : CustomerSchemes);
            this.esquemaNombre = NomEsquema;
            this.Clientes = (Customers == "" ? null : Customers);

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R087VentaPorCliente_ALT]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.EsquemaClientes + "',");
            sConsulta.AppendLine("@FILTROCLIENTES = '" + this.Clientes + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 0 ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryMovimientos = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();

            if (queryMovimientos.Count() > 0)
            {
                var jsonMovimientos = JsonConvert.SerializeObject(queryMovimientos);
                this.dtMovimientos = (DataTable)JsonConvert.DeserializeObject(jsonMovimientos, (typeof(DataTable)));
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
            DataTable dtProductos;
            DataTable dtTotales;
            DataTable dtCobranza;
            Object nTotalVta;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R087VentaPorCliente_ALT]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.EsquemaClientes + "',");
            sConsulta.AppendLine("@FILTROCLIENTES = '" + this.Clientes + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 1 ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryProductos = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonProductos = JsonConvert.SerializeObject(queryProductos);
            dtProductos = (DataTable)JsonConvert.DeserializeObject(jsonProductos, (typeof(DataTable)));

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R087VentaPorCliente_ALT]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.EsquemaClientes + "',");
            sConsulta.AppendLine("@FILTROCLIENTES = '" + this.Clientes + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 2 ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryTotales = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonTotales = JsonConvert.SerializeObject(queryTotales);
            dtTotales = (DataTable)JsonConvert.DeserializeObject(jsonTotales, (typeof(DataTable)));

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R087VentaPorCliente_ALT]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.EsquemaClientes + "',");
            sConsulta.AppendLine("@FILTROCLIENTES = '" + this.Clientes + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 3 ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryCobranza = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonCobranza = JsonConvert.SerializeObject(queryCobranza);
            dtCobranza = (DataTable)JsonConvert.DeserializeObject(jsonCobranza, (typeof(DataTable)));

            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("ALMClave", typeof(string));
            dtFinal.Columns.Add("RUTClave", typeof(string));
            dtFinal.Columns.Add("ClienteClave", typeof(string));
            dtFinal.Columns.Add("TransProdId", typeof(string));
            dtFinal.Columns.Add("Fecha", typeof(string));
            dtFinal.Columns.Add("Folio", typeof(string));

            //PRODUCTOS
            DataRow[] filas = dtProductos.Select("Contenido = 0", "ProductoClave");
            string sCol = "";
            DataColumn columnAlias;

            foreach (DataRow row in filas)
            {
                if (row["ProductoClave"].ToString() != sCol)
                {
                    columnAlias = dtFinal.Columns.Add("Nom_" + row["ProductoClave"].ToString(), typeof(Int64));
                    columnAlias.Caption = "'" + row["Nombre"].ToString();
                    sCol = row["ProductoClave"].ToString();
                }
            }

            //CONTENIDOS
            filas = dtProductos.Select("Contenido = 1", "ProductoClave");
            sCol = "";

            foreach (DataRow row in filas)
            {
                if (row["ProductoClave"].ToString() != sCol)
                {
                    columnAlias = dtFinal.Columns.Add("NomCont_" + row["ProductoClave"].ToString(), typeof(Int64));
                    columnAlias.Caption = "'" + row["Nombre"].ToString();
                    sCol = row["ProductoClave"].ToString();
                }
            }

            //RETORNABLE Y NO RETORNABLE
            dtFinal.Columns.Add("Retornable", typeof(Int64));
            dtFinal.Columns.Add("NoRetornable", typeof(Int64));
            //Resumen ventas y devoluciones
            dtFinal.Columns.Add("VentaLiquido", typeof(Int64));
            dtFinal.Columns.Add("DevolucionEnvase", typeof(Int64));
            dtFinal.Columns.Add("VentaEnvase", typeof(Int64));
            //Totales
            dtFinal.Columns.Add("ImporteVenta", typeof(double));
            dtFinal.Columns.Add("ImporteDescuento", typeof(double));
            dtFinal.Columns.Add("PorcDescuento", typeof(double));
            dtFinal.Columns.Add("SubTotal", typeof(double));
            dtFinal.Columns.Add("Credito", typeof(double));
            //Cobranza
            dtFinal.Columns.Add("AbonoCredito", typeof(double));
            dtFinal.Columns.Add("TotalCobrado", typeof(double));

            //AGREGAR REGISTROS
            //int dtFinalCount = 0;
            filas = this.dtMovimientos.Select();
            foreach (DataRow fil in filas)
            {
                DataRow drNueva = dtFinal.NewRow();
                drNueva["ALMClave"] = fil["ClaveCEDI"].ToString();
                drNueva["RUTClave"] = fil["RUTClave"].ToString();
                drNueva["ClienteClave"] = fil["ClienteClave"].ToString();
                drNueva["TransProdId"] = fil["TransProdId"].ToString();
                drNueva["Fecha"] = fil["Fecha"].ToString();
                drNueva["Folio"] = fil["Folio"].ToString();

                foreach (DataColumn col in dtFinal.Columns)
                {
                    if (col.DataType.ToString() != "System.String")
                    {
                        drNueva[col.ColumnName] = 0;
                    }

                }

                //PRODUCTOS
                filas = dtProductos.Select("Contenido = 0 and TransProdId = '" + fil["TransProdId"].ToString() + "'", "ProductoClave");
                foreach (DataRow row in filas)
                {
                    drNueva["Nom_" + row["ProductoClave"].ToString()] = row["Cantidad"].ToString();
                }

                //CONTENIDOS
                filas = dtProductos.Select("Contenido = 1 and TransProdId = '" + fil["TransProdId"].ToString() + "'", "ProductoClave");
                foreach (DataRow row in filas)
                {
                    drNueva["NomCont_" + row["ProductoClave"].ToString()] = row["Cantidad"].ToString();
                }

                //RETORNABLE Y NO RETORNABLE
                nTotalVta = dtProductos.Compute("sum(Cantidad)", "Contenido = 0 and Retornable = 1 and TransProdId = '" + fil["TransProdId"].ToString() + "'");
                if (String.IsNullOrEmpty(nTotalVta.ToString()))
                {
                    nTotalVta = 0;
                }
                drNueva["Retornable"] = nTotalVta;

                nTotalVta = dtProductos.Compute("sum(Cantidad)", "Contenido = 0 and Retornable = 0 and TransProdId = '" + fil["TransProdId"].ToString() + "'");
                if (String.IsNullOrEmpty(nTotalVta.ToString()))
                {
                    nTotalVta = 0;
                }
                drNueva["NoRetornable"] = nTotalVta;

                //VENTA LIQUIDO
                if (fil["TRPTipo"].ToString() == "1" | fil["TRPTipo"].ToString() == "24")
                {
                    nTotalVta = dtProductos.Compute("sum(Cantidad)", "Contenido = 0 and TransProdId = '" + fil["TransProdId"].ToString() + "'");
                    if (String.IsNullOrEmpty(nTotalVta.ToString()))
                    {
                        nTotalVta = 0;
                    }
                    drNueva["VentaLiquido"] = nTotalVta;
                }

                //Devolucion envase
                if (fil["TRPTipo"].ToString() == "3")
                {
                    nTotalVta = dtProductos.Compute("sum(Cantidad)", "Contenido = 1 and TransProdId = '" + fil["TransProdId"].ToString() + "'");
                    if (String.IsNullOrEmpty(nTotalVta.ToString()))
                    {
                        nTotalVta = 0;
                    }
                    drNueva["DevolucionEnvase"] = nTotalVta;
                }

                //Venta envase
                if (fil["TRPTipo"].ToString() == "1" | fil["TRPTipo"].ToString() == "24")
                {
                    nTotalVta = dtProductos.Compute("sum(Cantidad)", "Contenido = 1 and TransProdId = '" + fil["TransProdId"].ToString() + "'");
                    if (String.IsNullOrEmpty(nTotalVta.ToString()))
                    {
                        nTotalVta = 0;
                    }
                    drNueva["VentaEnvase"] = nTotalVta;
                }

                //TOTALES
                if (queryTotales.Count() > 0)
                {
                    filas = dtTotales.Select("TransProdId = '" + fil["TransProdId"].ToString() + "'");
                    if (filas.Count() > 0)
                    {
                        drNueva["ImporteVenta"] = filas[0]["ImporteVenta"].ToString();
                        drNueva["ImporteDescuento"] = filas[0]["ImporteDescuento"].ToString();
                        drNueva["PorcDescuento"] = filas[0]["PorcDescuento"].ToString();
                        drNueva["SubTotal"] = filas[0]["SubTotal"].ToString();
                        drNueva["Credito"] = filas[0]["Credito"].ToString();
                        drNueva["TotalCobrado"] = Double.Parse(filas[0]["SubTotal"].ToString()) - Double.Parse(filas[0]["Credito"].ToString());
                    }
                }

                //COBRANZA
                if (queryCobranza.Count() > 0)
                {
                    filas = dtCobranza.Select("TransProdId = '" + fil["TransProdId"].ToString() + "'");
                    if (filas.Count() > 0)
                    {
                        drNueva["AbonoCredito"] = filas[0]["AbonoCredito"].ToString();
                    }
                }

                dtFinal.Rows.Add(drNueva);
                //dtFinalCount++;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.nombreReporte.Split(' ')[0];

                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }

                        //for (int i = 0; i < dtFinalCount; i++)
                        //{
                        //    using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 80; }
                        //}

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
                                cell.Value = Mensaje.ObtenerDescripcion("XFecha", this.Lenguaje) + "(s): " + (this.StatusDate == "Entre" ? this.FechaInicial + " - " + this.FechaFinal : this.FechaInicial);
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
                                cell.Value = Mensaje.ObtenerDescripcion("XRuta", this.Lenguaje) + ": " + this.Rutas;
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
                                cell.Value = Mensaje.ObtenerDescripcion("XVendedor", this.Lenguaje) + ": " + this.VendedorNombre;
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
                                cell.Value = Mensaje.ObtenerDescripcion("XCategoriaCliente", this.Lenguaje) + ": " + this.esquemaNombre;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                cell.ApplyFormatting(Font);
                            }
                        }

                        int countRows = 9;
                        string sRegistro = "";
                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(countRows))
                        {
                            foreach (DataColumn col in dtFinal.Columns)
                            {
                                if (col.ColumnName != "ALMClave" && col.ColumnName != "RUTClave" && col.ColumnName != "ClienteClave" && col.ColumnName != "TransProdId")
                                {
                                    if (col.ColumnName.StartsWith("Nom_") ^ col.ColumnName.StartsWith("NomCont_"))
                                    {
                                        sRegistro = col.Caption;
                                    }
                                    else
                                    {
                                        sRegistro = Mensaje.ObtenerDescripcion("VCK" + col.ColumnName, this.Lenguaje);
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

                        //RENGLONES
                        string sCEDI = "";
                        string sRuta = "";
                        string sRutaAnt = "";
                        string sVendedor = "";
                        string sVendedorAnt = "";
                        string sCliente = "";
                        string sClienteAnt = "";
                        string sTotales = "";
                        Object nTotal;

                        countRows += 2;
                        foreach (DataRow fil in this.dtMovimientos.Rows)
                        {
                            sRegistro = "";
                            if (sCEDI != fil["ClaveCEDI"].ToString())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("Xcentrodistribucion", this.Lenguaje) + ": " + fil["ClaveCEDI"].ToString() + " " + fil["ALMNombre"].ToString();
                                sCEDI = fil["ClaveCEDI"].ToString();
                                sRuta = "";

                                using (IXlRow row = sheet.CreateRow(countRows++))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sRegistro;
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                            }

                            if (sRuta != fil["RUTClave"].ToString())
                            {
                                if (sRuta != "")
                                {
                                    sTotales = "";
                                    countRows++;
                                    using (IXlRow row = sheet.CreateRow(countRows++))
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            sRegistro = Mensaje.ObtenerDescripcion("XTotalPorRuta", this.Lenguaje);
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
                                                if (cols.ColumnName == "PorcDescuento")
                                                {
                                                    nTotal = dtFinal.Compute("sum(ImporteVenta)", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "'");

                                                    if (String.IsNullOrEmpty(nTotal.ToString()))
                                                    {
                                                        nTotal = 0;
                                                    }
                                                    if (double.Parse(nTotal.ToString()) > 0)
                                                    {
                                                        nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "'");
                                                    }
                                                }
                                                else
                                                {
                                                    nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "'");
                                                }
                                                sTotales = nTotal.ToString();

                                                using (IXlCell cell = row.CreateCell())
                                                {
                                                    cell.Value = sTotales;
                                                    cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                                    cell.ApplyFormatting(cellFormatting);
                                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                                }
                                            }
                                            else if (cols.ColumnName != "ALMClave" ^ cols.ColumnName != "RUTClave" ^ cols.ColumnName != "RuClienteClaveta" ^ cols.ColumnName != "TransProdId")
                                            {
                                                sTotales = "";
                                            }
                                        }
                                    }
                                }

                                countRows++;
                                sRuta = fil["RUTClave"].ToString();
                                sRutaAnt = sRuta;
                                sVendedor = "";
                                sRegistro = Mensaje.ObtenerDescripcion("XRuta", this.Lenguaje) + ": " + fil["RUTClave"].ToString();

                                using (IXlRow row = sheet.CreateRow(countRows++))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sRegistro;
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                            }

                            if (sVendedor != fil["USUClave"].ToString())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XVendedor", this.Lenguaje) + ": " + fil["USUClave"].ToString() + " " + fil["VENNombre"].ToString();
                                sVendedor = fil["USUClave"].ToString();
                                sVendedorAnt = sVendedor;
                                sCliente = "";
                                sClienteAnt = "";

                                using (IXlRow row = sheet.CreateRow(countRows++))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sRegistro;
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                            }

                            if (sCliente != fil["ClienteClave"].ToString())
                            {
                                if (sClienteAnt != "")
                                {
                                    sTotales = "";
                                    using (IXlRow row = sheet.CreateRow(countRows++))
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            sRegistro = Mensaje.ObtenerDescripcion("XTotalPorCliente", this.Lenguaje);
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
                                                if (cols.ColumnName == "PorcDescuento")
                                                {
                                                    nTotal = dtFinal.Compute("sum(ImporteVenta)", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "' and ClienteClave = '" + sClienteAnt + "'");

                                                    if (String.IsNullOrEmpty(nTotal.ToString()))
                                                    {
                                                        nTotal = 0;
                                                    }
                                                    if (double.Parse(nTotal.ToString()) > 0)
                                                    {
                                                        nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "' and ClienteClave = '" + sClienteAnt + "'");
                                                    }
                                                }
                                                else
                                                {
                                                    nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "' and ClienteClave = '" + sClienteAnt + "'");
                                                }
                                                sTotales = nTotal.ToString();

                                                using (IXlCell cell = row.CreateCell())
                                                {
                                                    cell.Value = sTotales;
                                                    cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                                    cell.ApplyFormatting(cellFormatting);
                                                    cell.ApplyFormatting(XlBorder.NoBorders());
                                                }
                                            }
                                            else if (cols.ColumnName != "ALMClave" ^ cols.ColumnName != "RUTClave" ^ cols.ColumnName != "ClienteClave" ^ cols.ColumnName != "TransProdId")
                                            {
                                                sTotales = "";
                                            }
                                        }
                                    }
                                }

                                countRows++;
                                sRegistro = Mensaje.ObtenerDescripcion("XCliente", this.Lenguaje) + ": " + fil["CLIClave"].ToString() + " " + fil["CLINombre"].ToString();
                                sCliente = fil["ClienteClave"].ToString();
                                sClienteAnt = sCliente;

                                using (IXlRow row = sheet.CreateRow(countRows++))
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sRegistro;
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                            }

                            filas = dtFinal.Select("TransProdId = '" + fil["TransProdId"].ToString() + "'");
                            foreach (DataRow rows in filas)
                            {
                                sRegistro = "";
                                using (IXlRow row = sheet.CreateRow(countRows++))
                                {
                                    foreach (DataColumn cols in dtFinal.Columns)
                                    {
                                        if (cols.ColumnName != "ALMClave" && cols.ColumnName != "RUTClave" && cols.ColumnName != "ClienteClave" && cols.ColumnName != "TransProdId")
                                        {
                                            if (cols.ColumnName == "Fecha")
                                            {
                                                sRegistro = DateTime.Parse(rows[cols.ColumnName].ToString()).ToString("dd/MM/yyyy");
                                                //DateTime.Parse(FinalDate).ToString("dd/MM/yyyy")
                                            }
                                            else
                                            {
                                                sRegistro = rows[cols.ColumnName].ToString();
                                            }

                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = sRegistro;
                                                cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                                cell.ApplyFormatting(cellFormatting);
                                                cell.ApplyFormatting(XlBorder.NoBorders());
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        sTotales = "";
                        using (IXlRow row = sheet.CreateRow(countRows++))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XTotalPorCliente", this.Lenguaje);
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
                                    if (cols.ColumnName == "PorcDescuento")
                                    {
                                        nTotal = dtFinal.Compute("sum(ImporteVenta)", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "' and ClienteClave = '" + sClienteAnt + "'");

                                        if (String.IsNullOrEmpty(nTotal.ToString()))
                                        {
                                            nTotal = 0;
                                        }
                                        if (double.Parse(nTotal.ToString()) > 0)
                                        {
                                            nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "' and ClienteClave = '" + sClienteAnt + "'");
                                        }
                                    }
                                    else
                                    {
                                        nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "' and ClienteClave = '" + sClienteAnt + "'");
                                    }
                                    sTotales = nTotal.ToString();

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sTotales;
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                                else if (cols.ColumnName != "ALMClave" ^ cols.ColumnName != "RUTClave" ^ cols.ColumnName != "ClienteClave" ^ cols.ColumnName != "TransProdId")
                                {
                                    sTotales = "";
                                }
                            }
                        }

                        if (sRuta != "")
                        {
                            sTotales = "";
                            countRows++;
                            using (IXlRow row = sheet.CreateRow(countRows++))
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    sRegistro = Mensaje.ObtenerDescripcion("XTotalPorRuta", this.Lenguaje);
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
                                        if (cols.ColumnName == "PorcDescuento")
                                        {
                                            nTotal = dtFinal.Compute("sum(ImporteVenta)", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "'");

                                            if (String.IsNullOrEmpty(nTotal.ToString()))
                                            {
                                                nTotal = 0;
                                            }
                                            if (double.Parse(nTotal.ToString()) > 0)
                                            {
                                                nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "'");
                                            }
                                        }
                                        else
                                        {
                                            nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "'");
                                        }
                                        sTotales = nTotal.ToString();

                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = sTotales;
                                            cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                            cell.ApplyFormatting(cellFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }
                                    }
                                    else if (cols.ColumnName != "ALMClave" ^ cols.ColumnName != "RUTClave" ^ cols.ColumnName != "RuClienteClaveta" ^ cols.ColumnName != "TransProdId")
                                    {
                                        sTotales = "";
                                    }
                                }
                            }
                        }

                        if (sCEDI != "")
                        {
                            sTotales = "";
                            using (IXlRow row = sheet.CreateRow(countRows++))
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    sRegistro = Mensaje.ObtenerDescripcion("XTotalPorCEDI", this.Lenguaje);
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
                                        if (cols.ColumnName == "PorcDescuento")
                                        {
                                            nTotal = dtFinal.Compute("sum(ImporteVenta)", "ALMClave = '" + sCEDI + "'");

                                            if (String.IsNullOrEmpty(nTotal.ToString()))
                                            {
                                                nTotal = 0;
                                            }
                                            if (double.Parse(nTotal.ToString()) > 0)
                                            {
                                                nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "ALMClave = '" + sCEDI + "'");
                                            }
                                        }
                                        else
                                        {
                                            nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "ALMClave = '" + sCEDI + "'");
                                        }
                                        sTotales = nTotal.ToString();

                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = sTotales;
                                            cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                            cell.ApplyFormatting(cellFormatting);
                                            cell.ApplyFormatting(XlBorder.NoBorders());
                                        }
                                    }
                                    else if (cols.ColumnName != "ALMClave" ^ cols.ColumnName != "RUTClave" ^ cols.ColumnName != "ClienteClave" ^ cols.ColumnName != "TransProdId")
                                    {
                                        sTotales = "";
                                    }
                                }
                            }
                        }

                        sTotales = "";
                        using (IXlRow row = sheet.CreateRow(countRows++))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XGRANTOTAL", this.Lenguaje);
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
                                    if (cols.ColumnName == "PorcDescuento")
                                    {
                                        nTotal = dtFinal.Compute("sum(ImporteVenta)", "");

                                        if (String.IsNullOrEmpty(nTotal.ToString()))
                                        {
                                            nTotal = 0;
                                        }
                                        if (double.Parse(nTotal.ToString()) > 0)
                                        {
                                            nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "");
                                        }
                                    }
                                    else
                                    {
                                        nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "");
                                    }
                                    sTotales = nTotal.ToString();

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = sTotales;
                                        cellFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlBorder.NoBorders());
                                    }
                                }
                                else if (cols.ColumnName != "ALMClave" ^ cols.ColumnName != "RUTClave" ^ cols.ColumnName != "ClienteClave" ^ cols.ColumnName != "TransProdId")
                                {
                                    sTotales = "";
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