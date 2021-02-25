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
    public class GetSchemeController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET(int Tipo)
        {
            try
            {
                QueryString = "select EsquemaId, Clave, Nombre from Esquema where TipoEstado = 1 and Tipo = " + Tipo;
                List<GetSchemeModel> List = Connection.Query<GetSchemeModel>(QueryString).ToList();
                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GET(int Tipo, int Nivel)
        {
            try
            {
                QueryString = "select EsquemaId, Clave, Nombre from Esquema where TipoEstado = 1 and Tipo = " + Tipo + " and Nivel = " + Nivel;
                List<GetSchemeModel> List = Connection.Query<GetSchemeModel>(QueryString).ToList();
                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        
    }

    public class GetSchemeModel
    {
        public string EsquemaId { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool Checked { get; set; }
    }
}
