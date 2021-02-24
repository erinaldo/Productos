using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebReports.Models;


namespace WebReports.Controllers
{
    public class RecargaController : Controller
    {
        private DACZAEntities db = new DACZAEntities();

        //
        // GET: /Inventario/

        [Authorize]
        public ActionResult FiltroRecargas()
        {
            ViewBag.Sucursales = db.Sucursal.ToList();
            ViewBag.Talleres = db.Taller.ToList();
            Session.Remove("Filtro");
            Session.Remove("Sucursal");
            Session.Remove("Taller");
            Session.Remove("Fase");
            return View();
        }

        [HttpPost]
        public ActionResult FiltroRecargas(FilterModels.FilterRecargas filtro)
        {
            if (ModelState.IsValid)
            {
                Session["Filtro"] = filtro;
                if (!String.IsNullOrEmpty(filtro.Sucursal))
                    Session["Sucursal"] = db.Sucursal.First(x => x.SucursalId == filtro.Sucursal).Descripcion;

                if (!String.IsNullOrEmpty(filtro.Taller) && !filtro.Taller.Equals("-999"))
                    Session["Taller"] = db.Taller.First(x => x.TallerId == filtro.Taller).Descripcion;

                if (filtro.Fase != 255)
                {
                    switch (filtro.Fase)
                    {
                        case 0:
                            Session["Fase"] = "Cancelada";
                            break;
                        case 1:
                            Session["Fase"] = "Captura";
                            break;
                        case 2:
                            Session["Fase"] = "Cerrada";
                            break;
                        case 3:
                            Session["Fase"] = "Surtida";
                            break;
                    }
                }

                return RedirectToAction("Recargas");
            }

            ViewBag.Sucursales = db.Sucursal.ToList();
            return View(filtro);
        }

        [Authorize]
        public ActionResult Recargas()
        {
            FilterModels.FilterRecargas filtro = (FilterModels.FilterRecargas)Session["Filtro"];
            var recargas = db.Recarga.Include("Taller").Include("Usuario");

            List<Recarga> recargasFiltradas = recargas.ToList();
            if (!String.IsNullOrEmpty(filtro.Sucursal))
                recargasFiltradas = recargasFiltradas.FindAll(x => x.Taller.Almacen.SucursalId == filtro.Sucursal);
            if (!filtro.Taller.Equals("-999"))
                recargasFiltradas = recargasFiltradas.FindAll(x => x.TallerId == filtro.Taller);
            if (filtro.FechaIni != null)
                recargasFiltradas = recargasFiltradas.FindAll(x => x.FechaSolicitud.Date >= filtro.FechaIni.Value.Date);
            if (filtro.FechaFin != null)
                recargasFiltradas = recargasFiltradas.FindAll(x => x.FechaSolicitud.Date <= filtro.FechaFin.Value.Date);
            if (filtro.Fase != 255)
                recargasFiltradas = recargasFiltradas.FindAll(x => x.Fase == filtro.Fase);

            return View(recargasFiltradas);
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

        public ActionResult ObtenerImagen(string detalleId)
        {
            RECDetalle detalle = db.RECDetalle.First(x => x.DetalleId == detalleId);
            String imgBase64 = Convert.ToBase64String(detalle.Imagen);

            return Json(new { imagen = imgBase64, titulo = detalle.ArticuloDesc}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActualizarFase(string recargaId, short fase)
        {
            Recarga oRecarga = db.Recarga.First(x => x.RecargaId == recargaId);
            oRecarga.Fase = fase;
            oRecarga.FechaSurtido = DateTime.Now;
            oRecarga.MFechaHora = DateTime.Now;
            oRecarga.MUsuarioId = ObtenerUsuario();

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
