using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GalaxItApi.Data;
using GalaxItApi.Models;

namespace GalaxItApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BubblesController : ControllerBase
    {
        private readonly GalaxitContext _context;

        public BubblesController(GalaxitContext context)
        {
            _context = context;
        }

        // GET: api/Bubbles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bubble>>> GetBubbles()
        {
            return await _context.Bubbles.ToListAsync();
        }

        // GET: api/Bubbles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bubble>> GetBubble(string id)
        {
            var bubble = await _context.Bubbles.FindAsync(id);

            if (bubble == null)
            {
                return NotFound();
            }

            return bubble;
        }

        // PUT: api/Bubbles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBubble(string id, Bubble bubble)
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
        [HttpPost]
        public async Task<ActionResult<Bubble>> PostBubble(Bubble bubble)
        {
            _context.Bubbles.Add(bubble);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBubble", new { id = bubble.Id }, bubble);
        }

        // DELETE: api/Bubbles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bubble>> DeleteBubble(string id)
        {
            var bubble = await _context.Bubbles.FindAsync(id);
            if (bubble == null)
            {
                return NotFound();
            }

            _context.Bubbles.Remove(bubble);
            await _context.SaveChangesAsync();

            return bubble;
        }

        private bool BubbleExists(string id)
        {
            return _context.Bubbles.Any(e => e.Id == id);
        }
    }
}
