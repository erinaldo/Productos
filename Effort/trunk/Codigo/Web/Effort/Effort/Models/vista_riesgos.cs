using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Effort.Models
{
    public class vista_riesgos
    {
        /* <td> @item.idRiesgos</td>
                   <td>@item.nombreProyecto</td>
                   <td>@item.riesgoDesc</td>
                   <td>@item.estadoDesc</td>*/
        public int idRiesgos { get; set; }

        public string nombreProyecto { get; set; }

        public string riesgoDesc { get; set; }

        public string estadoDesc { get; set; }
    }
}