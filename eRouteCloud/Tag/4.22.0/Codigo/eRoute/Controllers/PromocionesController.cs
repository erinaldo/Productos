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
    public class PromocionesController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: Promociones
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


        // GET: Promociones/Create
        public ActionResult Create(string Permiso)
        {
          //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = ""; 
                ViewBag.Permiso = Permiso; 
                ViewBag.SoloLectura = false;
                return View("Promociones");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Promociones/Edit/5
        public ActionResult Edit(string Clave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = Clave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Promociones");
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
