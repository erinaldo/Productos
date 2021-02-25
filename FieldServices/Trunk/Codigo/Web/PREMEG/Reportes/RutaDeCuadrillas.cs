using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Acceso;
using MODMEG;
using System.Data;

namespace PREMEG.Reportes
{
    public class RutaDeCuadrillas
    {
        public class DetalleOrden
        {
            public string Descripcion { get; set; }
            public string EstadoDescripcion { get; set; }
            public DateTime Hora { get; set; }
        }
        public static GenerarReportes.DatosExistentes ValidarExistenciaInformacion(DateTime fecha1, DateTime fecha2)
        {
            bool res = false;
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                fecha2 = fecha2.AddDays(1);
                res = contexto.OrdenTrabajo.Any(ot => ot.Visita.FechaHoraInicio >= fecha1 && ot.Visita.FechaHoraInicio < fecha2);

            }
            return (res ? GenerarReportes.DatosExistentes.Mapa : GenerarReportes.DatosExistentes.Ninguno);
        }

        internal static System.Data.DataTable ConsultarReporte(DateTime fecha1, DateTime fecha2)
        {
            DataTable tabla = new DataTable();
            
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                fecha2 = fecha2.AddDays(1);
                var lista = from ot in contexto.OrdenTrabajo
                            where ot.Visita.FechaHoraInicio >= fecha1 && ot.Visita.FechaHoraInicio < fecha2
                            group ot by
                               new { ClaveSupervisor = ot.Visita.Jornada.Cuadrilla.ClaveCuadrillaSupervisor, Supervisor = ot.Visita.Jornada.Cuadrilla.CuadrillaSupervisor.Nombre, ClaveCuadrilla = ot.ClaveCuadrilla, NombreTecnico = ot.Visita.Jornada.Usuario.Nombre } into grupo
                            select new
                            {
                                ClaveSupervisor = grupo.Key.ClaveSupervisor,
                                Supervisor = grupo.Key.Supervisor,
                                ClaveCuadrilla = grupo.Key.ClaveCuadrilla,
                                Tecnico = grupo.Key.NombreTecnico
                            };

                tabla.Columns.Add("ClaveCuadrilla");
                tabla.Columns.Add("Tecnico");
                tabla.Columns.Add("ClaveSupervisor");
                tabla.Columns.Add("Supervisor");

                foreach (var ta in lista)
                {
                    DataRow fila = tabla.NewRow();
                    fila["ClaveCuadrilla"] = ta.ClaveCuadrilla;
                    fila["Tecnico"] = ta.Tecnico;
                    fila["ClaveSupervisor"] = ta.ClaveSupervisor;
                    fila["Supervisor"] = ta.Supervisor;
                    tabla.Rows.Add(fila);
                }
            }

            return tabla;
        }

        internal static System.Data.DataTable ObtenerDetalles(string idNodo, System.Data.DataTable tabla)
        {
            DataTable ret = new DataTable();
            ret.Columns.Add("Orden");
            ret.Columns.Add("Tecnico");
            ret.Columns.Add("FechaHoraI");
            ret.Columns.Add("FechaHoraF");
            ret.Columns.Add("ClaveCuadrilla");
            ret.Columns.Add("NoContrato");
            ret.Columns.Add("Ordenes",typeof(DetalleOrden[]));
            ret.Columns.Add("Lat");
            ret.Columns.Add("Lng");

            if (tabla.Rows.Count > 0)
            {
                string ClaveCuadrilla = tabla.Rows[0]["ClaveCuadrilla"].ToString();
                DateTime Fecha1 = Convert.ToDateTime(tabla.Rows[0]["Fecha1"]);
                DateTime Fecha2 = Convert.ToDateTime(tabla.Rows[0]["Fecha2"]);

                using (MegaCableEntities contexto = new MegaCableEntities())
                {
                    var listaVisita = from vis in contexto.Visita
                                      where vis.Jornada.ClaveCuadrilla == ClaveCuadrilla && vis.FechaHoraInicio >= Fecha1 && vis.FechaHoraInicio < Fecha2
                                      orderby vis.FechaHoraInicio
                                      select new
                                      {
                                          Tecnico = vis.Jornada.Usuario.Nombre,
                                          vis.ClaveSuscriptor,
                                          vis.FechaHoraInicio,
                                          vis.FechaHoraFin,
                                          Ordenes = (from ot in vis.OrdenTrabajo
                                                     where ot.ClaveCuadrilla == ClaveCuadrilla
                                                     select new DetalleOrden(){ Descripcion = ot.Trabajo.Descripcion,
                                                         EstadoDescripcion = (ot.Estado == 1012 ? ot.ValorReferencia2.Descripcion : ot.ValorReferencia1.Descripcion),
                                                         Hora = ot.FechaHoraProgramada 
                                                     }),
                                          Lat = vis.Lat,
                                          Lng = vis.Lng
                                      };
                    int or = 0;
                    foreach (var i in listaVisita)
                    {
                        or++;
                        DataRow fila = ret.NewRow();
                        fila["Orden"] = or;
                        fila["Tecnico"] = i.Tecnico;
                        fila["ClaveCuadrilla"] = ClaveCuadrilla;
                        fila["NoContrato"] = i.ClaveSuscriptor;
                        fila["FechaHoraI"] = i.FechaHoraInicio ;
                        fila["FechaHoraF"] = i.FechaHoraFin ;
                        fila["Ordenes"] = i.Ordenes.ToArray();
                        fila["Lat"] = i.Lat;
                        fila["Lng"] = i.Lng;
                        ret.Rows.Add(fila);
                    }
                }
            }
            return ret;
        }
    }
}
