using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Threading;

namespace eRoute.Models.ReportesModels
{
    public class VentasPorClienteMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(string nombreReport, string nombreCedis, string FechaInicial, string FechaFinal, string Cedis, string sFecha1, int vavclave, string dateStatus, string unidadMedida, string pvProductos, string nombreProductos, string sEsquemasProd, string pvCondicion, string pvCondicionProd, string RutasSplit)
        {
            try
            {
                Boolean existeOrderProductos = ordenProductos(vavclave);

                DateTime sFecha = Convert.ToDateTime(FechaInicial);
                DateTime sFechaFin;
                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
                {
                    sFechaFin = sFecha;
                }
                else
                {
                    sFechaFin = Convert.ToDateTime(FechaFinal);
                }


                DateTime dFechaIni = new DateTime(sFecha.Year, sFecha.Month, sFecha.Day);
                DateTime dFechaFin = new DateTime(sFechaFin.Year, sFechaFin.Month, sFechaFin.Day);


                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("if (select object_id('tempdb..#TmpClientes')) is not null drop table #TmpClientes ");
                sConsulta.AppendLine("select * into #TmpClientes from ( ");
                sConsulta.AppendLine("select ALM.Clave as ALMClave, ");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre,");
                sConsulta.AppendLine("SEC.RUTClave, ");
                sConsulta.AppendLine("RUT.Descripcion,");
                sConsulta.AppendLine("USU.CLAVE as USUClave, ");
                sConsulta.AppendLine("VEN.Nombre as VENNombre, ");
                sConsulta.AppendLine("CLI.ClienteClave, ");
                sConsulta.AppendLine("CLI.Clave as CLIClave, ");
                sConsulta.AppendLine("CLI.NombreCorto as CLINombre ");
                sConsulta.AppendLine("from Cliente CLI (NOLOCK) ");
                sConsulta.AppendLine("inner join (select distinct ClienteClave, RUTClave from Secuencia (NOLOCK) where not RUTClave is null) as SEC on CLI.ClienteClave =SEC.ClienteClave ");
                sConsulta.AppendLine("inner join VenRut VRT (NOLOCK) on SEC.RUTClave=VRT.RUTClave and VRT.TipoEstado=1 ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VRT.VendedorID=VEN.VendedorID  ");
                sConsulta.AppendLine("inner join (select VendedorId, AlmacenId, max(VCHFechaInicial) as FechaInicial from VENCentroDistHist (NOLOCK) group by VendedorId, AlmacenId) as CEDI on CEDI.VendedorId=VRT.VendedorId ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId=ALM.AlmacenID ");
                sConsulta.AppendLine("inner join Usuario USU (NOLOCK) on VEN.USUId=USU.USUId ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on RUT.RUTClave=VRT.RUTClave ");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine(")as T1 ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select CLI.* ");
                sConsulta.AppendLine("from #TmpClientes CLI ");
                sConsulta.AppendLine("order by CLI.ALMClave, CLI.RUTClave, CLI.USUClave, CLI.CLIClave ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("drop table #TmpClientes ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                List<VPCMORClientesModel> Clientes = Connection.Query<VPCMORClientesModel>(QueryString, null, null, true, 600).ToList();
                if (Clientes.Count() <= 0)
                {
                    return null;
                }

                DataTable ClientesDt = new DataTable();
                ClientesDt.Columns.Add("ALMClave", typeof(string));
                ClientesDt.Columns.Add("ALMNombre", typeof(string));
                ClientesDt.Columns.Add("RUTClave", typeof(string));
                ClientesDt.Columns.Add("Descripcion", typeof(string));
                ClientesDt.Columns.Add("USUClave", typeof(string));
                ClientesDt.Columns.Add("VENNombre", typeof(string));
                ClientesDt.Columns.Add("ClienteClave", typeof(string));
                ClientesDt.Columns.Add("CLIClave", typeof(string));
                ClientesDt.Columns.Add("CLINombre", typeof(string));

                foreach (VPCMORClientesModel cte in Clientes)
                {
                    DataRow drNueva = ClientesDt.NewRow();

                    drNueva["ALMClave"] = cte.ALMClave;
                    drNueva["ALMNombre"] = cte.ALMNombre;
                    drNueva["RUTClave"] = cte.RUTClave;
                    drNueva["Descripcion"] = cte.Descripcion;
                    drNueva["USUClave"] = cte.USUClave;
                    drNueva["VENNombre"] = cte.VENNombre;
                    drNueva["ClienteClave"] = cte.ClienteClave;
                    drNueva["CLIClave"] = cte.CLIClave;
                    drNueva["CLINombre"] = cte.CLINombre;

                    ClientesDt.Rows.Add(drNueva);
                }


                sConsulta = new StringBuilder();
                sConsulta.AppendLine("select ALM.Clave as ALMClave, ");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre, ");
                sConsulta.AppendLine("VIS.RUTClave, ");
                sConsulta.AppendLine("RUT.Descripcion, ");
                sConsulta.AppendLine("USU.CLAVE as USUClave, ");
                sConsulta.AppendLine("VEN.Nombre as VENNombre, ");
                sConsulta.AppendLine("VIS.ClienteClave, ");
                sConsulta.AppendLine("CLI.Clave as CLIClave, ");
                sConsulta.AppendLine("CLI.NombreCorto as CLINombre, ");
                sConsulta.AppendLine("TPD.ProductoClave, ");
                sConsulta.AppendLine("PRO.Nombre, ");
                sConsulta.AppendLine("PRO.Contenido, ");
                sConsulta.AppendLine("PRO.Venta ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'CartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'CartonesHectolitraje'");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave=CLI.ClienteClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("inner join Usuario USU (NOLOCK) on VEN.USUId = USU.USUId ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave=RUT.RUTClave ");
                if (sEsquemasProd.Replace("where 1 = 1 ", "") != "")
                    sConsulta.AppendLine("inner join (select distinct ProductoClave from ProductoEsquema PE (NOLOCK) " + sEsquemasProd + ") PEE on PRO.ProductoClave=PEE.ProductoClave ");
                if (existeOrderProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + vavclave + "'");
                sConsulta.AppendLine(pvCondicionProd);
                sConsulta.AppendLine("and ( " + sFecha1 + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (existeOrderProductos)
                {
                    sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, VIS.RUTClave, RUT.Descripcion, USU.CLAVE, VEN.Nombre, VIS.ClienteClave, CLI.Clave, CLI.NombreCorto, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta, OP.Orden ");
                    sConsulta.AppendLine("order by OP.Orden");
                }
                else
                {
                    sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, VIS.RUTClave, RUT.Descripcion, USU.CLAVE, VEN.Nombre, VIS.ClienteClave, CLI.Clave, CLI.NombreCorto, TPD.ProductoClave, PRO.Nombre, PRO.Contenido, PRO.Venta ");
                }

                QueryString = sConsulta.ToString();

                List<VPCMORProductosModel> Productos = Connection.Query<VPCMORProductosModel>(QueryString, null, null, true, 600).ToList();

                sConsulta = new StringBuilder();
                sConsulta.AppendLine("select ALM.Clave as ALMClave, ");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre, ");
                sConsulta.AppendLine("VIS.RUTClave, ");
                sConsulta.AppendLine("RUT.Descripcion, ");
                sConsulta.AppendLine("USU.CLAVE as USUClave, ");
                sConsulta.AppendLine("VEN.Nombre as VENNombre, ");
                sConsulta.AppendLine("VIS.ClienteClave, ");
                sConsulta.AppendLine("CLI.Clave as CLIClave, ");
                sConsulta.AppendLine("CLI.NombreCorto as CLINombre ");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM( TPD.Cantidad * PRD.Factor ) as 'TotalCartonesHectolitraje' ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as 'TotalCartonesHectolitraje'");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) on VIS.ClienteClave=CLI.ClienteClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) on VIS.VendedorId=VEN.VendedorId ");
                sConsulta.AppendLine("inner join Usuario USU (NOLOCK) on VEN.USUId = USU.USUId ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) on VIS.RUTClave=RUT.RUTClave ");
                if (sEsquemasProd.Replace("where 1 = 1 ", "") != "")
                    sConsulta.AppendLine("inner join (select distinct ProductoClave from ProductoEsquema PE (NOLOCK) " + sEsquemasProd + ") PEE on PRO.ProductoClave=PEE.ProductoClave ");
                if (existeOrderProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + vavclave + "'");
                sConsulta.AppendLine(pvCondicionProd);
                sConsulta.AppendLine("and ( " + sFecha1 + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                sConsulta.AppendLine("group by ALM.Clave, ALM.Nombre, VIS.RUTClave, RUT.Descripcion, USU.CLAVE, VEN.Nombre, VIS.ClienteClave, CLI.Clave, CLI.NombreCorto ");

                QueryString = sConsulta.ToString();

                List<VPCMORTotalProductosModel> TotalProductos = Connection.Query<VPCMORTotalProductosModel>(QueryString, null, null, true, 600).ToList();

                if (String.IsNullOrEmpty(RutasSplit))
                {
                    RutasSplit = "Todas";
                }
                else
                {
                    RutasSplit = RutasSplit.Replace(",", ", ");
                }

                if (String.IsNullOrEmpty(pvProductos))
                {
                    pvProductos = "Todos";
                }else
                {
                    pvProductos = pvProductos.Replace("'", "");
                    pvProductos = pvProductos.Replace(",", ", ");
                }

                //comenzamos a enlistar datos para pasarlos al reporte
                DataTable dtFinal = new DataTable();
                dtFinal.Columns.Add("ALMClave", typeof(string));//Type.GetType("string")
                dtFinal.Columns.Add("RUTClave", typeof(string));
                dtFinal.Columns.Add("USUClave", typeof(string));
                dtFinal.Columns.Add("ClienteClave", typeof(string));
                String sCol = "";

                //Productos
                List<VPCMORProductosModel> drCols = (from producto in Productos where (producto.Contenido == 0 && producto.Venta == 0) orderby producto.ProductoClave select producto).ToList();
                foreach (VPCMORProductosModel dr in drCols)
                {
                    if (dr.ProductoClave != sCol)
                    {
                        dtFinal.Columns.Add("Nom_" + dr.ProductoClave, typeof(double));
                        dtFinal.Columns[dtFinal.Columns.Count - 1].Caption = dr.Nombre;

                        sCol = dr.ProductoClave;
                    }
                }

                dtFinal.Columns.Add("TotalCartonesHectolitraje", typeof(double));

                foreach (VPCMORClientesModel drCte in Clientes)
                {
                    try
                    {
                        DataRow drNueva = dtFinal.NewRow();

                        drNueva["ALMClave"] = drCte.ALMClave;
                        drNueva["RUTClave"] = drCte.RUTClave;
                        drNueva["USUClave"] = drCte.USUClave;
                        drNueva["ClienteClave"] = drCte.ClienteClave;

                        //Productos
                        drCols = (from producto in Productos where (producto.Contenido == 0 && producto.Venta == 0 && producto.ALMClave == drCte.ALMClave && producto.RUTClave == drCte.RUTClave && producto.USUClave == drCte.USUClave && producto.ClienteClave == drCte.ClienteClave) orderby producto.ProductoClave select producto).ToList();
                        foreach (VPCMORProductosModel dr in drCols)
                        {
                            drNueva["Nom_" + dr.ProductoClave] = dr.CartonesHectolitraje;
                        }

                        //Total Productos
                        List<VPCMORTotalProductosModel> drCols2 = (from tproducto in TotalProductos where (tproducto.ALMClave == drCte.ALMClave && tproducto.RUTClave == drCte.RUTClave && tproducto.USUClave == drCte.USUClave && tproducto.ClienteClave == drCte.ClienteClave) select tproducto).ToList();
                        if (drCols2.Count() > 0)
                        {
                            drNueva["TotalCartonesHectolitraje"] = drCols2[0].TotalCartonesHectolitraje;
                        }

                        dtFinal.Rows.Add(drNueva);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }

                string empresaQuery = "select NombreEmpresa from Configuracion";
                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();


                string filename = nombreReport + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + ".xlsx";
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument x1 = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = x1.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();
                SheetData sd = new SheetData();

                Dictionary<int, Row> Rows = new Dictionary<int, Row>();

                createRow(1, ref Rows);

                createCell(1, ref Rows, "A1", CellValues.String, nombreEmpresa);

                createRow(2, ref Rows);
                createCell(2, ref Rows, "A2", CellValues.String, nombreReport);

                createRow(4, ref Rows);
                createCell(4, ref Rows, "A4", CellValues.String, "Agencia: " + nombreCedis);

                createRow(5, ref Rows);
                createCell(5, ref Rows, "A5", CellValues.String, "Ruta: " + RutasSplit);

                createRow(6, ref Rows);
                createCell(6, ref Rows, "A6", CellValues.String, "Periodo: " + sFecha.ToString("dd/MM/yyyy") + " - " + sFechaFin.ToString("dd/MM/yyyy"));

                //convertimos la unidadMedida a hectolitraje si es hectolitros
                if (unidadMedida != "Cartones")
                    unidadMedida = "Hectolitraje";
                createRow(7, ref Rows);
                createCell(7, ref Rows, "A7", CellValues.String, "Unidad: " + unidadMedida);

                createRow(8, ref Rows);
                createCell(8, ref Rows, "A8", CellValues.String, "Esquemas de Producto: " + pvProductos);

                int currentRow = 10;

                //Encabezados
                //En el antiguo reporteador hay un foreach que recorre las columnas del modelo de clientes, no he encontrado razon valida para ponerlo
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, "Agencia");
                createCell(currentRow, ref Rows, null, CellValues.String, "Ruta");
                createCell(currentRow, ref Rows, null, CellValues.String, "Código");
                createCell(currentRow, ref Rows, null, CellValues.String, "Cliente");

                foreach (DataColumn oCol in dtFinal.Columns)
                {
                    if (oCol.ColumnName != "ALMClave" && oCol.ColumnName != "RUTClave" && oCol.ColumnName != "USUClave" && oCol.ColumnName != "ClienteClave" && oCol.ColumnName != "TotalCartonesHectolitraje")
                    {
                        createCell(currentRow, ref Rows, null, CellValues.String, oCol.Caption);
                    }
                    else if (oCol.ColumnName == "TotalCartonesHectolitraje")
                    {
                        createCell(currentRow, ref Rows, null, CellValues.String, "Total Cartones/Hectolitraje");
                    }
                }
                currentRow++;

                //Renglones
                String sCEDI = "";
                String sRuta = "";
                String sRutaAnt = "";
                String sVendedor = "";
                String sVendedorAnt = "";
                List<Decimal> sTotales = new List<Decimal>();
                //int sTotalesblankcells = 0;
                Object nTotal = "";
                String sTabulaciones = "";
                int sTabulacionesCount = 0;
                double dTotalCliente = 0;

                List<string> sRegistro = new List<string>();

                foreach (DataRow drCliente in ClientesDt.Rows)
                {
                    try { 
                    dTotalCliente = 0;

                    //Totales
                    //Total por Ruta
                    if (sRutaAnt != "" && sRuta != drCliente["RUTClave"].ToString())
                    {
                        sTotales = new List<Decimal>();
                        sTabulacionesCount = 0;
                        foreach (DataColumn dc in dtFinal.Columns)
                        {
                            if (dc.DataType == typeof(double) || dc.DataType == typeof(Int64) || dc.DataType == typeof(int))
                            {
                                nTotal = dtFinal.Compute("sum([" + dc.ColumnName + "])", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "'");
                                if (typeof(DBNull) == nTotal.GetType())
                                {
                                    nTotal = 0;
                                }
                                sTotales.Add(Decimal.Parse(nTotal.ToString()));
                            }
                            else if (dc.ColumnName != "ALMNombre" && dc.ColumnName != "USUClave")
                            {
                                sTabulacionesCount++;
                            }
                        }

                        createRow(currentRow, ref Rows);
                        //creamos celdas vacias tantas veces diga la variable sTabulacionesCount
                        foreach (var i in Enumerable.Range(0, sTabulacionesCount))
                        {
                            createCell(currentRow, ref Rows, null, CellValues.String, "");
                        }
                        createCell(currentRow, ref Rows, null, CellValues.String, "Total Ruta:");
                        foreach (Decimal total in sTotales)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, total.ToString());
                        }
                        currentRow++;
                    }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    try { 
                    //Total por CEDI
                    if (sCEDI != "" && sCEDI != drCliente["ALMClave"].ToString())
                    {
                        sTotales = new List<Decimal>();
                        sTabulacionesCount = 0;
                        foreach (DataColumn dc in dtFinal.Columns)
                        {
                            if (dc.DataType == typeof(double) || dc.DataType == typeof(Int64) || dc.DataType == typeof(int))
                            {
                                nTotal = dtFinal.Compute("sum([" + dc.ColumnName + "])", "ALMClave = '" + sCEDI + "'");
                                if (typeof(DBNull) == nTotal.GetType())
                                {
                                    nTotal = 0;
                                }
                                sTotales.Add(Decimal.Parse(nTotal.ToString()));
                            }
                            else if (dc.ColumnName != "ALMNombre" && dc.ColumnName != "USUClave")
                            {
                                sTabulacionesCount++;
                            }
                        }
                        createRow(currentRow, ref Rows);
                        //creamos celdas vacias tantas veces diga la variable sTabulacionesCount
                        foreach (var i in Enumerable.Range(0, sTabulacionesCount))
                        {
                            createCell(currentRow, ref Rows, null, CellValues.String, "");
                        }

                        createCell(currentRow, ref Rows, null, CellValues.String, "TOTAL AGENCIA:");
                        foreach (Decimal total in sTotales)
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, total.ToString());
                        }
                        currentRow++;

                    }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                    try { 
                    //Agrupadores
                    if (sCEDI != drCliente["ALMClave"].ToString())
                    {
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, null, CellValues.String, "    Agencia: " + drCliente["ALMClave"].ToString() + " - " + drCliente["ALMNombre"].ToString());
                        sCEDI = drCliente["ALMClave"].ToString();
                        sRuta = "";
                        currentRow++;
                    }

                    if (sRuta != drCliente["RUTClave"].ToString())
                    {
                        if (sRuta != "")
                        {
                            currentRow++;
                        }
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, null, CellValues.String, "        Ruta: " + drCliente["RUTClave"].ToString() + " - " + drCliente["Descripcion"].ToString());
                        sRuta = drCliente["RUTClave"].ToString();
                        sRutaAnt = sRuta;
                        sVendedor = "";
                        currentRow++;
                    }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                    //Detalle
                    foreach (DataColumn dc in ClientesDt.Columns)
                    {
                        if (dc.ColumnName != "ALMNombre" && dc.ColumnName != "Descripcion" && dc.ColumnName != "USUClave" && dc.ColumnName != "VENNombre" && dc.ColumnName != "ClienteClave")
                        {
                            sRegistro.Add(drCliente[dc.ColumnName].ToString().Contains("01/01/1900") ? "" : drCliente[dc.ColumnName].ToString() == "0" ? "" : drCliente[dc.ColumnName].ToString());
                        }
                    }

                    var drCols3 = dtFinal.Select("ClienteClave = '" + drCliente["ClienteClave"].ToString() + "' and RUTClave = '" + drCliente["RUTClave"].ToString() + "' and ALMClave='" + drCliente["ALMClave"].ToString() + "'");
                    foreach (var dr in drCols3)
                    {
                        foreach (DataColumn dc in dtFinal.Columns)
                        {
                            if (dc.ColumnName != "ALMClave" && dc.ColumnName != "ALMNombre" && dc.ColumnName != "RUTClave" && dc.ColumnName != "USUClave" && dc.ColumnName != "ClienteClave")
                            {
                                sRegistro.Add(dr[dc.ColumnName].ToString() == "0" ? "" : dr[dc.ColumnName].ToString());
                            }
                        }
                    }

                    createRow(currentRow, ref Rows);
                    foreach (string reg in sRegistro)
                    {
                        Decimal temp;
                        if (Decimal.TryParse(reg, out temp))
                        {
                            createCell(currentRow, ref Rows, null, CellValues.Number, reg);
                        }
                        else
                        {
                            createCell(currentRow, ref Rows, null, CellValues.String, reg);
                        }
                    }
                    currentRow++;
                    sRegistro = new List<string>();
                }

                //Totales
                //Total por Ruta
                if (sRutaAnt != "")
                {
                    sTotales = new List<Decimal>();
                    sTabulacionesCount = 0;
                    foreach (DataColumn dc in dtFinal.Columns)
                    {
                        if (dc.DataType == typeof(double) || dc.DataType == typeof(Int64) || dc.DataType == typeof(int))
                        {
                            nTotal = dtFinal.Compute("sum([" + dc.ColumnName + "])", "ALMClave = '" + sCEDI + "' and RUTClave = '" + sRutaAnt + "'");
                            if (typeof(DBNull) == nTotal.GetType())
                            {
                                nTotal = 0;
                            }
                            sTotales.Add(Decimal.Parse(nTotal.ToString()));
                        }
                        else if (dc.ColumnName != "ALMNombre" && dc.ColumnName != "USUClave")
                        {
                            sTabulacionesCount++;
                        }
                    }
                    createRow(currentRow, ref Rows);
                    //creamos celdas vacias tantas veces diga la variable sTabulacionesCount
                    foreach (var i in Enumerable.Range(0, sTabulacionesCount))
                    {
                        createCell(currentRow, ref Rows, null, CellValues.String, "");
                    }

                    createCell(currentRow, ref Rows, null, CellValues.String, "Total Por Ruta:");
                    foreach (Decimal total in sTotales)
                    {
                        createCell(currentRow, ref Rows, null, CellValues.Number, total.ToString());
                    }
                    currentRow++;

                }

                //Total por CEDI
                if (sCEDI != "")
                {
                    sTotales = new List<Decimal>();
                    sTabulacionesCount = 0;
                    foreach (DataColumn dc in dtFinal.Columns)
                    {
                        if (dc.DataType == typeof(double) || dc.DataType == typeof(Int64) || dc.DataType == typeof(int))
                        {
                            nTotal = dtFinal.Compute("sum([" + dc.ColumnName + "])", "ALMClave = '" + sCEDI + "'");
                            if (typeof(DBNull) == nTotal.GetType())
                            {
                                nTotal = 0;
                            }
                            sTotales.Add(Decimal.Parse(nTotal.ToString()));
                        }
                        else if (dc.ColumnName != "ALMNombre" && dc.ColumnName != "USUClave")
                        {
                            sTabulacionesCount++;
                        }
                    }
                    createRow(currentRow, ref Rows);
                    //creamos celdas vacias tantas veces diga la variable sTabulacionesCount
                    foreach (var i in Enumerable.Range(0, sTabulacionesCount))
                    {
                        createCell(currentRow, ref Rows, null, CellValues.String, "");
                    }

                    createCell(currentRow, ref Rows, null, CellValues.String, "TOTAL AGENCIA:");
                    foreach (Decimal total in sTotales)
                    {
                        createCell(currentRow, ref Rows, null, CellValues.Number, total.ToString());
                    }
                    currentRow++;

                }

                sTotales = new List<Decimal>();
                sTabulacionesCount = 0;
                foreach (DataColumn dc in dtFinal.Columns)
                {
                    if (dc.DataType == typeof(double) || dc.DataType == typeof(Int64) || dc.DataType == typeof(int))
                    {
                        nTotal = dtFinal.Compute("sum([" + dc.ColumnName + "])", "");
                        if (typeof(DBNull) == nTotal.GetType())
                        {
                            nTotal = 0;
                        }
                        sTotales.Add(Decimal.Parse(nTotal.ToString()));
                    }
                    else if (dc.ColumnName != "ALMNombre" && dc.ColumnName != "USUClave")
                    {
                        sTabulacionesCount++;
                    }
                }
                currentRow += 2;
                createRow(currentRow, ref Rows);
                //creamos celdas vacias tantas veces diga la variable sTabulacionesCount
                foreach (var i in Enumerable.Range(0, sTabulacionesCount))
                {
                    createCell(currentRow, ref Rows, null, CellValues.String, "");
                }

                createCell(currentRow, ref Rows, null, CellValues.String, "TOTAL GLOBAL:");
                foreach (Decimal total in sTotales)
                {
                    createCell(currentRow, ref Rows, null, CellValues.Number, total.ToString());
                }
                currentRow++;







                foreach (var row in Rows)
                {
                    sd.Append(row.Value);
                }

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = nombreReport;
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);

                x1.WorkbookPart.Workbook = wb;
                x1.WorkbookPart.Workbook.Save();
                x1.Close();

                ArchivoXlsModel archivo = new ArchivoXlsModel();
                archivo.archivo = ms.ToArray();
                archivo.nombre = filename;
                return archivo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        void createRow(int id, ref Dictionary<int, Row> Rows)
        {
            Rows.Add(id, new Row() { RowIndex = (UInt32)id });
        }

        void createCell(int idRow, ref Dictionary<int, Row> Rows, string cellReference, DocumentFormat.OpenXml.Spreadsheet.CellValues dt, string cellValue)
        {
            Cell cell = new Cell();
            if (cellReference != null)
                cell.CellReference = cellReference;
            cell.DataType = dt;
            cell.CellValue = new CellValue(cellValue);
            cell.CellValue.Space = SpaceProcessingModeValues.Preserve;
            if (Rows.ContainsKey(idRow))
            {
                Rows[idRow].Append(cell);
            }
        }

        bool ordenProductos(int numReporte)
        {
            string query = "Select * from OrdenProductos (NOLOCK) where ReporteW = '" + numReporte + "'";
            List<DataTable> dt = Connection.Query<DataTable>(query, null, null, true, 9000).ToList();

            if (dt.Count > 0)
                return true;
            else
                return false;
        }
    }

    class VPCMORClientesModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public string RUTClave { get; set; }
        public string Descripcion { get; set; }
        public string USUClave { get; set; }
        public string VENNombre { get; set; }
        public string ClienteClave { get; set; }
        public string CLIClave { get; set; }
        public string CLINombre { get; set; }
    }

    class VPCMORProductosModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public string RUTClave { get; set; }
        public string Descripcion { get; set; }
        public string USUClave { get; set; }
        public string VENNombre { get; set; }
        public string ClienteClave { get; set; }
        public string CLIClave { get; set; }
        public string CLINombre { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public int Contenido { get; set; }
        public int Venta { get; set; }
        public Decimal CartonesHectolitraje { get; set; }
    }

    class VPCMORTotalProductosModel
    {
        public string ALMClave { get; set; }
        public string ALMNombre { get; set; }
        public string RUTClave { get; set; }
        public string Descripcion { get; set; }
        public string USUClave { get; set; }
        public string VENNombre { get; set; }
        public string ClienteClave { get; set; }
        public string CLIClave { get; set; }
        public string CLINombre { get; set; }
        public Decimal TotalCartonesHectolitraje { get; set; }
    }


}