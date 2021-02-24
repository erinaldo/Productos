using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Effort.Models.Reportes
{
    public class TareasPorEquipo
    {
        //public string idProyecto { get; set; }
        public string nombreEquipo { get; set; }
        public int tareasEnCurso { get; set; }
        public int tareasPendientes { get; set; }
        public int tareasCompletadas { get; set; }
        public int tareasCanceladas { get; set; }
   
    }
}