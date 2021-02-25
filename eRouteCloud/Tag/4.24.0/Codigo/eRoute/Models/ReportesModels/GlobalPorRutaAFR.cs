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
    public class GlobalPorRutaAFR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string FechaIni;
        private string FechaFin;
        private string Rutas;
        private string NombreReporte;
        private string NombreEmpresa;


        public bool GetReport(string NombreReporte, string NombreEmpresa, string FechaIni, string FechaFin, string Rutas)
        {
            try
            {
                DateTime dFechaIni;
                DateTime.TryParse(FechaIni, out dFechaIni);
                DateTime dFechaFin;
                DateTime.TryParse(FechaFin, out dFechaFin);
                this.FechaIni = dFechaIni.ToShortDateString();
                this.FechaFin = dFechaFin.ToShortDateString();
                this.Rutas = Rutas.Replace("'", "");
                this.NombreReporte = NombreReporte;
                this.NombreEmpresa = NombreEmpresa;
                
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("declare @FechaIni as datetime");
                sConsulta.AppendLine("declare @FechaFin as datetime");

                sConsulta.AppendLine("set @FechaIni = '" + dFechaIni.Date.ToString("s") + "'");
                sConsulta.AppendLine("set @FechaFin = '" + dFechaFin.Date.ToString("s") + "'");
                
                sConsulta.AppendLine("--Ventas ");
                sConsulta.AppendLine("if (select object_id('tempdb..#tmpVentas')) is not null drop table #tmpVentas ");
                sConsulta.AppendLine("select * into #tmpVentas from ( ");
                sConsulta.AppendLine("    select VIS.RUTClave, Dia.FechaCaptura, sum(case when TRP.CFVTipo = 1 then TRP.Total else 0 end) VentasContado, sum(case when TRP.CFVTipo = 2 then TRP.Total else 0 end) VentasCredito ");
                sConsulta.AppendLine("    from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("    inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("    inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("    where TRP.Tipo = 1 and TRP.TipoFase = 2 "); 
                sConsulta.AppendLine("    and Dia.FechaCaptura between @FechaIni and @FechaFin "); 
                sConsulta.AppendLine("    and VIS.RUTClave in (" + Rutas + ") ");
                sConsulta.AppendLine("    group by VIS.RUTClave, Dia.FechaCaptura ");
                sConsulta.AppendLine(") as t ");

                sConsulta.AppendLine("--Descuentos ");
                sConsulta.AppendLine("if (select object_id('tempdb..#tmpDescuentos')) is not null drop table #tmpDescuentos ");
                sConsulta.AppendLine("select * into #tmpDescuentos from ( "); 
                sConsulta.AppendLine("    select t.RUTClave, t.FechaCaptura, sum(t.DescuentoImp + t.DesImporteVen + t.DesImporteCte + ((t.PrecioBase - t.Precio) * t.Cantidad)) as Descuento, ");
                sConsulta.AppendLine("    sum(case when t.CFVTipo = 2 then case when t.DescuentoImp + t.DesImporteVen + t.DesImporteCte > 0 or ListaPrecioBase != PrecioClave then t.Total else 0 end else 0 end) as CreditoConDesc, ");
                sConsulta.AppendLine("    sum(case when t.CFVTipo = 2 then case when t.DescuentoImp + t.DesImporteVen + t.DesImporteCte <= 0 and ListaPrecioBase = PrecioClave then t.Total else 0 end else 0 end) as CreditoSinDesc, ");
                sConsulta.AppendLine("    sum(case when t.CFVTipo = 1 then case when t.DescuentoImp + t.DesImporteVen + t.DesImporteCte > 0 or ListaPrecioBase != PrecioClave then t.Total else 0 end else 0 end) as VentasConDesc, ");
                sConsulta.AppendLine("    sum(case when t.CFVTipo = 1 then case when t.DescuentoImp + t.DesImporteVen + t.DesImporteCte <= 0 and ListaPrecioBase = PrecioClave then t.Total else 0 end else 0 end) as VentasSinDesc ");                
                sConsulta.AppendLine("    from ( ");
                sConsulta.AppendLine("    select VIS.RUTClave, Dia.FechaCaptura, TRP.CFVTipo, TPD.Cantidad, TPD.Precio, isnull(TPD.DescuentoImp, 0) as DescuentoImp, TPD.Total, isnull(TDV.DesImporte, 0) as DesImporteVen, "); 
                sConsulta.AppendLine("    (select isnull(sum(DesImporte), 0) from TpdDes TDS (NOLOCK) where TDS.TransProdId = TPD.TransProdID and TDS.TransProdDetalleId = TPD.TransProdDetalleID) as DesImporteCte, ");
                sConsulta.AppendLine("    case when VEN.ListaPrecioBase is null then TPD.Precio else dbo.FNObtenerPrecio(VEN.ListaPrecioBase, TPD.ProductoClave, TPD.TipoUnidad, TRP.FechaCaptura) end as PrecioBase, ");
                sConsulta.AppendLine("    isnull(VEN.ListaPrecioBase, '') as ListaPrecioBase, TDE.PrecioClave ");
                sConsulta.AppendLine("    from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("    inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave "); 
                sConsulta.AppendLine("    inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("    inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("    inner join TPDDatosExtra TDE (NOLOCK) on TPD.TransProdID = TDE.TransProdID and TPD.TransProdDetalleID = TDE.TransProdDetalleID ");
                sConsulta.AppendLine("    left join TPDDesVendedor TDV (NOLOCK) on TPD.TransProdID = TDV.TransProdId and TPD.TransProdDetalleID = TDV.TransProdDetalleId ");
                sConsulta.AppendLine("    inner join Vendedor VEN (NOLOCK) on VIS.VendedorID = VEN.VendedorID ");
                sConsulta.AppendLine("    where TRP.Tipo = 1 and TRP.TipoFase = 2 "); 
                sConsulta.AppendLine("    and Dia.FechaCaptura between @FechaIni and @FechaFin "); 
                sConsulta.AppendLine("    and VIS.RUTClave in (" + Rutas + ") ");
                sConsulta.AppendLine("    ) as t ");
                sConsulta.AppendLine("    group by t.RUTClave, t.FechaCaptura ");
                sConsulta.AppendLine(") as t1 "); 

                sConsulta.AppendLine("--Abonos ");
                sConsulta.AppendLine("if (select object_id('tempdb..#tmpAbonos')) is not null drop table #tmpAbonos ");
                sConsulta.AppendLine("select * into #tmpAbonos from ( "); 
                sConsulta.AppendLine("    select VIS.RUTClave, Dia.FechaCaptura, sum(ABT.Importe) as Importe ");
                sConsulta.AppendLine("    from Abono ABN (NOLOCK) ");
                sConsulta.AppendLine("    inner join Visita VIS (NOLOCK) on ABN.VisitaClave = VIS.VisitaClave and ABN.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("    inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("    inner join AbnTrp ABT (NOLOCK) on ABN.ABNId = ABT.ABNId ");
                sConsulta.AppendLine("    inner join TransProd TRP (NOLOCK) on ABT.TransProdID = TRP.TransProdID ");
                sConsulta.AppendLine("    where Dia.FechaCaptura between @FechaIni and @FechaFin and TRP.CFVTipo = 2 ");
                sConsulta.AppendLine("    and VIS.RUTClave in (" + Rutas + ") ");
                sConsulta.AppendLine("    group by VIS.RUTClave, Dia.FechaCaptura ");
                sConsulta.AppendLine(") as t ");

                sConsulta.AppendLine("--Devoluciones "); 
                sConsulta.AppendLine("if (select object_id('tempdb..#tmpDevoluciones')) is not null drop table #tmpDevoluciones ");
                sConsulta.AppendLine("select * into #tmpDevoluciones from ( "); 
                sConsulta.AppendLine("    select VRT.RUTClave, Dia.FechaCaptura, sum(TRP.Total) as Total ");
                sConsulta.AppendLine("    from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("    inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("    inner join Vendedor VEN (NOLOCK) on TRP.MUsuarioID = VEN.USUId ");
                sConsulta.AppendLine("    inner join VenRut VRT (NOLOCK) on VEN.VendedorID = VRT.VendedorID ");
                sConsulta.AppendLine("    where TRP.Tipo = 4 and TRP.TipoFase = 1 "); 
                sConsulta.AppendLine("    and Dia.FechaCaptura between @FechaIni and @FechaFin "); 
                sConsulta.AppendLine("    and VRT.RUTClave in (" + Rutas + ") ");
                sConsulta.AppendLine("    group by VRT.RUTClave, Dia.FechaCaptura ");
                sConsulta.AppendLine(") as t ");

                sConsulta.AppendLine("select vta.RUTClave, vta.FechaCaptura, vta.VentasContado, vta.VentasCredito, isnull(dsc.Descuento, 0) as Descuento, "); 
                sConsulta.AppendLine("isnull(dsc.VentasConDesc, 0) as VentasConDesc, isnull(dsc.VentasSinDesc, 0) as VentasSinDesc, isnull(dsc.CreditoConDesc, 0) as CreditoConDesc, "); 
                sConsulta.AppendLine("isnull(dsc.CreditoSinDesc, 0) as CreditoSinDesc, isnull(abn.Importe, 0) as CobranzaCredito, isnull(dev.Total, 0) as Perdida ");
                sConsulta.AppendLine("from #tmpVentas vta ");
                sConsulta.AppendLine("left join #tmpDescuentos dsc on vta.RUTClave = dsc.RUTClave and vta.FechaCaptura = dsc.FechaCaptura ");
                sConsulta.AppendLine("left join #tmpAbonos abn on vta.RUTClave = abn.RUTClave and vta.FechaCaptura = abn.FechaCaptura ");
                sConsulta.AppendLine("left join #tmpDevoluciones dev on vta.RUTClave = dev.RUTClave and vta.FechaCaptura = dev.FechaCaptura ");
                sConsulta.AppendLine("order by vta.RUTClave, vta.FechaCaptura ");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<GlobalPorRutaAFRModel> Datos = Connection.Query<GlobalPorRutaAFRModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                if (Datos.Count() <= 0)
                    return false;
                else
                {
                    ArchivoXlsModel file = GenerarExcel(Datos); 
                    DownloadFile.DownloadOpenXML(file);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }                
       
        private ArchivoXlsModel GenerarExcel(List<GlobalPorRutaAFRModel> Datos)
        {            
            string fileName = NombreReporte + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))            
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = NombreReporte};
                sheets.Append(sheet);
                workbookPart.Workbook.Save();

                RouteEntities db = new RouteEntities();
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();
                row.Append(MyOpenXML.ConstructCell(((Configuracion)db.Configuracion.First()).NombreEmpresa, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(MyOpenXML.ConstructCell(NombreReporte, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                string sFecha = FechaIni + " al " + FechaFin;
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFecha", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(sFecha, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRuta", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Rutas, CellValues.String));
                sheetData.AppendChild(row);                

                row = new Row();
                sheetData.AppendChild(row);
                                
                row = new Row();
                row.Append(                    
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFecha", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVentasTotales", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVentas", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDescuentos", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XCreditos", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XCreditosConDescuento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XCreditosSinDescuento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XCreditosPagados", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVentasConDescuento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVentasSinDescuento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPerdidas", "EM"), CellValues.String));
                sheetData.AppendChild(row);                

                float totalVentasTotales = 0;
                float totalVentas = 0;
                float totalDescuentos = 0;
                float totalCreditos = 0;
                float totalCreditosConDesc = 0;
                float totalCreditosSinDesc = 0;
                float totalCreditosPagados = 0;
                float totalVentasConDesc = 0;
                float totalVentasSinDesc = 0;
                float totalPerdidas = 0;
                int max = Datos.ToList().Count;
                int count = 0;
                bool ultima = false;

                string sRuta = "";
                foreach (var dato in Datos)
                {
                    ultima = false;
                    if (!sRuta.Equals("") && !sRuta.Equals(dato.RUTClave))
                    {
                        row = new Row();
                        row.Append(
                            MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTotal", "EM"), CellValues.String),
                            MyOpenXML.ConstructCell(totalVentasTotales.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalVentas.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalDescuentos.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalCreditos.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalCreditosConDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalCreditosSinDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalCreditosPagados.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalVentasConDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalVentasSinDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(totalPerdidas.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(Math.Round((totalPerdidas / totalVentas) * 100).ToString() + "%", CellValues.String)
                        );
                        sheetData.AppendChild(row);

                        row = new Row();
                        sheetData.AppendChild(row);

                        totalVentasTotales = 0;
                        totalVentas = 0;
                        totalDescuentos = 0;
                        totalCreditos = 0;
                        totalCreditosConDesc = 0;
                        totalCreditosSinDesc = 0;
                        totalCreditosPagados = 0;
                        totalVentasConDesc = 0;
                        totalVentasSinDesc = 0;
                        totalPerdidas = 0;
                    }                    

                    if (!sRuta.Equals(dato.RUTClave)) {
                        row = new Row();
                        row.Append(
                            MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRuta", "EM") + ": " + dato.RUTClave, CellValues.String));
                        sheetData.AppendChild(row);
                    }

                    if (count < max - 1)
                    {
                        GlobalPorRutaAFRModel siguiente;
                        Datos.TryGetValue(count + 1, out siguiente);
                        ultima = (!siguiente.RUTClave.Equals(dato.RUTClave));
                        count += 1;
                    }
                    else if (count == max - 1)
                        ultima = true;

                    row = new Row();
                    if (ultima) {
                        row.Append(
                            MyOpenXML.ConstructCell(dato.FechaCaptura.ToShortDateString(), CellValues.String),
                            MyOpenXML.ConstructCell((dato.VentasContado + dato.Descuento + dato.VentasCredito - dato.CobranzaCredito).ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.VentasContado.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.Descuento.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.VentasCredito.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.CreditoConDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.CreditoSinDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.CobranzaCredito.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.VentasConDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.VentasSinDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.Perdida.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPorcPerdida", "EM"), CellValues.String)
                        );
                    }
                    else {
                        row.Append(
                            MyOpenXML.ConstructCell(dato.FechaCaptura.ToShortDateString(), CellValues.String),
                            MyOpenXML.ConstructCell((dato.VentasContado + dato.Descuento + dato.VentasCredito - dato.CobranzaCredito).ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.VentasContado.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.Descuento.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.VentasCredito.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.CreditoConDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.CreditoSinDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.CobranzaCredito.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.VentasConDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.VentasSinDesc.ToString(), CellValues.Number),
                            MyOpenXML.ConstructCell(dato.Perdida.ToString(), CellValues.Number)
                        );
                    }                    
                    sheetData.AppendChild(row);

                    totalVentasTotales += dato.VentasContado + dato.Descuento + dato.VentasCredito - dato.CobranzaCredito;
                    totalVentas += dato.VentasContado;
                    totalDescuentos += dato.Descuento;
                    totalCreditos += dato.VentasCredito;
                    totalCreditosConDesc += dato.CreditoConDesc;
                    totalCreditosSinDesc += dato.CreditoSinDesc;
                    totalCreditosPagados += dato.CobranzaCredito;
                    totalVentasConDesc += dato.VentasConDesc;
                    totalVentasSinDesc += dato.VentasSinDesc;
                    totalPerdidas += dato.Perdida;
                    sRuta = dato.RUTClave;
                }

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTotal", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(totalVentasTotales.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalVentas.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalDescuentos.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalCreditos.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalCreditosConDesc.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalCreditosSinDesc.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalCreditosPagados.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalVentasConDesc.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalVentasSinDesc.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(totalPerdidas.ToString(), CellValues.Number),
                    MyOpenXML.ConstructCell(Math.Round((totalPerdidas / totalVentas) * 100).ToString() + "%", CellValues.String)
                );
                sheetData.AppendChild(row);

                worksheetPart.Worksheet.Save();

            }//using
            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
            //return fileName;
        }//GenerarExcel        
    }

    class GlobalPorRutaAFRModel
    {
        public String RUTClave { get; set; }
        public DateTime FechaCaptura { get; set; }
        public float VentasContado { get; set; }
        public float VentasCredito { get; set; }
        public float Descuento { get; set; }
        public float VentasConDesc { get; set; }
        public float VentasSinDesc { get; set; }
        public float CreditoConDesc { get; set; }
        public float CreditoSinDesc { get; set; }
        public float CobranzaCredito { get; set; }
        public float Perdida { get; set; }
    }    
}