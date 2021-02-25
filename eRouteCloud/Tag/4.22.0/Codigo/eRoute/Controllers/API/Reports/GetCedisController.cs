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
using System.Text;
using eRoute.Models;

namespace eRoute.Controllers.API.Reports
{
    public class GetCedisController : ApiController
    {
        RouteEntities db = new RouteEntities();
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET(string USUId)
        {
            try
            {

                /*
                Connection.Open();

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.Append("select ua.AlmacenId, a.Clave+' - '+a.Nombre as Nombre  ");
                sConsulta.Append("from UsuarioAlmacen ua ");
                sConsulta.Append("inner join Almacen a on ua.AlmacenId=a.AlmacenId ");
                sConsulta.Append("where ua.USUId='" + USUId + "' ");


                QueryString = sConsulta.ToString();
                List<CedisModel> Cedis = Connection.Query<CedisModel>(QueryString).ToList();

                Connection.Close();

                var CedisList = (from c in Cedis
                                 select c).ToList();

                StringBuilder list = new StringBuilder();
                foreach (var x in CedisList)
                {
                    if (x.Equals(CedisList.Last()))
                    {
                        list.Append("'" + x.AlmacenId + "'");
                    }
                    else
                    {
                        list.Append("'" + x.AlmacenId + "',");
                    }
                }

                string aux = list.ToString();
                string[] ListCedis = null;
                string cleanQuery = String.Empty;
                if (CedisList.Count() == 1)
                {
                    ListCedis = aux.Split(',');
                }
                else
                {
                    ListCedis = aux.Split(' ');
                }

                Connection.Open();
                QueryString = "select clave+' '+nombre as texto,clave from almacen where tipo =1 and AlmacenId in ('MOR','MORV','YUR','YURV')";
                QueryString = "select clave+' '+nombre as texto,clave from almacen where tipo =1 and AlmacenId in (" + ListCedis.ElementAt(0) + ")";
                List<string> List = Connection.Query<string>(QueryString).ToList();
                Connection.Close();
                */

                Connection.Open();
                QueryString = "select * from UsuarioAlmacen";
                List<UsuarioAlmacen> usuarioAlmacen = Connection.Query<UsuarioAlmacen>(QueryString).ToList();
                Connection.Close();

                Connection.Open();
                QueryString = "select * from Almacen";
                List<Almacen> Almacen = Connection.Query<Almacen>(QueryString).ToList();
                Connection.Close();
                

                /*CONSULTA LINQ*/

                var List = (from x in usuarioAlmacen
                            join a in Almacen on x.AlmacenId equals a.AlmacenID
                            where x.USUId == USUId && a.Tipo == "1"
                            select new cReportHeader
                                {
                                    value = a.AlmacenID,
                                    display = a.Clave + " " + a.Nombre
                                }
                            );  
                return Json(List);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }

    public class GetCedisModel
    {
        public string texto { get; set; }
        public string clave { get; set; }
    }

    class CedisModel
    {
        public string AlmacenId { get; set; }
        public string Nombre { get; set; }
    }

    public class GetCedisModelPro
    {
        public string AlmacenId { get; set; }
        public string Nombre { get; set; }
        public string display { get; set; }
        public string value { get; set; }
        public bool Checked { get; set; }
    }
}
