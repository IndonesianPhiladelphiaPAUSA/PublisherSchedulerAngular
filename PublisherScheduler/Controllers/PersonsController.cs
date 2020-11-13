using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherScheduler.Helpers;
using PublisherScheduler.Models;

namespace PublisherScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly SchedulerContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ICommon _common;

        public PersonsController(SchedulerContext context, IWebHostEnvironment hostEnvironment, ICommon common)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _common = common;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persons>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persons>> GetPersons(int id)
        {
            var persons = await _context.Persons.FindAsync(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersons(int id, Persons persons)
        {
            if (id != persons.Id)
            {
                return BadRequest();
            }

            _context.Entry(persons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonsExists(id))
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

        // POST: api/Persons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Persons>> PostPersons(Persons persons)
        {
            _context.Persons.Add(persons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersons", new { id = persons.Id }, persons);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persons>> DeletePersons(int id)
        {
            var persons = await _context.Persons.FindAsync(id);
            if (persons == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(persons);
            await _context.SaveChangesAsync();

            return persons;
        }

        [HttpPost]
        [Route("SaveFile")]
        public async Task<string> SaveFile(IFormFile formFile)
        {
            return await _common.SaveFileAsync(formFile);
        }

        [HttpGet]
        [Route("GetAllCapacityNames")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllCapacityNames()
        {
            return await _context.Capacities.Select(c => c.Name).ToListAsync();
        }

        private bool PersonsExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }


    }
}
