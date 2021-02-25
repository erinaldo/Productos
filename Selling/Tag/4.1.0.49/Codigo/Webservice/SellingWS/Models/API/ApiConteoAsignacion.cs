using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingWS.Models.API
{
    public class ApiConteoAsignacion
    {
        public string USRClave { get; set; }
        public string CONClave { get; set; }
        public string ALMClave { get; set; }
        public string Almacen { get; set; }
        public string Area { get; set; }
        public string Estructura { get; set; }
        public string Nivel { get; set; }
        public int? Columna { get; set; }
        public string UBCClave { get; set; }
        public string Ubicacion { get; set; }
        public int? Estado { get; set; }
    }
}