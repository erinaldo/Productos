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
    public class R097ResumenDeVentasPorRutaYVendedor
    {
        private string[] header;
        private string reportName;
        private SelectedData tableData;

        public bool GetReport(string ReportName, string CompanyName, string CEDISName, string CEDIS, string StartDate, string EndDate, string ProductSchemes)
        {
            string[] parametersArray = { "paramCedis", "paramStartDate", "paramEndDate", "paramProductSchemes" };
            string[] listValours = { CEDIS, DateTime.Parse(StartDate).ToString("yyyy-MM-dd"), DateTime.Parse(EndDate).ToString("yyyy-MM-dd"), ProductSchemes };
            reportName = ReportName;
            header = new string[] {
                    ReportName,
                    CompanyName,
                    Mensaje.ObtenerDescripcion("Xcentrodistribucion", "EM") + ": " + CEDISName,
                    Mensaje.ObtenerDescripcion("XFecha", "EM") + ": " + (StartDate + (EndDate == StartDate ? "" : " - " + EndDate)),
                    Mensaje.ObtenerDescripcion("XCATEGORIAPRODUCTO", "EM") + ": " + ProductSchemes };

            GetDataLayer();
            Session session = new Session();
            const string queryString =
                @"EXEC [dbo].[stpr_RW097ResumenDeVentasPorRutaYVendedor]
                        @filtroCEDIS = @paramCedis,
                        @filtroFechaInicio = @paramStartDate,
                        @filtroFechaFin = @paramEndDate,
                        @filtroEsquemasProd = @paramProductSchemes";
            tableData = session.ExecuteQueryWithMetadata(queryString, parametersArray, listValours);

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

                        //1 RUTA VENDEDOR
                        //3 CATALOGO PRODUCTOS
                        //5 PRODUCTOS
                        //7 CONTENIDOS
                        //9 TOTALES
                        //11 ABONO CREDITO
                        //13 ABONO TOTAL

                        //HEADER PRODUCTOS
                        using (IXlRow row = sheet.CreateRow(6))
                        {
                            row.SkipCells(2);

                            foreach (SelectStatementResultRow rowResult in tableData.ResultSet[3].Rows)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = (rowResult.Values[0]).ToString(); //ProductoClave
                                }
                            }
                        }

                        var esquemas = tableData.ResultSet[5].Rows
                            .GroupBy(x => new
                            {
                                EsquemaId = x.Values[7],
                                Nombre = x.Values[8]
                            })
                            .Select(x => new
                            {
                                EsquemaId = x.First().Values[7].ToString(),
                                Nombre = x.First().Values[8].ToString()
                            })
                            .OrderBy(x => x.Nombre);

                        using (IXlRow row = sheet.CreateRow())
                        {
                            string[] titles = { Mensaje.ObtenerDescripcion("XRuta", "EM"), Mensaje.ObtenerDescripcion("XVendedor", "EM") };
                            foreach (string rowResult in titles)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = rowResult;
                                }
                            }

                            //HEADER PRODUCTOS
                            foreach (SelectStatementResultRow rowResult in tableData.ResultSet[3].Rows)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = (rowResult.Values[1]).ToString(); //ProductoNombre
                                }
                            }

                            //HEADER ESQUEMAS
                            foreach (var rowResult in esquemas.ToList())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = rowResult.Nombre; //NombreEsquema
                                }
                            }

                            titles = new string[] {
                                Mensaje.ObtenerDescripcion("VRVVentaLiquido", "EM"),
                                Mensaje.ObtenerDescripcion("VRVDevolucionEnvase", "EM"),
                                Mensaje.ObtenerDescripcion("VRVVentaEnvase", "EM"),
                                Mensaje.ObtenerDescripcion("VRVImporteVenta", "EM"),
                                Mensaje.ObtenerDescripcion("VRVImporteDescuento", "EM"),
                                Mensaje.ObtenerDescripcion("VRVPorcDescuento", "EM"),
                                Mensaje.ObtenerDescripcion("VRVSubTotal", "EM"),
                                Mensaje.ObtenerDescripcion("VRVCredito", "EM"),
                                Mensaje.ObtenerDescripcion("VRVAbonoCredito", "EM"),
                                Mensaje.ObtenerDescripcion("VRVTotalCobrado", "EM")
                            };

                            foreach (string rowResult in titles)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = rowResult;
                                }
                            }
                        }
                        int startDataRowForGrandTotal = sheet.CurrentRowIndex;
                        int ventaCol = 0;
                        int descuentoCol = 0;
                        int porcentajeCol = 0;

                        foreach (SelectStatementResultRow rowResult in tableData.ResultSet[1].Rows) //RUTA Y VENDDOR
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = (rowResult.Values[0]).ToString(); //Ruta
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "[" + (rowResult.Values[1]).ToString() + "] " + (rowResult.Values[2]).ToString(); //Vendedor
                                }

                                //Productos
                                var productos = tableData.ResultSet[5].Rows
                                    .Where(x => x.Values[0].ToString() == rowResult.Values[0].ToString() && x.Values[1].ToString() == rowResult.Values[1].ToString())
                                    .GroupBy(x => new
                                    {
                                        Producto = x.Values[2].ToString(),
                                        Cantidad = float.Parse(x.Values[6].ToString())
                                    })
                                    .Select(x => new
                                    {
                                        Producto = x.First().Values[2].ToString(),
                                        Cantidad = float.Parse(x.First().Values[6].ToString()),
                                        Contenido = bool.Parse(x.First().Values[4].ToString()),
                                        Promocion = int.Parse(x.First().Values[5].ToString())
                                    });

                                foreach (SelectStatementResultRow rowProductos in tableData.ResultSet[3].Rows)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        var cantidad = productos.ToArray()
                                                .Where(x => x.Producto == rowProductos.Values[0].ToString())
                                                .Select(x => x.Cantidad)
                                                .FirstOrDefault();

                                        cell.Value = cantidad;
                                    }
                                }

                                //Esquemas
                                var productosEsq = tableData.ResultSet[5].Rows
                                    .Where(x => x.Values[0].ToString() == rowResult.Values[0].ToString() && x.Values[1].ToString() == rowResult.Values[1].ToString())
                                    .GroupBy(x => new
                                    {
                                        EsquemaId = x.Values[7].ToString()
                                    })
                                    .Select(x => new
                                    {
                                        EsquemaId = x.First().Values[7].ToString(),
                                        Cantidad = x.Sum(y => float.Parse(y.Values[6].ToString()))
                                    });

                                foreach (var rowEsquemas in esquemas.ToList())
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        var cantidad = productosEsq.ToArray()
                                                .Where(x => x.EsquemaId == rowEsquemas.EsquemaId)
                                                .Select(x => x.Cantidad)
                                                .FirstOrDefault();

                                        cell.Value = cantidad;
                                    }
                                }

                                //Liquido
                                using (IXlCell cell = row.CreateCell())
                                {
                                    var cantidad = productos.ToArray()
                                            .Where(x => x.Contenido == false && x.Promocion == 0)
                                            .Select(x => productos.Sum(y => y.Cantidad))
                                            .FirstOrDefault();

                                    cell.Value = cantidad;
                                }

                                //Envases
                                var envases = tableData.ResultSet[7].Rows
                                            .Where(x => x.Values[0].ToString() == rowResult.Values[0].ToString() && x.Values[1].ToString() == rowResult.Values[1].ToString())
                                            .Select(x => new
                                            {
                                                CantidadDev = float.Parse(x.Values[2].ToString()),
                                                CantidadVta = float.Parse(x.Values[3].ToString())
                                            })
                                            .FirstOrDefault();

                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = envases?.CantidadDev ?? 0;

                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = envases?.CantidadVta ?? 0;


                                //Totales -- Importe Venta	Importe Descuento	% Descuento	Subtotal	Crédito
                                var totales = tableData.ResultSet[9].Rows
                                           .Where(x => x.Values[0].ToString() == rowResult.Values[0].ToString() && x.Values[1].ToString() == rowResult.Values[1].ToString())
                                           .Select(x => new
                                           {
                                               ImporteVta = float.Parse(x.Values[2].ToString()),
                                               ImporteDesc = float.Parse(x.Values[3].ToString()),
                                               PorcentajeDesc = float.Parse(x.Values[4].ToString()),
                                               Subtotal = float.Parse(x.Values[5].ToString()),
                                               VentaCredito = float.Parse(x.Values[6].ToString()),
                                           })
                                           .FirstOrDefault();

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = totales?.ImporteVta ?? 0;
                                    ventaCol = cell.Position.Column;
                                }

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = totales?.ImporteDesc ?? 0;
                                    descuentoCol = cell.Position.Column;
                                }

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = totales?.PorcentajeDesc ?? 0;
                                    porcentajeCol = cell.Position.Column;
                                }

                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = totales?.Subtotal ?? 0;

                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = totales?.VentaCredito ?? 0;

                                //Abono Crédito
                                var abonoCred = tableData.ResultSet[11].Rows
                                            .Where(x => x.Values[0].ToString() == rowResult.Values[0].ToString() && x.Values[1].ToString() == rowResult.Values[1].ToString())
                                            .Select(x => new
                                            {
                                                Importe = float.Parse(x.Values[2].ToString())
                                            })
                                            .FirstOrDefault();

                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = abonoCred?.Importe ?? 0;


                                //Abono Total
                                var abonoTot = tableData.ResultSet[13].Rows
                                            .Where(x => x.Values[0].ToString() == rowResult.Values[0].ToString() && x.Values[1].ToString() == rowResult.Values[1].ToString())
                                            .Select(x => new
                                            {
                                                Importe = float.Parse(x.Values[2].ToString())
                                            })
                                            .FirstOrDefault();

                                using (IXlCell cell = row.CreateCell())
                                    cell.Value = abonoTot?.Importe ?? 0;

                            }
                        }

                        //GRAN TOTAL                        
                        int endDataRowForGrandTotal = sheet.DataRange.BottomRight.Column - 1;
                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell())
                                cell.Value = Mensaje.ObtenerDescripcion("XGRANTOTAL", "EM");

                            row.SkipCells(1);
                            for (int j = 0; j < endDataRowForGrandTotal; j++)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    if (cell.ColumnIndex != porcentajeCol)
                                        cell.SetFormula(XlFunc.Sum(XlCellRange.FromLTRB(j + 2, startDataRowForGrandTotal, j + 2, row.RowIndex - 1)));
                                    else
                                    {
                                        cell.SetFormula("=Sum(" + XlCellRange.FromLTRB(descuentoCol, startDataRowForGrandTotal, descuentoCol, row.RowIndex - 1) + ")/" +
                                            "Sum(" + XlCellRange.FromLTRB(ventaCol, startDataRowForGrandTotal, ventaCol, row.RowIndex - 1) + ")*100");
                                    }
                                }
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

        private static IDataLayer GetDataLayer()
        {
            IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            XpoDefault.Session = null;
            XPDictionary dict = new ReflectionDictionary();
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(Connection, AutoCreateOption.DatabaseAndSchema);
            IDataStore store = XpoDefault.GetConnectionProvider(Connection, AutoCreateOption.SchemaAlreadyExists);
            IDataStore store1 = XpoDefault.GetConnectionProvider(Connection, AutoCreateOption.DatabaseAndSchema);
            dict.GetDataStoreSchema(System.Reflection.Assembly.GetExecutingAssembly());
            IDataLayer dl = new ThreadSafeDataLayer(dict, store);
            return dl;
        }
    }
}