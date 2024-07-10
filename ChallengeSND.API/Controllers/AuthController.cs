using ChallengeSND.Business.DTOS;
using ChallengeSND.Business.Servicies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeSND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;

        public AuthController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Business.DTOS.LoginRequest request)
        {

            var user = new User { UserName = request.UserName, Role = "Admin" };
            var token = _authenticationService.GenerateToken(user);

         
            return Ok(new { Token = token });
        }
    }
}
