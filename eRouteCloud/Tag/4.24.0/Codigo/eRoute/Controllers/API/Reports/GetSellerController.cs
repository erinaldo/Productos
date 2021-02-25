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
    public class GetSellerController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;
        StringBuilder sConsulta = new StringBuilder();

        [HttpGet]
        public IHttpActionResult GET(string Cedis)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Cedis) || Cedis == "null")
                {
                    QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado = 1 ORDER BY VEN.Nombre";
                }
                else
                {
                    QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado = 1 AND ALM.AlmacenID = '" + Cedis + "' ORDER BY VEN.Nombre";
                }
                List<GetSellerModel> List = Connection.Query<GetSellerModel>(QueryString).ToList();

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
                if (string.IsNullOrWhiteSpace(Cedis) || Cedis == "null")
                {
                    if (inactivos == "false" || inactivos == "undefined")
                    {
                        QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado in (1,0) ORDER BY VEN.Nombre";
                    }
                    else
                    {
                        QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado = 1 ORDER BY VEN.Nombre";

                    }
                }
                else
                {

                    if (inactivos == "false" || inactivos == "undefined")
                    {
                        QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado in (1,0) AND ALM.AlmacenID = '" + Cedis + "' ORDER BY VEN.Nombre";

                    }
                    else
                    {
                        QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado = 1 AND ALM.AlmacenID = '" + Cedis + "' ORDER BY VEN.Nombre";

                    }
                }
                List<GetSellerModel> List = Connection.Query<GetSellerModel>(QueryString).ToList();

                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }


        [HttpGet]

        public IHttpActionResult GET(string Cedis, bool estado)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Cedis) || Cedis == "null")
                {
                    if (estado == true)
                    {
                        QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado in ('0') ORDER BY VEN.Nombre";
                    }
                    else
                    {
                        QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado = 1 ORDER BY VEN.Nombre";
                    }
                }
                else
                {
                    if (estado == true)
                    {
                        QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado in ('0') AND ALM.AlmacenID = '" + Cedis + "' ORDER BY VEN.Nombre";
                    }
                    else
                    {
                        QueryString = "SELECT VEN.VendedorId,VEN.Nombre FROM Vendedor VEN INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId INNER JOIN Almacen ALM ON VENDIS.AlmacenId = ALM.AlmacenID where VEN.TipoEstado = 1 AND ALM.AlmacenID = '" + Cedis + "' ORDER BY VEN.Nombre";
                    }
                }
                List<GetSellerModel> List = Connection.Query<GetSellerModel>(QueryString).ToList();

                return Ok(List);

            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GETSeller(string cedis = null, string estado = null)
        {
            try
            {
                ReportGetCondition report = new ReportGetCondition();
                cedis = report.AllFilter(cedis, null);
                estado = report.AllFilter(estado, null);

                sConsulta.Append("SELECT VEN.VendedorId, VEN.Nombre FROM Vendedor VEN (NOLOCK) INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 (NOLOCK) INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist (NOLOCK) GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId ");
                if (cedis != null)
                {
                    sConsulta.Append("INNER JOIN Almacen ALM (NOLOCK) ON VENDIS.AlmacenId = ALM.AlmacenID AND ALM.AlmacenID IN (" + cedis + ") ");
                }
                sConsulta.Append("WHERE VEN.TipoEstado IN (" + (estado == null ? "1" : estado) + ") ORDER BY VEN.Nombre");
                QueryString = sConsulta.ToString();
                List<GetSellerModel> List = Connection.Query<GetSellerModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }
    }

    public class GetSellerModel
    {
        public string VendedorId { get; set; }
        public string Nombre { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
