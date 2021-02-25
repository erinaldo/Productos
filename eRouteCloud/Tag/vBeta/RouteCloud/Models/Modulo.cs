using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            IntPer = new HashSet<IntPer>();
            IntUsu = new HashSet<IntUsu>();
            Interfaz = new HashSet<Interfaz>();
            InverseModid1Navigation = new HashSet<Modulo>();
        }

        public string Modid { get; set; }
        public string Modid1 { get; set; }
        public string MennombreClave { get; set; }
        public string MendescripcionClave { get; set; }
        public short TipoInterfaz { get; set; }
        public short Secuencia { get; set; }
        public byte[] Imagen { get; set; }
        public string MusuarioId { get; set; }
        public DateTime MfechaHora { get; set; }

        public virtual Mensaje MendescripcionClaveNavigation { get; set; }
        public virtual Mensaje MennombreClaveNavigation { get; set; }
        public virtual Modulo Modid1Navigation { get; set; }
        public virtual ICollection<IntPer> IntPer { get; set; }
        public virtual ICollection<IntUsu> IntUsu { get; set; }
        public virtual ICollection<Interfaz> Interfaz { get; set; }
        public virtual ICollection<Modulo> InverseModid1Navigation { get; set; }
    }
}
