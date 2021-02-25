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
    public class CargasController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: Producto
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


        // GET: Producto/Create
        public ActionResult Create(string Permiso)
        {
          //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = ""; 
                ViewBag.Permiso = Permiso; 
                ViewBag.SoloLectura = false;
                return View("Cargas");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(string Folio, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = Folio;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Cargas");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Details(string Folio, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = Folio;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                return View("Cargas");
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
