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
    public class StudentController(AuthDbContext _context) : ControllerBase
    {
        [Authorize(Roles ="Admin")]
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<Students>>> GetAllStudents(int pageNumber, int pageSize)
        {
            var result = await _context.Students.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();

            if (result is null)
                return BadRequest("No students found");

            return Ok(result);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("{name}")]
        public async Task<ActionResult<string>> GetStudentByName(string name)
        {
            var rsult = await _context.Students.FirstOrDefaultAsync(x=>x.Name == name);

            if(rsult is null)
                return BadRequest("No student found with the given name");

            return Ok(rsult);
        }



    }
}
