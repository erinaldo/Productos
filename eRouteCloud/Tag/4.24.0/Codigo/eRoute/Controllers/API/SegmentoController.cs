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
using Newtonsoft.Json;

namespace eRoute.Controllers.API
{
    public class SegmentoController : ApiController
    {
        RouteEntities db = new RouteEntities();

        [HttpPost]
        public bool GuardarEsquema(Esquema esquema)
        {
            if (esquema != null)
            {
                bool nuevo = !db.Esquema.ToList().Exists(x => x.EsquemaID == esquema.EsquemaID);
                Esquema cEsquema;
                if (nuevo)
                {
                    cEsquema = new Esquema();
                    // cEsquema.EsquemaID = esquema.EsquemaID;
                    cEsquema.EsquemaID = "ESQUEMAIDCLAVE13";
                }
                else
                {
                    cEsquema = db.Esquema.ToList().First(x => x.EsquemaID == esquema.EsquemaID);
                }
                cEsquema.Clave = esquema.Clave;
                cEsquema.EsquemaIDPadre = (esquema.EsquemaIDPadre == "" ? null : esquema.EsquemaIDPadre);
                cEsquema.Nombre = esquema.Nombre;
                cEsquema.Abreviatura = esquema.Abreviatura;
                cEsquema.Baja = esquema.Baja;
                cEsquema.Clasificacion = esquema.Clasificacion;
                cEsquema.Nombre = esquema.Nombre;
                cEsquema.Orden = esquema.Orden;
                cEsquema.Tipo = esquema.Tipo;
                cEsquema.TipoEstado = esquema.TipoEstado;
                cEsquema.MUsuarioID = esquema.MUsuarioID;
                cEsquema.MFechaHora = DateTime.Now;

                if (nuevo)
                {
                    //Agregar productos prioritarios
                    if (esquema.Tipo == 2)
                    {
                        if (esquema.ProductoPrioritarioEsq.Count > 0)
                        {
                            foreach (ProductoPrioritarioEsq cprodPrior in esquema.ProductoPrioritarioEsq)
                            {
                                ProductoPrioritarioEsq pro = new ProductoPrioritarioEsq();
                                pro.ProductoClave = cprodPrior.ProductoClave;
                                pro.EsquemaId = cEsquema.EsquemaID;
                                pro.MUsuarioId = esquema.MUsuarioID;
                                pro.MFechaHora = DateTime.Now;
                                db.ProductoPrioritarioEsq.Add(pro);
                            }
                        }
                    }

                    db.Esquema.Add(cEsquema);
                }
                else
                {

                    var eliminarEsq = new List<string>();
                    //    foreach (UsuarioAlmacen usuarioA in cUsuario.UsuarioAlmacen)
                    foreach (ProductoPrioritarioEsq prodEsq in cEsquema.ProductoPrioritarioEsq)
                    {
                        if (!esquema.ProductoPrioritarioEsq.ToList().Exists(x => x.EsquemaId == prodEsq.EsquemaId && prodEsq.ProductoClave == x.ProductoClave))
                        {
                            eliminarEsq.Add(prodEsq.ProductoClave);
                        }
                    }

                    foreach (string esq in eliminarEsq)
                    {
                        db.ProductoPrioritarioEsq.Remove(db.ProductoPrioritarioEsq.First(x => x.EsquemaId == cEsquema.EsquemaID && x.ProductoClave == esq));
                    }

                    if (esquema.Tipo == 2)
                    {
                        if (esquema.ProductoPrioritarioEsq.Count > 0)
                        {
                            foreach (ProductoPrioritarioEsq cprodPrior in esquema.ProductoPrioritarioEsq)
                            {
                                if(!db.ProductoPrioritarioEsq.ToList().Exists(x => x.ProductoClave == cprodPrior.ProductoClave && x.EsquemaId == cprodPrior.EsquemaId))
                                {
                                    ProductoPrioritarioEsq pro = new ProductoPrioritarioEsq();
                                    pro.ProductoClave = cprodPrior.ProductoClave;
                                    pro.EsquemaId = cEsquema.EsquemaID;
                                    pro.MUsuarioId = esquema.MUsuarioID;
                                    pro.MFechaHora = DateTime.Now;
                                    db.ProductoPrioritarioEsq.Add(pro);
                                }
                            }
                        }
                    }


                }
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        // Get entry

                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;

                        // Display or log error messages

                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                     subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            Console.WriteLine(message);
                        }
                    }
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
              
        }
       
        [HttpGet]
        [ActionName("ObtenerEsquemas")]
        public IHttpActionResult ObtenerEsquemas()
        {

            var padres = (from x in db.Esquema where x.Nivel == 0 select new cEsquema{
                Nombre = x.Nombre,
                Abreviatura = x.Abreviatura,
                EsquemaID = x.EsquemaID,
                EsquemaIDPadre = x.EsquemaIDPadre,
                Tipo = x.Tipo,
                Orden = x.Orden,
                TipoEstado = x.TipoEstado,
                NivelHijo = x.Nivel.ToString()

            }).ToList();

            foreach(cEsquema esq in padres)
            {
                //Se busca sobre los padres sí tiene hijos
                obtenerHijos(esq,esq.NivelHijo);
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
                             Clave = x.Clave,
                             Nombre = x.Nombre,
                             Abreviatura = x.Abreviatura,
                             EsquemaID = x.EsquemaID,
                             EsquemaIDPadre = x.EsquemaIDPadre,
                             Tipo = x.Tipo,
                             Orden = x.Orden,
                             TipoEstado = x.TipoEstado,
                             NivelHijo = nivelHijo.ToString()

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

        [HttpGet]
        [ActionName("ObtenerEsquemasActivos")]
        public IHttpActionResult ObtenerEsquemasActivos(int Tipo)
        {
            var padres = (from x in db.Esquema

                          where x.Nivel == 0 && x.Tipo == Tipo && x.TipoEstado == 1
                          select new cEsquema
                          {
                              Clave = x.Clave,
                              Nombre = x.Nombre,
                              Abreviatura = x.Abreviatura,
                              EsquemaID = x.EsquemaID,
                              EsquemaIDPadre = x.EsquemaIDPadre,
                              Tipo = x.Tipo,
                              Orden = x.Orden,
                              Clasificacion = x.Clasificacion,
                              NivelHijo = x.Nivel.ToString()

                          }).ToList();

            foreach (cEsquema esq in padres)
            {
                //Se busca sobre los padres sí tiene hijos
                obtenerHijos(esq, esq.NivelHijo);
            }
            return Json(padres);
        }

        public void obtenerHijosActivos(cEsquema esquema, string nivel)
        {
            int nivelAux = (nivel == null ? 0 : Convert.ToInt32((nivel).ToString()));
            int nivelHijo = nivelAux + 1;
            var hijos = (from x in db.Esquema
                         where x.EsquemaIDPadre == esquema.EsquemaID && x.TipoEstado == 1
                         select new cEsquema
                         {
                             Clave = x.Clave,
                             Nombre = x.Nombre,
                             Abreviatura = x.Abreviatura,
                             EsquemaID = x.EsquemaID,
                             EsquemaIDPadre = x.EsquemaIDPadre,
                             Tipo = x.Tipo,
                             Orden = x.Orden,
                             NivelHijo = nivelHijo.ToString()

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


        [HttpGet]
        [ActionName("verificarEsquema")]
        public IHttpActionResult verificarEsquema(string esquemaId)
        {
            var esquema = (from x in db.Esquema
                           join e in db.Esquema on x.EsquemaID equals e.EsquemaID
                           where x.EsquemaID == esquemaId select new {
                Nombre = x.Nombre,
                Abreviatura = x.Abreviatura,
                EsquemaID = x.EsquemaID,
                NombrePadre = e.Nombre,
                EsquemaIDPadre = x.EsquemaIDPadre,
                Tipo = x.Tipo.ToString(),
                Orden = x.Orden,
                TipoEstado = x.TipoEstado.ToString(),
                Clasificacion = x.Clasificacion.ToString(),
                Clave = x.Clave
            });

            return Json(esquema);
        }

        [HttpGet]
        [ActionName("obtenerProductosPrioritarios")]
        public IHttpActionResult obtenerProductosPrioritarios()
        {
            var productos = (from pro in db.Producto
                             where pro.Venta == true && pro.Contenido == true
                             select new {
                                 pro.ProductoClave,
                                 pro.Nombre,
                                 pro.NombreLargo,
                                 pro.Id,
                                 pro.Tipo,
                                 pro.TipoFase
                             } );

 
            return Json(productos);

        }

        [HttpGet]
        [ActionName("obtenerProductosDetalle")]
        public IHttpActionResult obtenerProductosDetalle(string EsquemaID)
        {
            var productoDetalle = (from x in db.ProductoPrioritarioEsq
                                   join p in db.Producto on x.ProductoClave equals p.ProductoClave
                                   select new
                                   {
                                       Nombre = p.Nombre,
                                       ProductoClave = p.ProductoClave
                                   });
            return Json(productoDetalle);
        }
        [HttpGet]
        [ActionName("verificarPorcentajeCambios")]
        public IHttpActionResult verificarPorcentajeCambios()
        {
            return Json(db.ConfigParametro.ToList().Exists(x => x.Parametro == "PorCambios" && x.Valor == "1"));
        }

        [HttpGet]
        [ActionName("esquemasUtilizados")]
        public IHttpActionResult esquemasUtilizados(string EsquemaID)
        {
            var cont = 0;

            var esquemaPadre = (from x in db.Esquema where x.EsquemaIDPadre == EsquemaID select x);
            var ProductoEsquema = (from x in db.ProductoEsquema where x.EsquemaID == EsquemaID select x);
            var ClienteEsquema = (from x in db.ClienteEsquema where x.EsquemaID == EsquemaID select x);
            var PrecioClienteEsquema = (from x in db.PrecioClienteEsquema where x.EsquemaID == EsquemaID select x);
            var ModuloEsquema = (from x in db.ModuloEsquema where x.EsquemaID == EsquemaID select x);
            var PromocionDetalle = (from x in db.PromocionDetalle where x.EsquemaID == EsquemaID select x);
            var DESDetalle = (from x in db.DESDetalle where x.EsquemaID == EsquemaID select x);
            var CUOEsquema = (from x in db.CUOEsquema where x.EsquemaID == EsquemaID select x);
            var ImpuestoEsquema = (from x in db.ImpuestoEsquema where x.EsquemaID == EsquemaID select x);
            var VendedorEsquema = (from x in db.VendedorEsquema where x.EsquemaID == EsquemaID select x);

            var nombre = "";
            bool primero = false, disponible = true;

            if (esquemaPadre.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "Esquema"; primero = true; }
            }
            if (ProductoEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "ProductoEsquema"; primero = true;
            }
        }
            if (ClienteEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false){ nombre = "ClienteEsquema"; primero = true; }
}
            if (PrecioClienteEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false){ nombre = "PrecioClienteEsquema"; primero = true; }
            }
            if (ModuloEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false){  nombre = "ModuloEsquema"; primero = true; }
            }
            if (PromocionDetalle.ToList().Count > 0)
            {
                cont++;
                if (primero == false){  nombre = "PromocionDetalle"; primero = true; }
            }
            if (DESDetalle.ToList().Count > 0)
            {
                cont++;
                if (primero == false){ nombre = "DESDetalle"; primero = true; }
            }
            if (CUOEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false){ nombre = "CUOEsquema"; primero = true; }
            }
            if (ImpuestoEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false){ nombre = "ImpuestoEsquema"; primero = true; }
            }
            if (VendedorEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false) {nombre = "VendedorEsquema"; primero = true; }
            }


            if (cont > 0)
                disponible = false;
            else
                disponible = true;
            var lista = new List<EsquemaDisponible>();
            lista.Add(new EsquemaDisponible { Disponible = disponible, Nombre = nombre });
            return Json(lista);
        }
        [HttpGet]
        [ActionName("verificarEliminarEsquema")]
        public IHttpActionResult verificarEliminarEsquema(string EsquemaID)
        {
            var lista = new List<EsquemaDisponible>();
            var nombreDispoible = validarUsoEsquema(EsquemaID);
            var nombre = nombreDispoible.Split('%')[0];
            var disponible = nombreDispoible.Split('%')[1];

            if (disponible == "true")
            {
                db.Esquema.Remove(db.Esquema.First(x => x.EsquemaID == EsquemaID)).Baja = true;
                db.SaveChanges();
                lista.Add(new EsquemaDisponible { Disponible = true, Nombre = nombre });
                return Json(lista);
            }else
            {
                lista.Add(new EsquemaDisponible { Disponible = false, Nombre = nombre });
                return Json(lista);
            }
        }

        public string validarUsoEsquema(string EsquemaID)
        {
            var cont = 0;

            var esquemaPadre = (from x in db.Esquema where x.EsquemaIDPadre == EsquemaID select x);
            var ProductoEsquema = (from x in db.ProductoEsquema where x.EsquemaID == EsquemaID select x);
            var ClienteEsquema = (from x in db.ClienteEsquema where x.EsquemaID == EsquemaID select x);
            var PrecioClienteEsquema = (from x in db.PrecioClienteEsquema where x.EsquemaID == EsquemaID select x);
            var ModuloEsquema = (from x in db.ModuloEsquema where x.EsquemaID == EsquemaID select x);
            var PromocionDetalle = (from x in db.PromocionDetalle where x.EsquemaID == EsquemaID select x);
            var DESDetalle = (from x in db.DESDetalle where x.EsquemaID == EsquemaID select x);
            var CUOEsquema = (from x in db.CUOEsquema where x.EsquemaID == EsquemaID select x);
            var ImpuestoEsquema = (from x in db.ImpuestoEsquema where x.EsquemaID == EsquemaID select x);
            var VendedorEsquema = (from x in db.VendedorEsquema where x.EsquemaID == EsquemaID select x);

            var nombre = "";
            var disponible = "";
            bool primero = false;

            if (esquemaPadre.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "Esquema"; primero = true; }
            }
            if (ProductoEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false)
                {
                    nombre = "ProductoEsquema"; primero = true;
                }
            }
            if (ClienteEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "ClienteEsquema"; primero = true; }
            }
            if (PrecioClienteEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "PrecioClienteEsquema"; primero = true; }
            }
            if (ModuloEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "ModuloEsquema"; primero = true; }
            }
            if (PromocionDetalle.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "PromocionDetalle"; primero = true; }
            }
            if (DESDetalle.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "DESDetalle"; primero = true; }
            }
            if (CUOEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "CUOEsquema"; primero = true; }
            }
            if (ImpuestoEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "ImpuestoEsquema"; primero = true; }
            }
            if (VendedorEsquema.ToList().Count > 0)
            {
                cont++;
                if (primero == false) { nombre = "VendedorEsquema"; primero = true; }
            }


            if (cont > 0)
                disponible = "false";
            else
                disponible = "true";

            return nombre + "%" +disponible;
        }

    }

}