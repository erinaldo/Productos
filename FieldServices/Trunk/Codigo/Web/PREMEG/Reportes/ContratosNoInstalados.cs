using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Acceso;
using System.Data;
using MODMEG;

namespace PREMEG.Reportes
{
    public class ContratosNoInstalados
    {
        public static GenerarReportes.DatosExistentes ValidarExistenciaInformacion(DateTime fecha1, DateTime fecha2)
        {
            bool res = false;
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                fecha2 = fecha1.AddDays(1);
                res = contexto.OrdenTrabajo.Any(ot => ot.ValorReferencia2.Grupo == 2 && ot.Visita.FechaHoraInicio >= fecha1 && ot.Visita.FechaHoraInicio < fecha2);

            }
            return (res ? GenerarReportes.DatosExistentes.Reporte : GenerarReportes.DatosExistentes.Ninguno);
        }

        private class Elemento
        {
            public string ClaveRegion { get; set; }
            public string ClaveSucursal { get; set; }
            public string ClaveCuadrilla { get; set; }
            public string ClaveSupervisor { get; set; }
            public short TipoMotivo {get;set;}
            
        }
        public static DataTable ConsultarReporte(DateTime fecha1, DateTime fecha2)
        {

            DataTable tabla = new DataTable();
            List<Elemento> lista = new List<Elemento>();
            List<Region> regiones = new List<Region>();
            List<Sucursal> sucursales = new List<Sucursal>();
            List<CuadrillaSupervisor> supervisores = new List<CuadrillaSupervisor>();
            List<Cuadrilla> cuadrillas = new List<Cuadrilla>();
            List<ValorReferencia> motivos = new List<ValorReferencia>();
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                fecha2 = fecha1.AddDays(1);
                lista = (from ot in contexto.OrdenTrabajo
                         where ot.ValorReferencia2.Grupo == 2 && ot.Visita.FechaHoraInicio >= fecha1 && ot.Visita.FechaHoraInicio < fecha2
                         select new Elemento { ClaveCuadrilla = ot.ClaveCuadrilla, ClaveSucursal = ot.Cuadrilla.ClaveSucursal, ClaveRegion = ot.Cuadrilla.Sucursal.ClaveRegion, TipoMotivo = ot.ValorReferencia2.Valor, ClaveSupervisor=ot.Cuadrilla.ClaveCuadrillaSupervisor}).ToList();
                regiones = contexto.Region.ToList();
                sucursales = contexto.Sucursal.ToList();
                supervisores = contexto.CuadrillaSupervisor.ToList();
                cuadrillas = contexto.Cuadrilla.ToList();
                motivos = (from vr in
                               (from ele in lista
                                select new { Valor = ele.TipoMotivo }).Distinct()
                           select contexto.ValorReferencia.Where(v => v.Valor == vr.Valor).FirstOrDefault()).ToList() ;

                tabla.Columns.Add("idnodo");
                tabla.Columns.Add("idpadre");
                tabla.Columns.Add("nodoultimo");
                tabla.Columns.Add("_ClaveCuadrilla");
                tabla.Columns.Add("_FechaAgenda");
                tabla.Columns.Add("Nombre");
                tabla.Columns.Add("?TotalProblemas");
                tabla.PrimaryKey = new DataColumn[] { tabla.Columns["idnodo"] };
            }

            foreach (ValorReferencia m in motivos)
                tabla.Columns.Add(m.Descripcion);

            DataRow fila = tabla.NewRow();
            
            fila["idnodo"] = "node-1";
            fila["idpadre"] = "";
            fila["nodoultimo"] = false;
            fila["_ClaveCuadrilla"] = "";
            fila["_FechaAgenda"] = "";
            fila["Nombre"] = "Megacable";
            fila["?TotalProblemas"] = lista.Count;

            foreach (ValorReferencia m in motivos)
            {
                fila[m.Descripcion] = lista.Where(o => o.TipoMotivo == m.Valor).Count();
            }
            tabla.Rows.Add(fila);
            int nodoId = 1;
            foreach (Region r in regiones.OrderBy(reg => reg.Nombre))
            {
                List<Elemento> ePorRegion = lista.Where(e => e.ClaveRegion == r.ClaveRegion).ToList();
                if (ePorRegion.Count >0)
                {
                    DataRow filaRegion = tabla.NewRow();
                    nodoId++;
                    filaRegion["idnodo"] = "node-" + nodoId.ToString();
                    filaRegion["idpadre"] = "node-1";
                    filaRegion["nodoultimo"] = false;
                    filaRegion["_ClaveCuadrilla"] = "";
                    filaRegion["_FechaAgenda"] = "";
                    filaRegion["Nombre"] = r.Nombre;
                    filaRegion["?TotalProblemas"] = ePorRegion.Count;
                    foreach (ValorReferencia m in motivos)
                    {
                        filaRegion[m.Descripcion] = ePorRegion.Where(o => o.TipoMotivo == m.Valor).Count();
                    }
                    tabla.Rows.Add(filaRegion);

                    int nodopadreSuc = nodoId;
                    foreach (Sucursal s in sucursales.OrderBy(su => su.Nombre))
                    {
                        List<Elemento> ePorSucursal = ePorRegion.Where(e => e.ClaveSucursal == s.ClaveSucursal).ToList();
                        if (ePorSucursal.Count > 0)
                        {
                            DataRow filaSucursal = tabla.NewRow();
                            nodoId++;
                            filaSucursal["idnodo"] = "node-" + nodoId.ToString();
                            filaSucursal["idpadre"] = "node-" + nodopadreSuc.ToString();
                            filaSucursal["nodoultimo"] = false;
                            filaSucursal["_ClaveCuadrilla"] = "";
                            filaSucursal["_FechaAgenda"] = "";
                            filaSucursal["Nombre"] =s.Nombre;
                            filaSucursal["?TotalProblemas"] = ePorSucursal.Count;
                            foreach (ValorReferencia m in motivos)
                            {
                                filaSucursal[m.Descripcion] = ePorSucursal.Where(o => o.TipoMotivo == m.Valor).Count();
                            }
                            tabla.Rows.Add(filaSucursal);

                            int nodopadreSup = nodoId;
                            foreach (CuadrillaSupervisor su in supervisores.OrderBy(su => su.Nombre))
                            {
                                List<Elemento> ePorSupervisor = ePorSucursal.Where(e => e.ClaveSupervisor== su.ClaveCuadrillaSupervisor).ToList();
                                if (ePorSupervisor.Count > 0)
                                {
                                    DataRow filaSupervisor = tabla.NewRow();
                                    nodoId++;
                                    filaSupervisor["idnodo"] = "node-" + nodoId.ToString();
                                    filaSupervisor["idpadre"] = "node-" + nodopadreSup.ToString();
                                    filaSupervisor["nodoultimo"] = false;
                                    filaSupervisor["_ClaveCuadrilla"] = "";
                                    filaSupervisor["_FechaAgenda"] = "";
                                    filaSupervisor["Nombre"] = su.Nombre;
                                    filaSupervisor["?TotalProblemas"] = ePorSupervisor.Count;
                                    foreach (ValorReferencia m in motivos)
                                    {
                                        filaSupervisor[m.Descripcion] = ePorSupervisor.Where(o => o.TipoMotivo == m.Valor).Count();
                                    }
                                    tabla.Rows.Add(filaSupervisor);

                                    int nodopadreCua = nodoId;
                                    foreach (Cuadrilla cua in cuadrillas.OrderBy(cu => cu.Nombre))
                                    {
                                        List<Elemento> ePorCuadrilla = ePorSupervisor.Where(e => e.ClaveCuadrilla == cua.ClaveCuadrilla).ToList();
                                        if (ePorCuadrilla.Count > 0)
                                        {
                                            DataRow filaCuadrilla = tabla.NewRow();
                                            nodoId++;
                                            filaCuadrilla["idnodo"] = "node-" + nodoId.ToString();
                                            filaCuadrilla["idpadre"] = "node-" + nodopadreCua.ToString();
                                            filaCuadrilla["nodoultimo"] = true;
                                            filaCuadrilla["_ClaveCuadrilla"] = cua.ClaveCuadrilla;
                                            filaCuadrilla["_FechaAgenda"] = fecha1;
                                            filaCuadrilla["Nombre"] = cua.Nombre;
                                            filaCuadrilla["?TotalProblemas"] = ePorCuadrilla.Count;
                                            foreach (ValorReferencia m in motivos)
                                            {
                                                filaCuadrilla[m.Descripcion] = ePorCuadrilla.Where(o => o.TipoMotivo == m.Valor).Count();
                                            }
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

        internal static DataTable ObtenerDetalles(string idNodo, DataTable reporte)
        {
            DataRow filaSel = reporte.Rows.Find(idNodo);
            DataTable tabla = new DataTable("Detalle");
            tabla.Columns.Add("?Fecha");
            tabla.Columns.Add("?Tecnico");
            tabla.Columns.Add("?No.Suscriptor");
            tabla.Columns.Add("?Trabajo");
            tabla.Columns.Add("?Motivo");
            if (filaSel != null)
            {
                string ClaveCuadrilla = filaSel["_ClaveCuadrilla"].ToString().Trim();
                DateTime FechaAgenda = Convert.ToDateTime(filaSel["_FechaAgenda"]);
                DateTime FechaFin = FechaAgenda.AddDays(1);
                using (MegaCableEntities contexto = new MegaCableEntities())
                {
                    var lista = from ot in contexto.OrdenTrabajo where ot.ClaveCuadrilla == ClaveCuadrilla && ot.Visita.FechaHoraInicio >= FechaAgenda && ot.Visita.FechaHoraInicio < FechaFin select new { Fecha = ot.FechaHoraProgramada, Tecnico = ot.Visita.Jornada.Usuario.Nombre, Suscriptor = ot.Suscriptor.ClaveSuscriptor, Trabajo = ot.Trabajo.Descripcion, Motivo = ot.ValorReferencia2.Descripcion };
                    foreach (var l in lista)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["?Fecha"] = l.Fecha.ToString();
                        fila["?Tecnico"] = l.Tecnico;
                        fila["?No.Suscriptor"] = l.Suscriptor;
                        fila["?Trabajo"] = l.Trabajo;
                        fila["?Motivo"] = l.Motivo;
                        tabla.Rows.Add(fila);
                    }
                }
            }
            return tabla ;
        }
    }
}
