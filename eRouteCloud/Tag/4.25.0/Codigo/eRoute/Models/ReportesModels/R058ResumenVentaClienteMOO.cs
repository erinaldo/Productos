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
    public class R058ResumenVentaClienteMOO
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string nombreEmpresa;
        private string nombreReporte;
        private string CEDIS;
        private string NameCEDIS;
        private string Vendedor;
        private string VendedorNombre;
        private string EsquemaNombre;
        private string Rutas;
        private string Esquema;
        private string FechaInicial;
        private string FechaFinal;
        private string StatusDate;
        private string Lenguaje;
        private StringBuilder sConsulta = new StringBuilder();
        private DataTable dtVendedores;

        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public bool GetReport(string ReportName, string CompanyName, MemoryStream CompanyLogo, string CEDIS, string NameCEDIS, string StatusDate, string InitialDate, string FinalDate, string Routes, string Sellers, string CustomerSchemes)
        {
            var NomVendedores = "";
            string[] SellersArrays = Sellers.Split(',');

            if (!Sellers.Equals("") && SellersArrays.Length == 1)
            {
                var Vendedor = (from V in db.Vendedor
                                join U in db.Usuario on V.USUId equals U.USUId
                                where V.VendedorID == Sellers
                                select V.Nombre).Take(1).ToList();

                NomVendedores = Vendedor[0].ToString();
            }

            var NomEsquema = "";
            string[] SchemesArrays = CustomerSchemes.Split(',');

            if (!CustomerSchemes.Equals("") && SchemesArrays.Length == 1)
            {
                var esquema = (from E in db.Esquema
                               where E.EsquemaID == CustomerSchemes
                               select E.Nombre).Take(1).ToList();

                NomEsquema = esquema[0].ToString();
            }

            this.CEDIS = CEDIS;
            this.NameCEDIS = NameCEDIS;
            this.Vendedor = Sellers;
            this.VendedorNombre = NomVendedores;
            this.EsquemaNombre = NomEsquema;
            this.Rutas = Routes;
            this.Esquema = CustomerSchemes;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R058ResumenVentaCliente_MOO]");
            sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + Sellers + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + Routes + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + CustomerSchemes + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 0 ");
            sConsulta.AppendLine("");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryVendedores = Connection.Query(QueryString, null, null, true, 5000).ToList();
            Connection.Close();

            if (queryVendedores.Count() > 0)
            {
                var jsonVendedores = JsonConvert.SerializeObject(queryVendedores);
                this.dtVendedores = (DataTable)JsonConvert.DeserializeObject(jsonVendedores, (typeof(DataTable)));

                if (InitialDate != null)
                {
                    this.FechaInicial = InitialDate;
                    this.FechaFinal = (StatusDate == "Entre" ? FinalDate : this.FechaInicial);
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
            DataTable dtProductos;
            DataTable dtContenidos;
            DataTable dtTotales;
            DataTable dtAbonoCredito;
            DataTable dtAbonoTotal;
            DataTable dtListaPrecios;
            Object nTotalVta;

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R058ResumenVentaCliente_MOO]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.Esquema + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 1 ");
            sConsulta.AppendLine("");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryProductos = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonProductos = JsonConvert.SerializeObject(queryProductos);
            dtProductos = (DataTable)JsonConvert.DeserializeObject(jsonProductos, (typeof(DataTable)));

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R058ResumenVentaCliente_MOO]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.Esquema + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 2 ");
            sConsulta.AppendLine("");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryContenidos = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonContenidos = JsonConvert.SerializeObject(queryContenidos);
            dtContenidos = (DataTable)JsonConvert.DeserializeObject(jsonContenidos, (typeof(DataTable)));

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R058ResumenVentaCliente_MOO]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.Esquema + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 3 ");
            sConsulta.AppendLine("");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryTotales = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonTotales = JsonConvert.SerializeObject(queryTotales);
            dtTotales = (DataTable)JsonConvert.DeserializeObject(jsonTotales, (typeof(DataTable)));

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R058ResumenVentaCliente_MOO]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.Esquema + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 4 ");
            sConsulta.AppendLine("");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryAbonoCredito = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonAbonoCredito = JsonConvert.SerializeObject(queryAbonoCredito);
            dtAbonoCredito = (DataTable)JsonConvert.DeserializeObject(jsonAbonoCredito, (typeof(DataTable)));

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R058ResumenVentaCliente_MOO]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.Esquema + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 5 ");
            sConsulta.AppendLine("");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryAbonoTotal = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonAbonoTotal = JsonConvert.SerializeObject(queryAbonoTotal);
            dtAbonoTotal = (DataTable)JsonConvert.DeserializeObject(jsonAbonoTotal, (typeof(DataTable)));

            sConsulta.Clear();
            sConsulta.AppendLine("EXECUTE [DBO].[stpr_R058ResumenVentaCliente_MOO]");
            sConsulta.AppendLine("@FILTROCEDI = '" + this.CEDIS + "',");
            sConsulta.AppendLine("@FILTROVENDEDOR = '" + this.Vendedor + "',");
            sConsulta.AppendLine("@FILTRORUTAS = '" + this.Rutas + "',");
            sConsulta.AppendLine("@FILTROESQUEMA = '" + this.Esquema + "',");
            sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd") + "',");
            sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(this.FechaFinal).ToString("yyyyMMdd") : DateTime.Parse(this.FechaInicial).ToString("yyyyMMdd")) + "',");
            sConsulta.AppendLine("@noConsulta = 6 ");
            sConsulta.AppendLine("");

            QueryString = sConsulta.ToString();
            Connection.Open();
            var queryListaPrecio = Connection.Query(QueryString, null, null, true, 600).ToList();
            Connection.Close();
            var jsonListaPrecio = JsonConvert.SerializeObject(queryListaPrecio);
            dtListaPrecios = (DataTable)JsonConvert.DeserializeObject(jsonListaPrecio, (typeof(DataTable)));

            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("CEDI", typeof(string));
            dtFinal.Columns.Add("Ruta", typeof(string));
            dtFinal.Columns.Add("Vendedor", typeof(string));
            dtFinal.Columns.Add("ClienteClave", typeof(string));
            dtFinal.Columns.Add("CLIClave", typeof(string));
            dtFinal.Columns.Add("CLINombre", typeof(string));

            //PRODUCTOS
            DataRow[] filas = dtProductos.Select("Contenido = 0 and Promocion = 0", "ProductoClave");
            string sCol = "";
            DataColumn columnAlias;

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
            filas = dtProductos.Select("Contenido = 1 and Promocion = 0", "ProductoClave");
            sCol = "";

            foreach (DataRow row in filas)
            {
                if (row["ProductoClave"].ToString() != sCol)
                {
                    columnAlias = dtFinal.Columns.Add("NomCont_" + row["ProductoClave"].ToString(), typeof(double));
                    columnAlias.Caption = "'" + Mensaje.ObtenerDescripcion("VRVEnvase", this.Lenguaje) + " " + row["Nombre"].ToString();
                    sCol = row["ProductoClave"].ToString();
                }
            }

            //RETORNABLE Y NO RETORNABLE
            dtFinal.Columns.Add("Retornable", typeof(double));
            dtFinal.Columns.Add("NoRetornable", typeof(double));
            //VENTA LIQUIDO
            dtFinal.Columns.Add("VentaLiquido", typeof(double));

            //PROMOCIONES
            filas = dtProductos.Select("Promocion = 1", "ProductoClave");
            sCol = "";

            foreach (DataRow row in filas)
            {
                if (row["ProductoClave"].ToString() != sCol)
                {
                    columnAlias = dtFinal.Columns.Add("NomProm_" + row["ProductoClave"].ToString(), typeof(double));
                    columnAlias.Caption = "'" + Mensaje.ObtenerDescripcion("VRVPromocion", this.Lenguaje) + " " + row["Nombre"].ToString();
                    sCol = row["ProductoClave"].ToString();
                }
            }

            dtFinal.Columns.Add("DevolucionEnvase", typeof(double));
            dtFinal.Columns.Add("VentaEnvase", typeof(double));
            dtFinal.Columns.Add("ImporteVenta", typeof(double));
            dtFinal.Columns.Add("ImporteDescuento", typeof(double));
            dtFinal.Columns.Add("PorcDescuento", typeof(double));
            dtFinal.Columns.Add("SubTotal", typeof(double));
            dtFinal.Columns.Add("Credito", typeof(double));
            dtFinal.Columns.Add("AbonoCredito", typeof(double));
            dtFinal.Columns.Add("TotalCobrado", typeof(double));
            dtFinal.Columns.Add("ListaPrecios", typeof(string));

            //AGREGAR REGISTROS
            int dtFinalCount = 0;
            filas = this.dtVendedores.Select();
            foreach (DataRow fil in filas)
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
                filas = dtProductos.Select("Contenido = 0 and Promocion = 0 and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'", "ProductoClave");
                foreach (DataRow row in filas)
                {
                    drNueva["Nom_" + row["ProductoClave"].ToString()] = row["Cantidad"].ToString();
                }

                //CONTENIDOS
                filas = dtProductos.Select("Contenido = 1 and Promocion = 0 and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'", "ProductoClave");
                foreach (DataRow row in filas)
                {
                    drNueva["NomCont_" + row["ProductoClave"].ToString()] = row["Cantidad"].ToString();
                }

                //RETORNABLE Y NO RETORNABLE
                nTotalVta = dtProductos.Compute("sum(Cantidad)", "Contenido = 0 and Promocion = 0 and Retornable = 1 and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                if (String.IsNullOrEmpty(nTotalVta.ToString()))
                {
                    nTotalVta = 0;
                }
                drNueva["Retornable"] = nTotalVta;

                nTotalVta = dtProductos.Compute("sum(Cantidad)", "Contenido = 0 and Promocion = 0 and Retornable = 0 and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                if (String.IsNullOrEmpty(nTotalVta.ToString()))
                {
                    nTotalVta = 0;
                }
                drNueva["NoRetornable"] = nTotalVta;

                //VENTA LIQUIDO
                nTotalVta = dtProductos.Compute("sum(Cantidad)", "Contenido = 0 and Promocion = 0 and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                if (String.IsNullOrEmpty(nTotalVta.ToString()))
                {
                    nTotalVta = 0;
                }
                drNueva["VentaLiquido"] = nTotalVta;

                //PROMOCIONES
                if (queryProductos.Count() > 0)
                {
                    filas = dtProductos.Select("Promocion = 1 and RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'", "ProductoClave");
                    foreach (DataRow row in filas)
                    {
                        drNueva["NomProm_" + row["ProductoClave"].ToString()] = row["Cantidad"].ToString();
                    }
                }

                //CONTENIDOS
                if (queryContenidos.Count() > 0)
                {
                    filas = dtContenidos.Select("RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                    if (filas.Count() > 0)
                    {
                        drNueva["DevolucionEnvase"] = filas[0]["CantidadDev"].ToString();
                        drNueva["VentaEnvase"] = filas[0]["CantidadVta"].ToString();
                    }
                }

                //TOTALES
                if (queryTotales.Count() > 0)
                {
                    filas = dtTotales.Select("RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                    if (filas.Count() > 0)
                    {
                        drNueva["ImporteVenta"] = filas[0]["Venta"].ToString();
                        drNueva["ImporteDescuento"] = filas[0]["Descuento"].ToString();
                        drNueva["PorcDescuento"] = filas[0]["PorcentajeDescuento"].ToString();
                        drNueva["SubTotal"] = filas[0]["SubTotal"].ToString();
                        drNueva["Credito"] = filas[0]["VentaCredito"].ToString();
                    }
                }

                //ABONO CREDITOS
                if (queryAbonoCredito.Count() > 0)
                {
                    filas = dtAbonoCredito.Select("RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                    if (filas.Count() > 0)
                    {
                        drNueva["AbonoCredito"] = filas[0]["AbonoCredito"].ToString();
                    }
                }

                //ABONO TOTAL
                if (queryAbonoTotal.Count() > 0)
                {
                    filas = dtAbonoTotal.Select("RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
                    if (filas.Count() > 0)
                    {
                        drNueva["TotalCobrado"] = filas[0]["AbonoTotal"].ToString();
                    }
                }

                //LISTA PRECIOS
                string sPrecios = "";
                if (queryListaPrecio.Count() > 0)
                {
                    filas = dtListaPrecios.Select("RUTClave = '" + fil["RUTClave"].ToString() + "' and VendedorId = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
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
                dtFinalCount++;
            }




            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.nombreReporte.Split(' ')[0];

                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }

                        for (int i = 0; i < dtFinalCount; i++)
                        {
                            using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 80; }
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
                                cell.Value = Mensaje.ObtenerDescripcion("XFecha", this.Lenguaje) + "(s): " + (this.StatusDate == "Entre" ? DateTime.Parse(this.FechaInicial).ToString("dd/MM/yyyy") + " Al " + DateTime.Parse(this.FechaFinal).ToString("dd/MM/yyyy") : this.FechaInicial);
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
                                cell.Value = Mensaje.ObtenerDescripcion("XCategoriaCliente", this.Lenguaje) + ": " + this.EsquemaNombre;
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
                                if (col.ColumnName != "CEDI" && col.ColumnName != "Ruta" && col.ColumnName != "Vendedor" && col.ColumnName != "ClienteClave")
                                {
                                    if (col.ColumnName.StartsWith("Nom_") ^ col.ColumnName.StartsWith("NomCont_") ^ col.ColumnName.StartsWith("NomProm_"))
                                    {
                                        sRegistro = col.Caption;
                                    }
                                    else
                                    {
                                        sRegistro = Mensaje.ObtenerDescripcion("RVC" + col.ColumnName, this.Lenguaje);
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
                        string sTotales = "";
                        Object nTotal;

                        countRows += 2;
                        foreach (DataRow fil in this.dtVendedores.Rows)
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
                                if (sVendedorAnt != "")
                                {
                                    sTotales = "";
                                    using (IXlRow row = sheet.CreateRow(countRows++))
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            sRegistro = Mensaje.ObtenerDescripcion("XTotalPorVendedor", this.Lenguaje);
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
                                                    nTotal = dtFinal.Compute("sum(ImporteVenta)", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "' and Vendedor = '" + sVendedorAnt + "'");

                                                    if (String.IsNullOrEmpty(nTotal.ToString()))
                                                    {
                                                        nTotal = 0;
                                                    }
                                                    if (double.Parse(nTotal.ToString()) > 0)
                                                    {
                                                        nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "' and Vendedor = '" + sVendedorAnt + "'");
                                                    }
                                                }
                                                else
                                                {
                                                    nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "' and Vendedor = '" + sVendedorAnt + "'");
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
                                            else if (cols.ColumnName != "Vendedor" ^ cols.ColumnName != "CEDI" ^ cols.ColumnName != "Ruta" ^ cols.ColumnName != "ClienteClave")
                                            {
                                                sTotales = "";
                                            }
                                        }
                                    }
                                }

                                if (sRuta != "")
                                {
                                    sTotales = "";
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
                                                    nTotal = dtFinal.Compute("sum(ImporteVenta)", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "'");

                                                    if (String.IsNullOrEmpty(nTotal.ToString()))
                                                    {
                                                        nTotal = 0;
                                                    }
                                                    if (double.Parse(nTotal.ToString()) > 0)
                                                    {
                                                        nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "'");
                                                    }
                                                }
                                                else
                                                {
                                                    nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "'");
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
                                            else if (cols.ColumnName != "Vendedor" ^ cols.ColumnName != "CEDI" ^ cols.ColumnName != "Ruta" ^ cols.ColumnName != "ClienteClave")
                                            {
                                                sTotales = "";
                                            }
                                        }
                                    }
                                }

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

                            if (sVendedor != fil["VendedorId"].ToString())
                            {
                                sRegistro = Mensaje.ObtenerDescripcion("XVendedor", this.Lenguaje) + ": " + fil["VENNombre"].ToString();
                                sVendedor = fil["VendedorId"].ToString();
                                sVendedorAnt = sVendedor;

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

                            filas = dtFinal.Select("CEDI = '" + fil["ClaveCEDI"].ToString() + "' and Ruta = '" + fil["RUTClave"].ToString() + "' and Vendedor = '" + fil["VendedorId"].ToString() + "' and ClienteClave = '" + fil["ClienteClave"].ToString() + "'");
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
                                                if (cols.ColumnName == "CLINombre")
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
                        }

                        if (sVendedorAnt != "")
                        {
                            sTotales = "";
                            using (IXlRow row = sheet.CreateRow(countRows++))
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    sRegistro = Mensaje.ObtenerDescripcion("XTotalPorVendedor", this.Lenguaje);
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
                                            nTotal = dtFinal.Compute("sum(ImporteVenta)", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "' and Vendedor = '" + sVendedorAnt + "'");

                                            if (String.IsNullOrEmpty(nTotal.ToString()))
                                            {
                                                nTotal = 0;
                                            }
                                            if (double.Parse(nTotal.ToString()) > 0)
                                            {
                                                nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "' and Vendedor = '" + sVendedorAnt + "'");
                                            }
                                        }
                                        else
                                        {
                                            nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "' and Vendedor = '" + sVendedorAnt + "'");
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
                                    else if (cols.ColumnName != "Vendedor" ^ cols.ColumnName != "CEDI" ^ cols.ColumnName != "Ruta" ^ cols.ColumnName != "ClienteClave")
                                    {
                                        sTotales = "";
                                    }
                                }
                            }
                        }

                        if (sRuta != "")
                        {
                            sTotales = "";
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
                                            nTotal = dtFinal.Compute("sum(ImporteVenta)", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "'");

                                            if (String.IsNullOrEmpty(nTotal.ToString()))
                                            {
                                                nTotal = 0;
                                            }
                                            if (double.Parse(nTotal.ToString()) > 0)
                                            {
                                                nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "'");
                                            }
                                        }
                                        else
                                        {
                                            nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "CEDI = '" + sCEDI + "' and Ruta = '" + sRutaAnt + "'");
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
                                    else if (cols.ColumnName != "Vendedor" ^ cols.ColumnName != "CEDI" ^ cols.ColumnName != "Ruta" ^ cols.ColumnName != "ClienteClave")
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
                                            nTotal = dtFinal.Compute("sum(ImporteVenta)", "CEDI = '" + sCEDI + "'");

                                            if (String.IsNullOrEmpty(nTotal.ToString()))
                                            {
                                                nTotal = 0;
                                            }
                                            if (double.Parse(nTotal.ToString()) > 0)
                                            {
                                                nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" + sCEDI + "'");
                                            }
                                        }
                                        else
                                        {
                                            nTotal = dtFinal.Compute("sum([" + cols.ColumnName + "])", "CEDI = '" + sCEDI + "'");
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
                                    else if (cols.ColumnName != "Vendedor" ^ cols.ColumnName != "CEDI" ^ cols.ColumnName != "Ruta" ^ cols.ColumnName != "ClienteClave")
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
                                else if (cols.ColumnName != "Vendedor" ^ cols.ColumnName != "CEDI" ^ cols.ColumnName != "Ruta" ^ cols.ColumnName != "ClienteClave")
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