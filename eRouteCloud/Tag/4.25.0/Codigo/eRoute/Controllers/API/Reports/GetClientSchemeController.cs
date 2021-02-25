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
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text;

namespace eRoute.Controllers.API.Reports
{
    public class GetClientSchemeController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        public IHttpActionResult GET()
        {
            try
            {
                QueryString = "SELECT Nombre, EsquemaID, EsquemaIDPadre From Esquema where tipo =1";
                List<ClientSchemaModel> List = Connection.Query<ClientSchemaModel>(QueryString).ToList();
                List<ClientSchemaModel> Parents = new List<ClientSchemaModel>();

                Parents = (from c in List
                           where c.EsquemaIDPadre == null
                           select c).ToList();

                List<Child> tree = new List<Child>();
                Child node = new Child();
                foreach (var x in Parents)
                {
                    List<Child> child = new List<Child>();
                    Child ch = new Child();
                    ch.id = x.EsquemaID;
                    ch.label = x.Nombre;
                    foreach (var c in List)
                    {
                        if (c.EsquemaIDPadre == x.EsquemaID)
                        {
                            List<Child> child2 = new List<Child>();
                            Child ch2 = new Child();
                            ch2.id = c.EsquemaID;
                            ch2.label = c.Nombre;
                            foreach (var t in List)
                            {
                                Child ch3 = new Child();
                                if (t.EsquemaIDPadre == c.EsquemaID)
                                {
                                    ch3.id = t.EsquemaID;
                                    ch3.label = t.Nombre;
                                    ch3.collapsed = true;
                                    child2.Add(ch3);
                                }
                            }
                            ch2.collapsed = true;
                            ch2.children = child2;
                            child.Add(ch2);
                        }
                    }
                    ch.children = child;
                    ch.collapsed = true;
                    tree.Add(ch);
                }
                node.label = "Todos";
                node.id = "Todos";
                node.children = tree;
                node.collapsed = false;

                string json = JsonConvert.SerializeObject(node);

                string parse = "[ " + json + " ]";
                return Json(parse);
            }
            catch
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        [ActionName("ObtenerEsquemaClientes")]
        public IHttpActionResult ObtenerEsquemaClientes(string cedis, string estado = null)
        {
            QueryString = "SELECT DISTINCT e.EsquemaID,e.Nombre FROM Ruta r (NOLOCK) "
                            + "INNER JOIN Secuencia s (NOLOCK) ON r.RUTClave = s.RUTClave "
                            + "INNER JOIN ClienteEsquema ce (NOLOCK) ON ce.ClienteClave = s.ClienteClave "
                            + "INNER JOIN Esquema e (NOLOCK) ON ce.EsquemaID = e.EsquemaID and e.TipoEstado in (" + (estado == null ? "0,1" : estado) + ") "
                            + "WHERE r.RUTClave IN (SELECT ru.RUTClave FROM Ruta ru (NOLOCK) INNER JOIN Almacen al (NOLOCK) ON ru.AlmacenId = al.AlmacenID WHERE al.AlmacenID = '" + cedis + "')";

            List<ClientSchemaModel> List = Connection.Query<ClientSchemaModel>(QueryString).ToList();

            return Json(List);
        }

    }

    class TreeList
    {
        public List<Child> Children { get; set; }
    }

    class Child
    {
        public string label { get; set; }
        public string id { get; set; }
        public List<Child> children { get; set; }
        public bool collapsed { get; set; }
    }


    class Test
    {
        public string label { get; set; }
        public string id { get; set; }
    }

    public class ClientSchemaModel
    {
        public string Nombre { get; set; }
        public string EsquemaID { get; set; }
        public string EsquemaIDPadre { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}
