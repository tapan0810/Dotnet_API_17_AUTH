using Dotnet_API_17.Entities.Dtos;
using Dotnet_API_17.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API_17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginDto login)
        {
            var result = await authService.Login(login);
            if (result == null)
            {
                return BadRequest("Username or password is incorrect");
            }
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto register)
        {
            var result = await authService.Register(register);
            if (result == null)
            {
                return BadRequest("Username already exists");
            }
            return Ok(result);
        }
    }
}
