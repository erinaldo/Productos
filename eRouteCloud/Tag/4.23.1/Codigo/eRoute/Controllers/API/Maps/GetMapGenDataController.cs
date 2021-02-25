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
using System.ComponentModel.DataAnnotations;

namespace eRoute.Controllers.API.Maps
{
    //public class SetMapDataModel
    //{
    //    [Required]
    //    public string Route { get; set; }
    //    [Required]
    //    public string Date { get; set; }
    //}

    public class GetMapGenDataController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        //string QueryString;

        [HttpPost]
        public IHttpActionResult POST([FromBody] SetMapDataModel test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Verificar campos vacíos");
            }

            try
            {
                DateTime DateToQuery = DateTime.Parse(test.Date);

                StringBuilder Query = new StringBuilder();
                StringBuilder QueryOutRange = new StringBuilder();

                /* Visitados Y No Visitados */
                Query.AppendLine("EXEC [dbo].[stpr_MW001Logistica]");
                Query.AppendLine(string.Format("@filterRoute = '{0}',", test.Route));
                Query.AppendLine(string.Format("@filterStartDate = '{0:dd/MM/yyyy}',", DateToQuery.Date));
                Query.AppendLine("@filterQueryNumber = 2");

                /* Visitados Fuera De Rango */
                QueryOutRange.AppendLine("EXEC [dbo].[stpr_MW001Logistica]");
                QueryOutRange.AppendLine(string.Format("@filterRoute = '{0}',", test.Route));
                QueryOutRange.AppendLine(string.Format("@filterStartDate = '{0:dd/MM/yyyy}',", DateToQuery.Date));
                QueryOutRange.AppendLine("@filterQueryNumber = 1");

                List<MapGenDataModel> List = Connection.Query<MapGenDataModel>(Query.ToString()).ToList();
                List<MapGenDataModel> ListOutRange = Connection.Query<MapGenDataModel>(QueryOutRange.ToString()).ToList();

                if (List.Count <= 0)
                {
                    return BadRequest("No existen registros que coincidan con los filtros");
                }

                MapGenListDataModel FilterLists = new MapGenListDataModel();
                List<MapGenDataModel> nVisit = new List<MapGenDataModel>();
                List<MapGenDataModel> outFreq = new List<MapGenDataModel>();
                List<MapGenDataModel> Freq = new List<MapGenDataModel>();
                List<MapGenDataModel> Real = new List<MapGenDataModel>();
                List<MapGenDataModel> Configurada = new List<MapGenDataModel>();
                List<Coordinates> Coord = (from c in List
                                           select new Coordinates { x = c.CoordenadaX, y = c.CoordenadaY }).ToList();

                var Coord2 = Coord.GroupBy(i => new { i.x, i.y }).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                double minX = Double.MaxValue;
                double minY = Double.MaxValue;
                double maxX = Double.MinValue;
                double maxY = Double.MinValue;

                foreach (var x in List)
                {

                    if (x.CoordenadaY > maxY) { maxY = x.CoordenadaY; }
                    if (x.CoordenadaY < minY) { minY = x.CoordenadaY; }
                    if (x.CoordenadaX > maxX) { maxX = x.CoordenadaX; }
                    if (x.CoordenadaX < minX) { minX = x.CoordenadaX; }

                    if (x.visitado == "0")
                    {
                        nVisit.Add(x);
                    }
                    if (x.fuerafrecuencia == "True")
                    {
                        x.spanColor = "#FF0000";
                        outFreq.Add(x);
                    }
                    if (x.fuerafrecuencia == "False")
                    {
                        x.spanColor = "#0049b9";
                        Freq.Add(x);
                    }
                    if (x.visitado == "1")
                    {
                        Real.Add(x);
                    }
                    if (x.fuerafrecuencia == null)
                    {
                        Configurada.Add(x);
                    }
                    if (x.fuerafrecuencia == "False")
                    {
                        Configurada.Add(x);
                    }
                }

                foreach (var x in outFreq)
                {
                    foreach (var y in Coord2)
                    {
                        if (y.x == x.CoordenadaX && y.y == x.CoordenadaY)
                        {
                            x.spanColor = "#3dbf09";
                        }
                    }
                }

                foreach (var x in Freq)
                {
                    foreach (var y in Coord2)
                    {
                        if (y.x == x.CoordenadaX && y.y == x.CoordenadaY)
                        {
                            x.spanColor = "#3dbf09";
                        }
                    }
                }


                Configurada = (from c in Configurada
                               orderby c.ordenagenda ascending
                               select c).ToList();


                Query = new StringBuilder();
                Query.AppendLine("EXEC [dbo].[stpr_MW001Logistica]");
                Query.AppendLine(string.Format("@filterRoute = '{0}',", test.Route));
                Query.AppendLine(string.Format("@filterStartDate = '{0:dd/MM/yyyy}',", DateToQuery.Date));
                Query.AppendLine("@filterQueryNumber = 3");
                List<MapGenDataModel> Tracking = Connection.Query<MapGenDataModel>(Query.ToString()).ToList();

                int nCont = 1;
                foreach (var x in Tracking)
                {
                    x.ordenagenda = nCont;
                    x.spanColor = "#660066";//"#ff6600";
                    nCont++;
                }

                FilterLists.ListFreq = Freq;
                FilterLists.ListOutFreq = outFreq;
                FilterLists.ListNoVisit = nVisit;
                FilterLists.ListReal = Real;
                FilterLists.ListAgenda = Configurada;
                FilterLists.ListOutRange = ListOutRange;
                FilterLists.ListTracking = Tracking;
                FilterLists.latitude = minX;
                FilterLists.longitude = maxY;

                return Json(FilterLists);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
    
    public class MapGenListDataModel
    {
        public List<MapGenDataModel> ListFreq { get; set; }
        public List<MapGenDataModel> ListOutFreq { get; set; }
        public List<MapGenDataModel> ListNoVisit { get; set; }
        public List<MapGenDataModel> ListReal { get; set; }
        public List<MapGenDataModel> ListAgenda { get; set; }
        public List<MapGenDataModel> ListOutRange { get; set; }
        public List<MapGenDataModel> ListTracking { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class MapGenDataModel
    {
        public double distanciagps { get; set; }
        public string GPSLeido { get; set; }
        public string fuerafrecuencia { get; set; }
        public int ordenagenda { get; set; }
        public string improductividad { get; set; }
        public string ordenvisita { get; set; }
        public string total { get; set; }
        public string codigoleido { get; set; }
        public string FechaHoraInicial { get; set; }
        public string visitado { get; set; }
        public double CoordenadaX { get; set; }
        public double CoordenadaY { get; set; }
        public string Clave { get; set; }
        public string razonsocial { get; set; }
        public string spanColor { get; set; }
    }

    //public class Coordinates
    //{
    //    public double x { get; set; }
    //    public double y { get; set; }
    //}

}
