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
    
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            this.Estrategia = new HashSet<Estrategia>();
            this.prd_exist_uba = new HashSet<prd_exist_uba>();
            this.ReciboAlmacen = new HashSet<ReciboAlmacen>();
            this.ReciboAlmacenT = new HashSet<ReciboAlmacenT>();
            this.SurtidoDetalle = new HashSet<SurtidoDetalle>();
        }
    
        public string UBCClave { get; set; }
        public string Ubicacion1 { get; set; }
        public string ESTClave { get; set; }
        public string HUEClave { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> Fase { get; set; }
        public Nullable<decimal> Volumen { get; set; }
        public Nullable<bool> Baja { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
    
        public virtual ICollection<Estrategia> Estrategia { get; set; }
        public virtual Hueco Hueco { get; set; }
        public virtual ICollection<prd_exist_uba> prd_exist_uba { get; set; }
        public virtual ICollection<ReciboAlmacen> ReciboAlmacen { get; set; }
        public virtual ICollection<ReciboAlmacenT> ReciboAlmacenT { get; set; }
        public virtual ICollection<SurtidoDetalle> SurtidoDetalle { get; set; }
    }
}
