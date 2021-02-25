using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PREMEG.Acceso
{
    public interface IGenerarReporte
    {
        void PoblarTabla(DataTable tabla);
        string Filtro { get; set; }
        void HabilitarFotos(bool Habilita);
        string Titulo { get; set; }
    }
}
