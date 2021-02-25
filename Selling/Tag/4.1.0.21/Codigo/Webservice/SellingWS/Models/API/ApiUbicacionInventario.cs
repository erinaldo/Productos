using System;

namespace SellingWS.Models.API
{
    public class ApiUbicacionInventario
    {
        public string UBCClave { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<decimal> Existencia { get; set; }
        public Nullable<decimal> Apartado { get; set; }
        public Nullable<decimal> Bloqueado { get; set; }
    }
}