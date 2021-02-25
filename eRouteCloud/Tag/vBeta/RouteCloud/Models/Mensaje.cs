using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Mensaje
    {
        public Mensaje()
        {
            ActividadMendescripcionClaveNavigation = new HashSet<Actividad>();
            ActividadMennombreClaveNavigation = new HashSet<Actividad>();
            Mendetalle = new HashSet<Mendetalle>();
            ModuloMendescripcionClaveNavigation = new HashSet<Modulo>();
            ModuloMennombreClaveNavigation = new HashSet<Modulo>();
        }

        public string Menclave { get; set; }
        public string TipoMensaje { get; set; }
        public short? TipoAplicacion { get; set; }
        public short TipoProyecto { get; set; }
        public string MusuarioId { get; set; }
        public DateTime MfechaHora { get; set; }

        public virtual ICollection<Actividad> ActividadMendescripcionClaveNavigation { get; set; }
        public virtual ICollection<Actividad> ActividadMennombreClaveNavigation { get; set; }
        public virtual ICollection<Mendetalle> Mendetalle { get; set; }
        public virtual ICollection<Modulo> ModuloMendescripcionClaveNavigation { get; set; }
        public virtual ICollection<Modulo> ModuloMennombreClaveNavigation { get; set; }
    }
}
