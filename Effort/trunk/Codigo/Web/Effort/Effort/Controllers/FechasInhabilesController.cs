using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Effort.Models;
using Effort.Filters;

namespace Effort.Controllers
{
    [RoleFilter]
    [SessionExpireFilter]
    public class FechasInhabilesController : Controller
    {
        private EffortEntities db = new EffortEntities();

        //
        // GET: /FechasInhabiles/

        public ActionResult Index()
        {
            return View(db.DiasNoHabiles.ToList());
        }

        //
        // GET: /FechasInhabiles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FechasInhabiles/Create

        [HttpPost]
        public ActionResult Create(DiasNoHabiles diasnohabiles)
        {
            if (ModelState.IsValid)
            {
                db.DiasNoHabiles.Add(diasnohabiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diasnohabiles);
        }

        //
        // GET: /FechasInhabiles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DiasNoHabiles diasnohabiles = db.DiasNoHabiles.Find(id);
            if (diasnohabiles == null)
            {
                return HttpNotFound();
            }
            return View(diasnohabiles);
        }

        //
        // POST: /FechasInhabiles/Edit/5

        [HttpPost]
        public ActionResult Edit(DiasNoHabiles diasnohabiles)
        {
            if (ModelState.IsValid)
            {
                DiasNoHabiles diaNoHabil = db.DiasNoHabiles.SingleOrDefault(d => d.id == diasnohabiles.id);
                diaNoHabil.fecha = diasnohabiles.fecha;
                diaNoHabil.descripcion = diasnohabiles.descripcion;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diasnohabiles);
        }

        public ActionResult Delete(int id)
        {
            DiasNoHabiles diasnohabiles = db.DiasNoHabiles.Find(id);
            db.DiasNoHabiles.Remove(diasnohabiles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}