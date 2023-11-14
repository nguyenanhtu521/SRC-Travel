using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRCTravel.Data;
using SRCTravel.Models;

namespace SRCTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly DbConnection _context;

        public BusesController(DbConnection context)
        {
            _context = context;
        }

        // GET: api/Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buses>>> GetBuses()
        {
            if (_context.Buses == null)
            {
                return NotFound();
            }
            return await _context.Buses.ToListAsync();
        }

        // GET: api/Buses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buses>> GetBuses(int id)
        {
            if (_context.Buses == null)
            {
                return NotFound();
            }
            var buses = await _context.Buses.FindAsync(id);

            if (buses == null)
            {
                return NotFound();
            }

            return buses;
        }

        // PUT: api/Buses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuses(int id, Buses buses)
        {
            if (id != buses.BusID)
            {
                return BadRequest();
            }

            _context.Entry(buses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusesExists(id))
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

        // POST: api/Buses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buses>> PostBuses(Buses buses)
        {
            if (_context.Buses == null)
            {
                return Problem("Entity set 'DbConnection.Buses'  is null.");
            }
            _context.Buses.Add(buses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuses", new { id = buses.BusID }, buses);
        }

        // DELETE: api/Buses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuses(int id)
        {
            if (_context.Buses == null)
            {
                return NotFound();
            }
            var buses = await _context.Buses.FindAsync(id);
            if (buses == null)
            {
                return NotFound();
            }

            _context.Buses.Remove(buses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusesExists(int id)
        {
            return (_context.Buses?.Any(e => e.BusID == id)).GetValueOrDefault();
        }
    }
}
