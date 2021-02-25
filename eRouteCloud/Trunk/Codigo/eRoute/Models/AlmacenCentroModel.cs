using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoute.Models
{

        public class cAlmacen
        {
            public string AlmacenID { get; set; }
            public string Clave { get; set; }
            public string Nombre { get; set; }
            public string NombreCompuesto { get; set; }
            public string Domicilio { get; set; }
            public string Telefono { get; set; }
            public string Tipo { get; set; }
            public string TipoEstado { get; set; }
            public string CodigoBarras { get; set; }
            public bool Existe { get; set; }

    }


}