using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Interfaz
    {
        public Interfaz()
        {
            IntPer = new HashSet<IntPer>();
            IntUsu = new HashSet<IntUsu>();
        }

        public string Actid { get; set; }
        public short InttipoInterfaz { get; set; }
        public string Modid { get; set; }
        public short Tipo { get; set; }
        public string Componente { get; set; }
        public string Clase { get; set; }
        public string Procedimiento { get; set; }
        public string Permiso { get; set; }
        public int Secuencia { get; set; }
        public string FolioId { get; set; }
        public string ModuloMovDetalleClave { get; set; }
        public DateTime MfechaHora { get; set; }
        public string MusuarioId { get; set; }

        public virtual Actividad Act { get; set; }
        public virtual Modulo Mod { get; set; }
        public virtual ICollection<IntPer> IntPer { get; set; }
        public virtual ICollection<IntUsu> IntUsu { get; set; }
    }
}
