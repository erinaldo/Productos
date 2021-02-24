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
    public class OrdenTrabajoController : Controller
    {
        private DACZAEntities db = new DACZAEntities();

        [Authorize]
        public ActionResult FiltroOrdenes()
        {
            ViewBag.Sucursales = db.Sucursal.ToList();
            Session.Remove("Filtro");
            Session.Remove("Sucursal");
            Session.Remove("Fase");
            return View();
        }

        [HttpPost]
        public ActionResult FiltroOrdenes(FilterModels.FilterOrdenTrabajo filtro)
        {
            if (ModelState.IsValid)
            {
                Session["Filtro"] = filtro;
                if (!String.IsNullOrEmpty(filtro.Sucursal))
                    Session["Sucursal"] = db.Sucursal.First(x => x.SucursalId == filtro.Sucursal).Descripcion;
                if (filtro.Fase != 255) { 
                    switch (filtro.Fase) {
                        case 0:
                            Session["Fase"] = "Cancelada";
                            break;
                        case 1:
                            Session["Fase"] = "Captura";
                            break;
                        case 2:
                            Session["Fase"] = "Cerrada";
                            break;
                    }
                }               
                
                return RedirectToAction("Ordenes");
            }

            ViewBag.Sucursales = db.Sucursal.ToList();
            return View(filtro);
        }

        [Authorize]
        public ActionResult FiltroRefacciones()
        {
            ViewBag.Sucursales = db.Sucursal.ToList();
            ViewBag.Talleres = db.Taller.ToList();
            Session.Remove("Filtro");
            Session.Remove("Sucursal");
            Session.Remove("Taller");
            return View();
        }

        [HttpPost]
        public ActionResult FiltroRefacciones(FilterModels.FilterRefacciones filtro)
        {
            if (ModelState.IsValid)
            {
                Session["Filtro"] = filtro;
                if (!String.IsNullOrEmpty(filtro.Sucursal))
                    Session["Sucursal"] = db.Sucursal.First(x => x.SucursalId == filtro.Sucursal).Descripcion;
                if (filtro.Seleccion.Equals("Taller"))
                    if (!String.IsNullOrEmpty(filtro.Taller) && !filtro.Taller.Equals("-999"))
                        Session["Taller"] = db.Taller.First(x => x.TallerId == filtro.Taller).Descripcion;

                return RedirectToAction("Refacciones");
            }

            ViewBag.Sucursales = db.Sucursal.ToList();
            return View(filtro);
        }

        //
        // GET: /OrdenTrabajo/
        [Authorize] 
        public ActionResult Ordenes()
        {
            FilterModels.FilterOrdenTrabajo filtro = (FilterModels.FilterOrdenTrabajo)Session["Filtro"];
            var ordentrabajo = db.OrdenTrabajo.Include("Cliente").Include("Usuario").Include("Taller").Include("Vin");

            List<OrdenTrabajo> ordenesFiltradas = ordentrabajo.ToList();
            if (!String.IsNullOrEmpty(filtro.Sucursal))
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.Taller.Almacen.SucursalId == filtro.Sucursal);
            if (filtro.FechaIni != null)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.FechaIni.Date >= filtro.FechaIni.Value.Date);
            if (filtro.FechaFin != null)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.FechaIni.Date <= filtro.FechaFin.Value.Date);
            if (filtro.Fase != 255)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.Fase == filtro.Fase);
            if (filtro.Folio != null)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.Folio.Contains(filtro.Folio));
            if (filtro.Vin != null)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.Vin.Clave.Contains(filtro.Vin));
            if (filtro.Cliente != null)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.Cliente.Clave.Contains(filtro.Cliente) || x.Cliente.RazonSocial.Contains(filtro.Cliente));


            return View(ordenesFiltradas.OrderBy(x => x.Taller.Almacen.Clave).ThenBy(x => x.Taller.Clave).ThenBy(x => x.Usuario.Clave).ThenBy(x => x.Cliente.Clave).ThenBy(x => x.Folio));
        }

        [Authorize]
        public ActionResult Refacciones()
        {
            FilterModels.FilterRefacciones filtro = (FilterModels.FilterRefacciones)Session["Filtro"];
            var ordentrabajo = db.OrdenTrabajo.Include("Cliente").Include("Usuario").Include("Taller").Include("Vin");
                       
            List<OrdenTrabajo> ordenesFiltradas = ordentrabajo.ToList().FindAll(x => x.Fase != 0);
            if (!String.IsNullOrEmpty(filtro.Sucursal))
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.Taller.Almacen.SucursalId == filtro.Sucursal);
            if (filtro.FechaIni != null)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.FechaIni.Date >= filtro.FechaIni.Value.Date);
            if (filtro.FechaFin != null)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.FechaIni.Date <= filtro.FechaFin.Value.Date);

            if (filtro.Seleccion.Equals("Taller") && !filtro.Taller.Equals("-999"))
                    ordenesFiltradas = ordenesFiltradas.FindAll(x => x.TallerId == filtro.Taller);
            else if (filtro.Seleccion.Equals("Vin") && filtro.Vin != null)
                ordenesFiltradas = ordenesFiltradas.FindAll(x => x.Vin.Clave.Contains(filtro.Vin));

            IEnumerable<ViewModels.ViewRefacciones> odtDetalle = ordenesFiltradas.Join(db.ODTDetalle, o => o.OrdenId, d => d.OrdenId,
                (o, d) => new { Orden = o, Detalle = d })
                .Select(d => new ViewModels.ViewRefacciones()
                    {
                        Taller = d.Orden.Taller,
                        Folio = d.Orden.Folio,
                        Fecha = d.Orden.FechaIni,
                        Vin = d.Orden.Vin.Clave,
                        ClaveArticulo = d.Detalle.Articulo.Clave,
                        DescripcionArticulo = d.Detalle.Articulo.Descripcion
                    });                

            if (filtro.Seleccion.Equals("Parte") && filtro.Parte != null)
            {
                odtDetalle = odtDetalle.Where(x => x.ClaveArticulo.Contains(filtro.Parte));
            }

            return View(odtDetalle);
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
                select new {taller.TallerId, taller.Descripcion};

            return Json(talleres, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActualizarFaseOrden(string ordenId, short fase)
        {
            OrdenTrabajo oOrden = db.OrdenTrabajo.First(x => x.OrdenId == ordenId);
            oOrden.Fase = fase;
            oOrden.MFechaHora = DateTime.Now;
            oOrden.MUsuarioId = ObtenerUsuario();

            db.SaveChanges();

            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }

        public string ObtenerUsuario()
        {
            if (Session["UsuarioId"] == null)
            {
                string sNombre = User.Identity.Name;
                if (db.Usuario.ToList().Exists(x => x.Nombre == sNombre))
                    return db.Usuario.First(x => x.Nombre == sNombre).UsuarioId;
                else
                    return "Admin";
            }
            else
                return Session["UsuarioId"].ToString();
        }
    }
}