using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using SellingWS.Models;
using SellingWS.Models.API;

namespace SellingWS.Controllers
{
    /// <summary>
    /// Controlador de Sucursales
    /// </summary>
    public class SucursalController : ApiController
    {
        private SellingEntities db = new SellingEntities();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/Sucursal/Show/5
        /// <summary>
        /// Detalle de una Sucursal.
        /// </summary>
        /// <param name="id">El identificador de la Sucursal.</param>
        /// <returns>La información de una Sucursal a la que el usuario tiene Acceso.</returns>
        [HttpGet]
        public Sucursal Show(string id)
        {
            string usrClave = (string)HttpContext.Current.Items["USRClave"];

            if (usrClave == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Sucursal sucursal = db.Sucursal
                .Where(s => s.Baja==false && s.SUCClave == id && s.Usuario.Any(usuario => usuario.USRClave == usrClave && usuario.Baja==false))
                .SingleOrDefault();

            if (sucursal == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return sucursal;
        }

        // GET api/Sucursal/Almacenes/5
        /// <summary>
        /// Listado de Almacenes de una Sucursal.
        /// </summary>
        /// <param name="id">El identificador de la Sucursal.</param>
        /// <returns>El listado de Almacenes de una Sucursal a los que el usuario tiene Acceso.</returns>
        [HttpGet]
        public IQueryable<ApiObject> Almacenes(string id)
        {
            string usrClave = (string)HttpContext.Current.Items["USRClave"];

            if (usrClave == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            IQueryable<ApiObject> almacenes = db.Almacen
                .Where(a => a.SUCClave == id && a.Baja==false)
                .Where(a => a.Sucursal.Usuario.Any(usuario => usuario.USRClave == usrClave && usuario.Baja==false))
                .OrderByDescending(x => x.Predeterminado)
                .Select(a => new ApiObject { clave = a.ALMClave, nombre = a.Nombre });

            return almacenes;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}