using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eRoute.Models;

namespace eRoute.Controllers
{
    public class PerfilController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: Perfil
        public ActionResult Index(string Permiso)
        {
            if (Session["URL"] != null)
            {
                var perfiles = db.Perfil.ToList();
                ViewBag.Permiso = Permiso;
                return View(perfiles);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Perfil/Create
        //[Authorize]
        public ActionResult Create(string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = "";
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Perfil/Edit/5
        //[Authorize]
        public ActionResult Edit(string PERClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = PERClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Perfil/Details/5
        //[Authorize]
        public ActionResult Details(string PERClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = PERClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                return View("Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}