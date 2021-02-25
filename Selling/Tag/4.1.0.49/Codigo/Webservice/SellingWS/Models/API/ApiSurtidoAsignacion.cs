using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingWS.Models.API
{
    public class ApiSurtidoAsigancion
    {
        public int TipoDocumento { get; set; }
        public string DOCClave { get; set; }
        public string Cliente { get; set; }
        public string Folio { get; set; }
        public int? Prioridad { get; set; }
        public string Stage { get; set; }//UbicacionStage
        public string StageClave { get; set; }//UBCClaveStage
        public int? Estado { get; set; }
        public IEnumerable<ApiSurtidoAsignacionDetalle> detalles { get; set; }
    }
}