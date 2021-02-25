using System;
using System.Collections.Generic;

namespace RouteCloud.Models
{
    public partial class Actividad
    {
        public Actividad()
        {
            Interfaz = new HashSet<Interfaz>();
        }

        public string Actid { get; set; }
        public string MennombreClave { get; set; }
        public string MendescripcionClave { get; set; }
        public byte[] Imagen { get; set; }
        public short TipoActividad { get; set; }
        public string MusuarioId { get; set; }
        public DateTime MfechaHora { get; set; }

        public virtual Mensaje MendescripcionClaveNavigation { get; set; }
        public virtual Mensaje MennombreClaveNavigation { get; set; }
        public virtual ICollection<Interfaz> Interfaz { get; set; }
    }
}
