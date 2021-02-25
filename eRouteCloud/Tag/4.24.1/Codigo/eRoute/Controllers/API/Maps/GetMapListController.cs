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

namespace eRoute.Controllers.API.Maps
{
    public class GetMapListController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET()
        {
            try
            {
                QueryString = "select vavclave,Descripcion from vavdescripcion where varcodigo ='MAPAW' and vadtipolenguaje='EM'";
                List<GetMapModel> List = Connection.Query<GetMapModel>(QueryString).ToList();

                return Json(List);
            }
            catch
            {
                return null;
            }
        }
    }

    public class GetMapModel
    {
        public string vavclave { get; set; }
        public string Descripcion { get; set; }
    }
}
