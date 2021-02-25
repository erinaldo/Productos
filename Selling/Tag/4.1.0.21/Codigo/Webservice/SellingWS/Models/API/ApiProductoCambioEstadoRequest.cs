namespace SellingWS.Models.API
{
    public class ApiProductoCambioEstadoRequest
    {
        public string COMClave { get; set; }
        public string SUCClave { get; set; }
        public string ALMClave { get; set; }
        public string UBCClave { get; set; }
        public string PROClave { get; set; }
        public bool Bloquear { get; set; }
    }
}