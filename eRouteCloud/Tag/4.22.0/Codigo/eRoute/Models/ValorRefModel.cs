using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoute.Models
{

        public class cVARValor
        {
            public string VARCodigo { get; set; }
            public string VAVClave { get; set; }
            public string ClaveSAT { get; set; }
            public string Grupo { get; set; }
            public string Estado { get; set; }
            public bool Nuevo { get; set; }
        public List<cVAVDescripcion> VAVDescripcion { get; set; }           
        }

        public class cVAVDescripcion
        {
            public string VADTipoLenguaje { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionSAT { get; set; }
    }
}