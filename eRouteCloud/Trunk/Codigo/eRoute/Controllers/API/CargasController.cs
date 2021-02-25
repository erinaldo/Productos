using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace eRoute.Controllers.API
{
    public class CargasController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //CARGAS INICIO

        [HttpGet]
        [ActionName("ObtenerCargas")]
        public IHttpActionResult ObtenerCargas()
        {
            var fecha = "02/08/2016";

            var cargas = (from T in db.TransProd
                          where T.Tipo == 2 //&& T.DiaClave == fecha
                          from A in db.Almacen
                          where A.Clave == T.Notas
                          //from A2 in db.Almacen
                          from V in db.Vendedor
                          where V.USUId == T.MUsuarioID
                          select new
                          {
                              T.TransProdID,
                              T.Folio,
                              T.DiaClave,
                              Almacen = T.TipoFase != 1 ? A.Nombre : "",
                              Vendedor = V.Nombre,
                              T.TipoFase,
                              Sugerida = T.TipoMotivo == 9 ? 1 : 0
                          }).ToList();

            return Json(cargas);
        }

        [HttpGet]
        [ActionName("ObtenerCONHIST")]
        public IHttpActionResult ObtenerCONHIST(string USUId)
        {
            var CONHIST = (
                from C in db.Configuracion
                from x in db.CONHist
                where x.ConfiguracionID == C.ConfiguracionID
                orderby x.CONHistFechaInicio descending
                select new { x.FolioAutCarga }).First();
            return Json(CONHIST);
        }

        [HttpGet]
        [ActionName("ObtenerCentroDistribucion")]
        public IHttpActionResult ObtenerCentroDistribucion()
        {
            var lista = new List<cAlmacen>();

            var cedi = (
                from x in db.Almacen
                where x.Tipo.Equals("1") && x.TipoEstado == 1
                select new cAlmacen { AlmacenID = x.AlmacenID, Nombre =  x.Nombre });
            return Json(cedi);

        }


        [HttpGet]
        [ActionName("ObtenerModulo")]
        public IHttpActionResult ObtenerModulo()
        {
            var modulos = (from md in db.ModuloMovDetalle
                           join mt in db.ModuloTerm on md.ModuloClave equals mt.ModuloClave
                           where md.TipoIndice == 10 && md.TipoTransProd == 2 && md.TipoEstado == 1 && mt.TipoEstado == 1
                           select new
                           {
                               md.ModuloMovDetalleClave,
                               md.Nombre
                           }).ToList();
            return Json(modulos);
        }

        [HttpGet]
        [ActionName("ObtenerRutasPreventa")]
        public IHttpActionResult ObtenerRutasPreventa()
        {
            var rutas = (from R in db.Ruta
                           where R.Tipo==2 && R.TipoEstado==1
                           select new
                           {
                               R.RUTClave,
                               R.Descripcion
                           }).ToList();
            return Json(rutas);
        }


        //CARGAS INICIO






        [HttpGet]
        [ActionName("ValidarClaveProducto")]
        public IHttpActionResult ValidarClaveProducto(string ProductoClave)
        {
            return Json(db.Producto.ToList().Exists(x => x.ProductoClave == ProductoClave));
        }

     

    }
}