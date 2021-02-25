using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eRoute.Models;
using eRoute.Controllers.API;

namespace eRoute.Controllers
{
    public class MensajeController : Controller
    {
        private RouteEntities db = new RouteEntities();
        // GET: Mensaje
        //[Authorize]
        public ActionResult Index(string Permiso)
        {
            if (Session["URL"] != null)
            {
                var mensajes = db.Mensaje.ToList();
                ViewBag.Permiso = Permiso;
                return View(mensajes);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Mensaje/Create
        //[Authorize]
        public ActionResult Create(string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = "";
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Mensaje");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Mensaje/Edit/5
        //[Authorize]
        public ActionResult Edit(string MENClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = MENClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Mensaje");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Mensaje/Details/5
        //[Authorize]
        public ActionResult Details(string MENClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Clave = MENClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                return View("Mensaje");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
