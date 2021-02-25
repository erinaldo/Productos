using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Dapper;
using System.Text;
using eRoute.Models;

namespace eRoute.Controllers.API.Reports
{
    public class GetReportFiltersController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;
        StringBuilder sConsulta = new StringBuilder();
        ReportGetCondition report = new ReportGetCondition();
        List<ReportFilterModel> List;

        /*GetRoutes*/
        [HttpGet]
        public IHttpActionResult GetRoutes(string cedis = null, string state = null)
        {
            try
            {
                cedis = report.AllFilter(cedis, null);
                state = report.AllFilter(state, null);

                sConsulta.Append("SELECT R.RUTClave AS Clave, R.Descripcion AS Nombre FROM Ruta AS R (NOLOCK) ");
                if (cedis != null)
                {
                    sConsulta.AppendFormat("INNER JOIN Almacen AS A (NOLOCK) ON R.AlmacenID = A.AlmacenID AND A.AlmacenID IN (SELECT Datos FROM FNSplit('{0}', ',')) AND R.TipoEstado IN ({1}) ORDER BY A.Nombre", cedis, state ?? "1");
                }
                else
                {
                    sConsulta.AppendFormat("WHERE R.TipoEstado IN ({0})", state ?? "1");
                }
                QueryString = sConsulta.ToString();
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
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
                sConsulta.Append("SELECT DISTINCT C.ClienteClave AS Clave, C.RazonSocial AS Nombre FROM Cliente AS C (NOLOCK) ");
                if (cedis != null)
                {
                    //Filtrado por Almacen
                    sConsulta.AppendFormat("INNER JOIN Almacen AS A (NOLOCK) ON C.AlmacenID = A.AlmacenID AND A.AlmacenID IN (SELECT Datos FROM FNSplit('{0}', ',')) ", cedis);
                }
                if (routes != null || sellers != null)
                {
                    //Filtrado por Rutas o Vendedores
                    sConsulta.Append("INNER JOIN Secuencia AS S (NOLOCK) ON S.ClienteClave = C.ClienteClave ");
                    if (routes != null)
                    {
                        //Por Rutas
                        sConsulta.AppendFormat("AND S.RUTClave IN (SELECT Datos FROM FNSplit('{0}', ',')) ", routes);
                    }
                    else if (sellers != null)
                    {
                        if (visit)
                        {
                            //Por Vendedores en base a sus visitas
                            sConsulta.AppendFormat("INNER JOIN Visita AS V (NOLOCK) ON S.RUTClave = V.RUTClave AND V.VendedorID IN (SELECT Datos FROM FNSplit('{0}', ','))) ", sellers);
                        }
                        else
                        {
                            //Por Vendedores
                            sConsulta.AppendFormat("AND S.RUTClave IN (SELECT RUTClave FROM VenRut (NOLOCK) WHERE VendedorID IN (SELECT Datos FROM FNSplit('{0}', ','))) ", sellers);
                        }
                    }
                }
                if (clientScheme != null)
                {
                    //Filtro por Esquema
                    sConsulta.AppendFormat("INNER JOIN ClienteEsquema AS D (NOLOCK) ON C.ClienteClave = D.ClienteClave INNER JOIN Esquema AS E (NOLOCK) ON D.EsquemaID = E.EsquemaID AND E.Tipo = 1 AND E.EsquemaID IN (SELECT Datos FROM FNSplit('{0}', ',')) ", clientScheme);
                }
                //Filtro por Estado
                sConsulta.AppendFormat("WHERE C.TipoEstado IN ({0})", state ?? "1");
                QueryString = sConsulta.ToString();
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetSellers*/
        [HttpGet]
        public IHttpActionResult GetSellers(string cedis = null, string state = null)
        {
            try
            {
                cedis = report.AllFilter(cedis, null);
                state = report.AllFilter(state, null);

                sConsulta.Append("SELECT VEN.VendedorId AS Clave, VEN.Nombre AS Nombre FROM Vendedor AS VEN (NOLOCK) INNER JOIN (SELECT V1.VendedorId, V1.AlmacenId FROM VENCentroDistHist AS V1 (NOLOCK) INNER JOIN (SELECT VendedorId, MAX(FechaFinal) AS FechaFinal FROM VENCentroDistHist (NOLOCK) GROUP BY VendedorId) V2 ON V1.VendedorId = V2.VendedorId AND V1.FechaFinal = V2.FechaFinal) AS VENDIS ON VEN.VendedorID = VENDIS.VendedorId ");
                if (cedis != null)
                {
                    sConsulta.AppendFormat("INNER JOIN Almacen AS ALM (NOLOCK) ON VENDIS.AlmacenId = ALM.AlmacenID AND ALM.AlmacenID IN (SELECT Datos FROM FNSplit('{0}', ',')) ", cedis);
                }
                sConsulta.AppendFormat("WHERE VEN.TipoEstado IN ({0}) ORDER BY VEN.Nombre", state ?? "1");
                QueryString = sConsulta.ToString();
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetLots*/
        [HttpGet]
        public IHttpActionResult GetLots(string state = null)
        {
            try
            {
                state = report.AllFilter(state, null);

                QueryString = string.Format("SELECT LC.Lote AS Clave, LC.Caducidad AS Nombre FROM LoteCaducidad AS LC (NOLOCK) WHERE LC.Estado IN ({0})", state ?? "1");
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
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

                sConsulta.Append("SELECT DISTINCT P.ProductoClave AS Clave, P.Nombre AS Nombre FROM Producto AS P (NOLOCK) ");
                if (productSchemes != null)
                {
                    sConsulta.AppendFormat("INNER JOIN ProductoEsquema AS PE (NOLOCK) ON P.ProductoClave = PE.ProductoClave WHERE PE.EsquemaID IN (SELECT Datos FROM FNSplit('{0}', ',')) ORDER BY Clave, Nombre", productSchemes);
                }
                QueryString = sConsulta.ToString();
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetSupervisors*/
        [HttpGet]
        public IHttpActionResult GetSupervisors(string cedis = null, string state = null)
        {
            try
            {
                cedis = report.AllFilter(cedis, null);
                state = report.AllFilter(state, null);

                sConsulta.Append("SELECT U.USUId AS Clave, U.Nombre AS Nombre, U.Clave AS Extra FROM Usuario AS U (NOLOCK) INNER JOIN VARValor AS V (NOLOCK) ON U.Tipo = V.VAVClave ");
                if (cedis != null)
                {
                    sConsulta.AppendFormat("INNER JOIN Almacen AS A (NOLOCK) ON U.AlmacenId = A.AlmacenId AND A.Clave IN (SELECT Datos FROM FNSplit('{0}', ',')) ", cedis);
                }
                sConsulta.AppendFormat("WHERE U.Activo IN ({0}) AND V.VARCodigo = 'BTIPUSO' AND V.Grupo = 'Supervisores' ORDER BY U.Clave", state ?? "1");
                QueryString = sConsulta.ToString();
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
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
                QueryString = "SELECT VAD.Descripcion AS Otro, CENClave AS Clave, CEN.Descripcion AS Nombre FROM ConfigEncuesta AS CEN (NOLOCK) INNER JOIN VAVDescripcion AS VAD (NOLOCK) ON CEN.Tipo = VAD.VAVClave AND VAD.VARCodigo = 'TENC' AND VAD.VADTipoLenguaje = 'EM'";
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }

        /*GetPriceList*/
        [HttpGet]
        public IHttpActionResult GetPriceList()
        {
            try
            {
                QueryString = "SELECT PRE.PrecioClave AS Clave, PRE.Nombre AS Nombre FROM Precio AS PRE (NOLOCK) WHERE PRE.TipoEstado = 1";
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
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
                sConsulta.Append("SELECT DISTINCT E.EsquemaID AS Clave, E.Clave + ' ' + E.Nombre AS Nombre FROM Esquema AS E (NOLOCK) ");
                if (types == "2")
                {
                    //Filtrado por Producto
                    sConsulta.Append("INNER JOIN ProductoEsquema AS PE (NOLOCK) ON PE.EsquemaID = E.EsquemaID INNER JOIN Producto AS P (NOLOCK) ON P.ProductoClave = PE.ProductoClave ");
                }
                else if (types == "1")
                {
                    //Filtrado por Cliente
                    sConsulta.Append("INNER JOIN ClienteEsquema AS CE (NOLOCK) ON CE.EsquemaID = E.EsquemaID ");
                    if (cedis != null)
                    {
                        sConsulta.AppendFormat("INNER JOIN Secuencia AS S (NOLOCK) ON S.ClienteClave = CE.ClienteClave INNER JOIN Ruta AS R (NOLOCK) ON R.RUTClave = S.RUTClave AND R.AlmacenID IN (SELECT AlmacenID FROM Almacen (NOLOCK) WHERE AlmacenID IN (SELECT Datos FROM FNSplit('{0}', ','))) ", cedis);
                    }
                }
                sConsulta.AppendFormat("WHERE E.TipoEstado IN ({0}) AND E.Tipo IN ({1}) AND E.Nivel IN ({2}) ", state ?? "1", types ?? "1", levels ?? "0");
                if (schemesID != null)
                {
                    sConsulta.AppendFormat("AND E.EsquemaIDPadre IN (SELECT Datos FROM FNSplit('{0}', ','))", schemesID);
                }
                QueryString = sConsulta.ToString();
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
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
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
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

                sConsulta.AppendFormat("SELECT DISTINCT A.AlmacenID AS Clave, A.Clave + ' ' + A.Nombre AS Nombre FROM UsuarioAlmacen AS UA (NOLOCK) INNER JOIN Almacen AS A (NOLOCK) ON A.AlmacenID = UA.AlmacenId WHERE A.TipoEstado IN ({0}) AND A.Tipo IN ({1}) AND ((UA.USUId = '{2}') OR '{2}' IS NULL)", state ?? "1", types ?? "1", USUId);
                QueryString = sConsulta.ToString();
                List = Connection.Query<ReportFilterModel>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }
    }
}
