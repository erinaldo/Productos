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
    public class MDBMensajeController : ApiController
    {
        RouteEntities db = new RouteEntities();
      
        [HttpGet]
        [ActionName("ObtenerSiguienteNumero")]
        public int ObtenerSiguienteNumero(short MDBMensajeTipo)
        {
            int siguiente = 1;
            List<MDBMensaje> msgs = db.MDBMensaje.Where(x => x.MDBMensajeTipo == MDBMensajeTipo).OrderByDescending(x => x.Numero).ToList();
            if (msgs.Count > 0)
                siguiente = msgs[0].Numero + 1;

            return siguiente;
        }

        [HttpGet]
        [ActionName("ObtenerModuloMensaje")]
        public IHttpActionResult ObtenerModuloMensaje(string MDBMensajeID)
        {
            RouteEntities db = new RouteEntities();

            var modulos = (from mdt in db.ModuloTerm
                           join vav in db.VAVDescripcion on new { VARCodigo = "TINDMOD", VAVClave = mdt.TipoIndice.ToString(), VADTipoLenguaje = "EM" } equals new { VARCodigo = vav.VARCodigo, VAVClave = vav.VAVClave, VADTipoLenguaje = vav.VADTipoLenguaje }
                           join mdm in db.ModuloMensaje on new { MDBMensajeID = MDBMensajeID, TipoIndice = mdt.TipoIndice } equals new { MDBMensajeID = mdm.MDBMensajeID, TipoIndice = mdm.TipoIndice } into left
                           from mdm in left.DefaultIfEmpty()
                           where !mdt.Baja && mdt.TipoEstado == 1 && mdt.Tipo == 1
                           select new
                           {
                               Seleccionado = (mdm.MDBMensajeID != null ? true : false),
                               mdt.TipoIndice,
                               Nombre = vav.Descripcion
                           }).ToList();

            var distintos = modulos.GroupBy(x => x.TipoIndice).Select(x => x.FirstOrDefault()).ToList();                          

            return Json(distintos);
        }

        [HttpPost]
        public string Grabar(MDBMensaje msg)
        {
            RouteEntities db = new RouteEntities();
            if (msg != null)
            {
                bool nuevo = msg.MDBMensajeID == "";
                MDBMensaje mensaje;
                if (nuevo)
                {
                    mensaje = new MDBMensaje();
                    mensaje.MDBMensajeID = Guid.NewGuid().ToString().Substring(0, 16);
                }
                else
                {
                    mensaje = db.MDBMensaje.First(x => x.MDBMensajeID == msg.MDBMensajeID);
                }

                mensaje.MDBMensajeTipo = msg.MDBMensajeTipo;
                mensaje.Numero = msg.Numero;
                mensaje.Asunto = msg.Asunto;
                mensaje.Descripcion = msg.Descripcion;
                mensaje.TipoEstado = msg.TipoEstado;
                mensaje.MFechaHora = DateTime.Now;
                mensaje.MUsuarioID = msg.MUsuarioID;

                if (nuevo)
                {
                    foreach (ModuloMensaje mme in msg.ModuloMensaje) {
                        if (mme.Seleccionado)
                        {
                            ModuloMensaje nmme = new ModuloMensaje();
                            nmme.MDBMensajeID = mensaje.MDBMensajeID;
                            nmme.TipoIndice = mme.TipoIndice;
                            nmme.MFechaHora = DateTime.Now;
                            nmme.MUsuarioID = msg.MUsuarioID;
                            db.ModuloMensaje.Add(nmme);
                        }
                    }
                }
                else
                {
                    List<short> borrar = new List<short>();
                    if (msg.ModuloMensaje.ToList().Count > 0)
                    {
                        foreach (ModuloMensaje mme in mensaje.ModuloMensaje)
                        {
                            if (!msg.ModuloMensaje.ToList().Exists(x => x.TipoIndice == mme.TipoIndice && x.Seleccionado))
                                borrar.Add(mme.TipoIndice);
                        }
                    }
                    foreach (short llave in borrar)
                    {                        
                        db.ModuloMensaje.Remove(mensaje.ModuloMensaje.First(x => x.TipoIndice == llave));
                    }
                    foreach (ModuloMensaje mme in msg.ModuloMensaje)
                    {
                        if (mme.Seleccionado)
                        {
                            if (!mensaje.ModuloMensaje.ToList().Exists(x => x.TipoIndice == mme.TipoIndice))
                            {
                                ModuloMensaje nmme = new ModuloMensaje();
                                nmme.MDBMensajeID = mensaje.MDBMensajeID;
                                nmme.TipoIndice = mme.TipoIndice;
                                nmme.MFechaHora = DateTime.Now;
                                nmme.MUsuarioID = msg.MUsuarioID;
                                db.ModuloMensaje.Add(nmme);
                            }
                        }
                    }
                }

                if (nuevo)
                    db.MDBMensaje.Add(mensaje);

                db.SaveChanges();
                return mensaje.MDBMensajeID;

            }
            else
            {
                return "";
            }
        }

        [HttpGet]
        [ActionName("ObtenerMDBMensaje")]
        public IHttpActionResult ObtenerMDBMensaje(string MDBMensajeID)
        {
            RouteEntities db = new RouteEntities();
            var mensaje = (from msg in db.MDBMensaje
                        where msg.MDBMensajeID == MDBMensajeID
                        join vad1 in db.VAVDescripcion on msg.TipoEstado.ToString() equals vad1.VAVClave
                        join vad2 in db.VAVDescripcion on msg.MDBMensajeTipo.ToString() equals vad2.VAVClave
                        where msg.MDBMensajeID == MDBMensajeID && vad1.VARCodigo == "EDOREG" && vad1.VADTipoLenguaje == "EM" && vad2.VARCodigo == "MDBMENT" && vad2.VADTipoLenguaje == "EM"
                        select new
                        {
                            msg.MDBMensajeID,
                            msg.Numero,
                            msg.Asunto,
                            TipoMensaje = vad2.Descripcion,
                            msg.Descripcion,
                            TipoEstado = vad1.Descripcion
                        }).ToList();            

            if (mensaje.ToList().Count > 0) {
                var msg = mensaje.ToList()[0];
                var modulos = (from mod in db.ModuloMensaje
                               join vav in db.VAVDescripcion on new { VARCodigo = "TINDMOD", VAVClave = mod.TipoIndice.ToString(), VADTipoLenguaje = "EM" } equals new { VARCodigo = vav.VARCodigo, VAVClave = vav.VAVClave, VADTipoLenguaje = vav.VADTipoLenguaje }
                               //join mdt in db.ModuloTerm on mod.TipoIndice equals mdt.TipoIndice
                               where mod.MDBMensajeID == MDBMensajeID
                               //orderby mdt.Tipo
                               select new { Modulo = vav.Descripcion }).ToList();

                //List<ModulosMensaje> modulosMen = new List<ModulosMensaje>();
                //string id = "";
                string sModulos = "";
                foreach (var mod in modulos)
                    sModulos += mod.Modulo + ", ";

                if (sModulos.Length > 0)
                    sModulos = sModulos.Substring(0, sModulos.Length - 2);

                VistaClienteMensaje cteMensaje = new VistaClienteMensaje();
                cteMensaje.MDBMensajeID = msg.MDBMensajeID;
                cteMensaje.Numero = msg.Numero;
                cteMensaje.Asunto = msg.Asunto;
                cteMensaje.TipoMensaje = msg.TipoMensaje;
                cteMensaje.Descripcion = msg.Descripcion;
                cteMensaje.TipoEstado = msg.TipoEstado;
                cteMensaje.Modulos = sModulos;

                return Json(cteMensaje);

            }
            else
                return null;
        }

        [HttpGet]
        [ActionName("ObtenerMDBMensajesCliente")]
        public IHttpActionResult ObtenerMDBMensajesCliente()
        {
            RouteEntities db = new RouteEntities();

            var modulos = (from mdb in db.MDBMensaje
                           join mod in db.ModuloMensaje on mdb.MDBMensajeID equals mod.MDBMensajeID
                           //join mdt in db.ModuloTerm on mod.TipoIndice equals mdt.TipoIndice
                           join vav in db.VAVDescripcion on new { VARCodigo = "TINDMOD", VAVClave = mod.TipoIndice.ToString(), VADTipoLenguaje = "EM" } equals new { VARCodigo = vav.VARCodigo, VAVClave = vav.VAVClave, VADTipoLenguaje = vav.VADTipoLenguaje }
                           //where mdt.Tipo == 1
                           orderby mdb.MDBMensajeID
                           select new { mdb.MDBMensajeID, Modulo = vav.Descripcion }).ToList();

            List<ModulosMensaje> modulosMen = new List<ModulosMensaje>();
            string id = "";
            string mods = "";
            foreach (var mod in modulos)
            {
                if (id != "" && id != mod.MDBMensajeID)
                {
                    mods = mods.Substring(0, mods.Length - 2);
                    modulosMen.Add(new ModulosMensaje { MDBMensajeID = id, Modulos = mods });
                    mods = "";
                }
                id = mod.MDBMensajeID;
                mods += mod.Modulo + ", ";
            }
            if (mods.Length > 0)
            {
                mods = mods.Substring(0, mods.Length - 2);
                modulosMen.Add(new ModulosMensaje { MDBMensajeID = id, Modulos = mods });
            }

            var mensajes = (from mdb in db.MDBMensaje
                            join vad1 in db.VAVDescripcion on mdb.TipoEstado.ToString() equals vad1.VAVClave
                            join vad2 in db.VAVDescripcion on mdb.MDBMensajeTipo.ToString() equals vad2.VAVClave
                            where mdb.TipoEstado == 1 && (mdb.MDBMensajeTipo == 2 || mdb.MDBMensajeTipo == 3) 
                            && vad1.VARCodigo == "EDOREG" && vad1.VADTipoLenguaje == "EM" && vad2.VARCodigo == "MDBMENT" && vad2.VADTipoLenguaje == "EM"                            
                            select new
                            {
                                mdb.MDBMensajeID,
                                mdb.Numero,
                                mdb.Asunto,
                                TipoMensaje = vad2.Descripcion,
                                mdb.Descripcion,
                                TipoEstado = vad1.Descripcion
                            }).ToList();


            List<VistaClienteMensaje> cteMensaje = new List<VistaClienteMensaje>();
            foreach (var msg in mensajes)
            {
                string sModulos = "";

                if (modulosMen.Exists(x => x.MDBMensajeID == msg.MDBMensajeID))
                    sModulos = modulosMen.Find(x => x.MDBMensajeID == msg.MDBMensajeID).Modulos;

                cteMensaje.Add(new Models.VistaClienteMensaje
                {
                    Seleccionado = false,
                    MDBMensajeID = msg.MDBMensajeID,
                    Numero = msg.Numero,
                    Asunto = msg.Asunto,
                    TipoMensaje = msg.TipoMensaje,
                    Descripcion = msg.Descripcion,
                    TipoEstado = msg.TipoEstado,
                    Modulos = sModulos
                });
            }

            return Json(cteMensaje);
        }
    }

}