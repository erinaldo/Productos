using eRoute.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;

namespace eRoute.Controllers.API
{
    [AuthorizeAPI]
    public class LogoutController : ApiController
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString;

        [HttpPost]
        public IHttpActionResult Logout([FromBody] LogoutModel model)
        {
            try
            {
                Connection.Open();

                string UserName = AuthToken.TokenDecrypt(model.Token);

                QueryString = "SELECT * FROM Tokens where Clave = '" + UserName + "' and Token = '" + model.Token + "'";
                TokenModel Token = Connection.Query<TokenModel>(QueryString).First();

                Connection.Close();

                Connection.Open();
                using (var Transaction = Connection.BeginTransaction())
                {
                    try
                    {
                        QueryString = "DELETE FROM Tokens WHERE Id = @Id";
                        Connection.Execute(QueryString, new { Id = Token.Id }, Transaction);
                        Transaction.Commit();
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback();
                        return InternalServerError();
                    }
                    finally
                    {
                        Transaction.Dispose();
                        Connection.Close();
                    }
                }
            }
            catch
            {
                return InternalServerError();
            }
        }
    }

    public class LogoutModel
    {
        public string Token { get; set; }
    }
}
