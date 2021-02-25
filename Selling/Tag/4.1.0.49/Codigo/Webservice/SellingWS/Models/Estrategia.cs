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
    
    public partial class Estrategia
    {
        public string Id { get; set; }
        public string PROClave { get; set; }
        public string ALMClave { get; set; }
        public string AREClave { get; set; }
        public string UBCClave { get; set; }
        public Nullable<decimal> Capacidad { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
    
        public virtual Almacen Almacen { get; set; }
        public virtual Area Area { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
    }
}
