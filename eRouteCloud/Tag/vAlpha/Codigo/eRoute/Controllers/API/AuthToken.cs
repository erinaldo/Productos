using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace eRoute.Controllers.API
{
    public class AuthToken
    {
        public static string TokenEncrypt(string UserId, string UserName,string Profile)
        {
            string[] userData = new string[3] { UserId, UserName, Profile };
            FormsAuthenticationTicket formsTicket = new FormsAuthenticationTicket(
                1,
                UserName,
                DateTime.Now,
                DateTime.Now.AddMinutes(10),
                true,
                string.Join("_",userData)
                );

            string encryptedToken = FormsAuthentication.Encrypt(formsTicket);
            return encryptedToken;
        }

        public static string TokenDecrypt(string encrypt)
        {
            try
            {
                FormsAuthenticationTicket forms = FormsAuthentication.Decrypt(encrypt);
                string[] userData = forms.UserData.Split(new string[] { "_" }, StringSplitOptions.None);

                string s = forms.Name;

                return s;
            }
            catch
            {
                return null;
            }
        }
    }
}