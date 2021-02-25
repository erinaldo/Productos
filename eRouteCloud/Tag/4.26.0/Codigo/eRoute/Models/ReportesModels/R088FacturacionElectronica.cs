using DevExpress.Export.Xl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace eRoute.Models.ReportesModels
{
    public class R088FacturacionElectronica
    {
        private string[] header;
        private string reportName;
        private SelectedData tableData;

        public bool GetReport(string ReportName, string CompanyName, string CEDISName, string CEDIS, string SellerName, string Seller, string StartDate, string EndDate)
        {
            string[] parametersArray = { "paramCedis", "paramSeller", "paramStartDate", "paramEndDate" };
            string[] listValours = { CEDIS, Seller, DateTime.Parse(StartDate).ToString("yyyy-MM-dd"), DateTime.Parse(EndDate).ToString("yyyy-MM-dd") };
            reportName = ReportName;
            header = new string[] { ReportName, CompanyName, "Centro De Distribucion: " + CEDISName, "Vendedor: " + SellerName, "Fecha: " + (StartDate + (EndDate == StartDate ? "" : " - " + EndDate)) };
            GetDataLayer();
            Session session = new Session();
            const string queryString =
                @"EXEC [dbo].[stpr_RW088FacturacionElectronica]
                        @filterCEDIS = @paramCedis,
                        @filterSeller = @paramSeller,
                        @filterStartDate = @paramStartDate,
                        @filterEndDate = @paramEndDate";
            tableData = session.ExecuteQueryWithMetadata(queryString, parametersArray, listValours);

            if (tableData.ResultSet[1].Rows.Length > 0)
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
            List<string> subHeader = new List<string>();
            dynamic cellValue;
            int firstValueArray = 0;
            SelectStatementResultRow[] rowResultTem;
            SelectStatementResultRow[] colResult;
            int startDataColForTotal = 0;
            int startDataRowForGrandTotal = 0;
            int startDataRowForSubTotal = 0;
            List<string> impuestosList = new List<string>();
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = reportName.Length <= 25 ? reportName : reportName.Substring(0, 25);

                        sheet.OutlineProperties.SummaryBelow = true;

                        XlCellFormatting cellFormatting = new XlCellFormatting() { Font = new XlFont() };

                        XlCellFormatting subHeaderRowFormatting = new XlCellFormatting();
                        subHeaderRowFormatting.CopyFrom(cellFormatting);
                        subHeaderRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Center, XlVerticalAlignment.Center);
                        subHeaderRowFormatting.Border = new XlBorder();
                        subHeaderRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.Thin;
                        subHeaderRowFormatting.Border.TopLineStyle = XlBorderLineStyle.Thin;
                        subHeaderRowFormatting.Font.Bold = true;

                        XlCellFormatting totalRowFormatting = new XlCellFormatting();
                        totalRowFormatting.CopyFrom(subHeaderRowFormatting);
                        totalRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Center);
                        totalRowFormatting.Border = new XlBorder();
                        totalRowFormatting.Border.BottomLineStyle = XlBorderLineStyle.None;
                        totalRowFormatting.Border.TopLineStyle = XlBorderLineStyle.Thin;

                        XlCellFormatting headerRowFormatting = new XlCellFormatting();
                        headerRowFormatting.CopyFrom(subHeaderRowFormatting);
                        headerRowFormatting.Alignment = XlCellAlignment.FromHV(XlHorizontalAlignment.Left, XlVerticalAlignment.Center);
                        headerRowFormatting.Border = XlBorder.NoBorders();

                        for (int i = 0; i < header.Length; i++)
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

                        firstValueArray = tableData.ResultSet[0].Rows.FindIndex(item => item.Values[0].Equals("Serie"));
                        subHeader.AddRange((tableData.ResultSet[0].Rows).Where((value, index) => index >= firstValueArray - 1).Select(value => value.Values.First().ToString()).Distinct().ToList());
                        foreach (SelectStatementResultRow rowResult in tableData.ResultSet[3].Rows)
                        {
                            string valueTemp = string.Format("{0} {1} %", rowResult.Values[1], rowResult.Values[2]);
                            if (!subHeader.Contains(valueTemp))
                            {
                                impuestosList.Add(rowResult.Values[3].ToString());
                                subHeader.Insert(subHeader.IndexOf("Total"), valueTemp);
                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            foreach (string rowResult in subHeader)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = rowResult;
                                    cell.ApplyFormatting(subHeaderRowFormatting);
                                }
                            }
                        }

                        var dates = tableData.ResultSet[1].Rows.GroupBy(r => r.Values[7]).Select(r => r.Key).ToList();
                        int x = 0;
                        rowResultTem = tableData.ResultSet[1].Rows;
                        sheet.BeginGroup(false);
                        startDataRowForGrandTotal = sheet.CurrentRowIndex;
                        startDataColForTotal = subHeader.IndexOf("Fase");
                        foreach (DateTime d in dates)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Fecha:";
                                    cell.ApplyFormatting(cellFormatting);
                                }

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = string.Format("{0:dd/MM/yyyy}", d);
                                    cell.ApplyFormatting(cellFormatting);
                                }
                            }

                            startDataRowForSubTotal = sheet.CurrentRowIndex;
                            sheet.BeginGroup(false);
                            colResult = tableData.ResultSet[3].Rows;
                            while (x < rowResultTem.Length && d.Equals(rowResultTem[x].Values[7]))
                            {
                                bool tipo = rowResultTem[x].Values[2].ToString().Equals("8");
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    for (int i = firstValueArray - 1; i < rowResultTem[x].Values.Length; i++)
                                    {
                                        if (i == rowResultTem[x].Values.Length - 1)
                                        {
                                            foreach (string item in impuestosList)
                                            {
                                                using (IXlCell cell = row.CreateCell())
                                                {
                                                    cellValue = colResult.Where(imp => rowResultTem[x].Values[3].Equals(imp.Values.First()) && item.Equals(imp.Values[3].ToString())).Select(imp => imp.Values.Last().ToString()).FirstOrDefault();
                                                    cellValue = string.IsNullOrEmpty(cellValue) ? 0 : double.Parse(cellValue);
                                                    cell.Value = tipo || i < 17 ? cellValue : cellValue * -1;
                                                    cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                                    cell.ApplyFormatting(cellFormatting);
                                                }
                                            }
                                        }

                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cellValue = rowResultTem[x].Values[i];
                                            cell.Value = tipo || i < 17 ? cellValue : cellValue * -1;
                                            if (i > 17)
                                            {
                                                cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                            }
                                            else if (i == firstValueArray - 1)
                                            {
                                                cell.Formatting = XlCellFormatting.FromNetFormat("dd/MM/yyyy", true);
                                            }
                                            cell.ApplyFormatting(cellFormatting);
                                        }
                                    }
                                }
                                x++;
                            }
                            sheet.EndGroup();

                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell(startDataColForTotal))
                                {
                                    cell.Value = "Total:";
                                    cell.ApplyFormatting(totalRowFormatting);
                                }
                                for (int i = startDataColForTotal; i < subHeader.Count - 1; i++)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(i + 1, startDataRowForSubTotal, i + 1, row.RowIndex - 1), XlSummary.Sum, false));
                                        cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                        cell.ApplyFormatting(totalRowFormatting);
                                    }
                                }
                            }
                        }
                        sheet.EndGroup();
                        using (IXlRow row = sheet.CreateRow())
                        {
                            using (IXlCell cell = row.CreateCell(startDataColForTotal))
                            {
                                cell.Value = "Grand Total:";
                                cell.ApplyFormatting(totalRowFormatting);
                            }
                            for (int j = startDataColForTotal; j < subHeader.Count - 1; j++)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(j + 1, startDataRowForGrandTotal, j + 1, row.RowIndex - 1), XlSummary.Sum, false));
                                    cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                    cell.ApplyFormatting(totalRowFormatting);
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