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
    public class PromocionesController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Primera Pestaña
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Obtener las Promociones existentes
        [HttpGet]
        [ActionName("ObtenerPromociones")]
        public IHttpActionResult ObtenerPromociones()
        {
            var promociones = (
                from P in db.Promocion
                join VD in db.VAVDescripcion on new { Tipo = P.Tipo.ToString(), Aux1 = "TPROM", Aux2 = "EM" } equals new { Tipo = VD.VAVClave, Aux1 = VD.VARCodigo, Aux2 = VD.VADTipoLenguaje }
                join VDD in db.VAVDescripcion on new { Tipo = P.TipoEstado.ToString(), Aux1 = "EDOREG", Aux2 = "EM" } equals new { Tipo = VDD.VAVClave, Aux1 = VDD.VARCodigo, Aux2 = VDD.VADTipoLenguaje }
                select new { Clave = P.PromocionClave, Nombre = P.Nombre, Tipo = VD.Descripcion, FechaI = P.FechaInicial, FechaF = P.FechaFinal, Estado = VDD.Descripcion }
                         ).ToList();
            return Json(promociones);
        }

        //Esquemas de productos relacionados a la ruta
        [HttpGet]
        [ActionName("ObtenerEsquemas")]
        public IHttpActionResult ObtenerEsquemas()
        {

            var padres = (from x in db.Esquema
                          where x.Baja == false && x.Nivel == 0 && x.Tipo == 2 && x.TipoEstado == 1
                          select new cEsquema
                          {
                              Nombre = x.Nombre + " - " + x.Clave,
                              Abreviatura = x.Abreviatura,
                              EsquemaID = x.EsquemaID,
                              EsquemaIDPadre = x.EsquemaIDPadre,
                              Tipo = x.Tipo,
                              Orden = x.Orden,
                              TipoEstado = x.TipoEstado,
                              NivelHijo = x.Nivel.ToString(),
                              Clasificacion = x.Clasificacion,
                              Clave = x.Clave

                          }).ToList();

            foreach (cEsquema esq in padres)
            {
                //Se busca sobre los padres sí tiene hijos
                obtenerHijos(esq, esq.NivelHijo);
            }
            return Json(padres);
        }

        public void obtenerHijos(cEsquema esquema, string nivel)
        {
            int nivelAux = (nivel == null ? 0 : Convert.ToInt32((nivel).ToString()));
            int nivelHijo = nivelAux + 1;
            var hijos = (from x in db.Esquema
                         where x.EsquemaIDPadre == esquema.EsquemaID
                         select new cEsquema
                         {

                             Nombre = x.Nombre + " - " + x.Clave,
                             Abreviatura = x.Abreviatura,
                             EsquemaID = x.EsquemaID,
                             EsquemaIDPadre = x.EsquemaIDPadre,
                             Tipo = x.Tipo,
                             Orden = x.Orden,
                             TipoEstado = x.TipoEstado,
                             NivelHijo = nivelHijo.ToString(),
                             Clasificacion = x.Clasificacion,
                             Clave = x.Clave

                         }).ToList();
            if (hijos.Count > 0)
            {
                foreach (cEsquema esq in hijos)
                {
                    //Se busca sobre los padres sí tiene hijos
                    obtenerHijos(esq, esq.NivelHijo);
                }
                esquema.esquemas = hijos;
                esquema.children = hijos;

            }

        }

        //Verificar existencia de una Promocion
        [HttpGet]
        [ActionName("ValidarPromocion")]
        public IHttpActionResult ValidarPromocion(string Clave)
        {
            return Json(db.Promocion.ToList().Exists(x => x.PromocionClave == Clave));
        }

        //Obtener Detalles de un cliente
        [HttpGet]
        [ActionName("ObtCliente")]
        public IHttpActionResult ObtCliente(string Clave)
        {
            var Esquemas = (
                from E in db.Esquema
                where E.Clave == Clave && E.Tipo == 1
                select new { Clave = E.Clave, Nombre = E.Nombre, EsquemaID = E.EsquemaID, TipoEstado = E.TipoEstado, Editable = "1" }
                         ).ToList();
            return Json(Esquemas);
        }

        //Obtener Detalles de un cliente
        [HttpGet]
        [ActionName("ObtModulo")]
        public IHttpActionResult ObtModulo(string Clave)
        {
            var Modulos = (
                from M in db.ModuloMovDetalle
                where M.TipoEstado == 1 && M.Baja == false && (M.TipoIndice == 9 || M.TipoIndice == 22 || M.TipoIndice == 26) && M.ModuloMovDetalleClave == Clave.Replace(" ", "+")
                select new { M.ModuloMovDetalleClave, M.Nombre, M.TipoEstado }
                         ).ToList();
            return Json(Modulos);
        }

        //Esquemas de clientes tree-grid
        [HttpGet]
        [ActionName("EsquemaCliente")]
        public IHttpActionResult Esquemas()
        {

            var padres = (from x in db.Esquema
                          where x.Baja == false && x.Nivel == 0 && x.Tipo == 1 && x.TipoEstado == 1
                          select new cEsquema
                          {
                              Nombre = x.Nombre,
                              Abreviatura = x.Abreviatura,
                              EsquemaID = x.EsquemaID,
                              EsquemaIDPadre = x.EsquemaIDPadre,
                              Tipo = x.Tipo,
                              Orden = x.Orden,
                              TipoEstado = x.TipoEstado,
                              NivelHijo = x.Nivel.ToString(),
                              Clasificacion = x.Clasificacion,
                              Clave = x.Clave

                          }).ToList();

            foreach (cEsquema esq in padres)
            {
                //Se busca sobre los padres sí tiene hijos
                obtenerHijos(esq, esq.NivelHijo);
            }
            return Json(padres);
        }

        //Obtener los Modulos Activos
        [HttpGet]
        [ActionName("ObtenerModulos")]
        public IHttpActionResult ObtenerModulos()
        {
            var Modulos = (
                from M in db.ModuloMovDetalle
                where M.TipoEstado == 1 && M.Baja == false && (M.TipoIndice == 9 || M.TipoIndice == 22 || M.TipoIndice == 26)
                select new {M.ModuloMovDetalleClave, M.Nombre, M.TipoEstado, M.Orden, M.TipoIndice}
                         ).ToList();
            return Json(Modulos);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Segunda Pestaña
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Obtener las subempresas
        [HttpGet]
        [ActionName("ObtenerSubEmpresa")]
        public IHttpActionResult ObtenerSubEmpresa()
        {
            var SubEmpresas = (
                from S in db.SubEmpresa
                where S.TipoEstado == 1
                select new { S.NombreCorto, S.SubEmpresaId}
                         ).ToList();
            return Json(SubEmpresas);
        }

        //Obtener los Productos
        [HttpGet]
        [ActionName("ObtenerProductos")]
        public IHttpActionResult ObtenerProductos()
        {
            var Productos = (
                from P in db.Producto
                join PE in db.ProductoEsquema on new { Clave = P.ProductoClave } equals new { Clave = PE.ProductoClave}
                where P.Tipo != 5 && P.TipoFase == 1
                select new { P.ProductoClave, P.Nombre, P.SubEmpresaID, PE.EsquemaID, Estado = "0" }
                         ).ToList();
            return Json(Productos);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Tercera Pestaña
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Editar Promoción
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Obtener datos de la promocion seleccionada
        [HttpGet]
        [ActionName("CargarPromocion")]
        public IHttpActionResult CargarPromocion(string Clave)
        {
            var Promocion = (
                from Pr in db.Promocion
                where Pr.PromocionClave == Clave
                select new { Pr.PromocionClave, Pr.TipoEstado, Pr.Nombre, Pr.Obligatoria, Pr.FechaInicial, Pr.FechaFinal, Pr.Tipo }
                         ).ToList();
            return Json(Promocion);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}