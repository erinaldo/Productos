using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;
using System.Web.Script.Serialization;

namespace eRoute.Controllers.API
{
    public class MensajeController : ApiController
    {

        [HttpGet]
        [ActionName("ObtenerMensajes")]
        public IHttpActionResult ObtenerMensajes()
        {
            RouteEntities db = new RouteEntities();
            var mensajes = (from mensaje in db.Mensaje
                            join tipomsg in db.VAVDescripcion on mensaje.TipoMensaje equals tipomsg.VAVClave
                            join tipoapp in db.VAVDescripcion on mensaje.TipoAplicacion.ToString() equals tipoapp.VAVClave
                            join tipopro in db.VAVDescripcion on mensaje.TipoProyecto.ToString() equals tipopro.VAVClave
                            where tipomsg.VARCodigo == "BMENSAJE" && tipomsg.VADTipoLenguaje == "EM"
                               && tipoapp.VARCodigo == "BMENAPL" && tipoapp.VADTipoLenguaje == "EM"
                               && tipopro.VARCodigo == "BPROYECT" && tipopro.VADTipoLenguaje == "EM"
                            select new { mensaje.MENClave, TipoMensaje = tipomsg.Descripcion, TipoAplicacion = tipoapp.Descripcion, TipoProyecto = tipopro.Descripcion }
                                      ).ToList();
                                     
            return Json(mensajes);
        }

        [HttpGet]
        [ActionName("ValidarClaveUnica")]
        public IHttpActionResult ValidarClaveUnica(string MENClave)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.Mensaje.ToList().Exists(x => x.MENClave == MENClave));
        }

        [HttpGet]
        [ActionName("ObtenerMensaje")]
        public IHttpActionResult ObtenerMensaje(string MENClave)
        {
            RouteEntities db = new RouteEntities();
            var msg = (from mensaje in db.Mensaje
                       where mensaje.MENClave == MENClave
                       select new { mensaje.MENClave, mensaje.TipoMensaje, TipoAplicacion = mensaje.TipoAplicacion.ToString(), TipoProyecto = mensaje.TipoProyecto.ToString() });

            if (msg.ToList().Count > 0)
                return Json(msg.ToList()[0]);
            else
                return null;
        }

        [HttpGet]
        [ActionName("ObtenerDetalle")]
        public IHttpActionResult ObtenerDetalle(string MENClave)
        {
            RouteEntities db = new RouteEntities();

            string lenguaje = (from config in db.CONHist
                            orderby config.CONHistFechaInicio descending
                            select config.TipoLenguaje).Take(1).ToList()[0];

            
            var detalles = (from mensaje in db.Mensaje
                            join mendetalle in db.MENDetalle on mensaje.MENClave equals mendetalle.MENClave                                                        
                            where mensaje.MENClave == MENClave
                            select new { mendetalle.MEDTipoLenguaje, mendetalle.Descripcion }
                                     ).ToList();

            if (detalles.Count == 0)
            {
                detalles.Add(new { MEDTipoLenguaje = lenguaje, Descripcion = "" });
            }

            return Json(detalles);
        }

        [HttpGet]
        [ActionName("ObtenerDescripcion")]
        public IHttpActionResult ObtenerDescripcion(string MENClave, string MEDTipoLenguaje)
        {
            try
            {
                RouteEntities db = new RouteEntities();
                return Json(db.MENDetalle.First(x => x.MENClave == MENClave && x.MEDTipoLenguaje == MEDTipoLenguaje).Descripcion);
            }
            catch (Exception)
            {
                return Json("No se encontró el mensaje " + MENClave);
            }
            
        }

        [HttpPost]
        public bool Grabar(Mensaje msg)
        {
            RouteEntities db = new RouteEntities();
            if (msg != null)
            {
                bool nuevo = !db.Mensaje.ToList().Exists(x => x.MENClave == msg.MENClave);
                Mensaje mensaje;
                if (nuevo)
                {
                    mensaje = new Mensaje();
                    mensaje.MENClave = msg.MENClave;                   
                }
                else {
                    mensaje = db.Mensaje.First(x => x.MENClave == msg.MENClave);
                }

                mensaje.TipoAplicacion = msg.TipoAplicacion;
                mensaje.TipoProyecto = msg.TipoProyecto;
                mensaje.TipoMensaje = msg.TipoMensaje;
                mensaje.MFechaHora = DateTime.Now;
                mensaje.MUsuarioId = msg.MUsuarioId;

                if (nuevo)
                {
                    foreach (MENDetalle det in msg.MENDetalle)
                    {
                        MENDetalle detalle = new MENDetalle();
                        detalle.MENClave = mensaje.MENClave;
                        detalle.MEDTipoLenguaje = det.MEDTipoLenguaje;
                        detalle.Descripcion = det.Descripcion;
                        detalle.MFechaHora = DateTime.Now;
                        detalle.MUsuarioId = msg.MUsuarioId;
                        mensaje.MENDetalle.Add(detalle);
                    }

                    db.Mensaje.Add(mensaje);
                }
                else
                {                    
                    List<string> eliminar = new List<string>();
                    foreach (MENDetalle detalle in mensaje.MENDetalle)
                    {
                        if (!msg.MENDetalle.ToList().Exists(x => x.MEDTipoLenguaje == detalle.MEDTipoLenguaje))
                        {
                            eliminar.Add(detalle.MEDTipoLenguaje);
                        }
                    }                    
                    foreach (string lenguaje in eliminar) {
                        mensaje.MENDetalle.Remove(mensaje.MENDetalle.First(x => x.MEDTipoLenguaje == lenguaje));                        
                    }

                    foreach (MENDetalle det in msg.MENDetalle)
                    {
                        if (mensaje.MENDetalle.ToList().Exists(x => x.MEDTipoLenguaje == det.MEDTipoLenguaje))
                        {
                            mensaje.MENDetalle.First(x => x.MEDTipoLenguaje == det.MEDTipoLenguaje).Descripcion = det.Descripcion;
                            mensaje.MENDetalle.First(x => x.MEDTipoLenguaje == det.MEDTipoLenguaje).MFechaHora = DateTime.Now;
                            mensaje.MENDetalle.First(x => x.MEDTipoLenguaje == det.MEDTipoLenguaje).MUsuarioId = msg.MUsuarioId;
                        }
                        else
                        {
                            MENDetalle detalle = new MENDetalle();
                            detalle.MENClave = mensaje.MENClave;
                            detalle.MEDTipoLenguaje = det.MEDTipoLenguaje;
                            detalle.Descripcion = det.Descripcion;
                            detalle.MFechaHora = DateTime.Now;
                            detalle.MUsuarioId = msg.MUsuarioId;
                            mensaje.MENDetalle.Add(detalle);
                        }
                    }
                }
                
                db.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [ActionName("Eliminar")]
        public IHttpActionResult Eliminar(string MENClave) {
            RouteEntities db = new RouteEntities();
            try
            {
                db.MENDetalle.RemoveRange(db.MENDetalle.ToList().FindAll(x => x.MENClave == MENClave));
                db.Mensaje.Remove(db.Mensaje.First(x => x.MENClave == MENClave));
                db.SaveChanges();
                return Json(true);
            }
            catch (Exception) {
                return Json(false);
            }
        }
       
        [HttpGet]
        [ActionName("GenerarDiccionario")]
        public IHttpActionResult GenerarDiccionario()
        {
            try
            {
                RouteEntities db = new RouteEntities();
                List<VARValor> lenguajes = db.VARValor.ToList().FindAll(x => x.VARCodigo == "BLENGUA");

                foreach (VARValor lenguaje in lenguajes) {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    //revisar los tipos de proyectos

                    var descripciones = (from men in db.Mensaje
                                        join det in db.MENDetalle on men.MENClave equals det.MENClave
                                        where (men.TipoAplicacion == 1 || men.TipoAplicacion == 3) && det.MEDTipoLenguaje == lenguaje.VAVClave
                                        select det).ToList();

                    foreach (MENDetalle det in descripciones)
                    {
                        dictionary.Add(det.MENClave, det.Descripcion);
                    }

                    string path = ConfigurationManager.AppSettings.Get("pathDiccionario");
                    string file = path + @"\Translation_" + lenguaje.VAVClave + ".json";
                    string json = js.Serialize(dictionary);
                    System.IO.File.WriteAllText(file, json);
                }
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
            }            
        }

    }
}
