using DevExpress.Export.Xl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace eRoute.Models.ReportesModels
{
    public class R057ResumenDeVentasPorRutaYVendedor
    {
        private string[] header;
        private string reportName;
        private SelectedData tableData;

        public bool GetReport(string ReportName, string CompanyName, string CEDISName, string CEDIS, string StartDate, string EndDate)
        {
            string[] parametersArray = { "paramCedis", "paramStartDate", "paramEndDate" };
            string[] listValours = { CEDIS, DateTime.Parse(StartDate).ToString("yyyy-MM-dd"), DateTime.Parse(EndDate).ToString("yyyy-MM-dd") };
            reportName = ReportName;
            header = new string[] { ReportName, CompanyName, "Centro De Distribucion: " + CEDISName, "Fecha: " + (StartDate + (EndDate == StartDate ? "" : " - " + EndDate)) };

            const string queryString =
                @"EXEC [dbo].[stpr_RW057ResumenDeVentasPorRutaYVendedor]
                        @filterCEDIS = @paramCedis,
                        @filterStartDate = @paramStartDate,
                        @filterEndDate = @paramEndDate";

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
            dynamic cellValue;
            double kgValue;
            SelectStatementResultRow cellResult;
            bool colBool;
            int skip;
            int startDataRowForGrandTotal = 0;
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
                                if (i == 0)
                                {
                                    row.SkipCells(2);
                                }

                                if (i != 0)
                                {
                                    for (int j = 1; j < 3; j++)
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

                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = "Kg";
                                        cell.ApplyFormatting(subHeaderRowFormatting);
                                    }

                                    for (int j = 3; j < tableData.ResultSet[4].Rows.Count(); j++)
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
                                for (int i = 1; i < 3; i++)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (rowResult.Values[i]).ToString();
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                }

                                kgValue = 0;
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
                                                    rowResult.Values.Where((value, index) => index < 3 && index != 2).ToList()
                                                ).SequenceEqual(
                                                    cellResult.Values.Where((value, index) => index < 2).ToList()
                                                )
                                                &&
                                                (
                                                    colResult.Values.FirstOrDefault()
                                                ).Equals(
                                                    cellResult.Values.GetValue(2)
                                                );
                                            cellValue = cellResult.Values.LastOrDefault();
                                            kgValue += double.Parse(cellResult.Values[6].ToString());
                                        }
                                        cell.Value = colBool ? cellValue : 0;
                                        cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                        cell.ApplyFormatting(cellFormatting);
                                        skip += colBool ? 1 : 0;
                                    }
                                }

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.SetFormula(XlFunc.Sum(XlCellRange.FromLTRB(2, row.RowIndex, cell.ColumnIndex - 1, row.RowIndex)));
                                    cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                }

                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = kgValue;
                                    cell.Formatting = XlCellFormatting.FromNetFormat("{0:n}", false);
                                }

                                for (int j = 3; j < rowResult.Values.Count(); j++)
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
                            row.SkipCells(1);
                            using (IXlCell cell = row.CreateCell())
                            {
                                cell.Value = "GRAN TOTAL:";
                                cell.ApplyFormatting(totalRowFormatting);
                            }

                            for (int j = 2; j < endDataRowForGrandTotal; j++)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(j, startDataRowForGrandTotal, j, row.RowIndex - 1), XlSummary.Sum, false));
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
    }
}