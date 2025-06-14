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
    public class MCultureCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MCultureCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MCultureCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCultureCode>>> GetMCultureCode()
        {
            return await _context.MCultureCode.ToListAsync();
        }

        // GET: api/MCultureCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCultureCode>> GetMCultureCode(int id)
        {
            var mCultureCode = await _context.MCultureCode.FindAsync(id);

            if (mCultureCode == null)
            {
                return NotFound();
            }

            return mCultureCode;
        }

        // PUT: api/MCultureCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCultureCode(int id, MCultureCode mCultureCode)
        {
            if (id != mCultureCode.CultureID)
            {
                return BadRequest();
            }

            _context.Entry(mCultureCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCultureCodeExists(id))
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

        // POST: api/MCultureCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MCultureCode>> PostMCultureCode(MCultureCode mCultureCode)
        {
            _context.MCultureCode.Add(mCultureCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCultureCode", new { id = mCultureCode.CultureID }, mCultureCode);
        }

        // DELETE: api/MCultureCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCultureCode(int id)
        {
            var mCultureCode = await _context.MCultureCode.FindAsync(id);
            if (mCultureCode == null)
            {
                return NotFound();
            }

            _context.MCultureCode.Remove(mCultureCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MCultureCodeExists(int id)
        {
            return _context.MCultureCode.Any(e => e.CultureID == id);
        }
    }
}
