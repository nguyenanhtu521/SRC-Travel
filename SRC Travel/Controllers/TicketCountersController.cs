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
    [Route("Api/[Controller]/[Action]")]
    [ApiController]
    public class TicketCountersController : ControllerBase
    {
        private readonly DbConnection _context;

        public TicketCountersController(DbConnection context)
        {
            _context = context;
        }

        // GET: api/TicketCounters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketCounter>>> GetTicketCounters()
        {
          if (_context.TicketCounters == null)
          {
              return NotFound();
          }
            return await _context.TicketCounters.ToListAsync();
        }

        // GET: api/TicketCounters/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TicketCounter>> GetTicketCounter(int id)
        {
          if (_context.TicketCounters == null)
          {
              return NotFound();
          }
            var ticketCounter = await _context.TicketCounters.FindAsync(id);

            if (ticketCounter == null)
            {
                return NotFound();
            }

            return ticketCounter;
        }

        // PUT: api/TicketCounters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<TicketCounter>> PutTicketCounter(int id, TicketCounter ticketCounter)
        {
            if (id != ticketCounter.TicketCounterID)
            {
                return BadRequest();
            }

            _context.Entry(ticketCounter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketCounterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Tìm lại dữ liệu đã cập nhật và trả về nó
            var updatedTicketCounter = await _context.TicketCounters.FindAsync(id);

            if (updatedTicketCounter == null)
            {
                return NotFound();
            }

            return Ok(updatedTicketCounter);
        }


        // POST: api/TicketCounters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketCounter>> PostTicketCounter(TicketCounter ticketCounter)
        {
          if (_context.TicketCounters == null)
          {
              return Problem("Entity set 'DbConnection.TicketCounters'  is null.");
          }
            _context.TicketCounters.Add(ticketCounter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketCounter", new { id = ticketCounter.TicketCounterID }, ticketCounter);
        }

        // DELETE: api/TicketCounters/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTicketCounter(int id)
        {
            if (_context.TicketCounters == null)
            {
                return NotFound();
            }
            var ticketCounter = await _context.TicketCounters.FindAsync(id);
            if (ticketCounter == null)
            {
                return NotFound();
            }

            _context.TicketCounters.Remove(ticketCounter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketCounterExists(int id)
        {
            return (_context.TicketCounters?.Any(e => e.TicketCounterID == id)).GetValueOrDefault();
        }
    }
}
