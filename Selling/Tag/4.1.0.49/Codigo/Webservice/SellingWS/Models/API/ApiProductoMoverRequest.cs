namespace SellingWS.Models.API
{
    public class ApiProductoMoverRequest
    {
        public string COMClave { get; set; }
        public string ALMClave { get; set; }
        public string SUCClave { get; set; }
        public string origenUBCClave { get; set; }
        public string destinoUBCClave { get; set; }
        public string PROClave { get; set; }
        public int cantidad { get; set; }
        public string cantString { get; set; }
    }
}