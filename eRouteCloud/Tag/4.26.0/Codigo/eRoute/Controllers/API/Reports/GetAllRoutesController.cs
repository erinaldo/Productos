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

namespace eRoute.Controllers.API.Reports
{
    public class GetAllRoutesController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET(bool inactivos = false)
        {
            try
            {
                if (inactivos)
                {
                    QueryString = "SELECT RUTClave, Descripcion FROM Ruta (nolock)";
                }
                else
                {
                    QueryString = "SELECT RUTClave, Descripcion FROM Ruta (nolock) WHERE TipoEstado = 1";
                }
                List<GetRoutesModel> List = Connection.Query<GetRoutesModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }
    }
}