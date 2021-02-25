using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class ConcentradoMovAlmacenALT
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public bool GetReport(string NombreReporte, string NombreEmpresa, int Reporte, string Fecha)
        {
            DateTime dFecha;
            DateTime.TryParse(Fecha, out dFecha);

            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("declare @fecha as datetime ");
            sConsulta.AppendLine("set @fecha = '" + dFecha.ToString("s") + "'");
            sConsulta.AppendLine("exec sp_ObtenerMovAlmacenConcentrado @fecha ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            List<MovAlmacenALTModel> MovAlmacen = Connection.Query<MovAlmacenALTModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            sConsulta.Clear();
            sConsulta.AppendLine("declare @fecha as datetime ");
            sConsulta.AppendLine("set @fecha = '" + dFecha.ToString("s") + "'");
            sConsulta.AppendLine("exec sp_ObtenerMovRutaTepatitlan @fecha ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            List<MovAlmacenALTModel> MovRuta1 = Connection.Query<MovAlmacenALTModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            sConsulta.Clear();
            sConsulta.AppendLine("declare @fecha as datetime ");
            sConsulta.AppendLine("set @fecha = '" + dFecha.ToString("s") + "'");
            sConsulta.AppendLine("exec sp_ObtenerMovRutaArandas @fecha ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            List<MovAlmacenALTModel> MovRuta2 = Connection.Query<MovAlmacenALTModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            sConsulta.Clear();
            sConsulta.AppendLine("declare @fecha as datetime ");
            sConsulta.AppendLine("set @fecha = '" + dFecha.ToString("s") + "'");
            sConsulta.AppendLine("exec sp_ObtenerMovRutaAtotonilco @fecha ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            List<MovAlmacenALTModel> MovRuta3 = Connection.Query<MovAlmacenALTModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            sConsulta.Clear();
            sConsulta.AppendLine("declare @fecha as datetime ");
            sConsulta.AppendLine("set @fecha = '" + dFecha.ToString("s") + "'");
            sConsulta.AppendLine("exec sp_ObtenerMovRutaYahualica @fecha ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            List<MovAlmacenALTModel> MovRuta4 = Connection.Query<MovAlmacenALTModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            List<MovAlmacenALTModel> MovRuta = MovRuta1.Union(MovRuta2).Union(MovRuta3).Union(MovRuta4).ToList();

            sConsulta.Clear();
            sConsulta.AppendLine("declare @fecha as datetime ");
            sConsulta.AppendLine("set @fecha = '" + dFecha.ToString("s") + "'");
            sConsulta.AppendLine("exec sp_ObtenerMovConsignaConcentrado @fecha ");

            QueryString = sConsulta.ToString();
            Connection.Open();
            List<MovAlmacenALTModel> MovConsigna = Connection.Query<MovAlmacenALTModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            if (MovAlmacen.Count() <= 0)
                return false;
            else
            {
                ArchivoXlsModel file = GenerarExcel(MovAlmacen, MovRuta, MovConsigna, dFecha.ToShortDateString());
                DownloadFile.DownloadOpenXML(file);
            }
            return true;
        }

        private ArchivoXlsModel GenerarExcel(List<MovAlmacenALTModel> MovAlmacen, List<MovAlmacenALTModel> MovRuta, List<MovAlmacenALTModel> MovConsigna, string Fecha)
        {
            string fileName = "ConcentradoMovAlmacen_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Concentrado" };
            sheets.Append(sheet);

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            Dictionary<int, Row> Rows = new Dictionary<int, Row>();
            Dictionary<string, float> totalesAlmacen = new Dictionary<string, float>();
            Dictionary<string, float> totalesRuta = new Dictionary<string, float>();
            Dictionary<string, float> totalesConsigna = new Dictionary<string, float>();
            Dictionary<int, string> tiposMov = new Dictionary<int, string>();

            MyOpenXML.createRow(1, ref Rows);
            MyOpenXML.createCell(1, ref Rows, "A1", CellValues.String, "FECHA");
            MyOpenXML.createCell(1, ref Rows, "B1", CellValues.String, Fecha);

            MyOpenXML.createRow(2, ref Rows);
            MyOpenXML.createCell(2, ref Rows, "D2", CellValues.String, "INVENTARIO CERVEZA");
            MyOpenXML.createCell(2, ref Rows, "K2", CellValues.String, "INVENTARIO NESTLE");
            MyOpenXML.createCell(2, ref Rows, "R2", CellValues.String, "INVENTARIO BEERHOUSE");

            MyOpenXML.createRow(4, ref Rows);
            MyOpenXML.createCell(4, ref Rows, "D4", CellValues.String, "LOGISTICO");
            MyOpenXML.createCell(4, ref Rows, "E4", CellValues.String, "TEPATITLAN");
            MyOpenXML.createCell(4, ref Rows, "F4", CellValues.String, "ARANDAS");
            MyOpenXML.createCell(4, ref Rows, "G4", CellValues.String, "ATOTONILCO");
            MyOpenXML.createCell(4, ref Rows, "H4", CellValues.String, "YAHUALICA");
            MyOpenXML.createCell(4, ref Rows, "I4", CellValues.String, "TOTAL");

            MyOpenXML.createCell(4, ref Rows, "K4", CellValues.String, "LOGISTICO");
            MyOpenXML.createCell(4, ref Rows, "L4", CellValues.String, "TEPATITLAN");
            MyOpenXML.createCell(4, ref Rows, "M4", CellValues.String, "ARANDAS");
            MyOpenXML.createCell(4, ref Rows, "N4", CellValues.String, "ATOTONILCO");
            MyOpenXML.createCell(4, ref Rows, "O4", CellValues.String, "YAHUALICA");
            MyOpenXML.createCell(4, ref Rows, "P4", CellValues.String, "TOTAL");

            MyOpenXML.createCell(4, ref Rows, "R4", CellValues.String, "LOGISTICO");
            MyOpenXML.createCell(4, ref Rows, "S4", CellValues.String, "TEPATITLAN");
            MyOpenXML.createCell(4, ref Rows, "T4", CellValues.String, "ARANDAS");
            MyOpenXML.createCell(4, ref Rows, "U4", CellValues.String, "ATOTONILCO");
            MyOpenXML.createCell(4, ref Rows, "V4", CellValues.String, "YAHUALICA");
            MyOpenXML.createCell(4, ref Rows, "W4", CellValues.String, "TOTAL");

            //ALMACENES
            MyOpenXML.createRow(6, ref Rows);
            MyOpenXML.createCell(6, ref Rows, "A6", CellValues.String, "ALMACENES");

            MyOpenXML.createRow(8, ref Rows);
            MyOpenXML.createCell(8, ref Rows, "A8", CellValues.String, "INVENTARIO INICIAL ALMACEN");
            tiposMov.Add(0, "");
            ImprimirMovimientos(ref Rows, MovAlmacen, tiposMov, 8, "", true, ref totalesAlmacen);

            MyOpenXML.createRow(10, ref Rows);
            MyOpenXML.createCell(10, ref Rows, "B10", CellValues.String, "ENTRADAS");
            tiposMov.Clear();
            tiposMov.Add(1, "COMPRAS A FABRICA");
            tiposMov.Add(7, "DEVOLUCIONES DE RUTA");
            tiposMov.Add(38, "TRASPASOS CEDIS TEPATITLAN");
            tiposMov.Add(54, "TRASPASOS CENTRO LOGISTICO");
            tiposMov.Add(31, "AJUSTES");
            ImprimirMovimientos(ref Rows, MovAlmacen, tiposMov, 12, "TOTAL ENTRADAS", true, ref totalesAlmacen);

            MyOpenXML.createRow(20, ref Rows);
            MyOpenXML.createCell(20, ref Rows, "B20", CellValues.String, "SALIDAS");
            tiposMov.Clear();
            tiposMov.Add(2, "PEDIDOS RUTAS");
            tiposMov.Add(39, "TRASPASOS CEDIS TEPATITLAN");
            tiposMov.Add(47, "TRASPASOS CEDIS ARANDAS");
            tiposMov.Add(43, "TRASPASOS CEDIS ATOTONILCO");
            tiposMov.Add(51, "TRASPASOS CEDIS YAHUALICA");
            tiposMov.Add(22, "MERMAS");
            tiposMov.Add(32, "AJUSTES");
            ImprimirMovimientos(ref Rows, MovAlmacen, tiposMov, 22, "TOTAL SALIDAS", false, ref totalesAlmacen);

            MyOpenXML.createRow(32, ref Rows);
            MyOpenXML.createCell(32, ref Rows, "A32", CellValues.String, "INVENTARIO FINAL ALMACEN");
            ImprimeTotales(ref Rows, totalesAlmacen, 32);

            //RUTAS
            MyOpenXML.createRow(35, ref Rows);
            MyOpenXML.createCell(35, ref Rows, "A35", CellValues.String, "CARGA DE RUTAS");

            MyOpenXML.createRow(37, ref Rows);
            MyOpenXML.createCell(37, ref Rows, "A37", CellValues.String, "INVENTARIO INICIAL RUTAS");
            tiposMov.Clear();
            tiposMov.Add(1, "");
            ImprimirMovimientos(ref Rows, MovRuta, tiposMov, 37, "", true, ref totalesRuta);

            MyOpenXML.createRow(39, ref Rows);
            MyOpenXML.createCell(39, ref Rows, "B39", CellValues.String, "ENTRADAS");
            tiposMov.Clear();
            tiposMov.Add(2, "PEDIDOS RUTAS");
            tiposMov.Add(3, "DEVOLUCION DE CONSIGA PARA VENTA");
            tiposMov.Add(4, "DEVOLUCIONES DE CONSIGNA DE CLIENTES");
            ImprimirMovimientos(ref Rows, MovRuta, tiposMov, 41, "TOTAL ENTRADAS", true, ref totalesRuta);

            MyOpenXML.createRow(47, ref Rows);
            MyOpenXML.createCell(47, ref Rows, "B47", CellValues.String, "SALIDAS");
            tiposMov.Clear();
            tiposMov.Add(5, "VENTAS DIRECTAS");
            tiposMov.Add(6, "VENTAS POR CONSIGNA COBRADA");
            tiposMov.Add(7, "CONSIGNAS A CLIENTES");
            tiposMov.Add(8, "DEVOLUCION A ALMACEN");

            ImprimirMovimientos(ref Rows, MovRuta, tiposMov, 49, "TOTAL SALIDAS", false, ref totalesRuta);

            MyOpenXML.createRow(56, ref Rows);
            MyOpenXML.createCell(56, ref Rows, "A56", CellValues.String, "INVENTARIO FINAL RUTAS");
            ImprimeTotales(ref Rows, totalesRuta, 56);

            //CONSIGNAS A CLIENTES
            MyOpenXML.createRow(58, ref Rows);
            MyOpenXML.createCell(58, ref Rows, "A58", CellValues.String, "CONSIGNAS A CLIENTES");

            MyOpenXML.createRow(60, ref Rows);
            MyOpenXML.createCell(60, ref Rows, "A60", CellValues.String, "INVENTARIO INICIAL DE CONSIGNAS");
            tiposMov.Clear();
            tiposMov.Add(1, "");
            ImprimirMovimientos(ref Rows, MovConsigna, tiposMov, 60, "", true, ref totalesConsigna);

            MyOpenXML.createRow(62, ref Rows);
            MyOpenXML.createCell(62, ref Rows, "B62", CellValues.String, "ENTRADAS");
            tiposMov.Clear();
            tiposMov.Add(2, "CONSIGNAS A CLIENTES");
            ImprimirMovimientos(ref Rows, MovConsigna, tiposMov, 64, "", true, ref totalesConsigna);

            MyOpenXML.createRow(66, ref Rows);
            MyOpenXML.createCell(66, ref Rows, "B66", CellValues.String, "SALIDAS");
            tiposMov.Clear();
            tiposMov.Add(3, "CONSIGNAS COBRADAS");
            tiposMov.Add(4, "DEVOLUCIONES DE CLIENTES A RUTA");

            ImprimirMovimientos(ref Rows, MovConsigna, tiposMov, 68, "", false, ref totalesConsigna);

            MyOpenXML.createRow(71, ref Rows);
            MyOpenXML.createCell(71, ref Rows, "A71", CellValues.String, "INVENTARIO FINAL DE CONSIGNAS");
            ImprimeTotales(ref Rows, totalesConsigna, 71);

            MyOpenXML.createRow(74, ref Rows);
            MyOpenXML.createCell(74, ref Rows, "A74", CellValues.String, "INVENTARIO TOTAL");

            float total = 0;
            List<string> columnas = totalesAlmacen.Keys.ToList();
            columnas.Sort();
            foreach (string col in columnas)
            {
                total = totalesAlmacen[col];
                if (totalesRuta.ContainsKey(col))
                    total += totalesRuta[col];
                if (totalesConsigna.ContainsKey(col))
                    total += totalesConsigna[col];
                MyOpenXML.createCell(72, ref Rows, col + "74", CellValues.Number, total.ToString());
            }

            foreach (var row in Rows)
            {
                sheetData.Append(row.Value);
            }

            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;

            workbookPart.Workbook.Save();

            // Close the document.
            document.Close();

            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
        }//GenerarExcel

        private void ImprimirMovimientos(ref Dictionary<int, Row> Rows, List<MovAlmacenALTModel> MovAlmacen, Dictionary<int, string> tiposMov, int nRow, string leyendaTotales, bool entrada, ref Dictionary<string, float> totalesSeccion)
        {
            Dictionary<string, float> totales = new Dictionary<string, float>();
            float total = 0;
            foreach (int tipoMov in tiposMov.Keys)
            {
                if (!Rows.ContainsKey(nRow))
                    MyOpenXML.createRow(nRow, ref Rows);

                if (!tiposMov[tipoMov].Equals(""))
                    MyOpenXML.createCell(nRow, ref Rows, "C" + nRow.ToString(), CellValues.String, tiposMov[tipoMov]);

                var totalMarca = MovAlmacen
                     .Where(x => x.Tipo == tipoMov)
                     .GroupBy(x => x.Marca)
                     .Select(x => new
                     {
                         Marca = x.First().Marca,
                         Total = x.Sum(y => y.Cantidad)
                     })
                     .ToList();

                //CERVEZA
                var movAlmacen = MovAlmacen.Where(x => x.Tipo == tipoMov && x.Marca.Equals("CERVEZA")).Select(x => new { x.Cedis, x.Cantidad }).OrderBy(x => x.Cedis); //.OrderBy(x => x.Marca);               
                foreach (var oMov in movAlmacen)
                {
                    switch (oMov.Cedis)
                    {
                        case 0: //Logistico                         
                            MyOpenXML.createCell(nRow, ref Rows, "D" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "D", oMov.Cantidad, true);
                            break;
                        case 1: //Tepatitlan                            
                            MyOpenXML.createCell(nRow, ref Rows, "E" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "E", oMov.Cantidad, true);
                            break;
                        case 2: //Arandas                            
                            MyOpenXML.createCell(nRow, ref Rows, "F" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "F", oMov.Cantidad, true);
                            break;
                        case 3: //Atotonilco                            
                            MyOpenXML.createCell(nRow, ref Rows, "G" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "G", oMov.Cantidad, true);
                            break;
                        case 4: //Yahualica                            
                            MyOpenXML.createCell(nRow, ref Rows, "H" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "H", oMov.Cantidad, true);
                            break;
                    }
                }
                if (totalMarca.Where(x => x.Marca == "CERVEZA").ToList().Count > 0)
                {
                    total = totalMarca.Where(x => x.Marca == "CERVEZA").ToList()[0].Total;
                    MyOpenXML.createCell(nRow, ref Rows, "I" + nRow.ToString(), CellValues.Number, total.ToString());
                    AcumulaTotales(ref totales, "I", total, true);
                }

                //NESTLE
                movAlmacen = MovAlmacen.Where(x => x.Tipo == tipoMov && x.Marca.Equals("NESTLE")).Select(x => new { x.Cedis, x.Cantidad }).OrderBy(x => x.Cedis); //.OrderBy(x => x.Marca);               
                foreach (var oMov in movAlmacen)
                {
                    switch (oMov.Cedis)
                    {
                        case 0: //Logistico                            
                            MyOpenXML.createCell(nRow, ref Rows, "K" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "K", oMov.Cantidad, true);
                            break;
                        case 1: //Tepatitlan                            
                            MyOpenXML.createCell(nRow, ref Rows, "L" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "L", oMov.Cantidad, true);
                            break;
                        case 2:  //Arandas
                            MyOpenXML.createCell(nRow, ref Rows, "M" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "M", oMov.Cantidad, true);
                            break;
                        case 3: //Atotonilco
                            MyOpenXML.createCell(nRow, ref Rows, "N" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "N", oMov.Cantidad, true);
                            break;
                        case 4:  //Yahualica
                            MyOpenXML.createCell(nRow, ref Rows, "O" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "O", oMov.Cantidad, true);
                            break;

                    }
                }
                if (totalMarca.Where(x => x.Marca == "NESTLE").ToList().Count > 0)
                {
                    total = totalMarca.Where(x => x.Marca == "NESTLE").ToList()[0].Total;
                    MyOpenXML.createCell(nRow, ref Rows, "P" + nRow.ToString(), CellValues.Number, total.ToString());
                    AcumulaTotales(ref totales, "P", total, true);
                }

                //BEERHOUSE
                movAlmacen = MovAlmacen.Where(x => x.Tipo == tipoMov && x.Marca.Equals("BEERHOUSE")).Select(x => new { x.Cedis, x.Cantidad }).OrderBy(x => x.Cedis); //.OrderBy(x => x.Marca);               
                foreach (var oMov in movAlmacen)
                {
                    switch (oMov.Cedis)
                    {
                        case 0: //Logistico
                            MyOpenXML.createCell(nRow, ref Rows, "R" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "R", oMov.Cantidad, true);
                            break;
                        case 1: //Tepatitlan
                            MyOpenXML.createCell(nRow, ref Rows, "S" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "S", oMov.Cantidad, true);
                            break;
                        case 2: //Arandas
                            MyOpenXML.createCell(nRow, ref Rows, "T" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "T", oMov.Cantidad, true);
                            break;
                        case 3: //Atotonilco
                            MyOpenXML.createCell(nRow, ref Rows, "U" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "U", oMov.Cantidad, true);
                            break;
                        case 4: //Yahualica
                            MyOpenXML.createCell(nRow, ref Rows, "V" + nRow.ToString(), CellValues.Number, oMov.Cantidad.ToString());
                            AcumulaTotales(ref totales, "V", oMov.Cantidad, true);
                            break;
                    }
                }
                if (totalMarca.Where(x => x.Marca == "BEERHOUSE").ToList().Count > 0)
                {
                    total = totalMarca.Where(x => x.Marca == "BEERHOUSE").ToList()[0].Total;
                    MyOpenXML.createCell(nRow, ref Rows, "W" + nRow.ToString(), CellValues.Number, total.ToString());
                    AcumulaTotales(ref totales, "W", total, true);
                }

                nRow++;
            }

            if (!leyendaTotales.Equals(""))
            {
                nRow++;

                MyOpenXML.createRow(nRow, ref Rows);
                MyOpenXML.createCell(nRow, ref Rows, "C" + nRow.ToString(), CellValues.String, leyendaTotales);

                ImprimeTotales(ref Rows, totales, nRow);
            }

            foreach (string col in totales.Keys)
            {
                AcumulaTotales(ref totalesSeccion, col, totales[col], entrada);
            }
        }

        private void AcumulaTotales(ref Dictionary<string, float> totales, string letra, float cantidad, bool entrada)
        {
            if (totales.ContainsKey(letra))
                totales[letra] = totales[letra] + (entrada ? cantidad : -cantidad);
            else
                totales.Add(letra, (entrada ? cantidad : -cantidad));
        }

        private void ImprimeTotales(ref Dictionary<int, Row> Rows, Dictionary<string, float> totales, int nRow)
        {
            List<string> columnas = totales.Keys.ToList();
            columnas.Sort();
            foreach (string col in columnas)
            {
                MyOpenXML.createCell(nRow, ref Rows, col + nRow.ToString(), CellValues.Number, totales[col].ToString());
            }
        }
    }


    class MovAlmacenALTModel
    {
        public Int64 Cedis { get; set; }
        public Int64 Tipo { get; set; }
        public string Marca { get; set; }
        public float Cantidad { get; set; }
    }


}