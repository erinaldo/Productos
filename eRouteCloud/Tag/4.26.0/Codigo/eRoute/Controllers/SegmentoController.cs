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
    public class SegmentoController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: Segmento
        public ActionResult Index(string Permiso)
        {
            if (Session["URL"] != null)
            {
                    ViewBag.Permiso = Permiso;
                    ViewBag.Action = "Index";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        // GET: Segmento/Create
        public ActionResult Create(string Permiso)
        {
          //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = ""; 
                ViewBag.Permiso = Permiso; 
                ViewBag.SoloLectura = false;
                ViewBag.Action = "Create";
                return View("Segmento");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Segmento/Edit/5
        public ActionResult Edit(string ProductoClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = ProductoClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                ViewBag.Action = "Edit";
                return View("Segmento");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Segmento/Edit/5
        public ActionResult Details(string USUId, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = USUId;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                ViewBag.Action = "Details";
                return View("Excepciones");
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
