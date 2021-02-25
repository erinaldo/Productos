using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoute.Models
{
    public class TokenModel
    {
        public string Id { get; set; }
        public string USUId { get; set; }
        public string PERClave { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public DateTime Fecha_Expiracion { get; set; }
        public string Token { get; set; }
    }
}