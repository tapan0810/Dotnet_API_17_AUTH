using Dotnet_API_17.Data;
using Dotnet_API_17.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(AuthDbContext _context) : ControllerBase
    {
        [Authorize(Roles ="Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            if(users is null || users.Count == 0)
            {
                return NotFound("No users found.");
            }

            return Ok(users);

        }   
    }
}
