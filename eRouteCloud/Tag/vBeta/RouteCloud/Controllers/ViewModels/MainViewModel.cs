using System.Collections.Generic;

namespace RouteCloud.Controllers.ViewModels
{
    public class MainViewModel
    {
        public class ViewModulo
        {
            public string MODId { get; set; }
            public string Clave { get; set; }
            public string Nombre { get; set; }
            public int Secuencia { get; set; }
            public int TipoInterfaz { get; set; }
            public List<ViewActividad> Actividades { get; set; }
        }

        public class ViewActividad
        {
            public string ACTId { get; set; }
            public string Nombre { get; set; }
            public string Permiso { get; set; }
            public string PermisoA { get; set; }
            public int Secuencia { get; set; }
            public int TipoActividad { get; set; }
            public bool Create { get; set; }
            public bool Read { get; set; }
            public bool Update { get; set; }
            public bool Delete { get; set; }
            public bool Execute { get; set; }
            public bool Others { get; set; }
            public bool Print { get; set; }
            public bool Sign { get; set; }
            public bool PERAct { get; set; }
            public bool Asignada { get; set; }
        }

        public class ViewInt
        {
            public string ACTId { get; set; }
            public string Permiso { get; set; }
            public int Secuencia { get; set; }
            public string Valor { get; set; }
            public short? Estado { get; set; }
            public string Nombre { get; set; }
            public short TipoActividad { get; set; }
        }
    }
}
