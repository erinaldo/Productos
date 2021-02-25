using System;

namespace SellingWS.Models.API
{
    public class ApiProductoContado
    {
        public string PROClave { get; set; }
        public string Nombre { get; set; }
        public double Cantidad { get; set; }
        public string UBCClave { get; set; }
        public string Ubicacion { get; set; }
    }
}