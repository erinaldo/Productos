using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;

namespace eRoute.Controllers.API
{
    public class ProfileListController : ApiController
    {
        
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        string QueryString;

        [HttpGet]
        [ActionName("GetModules")]
        public IHttpActionResult GetModules(string PERClave, string USUId)
        {
            try
            {
                Models.ProfileModel oProfile = new Models.ProfileModel();
                List<Models.cModulo> List = oProfile.GetModules(PERClave, USUId);

                return Json(List);
            }
            catch
            {
                return null;
            }
        }

        //[HttpGet]
        //[ActionName("GetActivities")]
        //public IHttpActionResult GetActivities(string PERClave, string USUId)
        //{
        //    try
        //    {
        //        Models.ProfileModel oProfile = new Models.ProfileModel();
        //        List<Models.Actividad> List = oProfile.GetActivities(PERClave, USUId);

        //        return Json(List);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
