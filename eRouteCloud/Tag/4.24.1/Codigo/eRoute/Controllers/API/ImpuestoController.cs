using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eRoute.Models;
using System.Web.Script.Serialization;

namespace eRoute.Controllers.API
{
    public class ImpuestoController : ApiController
    {

        [HttpGet]
        [ActionName("ObtenerImpuestosActivos")]
        public IHttpActionResult ObtenerImpuestosActivos()
        {
            RouteEntities db = new RouteEntities();
            var impuestos = (from imp in db.Impuesto
                            where imp.TipoEstado == 1
                            select new {
                                Seleccionado = false,
                                imp.ImpuestoClave,
                                imp.Nombre,
                                imp.Abreviatura
                            }).ToList();
                                     
            return Json(impuestos);
        }
    }
}
