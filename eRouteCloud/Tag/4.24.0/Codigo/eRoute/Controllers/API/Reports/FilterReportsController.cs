using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using eRoute.Models;
using System.Collections;
namespace eRoute.Controllers.API
{
    [AuthorizeAPI]
    public class FilterReportsController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET(string PERClave, string USUId)
        {
            try
            {
                QueryString = "SELECT VAD.VAVClave, VAD.Descripcion FROM VAVDescripcion VAD INNER JOIN VARValor VAV ON VAV.VARCodigo=VAD.VARCodigo AND VAV.VAVClave=VAD.VAVClave AND VAV.Estado=1 WHERE VAD.VARCodigo = 'REPORTEW' and VAD.VAVClave <> 0 and VAD.VADTipoLenguaje ='EM' order by VAD.Descripcion ";
                List<GetReportsModel> User = Connection.Query<GetReportsModel>(QueryString).ToList();

                List<GetReportsModel> List = new List<GetReportsModel>();
                ArrayList array = new ArrayList();
                string vlpermiso = "";
                for (int i = 0; i <= User.Count() - 1; i++)
                {
                    vlpermiso = "";
                    QueryString = "select * from intusu where permiso like '%E%' and USUId='" + USUId + "' AND ACTId='ReporteW" + User.ElementAt(i).VAVClave + "' AND INTTipoInterfaz=3";
                    var permiso = Connection.Query(QueryString).ToList();
                    if (permiso.Count() > 0)
                    {
                        vlpermiso = permiso.ElementAt(0).Permiso;
                    }
                    else
                    {
                        QueryString = "select * from intper where permiso like '%E%' and PERClave='" + PERClave + "' AND ACTId='ReporteW" + User.ElementAt(i).VAVClave + "' AND INTTipoInterfaz=3";
                        permiso = Connection.Query(QueryString).ToList();
                        if (permiso.Count() > 0)
                        {
                            vlpermiso = permiso.ElementAt(0).Permiso;
                        }
                        else
                        {
                            vlpermiso = "";
                        }
                    }
                    if (vlpermiso.Trim() == "")
                    {
                        array.Add(i);
                    }
                }

                for (int x = array.Count - 1; x >= 0; x--)
                {
                    string s = array[x].ToString();
                    int g = Int32.Parse(s);
                    User.RemoveAt(g);
                }

                return Ok(User);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }

    public class GetReportsModel
    {
        public string VAVClave { get; set; }
        public string Descripcion { get; set; }
    }
}
