using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebReports.Models;
using System.Web.Security;

namespace WebReports.Controllers
{
    public class UsuarioController : Controller
    {
        private DACZAEntities db = new DACZAEntities();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuario = db.Usuario.Include("Taller");
            return View(usuario.ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(string id = null)
        {
            Usuario usuario = db.Usuario.Single(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.TallerId = new SelectList(db.Taller, "TallerId", "AlmacenId");
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.AddObject(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TallerId = new SelectList(db.Taller, "TallerId", "AlmacenId", usuario.TallerId);
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(string id = null)
        {
            Usuario usuario = db.Usuario.Single(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.TallerId = new SelectList(db.Taller, "TallerId", "AlmacenId", usuario.TallerId);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Attach(usuario);
                db.ObjectStateManager.ChangeObjectState(usuario, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TallerId = new SelectList(db.Taller, "TallerId", "AlmacenId", usuario.TallerId);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(string id = null)
        {
            Usuario usuario = db.Usuario.Single(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuario usuario = db.Usuario.Single(u => u.UsuarioId == id);
            db.Usuario.DeleteObject(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            Usuario usuario = new Usuario();
            ViewBag.ReturnUrl = returnUrl;
            return View(usuario);
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (!usuario.IsValid(db))
                {
                    foreach (LoginValidate status in usuario.ErrorStates)
                    {
                        ModelState.AddModelError("", ValidateLogin.ErrorCodeToString(status));
                    }
                    return View(usuario);
                }
                Usuario oUsr = db.Usuario.First(x => x.Clave == usuario.Clave);
                Session["UsuarioId"] = oUsr.UsuarioId;
                FormsAuthentication.SetAuthCookie(oUsr.Nombre, false);
                
                return RedirectToAction("FiltroOrdenes", "OrdenTrabajo");
            }

            return View(usuario);
            
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}