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
    public class MChannelHashesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MChannelHashesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MChannelHashes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MChannelHash>>> GetMChannelHashes()
        {
            return await _context.MChannelHashes.ToListAsync();
        }

        // GET: api/MChannelHashes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MChannelHash>> GetMChannelHash(int id)
        {
            var mChannelHash = await _context.MChannelHashes.FindAsync(id);

            if (mChannelHash == null)
            {
                return NotFound();
            }

            return mChannelHash;
        }

        // PUT: api/MChannelHashes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMChannelHash(int id, MChannelHash mChannelHash)
        {
            if (id != mChannelHash.ChannelHashId)
            {
                return BadRequest();
            }

            _context.Entry(mChannelHash).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MChannelHashExists(id))
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

        // POST: api/MChannelHashes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MChannelHash>> PostMChannelHash(MChannelHash mChannelHash)
        {
            _context.MChannelHashes.Add(mChannelHash);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMChannelHash", new { id = mChannelHash.ChannelHashId }, mChannelHash);
        }

        // DELETE: api/MChannelHashes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMChannelHash(int id)
        {
            var mChannelHash = await _context.MChannelHashes.FindAsync(id);
            if (mChannelHash == null)
            {
                return NotFound();
            }

            _context.MChannelHashes.Remove(mChannelHash);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MChannelHashExists(int id)
        {
            return _context.MChannelHashes.Any(e => e.ChannelHashId == id);
        }
    }
}
