using System;

namespace SellingWS.Models.API
{
    public class ApiProductoInventario
    {
        public string PROClave { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<decimal> Existencia { get; set; }
        public Nullable<decimal> Apartado { get; set; }
        public Nullable<decimal> Bloqueado { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
    }
}