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
    public class DynamicExcelGenerator
    {
        private string reportName;
        private SelectedData headerData;
        private SelectedData reportData;

        public bool GetReport(string companyName, string reportName, string listObject, string query, string parameters)
        {
            try
            {
                // Campos obtenidos de la DB
                string[] parametersArray = parameters.Split(',');
                string[] listValours = listObject.Split('&');

                this.reportName = reportName;

                GetDataLayer();
                Session session = new Session();
                headerData = session.ExecuteQueryWithMetadata(query, parametersArray, listValours);
                reportData = session.ExecuteQuery(query, parametersArray, listValours);

                if (reportData.ResultSet[0].Rows.Count() > 0)
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
                        sheet.Name = reportName.Length <= 25 ? reportName : reportName.Substring(0, 25);

                        using (IXlRow row = sheet.CreateRow())
                        {
                            foreach (SelectStatementResultRow rowResult in headerData.ResultSet[0].Rows)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = (rowResult.Values[0]).ToString();
                                }
                            }
                        }

                        foreach (SelectStatementResultRow rowResult in reportData.ResultSet[0].Rows)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                foreach (object colResult in rowResult.Values)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (colResult).ToString();
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