using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GalaxItApi.Data;
using GalaxItApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace GalaxItApi.Controllers
{
    [
        Route("api/[controller]"),
        ApiController,
        Produces("application/json")
    ]
    public class UsersController : ControllerBase
    {
        private readonly GalaxitContext _context;

        public UsersController(GalaxitContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [
            HttpGet,
            SwaggerOperation(
                Summary = "Requests all the users",
                Description = "Returns all the available users"
            ),
            SwaggerResponse(200, "Returns all the available users", typeof(IEnumerable<User>))
        ]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [
            HttpGet("{id}"),
            SwaggerOperation(
                Summary = "Requests a user based on its id",
                Description = "Returns the user data"
            ),
            SwaggerResponse(200, "Returns the user data", typeof(User)),
            SwaggerResponse(404, "If the user does not exist")
        ]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Users/5
        [
            HttpPut("{id}"),
            SwaggerOperation(
                Summary = "Edits a user based on its id",
                Description = "Returns the edited user data"
            ),
            SwaggerResponse(204, "Returns no result when it succeeded"),
            SwaggerResponse(400, "If the body does not validate the requirements"),
            SwaggerResponse(404, "If the user does not exist")
        ]
        public async Task<IActionResult> PutUser(string id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [
            HttpPost,
            SwaggerOperation(
                Summary = "Creates a user",
                Description = "Returns the created user data"
            ),
            SwaggerResponse(201, "Returns the newly created user", typeof(User)),
            SwaggerResponse(400, "If the body does not validate the requirements")
        ]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Created($"api/users/{user.Id}", user);
        }

        // DELETE: api/Users/5
        [
            HttpDelete("{id}"),
            SwaggerOperation(
                Summary = "Deletes a user based on its id",
                Description = "Returns the deleted user data"
            ),
            SwaggerResponse(202, "Returns the deleted user data", typeof(User)),
            SwaggerResponse(404, "If the user does not exist")
        ]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Accepted(user);
        }

        private bool UserExists(string id) => _context.Users.Any(e => e.Id == id);
    }
}
