using eRoute.Controllers.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Net;
using DevExpress.XtraReports.UI;

namespace eRoute.Controllers
{
    public class MenuController : Controller
    {

        public ActionResult Index(string URL)
        {
            if (Session["URL"] != null)
            {
                //if (Session["USUId"] != null && Session["PERClave"] != null) {
                //    Models.ProfileModel oProfile = new Models.ProfileModel();
                //    List<Models.Modulo> oModulos = oProfile.GetModules(Session["PERClave"].ToString(), Session["USUId"].ToString());
                //    return View(oModulos);
                //}
                //else {
                //    return RedirectToAction("Index", "Login");
                //}       
                return View("Landing", new TiemposRutaReport());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NoImplementado() {
            return View("~/Views/Shared/NoImplementado.cshtml");
        }

    }
}