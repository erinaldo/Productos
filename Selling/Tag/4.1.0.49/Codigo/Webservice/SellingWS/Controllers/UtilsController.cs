using System.Collections;
using System.Linq;
using System.Web.Http;
using SellingWS.Models;

namespace SellingWS.Controllers
{
    /// <summary>
    /// Controlador utilidades
    /// </summary>
    public class UtilsController : ApiController
    {
        private SellingEntities db = new SellingEntities();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/Utils/ValorRef
        /// <summary>
        /// Las referencias de los valores de cada campo por tabla.
        /// </summary>
        /// <returns>Las referencias de los valores de cada campo por tabla.</returns>
        [HttpGet]
        public IEnumerable ValorRef()
        {
            IEnumerable referencias = from v in db.ValorRef
                                      where v.Baja==false
                                      select new
                                      {
                                          tabla = v.Tabla,
                                          campo = v.Campo,
                                          valor = v.Valor,
                                          descripcion = v.Descripcion,
                                          grupo = v.Grupo ?? 0
                                      };

            return referencias;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}