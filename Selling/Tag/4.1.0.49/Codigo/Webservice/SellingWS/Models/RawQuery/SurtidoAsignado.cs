using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingWS.Models
{
    public class SurtidoAsignado
    {
        public int TipoDocumento { get; set; }
        public string DOCClave { get; set; }
        public int? Periodo { get; set; }
        public int? Mes { get; set; }
        public int? Folio { get; set; }
        public int? Prioridad { get; set; }
        public string Stage { get; set; }//UbicacionStage
        public string StageClave { get; set; }//UBCClaveStage
        public int? Estado { get; set; }
        public IEnumerable<SurtidoAsignadoDetalle> detalles { get; set; }
    }
}