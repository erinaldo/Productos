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
    public class GetEncuestasController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET()
        {
            try
            {
                QueryString = "select VAD.Descripcion as Tipo, CENClave, CEN.Descripcion ";
                QueryString += "from ConfigEncuesta CEN ";
                QueryString += "inner join VAVDescripcion VAD on CEN.Tipo = VAD.VAVClave and VAD.VARCodigo = 'TENC' and VAD.VADTipoLenguaje = 'EM'";
                List<GetEncuestaModel> List = Connection.Query<GetEncuestaModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }

    public class GetEncuestaModel
    {
        public string Tipo { get; set; }
        public string CENClave { get; set; }
        public string Descripcion { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
