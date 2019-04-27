using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GalaxItApi.Data;
using GalaxItApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GalaxItApi.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace GalaxItApi.Controllers
{
    [
        Route("api/[controller]/[Action]"),
        ApiController,
        Produces("application/json")
    ]
    public class LoginController : ControllerBase
    {
        private readonly GalaxitContext _context;

        public LoginController(GalaxitContext context)
        {
            _context = context;
        }

        [
            HttpPost,
            SwaggerOperation(
                Summary = "Requests a user's token",
                Description = "Returns the user's id"
            ),
            SwaggerResponse(200, "Returns the user's id", typeof(string)),
            SwaggerResponse(401, "If the passwords do not match"),
            SwaggerResponse(404, "If the user does not exist")
        ]
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

        [
            HttpPost,
            SwaggerOperation(
                Summary = "Register into an account",
                Description = "Returns the user's id"
            ),
            SwaggerResponse(200, "Returns the user's id", typeof(string)),
            SwaggerResponse(400, "If the email is already associated with an account")
        ]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            User entity = await GetUserByEmail(user.Email);
            if (entity != null)
            {
                return BadRequest("Email is already associated with an account");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user.Id);
        }

        private Task<User> GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
