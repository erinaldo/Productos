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
    public class CamionesController : ApiController
    {
        RouteEntities db = new RouteEntities();

        //Obtener
        [HttpGet]
        [ActionName("ObtenerCamiones")]
        public IHttpActionResult ObtenerCamiones(string usu)
        {
            var valter = (from Cam in db.Camion
                          join Vd in db.VAVDescripcion on Cam.TipoEstado.ToString() equals Vd.VAVClave
                          where Vd.VARCodigo == "EDOREG" && Vd.VADTipoLenguaje == "EM"
                          from alma in db.Almacen
                          .Where(c => c.AlmacenID.Equals(Cam.AlmacenIDCEDI))
                          .DefaultIfEmpty()//Funciona cono left join
                          from AL in db.Almacen
                          .Where(d => Cam.AlmacenId.Equals(d.AlmacenID))
                          .DefaultIfEmpty()
                          where (

                               from ua in db.UsuarioAlmacen
                               join a in db.Almacen on ua.AlmacenId equals a.AlmacenID
                               where ua.USUId == usu
                               select ua.AlmacenId




                            ).Contains(Cam.AlmacenIDCEDI) || (Cam.AlmacenIDCEDI.Equals(""))
                          orderby Cam.Placa ascending
                          select new
                          {
                              Cam.Placa,
                              Cam.Clave,
                              Cam.Descripcion,
                              Kilogramos = Cam.CapacidadKg,
                              Volumen = Cam.Cajas,
                              Estado = Vd.Descripcion

                          }
                          
                          ).ToList();

            return Json(valter);
        }
        //ObtenerCentrosDeDistribucion
        [HttpGet]
        [ActionName("ObtCentroDistribucion")]
        public IHttpActionResult ObtCentroDistribucion()
        {
            var lista = new List<cAlmacen>();

            var btipouso = (
                from x in db.Almacen
                where x.Tipo.Equals("1") && x.TipoEstado == 1
                select new cAlmacen { AlmacenID = x.AlmacenID, NombreCompuesto = x.Clave + " - " + x.Nombre });
            return Json(btipouso);

        }

        //Validar Clave Camion 
        [HttpGet]
        [ActionName("ValidarCamionClave")]
        public IHttpActionResult ValidarCamionClave(string Placa)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.Camion.ToList().Exists(x => x.Placa == Placa));
        }

        //Guardando Camion
        [HttpPost]
        public bool Grabar(Camion camiones) //valor = msg
        {

            bool nuevo = !db.Camion.ToList().Exists(x => x.Placa == camiones.Placa);
            Camion cam; 
            if (nuevo)
            {
                cam = new Camion();
                cam.Placa = camiones.Placa;
            }
            else
            {
                cam = db.Camion.ToList().First(x => x.Placa == camiones.Placa);//primer resultado con la clave

            }


            cam.Placa = camiones.Placa;
            cam.Clave = camiones.Clave;
            cam.Descripcion = camiones.Descripcion;
            cam.CapacidadKg = camiones.CapacidadKg;
            cam.Cajas = camiones.Cajas;
            cam.TipoEstado = camiones.TipoEstado;
            cam.AlmacenIDCEDI = camiones.AlmacenIDCEDI;
            cam.AlmacenId = camiones.AlmacenId;
            cam.TipoCamion = camiones.TipoCamion;
            cam.MFechaHora = DateTime.Now;
            cam.MUsuarioID = camiones.MUsuarioID;

            if (nuevo)
            {
                db.Camion.Add(cam);
            }
            else
            {//eliminar

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
            }
            return true;


        }

        //Mandar y Editar
        [HttpGet]
        [ActionName("ObtenerValorCamion")]
        public IHttpActionResult ObtenerValorCamion(string Placa)
        {
            //var valores = db.VAVDescripcion.ToList().FindAll(x => x.VARValor.VARCodigo == sVARCodigo && x.VADTipoLenguaje == "EM");
            var valores = (from camion in db.Camion
                           where camion.Placa == Placa
                           select new { camion.Placa, TipoEstado = camion.TipoEstado.ToString(), camion.Clave, camion.AlmacenIDCEDI, camion.Descripcion, TipoCamion = camion.TipoCamion.ToString(), camion.CapacidadKg, camion.Cajas, camion.AlmacenId }).ToList();

            return Json(valores);
        }

    }
}