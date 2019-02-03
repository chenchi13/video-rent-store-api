using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoRentStore.API.Models;

namespace VideoRentStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class RentsController : ControllerBase
    {
        private readonly VideoRentStoreDBContext _context;

        public RentsController(VideoRentStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Rents
        [HttpGet]
        public IEnumerable<Rent> GetRents()
        {
            return _context.Rents.Include("Movie").Include("Customer").ToList();
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rent = await _context.Rents.FindAsync(id);

            if (rent == null)
            {
                return NotFound();
            }

            return Ok(rent);
        }

        // PUT: api/Rents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent([FromRoute] int id, [FromBody] Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rent.IdRent)
            {
                return BadRequest();
            }

            _context.Entry(rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rents
        [HttpPost]
        public async Task<IActionResult> PostRent([FromBody] Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Rents.Add(rent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRent", new { id = rent.IdRent }, rent);
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();

            return Ok(rent);
        }

        private bool RentExists(int id)
        {
            return _context.Rents.Any(e => e.IdRent == id);
        }
    }
}