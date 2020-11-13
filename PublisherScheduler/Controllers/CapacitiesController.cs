using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherScheduler.Models;

namespace PublisherScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitiesController : ControllerBase
    {
        private readonly SchedulerContext _context;

        public CapacitiesController(SchedulerContext context)
        {
            _context = context;
        }

        // GET: api/Capacities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capacities>>> GetCapacities()
        {
            return await _context.Capacities.ToListAsync();
        }

        // GET: api/Capacities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capacities>> GetCapacities(int id)
        {
            var capacities = await _context.Capacities.FindAsync(id);

            if (capacities == null)
            {
                return NotFound();
            }

            return capacities;
        }

        // PUT: api/Capacities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacities(int id, Capacities capacities)
        {
            if (id != capacities.Id)
            {
                return BadRequest();
            }

            _context.Entry(capacities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacitiesExists(id))
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

        // POST: api/Capacities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Capacities>> PostCapacities(Capacities capacities)
        {
            _context.Capacities.Add(capacities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapacities", new { id = capacities.Id }, capacities);
        }

        // DELETE: api/Capacities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Capacities>> DeleteCapacities(int id)
        {
            var capacities = await _context.Capacities.FindAsync(id);
            if (capacities == null)
            {
                return NotFound();
            }

            _context.Capacities.Remove(capacities);
            await _context.SaveChangesAsync();

            return capacities;
        }

        private bool CapacitiesExists(int id)
        {
            return _context.Capacities.Any(e => e.Id == id);
        }
    }
}
