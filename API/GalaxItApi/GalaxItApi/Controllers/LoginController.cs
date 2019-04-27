using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GalaxItApi.Data;
using GalaxItApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GalaxItApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly GalaxitContext _context;

        public LoginController(GalaxitContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromForm] string email, [FromForm] byte[] password)
        {
            User entity = await GetUserByEmail(email);
            if (entity == null)
            {
                return NotFound();
            }

            if (entity.Password.Equals(password)) return Ok();
            return Unauthorized();

        }

        private Task<User> GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
