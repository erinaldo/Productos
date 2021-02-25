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
    public class CifrasControlBYD
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string CEDIS;
        private string FechaInicial;
        private string FechaFinal;
        private string NombreReporte;
        private string NombreEmpresa;

        private string NumeroNotasVentaM;
        private string CantidadPiezasVentasM;
        private string ImporteVentasM;

        private string NumeroNotasVentaAC;
        private string CantidadPiezasVentasAC;
        private string ImporteVentasAC;

        private string NumeroNotasVentaCSAP;
        private string CantidadPiezasVentasCSAP;
        private string ImporteVentasCSAP;

        private string NoCargas;
        private string CantidadPiezasCargadas;

        private string NoVisitasRealizadas;
        private string NoNoVisitas;
        private string NoVisitasPlaneadas;
        private string TotalClientes;
        private string TotalVendedores;
        private string TotalRutas;
        private string NumSucursales;

        private List<CifrasControlBYDModel> lstCifrasControl;

        public bool GetReport(string NombreReporte, string NombreEmpresa, string NombreCEDIS, string DateStatus, string CEDIS, string FechaInicial, string FechaFinal)
        {
            if (FechaInicial != null)
            {
                DateTime init = DateTime.Parse(FechaInicial);
                switch (DateStatus)
                {
                    case "Igual":
                        FechaInicial = init.Date.ToString("yyyy-MM-dd");
                        FechaFinal = init.Date.ToString("yyyy-MM-dd");
                        break;
                    case "Entre":
                        FechaInicial = init.Date.ToString("yyyy-MM-dd");
                        FechaFinal = DateTime.Parse(FechaFinal).Date.ToString("yyyy-MM-dd");
                        break;
                }
            }

            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("EXEC [dbo].[stpr_ReporteCifrasControlBYD] ");
            sConsulta.AppendLine("@filtroCEDIS = '" + CEDIS + "', ");
            sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "', ");
            sConsulta.AppendLine("@filtroFechaFin = '" + FechaFinal + "'");
            QueryString = sConsulta.ToString();
            lstCifrasControl = Connection.Query<CifrasControlBYDModel>(QueryString, null, null, true, 9000).ToList();

            if (lstCifrasControl.Count > 0)
            {
                this.CEDIS = (CEDIS == "" ? "Todos los CEDIS seleccionados" : NombreCEDIS);
                if (FechaInicial != null)
                {
                    DateTime fInicio = DateTime.Parse(FechaInicial);
                    if (FechaFinal == null || FechaFinal == FechaInicial)
                    {
                        this.FechaFinal = "";
                    }
                    else
                    {
                        DateTime fFin = DateTime.Now;
                        fFin = DateTime.Parse(FechaFinal);
                        this.FechaFinal = " al " + fFin.Date.ToShortDateString();
                    }
                    this.FechaInicial = fInicio.Date.ToShortDateString();
                }

                this.NumeroNotasVentaM = ((lstCifrasControl.Where(a => a.Tipo == "1" && a.ClienteSAP == "0").Select(a => a.NumeroDoctos)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.CantidadPiezasVentasM = ((lstCifrasControl.Where(a => a.Tipo == "1" && a.ClienteSAP == "0").Select(a => a.CantidadPiezas)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.ImporteVentasM = ((lstCifrasControl.Where(a => a.Tipo == "1" && a.ClienteSAP == "0").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();

                this.NumeroNotasVentaAC = ((lstCifrasControl.Where(a => a.Tipo == "24" && a.ClienteSAP == "0").Select(a => a.NumeroDoctos)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.CantidadPiezasVentasAC = ((lstCifrasControl.Where(a => a.Tipo == "24" && a.ClienteSAP == "0").Select(a => a.CantidadPiezas)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.ImporteVentasAC = ((lstCifrasControl.Where(a => a.Tipo == "24" && a.ClienteSAP == "0").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();

                this.NumeroNotasVentaCSAP = ((lstCifrasControl.Where(a => a.Tipo == "1" && a.ClienteSAP == "1").Select(a => a.NumeroDoctos)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.CantidadPiezasVentasCSAP = ((lstCifrasControl.Where(a => a.Tipo == "1" && a.ClienteSAP == "1").Select(a => a.CantidadPiezas)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.ImporteVentasCSAP = ((lstCifrasControl.Where(a => a.Tipo == "1" && a.ClienteSAP == "1").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();

                this.NoCargas = ((lstCifrasControl.Where(a => a.Tipo == "2" && a.ClienteSAP == "0").Select(a => a.NumeroDoctos)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.CantidadPiezasCargadas = ((lstCifrasControl.Where(a => a.Tipo == "2" && a.ClienteSAP == "0").Select(a => a.CantidadPiezas)).DefaultIfEmpty("0").ToList()[0]).ToString();

                this.NoVisitasRealizadas = ((lstCifrasControl.Where(a => a.Tipo == "5" && a.ClienteSAP == "5" && a.NumeroDoctos == "5" && a.CantidadPiezas == "1").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.NoNoVisitas = ((lstCifrasControl.Where(a => a.Tipo == "5" && a.ClienteSAP == "5" && a.NumeroDoctos == "5" && a.CantidadPiezas == "2").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.NoVisitasPlaneadas = ((lstCifrasControl.Where(a => a.Tipo == "5" && a.ClienteSAP == "5" && a.NumeroDoctos == "5" && a.CantidadPiezas == "3").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();

                this.TotalClientes = ((lstCifrasControl.Where(a => a.Tipo == "5" && a.ClienteSAP == "5" && a.NumeroDoctos == "5" && a.CantidadPiezas == "4").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.TotalVendedores = ((lstCifrasControl.Where(a => a.Tipo == "5" && a.ClienteSAP == "5" && a.NumeroDoctos == "5" && a.CantidadPiezas == "5").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.TotalRutas = ((lstCifrasControl.Where(a => a.Tipo == "5" && a.ClienteSAP == "5" && a.NumeroDoctos == "5" && a.CantidadPiezas == "6").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();
                this.NumSucursales = ((lstCifrasControl.Where(a => a.Tipo == "5" && a.ClienteSAP == "5" && a.NumeroDoctos == "5" && a.CantidadPiezas == "7").Select(a => a.Total)).DefaultIfEmpty("0").ToList()[0]).ToString();

                this.NombreEmpresa = NombreEmpresa;
                this.NombreReporte = NombreReporte;

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
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.NombreReporte.Substring(0, 25);
                        using (IXlColumn column = sheet.CreateColumn(1)) { column.WidthInPixels = 430; }
                        using (IXlColumn column = sheet.CreateColumn()) { column.WidthInPixels = 100; }

                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Arial";
                        cellFormatting.Font.Size = 10;
                        cellFormatting.Font.SchemeStyle = XlFontSchemeStyles.None;
                        cellFormatting.Border = new XlBorder();
                        cellFormatting.Border = XlBorder.OutlineBorders(XlColor.Auto, XlBorderLineStyle.Thin);

                        XlCellFormatting subHeaderRowFormatting = new XlCellFormatting();
                        subHeaderRowFormatting.CopyFrom(cellFormatting);
                        subHeaderRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                        subHeaderRowFormatting.Font.Bold = true;

                        XlCellFormatting headerRowFormatting = new XlCellFormatting();
                        headerRowFormatting.CopyFrom(subHeaderRowFormatting);
                        headerRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                        headerRowFormatting.Border = XlBorder.NoBorders();
                        headerRowFormatting.Font.Size = 15;

                        // Nombre del Reporte.
                        using (IXlRow row = sheet.CreateRow(1))
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = this.NombreReporte;
                                cell.ApplyFormatting(headerRowFormatting);
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 1, 3, 1));
                            }
                        }

                        // Nombre de la Empresa.
                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = this.NombreEmpresa;
                                cell.ApplyFormatting(headerRowFormatting);
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 2, 3, 2));
                            }
                        }

                        // Datos de los Filtros Seleccionados.
                        XlFont Font = new XlFont();
                        Font.Bold = false;
                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XSucursal", "EM") + ": " + this.CEDIS;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 3, 3, 3));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Mensaje.ObtenerDescripcion("XFecha", "EM") + "(s): " + this.FechaInicial + this.FechaFinal;
                                cell.ApplyFormatting(subHeaderRowFormatting);
                                cell.ApplyFormatting(XlBorder.NoBorders());
                                sheet.MergedCells.Add(XlCellRange.FromLTRB(0, 4, 3, 4));
                                cell.ApplyFormatting(Font);
                            }
                        }

                        // Nombre de los Encabezados.
                        using (IXlRow row = sheet.CreateRow(6))
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Número de Notas de Venta de Mostrador:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.NumeroNotasVentaM);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Cantidad de Piezas de Ventas Mostrador:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.CantidadPiezasVentasM);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Importe de Ventas Mostrador:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Double.Parse(this.ImporteVentasM);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator2);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow(10))
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Número de Notas de Venta de Autoservicio y Conveniencia:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.NumeroNotasVentaAC);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Cantidad de Piezas Ventas Clientes Autoservicio y Conveniencia:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.CantidadPiezasVentasAC);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Importe de Ventas Clientes Autoservicio y Conveniencia:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Double.Parse(this.ImporteVentasAC);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator2);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow(14))
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Número de Notas de Venta Clientes SAP:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.NumeroNotasVentaCSAP);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Cantidad de Piezas Ventas Clientes SAP:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.CantidadPiezasVentasCSAP);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Importe de Ventas Clientes SAP:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Double.Parse(this.ImporteVentasCSAP);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator2);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow(18))
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "No. de Cargas:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.NoCargas);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Cantidad de Piezas Cargadas:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.CantidadPiezasCargadas);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow(21))
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "No. Visitas Realizadas:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.NoVisitasRealizadas);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "No. de No Visitas:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.NoNoVisitas);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "No. de Visitas Planeadas:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.NoVisitasPlaneadas);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow(25))
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Total Clientes:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.TotalClientes);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Total de Vendedores:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.TotalVendedores);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Total de Rutas:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.TotalRutas);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "No. de Sucursales:";
                                cell.ApplyFormatting(subHeaderRowFormatting);
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = Int32.Parse(this.NumSucursales);
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                        }
                    }
                }
                archivo = new ArchivoXlsModel();
                archivo.archivo = stream.ToArray();
                archivo.nombre = this.NombreReporte + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            }
            return archivo;
        }
    }

    class CifrasControlBYDModel
    {
        public String Tipo { get; set; }
        public String ClienteSAP { get; set; }
        public String NumeroDoctos { get; set; }
        public String CantidadPiezas { get; set; }
        public String Total { get; set; }
    }
}