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

namespace eRoute.Models.ReportesModels
{
    public class R263ImproductividadImagenes
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string nombreEmpresa;
        private string nombreReporte;
        private string CEDI;
        private string Rutas;
        private string FechaInicial;
        private string FechaFinal;
        private string StatusDate;
        private string Lenguaje;

        private List<R263ImproductividadImagenesModel> ListModel;

        RouteEntities db = new RouteEntities();

        public string ObtenerLenguaje()
        {
            var lenguaje = (from config in db.CONHist orderby config.CONHistFechaInicio descending select config.TipoLenguaje).Take(1).ToList();
            return lenguaje[0];
        }

        public bool GetReport(string CompanyName, string ReportName, string CEDIS, string NameCEDIS, string Routes, string StatusDate, string InitialDate, string FinalDate)
        {
            try
            {
                StringBuilder sConsulta = new StringBuilder();

                this.CEDI = NameCEDIS;
                this.Rutas = Routes;

                sConsulta.Clear();
                sConsulta.AppendLine("EXECUTE [DBO].[stpr_r263ImproductividadConImagenes]");
                sConsulta.AppendLine("@FILTROCEDI = '" + CEDIS + "',");
                sConsulta.AppendLine("@FILTRORUTA = '" + Routes + "',");
                sConsulta.AppendLine("@FILTROFECHAINI = '" + DateTime.Parse(InitialDate).ToString("yyyyMMdd") + "',");
                sConsulta.AppendLine("@FILTROFECHAFIN = '" + (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("yyyyMMdd") : DateTime.Parse(InitialDate).ToString("yyyyMMdd")) + "'");
                sConsulta.AppendLine("");

                QueryString = sConsulta.ToString();

                ListModel = Connection.Query<R263ImproductividadImagenesModel>(QueryString, null, null, true, 9000).ToList();
                
                if (ListModel.Count > 0)
                {
                    if (InitialDate != null)
                    {
                        this.FechaInicial = DateTime.Parse(InitialDate).ToString("dd/MM/yyyy");
                        this.FechaFinal = (StatusDate == "Entre" ? DateTime.Parse(FinalDate).ToString("dd/MM/yyyy") : FinalDate);
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

            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.nombreReporte.Replace(" ", "");

                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 200; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 350; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 90; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 140; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 140; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 150; }

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
                                cell.Value = this.nombreEmpresa;
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
                                cell.Value = Mensaje.ObtenerDescripcion("XFecha", this.Lenguaje) + "(s): " + (this.StatusDate == "Entre" ? this.FechaInicial + " Al " + this.FechaFinal : this.FechaInicial);
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
                                cell.Value = "Secuencia Visita";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XClaveCliente", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XNombredelCliente", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XDomicilio", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XHoraInicial", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XHoraFinal", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XTiempoDeVisita", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XMotivoImprod", this.Lenguaje);
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Nota de Improductividad";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "Foto en Improductividad";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                        }

                        var fechasConsulta = ListModel.GroupBy(f => f.FECHACAPTURA);

                        foreach (var group in fechasConsulta)
                        {
                            countRows += 2;
                            using (IXlRow row = sheet.CreateRow(countRows))
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Mensaje.ObtenerDescripcion("XFecha", this.Lenguaje) + ": " + DateTime.Parse(group.Key).ToString("dd/MM/yyyy");
                                    cell.ApplyFormatting(cellFormatting);
                                }
                            }

                            countRows++;
                            foreach (var registros in group)
                            {
                                countRows++;
                                countRowsPicture = countRows;
                                using (IXlRow row = sheet.CreateRow(countRows))
                                {
                                    row.HeightInPixels = 100;
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.NUMEROSECUENCIA;
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.CLIENTECLAVE;
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.CLIENTENOMBRE;
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.CALLE + registros.NUMERO + ", " + registros.COLONIA;
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.FECHAHORAINICIAL.ToString("HH:mm:ss");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.FECHAHORAFINAL.ToString("HH:mm:ss");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.CalculatedVisita.ToString("mm':'ss");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.DESCRIPCION;
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = registros.COMENTARIO;
                                        cell.ApplyFormatting(cellFormatting);
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        Image imageData;
                                        imageData = GetImageValidater(registros.VISITACLAVE);

                                        if (imageData != null)
                                        {
                                            using (IXlPicture picture = sheet.CreatePicture())
                                            {
                                                picture.Image = imageData;
                                                picture.StretchToCell(new XlCellPosition(9, countRows));
                                            }
                                        }
                                        else
                                        {
                                            cell.Value = "No Image";
                                            cell.ApplyFormatting(cellFormatting);
                                        }
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

        private Image GetImageValidater(string visitaClave)
        {
            string LogoQuery = "SELECT IV.ImagenEvidencia FROM ImproductividadVenta IV (NOLOCK) WHERE IV.VisitaClave = '" + visitaClave + "'";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();

            try {
                MemoryStream CompanyLogo = new MemoryStream(byteArrayIn);
                return Image.FromStream(CompanyLogo);
            } catch (ArgumentException ex) {
                return null;
            }
        }
    }

    class R263ImproductividadImagenesModel
    {
        public string VISITACLAVE { get; set; }
        public string NUMEROSECUENCIA { get; set; }
        public string CLIENTECLAVE { get; set; }
        public string CLIENTENOMBRE { get; set; }
        public string CALLE { get; set; }
        public string NUMERO { get; set; }
        public string COLONIA { get; set; }
        public DateTime FECHAHORAINICIAL { get; set; }
        public DateTime FECHAHORAFINAL { get; set; }
        public TimeSpan CalculatedVisita { get { return FECHAHORAFINAL.Subtract(FECHAHORAINICIAL); } }
        public string DESCRIPCION { get; set; }
        public string COMENTARIO { get; set; }
        public string FECHACAPTURA { get; set; }
    }
}