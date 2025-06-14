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
    public class MCarrierCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MCarrierCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MCarrierCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MCarrierCode>>> GetMCarrierCode()
        {
            return await _context.MCarrierCode.ToListAsync();
        }

        // GET: api/MCarrierCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MCarrierCode>> GetMCarrierCode(int id)
        {
            var mCarrierCode = await _context.MCarrierCode.FindAsync(id);

            if (mCarrierCode == null)
            {
                return NotFound();
            }

            return mCarrierCode;
        }

        // PUT: api/MCarrierCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMCarrierCode(int id, MCarrierCode mCarrierCode)
        {
            if (id != mCarrierCode.CarrierID)
            {
                return BadRequest();
            }

            _context.Entry(mCarrierCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCarrierCodeExists(id))
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

        // POST: api/MCarrierCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MCarrierCode>> PostMCarrierCode(MCarrierCode mCarrierCode)
        {
            _context.MCarrierCode.Add(mCarrierCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMCarrierCode", new { id = mCarrierCode.CarrierID }, mCarrierCode);
        }

        // DELETE: api/MCarrierCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMCarrierCode(int id)
        {
            var mCarrierCode = await _context.MCarrierCode.FindAsync(id);
            if (mCarrierCode == null)
            {
                return NotFound();
            }

            _context.MCarrierCode.Remove(mCarrierCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MCarrierCodeExists(int id)
        {
            return _context.MCarrierCode.Any(e => e.CarrierID == id);
        }
    }
}
