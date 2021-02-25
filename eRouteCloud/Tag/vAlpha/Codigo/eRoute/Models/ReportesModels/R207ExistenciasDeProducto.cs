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
    public class R207ExistenciasDeProducto
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;
        private string CEDIS;
        private string FechaInicial;
        private string FechaFinal;
        private string NombreReporte;
        private string NombreEmpresa;
        private string Cantidad;
        private string Esquema;
        string Cantidad1;
        string Cantidad2;
        string Cantidad6;
        private List<ExistenciasProductoModel> lstCifrasControl;

        public bool GetReport(string NombreReporte, string NombreEmpresa, string NombreCEDIS, string CEDIS, string FechaInicial)
        {
            try
            {
                
                DateTime init = DateTime.Parse(FechaInicial);
                FechaInicial = init.Date.ToString("yyyy-MM-dd");

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("EXEC [dbo].[strp_Reporte207ExistenciaProducto] ");
                sConsulta.AppendLine("@filtroCEDIS = '" + CEDIS + "', ");
                sConsulta.AppendLine("@filtroFechaInicio = '" + FechaInicial + "' ");
                QueryString = sConsulta.ToString();

                lstCifrasControl = Connection.Query<ExistenciasProductoModel>(QueryString, null, null, true, 9000).ToList();

                if (lstCifrasControl.Count > 0)
                {

                    var Cantidad7 = (lstCifrasControl.Select(a => a.Almacen).Distinct()).ToList();
                    var Cantidad6 = ((from a in lstCifrasControl select a.Almacen).Distinct()).ToList();


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
                
                    this.NombreEmpresa = NombreEmpresa;
                    this.NombreReporte = NombreReporte;
                    List<ExistProductoModel> test = (from l in lstCifrasControl select new ExistProductoModel { Nombre = l.Nombre, Producto = l.Producto }).ToList();
                    var test1 = test.Distinct();

                    List<ExistProductoModel> test3 = ((from l in lstCifrasControl select new ExistProductoModel { Nombre = l.Nombre, Producto = l.Producto }).Distinct()).ToList();
                    var test4 = (from l in lstCifrasControl select new ExistProductoModel { Nombre = l.Nombre, Producto = l.Producto }).ToList();

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
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = this.NombreReporte.Substring(0, 25);
                        
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



                        int i = 3;
                        using (IXlRow row = sheet.CreateRow(5))
                        {
                            using (IXlCell cell = row.CreateCell(0))
                            {
                                cell.Value = "Segmento:";
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                            using (IXlCell cell = row.CreateCell(1))
                            {
                                cell.Value = "Producto:";
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                            using (IXlCell cell = row.CreateCell(2))
                            {
                                cell.Value = "Clave:";
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                            }
                            foreach (string ruta in lstCifrasControl.Select(a => a.Almacen).Distinct())
                            {
                                using (IXlCell cell = row.CreateCell(i))
                                {
                                    cell.Value = ruta;
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                                    i++;
                                }
                            }
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "TOTAL";
                                cell.ApplyFormatting(cellFormatting);
                                cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                                
                            }
                        }
                        int p = 0;
                        List<string> lstProdutos = new List<string>();
                        List<string> lstNombre = new List<string>();
                        List<string> lstRutas = new List<string>();
                        lstProdutos = lstCifrasControl.OrderBy(a => a.Producto).Select(a => a.Producto).Distinct().ToList();
                        lstNombre = lstCifrasControl.OrderBy(a => a.Producto).Select(a => a.Nombre).Distinct().ToList();
                        lstRutas = lstCifrasControl.Select(a => a.Almacen).Distinct().ToList();


                        int y = 0;
                        int suma=0;
                        foreach (var Product in lstProdutos)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    var Cantidad = ((lstCifrasControl.Where(a => a.Producto == Product).Select(a => a.Esquema)).FirstOrDefault());
                                    string Cantidad1 = Cantidad.ToString();
                                    cell.Value = Cantidad1;
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = lstNombre[p];
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                                    p++;
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = Product;
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                                }
                                for (int x = 0; x < lstRutas.Count; x++)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {   
                                        var Cantidad = ((lstCifrasControl.Where(a => a.Nombre == lstNombre[y] && a.Almacen==lstRutas[x] ).Select(a => a.Cantidad)).FirstOrDefault());
                                        string Cantidad1 = Cantidad.ToString();
                                        cell.Value =Convert.ToInt32( Cantidad1);
                                        cell.ApplyFormatting(cellFormatting);
                                        cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                                        int numero = 0;
                                        numero = Convert.ToInt32(Cantidad1);
                                        suma += numero;
                                    }
                                }
                                y++;

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = suma;
                                    cell.ApplyFormatting(cellFormatting);
                                    cell.ApplyFormatting(XlNumberFormat.NumberWithThousandSeparator);
                                }
                                suma = 0;
                            }


                        }
                        
                    }
                }

                archivo = new ArchivoXlsModel();
                archivo.archivo = stream.ToArray();
                archivo.nombre = this.NombreReporte + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            }
            return archivo;
            return null;
        }
    }

    class ExistenciasProductoModel
    {
        public String Esquema { get; set; }
        public String Almacen { get; set; }
        public String Producto { get; set; }
        public String Nombre { get; set; }
        public int Cantidad { get; set; }
    }


    class ExistProductoModel
    {
        public String Producto { get; set; }
        public String Nombre { get; set; }
    }
}