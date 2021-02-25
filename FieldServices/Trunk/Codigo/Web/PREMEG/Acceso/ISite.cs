using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PREMEG.Acceso
{
    public interface ISite
    {
        string ClaveUsuario { get; }
        string ClavePerfil { get; }
        void PresentaActividades(SeleccionarActividades.ListaMenu[] lista);
    }
}
