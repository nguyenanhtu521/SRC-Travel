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
    public class AgeGroupsController : ControllerBase
    {
        private readonly DbConnection _context;

        public AgeGroupsController(DbConnection context)
        {
            _context = context;
        }

        // GET: api/AgeGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgeGroup>>> GetAgeGroups()
        {
          if (_context.AgeGroups == null)
          {
              return NotFound();
          }
            return await _context.AgeGroups.ToListAsync();
        }

        // GET: api/AgeGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgeGroup>> GetAgeGroup(int id)
        {
          if (_context.AgeGroups == null)
          {
              return NotFound();
          }
            var ageGroup = await _context.AgeGroups.FindAsync(id);

            if (ageGroup == null)
            {
                return NotFound();
            }

            return ageGroup;
        }

        // PUT: api/AgeGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgeGroup(int id, AgeGroup ageGroup)
        {
            if (id != ageGroup.AgeGroupID)
            {
                return BadRequest();
            }

            _context.Entry(ageGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeGroupExists(id))
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

        // POST: api/AgeGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgeGroup>> PostAgeGroup(AgeGroup ageGroup)
        {
          if (_context.AgeGroups == null)
          {
              return Problem("Entity set 'DbConnection.AgeGroups'  is null.");
          }
            _context.AgeGroups.Add(ageGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgeGroup", new { id = ageGroup.AgeGroupID }, ageGroup);
        }

        // DELETE: api/AgeGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgeGroup(int id)
        {
            if (_context.AgeGroups == null)
            {
                return NotFound();
            }
            var ageGroup = await _context.AgeGroups.FindAsync(id);
            if (ageGroup == null)
            {
                return NotFound();
            }

            _context.AgeGroups.Remove(ageGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgeGroupExists(int id)
        {
            return (_context.AgeGroups?.Any(e => e.AgeGroupID == id)).GetValueOrDefault();
        }
    }
}
