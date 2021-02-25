using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRoute.Controllers
{
    public class ConfiguracionController : Controller
    {
       
        // GET: Configuracion/Edit/5
        //[Authorize]
        public ActionResult Edit(string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Configuracion");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}