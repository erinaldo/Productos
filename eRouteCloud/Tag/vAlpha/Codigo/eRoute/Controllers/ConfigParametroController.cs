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
    public class ConfigParametroController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: ConfigParametro
        public ActionResult Index(string Permiso)
        {
            if (Session["URL"] != null)
            {
                  //  Permiso = "CRUDEOP";
                    ViewBag.Permiso = Permiso; 
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        // GET: ConfigParametro/Create
        public ActionResult Create(string Permiso)
        {
          //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = ""; 
                ViewBag.Permiso = Permiso; 
                ViewBag.SoloLectura = false;
                return View("ConfigParametro");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ConfigParametro/Edit/5
        public ActionResult Edit(string Clave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = Clave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("ConfigParametro");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ConfigParametro/Edit/5
        public ActionResult Delete(string Parametro, string Clave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Parametro = Parametro;
                ViewBag.Clave = Clave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Cambiar");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
