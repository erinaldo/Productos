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
    public class GetRoutesController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;
        StringBuilder sConsulta = new StringBuilder();

        [HttpGet]
        public IHttpActionResult GET(string Cedis)
        {
            try
            {
                if (String.IsNullOrEmpty(Cedis) || Cedis == "undefined")
                {
                    QueryString = "select r.RUTClave, r.Descripcion from Ruta r inner join Almacen a on r.AlmacenId=a.AlmacenID order by a.Nombre ";
                }
                else
                {
                    QueryString = "select r.RUTClave, r.Descripcion from Ruta r inner join Almacen a on r.AlmacenId=a.AlmacenID  where 1 = 1 and a.AlmacenID = '" + Cedis + "' order by a.Nombre ";
                }
                List<GetRoutesModel> List = Connection.Query<GetRoutesModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GET(string Cedis, bool Varios)
        {
            try
            {
                if (String.IsNullOrEmpty(Cedis) || Cedis == "undefined")
                {
                    QueryString = "select r.RUTClave, r.Descripcion from Ruta r inner join Almacen a on r.AlmacenId=a.AlmacenID order by a.Nombre ";
                }
                else
                {
                    QueryString = "select r.RUTClave, r.Descripcion from Ruta r inner join Almacen a on r.AlmacenId=a.AlmacenID  where 1 = 1 and a.AlmacenID in (" + Cedis + ") order by a.Nombre ";
                }
                List<GetRoutesModel> List = Connection.Query<GetRoutesModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GET(string Cedis, int tipo)
        {
            try
            {
                if (String.IsNullOrEmpty(Cedis) || Cedis == "undefined")
                {
                    QueryString = "select r.RUTClave, r.Descripcion from Ruta r inner join Almacen a on r.AlmacenId=a.AlmacenID and r.Tipo =" +tipo+ " order by a.Nombre ";
                }
                else
                {
                    QueryString = "select r.RUTClave, r.Descripcion from Ruta r inner join Almacen a on r.AlmacenId=a.AlmacenID  where 1 = 1 and a.AlmacenID in (" + Cedis + ") and r.Tipo =" + tipo + " order by a.Nombre ";
                }
                List<GetRoutesModel> List = Connection.Query<GetRoutesModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GET(string Cedis, string inactivos)
        {
            try
            {
                if (inactivos == "false" || inactivos == "undefined")
                {
                    QueryString = "select R.RUTClave, R.Descripcion from Ruta R (nolock) inner join Almacen (nolock) A on R.AlmacenID = A.AlmacenID where R.TipoEstado = 1 and A.AlmacenID = '" + Cedis + "' ";
                }
                else
                {
                    QueryString = "select R.RUTClave, R.Descripcion from Ruta R (nolock) inner join Almacen (nolock) A on R.AlmacenID = A.AlmacenID where R.TipoEstado in (1,0) and A.AlmacenID = '" + Cedis + "' ";
                }

                List<GetRoutesModel> List = Connection.Query<GetRoutesModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GETRoutes(string cedis = null, string estado = null)
        {
            try
            {
                ReportGetCondition report = new ReportGetCondition();
                cedis = report.AllFilter(cedis, null);
                estado = report.AllFilter(estado, null);

                sConsulta.Append("SELECT r.RUTClave, r.Descripcion FROM Ruta r (NOLOCK) ");
                if (cedis != null)
                {
                    sConsulta.Append("INNER JOIN Almacen a (NOLOCK) ON r.AlmacenId = a.AlmacenID WHERE a.AlmacenID IN (" + cedis + ") AND r.TipoEstado IN (" + (estado == null ? "1" : estado) + ") ORDER BY a.Nombre");
                }
                else
                {
                    sConsulta.Append("WHERE r.TipoEstado IN (" + (estado == null ? "1" : estado) + ")");
                }
                QueryString = sConsulta.ToString();
                List<GetRoutesModel> List = Connection.Query<GetRoutesModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }
    }

    public class GetRoutesModel
    {
        public string RUTClave { get; set; }
        public string Descripcion { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
