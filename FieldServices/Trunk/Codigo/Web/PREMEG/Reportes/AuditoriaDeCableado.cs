using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Acceso;
using MODMEG;
using System.Data;

namespace PREMEG.Reportes
{
    public class AuditoriaDeCableado
    {
        public static GenerarReportes.DatosExistentes ValidarExistenciaInformacion(DateTime fecha1, DateTime fecha2)
        {
            bool res = false;
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                fecha2 = fecha2.AddDays(1);
                res = contexto.OrdenTrabajo.Any(ot => ot.ConsumoCableTrabajo.Any(cc => cc.ValorReferencia.Grupo == 2) && ot.Visita.FechaHoraInicio >= fecha1 && ot.Visita.FechaHoraInicio < fecha2);

            }
            return (res ? GenerarReportes.DatosExistentes.Reporte : GenerarReportes.DatosExistentes.Ninguno);
        }

        private class CuadrillaTotal
        {
            public string ClaveRegion { get; set; }
            public string ClaveSucursal { get; set; }
            public string ClaveCuadrilla { get; set; }
            public string ClaveSupervisor { get; set; }
            public int Cantidad { get; set; }
            public decimal Porcentaje { get; set; }
        }
        internal static System.Data.DataTable ConsultarReporte(DateTime fecha1, DateTime fecha2)
        {
            DataTable tabla = new DataTable();
            List<CuadrillaTotal> lista = new List<CuadrillaTotal>();
            List<Region> regiones = new List<Region>();
            List<Sucursal> sucursales = new List<Sucursal>();
            List<CuadrillaSupervisor> supervisores = new List<CuadrillaSupervisor>();
            List<Cuadrilla> cuadrillas = new List<Cuadrilla>();
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                fecha2 = fecha2.AddDays(1);
                lista = (from ot in contexto.OrdenTrabajo
                         where ot.ConsumoCableTrabajo.Any(cc => cc.ValorReferencia.Grupo == 2) && ot.Visita.FechaHoraInicio >= fecha1 && ot.Visita.FechaHoraInicio < fecha2
                         group ot by
                            new { ot.ClaveCuadrilla, ot.Cuadrilla.ClaveSucursal, ot.Cuadrilla.Sucursal.ClaveRegion, ot.Cuadrilla.ClaveCuadrillaSupervisor } into grupo
                         select new CuadrillaTotal
                         {
                             ClaveCuadrilla = grupo.Key.ClaveCuadrilla,
                             ClaveSucursal = grupo.Key.ClaveSucursal,
                             ClaveRegion = grupo.Key.ClaveRegion,
                             ClaveSupervisor = grupo.Key.ClaveCuadrillaSupervisor,
                             Cantidad = grupo.Count(),
                             Porcentaje = (((grupo.Sum(c => c.ConsumoCableTrabajo.Sum(cc => cc.CantidadUtilizada)) - 
                             grupo.Sum(c => c.ConsumoCableTrabajo.Sum(cc=> cc.Material.TrabajoMaterial.Where(t=> t.ClaveTrabajo == cc.OrdenTrabajo.ClaveTrabajo).Sum(tm => tm.CantidadMaxima)))) * 100) /
                                grupo.Sum(c => c.ConsumoCableTrabajo.Sum(cc => cc.Material.TrabajoMaterial.Where(t => t.ClaveTrabajo == cc.OrdenTrabajo.ClaveTrabajo).Sum(tm => tm.CantidadMaxima))))
                         }).ToList();
                regiones = contexto.Region.ToList();
                sucursales = contexto.Sucursal.ToList();
                supervisores = contexto.CuadrillaSupervisor.ToList();
                cuadrillas = contexto.Cuadrilla.ToList();

                tabla.Columns.Add("idnodo");
                tabla.Columns.Add("idpadre");
                tabla.Columns.Add("nodoultimo");
                tabla.Columns.Add("_ClaveCuadrilla");
                tabla.Columns.Add("_FechaInicio");
                tabla.Columns.Add("_FechaFin");
                tabla.Columns.Add("Nombre");
                tabla.Columns.Add("?NoTrabajosExcedente", typeof(int));
                tabla.Columns.Add("?%Excedente", typeof(int));
                tabla.PrimaryKey = new DataColumn[] { tabla.Columns["idnodo"] };
            }
            DataRow fila = tabla.NewRow();

            fila["idnodo"] = "node-1";
            fila["idpadre"] = "";
            fila["nodoultimo"] = false;
            fila["_ClaveCuadrilla"] = "";
            fila["_FechaInicio"] = "";
            fila["_FechaFin"] = "";
            fila["Nombre"] = "Megacable";
            fila["?NoTrabajosExcedente"] = lista.Sum(e => e.Cantidad);
            fila["?%Excedente"] = lista.Average(e => e.Porcentaje);
            tabla.Rows.Add(fila);
            int nodoId = 1;
            foreach (Region r in regiones.OrderBy(reg => reg.Nombre))
            {
                List<CuadrillaTotal> ePorRegion = lista.Where(e => e.ClaveRegion == r.ClaveRegion).ToList();
                if (ePorRegion.Count > 0)
                {
                    DataRow filaRegion = tabla.NewRow();
                    nodoId++;
                    filaRegion["idnodo"] = nodoId;
                    filaRegion["idpadre"] = "node-1";
                    filaRegion["nodoultimo"] = false;
                    filaRegion["_ClaveCuadrilla"] = "";
                    filaRegion["_FechaInicio"] = "";
                    filaRegion["_FechaFin"] = "";
                    filaRegion["Nombre"] = r.Nombre;
                    filaRegion["?NoTrabajosExcedente"] = ePorRegion.Sum(e => e.Cantidad);
                    filaRegion["?%Excedente"] = ePorRegion.Average(e => e.Porcentaje);
                    tabla.Rows.Add(filaRegion);

                    int nodopadreSuc = nodoId;
                    foreach (Sucursal s in sucursales.OrderBy(su => su.Nombre))
                    {
                        List<CuadrillaTotal> ePorSucursal = ePorRegion.Where(e => e.ClaveSucursal == s.ClaveSucursal).ToList();
                        if (ePorSucursal.Count > 0)
                        {
                            DataRow filaSucursal = tabla.NewRow();
                            nodoId++;
                            filaSucursal["idnodo"] = nodoId;
                            filaSucursal["idpadre"] = nodopadreSuc;
                            filaSucursal["nodoultimo"] = false;
                            filaSucursal["_ClaveCuadrilla"] = "";
                            filaSucursal["_FechaInicio"] = "";
                            filaSucursal["_FechaFin"] = "";
                            filaSucursal["Nombre"] = s.Nombre;
                            filaSucursal["?NoTrabajosExcedente"] = ePorSucursal.Sum(e => e.Cantidad);
                            filaSucursal["?%Excedente"] = ePorSucursal.Average(e => e.Porcentaje);
                            tabla.Rows.Add(filaSucursal);

                            int nodopadreSup = nodoId;
                            foreach (CuadrillaSupervisor su in supervisores.OrderBy(su => su.Nombre))
                            {
                                List<CuadrillaTotal> ePorSupervisor = ePorSucursal.Where(e => e.ClaveSupervisor == su.ClaveCuadrillaSupervisor).ToList();
                                if (ePorSupervisor.Count > 0)
                                {
                                    DataRow filaSupervisor = tabla.NewRow();
                                    nodoId++;
                                    filaSupervisor["idnodo"] = nodoId;
                                    filaSupervisor["idpadre"] = nodopadreSup;
                                    filaSupervisor["nodoultimo"] = false;
                                    filaSupervisor["_ClaveCuadrilla"] = "";
                                    filaSupervisor["_FechaInicio"] = "";
                                    filaSupervisor["_FechaFin"] = "";
                                    filaSupervisor["Nombre"] = su.Nombre;
                                    filaSupervisor["?NoTrabajosExcedente"] = ePorSupervisor.Sum(e => e.Cantidad);
                                    filaSupervisor["?%Excedente"] = ePorSupervisor.Average(e => e.Porcentaje);
                                    tabla.Rows.Add(filaSupervisor);

                                    int nodopadreCua = nodoId;
                                    foreach (Cuadrilla cua in cuadrillas.OrderBy(cu => cu.Nombre))
                                    {
                                        List<CuadrillaTotal> ePorCuadrilla = ePorSupervisor.Where(e => e.ClaveCuadrilla == cua.ClaveCuadrilla).ToList();
                                        if (ePorCuadrilla.Count > 0)
                                        {
                                            DataRow filaCuadrilla = tabla.NewRow();
                                            nodoId++;
                                            filaCuadrilla["idnodo"] = nodoId;
                                            filaCuadrilla["idpadre"] = nodopadreCua;
                                            filaCuadrilla["nodoultimo"] = true;
                                            filaCuadrilla["_ClaveCuadrilla"] = cua.ClaveCuadrilla;
                                            filaCuadrilla["_FechaInicio"] = fecha1;
                                            filaCuadrilla["_FechaFin"] = fecha2;
                                            filaCuadrilla["Nombre"] = cua.Nombre;
                                            filaCuadrilla["?NoTrabajosExcedente"] = ePorCuadrilla.Sum(e => e.Cantidad);
                                            filaCuadrilla["?%Excedente"] = ePorCuadrilla.Average(e => e.Porcentaje);
                                            tabla.Rows.Add(filaCuadrilla);
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            return tabla;
        }

        internal static System.Data.DataTable ObtenerDetalles(string idNodo, System.Data.DataTable reporte)
        {
            DataRow filaSel = reporte.Rows.Find(idNodo);
            DataTable tabla = new DataTable("Detalle");
            tabla.Columns.Add("?Fecha");
            tabla.Columns.Add("?Tecnico");
            tabla.Columns.Add("?NoContrato");
            tabla.Columns.Add("?Trabajo");
            tabla.Columns.Add("?DiferenciaMts");
            tabla.Columns.Add("_ClaveSucursal");
            tabla.Columns.Add("_RutaImagenIni");
            tabla.Columns.Add("_RutaImagenFin");
            if (filaSel != null)
            {
                string ClaveCuadrilla = filaSel["_ClaveCuadrilla"].ToString().Trim();
                DateTime FechaAgenda = Convert.ToDateTime(filaSel["_FechaInicio"]);
                DateTime FechaFin = Convert.ToDateTime(filaSel["_FechaFin"]);
                using (MegaCableEntities contexto = new MegaCableEntities())
                {
                    FechaFin = FechaFin.AddDays(1);
                    string ClaveSucursal = (from cua in contexto.Cuadrilla 
                                         where cua.ClaveCuadrilla == ClaveCuadrilla select cua.ClaveSucursal).First().ToString();
                    var lista = from ot in contexto.OrdenTrabajo
                                where
                                ot.ConsumoCableTrabajo.Any(cc => cc.ValorReferencia.Grupo == 2) &&
                                ot.ClaveCuadrilla == ClaveCuadrilla &&
                                ot.Visita.FechaHoraInicio >= FechaAgenda &&
                                ot.Visita.FechaHoraInicio < FechaFin
                                select new
                                {
                                    Fecha = ot.FechaHoraProgramada,
                                    Tecnico = ot.Visita.Jornada.Usuario.Nombre,
                                    Suscriptor = ot.Suscriptor.ClaveSuscriptor,
                                    Trabajo = ot.Trabajo.Descripcion,
                                    Diferencia = ot.ConsumoCableTrabajo.Sum(c => c.CantidadUtilizada) - ot.ConsumoCableTrabajo.Sum(c => c.Material.TrabajoMaterial.Where(t => t.ClaveTrabajo == ot.ClaveTrabajo ).Sum(tm => tm.CantidadMaxima)),
                                    RutaImagenIni = ot.ConsumoCableTrabajo.FirstOrDefault().IdImagenIni,
                                    RutaImagenFin = ot.ConsumoCableTrabajo.FirstOrDefault().IdImagenFin
                                };
                    foreach (var l in lista)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["?Fecha"] = l.Fecha.ToString();
                        fila["?Tecnico"] = l.Tecnico;
                        fila["?NoContrato"] = l.Suscriptor;
                        fila["?Trabajo"] = l.Trabajo;
                        fila["?DiferenciaMts"] = l.Diferencia;
                        fila["_ClaveSucursal"] = ClaveSucursal;
                        fila["_RutaImagenIni"] = l.RutaImagenIni;
                        fila["_RutaImagenFin"] = l.RutaImagenFin;
                        tabla.Rows.Add(fila);
                    }
                }
            }
            return tabla;
        }
    }
}
