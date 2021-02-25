using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PREMEG.Util
{
    [Serializable]
    public class objCombo
    {
        private string clave;
        private string texto;

        public string Clave {
            get { return clave; }
            set { this.clave = value; } 
        }

        public string Texto
        {
            get { return texto ; }
            set { this.texto = value; }
        }

        public string ClaveSucursal { get; set; }
    }
}
