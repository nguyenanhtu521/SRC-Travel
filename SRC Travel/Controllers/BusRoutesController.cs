using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRC_Travel.Data;
using SRC_Travel.Models;

namespace SRC_Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRoutesController : ControllerBase
    {
        private readonly DbConnection _context;

        public BusRoutesController(DbConnection context)
        {
            _context = context;
        }

        // GET: api/BusRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusRoutes>>> GetBusRoutes()
        {
          if (_context.BusRoutes == null)
          {
              return NotFound();
          }
            return await _context.BusRoutes.ToListAsync();
        }

        // GET: api/BusRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusRoutes>> GetBusRoutes(int id)
        {
          if (_context.BusRoutes == null)
          {
              return NotFound();
          }
            var busRoutes = await _context.BusRoutes.FindAsync(id);

            if (busRoutes == null)
            {
                return NotFound();
            }

            return busRoutes;
        }

        // PUT: api/BusRoutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusRoutes(int id, BusRoutes busRoutes)
        {
            if (id != busRoutes.BusRouteID)
            {
                return BadRequest();
            }

            _context.Entry(busRoutes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusRoutesExists(id))
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

        // POST: api/BusRoutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusRoutes>> PostBusRoutes(BusRoutes busRoutes)
        {
          if (_context.BusRoutes == null)
          {
              return Problem("Entity set 'DbConnection.BusRoutes'  is null.");
          }
            _context.BusRoutes.Add(busRoutes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusRoutes", new { id = busRoutes.BusRouteID }, busRoutes);
        }

        // DELETE: api/BusRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusRoutes(int id)
        {
            if (_context.BusRoutes == null)
            {
                return NotFound();
            }
            var busRoutes = await _context.BusRoutes.FindAsync(id);
            if (busRoutes == null)
            {
                return NotFound();
            }

            _context.BusRoutes.Remove(busRoutes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusRoutesExists(int id)
        {
            return (_context.BusRoutes?.Any(e => e.BusRouteID == id)).GetValueOrDefault();
        }
    }
}
