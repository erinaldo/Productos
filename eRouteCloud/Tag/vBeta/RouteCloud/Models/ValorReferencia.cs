using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class ValorReferencia
    {
        public ValorReferencia()
        {
            Varvalor = new HashSet<Varvalor>();
        }

        public string Varcodigo { get; set; }
        public string Descripcion { get; set; }
        public string TipoDato { get; set; }
        public short TipoAplicacion { get; set; }
        public byte TipoNulo { get; set; }
        public byte TipoModificable { get; set; }
        public string MusuarioId { get; set; }
        public DateTime MfechaHora { get; set; }

        public virtual ICollection<Varvalor> Varvalor { get; set; }
    }
}
