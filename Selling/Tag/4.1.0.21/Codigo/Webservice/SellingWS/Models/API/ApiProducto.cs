using System;

namespace SellingWS.Models.API
{
    public class ApiProducto
    {
        public string PROClave { get; set; }
        public string Nombre { get; set; }
        public Nullable<double> Cantidad { get; set; }
    }
}