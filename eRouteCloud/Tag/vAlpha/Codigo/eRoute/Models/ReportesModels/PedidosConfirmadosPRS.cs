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
    public class PedidosConfirmadosPRS
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

        private List<PedidosConfirmadosPRSNodel> ListModel;
        private List<InformeDatosEncabezado> ListSeller;
        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            String lenguaje = "select top 1 TipoLenguaje from CONHist order by CONHistFechaInicio desc";
            lenguaje = Connection.Query<string>(lenguaje, null, null, true, 9000).FirstOrDefault();
            return lenguaje;
        }

        public string ObtenerDescripcion(string VARCodigo, string VAVClave, string Lenguaje)
        {
            String Descripcion = "select top 1 Descripcion from VAVDescripcion where VARCodigo = '" + VARCodigo  + "' and VAVClave = '" + VAVClave  + "' and VADTipoLenguaje = '" + Lenguaje + "'";
            Descripcion = Connection.Query<string>(Descripcion, null, null, true, 9000).FirstOrDefault();
            return Descripcion;
        }

        public string ObtenerMensaje(string MENClave, string MEDTipoLenguaje)
        {
            String Descripcion = "select top 1 Descripcion from MENDetalle where MENClave = '" + MENClave + "' and MEDTipoLenguaje = '" + MEDTipoLenguaje + "'";
            Descripcion = Connection.Query<string>(Descripcion, null, null, true, 9000).FirstOrDefault();
            return Descripcion;
        }

        public bool GetReport(string Cedis, string nombreCedis, string StatusDate, string FechaInicial, string FechaFinal, string Vendedor)
        {
            try
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

                this.CEDI = (Cedis == "" ? "Todos" : Cedis + " - " + nombreCedis);
                this.Vendedores = (Vendedor == "" ? "N/A" : SellerHeader.ToString());
                
                if (FechaInicial != null)
                {
                    DateTime init = DateTime.Parse(FechaInicial);
                    FechaInicial = init.Date.ToString("yyyy-MM-dd");
                    FechaFinal = (StatusDate == "Entre" ? DateTime.Parse(FechaFinal).ToString("yyyy-MM-dd") : FechaInicial);
                }

                sConsulta.Clear();
                sConsulta.AppendLine("EXEC [dbo].[stpr_ReportePedidosConfirmadosPRS]");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "' ,");
                sConsulta.AppendLine("@filtroFechaFinal = '" + FechaFinal + "' ,");
                sConsulta.AppendLine("@filtroVendedores = '" + Vendedor + "' ");
                sConsulta.AppendLine("");
                QueryString = sConsulta.ToString();


                ListModel = Connection.Query<PedidosConfirmadosPRSNodel>(QueryString, null, null, true, 9000).ToList();
                
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
            catch (Exception ex)
            {
                return false;
            }
        }
        private ArchivoXlsModel GenerarExcel()
        {
            IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xlsx);
            ArchivoXlsModel archivo;
            this.Lenguaje = ObtenerLenguaje();
            var nom = ObtenerDescripcion("REPORTEW", "261", this.Lenguaje); 
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = nom;
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 280; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 250; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 120; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }

                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Arial";
                        cellFormatting.Font.Size = 9;
                        //cellFormatting.Font.SchemeStyle = XlFontSchemeStyles.None;

                        XlCellFormatting cellFormattingRigth = new XlCellFormatting();
                        cellFormattingRigth.Font = new XlFont();
                        cellFormattingRigth.Font.Name = "Arial";
                        cellFormattingRigth.Font.Size = 9;
                        cellFormattingRigth.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);

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
                                cell.Value = ObtenerDescripcion("REPORTEW", "261", this.Lenguaje);
                                cell.ApplyFormatting(headerRowFormatting);
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(4, 1, 8, 1));
                            }
                        }

                        // Datos de los Filtros Seleccionados.
                        XlFont Font = new XlFont();
                        Font.Bold = false;

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = ObtenerMensaje("XVendedores", this.Lenguaje) + ": " + this.Vendedores;
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
                                cell.Value = ObtenerMensaje("XFecha", this.Lenguaje) + ": " + this.FechaInicial;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center));
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                //sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 4, 17, 4));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(6))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Cliente";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Fecha Pedido";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Folio Pedido Protheus";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Total Antes de Impuestos";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Estatus";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Folio BackOrder";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Pedido eRoute";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Código";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Descripcion";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Unidad";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Cantidad Original";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Cantidad Confirmada";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Total";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            //using (IXlCell cell = row.CreateCell())
                            //{
                            //    cell.Value = "PRECIO BRUTO";
                            //    cell.ApplyFormatting(subHeaderRowFormatting);
                            //}
                            //using (IXlCell cell = row.CreateCell())
                            //{
                            //    cell.Value = "IVA";
                            //    cell.ApplyFormatting(subHeaderRowFormatting);
                            //}
                            //using (IXlCell cell = row.CreateCell())
                            //{
                            //    cell.Value = "PRECIO FINAL";
                            //    cell.ApplyFormatting(subHeaderRowFormatting);
                            //}
                            //using (IXlCell cell = row.CreateCell())
                            //{
                            //    cell.Value = "FACTURA";
                            //    cell.ApplyFormatting(subHeaderRowFormatting);
                            //}
                            //using (IXlCell cell = row.CreateCell())
                            //{
                            //    cell.Value = "TIPO MOVIMIENTO";
                            //    cell.ApplyFormatting(subHeaderRowFormatting);
                            //}
                        }

                        string Actual = "";
                        foreach (var item in ListModel)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    if(Actual != item.FolioeRoute)
                                    {
                                        cell.Value = item.Cliente;
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    if (Actual != item.FolioeRoute)
                                    {
                                        cell.Value = item.FechaPedido;
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    if (Actual != item.FolioeRoute)
                                    {
                                        cell.Value = item.FolioPedidoProtheus;
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    if (Actual != item.FolioeRoute)
                                    {
                                        cell.Value = item.TotalAntesImpuestos;
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    if (Actual != item.FolioeRoute)
                                    {
                                        cell.Value = item.Estatus;
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    if (Actual != item.FolioeRoute)
                                    {
                                        cell.Value = item.FolioBackOrder;
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    if (Actual != item.FolioeRoute)
                                    {
                                        cell.Value = item.FolioeRoute;
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.Codigo;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.Descripcion;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.Unidad;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.CantidadOriginal;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.CantidadConfirmada;
                                    cell.ApplyFormatting(cellFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = item.Total;
                                    cell.ApplyFormatting(cellFormattingRigth);
                                }
                                Actual = item.FolioeRoute;
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
                archivo.nombre = nom.Split('-')[1] + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            }
            return archivo;
        }
    }

    class PedidosConfirmadosPRSNodel
    {
        public string Cliente { get; set; }
        public string FechaPedido { get; set; }
        public string FolioPedidoProtheus { get; set; }
        public string TotalAntesImpuestos { get; set; }
        public string Estatus { get; set; }
        public string FolioBackOrder { get; set; }
        public string FolioeRoute { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string CantidadOriginal { get; set; }
        public string CantidadConfirmada { get; set; }
        public string Total { get; set; }
    }
}
#endregion