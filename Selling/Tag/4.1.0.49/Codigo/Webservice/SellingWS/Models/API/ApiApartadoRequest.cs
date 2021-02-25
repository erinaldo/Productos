namespace SellingWS.Models.API
{
    public class ApiApartadoRequest
    {
        public string origenUBCClave { get; set; }
        public string destinoUBCClave { get; set; }
        public string PROClave { get; set; }
        public int productoCantidad { get; set; }
    }
}