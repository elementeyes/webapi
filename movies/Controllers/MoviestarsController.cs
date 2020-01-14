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
    public class MoviestarsController : ControllerBase
    {
        private readonly moviesContext _context;

        public MoviestarsController(moviesContext context)
        {
            _context = context;
        }

        // GET: api/Moviestars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moviestar>>> GetMoviestar()
        {
            return await _context.Moviestar.ToListAsync();
        }

        // GET: api/Moviestars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moviestar>> GetMoviestar(string id)
        {
            var moviestar = await _context.Moviestar.FindAsync(id);

            if (moviestar == null)
            {
                return NotFound();
            }

            return moviestar;
        }

        // PUT: api/Moviestars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviestar(string id, Moviestar moviestar)
        {
            if (id != moviestar.Name)
            {
                return BadRequest();
            }

            _context.Entry(moviestar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviestarExists(id))
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

        // POST: api/Moviestars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Moviestar>> PostMoviestar(Moviestar moviestar)
        {
            _context.Moviestar.Add(moviestar);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MoviestarExists(moviestar.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMoviestar", new { id = moviestar.Name }, moviestar);
        }

        // DELETE: api/Moviestars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Moviestar>> DeleteMoviestar(string id)
        {
            var moviestar = await _context.Moviestar.FindAsync(id);
            if (moviestar == null)
            {
                return NotFound();
            }

            _context.Moviestar.Remove(moviestar);
            await _context.SaveChangesAsync();

            return moviestar;
        }

        private bool MoviestarExists(string id)
        {
            return _context.Moviestar.Any(e => e.Name == id);
        }
    }
}
