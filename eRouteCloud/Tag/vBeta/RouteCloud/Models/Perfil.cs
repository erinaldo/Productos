using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            IntPer = new HashSet<IntPer>();
            Usuario = new HashSet<Usuario>();
        }

        public string Perclave { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string MusuarioId { get; set; }
        public DateTime MfechaHora { get; set; }

        public virtual ICollection<IntPer> IntPer { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
