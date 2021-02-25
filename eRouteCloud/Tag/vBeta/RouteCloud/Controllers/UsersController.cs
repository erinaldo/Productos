using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RouteCloud.Services;
using RouteCloud.Models;
using RouteCloud.Entities;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody]Authenticate model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Usuario y/o contraseña incorrectos" });

            return Ok(user);
        }

        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public void Logout([FromBody]Logout model)
        {
            _userService.Logout(model.Token);
        }
    }
}
