using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;

using System.Web.Http.Controllers;
using System.Diagnostics.Contracts;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.SessionState;
using eRoute.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;


namespace eRoute.Controllers.API
{
    public class AuthorizeAPI : AuthorizationFilterAttribute
    {


        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);
            return actionContext.ActionDescriptor.GetCustomAttributes<System.Web.Http.AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<System.Web.Http.AllowAnonymousAttribute>().Any();
        }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
            string QueryString;
            //if (SkipAuthorization(actionContext))
            //    return;


            var header = actionContext.Request.Headers.Authorization;

            if (header.Scheme != null)
            {
                string userName = AuthToken.TokenDecrypt(header.Scheme);
                if (!String.IsNullOrEmpty(userName))
                {
                    Connection.Open();
                    QueryString = "SELECT * FROM Tokens where Clave = '" + userName + "' and Token = '" + header.Scheme + "'";
                    List<TokenModel> TokenList = Connection.Query<TokenModel>(QueryString).ToList();
                    Connection.Close();
                    if (TokenList.Count() > 0)
                    {
                        if (TokenList.ElementAt(0).Fecha_Expiracion <= DateTime.Now.AddMinutes(30))
                        {
                            Connection.Open();
                            using (var Transaction = Connection.BeginTransaction())
                            {
                                try
                                {
                                    QueryString = "UPDATE Tokens SET Fecha_Emision = @Emision, Fecha_Expiracion = @Expiration WHERE Id = @Id";
                                    Connection.Execute(QueryString, new { Id = TokenList.ElementAt(0).Id, Emision = DateTime.Now, Expiration = DateTime.Now.AddMinutes(30) }, Transaction);
                                    Transaction.Commit();
                                    return;
                                }
                                catch { }
                                finally
                                {
                                    Transaction.Dispose();
                                    Connection.Close();
                                }
                            }
                        }
                    }
                }
            }

            HandleUnauthorized(actionContext);
        }

        void HandleUnauthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}