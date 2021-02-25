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
    public class UsuarioController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: ValorReferencia
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


        // GET: ValorReferencia/Create
        public ActionResult Create(string Permiso)
        {
          //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = ""; 
                ViewBag.Permiso = Permiso; //Valor provisional
                ViewBag.SoloLectura = false;
                return View("Usuario");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ValorReferencia/Edit/5
        public ActionResult Edit(string USUId, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = USUId;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Usuario");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ValorReferencia/Edit/5
        public ActionResult Exceptions(string USUId, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = USUId;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Excepciones");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ValorReferencia/Edit/5
        public ActionResult Details(string USUId, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = USUId;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                return View("Usuario");
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
