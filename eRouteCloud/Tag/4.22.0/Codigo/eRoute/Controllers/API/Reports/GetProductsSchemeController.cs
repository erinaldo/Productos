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
using eRoute.Models;

namespace eRoute.Controllers.API
{
    public class GetProductsSchemeController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET(string Productos)
        {
            try
            {
                if (String.IsNullOrEmpty(Productos) || Productos == "undefined")
                {
                    QueryString = "select distinct p.ProductoClave as Clave, p.Nombre as Nombre from Producto p inner join ProductoEsquema pe on p.ProductoClave = pe.ProductoClave order by Clave, Nombre ";
                }
                else
                {
                    QueryString = "select distinct p.ProductoClave as Clave, p.Nombre as Nombre from Producto p inner join ProductoEsquema pe on p.ProductoClave = pe.ProductoClave  where 1 = 1 and pe.EsquemaID = '" + Productos + "'  order by Clave, Nombre ";
                }
                List<GetProductsSchemeModel> List = Connection.Query<GetProductsSchemeModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult GET(string Esquemas, string id)
        {
            try
            {
                if (String.IsNullOrEmpty(Esquemas) || Esquemas == "undefined")
                {
                    QueryString = "select distinct p.ProductoClave as Clave, p.Nombre as Nombre from Producto p inner join ProductoEsquema pe on p.ProductoClave = pe.ProductoClave order by Clave, Nombre ";
                }
                else
                {
                    QueryString = "select distinct p.ProductoClave as Clave, p.Nombre as Nombre from Producto p inner join ProductoEsquema pe on p.ProductoClave = pe.ProductoClave  where 1 = 1 and pe.EsquemaID in (" + Esquemas + ") order by Clave, Nombre ";
                }
                List<GetProductsSchemeModel> List = Connection.Query<GetProductsSchemeModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult GETProductsScheme(string level = null)
        {
            try
            {
                ReportGetCondition report = new ReportGetCondition();
                level = report.AllFilter(level, null);
                if (level == null)
                {
                    QueryString = "SELECT DISTINCT E.EsquemaID, E.Nombre, E.Clave FROM Producto P (NOLOCK) "
                                + "INNER JOIN ProductoEsquema Pe (NOLOCK) ON PE.ProductoClave = P.ProductoClave "
                                + "INNER JOIN Esquema E (NOLOCK) ON PE.EsquemaID = E.EsquemaID "
                                + "WHERE E.TipoEstado = 1 AND E.Tipo = 2";
                }
                else
                {
                    QueryString = "SELECT DISTINCT E.EsquemaID, E.Nombre, E.Clave FROM   Esquema E (NOLOCK) "
                        + "WHERE E.TipoEstado = 1 AND E.Tipo = 2 AND E.Nivel  IN (" + (level == null ? "1, 2" : level) + ")";
                }
                List<GetProductsSchemeModel> List = Connection.Query<GetProductsSchemeModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }

    public class GetProductsSchemeModel
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
