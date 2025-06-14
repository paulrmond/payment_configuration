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
    public class MCurrencyCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MCurrencyCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MCurrencyCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCurrencyCode>>> GetMCurrencyCode()
        {
            return await _context.MCurrencyCode.ToListAsync();
        }

        // GET: api/MCurrencyCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCurrencyCode>> GetMCurrencyCode(int id)
        {
            var mCurrencyCode = await _context.MCurrencyCode.FindAsync(id);

            if (mCurrencyCode == null)
            {
                return NotFound();
            }

            return mCurrencyCode;
        }

        // PUT: api/MCurrencyCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCurrencyCode(int id, MCurrencyCode mCurrencyCode)
        {
            if (id != mCurrencyCode.CurrencyID)
            {
                return BadRequest();
            }

            _context.Entry(mCurrencyCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCurrencyCodeExists(id))
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

        // POST: api/MCurrencyCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MCurrencyCode>> PostMCurrencyCode(MCurrencyCode mCurrencyCode)
        {
            _context.MCurrencyCode.Add(mCurrencyCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCurrencyCode", new { id = mCurrencyCode.CurrencyID }, mCurrencyCode);
        }

        // DELETE: api/MCurrencyCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCurrencyCode(int id)
        {
            var mCurrencyCode = await _context.MCurrencyCode.FindAsync(id);
            if (mCurrencyCode == null)
            {
                return NotFound();
            }

            _context.MCurrencyCode.Remove(mCurrencyCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MCurrencyCodeExists(int id)
        {
            return _context.MCurrencyCode.Any(e => e.CurrencyID == id);
        }
    }
}
