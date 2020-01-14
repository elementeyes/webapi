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
    public class MovieexecsController : ControllerBase
    {
        private readonly moviesContext _context;

        public MovieexecsController(moviesContext context)
        {
            _context = context;
        }

        // GET: api/Movieexecs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movieexec>>> GetMovieexec()
        {
            return await _context.Movieexec.ToListAsync();
        }

        // GET: api/Movieexecs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movieexec>> GetMovieexec(int id)
        {
            var movieexec = await _context.Movieexec.FindAsync(id);

            if (movieexec == null)
            {
                return NotFound();
            }

            return movieexec;
        }

        // PUT: api/Movieexecs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieexec(int id, Movieexec movieexec)
        {
            if (id != movieexec.Cert)
            {
                return BadRequest();
            }

            _context.Entry(movieexec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieexecExists(id))
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

        // POST: api/Movieexecs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Movieexec>> PostMovieexec(Movieexec movieexec)
        {
            _context.Movieexec.Add(movieexec);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieexecExists(movieexec.Cert))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieexec", new { id = movieexec.Cert }, movieexec);
        }

        // DELETE: api/Movieexecs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movieexec>> DeleteMovieexec(int id)
        {
            var movieexec = await _context.Movieexec.FindAsync(id);
            if (movieexec == null)
            {
                return NotFound();
            }

            _context.Movieexec.Remove(movieexec);
            await _context.SaveChangesAsync();

            return movieexec;
        }

        private bool MovieexecExists(int id)
        {
            return _context.Movieexec.Any(e => e.Cert == id);
        }
    }
}
