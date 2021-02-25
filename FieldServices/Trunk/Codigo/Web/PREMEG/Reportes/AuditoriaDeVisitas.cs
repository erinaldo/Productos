using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PREMEG.Acceso;
using MODMEG;
using System.Data;

namespace PREMEG.Reportes
{
    public class AuditoriaDeVisitas
    {
        public static GenerarReportes.DatosExistentes ValidarExistenciaInformacion(DateTime fecha1, DateTime fecha2)
        {
            bool res = false;
            using (MegaCableEntities contexto = new MegaCableEntities())
            {
                fecha2 = fecha2.AddDays(1);
                res = contexto.OrdenTrabajo.Any(o => o.Visita.FechaHoraInicio >= fecha1 && o.Visita.FechaHoraInicio <= fecha2 && o.IdVisita != null);
            }
            return (res ? GenerarReportes.DatosExistentes.Reporte : GenerarReportes.DatosExistentes.Ninguno);
        }

        internal static System.Data.DataTable ConsultarReporte(DateTime fecha1, DateTime fecha2)
        {
            fecha2 = fecha2.AddDays(1);
            MegaCableEntities ctx = new MegaCableEntities();

            //var qry = ctx.Region.
            //    Join(ctx.Sucursal, Region => Region.ClaveRegion, Sucursal => Sucursal.ClaveRegion, (Region, Sucursal) => new { Region, Sucursal }).
            //    Join(ctx.Usuario, Region => Region.Sucursal.ClaveSucursal, Usuario => Usuario.ClaveSucursal, (Region, Usuario) => new { Region, Usuario }).
            //    Join(ctx.Cuadrilla, Region => Region.Usuario.ClaveUsuario, Cuadrilla => Cuadrilla.ClaveCuadrillaSupervisor, (Region, Cuadrilla) => new { Region, Cuadrilla }).
            //    Join(ctx.OrdenTrabajo, Region => Region.Cuadrilla.ClaveCuadrilla, Orden => Orden.ClaveCuadrilla, (Region, Orden) => new { Region, Orden }).
            //    Where(o => o.Orden.FechaHoraProgramada >= fecha1 && o.Orden.FechaHoraProgramada <= fecha2 && o.Orden.IdVisita != null).
            //    Select(o => new { o.Orden.ValorReferencia, o.Orden.ValorReferencia1, o.Orden, o.Orden.Visita, o.Orden.Visita.Jornada, o.Region.Cuadrilla, o.Region.Region.Usuario, o.Region.Region.Region.Sucursal, o.Region.Region.Region.Region }).
            //    ToList();

            var qry = ctx.OrdenTrabajo.Where(o => o.Visita.FechaHoraInicio >= fecha1 && o.Visita.FechaHoraInicio <= fecha2 && o.IdVisita != null).
                Join(ctx.Cuadrilla, Orden => Orden.ClaveCuadrilla, Cuadrilla => Cuadrilla.ClaveCuadrilla, (Orden, Cuadrilla) => new { Orden, Cuadrilla }).
                Join(ctx.CuadrillaSupervisor, obj => obj.Cuadrilla.ClaveCuadrillaSupervisor, CuadrillaSupervisor => CuadrillaSupervisor.ClaveCuadrillaSupervisor, (obj, CuadrillaSupervisor) => new { obj, CuadrillaSupervisor }).
                Join(ctx.Sucursal, obj => obj.obj.Cuadrilla.ClaveSucursal, Sucursal => Sucursal.ClaveSucursal, (obj, Sucursal) => new { obj, Sucursal }).
                Join(ctx.Region, obj => obj.Sucursal.ClaveRegion, Region => Region.ClaveRegion, (obj, Region) => new { obj, Region }).
                Select(o => new
                {
                    o.obj.obj.obj.Orden.ValorReferencia,
                    o.obj.obj.obj.Orden.ValorReferencia1,
                    o.obj.obj.obj.Orden,
                    o.obj.obj.obj.Orden.Visita,
                    o.obj.obj.obj.Orden.Visita.Jornada,
                    o.obj.obj.obj.Cuadrilla,
                    Usuario = o.obj.obj.CuadrillaSupervisor,
                    o.obj.Sucursal,
                    o.Region
                }).
                ToList();                
            

            ctx.Dispose();

            List<Region> regiones = qry.Select(o => o.Region).Distinct().ToList();
            var contratos = qry.Distinct().ToList();
            
            var confirmados = qry.Where(o => o.ValorReferencia1.Valor == 1013 ||
                o.ValorReferencia1.Valor == 1016 ||
                o.ValorReferencia1.Valor == 1015 ||
                (o.ValorReferencia.Clave == "MOTFIN" && o.ValorReferencia.Grupo == 2)
                ).Distinct().ToList();

            var atendidos = qry.Where(o =>
                o.ValorReferencia1.Valor == 1016
                ).Distinct().ToList();

            var conProblema = qry.Where(o =>
                o.ValorReferencia1.Valor == 1015
                ).Distinct().ToList();

            var visitados = qry.Where(o =>
                o.ValorReferencia.Clave == "MOTFIN" && o.ValorReferencia.Grupo == 2
                ).Distinct().ToList();
            

            DataTable tabla = new DataTable();
            tabla.Columns.Add("idnodo");
            tabla.Columns.Add("idpadre");
            tabla.Columns.Add("nodoultimo");
            tabla.Columns.Add("_ClaveCuadrilla");
            tabla.Columns.Add("_FechaInicio");
            tabla.Columns.Add("_FechaFin");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("?ContratosAsignados");
            tabla.Columns.Add("?Confirmados");
            tabla.Columns.Add("?Atendidos");
            tabla.Columns.Add("?ConProblema");
            tabla.Columns.Add("?Visitados");
            tabla.Columns.Add("?%EficienciaServicio");
            tabla.Columns.Add("?%EficienciaTecnico");
            
            tabla.PrimaryKey = new DataColumn[] { tabla.Columns["idnodo"] };

            DataRow fila = tabla.NewRow();
            fila["idnodo"] = "node-1";
            fila["idpadre"] = "";
            fila["nodoultimo"] = false;
            fila["_ClaveCuadrilla"] = "";
            fila["_FechaInicio"] = "";
            fila["_FechaFin"] = "";                                    
            fila["Nombre"] = "MegaCable";
            fila["?ContratosAsignados"] = contratos.Count.ToString();
            fila["?Confirmados"] = confirmados.Count.ToString();
            fila["?Atendidos"] = atendidos.Count.ToString();
            fila["?ConProblema"] = conProblema.Count.ToString();
            fila["?Visitados"] = visitados.Count.ToString();
            fila["?%EficienciaServicio"] = confirmados.Count == 0 ? 0 : (atendidos.Count * 100) / confirmados.Count;
            fila["?%EficienciaTecnico"] = confirmados.Count == 0 ? 0 : ((atendidos.Count + conProblema.Count) * 100) / confirmados.Count;




            
            tabla.Rows.Add(fila);

            int indice = 1;
            foreach (var region in regiones)
            {
                indice++;                               
                var contratosReg = contratos.Where(o => o.Region.ClaveRegion == region.ClaveRegion).ToList();
                if (contratosReg.Count == 0) continue;
                var confirmadosReg = confirmados.Where(o => o.Region.ClaveRegion == region.ClaveRegion).ToList();
                var atendidosReg = atendidos.Where(o => o.Region.ClaveRegion == region.ClaveRegion).ToList();
                var conProblemaReg = conProblema.Where(o => o.Region.ClaveRegion == region.ClaveRegion).ToList();
                var visitadosReg = visitados.Where(o => o.Region.ClaveRegion == region.ClaveRegion).ToList();


                fila = tabla.NewRow();
                fila["idnodo"] = "node-" + indice.ToString();
                fila["idpadre"] = "node-1";
                fila["nodoultimo"] = false;
                fila["_ClaveCuadrilla"] = "";
                fila["_FechaInicio"] = "";
                fila["_FechaFin"] = "";                                    
                fila["Nombre"] = region.Nombre;

                fila["?ContratosAsignados"] = contratosReg.Count.ToString();
                fila["?Confirmados"] = confirmadosReg.Count.ToString();
                fila["?Atendidos"] = atendidosReg.Count.ToString();
                fila["?ConProblema"] = conProblemaReg.Count.ToString();
                fila["?Visitados"] = visitadosReg.Count.ToString();
                fila["?%EficienciaServicio"] = confirmadosReg.Count == 0 ? 0 : (atendidosReg.Count * 100) / confirmadosReg.Count;
                fila["?%EficienciaTecnico"] = confirmadosReg.Count == 0 ? 0 : ((atendidosReg.Count + conProblemaReg.Count) * 100) / confirmadosReg.Count; ;

                tabla.Rows.Add(fila);


                int indice2 = 0;
                foreach (var sucursal in qry.Where(o => o.Region.ClaveRegion == region.ClaveRegion).Select(o => o.Sucursal).Distinct())
                {
                    indice2++;

                    var contratosSuc = contratosReg.Where(o => o.Sucursal.ClaveSucursal == sucursal.ClaveSucursal).ToList();
                    if (contratosSuc.Count == 0) continue;
                    var confirmadosSuc = confirmadosReg.Where(o => o.Sucursal.ClaveSucursal == sucursal.ClaveSucursal).ToList();
                    var atendidosSuc = atendidosReg.Where(o => o.Sucursal.ClaveSucursal == sucursal.ClaveSucursal).ToList();
                    var conProblemaSuc = conProblemaReg.Where(o => o.Sucursal.ClaveSucursal == sucursal.ClaveSucursal).ToList();
                    var visitadosSuc = visitadosReg.Where(o => o.Sucursal.ClaveSucursal == sucursal.ClaveSucursal).ToList();


                    fila = tabla.NewRow();
                    fila["idnodo"] = "node-" + indice.ToString() + "-" + indice2.ToString();
                    fila["idpadre"] = "node-" + indice.ToString();
                    fila["nodoultimo"] = false;
                    fila["_ClaveCuadrilla"] = "";
                    fila["_FechaInicio"] = "";
                    fila["_FechaFin"] = "";                                    
                    fila["Nombre"] = sucursal.Nombre;

                    fila["?ContratosAsignados"] = contratosSuc.Count.ToString();
                    fila["?Confirmados"] = confirmadosSuc.Count.ToString();
                    fila["?Atendidos"] = atendidosSuc.Count.ToString();
                    fila["?ConProblema"] = conProblemaSuc.Count.ToString();
                    fila["?Visitados"] = visitadosSuc.Count.ToString();
                    fila["?%EficienciaServicio"] = confirmadosSuc.Count == 0 ? 0 : (atendidosSuc.Count * 100) / confirmadosSuc.Count;
                    fila["?%EficienciaTecnico"] = confirmadosSuc.Count == 0 ? 0 : ((atendidosSuc.Count + conProblemaSuc.Count) * 100) / confirmadosSuc.Count; ;

                    tabla.Rows.Add(fila);


                    int indice3 = 0;
                    foreach (var usuario in qry.Where(o => o.Sucursal.ClaveSucursal == sucursal.ClaveSucursal).Select(o => o.Usuario).Distinct())
                    {
                        indice3++;

                        var contratosUsu = contratosSuc.Where(o => o.Usuario.ClaveCuadrillaSupervisor == usuario.ClaveCuadrillaSupervisor).ToList();
                        if (contratosUsu.Count == 0) continue;
                        var confirmadosUsu = confirmadosSuc.Where(o => o.Usuario.ClaveCuadrillaSupervisor == usuario.ClaveCuadrillaSupervisor).ToList();
                        var atendidosUsu = atendidosSuc.Where(o => o.Usuario.ClaveCuadrillaSupervisor == usuario.ClaveCuadrillaSupervisor).ToList();
                        var conProblemaUsu = conProblemaSuc.Where(o => o.Usuario.ClaveCuadrillaSupervisor == usuario.ClaveCuadrillaSupervisor).ToList();
                        var visitadosUsu = visitadosSuc.Where(o => o.Usuario.ClaveCuadrillaSupervisor == usuario.ClaveCuadrillaSupervisor).ToList();

                        fila = tabla.NewRow();
                        fila["idnodo"] = "node-" + indice.ToString() + "-" + indice2.ToString() + "-" + indice3.ToString();
                        fila["idpadre"] = "node-" + indice.ToString() + "-" + indice2.ToString();
                        fila["nodoultimo"] = false;
                        fila["_ClaveCuadrilla"] = "";
                        fila["_FechaInicio"] = "";
                        fila["_FechaFin"] = "";                                    
                        fila["Nombre"] = usuario.Nombre;

                        fila["?ContratosAsignados"] = contratosUsu.Count.ToString();
                        fila["?Confirmados"] = confirmadosUsu.Count.ToString();
                        fila["?Atendidos"] = atendidosUsu.Count.ToString();
                        fila["?ConProblema"] = conProblemaUsu.Count.ToString();
                        fila["?Visitados"] = visitadosUsu.Count.ToString();
                        fila["?%EficienciaServicio"] = confirmadosUsu.Count == 0 ? 0 : (atendidosUsu.Count * 100) / confirmadosUsu.Count;
                        fila["?%EficienciaTecnico"] = confirmadosUsu.Count == 0 ? 0 : ((atendidosUsu.Count + conProblemaUsu.Count) * 100) / confirmadosUsu.Count; ;
                        tabla.Rows.Add(fila);

                        int indice4 = 0;
                        foreach (var cuadrilla in qry.Where(o => o.Usuario.ClaveCuadrillaSupervisor == usuario.ClaveCuadrillaSupervisor).Select(o => o.Cuadrilla).Distinct())
                        {
                            indice4++;

                            var contratosCua = contratosUsu.Where(o => o.Cuadrilla.ClaveCuadrilla == cuadrilla.ClaveCuadrilla).ToList();
                            if (contratosCua.Count == 0) continue;
                            var confirmadosCua = confirmadosUsu.Where(o => o.Cuadrilla.ClaveCuadrilla == cuadrilla.ClaveCuadrilla).ToList();
                            var atendidosCua = atendidosUsu.Where(o => o.Cuadrilla.ClaveCuadrilla == cuadrilla.ClaveCuadrilla).ToList();
                            var conProblemaCua = conProblemaUsu.Where(o => o.Cuadrilla.ClaveCuadrilla == cuadrilla.ClaveCuadrilla).ToList();
                            var visitadosCua = visitadosUsu.Where(o => o.Cuadrilla.ClaveCuadrilla == cuadrilla.ClaveCuadrilla).ToList();


                            fila = tabla.NewRow();
                            fila["idnodo"] = "node-" + indice.ToString() + "-" + indice2.ToString() + "-" + indice3.ToString() + "-" + indice4.ToString() + "_" + cuadrilla.ClaveCuadrilla;
                            fila["idpadre"] = "node-" + indice.ToString() + "-" + indice2.ToString() + "-" + indice3.ToString();
                            fila["nodoultimo"] = true;
                            fila["_ClaveCuadrilla"] = cuadrilla.ClaveCuadrilla;
                            fila["_FechaInicio"] = fecha1 ;
                            fila["_FechaFin"] = fecha2;                                    
                            fila["Nombre"] = cuadrilla.Nombre;

                            fila["?ContratosAsignados"] = contratosCua.Count.ToString();
                            fila["?Confirmados"] = confirmadosCua.Count.ToString();
                            fila["?Atendidos"] = atendidosCua.Count.ToString();
                            fila["?ConProblema"] = conProblemaCua.Count.ToString();
                            fila["?Visitados"] = visitadosCua.Count.ToString();
                            fila["?%EficienciaServicio"] = atendidosCua.Count == 0 ? 0 : (atendidosCua.Count * 100) / confirmadosCua.Count;
                            fila["?%EficienciaTecnico"] = atendidosCua.Count == 0 ? 0 : ((atendidosCua.Count + conProblemaCua.Count) * 100) / confirmadosCua.Count; 
                            tabla.Rows.Add(fila);
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
            tabla.Columns.Add("?Hora");
            tabla.Columns.Add("?Estatus");
            tabla.Columns.Add("_ClaveSucursal");
            tabla.Columns.Add("_RutaImagen");
            

            if (filaSel != null)
            {
                string ClaveCuadrilla = filaSel["_ClaveCuadrilla"].ToString().Trim();
                DateTime FechaAgenda = Convert.ToDateTime(filaSel["_FechaInicio"]);
                DateTime FechaFin = Convert.ToDateTime(filaSel["_FechaFin"]);
                using (MegaCableEntities contexto = new MegaCableEntities())
                {
                    FechaFin = FechaFin.AddDays(1);
                    string ClaveSucursal = (from cua in contexto.Cuadrilla
                                            where cua.ClaveCuadrilla == ClaveCuadrilla
                                            select cua.ClaveSucursal).First().ToString();
                    var lista = from ot in contexto.OrdenTrabajo
                                where
                                ot.ClaveCuadrilla == ClaveCuadrilla &&
                                ot.Visita.FechaHoraInicio >= FechaAgenda &&
                                ot.Visita.FechaHoraInicio < FechaFin
                                select new
                                {
                                    Fecha = ot.Visita.FechaHoraInicio,
                                    Tecnico = ot.Visita.Jornada.Usuario.Nombre,
                                    Suscriptor = ot.Suscriptor.ClaveSuscriptor,
                                    Trabajo = ot.Trabajo.Descripcion,
                                    Estatus = ot.ValorReferencia1.Descripcion,
                                    RutaImagenIni = ot.Visita.SuscriptorVisitado.FirstOrDefault()

                                };
                    foreach (var l in lista)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["?Fecha"] = l.Fecha.ToString("dd/MM/yyyy");
                        fila["?Tecnico"] = l.Tecnico;
                        fila["?NoContrato"] = l.Suscriptor;
                        fila["?Hora"] = l.Fecha.ToString("hh:mm:ss");
                        fila["?Estatus"] = l.Estatus;
                        fila["_ClaveSucursal"] = ClaveSucursal;
                        fila["_RutaImagen"] = l.RutaImagenIni == null ? "" : l.RutaImagenIni.IdImagen.ToString();
                        tabla.Rows.Add(fila);
                    }
                }
            }
            return tabla;
        }
    }
}
