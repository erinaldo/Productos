using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eRoute.Controllers.API
{
    public class OpenFilterController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GET(string VAVClave)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
