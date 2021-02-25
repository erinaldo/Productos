using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteCloud.Context;
using static RouteCloud.Controllers.ViewModels.MainViewModel;

namespace RouteCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    {
        private readonly RouteCloudContext db;

        public MainController(RouteCloudContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<ViewModulo> Get(string sPERClave = "Admin", string sUSUId = "Admin")
        {
            var lst = (((from intp in db.IntPer where intp.Perclave == sPERClave && (intp.InttipoInterfaz == 1 || intp.InttipoInterfaz == 3) select intp.Modid).Distinct()).Union((from intu in db.IntUsu where intu.Usuid == sUSUId && (intu.InttipoInterfaz == 1 || intu.InttipoInterfaz == 3) select intu.Modid).Distinct())).ToList();
            List<ViewModulo> lstModulos = (from m in db.Modulo
                                           join men in db.Mendetalle on m.MennombreClave equals men.Menclave
                                           where men.MedtipoLenguaje == "EM" && lst.Contains(m.Modid)
                                           orderby m.TipoInterfaz, m.Secuencia
                                           select new ViewModulo
                                           {
                                               MODId = m.Modid,
                                               Clave = men.Menclave,
                                               Nombre = men.Descripcion,
                                               Secuencia = m.Secuencia
                                           }).ToList();

            foreach (ViewModulo oModulo in lstModulos)
            {
                GetActivities(oModulo, sPERClave, sUSUId);
            }
            return lstModulos;
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void GetActivities(ViewModulo oModulo, string sPERClave, string sUSUId)
        {
            List<ViewInt> lstInter =
            (
            from q in (
                (
                    (
                        from intp in db.IntPer
                        where intp.Perclave == sPERClave && (intp.InttipoInterfaz == 1 || intp.InttipoInterfaz == 3) && !(from intu in db.IntUsu where intu.Usuid == sUSUId && (intu.InttipoInterfaz == 1 || intu.InttipoInterfaz == 3) select intu.Actid).Contains(intp.Actid) && intp.Modid == oModulo.MODId
                        select new ViewInt
                        {
                            ACTId = intp.Actid,
                            Permiso = intp.Permiso,
                            Secuencia = intp.Secuencia,
                            Valor = intp.Actid.StartsWith("ReporteW") ? intp.Actid.Replace("ReporteW", "") : intp.Actid.Replace("MapaW", "")
                        }
                    ).Distinct()
                 ).Union(
                    (
                        from intu in db.IntUsu
                        where intu.Usuid == sUSUId && (intu.InttipoInterfaz == 1 || intu.InttipoInterfaz == 3) && intu.Modid == oModulo.MODId
                        select new ViewInt
                        {
                            ACTId = intu.Actid,
                            Permiso = intu.Permiso,
                            Secuencia = intu.Secuencia,
                            Valor = intu.Actid.StartsWith("ReporteW") ? intu.Actid.Replace("ReporteW", "") : intu.Actid.Replace("MapaW", "")
                        }
                    ).Distinct()
                 )
             )
            select new ViewInt { ACTId = q.ACTId, Permiso = q.Permiso, Secuencia = q.Secuencia, Valor = q.Valor }).ToList();

            List<ViewInt> lstAct = (
                                    from m in lstInter
                                    join a in db.Actividad on m.ACTId equals a.Actid

                                    join men in db.Mendetalle on a.MennombreClave equals men.Menclave into ActMen
                                    from amen in ActMen.DefaultIfEmpty()
                                    where amen.MedtipoLenguaje == "EM"

                                    join vav in db.Vavdescripcion on m.Valor equals vav.Vavclave into MenVav
                                    from vav in MenVav.DefaultIfEmpty()
                                    where vav?.Vavclave != null ? (vav?.VadtipoLenguaje == "EM" && ((m.ACTId.StartsWith("ReporteW") && vav?.Varcodigo == "REPORTEW") || (m.ACTId.StartsWith("MapaW") && vav?.Varcodigo == "MAPAW"))) : true

                                    join var in db.Varvalor on new { vav?.Varcodigo, vav?.Vavclave } equals new { var.Varcodigo, var.Vavclave } into VavVar
                                    from var in VavVar.DefaultIfEmpty()

                                    select new ViewInt
                                    {
                                        ACTId = m.Valor,
                                        Nombre = (m.ACTId.StartsWith("ReporteW") || m.ACTId.StartsWith("MapaW") ? vav?.Descripcion : amen.Descripcion),
                                        Permiso = m.Permiso,
                                        Secuencia = m.Secuencia,
                                        TipoActividad = a.TipoActividad,
                                        Estado = var?.Estado
                                    }
                                  ).ToList();

            List<ViewActividad> lstModulos = (from m in lstAct
                                              where m.Estado == 1 || m.Estado == null
                                              orderby m.Secuencia
                                              select new ViewActividad
                                              {
                                                  ACTId = m.ACTId,
                                                  Nombre = m.Nombre,
                                                  Permiso = m.Permiso,
                                                  Secuencia = m.Secuencia,
                                                  TipoActividad = m.TipoActividad
                                              }).ToList();
            oModulo.Actividades = lstModulos;
        }
    }
}