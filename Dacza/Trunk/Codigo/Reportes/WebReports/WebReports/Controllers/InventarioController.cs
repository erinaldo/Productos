using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebReports.Models;

namespace WebReports.Controllers
{
    public class InventarioController : Controller
    {
        private DACZAEntities db = new DACZAEntities();

        //
        // GET: /Inventario/

        [Authorize]
        public ActionResult FiltroInventario()
        {
            ViewBag.Sucursales = db.Sucursal.ToList();
            ViewBag.Talleres = db.Taller.ToList();
            Session.Remove("Filtro");
            Session.Remove("Sucursal");
            Session.Remove("Taller");
            return View();
        }

        [HttpPost]
        public ActionResult FiltroInventario(FilterModels.FilterInventario filtro)
        {
            if (ModelState.IsValid)
            {
                Session["Filtro"] = filtro;
                if (!String.IsNullOrEmpty(filtro.Sucursal))
                    Session["Sucursal"] = db.Sucursal.First(x => x.SucursalId == filtro.Sucursal).Descripcion;
               
                if (!String.IsNullOrEmpty(filtro.Taller) && !filtro.Taller.Equals("-999"))
                    Session["Taller"] = db.Taller.First(x => x.TallerId == filtro.Taller).Descripcion;

                return RedirectToAction("InventarioTalleres");
            }

            ViewBag.Sucursales = db.Sucursal.ToList();
            return View(filtro);
        }

        [Authorize]
        public ActionResult InventarioTalleres()
        {            
            FilterModels.FilterInventario filtro = (FilterModels.FilterInventario)Session["Filtro"];
            var inventario = db.InventarioTaller.Include("Taller").Include("Articulo");

            List<InventarioTaller> inventarioFiltrado = inventario.ToList().FindAll(x => x.Existencia > 0);
            if (!String.IsNullOrEmpty(filtro.Sucursal))
                inventarioFiltrado = inventarioFiltrado.FindAll(x => x.Taller.Almacen.SucursalId == filtro.Sucursal);
            if (!filtro.Taller.Equals("-999"))
                inventarioFiltrado = inventarioFiltrado.FindAll(x => x.TallerId == filtro.Taller);
            
            return View(inventarioFiltrado);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ObtenerTalleres(string sucursalId)
        {
            var talleres =
                from taller in db.Taller
                join almacen in db.Almacen on taller.AlmacenId equals almacen.AlmacenId
                join sucursal in db.Sucursal on almacen.SucursalId equals sucursal.SucursalId
                where sucursal.SucursalId == sucursalId
                orderby taller.Clave
                select new { taller.TallerId, taller.Descripcion };

            return Json(talleres, JsonRequestBehavior.AllowGet);
        }
    }
}