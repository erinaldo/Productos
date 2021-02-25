using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RouteCloud.Context;
using RouteCloud.Entities;

namespace RouteCloud.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        void Logout(string token);
    }

    public class UserService : IUserService
    {
        private List<User> _users;
        private readonly RouteCloudContext _context;
        private readonly RouteContext _contextR;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, RouteContext contextR, RouteCloudContext context)
        {
            _appSettings = appSettings.Value;
            _contextR = contextR;
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            _users = (from u in _context.Usuario
                      where (_contextR.Login.FromSqlInterpolated($"SELECT dbo.FNCrypt( { password } ) AS Password").FirstOrDefault()).Password.Contains(u.ClaveAcceso) && username.Contains(u.Clave)
                      select new User
                      {
                          USUId = u.Usuid,
                          Clave = u.Clave,
                          PERClave = u.Perclave,
                          Fecha_Emision = DateTime.Now.ToString(),
                          Fecha_Expiracion = DateTime.Now.AddMinutes(30).ToString()
                      }).ToList();

            var user = _users.FirstOrDefault();

            // Return null if user not found
            if (user == null)
                return null;

            // Authentication successful so generate JWT Token
            user.Id = Guid.NewGuid();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddSeconds(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            try
            {
                _context.Database.OpenConnection();
                _context.Database.BeginTransaction();
                _context.Database.ExecuteSqlInterpolated($"INSERT INTO Tokens (Id,USUId,Clave,PERClave,Fecha_Emision, Fecha_Expiracion,Token) VALUES ({user.Id},{user.USUId},{user.Clave},{user.PERClave},{user.Fecha_Emision},{user.Fecha_Expiracion},{user.Token})");
                _context.Database.CommitTransaction();
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                _context.Database.RollbackTransaction();
                throw new Exception("Error de conexion: ", ex);
            }
            finally
            {
                _context.Database.CloseConnection();
            }
            return user;
        }

        public void Logout(string token)
        {
            try
            {
                _context.Database.OpenConnection();
                _context.Database.BeginTransaction();
                _context.Database.ExecuteSqlInterpolated($"DELETE FROM Tokens WHERE Id = {token}");
                _context.Database.CommitTransaction();
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                _context.Database.RollbackTransaction();
                throw new Exception("Error de conexion: ", ex);
            }
            finally
            {
                _context.Database.CloseConnection();
            }
        }
    }
}