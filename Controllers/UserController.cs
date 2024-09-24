using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace GarageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDto loginData)
        {

            if (loginData.UserName == null || loginData.UserName == "")//es lo mismo que: if(string.IsNullOrEmpty(loginData.UserName))
            {
                return BadRequest("Debe ingresar un nombre de usuario.");
            }
            if (loginData.Password == null || loginData.Password == "")//es lo mismo que: if(string.IsNullOrEmpty(loginData.Password))
            {
                return BadRequest("Debe ingresar una contraseña.");
            }

            var loginResult = _userService.ValidateUser(loginData);

            if (loginResult == true)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
