//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SellingWS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConteoDetalle
    {
        public string CNDClave { get; set; }
        public string CONClave { get; set; }
        public string UBCClave { get; set; }
        public string PROClave { get; set; }
        public Nullable<decimal> Fisica { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
    
        public virtual Conteo Conteo { get; set; }
    }
}
