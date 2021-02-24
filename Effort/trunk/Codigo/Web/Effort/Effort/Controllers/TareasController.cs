using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Effort.Models;
using Effort.Filters;

namespace Effort.Controllers
{
    [SessionExpireFilter]
    public class TareasController : Controller
    {
        //
        // GET: /Tareas/
        EffortEntities context = new EffortEntities();
        
        public ActionResult Index(string buscador = "", string buscarCampo = "", int page = 0, int pageSize = 10, string message = null)
        {
            Equipo currentUser = ((Equipo)Session["Login"]);
            bool admin = currentUser.perfil.Equals("Administrador");

            var count = admin?context.Tarea.Count():context.Tarea.Count(t=>t.idEquipo ==currentUser.idEquipo);
            var maxPage = ((count / pageSize) - (count % pageSize == 0 ? 1 : 0));

            page = page >= 0 ? page : 0;
            page = page <= maxPage ? page : maxPage;
            // System.Diagnostics.Debug.WriteLine("Pasa: " + buscador + " , " + buscarCampo);
            List<vista_tarea> consulta = null;
            if (count > 0)
            {
                 consulta = admin ? (from t in context.Tarea
                                        join p in context.Proyecto on t.idProyecto equals p.idProyecto
                                        join et in context.Estados_tareas on t.idEstado equals et.idEstado
                                     select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).OrderBy(t => t.idTarea).Skip(page * pageSize).Take(pageSize).ToList()
                            :
                            (from t in context.Tarea
                             join p in context.Proyecto on t.idProyecto equals p.idProyecto
                             join et in context.Estados_tareas on t.idEstado equals et.idEstado
                             where t.idEquipo == currentUser.idEquipo
                             select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).OrderBy(t => t.idTarea).Skip(page * pageSize).Take(pageSize).ToList();
            }
            

            switch (buscarCampo)
            {
                case "titulo":

                    count = admin?(from t in context.Tarea
                             join p in context.Proyecto on t.idProyecto equals p.idProyecto
                             join et in context.Estados_tareas on t.idEstado equals et.idEstado
                             where t.titulo.ToLower().Contains(buscador.ToLower())
                                   select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).ToList().Count
                             :
                             (from t in context.Tarea
                              join p in context.Proyecto on t.idProyecto equals p.idProyecto
                              join et in context.Estados_tareas on t.idEstado equals et.idEstado
                              where t.titulo.ToLower().Contains(buscador.ToLower()) && t.idEquipo == currentUser.idEquipo
                              select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).ToList().Count;

                    maxPage = ((count / pageSize) - (count % pageSize == 0 ? 1 : 0));
                    page = page >= 0 ? page : 0;
                    page = page <= maxPage ? page : maxPage;

                    if (count > 0)
                    {
                        consulta = admin ? (from t in context.Tarea
                                            join p in context.Proyecto on t.idProyecto equals p.idProyecto
                                            join et in context.Estados_tareas on t.idEstado equals et.idEstado
                                            where t.titulo.ToLower().Contains(buscador.ToLower())
                                            select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).OrderBy(t => t.idTarea).Skip(page * pageSize).Take(pageSize).ToList()
                                    :
                                    (from t in context.Tarea
                                     join p in context.Proyecto on t.idProyecto equals p.idProyecto
                                     join et in context.Estados_tareas on t.idEstado equals et.idEstado
                                     where t.titulo.ToLower().Contains(buscador.ToLower()) && t.idEquipo == currentUser.idEquipo
                                     select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).OrderBy(t => t.idTarea).Skip(page * pageSize).Take(pageSize).ToList();
                    }
                    break;
                case "proyecto":

                    count = admin?(from t in context.Tarea
                             join p in context.Proyecto on t.idProyecto equals p.idProyecto
                             join et in context.Estados_tareas on t.idEstado equals et.idEstado
                             where p.nombre.ToLower().Contains(buscador.ToLower())
                                   select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).ToList().Count
                             :
                             (from t in context.Tarea
                              join p in context.Proyecto on t.idProyecto equals p.idProyecto
                              join et in context.Estados_tareas on t.idEstado equals et.idEstado
                              where p.nombre.ToLower().Contains(buscador.ToLower()) && t.idEquipo == currentUser.idEquipo
                              select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).ToList().Count;

                    maxPage = ((count / pageSize) - (count % pageSize == 0 ? 1 : 0));
                    page = page >= 0 ? page : 0;
                    page = page <= maxPage ? page : maxPage;

                    if (count > 0)
                    {
                        consulta = admin ? (from t in context.Tarea
                                            join p in context.Proyecto on t.idProyecto equals p.idProyecto
                                            join et in context.Estados_tareas on t.idEstado equals et.idEstado
                                            where p.nombre.ToLower().Contains(buscador.ToLower())
                                            select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).OrderBy(t => t.idTarea).Skip(page * pageSize).Take(pageSize).ToList()
                                    :
                                    (from t in context.Tarea
                                     join p in context.Proyecto on t.idProyecto equals p.idProyecto
                                     join et in context.Estados_tareas on t.idEstado equals et.idEstado
                                     where p.nombre.ToLower().Contains(buscador.ToLower()) && t.idEquipo == currentUser.idEquipo
                                     select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).OrderBy(t => t.idTarea).Skip(page * pageSize).Take(pageSize).ToList();
                    }
                    break;

                case "estado":

                    count = admin?(from t in context.Tarea
                             join p in context.Proyecto on t.idProyecto equals p.idProyecto
                             join et in context.Estados_tareas on t.idEstado equals et.idEstado
                             where et.descripcion.ToLower().Contains(buscador.ToLower())
                                   select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).ToList().Count
                             :
                             (from t in context.Tarea
                              join p in context.Proyecto on t.idProyecto equals p.idProyecto
                              join et in context.Estados_tareas on t.idEstado equals et.idEstado
                              where et.descripcion.ToLower().Contains(buscador.ToLower()) && t.idEquipo == currentUser.idEquipo
                              select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).ToList().Count;

                    maxPage = ((count / pageSize) - (count % pageSize == 0 ? 1 : 0));
                    page = page >= 0 ? page : 0;
                    page = page <= maxPage ? page : maxPage;

                    if (count > 0)
                    {

                        consulta = admin ? (from t in context.Tarea
                                            join p in context.Proyecto on t.idProyecto equals p.idProyecto
                                            join et in context.Estados_tareas on t.idEstado equals et.idEstado
                                            where et.descripcion.ToLower().Contains(buscador.ToLower())
                                            select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).OrderBy(t => t.idTarea).Skip(page * pageSize).Take(pageSize).ToList()
                                    :
                                    (from t in context.Tarea
                                     join p in context.Proyecto on t.idProyecto equals p.idProyecto
                                     join et in context.Estados_tareas on t.idEstado equals et.idEstado
                                     where et.descripcion.ToLower().Contains(buscador.ToLower()) && t.idEquipo == currentUser.idEquipo
                                     select new vista_tarea { idTarea = t.idTarea, tituloTarea = t.titulo, nombreProyecto = p.nombre, estadoDesc = et.descripcion, presupuesto = t.presupuesto, horas_estimadas_dia = t.horas_estimadas_dia, fecha_inicio = t.fecha_fin, fecha_fin = t.fecha_fin, avance = t.avanceTarea, idEquipo = t.idEquipo, descripcion = t.descripcion }).OrderBy(t => t.idTarea).Skip(page * pageSize).Take(pageSize).ToList();
                    }
                    break;
            }

            ViewBag.BuscarCampo = buscarCampo;
            ViewBag.Buscador = buscador;
            ViewBag.MaxPage = maxPage + 1;
            ViewBag.Page = page;
            ViewBag.Count = count;
            ViewBag.Success = message;
            return View(consulta);
        }

        [RoleFilter]
        public ActionResult Create()
        {
            getCatalogos(null, null, -1, -1, -1, -1);
            return View();
        }

        [RoleFilter]
        [HttpPost]
        public ActionResult Create(Tarea tarea)
        {

            if (ModelState.IsValid)
            {
                context.Tarea.Add(tarea);
                context.SaveChanges();
                ViewBag.Success = "!Tarea creada exitosamente!";
                getCatalogos(null, null, -1, -1, -1, -1);
                return View();
            }
            getCatalogos(tarea.idProyecto, tarea.idEquipo, tarea.idTipo, tarea.idEstado, tarea.predecesora, tarea.idVersion);
            return View(tarea);

        }

        public ActionResult CreateUsuario(string idProyecto = null)
        {

            getCatalogosUsuario(idProyecto, ((Equipo)Session["Login"]).idEquipo, -1, -1, -1, -1);
            ViewBag.idProyecto = idProyecto;
            ViewBag.idEquipo = ((Equipo)Session["Login"]).idEquipo;
            return View();
        }

        [HttpPost]
        public ActionResult CreateUsuario(Tarea tarea)
        {

            if (ModelState.IsValid)
            {
                context.Tarea.Add(tarea);
                context.SaveChanges();
                ViewBag.Success = "!Tarea creada exitosamente!";
                getCatalogosUsuario(tarea.idProyecto, tarea.idEquipo, -1, -1, -1, -1);
                return View();
            }
            getCatalogosUsuario(tarea.idProyecto, tarea.idEquipo, tarea.idTipo, tarea.idEstado, tarea.predecesora, tarea.idVersion);
            return View(tarea);

        }

        [RoleFilter]
        public ActionResult Edit(int id = -1)
        {
            Tarea tarea = context.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            getCatalogos(tarea.idProyecto, tarea.idEquipo, tarea.idTipo, tarea.idEstado, tarea.predecesora, tarea.idVersion);

            return View(tarea);
        }

        [RoleFilter]
        [HttpPost]
        public ActionResult Edit(Tarea tarea)
        {

            System.Diagnostics.Debug.WriteLine(tarea);
            if (ModelState.IsValid)
            {
                Tarea tareaDb = context.Tarea.SingleOrDefault(t => t.idTarea == tarea.idTarea);
                tareaDb.idProyecto = tarea.idProyecto;
                tareaDb.titulo = tarea.titulo;
                tareaDb.descripcion = tarea.descripcion;
                tareaDb.presupuesto = tarea.presupuesto;
                tareaDb.horas_estimadas_dia = tarea.horas_estimadas_dia;
                tareaDb.fecha_inicio = tarea.fecha_inicio;
                tareaDb.fecha_fin = tarea.fecha_fin;
                tareaDb.idTipo = tarea.idTipo;
                tareaDb.idEquipo = tarea.idEquipo;
                tareaDb.idEstado = tarea.idEstado;
                tareaDb.predecesora = tarea.predecesora;
                tareaDb.idVersion = tarea.idVersion;

                context.SaveChanges();

                return RedirectToAction("Index");

            }

            getCatalogos(tarea.idProyecto, tarea.idEquipo, tarea.idTipo, tarea.idEstado, tarea.predecesora, tarea.idVersion);
            return View(tarea);
        }

        [RoleFilter]
        public ActionResult Delete(int? id = -1)
        {
            Tarea tarea = context.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            else if (tarea.Esfuerzo != null)
            {
                if (tarea.Esfuerzo.Count() > 0)
                {
                    ViewBag.Error = "Esta tarea no puede eliminarse debido a que tiene esfuerzos asociados.";
                    getCatalogos(tarea.idProyecto, tarea.idEquipo, tarea.idTipo, tarea.idEstado, tarea.predecesora, tarea.idVersion);
                    return View("Edit", tarea);
                }
                else
                {
                    context.Tarea.Remove(tarea);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                context.Tarea.Remove(tarea);
                context.SaveChanges();
                return RedirectToAction("Index");
            }


        }

        public JsonResult updateTareas(string idProyecto)
        {
            List<Tarea> tareasList = (from t in context.Tarea
                                      where t.idProyecto == idProyecto
                                      select t).ToList();

            List<SelectListItem> tareasItem = new List<SelectListItem>();

            tareasItem.Add(new SelectListItem { Text = "Elija una opción…", Value = DBNull.Value.ToString() });

            foreach (Tarea tarea in tareasList)
            {
                tareasItem.Add(new SelectListItem { Text = tarea.titulo, Value = tarea.idTarea.ToString() });
            }

            return Json(tareasItem,JsonRequestBehavior.AllowGet);

        }
        public void getCatalogos(string proyectoId, string equipoId, int? tipoId, int? estadoId,int? tareaId, int? versionId)
        {
            List<Proyecto> proyectosList = context.Proyecto.ToList();
            List<SelectListItem> proyectosItems = new List<SelectListItem>();

            foreach (Proyecto proyecto in proyectosList)
            {
                proyectosItems.Add(new SelectListItem { Text = proyecto.nombre, Value = proyecto.idProyecto, Selected = proyecto.idProyecto.Equals(proyectoId) });
            }


            List<Tipo_tarea> tipoTareaList = context.Tipo_tarea.ToList();
            List<SelectListItem> tipoTareaItems = new List<SelectListItem>();

            foreach (Tipo_tarea tipoTarea in tipoTareaList)
            {
                tipoTareaItems.Add(new SelectListItem { Text = tipoTarea.descripcion, Value = tipoTarea.idTipo.ToString(), Selected = tipoId == tipoTarea.idTipo ? true : false });
            }

            List<Equipo> empleados = context.Equipo.ToList();
            List<SelectListItem> empleadosSelect = new List<SelectListItem>();

            foreach (Equipo equipo in empleados)
            {
                empleadosSelect.Add(new SelectListItem { Text = equipo.nombre, Value = equipo.idEquipo, Selected = equipo.idEquipo.Equals(equipoId) });
            }


            List<Estados_tareas> estatus = context.Estados_tareas.ToList();
            List<SelectListItem> estados = new List<SelectListItem>();

            foreach (Estados_tareas estado in estatus)
            {
                estados.Add(new SelectListItem { Text = estado.descripcion, Value = estado.idEstado.ToString(), Selected = estadoId == estado.idEstado ? true : false });
            }

            List<Tarea> tareasList = context.Tarea.ToList();

            List<SelectListItem> tareasItem = new List<SelectListItem>();

            tareasItem.Add(new SelectListItem { Text = "Elija una opción…", Value = DBNull.Value.ToString(), Selected = tareaId == -1 });

            foreach (Tarea tarea in tareasList)
            {
                tareasItem.Add(new SelectListItem { Text = tarea.titulo, Value = tarea.idTarea.ToString()});
            }

            List<Versiones> versionesList = context.Versiones.ToList();
            List<SelectListItem> versionesItem = new List<SelectListItem>();

            foreach (Versiones version in versionesList)
            {
                versionesItem.Add(new SelectListItem { Text = version.descripcion, Value = version.idVersion.ToString(), Selected = versionId == version.idVersion ? true : false });
            }

            ViewData["idProyecto"] = proyectosItems;
            ViewData["idTipo"] = tipoTareaItems;
            ViewData["idEquipo"] = empleadosSelect;
            ViewData["idEstado"] = estados;
            ViewData["predecesora"] = tareasItem;
            ViewData["idVersion"] = versionesItem;
        }

        public void getCatalogosUsuario(string proyectoId, string equipoId, int? tipoId, int? estadoId, int? tareaId, int? versionId)
        {
            Proyecto proyecto = context.Proyecto.SingleOrDefault(p => p.idProyecto == proyectoId);
            List<SelectListItem> proyectosItems = new List<SelectListItem>();
            proyectosItems.Add(new SelectListItem { Text = proyecto.nombre, Value = proyecto.idProyecto, Selected = true});
            


            List<Tipo_tarea> tipoTareaList = context.Tipo_tarea.ToList();
            List<SelectListItem> tipoTareaItems = new List<SelectListItem>();

            foreach (Tipo_tarea tipoTarea in tipoTareaList)
            {
                tipoTareaItems.Add(new SelectListItem { Text = tipoTarea.descripcion, Value = tipoTarea.idTipo.ToString(), Selected = tipoId == tipoTarea.idTipo ? true : false });
            }

            Equipo equipo = context.Equipo.SingleOrDefault(e => e.idEquipo == equipoId);
            List<SelectListItem> empleadosSelect = new List<SelectListItem>();

            empleadosSelect.Add(new SelectListItem { Text = equipo.nombre, Value = equipo.idEquipo, Selected = true });
            


            List<Estados_tareas> estatus = context.Estados_tareas.ToList();
            List<SelectListItem> estados = new List<SelectListItem>();

            foreach (Estados_tareas estado in estatus)
            {
                estados.Add(new SelectListItem { Text = estado.descripcion, Value = estado.idEstado.ToString(), Selected = estadoId == estado.idEstado ? true : false });
            }

            List<Tarea> tareasList = context.Tarea.ToList();

            List<SelectListItem> tareasItem = new List<SelectListItem>();

            tareasItem.Add(new SelectListItem { Text = "Elija una opción…", Value = DBNull.Value.ToString(), Selected = tareaId == -1 });

            foreach (Tarea tarea in tareasList)
            {
                tareasItem.Add(new SelectListItem { Text = tarea.titulo, Value = tarea.idTarea.ToString() });
            }

            List<Versiones> versionesList = context.Versiones.ToList();
            List<SelectListItem> versionesItem = new List<SelectListItem>();

            foreach (Versiones version in versionesList)
            {
                versionesItem.Add(new SelectListItem { Text = version.descripcion, Value = version.idVersion.ToString(), Selected = versionId == version.idVersion ? true : false });
            }

            ViewData["proyecto"] = proyectosItems;
            ViewData["idTipo"] = tipoTareaItems;
            ViewData["equipo"] = empleadosSelect;
            ViewData["idEstado"] = estados;
            ViewData["predecesora"] = tareasItem;
            ViewData["idVersion"] = versionesItem;
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
