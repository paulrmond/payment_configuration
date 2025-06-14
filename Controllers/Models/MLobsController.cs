using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentOptions.Data;
using PaymentOptions.Model;

namespace PaymentOptions.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class MLobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MLobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MLobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MLob>>> GetMLobs()
        {
            return await _context.MLobs.ToListAsync();
        }

        // GET: api/MLobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MLob>> GetMLob(int id)
        {
            var mLob = await _context.MLobs.FindAsync(id);

            if (mLob == null)
            {
                return NotFound();
            }

            return mLob;
        }

        // PUT: api/MLobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMLob(int id, MLob mLob)
        {
            if (id != mLob.LobId)
            {
                return BadRequest();
            }

            _context.Entry(mLob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MLobExists(id))
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

        // POST: api/MLobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MLob>> PostMLob(MLob mLob)
        {
            _context.MLobs.Add(mLob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMLob", new { id = mLob.LobId }, mLob);
        }

        // DELETE: api/MLobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMLob(int id)
        {
            var mLob = await _context.MLobs.FindAsync(id);
            if (mLob == null)
            {
                return NotFound();
            }

            _context.MLobs.Remove(mLob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MLobExists(int id)
        {
            return _context.MLobs.Any(e => e.LobId == id);
        }
    }
}
