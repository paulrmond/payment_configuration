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
    public class MChannelDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MChannelDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MChannelDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MChannelDetail>>> GetChannelDetails()
        {
            return await _context.ChannelDetails.ToListAsync();
        }

        // GET: api/MChannelDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MChannelDetail>> GetMChannelDetail(int id)
        {
            var mChannelDetail = await _context.ChannelDetails.FindAsync(id);

            if (mChannelDetail == null)
            {
                return NotFound();
            }

            return mChannelDetail;
        }

        // PUT: api/MChannelDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMChannelDetail(int id, MChannelDetail mChannelDetail)
        {
            if (id != mChannelDetail.ChannelDetailId)
            {
                return BadRequest();
            }

            _context.Entry(mChannelDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MChannelDetailExists(id))
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

        // POST: api/MChannelDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MChannelDetail>> PostMChannelDetail(MChannelDetail mChannelDetail)
        {
            _context.ChannelDetails.Add(mChannelDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMChannelDetail", new { id = mChannelDetail.ChannelDetailId }, mChannelDetail);
        }

        // DELETE: api/MChannelDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMChannelDetail(int id)
        {
            var mChannelDetail = await _context.ChannelDetails.FindAsync(id);
            if (mChannelDetail == null)
            {
                return NotFound();
            }

            _context.ChannelDetails.Remove(mChannelDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MChannelDetailExists(int id)
        {
            return _context.ChannelDetails.Any(e => e.ChannelDetailId == id);
        }
    }
}
