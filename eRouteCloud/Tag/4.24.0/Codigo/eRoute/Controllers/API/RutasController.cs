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
    public class RutasController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Validar si la Ruta esta asignada a algun vendedor
        [HttpGet]
        [ActionName("ValidarRutaAsignada")]
        public IHttpActionResult ValidarRutaAsignada(string Ruta)
        {
            var Asignada = (
                from ven in db.VenRut
                where ven.RUTClave == Ruta
                select new { TipoEstado = ven.TipoEstado.ToString() , }
                ).ToList();
            return Json(Asignada);
        }

        //Validar si la Ruta esta asignada a varios Vendedores
        [HttpGet]
        [ActionName("ValidarRutaVarios")]
        public IHttpActionResult ValidarRutaVarios()
        {
            var Asignada = (
                from con in db.CONHist
                orderby con.CONHistFechaInicio descending
                select new { ClienteVariasRutas = con.ClienteVariasRutas.ToString() }
                ).ToList().First();
            return Json(Asignada);
        }

        //Obtener todos los datos de camión
        [HttpGet]
        [ActionName("ObtCam")]
        public IHttpActionResult ObtCam(string Placa)
        {
            var camion = (
                from cam in db.Camion
                where cam.Clave == Placa
                select new { cam.Clave, cam.Placa }
                ).ToList();
            return Json(camion);
        }

        //Verificar Camion no asignado
        [HttpGet]
        [ActionName("CamionDisponible")]
        public IHttpActionResult CamionDisponible(string Placa)
        {
            var rutas = (
                from rut in db.Ruta
                from cam in db.Camion
                where rut.CAMPlaca == Placa && cam.Clave == Placa
                select new { rut.RUTClave, rut.Descripcion, rut.CAMPlaca, cam.Placa}
                ).ToList();
            return Json(rutas);
        }

        //Verificar existencia de una Ruta
        [HttpGet]
        [ActionName("ValidarClaveRuta")]
        public IHttpActionResult ValidarClaveRuta(string ClaveRuta)
        {
            return Json(db.Ruta.ToList().Exists(x => x.RUTClave == ClaveRuta));
        }

        //Verificar existencia de una Camion
        [HttpGet]
        [ActionName("ValidarClaveCamion")]
        public IHttpActionResult ValidarClaveCamion(string ClaveCamion)
        {
            if (ClaveCamion != "" && ClaveCamion != null && ClaveCamion != "null")
                return Json(db.Camion.ToList().Exists(x => x.Placa == ClaveCamion));
            else
                return Json(true);
        }

        //Obtener las Rutas existentes
        [HttpGet]
        [ActionName("ObtenerRutas")]
        public IHttpActionResult ObtenerRutas()
        {
            var rutas = (
                from rut in db.Ruta
                join vd in db.VAVDescripcion on "TINDMOD" equals vd.VARCodigo
                join vd2 in db.VAVDescripcion on "EDOREG" equals vd2.VARCodigo
                where rut.Tipo.ToString() == vd.VAVClave && rut.TipoEstado.ToString() == vd2.VAVClave && vd.VADTipoLenguaje == "EM" && vd2.VADTipoLenguaje == "EM"
                select new { rut.RUTClave, Des = rut.Descripcion, Tip = vd.Descripcion, Act = vd2.Descripcion}
                         ).ToList();
            return Json(rutas);
        }

        //Obtener Centros De Distribucion
        [HttpGet]
        [ActionName("ObtCentros")]
        public IHttpActionResult ObtCentros(string Usuario)
        {
            var lista = new List<cAlmacen>();

            var btipouso = (
                from x in db.Almacen
                join UA in db.UsuarioAlmacen on x.AlmacenID equals UA.AlmacenId 
                where x.TipoEstado == 1 && UA.USUId == Usuario
                select new cAlmacen { AlmacenID = x.AlmacenID, NombreCompuesto = x.Clave + " - " + x.Nombre }).Distinct();
            return Json(btipouso);

        }

        //Obtener Camiones
        [HttpGet]
        [ActionName("ObtCamiones")]
        public IHttpActionResult ObtCamiones()
        {
            var cam = (
                from c in db.Camion
                from r in db.Ruta.Where(rutas => rutas.CAMPlaca == c.Placa).DefaultIfEmpty()
                where (c.TipoCamion.ToString() != "")
                select new { c.Placa, c.Clave, c.Descripcion, TipoCamion = c.TipoCamion.ToString(), c.CapacidadKg, c.Cajas, /*r.RUTClave, Des = r.Descripcion */ Des = r.RUTClave + r.Descripcion }
                ).ToList();

            var Aux = (
                from c in cam
                join vd in db.VAVDescripcion on "TIPOCAM" equals vd.VARCodigo
                where c.TipoCamion.ToString() == vd.VAVClave && vd.VADTipoLenguaje == "EM"
                select new { c.Placa, c.Clave, c.Descripcion, TipoCamion = vd.Descripcion, c.CapacidadKg, c.Cajas, c.Des }
                ).ToList();

            return Json(Aux);
        }

        //Cargar Ruta
        [HttpGet]
        [ActionName("CargarRuta")]
        public IHttpActionResult CargarRuta(string rutaC)
        {
            var objRuta = (
                from x in db.Ruta
                from c in db.Camion.Where(Vehiculo => Vehiculo.Placa == x.CAMPlaca).DefaultIfEmpty()
                where x.RUTClave == rutaC
                select new { x.RUTClave, x.Descripcion, Tipo = x.Tipo.ToString(), TipoEstado = x.TipoEstado.ToString(), x.Inventario, x.AlmacenID, x.CAMPlaca, c.Clave }
                ).ToList();
            return Json(objRuta);
        }

        //Obtener UsuarioAlmacen
        [HttpGet]
        [ActionName("UsuarioAlmacen")]
        public IHttpActionResult UsuarioAlmacen(string Usuario)
        {
            var objUsuario = (
                from x in db.UsuarioAlmacen
                where x.USUId == Usuario
                select x.USUId
                ).ToList();
            return Json(objUsuario);
        }

        //Obtener Esquemas asignados a la Ruta seleccionada
        [HttpGet]
        [ActionName("ObtEsquemas")]
        public IHttpActionResult ObtEsquemas(string Ruta)
        {
            var Esquemas = (
                from RPE in db.RutaProductoEsquema
                join E in db.Esquema on new { EsquemaID = RPE.EsquemaID, Clave = RPE.RUTClave } equals new { EsquemaID = E.EsquemaID, Clave = Ruta }
                select new { Clave = E.Clave, Nombre = E.Nombre, EsquemaID = RPE.EsquemaID }
                         ).ToList();
            return Json(Esquemas);
        }

        //Obtener Detalles de un producto
        [HttpGet]
        [ActionName("ObtProducto")]
        public IHttpActionResult ObtProducto(string Clave)
        {
            var Esquemas = (
                from E in db.Esquema
                where E.Clave == Clave && E.Tipo == 2
                select new { Clave = E.Clave, Nombre = E.Nombre, EsquemaID = E.EsquemaID, Editable = "1" }
                         ).ToList();
            return Json(Esquemas);
        }

        [HttpPost]
        public Boolean CAMPlacaClean(Ruta ruta)
        {
            //Editar CAMPlaca
            var query =
                    from rut in db.Ruta
                    where rut.RUTClave == ruta.RUTClave
                    select rut;

            foreach (Ruta rut in query)
            {
                rut.CAMPlaca = null;
            }
            try
            {
                db.SaveChanges();
                Console.WriteLine("Exitoso");
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
        
        [HttpPost]
        public bool GuardarRuta(Ruta ruta)
        {
            Ruta cRuta;
            var nuevo = !db.Ruta.ToList().Exists(x => x.RUTClave == ruta.RUTClave);
            if (nuevo)
            {
                cRuta = new Ruta();
                cRuta.RUTClave = ruta.RUTClave;
            }
            else
            {
                cRuta = db.Ruta.ToList().First(x => x.RUTClave == ruta.RUTClave);
            }
            cRuta.Descripcion = ruta.Descripcion;
            cRuta.Tipo = ruta.Tipo;
            cRuta.TipoEstado = ruta.TipoEstado;
            cRuta.Inventario = ruta.Inventario;
            cRuta.FolioClienteNvo = 0;
            cRuta.AlmacenID = ruta.AlmacenID;
            if(ruta.CAMPlaca==null||ruta.CAMPlaca=="")
                cRuta.CAMPlaca = null;
            else
                cRuta.CAMPlaca = ruta.CAMPlaca;
            cRuta.MFechaHora = DateTime.Now;
            cRuta.MUsuarioID = ruta.MUsuarioID;
            if (nuevo)
            {
                db.Ruta.Add(cRuta);
            }
            try
            {
                db.SaveChanges();
                Console.WriteLine("Exitoso");
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

        //Eliminar producto relacionado a la Ruta seleccionada
        [HttpPost]
        public bool Eliminar(RutaProductoEsquema Ruta)
        {
            RutaProductoEsquema cRuta;
            var nuevo = !db.RutaProductoEsquema.ToList().Exists(x => x.RUTClave == Ruta.RUTClave && x.EsquemaID == Ruta.EsquemaID);
            if (!nuevo)
            {
                cRuta = db.RutaProductoEsquema.Where(R => R.RUTClave == Ruta.RUTClave && R.EsquemaID == Ruta.EsquemaID).FirstOrDefault();
                db.RutaProductoEsquema.Remove(cRuta);
            }
            try
            {
                db.SaveChanges();
                Console.WriteLine("Exitoso");
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

        [HttpPost]
        public bool Agregar(RutaProductoEsquema producto)
        {
            RutaProductoEsquema cProducto;
            var nuevo = !db.RutaProductoEsquema.ToList().Exists(x => x.RUTClave == producto.RUTClave && x.EsquemaID == producto.EsquemaID);
            if (nuevo)
            {
                cProducto = new RutaProductoEsquema();
                cProducto.RUTClave = producto.RUTClave;
            }
            else
            {
                cProducto = db.RutaProductoEsquema.Where(R => R.RUTClave == producto.RUTClave && R.EsquemaID == producto.EsquemaID).FirstOrDefault();
            }
            cProducto.EsquemaID = producto.EsquemaID;
            cProducto.MFechaHora = DateTime.Now;
            cProducto.MUsuarioID = producto.MUsuarioID;
            if (nuevo)
            {
                db.RutaProductoEsquema.Add(cProducto);
            }
            try
            {
                db.SaveChanges();
                Console.WriteLine("Exitoso");
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

        //Esquemas de productos relacionados a la ruta
        [HttpGet]
        [ActionName("Esquemas")]
        public IHttpActionResult Esquemas()
        {

            var padres = (from x in db.Esquema
                          where x.Baja == false && x.Nivel == 0 && x.Tipo == 2 && x.TipoEstado == 1
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

        public void obtenerHijos(cEsquema esquema, string nivel)
        {
            int nivelAux = (nivel == null ? 0 : Convert.ToInt32((nivel).ToString()));
            int nivelHijo = nivelAux + 1;
            //var cabecera = (from x in db.Esquema
            //                select new cEsquema
            //                {

            //                    Nombre = "Nombre",
            //                    Abreviatura = "Abreviatura",
            //                    EsquemaID = x.EsquemaID,
            //                    EsquemaIDPadre = x.EsquemaIDPadre,
            //                    Tipo = x.Tipo,
            //                    Orden = x.Orden,
            //                    TipoEstado = x.TipoEstado,
            //                    NivelHijo = nivelHijo.ToString(),
            //                    Clasificacion = x.Clasificacion,
            //                    Clave = x.Clave

            //                }).Take(1).ToList();
            var hijos = (from x in db.Esquema
                         where x.EsquemaIDPadre == esquema.EsquemaID
                         select new cEsquema
                         {

                             Nombre = x.Nombre,
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
            //hijos.AddRange(cabecera);
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
    }
}