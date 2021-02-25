using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SellingWS.Models;
using SellingWS.Models.API;
using SellingWS.Security;

namespace SellingWS.Controllers
{
    /// <summary>
    /// Controlador de Tokens
    /// </summary>
    public class TokensController : ApiController
    {
        private SellingEntities db = new SellingEntities();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // POST api/Tokens/Login/USRClave
        /// <summary>
        /// Genera un token de acceso.
        /// </summary>
        /// <param name="usuario">ApiUsuario{nombre,contrasenia}.</param>
        /// <returns>Token de acceso .</returns>
        [AllowAnonymous]
        public HttpResponseMessage Login([FromBody]ApiUsuario usuario)
        {
            Compania companina = db.Compania.First();
            if (companina.VersionRF != usuario.versionRF)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.Token_Version_Error));

            try
            {
               
                Usuario usuarioInstance = db.Usuario.SingleOrDefault(u => u.Login == usuario.usuario && u.Baja == false);

                if (usuarioInstance == null || !HashPass.ValidatePassword(usuario.contrasenia, usuarioInstance.Password))
                    throw new UnauthorizedAccessException();

                ApiLoginSucursalesResponse[] sucursales = usuarioInstance.Sucursal
                    .Where(sucursal => sucursal.Baja == false)
                    .Select(sucursal => new ApiLoginSucursalesResponse { clave = sucursal.SUCClave, nombre = sucursal.Nombre, COMClave = sucursal.COMClave, ubicacionRecibo = sucursal.UbicacionRecibo })
                    .OrderByDescending(s => s.clave == usuarioInstance.SUCClave)
                    .ToArray();
                
                log.Info(usuarioInstance.Nombre);

                CompanyParam tallaColor = db.CompanyParam.FirstOrDefault(tc => tc.PARClave == "TallaColor");
                if (tallaColor == null)
                    tallaColor.Valor = "0";

                Tokens token = db.Tokens.SingleOrDefault(t => t.USRClave == usuarioInstance.USRClave);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Token = token.token, Sucursales = sucursales, TallaColor = int.Parse(tallaColor.Valor) });
                }
                else
                {
                    token = new Tokens
                    {
                        USRClave = usuarioInstance.USRClave,
                        fechaCreacion = DateTime.Now,
                        ip = HttpContext.Current.Request.UserHostAddress
                    };
                    token.token = HashPass.CreateHash(token.ip + usuarioInstance.USRClave + token.fechaCreacion.ToString(CultureInfo.InvariantCulture));
                    db.Tokens.Add(token);

                    db.SaveChanges();
                    
                    return Request.CreateResponse(HttpStatusCode.Created, new ApiTokensLoginResponse { Token = token.token, Sucursales = sucursales, TallaColor = int.Parse(tallaColor.Valor) });
                }
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                log.Error("UnauthorizedAccessException", unauthorizedAccessException);
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, Resources.Mensajes.General_USRClave_NotFound);
            }
            catch (Exception ex)
            {
                log.Error("Error General", ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Resources.Mensajes.General_Error);
            }
        }

        // GET api/Tokens/5
        /// <summary>
        /// Elimina un token de acceso.
        /// </summary>
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            int? tokenId = (int)HttpContext.Current.Items["TokenId"];

            Tokens tokenInstance = db.Tokens.SingleOrDefault(t => t.TokenId == tokenId);
            if (tokenInstance == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Tokens.Remove(tokenInstance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                log.Error(ex);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Resources.Mensajes.General_Error);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}