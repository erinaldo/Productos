using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class InventarioVentasRIK
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string Fecha;
        private string RUTClave;
        string Clientes;

        public bool GetReport(string Fecha, string RUTClave, string Clientes)
        {
            try
            {
                DateTime dFecha;
                DateTime.TryParse(Fecha, out dFecha);
                DateTime dFechaFiltro = dFecha.Date;
                this.Fecha = dFecha.ToShortDateString();
                this.RUTClave = RUTClave.Replace("'", "");
                this.Clientes = Clientes;

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("declare @Fecha as datetime ");
                sConsulta.AppendLine("declare @RUTClave as varchar(10) ");
                sConsulta.AppendLine("declare @ClienteClave varchar(16) ");
                sConsulta.AppendLine("declare @cursorClientes as cursor ");

                sConsulta.AppendLine("set @Fecha = '" + Fecha + "' ");
                if (Clientes == "") { 
                    sConsulta.AppendLine("set @RUTClave = " + RUTClave + " ");
                    Clientes = "''";
                }
                else
                    sConsulta.AppendLine("set @RUTClave = ''");

                sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisitas')) is not null drop table #tmpVisitas ");
                sConsulta.AppendLine("create Table #tmpVisitas ( ");
                sConsulta.AppendLine("    DiaClave varchar(10) collate SQL_Latin1_General_CP1_CI_AS, ");
                sConsulta.AppendLine("    ClienteClave varchar(16) collate SQL_Latin1_General_CP1_CI_AS) ");

                sConsulta.AppendLine("if @RUTClave <> '' ");
                sConsulta.AppendLine("begin ");
                sConsulta.AppendLine("    set @cursorClientes = cursor scroll dynamic for ");
                sConsulta.AppendLine("    select distinct ClienteClave ");
                sConsulta.AppendLine("    from Secuencia ");
                sConsulta.AppendLine("    where RUTClave = @RUTClave ");
                sConsulta.AppendLine("end ");
                sConsulta.AppendLine("else ");
                sConsulta.AppendLine("begin ");
                sConsulta.AppendLine("    set @cursorClientes = cursor scroll dynamic for ");
                sConsulta.AppendLine("    select ClienteClave from Cliente where ClienteClave in (" + Clientes + ") ");
                sConsulta.AppendLine("end ");

                sConsulta.AppendLine("open @cursorClientes ");
                sConsulta.AppendLine("fetch next from @cursorClientes into @ClienteClave ");
                sConsulta.AppendLine("while @@FETCH_STATUS = 0 ");
                sConsulta.AppendLine("begin ");
                sConsulta.AppendLine("    insert into #tmpVisitas  ");
                sConsulta.AppendLine("	  select top 8 VIS.DiaClave, VIS.ClienteClave ");
                sConsulta.AppendLine("    from Visita VIS ");
                sConsulta.AppendLine("    inner join Dia on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("    where Dia.FechaCaptura <= @Fecha and VIS.ClienteClave = @ClienteClave ");
                sConsulta.AppendLine("    group by Dia.FechaCaptura, VIS.DiaClave, VIS.ClienteClave ");
                sConsulta.AppendLine("    order by Dia.FechaCaptura desc ");
                sConsulta.AppendLine("    fetch next from @cursorClientes into @ClienteClave ");
                sConsulta.AppendLine("end ");
                sConsulta.AppendLine("close @cursorClientes ");
                sConsulta.AppendLine("deallocate @cursorClientes ");

                sConsulta.AppendLine("select CLI.Clave as ClienteClave, CLI.RazonSocial as RazonSocial, Dia.FechaCaptura, PRO.ProductoClave, PRO.Nombre as Nombre, ");
                sConsulta.AppendLine("sum(case when TRP.Tipo = 21 then TPD.Cantidad else 0 end) as INV, ");
                sConsulta.AppendLine("sum(case when TRP.Tipo = 3 and upper(VAV.Grupo) = 'NO VENTA' then TPD.Cantidad else 0 end) as DEV, ");
                sConsulta.AppendLine("sum(case when TRP.Tipo = 3 and upper(VAV.Grupo) = 'VENTA' then TPD.Cantidad else 0 end) as ROT, ");
                sConsulta.AppendLine("sum(case when TRP.Tipo = 1 then TPD.Cantidad else 0 end) as VEN, ");
                sConsulta.AppendLine("sum(case when TRP.Tipo = 1 then TPD.Cantidad * TPD.Precio else 0 end) as Importe ");
                sConsulta.AppendLine("from TransProd TRP ");
                sConsulta.AppendLine("inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join #tmpVisitas TMP on VIS.DiaClave = TMP.DiaClave and VIS.ClienteClave = TMP.ClienteClave ");
                sConsulta.AppendLine("inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("left join VARValor VAV on TPD.TipoMotivo = VAV.VAVClave and VAV.VARCodigo = 'TRPMOT' ");
                sConsulta.AppendLine("where((TRP.Tipo = 21 and TRP.TipoFase = 1) or(TRP.Tipo = 3 and TRP.TipoFase = 1) or(TRP.Tipo = 1 and TRP.TipoFase = 2)) ");
                sConsulta.AppendLine("group by CLI.Clave, CLI.RazonSocial, Dia.FechaCaptura, PRO.ProductoClave, PRO.Nombre ");
                sConsulta.AppendLine("order by CLI.Clave, Dia.FechaCaptura, PRO.ProductoClave ");
                sConsulta.AppendLine("if (select object_id('tempdb..#tmpVisitas')) is not null drop table #tmpVisitas ");
                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<InventarioVentasRIKModel> Datos = Connection.Query<InventarioVentasRIKModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                if (Datos.Count() <= 0)
                    return false;
                else
                {
                    string fileName = GenerarExcel(Datos);
                    DownloadFile.DownloadOpenXML(fileName);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }        

        private string GenerarExcel(List<InventarioVentasRIKModel> Datos)
        {
            string path = ConfigurationManager.AppSettings.Get("pathReportes");
            string fileName = path + @"\InventarioYVentas_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Reporte de Inventario" };
                sheets.Append(sheet);
                workbookPart.Workbook.Save();

                RouteEntities db = new RouteEntities();
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();
                row.Append(MyOpenXML.ConstructCell(((Configuracion)db.Configuracion.First()).NombreEmpresa, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();                
                row.Append(MyOpenXML.ConstructCell(ValorReferencia.ObtenerDescripcion("REPORTEW", "200", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                string sFecha = Fecha.Substring(0, 10);
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFecha", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(sFecha, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRuta", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(RUTClave, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                string sVendedor;
                try
                {
                    sVendedor = db.VenRut.First(x => x.RUTClave == RUTClave && x.TipoEstado == 1).Vendedor.Nombre;
                }
                catch {
                    sVendedor = RUTClave;
                }
                 
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVendedor", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(sVendedor, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                bool primera = true;
                row = new Row();
                for (int i = 0; i < 8; i++)
                {
                    if (primera)
                    {
                        row.Append(
                               MyOpenXML.ConstructCell("", CellValues.String),
                               MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XCodigo", "EM"), CellValues.String),
                               MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XProducto", "EM"), CellValues.String));
                    }
                    row.Append(
                            MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XInventario", "EM"), CellValues.String),
                            MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDevolucion", "EM"), CellValues.String),
                            MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRotacion", "EM"), CellValues.String),
                            MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVenta", "EM"), CellValues.String),
                            MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XImporte", "EM"), CellValues.String));

                    primera = false;
                }//for (int i = 0; i < 8; i++)
                sheetData.AppendChild(row);

                var clientes = Datos.OrderBy(x => x.ClienteClave)
                  .GroupBy(x => x.ClienteClave)
                  .Select(g => g.First())
                  .Select(x => new { x.ClienteClave, x.RazonSocial }).ToList();

                foreach (var cliente in clientes)
                {
                    var fechas = Datos.Where(x => x.ClienteClave == cliente.ClienteClave)
                        .OrderBy(x => x.FechaCaptura)
                        .GroupBy(x => x.FechaCaptura)
                        .Select(x => x.First().FechaCaptura)
                        .ToList();

                    primera = true;
                    row = new Row();
                    foreach (DateTime fecha in fechas)
                    {
                        if (primera)
                        {
                            row.Append(
                                MyOpenXML.ConstructCell("", CellValues.String),
                                MyOpenXML.ConstructCell("", CellValues.String),
                                MyOpenXML.ConstructCell("", CellValues.String));
                        }

                        row.Append(
                            MyOpenXML.ConstructCell(fecha.ToShortDateString(), CellValues.String),
                            MyOpenXML.ConstructCell("", CellValues.String),
                            MyOpenXML.ConstructCell("", CellValues.String),
                            MyOpenXML.ConstructCell("", CellValues.String),
                            MyOpenXML.ConstructCell("", CellValues.String));

                        primera = false;
                    }//foreach (DateTime fecha in fechas)
                    sheetData.AppendChild(row);

                    var productos = Datos.Where(x => x.ClienteClave == cliente.ClienteClave)
                        .OrderBy(x => x.ProductoClave)
                        .GroupBy(x => new { x.ProductoClave })
                        .Select(g => g.First())
                        .Select(x => new { x.ProductoClave, x.Nombre }).ToList();

                    int nCount = 0;
                    foreach (var producto in productos)
                    {
                        row = new Row();
                        if (nCount == 0)
                            row.Append(MyOpenXML.ConstructCell(cliente.ClienteClave, CellValues.String));
                        else if (nCount == 1)
                            row.Append(MyOpenXML.ConstructCell(cliente.RazonSocial, CellValues.String));
                        else
                            row.Append(MyOpenXML.ConstructCell("", CellValues.String));
                        row.Append(
                            MyOpenXML.ConstructCell(producto.ProductoClave, CellValues.String),
                            MyOpenXML.ConstructCell(producto.Nombre, CellValues.String));

                        foreach (DateTime fecha in fechas)
                        {
                            try
                            {
                                InventarioVentasRIKModel movs = Datos.Where(x => x.ClienteClave == cliente.ClienteClave && x.FechaCaptura == fecha && x.ProductoClave == producto.ProductoClave).First();
                                row.Append(
                                    MyOpenXML.ConstructCell(movs.INV.ToString(), CellValues.Number),
                                    MyOpenXML.ConstructCell(movs.DEV.ToString(), CellValues.Number),
                                    MyOpenXML.ConstructCell(movs.ROT.ToString(), CellValues.Number),
                                    MyOpenXML.ConstructCell(movs.VEN.ToString(), CellValues.Number),
                                    MyOpenXML.ConstructCell(movs.Importe.ToString(), CellValues.Number));
                            }
                            catch (Exception)
                            {
                                row.Append(
                                   MyOpenXML.ConstructCell("0", CellValues.Number),
                                   MyOpenXML.ConstructCell("0", CellValues.Number),
                                   MyOpenXML.ConstructCell("0", CellValues.Number),
                                   MyOpenXML.ConstructCell("0", CellValues.Number),
                                   MyOpenXML.ConstructCell("0", CellValues.Number));
                            }
                        }
                        sheetData.AppendChild(row);
                        nCount++;
                    }//foreach (var producto in productos)

                    var sumatoria = from item in Datos
                                    where item.ClienteClave == cliente.ClienteClave
                                    group item by new { FechaCaptura = item.FechaCaptura } into temp
                                    select new
                                    {
                                        FechaCaptura = temp.Key.FechaCaptura,
                                        INV = temp.Sum(c => c.INV),
                                        DEV = temp.Sum(c => c.DEV),
                                        ROT = temp.Sum(c => c.ROT),
                                        VEN = temp.Sum(c => c.VEN),
                                        Importe = temp.Sum(c => c.Importe)
                                    };

                    primera = true;
                    row = new Row();
                    foreach (var suma in sumatoria.OrderBy(x => x.FechaCaptura))
                    {
                        if (primera)
                        {
                            row.Append(
                                MyOpenXML.ConstructCell("", CellValues.String),
                                MyOpenXML.ConstructCell("", CellValues.String),
                                MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTotalPzasPesos", "EM"), CellValues.String));
                        }
                        row.Append(
                            MyOpenXML.ConstructCell(suma.INV.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(suma.DEV.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(suma.ROT.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(suma.VEN.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(suma.Importe.ToString(), CellValues.Number));
                        primera = false;
                    }//foreach (var suma in sumatoria.OrderBy(x => x.FechaCaptura))
                    sheetData.AppendChild(row);

                    row = new Row();
                    sheetData.AppendChild(row);
                }//foreach (var cliente in clientes)

                worksheetPart.Worksheet.Save();                

            }//using
            return fileName;
        }//GenerarExcel      


    }

    class InventarioVentasRIKModel
    {
        public String ClienteClave { get; set; }
        public String RazonSocial { get; set; }
        public DateTime FechaCaptura { get; set; }
        public String ProductoClave { get; set; }
        public String Nombre { get; set; }
        public long INV { get; set; }
        public long DEV { get; set; }
        public long ROT { get; set; }
        public long VEN { get; set; }
        public float Importe { get; set; }
    }
}