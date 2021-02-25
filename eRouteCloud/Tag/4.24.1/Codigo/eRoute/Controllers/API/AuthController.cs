using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using eRoute.Models;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

//using eRoute.Controllers.API;
//using System.Web;


namespace eRoute.Controllers.API
{
    [System.Web.Http.AllowAnonymous]
    public class AuthController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;


        [System.Web.Http.HttpPost]
        public IHttpActionResult Login([FromBody] LoginData data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

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

                                return Ok(session);
                            }
                            catch (Exception ex)
                            {
                                return InternalServerError(ex);
                            }
                            finally
                            {
                                Transaction.Dispose();
                                Connection.Close();
                            }
                        }
                    }
                    return BadRequest();
                }
                return NotFound();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return InternalServerError();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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

    }

    //public class LoginData
    //{
    //    [Required]
    //    public string userName { get; set; }
    //    [Required]
    //    public string Password { get; set; }
    //}

    public class SessionDataModel
    {
        public string Clave { get; set; }
        public string PERClave { get; set; }
        public string USUId { get; set; }
        public string Token { get; set; }
    }
}
