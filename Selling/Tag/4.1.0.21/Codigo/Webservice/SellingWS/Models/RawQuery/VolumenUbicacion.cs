namespace SellingWS.Models.RawQuery
{
    public class VolumenUbicacion
    {
        public string AREClave { get; set; }
        public string Area { get; set; }
        public string UBCClave { get; set; }
        public string Ubicacion { get; set; }
        public decimal? Volumen { get; set; }
        public decimal? VolumenOcupado { get; set; }
    }
}