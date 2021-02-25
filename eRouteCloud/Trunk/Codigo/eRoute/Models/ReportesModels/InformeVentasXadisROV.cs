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
    public class InformeVentasXadisROV
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string nombreEmpresa;
        private string CEDI;
        private string Rutas;
        private string Vendedores;
        private string EsquemaCliente;
        private string EsquemaProducto;
        private string Clientes;
        private string FechaInicial;
        private string Lenguaje;

        private List<InformeVentasXadisROVNodel> ListModel;
        private List<InformeDatosEncabezado> ListSeller;
        private List<InformeDatosEncabezado> listClientsSchema;
        private List<InformeDatosEncabezado> listProductsSchema;
        private List<InformeDatosEncabezado> listClients;

        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public bool GetReport(string Cedis, string nombreCedis, string FechaInicial, string Rutas, string Vendedor, string ClientesScheme, string Clientes, string ProductosScheme)
        {
            #region Header

            StringBuilder sConsulta = new StringBuilder();
            StringBuilder SellerHeader = new StringBuilder();
            StringBuilder ClientsSchemaHeader = new StringBuilder();
            StringBuilder ProductsSchemaHeader = new StringBuilder();
            StringBuilder ClientsHeader = new StringBuilder();

            if (Vendedor != "")
            {
                sConsulta.Clear();
                sConsulta.AppendLine("select V.VendedorID AS Clave, V.Nombre AS Nombre from Vendedor V where V.VendedorID IN (SELECT Datos FROM FNSplit('" + Vendedor + "', ','))");
                QueryString = sConsulta.ToString();

                ListSeller = Connection.Query<InformeDatosEncabezado>(QueryString, null, null, true, 9000).ToList();

                foreach (var x in ListSeller)
                {
                    if (x.Equals(ListSeller.Last()))
                    {
                        SellerHeader.Append(x.Nombre);
                    }
                    else
                    {
                        SellerHeader.Append(x.Nombre + ", ");
                    }
                }
            }

            if (ClientesScheme != "")
            {
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT E.EsquemaID AS Clave, E.Nombre AS Nombre FROM Esquema E WHERE E.EsquemaID IN(SELECT Datos FROM FNSplit('" + ClientesScheme + "', ','))");
                QueryString = sConsulta.ToString();

                listClientsSchema = Connection.Query<InformeDatosEncabezado>(QueryString, null, null, true, 9000).ToList();

                foreach (var x in listClientsSchema)
                {
                    if (x.Equals(listClientsSchema.Last()))
                    {
                        ClientsSchemaHeader.Append(x.Nombre);
                    }
                    else
                    {
                        ClientsSchemaHeader.Append(x.Nombre + ", ");
                    }
                }
            }

            if (ProductosScheme != "")
            {
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT E.EsquemaID AS Clave, E.Nombre AS Nombre FROM Esquema E WHERE E.EsquemaID IN(SELECT Datos FROM FNSplit('" + ProductosScheme + "', ','))");
                QueryString = sConsulta.ToString();

                listProductsSchema = Connection.Query<InformeDatosEncabezado>(QueryString, null, null, true, 9000).ToList();

                foreach (var x in listProductsSchema)
                {
                    if (x.Equals(listProductsSchema.Last()))
                    {
                        ProductsSchemaHeader.Append(x.Nombre);
                    }
                    else
                    {
                        ProductsSchemaHeader.Append(x.Nombre + ", ");
                    }
                }
            }

            if (Clientes != "")
            {
                sConsulta.Clear();
                sConsulta.AppendLine("SELECT C.Clave AS Clave, C.RazonSocial AS Nombre FROM Cliente C WHERE C.Clave IN (SELECT Datos FROM FNSplit('" + Clientes + "', ','))");
                QueryString = sConsulta.ToString();

                listClients = Connection.Query<InformeDatosEncabezado>(QueryString, null, null, true, 9000).ToList();

                foreach (var x in listClients)
                {
                    if (x.Equals(listClients.Last()))
                    {
                        ClientsHeader.Append(x.Clave + " - " + x.Nombre);
                    }
                    else
                    {
                        ClientsHeader.Append(x.Clave + " - " + x.Nombre + ", ");
                    }
                }
            }

            #endregion

            this.CEDI = (Cedis == "" ? "Todos" : Cedis + " - " + nombreCedis);
            this.Rutas = (Rutas == "" ? "N/A" : Rutas);
            this.Vendedores = (Vendedor == "" ? "N/A" : SellerHeader.ToString());
            this.EsquemaCliente = (ClientesScheme == "" ? "N/A" : ClientsSchemaHeader.ToString());
            this.EsquemaProducto = (ProductosScheme == "" ? "N/A" : ProductsSchemaHeader.ToString());
            this.Clientes = (Clientes == "" ? "N/A" : ClientsHeader.ToString());

            if (FechaInicial != null)
            {
                DateTime init = DateTime.Parse(FechaInicial);
                FechaInicial = init.Date.ToString("yyyy-MM-dd");
            }

            sConsulta.Clear();
            sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteInformeVentasXadisROV]");
            sConsulta.AppendLine("@filtroCEDIS = '" + Cedis + "' ,");
            sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "' ,");
            sConsulta.AppendLine("@filtroRutas = '" + Rutas + "' ,");
            sConsulta.AppendLine("@filtroVendedores = '" + Vendedor + "' ,");
            sConsulta.AppendLine("@filtroEsquemaCliente = '" + ClientesScheme + "' ,");
            sConsulta.AppendLine("@filtroEsquemaProducto = '" + ProductosScheme + "' ,");
            sConsulta.AppendLine("@filtroClientes = '" + Clientes + "' ");
            sConsulta.AppendLine("");
            QueryString = sConsulta.ToString();


            ListModel = Connection.Query<InformeVentasXadisROVNodel>(QueryString, null, null, true, 9000).ToList();

            if (ListModel.Count > 0)
            {
                if (FechaInicial != null)
                {
                    DateTime fInicio = DateTime.Parse(FechaInicial);
                    this.FechaInicial = fInicio.Date.ToString("yyyyMMdd");
                }

                this.nombreEmpresa = "SELECT NombreEmpresa FROM Configuracion (NOLOCK)";
                this.nombreEmpresa = Connection.Query<string>(this.nombreEmpresa, null, null, true, 9000).FirstOrDefault();

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
            var nom = ValorReferencia.ObtenerDescripcion("REPORTEW", "256", this.Lenguaje).Split(' ');
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = nom[1] + nom[2] + nom[3] + nom[4];
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 55; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 70; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 80; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 80; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 200; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 95; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 70; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 70; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 120; }

                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Arial";
                        cellFormatting.Font.Size = 9;
                        //cellFormatting.Font.SchemeStyle = XlFontSchemeStyles.None;

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
                                cell.Value = ValorReferencia.ObtenerDescripcion("REPORTEW", "256", this.Lenguaje);
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
                                cell.Value = Mensaje.ObtenerDescripcion("XCEDI", this.Lenguaje) + ": " + this.CEDI;
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
                                cell.Value = Mensaje.ObtenerDescripcion("XRuta(s)", this.Lenguaje) + ": " + this.Rutas;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                //sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 3, 17, 3));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XVendedores", this.Lenguaje) + ": " + this.Vendedores;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                //sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 3, 17, 3));
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
                                //sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 4, 17, 4));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XEsquemaCl", this.Lenguaje) + ": " + this.EsquemaCliente;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                //sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 3, 17, 3));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XEsquemaPr", this.Lenguaje) + ": " + this.EsquemaProducto;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                //sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 3, 17, 3));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XClient", this.Lenguaje) + ": " + this.Clientes;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                //sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 3, 17, 3));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(11))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "COD ARTICULO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "COD ALMACEN";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "VENTA";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "DEVOLUCION";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "UNIDAD";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "PERIODO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "COD CLIENTE";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "CANAL CLIENTE";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "PRECIO CLIENTE";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "% DESCUENTO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "DESCUENTO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "PRECIO NETO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "IEPS";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "PRECIO BRUTO";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "IVA";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "PRECIO FINAL";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "FACTURA";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "TIPO MOVIMIENTO";
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
                                    cell.Value = item.PrecioNeto;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.IEPS;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.PrecioBruto;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.IVA;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.PrecioFinal;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.FACTURA;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.TipoMov;
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
                archivo.nombre = nom[1] + nom[3] + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            }
            return archivo;
        }
    }

    class InformeVentasXadisROVNodel
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
        public string PrecioNeto { get; set; }
        public string IEPS { get; set; }
        public string PrecioBruto { get; set; }
        public string IVA { get; set; }
        public string PrecioFinal { get; set; }
        public string FACTURA { get; set; }
        public string TipoMov { get; set; }
    }

    class InformeDatosEncabezado
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
    }
}