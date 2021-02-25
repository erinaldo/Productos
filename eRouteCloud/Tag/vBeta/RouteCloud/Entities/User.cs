using System;

namespace RouteCloud.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string USUId { get; set; }
        public string Clave { get; set; }
        public string PERClave { get; set; }
        public string Fecha_Emision { get; set; }
        public string Fecha_Expiracion { get; set; }
        public string Token { get; set; }
    }
}