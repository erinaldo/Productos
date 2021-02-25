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

namespace eRoute.Controllers.API.Reports
{
    public class GetProductsController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET()
        {
            try
            {
                QueryString = "SELECT EsquemaId, Clave, Nombre FROM Esquema where tipoestado=1 and tipo=2";
                List<GetProductsModel> List = Connection.Query<GetProductsModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        //public IHttpActionResult GETProducts(string productsScheme = null)
        //{
        //    try
        //    {
        //        ReportGetCondition report = new ReportGetCondition();
        //        productsScheme = report.AllFilter(productsScheme, null);
        //        QueryString = "SELECT DISTINCT P.ProductoClave AS Clave, P.Nombre AS Nombre FROM Producto P INNER JOIN ProductoEsquema PE ON P.ProductoClave = PE.ProductoClave WHERE PE.EsquemaID IN (" + productsScheme + ") ORDER BY Clave, Nombre";
        //        List<GetProductsModel> List = Connection.Query<GetProductsModel>(QueryString).ToList();

        //        return Ok(List);
        //    }
        //    catch
        //    {
        //        return InternalServerError();
        //    }
        //}
    }

    public class GetProductsModel
    {
        public string EsquemaId { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
