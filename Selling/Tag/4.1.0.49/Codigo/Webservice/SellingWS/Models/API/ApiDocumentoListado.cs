using System;

namespace SellingWS.Models.API
{
    public class ApiDocumentoListado
    {
        public string TipoDocumento { get; set; }
        public string Clave { get; set; }
        public string Folio { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> Prioridad { get; set; }
        public Nullable<int> CantidadProductos { get; set; }

    }
}