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
    public class GetSupervisorController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET(string Cedis)
        {
            try
            {
                if (String.IsNullOrEmpty(Cedis) || Cedis == "undefined")
                {
                    QueryString = "select u.Clave, u.Nombre from Usuario u inner join VARValor v on u.Tipo=v.VAVClave where u.Activo=1 and v.VARCodigo='BTIPUSO' and v.Grupo='Supervisores' order by u.Clave --v.Grupo='Supervisores'";

                }
                else
                {

                    QueryString = "select u.Clave, u.Nombre from Usuario u inner join VARValor v on u.Tipo=v.VAVClave inner join Almacen a on u.AlmacenId=a.AlmacenId where u.Activo=1 and v.VARCodigo='BTIPUSO' and v.Grupo='Supervisores' and a.Clave= '" + Cedis + "' order by u.Clave  --v.Grupo='Supervisores'";

                }
                List<GetSupervisorModel> List = Connection.Query<GetSupervisorModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }

    public class GetSupervisorModel
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
