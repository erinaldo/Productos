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
    public class DynamicExcelGenerator
    {
        private string reportName;
        private SelectedData tableData;

        public bool GetReport(string reportName, string listObject, string query, string parameters)
        {
            string[] parametersArray = parameters.Split(',');
            string[] listValours = listObject.Split('&');

            this.reportName = reportName;

            GetDataLayer();
            Session session = new Session();
            tableData = session.ExecuteQueryWithMetadata(query, parametersArray, listValours);

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
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = reportName.Length <= 25 ? reportName : reportName.Substring(0, 25);
                        IXlTable table;
                        for (int x = 0; x < tableData.ResultSet.Length; x += 2)
                        {
                            SelectStatementResultRow[] header = tableData.ResultSet[x].Rows;
                            SelectStatementResultRow[] data = tableData.ResultSet[x + 1].Rows;

                            if (data.Length > 0)
                            {
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

                                string[] valueTemp;
                                string[] value;
                                string[] columnNames;
                                string tableTitle;
                                dynamic cellValue;

                                List<string> subHeader = new List<string>();
                                List<Grouper> groupers = new List<Grouper>();
                                List<int> sumCount = new List<int>();

                                groupers = (header)
                                    .Where(group => group.Values.First().ToString().Contains("|GROUPER"))
                                    .Select((group, index) => new Grouper { Index = index, GrouperHeader = group.Values.First().ToString(), StartSumGrouper = 0 }).ToList();

                                subHeader.AddRange((header)
                                    .Where((sub, index) => index >= groupers.Count)
                                    .Select(sub => sub.Values.First().ToString()).ToList());

                                columnNames = subHeader.Select(h => h.Split('|')[0]).ToArray();

                                tableTitle = header.First().Values.First().ToString();

                                if (tableTitle.Contains("|TABLE_TITLE"))
                                {
                                    tableTitle = (tableTitle.Split('|').Where(t => t.Contains("TABLE_TITLE:")).FirstOrDefault()).Split(':').LastOrDefault();
                                    using (IXlRow row = sheet.CreateRow())
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = tableTitle;
                                            cell.ApplyFormatting(tableTitleFormatting);
                                            sheet.MergedCells.Add(XlCellRange.FromLTRB(0, cell.RowIndex, 5, cell.RowIndex));
                                        }
                                    }
                                }

                                if (header.First().Values.First().ToString().Contains("PIVOT"))
                                {
                                    int skip = 0;
                                    foreach (string rowResult in subHeader)
                                    {
                                        value = rowResult.Split('|');
                                        using (IXlRow row = sheet.CreateRow())
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = value[0];
                                                cell.ApplyFormatting(groupHeaderRowFormatting);
                                            }
                                            foreach (SelectStatementResultRow cellResult in data)
                                            {
                                                using (IXlCell cell = row.CreateCell())
                                                {
                                                    cellValue = cellResult.Values[skip];
                                                    cell.Value = cellValue;

                                                    if (value.Length > 1)
                                                    {
                                                        string valueCase = Array.Find(value, v => v.Contains("FORMAT"));
                                                        if (!string.IsNullOrEmpty(valueCase))
                                                        {
                                                            valueTemp = valueCase.Contains("&") ? valueCase.Split('&') : valueCase.Split('%');
                                                            switch (valueTemp[1])
                                                            {
                                                                case "$":
                                                                    XlNumberFormat formatNumber = @"_([$$-409]* #,##0.00_);_([$$-409]* \(#,##0.00\);_([$$-409]* ""0""??_);_(@_)";
                                                                    cell.Formatting = new XlCellFormatting();
                                                                    cell.Formatting.NumberFormat = formatNumber;
                                                                    break;
                                                                default:
                                                                    XlCellFormatting format = XlCellFormatting.FromNetFormat(valueTemp[1], valueCase.Contains("%"));
                                                                    cell.Formatting = format;
                                                                    break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        skip++;
                                    }
                                }
                                else
                                {
                                    using (IXlRow row = sheet.CreateRow())
                                    {
                                        table = row.BeginTable(columnNames, true, subHeaderRowFormatting);
                                        if (header.First().Values.First().ToString().Contains("PAINT_TABLE"))
                                        {
                                            table.Style.Name = XlBuiltInTableStyleId.Medium2;
                                        }
                                        else
                                        {
                                            table.Style.Name = XlBuiltInTableStyleId.None;
                                            table.Style.ShowRowStripes = false;
                                        }

                                        table.HasAutoFilter = false;
                                        for (int i = 0; i < subHeader.Count; i++)
                                        {
                                            value = subHeader[i].Split('|');
                                            if (value.Length > 1)
                                            {
                                                for (int j = 0; j < value.Length; j++)
                                                {
                                                    if (value[j].Contains("FORMAT"))
                                                    {
                                                        string valueCase = Array.Find(value, val => val.Contains("FORMAT"));
                                                        valueTemp = valueCase.Contains("&") ? valueCase.Split('&') : valueCase.Split('%');
                                                        switch (valueTemp[1])
                                                        {
                                                            case "$":
                                                                XlNumberFormat formatNumber = @"_([$$-409]* #,##0.00_);_([$$-409]* \(#,##0.00\);_([$$-409]* ""0""??_);_(@_)";
                                                                table.Columns[i].DataFormatting = formatNumber;
                                                                break;
                                                            default:
                                                                XlCellFormatting format = XlCellFormatting.FromNetFormat(valueTemp[1], valueCase.Contains("%"));
                                                                table.Columns[i].DataFormatting = format;
                                                                break;
                                                        }
                                                    }
                                                    else if (value[j].Contains("SUMMARY"))
                                                    {
                                                        sumCount.Add(i);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    sheet.BeginGroup(false);

                                    dynamic groupingCellValue = string.Empty;
                                    string grouperHeader = string.Empty;
                                    bool startGroupChange = false;
                                    int endGroup = 0;

                                    for (int q = 0; q <= data.Length; q++)
                                    {
                                        SelectStatementResultRow rowResult = data[q < data.Length ? q : q - 1];
                                        if (q < data.Length)
                                        {
                                            if (groupers.Count > 0)
                                            {
                                                for (int i = 0; i < groupers.Count; i++)
                                                {
                                                    grouperHeader = groupers[i].GrouperHeader;
                                                    startGroupChange = q > 0 && !startGroupChange ? !rowResult.Values[groupers[i].Index].Equals(data[q - 1].Values[groupers[i].Index]) : true;

                                                    if (startGroupChange)
                                                    {
                                                        using (IXlRow row = sheet.CreateRow())
                                                        {
                                                            using (IXlCell cell = row.CreateCell())
                                                            {
                                                                cell.Value = string.Format("{0}:", grouperHeader.Split('|')[0]);
                                                                cell.ApplyFormatting(groupHeaderRowFormatting);
                                                            }

                                                            using (IXlCell cell = row.CreateCell())
                                                            {
                                                                groupingCellValue = rowResult.Values[groupers[i].Index];
                                                                cell.Value = groupingCellValue;

                                                                if (sumCount.Count > 0)
                                                                {
                                                                    groupers[i].StartSumGrouper = row.RowIndex + (groupers.Count - groupers[i].Index);
                                                                }

                                                                if (grouperHeader.Contains("FORMAT%"))
                                                                {
                                                                    string valueCase = Array.Find(grouperHeader.Split('|'), val => val.Contains("FORMAT%"));
                                                                    value = valueCase.Split('%');
                                                                    cell.Formatting = new XlCellFormatting();
                                                                    cell.Formatting = XlCellFormatting.FromNetFormat(value[1], true);
                                                                }

                                                                cell.ApplyFormatting(groupHeaderRowFormatting);
                                                            }
                                                        }
                                                        sheet.BeginGroup(false);
                                                    }
                                                }
                                                startGroupChange = false;
                                            }

                                            bool groupBool = groupers.Count != 0 ? groupingCellValue.Equals(rowResult.Values[groupers.Count - 1]) : true;
                                            if (groupBool)
                                            {
                                                using (IXlRow row = sheet.CreateRow())
                                                {
                                                    for (int i = groupers.Count; i < rowResult.Values.Length; i++)
                                                    {
                                                        using (IXlCell cell = row.CreateCell())
                                                        {
                                                            cellValue = rowResult.Values[i];

                                                            if (cellValue != null)
                                                            {
                                                                if (cellValue.ToString().StartsWith("="))
                                                                {
                                                                    cell.SetFormula(String.Format(cellValue, row.RowIndex + 1));
                                                                }
                                                                else
                                                                {
                                                                    cell.Value = cellValue;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }


                                        if (groupers.Count > 0 && sumCount.Count > 0)
                                        {
                                            bool endGroupChange = q == data.Length - 1 ? true : q == data.Length ? false : !rowResult.Values[groupers[groupers.Count - 1].Index].Equals(data[q + 1].Values[groupers[groupers.Count - 1].Index]);

                                            if (endGroupChange)
                                            {
                                                for (int i = 0; i < groupers.Count; i++)
                                                {
                                                    if (q > 0 && !startGroupChange)
                                                    {
                                                        endGroup = q == data.Length - 1 ? 0 : i;
                                                        startGroupChange = q == data.Length - 1 ? true : !rowResult.Values[groupers[i].Index].Equals(data[q + 1].Values[groupers[i].Index]);
                                                    }
                                                    else
                                                    {
                                                        startGroupChange = true;
                                                    }
                                                }

                                                for (int i = groupers.Count - 1; i >= endGroup; i--)
                                                {
                                                    grouperHeader = groupers[i].GrouperHeader;
                                                    sheet.EndGroup();
                                                    using (IXlRow row = sheet.CreateRow())
                                                    {
                                                        if (sumCount.FirstOrDefault() > 0)
                                                        {
                                                            using (IXlCell cell = row.CreateCell(sumCount.FirstOrDefault() - 1))
                                                            {
                                                                cell.Value = string.Format("Total Por {0}:", grouperHeader.Split('|')[0]);
                                                                cell.ApplyFormatting(totalRowFormatting);
                                                            }
                                                        }

                                                        foreach (int cellResult in sumCount)
                                                        {
                                                            using (IXlCell cell = row.CreateCell(cellResult))
                                                            {
                                                                cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(cellResult, groupers[i].StartSumGrouper, cellResult, row.RowIndex - (groupers.Count - groupers[i].Index)), XlSummary.Sum, false));
                                                                cell.ApplyFormatting(totalRowFormatting);
                                                            }
                                                        }
                                                    }
                                                }
                                                startGroupChange = false;
                                            }
                                        }
                                    }

                                    sheet.EndGroup();

                                    using (IXlRow row = sheet.CreateRow())
                                    {
                                        /* Grand Total */
                                        if (sumCount.Count > 0)
                                        {
                                            if (sumCount.FirstOrDefault() > 0)
                                            {
                                                using (IXlCell cell = row.CreateCell(sumCount.FirstOrDefault() - 1))
                                                {
                                                    cell.Value = "Gran Total:";
                                                    cell.ApplyFormatting(totalRowFormatting);
                                                }
                                            }

                                            foreach (int cellResult in sumCount)
                                            {
                                                using (IXlCell cell = row.CreateCell(cellResult))
                                                {
                                                    cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(cellResult, table.Range.TopLeft.Row + 1, cellResult, (row.RowIndex - groupers.Count) - 1), XlSummary.Sum, false));
                                                    cell.ApplyFormatting(totalRowFormatting);
                                                }
                                            }
                                        }

                                        row.EndTable(table, false);
                                    }
                                }
                                sheet.SkipRows(5);
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

    public class Grouper
    {
        public int Index { get; set; }
        public string GrouperHeader { get; set; }
        public int StartSumGrouper { get; set; }
    }
}