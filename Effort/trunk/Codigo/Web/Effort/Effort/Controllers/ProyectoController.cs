using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Effort.Models;
using Effort.Filters;
using Effort.Models.Reportes;

namespace Effort.Controllers
{
    [SessionExpireFilter]
    public class ProyectoController : Controller
    {
        //
        // GET: /Proyecto/
        EffortEntities context = new EffortEntities();

        public ActionResult Index(string message = null,int page = 0, int pageSize = 10)
        {
            Equipo currentUser = ((Equipo)Session["Login"]);
            bool admin = currentUser.perfil.Equals("Administrador");

            var count = admin?context.Proyecto.Count()
                :
                (from p in context.Proyecto
                        join t in context.Tarea on p.idProyecto equals t.idProyecto
                        join e in context.Equipo on t.idEquipo equals e.idEquipo
                        where e.idEquipo == currentUser.idEquipo
                        select p).Distinct().Count() ;

            var maxPage = ((count / pageSize) - (count % pageSize == 0 ? 1 : 0));

            page = page >= 0 ? page : 0;
            page = page <= maxPage ? page : maxPage;
            //var data = context.Proyecto.OrderBy(p => p.idProyecto).Skip(page * pageSize).Take(pageSize).ToList();

            List<CustomProyecto> data = null;
            if (count > 0)
            {
                data = admin ? (from p in context.Proyecto
                                join ep in context.Estados_tareas on p.EstadoProyecto equals ep.idEstado
                                join e in context.Equipo on p.administrador_proyecto equals e.idEquipo
                                select new CustomProyecto
                                {
                                    idProyecto = p.idProyecto,
                                    nombre = p.nombre,
                                    fechaInicio = p.fechaInicio,
                                    duracion = p.duracion,
                                    presupuesto_hrs = p.presupuesto_hrs,
                                    presupuesto_precio = p.presupuesto_precio,
                                    administrador_proyecto = p.administrador_proyecto,
                                    EstadoProyecto = ep.descripcion
                                }).OrderBy(p => p.idProyecto).Skip(page * pageSize).Take(pageSize).ToList()
                             :
                             (from p in context.Proyecto
                              join ep in context.Estados_tareas on p.EstadoProyecto equals ep.idEstado
                              join t in context.Tarea on p.idProyecto equals t.idProyecto
                              join e in context.Equipo on t.idEquipo equals e.idEquipo
                              where e.idEquipo == currentUser.idEquipo
                              select new CustomProyecto
                              {
                                  idProyecto = p.idProyecto,
                                  nombre = p.nombre,
                                  fechaInicio = p.fechaInicio,
                                  duracion = p.duracion,
                                  presupuesto_hrs = p.presupuesto_hrs,
                                  presupuesto_precio = p.presupuesto_precio,
                                  administrador_proyecto = p.administrador_proyecto,
                                  EstadoProyecto = ep.descripcion
                              }
                              ).Distinct().OrderBy(p => p.idProyecto).Skip(page * pageSize).Take(pageSize).ToList()
                             ;
            }
            

            ViewBag.MaxPage = maxPage+1; 
            ViewBag.Page = page;
            ViewBag.Count = count;
            //List<Proyecto> proyectos = context.Proyecto.ToList();
            ViewBag.Success = message;
            return View(data);
        }

        [RoleFilter]
        public ActionResult Create()
        {

            getCatalogos(-1,null);
            return View();
        }

         [RoleFilter]
        [HttpPost]
        public ActionResult Create(Proyecto proyecto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    context.Proyecto.Add(proyecto);
                    context.SaveChanges();

                    return RedirectToAction("Index", new { message = "!Proyecto creado exitosamente!" });
                }
                catch (Exception e)
                {
                    ViewBag.Error = "El identificador del proyecto ya existe.";
                    getCatalogos(proyecto.EstadoProyecto, proyecto.administrador_proyecto);
                    return View(proyecto);
                }
            }
            getCatalogos(proyecto.EstadoProyecto, proyecto.administrador_proyecto);
            return View(proyecto);
            
        }

         [RoleFilter]
        public ActionResult Edit(string id = null)
        {
            Proyecto proyecto = context.Proyecto.Find(id);           
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            getCatalogos(proyecto.EstadoProyecto, proyecto.administrador_proyecto);
            return View(proyecto);
        }
         [RoleFilter]
        [HttpPost]
        public ActionResult Edit(Proyecto proyecto)
        {
            System.Diagnostics.Debug.WriteLine("EDIT");
            System.Diagnostics.Debug.WriteLine(proyecto.presupuesto_precio);
            if (ModelState.IsValid)
            {
               
                Proyecto proyectoDb = context.Proyecto.SingleOrDefault(p => p.idProyecto == proyecto.idProyecto);
                proyectoDb.nombre = proyecto.nombre;
                proyectoDb.fechaInicio = proyecto.fechaInicio;
                proyectoDb.duracion = proyecto.duracion;
                proyectoDb.presupuesto_hrs = proyecto.presupuesto_hrs;
                proyectoDb.presupuesto_precio = proyecto.presupuesto_precio;
                proyectoDb.administrador_proyecto = proyecto.administrador_proyecto;
                proyectoDb.EstadoProyecto = proyecto.EstadoProyecto;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            System.Diagnostics.Debug.WriteLine("ERROR MODEL");
            getCatalogos(proyecto.EstadoProyecto, proyecto.administrador_proyecto);
            return View(proyecto);
        }

         [RoleFilter]
        public ActionResult Delete(string id = null)
        {
            Proyecto proyecto = context.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            else if (proyecto.Tarea != null)
            {
                if (proyecto.Tarea.Count() > 0)
                {
                    ViewBag.Error = "Este proyecto no puede eliminarse debido a que tiene tareas asignadas.";
                    getCatalogos(proyecto.EstadoProyecto, proyecto.administrador_proyecto);
                    return View("Edit",proyecto);
                }
                else
                {
                    context.Proyecto.Remove(proyecto);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                context.Proyecto.Remove(proyecto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }


        }

        public void getCatalogos(int? estadoId, String equipoId)
        {
            List<Estados_tareas> estatus = context.Estados_tareas.ToList();
            List<SelectListItem> estados = new List<SelectListItem>();

            foreach (Estados_tareas estado in estatus)
            {
                estados.Add(new SelectListItem { Text = estado.descripcion, Value = estado.idEstado.ToString(), Selected = estadoId == estado.idEstado?true:false });
            }

            List<Equipo> empleados = context.Equipo.ToList();
            List<SelectListItem> empleadosSelect = new List<SelectListItem>();

            foreach (Equipo equipo in empleados)
            {
                empleadosSelect.Add(new SelectListItem { Text = equipo.nombre, Value = equipo.idEquipo, Selected = equipo.idEquipo.Equals(equipoId)});
            }

            ViewData["EstadoProyecto"] = estados;
            ViewData["administrador_proyecto"] = empleadosSelect;
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult tareasPorProyecto()
        {
            Equipo currentUser = ((Equipo)Session["Login"]);
            bool admin = currentUser.perfil.Equals("Administrador");

            var tareasPorProyecto = admin?
                from t in context.Tarea
                join p in context.Proyecto on t.idProyecto equals p.idProyecto
                group t by new { p.nombre, t.idProyecto} into tgroup
                select new { 
                    nombreProyecto = tgroup.Key.nombre, 
                    tareasEnCurso = tgroup.Count(t=> t.idEstado==1),
                    tareasPendientes = tgroup.Count(t => t.idEstado == 2),
                    tareasCompletadas = tgroup.Count(t => t.idEstado == 3),
                    tareasCanceladas = tgroup.Count(t => t.idEstado == 4)
                }:
                from t in context.Tarea
                join p in context.Proyecto on t.idProyecto equals p.idProyecto
                join e in context.Equipo on t.idEquipo equals e.idEquipo
                where e.idEquipo == currentUser.idEquipo
                group t by new { p.nombre, t.idProyecto } into tgroup
                select new
                {
                    nombreProyecto = tgroup.Key.nombre,
                    tareasEnCurso = tgroup.Count(t => t.idEstado == 1),
                    tareasPendientes = tgroup.Count(t => t.idEstado == 2),
                    tareasCompletadas = tgroup.Count(t => t.idEstado == 3),
                    tareasCanceladas = tgroup.Count(t => t.idEstado == 4)
                }
                ;

            return Json(tareasPorProyecto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult proyectosTareasAtrasadas()
        {
            var tareasAtrasadas =
                from t in context.Tarea
                join p in context.Proyecto on t.idProyecto equals p.idProyecto
                where (t.idEstado != 3 && t.idEstado != 4) && t.fecha_fin < DateTime.Now
                group t by new { p.nombre, t.idProyecto } into tgroup
                select new { nombreProyecto = tgroup.Key.nombre, tareasAtrasadas = tgroup.Count() };

            return Json(tareasAtrasadas, JsonRequestBehavior.AllowGet);

        }

    }
}
