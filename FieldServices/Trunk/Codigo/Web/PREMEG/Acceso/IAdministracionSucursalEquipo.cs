using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public interface IAdministracionSucursalEquipo
    {
        string ClaveSucursal { get; set; }
        List<Material> ListaMateriales { get; set; }
    }
}
