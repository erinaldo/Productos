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
    public class R089ResumenDeVentasPorRutaYVendedor
    {
        private string[] header;
        private string reportName;
        private int type;
        private SelectedData tableData;

        public bool GetReport(string ReportName, string CompanyName, string CEDISName, string CEDIS, string StartDate, string EndDate, bool Type)
        {
            string[] parametersArray = { "paramCedis", "paramStartDate", "paramEndDate", "paramType" };
            string[] listValours = { CEDIS, DateTime.Parse(StartDate).ToString("yyyy-MM-dd"), DateTime.Parse(EndDate).ToString("yyyy-MM-dd"), (Type ? null : "") };
            reportName = ReportName;
            header = new string[] { ReportName + (Type ? " - Detallado" : " - General"), CompanyName, "Centro De Distribucion: " + CEDISName, "Fecha: " + (StartDate + (EndDate == StartDate ? "" : " - " + EndDate)) };
            type = (Type ? 4 : 3);
            const string queryString =
                @"EXEC [dbo].[stpr_RW089ResumenDeVentasPorRutaYVendedor]
                        @filterCEDIS = @paramCedis,
                        @filterStartDate = @paramStartDate,
                        @filterEndDate = @paramEndDate,
                        @filterType = @paramType";
            IDbConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            IDataLayer dataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.SchemaAlreadyExists);

            using (UnitOfWork uow = new UnitOfWork(dataLayer))
            {
                tableData = uow.ExecuteQueryWithMetadata(queryString, parametersArray, listValours);
            }

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
            dynamic cellValue;
            SelectStatementResultRow cellResult;
            bool colBool;
            int skip;
            int startDataRowForGrandTotal = 0;
            int startDataRowForSubTotal = 0;
            int endDataRowForGrandTotal = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = reportName.Length <= 25 ? reportName : reportName.Substring(0, 25);

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

                        if (type == 3)
                        {
                            #region Reporte General
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
                            for (int i = 0; i < tableData.ResultSet[0].Rows.Count(); i++)
                            {
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    if (i == 0) { row.SkipCells(type - 1); }

                                    if (i != 0)
                                    {
                                        for (int j = 1; j < type; j++)
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (tableData.ResultSet[4].Rows[j].Values[0]).ToString();
                                                cell.ApplyFormatting(subHeaderRowFormatting);
                                            }
                                        }
                                    }

                                    foreach (SelectStatementResultRow colResult in tableData.ResultSet[1].Rows)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = (colResult.Values[i]).ToString();
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                        }
                                    }

                                    if (i != 0)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Venta Liquido";
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                        }

                                        for (int j = 4; j < tableData.ResultSet[4].Rows.Count(); j++)
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (tableData.ResultSet[4].Rows[j].Values[0]).ToString();
                                                cell.ApplyFormatting(subHeaderRowFormatting);
                                            }
                                        }
                                    }
                                }
                            }

                            skip = 0;
                            startDataRowForGrandTotal = sheet.CurrentRowIndex;
                            foreach (SelectStatementResultRow rowResult in tableData.ResultSet[5].Rows)
                            {
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    for (int i = 1; i < type; i++)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = (rowResult.Values[i]).ToString();
                                            cell.ApplyFormatting(cellFormatting);
                                        }
                                    }

                                    foreach (SelectStatementResultRow colResult in tableData.ResultSet[1].Rows)
                                    {
                                        colBool = false;
                                        cellValue = 0;
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            if (skip < tableData.ResultSet[3].Rows.Count())
                                            {
                                                cellResult = tableData.ResultSet[3].Rows[skip];
                                                colBool = (
                                                        rowResult.Values.Where((value, index) => index < type && index != 2).ToList()
                                                    ).SequenceEqual(
                                                        cellResult.Values.Where((value, index) => index < type - 1).ToList()
                                                    )
                                                    &&
                                                    (
                                                        colResult.Values.FirstOrDefault()
                                                    ).Equals(
                                                        cellResult.Values.GetValue(3)
                                                    );
                                                cellValue = cellResult.Values.LastOrDefault();
                                            }
                                            cell.Value = colBool ? cellValue : 0;
                                            cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                            cell.ApplyFormatting(cellFormatting);
                                            skip += colBool ? 1 : 0;
                                        }
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.SetFormula(XlFunc.Sum(XlCellRange.FromLTRB(type - 1, row.RowIndex, cell.ColumnIndex - 1, row.RowIndex)));
                                        cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                    }

                                    for (int j = 4; j < rowResult.Values.Count(); j++)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cellValue = rowResult.Values[j];
                                            cell.Value = cellValue;
                                            cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                            cell.ApplyFormatting(cellFormatting);
                                        }
                                    }
                                }
                            }

                            endDataRowForGrandTotal = sheet.DataRange.BottomRight.Column;

                            using (IXlRow row = sheet.CreateRow())
                            {
                                row.SkipCells(type - 2);
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "GRAN TOTAL:";
                                    cell.ApplyFormatting(totalRowFormatting);
                                }

                                for (int j = type - 1; j < endDataRowForGrandTotal; j++)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(j, startDataRowForGrandTotal, j, row.RowIndex - 1), XlSummary.Sum, false));
                                        cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                        cell.ApplyFormatting(totalRowFormatting);
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region Reporte Detallado
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
                            for (int i = 0; i < tableData.ResultSet[0].Rows.Count(); i++)
                            {
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    if (i == 0) { row.SkipCells(type - 1); }

                                    if (i != 0)
                                    {
                                        for (int j = 1; j < type; j++)
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (tableData.ResultSet[4].Rows[j].Values[0]).ToString();
                                                cell.ApplyFormatting(subHeaderRowFormatting);
                                            }
                                        }
                                    }

                                    foreach (SelectStatementResultRow colResult in tableData.ResultSet[1].Rows)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = (colResult.Values[i]).ToString();
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                        }
                                    }

                                    if (i != 0)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Venta Liquido";
                                            cell.ApplyFormatting(subHeaderRowFormatting);
                                        }

                                        for (int j = 4; j < tableData.ResultSet[4].Rows.Count(); j++)
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (tableData.ResultSet[4].Rows[j].Values[0]).ToString();
                                                cell.ApplyFormatting(subHeaderRowFormatting);
                                            }
                                        }
                                    }
                                }
                            }

                            skip = 0;
                            startDataRowForGrandTotal = sheet.CurrentRowIndex;
                            dynamic tempValue;
                            for (int k = 0; k < tableData.ResultSet[5].Rows.Count(); k++)
                            {
                                SelectStatementResultRow rowResult = tableData.ResultSet[5].Rows[k];
                                SelectStatementResultRow rowResultTemp = tableData.ResultSet[5].Rows[k != 0 ? k - 1 : 0];
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    tempValue = k != 0 ? !(new dynamic[] { rowResult.Values[0], rowResult.Values[1] }).SequenceEqual(new dynamic[] { rowResultTemp.Values[0], rowResultTemp.Values[1] }) : true;
                                    for (int i = 1; i < type; i++)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            if (i == 3)
                                            {
                                                cell.Value = DateTime.Parse((rowResult.Values[i]).ToString()).ToString("dd/MM/yyyy");
                                            }
                                            else
                                            {
                                                if (tempValue) { startDataRowForSubTotal = sheet.CurrentRowIndex; };
                                                cell.Value = tempValue ? (rowResult.Values[i]).ToString() : "";
                                            }
                                            cell.ApplyFormatting(cellFormatting);
                                        }
                                    }

                                    foreach (SelectStatementResultRow colResult in tableData.ResultSet[1].Rows)
                                    {
                                        colBool = false;
                                        cellValue = 0;
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            if (skip < tableData.ResultSet[3].Rows.Count())
                                            {
                                                cellResult = tableData.ResultSet[3].Rows[skip];
                                                colBool = (
                                                        rowResult.Values.Where((value, index) => index < type && index != 2).ToList()
                                                    ).SequenceEqual(
                                                        cellResult.Values.Where((value, index) => index < type - 1).ToList()
                                                    )
                                                    &&
                                                    (
                                                        colResult.Values.FirstOrDefault()
                                                    ).Equals(
                                                        cellResult.Values.GetValue(3)
                                                    );
                                                cellValue = cellResult.Values.LastOrDefault();
                                            }
                                            cell.Value = colBool ? cellValue : 0;
                                            cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                            cell.ApplyFormatting(cellFormatting);
                                            skip += colBool ? 1 : 0;
                                        }
                                    }

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.SetFormula(XlFunc.Sum(XlCellRange.FromLTRB(type - 1, row.RowIndex, cell.ColumnIndex - 1, row.RowIndex)));
                                        cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                        cell.ApplyFormatting(cellFormatting);
                                    }

                                    for (int j = 4; j < rowResult.Values.Count(); j++)
                                    {
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cellValue = rowResult.Values[j];
                                            cell.Value = cellValue;
                                            cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                            cell.ApplyFormatting(cellFormatting);
                                        }
                                    }
                                }

                                SelectStatementResultRow rowResultTempSub = tableData.ResultSet[5].Rows[tableData.ResultSet[5].Rows.Count() - 1 > k ? k + 1 : k];
                                tempValue = k != 0 ? !(new dynamic[] { rowResult.Values[0], rowResult.Values[1] }).SequenceEqual(new dynamic[] { rowResultTempSub.Values[0], rowResultTempSub.Values[1] }) : true;

                                if (tempValue)
                                {
                                    endDataRowForGrandTotal = sheet.DataRange.BottomRight.Column;
                                    using (IXlRow row = sheet.CreateRow())
                                    {
                                        row.SkipCells(type - 2);
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "TOTAL:";
                                            cell.ApplyFormatting(totalRowFormatting);
                                        }

                                        for (int j = type - 1; j < endDataRowForGrandTotal; j++)
                                        {
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(j, startDataRowForSubTotal, j, row.RowIndex - 1), XlSummary.Sum, false));
                                                cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                                cell.ApplyFormatting(totalRowFormatting);
                                            }
                                        }
                                    }
                                }
                            }

                            endDataRowForGrandTotal = sheet.DataRange.BottomRight.Column;
                            using (IXlRow row = sheet.CreateRow())
                            {
                                row.SkipCells(type - 2);
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "TOTAL:";
                                    cell.ApplyFormatting(totalRowFormatting);
                                }

                                for (int j = type - 1; j < endDataRowForGrandTotal; j++)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(j, startDataRowForSubTotal, j, row.RowIndex - 1), XlSummary.Sum, false));
                                        cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                        cell.ApplyFormatting(totalRowFormatting);
                                    }
                                }
                            }

                            endDataRowForGrandTotal = sheet.DataRange.BottomRight.Column;

                            using (IXlRow row = sheet.CreateRow())
                            {
                                row.SkipCells(type - 2);
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "GRAN TOTAL:";
                                    cell.ApplyFormatting(totalRowFormatting);
                                }

                                for (int j = type - 1; j < endDataRowForGrandTotal; j++)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(j, startDataRowForGrandTotal, j, row.RowIndex - 1), XlSummary.Sum, false));
                                        cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                        cell.ApplyFormatting(totalRowFormatting);

                                    }
                                }
                            }
                            #endregion
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