using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB.Models;

namespace movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarsinsController : ControllerBase
    {
        private readonly moviesContext _context;

        public StarsinsController(moviesContext context)
        {
            _context = context;
        }

        // GET: api/Starsins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Starsin>>> GetStarsin()
        {
            return await _context.Starsin.ToListAsync();
        }

        // GET: api/Starsins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Starsin>> GetStarsin(string id)
        {
            var starsin = await _context.Starsin.FindAsync(id);

            if (starsin == null)
            {
                return NotFound();
            }

            return starsin;
        }

        // PUT: api/Starsins/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarsin(string id, Starsin starsin)
        {
            if (id != starsin.Movietitle)
            {
                return BadRequest();
            }

            _context.Entry(starsin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarsinExists(id))
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

        // POST: api/Starsins
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Starsin>> PostStarsin(Starsin starsin)
        {
            _context.Starsin.Add(starsin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StarsinExists(starsin.Movietitle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStarsin", new { id = starsin.Movietitle }, starsin);
        }

        // DELETE: api/Starsins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Starsin>> DeleteStarsin(string id)
        {
            var starsin = await _context.Starsin.FindAsync(id);
            if (starsin == null)
            {
                return NotFound();
            }

            _context.Starsin.Remove(starsin);
            await _context.SaveChangesAsync();

            return starsin;
        }

        private bool StarsinExists(string id)
        {
            return _context.Starsin.Any(e => e.Movietitle == id);
        }
    }
}
