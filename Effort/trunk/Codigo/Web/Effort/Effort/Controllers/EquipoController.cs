using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Effort.Models;
using Effort.Models.Reportes;
using Effort.Utils;
using Effort.Filters;

namespace Effort.Controllers
{
    [RoleFilter]
    [SessionExpireFilter]
    public class EquipoController : Controller
    {
        private EffortEntities db = new EffortEntities();

        //
        // GET: /Equipo/

        public ActionResult Index(int page = 0, int pageSize = 10)
        {
            var count = db.Equipo.Count();
            var maxPage = ((count / pageSize) - (count % pageSize == 0 ? 1 : 0));

            page = page >= 0 ? page : 0;
            page = page <= maxPage ? page : maxPage;
            var data = db.Equipo.OrderBy(e => e.idEquipo).Skip(page * pageSize).Take(pageSize).ToList();

            ViewBag.MaxPage = maxPage + 1;
            ViewBag.Page = page;

            return View(data);
        }

        //
        // GET: /Equipo/Details/5

        public ActionResult Details(string id = null)
        {
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        //
        // GET: /Equipo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Equipo/Create

        [HttpPost]
        public ActionResult Create(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipo.Add(equipo);
                db.SaveChanges();
                Equipo equipoDb = db.Equipo.SingleOrDefault(e => e.idEquipo == equipo.idEquipo);
                equipoDb.contrasena = HashPass.CreateHash(equipo.contrasena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipo);
        }

        //
        // GET: /Equipo/Edit/5

        public ActionResult Edit(string id = null)
        {
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        //
        // POST: /Equipo/Edit/5

        [HttpPost]
        public ActionResult Edit(Equipo equipo)
        {
            System.Diagnostics.Debug.WriteLine(equipo.idEquipo+ " " + equipo.nombre);
            if (ModelState.IsValid)
            {
                Equipo equipoDb = db.Equipo.SingleOrDefault(e => e.idEquipo == equipo.idEquipo);
                equipoDb.nombre = equipo.nombre;
                equipoDb.correo = equipo.correo;
                equipoDb.contrasena = HashPass.CreateHash(equipo.contrasena);
                equipoDb.inversion_horas_dia = equipo.inversion_horas_dia;
                equipoDb.costo_hr = equipo.costo_hr;
                equipoDb.perfil = equipo.perfil;
                equipoDb.Estado = equipo.Estado;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(equipo);
        }

        //
        // GET: /Equipo/Delete/5

        public ActionResult Delete(string id = null)
        {
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Equipo.Remove(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public void updatePass(string newPass)
        {
            List<Equipo> equipos = db.Equipo.ToList();
            foreach (Equipo equipo in equipos)
            {
                Equipo aux = db.Equipo.SingleOrDefault(e => e.idEquipo == equipo.idEquipo);
                aux.contrasena = newPass;
                db.SaveChanges();
            }
        }

        public void hashPass()
        {
            List<Equipo> equipos = db.Equipo.ToList();
            foreach (Equipo equipo in equipos)
            {
                Equipo aux = db.Equipo.SingleOrDefault(e => e.idEquipo == equipo.idEquipo);
                aux.contrasena = HashPass.CreateHash(equipo.contrasena);
                db.SaveChanges();
            }
        }

        public JsonResult testPass(string pass)
        {
            var equipos = (from e in db.Equipo select e.contrasena).ToList();
            List<bool> results = new List<bool>();
            foreach (string equipo in equipos)
            {
                results.Add(HashPass.ValidatePassword(pass, equipo));
            }

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult tareasPorEquipo()
        {
            var tareasPorEquipo =
                from t in db.Tarea
                join e in db.Equipo on t.idEquipo equals e.idEquipo
                group t by new { e.nombre, t.idEquipo } into tgroup
                select new
                {
                    nombreProyecto = tgroup.Key.nombre,
                    tareasEnCurso = tgroup.Count(t => t.idEstado == 1),
                    tareasPendientes = tgroup.Count(t => t.idEstado == 2),
                    tareasCompletadas = tgroup.Count(t => t.idEstado == 3),
                    tareasCanceladas = tgroup.Count(t => t.idEstado == 4)
                };

            return Json(tareasPorEquipo, JsonRequestBehavior.AllowGet);

        }

        public JsonResult tareasPendientes()
        {
            var tareasPendientes =
                from t in db.Tarea
                join e in db.Equipo on t.idEquipo equals e.idEquipo
                where t.idEstado == 2 
                group t by new { e.nombre, t.idEquipo } into tgroup
                select new { nombreEquipo = tgroup.Key.nombre, tareasPendientes = tgroup.Count() };

            return Json(tareasPendientes, JsonRequestBehavior.AllowGet);

        }
    }
}