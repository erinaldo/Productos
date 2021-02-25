using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public class SeleccionarActividades
    {
        private ISite sitio;
        public SeleccionarActividades(ISite Sitio)
        {
            sitio = Sitio;
        }
        public void ObtenerActividades()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                /*var actividades = (from act in contexto.Actividad where act.Perfil.Any(p => p.ClavePerfil == sitio.ClavePerfil) && act.ClaveModulo != null select new { act.ClaveActividad, act.ClaveModulo, act.TipoIndice, ModuloNombre = act.Modulo.Nombre, act.Nombre }).OrderBy(a => a.TipoIndice);
                List<ListaMenu> lista = new List<ListaMenu>();
                foreach (var act in actividades)
                    lista.Add(new ListaMenu(act.ClaveActividad, act.ClaveModulo, act.TipoIndice, act.Nombre, act.ModuloNombre));*/
                List<ListaMenu> lista = (from act in contexto.Actividad where act.Perfil.Any(p => p.ClavePerfil == sitio.ClavePerfil) && act.ClaveModulo != null select new ListaMenu { ClaveActividad = act.ClaveActividad, ClaveModulo = act.ClaveModulo, TipoIndice = act.TipoIndice, NombreModulo = act.Modulo.Nombre, NombreActividad = act.Nombre }).OrderBy(a => a.TipoIndice).ToList();
                sitio.PresentaActividades(lista.ToArray());
            }
        }
        public class ListaMenu
        {
            public string ClaveActividad
            {
                get;
                set;
            }
            public string ClaveModulo
            {
                get;
                set;
            }
            public short TipoIndice
            {
                get;
                set;
            }
            public string NombreActividad
            {
                get;
                set;
            }
            public string NombreModulo
            {
                get;
                set;
            }
        }
        /*public class ListaMenu
        {
            public string claveActividad;
            public string claveModulo; 
            public short tipoIndice ;
            public string nombreActividad;
            public string nombreModulo;

            public ListaMenu(string claveactividad, string clavemodulo, short tipoindice, string nombreactividad, string nombremodulo)
            {
                claveActividad = claveactividad;
                claveModulo = clavemodulo;
                tipoIndice = tipoindice;
                nombreActividad = nombreactividad;
                nombreModulo = nombremodulo;
            }
            
            public string ClaveActividad {
                get { return claveActividad; }
                set { claveActividad = value; }
            }
            public string  ClaveModulo {
                get { return claveModulo; }
                set { claveModulo = value; }
            }
            public short TipoIndice {
                get { return tipoIndice; }
                set { tipoIndice = value; }
            }
            public string NombreActividad {
                get { return nombreActividad; }
                set { nombreActividad = value; }
            }
            public string NombreModulo {
                get { return nombreModulo; }
                set { nombreModulo = value; }
            }
        }*/

    }
}
