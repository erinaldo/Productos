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
    public class RutasController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: Rutas
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


        // GET: Rutas/Create
        public ActionResult Create(string Permiso)
        {
          //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = ""; 
                ViewBag.Permiso = Permiso; 
                ViewBag.SoloLectura = false;
                return View("Rutas");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Rutas/Edit/5
        public ActionResult Edit(string Clave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = Clave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Rutas");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Rutas/Details
        public ActionResult Details(string Clave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = Clave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                return View("Rutas");
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
