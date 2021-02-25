using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoute.Models
{
    public class UserModel
    {
        public string USUId { get; set; }
        public string PERClave { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ClaveAcceso { get; set; }
        public int DiasLimite { get; set; }
        public DateTime FechaMod { get; set; }
        public int Tipo { get; set; } 
        public bool Activo { get; set; }
        public string AlmacenID { get; set; }
        public string PoliticaId { get; set; }
        public DateTime MFechaHora { get; set; }
        public string MUsuarioId { get; set; }
    }


    public class LoginData
    {
        public string userName { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
    }
}