using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PREMEG.Acceso
{
    public interface IAccesoSistema
    {
        string Usuario { get; set; }
        string Contrasenia { get; set; }
        void MensajeError(string error);
    }
}
