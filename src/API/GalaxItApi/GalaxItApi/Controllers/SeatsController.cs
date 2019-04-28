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
    public class SeatsController : ControllerBase
    {
        private readonly GalaxitContext _context;

        public SeatsController(GalaxitContext context)
        {
            _context = context;
        }

        // GET: api/Seats
        [
            HttpGet,
            SwaggerOperation(
                Summary = "Requests all the seats",
                Description = "Returns all the seats"
            ),
            SwaggerResponse(200, "Returns all the seats", typeof(IEnumerable<Seat>))
        ]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
        {
            return await _context.Seats.ToListAsync();
        }

        // GET: api/Seats/5
        [
            HttpGet("{id}"),
            SwaggerOperation(
                Summary = "Requests a seat based on its id",
                Description = "Returns the seat data"
            ),
            SwaggerResponse(200, "Returns the seat data", typeof(Seat)),
            SwaggerResponse(404, "If the seat does not exist")
        ]
        public async Task<ActionResult<Seat>> GetSeat(string id)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == id);
            if (seat == null)
            {
                return NotFound();
            }
            return Ok(seat);
        }

        // PUT: api/Seats/5
        [
            HttpPut("{id}"),
            SwaggerOperation(
                Summary = "Edits a seat based on its id",
                Description = "Returns the edited seat data"
            ),
            SwaggerResponse(204, "Returns no result when it succeeded"),
            SwaggerResponse(400, "If the body does not validate the requirements"),
            SwaggerResponse(404, "If the seat does not exist")
        ]
        public async Task<IActionResult> PutSeat(string id, [FromBody] Seat seat)
        {
            if (id != seat.Id)
            {
                return BadRequest();
            }

            _context.Entry(seat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(id))
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

        // POST: api/Seats
        [
            HttpPost,
            SwaggerOperation(
                Summary = "Creates a seat",
                Description = "Returns the created seat data"
            ),
            SwaggerResponse(201, "Returns the newly created seat", typeof(Seat)),
            SwaggerResponse(400, "If the body does not validate the requirements")
        ]
        public async Task<ActionResult<Seat>> PostSeat([FromBody] Seat seat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();
            return Created($"api/seats/{seat.Id}", seat);
        }

        // DELETE: api/Seats/5
        [
            HttpDelete("{id}"),
            SwaggerOperation(
                Summary = "Deletes a seat based on its id",
                Description = "Returns the deleted seat data"
            ),
            SwaggerResponse(202, "Returns the deleted seat data", typeof(Seat)),
            SwaggerResponse(404, "If the seat does not exist")
        ]
        public async Task<ActionResult<Seat>> DeleteSeat(string id)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();

            return Accepted(seat);
        }

        private bool SeatExists(string id) => _context.Seats.Any(e => e.Id == id);
    }
}
