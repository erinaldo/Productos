using DevExpress.XtraReports.UI;
using eRoute.Controllers.API;
using eRoute.Controllers.API.Reports;
using eRoute.Models;
using eRoute.Models.ReportesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.IO;

namespace eRoute.Controllers
{
    public class ReportsController : Controller
    {

        //[Authorize]
        public ActionResult Index(string VAVClave)
        {
            if (Session["URL"] != null)
            {
                int Clave = Convert.ToInt32(VAVClave);
                ViewBag.VAVClave = Clave;

                switch (Clave)
                {
                    case 3:
                        return View("EfectividadPorRuta");
                    case 9:
                        return View("TiemposEnRuta");
                    case 10:
                        return View("DevolucionesCambiosporCliente");
                    case 18:
                        return View("Cargas");
                    case 27:
                        return View("DevolucionesCambiosporVendedor");
                    case 32:
                        return View("VentaDiarioCOS");
                    case 33:
                        return View("DiarioDeActividades");
                    case 34:
                        return View("IndicadoresDeVenta");
                    case 37:
                        return View("VentasGAT");
                    case 46:
                        return View("ClientesPorRuta");                    
                    case 52:
                        return View("ReporteClientesNoVisitados");
                    case 53:
                        return View("PuntosDeRecorrido");
                    case 69:
                        return View("AnalisisDeSaldosMOO");
                    case 72:
                        return View("Pedidos");
                    case 51://Encuestas 
                    case 79://Encuestas Disposur
                        return View("ExportarEncuestas");
                    case 83:
                        return View("PuntosPorCliente");
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
                        return View("PedidosPreventaDetallado");
                    case 135:
                        return View("ReportedeSincronizacion");
                    case 136:
                        return View("ImproductividadXCliente");
                    case 137:
                        return View("ProximidadRIP");
                    case 138:
                        return View("ScoreCard");
                    case 139:
                        return View("EfectividadVisitaRIP");
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
                        return View("LibrodeRutasVitere");
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
                    case 189:
                        return View("PromocionClienteMOR");
                    case 195:
                        return View("VentaClienteOportuno");
                    case 198:
                        return View("EstatusPedidosSAPChocolatera");
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
                    case 209://Por Cliente
                        return View("NecesidadesDeCargaUNI");
                    case 210://Por Cliente
                        return View("HojaDeLiquidacionUNI");
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
                        return View("LiquidacionPDR");
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
                    case 275://Por Ruta
                        return View("R275CumplimientoVisitaRutaGHR2");
                    default:
                        return View("ReporteNoExiste");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult GetCondition(List<GetModel> Lotes, List<GetRoutesModel> Routes, List<Clients> Clientes, List<GetSellerModel> Seller, List<GetProductsModel> Products, List<GetProductsSchemeModel> ProductsSchema, string nombreReport = "", string init = "", string end = "", string unidadMedida = "", string CENClave = "", string promocion = "", string Presupuesto = "", bool reportType = false, int vavclave = 1, string lote = "", string NombreProductos = "", string Cedis = "", string nombreCedis = "", string dateStatus = "", string extra1 = "", string extra2 = "")
        {
            try
            {
                Session["Routes"] = "";
                Session["Sellers"] = "";
                Session["Clients"] = "";
                Session["Customers"] = "";
                Session["ProductSchemes"] = "";
                Session["CustomerSchemes"] = "";
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

        //public ActionResult GetCondition(string nombreReport, string Cedis, string nombreCedis, string dateStatus, List<GetRoutesModel> Routes, List<Clients> Clientes, List<GetSellerModel> Seller, List<GetProductsModel> Products, string init, string end, int vavclave, bool reportType, string unidadMedida, string CENClave)
        //{
        //    try
        //    {
        //        ReportGetCondition condition = new ReportGetCondition();
        //        ConditionModel cm = new ConditionModel();
        //        cm = condition.Get(nombreReport, Cedis, nombreCedis, dateStatus, Routes, Clientes, Seller, Products, init, end, vavclave, reportType, unidadMedida, CENClave, "", 0);
        //        return Json(cm);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex.Message);
        //    }

        //}

        public ActionResult GetObjectString(List<GetModel> Object)
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

        //window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Rutas=" + data.Rutas + "&Clientes=" + data.Clientes + 
        //                                                                                                                                                                                      "&Vendedor=" + data.Vendedor + "&nombreProductos=" + data.ProductsScheme + "&detallado=" + data.reportType + "&unidadMedida=" + data.unidadMedida + "&CENClave=" + data.CENClave + "&promocion=" + data.promocion + "&Presupuesto=" + data.Presupuesto, "_blank")
        public ActionResult Ver(string nombreReport = "", string Cedis = "", string nombreCedis = "", string FechaInicial = "", string FechaFinal = "", string dateStatus = "", string Rutas = "", string Lotes = "", string Clientes = "", string Vendedor = "", string Productos = "", string nombreProductos = "", string unidadMedida = "", string CENClave = "", string promocion = "", string Presupuesto = "", bool detallado = false, string extra1 = "", string extra2 = "", int VAVClave = 0, bool reportType = false)
        {
            try
            {
                ReportGetCondition report = new ReportGetCondition();
                string Routes = Session["Routes"].ToString();
                string Customers = Session["Customers"].ToString();
                string Sellers = Session["Sellers"].ToString();
                string Lots = Session["Lots"].ToString();
                string Products = Session["Products"].ToString();
                string Supervisors = Session["Supervisors"].ToString();
                string ProductSchemes = Session["ProductSchemes"].ToString();
                string CustomerSchemes = Session["CustomerSchemes"].ToString();
                string Polls = Session["Polls"].ToString();
                string ObjectName = Session["ObjectName"].ToString();
                VAVClave = int.Parse(Session["VAVClave"].ToString());
                bool ReportType = bool.Parse(Session["ReportType"].ToString());
                bool ReportFilter = bool.Parse(Session["ReportFilter"].ToString());
                string InitialDate = Session["InitialDate"].ToString();
                string FinalDate = Session["FinalDate"].ToString();
                string CEDIS = Session["CEDIS"].ToString();
                string NameCEDIS = Session["NameCEDIS"].ToString();
                int Budget = int.Parse(Session["Budget"].ToString());
                string ReportName = Session["ReportName"].ToString();
                string Promotion = Session["Promotion"].ToString();
                string UnitMeasure = Session["UnitMeasure"].ToString();
                string StatusDate = Session["StatusDate"].ToString();
                IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
                string CompanyName = "SELECT NombreEmpresa FROM Configuracion (NOLOCK)";
                CompanyName = Connection.Query<string>(CompanyName, null, null, true, 9000).FirstOrDefault();
                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK)";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream CompanyLogo = new MemoryStream(byteArrayIn);

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
                    catch (Exception)
                    {
                    }
                }

                XtraReport response = new XtraReport();
                ArchivoXlsModel archivo = new ArchivoXlsModel();
                switch (VAVClave)
                {
                    case 2:

                        break;
                    case 3:
                        pvCondicion = where + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.strWhereCedis(Cedis, "ALN.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "DIA.FechaCaptura");
                        response = new MEfectividadPorRuta().GetReport(pvCondicion, RutasSplit, VendedorSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, detallado);
                        break;
                    case 9:
                        if (Rutas == "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereCedis(Cedis, "ALN.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        }
                        else
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.strWhereCedis(Cedis, "ALN.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                            pvCondicionKm = where + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.strWhereCedis(Cedis, "ALN.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "CAV.FechaHoraInicial");
                        }
                        response = new TiemposEnRuta().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal, pvCondicionKm, report.strWhereVendedores(Vendedor, "VEN.VendedorID"), report.strWhereRutas(Rutas, "RUT.RUTClave"), report.strWhereCedis(Cedis, "ALN.AlmacenID"), report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura"), report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "CAV.FechaHoraInicial"));
                        break;
                    case 10:
                        response = new DevolucionesCambiosXCiente().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, StatusDate, InitialDate, FinalDate, Routes, Customers, Products, ProductSchemes);
                        break;
                    case 18:
                        pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        pvCondicionCEDI = report.strWhereCedis(Cedis, "ALN.AlmacenID");
                        response = new Cargas().GetReport(pvCondicion, FechaInicial, FechaFinal, nombreCedis, pvCondicionCEDI);
                        break;
                    case 27:
                        response = new DevolucionesCambiosXVendedor().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, CEDIS, StatusDate, InitialDate, FinalDate, Sellers, ObjectName, Customers);
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
                        response = new VentaDiarioCOS(pvCondicion, RutasSplit, VendedorSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 33:
                        if (Rutas != "")
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "VEN.VendedorID");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VIS.FechaHoraInicial");
                        }
                        else if (Vendedor != "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VIS.FechaHoraInicial");
                        }
                        response = new MDiarioDeActividades().GetReport(pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 34:
                        response = new MIndicadoresDeVenta().GetReport(Cedis, FechaInicial, FechaFinal, Vendedor, Rutas, nombreCedis, VendedorSplit, RutasSplit);
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
                        response = new ClientesPorRuta().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, StatusDate, CEDIS, Routes, Sellers, InitialDate, FinalDate, ReportFilter);
                        break;
                    case 52:
                        pvCondicion = report.strWhereRutas(Rutas, "RUT.RUTClave")/* + report.strWhereCedis(Cedis, "ALM.AlmacenID")*/ + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "DIA.FechaCaptura");
                        response = new MReporteClientesNoVisitados().getReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal);
                        break;
                    case 51: //Encuestas
                    case 79: //Encuestas Disposur
                        EncuestasAplicadas rptEnc = new EncuestasAplicadas();
                        if (!rptEnc.GetReport(VAVClave, CENClave, FechaInicial, FechaFinal, Rutas))
                            response = null;
                        break;
                    case 53:
                        pvCondicion = report.strWhereRutas(Rutas, "GPS.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "DIA.FechaCaptura");
                        response = new PuntosRecorrido().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal);
                        break;
                    case 69:
                        if (Rutas == "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereClientes(Clientes, "SEC.ClienteClave") + report.strWhereCedis(Cedis, "ALM.AlmacenID");
                        }
                        else
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "SEC.RUTClave") + report.strWhereClientes(Clientes, "SEC.ClienteClave") + report.strWhereCedis(Cedis, "ALM.AlmacenID");
                        }

                        response = new AnalisisDeSaldoMOO().GetReport(pvCondicion, RutasSplit, ClientesSplit, FechaInicial, nombreCedis, detallado);
                        break;
                    case 72:
                        if (Rutas == "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereClientes(Clientes, "CLI.ClienteClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        }
                        else
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "VIS.RUTClave") + report.strWhereClientes(Clientes, "CLI.ClienteClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        }

                        response = new Pedidos().GetReport(pvCondicion, RutasSplit, VendedorSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, detallado);
                        break;
                    case 83:
                        if (Clientes == "")
                            pvCondicion = where + report.strWhereCedis(Cedis, "Almacen.AlmacenID");
                        else
                            pvCondicion = where + report.strWhereCedis(Cedis, "Almacen.AlmacenID") + report.strWhereClientes(Clientes, "Cliente.Clave");

                        response = new PuntosPorCliente().GetReport(pvCondicion, nombreCedis, ClientesSplit);
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

                        response = new DocumentosConSaldo().GetReport(pvCondicion, RutasSplit, VendedorSplit, ClientesSplit, Cedis, nombreCedis);
                        break;
                    case 113:
                        pvCondicion = report.strWhereVendedores(Vendedor, "V.VendedorID");
                        response = new LiquidacionLaFlorida().GetReport(VAVClave, nombreReport, pvCondicion, VendedorSplit, FechaInicial, Cedis, nombreCedis);
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
                        response = new PuntosGPS().GetReport(pvCondicion, RutasSplit, VendedorSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 118:
                        pvCondicion = report.strWhereRutas(Rutas, "rut.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "dia.FechaCaptura");

                        response = new MClientesSinVentas().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal);
                        break;
                    case 124:
                        if (dateStatus == "Igual") FechaFinal = null;
                        string sCondicion = report.strWhereFechaSinHoras(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura") + report.strWhereRutas(Rutas, "VIS.RutClave");
                        string sCondicion2 = report.strWhereFechaSinHoras(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura") + report.strWhereRutas(Rutas, "(Select top 1 RUTClave from AgendaVendedor AGV where AGV.VendedorId = VEN.VendedorID and AGV.DiaClave = Dia.DiaClave )");
                        archivo = new DescargaEnvaseALT().GetReport(nombreReport, FechaInicial, FechaFinal, sCondicion, sCondicion2, RutasSplit);
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
                        pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID") + report.strWhereRutas(Vendedor, "RUT.RutClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion1 = where + report.strWhereVendedores(Vendedor, "AGV.VendedorID") + report.strWhereRutas(Vendedor, "AGV.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion2 = where + report.strWhereVendedores(Vendedor, "VIS.VendedorID") + report.strWhereRutas(Vendedor, "VIS.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");

                        response = new MPedidosPreventaDetallado().GetReport(pvCondicion, pvCondicion1, pvCondicion2, Vendedor, FechaInicial, FechaFinal, nombreCedis, Cedis, Presupuesto);
                        break;
                    case 135:
                        response = new MReportedeSincronizacion().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, Presupuesto, promocion);
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
                        response = new ImproductividadXCliente().GetReport(pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, nombreCedis, nombreReport, Cedis);
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
                        if (!rptScoreCard.GetReport(FechaInicial, Cedis, nombreProductos, nombreCedis, nombreProductosSplit))
                            response = null;
                        break;
                    case 139:
                        if (dateStatus == "Igual") FechaFinal = null;
                        sCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura");
                        String sCondicionDia1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia1.FechaCaptura");
                        response = new EfectividadVisitaRIP().GetReport(sCondicion, sCondicionDia1, FechaInicial, FechaFinal, Cedis, nombreCedis, nombreReport);
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
                        response = new MPlandeTrebajoSemanal().GetReport(pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, Presupuesto, promocion);
                        break;
                    case 145:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "Dia.FechaCaptura") + report.strWhereCedis(Cedis, "ALN.Clave") + report.strWhereRutas(Rutas, "RUT.RUTClave");
                        pvCondicion1 = report.strWhereSupervisor(Presupuesto, "SR.USUIdSupervisor");
                        response = new ActividadesAcumuladoCOS(pvCondicion, pvCondicion1, RutasSplit, Presupuesto, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 146:
                        pvCondicion = where + report.strWhereCedis(Cedis, "a.Clave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereRutas(Rutas, "v.RUTClave");
                        pvCondicion1 = report.strWhereCedis(Cedis, "a.Clave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereRutas(Rutas, "v.RUTClave");
                        response = new ResumenTiempoMovimientos().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal, nombreCedis, pvCondicion1);
                        break;
                    case 147:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereCedis(Cedis, "a.Clave");
                        response = new MInformeCuadreVentas().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 148:
                        pvCondicion = where + report.strWhereRutas(Rutas, "Clave");// + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Cargas.FechaCaptura");
                        response = new ClienteVisVsPlanTrabajo().GetReport(VAVClave, nombreReport, pvCondicion, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, unidadMedida);
                        break;
                    case 150:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        pvCondicion1 = report.strWhereSupervisor(Presupuesto, "SUR.USUIdSupervisor");
                        pvCondicion2 = report.strWhereRutas(Rutas, "AV.RUTClave");
                        pvCondicion3 = report.strWhereRutas(Rutas, "Vis.RUTClave");
                        pvCondicion4 = report.strWhereRutas(Rutas, "RUT.RUTClave");
                        pvCondicion5 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        response = new InformecCienteSINVisitaVenta().GetReport(pvCondicion, pvCondicion1, pvCondicion2, pvCondicion3, pvCondicion5, pvCondicion4, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, Presupuesto, promocion);
                        break;
                    case 153:
                        if (Rutas != "")
                        {
                            pvCondicion = report.strWhereRutas(Rutas, "RUTP.RUTClave");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        }
                        response = new LibroRutaVitere().GetReport(pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, nombreCedis, nombreReport);
                        break;
                    case 157:
                        if (Rutas != "")
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "VEN.VendedorID");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VIS.FechaHoraInicial");
                        }
                        else if (Vendedor != "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VIS.FechaHoraInicial");
                        }
                        response = new DiarioActividadesVit().GetReport(pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 160:
                        pvCondicion = where + report.strWhereCedis(Cedis, "a.AlmacenID");
                        response = new ClientesEsquemasVIT().GetReport(pvCondicion, ProductosSplit, Cedis, nombreProductos);
                        break;
                    case 161:
                        if (Rutas != "" || Clientes != "")
                        {
                            pvCondicion = report.strWhereRutas(Rutas, "v.RUTClave");
                            pvCondicion1 = report.strWhereClientes(Clientes, "c.ClienteClave");
                            pvCondicion2 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        }
                        response = new PedidoPromedioCliente().GetReport(pvCondicion, pvCondicion1, pvCondicion2, RutasSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, nombreReport);
                        break;
                    case 162:
                        pvCondicion = where + report.strWhereCedis(Cedis, "ALM.AlmacenID");
                        archivo = new CierreDeDiaGrupoMOR().GetReport(VAVClave, nombreReport, nombreCedis, pvCondicion, FechaInicial, FechaFinal, Cedis, unidadMedida);
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
                        archivo = new VentasPorClienteMOR().GetReport(nombreReport, nombreCedis, FechaInicial, FechaFinal, Cedis, sFecha1, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos, sEsquemasProd, pvCondicion, pvCondicionProd, RutasSplit);
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
                        archivo = new ComparativoVentaMensualMOO().GetReport(VAVClave, nombreReport, nombreCedis, pvCondicion, FechaInicial, FechaFinal, Cedis, unidadMedida, sFechaAnioActual, sFechaAnioAnterior);
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
                        archivo = new ClientesInformacionBase().GetReport(nombreReport, nombreCedis, FechaInicial, FechaFinal, Cedis);
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
                        archivo = new CoberturaPorProductoMOR().GetReport(nombreReport, nombreCedis, FechaInicial, FechaFinal, Cedis, whereAlmacen, whereFechaDia, whereEsquema, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos);
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
                        archivo = new VentasPorDiaMOR().GetReport(nombreReport, nombreCedis, FechaInicial, FechaFinal, Cedis, VAVClave, dateStatus, unidadMedida, pvCondicion, RutasSplit);
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
                        archivo = new GAPMOR().GetReport(nombreReport, nombreCedis, FechaInicial, FechaFinal, VAVClave, pvProductos, sEsquemasProd, pvCondicion, RutasSplit, sFechaAnioActual, sFechaAnioAnterior);
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
                        archivo = new VentasPorProductoMOR().GetReport(nombreReport, nombreCedis, FechaInicial, FechaFinal, Cedis, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos, pvCondicionProd, whereAlmacen, whereFechaDia, whereEsquema);
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
                        archivo = new PromocionesMOR().GetReport(nombreReport, nombreCedis, FechaInicial, FechaFinal, Cedis, pvCondicion, sFecha, VAVClave);
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
                        response = new LiquidacionMOR().GetReport(sVendedorID, sVendedorSplit, FechaInicial, Cedis);
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
                        response = new VentaDetalladaMOR().GetReport(pvCondicion, RutasSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis);
                        break;
                    case 189:
                        string ftPromo = report.strWherePromociones(promocion, "PM.TipoEstado");
                        string ftAlmacen = report.strWhereCedis(Cedis, "A.AlmacenID");
                        string ftRuta = report.strWhereRutas(Rutas, "V.RUTClave");
                        string ftFecha = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "D.FechaCaptura");
                        string ftFechaCentro = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "VDH.VCHFechaInicial");
                        response = new PromocionClientesMOR().GetReport(ftPromo, ftAlmacen, ftRuta, ftFecha, ftFechaCentro, promocion, nombreReport, nombreCedis, RutasSplit, FechaInicial, FechaFinal);
                        break;
                    case 195:
                        pvCondicion = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        response = new MReporteVentaClienteOportuno().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, Presupuesto, promocion);
                        break;
                    case 198:
                        pvCondicion = where + report.strWhereCedis(Cedis, "a.AlmacenID") + report.strWhereVendedores(Vendedor, "v.VendedorID") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        response = new EstatusPedidosSAPChocolatera().GetReport(pvCondicion, FechaInicial, FechaFinal, nombreCedis, Vendedor);
                        break;
                    case 200:
                        InventarioVentasRIK rpt = new InventarioVentasRIK();
                        if (!rpt.GetReport(FechaInicial, Rutas, Clientes))
                            response = null;
                        break;
                    case 201:
                        LiquidacionRIK rptLiq = new LiquidacionRIK();
                        if (!rptLiq.GetReport(FechaInicial, Vendedor, detallado))
                            response = null;
                        break;
                    case 202:
                    case 203:
                    case 204:
                        CumplimientoVisitaGHR rptCump = new CumplimientoVisitaGHR();
                        if (!rptCump.GetReport(VAVClave, FechaInicial, FechaFinal, Rutas, nombreCedis))
                            response = null;
                        break;
                    case 209:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereRutas(Rutas, "vi.RUTClave");
                        pvCondicion1 = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura") + report.strWhereRutas(Rutas, "tr.Rutareparto");

                        response = new NecesidadesDeCargaUNI().GetReport(pvCondicion, pvCondicion1, RutasSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis);
                        break;
                    case 210:
                        pvCondicion = where + report.strWhereRutas(Rutas, "RUT.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion1 = where + report.strWhereRutas(Rutas, "VIS.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion2 = where + report.strWhereRutas(Rutas, "VER.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion3 = where + report.strWhereRutas(Rutas, "AGV.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        pvCondicion4 = where + report.strWhereRutas(Rutas, "RutaReparto");
                        pvCondicion5 = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "TRP.FechaCancelacion");
                        pvCondicion6 = where + report.strWhereRutas(Rutas, "Clave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "CLI.FechaRegistroSistema");

                        response = new LiquidacionUNI().GetReport(pvCondicion, pvCondicion1, pvCondicion2, pvCondicion3, pvCondicion4, pvCondicion5, pvCondicion6, RutasSplit, FechaInicial, FechaFinal, nombreCedis, Presupuesto);
                        break;
                    case 212:
                        pvCondicion = where + report.strWhereRutas(Rutas, "vi.RUTClave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "d.FechaCaptura");
                        response = new VentaDetalladoCompleto().GetReport(pvCondicion, RutasSplit, ClientesSplit, FechaInicial, nombreCedis, detallado, nPresupuesto);
                        break;
                    case 213:
                        pvCondicion = where + report.strWhereRutas(Rutas, "Clave");// + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Cargas.FechaCaptura");
                        response = new CargasRealesporPedido().GetReport(VAVClave, nombreReport, pvCondicion, RutasSplit, FechaInicial, Cedis, nombreCedis, unidadMedida);
                        break;
                    case 214:
                        pvCondicion = where + report.strWhereRutas(Rutas, "Clave");
                        sEsquemasProd = where + report.strWhereEsquema(pvProductos, "EsquemaID");
                        response = new VentasporCodigoDetalladoUNI().GetReport(VAVClave, nombreReport, detallado, pvCondicion, sEsquemasProd, nombreProductos, RutasSplit, Productos, FechaInicial, Cedis, nombreCedis, unidadMedida);
                        break;
                    case 217:
                        whereAlmacen = (Cedis == "null" ? "" : report.strWhereCedis(Cedis, "A.AlmacenID"));
                        pvCondicion = where + report.strWhereRutas(Rutas, "R.Rutclave") + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, true, "D.FechaCaptura");
                        pvCondicion1 = where + report.strWhereRutas(Rutas, "R.Rutclave");
                        pvCondicion3 = report.strWhereRutas(Rutas, "VR.RUTClave");
                        pvCondicion2 = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "D.FechaCaptura");
                        archivo = new CargasInicialesPorRuta().GetReport(pvCondicion, pvCondicion1, pvCondicion2, pvCondicion3, nombreReport, RutasSplit, nombreCedis, FechaInicial, FechaFinal, Cedis, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos, pvCondicionProd, whereAlmacen, whereFechaDia, whereEsquema);
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
                        archivo = new CargasFinalesPorRuta().GetReport(pvCondicion, pvCondicion1, pvCondicion2, pvCondicion3, nombreReport, RutasSplit, nombreCedis, FechaInicial, FechaFinal, Cedis, VAVClave, dateStatus, unidadMedida, pvProductos, nombreProductos, pvCondicionProd, whereAlmacen, whereFechaDia, whereEsquema);
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
                        response = new VentasvsAnioAnterior().GetReport(VAVClave, nombreReport, pvCondicion, pvCondicion1, VendedorSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, unidadMedida);
                        break;
                    case 221:
                        ConcentradoMovAlmacenALT rptAlt = new ConcentradoMovAlmacenALT();
                        if (!rptAlt.GetReport(VAVClave, FechaInicial))
                            response = null;
                        break;
                    case 224:
                        pvCondicion = where + report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "Dia.FechaCaptura");
                        response = new InventarioAlmacenALT().GetReport(FechaInicial, nombreReport, pvCondicion, Cedis);
                        break;
                    case 226:
                        CargaPorDiaBYD rptCargaByd = new CargaPorDiaBYD();
                        if (!rptCargaByd.GetReport(nombreReport, CompanyName, VAVClave, Cedis, nombreCedis, FechaInicial, FechaFinal, RutasSplit, Vendedor, reportType))
                            response = null;
                        break;
                    case 227:
                        pvCondicion = report.strWhereClientes(Clientes, "CLI.ClienteClave");
                        response = new VentasBYD().GetReport(VAVClave, nombreReport, pvCondicion, RutasSplit, VendedorSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis);
                        break;
                    case 228:
                        pvCondicion = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "di.FechaCaptura");
                        response = new MReporteCFDI().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal, nombreCedis, Presupuesto, promocion);
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
                        response = new MTiemposEnRutaIN().GetReport(pvCondicion, RutasSplit, FechaInicial, FechaFinal, pvCondicionKm);
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
                        response = new LiquidacionAfrima().GetReport(VAVClave, nombreReport, pvCondicion, VendedorSplit, FechaInicial, Cedis, nombreCedis);
                        break;
                    case 241:
                        GlobalPorRutaAFR rptGlb = new GlobalPorRutaAFR();
                        if (!rptGlb.GetReport(FechaInicial, FechaFinal, Rutas))
                            response = null;
                        break;
                    case 242:
                        response = new MLiquidacionPDR().GetReport(ReportName, CompanyName, CompanyLogo, NameCEDIS, StatusDate, CEDIS, Sellers, InitialDate);
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

                        response = new PedidosPreventaAlt().GetReport(pvCondicion, RutasSplit, VendedorSplit, ClientesSplit, FechaInicial, FechaFinal, Cedis, nombreCedis, detallado);
                        break;
                    case 244:
                        IndicadoresOJAI rptIndOJAI = new IndicadoresOJAI();
                        if (!rptIndOJAI.GetReport(nombreCedis, FechaInicial, Rutas, detallado, int.Parse(extra1), int.Parse(extra2)))
                            response = null;
                        break;
                    case 245:
                        PromocionesNvoMOR rptPromMOR = new PromocionesNvoMOR();
                        if (!rptPromMOR.GetReport(Cedis, nombreCedis, FechaInicial, FechaFinal, Vendedor))
                            response = null;
                        break;
                    case 246:
                        CarteraMensualXRutaPDR rptCarMen = new CarteraMensualXRutaPDR();
                        if (!rptCarMen.GetReport(VAVClave, nombreReport, pvCondicion, RutasSplit, FechaInicial, FechaFinal, Cedis, nombreCedis))
                            response = null;
                        break;
                    case 247:
                        if (Rutas != "")
                        {
                            pvCondicion = where + report.strWhereRutas(Rutas, "VEN.VendedorID");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VIS.FechaHoraInicial");
                        }
                        else if (Vendedor != "")
                        {
                            pvCondicion = where + report.strWhereVendedores(Vendedor, "VEN.VendedorID");
                            pvCondicion1 = report.GetDateQuery(dateStatus, FechaInicial, FechaFinal, false, "VIS.FechaHoraInicial");
                        }
                        response = new MDiarioDeActividadesPDR().GetReport(pvCondicion, pvCondicion1, RutasSplit, FechaInicial, FechaFinal, nombreCedis);
                        break;
                    case 248:
                        VentasParaInterfazHOR rptVenIntH = new VentasParaInterfazHOR();
                        if (!rptVenIntH.GetReport(FechaInicial, FechaFinal, Vendedor))
                            response = null;
                        break;
                    case 275:
                        R275CumplimientoVisRutGHR cumpVisRut = new R275CumplimientoVisRutGHR();
                        if (!cumpVisRut.GetReport(VAVClave, FechaInicial, FechaFinal, Rutas, nombreCedis))
                            response = null;
                        break;
                    default:
                        return View("ReporteNoExiste");
                }

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
    }

    public class HolaMundo
    {

        public int VAVClave { get; set; }
        public string Cedis { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public string dateStatus { get; set; }
        public string Rutas { get; set; }
        public string Clientes { get; set; }
        public string Vendedor { get; set; }
    }
}