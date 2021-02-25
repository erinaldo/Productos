using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;
using System.Web.Script.Serialization;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace eRoute.Controllers.API
{
    public class FrecuenciasController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Obtener frecuencias para index
        [HttpGet]
        [ActionName("ObtenerFrecuencias")]
        public IHttpActionResult ObtenerFrecuencias()
        {
            var valter = (from f in db.Frecuencia
                          join vd in db.VAVDescripcion on f.Tipo.ToString() equals vd.VAVClave.ToString()
                          where vd.VARCodigo == "FRETIPO" && vd.VADTipoLenguaje == "EM"
                          orderby f.MFechaHora descending
                          
                          select new
                          {
                              f.FrecuenciaClave,
                              f.Descripcion,
                              Tipo = vd.Descripcion,
                              tip = f.Tipo,
                              f.FechaInicio,
                              f.FechaFinal,
                              f.UnidadInicio,
                              f.Repeticion,
                              f.Intervalo
                          }).ToList();
            return Json(valter);
        }



      

        //Mandar y Editar
        [HttpGet]
        [ActionName("ObtenerValorFrecuencia")]
        public IHttpActionResult ObtenerValorFrecuencia(string clave)
        {
            var valter = (from frec in db.Frecuencia
                          where frec.FrecuenciaClave == clave
                          select new {
                              frec.FrecuenciaClave,
                              frec.Descripcion,
                              frec.Tipo,
                              frec.FechaInicio,
                              frec.FechaFinal,
                              frec.UnidadInicio,
                              frec.Repeticion,
                              frec.Intervalo
                          }).ToList();

            return Json(valter);
        }




        ///guardar
        [HttpPost]
        public bool Grabar(Frecuencia f)
        {
 
            bool nuevo = !db.Frecuencia.ToList().Exists(x => x.FrecuenciaClave == f.FrecuenciaClave);
            

            if (nuevo){
                Frecuencia frec = new Frecuencia();
                frec.FrecuenciaClave = f.FrecuenciaClave;
                frec.Descripcion = f.Descripcion;
                frec.Tipo = f.Tipo;
                frec.FechaInicio = f.FechaInicio;
                frec.FechaFinal = f.FechaFinal;
                frec.UnidadInicio = f.UnidadInicio;
                frec.Repeticion = f.Repeticion;
                frec.Intervalo = f.Intervalo;
                frec.MUsuarioID = f.MUsuarioID;
                frec.MFechaHora = DateTime.Now;
                db.Frecuencia.Add(frec);
            }
            else
            {
                Frecuencia updateFrec = (from fr in db.Frecuencia where fr.FrecuenciaClave == f.FrecuenciaClave select fr).SingleOrDefault();
                updateFrec.Descripcion = f.Descripcion;
                updateFrec.Tipo = f.Tipo;
                updateFrec.FechaInicio = f.FechaInicio;
                updateFrec.FechaFinal = f.FechaFinal;
                updateFrec.UnidadInicio = f.UnidadInicio;
                updateFrec.Repeticion = f.Repeticion;
                updateFrec.Intervalo = f.Intervalo;
                updateFrec.MUsuarioID = f.MUsuarioID;
                updateFrec.MFechaHora = DateTime.Now;
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

    }
}