using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Effort.Models
{
    public class vista_tarea
    {
        public int idTarea { get; set; }

        public string tituloTarea { get; set; }

        public string nombreProyecto { get; set; }

        public string estadoDesc { get; set; }

        public Nullable<double> presupuesto { get; set; }

        public Nullable<double> horas_estimadas_dia { get; set; }

        public Nullable<DateTime> fecha_inicio { get; set; }

        public Nullable<DateTime> fecha_fin { get; set; }

        public double avance { get; set; }

        public string idEquipo { get; set; }

        public string descripcion { get; set; }
    }
}