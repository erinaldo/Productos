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
    public class VendedoresController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: ValorListadePrecios
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


        // GET: ListasdePrecios/Create
        public ActionResult Create(string Permiso)
        {
            //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = "";
                ViewBag.Permiso = Permiso; //Valor provisional
                ViewBag.SoloLectura = false;
                return View("Vendedores");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ListasdePrecios/Edit/5
        public ActionResult Edit(string PrecioClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = PrecioClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Vendedores");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ListasdePrecios/Copy/5
        public ActionResult Copy(string PrecioClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = PrecioClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("CopiarListasdePrecios");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ListasdePrecios/Details/5
        public ActionResult Details(string PrecioClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = PrecioClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Vendedores");
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

