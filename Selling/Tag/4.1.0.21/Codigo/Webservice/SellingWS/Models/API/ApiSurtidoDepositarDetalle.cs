using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingWS.Models.API
{
    public class ApiSurtidoDepositarDetalle
    {
        public string AREClave { get; set; }
        public string PROClave { get; set; }
        public string UBCClave { get; set; }
        public decimal? Transito { get; set; }
        public int? TipoRechazo { get; set; }
    }
}