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
    public class GetModelController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;
        StringBuilder sConsulta = new StringBuilder();
        ReportGetCondition report = new ReportGetCondition();
        List<GetModel> List;

        /*GetRoutes*/
        [HttpGet]
        public IHttpActionResult GetRoutes(string cedis = null, string estado = null)
        {
            try
            {
                cedis = report.AllFilter(cedis, null);
                estado = report.AllFilter(estado, null);

                sConsulta.Append("SELECT R.RUTClave AS Clave, R.Descripcion AS Nombre FROM Ruta R (NOLOCK) ");
                if (cedis != null)
                {
                    sConsulta.Append("INNER JOIN Almacen A (NOLOCK) ON R.AlmacenID = A.AlmacenID AND A.AlmacenID IN (SELECT Datos FROM FNSplit('" + cedis + "', ',')) AND R.TipoEstado IN (" + (estado == null ? "1" : estado) + ") ORDER BY A.Nombre");
                }
                else
                {
                    sConsulta.Append("WHERE R.TipoEstado IN (" + (estado == null ? "1" : estado) + ")");
                }
                QueryString = sConsulta.ToString();
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetClients*/
        [HttpGet]
        public IHttpActionResult GetClients(string cedis = null, string state = null, string clientScheme = null, string routes = null, string sellers = null, bool visit = false)
        {
            try
            {
                cedis = report.AllFilter(cedis, null);
                state = report.AllFilter(state, null);
                clientScheme = report.AllFilter(clientScheme, null);
                routes = report.AllFilter(routes, null);
                sellers = report.AllFilter(sellers, null);

                //Consulta general
                sConsulta.Append("SELECT DISTINCT C.ClienteClave AS Clave, C.RazonSocial AS Nombre, C.Clave AS Extra FROM Cliente C (NOLOCK) ");
                if (cedis != null)
                {
                    //Filtrado por Almacen
                    sConsulta.Append("INNER JOIN Almacen A (NOLOCK) ON C.AlmacenID = A.AlmacenID AND A.AlmacenID IN (SELECT Datos FROM FNSplit('" + cedis + "', ',')) ");
                }
                else if (routes != null || sellers != null)
                {
                    //Filtrado por Rutas o Vendedores
                    sConsulta.Append("INNER JOIN Secuencia S (NOLOCK) ON S.ClienteClave = C.ClienteClave ");
                    if (routes != null)
                    {
                        //Por Rutas
                        sConsulta.Append("AND S.RUTClave IN (SELECT Datos FROM FNSplit('" + routes + "', ',')) ");
                    }
                    else if (sellers != null)
                    {
                        if (visit)
                        {
                            //Por Vendedores en base a sus visitas
                            sConsulta.Append("INNER JOIN Visita V (NOLOCK) ON S.RUTClave = V.RUTClave AND V.VendedorID IN (SELECT Datos FROM FNSplit('" + sellers + "', ','))) ");
                        }
                        else
                        {
                            //Por Vendedores
                            sConsulta.Append("AND S.RUTClave IN (SELECT RUTClave FROM VenRut (NOLOCK) WHERE VendedorID IN (SELECT Datos FROM FNSplit('" + sellers + "', ','))) ");
                        }
                    }
                }
                if (clientScheme != null)
                {
                    //Filtro por Esquema
                    sConsulta.Append("INNER JOIN ClienteEsquema D (NOLOCK) ON C.ClienteClave = D.ClienteClave INNER JOIN Esquema E (NOLOCK) ON D.EsquemaID = E.EsquemaID AND E.Tipo = 1 AND E.EsquemaID IN (SELECT Datos FROM FNSplit('" + clientScheme + "', ',')) ");
                }
                //Filtro por Estado
                sConsulta.Append("WHERE C.TipoEstado IN (" + (state == null ? "1" : state) + ")");
                QueryString = sConsulta.ToString();
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetSellers*/
        [HttpGet]
        public IHttpActionResult GetSellers(string cedis = null, string estado = null)
        {
            try
            {
                cedis = report.AllFilter(cedis, null);
                estado = report.AllFilter(estado, null);

                sConsulta.Append("SELECT VEN.VendedorId AS Clave, VEN.Nombre AS Nombre FROM Vendedor VEN (NOLOCK) INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist V1 (NOLOCK) INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist (NOLOCK) GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) VENDIS ON VEN.VendedorID = VENDIS.VendedorId ");
                if (cedis != null)
                {
                    sConsulta.Append("INNER JOIN Almacen ALM (NOLOCK) ON VENDIS.AlmacenId = ALM.AlmacenID AND ALM.AlmacenID IN (SELECT Datos FROM FNSplit('" + cedis + "', ',')) ");
                }
                sConsulta.Append("WHERE VEN.TipoEstado IN (" + (estado == null ? "1" : estado) + ") ORDER BY VEN.Nombre");
                QueryString = sConsulta.ToString();
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetLots*/
        [HttpGet]
        public IHttpActionResult GetLots(string estado = null)
        {
            try
            {
                estado = report.AllFilter(estado, null);

                QueryString = "SELECT LC.Lote AS Clave, LC.Caducidad AS Nombre FROM LoteCaducidad LC (NOLOCK) WHERE LC.Estado IN (" + (estado == null ? "1" : estado) + ")";
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetProducts*/
        [HttpGet]
        public IHttpActionResult GetProducts(string productSchemes = null)
        {
            try
            {
                productSchemes = report.AllFilter(productSchemes, null);

                QueryString = "SELECT DISTINCT P.ProductoClave AS Clave, P.Nombre AS Nombre FROM Producto P (NOLOCK) INNER JOIN ProductoEsquema PE (NOLOCK) ON P.ProductoClave = PE.ProductoClave WHERE PE.EsquemaID IN (SELECT Datos FROM FNSplit('" + productSchemes + "', ',')) ORDER BY Clave, Nombre";
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetSupervisors*/
        [HttpGet]
        public IHttpActionResult GetSupervisors(string cedis = null, string estado = null)
        {
            try
            {
                cedis = report.AllFilter(cedis, null);
                estado = report.AllFilter(estado, null);

                sConsulta.Append("SELECT U.USUId AS Clave, U.Nombre AS Nombre, U.Clave AS Extra FROM Usuario U (NOLOCK) INNER JOIN VARValor V (NOLOCK) ON U.Tipo = V.VAVClave ");
                if (cedis != null)
                {
                    sConsulta.Append("INNER JOIN Almacen A (NOLOCK) ON U.AlmacenId = A.AlmacenId AND A.Clave IN (SELECT Datos FROM FNSplit('" + cedis + "', ',')) ");
                }
                sConsulta.Append("WHERE U.Activo IN (" + (estado == null ? "1" : estado) + ") AND V.VARCodigo = 'BTIPUSO' AND V.Grupo = 'Supervisores' ORDER BY U.Clave");
                QueryString = sConsulta.ToString();
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetPolls*/
        [HttpGet]
        public IHttpActionResult GetPolls()
        {
            try
            {
                QueryString = "SELECT VAD.Descripcion AS Otro, CENClave AS Clave, CEN.Descripcion AS Nombre FROM ConfigEncuesta CEN (NOLOCK) INNER JOIN VAVDescripcion VAD (NOLOCK) ON CEN.Tipo = VAD.VAVClave AND VAD.VARCodigo = 'TENC' AND VAD.VADTipoLenguaje = 'EM'";
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetSchemes*/
        [HttpGet]
        public IHttpActionResult GetSchemes(string cedis = null, string state = null, string types = null, string levels = null, string schemesID = null)
        {
            try
            {
                cedis = report.AllFilter(cedis, null);
                state = report.AllFilter(state, null);
                types = report.AllFilter(types, null);
                levels = report.AllFilter(levels, null);
                schemesID = report.AllFilter(schemesID, null);

                //Consulta general
                sConsulta.Append("SELECT DISTINCT E.EsquemaID AS Clave, E.Nombre AS Nombre, E.Clave AS Extra FROM Esquema E (NOLOCK) ");
                if (types == "2")
                {
                    //Filtrado por Producto
                    sConsulta.Append("INNER JOIN ProductoEsquema PE (NOLOCK) ON PE.EsquemaID = E.EsquemaID INNER JOIN Producto P (NOLOCK) ON P.ProductoClave = PE.ProductoClave ");
                }
                else if (types == "1")
                {
                    //Filtrado por Cliente
                    sConsulta.Append("INNER JOIN ClienteEsquema CE (NOLOCK) ON CE.EsquemaID = E.EsquemaID ");
                    if (cedis != null)
                    {
                        sConsulta.Append("INNER JOIN Secuencia S (NOLOCK) ON S.ClienteClave = CE.ClienteClave INNER JOIN Ruta R (NOLOCK) ON R.RUTClave = S.RUTClave AND R.AlmacenID IN (SELECT AlmacenID FROM Almacen (NOLOCK) WHERE AlmacenID IN (SELECT Datos FROM FNSplit('" + cedis + "', ','))) ");
                    }
                }
                sConsulta.Append("WHERE E.TipoEstado IN (" + (state == null ? "1" : state) + ") AND E.Tipo IN (" + (types == null ? "1" : types) + ") AND E.Nivel IN (" + (levels == null ? "0" : levels) + ") ");
                if (schemesID != null)
                {
                    sConsulta.Append("AND E.EsquemaIDPadre IN (SELECT Datos FROM FNSplit('" + schemesID + "', ','))");
                }
                QueryString = sConsulta.ToString();
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetDateStatus*/
        [HttpGet]
        public IHttpActionResult GetDateStatus()
        {
            try
            {
                QueryString = "SELECT Descripcion AS Nombre FROM VAVDescripcion (NOLOCK) WHERE VARCodigo ='BFNUMERI' AND VADTipoLenguaje = 'EM' AND (Descripcion = 'Igual' OR Descripcion = 'Entre')";
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetCEDIS*/
        [HttpGet]
        public IHttpActionResult GetCEDIS(string USUId = null, string state = null, string types = null)
        {
            try
            {
                USUId = report.AllFilter(USUId, "null");
                state = report.AllFilter(state, null);
                types = report.AllFilter(types, null);

                sConsulta.Append("SELECT DISTINCT A.AlmacenID AS Clave, A.Clave + ' ' + A.Nombre AS Nombre FROM UsuarioAlmacen UA (NOLOCK) INNER JOIN Almacen A (NOLOCK) ON A.AlmacenID = UA.AlmacenId WHERE A.TipoEstado IN (" + (state == null ? "1" : state) + ") AND A.Tipo IN (" + (types == null ? "1" : types) + ") AND ((UA.USUId = '" + USUId + "') OR '" + USUId + "' IS NULL)");
                QueryString = sConsulta.ToString();
                List = Connection.Query<GetModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }
    }

    public class GetModel
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Otro { get; set; }
        public string Extra { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
