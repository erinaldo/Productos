using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Effort.Models
{
    public class CustomProyecto
    {
    
        public string idProyecto { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public Nullable<int> duracion { get; set; }
        public Nullable<int> presupuesto_hrs { get; set; }
        public Nullable<decimal> presupuesto_precio { get; set; }
        public string administrador_proyecto { get; set; }
        public string EstadoProyecto { get; set; }
    
    
    }
}