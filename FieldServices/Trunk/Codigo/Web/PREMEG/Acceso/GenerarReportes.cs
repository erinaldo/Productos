using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;
using PREMEG.Reportes;
using System.Data;

namespace PREMEG.Acceso
{
    public class GenerarReportes
    {
        public enum DatosExistentes
        {
            Ninguno,
            Reporte,
            Mapa
        }
        public List<ValorReferencia> ObtenerReportes()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = from vr in contexto.ValorReferencia where vr.Clave == "REPWEB" && vr.Estado select vr;
                return lista.ToList();
            }
        }

        public DatosExistentes ValidarExistenciaInformacion(string tipo, DateTime fecha1, DateTime fecha2)
        {
            DatosExistentes res =  DatosExistentes.Ninguno;
            switch (tipo)
            {
                case "30":
                    res = ContratosNoInstalados.ValidarExistenciaInformacion(fecha1, fecha2);
                    break;
                case "31":
                    res = TiemposYMovimientos.ValidarExistenciaInformacion(fecha1, fecha2);
                    break;
                case "32":
                    res = AuditoriaDeCableado.ValidarExistenciaInformacion(fecha1, fecha2);
                    break;
                case "33":
                    res = AuditoriaDeVisitas.ValidarExistenciaInformacion(fecha1, fecha2);
                    break;
                case "34":
                    res = RutaDeCuadrillas.ValidarExistenciaInformacion(fecha1, fecha2);
                    break;
                case "35":
                    res = UbicacionEnTiempoReal.ValidarExistenciaInformacion(fecha1, fecha2);
                    break;
            }
            return res;
        }

        public void ConsultarReporte(string tipo, DateTime fecha1, DateTime fecha2, IGenerarReporte reporte)
        {

            reporte.Filtro = fecha1.ToString("dd/MM/yyyy") + (fecha1.CompareTo(fecha2.AddDays(-1)) == 0 ? "" : " - " + fecha2.ToString("dd/MM/yyyy"));

            
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                short ValorRef = Convert.ToInt16(tipo);
                reporte.Titulo = (from val in contexto.ValorReferencia where val.Valor == ValorRef select val.Descripcion).FirstOrDefault().ToString();
            }
            switch (tipo)
            {
                case "30":
                    reporte.PoblarTabla(ContratosNoInstalados.ConsultarReporte(fecha1,fecha2));
                    break;
                case "31":
                    reporte.PoblarTabla(TiemposYMovimientos.ConsultarReporte(fecha1, fecha2));
                    break;
                case "32":
                    reporte.HabilitarFotos(true);
                    reporte.PoblarTabla(AuditoriaDeCableado.ConsultarReporte(fecha1, fecha2));
                    break;
                case "33":
                    reporte.HabilitarFotos(true);
                    reporte.PoblarTabla(AuditoriaDeVisitas.ConsultarReporte(fecha1, fecha2));
                    break;
                case "34":
                    reporte.PoblarTabla(RutaDeCuadrillas.ConsultarReporte(fecha1, fecha2));
                    break;
                case "35":
                    reporte.PoblarTabla(UbicacionEnTiempoReal.ConsultarReporte(fecha1, fecha2));
                    break;
            }
        }

        public DataTable ObtenerDetalles(string tipo, string idNodo, DataTable tabla)
        {
            DataTable tablaRes = null;
            switch (tipo)
            {
                case "30":
                    tablaRes = ContratosNoInstalados.ObtenerDetalles(idNodo, tabla);
                    break;
                case "31":
                    tablaRes = TiemposYMovimientos.ObtenerDetalles(idNodo, tabla);
                    break;
                case "32":
                    tablaRes = AuditoriaDeCableado.ObtenerDetalles(idNodo, tabla);
                    break;
                case "33":
                    tablaRes = AuditoriaDeVisitas.ObtenerDetalles(idNodo, tabla);
                    break;
                case "34":
                    tablaRes = RutaDeCuadrillas.ObtenerDetalles(idNodo, tabla);
                    break;
                case "35":
                    tablaRes = UbicacionEnTiempoReal.ObtenerDetalles(idNodo, tabla);
                    break;
            }
            return tablaRes;
        }

        public Dictionary<string,Dictionary<string,string>> ObtenerParametros()
        {
            Dictionary<string, Dictionary<string, string>> res = new Dictionary<string, Dictionary<string, string>>();

            using (MODMEG.MegaCableEntities contexto = new MegaCableEntities())
            {
                var configuracion = from conf in contexto.Configuracion select conf;
                foreach (var conf in configuracion.OrderBy(c=> c.ClaveSucursal))
                {
                    if (!res.ContainsKey(conf.ClaveSucursal.ToUpper()))
                        res.Add(conf.ClaveSucursal.ToUpper(), new Dictionary<string, string>());
                    if (!res[conf.ClaveSucursal].ContainsKey(conf.Parametro.ToUpper()))
                        res[conf.ClaveSucursal].Add(conf.Parametro.ToUpper(), conf.Valor);
                }
            }
            return res;
        }
    }

}
