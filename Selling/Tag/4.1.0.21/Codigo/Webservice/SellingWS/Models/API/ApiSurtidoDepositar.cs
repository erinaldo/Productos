using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingWS.Models.API
{
    public class ApiSurtidoDepositar
    {
        public string DOCClave { get; set; }
        public int TipoDocumento { get; set; }
        public IEnumerable<ApiSurtidoDepositarDetalle> detalles { get; set; }
    }
}