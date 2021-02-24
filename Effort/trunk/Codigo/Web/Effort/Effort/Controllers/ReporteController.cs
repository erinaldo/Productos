using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Effort.Filters;

namespace Effort.Controllers
{
    [RoleFilter]
    [SessionExpireFilter]
    public class ReporteController : Controller
    {
        //
        // GET: /ReportViewer/

        public ActionResult TareasEmpleado()
        {
            return Redirect("~/ReportViewer/ReporteTareasPorEquipo.aspx");
        }

        public ActionResult Gantt()
        {
            return Redirect("~/ReportViewer/ReporteGantt.aspx");
        }

        public ActionResult ProyectosAsignados()
        {
            return Redirect("~/ReportViewer/ReporteProyectosAsignados.aspx");
        }

        public ActionResult EsfuerzoProyectos()
        {
            return Redirect("~/ReportViewer/ReporteEsfuerzoProyectos.aspx");
        }

        public ActionResult EsfuerzoTareas()
        {
            return Redirect("~/ReportViewer/ReporteEsfuerzoTareas.aspx");
        }

        public ActionResult AdministracionRiesgo()
        {
            return Redirect("~/ReportViewer/ReporteAdministracionRiesgo.aspx");
        }

        public ActionResult Avance()
        {
            return Redirect("~/ReportViewer/ReporteAvance.aspx");
        }

    }
}
