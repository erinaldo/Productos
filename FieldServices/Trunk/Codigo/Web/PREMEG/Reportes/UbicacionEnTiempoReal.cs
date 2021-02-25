using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Acceso;
using MODMEG;
using System.Data;

namespace PREMEG.Reportes
{
    public class UbicacionEnTiempoReal
    {
        public static GenerarReportes.DatosExistentes ValidarExistenciaInformacion(DateTime fecha1, DateTime fecha2)
        {
            bool res = false;
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                res = contexto.Visita.Any(v => v.OrdenTrabajo.Any());

            }
            return (res ? GenerarReportes.DatosExistentes.Mapa : GenerarReportes.DatosExistentes.Ninguno);
        }

        internal static System.Data.DataTable ConsultarReporte(DateTime fecha1, DateTime fecha2)
        {
            DataTable tabla = new DataTable();

            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                var lista = from res in
                                (from cuad in contexto.Cuadrilla
                                 select new
                                 {
                                     ClaveCuadrilla = cuad.ClaveCuadrilla,
                                     Tecnico = cuad.Usuario.FirstOrDefault().Nombre,
                                     ClaveSupervisor = cuad.CuadrillaSupervisor.ClaveCuadrillaSupervisor,
                                     Supervisor = cuad.CuadrillaSupervisor.Nombre,
                                     Visita =
                                     (from vis in contexto.Visita
                                      where vis.Jornada.ClaveCuadrilla == cuad.ClaveCuadrilla
                                      && vis.FechaHoraInicio ==
                                      (from v1 in contexto.Visita
                                       where v1.Jornada.ClaveCuadrilla == cuad.ClaveCuadrilla
                                       && v1.OrdenTrabajo.Any()
                                       select v1
                                      ).Max(v => v.FechaHoraInicio)
                                      select vis).FirstOrDefault()

                                 })
                            select new
                            {
                                ClaveCuadrilla = res.ClaveCuadrilla,
                                Tecnico = res.Tecnico,
                                ClaveSupervisor = res.ClaveSupervisor,
                                Supervisor = res.Supervisor,
                                OT = (from ot in contexto.OrdenTrabajo
                                      where ot.IdVisita == res.Visita.IdVisita
                                      select new
                                      {
                                          NoContrato= ot.ClaveSuscriptor,
                                          Estado = ot.Estado,
                                          FechaHoraProgramada= ot.FechaHoraProgramada,
                                          Trabajo = ot.Trabajo.Descripcion,
                                          EstadoDescripcion = (ot.Estado == 1012 ? ot.ValorReferencia2.Descripcion : ot.ValorReferencia1.Descripcion)
                                      }).FirstOrDefault(),
                                Lat = res.Visita.Lat,
                                Lng = res.Visita.Lng
                            };

                tabla.Columns.Add("ClaveCuadrilla");
                tabla.Columns.Add("Tecnico");
                tabla.Columns.Add("ClaveSupervisor");
                tabla.Columns.Add("Supervisor");
                tabla.Columns.Add("Estado");
                tabla.Columns.Add("NoContrato");
                tabla.Columns.Add("Hora");
                tabla.Columns.Add("Trabajo");
                tabla.Columns.Add("EstadoDescripcion");
                tabla.Columns.Add("Lat");
                tabla.Columns.Add("Lng");

                foreach (var ta in lista)
                {
                    if ((ta.Lat != null) && (ta.Lng != null) && (ta.OT != null))
                    {
                        DataRow fila = tabla.NewRow();
                        fila["ClaveCuadrilla"] = ta.ClaveCuadrilla;
                        fila["Tecnico"] = ta.Tecnico;
                        fila["ClaveSupervisor"] = ta.ClaveSupervisor;
                        fila["Supervisor"] = ta.Supervisor;
                        fila["Estado"] = ta.OT.Estado;
                        fila["NoContrato"] = ta.OT.NoContrato;
                        fila["Hora"] = ta.OT.FechaHoraProgramada.ToShortTimeString();
                        fila["Trabajo"] = ta.OT.Trabajo;
                        fila["EstadoDescripcion"] = ta.OT.EstadoDescripcion;
                        fila["Lat"] = ta.Lat;
                        fila["Lng"] = ta.Lng;
                        tabla.Rows.Add(fila);
                    }
                }
            }

            return tabla;
        }

        internal static System.Data.DataTable ObtenerDetalles(string idNodo, System.Data.DataTable tabla)
        {
            return null;
        }
    }
}
