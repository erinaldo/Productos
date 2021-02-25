using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoute.Models
{

    public class cRutaDisponible
    {
        public string RUTClave { get; set; }
        public string Descripcion { get; set; }
        public short Tipo { get; set; }
        public short TipoEstado { get; set; }
        public bool Inventario { get; set; }
        public short FolioClienteNvo { get; set; }
        public string AlmacenID { get; set; }
        public string CAMPlaca { get; set; }
        public string MUsuarioID { get; set; }

    }

}