using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            IntUsu = new HashSet<IntUsu>();
        }

        public string Usuid { get; set; }
        public string Perclave { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ClaveAcceso { get; set; }
        public int DiasLimite { get; set; }
        public DateTime FechaMod { get; set; }
        public short Tipo { get; set; }
        public bool Activo { get; set; }
        public string AlmacenId { get; set; }
        public string PoliticaId { get; set; }
        public DateTime MfechaHora { get; set; }
        public string MusuarioId { get; set; }

        public virtual Perfil PerclaveNavigation { get; set; }
        public virtual ICollection<IntUsu> IntUsu { get; set; }
    }
}
