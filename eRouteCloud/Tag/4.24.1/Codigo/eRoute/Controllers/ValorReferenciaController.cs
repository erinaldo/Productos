using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eRoute.Models;

namespace eRoute.Controllers
{
    public class ValorReferenciaController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: ValorReferencia
        public ActionResult Index(string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Permiso = Permiso;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ValorReferencia/Details
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorReferencia valorReferencia = db.ValorReferencia.Find(id);
            if (valorReferencia == null)
            {
                return HttpNotFound();
            }
            return View(valorReferencia);
        }

        // GET: ValorReferencia/Create
        public ActionResult Create(string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = "";
                ViewBag.Permiso = Permiso; //Valor provisional
                ViewBag.SoloLectura = false;
                ViewBag.PruebaView = "Valor de prueba";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: ValorReferencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VARCodigo,Descripcion,TipoDato,TipoAplicacion,TipoNulo,TipoModificable,MUsuarioId,MFechaHora")] ValorReferencia valorReferencia)
        {
            if (ModelState.IsValid)
            {
                db.ValorReferencia.Add(valorReferencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valorReferencia);
        }

        // GET: ValorReferencia/Edit
        public ActionResult Edit(string VARCodigo, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = VARCodigo;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                return View("Create");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: ValorReferencia/Edit
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VARCodigo,Descripcion,TipoDato,TipoAplicacion,TipoNulo,TipoModificable,MUsuarioId,MFechaHora")] ValorReferencia valorReferencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valorReferencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valorReferencia);
        }

        // GET: ValorReferencia/Delete
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorReferencia valorReferencia = db.ValorReferencia.Find(id);
            if (valorReferencia == null)
            {
                return HttpNotFound();
            }
            return View(valorReferencia);
        }

        // POST: ValorReferencia/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string Permiso)
        {
            ValorReferencia valorReferencia = db.ValorReferencia.Find(id);
            db.ValorReferencia.Remove(valorReferencia);
            db.SaveChanges();
            ViewBag.Permiso = Permiso;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
