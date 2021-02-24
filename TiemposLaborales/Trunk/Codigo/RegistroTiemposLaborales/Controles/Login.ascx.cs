using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Collections;
using System.Collections.Specialized;
using System.Web.Security;
namespace RegistroTiemposLaborales.Controles
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Session["Usuario"].ToString(), DateTime.Now, DateTime.Now.AddHours(6), false, Session["Grupos"].ToString(), FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,hash);
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                

                Response.Cookies.Add(cookie);

                //FormsAuthentication.RedirectFromLoginPage(Session["Usuario"].ToString(), false);
                Response.Redirect("Default.aspx");


          
            }
          
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = IsAuthenticated(System.Configuration.ConfigurationManager.AppSettings["Dominio"], ebLogin.Text, ebPassword.Text);
            }
            catch (Exception ex)
            {
                args.IsValid = false;
                CustomValidator1.Text = ex.Message;
            }
            
        }

        public bool IsAuthenticated(string domain, string username, string pwd)
        {
            //Session["Grupos"] = "";
            //Session["Nombre"] = "ESTA MODIFICADO";
            //Session["Usuario"] = username;
            //return true;
            string Grupos = "";
            username = username.Trim().ToLower();
            string domainAndUsername = domain + "\\" + username;
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + System.Configuration.ConfigurationManager.AppSettings["LDAP"], domainAndUsername, pwd);

            // Bind to the native AdsObject to force authentication.
            Object obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            if (null == result)
            {
                return false;
            }
            DirectoryEntry obUser = new DirectoryEntry(result.Path);
            // Invoke Groups method.
            StringCollection groups = new StringCollection();

            object obGroups = obUser.Invoke("Groups");
            foreach (object ob in (IEnumerable)obGroups)
            {
                // Create object for each group.

                DirectoryEntry obGpEntry = new DirectoryEntry(ob);
                Grupos += obGpEntry.Name + ",";

            }
            //string[] strings = new string[groups.Count];
            //groups.CopyTo(strings, 0);
            Grupos = Grupos.Replace("CN=", "");
            if (Grupos.Length > 0)
                Grupos = Grupos.Substring(0, Grupos.Length - 1);



            Session["Grupos"] = Grupos;
            Session["Nombre"] = (String)result.Properties["cn"][0];
            Session["Usuario"] = username;
            return true;
        }


        public string getGroups(SearchResult result)
        {
            int propertyCount = result.Properties["memberOf"].Count;
            System.Text.StringBuilder groupNames = new System.Text.StringBuilder();

            String dn;
            int equalsIndex, commaIndex;

            for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
            {
               
                dn = (String)result.Properties["memberOf"][propertyCounter];

                equalsIndex = dn.IndexOf("=", 1);
                commaIndex = dn.IndexOf(",", 1);
                if (-1 == equalsIndex)
                {
                    return null;
                }

                groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                groupNames.Append("|");



            }
            return groupNames.ToString();
        }
    }
}