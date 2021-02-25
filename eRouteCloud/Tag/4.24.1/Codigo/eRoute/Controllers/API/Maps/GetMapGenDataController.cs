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
                string leng = "EM";

                StringBuilder Query = new StringBuilder();
                StringBuilder QueryOutRange = new StringBuilder();

                Query.AppendLine("select * from (");
                Query.AppendLine("");

                //no visitados
                Query.AppendLine("select null as distanciagps,");
                Query.AppendLine("'No' as GPSLeido,");
                Query.AppendLine("null as fuerafrecuencia,");
                Query.AppendLine("ag.orden as ordenagenda,");
                Query.AppendLine("'No Visitado' as improductividad,");
                Query.AppendLine("null as ordenvisita,");
                Query.AppendLine("null as total,");
                Query.AppendLine("'No' as codigoleido,");
                Query.AppendLine("null as FechaHoraInicial,");
                Query.AppendLine("0 as visitado");
                Query.AppendLine(",cd.CoordenadaX,cd.CoordenadaY,c.clave,c.razonsocial");
                Query.AppendLine("from agendavendedor ag");
                Query.AppendLine("inner join cliente c on c.ClienteClave =ag.clienteclave");
                Query.AppendLine("inner join ClienteDomicilio  cd on cd.clienteclave=  c.ClienteClave and cd.tipo=2 ");
                Query.AppendLine("where ag.RUTClave='" + test.Route + "' and  ag.DiaClave='" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' and not (cd.CoordenadaX is null or cd.CoordenadaX = 0) and ag.clienteclave not in(select clienteclave from visita v where v.RUTClave='" + test.Route + "' and v.DiaClave='" + DateToQuery.Date.ToString("dd/MM/yyyy") + "')");
                Query.AppendLine("union all");

                //'visitados
                Query.AppendLine("select v.distanciagps,");
                Query.AppendLine("(case when v.GPSLeido=1 then 'Si' else 'No' end)as GPSLeido,");
                Query.AppendLine("v.fuerafrecuencia,");
                Query.AppendLine("ag.orden as ordenagenda,");
                Query.AppendLine("(select descripcion from vavdescripcion where varcodigo ='motimpro' and vadtipolenguaje ='" + leng + "' and vavclave = im.tipomotivo)as improductividad,");
                Query.AppendLine("v.numero as ordenvisita,");
                Query.AppendLine("sum(t.total),");
                Query.AppendLine("(case when v.codigoleido=1 then 'Si' else 'No' end)as codigoleido,");
                Query.AppendLine("v.FechaHoraInicial,");
                Query.AppendLine("1 as visitado,");
                Query.AppendLine("cd.CoordenadaX , ");
                Query.AppendLine("cd.CoordenadaY, ");
                Query.AppendLine("c.clave,c.razonsocial");
                Query.AppendLine("from visita v ");
                Query.AppendLine("inner join cliente c on c.ClienteClave =v.clienteclave");
                Query.AppendLine("inner join ClienteDomicilio  cd on cd.clienteclave=  c.ClienteClave and cd.tipo=2");
                Query.AppendLine("left join agendavendedor ag on v.diaclave=ag.diaclave and v.rutclave=ag.rutclave and V.clienteclave=ag.clienteclave");
                Query.AppendLine("left join transprod t on t.visitaclave=t.visitaclave and c.clienteclave=t.clienteclave and t.diaclave=v.diaclave");
                Query.AppendLine("left join improductividadventa im on v.visitaclave=im.visitaclave and v.diaclave=im.diaclave");
                Query.AppendLine("where v.RUTClave='" + test.Route + "' and v.DiaClave='" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' ");
                Query.AppendLine("and not((cd.CoordenadaX is null or cd.CoordenadaX = 0)) ");
                Query.AppendLine("group by v.distanciagps,GPSLeido,v.fuerafrecuencia,ag.orden,im.TipoMotivo,v.numero,v.codigoleido,v.fechahorainicial, ");
                Query.AppendLine("v.VisitaClave, cd.CoordenadaX, cd.CoordenadaY, c.clave, c.razonsocial ");
                Query.AppendLine("");
                Query.AppendLine(")as t1");
                Query.AppendLine("order by ordenvisita");

                //visitados fuera de rango
                QueryOutRange.AppendLine("select v.distanciagps,");
                QueryOutRange.AppendLine("(case when v.GPSLeido=1 then 'Si' else 'No' end)as GPSLeido,");
                QueryOutRange.AppendLine("v.fuerafrecuencia,");
                QueryOutRange.AppendLine("ag.orden as ordenagenda,");
                QueryOutRange.AppendLine("(select descripcion from vavdescripcion where varcodigo ='motimpro' and vadtipolenguaje ='" + leng + "' and vavclave = im.tipomotivo)as improductividad,");
                QueryOutRange.AppendLine("v.numero as ordenvisita,");
                QueryOutRange.AppendLine("sum(t.total) as Total,");
                QueryOutRange.AppendLine("(case when v.codigoleido=1 then 'Si' else 'No' end)as codigoleido,");
                QueryOutRange.AppendLine("v.FechaHoraInicial,");
                QueryOutRange.AppendLine("1 as visitado,");
                QueryOutRange.AppendLine("p.CoordenadaX , ");
                QueryOutRange.AppendLine("p.CoordenadaY, ");
                QueryOutRange.AppendLine("c.clave,c.razonsocial");
                QueryOutRange.AppendLine("from visita v ");
                QueryOutRange.AppendLine("inner join PuntoGPS p on v.VisitaClave = p.VisitaClave and v.DiaClave = p.DiaClave1 ");
                QueryOutRange.AppendLine("inner join cliente c on c.ClienteClave =v.clienteclave");
                QueryOutRange.AppendLine("inner join ClienteDomicilio  cd on cd.clienteclave=  c.ClienteClave and cd.tipo=2");
                QueryOutRange.AppendLine("left join agendavendedor ag on v.diaclave=ag.diaclave and v.rutclave=ag.rutclave and V.clienteclave=ag.clienteclave");
                QueryOutRange.AppendLine("left join transprod t on t.visitaclave=t.visitaclave and c.clienteclave=t.clienteclave and t.diaclave=v.diaclave");
                QueryOutRange.AppendLine("left join improductividadventa im on v.visitaclave=im.visitaclave and v.diaclave=im.diaclave");
                QueryOutRange.AppendLine("where v.RUTClave='" + test.Route + "' and v.DiaClave='" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' ");
                QueryOutRange.AppendLine("and not((cd.CoordenadaX is null or cd.CoordenadaX = 0)) and not v.Distanciagps is null");
                QueryOutRange.AppendLine("group by v.distanciagps,GPSLeido,v.fuerafrecuencia,ag.orden,im.TipoMotivo,v.numero,v.codigoleido,v.fechahorainicial, ");
                QueryOutRange.AppendLine("v.VisitaClave, p.CoordenadaX, p.CoordenadaY, c.clave, c.razonsocial ");
                QueryOutRange.AppendLine("");


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
                Query.AppendLine("select MFechaHora as FechaHoraInicial, 0 as visitado, CoordenadaX, CoordenadaY ");
                Query.AppendLine("from PuntoGPS ");
                Query.AppendLine("where RUTClave = '" + test.Route + "' and DiaClave = '" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' ");
                Query.AppendLine("order by MFechaHora ");
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
