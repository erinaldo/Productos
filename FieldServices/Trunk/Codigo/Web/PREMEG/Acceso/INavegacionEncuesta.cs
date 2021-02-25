using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public interface INavegacionEncuesta
    {
        void PresentarEncuestas(List<Encuesta> listaEncuestas);
    }
}
