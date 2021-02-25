using DevExpress.XtraReports.UI;
using eRoute.Controllers.API;
using eRoute.Controllers.API.Reports;
using eRoute.Models;
using eRoute.Models.ReportesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DevExpress.XtraPrinting;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.IO;
using System.Text;

namespace eRoute.Controllers
{
    public class ReportsController : Controller
    {
        public ActionResult DynamicReport(string id)
        {
            if (Session["URL"] != null)
            {
                ViewBag.VAVClave = Convert.ToInt32(id);
                return View("DynamicReport");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SetDynamicConditions(string DataListObject, int VAVClave = 0, string ReportName = "")
        {
            try
            {
                ReportGetCondition report = new ReportGetCondition();
                IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
                string query;
                string parameters;

                string queryParameters = string.Format(@"SELECT [VAV].[Descripcion] FROM [dbo].[FiltrosDinamicos] AS [FD] (NOLOCK)
                                                                     INNER JOIN [dbo].[VAVDescripcion] AS [VAV] (NOLOCK) ON [FD].[TipoFiltro] = [VAV].[VAVClave] AND [VARCodigo] = 'TIPFIR'
                                                                     WHERE [FD].[RepDinID] = {0} ORDER BY [FD].[TipoFiltro]", VAVClave);
                string[] q = Connection.Query<string>(queryParameters, null, null, true, 9000).ToArray();
                string[] listValours = DataListObject.Split('&');
                if (listValours.Length > q.Length && q.Contains("FECHA"))
                {
                    q.SetValue("FECHAINCIAL,FECHAFINAL", q.FindIndex(value => value == "FECHA"));
                }

                parameters = String.Join(",", q);
                string queryReport = @"SELECT [Consulta] FROM [dbo].[ReporteDinamico] (NOLOCK) WHERE [RepDinID] = " + VAVClave;
                query = Connection.Query<string>(queryReport, null, null, true, 9000).FirstOrDefault();
                List<string> param = new List<string>();
                foreach (var item in parameters.Split(','))
                {
                    param.Add("@" + item);
                }
                query = string.Format(query, param.ToArray());

                Session["ReportName"] = ReportName;
                Session["DataListObject"] = DataListObject;
                Session["Query"] = query;
                Session["Parameters"] = parameters;
                return Json("");
            }
            catch (Exception ex) { return Json(ex.Message); }
        }

        public ActionResult GetDynamicReport()
        {
            try
            {
                string reportName = Session["ReportName"].ToString();
                string dataListObject = Session["DataListObject"].ToString();
                string query = Session["Query"].ToString();
                string parameters = Session["Parameters"].ToString();
                DynamicExcelGenerator excel = new DynamicExcelGenerator();
                XtraReport response = new XtraReport();
                if (!excel.GetReport(reportName, dataListObject, query, parameters))
                    response = null;

                if (response == null)
                {
                    return View("Empty");
                }
                else
                {
                    return View(response);
                }
            }
            catch (Exception ex)
            {
                return View("ReporteNoExiste");
            }
        }

        public ActionResult Index(string VAVClave)
        {
            if (Session["URL"] != null)
            {
                int Clave = Convert.ToInt32(VAVClave);
                ViewBag.VAVClave = Clave;

                switch (Clave)
                {
                    case 0:
                        return View("DynamicReportW");
                    case 1:
                        return View("R001Facturas");
                    case 2:
                        return View("R002Ventas");
                    case 3:
                        return View("EfectividadPorRuta");
                    case 9:
                        return View("TiemposEnRuta");
                    case 10:
                        return View("R010DevolucionesYCambiosDelCliente");
                    case 14:
                        return View("R014InformeVentaEsquema");
                    case 16:
                        return View("R016VentaEsquemaproducto");
                    case 18:
                        return View("R018Cargas");
                    case 19:
                        return View("R019Liquidacion");
                    case 20:
                        return View("R020MovSinInventarioSinVisita");
                    case 21:
                        return View("R021MovSinInventarioEnVisitaGUA");
                    case 24:
                        return View("R024VentasPorVendedor");
                    case 26:
                        return View("R026Liquidacion");
                    case 27:
                        return View("R027DevolucionesYCambiosPorVendedor");
                    case 32:
                        return View("R032VentaDiario");
                    case 33:
                        return View("DiarioDeActividades");
                    case 34:
                        return View("FiltroUno"); //View("IndicadoresDeVenta");
                    case 36:
                        return View("R036ProductoOtorgadoPromo");
                    case 37:
                        return View("VentasGAT");
                    case 46:
                        return View("R046ClientesPorRuta");
                    case 48:
                        return View("R048LiquidacionDPS");
                    case 52:
                        return View("R052ClientesNoVisitados");
                    case 53:
                        return View("PuntosDeRecorrido");
                    case 57:
                        return View("R057ResumenDeVentasPorRutaYVendedor");
                    case 58:
                        return View("R058ResumenVentaClienteMOO");
                    case 64:
                        return View("R064TiemposEnRuta");
                    case 66:
                        return View("R066ClientesYActivos");
                    case 69:
                        return View("AnalisisDeSaldosMOO");
                    case 71:
                        return View("R071Liquidacion");
                    case 72:
                        return View("Pedidos");
                    case 75:
                        return View("R075CobranzaMultiple");
                    case 76:
                        return View("R076Liquidacion");
                    case 77:
                        return View("R077DevolucionesComision");
                    case 51://Encuestas                     
                    case 79://Encuestas Disposur
                        return View("ExportarEncuestas");
                    case 80:
                        return View("R080Liquidacion");
                    case 83:
                        return View("PuntosPorCliente");
                    case 87:
                        return View("R087VentaPorClienteALT");
                    case 88:
                        return View("R088FacturacionElectronica");
                    case 89:
                        return View("R089ResumenDeVentasPorRutaYVendedor");
                    case 92:
                        return View("R092VentasPorMarca");
                    case 96:
                        return View("R096AnalisisSaldoSIE");
                    case 97:
                        return View("R097ResumenDeVentasPorRutaYVendedor");
                    case 103:
                        return View("R103VentaDiario");
                    case 108:
                        return View("R108TotalVentasELE");
                    case 112:
                        return View("DocumentosConSaldo");
                    case 113:
                        return View("LiquidacionLaFlorida");
                    case 116:
                        return View("PuntosGPS");
                    case 118:
                        return View("ClientesSinVenta");
                    case 124:
                        return View("DescargaEnvaseALT");
                    case 130:
                        return View("R130PedidosPreventaDetallado");
                    case 131:
                        return View("R131Liquidacion");
                    case 133:
                        return View("R133ArrastreInventarioALT");
                    case 135:
                        return View("R135Sincronizacion");
                    case 136:
                        return View("ImproductividadXCliente");
                    case 137:
                        return View("ProximidadRIP");
                    case 138:
                        return View("ScoreCard");
                    case 139:
                        return View("EfectividadVisitaRIP");
                    case 140:
                        return View("R140VentaMensual");
                    case 142:
                        return View("CargaSugeridaRIP");
                    case 143:
                        return View("ListaDeSurtimientoCOS");
                    case 144:
                        return View("PlandeTrabajoSemanal");
                    case 145:
                        return View("ActividadesAcumuladoCOS");
                    case 146:
                        return View("ResumenTiempoMovimientos");
                    case 147:
                        return View("InformeCuadreVentas");
                    case 148:
                        return View("ReporteClientesVisVsPlanTrabajo");
                    case 150:
                        return View("InformeCLientesSinVisitaSinVenta");
                    case 153:
                        return View("R153LibroDeRuta");
                    case 156:
                        return View("R156KardexInventarioProducto");
                    case 157:
                        return View("DiarioActividadesVit");
                    case 160:
                        return View("ClienteEsquemasVit");
                    case 161:
                        return View("PedidoPromedioPorCliente");
                    case 162:
                        return View("CierreDeDiaGrupoMOO");
                    case 163:
                        return View("VentasPorClienteMOR");
                    case 164:
                        return View("ComparativoVentaMensualMOO");
                    case 165:
                        return View("ClientesInformacionBaseMOR");
                    case 166:
                        return View("CoberturaPorProductoMOR");
                    case 167:
                        return View("VentasPorDiaMOR");
                    case 168:
                        return View("GAPMOR");
                    case 169:
                        return View("VentasPorProductoMOR");
                    case 171:
                        return View("PromocionesMOR");
                    case 173:
                        return View("LiquidacionMOR");
                    case 183:
                        return View("VentaDetalladaMOR");
                    case 187:
                        return View("R187Liquidacion");
                    case 189:
                        return View("PromocionClienteMOR");
                    case 190:
                        return View("R190KardexDeExistencia");
                    case 194:
                        return View("R194VentasPorProducto");
                    case 195:
                        return View("VentaClienteOportuno");
                    case 196:
                        return View("R196ResumenTiemposMovimientosCOS");
                    case 198:
                        return View("EstatusPedidosSAPChocolatera");
                    case 199:
                        return View("R199LiquidacionBRA");
                    case 200:
                        return View("InventarioVentasRIK");
                    case 201:
                        return View("LiquidacionRIK");
                    case 202:
                        return View("CumplimientoVisitaGeneralGHR");
                    case 203://Por Ruta
                        return View("CumplimientoVisitaRutaGHR");
                    case 204://Por Cliente
                        return View("CumplimientoVisitaGHR");
                    case 207:
                        return View("R207ExistenciasDeProducto");
                    case 209://Por Cliente
                        return View("NecesidadesDeCargaUNI");
                    case 210://Por Cliente
                        return View("HojaDeLiquidacionUNI");
                    case 211:
                        return View("R211InventarioGeneralNUT");
                    case 212:
                        return View("VentasDetalladoCompleto");
                    case 213:
                        return View("CargasRealesporPedido");
                    case 214:
                        return View("VentasporCodigoDetalladoUNI");
                    case 217:
                        return View("CargasInicialesporRutaAlt");
                    case 218:
                        return View("CargasFinalesporRutaAlt");
                    case 220:
                        return View("VentasvsAnioAnterior");
                    case 221:
                        return View("ConcentradoMovAlmacenALT");
                    case 224:
                        return View("InventarioAlmacenALT");
                    case 226:
                        return View("CargaPorDiaBYD");
                    case 227:
                        return View("VentasBYD");
                    case 228:
                        return View("ReporteCFDI");
                    case 234:
                        return View("R234ResumenDevolucionClienteLEO");
                    case 235:
                        return View("TiemposEnRutaINDAR");
                    case 236:
                        return View("LiquidacionLPB");
                    case 238:
                        return View("VentasLPB");
                    case 240:
                        return View("LiquidacionAfrima");
                    case 241:
                        return View("GlobalPorRutaAFR");
                    case 242:
                        return View("R242Liquidacion");
                    case 243:
                        return View("PedidosPreventaAltena");
                    case 244:
                        return View("IndicadoresOJAI");
                    case 245:
                        return View("PromocionesNvoMOR");
                    case 246:
                        return View("CarteraMensualXRutaPDR");
                    case 247:
                        return View("DiarioDeActividades");
                    case 248:
                        return View("ventasParaInterfazHOR");
                    case 249:
                        return View("CargasDEL");
                    case 250:
                        return View("CifrasControlBYD");
                    case 251:
                        return View("VendedorCliModelListPreBYD");
                    case 252:
                        return View("LiquidacionDEL");
                    case 253:
                        return View("LiquidacionTUC");
                    case 254:
                        return View("ComisionesTUC");
                    case 255:
                        return View("MovimientosPorLoteDEL");
                    case 256:
                        return View("informeVentasXadisROV");
                    case 257:
                        return View("FacturaGlobalPDR");
                    case 258:
                        return View("FiltroUno");
                    case 259:
                        return View("R259DocumentosConSaldo");
                    case 260:
                        return View("ventasXadisSIE");
                    case 261:
                        return View("PedidosConfirmadosPRS");
                    case 262:
                        return View("R262Ventas");
                    case 263:
                        return View("R263ImproductividadImagenes");
                    case 264:
                        return View("R264ClientesProspectos");
                    case 265:
                        return View("R265ListadoDeClientesGenerico");
                    case 266:
                        return View("R266ListaDePreciosGenerico");
                    case 267:
                        return View("LiquidacionMelbrin");
                    case 268:
                        return View("ReporteLiquidacionEfectivoDIV");
                    case 269:
                        return View("R269Devoluciones");
                    case 270:
                        return View("R270DescargasDIV");
                    case 271:
                        return View("R271DocumentoConSaldoDIV");
                    case 273:
                        return View("R273InventarioXadis");
                    case 274:
                        return View("R274LiquidacionROV");
                    case 275:
                        return View("R275CumplimientoVisitaRutaGHR2");
                    case 276:
                        return View("TiemposEnRutaMED");
                    case 277:
                        return View("R277LiquidacionNOR");
                    default:
                        return View("ReporteNoExiste");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult SetCondition(List<ReportFilterModel>[] dataListObject, string[] dataList, List<ReportFilterModel> Routes, List<ReportFilterModel> Customers, List<ReportFilterModel> Sellers, List<ReportFilterModel> Lots, List<ReportFilterModel> Products, List<ReportFilterModel> Supervisors, List<ReportFilterModel> ProductSchemes, List<ReportFilterModel> CustomerSchemes, List<ReportFilterModel> PriceList, List<ReportFilterModel> Polls, List<ReportFilterModel> ObjectName, List<ReportFilterModel> Warehouses, int VAVClave = 0, bool ReportType = false, bool ReportFilter = false, string InitialDate = "", string FinalDate = "", string CEDIS = "", string NameCEDIS = "", double Budget = 0, string ReportName = "", string Promotion = "", string UnitMeasure = "", string StatusDate = "")
        {
            try
            {
                ReportGetCondition condition = new ReportGetCondition();
                StringBuilder listObject = new StringBuilder();
                if (dataListObject != null)
                {
                    if (dataListObject.Count() != 0)
                    {
                        foreach (var x in dataListObject)
                        {
                            listObject.Append(x.Equals(dataListObject.Last()) ? condition.Get(x) : condition.Get(x) + "&");
                        }
                    }
                }
                if (dataList != null)
                {
                    if (dataList.Count() != 0)
                    {
                        foreach (var x in dataList)
                        {
                            listObject.Append(dataListObject.Count() != 0 && x.Equals(dataList.First()) ? "&" : "");
                            listObject.Append(x.Equals(dataList.Last()) ? x : x + "&");
                        }
                    }
                }

                Session["listObject"] = (listObject == null ? "" : listObject.ToString());
                Session["Routes"] = (Routes == null ? "" : condition.Get(Routes));
                Session["Sellers"] = (Sellers == null ? "" : condition.Get(Sellers));
                Session["Customers"] = (Customers == null ? "" : condition.Get(Customers));
                Session["ProductSchemes"] = (ProductSchemes == null ? "" : condition.Get(ProductSchemes));
                Session["CustomerSchemes"] = (CustomerSchemes == null ? "" : condition.Get(CustomerSchemes));
                Session["PriceList"] = (PriceList == null ? "" : condition.Get(PriceList));
                Session["Lots"] = (Lots == null ? "" : condition.Get(Lots));
                Session["Supervisors"] = (Supervisors == null ? "" : condition.Get(Supervisors));
                Session["Polls"] = (Polls == null ? "" : condition.Get(Polls));
                Session["Products"] = (Products == null ? "" : condition.Get(Products));
                Session["Warehouses"] = (Warehouses == null ? "" : condition.Get(Warehouses));
                Session["ObjectName"] = (ObjectName == null ? "" : condition.Get(ObjectName, true));
                Session["VAVClave"] = VAVClave;
                Session["ReportType"] = ReportType;
                Session["ReportFilter"] = ReportFilter;
                Session["InitialDate"] = InitialDate;
                Session["FinalDate"] = FinalDate;
                Session["CEDIS"] = CEDIS;
                Session["NameCEDIS"] = NameCEDIS;
                Session["Budget"] = Budget;
                Session["ReportName"] = ReportName;
                Session["Promotion"] = Promotion;
                Session["UnitMeasure"] = UnitMeasure;
                Session["StatusDate"] = StatusDate;
                return Json("");
            }
            catch (Exception ex) { return Json(ex.Message); }
        }

        public ActionResult GetCondition(List<ReportFilterModel> Lotes, List<GetRoutesModel> Routes, List<Clients> Clientes, List<GetSellerModel> Seller, List<GetProductsModel> Products, List<GetProductsSchemeModel> ProductsSchema, string nombreReport = "", string init = "", string end = "", string unidadMedida = "", string CENClave = "", string promocion = "", string Presupuesto = "", bool reportType = false, int vavclave = 1, string lote = "", string NombreProductos = "", string Cedis = "", string nombreCedis = "", string dateStatus = "", string extra1 = "", string extra2 = "")
        {
            try
            {
                Session["listObject"] = "";
                Session["Warehouses"] = "";
                Session["Routes"] = "";
                Session["Sellers"] = "";
                Session["Customers"] = "";
                Session["ProductSchemes"] = "";
                Session["CustomerSchemes"] = "";
                Session["PriceList"] = "";
                Session["Lots"] = "";
                Session["Supervisors"] = "";
                Session["Polls"] = "";
                Session["Products"] = "";
                Session["ObjectName"] = "";
                Session["VAVClave"] = "";
                Session["ReportType"] = "";
                Session["ReportFilter"] = "false";
                Session["InitialDate"] = "";
                Session["FinalDate"] = "";
                Session["CEDIS"] = "";
                Session["NameCEDIS"] = "";
                Session["Budget"] = "0";
                Session["ReportName"] = "";
                Session["Promotion"] = "";
                Session["UnitMeasure"] = "";
                Session["StatusDate"] = "";
                Session["extra1"] = "";
                Session["extra2"] = "";

                ReportGetCondition condition = new ReportGetCondition();
                ConditionModel cm = new ConditionModel();
                cm = condition.Get(Lotes, Routes, Clientes, Seller, Products, ProductsSchema, nombreReport, Cedis, nombreCedis, dateStatus, init, end, vavclave, reportType, unidadMedida, CENClave, promocion, Presupuesto, NombreProductos);

                Session["VAVClave"] = cm.VAVClave;
                Session["Cedis"] = cm.Cedis;
                Session["nombreCedis"] = cm.nombreCedis;
                Session["FechaFinal"] = cm.FechaFinal;
                Session["FechaInicial"] = cm.FechaInicial;
                Session["dateStatus"] = cm.Rango;
                Session["Clientes"] = cm.Clientes;
                Session["Vendedor"] = cm.Vendedor;
                Session["Productos"] = cm.Productos;
                Session["nombreProductos"] = cm.NombreProductos;
                Session["unidadMedidad"] = cm.unidadMedida;
                Session["CENClave"] = cm.CENClave;
                Session["promocion"] = cm.promocion;
                Session["Presupuesto"] = cm.Presupuesto;
                Session["nombreReport"] = cm.nombreReport;
                Session["Rutas"] = cm.Rutas;
                Session["Lotes"] = cm.Lotes;
                Session["reportType"] = reportType;
                Session["extra1"] = extra1;
                Session["extra2"] = extra2;
                return Json(cm);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult GetObjectString(List<ReportFilterModel> Object)
        {
            return Json(Object != null ? new ReportGetCondition().Get(Object) : null);
        }

        public ActionResult GetRoutesStiring(List<GetRoutesModel> Routes)
        {
            return Json(new ReportGetCondition().BuildRutas(Routes));
        }

        public ActionResult GetCedisString(List<GetCedisModelPro> CedisList = null, string Cedis = null)
        {
            return Json(new ReportGetCondition().BuildCedis(CedisList, Cedis));
        }

        public ActionResult GetSellersString(List<GetSellerModel> SellersList = null, string Sellers = null)
        {
            return Json(new ReportGetCondition().BuildSellers(SellersList, Sellers));
        }

        public ActionResult GetClientSchemeString(List<ClientSchemaModel> ClientSchemeList = null, string ClientScheme = null)
        {
            return Json(new ReportGetCondition().BuildClientScheme(ClientSchemeList, ClientScheme));
        }

        public ActionResult Ver(string nombreReport = "", string Cedis = "", string nombreCedis = "", string FechaInicial = "", string FechaFinal = "", string dateStatus = "", string Rutas = "", string Lotes = "", string Clientes = "", string Vendedor = "", string Productos = "", string nombreProductos = "", string unidadMedida = "", string CENClave = "", string promocion = "", string Presupuesto = "", bool detallado = false, string extra1 = "", string extra2 = "", int VAVClave = 0, bool reportType = false)
        {
            try
            {
                ReportGetCondition report = new ReportGetCondition();
                string listObject = Session["listObject"].ToString();
                string Routes = Session["Routes"].ToString();
                string Customers = Session["Customers"].ToString();
                string Sellers = Session["Sellers"].ToString();
                string Lots = Session["Lots"].ToString();
                string Products = Session["Products"].ToString();
                string Warehouses = Session["Warehouses"].ToString();
                string Supervisors = Session["Supervisors"].ToString();
                string ProductSchemes = Session["ProductSchemes"].ToString();
                string CustomerSchemes = Session["CustomerSchemes"].ToString();
                string PriceList = Session["PriceList"].ToString();
                string Polls = Session["Polls"].ToString();
                string ObjectName = Session["ObjectName"].ToString();
                VAVClave = int.Parse(Session["VAVClave"].ToString());
                bool ReportType = bool.Parse(Session["ReportType"].ToString());
                bool ReportFilter = bool.Parse(Session["ReportFilter"].ToString());
                string InitialDate = Session["InitialDate"].ToString();
                string FinalDate = Session["FinalDate"].ToString();
                string CEDIS = Session["CEDIS"].ToString();
                string NameCEDIS = Session["NameCEDIS"].ToString();
                double Budget = double.Parse(Session["Budget"].ToString());
                string ReportName = Session["ReportName"].ToString();
                string Promotion = Session["Promotion"].ToString();
                string UnitMeasure = Session["UnitMeasure"].ToString();
                string StatusDate = Session["StatusDate"].ToString();
                IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
                string CompanyName = "SELECT NombreEmpresa FROM Configuracion (NOLOCK)";
                CompanyName = Connection.Query<string>(CompanyName, null, null, true, 9000).FirstOrDefault();
                const string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK)";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream CompanyLogo = new MemoryStream(byteArrayIn);
                bool exportToExcel = false;
                string query;
                string parameters;

                string pvCondicion = "";
                string pvCondicion1 = "";
                string pvCondicion2 = "";
                string pvCondicion3 = "";
                string pvCondicion4 = "";
                string pvCondicion5 = "";
                string pvCondicion6 = "";
                string pvCondicionProd = "";
                string pvCondicionKm = "";
                string pvCondicionCEDI = "";
                string pvProductos = Productos;
                string where = "where 1 = 1 ";
                string RutasSplit = String.Empty;
                string LotesSplit = String.Empty;
                string ClientesSplit = String.Empty;
                string VendedorSplit = String.Empty;
                string ProductosSplit = String.Empty;
                string nombreProductosSplit = String.Empty;
                string whereAlmacen = "";
                string whereFechaDia = "";
                string whereEsquema = "";
                string sEsquemasProd = "";
                string sFecha1 = "";
                String sFechaAnioActual;
                String sFechaAnioAnterior;

                VAVClave = int.Parse(Session["VAVClave"].ToString());
                Cedis = (Session["Cedis"] == null ? "" : Session["Cedis"].ToString());
                nombreCedis = (Session["nombreCedis"] == null ? "" : Session["nombreCedis"].ToString());
                FechaFinal = (Session["FechaFinal"] == null ? "" : Session["FechaFinal"].ToString());
                FechaInicial = (Session["FechaInicial"] == null ? "" : Session["FechaInicial"].ToString());
                dateStatus = (Session["dateStatus"] == null ? "" : Session["dateStatus"].ToString());
                Clientes = (Session["Clientes"] == null ? "" : Session["Clientes"].ToString());
                Vendedor = (Session["Vendedor"] == null ? "" : Session["Vendedor"].ToString());
                Productos = (Session["Productos"] == null ? "" : Session["Productos"].ToString());
                nombreProductos = (Session["nombreProductos"] == null ? "" : Session["nombreProductos"].ToString());
                unidadMedida = (Session["unidadMedidad"] == null ? "" : Session["unidadMedidad"].ToString());
                CENClave = (Session["CENClave"] == null ? "" : Session["CENClave"].ToString());
                promocion = (Session["promocion"] == null ? "" : Session["promocion"].ToString());
                Presupuesto = (Session["Presupuesto"] == null ? "" : Session["Presupuesto"].ToString());
                nombreReport = (Session["nombreReport"] == null ? "" : Session["nombreReport"].ToString());
                Rutas = (Session["Rutas"] == null ? "" : Session["Rutas"].ToString());
                Lotes = (Session["Lotes"] == null ? "" : Session["Lotes"].ToString());
                reportType = (Session["reportType"] == null ? false : bool.Parse(Session["reportType"].ToString()));
                extra1 = (Session["extra1"] == null ? "" : Session["extra1"].ToString());
                extra2 = (Session["extra2"] == null ? "" : Session["extra2"].ToString());

                if (!String.IsNullOrEmpty(Lotes) || Lotes == "null")
                    LotesSplit = Lotes.Replace("'", "");
                if (!String.IsNullOrEmpty(Rutas) || Rutas == "null")
                    RutasSplit = Rutas.Replace("'", "");
                if (!String.IsNullOrEmpty(Clientes) || Clientes == "null")
                    ClientesSplit = Clientes.Replace("'", "");
                if (!String.IsNullOrEmpty(Vendedor) || Vendedor == "null")
                    VendedorSplit = Vendedor.Replace("'", "");
                if (!String.IsNullOrEmpty(Productos) || Productos == "null")
                    ProductosSplit = Productos.Replace("'", "");
                if (!String.IsNullOrEmpty(nombreProductos) || nombreProductos == "null")
                    nombreProductosSplit = nombreProductos.Replace("'", "");

                int nPresupuesto = 0;
                if (Presupuesto != null && Presupuesto != "")
                {
                    try
                    {
                        nPresupuesto = int.Parse(Presupuesto);
                    }
                    catch (Exception) { }
                }

                DynamicExcelGenerator excel = new DynamicExcelGenerator();
                XtraReport response = new XtraReport();
                ArchivoXlsModel archivo = new ArchivoXlsModel();
                switch (VAVClave)
                {
                    case 1:
                        response = new R001Facturas().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers, CustomerSchemes, Customers, ReportType);
                        break;
                    case 2:
                        if (ReportType)
                        {
                            response = new R002VentasDetallado().GetReport(ReportName + " Detallado", CompanyName, CompanyLogo, ObjectName, NameCEDIS, CEDIS, Routes, Sellers, Customers, InitialDate, FinalDate, ReportFilter);
                        }
                        else
                        {
                            response = new R002VentasGeneral().GetReport(ReportName + " General", CompanyName, CompanyLogo, ObjectName, NameCEDIS, CEDIS, Routes, Sellers, Customers, InitialDate, FinalDate, ReportFilter);
                        }
                        break;
                    case 3:
                        pvCondicion = where + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.strWhereCedis(Cedis, "ALN.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "DIA.FechaCaptura");
                        response = new MEfectividadPorRuta().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, VendedorSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, detallado);
                        break;
                    case 9:
                        response = new TiemposEnRuta().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers, ReportFilter);
                        break;
                    case 10:
                        response = new R010DevolucionesYCambiosDelCliente().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate, FinalDate, Routes, Products, ProductSchemes, Customers);
                        break;
                    case 14:
                        response = new R014InformeVentaEsquema().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers);
                        break;
                    case 16:
                        response = new R016VentaEsquemaProducto().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers);
                        break;
                    case 18:
                        response = new Cargas().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, CEDIS, Sellers, InitialDate, FinalDate);
                        break;
                    case 19:
                        response = new R019Liquidacion().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, ObjectName, Sellers, InitialDate, FinalDate);
                        break;
                    case 20:
                        response = new R020MovSinInvSinVisita().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, ReportType, Sellers);
                        break;
                    case 21:
                        response = new R021MovSinInvEnVisita().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers, CustomerSchemes, Customers, ReportType);
                        break;
                    case 24:
                        response = new R024VentasPorVendedor().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate, FinalDate);
                        break;
                    case 26:
                        response = new R026Liquidacion().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, Sellers, InitialDate, FinalDate);
                        break;
                    case 27:
                        response = new R027DevolucionesYCambiosPorVendedor().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate, FinalDate, ObjectName, Sellers, Customers);
                        break;
                    case 32:
                        if (Rutas == "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorId") + report.strWhereCedis(Cedis, "ALM.Clave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "TRP.FechaHoraAlta");
                        }
                        else
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "VIS.RUTClave") + report.strWhereCedis(Cedis, "ALM.Clave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "TRP.FechaHoraAlta");
                        }
                        //response = new VentaDiarioCOS().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, CEDIS, Routes, Sellers, InitialDate, FinalDate, ReportFilter);
                        break;
                    case 33:
                        response = new MDiarioDeActividades().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Routes, Sellers, InitialDate, FinalDate, ReportFilter);
                        break;
                    case 34:
                        response = new MIndicadoresDeVenta().GetReport(nombreReport, CompanyName, Cedis, FechaInicial, FechaFinal, Vendedor, Rutas, nombreCedis, VendedorSplit, RutasSplit);
                        break;
                    case 36:
                        response = new R036ProductoOtorgadoPromocion().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers);
                        break;
                    case 37:
                        if (ReportType)
                        {
                            response = new VentasGATDetallado().GetReport(ReportName + " Detallado", CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Routes, Sellers, Customers, InitialDate, FinalDate, ReportFilter);
                        }
                        else
                        {
                            response = new VentasGATGeneral().GetReport(ReportName + " General", CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Routes, Sellers, Customers, InitialDate, FinalDate, ReportFilter);
                        }
                        break;
                    case 46:
                        response = new R046ClientesPorRuta().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers, ReportFilter);
                        break;
                    case 48:
                        response = new R048LiquidacionDPS().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, Sellers);
                        break;
                    case 52:
                        R052ClientesNoVisitados rptCliNoVis = new R052ClientesNoVisitados();
                        if (!rptCliNoVis.GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes))
                            response = null;
                        break;
                    case 75:
                        response = new R075CobranzaMultiple().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, CEDIS, Sellers, InitialDate, FinalDate);
                        break;
                    case 51: //Encuestas
                    case 79: //Encuestas Disposur
                        EncuestasAplicadas rptEnc = new EncuestasAplicadas();
                        if (!rptEnc.GetReport(ReportName, CompanyName, VAVClave, Polls, InitialDate, FinalDate, Routes))
                            response = null;
                        break;
                    case 53:
                        pvCondicion = report.strWhereRutas(Rutas, "GPS.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "DIA.FechaCaptura");
                        response = new PuntosRecorrido().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, FechaInicial, FechaFinal);
                        break;
                    case 57:
                        R057ResumenDeVentasPorRutaYVendedor r057 = new R057ResumenDeVentasPorRutaYVendedor();
                        if (!r057.GetReport(ReportName, CompanyName, NameCEDIS, CEDIS, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 58:
                        R058ResumenVentaClienteMOO rptVentaCliente = new R058ResumenVentaClienteMOO();
                        if (!rptVentaCliente.GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers, CustomerSchemes))
                            response = null;
                        break;
                    case 64:
                        response = new R064TiemposEnRuta().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, ObjectName, Sellers, InitialDate, FinalDate);
                        break;
                    case 66:
                        R066ClientesYActivos r066 = new R066ClientesYActivos();
                        if (!r066.GetReport(ReportName, CompanyName, NameCEDIS, CEDIS, InitialDate, FinalDate, Routes, Sellers, Customers, ReportFilter, ReportType))
                            response = null;
                        break;
                    case 69:
                        response = new AnalisisDeSaldoMOO().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate, Routes, Sellers, ObjectName, Customers, ReportFilter, ReportType);
                        break;
                    case 72:
                        response = new Pedidos().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate, FinalDate, Routes, Sellers, ObjectName, Customers, ReportFilter, ReportType);
                        break;
                    case 71:
                        //TotalCont = "10";
                        response = new R071Liquidacion().GetReport(ReportName, CompanyName, CompanyLogo, Routes, InitialDate);
                        break;
                    case 76:
                        response = new R076Liquidacion().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, ObjectName, Sellers, InitialDate, FinalDate);
                        break;
                    case 77:
                        response = new R077DevolucionesComision().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, Sellers);
                        break;
                    case 80:
                        response = new R080Liquidacion().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, ObjectName, Sellers, InitialDate);
                        break;
                    case 83:
                        if (Clientes == "")
                            pvCondicion = where + report.strWhereCedis(Cedis, "Almacen.AlmacenID");
                        else
                            pvCondicion = where + report.strWhereCedis(Cedis, "Almacen.AlmacenID") + report.strWhereClientes(Clientes, "Cliente.Clave");

                        response = new PuntosPorCliente().GetReport(nombreReport, CompanyName, pvCondicion, nombreCedis, ClientesSplit);
                        break;
                    case 87:
                        R087VentaPorClienteALT rptVentaClienteALT = new R087VentaPorClienteALT();
                        if (!rptVentaClienteALT.GetReport(ReportName, CompanyName, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers, CustomerSchemes, Customers))
                            response = null;
                        break;
                    case 88:
                        R088FacturacionElectronica r088 = new R088FacturacionElectronica();
                        if (!r088.GetReport(ReportName, CompanyName, NameCEDIS, CEDIS, ObjectName, Sellers, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 89:
                        R089ResumenDeVentasPorRutaYVendedor r089 = new R089ResumenDeVentasPorRutaYVendedor();
                        if (!r089.GetReport(ReportName, CompanyName, NameCEDIS, CEDIS, InitialDate, FinalDate, ReportType))
                            response = null;
                        break;
                    case 92:
                        response = new R092VentasPorMarca().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers);
                        break;
                    case 96:
                        response = new R096AnalisisSaldoSIE().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, Routes, Sellers, CustomerSchemes, Customers, ReportType);
                        break;
                    case 97:
                        R097ResumenDeVentasPorRutaYVendedor r097 = new R097ResumenDeVentasPorRutaYVendedor();
                        if (!r097.GetReport(ReportName, CompanyName, NameCEDIS, CEDIS, InitialDate, FinalDate, ProductSchemes))
                            response = null;
                        break;
                    case 103:
                        response = new R103VentaDiario().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, Sellers, InitialDate, Budget);
                        break;
                    case 108:
                        response = new R108TotalVentasELE().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers);
                        break;
                    case 112:

                        if (Rutas == "")
                        {
                            pvCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID") + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereClientes(Clientes, "CLI.ClienteClave");
                        }
                        else
                        {
                            pvCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID") + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.strWhereClientes(Clientes, "CLI.ClienteClave");
                        }

                        response = new DocumentosConSaldo().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, VendedorSplit, ClientesSplit, Cedis, nombreCedis);
                        break;
                    case 113:
                        pvCondicion = report.strWhereVendedores(Vendedor, "V.VendedorID");
                        response = new LiquidacionLaFlorida().GetReport(nombreReport, CompanyName, VAVClave, pvCondicion, VendedorSplit, FechaInicial, Cedis, nombreCedis);
                        break;
                    case 116:
                        if (Rutas == "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereCedis(Cedis, "a.AlmacenId") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        }
                        else
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "v.RutClave") + report.strWhereCedis(Cedis, "a.AlmacenId") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        }
                        response = new PuntosGPS().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, VendedorSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 118:
                        response = new MClientesSinVentas().GetReport(nombreReport, CompanyName, ReportName, Routes, InitialDate, FinalDate, StatusDate);
                        break;
                    case 124:
                        if (dateStatus == "Igual") FechaFinal = null;
                        string sCondicion = report.strWhereFechaSinHoras(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura") + report.strWhereRutas(Rutas, "VIS.RutClave");
                        string sCondicion2 = report.strWhereFechaSinHoras(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura") + report.strWhereRutas(Rutas, "(Select top 1 RUTClave from AgendaVendedor AGV where AGV.VendedorId = VEN.VendedorID and AGV.DiaClave = Dia.DiaClave )");
                        archivo = new DescargaEnvaseALT().GetReport(nombreReport, CompanyName, FechaInicial, FechaFinal, sCondicion, sCondicion2, RutasSplit);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 130:
                        response = new R130PedidosPreventaDetallado().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate, ObjectName, Sellers);
                        break;
                    case 131:
                        response = new LiquidacionDEL().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, "", "", "", Sellers, InitialDate);
                        break;
                    case 133:
                        R133ArrastreInventarioALT rptArrastreInv = new R133ArrastreInventarioALT();
                        if (!rptArrastreInv.GetReport(ReportName, CompanyName, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, ReportType))
                            response = null;
                        break;
                    case 135:
                        response = new R135Sincronizacion().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate);
                        break;
                    case 136:
                        if (Rutas != "")
                        {
                            pvCondicion = report.strWhereRutas(Rutas, "VIS.RUTClave");
                        }
                        else if (Vendedor != "")
                        {
                            pvCondicion = " and VEN.VendedorId = '" + Vendedor + "'";
                        }
                        pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        response = new ImproductividadXCliente().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, nombreCedis, nombreProductos, Cedis);
                        break;
                    case 137:
                        response = new ProximidadRIP().ProximidadRIPGet(
                                report.AllFilter(nombreCedis, null),
                                report.AllFilter(dateStatus, null),
                                report.AllFilter(Cedis, null),
                                report.AllFilter(ProductosSplit, null),
                                report.AllFilter(nombreProductosSplit, null),
                                report.AllFilter(FechaInicial, null));
                        break;
                    case 138:
                        ScoreCard rptScoreCard = new ScoreCard();
                        if (!rptScoreCard.GetReport(nombreReport, CompanyName, FechaInicial, Cedis, nombreProductos, nombreCedis, nombreProductosSplit))
                            response = null;
                        break;
                    case 139:
                        if (dateStatus == "Igual") FechaFinal = null;
                        sCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura");
                        String sCondicionDia1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia1.FechaCaptura");
                        response = new EfectividadVisitaRIP().GetReport(nombreReport, CompanyName, sCondicion, sCondicionDia1, FechaInicial, FechaFinal, Cedis, nombreCedis);
                        break;
                    case 140:
                        bool conversionKg = bool.Parse(Connection.Query<string>("select top 1 ConversionKg from ConHist order by MFechaHora desc", null, null, true, 9000).FirstOrDefault());
                        response = new R140VentaMensual().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, Cedis, dateStatus, InitialDate, FinalDate, Routes, Sellers, conversionKg);
                        break;
                    case 142:
                        response = new CargaSugeridaRIP(
                                report.AllFilter(nombreCedis, null),
                                report.AllFilter(dateStatus, null),
                                report.AllFilter(Cedis, null),
                                report.AllFilter(RutasSplit, null),
                                report.AllFilter(FechaInicial, null),
                                report.AllFilter(FechaFinal, null));
                        break;
                    case 143:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "TRP.FechaEntrega") + report.strWhereCedis(Cedis, "ALM.Clave") + report.strWhereRutas(Rutas, "RUT.RUTClave");
                        response = new ListaDeSurtimientoCOS(pvCondicion, RutasSplit, FechaInicial, nombreCedis);
                        break;
                    case 144:
                        pvCondicion = where + report.strWhereRutas(Rutas, "s.RUTClave");
                        pvCondicion1 = report.strWhereSupervisor(Presupuesto, "SR.USUIdSupervisor");
                        response = new MPlandeTrebajoSemanal().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, Presupuesto, promocion);
                        break;
                    case 145:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura") + report.strWhereCedis(Cedis, "ALN.Clave") + report.strWhereRutas(Rutas, "RUT.RUTClave");
                        pvCondicion1 = report.strWhereSupervisor(Presupuesto, "SR.USUIdSupervisor");
                        response = new ActividadesAcumuladoCOS(pvCondicion, pvCondicion1, RutasSplit, Presupuesto, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 146:
                        pvCondicion = where + report.strWhereCedis(Cedis, "a.Clave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereRutas(Rutas, "v.RUTClave");
                        pvCondicion1 = report.strWhereCedis(Cedis, "a.Clave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereRutas(Rutas, "v.RUTClave");
                        response = new ResumenTiempoMovimientos().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, FechaInicial, FechaFinal, nombreCedis, pvCondicion1);
                        break;
                    case 147:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereCedis(Cedis, "a.Clave");
                        response = new MInformeCuadreVentas().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 148:
                        pvCondicion = where + report.strWhereRutas(Rutas, "Clave");// + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Cargas.FechaCaptura");
                        response = new ClienteVisVsPlanTrabajo().GetReport(nombreReport, CompanyName, VAVClave, pvCondicion, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, unidadMedida);
                        break;
                    case 150:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        pvCondicion1 = report.strWhereSupervisor(Presupuesto, "SUR.USUIdSupervisor");
                        pvCondicion2 = report.strWhereRutas(Rutas, "AV.RUTClave");
                        pvCondicion3 = report.strWhereRutas(Rutas, "Vis.RUTClave");
                        pvCondicion4 = report.strWhereRutas(Rutas, "RUT.RUTClave");
                        pvCondicion5 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        response = new InformecCienteSINVisitaVenta().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, pvCondicion2, pvCondicion3, pvCondicion5, pvCondicion4, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, Presupuesto, promocion);
                        break;
                    case 153:
                        response = new R153LibroDeRuta().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate, Routes);
                        break;
                    case 156:
                        response = new R156KardexInventarioProducto().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, Routes);
                        break;
                    case 157:
                        if (Rutas != "")
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "RUT.RUTClave");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VIS.FechaHoraInicial");
                        }
                        else if (Vendedor != "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VIS.FechaHoraInicial");
                        }
                        response = new DiarioActividadesVit().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 160:
                        pvCondicion = where + report.strWhereCedis(Cedis, "a.AlmacenID");
                        response = new ClientesEsquemasVIT().GetReport(nombreReport, CompanyName, pvCondicion, ProductosSplit, Cedis, nombreProductos);
                        break;
                    case 161:
                        if (Rutas != "" || Clientes != "")
                        {
                            pvCondicion = report.strWhereRutas(Rutas, "v.RUTClave");
                            pvCondicion1 = report.strWhereClientes(Clientes, "c.ClienteClave");
                            pvCondicion2 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        }
                        response = new PedidoPromedioCliente().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, pvCondicion2, RutasSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, promocion);
                        break;
                    case 162:
                        pvCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID");
                        archivo = new CierreDeDiaGrupoMOR().GetReport(nombreReport, CompanyName, VAVClave, nombreCedis, pvCondicion, FechaInicial, FechaFinal, Cedis, unidadMedida);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 163:
                        pvCondicion = where + (Cedis == "null" ? "" : report.strWhereCedis(Cedis, "ALM.AlmacenID")) + report.strWhereRutas(Rutas, "SEC.RutClave");
                        pvCondicionProd = where + (Cedis == "null" ? "" : report.strWhereCedis(Cedis, "ALM.AlmacenID")) + report.strWhereRutas(Rutas, "VIS.RutClave");
                        sFecha1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura").Remove(0, 4);
                        sEsquemasProd = where + report.strWhereEsquema(pvProductos, "PE.EsquemaId");//usamos esta ya que strWhereEsquema y strWhereProductos serian funciones exactamente iguales solo cambia el nombre de los parametros
                        nombreCedis = nombreCedis == "null" ? "Todos" : nombreCedis;
                        archivo = new VentasPorClienteMOR().GetReport(nombreReport, CompanyName, nombreCedis, FechaInicial, FechaFinal, Cedis, sFecha1, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos, sEsquemasProd, pvCondicion, pvCondicionProd, RutasSplit);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 164:
                        pvCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID");
                        sFechaAnioActual = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura").Remove(0, 4);
                        sFechaAnioAnterior = report.strWhereFechaAnioAnterior(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura").Remove(0, 4);
                        archivo = new ComparativoVentaMensualMOO().GetReport(nombreReport, CompanyName, VAVClave, nombreCedis, pvCondicion, FechaInicial, FechaFinal, Cedis, unidadMedida, sFechaAnioActual, sFechaAnioAnterior);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 165:
                        pvCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID");
                        archivo = new ClientesInformacionBase().GetReport(nombreReport, CompanyName, nombreCedis, FechaInicial, FechaFinal, Cedis);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 166:
                        whereAlmacen = report.strWhereCedis(Cedis, "A.AlmacenID");
                        whereFechaDia = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "D.FechaCaptura");
                        whereEsquema = report.strWhereEsquema(pvProductos, "PE.EsquemaID");
                        archivo = new CoberturaPorProductoMOR().GetReport(nombreReport, CompanyName, nombreCedis, FechaInicial, FechaFinal, Cedis, whereAlmacen, whereFechaDia, whereEsquema, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 167:
                        pvCondicion = where + (Cedis == "null" ? "" : report.strWhereCedis(Cedis, "a.AlmacenID")) + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "d.FechaCaptura") + report.strWhereRutas(Rutas, "v.RutClave");
                        archivo = new VentasPorDiaMOR().GetReport(nombreReport, CompanyName, nombreCedis, FechaInicial, FechaFinal, Cedis, VAVClave, dateStatus, unidadMedida, pvCondicion, RutasSplit);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 168:
                        pvCondicion = where + (Cedis == "null" ? "" : report.strWhereCedis(Cedis, "ALM.AlmacenID")) + report.strWhereRutas(Rutas, "VIS.RutClave");
                        sEsquemasProd = report.strWhereEsquema(pvProductos, "PE.EsquemaId");
                        nombreCedis = nombreCedis == "null" ? "Todos" : nombreCedis;
                        sFechaAnioActual = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura").Remove(0, 4);
                        sFechaAnioAnterior = report.strWhereFechaAnioAnterior(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura").Remove(0, 4);
                        archivo = new GAPMOR().GetReport(nombreReport, CompanyName, nombreCedis, FechaInicial, FechaFinal, VAVClave, pvProductos, sEsquemasProd, pvCondicion, RutasSplit, sFechaAnioActual, sFechaAnioAnterior);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 169:
                        whereAlmacen = (Cedis == "null" ? "" : report.strWhereCedis(Cedis, "A.AlmacenID"));
                        whereFechaDia = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "D.FechaCaptura");
                        whereEsquema = report.strWhereEsquema(pvProductos, "PE.EsquemaID");
                        archivo = new VentasPorProductoMOR().GetReport(nombreReport, CompanyName, nombreCedis, FechaInicial, FechaFinal, Cedis, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos, pvCondicionProd, whereAlmacen, whereFechaDia, whereEsquema);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 171:
                        pvCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID");
                        string sFecha = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura").Remove(0, 4);
                        archivo = new PromocionesMOR().GetReport(nombreReport, CompanyName, nombreCedis, FechaInicial, FechaFinal, Cedis, pvCondicion, sFecha, VAVClave);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 173:
                        string sVendedorID = report.strWhereVendedores(Vendedor, "VEN.VendedorID");
                        string sVendedorSplit = "('" + VendedorSplit + "', ',')";
                        response = new LiquidacionMOR().GetReport(nombreReport, CompanyName, sVendedorID, sVendedorSplit, FechaInicial, Cedis);
                        break;
                    case 183:
                        if (Rutas == "")
                        {
                            pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura") + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereClientes(Clientes, "CLI.ClienteClave");
                        }
                        else
                        {
                            pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura") + report.strWhereRutas(Rutas, "VIS.RUTClave") + report.strWhereClientes(Clientes, "CLI.ClienteClave");
                        }
                        response = new VentaDetalladaMOR().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis);
                        break;
                    case 187:
                        response = new R187Liquidacion().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, ObjectName, Sellers, InitialDate);
                        break;
                    case 189:
                        string ftPromo = report.strWherePromociones(promocion, "PM.TipoEstado");
                        string ftAlmacen = report.strWhereCedis(Cedis, "A.AlmacenID");
                        string ftRuta = report.strWhereRutas(Rutas, "V.RUTClave");
                        string ftFecha = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "D.FechaCaptura");
                        string ftFechaCentro = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "VDH.VCHFechaInicial");
                        response = new PromocionClientesMOR().GetReport(nombreReport, CompanyName, ftPromo, ftAlmacen, ftRuta, ftFecha, ftFechaCentro, promocion, nombreCedis, RutasSplit, FechaInicial, FechaFinal);
                        break;
                    case 190:
                        R190KardexDeExistencia r1907 = new R190KardexDeExistencia();
                        if (!r1907.GetReport(ReportName, CompanyName, NameCEDIS, CEDIS))
                            response = null;
                        break;
                    case 194:
                        response = new R194VentasPorProducto().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, CEDIS, Sellers, Products, Customers, InitialDate, FinalDate);
                        break;
                    case 195:
                        pvCondicion = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        response = new MReporteVentaClienteOportuno().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, Presupuesto, promocion);
                        break;
                    case 196:
                        response = new R196ResumenTiemposMovimientosCOS().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, InitialDate);
                        break;
                    case 198:
                        pvCondicion = where + report.strWhereCedis(Cedis, "a.AlmacenID") + report.strWhereVendedores(Vendedor, "v.VendedorID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        response = new EstatusPedidosSAPChocolatera().GetReport(nombreReport, CompanyName, pvCondicion, FechaInicial, FechaFinal, nombreCedis, Vendedor);
                        break;
                    case 199:
                        response = new R199LiquidacionBRA().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, Sellers);
                        break;
                    case 200:
                        InventarioVentasRIK rpt = new InventarioVentasRIK();
                        if (!rpt.GetReport(nombreReport, CompanyName, FechaInicial, Rutas, Clientes))
                            response = null;
                        break;
                    case 201:
                        LiquidacionRIK rptLiq = new LiquidacionRIK();
                        if (!rptLiq.GetReport(nombreReport, CompanyName, FechaInicial, Vendedor, reportType))
                            response = null;
                        break;
                    case 202:
                    case 203:
                    case 204:
                        CumplimientoVisitaGHR rptCump = new CumplimientoVisitaGHR();
                        if (!rptCump.GetReport(nombreReport, CompanyName, VAVClave, FechaInicial, FechaFinal, Rutas, nombreCedis))
                            response = null;
                        break;
                    case 207:
                        R207ExistenciasDeProducto rptExistencia = new R207ExistenciasDeProducto();
                        if (!rptExistencia.GetReport(ReportName, CompanyName, NameCEDIS, CEDIS, InitialDate))
                            response = null;
                        break;
                    case 209:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereRutas(Rutas, "vi.RUTClave");
                        pvCondicion1 = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereRutas(Rutas, "tr.Rutareparto");

                        response = new NecesidadesDeCargaUNI().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, RutasSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis);
                        break;
                    case 210:
                        pvCondicion = where + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion1 = where + report.strWhereRutas(Rutas, "VIS.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion2 = where + report.strWhereRutas(Rutas, "VER.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion3 = where + report.strWhereRutas(Rutas, "AGV.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion4 = where + report.strWhereRutas(Rutas, "RutaReparto");
                        pvCondicion5 = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "TRP.FechaCancelacion");
                        pvCondicion6 = where + report.strWhereRutas(Rutas, "Clave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "CLI.FechaRegistroSistema");

                        response = new LiquidacionUNI().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, pvCondicion2, pvCondicion3, pvCondicion4, pvCondicion5, pvCondicion6, RutasSplit, FechaInicial, FechaFinal, nombreCedis, Presupuesto);
                        break;
                    case 211:
                        R211InventarioGeneralNUT rptInvGral = new R211InventarioGeneralNUT();
                        if (!rptInvGral.GetReport(ReportName, CompanyName, CEDIS, NameCEDIS, StatusDate, InitialDate))
                            response = null;
                        break;
                    case 212:
                        pvCondicion = where + report.strWhereRutas(Rutas, "vi.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        response = new VentaDetalladoCompleto().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, ClientesSplit, FechaInicial, nombreCedis, reportType, nPresupuesto);
                        break;
                    case 213:
                        pvCondicion = where + report.strWhereRutas(Rutas, "Clave");// + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Cargas.FechaCaptura");
                        response = new CargasRealesporPedido().GetReport(nombreReport, CompanyName, VAVClave, pvCondicion, RutasSplit, FechaInicial, Cedis, nombreCedis, unidadMedida);
                        break;
                    case 214:
                        pvCondicion = where + report.strWhereRutas(Rutas, "Clave");
                        sEsquemasProd = where + report.strWhereEsquema(pvProductos, "EsquemaID");
                        response = new VentasporCodigoDetalladoUNI().GetReport(nombreReport, CompanyName, VAVClave, reportType, pvCondicion, sEsquemasProd, nombreProductos, RutasSplit, extra1, FechaInicial, Cedis, nombreCedis, unidadMedida);
                        break;
                    case 217:
                        whereAlmacen = (Cedis == "null" ? "" : report.strWhereCedis(Cedis, "A.AlmacenID"));
                        pvCondicion = where + report.strWhereRutas(Rutas, "R.Rutclave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "D.FechaCaptura");
                        pvCondicion1 = where + report.strWhereRutas(Rutas, "R.Rutclave");
                        pvCondicion3 = report.strWhereRutas(Rutas, "VR.RUTClave");
                        pvCondicion2 = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "D.FechaCaptura");
                        archivo = new CargasInicialesPorRuta().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, pvCondicion2, pvCondicion3, RutasSplit, nombreCedis, FechaInicial, FechaFinal, Cedis, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos, pvCondicionProd, whereAlmacen, whereFechaDia, whereEsquema);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 218:
                        whereAlmacen = (Cedis == "null" ? "" : report.strWhereCedis(Cedis, "A.AlmacenID"));
                        pvCondicion = where + report.strWhereRutas(Rutas, "R.Rutclave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "D.FechaCaptura");
                        pvCondicion1 = where + report.strWhereRutas(Rutas, "R.Rutclave");
                        pvCondicion3 = report.strWhereRutas(Rutas, "VR.RUTClave");
                        pvCondicion2 = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "D.FechaCaptura");
                        archivo = new CargasFinalesPorRuta().GetReport(nombreReport, CompanyName, pvCondicion, pvCondicion1, pvCondicion2, pvCondicion3, RutasSplit, nombreCedis, FechaInicial, FechaFinal, Cedis, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos, pvCondicionProd, whereAlmacen, whereFechaDia, whereEsquema);
                        if (archivo == null)
                        {
                            return View("Empty");
                        }
                        else
                        {
                            Response.Clear();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", archivo.nombre));
                            Response.BinaryWrite(archivo.archivo);
                            Response.End();
                            return View("Xls");
                        }
                        break;
                    case 220:
                        pvCondicion = where + report.strWhereRutas(Vendedor, "TempA.VendedorID");
                        pvCondicion1 = report.strWhereRutas(Vendedor, "V.VendedorID");
                        response = new VentasvsAnioAnterior().GetReport(nombreReport, CompanyName, VAVClave, pvCondicion, pvCondicion1, VendedorSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, unidadMedida);
                        break;
                    case 221:
                        ConcentradoMovAlmacenALT rptAlt = new ConcentradoMovAlmacenALT();
                        if (!rptAlt.GetReport(nombreReport, CompanyName, VAVClave, FechaInicial))
                            response = null;
                        break;
                    case 224:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        response = new InventarioAlmacenALT().GetReport(nombreReport, CompanyName, FechaInicial, pvCondicion, Cedis);
                        break;
                    case 226:
                        CargaPorDiaBYD rptCargaByd = new CargaPorDiaBYD();
                        if (!rptCargaByd.GetReport(nombreReport, CompanyName, VAVClave, Cedis, nombreCedis, FechaInicial, FechaFinal, RutasSplit, Vendedor, reportType))
                            response = null;
                        break;
                    case 227:
                        response = new VentasBYD().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, InitialDate, FinalDate, (ReportFilter ? Sellers : Routes), ObjectName, Customers, ReportFilter);
                        break;
                    case 228:
                        pvCondicion = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        response = new MReporteCFDI().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, FechaInicial, FechaFinal, nombreCedis, Presupuesto, promocion);
                        break;
                    case 234:
                        R234ResumenDevolucionClienteLEO rptDevolucionCliente = new R234ResumenDevolucionClienteLEO();
                        if (!rptDevolucionCliente.GetReport(CompanyLogo, CompanyName, ReportName, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers, CustomerSchemes))
                            response = null;
                        break;
                    case 235:
                        if (Rutas == "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereCedis(Cedis, "ALN.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        }
                        else
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.strWhereCedis(Cedis, "ALN.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                            pvCondicionKm = where + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.strWhereCedis(Cedis, "ALN.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "CAV.FechaHoraInicial");
                        }
                        response = new MTiemposEnRutaIN().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, FechaInicial, FechaFinal, pvCondicionKm);
                        break;
                    case 236:
                        response = new MReporteLiquidacionLPB().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Sellers, InitialDate);
                        break;
                    case 238:
                        if (ReportType)
                        {
                            response = new VentasDetallado().GetReport(ReportName + " Detallado", CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Routes, Sellers, Customers, InitialDate, FinalDate, ReportFilter);
                        }
                        else
                        {
                            response = new VentasGeneral().GetReport(ReportName + " General", CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Routes, Sellers, Customers, InitialDate, FinalDate, ReportFilter);
                        }
                        break;
                    case 240:
                        pvCondicion = report.strWhereVendedores(Vendedor, "V.VendedorID");
                        response = new LiquidacionAfrima().GetReport(nombreReport, CompanyName, VAVClave, pvCondicion, VendedorSplit, FechaInicial, Cedis, nombreCedis);
                        break;
                    case 241:
                        GlobalPorRutaAFR rptGlb = new GlobalPorRutaAFR();
                        if (!rptGlb.GetReport(nombreReport, CompanyName, FechaInicial, FechaFinal, Rutas))
                            response = null;
                        break;
                    case 242:
                        response = new R242Liquidacion().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, InitialDate, Sellers);
                        break;
                    case 243:
                        if (Rutas == "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereClientes(Clientes, "CLI.ClienteClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        }
                        else
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "VIS.RUTClave") + report.strWhereClientes(Clientes, "CLI.ClienteClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        }

                        response = new PedidosPreventaAlt().GetReport(nombreReport, CompanyName, pvCondicion, RutasSplit, VendedorSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, reportType);
                        break;
                    case 244:
                        IndicadoresOJAI rptIndOJAI = new IndicadoresOJAI();
                        if (!rptIndOJAI.GetReport(nombreReport, CompanyName, nombreCedis, FechaInicial, Rutas, reportType, int.Parse(extra1), int.Parse(extra2)))
                            response = null;
                        break;
                    case 245:
                        PromocionesNvoMOR rptPromMOR = new PromocionesNvoMOR();
                        if (!rptPromMOR.GetReport(nombreReport, CompanyName, Cedis, nombreCedis, FechaInicial, FechaFinal, Vendedor))
                            response = null;
                        break;
                    case 246:
                        CarteraMensualXRutaPDR rptCarMen = new CarteraMensualXRutaPDR();
                        if (!rptCarMen.GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Routes, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 247:
                        response = new MDiarioDeActividadesTiemposPDR().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Routes, Sellers, InitialDate, FinalDate, ReportFilter);
                        break;
                    case 248:
                        VentasParaInterfazHOR rptVenIntH = new VentasParaInterfazHOR();
                        if (!rptVenIntH.GetReport(nombreReport, CompanyName, FechaInicial, FechaFinal, Vendedor))
                            response = null;
                        break;
                    case 249:
                        //pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "convert(datetime,TRP.DiaClave, 103)");
                        pvCondicionCEDI = report.strWhereCedis(Cedis, "ALN.AlmacenID");
                        response = new CargasDEL().GetReport(nombreReport, CompanyName, pvCondicion, FechaInicial, FechaFinal, nombreCedis, pvCondicionCEDI, Session["Lote"].ToString());
                        break;
                    case 250:
                        CifrasControlBYD rptCifConBYD = new CifrasControlBYD();
                        if (!rptCifConBYD.GetReport(ReportName, CompanyName, NameCEDIS, StatusDate, CEDIS, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 251:
                        pvCondicion = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VCH.VCHFechaInicial");

                        VendedorCliModelListPreBYD rptVCMLPBYD = new VendedorCliModelListPreBYD();
                        if (!rptVCMLPBYD.GetReport(nombreReport, CompanyName, Cedis, nombreCedis, pvCondicion, FechaInicial, FechaFinal))
                            response = null;
                        break;
                    case 252:
                        response = new LiquidacionDEL().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, StatusDate, CEDIS, Sellers, InitialDate);
                        break;
                    case 253:
                        response = new LiquidacionTUC().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, ReportType, Sellers);
                        break;
                    case 254:
                        response = new ComisionesTUC().GetReport(nombreReport, CompanyName, Cedis, nombreCedis, FechaInicial, FechaFinal, Vendedor, VendedorSplit);
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            XlsxExportOptions opts = new XlsxExportOptions();
                            response.ExportToXlsx(ms, opts);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);

                            byte[] breport = ms.ToArray();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", response.Name));
                            Response.Clear();
                            Response.OutputStream.Write(breport, 0, breport.Length);
                            Response.End();
                        }
                        return View("Xls");
                    //break;
                    case 255:
                        MovimientosPorLoteDEL rptMovLotDEL = new MovimientosPorLoteDEL();
                        if (!rptMovLotDEL.GetReport(ReportName, CompanyName, StatusDate, Lots, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 256:
                        InformeVentasXadisROV rptventasXadis = new InformeVentasXadisROV();
                        if (!rptventasXadis.GetReport(CEDIS, NameCEDIS, InitialDate, Routes, Sellers, CustomerSchemes, Customers, ProductSchemes))
                            response = null;
                        break;
                    case 257:
                        response = new MFacturaGlobalPDR().GetReport(nombreReport, CompanyName, FechaInicial, FechaFinal, Vendedor);
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            XlsxExportOptions opts = new XlsxExportOptions();
                            response.ExportToXlsx(ms, opts);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);

                            byte[] breport = ms.ToArray();
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", response.Name));
                            Response.Clear();
                            Response.OutputStream.Write(breport, 0, breport.Length);
                            Response.End();
                        }
                        return View("Xls");
                        break;
                    case 258:
                        response = new MIndicadoresDeVentaPDR().GetReport(nombreReport, CompanyName, Cedis, FechaInicial, FechaFinal, Vendedor, Rutas, nombreCedis, VendedorSplit, RutasSplit);
                        break;
                    case 259:
                        response = new R259DocumentosConSaldo().GetReport(ReportName, CompanyName, CompanyLogo, ObjectName, NameCEDIS, CEDIS, Routes, Sellers, Customers, ReportFilter);
                        break;
                    case 260:
                        VentasXadisSIE rptventasXadisSIE = new VentasXadisSIE();
                        if (!rptventasXadisSIE.GetReport(CompanyName, ReportName, StatusDate, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 261:
                        PedidosConfirmadosPRS rptPedidosConfirmados = new PedidosConfirmadosPRS();
                        if (!rptPedidosConfirmados.GetReport(CEDIS, NameCEDIS, StatusDate, InitialDate, FinalDate, Sellers))
                            response = null;
                        break;
                    case 262:
                        try
                        {
                            response = new R262Ventas().GetReport(CEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers);
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                            {
                                XlsxExportOptions opts = new XlsxExportOptions();
                                response.ExportToXlsx(ms, opts);
                                ms.Seek(0, System.IO.SeekOrigin.Begin);

                                byte[] breport = ms.ToArray();
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", response.Name));
                                Response.Clear();
                                Response.OutputStream.Write(breport, 0, breport.Length);
                                Response.End();
                            }
                            return View("Xls");
                        }
                        catch (Exception e)
                        {
                            response = null;
                        }
                        break;
                    case 263:
                        R263ImproductividadImagenes rptImproductividad = new R263ImproductividadImagenes();
                        if (!rptImproductividad.GetReport(CompanyName, ReportName, CEDIS, NameCEDIS, Routes, StatusDate, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 264:
                        R264ClientesProspectos rptClientesProspecto = new R264ClientesProspectos();
                        if (!rptClientesProspecto.GetReport(CompanyName, ReportName, CEDIS, NameCEDIS, Routes, StatusDate, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 265:
                        parameters = "filterCEDIS,filterRutas,filterClientes";
                        query = @"EXEC [dbo].[stpr_RW265ListadoDeClientesGenerico]
                                @filtroCEDIS = @filterCEDIS, @filtroRutas = @filterRutas, @filtroClientes = @filterClientes";
                        if (!excel.GetReport(ReportName, listObject, query, parameters))
                            response = null;
                        break;
                    case 266:
                        parameters = "filterListaPrecios,filterFechaInicio";
                        query = @"EXEC [dbo].[stpr_RW266ListaDePreciosGenerico]
                                @filtroListaPrecios = @filterListaPrecios, @filtroFechaInicio = @filterFechaInicio";
                        if (!excel.GetReport(ReportName, listObject, query, parameters))
                            response = null;
                        break;
                    case 267:
                        pvCondicion = report.strWhereVendedores(Vendedor, "V.VendedorID");
                        response = new LiquidacionMelbrin().GetReport(VAVClave, nombreReport, pvCondicion, VendedorSplit, FechaInicial, Cedis, nombreCedis);
                        break;
                    case 268:
                        try
                        {
                            response = new ReporteLiquidacionEfectivoDIV().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, StatusDate, InitialDate, FinalDate, Routes);

                        }
                        catch (Exception e)
                        {
                            response = null;
                        }
                        break;
                    case 269:
                        response = new R269Devoluciones().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, Routes, InitialDate, FinalDate);
                        break;
                    case 270:
                        R270DescargasDIV rptdscgas = new R270DescargasDIV();
                        if (!rptdscgas.GetReport(CompanyLogo, CompanyName, ReportName, CEDIS, NameCEDIS, Routes, StatusDate, InitialDate, FinalDate))
                            response = null;
                        break;
                    case 271:
                        response = new R271DocumentoConSaldoDIV().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, Routes, Sellers, CustomerSchemes, Customers);
                        break;
                    case 273:
                        R273InventarioXadis rptInvXadis = new R273InventarioXadis();
                        if (!rptInvXadis.GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, InitialDate))
                            response = null;
                        break;
                    case 274:
                        response = new R274LiquidacionROV().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, Sellers);
                        break;
                    case 275:
                        R275CumplimientoVisRutGHR cumpVisRut = new R275CumplimientoVisRutGHR();
                        if (!cumpVisRut.GetReport(VAVClave, FechaInicial, FechaFinal, Rutas, nombreCedis))
                            response = null;
                        break;
                    case 276:
                        response = new TiemposEnRutaMED().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, StatusDate, InitialDate, FinalDate, Routes, Sellers, ReportFilter);
                        break;
                    case 277:
                        response = new R277LiquidacionNOR().GetReport(ReportName, CompanyName, CompanyLogo, CEDIS, NameCEDIS, StatusDate, InitialDate, Routes);
                        break;
                    default:
                        return View("ReporteNoExiste");
                }

                if (response == null)
                {
                    return View("Empty");
                }
                else if (exportToExcel)
                {
                    report.GetExportToExcel(response, ReportName);
                    return View("ExcelGenerado");
                }
                else
                {
                    return View(response);
                }
            }
            catch (Exception ex)
            {
                LogController log = new LogController();
                log.Log(ex, "ExceptionsReports");
                ViewData["exception"] = "Exception: " + ex.Message;
                return View("ExceptionsReports");
            }
        }
    }
}