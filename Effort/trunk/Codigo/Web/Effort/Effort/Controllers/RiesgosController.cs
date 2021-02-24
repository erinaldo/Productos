using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Effort.Models;
using System.Web.Script.Services;
using System.Data.Entity.Validation;
using System.Text;
using Effort.Filters;

namespace Effort.Controllers
{
    [SessionExpireFilter]
    public class RiesgosController : Controller
    {
        //
        // GET: /Riesgos/
        EffortEntities context = new EffortEntities();


        public ActionResult Index(int page = 0, int pageSize = 10)
        {
            Equipo currentUser = ((Equipo)Session["Login"]);
            bool admin = currentUser.perfil.Equals("Administrador");

            var count = admin ? context.Riesgos.Count()
                :
                (from r in context.Riesgos
                 join p in context.Proyecto on r.idProyecto equals p.idProyecto
                 join t in context.Tarea on p.idProyecto equals t.idProyecto
                 join e in context.Equipo on t.idEquipo equals e.idEquipo
                 where e.idEquipo == currentUser.idEquipo
                 select p).Distinct().Count();
                ;
            if (count > 0)
            {
                var maxPage = ((count / pageSize) - (count % pageSize == 0 ? 1 : 0));

                page = page >= 0 ? page : 0;
                page = page <= maxPage ? page : maxPage;

                var consulta = admin?(from r in context.Riesgos
                                join p in context.Proyecto on r.idProyecto equals p.idProyecto
                                join et in context.Estados_tareas on r.idEstado equals et.idEstado
                                select new vista_riesgos { idRiesgos = r.idRiesgos, nombreProyecto = p.nombre, riesgoDesc = r.descripcion, estadoDesc = et.descripcion }).OrderBy(r => r.idRiesgos).Skip(page * pageSize).Take(pageSize).ToList()
                                :
                                (from r in context.Riesgos
                                 join p in context.Proyecto on r.idProyecto equals p.idProyecto
                                 join t in context.Tarea on p.idProyecto equals t.idProyecto
                                 join e in context.Equipo on t.idEquipo equals e.idEquipo
                                 join et in context.Estados_tareas on r.idEstado equals et.idEstado
                                 where e.idEquipo == currentUser.idEquipo
                                 select new vista_riesgos { idRiesgos = r.idRiesgos, nombreProyecto = p.nombre, riesgoDesc = r.descripcion, estadoDesc = et.descripcion }).Distinct().OrderBy(r => r.idRiesgos).Skip(page * pageSize).Take(pageSize).ToList()
                                ;

                ViewBag.MaxPage = maxPage + 1;
                ViewBag.Page = page;
                ViewBag.Count = count;

                return View(consulta);
            }

            return View(context.Riesgos.ToList());

            
        }

        public ActionResult Create() // lo utilizo para direccionar a la vista de crear
        {
            this.llenarCombos(-1,null,0,0,0,-1,null);

            return View();
        }


        [HttpPost]
        public ActionResult Create (Riesgos riesgos)// lo utilizo para guardar y si no cumple una validacion lo regresa al crete con mensaje de error
        {
   
            this.llenarCombos(-1,null,0,0,0,-1,null);
 

                try
                {
                    riesgos.fecha_registro = DateTime.Now;
                    context.Riesgos.Add(riesgos);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Riesgos");
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    System.Diagnostics.Debug.WriteLine(sb);
                }


            



            return View(riesgos);

        }

        public void llenarCombos(int idestado, string idproyecto, int c, int p, int i, int? tareaId, string responsable)
        {
            Equipo currentUser = ((Equipo)Session["Login"]);
            bool admin = currentUser.perfil.Equals("Administrador");

            List<Estados_tareas> estatus = context.Estados_tareas.ToList();
            List<SelectListItem> estados = new List<SelectListItem>();
            foreach (Estados_tareas estado in estatus)
            {
                estados.Add(new SelectListItem { Text = estado.descripcion, Value = estado.idEstado.ToString(), Selected = idestado == estado.idEstado ? true : false });
            }

            List<Proyecto> proyectos = admin?context.Proyecto.ToList()
                :
                (from pr in context.Proyecto
                        join t in context.Tarea on pr.idProyecto equals t.idProyecto
                        join e in context.Equipo on t.idEquipo equals e.idEquipo
                        where e.idEquipo == currentUser.idEquipo
                        select pr).Distinct().ToList();

            List<SelectListItem> proyectoSelect = new List<SelectListItem>();
            foreach (Proyecto proyecto in proyectos)
            {
                proyectoSelect.Add(new SelectListItem { Text = proyecto.nombre, Value = proyecto.idProyecto, Selected = idproyecto == proyecto.idProyecto ? true : false });
            }

            List<SelectListItem> criticidad = new List<SelectListItem>();
            criticidad.Add(new SelectListItem { Text = "Baja", Value = "1", Selected = c == 1 ? true :false });
            criticidad.Add(new SelectListItem { Text = "Media", Value = "2", Selected = c == 2 ? true : false });
            criticidad.Add(new SelectListItem { Text = "Alta", Value = "3", Selected = c == 3 ? true : false });

            List<SelectListItem> probabilidad = new List<SelectListItem>();
            probabilidad.Add(new SelectListItem { Text = "Baja", Value = "1", Selected = p == 1 ? true : false });
            probabilidad.Add(new SelectListItem { Text = "Media", Value = "2", Selected = p == 2 ? true : false });
            probabilidad.Add(new SelectListItem { Text = "Alta", Value = "3", Selected = p == 3 ? true : false });

            List<SelectListItem> impacto = new List<SelectListItem>();
            impacto.Add(new SelectListItem { Text = "Baja", Value = "1", Selected = i == 1 ? true : false });
            impacto.Add(new SelectListItem { Text = "Media", Value = "2", Selected = i == 2 ? true : false });
            impacto.Add(new SelectListItem { Text = "Alta", Value = "3", Selected = i == 3 ? true : false });


            List<Tarea> tareasList = context.Tarea.ToList();

            List<SelectListItem> tareasItem = new List<SelectListItem>();

            foreach (Tarea tarea in tareasList)
            {
                tareasItem.Add(new SelectListItem { Text = tarea.titulo, Value = tarea.idTarea.ToString() });
            }

            List<Equipo> empleados = context.Equipo.ToList();
            List<SelectListItem> empleadosSelect = new List<SelectListItem>();

            foreach (Equipo equipo in empleados)
            {
                empleadosSelect.Add(new SelectListItem { Text = equipo.nombre, Value = equipo.idEquipo, Selected = equipo.idEquipo.Equals(responsable) });
            }

            ViewData["idEstado"] = estados;
            ViewData["idProyecto"] = proyectoSelect;
            ViewData["criticidad"] = criticidad;
            ViewData["probabilidad"] = probabilidad;
            ViewData["impacto"] = impacto;
            ViewData["idTarea"] = tareasItem;
            ViewData["responsable"] = empleadosSelect;
        }

        public JsonResult updateTareas(string idProyecto)
        {
            List<Tarea> tareasList = (from t in context.Tarea
                                      where t.idProyecto == idProyecto
                                      select t).ToList();

            List<SelectListItem> tareasItem = new List<SelectListItem>();

            foreach (Tarea tarea in tareasList)
            {
                tareasItem.Add(new SelectListItem { Text = tarea.titulo, Value = tarea.idTarea.ToString() });
            }

            return Json(tareasItem, JsonRequestBehavior.AllowGet);

        }
       
        [RoleFilter]
        public ActionResult Edit(int id = -1)
        {
            

            Riesgos riesgos = context.Riesgos.Find(id);

            if (riesgos == null)
            {
                return HttpNotFound();
            }
            else
            {

                int c = Convert.ToInt32(riesgos.criticidad);
                int p = Convert.ToInt32(riesgos.probabilidad);
                int i = Convert.ToInt32(riesgos.impacto);

                this.llenarCombos(riesgos.idEstado,riesgos.idProyecto,c,p,i,-1,riesgos.responsable);
            }
            return View(riesgos);
        }

        [RoleFilter]
        [HttpPost]
        public ActionResult Edit(Riesgos riesgo)
        {

                try
                {
                    Riesgos riesgosEditar = context.Riesgos.SingleOrDefault(r => r.idRiesgos == riesgo.idRiesgos);
                    riesgosEditar.idProyecto = riesgo.idProyecto;
                    riesgosEditar.idTarea = riesgo.idTarea;
                    riesgosEditar.descripcion = riesgo.descripcion;
                    riesgosEditar.responsable = riesgo.responsable;
                    riesgosEditar.idEstado = riesgo.idEstado;
                    riesgosEditar.criticidad = riesgo.criticidad;
                    riesgosEditar.probabilidad = riesgo.probabilidad;
                    riesgosEditar.impacto = riesgo.impacto;
                    riesgosEditar.mitigacion = riesgo.mitigacion;
                    riesgosEditar.fecha_seguimiento = riesgo.fecha_seguimiento;
                  //  System.Diagnostics.Debug.WriteLine("fecha_registro: " + riesgosEditar.fecha_registro);
                   // riesgosEditar.fecha_registro = riesgo.fecha_registro;

                    context.SaveChanges();

                    return RedirectToAction("Index");

                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    System.Diagnostics.Debug.WriteLine(sb);
                }
                
            
            
            System.Diagnostics.Debug.WriteLine("ERROR MODEL");
            int c = Convert.ToInt32(riesgo.criticidad);
            int p = Convert.ToInt32(riesgo.probabilidad);
            int i = Convert.ToInt32(riesgo.impacto);

            this.llenarCombos(riesgo.idEstado, riesgo.idProyecto, c, p, i,-1,riesgo.responsable);
            return View(riesgo);
        }

    }
}
