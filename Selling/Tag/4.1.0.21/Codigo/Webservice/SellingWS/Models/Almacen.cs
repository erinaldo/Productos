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
    
    public partial class Almacen
    {
        public Almacen()
        {
            this.Area = new HashSet<Area>();
            this.DevCompra = new HashSet<DevCompra>();
            this.Estrategia = new HashSet<Estrategia>();
            this.Estructura = new HashSet<Estructura>();
            this.Existencia = new HashSet<Existencia>();
            this.MOVALM = new HashSet<MOVALM>();
            this.MovUbc = new HashSet<MovUbc>();
            this.Orden = new HashSet<Orden>();
            this.ReciboAlmacen = new HashSet<ReciboAlmacen>();
            this.Traslado = new HashSet<Traslado>();
            this.Traslado1 = new HashSet<Traslado>();
            this.Venta = new HashSet<Venta>();
        }
    
        public string ALMClave { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Largo { get; set; }
        public Nullable<decimal> Alto { get; set; }
        public Nullable<decimal> Ancho { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<decimal> Escala { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string SUCClave { get; set; }
        public Nullable<bool> BloqueoVta { get; set; }
        public Nullable<bool> Predeterminado { get; set; }
        public Nullable<int> TipoSurtido { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
    
        public virtual Sucursal Sucursal { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<DevCompra> DevCompra { get; set; }
        public virtual ICollection<Estrategia> Estrategia { get; set; }
        public virtual ICollection<Estructura> Estructura { get; set; }
        public virtual ICollection<Existencia> Existencia { get; set; }
        public virtual ICollection<MOVALM> MOVALM { get; set; }
        public virtual ICollection<MovUbc> MovUbc { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
        public virtual ICollection<ReciboAlmacen> ReciboAlmacen { get; set; }
        public virtual ICollection<Traslado> Traslado { get; set; }
        public virtual ICollection<Traslado> Traslado1 { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
