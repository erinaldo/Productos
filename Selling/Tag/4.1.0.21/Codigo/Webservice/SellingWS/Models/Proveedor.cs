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
    
    public partial class Proveedor
    {
        public Proveedor()
        {
            this.DevCompra = new HashSet<DevCompra>();
            this.Orden = new HashSet<Orden>();
            this.Orden1 = new HashSet<Orden>();
        }
    
        public string PRVClave { get; set; }
        public string Clave { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public string NombreCorto { get; set; }
        public string RazonSocial { get; set; }
        public string id_Fiscal { get; set; }
        public string CURP { get; set; }
        public string Pais { get; set; }
        public string Entidad { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
        public string codigoPostal { get; set; }
        public string Colonia { get; set; }
        public string referencia { get; set; }
        public string Calle { get; set; }
        public string noExterior { get; set; }
        public string noInterior { get; set; }
        public Nullable<decimal> LimiteCredito { get; set; }
        public Nullable<int> DiasCredito { get; set; }
        public Nullable<int> DiasEntrega { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public string Contacto { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Email { get; set; }
        public Nullable<int> TImpuesto { get; set; }
        public string NoCliente { get; set; }
        public string COMClave { get; set; }
        public string CtaContable { get; set; }
        public string ProveedorSAP { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<bool> Baja { get; set; }
        public Nullable<System.DateTime> MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
    
        public virtual ICollection<DevCompra> DevCompra { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
        public virtual ICollection<Orden> Orden1 { get; set; }
    }
}
