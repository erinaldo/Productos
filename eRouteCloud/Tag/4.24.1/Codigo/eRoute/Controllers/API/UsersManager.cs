using eRoute.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace eRoute.Controllers.API
{
    public class UsersManager
    {
        public static UserModel GetUserById(string Id)
        {
            try
            {
                IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

                string QueryString = "Select * from usuario where Clave = '" + Id + "'";
                UserModel User = Connection.Query<UserModel>(QueryString).First();
                return User;
            }
            catch
            {
                return null;
            }

        }
    }
}