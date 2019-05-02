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
    public class TablesController : ControllerBase
    {
        private readonly GalaxitContext _context;

        public TablesController(GalaxitContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        [
            HttpGet,
            SwaggerOperation(
                Summary = "Requests all the tables",
                Description = "Returns all the available tables"
            ),
            SwaggerResponse(200, "Returns all the available tables", typeof(IEnumerable<Table>))
        ]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await _context.Tables.Include(t=>t.Seats).ToListAsync();
        }

        // GET: api/Tables/5
        [
            HttpGet("{id}"),
            SwaggerOperation(
                Summary = "Requests a table based on its id",
                Description = "Returns the table data"
            ),
            SwaggerResponse(200, "Returns the table data", typeof(Table)),
            SwaggerResponse(404, "If the table does not exist")
        ]
        public async Task<ActionResult<Table>> GetTable(string id)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(t => t.Id == id);
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

        // GET: api/Tables/FromBubble/5
        [
            HttpGet("FromBubble/{id}"),
            SwaggerOperation(
                Summary = "Requests a table based on it own location",
                Description = "Returns the table data"
            ),
            SwaggerResponse(200, "Returns the table data", typeof(Table)),
            SwaggerResponse(404, "If the table does not exist")
        ]
        public async Task<ActionResult<Table>> GetTableFromBubble(string id)
        {
            var bubble = await _context.Bubbles.Include(b => b.Tables).ThenInclude(t => t.Seats).FirstOrDefaultAsync(b => b.Id == id);
            if (bubble == null)
            {
                return NotFound();
            }
            return Ok(bubble);
        }

        // PUT: api/Tables/5
        [
            HttpPut("{id}"),
            SwaggerOperation(
                Summary = "Edits a table based on its id",
                Description = "Returns the edited table data"
            ),
            SwaggerResponse(204, "Returns no result when it succeeded"),
            SwaggerResponse(400, "If the body does not validate the requirements"),
            SwaggerResponse(404, "If the table does not exist")
        ]
        public async Task<IActionResult> PutTable(string id, [FromBody] Table table)
        {
            if (id != table.Id)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
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

        // POST: api/Tables
        [
            HttpPost,
            SwaggerOperation(
                Summary = "Creates a table",
                Description = "Returns the created table data"
            ),
            SwaggerResponse(201, "Returns the newly created table", typeof(Table)),
            SwaggerResponse(400, "If the body does not validate the requirements")
        ]
        public async Task<ActionResult<Table>> PostTable([FromBody] Table table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return Created($"api/tables/{table.Id}", table);
        }

        // DELETE: api/Tables/5
        [
            HttpDelete("{id}"),
            SwaggerOperation(
                Summary = "Deletes a table based on its id",
                Description = "Returns the deleted table data"
            ),
            SwaggerResponse(202, "Returns the deleted table data", typeof(Table)),
            SwaggerResponse(404, "If the table does not exist")
        ]
        public async Task<ActionResult<Table>> DeleteTable(string id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return Accepted(table);
        }

        private bool TableExists(string id) => _context.Tables.Any(e => e.Id == id);
    }
}
