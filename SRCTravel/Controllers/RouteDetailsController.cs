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
    public class RouteDetailsController : ControllerBase
    {
        private readonly DbConnection _context;

        public RouteDetailsController(DbConnection context)
        {
            _context = context;
        }

        // GET: api/RouteDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteDetails>>> GetRouteDetails()
        {
            if (_context.RouteDetails == null)
            {
                return NotFound();
            }
            return await _context.RouteDetails.ToListAsync();
        }

        // GET: api/RouteDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteDetails>> GetRouteDetails(int id)
        {
            if (_context.RouteDetails == null)
            {
                return NotFound();
            }
            var routeDetails = await _context.RouteDetails.FindAsync(id);

            if (routeDetails == null)
            {
                return NotFound();
            }

            return routeDetails;
        }

        // PUT: api/RouteDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteDetails(int id, RouteDetails routeDetails)
        {
            if (id != routeDetails.RouteDetailID)
            {
                return BadRequest();
            }

            _context.Entry(routeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteDetailsExists(id))
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

        // POST: api/RouteDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RouteDetails>> PostRouteDetails(RouteDetails routeDetails)
        {
            if (_context.RouteDetails == null)
            {
                return Problem("Entity set 'DbConnection.RouteDetails'  is null.");
            }
            _context.RouteDetails.Add(routeDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRouteDetails", new { id = routeDetails.RouteDetailID }, routeDetails);
        }

        // DELETE: api/RouteDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteDetails(int id)
        {
            if (_context.RouteDetails == null)
            {
                return NotFound();
            }
            var routeDetails = await _context.RouteDetails.FindAsync(id);
            if (routeDetails == null)
            {
                return NotFound();
            }

            _context.RouteDetails.Remove(routeDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteDetailsExists(int id)
        {
            return (_context.RouteDetails?.Any(e => e.RouteDetailID == id)).GetValueOrDefault();
        }
    }
}
