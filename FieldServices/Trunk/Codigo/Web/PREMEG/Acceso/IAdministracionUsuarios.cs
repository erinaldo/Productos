using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public interface IAdministracionUsuarios
    {
        void PresentaListaUsuarios(Usuario[] usuarios);
        void CargarCatalogos(object perfiles, object valores, object sucursales, object cuadrillas);
    }
}
