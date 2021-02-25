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
    public class CamionesController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: ValorCamioneses
        public ActionResult Index(string Permiso)
        {
            if (Session["URL"] != null)
            {
                //  Permiso = "CRUDEOP";
                ViewBag.Permiso = Permiso; //Valor provisional
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        // GET: Camiones/Create
        public ActionResult Create(string Permiso)
        {
            //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = "";
                ViewBag.Permiso = Permiso; //Valor provisional
                ViewBag.SoloLectura = false;
                return View("Camiones");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Camiones/Edit/5
        public ActionResult Edit(string Placa, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = Placa;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Camiones");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Camiones/Edit/5
        public ActionResult Details(string Placa, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = Placa;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                return View("Camiones");
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
