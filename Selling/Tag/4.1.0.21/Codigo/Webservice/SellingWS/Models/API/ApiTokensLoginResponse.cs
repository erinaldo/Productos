namespace SellingWS.Models.API
{
    public class ApiTokensLoginResponse
    {
        public string Token { set; get; }
        public ApiLoginSucursalesResponse[] Sucursales { set; get; }
    }
}