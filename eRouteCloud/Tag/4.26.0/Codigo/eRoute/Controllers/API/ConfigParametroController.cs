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
    public class ConfigParametroController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Obtener los parametros activos
        [HttpGet]
        [ActionName("ObtenerParametros")]
        public IHttpActionResult ObtenerParametros()
        {
            var Parametros = (
                from CP in db.ConfigParametro
                from VD in db.VAVDescripcion.Where(Tipo => Tipo.VAVClave == CP.TipoAplicacion.ToString() && Tipo.VARCodigo == "BMENAPL" && Tipo.VADTipoLenguaje == "EM").DefaultIfEmpty()
                from VDD in db.VAVDescripcion.Where(Nivel => Nivel.VAVClave == CP.Nivel.ToString() && Nivel.VARCodigo == "NIPA" && Nivel.VADTipoLenguaje == "EM").DefaultIfEmpty()
                from MC in db.MOTConfiguracion.Where(ID => ID.ModuloClave == CP.Identificador && CP.Nivel == 2).DefaultIfEmpty()
                from MMD in db.ModuloMovDetalle.Where(ID => ID.ModuloMovDetalleClave == CP.Identificador && CP.Nivel == 3).DefaultIfEmpty()
                select new { CP.Parametro, Identificador = (CP.Nivel == 2 ? MC.Nombre : CP.Nivel == 3 ? MMD.Nombre : CP.Identificador) == null ? "No coincide con identificador": (CP.Nivel == 2 ? MC.Nombre : CP.Nivel == 3 ? MMD.Nombre : CP.Identificador), CP.Valor, Nivel = VDD.Descripcion, TipoAplicacion = VD.Descripcion}
                         ).ToList();
            return Json(Parametros);
        }

        //Obtener los parametros disponibles
        [HttpGet]
        [ActionName("MensajeParametros")]
        public IHttpActionResult MensajeParametros()
        {
            var Parametros = (
                from M in db.Mensaje
                join VD in db.VAVDescripcion on new {TipoMensaje = M.TipoMensaje, Tipo = "BMENSAJE", Lenguaje = "EM" } equals new {TipoMensaje = VD.VAVClave, Tipo = VD.VARCodigo, Lenguaje = VD.VADTipoLenguaje }
                join VDD in db.VAVDescripcion on new { TipoProyecto = M.TipoProyecto.ToString(), Tipo = "BPROYECT", Lenguaje = "EM" } equals new { TipoProyecto = VDD.VAVClave, Tipo = VDD.VARCodigo, Lenguaje = VDD.VADTipoLenguaje }
                join MC in db.MENDetalle on new { M.MENClave, Lenguaje = "EM" } equals new { MC.MENClave, Lenguaje = MC.MEDTipoLenguaje }
                where M.MFechaHora.ToString().Contains("18 10:36")
                select new { M.MENClave, TipoMensaje = VD.Descripcion, TipoProyecto = VDD.Descripcion, Descripcion = MC.Descripcion }
                         ).ToList();
            return Json(Parametros);
        }

        //Verificar existencia del Parametro
        [HttpGet]
        [ActionName("ValidarParametro")]
        public IHttpActionResult ValidarClaveRuta(string Parametro)
        {
            if (Parametro != "" && Parametro != null)
                return Json(db.Mensaje.Where(S => S.MFechaHora.ToString().Contains("18 10:36")).ToList().Exists(x => x.MENClave == Parametro));
            else
                return Json(true);
        }

        //Obtener descripcion del parametro enviado
        [HttpGet]
        [ActionName("ObtenerDescripcion")]
        public IHttpActionResult ObtenerDescripcion(String Clave)
        {
            var Parametros = (
                from M in db.Mensaje
                join VD in db.VAVDescripcion on new {TipoMensaje = M.TipoMensaje, Tipo = "BMENSAJE", Lenguaje = "EM" } equals new {TipoMensaje = VD.VAVClave, Tipo = VD.VARCodigo, Lenguaje = VD.VADTipoLenguaje }
                join VDD in db.VAVDescripcion on new { TipoProyecto = M.TipoProyecto.ToString(), Tipo = "BPROYECT", Lenguaje = "EM" } equals new { TipoProyecto = VDD.VAVClave, Tipo = VDD.VARCodigo, Lenguaje = VDD.VADTipoLenguaje }
                join MC in db.MENDetalle on new { M.MENClave, Lenguaje = "EM" } equals new { MC.MENClave, Lenguaje = MC.MEDTipoLenguaje }
                where M.MFechaHora.ToString().Contains("18 10:36") && MC.MENClave == Clave
                select new { M.MENClave, TipoMensaje = VD.Descripcion, TipoProyecto = VDD.Descripcion, Descripcion = MC.Descripcion }
                         ).ToList();
            return Json(Parametros);
        }

        //Verificar existencia del Identificador de MotConfiguracion
        [HttpGet]
        [ActionName("ValidarIdentificador")]
        public IHttpActionResult ValidarIdentificador(string Identificador, string Nivel)
        {
            if (Identificador != "" && Identificador != null)
            {
                if (Nivel == "2")
                {
                    return Json(db.MOTConfiguracion.ToList().Exists(x => x.ModuloClave == Identificador));
                }
                else if (Nivel == "3")
                {
                    return Json(db.ModuloMovDetalle.ToList().Exists(x => x.ModuloMovDetalleClave == Identificador));
                }
                else
                    return Json(true);
            }
            else
                return Json(true);
        }

        //Obtener los Identificadores disponibles para el nivel seleccionado
        [HttpGet]
        [ActionName("ObtenerIdentificadores")]
        public IHttpActionResult ObtenerIdentificadores(string Nivel)
        {
            if (Nivel == "2")
            {
                var Identificadores = (
                from Mot in db.MOTConfiguracion
                select new { Identificador = Mot.ModuloClave, Nivel = "MOTConfiguracion", Descripcion = Mot.Nombre }
                         ).ToList();
                return Json(Identificadores);
            }
            else
            {
                var Identificadores = (
                from Mod in db.ModuloMovDetalle
                select new { Identificador = Mod.ModuloMovClave, Nivel = "ModuloMovDetalle", Descripcion = Mod.Nombre }
                         ).ToList();
                return Json(Identificadores);
            }
        }

        //Almacenar parametro
        [HttpPost]
        public bool AlmacenarParametro(ConfigParametro parametro)
        {
            ConfigParametro cParametro;
            var nuevo = !db.ConfigParametro.ToList().Exists(x => x.Parametro == parametro.Parametro && x.Identificador == parametro.Identificador);
            if (nuevo)
            {
                cParametro = new ConfigParametro();
                cParametro.Parametro = parametro.Parametro;
                cParametro.Identificador = parametro.Identificador;
            }
            else
            {
                cParametro = db.ConfigParametro.Where(P => P.Parametro == parametro.Parametro && P.Identificador == parametro.Identificador).FirstOrDefault();
            }
            cParametro.Valor = parametro.Valor;
            cParametro.Nivel = parametro.Nivel;
            cParametro.TipoAplicacion = parametro.TipoAplicacion;
            if (nuevo)
            {
                db.ConfigParametro.Add(cParametro);
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

        //Eliminar registro de la tabla de ConfigParametro
        [HttpPost]
        public bool EliminarParametro(ConfigParametro parametro)
        {
            ConfigParametro cParametro;
            cParametro = db.ConfigParametro.Where(P => P.Parametro == parametro.Parametro && P.Identificador == parametro.Identificador).FirstOrDefault();
            db.ConfigParametro.Remove(cParametro);
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

    }
}