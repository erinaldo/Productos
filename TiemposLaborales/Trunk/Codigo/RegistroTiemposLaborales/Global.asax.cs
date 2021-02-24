using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace RegistroTiemposLaborales
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(Object sender,  EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id =
                            (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;

                        // Get the stored user-data, in this case, our roles
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, roles);
                    }
                    else
                        throw new System.Exception("No tienes permisos para ingresar");

                       
                }
                else
                throw new System.Exception("No tienes permisos para ingresar");

            }


        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Exception objErr = Server.GetLastError().GetBaseException();
                String err = "<b>Error Caught in Page_Error event</b><hr><br>";
                err += "<br><b>Error in: </b>" + Request.Url.ToString();
                err += "<br><b>Error Message: </b>" + objErr.Message.ToString();
                err += "<br><b>Stack Trace:</b><br>";
                err += objErr.StackTrace.ToString();
               Response.Write(  err);

            }
            catch { }
            //Response.Write(err.ToString());
            //Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {
           

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}