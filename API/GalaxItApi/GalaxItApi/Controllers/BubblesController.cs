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
    public class BubblesController : ControllerBase
    {
        private readonly GalaxitContext _context;

        public BubblesController(GalaxitContext context)
        {
            _context = context;
        }

        // GET: api/Bubbles
        [
            HttpGet,
            SwaggerOperation(
                Summary="Requests all the bubbles",
                Description = "Returns all the available bubbles"
            ),
            SwaggerResponse(200, "Returns all the available bubbles", typeof(IEnumerable<Bubble>))
        ]
        public async Task<ActionResult<IEnumerable<Bubble>>> GetBubbles()
        {
            return await _context.Bubbles.ToListAsync();
        }

        // GET: api/Bubbles/5
        [
            HttpGet("{id}"),
            SwaggerOperation(
                Summary = "Requests a bubble based on its id",
                Description = "Returns the bubble data"
            ),
            SwaggerResponse(200, "Returns the bubble data", typeof(Bubble)),
            SwaggerResponse(404, "If the bubble does not exist")
        ]
        public async Task<ActionResult<Bubble>> GetBubble(string id)
        {
            var bubble = await _context.Bubbles.FirstOrDefaultAsync(b => b.Id == id);
            if (bubble == null)
            {
                return NotFound();
            }
            return bubble;
        }

        // PUT: api/Bubbles/5
        [
            HttpPut("{id}"),
            SwaggerOperation(
                Summary = "Edits a bubble based on its id",
                Description = "Returns the edited bubble data"
            ),
            SwaggerResponse(204, "Returns no result when it succeeded"),
            SwaggerResponse(400, "If the body does not validate the requirements"),
            SwaggerResponse(404, "If the bubble does not exist")
        ]
        public async Task<IActionResult> PutBubble(string id, [FromBody] Bubble bubble)
        {
            if (id != bubble.Id)
            {
                return BadRequest();
            }

            _context.Entry(bubble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BubbleExists(id))
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

        // POST: api/Bubbles
        [
            HttpPost,
            SwaggerOperation(
                Summary = "Creates a bubble",
                Description = "Returns the created bubble data"
            ),
            SwaggerResponse(201, "Returns the newly created bubble", typeof(Bubble)),
            SwaggerResponse(400, "If the body does not validate the requirements")
        ]
        public async Task<ActionResult<Bubble>> PostBubble([FromBody] Bubble bubble)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Bubbles.Add(bubble);
            await _context.SaveChangesAsync();
            return Created($"api/bubble/{bubble.Id}", bubble);
        }

        // DELETE: api/Bubbles/5
        [
            HttpDelete("{id}"),
            SwaggerOperation(
                Summary = "Deletes a bubble based on its id",
                Description = "Returns the deleted bubble data"
            ),
            SwaggerResponse(202, "Returns the deleted bubble data", typeof(Bubble)),
            SwaggerResponse(404, "If the bubble does not exist")
        ]
        public async Task<ActionResult<Bubble>> DeleteBubble(string id)
        {
            var bubble = await _context.Bubbles.FirstOrDefaultAsync(b => b.Id == id);
            if (bubble == null)
            {
                return NotFound();
            }

            _context.Bubbles.Remove(bubble);
            await _context.SaveChangesAsync();

            return bubble;
        }

        [
            HttpPut("NewNumberUser/{id}"),
            SwaggerOperation(
                Summary = "Edits a bubble based on its id",
                Description = "Returns the edited bubble data"
            ),
            SwaggerResponse(202, "Returns the edited bubble data", typeof(Bubble)),
            SwaggerResponse(404, "If the bubble does not exist")
        ]
        public async Task<ActionResult<Bubble>> SendNewNumberOfUsers(string id, [FromBody] bool[] place)
        {
            var bubble = await _context.Bubbles
                .Include(b => b.Tables)
                .ThenInclude(t => t.Seats)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bubble == null) return NotFound();
            foreach (var t in bubble.Tables)
            {
                var j = 0;
                foreach (var seat in t.Seats)
                {
                    seat.Occupied = place[j];
                    j++;
                }
            }
            _context.Entry(bubble).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return bubble;
        }

        private bool BubbleExists(string id) => _context.Bubbles.Any(e => e.Id == id);
    }
}
