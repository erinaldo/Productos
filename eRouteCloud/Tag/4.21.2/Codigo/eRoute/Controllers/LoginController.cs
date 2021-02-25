using eRoute.Controllers.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using eRoute.Models;
using System.Web.Security;

namespace eRoute.Controllers
{
    public class LoginController : Controller
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Log(LoginData data)
        {
            try
            {
                Connection.Open();
                QueryString = "Select * from usuario where Clave = '" + data.userName + "'";
                List<UserModel> User = Connection.Query<UserModel>(QueryString).ToList();
                Connection.Close();

                if (User.Count() >= 1)
                {
                    UserModel model = User.ElementAt(0);
                    string EncryptPass = SimpleCrypt(model.ClaveAcceso);
                    if (EncryptPass == data.Password)
                    {
                        Connection.Open();
                        using (var Transaction = Connection.BeginTransaction())
                        {
                            try
                            {
                                string Token = AuthToken.TokenEncrypt(model.USUId, model.Clave, model.PERClave);
                                QueryString = "INSERT INTO Tokens (Id,USUId,Clave,PERClave,Fecha_Emision, Fecha_Expiracion,Token) VALUES (@Id,@USUId,@Clave,@PerClave,@Emision,@Expiracion,@Token)";
                                Connection.Execute(QueryString, new { Id = Guid.NewGuid(), USUId = model.USUId, Clave = model.Clave, PerClave = model.PERClave, Emision = DateTime.Now, Expiracion = DateTime.Now.AddMinutes(30), Token = Token }, Transaction);
                                Transaction.Commit();
                                SessionDataModel session = new SessionDataModel();
                                session.Token = Token;
                                session.USUId = model.USUId;
                                session.PERClave = model.PERClave;
                                session.Clave = model.Clave;
                                                                
                                FormsAuthentication.SetAuthCookie(model.USUId, false);
                                //return Ok(session);
                                //return JavaScript("<script>alert(\"some message\")</script>");
                                return RedirectToAction("Index", "Menu");
                            }
                            catch (Exception ex)
                            {
                                //return InternalServerError(ex);
                                return null;
                            }
                            finally
                            {
                                Transaction.Dispose();
                                Connection.Close();
                            }
                        }
                    }
                    //return BadRequest();
                    return null;
                }
                //return NotFound();
                return null;
            }
            catch
            {
                return null;
                //return InternalServerError();
            }

        }

        public string SimpleCrypt(string Text)
        {
            // Encrypts/decrypts the passed string using a simple ASCII value-swapping algorithm 
            string strTempChar = "";
            for (int i = 0; i < Text.Length; i++)
            {
                if (char.ConvertToUtf32(Text, i) < 128)
                    strTempChar += char.ConvertFromUtf32(char.ConvertToUtf32(Text, i) + 128);
                else if (char.ConvertToUtf32(Text, i) > 128)
                    strTempChar += char.ConvertFromUtf32(char.ConvertToUtf32(Text, i) - 128);
            }
            return strTempChar;
        }



        public ActionResult SetSession(string URL, string USUId, string PERClave)
        {
            if (URL.Contains("Login"))
            {
                URL.Replace("Login", "");
            }

            Session["URL"] = URL;
            Session["USUId"] = USUId;
            Session["PERClave"] = PERClave;

            return Json(true);
        }

        public ActionResult DeleteSession()
        {
            Session["URL"] = null;
            return Json(true);
        }
    }
}