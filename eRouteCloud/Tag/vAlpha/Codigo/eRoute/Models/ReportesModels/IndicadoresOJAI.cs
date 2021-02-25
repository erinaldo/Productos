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
    public class IndicadoresOJAI
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string sAlmacenNombre;
        private string NombreReporte;
        private string NombreEmpresa;
        private bool bDetallado;
        private int nObjetivoVentaMensualCajas;
        private int nObjetivoVisitasEfectivas;

        private List<IndicadoresRuta> lstIndicadoresRuta;
        private List<IndicadoresRutaDetalle> lstIndicadoresRutaDet;
        private List<IndicadoresRutaGeneral> lstIndicadoresRutaGral;

        public bool GetReport(string NombreReporte, string NombreEmpresa, string AlmacenNombre, string Fecha, string RUTClave, bool Detallado, int ObjetivoVentaMensualCajas, int ObjetivoVisitasEfectivas)
        {
            try
            {
                this.NombreReporte = NombreReporte;
                this.NombreEmpresa = NombreEmpresa;
                DateTime dFecha;
                DateTime.TryParse(Fecha, out dFecha);
                //DateTime dFechaIni = dFecha.Date;

                sAlmacenNombre = AlmacenNombre;
                bDetallado = Detallado;
                nObjetivoVentaMensualCajas = ObjetivoVentaMensualCajas;
                nObjetivoVisitasEfectivas = ObjetivoVisitasEfectivas;

                StringBuilder sConsultaVar = new StringBuilder();
                sConsultaVar.AppendLine("declare @Detallado as bit");
                sConsultaVar.AppendLine("declare @RUTClave as varchar(10)");
                sConsultaVar.AppendLine("declare @Fecha as datetime");

                sConsultaVar.AppendLine("declare @FechaIni as datetime");
                sConsultaVar.AppendLine("declare @FechaFin as datetime");

                sConsultaVar.AppendLine("set @Detallado = " + (Detallado ? "1" : "0"));
                sConsultaVar.AppendLine("set @RUTClave = " + RUTClave);
                sConsultaVar.AppendLine("set @Fecha = '" + dFecha.ToString("s") + "'");

                sConsultaVar.AppendLine("set datefirst 1");

                sConsultaVar.AppendLine("if @Detallado = 1");
                sConsultaVar.AppendLine("begin");
                sConsultaVar.AppendLine("    set @FechaIni = DATEADD(dd, 0, DATEDIFF(dd, 0, (DATEADD(dd, -(DATEPART(DW, @Fecha) - 1), @Fecha))))");
                sConsultaVar.AppendLine("    set @FechaFin = DATEADD(ms, 86399998, DATEADD(dd, 0, DATEDIFF(dd, 0, (DATEADD(dd, 7 - (DATEPART(DW, @Fecha)), @Fecha)))))");
                sConsultaVar.AppendLine("end");
                sConsultaVar.AppendLine("else");
                sConsultaVar.AppendLine("begin");
                sConsultaVar.AppendLine("    set @FechaIni = DATEADD(MM, DATEDIFF(MM,0,@Fecha), 0)");
                sConsultaVar.AppendLine("    set @FechaFin = DATEADD(ms, 86399998, CONVERT(datetime, EOMONTH(@Fecha)))");
                sConsultaVar.AppendLine("end");

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine(sConsultaVar.ToString());
                sConsulta.AppendLine("select @RUTClave as RUTClave, DATEPART(WK, @Fecha) as Semana, @FechaIni as FechaInicial, @FechaFin as FechaFinal,");
                sConsulta.AppendLine("dbo.DiasLaboralesLS(DATEADD(MM, DATEDIFF(MM,0,@Fecha), 0), CONVERT(datetime, EOMONTH(@Fecha))) as DiasVentaMes,");
                sConsulta.AppendLine("case DATEPART(MM, @Fecha) when 1 then 'Enero' when 2 then 'Febrero' when 3 then 'Marzo' when 4 then 'Abril' when 5 then 'Mayo' when 6 then 'Junio'");
                sConsulta.AppendLine("when 7 then 'Julio' when 8 then 'Agosto' when 9 then 'Septiembre' when 10 then 'Octubre' when 11 then 'Noviembre' when 12 then 'Diciembre' end as Mes,");
                sConsulta.AppendLine("(select count(distinct SEC.ClienteClave) from Secuencia SEC (NOLOCK) where RUTClave = @RUTClave) as ClientesRuta,");
                sConsulta.AppendLine("(select case when @Detallado = 1 then count(ClienteClave) else count(distinct ClienteClave) end from AgendaVendedor AGV (NOLOCK) inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave where AGV.RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin) as ClientesProgramados,");
                sConsulta.AppendLine("(select min(VIS.FechaHoraInicial) from Visita VIS (NOLOCK) inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave where RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin) as PrimerCliente,");
                sConsulta.AppendLine("(select max(VIS.FechaHoraInicial) from Visita VIS (NOLOCK) inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave where RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin) as UltimoCliente");
                QueryString = sConsulta.ToString();
                lstIndicadoresRuta = Connection.Query<IndicadoresRuta>(QueryString, null, null, true, 600).ToList();

                sConsulta = new StringBuilder();
                sConsultaVar.AppendLine("declare @USUId as varchar(16)");
                sConsultaVar.AppendLine("select @USUId = VEN.USUId");
                sConsultaVar.AppendLine("from VenRut VRT (NOLOCK) ");
                sConsultaVar.AppendLine("inner join Vendedor VEN (NOLOCK) on VRT.VendedorID = VEN.VendedorID");
                sConsultaVar.AppendLine("where VRT.RUTClave = @RUTClave and VRT.TipoEstado = 1");
                sConsulta.AppendLine(sConsultaVar.ToString());

                if (Detallado)
                {
                    sConsulta.AppendLine("select t1.DiaSemana, t1.ClientesProgramados, t1.ClientesNuevos, t2.VisitasEfectivas, t2.VentaCajas, t2.Precio");
                    sConsulta.AppendLine("from (");
                    sConsulta.AppendLine("    select datepart(dw, Dia.FechaCaptura) as DiaSemana, count(ClienteClave) as ClientesProgramados,");
                    sConsulta.AppendLine("    (select count(ClienteClave)");
                    sConsulta.AppendLine("    from Cliente (NOLOCK) ");
                    sConsulta.AppendLine("    where ClienteClave like 'RUTA%' and DATEADD(dd, 0, DATEDIFF(dd, 0, FechaRegistroSistema)) = Dia.FechaCaptura and MUsuarioID = @USUId");
                    sConsulta.AppendLine("    ) as ClientesNuevos");
                    sConsulta.AppendLine("    from AgendaVendedor AGV (NOLOCK) ");
                    sConsulta.AppendLine("    inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave");
                    sConsulta.AppendLine("    where AGV.RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin");
                    sConsulta.AppendLine("    group by Dia.FechaCaptura");
                    sConsulta.AppendLine(") as t1");
                    sConsulta.AppendLine("left join (");
                    sConsulta.AppendLine("    select datepart(dw, Dia.FechaCaptura) as DiaSemana, count(distinct VIS.VisitaClave) as VisitasEfectivas, sum(TPD.Cantidad) as VentaCajas,");
                    sConsulta.AppendLine("    (select top 1 TPD.Precio");
                    sConsulta.AppendLine("    from TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("    inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave");
                    sConsulta.AppendLine("    inner join Dia DIA1 (NOLOCK) on VIS.DiaClave = DIA1.DiaClave");
                    sConsulta.AppendLine("    inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
                    sConsulta.AppendLine("    where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.RUTClave = @RUTClave and DIA1.FechaCaptura = Dia.FechaCaptura");
                    sConsulta.AppendLine("    order by TPD.MFechaHora) as Precio");
                    sConsulta.AppendLine("    from TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("    inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave");
                    sConsulta.AppendLine("    inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
                    sConsulta.AppendLine("    inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
                    sConsulta.AppendLine("    where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin");
                    sConsulta.AppendLine("    group by Dia.FechaCaptura");
                    sConsulta.AppendLine(") as t2 on t1.DiaSemana = t2.DiaSemana");
                    sConsulta.AppendLine("order by t1.DiaSemana");
                    QueryString = sConsulta.ToString();
                    lstIndicadoresRutaDet = Connection.Query<IndicadoresRutaDetalle>(QueryString, null, null, true, 600).ToList();
                }
                else
                {
                    sConsulta.AppendLine("select");
                    sConsulta.AppendLine("(select count(distinct ClienteClave)");
                    sConsulta.AppendLine("from AgendaVendedor AGV (NOLOCK) ");
                    sConsulta.AppendLine("inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave");
                    sConsulta.AppendLine("where AGV.RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin) as ClientesProgramados,");
                    sConsulta.AppendLine("(select count(ClienteClave)");
                    sConsulta.AppendLine("from Cliente (NOLOCK) ");
                    sConsulta.AppendLine("where ClienteClave like 'RUTA%' and DATEADD(dd, 0, DATEDIFF(dd, 0, FechaRegistroSistema)) between @FechaIni and @FechaFin and MUsuarioID = @USUId) as ClientesNuevos,");
                    sConsulta.AppendLine("(select count(distinct VIS.VisitaClave)");
                    sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave");
                    sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
                    sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin) as VisitasEfectivas,");
                    sConsulta.AppendLine("(select sum(Cantidad)");
                    sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave");
                    sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
                    sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID");
                    sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin) as VentaCajas,");
                    sConsulta.AppendLine("(select sum(TRP.Total)");
                    sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                    sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave");
                    sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave");
                    sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.RUTClave = @RUTClave and Dia.FechaCaptura between @FechaIni and @FechaFin) as VentaPesos");
                    QueryString = sConsulta.ToString();
                    lstIndicadoresRutaGral = Connection.Query<IndicadoresRutaGeneral>(QueryString, null, null, true, 600).ToList();
                }

                ArchivoXlsModel file = GenerarExcel();
                DownloadFile.DownloadOpenXML(file);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private ArchivoXlsModel GenerarExcel()
        {
            string fileName = "IndicadoresOJAI_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Indicadores" };
            sheets.Append(sheet);

            WorkbookStylesPart stylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            stylesPart.Stylesheet = MyOpenXML.GenerateStyleSheet();
            stylesPart.Stylesheet.Save();

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            Dictionary<int, Row> Rows = new Dictionary<int, Row>();
            MyOpenXML.createRow(2, ref Rows);
            MyOpenXML.createCell(2, ref Rows, "B2", CellValues.String, this.NombreEmpresa, 4);

            MyOpenXML.createRow(3, ref Rows);
            MyOpenXML.createCell(3, ref Rows, "B3", CellValues.String, this.NombreReporte, 4);

            MyOpenXML.createRow(4, ref Rows);
            MyOpenXML.createCell(4, ref Rows, "B4", CellValues.String, sAlmacenNombre, 4);

            MyOpenXML.createRow(5, ref Rows);
            MyOpenXML.createCell(5, ref Rows, "B5", CellValues.String, Mensaje.ObtenerDescripcion("XSemana", "EM") + " " + lstIndicadoresRuta[0].Semana.ToString() + ": " + lstIndicadoresRuta[0].FechaInicial.ToShortDateString() + " al " + lstIndicadoresRuta[0].FechaFinal.ToShortDateString(), 4);

            MyOpenXML.createRow(6, ref Rows);
            MyOpenXML.createCell(6, ref Rows, "B6", CellValues.String, (bDetallado ? Mensaje.ObtenerDescripcion("XDetallado", "EM") : Mensaje.ObtenerDescripcion("XGeneral", "EM")), 4);

            MyOpenXML.createRow(7, ref Rows);
            MyOpenXML.createCell(7, ref Rows, "B7", CellValues.String, Mensaje.ObtenerDescripcion("XEstructuraRuta", "EM"), 3);
            MyOpenXML.createCell(7, ref Rows, "C7", CellValues.String, lstIndicadoresRuta[0].RUTClave, 2);



            //Cell oCell = MyOpenXML.ConstructCell(index.ToString(), CellValues.SharedString, 1U);

            MyOpenXML.createRow(8, ref Rows);
            MyOpenXML.createCell(8, ref Rows, "B8", CellValues.String, Mensaje.ObtenerDescripcion("XDiasVentaMes", "EM").Replace("$0$", lstIndicadoresRuta[0].Mes), 3);
            MyOpenXML.createCell(8, ref Rows, "C8", CellValues.Number, lstIndicadoresRuta[0].DiasVentaMes.ToString(), 2);

            MyOpenXML.createRow(9, ref Rows);
            MyOpenXML.createCell(9, ref Rows, "B9", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoVentaCajasMes", "EM"), 3);
            MyOpenXML.createCell(9, ref Rows, "C9", CellValues.Number, nObjetivoVentaMensualCajas.ToString(), 2);

            MyOpenXML.createRow(10, ref Rows);
            MyOpenXML.createCell(10, ref Rows, "B10", CellValues.String, Mensaje.ObtenerDescripcion("XCantidadClientesRuta", "EM"), 3);
            MyOpenXML.createCell(10, ref Rows, "C10", CellValues.Number, lstIndicadoresRuta[0].ClientesRuta.ToString(), 2);

            MyOpenXML.createRow(11, ref Rows);
            MyOpenXML.createCell(11, ref Rows, "B11", CellValues.String, Mensaje.ObtenerDescripcion("PorcFrecVisitaCteSemanal", "EM"), 3);
            MyOpenXML.createCell(11, ref Rows, "C11", CellValues.Number, Math.Round(((float)lstIndicadoresRuta[0].ClientesProgramados / lstIndicadoresRuta[0].ClientesRuta), 2).ToString(), 2);

            MyOpenXML.createRow(12, ref Rows);
            MyOpenXML.createCell(12, ref Rows, "B12", CellValues.String, Mensaje.ObtenerDescripcion("XPorcCumplimientoVisita", "EM"), 3);
            MyOpenXML.createCell(12, ref Rows, "C12", CellValues.Number, "100", 2);

            MyOpenXML.createRow(13, ref Rows);
            MyOpenXML.createCell(13, ref Rows, "B13", CellValues.String, Mensaje.ObtenerDescripcion("XPorcEfectividad", "EM"), 3);
            MyOpenXML.createCell(13, ref Rows, "C13", CellValues.Number, "80", 2);

            MyOpenXML.createRow(14, ref Rows);
            MyOpenXML.createCell(14, ref Rows, "B14", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoClientesNuevos", "EM"), 3);
            MyOpenXML.createCell(14, ref Rows, "C14", CellValues.Number, (nObjetivoVisitasEfectivas - lstIndicadoresRuta[0].ClientesProgramados).ToString(), 2);

            MyOpenXML.createRow(15, ref Rows);
            MyOpenXML.createCell(15, ref Rows, "B15", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoVentaCajasCliente", "EM"), 3);
            MyOpenXML.createCell(15, ref Rows, "C15", CellValues.Number, (nObjetivoVentaMensualCajas / lstIndicadoresRuta[0].ClientesRuta).ToString(), 2);

            MyOpenXML.createRow(17, ref Rows);
            MyOpenXML.createCell(17, ref Rows, "B17", CellValues.String, Mensaje.ObtenerDescripcion("XTiempoMercadeoPrimerUltimoCliente", "EM").Replace("$0$", lstIndicadoresRuta[0].PrimerCliente.ToString("HH:mm")).Replace("$1$", lstIndicadoresRuta[0].UltimoCliente.ToString("HH:mm")));

            if (bDetallado)
            {
                MyOpenXML.createRow(18, ref Rows);
                MyOpenXML.createCell(18, ref Rows, "B18", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivosProductividad", "EM"), 3);
                MyOpenXML.createCell(18, ref Rows, "C18", CellValues.String, "Lunes", 3);
                MyOpenXML.createCell(18, ref Rows, "D18", CellValues.String, "Martes", 3);
                MyOpenXML.createCell(18, ref Rows, "E18", CellValues.String, "Miércoles", 3);
                MyOpenXML.createCell(18, ref Rows, "F18", CellValues.String, "Jueves", 3);
                MyOpenXML.createCell(18, ref Rows, "G18", CellValues.String, "Viernes", 3);
                MyOpenXML.createCell(18, ref Rows, "H18", CellValues.String, "Sabado", 3);
                MyOpenXML.createCell(18, ref Rows, "I18", CellValues.String, Mensaje.ObtenerDescripcion("XTotalSemana", "EM"), 3);


                MyOpenXML.createRow(19, ref Rows);
                MyOpenXML.createCell(19, ref Rows, "B19", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoVentaDiariaCajas", "EM"), 3);
                MyOpenXML.createRow(20, ref Rows);
                MyOpenXML.createCell(20, ref Rows, "B20", CellValues.String, Mensaje.ObtenerDescripcion("XLogroVentaDiariaCajas", "EM"), 3);
                MyOpenXML.createRow(21, ref Rows);
                MyOpenXML.createCell(21, ref Rows, "B21", CellValues.String, Mensaje.ObtenerDescripcion("XNoClientesProgramados", "EM"), 3);
                MyOpenXML.createRow(22, ref Rows);
                MyOpenXML.createCell(22, ref Rows, "B22", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoVisitasEfectivas", "EM"), 3);
                MyOpenXML.createRow(23, ref Rows);
                MyOpenXML.createCell(23, ref Rows, "B23", CellValues.String, Mensaje.ObtenerDescripcion("XLogroVisitasEfectivas", "EM"), 3);
                MyOpenXML.createRow(24, ref Rows);
                MyOpenXML.createCell(24, ref Rows, "B24", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoDropSizeCajas", "EM"), 3);
                MyOpenXML.createRow(25, ref Rows);
                MyOpenXML.createCell(25, ref Rows, "B25", CellValues.String, Mensaje.ObtenerDescripcion("XLogroDropSize", "EM"), 3);
                MyOpenXML.createRow(26, ref Rows);
                MyOpenXML.createCell(26, ref Rows, "B26", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoClientesNuevos", "EM"), 3);
                MyOpenXML.createRow(27, ref Rows);
                MyOpenXML.createCell(27, ref Rows, "B27", CellValues.String, Mensaje.ObtenerDescripcion("XLogroClientesNuevos", "EM"), 3);
                MyOpenXML.createRow(28, ref Rows);
                MyOpenXML.createCell(28, ref Rows, "B28", CellValues.String, Mensaje.ObtenerDescripcion("XPrecioPorCaja", "EM"), 3);
                MyOpenXML.createRow(29, ref Rows);
                MyOpenXML.createCell(29, ref Rows, "B29", CellValues.String, Mensaje.ObtenerDescripcion("XVentaPesosDia", "EM"), 3);

                IndicadoresRutaDetalle oIndicadoresRutaDet;
                int nObjetivoVentaDiariaCajas = 0;
                float nLogroVentaDiariaCajas = 0;
                int nNoClientesProgramados = 0;
                int nTotalObjetivoVisitasEfectivas = 0;
                int nLogroVisitasEfectivas = 0;
                int nLogroClientesNuevos = 0;
                float nVentaPesosDia = 0;

                int columna = 3;
                for (int i = 1; i <= 6; i++)
                {
                    MyOpenXML.createCell(19, ref Rows, GetExcelColumnName(columna) + "19", CellValues.Number, (nObjetivoVentaMensualCajas / lstIndicadoresRuta[0].DiasVentaMes).ToString(), 2);
                    nObjetivoVentaDiariaCajas += (nObjetivoVentaMensualCajas / lstIndicadoresRuta[0].DiasVentaMes);

                    if (lstIndicadoresRutaDet.Exists(x => x.DiaSemana == i))
                    {
                        oIndicadoresRutaDet = lstIndicadoresRutaDet.First(x => x.DiaSemana == i);

                        MyOpenXML.createCell(20, ref Rows, GetExcelColumnName(columna) + "20", CellValues.Number, oIndicadoresRutaDet.VentaCajas.ToString(), 2);
                        MyOpenXML.createCell(21, ref Rows, GetExcelColumnName(columna) + "21", CellValues.Number, oIndicadoresRutaDet.ClientesProgramados.ToString(), 2);
                        MyOpenXML.createCell(22, ref Rows, GetExcelColumnName(columna) + "22", CellValues.Number, nObjetivoVisitasEfectivas.ToString(), 2);
                        MyOpenXML.createCell(23, ref Rows, GetExcelColumnName(columna) + "23", CellValues.Number, oIndicadoresRutaDet.VisitasEfectivas.ToString(), 2);
                        MyOpenXML.createCell(24, ref Rows, GetExcelColumnName(columna) + "24", CellValues.Number, Math.Round(((float)(nObjetivoVentaMensualCajas / lstIndicadoresRuta[0].DiasVentaMes) / nObjetivoVisitasEfectivas), 2).ToString(), 2);
                        MyOpenXML.createCell(25, ref Rows, GetExcelColumnName(columna) + "25", CellValues.Number, Math.Round((float)(oIndicadoresRutaDet.VentaCajas / oIndicadoresRutaDet.VisitasEfectivas), 2).ToString(), 2);
                        MyOpenXML.createCell(26, ref Rows, GetExcelColumnName(columna) + "26", CellValues.Number, (nObjetivoVisitasEfectivas - oIndicadoresRutaDet.ClientesProgramados).ToString(), 2);
                        MyOpenXML.createCell(27, ref Rows, GetExcelColumnName(columna) + "27", CellValues.Number, oIndicadoresRutaDet.ClientesNuevos.ToString(), 2);
                        MyOpenXML.createCell(28, ref Rows, GetExcelColumnName(columna) + "28", CellValues.Number, oIndicadoresRutaDet.Precio.ToString(), 2);
                        MyOpenXML.createCell(29, ref Rows, GetExcelColumnName(columna) + "29", CellValues.Number, (oIndicadoresRutaDet.VentaCajas * oIndicadoresRutaDet.Precio).ToString(), 2);

                        nLogroVentaDiariaCajas += oIndicadoresRutaDet.VentaCajas;
                        nNoClientesProgramados += oIndicadoresRutaDet.ClientesProgramados;
                        nTotalObjetivoVisitasEfectivas += nObjetivoVisitasEfectivas;
                        nLogroVisitasEfectivas += oIndicadoresRutaDet.VisitasEfectivas;
                        nLogroClientesNuevos += oIndicadoresRutaDet.ClientesNuevos;
                        nVentaPesosDia += oIndicadoresRutaDet.VentaCajas * oIndicadoresRutaDet.Precio;
                    }
                    else
                    {
                        MyOpenXML.createCell(20, ref Rows, GetExcelColumnName(columna) + "20", CellValues.Number, "0", 2);
                        MyOpenXML.createCell(21, ref Rows, GetExcelColumnName(columna) + "21", CellValues.Number, "0", 2);
                        MyOpenXML.createCell(22, ref Rows, GetExcelColumnName(columna) + "22", CellValues.Number, nObjetivoVisitasEfectivas.ToString(), 2);
                        MyOpenXML.createCell(23, ref Rows, GetExcelColumnName(columna) + "23", CellValues.Number, "0", 2);
                        MyOpenXML.createCell(24, ref Rows, GetExcelColumnName(columna) + "24", CellValues.Number, Math.Round(((float)(nObjetivoVentaMensualCajas / lstIndicadoresRuta[0].DiasVentaMes) / nObjetivoVisitasEfectivas), 2).ToString(), 2);
                        MyOpenXML.createCell(25, ref Rows, GetExcelColumnName(columna) + "25", CellValues.Number, "0", 2);
                        MyOpenXML.createCell(26, ref Rows, GetExcelColumnName(columna) + "26", CellValues.Number, "0", 2);
                        MyOpenXML.createCell(27, ref Rows, GetExcelColumnName(columna) + "27", CellValues.Number, "0", 2);
                        MyOpenXML.createCell(28, ref Rows, GetExcelColumnName(columna) + "28", CellValues.Number, "0", 2);
                        MyOpenXML.createCell(29, ref Rows, GetExcelColumnName(columna) + "29", CellValues.Number, "0", 2);
                    }
                    columna += 1;
                }

                MyOpenXML.createCell(19, ref Rows, GetExcelColumnName(columna) + "19", CellValues.Number, nObjetivoVentaDiariaCajas.ToString(), 2);
                MyOpenXML.createCell(20, ref Rows, GetExcelColumnName(columna) + "20", CellValues.Number, nLogroVentaDiariaCajas.ToString(), 2);
                MyOpenXML.createCell(21, ref Rows, GetExcelColumnName(columna) + "21", CellValues.Number, nNoClientesProgramados.ToString(), 2);
                MyOpenXML.createCell(22, ref Rows, GetExcelColumnName(columna) + "22", CellValues.Number, nTotalObjetivoVisitasEfectivas.ToString(), 2);
                MyOpenXML.createCell(23, ref Rows, GetExcelColumnName(columna) + "23", CellValues.Number, nLogroVisitasEfectivas.ToString(), 2);
                MyOpenXML.createCell(24, ref Rows, GetExcelColumnName(columna) + "24", CellValues.Number, Math.Round(((float)nObjetivoVentaDiariaCajas / nTotalObjetivoVisitasEfectivas), 2).ToString(), 2);
                MyOpenXML.createCell(25, ref Rows, GetExcelColumnName(columna) + "25", CellValues.Number, Math.Round(((float)nLogroVentaDiariaCajas / nLogroVisitasEfectivas), 2).ToString(), 2);
                MyOpenXML.createCell(26, ref Rows, GetExcelColumnName(columna) + "26", CellValues.Number, (nTotalObjetivoVisitasEfectivas - nNoClientesProgramados).ToString(), 2);
                MyOpenXML.createCell(27, ref Rows, GetExcelColumnName(columna) + "27", CellValues.Number, nLogroClientesNuevos.ToString(), 2);
                MyOpenXML.createCell(28, ref Rows, GetExcelColumnName(columna) + "28", CellValues.Number, Math.Round((nVentaPesosDia / nLogroVentaDiariaCajas), 2).ToString(), 2);
                MyOpenXML.createCell(29, ref Rows, GetExcelColumnName(columna) + "29", CellValues.Number, nVentaPesosDia.ToString(), 2);
            }
            else
            {
                MyOpenXML.createRow(18, ref Rows);
                MyOpenXML.createCell(18, ref Rows, "B18", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivosProductividad", "EM"), 3);
                MyOpenXML.createCell(18, ref Rows, "C18", CellValues.String, Mensaje.ObtenerDescripcion("XTotalMes", "EM"), 3);

                MyOpenXML.createRow(19, ref Rows);
                MyOpenXML.createCell(19, ref Rows, "B19", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoVentaDiariaCajas", "EM"), 3);
                MyOpenXML.createCell(19, ref Rows, "C19", CellValues.Number, (nObjetivoVentaMensualCajas / lstIndicadoresRuta[0].DiasVentaMes).ToString(), 2);

                MyOpenXML.createRow(20, ref Rows);
                MyOpenXML.createCell(20, ref Rows, "B20", CellValues.String, Mensaje.ObtenerDescripcion("XLogroVentaDiariaCajas", "EM"), 3);
                MyOpenXML.createCell(20, ref Rows, "C20", CellValues.Number, Math.Round((lstIndicadoresRutaGral[0].VentaCajas / lstIndicadoresRuta[0].DiasVentaMes), 2).ToString(), 2);

                MyOpenXML.createRow(21, ref Rows);
                MyOpenXML.createCell(21, ref Rows, "B21", CellValues.String, Mensaje.ObtenerDescripcion("XNoClientesProgramados", "EM"), 3);
                MyOpenXML.createCell(21, ref Rows, "C21", CellValues.Number, lstIndicadoresRutaGral[0].ClientesProgramados.ToString(), 2);

                MyOpenXML.createRow(22, ref Rows);
                MyOpenXML.createCell(22, ref Rows, "B22", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoVisitasEfectivas", "EM"), 3);
                MyOpenXML.createCell(22, ref Rows, "C22", CellValues.Number, nObjetivoVisitasEfectivas.ToString(), 2);

                MyOpenXML.createRow(23, ref Rows);
                MyOpenXML.createCell(23, ref Rows, "B23", CellValues.String, Mensaje.ObtenerDescripcion("XLogroVisitasEfectivas", "EM"), 3);
                MyOpenXML.createCell(23, ref Rows, "C23", CellValues.Number, lstIndicadoresRutaGral[0].VisitasEfectivas.ToString(), 2);

                MyOpenXML.createRow(24, ref Rows);
                MyOpenXML.createCell(24, ref Rows, "B24", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoDropSizeCajas", "EM"), 3);
                MyOpenXML.createCell(24, ref Rows, "C24", CellValues.Number, Math.Round(((float)(nObjetivoVentaMensualCajas / lstIndicadoresRuta[0].DiasVentaMes) / nObjetivoVisitasEfectivas), 2).ToString(), 2);

                MyOpenXML.createRow(25, ref Rows);
                MyOpenXML.createCell(25, ref Rows, "B25", CellValues.String, Mensaje.ObtenerDescripcion("XLogroDropSize", "EM"), 3);
                MyOpenXML.createCell(25, ref Rows, "C25", CellValues.Number, Math.Round(((float)(lstIndicadoresRutaGral[0].VentaCajas / lstIndicadoresRuta[0].DiasVentaMes) / lstIndicadoresRutaGral[0].VisitasEfectivas), 2).ToString(), 2);

                MyOpenXML.createRow(26, ref Rows);
                MyOpenXML.createCell(26, ref Rows, "B26", CellValues.String, Mensaje.ObtenerDescripcion("XObjetivoClientesNuevos", "EM"), 3);
                MyOpenXML.createCell(26, ref Rows, "C26", CellValues.Number, (nObjetivoVisitasEfectivas - lstIndicadoresRutaGral[0].ClientesProgramados).ToString(), 2);

                MyOpenXML.createRow(27, ref Rows);
                MyOpenXML.createCell(27, ref Rows, "B27", CellValues.String, Mensaje.ObtenerDescripcion("XLogroClientesNuevos", "EM"), 3);
                MyOpenXML.createCell(27, ref Rows, "C27", CellValues.Number, lstIndicadoresRutaGral[0].ClientesNuevos.ToString(), 2);

                MyOpenXML.createRow(28, ref Rows);
                MyOpenXML.createCell(28, ref Rows, "B28", CellValues.String, Mensaje.ObtenerDescripcion("XVentaPesosMes", "EM"), 3);
                MyOpenXML.createCell(28, ref Rows, "C28", CellValues.Number, lstIndicadoresRutaGral[0].VentaPesos.ToString(), 2);
            }

            foreach (var row in Rows)
                sheetData.Append(row.Value);

            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;

            //insert Image by specifying two range
            string LogoQuery = "Select Logotipo from Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);

            MyOpenXML.InsertImage(worksheetPart, 1, 5, 4, 6, mStream);

            workbookPart.Workbook.Save();

            // Close the document.
            document.Close();

            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;
        }//GenerarExcel

    }

    //Clientes agenda vs mes anterior CEDI
    class IndicadoresRuta
    {
        public String RUTClave { get; set; }
        public int Semana { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int DiasVentaMes { get; set; }
        public String Mes { get; set; }
        public int ClientesRuta { get; set; }
        public int ClientesProgramados { get; set; }
        public DateTime PrimerCliente { get; set; }
        public DateTime UltimoCliente { get; set; }
    }

    class IndicadoresRutaDetalle
    {
        public int DiaSemana { get; set; }
        public int ClientesProgramados { get; set; }
        public int ClientesNuevos { get; set; }
        public int VisitasEfectivas { get; set; }
        public float VentaCajas { get; set; }
        public float Precio { get; set; }
    }

    class IndicadoresRutaGeneral
    {
        public int ClientesProgramados { get; set; }
        public int ClientesNuevos { get; set; }
        public int VisitasEfectivas { get; set; }
        public float VentaCajas { get; set; }
        public float VentaPesos { get; set; }
    }

}
