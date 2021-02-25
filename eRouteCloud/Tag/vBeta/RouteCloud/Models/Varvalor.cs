using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Varvalor
    {
        public Varvalor()
        {
            Vavdescripcion = new HashSet<Vavdescripcion>();
        }

        public string Varcodigo { get; set; }
        public string Vavclave { get; set; }
        public string ClaveSat { get; set; }
        public string Grupo { get; set; }
        public short Estado { get; set; }
        public DateTime MfechaHora { get; set; }
        public string MusuarioId { get; set; }

        public virtual ValorReferencia VarcodigoNavigation { get; set; }
        public virtual ICollection<Vavdescripcion> Vavdescripcion { get; set; }
    }
}
