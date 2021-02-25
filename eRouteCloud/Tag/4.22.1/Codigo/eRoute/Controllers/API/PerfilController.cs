using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;

namespace eRoute.Controllers.API
{
    public class PerfilController : ApiController
    {
        
        [HttpGet]
        [ActionName("ObtenerPerfiles")]
        public IHttpActionResult ObtenerPerfiles()
        {
            RouteEntities db = new RouteEntities();
            var perfiles = (from perfil in db.Perfil
                            select new { perfil.PERClave, perfil.Descripcion, perfil.Activo }).ToList();

            return Json(perfiles);
        }

        [HttpGet]
        [ActionName("ObtenerModulos")]
        public IHttpActionResult ObtenerModulos(string PERClave, int TipoInterfaz, bool Disponibles)
        {
            string MEDTipoLenguaje = "EM";

            RouteEntities db = new RouteEntities();
            //var lstModulos = (from a in db.Actividad
            //                  join i in db.Interfaz on a.ACTId equals i.ACTId
            //                  join m in db.Modulo on i.MODId equals m.MODId
            //                  join p in db.IntPer on new { ACTId = a.ACTId, PERClave = PERClave } equals new { ACTId = p.ACTId, PERClave = p.PERClave } into pl
            //                  from p in pl.DefaultIfEmpty()

            //                  where m.TipoInterfaz == TipoInterfaz && p == null
            //                  select new { m.MODId }).ToList().Distinct();

            //List<string> lstMod = new List<string>();
            //foreach (var mod in lstModulos) {
            //    lstMod.Add(mod.MODId);
            //}

            var modulos = (from m in db.Modulo
                           join msg in db.MENDetalle on new { MENClave = m.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = msg.MENClave, MEDTipoLenguaje = msg.MEDTipoLenguaje }
                           //where m.TipoInterfaz == TipoInterfaz
                           orderby m.TipoInterfaz, m.Secuencia
                           select new cModulo { MODId = m.MODId, Clave = m.MENNombreClave, Nombre = msg.Descripcion, Imagen = m.Imagen, TipoInterfaz = m.TipoInterfaz }).ToList();

            foreach (cModulo oModulo in modulos)
            {
                oModulo.SetImagenBase64();
                if (Disponibles)
                    ObtenerActividadesDisponibles(oModulo, PERClave, MEDTipoLenguaje);
                else
                    ObtenerActividadesAsignadas(oModulo, PERClave, MEDTipoLenguaje);
            }

            return Json(modulos);
        }

        public void ObtenerActividadesDisponibles(cModulo Modulo, string PERClave, string MEDTipoLenguaje) {
         
            RouteEntities db = new RouteEntities();
            var valoresRW = db.VARValor.Where(x => x.VARCodigo == "REPORTEW" && x.Estado == 1).ToList();
            var valoresMW = db.VARValor.Where(x => x.VARCodigo == "MAPAW" && x.Estado == 1).ToList();

            var actividades = (from a in db.Actividad
                               join i in db.Interfaz on a.ACTId equals i.ACTId
                               join m in db.MENDetalle on new { MENClave = a.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = m.MENClave, MEDTipoLenguaje = m.MEDTipoLenguaje }
                               join p in db.IntPer on new { ACTId = a.ACTId, PERClave = PERClave } equals new { ACTId = p.ACTId, PERClave = p.PERClave } into pl
                               from p in pl.DefaultIfEmpty()                               
                               where i.MODId == Modulo.MODId && p == null && !a.ACTId.Equals("REPORTESWEB") && !a.ACTId.Equals("MAPASWEB")
                               orderby i.Secuencia
                               select new cActividad { ACTId = a.ACTId, Nombre = m.Descripcion, Permiso = i.Permiso, PermisoA = "" }).ToList();

            foreach (cActividad act in actividades) {
                try
                {
                    if (act.ACTId.ToUpper().StartsWith("TINDMMD"))
                    {
                        act.Nombre = db.VAVDescripcion.First(x => x.VARCodigo == "TINDMMD" && x.VAVClave == act.ACTId.ToUpper().Replace("TINDMMD", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                    }
                    else if (act.ACTId.ToUpper().StartsWith("REPORTEW"))
                    {
                        if (valoresRW.Exists(x => x.VAVClave == act.ACTId.ToUpper().Replace("REPORTEW", "")))
                            act.Nombre = act.ACTId.ToUpper().Replace("REPORTEW", "") + " - " + db.VAVDescripcion.First(x => x.VARCodigo == "REPORTEW" && x.VAVClave == act.ACTId.ToUpper().Replace("REPORTEW", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                        else
                            act.Nombre = "";
                    }
                    else if (act.ACTId.ToUpper().StartsWith("MAPAW"))
                    {
                        if (valoresMW.Exists(x => x.VAVClave == act.ACTId.ToUpper().Replace("MAPAW", "")))
                            act.Nombre = act.ACTId.ToUpper().Replace("MAPAW", "") + " - " + db.VAVDescripcion.First(x => x.VARCodigo == "MAPAW" && x.VAVClave == act.ACTId.ToUpper().Replace("MAPAW", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                        else
                            act.Nombre = "";
                    }
                }catch{ }
            }

            Modulo.Actividades = actividades.Where(x => !x.Nombre.Equals("")).ToList();
        }        

        public void ObtenerActividadesAsignadas(cModulo Modulo, string PERClave, string MEDTipoLenguaje)
        {

            RouteEntities db = new RouteEntities();
            var valoresRW = db.VARValor.Where(x => x.VARCodigo == "REPORTEW" && x.Estado == 1).ToList();
            var valoresMW = db.VARValor.Where(x => x.VARCodigo == "MAPAW" && x.Estado == 1).ToList();

            var actividades = (from a in db.Actividad
                               join z in db.Interfaz on a.ACTId equals z.ACTId
                               join i in db.IntPer on new { ACTId = a.ACTId, PERClave = PERClave } equals new { ACTId = i.ACTId, PERClave = i.PERClave }
                               join m in db.MENDetalle on new { MENClave = a.MENNombreClave, MEDTipoLenguaje = MEDTipoLenguaje } equals new { MENClave = m.MENClave, MEDTipoLenguaje = m.MEDTipoLenguaje }
                               where i.MODId == Modulo.MODId
                               orderby i.Secuencia
                               select new cActividad { ACTId = a.ACTId, Nombre = m.Descripcion, Permiso = z.Permiso, PermisoA = i.Permiso }).ToList();

            foreach (cActividad act in actividades)
            {
                act.Create = act.PermisoA.Contains("C");
                act.Read = act.PermisoA.Contains("R");
                act.Update = act.PermisoA.Contains("U");
                act.Delete = act.PermisoA.Contains("D");
                act.Execute = act.PermisoA.Contains("E");
                act.Others = act.PermisoA.Contains("O");
                act.Print = act.PermisoA.Contains("P");
                act.Sign = act.PermisoA.Contains("S");

                try
                {
                    if (act.ACTId.ToUpper().StartsWith("TINDMMD"))
                    {
                        act.Nombre = db.VAVDescripcion.First(x => x.VARCodigo == "TINDMMD" && x.VAVClave == act.ACTId.ToUpper().Replace("TINDMMD", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                    }
                    else if (act.ACTId.ToUpper().StartsWith("REPORTEW"))
                    {
                        if (valoresRW.Exists(x => x.VAVClave == act.ACTId.ToUpper().Replace("REPORTEW", "")))
                            act.Nombre = act.ACTId.ToUpper().Replace("REPORTEW", "") + " - " + db.VAVDescripcion.First(x => x.VARCodigo == "REPORTEW" && x.VAVClave == act.ACTId.ToUpper().Replace("REPORTEW", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                        else
                            act.Nombre = "";
                    }
                    else if (act.ACTId.ToUpper().StartsWith("MAPAW"))
                    {
                        if (valoresMW.Exists(x => x.VAVClave == act.ACTId.ToUpper().Replace("MAPAW", "")))
                            act.Nombre = act.ACTId.ToUpper().Replace("MAPAW", "") + " - " + db.VAVDescripcion.First(x => x.VARCodigo == "MAPAW" && x.VAVClave == act.ACTId.ToUpper().Replace("MAPAW", "") && x.VADTipoLenguaje == MEDTipoLenguaje).Descripcion;
                        else
                            act.Nombre = "";
                    }
                }
                catch { }
            }

            Modulo.Actividades = actividades.Where(x => !x.Nombre.Equals("")).ToList();
        }

        [HttpGet]
        [ActionName("ValidarClaveUnica")]
        public IHttpActionResult ValidarClaveUnica(string PERClave)
        {
            RouteEntities db = new RouteEntities();
            return Json(db.Perfil.ToList().Exists(x => x.PERClave == PERClave));
        }

        [HttpGet]
        [ActionName("ObtenerPerfil")]
        public IHttpActionResult ObtenerPerfil(string PERClave)
        {
            RouteEntities db = new RouteEntities();
            var perf = (from perfil in db.Perfil 
                       where perfil.PERClave == PERClave
                       select new { perfil.PERClave, perfil.Descripcion, perfil.Activo });

            if (perf.ToList().Count > 0)
                return Json(perf.ToList()[0]);
            else
                return null;
        }

        [HttpPost]
        public bool Grabar(Perfil perf)
        {
            RouteEntities db = new RouteEntities();
            if (perf != null)
            {
                bool nuevo = !db.Perfil.ToList().Exists(x => x.PERClave == perf.PERClave);
                Perfil perfil;
                if (nuevo)
                {
                    perfil = new Perfil();
                    perfil.PERClave = perf.PERClave;
                }
                else
                {
                    perfil = db.Perfil.First(x => x.PERClave == perf.PERClave);
                }

                perfil.Descripcion = perf.Descripcion;
                perfil.Activo = perf.Activo;
                perfil.MFechaHora = DateTime.Now;
                perfil.MUsuarioId = perf.MUsuarioId;

                if (nuevo)
                {
                    foreach (IntPer det in perf.IntPer)
                    {
                        IntPer detalle = new IntPer();
                        detalle.PERClave = perfil.PERClave;
                        detalle.ACTId = det.ACTId;
                        detalle.INTTipoInterfaz = det.INTTipoInterfaz;
                        detalle.MODId = det.MODId;
                        detalle.Permiso = det.Permiso;
                        detalle.Secuencia = det.Secuencia;
                        detalle.MFechaHora = DateTime.Now;
                        detalle.MUsuarioId = perfil.MUsuarioId;
                        perfil.IntPer.Add(detalle);
                    }

                    db.Perfil.Add(perfil);
                }
                else
                {
                    List<string> eliminar = new List<string>();
                    foreach (IntPer det in perfil.IntPer)
                    {
                        if (!perf.IntPer.ToList().Exists(x => x.ACTId == det.ACTId))
                        {
                            eliminar.Add(det.ACTId);
                        }
                    }
                    foreach (string act in eliminar)
                    {
                        perfil.IntPer.Remove(perfil.IntPer.First(x => x.ACTId == act));
                    }

                    foreach (IntPer det in perf.IntPer)
                    {
                        if (perfil.IntPer.ToList().Exists(x => x.ACTId == det.ACTId))
                        {
                            perfil.IntPer.First(x => x.ACTId == det.ACTId).Permiso = det.Permiso;
                            perfil.IntPer.First(x => x.ACTId == det.ACTId).Secuencia = det.Secuencia;
                            perfil.IntPer.First(x => x.ACTId == det.ACTId).MFechaHora = DateTime.Now;
                            perfil.IntPer.First(x => x.ACTId == det.ACTId).MUsuarioId = perfil.MUsuarioId;
                        }
                        else
                        {
                            IntPer detalle = new IntPer();
                            detalle.PERClave = perfil.PERClave;
                            detalle.ACTId = det.ACTId;
                            detalle.INTTipoInterfaz = det.INTTipoInterfaz;
                            detalle.MODId = det.MODId;
                            detalle.Permiso = det.Permiso;
                            detalle.Secuencia = det.Secuencia;
                            detalle.MFechaHora = DateTime.Now;
                            detalle.MUsuarioId = perfil.MUsuarioId;
                            perfil.IntPer.Add(detalle);
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
    }
}
