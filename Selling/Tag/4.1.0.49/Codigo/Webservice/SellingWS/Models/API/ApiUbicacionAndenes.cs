using System;

namespace SellingWS.Models.API
{
    public class ApiUbicacionAndenes
    {
        public string IdRecibo { get; set; }
        public string Folio { get; set; }
        public string Anden { get; set; }
        public Nullable<decimal> PorcentajeRecibo { get; set; }
        public Nullable<decimal> NumPiezas { get; set; }
    }
}