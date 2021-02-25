using DevExpress.Export.Xl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace eRoute.Models.ReportesModels
{
    public class R190KardexDeExistencia
    {
        private string[] header;
        private string reportName;
        private SelectedData tableData;

        public bool GetReport(string ReportName, string CompanyName, string CEDISName, string CEDIS)
        {
            string[] parametersArray = { "paramCedis" };
            string[] listValours = { CEDIS };
            reportName = ReportName;
            header = new string[] {
                    ReportName,
                    CompanyName,
                    string.Format("{0}: {1}", Mensaje.ObtenerDescripcion("Xcentrodistribucion", "EM"), CEDISName),
                    string.Format("{0}: {1:d}", Mensaje.ObtenerDescripcion("XFecha", "EM"), DateTime.Today) };
            const string queryString =
                @"EXEC [dbo].[stpr_RW190KardexDeExistencia]
                        @filtroCEDIS = @paramCedis";
            IDbConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            IDataLayer dataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.SchemaAlreadyExists);

            using (UnitOfWork uow = new UnitOfWork(dataLayer))
            {
                tableData = uow.ExecuteQueryWithMetadata(queryString, parametersArray, listValours);
            }

            if (tableData.ResultSet[1].Rows.Count() > 0)
            {
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
                        sheet.Name = reportName.Length <= 25 ? reportName : reportName.Substring(0, 25);

                        for (int i = 0; i < header.Count(); i++)
                        {
                            sheet.MergedCells.Add(XlCellRange.FromLTRB(0, i, 4, i));
                        }

                        foreach (string rowResult in header)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = rowResult;
                                }
                            }
                        }

                        var almacenes = tableData.ResultSet[1].Rows
                           .GroupBy(x => new
                           {
                               Almacen = x.Values[0]
                           })
                           .Select(x => new
                           {
                               Almacen = x.First().Values[0].ToString()
                           })
                           .OrderBy(x => x.Almacen);

                        //HEADER ALMACENES
                        using (IXlRow row = sheet.CreateRow(5))
                        {
                            string[] titles = {
                                Mensaje.ObtenerDescripcion("XProducto", "EM"),
                                Mensaje.ObtenerDescripcion("XClave", "EM") };
                            foreach (string rowResult in titles)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = rowResult;
                                }
                            }

                            foreach (var rowResult in almacenes.ToList())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = rowResult.Almacen;
                                }
                            }

                            titles = new string[] {
                                Mensaje.ObtenerDescripcion("XTotal", "EM"),
                                Mensaje.ObtenerDescripcion("XConsigna", "EM")
                            };

                            foreach (string rowResult in titles)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = rowResult;
                                }
                            }
                        }

                        var productos = tableData.ResultSet[1].Rows
                           .GroupBy(x => new
                           {
                               Producto = x.Values[1],
                               Nombre = x.Values[2]
                           })
                           .Select(x => new
                           {
                               Producto = x.First().Values[1].ToString(),
                               Nombre = x.First().Values[2].ToString()
                           })
                           .OrderBy(x => x.Nombre);


                        const int startColumn = 2;
                        int endColumn = almacenes.ToList().Count() + 1;

                        foreach (var producto in productos)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = producto.Nombre;
                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = producto.Producto;

                                foreach (var almacen in almacenes.ToList())
                                {
                                    var cantidad = tableData.ResultSet[1].Rows
                                               .Where(x => x.Values[0].ToString() == almacen.Almacen && x.Values[1].ToString() == producto.Producto)
                                               .Select(x => float.Parse(x.Values[3].ToString()))
                                               .FirstOrDefault();

                                    using (IXlCell cell = row.CreateCell())
                                        cell.Value = cantidad;
                                }

                                using (IXlCell cell = row.CreateCell())
                                    cell.SetFormula(XlFunc.Sum(XlCellRange.FromLTRB(startColumn, row.RowIndex, endColumn, row.RowIndex)));

                                var consigna = tableData.ResultSet[1].Rows
                                              .Where(x => x.Values[1].ToString() == producto.Producto)
                                              .Select(x => float.Parse(x.Values[4].ToString()))
                                              .FirstOrDefault();

                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = consigna;
                            }
                        }

                    }
                }
                archivo = new ArchivoXlsModel();
                archivo.archivo = stream.ToArray();
                archivo.nombre = string.Format("{0}_{1:ddMMyyyy_hhmmss}.xlsx", reportName, DateTime.Now);
            }
            return archivo;
        }
    }
}