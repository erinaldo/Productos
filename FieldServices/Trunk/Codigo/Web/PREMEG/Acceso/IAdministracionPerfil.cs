using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public interface IAdministracionPerfil
    {
        string ClavePerfil { get; set; }
        string Descripcion { get; set; }
        bool Estado { get; set; }
        List<Actividad> ListaAsignadas { get; }
    }
}
