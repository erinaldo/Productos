using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Vavdescripcion
    {
        public string Varcodigo { get; set; }
        public string Vavclave { get; set; }
        public string VadtipoLenguaje { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionSat { get; set; }
        public DateTime MfechaHora { get; set; }
        public string MusuarioId { get; set; }

        public virtual Varvalor Va { get; set; }
    }
}
