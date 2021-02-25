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
    public class R066ClientesYActivos
    {
        private string[] header;
        private string reportName;
        private SelectedData tableData;

        public bool GetReport(string ReportName, string CompanyName, string CEDISName, string CEDIS, string StartDate, string EndDate, string Routes, string Sellers, string Customers, bool ReportFilter, bool ReportType)
        {
            string[] parametersArray = { "paramCedis", "paramStartDate", "paramEndDate", "paramRoutes", "paramSellers", "paramCustomers", "paramState" };
            string[] listValours = { CEDIS, DateTime.Parse(StartDate).ToString("yyyy-MM-dd"), DateTime.Parse(EndDate).ToString("yyyy-MM-dd"), Routes, Sellers, Customers, (ReportType ? "0" : "1") };
            reportName = ReportName;
            header = new string[] {
                    ReportName,
                    CompanyName,
                    "Centro De Distribucion: " + CEDISName,
                    "Fecha: " + (StartDate + (EndDate == StartDate ? "" : " - " + EndDate)),
                    ReportFilter ? "Vendedor: " + Sellers : "Ruta(s): " + (Routes == "" ? "Todas las Rutas" : Routes),
                    "Cliente(s): " + (Customers == "" ? "Todos los Clientes " + (ReportType ? "Inactivos" : "Activos") : Customers)
                };
            GetDataLayer();
            Session session = new Session();
            const string queryString =
                @"EXEC [dbo].[stpr_RW066ClientesYActivos]
                        @filterCEDIS = @paramCedis,
                        @filterStartDate = @paramStartDate,
                        @filterEndDate = @paramEndDate,
                        @filterRoutes = @paramRoutes,
                        @filterSellers = @paramSellers,
                        @filterCustomers = @paramCustomers,
                        @filterStateCustomers = @paramState";
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
            dynamic cellValue;
            //string[][] groupers;
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = reportName.Length <= 25 ? reportName : reportName.Substring(0, 25);

                        XlCellFormatting cellFormatting = new XlCellFormatting() { Font = new XlFont(), Border = new XlBorder() };

                        XlCellFormatting subHeaderRowFormatting = new XlCellFormatting();
                        subHeaderRowFormatting.CopyFrom(cellFormatting);
                        subHeaderRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                        subHeaderRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                        subHeaderRowFormatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                        subHeaderRowFormatting.Font.Bold = true;

                        XlCellFormatting groupHeaderRowFormatting = new XlCellFormatting();
                        groupHeaderRowFormatting.CopyFrom(subHeaderRowFormatting);
                        groupHeaderRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                        groupHeaderRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.None;
                        groupHeaderRowFormatting.Border.TopLineStyle = XlBorderLineStyle.None;

                        XlCellFormatting totalRowFormatting = new XlCellFormatting();
                        totalRowFormatting.CopyFrom(subHeaderRowFormatting);
                        totalRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                        totalRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.None;
                        totalRowFormatting.Border.TopLineStyle = XlBorderLineStyle.Thin;

                        XlCellFormatting tableTitleFormatting = new XlCellFormatting();
                        tableTitleFormatting.CopyFrom(subHeaderRowFormatting);
                        tableTitleFormatting.Font.Size = 15;
                        tableTitleFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);

                        XlCellFormatting headerRowFormatting = new XlCellFormatting();
                        headerRowFormatting.CopyFrom(subHeaderRowFormatting);
                        headerRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                        headerRowFormatting.Border = XlBorder.NoBorders();

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
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                            }
                        }
                        sheet.SkipRows(1);

                        SelectStatementResultRow[] subHeaderRow = tableData.ResultSet[0].Rows;
                        SelectStatementResultRow[] customersDataRow = tableData.ResultSet[1].Rows;

                        using (IXlRow row = sheet.CreateRow())
                        {
                            for (int i = 2; i < subHeaderRow.Length; i++)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = (subHeaderRow[i].Values[0]).ToString();
                                    cell.ApplyFormatting(subHeaderRowFormatting);
                                }
                            }
                        }

                        var groupers = customersDataRow.Select(x => new { Ruta = x.Values[0].ToString(), Vendedor = x.Values[1].ToString() }).Distinct().ToArray();
                        int count = 0;
                        for (int i = 0; i < groupers.Length; i++)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Ruta: ";
                                    cell.ApplyFormatting(groupHeaderRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = (groupers[i].Ruta).ToString();
                                    cell.ApplyFormatting(groupHeaderRowFormatting);
                                }
                            }

                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Vendedor: ";
                                    cell.ApplyFormatting(groupHeaderRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = (groupers[i].Vendedor).ToString();
                                    cell.ApplyFormatting(groupHeaderRowFormatting);
                                }
                            }

                            do
                            {
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    for (int j = 2; j < customersDataRow[count].Values.Length; j++)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cellValue = customersDataRow[count].Values[j];
                                            cell.Value = cellValue;
                                            cell.ApplyFormatting(cellFormatting);
                                        }
                                    }
                                }
                                count++;
                                if (count >= customersDataRow.Length)
                                {
                                    break;
                                }
                            } while ((new dynamic[] { customersDataRow[count].Values[0], customersDataRow[count].Values[1] }).SequenceEqual(new dynamic[] { groupers[i].Ruta, groupers[i].Vendedor }));

                            sheet.SkipRows(1);
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