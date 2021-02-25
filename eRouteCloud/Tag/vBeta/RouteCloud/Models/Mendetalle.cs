using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Mendetalle
    {
        public string Menclave { get; set; }
        public string MedtipoLenguaje { get; set; }
        public string Descripcion { get; set; }
        public string MusuarioId { get; set; }
        public DateTime MfechaHora { get; set; }

        public virtual Mensaje MenclaveNavigation { get; set; }
    }
}
