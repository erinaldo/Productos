using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;

namespace eRoute.Controllers.API
{
    public class GetDateStatusController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET()
        {
            try
            {
                QueryString = "SELECT [Descripcion] FROM [VAVDescripcion] WHERE [VARCodigo] ='BFNUMERI' AND [VADTipoLenguaje] = 'EM' AND ([Descripcion] = 'Igual' or [Descripcion] = 'Entre')";
                //QueryString = "SELECT [Descripcion] FROM [VAVDescripcion] WHERE [VARCodigo] ='BFNUMERI' AND [VADTipoLenguaje] = 'EM' AND ([Descripcion] = 'Igual' or [Descripcion] = 'Entre' or [Descripcion] = 'Menor o igual que')";
                List<GetDateStatusModel> List = Connection.Query<GetDateStatusModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }

    public class GetDateStatusModel
    {
        public string Descripcion { get; set; }
    }
}
