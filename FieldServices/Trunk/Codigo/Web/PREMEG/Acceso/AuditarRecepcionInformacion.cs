using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public class AuditarRecepcionInformacion
    {
        IAuditoriaRecepcionInformacion vista;
        public AuditarRecepcionInformacion(IAuditoriaRecepcionInformacion Vista)
        {
            vista = Vista;
        }
        public List<Sucursal> ObtenerSucursales()
        {
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = from suc in contexto.Sucursal where suc.Estado select suc;
                return lista.ToList();
            }
        }
        public void ObtenerAuditoria(string ClaveSucursal, DateTime Fecha)
        {
            DateTime fechaFin = Fecha.AddDays(1);
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                string sinagenda = UtilMensaje.ObtenerMensaje("#SinAgenda");
                string sinsync = UtilMensaje.ObtenerMensaje("#SinSync");
                string sincronizado = UtilMensaje.ObtenerMensaje("#Sincronizado");

                var qry = (from cua in contexto.Cuadrilla
                           join aud in
                               (
                                   from au in contexto.AuditoriaRecepcion
                                   where ((au.HoraAgenda >= Fecha && au.HoraAgenda < fechaFin) ||
                                   (au.HoraSincronizacion >= Fecha && au.HoraSincronizacion < fechaFin))
                                   group au by new { au.FechaAgenda, au.ClaveCuadrilla, au.ClaveSucursal} into g
                                   select new { 
                                       ClaveSucursal = g.Key.ClaveSucursal, 
                                       ClaveCuadrilla = g.Key.ClaveCuadrilla,
                                       HoraAgenda = g.Min(x=>x.HoraAgenda),
                                       HoraSincronizacion = g.Max(x => x.HoraSincronizacion)
                                   }
                                   ) on new { cua.ClaveCuadrilla, cua.ClaveSucursal } equals new { aud.ClaveCuadrilla, aud.ClaveSucursal } into AudCua
                           from aucu in AudCua.DefaultIfEmpty()
                           select new ElementoAuditoriaRecepcion
                           {
                               Estado = aucu.HoraAgenda == null ? sinagenda : aucu.HoraSincronizacion == null ? sinsync : sincronizado,
                               ClaveCuadrilla = cua.ClaveCuadrilla,
                               ClaveSucursal = cua.ClaveSucursal,
                               HoraAgenda = aucu.HoraAgenda,
                               HoraSincronizacion = aucu.HoraSincronizacion
                           }).OrderBy(l => l.Estado);
                List<ElementoAuditoriaRecepcion> lista = qry.ToList();
                vista.TNNoCuadrillas = lista.Count;
                vista.TNCuadrillasSalieronDeBase = lista.Count(x => x.HoraAgenda != null);
                vista.TNCuadrillasRegresaronABase = lista.Count(x => x.HoraSincronizacion != null);

                List<ElementoAuditoriaRecepcion> listaSucursal = lista.Where(x => x.ClaveSucursal == ClaveSucursal).ToList();
                vista.NoCuadrillas = listaSucursal.Count;
                vista.CuadrillasSalieronDeBase = listaSucursal.Count(x=>x.HoraAgenda != null);
                vista.CuadrillasRegresaronABase = listaSucursal.Count(x => x.HoraSincronizacion != null);
                vista.PoblarAuditoria(listaSucursal);
            }
        }
        public class ElementoAuditoriaRecepcion
        {
            public string  Estado { get; set; }
            public string ClaveCuadrilla { get; set; }
            public string ClaveSucursal { get; set; }
            public DateTime? HoraAgenda { get; set; }
            public DateTime? HoraSincronizacion { get; set; }

        }
    }
}
