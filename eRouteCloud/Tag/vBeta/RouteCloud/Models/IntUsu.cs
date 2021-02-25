using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class IntUsu
    {
        public string Actid { get; set; }
        public short InttipoInterfaz { get; set; }
        public string Usuid { get; set; }
        public string Modid { get; set; }
        public string Permiso { get; set; }
        public int TipoVisible { get; set; }
        public int Secuencia { get; set; }
        public DateTime MfechaHora { get; set; }
        public string MusuarioId { get; set; }

        public virtual Interfaz Interfaz { get; set; }
        public virtual Modulo Mod { get; set; }
        public virtual Usuario Usu { get; set; }
    }
}
