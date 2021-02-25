using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingWS.Models.API
{
    public class ApiSurtidoAsignacionDetalle
    {
        public string DOCClave { get; set; }
        public string AREClave { get; set; }
        public string Area { get; set; }
        public string PROClave { get; set; }
        public string Producto { get; set; }
        public string NumParte { get; set; }
        public string Alterno1 { get; set; }
        public string Alterno2 { get; set; }
        public string Alterno3 { get; set; }
        public string GTIN { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Surtido { get; set; }
        public decimal? Transito { get; set; }
        public string UBCClave { get; set; }
        public string Ubicacion { get; set; }
        public int? Tiporechazo { get; set; }
    }
}