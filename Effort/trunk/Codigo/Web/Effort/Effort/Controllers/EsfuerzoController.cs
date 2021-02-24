using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Effort.Models;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;
using Effort.Filters;
using Effort.Models.Reportes;

namespace Effort.Controllers
{
    [SessionExpireFilter]
    public class EsfuerzoController : Controller
    {
        private EffortEntities db = new EffortEntities();

        //
        // GET: /Esfuerzo/

        public ActionResult Index(string message = null, int idTarea = 0)
        {
            ViewBag.Success = message;
            var esfuerzos = (from e in db.Esfuerzo where e.idTarea == idTarea select e).OrderByDescending(e => e.fecha_actual).ToList();
            return View(esfuerzos);
        }
        //
        // GET: /Esfuerzo/Create

        public ActionResult Create(int idTarea)
        {
            getData(idTarea);
            return View();
        }

        //
        // POST: /Esfuerzo/Create

        [HttpPost]
        public ActionResult Create(Esfuerzo esfuerzo,int idEstado,int avanceTarea)
        {
            if (ModelState.IsValid)
            {

                String procedimiento = "";

                var esfuerzoAux = db.Esfuerzo.SingleOrDefault(e => e.fecha_actual == esfuerzo.fecha_actual && e.idTarea == esfuerzo.idTarea);

                if (esfuerzoAux == null)
                    procedimiento = "insertarEsfuerzo";
                else
                    procedimiento = "modificarEsfuerzo";

                SqlConnection dbCon = db.Database.Connection as SqlConnection;
                
                SqlCommand cmd = new SqlCommand(procedimiento, dbCon);

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;

                if (esfuerzoAux == null)
                    cmd.Parameters.Add("idEquipo", SqlDbType.VarChar);


                cmd.Parameters.Add("idTarea", SqlDbType.Int);
                cmd.Parameters.Add("consumoHrs", SqlDbType.Float);
                cmd.Parameters.Add("fecha", SqlDbType.Date);
                cmd.Parameters.Add("comentarios", SqlDbType.VarChar);
                cmd.Parameters.Add("idEstado", SqlDbType.Int);
                cmd.Parameters.Add("avanceTarea", SqlDbType.Int);

                if (esfuerzoAux == null)
                    cmd.Parameters["idEquipo"].Value = "jalcala";
                
                cmd.Parameters["idTarea"].Value = Convert.ToInt32(esfuerzo.idTarea);
                cmd.Parameters["consumoHrs"].Value = Convert.ToDouble(esfuerzo.consumo_hrs, CultureInfo.InvariantCulture);
                cmd.Parameters["fecha"].Value = Convert.ToDateTime(esfuerzo.fecha_actual);
                cmd.Parameters["comentarios"].Value = esfuerzo.comentarios;
                cmd.Parameters["idEstado"].Value = Convert.ToInt32(idEstado);
                cmd.Parameters["avanceTarea"].Value = Convert.ToInt32(avanceTarea);

                dbCon.Open();

                cmd.ExecuteNonQuery();

                dbCon.Close();
                return RedirectToAction("Index", "Tareas", new { message = "!Esfuerzo creado exitosamente!" });
            }

            getData(esfuerzo.idTarea);
            return View();
        }

        //
        // GET: /Esfuerzo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Esfuerzo esfuerzo = db.Esfuerzo.Find(id);
            if (esfuerzo == null)
            {
                return HttpNotFound();
            }
            getData(esfuerzo.idTarea);
            return View(esfuerzo);
        }

        //
        // POST: /Esfuerzo/Edit/5

        [HttpPost]
        public ActionResult Edit(Esfuerzo esfuerzo, int idEstado, int avanceTarea)
        {
            if (ModelState.IsValid)
            {
                SqlConnection dbCon = db.Database.Connection as SqlConnection;

                SqlCommand cmd = new SqlCommand("modificarEsfuerzo", dbCon);

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("idTarea", SqlDbType.Int);
                cmd.Parameters.Add("consumoHrs", SqlDbType.Float);
                cmd.Parameters.Add("fecha", SqlDbType.Date);
                cmd.Parameters.Add("comentarios", SqlDbType.VarChar);
                cmd.Parameters.Add("idEstado", SqlDbType.Int);
                cmd.Parameters.Add("avanceTarea", SqlDbType.Int);


                cmd.Parameters["idTarea"].Value = Convert.ToInt32(esfuerzo.idTarea);
                cmd.Parameters["consumoHrs"].Value = Convert.ToDouble(esfuerzo.consumo_hrs, CultureInfo.InvariantCulture);
                cmd.Parameters["fecha"].Value = Convert.ToDateTime(esfuerzo.fecha_actual);
                cmd.Parameters["comentarios"].Value = esfuerzo.comentarios;
                cmd.Parameters["idEstado"].Value = Convert.ToInt32(idEstado);
                cmd.Parameters["avanceTarea"].Value = Convert.ToInt32(avanceTarea);

                dbCon.Open();

                cmd.ExecuteNonQuery();

                dbCon.Close();
                return RedirectToAction("Index", new { message = "!Esfuerzo actualizado exitosamente!" , idTarea = esfuerzo.idTarea });
            }

            getData(esfuerzo.idTarea);
            return View();
        }

        //
        // GET: /Esfuerzo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Esfuerzo esfuerzo = db.Esfuerzo.Find(id);
            if (esfuerzo == null)
            {
                return HttpNotFound();
            }
            return View(esfuerzo);
        }

        //
        // POST: /Esfuerzo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Esfuerzo esfuerzo = db.Esfuerzo.Find(id);
            db.Esfuerzo.Remove(esfuerzo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public void getData(int idTarea)
        {

            Tarea tarea = db.Tarea.Find(idTarea);
            string proyecto = db.Proyecto.Find(tarea.idProyecto).nombre;
            ViewBag.idTarea = idTarea;
            ViewBag.titulo = tarea.titulo;
            ViewBag.descripcion = tarea.descripcion;
            ViewBag.horas = tarea.presupuesto;
            ViewBag.avance = tarea.avanceTarea;
            ViewBag.tipo = db.Tipo_tarea.Find(tarea.idTipo).descripcion;
            try
            {

                ViewBag.predecesora = db.Tarea.Find(tarea.predecesora).titulo;
            }
            catch (Exception e)
            {
                ViewBag.predecesora = "";
            }
            ViewBag.proyecto = proyecto;

            List<Estados_tareas> estatus = db.Estados_tareas.ToList();
            List<SelectListItem> estados = new List<SelectListItem>();

            foreach (Estados_tareas estado in estatus)
            {
                estados.Add(new SelectListItem { Text = estado.descripcion, Value = estado.idEstado.ToString(),Selected = tarea.idEstado == estado.idEstado });
            }
            ViewData["idEstado"] = estados;

        }

        public JsonResult esfuerzosPorEquipo(string id = null)
        {
            var esfuerzosPorEquipo =
                from esfuerzo in db.Esfuerzo
                join tarea in db.Tarea on esfuerzo.idTarea equals tarea.idTarea
                join equipo in db.Equipo on tarea.idEquipo equals equipo.idEquipo
                where tarea.idProyecto == id
                group esfuerzo by new { equipo.nombre, equipo.idEquipo } into esfuerzos
                select new { nombreEquipo = esfuerzos.Key.nombre, esfuerzo = esfuerzos.Sum(e => e.consumo_hrs) };

            return Json(esfuerzosPorEquipo, JsonRequestBehavior.AllowGet);
        }

    }
}