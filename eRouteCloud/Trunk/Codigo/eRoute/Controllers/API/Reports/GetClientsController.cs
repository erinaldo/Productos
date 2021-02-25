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


namespace eRoute.Controllers.API.Reports
{
    public class GetClientsController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;
        StringBuilder sConsulta = new StringBuilder();

        [HttpGet]
        public IHttpActionResult GET(string Id, string Routes, string Cedis)
        {
            try
            {
                string pvCondition;
                if (Id == "Todos")
                {
                    if (!String.IsNullOrEmpty(Cedis))
                    {
                        QueryString = "select distinct C.ClienteClave, C.Clave, C.RazonSocial from Cliente C (NOLOCK) inner join Almacen A (NOLOCK) on C.AlmacenID = A.AlmacenID and A.AlmacenID = '" + Cedis + "'";
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(Routes))
                        {
                            QueryString = "SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial  FROM Cliente C (NOLOCK) inner join ClienteEsquema D (NOLOCK) on C.ClienteClave = D.ClienteClave inner join esquema E (NOLOCK) on D.EsquemaID = E.EsquemaID and E.tipo=1";
                        }
                        else
                        {
                            QueryString = "SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial  FROM Cliente C (NOLOCK) inner join ClienteEsquema D (NOLOCK) on C.ClienteClave = D.ClienteClave inner join esquema E (NOLOCK) on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S (NOLOCK) on S.ClienteClave=C.ClienteClave AND S.RUTClave IN (" + Routes + ")";
                        }
                    }
                }
                else
                {
                    pvCondition = "and E.EsquemaID = '" + Id + "'";
                    if (!String.IsNullOrEmpty(Cedis))
                    {
                        QueryString = "select distinct C.ClienteClave, C.Clave, C.RazonSocial from Cliente C (NOLOCK) inner join Almacen A (NOLOCK) on C.AlmacenID = A.AlmacenID and A.Clave = '" + Cedis + "' inner join esquema E (NOLOCK) on D.EsquemaID = E.EsquemaID and E.tipo=1 " + pvCondition;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(Routes))
                        {
                            QueryString = "SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial FROM Cliente C (NOLOCK) inner join ClienteEsquema D (NOLOCK) on C.ClienteClave = D.ClienteClave inner join esquema E (NOLOCK) on D.EsquemaID = E.EsquemaID and E.tipo=1 " + pvCondition;
                        }
                        else
                        {
                            QueryString = "SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial  FROM Cliente C (NOLOCK) inner join ClienteEsquema D (NOLOCK) on C.ClienteClave = D.ClienteClave inner join esquema E (NOLOCK) on D.EsquemaID = E.EsquemaID and E.tipo=1 " + pvCondition + " inner join Secuencia S (NOLOCK) on S.ClienteClave=C.ClienteClave AND S.RUTClave IN (" + Routes + ")";
                        }
                    }
                }
                List<Clients> List = Connection.Query<Clients>(QueryString).ToList();
                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        [ActionName("ObtenerListaClientes")]
        public IHttpActionResult ObtenerListaClientes(string IdEsquema, string Routes, string Cedis)
        {
            String query = "select distinct c.ClienteClave, c.Clave, c.RazonSocial from ";
            try
            {
                /*Consulta para cuando hay un centro de distribucion, todas las rutas mostradas y/o seleccionadas y hay un esquema*/
                if ((Routes.Equals("Ninguna")) && !(IdEsquema.Equals("Ninguno")))
                {
                    QueryString = query + "ClienteEsquema ce (NOLOCK) inner join Cliente c (NOLOCK) on c.ClienteClave = ce.ClienteClave and c.AlmacenID = '" + Cedis + "' and ce.EsquemaID ='" + IdEsquema + "'";
                }
                else if (!(Routes.Equals("Ninguna")) && IdEsquema.Equals("Ninguno"))
                {
                    /*Consulta cuando hay un cedis, hay rutas seleccionadas y no hay esquemas seleccionados*/
                    QueryString = query + "Secuencia s (NOLOCK) inner join Cliente c (NOLOCK) on s.ClienteClave = c.ClienteClave and s.RUTClave in (" + Routes + ")";
                }
                else if (!(Routes.Equals("Ninguna")) && !(IdEsquema.Equals("Ninguno")))
                {
                    /*Consulta cuando hay un cedis, hay rutas seleccionadas y hay un esquema*/
                    QueryString = query + "Secuencia s (NOLOCK) inner join Cliente c (NOLOCK) on s.ClienteClave = c.ClienteClave and s.RUTClave in (" + Routes + ") inner join  ClienteEsquema ce (NOLOCK) on ce.ClienteClave = c.ClienteClave and ce.EsquemaID ='" + IdEsquema + "'";
                }
                List<Clients> List = Connection.Query<Clients>(QueryString).ToList();
                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }



        //Filtrar Clientes por Vendedor en base a sus visitas
        [HttpGet]
        public IHttpActionResult GET(string Sellers, string Cedis)
        {
            try
            {
                if (!String.IsNullOrEmpty(Cedis))
                {
                    QueryString = "select distinct C.ClienteClave, C.Clave, C.RazonSocial from Cliente C (NOLOCK) inner join Almacen A (NOLOCK) on C.AlmacenID = A.AlmacenID and A.AlmacenID = '" + Cedis + "'";
                }
                else
                {
                    if (String.IsNullOrEmpty(Sellers))
                    {
                        QueryString = "SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial, V.RUTClave  FROM Cliente C (NOLOCK) inner join ClienteEsquema D (NOLOCK) on C.ClienteClave = D.ClienteClave inner join esquema E (NOLOCK) on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S (NOLOCK) on S.ClienteClave=C.ClienteClave inner join Visita V (NOLOCK) on S.RUTClave = V.RUTClave";
                    }
                    else
                    {
                        QueryString = "SELECT distinct c.ClienteClave,c.Clave,C.RazonSocial, V.RUTClave  FROM Cliente C (NOLOCK) inner join ClienteEsquema D (NOLOCK) on C.ClienteClave = D.ClienteClave inner join esquema E (NOLOCK) on D.EsquemaID = E.EsquemaID and E.tipo=1 inner join Secuencia S (NOLOCK) on S.ClienteClave=C.ClienteClave inner join Visita V (NOLOCK) on S.RUTClave = V.RUTClave AND V.VendedorID IN (" + Sellers + ")";
                    }
                }
                List<Clients> List = Connection.Query<Clients>(QueryString).ToList();
                return Ok(List);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GETClients(string cedis = null, string state = null, string clientScheme = null, string routes = null, string sellers = null, bool visit = false)
        {
            try
            {
                ReportGetCondition report = new ReportGetCondition();
                cedis = report.AllFilter(cedis, null);
                state = report.AllFilter(state, null);
                clientScheme = report.AllFilter(clientScheme, null);
                routes = report.AllFilter(routes, null);
                sellers = report.AllFilter(sellers, null);

                //Consulta general
                sConsulta.Append("SELECT DISTINCT C.ClienteClave, C.Clave, C.RazonSocial FROM Cliente C (NOLOCK) ");
                if (cedis != null)
                {
                    //Filtrado por Almacen
                    sConsulta.Append("INNER JOIN Almacen A (NOLOCK) ON C.AlmacenID = A.AlmacenID AND A.AlmacenID = '" + cedis + "' ");
                }
                else if (routes != null || sellers != null)
                {
                    //Filtrado por Rutas o Vendedores
                    sConsulta.Append("INNER JOIN Secuencia S (NOLOCK) ON S.ClienteClave = C.ClienteClave ");
                    if (routes != null)
                    {
                        //Por Rutas
                        sConsulta.Append("AND S.RUTClave IN (" + routes + ") ");
                    }
                    else if (sellers != null)
                    {
                        if (visit) {
                            //Por Vendedores en base a sus visitas
                            sConsulta.Append("INNER JOIN Visita V (NOLOCK) ON S.RUTClave = V.RUTClave AND V.VendedorID IN (" + sellers + ")) ");
                        }
                        else
                        {
                            //Por Vendedores
                            sConsulta.Append("AND S.RUTClave IN (SELECT RUTClave FROM VenRut (NOLOCK) WHERE VendedorID IN (" + sellers + ")) ");
                        }
                    }
                }
                if (clientScheme != null)
                {
                    //Filtro por Esquema
                    sConsulta.Append("INNER JOIN ClienteEsquema D (NOLOCK) ON C.ClienteClave = D.ClienteClave INNER JOIN Esquema E (NOLOCK) ON D.EsquemaID = E.EsquemaID AND E.Tipo = 1 AND E.EsquemaID IN (" + clientScheme + ") ");
                }
                //Filtro por Estado
                sConsulta.Append("WHERE C.TipoEstado IN (" + (state == null ? "1" : state) + ")");
                QueryString = sConsulta.ToString();
                List<Clients> List = Connection.Query<Clients>(QueryString).ToList();
                return Ok(List);
            }
            catch { return InternalServerError(); }
        }
    }

    public class Clients
    {
        public string ClienteClave { get; set; }
        public string Clave { get; set; }
        public string RazonSocial { get; set; }
        public bool Checked { get; set; }
    }


}
