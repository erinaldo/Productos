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
    public class SetMapDataModel
    {
        [Required]
        public string Route { get; set; }
        [Required]
        public string Date { get; set; }
    }

    public class GetMapDataController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        //string QueryString;
        private string QueryString = "";

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
                Query.AppendLine("0 as visitado,");
                Query.AppendLine("cd.CoordenadaX as CoordenadaXD,cd.CoordenadaY as CoordenadaYD,");
                Query.AppendLine("null as CoordenadaXV, null as CoordenadaYV,");
                Query.AppendLine("c.clave,c.razonsocial, cd.Colonia, cd.Poblacion ");
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
                Query.AppendLine("'$' + convert(varchar, round(sum(t.total), 2)) as total,");
                Query.AppendLine("(case when v.codigoleido=1 then 'Si' else 'No' end)as codigoleido,");
                Query.AppendLine("v.FechaHoraInicial,");
                Query.AppendLine("1 as visitado,");
                Query.AppendLine("cd.CoordenadaX as CoordenadaXD, cd.CoordenadaY as CoordenadaYD, ");
                Query.AppendLine("p.CoordenadaX as CoordenadaXV, p.CoordenadaY as CoordenadaYV, ");
                Query.AppendLine("c.clave,c.razonsocial, cd.Colonia, cd.Poblacion ");
                Query.AppendLine("from visita v ");
                Query.AppendLine("inner join Ruta r on v.RUTClave = r.RUTClave ");
                Query.AppendLine("inner join cliente c on c.ClienteClave =v.clienteclave");
                Query.AppendLine("inner join PuntoGPS p on v.VisitaClave = p.VisitaClave and v.DiaClave = p.DiaClave1 ");
                Query.AppendLine("inner join ClienteDomicilio  cd on cd.clienteclave=  c.ClienteClave and cd.tipo=2 ");
                Query.AppendLine("left join agendavendedor ag on v.diaclave=ag.diaclave and v.rutclave=ag.rutclave and V.clienteclave=ag.clienteclave");
                Query.AppendLine("left join transprod t on isnull(t.VisitaClave1, t.VisitaClave)=v.VisitaClave and isnull(t.DiaClave1, t.DiaClave)=v.DiaClave and t.Tipo = 1 and ((r.Tipo = 2 and t.TipoFase = 1) or (r.Tipo != 2 and t.TipoFase in (2, 3)))");
                Query.AppendLine("left join improductividadventa im on v.visitaclave=im.visitaclave and v.diaclave=im.diaclave");
                Query.AppendLine("where v.RUTClave='" + test.Route + "' and v.DiaClave='" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' ");
                Query.AppendLine("and not(p.CoordenadaX is null or p.CoordenadaX = 0) and not(cd.CoordenadaX is null or cd.CoordenadaX = 0) ");
                Query.AppendLine("group by v.distanciagps,GPSLeido,v.fuerafrecuencia,ag.orden,im.TipoMotivo,v.numero,v.codigoleido,v.fechahorainicial, ");
                Query.AppendLine("v.VisitaClave, cd.CoordenadaX, cd.CoordenadaY, p.CoordenadaX, p.CoordenadaY, c.clave, c.razonsocial, cd.Colonia, cd.Poblacion ");
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
                QueryOutRange.AppendLine("cd.CoordenadaX as CoordenadaXD, cd.CoordenadaY as CoordenadaYD, ");
                QueryOutRange.AppendLine("p.CoordenadaX as CoordenadaXV, p.CoordenadaY as CoordenadaYV, ");
                QueryOutRange.AppendLine("c.clave,c.razonsocial ");
                QueryOutRange.AppendLine("from visita v ");
                QueryOutRange.AppendLine("inner join PuntoGPS p on v.VisitaClave = p.VisitaClave and v.DiaClave = p.DiaClave1 ");
                QueryOutRange.AppendLine("inner join cliente c on c.ClienteClave =v.clienteclave");
                QueryOutRange.AppendLine("inner join ClienteDomicilio  cd on cd.clienteclave=  c.ClienteClave and cd.tipo=2");
                QueryOutRange.AppendLine("left join agendavendedor ag on v.diaclave=ag.diaclave and v.rutclave=ag.rutclave and V.clienteclave=ag.clienteclave");
                QueryOutRange.AppendLine("left join transprod t on t.visitaclave=t.visitaclave and c.clienteclave=t.clienteclave and t.diaclave=v.diaclave");
                QueryOutRange.AppendLine("left join improductividadventa im on v.visitaclave=im.visitaclave and v.diaclave=im.diaclave");
                QueryOutRange.AppendLine("inner join Vendedor ven on v.VendedorID = ven.VendedorID");
                QueryOutRange.AppendLine("inner join AseguramientoVisita ase on ven.MCNClave = ase.MCNClave");
                QueryOutRange.AppendLine("where v.RUTClave='" + test.Route + "' and v.DiaClave='" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' ");
                QueryOutRange.AppendLine("and not(p.CoordenadaX is null or p.CoordenadaX = 0) and not(cd.CoordenadaX is null or cd.CoordenadaX = 0) and not v.Distanciagps is null and v.DistanciaGPS > ase.LimiteGPS");
                QueryOutRange.AppendLine("group by v.distanciagps,GPSLeido,v.fuerafrecuencia,ag.orden,im.TipoMotivo,v.numero,v.codigoleido,v.fechahorainicial, ");
                QueryOutRange.AppendLine("v.VisitaClave, cd.CoordenadaX, cd.CoordenadaY, p.CoordenadaX, p.CoordenadaY, c.clave, c.razonsocial ");
                QueryOutRange.AppendLine("");


                QueryString = "";

                QueryString = QueryOutRange.ToString();


                List<MapDataModel> cfdi = Connection.Query<MapDataModel>(QueryString, null, null, true, 600).ToList();

                List<MapDataModel> List = Connection.Query<MapDataModel>(Query.ToString()).ToList();
                List<MapDataModel> ListOutRange = Connection.Query<MapDataModel>(QueryOutRange.ToString()).ToList();

                if (List.Count <= 0)
                {
                    return BadRequest("No existen registros que coincidan con los filtros");
                }

                MapListDataModel FilterLists = new MapListDataModel();
                List<MapDataModel> nVisit = new List<MapDataModel>();
                List<MapDataModel> outFreq = new List<MapDataModel>();
                List<MapDataModel> Freq = new List<MapDataModel>();
                List<MapDataModel> Real = new List<MapDataModel>();
                List<MapDataModel> Configurada = new List<MapDataModel>();
                //List<Coordinates> CoordReal = (from c in List
                //                           select new Coordinates { x = c.CoordenadaXV, y = c.CoordenadaYV }).ToList();
                //List<Coordinates> CoordConfig = (from c in List
                //                               select new Coordinates { x = c.CoordenadaXD, y = c.CoordenadaYD }).ToList();

                //var Coord2 = Coord.GroupBy(i => new { i.x, i.y }).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                double minX = Double.MaxValue;
                double minY = Double.MaxValue;
                double maxX = Double.MinValue;
                double maxY = Double.MinValue;

                foreach (var x in List)
                {

                    if (x.CoordenadaYV > maxY) { maxY = x.CoordenadaYV; }
                    if (x.CoordenadaYV < minY) { minY = x.CoordenadaYV; }
                    if (x.CoordenadaXV > maxX) { maxX = x.CoordenadaXV; }
                    if (x.CoordenadaXV < minX) { minX = x.CoordenadaXV; }

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

                Configurada = (from c in Configurada
                               orderby c.ordenagenda ascending
                               select c).ToList();

                Query = new StringBuilder();
                Query.AppendLine("select v.DistanciaGPS, (case when v.GPSLeido = 1 then 'Si' else 'No' end) as GPSLeido, v.FueraFrecuencia, ag.Orden as OrdenAgenda, ");
                Query.AppendLine("(select Descripcion from VAVDescripcion where VARCodigo = 'MOTIMPRO' and VADTipoLenguaje = '" + leng + "' and VAVClave = im.TipoMotivo)as Improductividad, ");
                Query.AppendLine("v.Numero as OrdenVisita, 0 as Total, (case when v.CodigoLeido = 1 then 'Si' else 'No' end)as CodigoLeido, v.FechaHoraInicial, ");
                Query.AppendLine("1 as Visitado, null as CoordenadaXD, null as CoordenadaYD, p.CoordenadaX as CoordenadaXV, p.CoordenadaY as CoordenadaYV, c.Clave, c.RazonSocial ");
                Query.AppendLine("from Visita v ");
                Query.AppendLine("inner join Cliente c on c.ClienteClave = v.ClienteClave ");
                Query.AppendLine("left join AgendaVendedor ag on v.DiaClave = ag.DiaClave and v.RUTClave = ag.RUTClave and v.ClienteClave = ag.ClienteClave ");
                Query.AppendLine("left join ImproductividadVenta im on v.VisitaClave = im.VisitaClave and v.DiaClave = im.DiaClave ");
                Query.AppendLine("inner join PuntoGPS p on v.VisitaClave = p.VisitaClave and v.DiaClave = p.DiaClave1 ");
                Query.AppendLine("where v.RUTClave = '" + test.Route + "' and v.DiaClave = '" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' and v.ClienteClave in (");
                Query.AppendLine("  select ClienteClave ");
                Query.AppendLine("  from Visita ");
                Query.AppendLine("  where RUTClave = '" + test.Route + "' and DiaClave = '" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' ");
                Query.AppendLine("  group by ClienteClave ");
                Query.AppendLine("  having count(VisitaClave) > 1) ");
                List<MapDataModel> cfdi1 = Connection.Query<MapDataModel>(QueryString, null, null, true, 600).ToList();
                QueryString = "";

                QueryString = QueryOutRange.ToString();
                List<MapDataModel> ListMasDeUnaVez = Connection.Query<MapDataModel>(Query.ToString()).ToList();

                Query = new StringBuilder();
                Query.AppendLine("select MFechaHora as FechaHoraInicial, 0 as visitado, CoordenadaX as CoordenadaXV, CoordenadaY as CoordenadaYV ");
                Query.AppendLine("from PuntoGPS ");
                Query.AppendLine("where RUTClave = '" + test.Route + "' and DiaClave = '" + DateToQuery.Date.ToString("dd/MM/yyyy") + "' ");
                Query.AppendLine("order by MFechaHora ");
                List<MapDataModel> cfdi2 = Connection.Query<MapDataModel>(QueryString, null, null, true, 600).ToList();
                QueryString = "";

                QueryString = QueryOutRange.ToString();
                List<MapDataModel> Tracking = Connection.Query<MapDataModel>(Query.ToString()).ToList();

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
                FilterLists.ListMasDeUnaVez = ListMasDeUnaVez;
                FilterLists.ListTracking = Tracking;
                FilterLists.latitude = minX;
                FilterLists.longitude = maxY;

                return Json(FilterLists);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }

    public class MapListDataModel
    {
        public List<MapDataModel> ListFreq { get; set; }
        public List<MapDataModel> ListOutFreq { get; set; }
        public List<MapDataModel> ListNoVisit { get; set; }
        public List<MapDataModel> ListReal { get; set; }
        public List<MapDataModel> ListAgenda { get; set; }
        public List<MapDataModel> ListOutRange { get; set; }
        public List<MapDataModel> ListMasDeUnaVez { get; set; }
        public List<MapDataModel> ListTracking { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class MapDataModel
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
        public double CoordenadaXD { get; set; }
        public double CoordenadaYD { get; set; }
        public double CoordenadaXV { get; set; }
        public double CoordenadaYV { get; set; }
        public string Clave { get; set; }
        public string razonsocial { get; set; }
        public string spanColor { get; set; }
        public string Colonia { get; set; }
        public string Poblacion { get; set; }
    }

    public class Coordinates
    {
        public double x { get; set; }
        public double y { get; set; }
    }

}
