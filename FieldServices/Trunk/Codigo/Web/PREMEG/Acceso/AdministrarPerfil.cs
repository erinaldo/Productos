using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public class AdministrarPerfil
    {
        IAdministracionPerfil vista;
        public AdministrarPerfil()
        {
        }
        public AdministrarPerfil(IAdministracionPerfil Vista)
        {
            vista = Vista;
        }
        public List<Perfil> ObtenerPerfiles()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = (from per in contexto.Perfil select per).OrderBy(p => p.ClavePerfil);
                return lista.ToList();
            }
        }
        

        public List<Actividad> ObtenerActividadesActivas()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = (from act in contexto.Actividad where act.Estado select act).OrderBy(a => a.ClaveActividad);
                foreach (Actividad a in lista)
                    a.Nombre = (a.Modulo == null ? a.Nombre + " " + UtilMensaje.ObtenerMensaje("#TipoActividadMobile") : a.Nombre + " " + UtilMensaje.ObtenerMensaje("#TipoActividadWEB"));
                return lista.ToList();
            }
            
        }
        public List<Actividad> ObtenerActividadesAsignadas(string ClavePerfil)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = (from act in contexto.Actividad where act.Perfil.Any(p => p.ClavePerfil == ClavePerfil) select act);
                foreach (Actividad a in lista)
                    a.Nombre = (a.Modulo == null ? a.Nombre + " " + UtilMensaje.ObtenerMensaje("#TipoActividadMobile") : a.Nombre + " " + UtilMensaje.ObtenerMensaje("#TipoActividadWEB"));
                return lista.ToList();
            }

        }

        public void ActualizarPerfil(Perfil perfil)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                contexto.Attach(perfil);
                perfil.Estado = vista.Estado;
                perfil.Nombre = vista.Descripcion;
                List<Actividad> listaOriginal = perfil.Actividad.ToList();

                foreach (Actividad a in listaOriginal)
                    if (!vista.ListaAsignadas.Exists(act => act.ClaveActividad == a.ClaveActividad))
                        perfil.Actividad.Remove(a);


                foreach (Actividad a in vista.ListaAsignadas)
                {
                    if (!listaOriginal.Exists(act => act.ClaveActividad == a.ClaveActividad))
                    {
                        contexto.Actividad.Attach(a);
                        perfil.Actividad.Add(a);
                    }
                }
                contexto.SaveChanges();
            }
        }
        public void RegistrarPerfil(string ClavePerfil, string Nombre, bool Activo)
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                Perfil perfil = new Perfil();
                perfil.ClavePerfil = ClavePerfil;
                perfil.Estado = Activo;
                perfil.Nombre = Nombre;

                foreach (Actividad a in vista.ListaAsignadas)
                {
                    contexto.Actividad.Attach(a);
                    perfil.Actividad.Add(a);
                }
                contexto.Perfil.AddObject(perfil);
                contexto.SaveChanges();
            }
        }

        public bool ValidarDatosProporcionados(Perfil perfil, bool estado)
        {
            bool ret = true;
            if (!estado)
            {
                using (MegaCableEntities contexto = new MegaCableEntities())
                {
                    ret = !contexto.Usuario.Any(u => u.ClavePerfil == perfil.ClavePerfil);
                }
            }
            return ret;
        }
    }
}
