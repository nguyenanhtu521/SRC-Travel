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
    public class BusTypesController : ControllerBase
    {
        private readonly DbConnection _context;

        public BusTypesController(DbConnection context)
        {
            _context = context;
        }

        // GET: api/BusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusType>>> GetBusType()
        {
          if (_context.BusType == null)
          {
              return NotFound();
          }
            return await _context.BusType.ToListAsync();
        }

        // GET: api/BusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusType>> GetBusType(int id)
        {
          if (_context.BusType == null)
          {
              return NotFound();
          }
            var busType = await _context.BusType.FindAsync(id);

            if (busType == null)
            {
                return NotFound();
            }

            return busType;
        }

        // PUT: api/BusTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusType(int id, BusType busType)
        {
            if (id != busType.BusTypeID)
            {
                return BadRequest();
            }

            _context.Entry(busType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusTypeExists(id))
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

        // POST: api/BusTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusType>> PostBusType(BusType busType)
        {
          if (_context.BusType == null)
          {
              return Problem("Entity set 'DbConnection.BusType'  is null.");
          }
            _context.BusType.Add(busType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusType", new { id = busType.BusTypeID }, busType);
        }

        // DELETE: api/BusTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusType(int id)
        {
            if (_context.BusType == null)
            {
                return NotFound();
            }
            var busType = await _context.BusType.FindAsync(id);
            if (busType == null)
            {
                return NotFound();
            }

            _context.BusType.Remove(busType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusTypeExists(int id)
        {
            return (_context.BusType?.Any(e => e.BusTypeID == id)).GetValueOrDefault();
        }
    }
}
