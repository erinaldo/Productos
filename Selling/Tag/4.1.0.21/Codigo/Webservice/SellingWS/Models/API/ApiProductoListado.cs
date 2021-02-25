using System;

namespace SellingWS.Models.API
{
    public class ApiProductoListado
    {
        public string PROClave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<double> Solicitado { get; set; }

    }
}