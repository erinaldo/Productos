using System.Web.Mvc;
using eRoute.Models;

namespace eRoute.Controllers
{
    public class ClienteController : Controller
    {
        private RouteEntities db = new RouteEntities();

        // GET: Cliente
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


        // GET: Cliente/Create
        public ActionResult Create(string Permiso)
        {
          //  Permiso = "CRUDEOP";
            if (Session["URL"] != null)
            {
                ViewBag.Clave = ""; 
                ViewBag.Permiso = Permiso; 
                ViewBag.SoloLectura = false;
                return View("Cliente");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(string ClienteClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.ClienteClave = ClienteClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = false;
                return View("Cliente");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Details(string ClienteClave, string Permiso)
        {
            if (Session["URL"] != null)
            {
                ViewBag.ClienteClave = ClienteClave;
                ViewBag.Permiso = Permiso;
                ViewBag.SoloLectura = true;
                return View("Cliente");
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
