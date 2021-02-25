using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using eRoute.Controllers.API;
using eRoute.Models;
using System.Text;

namespace eRoute.Controllers
{
    public class MapsController : Controller
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        public ActionResult Index(string vavclave)
        {
            if (Session["URL"] != null)
            {
                switch (vavclave)
                {
                    case "1":
                        return View();
                    case "2":
                        return View("CoberturaMapFilter");
                    case "3":
                        return View("ClientesSinVentaMapFilter");
                    case "4":
                        return View("ClientesNoVisitadosMapFilter");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult getMapData(string Cedis, string dateStatus, List<GetRoutesModel> Routes, string init, string end, int vavclave, int tipo, string esquemaId, string productoClave)
        {
            StringBuilder sConsulta;
            string str2;
            List<RutasConsultaModel> list;
            MapaModel model;
            List<RutasModel> list2;
            long num;
            ReportGetCondition condition = new ReportGetCondition();
            string str = "where 1=1";
            string rutas = "";
            if (Routes != null)
            {
                List<GetRoutesModel> source = (from d2 in Routes
                                               where d2.Checked
                                               select d2).ToList<GetRoutesModel>();
                StringBuilder builder2 = new StringBuilder();
                foreach (GetRoutesModel model2 in source)
                {
                    if (model2.Equals(source.Last<GetRoutesModel>()))
                    {
                        builder2.Append("'" + model2.RUTClave + "'");
                    }
                    else
                    {
                        builder2.Append("'" + model2.RUTClave + "',");
                    }
                }
                string str5 = builder2.ToString();
                string[] strArray = null;
                if (source.Count<GetRoutesModel>() == 1)
                {
                    char[] separator = new char[] { ',' };
                    strArray = str5.Split(separator);
                }
                else
                {
                    char[] chArray2 = new char[] { ' ' };
                    strArray = str5.Split(chArray2);
                }
                rutas = strArray.ElementAt<string>(0);
            }
            switch (vavclave)
            {
                case 2://cobertura
                    {
                        str2 = condition.GetDateQuery(dateStatus, init, end, false, "d.FechaCaptura");
                        string str3 = (productoClave != "") ? condition.strWhereRutas(rutas, "r.RUTClave") : condition.strWhereRutas(rutas, "v.RUTClave");
                        str = str + condition.strWhereCedis(Cedis, "ALN.AlmacenID") + " and cd.CoordenadaX is not null";

                        //consulta para obtener todos los clientes que deben ser visitados en el rango de fechas
                        sConsulta = new StringBuilder();
                        sConsulta.AppendLine("declare @EsquemaId as varchar(25)");
                        sConsulta.AppendLine("declare @ProductoClave as varchar(25)");
                        sConsulta.AppendLine("declare @TipoFase as int ");
                        sConsulta.AppendLine("");
                        sConsulta.AppendLine("set @EsquemaId ='" + esquemaId + "'");
                        sConsulta.AppendLine(("set @TipoFase =" + tipo) ?? "");
                        sConsulta.AppendLine("set @ProductoClave ='" + productoClave + "'");
                        sConsulta.AppendLine("");
                        sConsulta.AppendLine("if @ProductoClave <>''");
                        sConsulta.AppendLine("");
                        sConsulta.AppendLine("Select distinct ");
                        sConsulta.AppendLine("c.Clave,c.RazonSocial,");
                        sConsulta.AppendLine("cd.NombreTienda,cd.Calle,cd.Numero,cd.NumInt,cd.Colonia,cd.CodigoPostal,cd.Poblacion,cd.Entidad,cd.CoordenadaX,cd.CoordenadaY, ");
                        sConsulta.AppendLine("r.RUTClave, r.Descripcion ");
                        sConsulta.AppendLine("from ");
                        sConsulta.AppendLine("TransProd t ");
                        sConsulta.AppendLine("inner join Visita v on t.VisitaClave=v.VisitaClave ");
                        sConsulta.AppendLine("inner join Dia d on d.DiaClave=v.DiaClave " + str2 + " ");
                        sConsulta.AppendLine("inner join Cliente c on t.Tipo=1 and  t.ClienteClave=c.ClienteClave ");
                        sConsulta.AppendLine("inner join ClienteDomicilio cd on c.ClienteClave=cd.ClienteClave and cd.Tipo =2");
                        sConsulta.AppendLine("inner join TransProdDetalle td on td.TransProdID=t.TransProdID and td.ProductoClave=@ProductoClave ");
                        sConsulta.AppendLine("inner join Ruta r on r.RUTClave = v.RUTClave " + str3);
                        sConsulta.AppendLine("inner join Almacen ALN on r.AlmacenID = ALN.AlmacenID ");
                        sConsulta.AppendLine(str);
                        sConsulta.AppendLine("else");
                        sConsulta.AppendLine("begin");
                        sConsulta.AppendLine("WITH ESQ_Productos (EsquemaId,EsquemaIdPadre)");
                        sConsulta.AppendLine("AS");
                        sConsulta.AppendLine("(");
                        sConsulta.AppendLine("Select EsquemaId,EsquemaIdPadre from Esquema where EsquemaIDPadre  =@EsquemaId ");
                        sConsulta.AppendLine("UNION ALL");
                        sConsulta.AppendLine("Select e.EsquemaId,e.EsquemaIdPadre from Esquema e ");
                        sConsulta.AppendLine("INNER JOIN ESQ_Productos  p on e.EsquemaIDPadre  =p.EsquemaId");
                        sConsulta.AppendLine(")");
                        sConsulta.AppendLine("Select distinct ");
                        sConsulta.AppendLine("c.Clave,c.RazonSocial,");
                        sConsulta.AppendLine("cd.NombreTienda,cd.Calle,cd.Numero,cd.NumInt,cd.Colonia,cd.CodigoPostal,cd.Poblacion,cd.Entidad,cd.CoordenadaX,cd.CoordenadaY,  ");
                        sConsulta.AppendLine("r.RUTClave,\tr.Descripcion  ");
                        sConsulta.AppendLine("from ");
                        sConsulta.AppendLine("TransProd t ");
                        sConsulta.AppendLine("inner join Visita v on t.VisitaClave=v.VisitaClave ");
                        sConsulta.AppendLine("inner join Dia d on d.DiaClave=v.DiaClave  " + str2 + " ");
                        sConsulta.AppendLine("inner join Cliente c on t.Tipo=1 and  t.ClienteClave=c.ClienteClave ");
                        sConsulta.AppendLine("inner join ClienteDomicilio cd on c.ClienteClave=cd.ClienteClave and cd.Tipo =2");
                        sConsulta.AppendLine("inner join TransProdDetalle td on td.TransProdID=t.TransProdID  ");
                        sConsulta.AppendLine("inner join Ruta r on r.RUTClave = v.RUTClave " + str3);
                        sConsulta.AppendLine("inner join ProductoEsquema pe on td.ProductoClave = pe.ProductoClave and pe.EsquemaID in (select Esquemaid from  ESQ_Productos )");
                        sConsulta.AppendLine("inner join Almacen ALN on r.AlmacenID = ALN.AlmacenID ");
                        sConsulta.AppendLine(str);
                        sConsulta.AppendLine("end");
                        this.QueryString = sConsulta.ToString();
                        list = this.Connection.Query<RutasConsultaModel>(this.QueryString, null, null, true, null, null).ToList<RutasConsultaModel>();
                        foreach (RutasConsultaModel ruta in list)
                        {
                            ruta.Rutas = ruta.RUTClave;
                            foreach (RutasConsultaModel model4 in list)
                            {
                                if ((ruta.Clave == model4.Clave) && (ruta.RUTClave != model4.RUTClave))
                                {
                                    ruta.Rutas = ruta.Rutas + ", " + model4.RUTClave;
                                }
                            }
                        }
                        model = new MapaModel();
                        list2 = new List<RutasModel>();
                        num = 0L;
                        foreach (var grouping in from ruta in list
                                                 group ruta by new { RUTClave = ruta.RUTClave } into grupo
                                                 select grupo)
                        {
                            RutasModel item = new RutasModel
                            {
                                RUTClave = grouping.First<RutasConsultaModel>().RUTClave,
                                Color = "#" + num.ToString("X6"),
                                Checked = true,
                                Clientes = new List<ClientePorRutaModel>()
                            };
                            list2.Add(item);
                            foreach (RutasConsultaModel model5 in grouping)
                            {
                                if (model5 != null)
                                {
                                    ClientePorRutaModel model12 = new ClientePorRutaModel
                                    {
                                        Clave = model5.Clave,
                                        RazonSocial = model5.RazonSocial,
                                        Calle = model5.Calle,
                                        Numero = model5.Numero,
                                        CodigoPostal = model5.CodigoPostal,
                                        Colonia = model5.Colonia,
                                        Poblacion = model5.Poblacion,
                                        Entidad = model5.Entidad,
                                        CoordenadaX = model5.CoordenadaX,
                                        CoordenadaY = model5.CoordenadaY,
                                        Rutas = model5.Rutas
                                    };
                                    list2.Last<RutasModel>().Clientes.Add(model12);
                                }
                            }
                        }


                        num += 0x7530L;

                        model.RutasTotales = list2;

                        sConsulta = new StringBuilder();
                        sConsulta.AppendLine("declare @EsquemaId as varchar(25)");
                        sConsulta.AppendLine("declare @ProductoClave as varchar(25)");
                        sConsulta.AppendLine("declare @TipoFase as int ");
                        sConsulta.AppendLine("");
                        sConsulta.AppendLine("set @EsquemaId ='" + esquemaId + "'");
                        sConsulta.AppendLine(("set @TipoFase =" + tipo) ?? "");
                        sConsulta.AppendLine("set @ProductoClave ='" + productoClave + "'");
                        sConsulta.AppendLine("");
                        sConsulta.AppendLine("if @ProductoClave <>''");
                        sConsulta.AppendLine("");
                        sConsulta.AppendLine("Select distinct ");
                        sConsulta.AppendLine("c.Clave,c.RazonSocial,");
                        sConsulta.AppendLine("cd.NombreTienda,cd.Calle,cd.Numero,cd.NumInt,cd.Colonia,cd.CodigoPostal,cd.Poblacion,cd.Entidad,cd.CoordenadaX,cd.CoordenadaY, ");
                        sConsulta.AppendLine("r.RUTClave, r.Descripcion ");
                        sConsulta.AppendLine("from ");
                        sConsulta.AppendLine("TransProd t ");
                        sConsulta.AppendLine("inner join Visita v on t.VisitaClave=v.VisitaClave ");
                        sConsulta.AppendLine("inner join Dia d on d.DiaClave=v.DiaClave " + str2 + " ");
                        sConsulta.AppendLine("inner join Cliente c on t.Tipo=1 and t.TipoFase=@TipoFase and  t.ClienteClave=c.ClienteClave ");
                        sConsulta.AppendLine("inner join ClienteDomicilio cd on c.ClienteClave=cd.ClienteClave and cd.Tipo =2");
                        sConsulta.AppendLine("inner join TransProdDetalle td on td.TransProdID=t.TransProdID and td.ProductoClave=@ProductoClave ");
                        sConsulta.AppendLine("inner join Ruta r on r.RUTClave = v.RUTClave " + str3);
                        sConsulta.AppendLine("inner join Almacen ALN on r.AlmacenID = ALN.AlmacenID ");
                        sConsulta.AppendLine(str);
                        sConsulta.AppendLine("else");
                        sConsulta.AppendLine("begin");
                        sConsulta.AppendLine("WITH ESQ_Productos (EsquemaId,EsquemaIdPadre)");
                        sConsulta.AppendLine("AS");
                        sConsulta.AppendLine("(");
                        sConsulta.AppendLine("Select EsquemaId,EsquemaIdPadre from Esquema where EsquemaIDPadre  =@EsquemaId ");
                        sConsulta.AppendLine("UNION ALL");
                        sConsulta.AppendLine("Select e.EsquemaId,e.EsquemaIdPadre from Esquema e ");
                        sConsulta.AppendLine("INNER JOIN ESQ_Productos  p on e.EsquemaIDPadre  =p.EsquemaId");
                        sConsulta.AppendLine(")");
                        sConsulta.AppendLine("Select distinct ");
                        sConsulta.AppendLine("c.Clave,c.RazonSocial,");
                        sConsulta.AppendLine("cd.NombreTienda,cd.Calle,cd.Numero,cd.NumInt,cd.Colonia,cd.CodigoPostal,cd.Poblacion,cd.Entidad,cd.CoordenadaX,cd.CoordenadaY,  ");
                        sConsulta.AppendLine("r.RUTClave,\tr.Descripcion  ");
                        sConsulta.AppendLine("from ");
                        sConsulta.AppendLine("TransProd t ");
                        sConsulta.AppendLine("inner join Visita v on t.VisitaClave=v.VisitaClave ");
                        sConsulta.AppendLine("inner join Dia d on d.DiaClave=v.DiaClave  " + str2 + " ");
                        sConsulta.AppendLine("inner join Cliente c on t.Tipo=1 and t.TipoFase=@TipoFase and  t.ClienteClave=c.ClienteClave ");
                        sConsulta.AppendLine("inner join ClienteDomicilio cd on c.ClienteClave=cd.ClienteClave and cd.Tipo =2");
                        sConsulta.AppendLine("inner join TransProdDetalle td on td.TransProdID=t.TransProdID  ");
                        sConsulta.AppendLine("inner join Ruta r on r.RUTClave = v.RUTClave " + str3);
                        sConsulta.AppendLine("inner join ProductoEsquema pe on td.ProductoClave = pe.ProductoClave and pe.EsquemaID in (select Esquemaid from  ESQ_Productos )");
                        sConsulta.AppendLine("inner join Almacen ALN on r.AlmacenID = ALN.AlmacenID ");
                        sConsulta.AppendLine(str);
                        sConsulta.AppendLine("end");
                        this.QueryString = sConsulta.ToString();
                        list = this.Connection.Query<RutasConsultaModel>(this.QueryString, null, null, true, null, null).ToList<RutasConsultaModel>();
                        foreach (RutasConsultaModel model3 in list)
                        {
                            model3.Rutas = model3.RUTClave;
                            foreach (RutasConsultaModel model4 in list)
                            {
                                if ((model3.Clave == model4.Clave) && (model3.RUTClave != model4.RUTClave))
                                {
                                    model3.Rutas = model3.Rutas + ", " + model4.RUTClave;
                                }
                            }
                        }
                        list2 = new List<RutasModel>();
                        foreach (var grouping in from ruta in list
                                                 group ruta by new { RUTClave = ruta.RUTClave } into grupo
                                                 select grupo)
                        {
                            RutasModel item = new RutasModel
                            {
                                RUTClave = grouping.First<RutasConsultaModel>().RUTClave,
                                Color = "#" + num.ToString("X6"),
                                Checked = true,
                                Clientes = new List<ClientePorRutaModel>()
                            };
                            list2.Add(item);
                            num += 0x7530L;
                            foreach (RutasConsultaModel model5 in grouping)
                            {
                                if (model5 != null)
                                {
                                    ClientePorRutaModel model12 = new ClientePorRutaModel
                                    {
                                        Clave = model5.Clave,
                                        RazonSocial = model5.RazonSocial,
                                        Calle = model5.Calle,
                                        Numero = model5.Numero,
                                        CodigoPostal = model5.CodigoPostal,
                                        Colonia = model5.Colonia,
                                        Poblacion = model5.Poblacion,
                                        Entidad = model5.Entidad,
                                        CoordenadaX = model5.CoordenadaX,
                                        CoordenadaY = model5.CoordenadaY,
                                        Rutas = model5.Rutas
                                    };
                                    list2.Last<RutasModel>().Clientes.Add(model12);
                                }
                            }
                        }
                        try
                        {
                            model.CoordenadaX = (from cx in list
                                                 orderby cx.CoordenadaX
                                                 select cx).ToList<RutasConsultaModel>()[list.Count<RutasConsultaModel>() / 2].CoordenadaX;
                            model.CoordenadaY = (from cx in list
                                                 orderby cx.CoordenadaY
                                                 select cx).ToList<RutasConsultaModel>()[list.Count<RutasConsultaModel>() / 2].CoordenadaY;
                        }
                        catch (Exception)
                        {
                            model.CoordenadaX = Convert.ToDecimal((double)-104.5345101);
                            model.CoordenadaY = Convert.ToDecimal((double)23.5309891);
                        }
                        model.Rutas = list2;
                        return base.Json(model, JsonRequestBehavior.AllowGet);
                    }
                case 3://clientes sin venta
                    str2 = condition.GetDateQuery(dateStatus, init, end, false, "Dia.FechaCaptura");
                    str = (str + condition.strWhereRutas(rutas, "RUT.RUTClave") + condition.strWhereCedis(Cedis, "ALN.AlmacenID")) + str2 + " and cd.CoordenadaX is not null";
                    sConsulta = new StringBuilder();
                    sConsulta.AppendLine("select distinct ");
                    sConsulta.AppendLine("c.Clave,c.RazonSocial,");
                    sConsulta.AppendLine("cd.NombreTienda,cd.Calle,cd.Numero,cd.NumInt,cd.Colonia,cd.CodigoPostal,cd.Poblacion,cd.Entidad,cd.CoordenadaX,cd.CoordenadaY,  ");
                    sConsulta.AppendLine("rut.RUTClave, rut.Descripcion ");
                    sConsulta.AppendLine("from ");
                    sConsulta.AppendLine("AgendaVendedor AGV ");
                    sConsulta.AppendLine("inner join Dia on DIA.DiaClave=AGV.DiaClave  ");
                    sConsulta.AppendLine(string.Concat(new object[] { "inner join  Cliente c on AGV.ClienteClave= c.ClienteClave and C.ClienteClave not in (select VEN.ClienteClave from TransProd VEN inner join DIA on DIA.DiaClave= VEN.DiaClave AND VEN.Tipo = 1 AND TipoFase = ", tipo, " ", str2, "  )" }));
                    sConsulta.AppendLine("inner join ClienteDomicilio cd on c.ClienteClave = cd.ClienteClave and cd.Tipo=2 ");
                    sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId  ");
                    sConsulta.AppendLine("inner join Ruta RUT ON RUT.RUTClave = AGV.RUTClave  ");
                    sConsulta.AppendLine("inner join Almacen ALN ON ALN.Clave = AGV.ClaveCEDI  ");
                    sConsulta.AppendLine(str);
                    this.QueryString = sConsulta.ToString();
                    list = this.Connection.Query<RutasConsultaModel>(this.QueryString, null, null, true, null, null).ToList<RutasConsultaModel>();
                    foreach (RutasConsultaModel model6 in list)
                    {
                        model6.Rutas = model6.RUTClave;
                        foreach (RutasConsultaModel model7 in list)
                        {
                            if ((model6.Clave == model7.Clave) && (model6.RUTClave != model7.RUTClave))
                            {
                                model6.Rutas = model6.Rutas + ", " + model7.RUTClave;
                            }
                        }
                    }
                    model = new MapaModel();
                    list2 = new List<RutasModel>();
                    num = 0L;
                    foreach (var grouping2 in from ruta in list
                                              group ruta by new { RUTClave = ruta.RUTClave } into grupo
                                              select grupo)
                    {
                        RutasModel model13 = new RutasModel
                        {
                            RUTClave = grouping2.First<RutasConsultaModel>().RUTClave,
                            Color = "#" + num.ToString("X6"),
                            Checked = true,
                            Clientes = new List<ClientePorRutaModel>()
                        };
                        list2.Add(model13);
                        num += 0x7530L;
                        foreach (RutasConsultaModel model8 in grouping2)
                        {
                            if (model8 != null)
                            {
                                ClientePorRutaModel model14 = new ClientePorRutaModel
                                {
                                    Clave = model8.Clave,
                                    RazonSocial = model8.RazonSocial,
                                    Calle = model8.Calle,
                                    Numero = model8.Numero,
                                    CodigoPostal = model8.CodigoPostal,
                                    Colonia = model8.Colonia,
                                    Poblacion = model8.Poblacion,
                                    Entidad = model8.Entidad,
                                    CoordenadaX = model8.CoordenadaX,
                                    CoordenadaY = model8.CoordenadaY,
                                    Rutas = model8.Rutas
                                };
                                list2.Last<RutasModel>().Clientes.Add(model14);
                            }
                        }
                    }
                    try
                    {
                        model.CoordenadaX = (from cx in list
                                             orderby cx.CoordenadaX
                                             select cx).ToList<RutasConsultaModel>()[list.Count<RutasConsultaModel>() / 2].CoordenadaX;
                        model.CoordenadaY = (from cx in list
                                             orderby cx.CoordenadaY
                                             select cx).ToList<RutasConsultaModel>()[list.Count<RutasConsultaModel>() / 2].CoordenadaY;
                    }
                    catch (Exception)
                    {
                        model.CoordenadaX = Convert.ToDecimal((double)-104.5345101);
                        model.CoordenadaY = Convert.ToDecimal((double)23.5309891);
                    }
                    model.Rutas = list2;
                    return base.Json(model, JsonRequestBehavior.AllowGet);

                case 4://clientes no visitados
                    str2 = condition.GetDateQuery(dateStatus, init, end, false, "Dia.FechaCaptura");
                    str = (str + condition.strWhereRutas(rutas, "RUT.RUTClave") + condition.strWhereCedis(Cedis, "ALN.AlmacenID")) + str2 + " and cd.CoordenadaX is not null";
                    sConsulta = new StringBuilder();
                    sConsulta.AppendLine("select distinct ");
                    sConsulta.AppendLine("c.Clave,c.RazonSocial,");
                    sConsulta.AppendLine("cd.NombreTienda,cd.Calle,cd.Numero,cd.NumInt,cd.Colonia,cd.CodigoPostal,cd.Poblacion,cd.Entidad,cd.CoordenadaX,cd.CoordenadaY,  ");
                    sConsulta.AppendLine("rut.RUTClave, rut.Descripcion ");
                    sConsulta.AppendLine("from ");
                    sConsulta.AppendLine("AgendaVendedor AGV ");
                    sConsulta.AppendLine("inner join Dia on DIA.DiaClave=AGV.DiaClave  ");
                    sConsulta.AppendLine("inner join  Cliente c on AGV.ClienteClave= c.ClienteClave and C.ClienteClave not in (select VIS.ClienteClave from Visita VIS inner join DIA on DIA.DiaClave= VIS.DiaClave  " + str2 + "  )");
                    sConsulta.AppendLine("inner join ClienteDomicilio cd on c.ClienteClave = cd.ClienteClave and cd.Tipo=2 ");
                    sConsulta.AppendLine("inner join Vendedor VEN on AGV.VendedorId = VEN.VendedorId  ");
                    sConsulta.AppendLine("inner join Ruta RUT ON RUT.RUTClave = AGV.RUTClave  ");
                    sConsulta.AppendLine("inner join Almacen ALN ON ALN.Clave = AGV.ClaveCEDI  ");
                    sConsulta.AppendLine(str);
                    this.QueryString = sConsulta.ToString();
                    list = this.Connection.Query<RutasConsultaModel>(this.QueryString, null, null, true, null, null).ToList<RutasConsultaModel>();
                    foreach (RutasConsultaModel model9 in list)
                    {
                        model9.Rutas = model9.RUTClave;
                        foreach (RutasConsultaModel model10 in list)
                        {
                            if ((model9.Clave == model10.Clave) && (model9.RUTClave != model10.RUTClave))
                            {
                                model9.Rutas = model9.Rutas + ", " + model10.RUTClave;
                            }
                        }
                    }
                    model = new MapaModel();
                    list2 = new List<RutasModel>();
                    num = 0L;
                    foreach (var grouping3 in from ruta in list
                                              group ruta by new { RUTClave = ruta.RUTClave } into grupo
                                              select grupo)
                    {
                        RutasModel model15 = new RutasModel
                        {
                            RUTClave = grouping3.First<RutasConsultaModel>().RUTClave,
                            Color = "#" + num.ToString("X6"),
                            Checked = true,
                            Clientes = new List<ClientePorRutaModel>()
                        };
                        list2.Add(model15);
                        num += 0x7530L;
                        foreach (RutasConsultaModel model11 in grouping3)
                        {
                            if (model11 != null)
                            {
                                ClientePorRutaModel model16 = new ClientePorRutaModel
                                {
                                    Clave = model11.Clave,
                                    RazonSocial = model11.RazonSocial,
                                    Calle = model11.Calle,
                                    Numero = model11.Numero,
                                    CodigoPostal = model11.CodigoPostal,
                                    Colonia = model11.Colonia,
                                    Poblacion = model11.Poblacion,
                                    Entidad = model11.Entidad,
                                    CoordenadaX = model11.CoordenadaX,
                                    CoordenadaY = model11.CoordenadaY,
                                    Rutas = model11.Rutas
                                };
                                list2.Last<RutasModel>().Clientes.Add(model16);
                            }
                        }
                    }
                    try
                    {
                        model.CoordenadaX = (from cx in list
                                             orderby cx.CoordenadaX
                                             select cx).ToList<RutasConsultaModel>()[list.Count<RutasConsultaModel>() / 2].CoordenadaX;
                        model.CoordenadaY = (from cx in list
                                             orderby cx.CoordenadaY
                                             select cx).ToList<RutasConsultaModel>()[list.Count<RutasConsultaModel>() / 2].CoordenadaY;
                    }
                    catch (Exception)
                    {
                        model.CoordenadaX = Convert.ToDecimal((double)-104.5345101);
                        model.CoordenadaY = Convert.ToDecimal((double)23.5309891);
                    }
                    model.Rutas = list2;
                    return base.Json(model, JsonRequestBehavior.AllowGet);
            }
            return base.View();
        }

        public ActionResult Ver()
        {
            return View("ClientesSinVentaMap");
        }

        public ActionResult VerLogistico()
        {
            return View("LogisticoMap");
        }

        public ActionResult NoRegistros()
        {
            return View("Empty");
        }

        [HttpGet]
        public ActionResult getEsquemas()
        {
            ActionResult result;
            List<EsquemaModel> data = new List<EsquemaModel>();
            try
            {
                Connection.Open();
                StringBuilder builder = new StringBuilder();
                builder.Append("select EsquemaID, EsquemaIDPadre, Nombre from Esquema");
                QueryString = builder.ToString();
                data = Connection.Query<EsquemaModel>(QueryString).ToList<EsquemaModel>();
                result = Json(data, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result = base.Json(data, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                this.Connection.Close();
            }
            return result;
        }

        [HttpGet]
        public ActionResult getProductos()
        {
            ActionResult result;
            List<ProductoModel> data = new List<ProductoModel>();
            try
            {
                this.Connection.Open();
                StringBuilder builder = new StringBuilder();
                builder.Append("select p.ProductoClave, p.Nombre from Producto p");
                QueryString = builder.ToString();
                data = this.Connection.Query<ProductoModel>(QueryString).ToList<ProductoModel>();
                result = base.Json(data, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result = base.Json(data, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                this.Connection.Close();
            }
            return result;
        }

    }

    public class RutasConsultaModel
    {
        public string Clave { get; set; }
        public string RazonSocial { get; set; }
        public string NombreTienda { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string NumeroInt { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Poblacion { get; set; }
        public string Entidad { get; set; }
        public string Rutas { get; set; }
        public Decimal CoordenadaX { get; set; }
        public Decimal CoordenadaY { get; set; }
        public string RUTClave { get; set; }
        public string Descripcion { get; set; }
    }

    public class RutasModel
    {
        public string RUTClave { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public bool Checked { get; set; }
        public List<ClientePorRutaModel> Clientes { get; set; }
    }

    public class ClientePorRutaModel
    {
        public string Clave { get; set; }
        public string RazonSocial { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string NumeroInt { get; set; }
        public string CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Poblacion { get; set; }
        public string Entidad { get; set; }
        public string Rutas { get; set; }
        public Decimal CoordenadaX { get; set; }
        public Decimal CoordenadaY { get; set; }
    }

    public class MapaModel
    {
        public Decimal CoordenadaX { get; set; }
        public Decimal CoordenadaY { get; set; }
        public List<RutasModel> Rutas { get; set; }
        public List<RutasModel> RutasTotales { get; set; }
    }

    public class EsquemaModel
    {
        //EsquemaID, EsquemaIDPadre, Nombre
        public string EsquemaID { get; set; }
        public string EsquemaIDPadre { get; set; }
        public string Nombre { get; set; }
    }

    public class ProductoModel
    {
        //ProductoClave, p.Nombre
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
    }
}