using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FDW.Data;
using FDW.Models;

namespace FDW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasAPIController : ControllerBase
    {
        private readonly FDWContext _context;

        public BodegasAPIController(FDWContext context)
        {
            _context = context;
        }

        // GET: api/BodegasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodega()
        {
            return await _context.Bodega.ToListAsync();
        }

        // GET: api/BodegasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bodega>> GetBodega(int id)
        {
            var bodega = await _context.Bodega.FindAsync(id);

            if (bodega == null)
            {
                return NotFound();
            }

            return bodega;
        }

        // PUT: api/BodegasAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodega(int id, Bodega bodega)
        {
            if (id != bodega.Id)
            {
                return BadRequest();
            }

            _context.Entry(bodega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodegaExists(id))
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

        // POST: api/BodegasAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bodega>> PostBodega(Bodega bodega)
        {
            _context.Bodega.Add(bodega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBodega", new { id = bodega.Id }, bodega);
        }

        // DELETE: api/BodegasAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bodega>> DeleteBodega(int id)
        {
            var bodega = await _context.Bodega.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }

            _context.Bodega.Remove(bodega);
            await _context.SaveChangesAsync();

            return bodega;
        }

        private bool BodegaExists(int id)
        {
            return _context.Bodega.Any(e => e.Id == id);
        }
    }
}
