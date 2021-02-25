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
using System.Text;
using eRoute.Models;

namespace eRoute.Controllers.API
{
    public class GetLotesController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;
        StringBuilder sConsulta = new StringBuilder();

        [HttpGet]
        public IHttpActionResult GET(string estado = null)
        {
            try
            {
                
                QueryString = "SELECT LC.Lote, LC.Caducidad FROM LoteCaducidad LC (NOLOCK) WHERE LC.Estado IN (" + (estado == null ? "1" : estado) + ")";
                
                List<GetLotesModel> List = Connection.Query<GetLotesModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }     
    }

    public class GetLotesModel
    {
        public string Lote { get; set; }
        public string Caducidad { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
