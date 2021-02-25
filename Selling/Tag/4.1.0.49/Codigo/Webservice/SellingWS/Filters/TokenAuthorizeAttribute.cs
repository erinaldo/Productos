using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SellingWS.Models;

namespace SellingWS.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TokenAuthorizeAttribute : AuthorizationFilterAttribute
    {
        bool _active = true;

        public TokenAuthorizeAttribute() { }

        /// <summary>
        /// Overriden constructor to allow explicit disabling of this filter's behavior.
        /// Pass false to disable (same as no filter but declarative)
        /// </summary>
        /// <param name="active"></param>
        public TokenAuthorizeAttribute(bool active)
        {
            _active = active;
        }

        /// <summary>
        /// Skips Authorization on AllowAnonymousAttribute
        /// </summary>
        /// <param name="actionContext"></param>
        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<System.Web.Http.AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<System.Web.Http.AllowAnonymousAttribute>().Any();
        }

        /// <summary>
        /// Override to Web API filter method to handle Basic Auth check
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Quit out here if the filter has been invoked with active being set to false.
            if (!_active) return;

            if (SkipAuthorization(actionContext))
                return;

            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader == null || !IsTokenValid(authHeader.Parameter))
            {
                // No authorization header has been supplied, therefore we are definitely not authorized
                // so return a 403 Forbidden result.
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }

        private bool IsTokenValid(string parameter)
        {
            // Perform basic token checking against a value
            // stored in a database table.

            SellingEntities db = new SellingEntities();

            var userToken = db.Tokens
                .Include("Usuario")
                .SingleOrDefault(t => t.token == parameter && t.Usuario.Baja==false);

            if (userToken == null)
                return false;

            HttpContext.Current.Items["USRClave"] = userToken.Usuario.USRClave;
            HttpContext.Current.Items["TokenId"] = userToken.TokenId;

            return true;
        }
    }
}