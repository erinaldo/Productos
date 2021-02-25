using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Acceso;
using System.Data;
using MODMEG;
using System.Data.Objects;

namespace PREMEG.Reportes
{
    public class TiemposYMovimientos
    {
        private class ArbolTyM
        {
            public string ClaveRegion { get; set; }
            public string ClaveSucursal { get; set; }
            public string ClaveCuadrillaSupervisor { get; set; }
            public string ClaveCuadrilla { get; set; }
            public int Atendidos { get; set; }
            public int Visitados { get; set; }
            public decimal Puntos { get; set; }
            public int Problema { get; set; }
            public int TiempoMuerto { get; set; }
            public int KmRecorrido { get; set; }
            public int TiempoTraslado { get; set; }
            public int PromedioTraslado { get; set; }
            public int PromedioAtendido { get; set; }
            public int PromedioVisitado { get; set; }
        }
        public static GenerarReportes.DatosExistentes ValidarExistenciaInformacion(DateTime fecha1, DateTime fecha2)
        {
            bool res = false;
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                fecha2 = fecha2.AddDays(1);
                res = contexto.OrdenTrabajo.Any(o => o.Visita.FechaHoraInicio >= fecha1 && o.Visita.FechaHoraInicio < fecha2 && o.IdVisita != null &&
                (o.ValorReferencia.Clave == "MOTFIN" && o.ValorReferencia.Grupo == 2 || o.ValorReferencia1.Valor == 1016));
            }
            return (res ? GenerarReportes.DatosExistentes.Reporte : GenerarReportes.DatosExistentes.Ninguno);
        }

        internal static DataTable ConsultarReporte(DateTime fecha1, DateTime fecha2)
        {
            List<Region> regiones;

            List<RptTiemposYMovimientos_Result> qry;
            using (MegaCableEntities ctx = new MegaCableEntities())
            {
                qry = ctx.RptTiemposYMovimientos(fecha1, fecha2).ToList();
                var arbol = from v in ctx.Region.Include("Sucursal").Include("Sucursal.Cuadrilla").Include("Sucursal.Cuadrilla.CuadrillaSupervisor") select v;
                regiones = arbol.ToList();
            }

            DataTable tabla = new DataTable();                                    
            tabla.Columns.Add("idnodo");
            tabla.Columns.Add("idpadre");
            tabla.Columns.Add("nodoultimo");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("_ClaveCuadrilla");
            tabla.Columns.Add("_Fecha1");
            tabla.Columns.Add("_Fecha2");
            tabla.Columns.Add("?TotalAtendidos"); 
            tabla.Columns.Add("?TotalVisitados");
            tabla.Columns.Add("?TotalDPuntos");
            tabla.Columns.Add("?TotalProblemas");
            tabla.Columns.Add("?TotalTiempoMuerto");
            tabla.Columns.Add("?TotalRecorrido");
            tabla.Columns.Add("?TotalTiempoTraslado");
            tabla.Columns.Add("?TiempoProTraslado");
            tabla.Columns.Add("?TiempoProAtendidos"); 
            tabla.Columns.Add("?TiempoProVisita");
            
            
            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["idnodo"] };

            DataRow fila = tabla.NewRow();                        
            fila["idnodo"] = "node-1";
            fila["idpadre"] = "";
            fila["nodoultimo"] = false;
            fila["Nombre"] = "MegaCable";
            InsertarFila(fila, tabla, qry);
            
            int indice = 1;
            foreach (Region region in regiones)
            {
                indice++;
                var regRegion = qry.Where(o => o.ClaveRegion == region.ClaveRegion);
                if (regRegion.Count() == 0)
                    continue;
                fila = tabla.NewRow();
                fila["idnodo"] = "node-" + indice.ToString();
                fila["idpadre"] = "node-1";
                fila["nodoultimo"] = false;
                fila["Nombre"] = region.Nombre;
                InsertarFila(fila, tabla, regRegion);


                int indice2 = 0;
                foreach (Sucursal sucursal in region.Sucursal)
                {
                    indice2++;
                    var regSucursal = regRegion.Where(o => o.ClaveSucursal == sucursal.ClaveSucursal);
                    if (regSucursal.Count() == 0)
                        continue;

                    fila = tabla.NewRow();
                    fila["idnodo"] = "node-" + indice.ToString() + "-" + indice2.ToString();
                    fila["idpadre"] = "node-" + indice.ToString();
                    fila["nodoultimo"] = false;
                    fila["Nombre"] = sucursal.Nombre;

                    InsertarFila(fila, tabla, regSucursal);


                    int indice3 = 0;
                    foreach (CuadrillaSupervisor usuario in sucursal.Cuadrilla.Select(c => c.CuadrillaSupervisor).Distinct())
                    {
                        indice3++;
                        var regCuadSup = regSucursal.Where(o => o.ClaveCuadrillaSupervisor == usuario.ClaveCuadrillaSupervisor).ToList();
                        if (regCuadSup.Count() == 0)
                            continue;
                        fila = tabla.NewRow();
                        fila["idnodo"] = "node-" + indice.ToString() + "-" + indice2.ToString() + "-" + indice3.ToString();
                        fila["idpadre"] = "node-" + indice.ToString() + "-" + indice2.ToString();
                        fila["nodoultimo"] = false;
                        fila["Nombre"] = usuario.Nombre;
                        InsertarFila(fila, tabla, regCuadSup);

                        int indice4 = 0;
                        foreach (Cuadrilla cuadrilla in sucursal.Cuadrilla.Where(c => c.ClaveCuadrillaSupervisor == usuario.ClaveCuadrillaSupervisor))
                        {
                            indice4++;
                            var regCuad = regCuadSup.Where(o => o.ClaveCuadrilla == cuadrilla.ClaveCuadrilla).ToList();
                            if (regCuad.Count() == 0)
                                continue;
                            fila = tabla.NewRow();
                            fila["idnodo"] = "node-" + indice.ToString() + "-" + indice2.ToString() + "-" + indice3.ToString() + "-" + indice4.ToString() + "_" + cuadrilla.ClaveCuadrilla;
                            fila["idpadre"] = "node-" + indice.ToString() + "-" + indice2.ToString() + "-" + indice3.ToString();
                            fila["nodoultimo"] = true;
                            fila["Nombre"] = cuadrilla.Nombre;
                            fila["_ClaveCuadrilla"] = cuadrilla.ClaveCuadrilla;
                            fila["_Fecha1"] = fecha1;
                            fila["_Fecha2"] = fecha2;
                            InsertarFila(fila, tabla, regCuad);
                        }
                    }
                }

            }
            
            return tabla;
            //return null;
        }

        internal static void InsertarFila(DataRow fila, DataTable tabla, IEnumerable<RptTiemposYMovimientos_Result> lista)
        {
            fila["?TotalAtendidos"] = lista.Sum(m => m.TotalAtendidos).ToString();
            fila["?TotalVisitados"] = lista.Sum(m => m.TotalVisitados).ToString();
            fila["?TotalDPuntos"] = lista.Sum(m => m.TotalPuntos).ToString();
            fila["?TotalProblemas"] = lista.Sum(m => m.TotalProblema).ToString();
            TimeSpan t = new TimeSpan(0, Convert.ToInt32(lista.Sum(m => m.TotalTiempoMuerto)), 0);
            fila["?TotalTiempoMuerto"] = t.ToString("hh\\:mm\\:ss");

            fila["?TotalRecorrido"] = lista.Sum(m => m.KmRecorrido).ToString();

            t = new TimeSpan(0, Convert.ToInt32(lista.Sum(m => m.TiempoTraslado)), 0);
            fila["?TotalTiempoTraslado"] = t.ToString("hh\\:mm\\:ss");

            t = new TimeSpan(0, Convert.ToInt32(lista.Average(m => m.PromedioVisitados)), 0);
            fila["?TiempoProVisita"] = t.ToString("hh\\:mm\\:ss");
            t = new TimeSpan(0, Convert.ToInt32(lista.Average(m => m.PromedioAtendidos)), 0);
            fila["?TiempoProAtendidos"] = t.ToString("hh\\:mm\\:ss");
            t = new TimeSpan(0, Convert.ToInt32(lista.Average(m => m.PromedioTraslado)), 0);
            fila["?TiempoProTraslado"] = t.ToString("hh\\:mm\\:ss");
            tabla.Rows.Add(fila);

        }

        internal static DataTable ObtenerDetalles(string idNodo, DataTable tabla)
        {
            DataRow filaSel = tabla.Rows.Find(idNodo);
            string clave = filaSel["_ClaveCuadrilla"].ToString();
            DateTime fecha1 = Convert.ToDateTime(filaSel["_Fecha1"]);
            DateTime fecha2 = Convert.ToDateTime(filaSel["_Fecha2"]);

            using (MegaCableEntities ctx = new MegaCableEntities())
            {

                List<Jornada> jornadas = ctx.Jornada
                    .Where(j => j.ClaveCuadrilla == clave && j.FechaHoraInicial >= fecha1
                        && (j.FechaHoraFinal == null ? j.FechaHoraInicial <= fecha2 : j.FechaHoraFinal <= fecha2))
                    .OrderByDescending(j => j.FechaHoraInicial)
                    .ToList();
                

                DataTable tDetalle = new DataTable("Detalle");
                tDetalle.Columns.Add("!Fecha");
                tDetalle.Columns.Add("!Tecnico");
                tDetalle.Columns.Add("!Puntos");
                tDetalle.Columns.Add("!Atendido");
                tDetalle.Columns.Add("|Concepto");
                tDetalle.Columns.Add("!Inicio");
                tDetalle.Columns.Add("!Fin");
                tDetalle.Columns.Add("!Duracion");
                tDetalle.Columns.Add("!Descripcion");
                tDetalle.Columns.Add("!Kilometraje");


                foreach (Jornada jornada in jornadas)
                {
                    DataRow fila = tDetalle.NewRow();

                    BitacoraActividad bitacoraActividad = ctx.BitacoraActividad
                        .Where(ba =>
                            ba.Fecha >= jornada.FechaHoraInicial.Date &&
                            ba.Fecha <= jornada.FechaHoraInicial &&
                            ba.ClaveUsuario == jornada.ClaveUsuario &&
                            ba.ClaveActividad == "ACCSIST")
                            .FirstOrDefault();



                    fila["!Fecha"] = jornada.FechaHoraInicial.ToShortDateString();
                    fila["|Concepto"] = UtilMensaje.ObtenerMensaje("#Inicio");
                    fila["!Tecnico"] = jornada.Usuario.Nombre;
                    fila["!Fin"] = jornada.FechaHoraInicial.ToShortTimeString();
                    

                    if (bitacoraActividad != null)
                    {
                        fila["!Inicio"] = bitacoraActividad.Fecha.ToShortTimeString();
                        TimeSpan tsTemp = jornada.FechaHoraInicial - bitacoraActividad.Fecha;
                        fila["!Duracion"] = tsTemp.ToString();
                    }
                    else
                    {
                        fila["!Inicio"] = "?";
                        fila["!Duracion"] = "?";
                    }
                    fila["!Kilometraje"] = jornada.KmInicial;
                    tDetalle.Rows.Add(fila);

                    Visita[] visitas = jornada.Visita.Where(v => v.OrdenTrabajo.Any(o => o.ValorReferencia1.Grupo == 2 || (o.ValorReferencia2 != null && o.ValorReferencia2.Grupo == 1))).OrderBy(v => v.FechaHoraInicio).ToArray();
                    TiempoMuerto[] tiemposMuertos = jornada.TiempoMuerto.OrderBy(tm => tm.FechaHoraInicial).ToArray();

                    int total = visitas.Count() + tiemposMuertos.Count();
                    int iVisitas = 0;
                    int iTiempoMuerto = 0;
                    DateTime fechaFin;
                    
                    for (int i = 0; i < total; i++)
                    {

                        Visita visita = (iVisitas < visitas.Count() ? visitas[iVisitas] : null);
                        TiempoMuerto tiempoMuerto = (iTiempoMuerto < tiemposMuertos.Count() ? tiemposMuertos[iTiempoMuerto] : null);

                        fila = tDetalle.NewRow();

                        bool isVisita = (
                            (tiempoMuerto == null) ||
                            (visita != null && visita.FechaHoraInicio < tiempoMuerto.FechaHoraInicial)
                            );

                        if (!isVisita)
                        {
                            //fila["?Fecha"] = tiempoMuerto.FechaHoraInicial.ToShortDateString();
                            //fila["?Tecnico"] = tiempoMuerto.Jornada.Usuario.Nombre;
                            fila["|Concepto"] = UtilMensaje.ObtenerMensaje("#T.Muerto");
                            fila["!Inicio"] = tiempoMuerto.FechaHoraInicial.ToShortTimeString();
                            fila["!Fin"] = (tiempoMuerto.FechaHoraFinal != null ? ((DateTime)tiempoMuerto.FechaHoraFinal).ToShortTimeString() : "");
                            TimeSpan tsTemp = (tiempoMuerto.FechaHoraFinal != null ? ((DateTime)tiempoMuerto.FechaHoraFinal) - tiempoMuerto.FechaHoraInicial : new TimeSpan());
                            fila["!Duracion"] = tsTemp.ToString();
                            fila["!Descripcion"] = tiempoMuerto.ValorReferencia.Descripcion;
                            if (tiempoMuerto.FechaHoraFinal != null)
                                fechaFin = ((DateTime)tiempoMuerto.FechaHoraFinal);
                            iTiempoMuerto++;
                        }
                        else
                        {
                            //fila["?Fecha"] = visita.FechaHoraInicio.ToShortDateString();
                            //fila["?Tecnico"] = visita.Jornada.Usuario.Nombre;
                            bool visitado = false;
                            if (visita.OrdenTrabajo.Any(o => o.ValorReferencia2 != null && o.ValorReferencia2.Grupo == 1))
                                visitado = true;
                            if (!visitado)
                                fila["!Puntos"] = visita.OrdenTrabajo.Sum(o => o.Trabajo.CantidadPuntos).ToString();
                            fila["!Atendido"] = (visitado ? UtilMensaje.ObtenerMensaje("#NO") : UtilMensaje.ObtenerMensaje("#SI"));
                            fila["|Concepto"] = "<a href=\"#\" onclick = 'AbrirDetale(\"DetalleReportes/DetalleTiemposYMovimientos.aspx?type=" + (visitado ? "0" : "1") + "&idVisita=" + visita.IdVisita+"\")' >" + UtilMensaje.ObtenerMensaje("#VerDetalle") + "</a>";
                            fila["!Inicio"] = visita.FechaHoraInicio.ToShortTimeString();
                            fila["!Fin"] = (visita.FechaHoraFin != null ? ((DateTime)visita.FechaHoraFin).ToShortTimeString() : "");
                            TimeSpan tsTemp = (visita.FechaHoraFin != null ? ((DateTime)visita.FechaHoraFin) - visita.FechaHoraInicio : new TimeSpan());
                            fila["!Duracion"] = tsTemp.ToString();
                            fila["!Descripcion"] = visita.Suscriptor.ClaveSuscriptor;
                            if (visita.FechaHoraFin != null)
                                fechaFin = ((DateTime)visita.FechaHoraFin);
                            iVisitas++;
                        }

                        tDetalle.Rows.Add(fila);
                    }

                    fila = tDetalle.NewRow();
                    fila["|Concepto"] = UtilMensaje.ObtenerMensaje("#Fin");
                    if (jornada.FechaHoraFinal != null)
                        fila["!Inicio"] = ((DateTime)jornada.FechaHoraFinal).ToShortTimeString();
                    else
                        fila["!Inicio"] = "?";
                    fila["!Kilometraje"] = jornada.KmFinal;
                    tDetalle.Rows.Add(fila);

                    DateTime? fechaUno = (jornada.FechaHoraFinal != null ? jornada.FechaHoraFinal : jornada.FechaHoraInicial.Date);
                    DateTime fechaDos = jornada.FechaHoraInicial.Date.AddDays(1);
                    bitacoraActividad = ctx.BitacoraActividad
                        .Where(ba =>
                            ba.Fecha >=  fechaUno &&
                            ba.Fecha <=  fechaDos &&
                            ba.ClaveUsuario == jornada.ClaveUsuario &&
                            ba.ClaveActividad == "RESJOR")
                            .FirstOrDefault();

                    if (bitacoraActividad != null)
                    {
                        fila["!Fin"] = bitacoraActividad.Fecha.ToShortTimeString();
                        if (jornada.FechaHoraFinal != null)
                        {
                            TimeSpan tsTemp = bitacoraActividad.Fecha - ((DateTime)jornada.FechaHoraFinal);
                            fila["!Duracion"] = tsTemp.ToString();
                        }
                    }
                    //Agregar Total
                    fila = tDetalle.NewRow();
                    fila["!Tecnico"] = UtilMensaje.ObtenerMensaje("#Total");
                    fila["!Puntos"] = jornada.PuntosAcumulados;
                    fila["!Atendido"] = visitas.Count();
                    fila["!Kilometraje"] = jornada.KmFinal - jornada.KmInicial;
                    tDetalle.Rows.Add(fila);
                }
                return tDetalle;

            }
        }




        /*private TimeSpan tiempoPromedio(List<ArbolTyM> visitas)
        {

            double segundos = 0; 
            int cant = 0;
            foreach (ArbolTyM v in visitas)
            {
                if((v.FechaHoraFin != null)&&(v.FechaHoraInicio != null))
                    segundos += ((DateTime)v.FechaHoraFin).Subtract(v.FechaHoraInicio).TotalSeconds;
                cant++;
            }
            if (segundos != 0)
                segundos = segundos / cant;

            TimeSpan t = TimeSpan.FromSeconds(segundos);
            return t;
        }*/

        /*private TimeSpan tiempoPromedioTraslado(List<ArbolTyM> visitas)
        {
            if (visitas.Count == 0 || visitas.Where(o => o.FechaHoraFin == null).Count() > 0)
                return TimeSpan.FromSeconds(0);                        
            visitas = visitas.OrderBy(o => o.FechaHoraInicio).ToList();
            List<double> tiempos = new List<double>();
            int i = 0;
            for (i = 0; i < visitas.Count; i++) {
                double segundos;
                if (i == 0)
                    segundos = visitas[i].FechaHoraInicio.Subtract(visitas[i].FechaHoraInicial).TotalSeconds;
                else
                    if(visitas[i].FechaHoraInicial > visitas[i-1].FechaHoraFin)
                        segundos = visitas[i].FechaHoraInicio.Subtract(visitas[i].FechaHoraInicial).TotalSeconds;
                    else
                        segundos = visitas[i].FechaHoraInicio.Subtract((DateTime)visitas[i - 1].FechaHoraFin).TotalSeconds;

                tiempos.Add(segundos);
            }
            var tiempo = tiempos.Average();
            TimeSpan t = TimeSpan.FromSeconds(tiempo);
            return t;
        }*/

    }
}
