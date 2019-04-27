using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GalaxItApi.Data;
using GalaxItApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GalaxItApi.DTO;

namespace GalaxItApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly GalaxitContext _context;

        public LoginController(GalaxitContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            User entity = await GetUserByEmail(login.Email);
            if (entity == null)
            {
                return NotFound();
            }

            if (entity.Password.Equals(login.Password)) return Ok(entity.Id);
            return Unauthorized();

        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            User entity = await GetUserByEmail(user.Email);
            if (entity == null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user.Id);
            }
            return BadRequest("Email is already associated with an account");
        }

        private Task<User> GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
